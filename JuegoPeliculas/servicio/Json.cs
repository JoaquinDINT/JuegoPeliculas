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
            string peliculasJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista)
        {
            string peliculasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", peliculasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista, string path)
        {
            string peliculasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText(path, peliculasJson);
        }
    }
}
