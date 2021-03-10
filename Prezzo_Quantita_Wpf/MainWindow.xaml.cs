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

namespace Prezzo_Quantita_Wpf
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMostra_Click(object sender, RoutedEventArgs e)
        {
            if (txtPrezzo.Text != "" && txtQuantita.Text != "")
            {
                try
                {
                    double sconto;
                    if (txtSconto.Text != "")
                    {
                        sconto = double.Parse(txtSconto.Text);
                    }
                    else
                        sconto = 0;
                    double p = double.Parse(txtPrezzo.Text);
                    int q = int.Parse(txtQuantita.Text);
                    double tot = p * q;
                    if (sconto < 0 || sconto > 100)
                    {
                        MessageBox.Show("Sconto non valido", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (q >= 20)
                    {
                        double ScontoTot = tot / 100;
                        double ScontoM = ScontoTot * sconto;
                        double ScontoS = tot - ScontoM;
                        lblStampa.Content = ScontoS;
                    }
                    else if (sconto == 0)
                        lblStampa.Content = tot;

                }
                catch (Exception ex)
                {
                    lblStampa.Content = ex.Message;
                }
            }
            else
            {
                MessageBox.Show("Dati non corretti", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
