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

namespace edfWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        edfEntities gst;
        public MainWindow()
        {
            InitializeComponent();
            gst = new edfEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            var ctrl = gst.controleur.ToList().Find(c => c.login == txtLogin.Text && c.mdp == txtMdp.Text);
            if (ctrl != null)
            {
                if(ctrl.statut == "admin")
                {
                    frmControleurAdmin frm = new frmControleurAdmin(gst);
                    frm.Show();
                }
                else
                {
                    frmControleur frm = new frmControleur(gst);
                    frm.Show();
                }
            }
            else
            {
                if(txtLogin.Text == "")
                {
                    txtReponse.Text = "Veuillez saisir un login";
                }
                if(txtMdp.Text == "")
                {
                    txtReponse.Text = "Veuillez saisir un mdp";
                }
            }
        }
    }
}
