using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas.servicio
{
    class Dialogo
    {
        static string Abrir()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";

            if (result == true)
            {
                // Open document
                filename = dlg.FileName;
            }

            return filename;

        }
    }
}
