using JuegoPeliculas.clase;
using JuegoPeliculas.dialogs;
using JuegoPeliculas.servicio;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    internal class MainWindowVM : ObservableObject
    {
        public MainWindowVM()
        {
            PeliculaActual = new Pelicula();
            PeliculaNueva = new Pelicula();
            ListaDificultades = new List<string> { "Fácil", "Media", "Difícil" };
            ListaGeneros = new List<string> { "Comedia", "Drama", "Acción", "Terror","Ciencia-Ficción" };
            ListaPeliculas = Json.CargarPeliculasJson(Dialogo.AbrirJson());
        }

        private ObservableCollection<Pelicula> _listaPeliculas;

        public ObservableCollection<Pelicula> ListaPeliculas
        {
            get => _listaPeliculas;
            set => _ = SetProperty(ref _listaPeliculas, value);
        }

        private Pelicula _peliculaActual;

        public Pelicula PeliculaActual
        {
            get => _peliculaActual;
            set
            {
                if (value != _peliculaActual)
                {
                    _ = SetProperty(ref _peliculaActual, value);
                }
            }
        }

        private List<String> _listaDificultades;

        public List<String> ListaDificultades
        {
            get => _listaDificultades;
            set
            {
                if (value != _listaDificultades)
                {
                    _ = SetProperty(ref _listaDificultades, value);
                }
            }
        }


        private List<String> _listaGeneros;

        public List<String> ListaGeneros
        {
            get => _listaGeneros;
            set
            {
                if (value != _listaGeneros)
                {
                    _ = SetProperty(ref _listaGeneros, value);
                }
            }
        }

        private Pelicula _peliculaNueva;

        public Pelicula PeliculaNueva
        {
            get => _peliculaNueva;
            set
            {
                if (value != _peliculaNueva)
                {
                    _ = SetProperty(ref _peliculaNueva, value);
                }
            }
        }

        public void CargarPeliculas()
        {
            ListaPeliculas = Json.CargarPeliculasJson(Dialogo.AbrirJson());
        }
        public void AñadirPelicula()
        {
            AñadirPeli AñadirDialogo = new AñadirPeli
            {
                DataContext = this
            };

            if (AñadirDialogo.ShowDialog() == true)
            {
                ListaPeliculas.Add(PeliculaNueva);
                PeliculaNueva = new Pelicula();

                foreach (Pelicula pel in ListaPeliculas)
                {
                    Console.WriteLine(pel.Titulo);
                }
            }
        }

        public void AceptarAñadirPelicula(AñadirPeli ap)
        {
            ap.DialogResult = true;
        }

        public void CancelarAñadirPelicula(AñadirPeli ap)
        {
            ap.DialogResult = false;
            PeliculaNueva = new Pelicula();
        }
    }
}
