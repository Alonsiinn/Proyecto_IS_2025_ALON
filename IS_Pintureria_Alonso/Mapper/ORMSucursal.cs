using Acceso_Datos;
using Dominio;
using Interface;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapper
{
    public class ORMSucursal : iCrud<Sucursal>
    {
        private SucursalDAL sucursalDAL;
        public ORMSucursal()
        {
            sucursalDAL = new SucursalDAL();
        }

        public void Add(Sucursal sucursal)
        {
            int newId = sucursalDAL.Insertar(sucursal.Nombre, sucursal.Direccion, sucursal.Ciudad);
            if (newId > 0)
            {
                sucursal.IdSucursal = newId;
            }
        }

        public void Delete(Sucursal sucursal)
        {
            sucursalDAL.Eliminar(sucursal.IdSucursal);
        }

        public List<Sucursal> DevolverTodos()
        {
            DataTable dt = sucursalDAL.ListarTodas();
            List<Sucursal> sucursales = new List<Sucursal>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Sucursal sucursal = new Sucursal();
                    sucursal.IdSucursal = (int)row["IdSucursal"];
                    sucursal.Nombre = (string)row["Nombre"];
                    sucursal.Direccion = (string)row["Direccion"];
                    sucursal.Ciudad =  (string)row["Ciudad"];
                    sucursales.Add(sucursal);
                }
            }
            return sucursales;
        }

        public bool Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public Sucursal GetByID(int id)
        {
            DataTable dt = sucursalDAL.ObtenerPorId(id);
            Sucursal suc = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                suc = new Sucursal();
                suc.IdSucursal = (int)row["IdSucursal"];
                suc.Nombre = (string)row["Nombre"];
                suc.Direccion = (string)row["Direccion"];
                suc.Ciudad = (string)row["Ciudad"];
            }
            return suc;
        }
        

        public void Update(Sucursal sucursal)
        {
            sucursalDAL.Actualizar(sucursal.IdSucursal, sucursal.Nombre, sucursal.Direccion, sucursal.Ciudad);
        }
    }
}
