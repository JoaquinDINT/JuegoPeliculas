﻿using Microsoft.Win32;

namespace JuegoPeliculas.servicio
{
    public static class Dialogo
    {
        public static string AbrirJson()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 0
            };
            string filename = "";

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
            }
            return filename;
        }

        public static string AbrirImagen()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*",
                FilterIndex = 0
            };
            string filename = "";

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
            }
            return filename;
        }

        public static string GuardarJson()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 0
            };
            string filename = "";

            if (sfd.ShowDialog() == true)
            {
                filename = sfd.FileName;
            }

            return filename;
        }
    }
}
