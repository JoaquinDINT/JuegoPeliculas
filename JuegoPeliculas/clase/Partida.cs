using Medallion;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JuegoPeliculas.clase
{
    class Partida : ObservableObject
    {
        private ObservableCollection<Pelicula> _listaPeliculas;

        public ObservableCollection<Pelicula> PeliculasPartida
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

        private Pelicula _peliculaActual;

        public Pelicula PeliculaActual
        {
            get => _peliculaActual;
            set => _ = SetProperty(ref _peliculaActual, value);
        }

        private string _respuesta;

        public string Respuesta
        {
            get => _respuesta;
            set => _ = SetProperty(ref _respuesta, value);
        }

        public Partida(ObservableCollection<Pelicula> listaPeliculas)
        {
            Puntuacion = 0;
            List<Pelicula> aux = listaPeliculas.Shuffled().ToList();
            PeliculasPartida = new ObservableCollection<Pelicula>();
            for(int i = 0; i < 5; i++)
            {
                PeliculasPartida.Add(aux[i]);
            }

            PeliculaActual = PeliculasPartida[0];
        }
    }
}
