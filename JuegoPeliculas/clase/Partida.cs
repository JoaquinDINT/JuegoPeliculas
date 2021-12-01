using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JuegoPeliculas.clase
{
    class Partida : ObservableObject
    {
        private ObservableCollection<Pelicula> _listaPeliculas;

        public ObservableCollection<Pelicula> ListaPeliculas
        {
            get => _listaPeliculas;
            set => _ = SetProperty(ref _listaPeliculas, value);
        }

        private int _puntuacion;

        public int Puntuacion
        {
            get => _puntuacion;
            set => _ = SetProperty(ref _puntuacion, value);
        }



    }
}
