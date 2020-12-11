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

namespace edfWPF
{
    /// <summary>
    /// Logique d'interaction pour frmControleur.xaml
    /// </summary>
    public partial class frmControleur : Window
    {
        edfEntities gst;
        public frmControleur(edfEntities gstBDD)
        {
            InitializeComponent();
            gst = gstBDD;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstClientControleur.ItemsSource = from c in gst.client.ToList()
                                              where gst.controleur.ToList().Find()
        }

        private void btnInsererReleve_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
