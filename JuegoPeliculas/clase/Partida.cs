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

        private bool _pistaMostrada;

        public bool PistaMostrada
        {
            get => _pistaMostrada;
            set => _ = SetProperty(ref _pistaMostrada, value);
        }

        private bool _preguntaRespondida;

        public bool PreguntaRespondida
        {
            get => _preguntaRespondida;
            set => _ = SetProperty(ref _preguntaRespondida, value);
        }


        public List<bool> ListaPistas;
        public List<bool> ListaRespondido;
        public Partida(ObservableCollection<Pelicula> listaPeliculas)
        {
            Puntuacion = 0;
            List<Pelicula> aux = listaPeliculas.Shuffled().ToList();
            PeliculasPartida = new ObservableCollection<Pelicula>();
            ListaPistas = new List<bool>();
            ListaRespondido = new List<bool>();
            Respuesta = "";
            for (int i = 0; i < 5; i++)
            {
                PeliculasPartida.Add(aux[i]);
                ListaPistas.Add(false);
                ListaRespondido.Add(false);
            }

            PeliculaActual = PeliculasPartida[0];
        }
    }
}
