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
using System.Windows.Shapes;

namespace JuegoPeliculas.dialogs
{
    /// <summary>
    /// Lógica de interacción para AñadirPeli.xaml
    /// </summary>
    public partial class AñadirPeli : Window
    {
        
        public AñadirPeli()
        {
            InitializeComponent();
        }

        private void AceptarClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).AceptarAñadirPelicula(this);
        }

        private void CancelarClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).CancelarAñadirPelicula(this);
        }

        private void ExaminarClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).ExaminarAñadirPelicula();
        }
    }
}
