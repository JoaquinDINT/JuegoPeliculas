using JuegoPeliculas.clase;
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
    class MainWindowVM: ObservableObject
    {

        public MainWindowVM()
        {
            PeliculaActual = new Pelicula("Holy Beasts");
            ListaPeliculas = Json.CargarPeliculasJson(Dialogo.AbrirJson());
        }<

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
    }
}
