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
    /// Logique d'interaction pour frmControleurAdmin.xaml
    /// </summary>
    public partial class frmControleurAdmin : Window
    {
        edfEntities gst;
        public frmControleurAdmin(edfEntities gstBDD)
        {
            InitializeComponent();
            gst = gstBDD;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstControleur.ItemsSource = gst.controleur.ToList();
        }

        private void lstControleur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstControleur.SelectedItem != null)
            {
                lstClient.ItemsSource = from c in gst.client.ToList()
                                        where gst.client.ToList().FindAll(ctrl => ctrl.idcontroleur == (lstControleur.SelectedItem as controleur).id).Any(cli => cli.identifiant == c.identifiant)
                                        select c;
            }
        }

        private void lstClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnInserer_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text == "")
            {
                MessageBox.Show("Veuillez saisir un nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(txtPrenom.Text == "")
                {
                    MessageBox.Show("Veuillez saisir un prenom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    controleur ctrl = new controleur
                    {
                        id = gst.controleur.ToList().Max(c => c.id + 1),
                        nom = txtNom.Text,
                        prenom = txtPrenom.Text,
                        login = txtPrenom.Text.Substring(0, 1),
                        mdp = txtNom.Text.Substring(0, 1),
                        statut = "ctrl"
                    };
                    gst.controleur.Add(ctrl);
                    gst.SaveChanges();
                }
            }
        }

        private void btnInsererCli_Click(object sender, RoutedEventArgs e)
        {
            if(txtNomCli.Text == "")
            {
                MessageBox.Show("Veuillez saisir un nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(txtPrenomCli.Text == "")
                {
                    MessageBox.Show("Veuillez saisir un prenom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    client cli = new client
                    {
                        identifiant = gst.client.ToList().Max(c => c.identifiant + 1),
                        nom = txtNomCli.Text,
                        prenom = txtPrenomCli.Text,
                        ancienReleve = 0,
                        dernierReleve = 0,
                        idcontroleur = (lstControleur.SelectedItem as controleur).id
                    };
                    gst.client.Add(cli);
                    gst.SaveChanges();
                }
            }
        }
    }
}
