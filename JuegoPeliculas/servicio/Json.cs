using JuegoPeliculas.clase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas.servicio
{
    static class Json
    {
        
        public static ObservableCollection<Pelicula> CargarPeliculasJson()
        {
            string peliculasJson = File.ReadAllText("peliculas.json");
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        }

        public static ObservableCollection<Pelicula> CargarPeliculasJson(string path)
        {
            string peliculasJson = "";
            try
            {
               peliculasJson = File.ReadAllText(path);
            } catch(ArgumentException)
            {
                Dialogo.Alerta("Por favor selecciona un archivo valido");
            }
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista)
        {
            string peliculasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", peliculasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista, string path)
        {
            try
            {
                string peliculasJson = JsonConvert.SerializeObject(lista);
                File.WriteAllText(path, peliculasJson);
            }
            catch (ArgumentException)
            {
                Dialogo.Alerta("Por favor elige donde quieres guardar tu archivo");
            }
        }
    }
}
