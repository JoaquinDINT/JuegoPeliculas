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
            string personasJson = File.ReadAllText("peliculas.json");
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(personasJson);
        }

        public static ObservableCollection<Pelicula> CargarPeliculasJson(string path)
        {
            string personasJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(personasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista)
        {
            string personasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("personas.json", personasJson);
        }

        public static void GuardarPeliculasJson(ObservableCollection<Pelicula> lista, string path)
        {
            string personasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText(path, personasJson);
        }
    }
}
