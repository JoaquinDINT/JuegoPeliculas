using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace JuegoPeliculas.clase
{
    class Pelicula : ObservableObject
    {
        private string titulo;
        public string Titulo
        {
            get => titulo;
            set => _ = SetProperty(ref titulo, value);
        }

        private string pista;
        public string Pista
        {
            get => pista;
            set => _ = SetProperty(ref pista, value);
        }

        private string cartel;
        public string Cartel
        {
            get => cartel;
            set => _ = SetProperty(ref cartel, value);
        }

        private string nivel;
        public string Nivel
        {
            get => nivel;
            set => _ = SetProperty(ref nivel, value);
        }

        private string genero;

        public string Genero
        {
            get => genero;
            set => _ = SetProperty(ref genero, value);
        }
    }
}

