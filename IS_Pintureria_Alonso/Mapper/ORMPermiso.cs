﻿using Acceso_Datos;
using Dominio;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ORMPermiso : iCrud<IPermisoComponente>
    {
        private PermisoDAL permisoDAL = new PermisoDAL();
        private PermisoComponenteDAL componenteDAL = new PermisoComponenteDAL();

        private DataTable dtPermisos;
        private DataTable dtComponentes;

        public ORMPermiso()
        {
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
        }

        public void Add(IPermisoComponente permiso)
        {
            if (permiso.Id != 0) return;

            int nuevoID = permisoDAL.InsertarPermisoSP(permiso.Nombre, permiso is PermisoCompuesto);
            permiso.Id = nuevoID;

            if (permiso is PermisoCompuesto compuesto)
            {
                foreach (var hijo in compuesto.ObtenerComponentes())
                {
                    Add(hijo); // Recursivo

                    DataRow rel = dtComponentes.NewRow();
                    rel["IdPadre"] = permiso.Id;
                    rel["IdHijo"] = hijo.Id;
                    dtComponentes.Rows.Add(rel);
                }

                componenteDAL.GuardarCambios();
            }
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
            
        }

        public IPermisoComponente GetByID(int id)
        {
            var row = dtPermisos.Rows.Find(id);
            if (row == null) return null;

            string nombre = row["Nombre"].ToString();
            bool esCompuesto = Convert.ToBoolean(row["EsCompuesto"]);

            IPermisoComponente comp = esCompuesto
                ? new PermisoCompuesto(nombre)
                : new PermisoSimple(nombre);

            comp.Id = id;

            if (comp is PermisoCompuesto pc)
                CargarHijos(pc);

            return comp;
        }

        private void CargarHijos(PermisoCompuesto padre)
        {
            foreach (DataRow row in dtComponentes.Select($"IdPadre = {padre.Id}"))
            {
                int idHijo = Convert.ToInt32(row["IdHijo"]);
                var hijo = GetByID(idHijo);
                if (hijo != null)
                    padre.Agregar(hijo);
            }
        }

        public List<IPermisoComponente> DevolverTodos()
        {
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
            List<IPermisoComponente> permisos = new();

            foreach (DataRow row in dtPermisos.Rows)
            {
                int id = Convert.ToInt32(row["IdPermiso"]);
                var comp = GetByID(id);
                permisos.Add(comp);
            }

            return permisos;
        }

        public void Update(IPermisoComponente entity)
        {
            var row = dtPermisos.Rows.Find(entity.Id);
            if (row != null)
            {
                row["Nombre"] = entity.Nombre;
                row["EsCompuesto"] = entity is PermisoCompuesto ? 1 : 0;
                permisoDAL.GuardarCambios();
            }
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
        }

        public void Delete(IPermisoComponente entity)
        {
            var row = dtPermisos.Rows.Find(entity.Id);
            if (row != null)
            {

                foreach (DataRow dr in dtComponentes.Select($"IdPadre = {entity.Id} OR IdHijo = {entity.Id}"))
                    dr.Delete();

                componenteDAL.GuardarCambios();


                row.Delete();
                permisoDAL.GuardarCambios();
            }
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
        }

        public bool Existe(string username)
        {
            throw new NotImplementedException();
        }

        public int RecuperarUltimo()
        {
            if (dtPermisos.Rows.Count == 0) return 0;
            return Convert.ToInt32(dtPermisos.Rows[dtPermisos.Rows.Count - 1]["IdPermiso"]);
        }
        public void AgregarRelacion(int idPadre, int idHijo)
        {
            DataRow rel = dtComponentes.NewRow();
            rel["IdPadre"] = idPadre;
            rel["IdHijo"] = idHijo;
            dtComponentes.Rows.Add(rel);
            componenteDAL.GuardarCambios();
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
        }

        public void EliminarRelacion(int idPadre, int idHijo)
        {
            foreach (DataRow row in dtComponentes.Select($"IdPadre = {idPadre} AND IdHijo = {idHijo}"))
            {
                row.Delete();
            }
            componenteDAL.GuardarCambios();
            dtPermisos = permisoDAL.DevolverDS().Tables["Permisos"];
            dtComponentes = componenteDAL.DevolverDS().Tables["PermisoComponentes"];
        }
    }
}
