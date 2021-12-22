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
            ListaPeliculas = new ObservableCollection<Pelicula>();
            ModoEdicion = false;
            PartidaEnCurso = false;
            contador = 0;
            DisplayContador = "";
        }

        private int contador;
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

        private List<string> _listaDificultades;

        public List<string> ListaDificultades
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

        private bool _modoEdicion;

        public bool ModoEdicion
        {
            get => _modoEdicion;
            set
            {
                if (value != _modoEdicion)
                {
                    _ = SetProperty(ref _modoEdicion, value);
                }
            }
        }

        private List<string> _listaGeneros;

        public List<string> ListaGeneros
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

        private bool _partidaEnCurso;

        public bool PartidaEnCurso
        {
            get => _partidaEnCurso;
            set
            {
                if (value != _partidaEnCurso)
                {
                    _ = SetProperty(ref _partidaEnCurso, value);
                }
            }
        }

        private Partida _partidaActual;

        public Partida PartidaActual
        {
            get => _partidaActual;
            set
            {
                if (value != _partidaActual)
                {
                    _ = SetProperty(ref _partidaActual, value);
                }
            }
        }
        private string _displayContador;

        public string DisplayContador
        {
            get => _displayContador;
            set
            {
                if (value != _displayContador)
                {
                    _ = SetProperty(ref _displayContador, value);
                }
            }
        }


        public void ComenzarPartida()
        {
            if (ListaPeliculas.Count() < 5)
            {
                Dialogo.Alerta("Necesitas al menos 5 peliculas cargadas para comenzar una partida");
            }
            else
            {
                PartidaEnCurso = true;
                PartidaActual = new Partida(ListaPeliculas);
                DisplayContador = "1/5";
            }
        }

        public void TerminarPartida()
        {
            PartidaEnCurso = false;
        }

        public void MostrarPista()
        {
            PartidaActual.PistaMostrada = true;
            PartidaActual.ListaPistas[contador] = true;
        }

        public void ValidarRespuesta()
        {
            if (string.Equals(PartidaActual.PeliculaActual.Titulo.ToLower().Trim(), PartidaActual.Respuesta.ToLower().Trim()) && !PartidaActual.PreguntaRespondida)
            {
                if (PartidaActual.PistaMostrada)
                {
                    switch (PartidaActual.PeliculaActual.Nivel)
                    {
                        case "Fácil":
                            PartidaActual.Puntuacion += 10;
                            break;

                        case "Media":
                            PartidaActual.Puntuacion += 20;
                            break;

                        case "Difícil":
                            PartidaActual.Puntuacion += 30;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (PartidaActual.PeliculaActual.Nivel)
                    {
                        case "Fácil":
                            PartidaActual.Puntuacion += 20;
                            break;

                        case "Media":
                            PartidaActual.Puntuacion += 40;
                            break;

                        case "Difícil":
                            PartidaActual.Puntuacion += 70;
                            break;
                        default:
                            break;
                    }
                }
            }

            PartidaActual.PreguntaRespondida = true;
            PartidaActual.ListaRespondido[contador] = true;
        }

        public void Avanza()
        {
            if (contador < 4 && PartidaEnCurso)
            {
                contador++;
                PartidaActual.PeliculaActual = PartidaActual.PeliculasPartida[contador];
                PartidaActual.PistaMostrada = PartidaActual.ListaPistas[contador];
                PartidaActual.PreguntaRespondida = PartidaActual.ListaRespondido[contador];
                DisplayContador = (contador + 1).ToString() + "/5";
            }
        }

        public void Retrocede()
        {
            if (contador > 0 && PartidaEnCurso)
            {
                contador--;
                PartidaActual.PeliculaActual = PartidaActual.PeliculasPartida[contador];
                PartidaActual.PistaMostrada = PartidaActual.ListaPistas[contador];
                PartidaActual.PreguntaRespondida = PartidaActual.ListaRespondido[contador];
                DisplayContador = (contador + 1).ToString() + "/5";
            }
        }

        public void CargarPeliculas()
        {
            ListaPeliculas = Json.CargarPeliculasJson(Dialogo.AbrirJson());
        }
        public void GuardarPeliculas()
        {
            Json.GuardarPeliculasJson(ListaPeliculas, Dialogo.GuardarJson());
        }

        public void AñadirPelicula()
        {
            AñadirPeli AñadirDialogo = new AñadirPeli
            {
                DataContext = this
            };

            if (AñadirDialogo.ShowDialog() == true)
            {
                if(PeliculaNueva.Genero != null && PeliculaNueva.Cartel != null && PeliculaNueva.Titulo != "" && PeliculaNueva.Nivel != null && PeliculaNueva.Pista != "")
                {
                    ListaPeliculas.Add(PeliculaNueva);
                }
                else
                {
                    Dialogo.Alerta("Rellene todos los campos de la pelicula nueva");
                }
                PeliculaNueva = new Pelicula();
            }
        }


        public void EliminarPelicula()
        {
            _ = ListaPeliculas.Remove(PeliculaActual);
        }

        public void AceptarAñadirPelicula(AñadirPeli ap)
        {
            ap.DialogResult = true;
        }

        public void CancelarAñadirPelicula(AñadirPeli ap)
        {
            ap.DialogResult = false;
        }

        public void AceptarCambios()
        {
            ModoEdicion = false;
        }

        public void ModificarPelicula()
        {
            ModoEdicion = true;
        }

        public void ExaminarAñadirPelicula()
        {
            try
            {
                string ruta = Dialogo.AbrirImagen();
                PeliculaNueva.Cartel = Nube.SubirImagen(ruta);
            }
            catch(Exception)
            {
                Dialogo.Alerta("Error al subir una imagen a la nube");
            }
        }

        public void ExaminarPelicula()
        {
            try
            {
                string ruta = Dialogo.AbrirImagen();
                PeliculaActual.Cartel = Nube.SubirImagen(ruta);
            }
            catch (Exception)
            {
                Dialogo.Alerta("Error al subir una imagen a la nube");
            }
        }
    }
}
