using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Pintureria_Alonso
{
    public partial class FRMDetectarColor : Form
    {
        private Bitmap imagenOriginal;
        public FRMDetectarColor()
        {
            InitializeComponent();
            pictureBoxImagen.MouseMove += pictureBoxImagen_MouseMove;
        }

        private void FRMDetectarColor_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxImagen_MouseMove(object sender, MouseEventArgs e)
        {
            if(imagenOriginal == null)
            {
                return;
            }
            if(e.X >= 0 && e.X < imagenOriginal.Width && e.Y >= 0 && e.Y < imagenOriginal.Height)
            {
                Color color = imagenOriginal.GetPixel(e.X, e.Y);
                lblColorARGB.Text = $"ARGB: {color.A},{color.R},{color.G},{color.B}";
                lblNombreColor.Text = $"{ObtenerNombreColor(color)}";
                panelVistaColor.BackColor = color;
            }
      
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*",
                Title = "Seleccionar imagen"
            };
            if(openfile.ShowDialog() == DialogResult.OK)
            {
                imagenOriginal = new Bitmap(openfile.FileName);
                pictureBoxImagen.Image = imagenOriginal;
                pictureBoxImagen.Size = imagenOriginal.Size;

            }
        }
        private string ObtenerNombreColor(Color color)
        {
            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(knownColor);
                if (known.ToArgb() == color.ToArgb())
                {
                    return knownColor.ToString();
                }

            }
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";

        }

    }
}
