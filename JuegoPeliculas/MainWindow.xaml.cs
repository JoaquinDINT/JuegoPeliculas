using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM vm = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void AñadirPeliculaClick(object sender, RoutedEventArgs e)
        {
            vm.AñadirPelicula();
        }

        private void CargarPeliculasClick(object sender, RoutedEventArgs e)
        {
            vm.CargarPeliculas();
        }

        private void ModificarClick(object sender, RoutedEventArgs e)
        {
            vm.ModificarPelicula();
        }

        private void AceptarClick(object sender, RoutedEventArgs e)
        {
            TituloTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            PistaTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ImagenTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DificultadComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            GeneroComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();

            vm.AceptarCambios();
        }

        private void GuardarPeliculasClick(object sender, RoutedEventArgs e)
        {
            vm.GuardarPeliculas();
        }

        private void ExaminarClick(object sender, RoutedEventArgs e)
        {
            vm.ExaminarPelicula();
        }
        private void EliminarPeliculaClick(object sender, RoutedEventArgs e)
        {
            vm.EliminarPelicula();
        }

        private void ComenzarPartidaClick(object sender, RoutedEventArgs e)
        {
            vm.ComenzarPartida();
        }

        private void TerminarPartidaClick(object sender, RoutedEventArgs e)
        {
            vm.TerminarPartida();
        }
        private void MasClick(object sender, MouseButtonEventArgs e)
        {
            vm.Avanza();
        }

        private void MenosClick(object sender, MouseButtonEventArgs e)
        {
            vm.Retrocede();
        }
    }
}
