using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace View
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : UserControl
    {
        public PlayerWindow()
        {
            InitializeComponent();
        }

        private void Parametre_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Parametre clicked");
            ParametreWindow window2 = new ParametreWindow();
            // Afficher la deuxième fenêtre
            //window2.OptionChanged += window2_OptionChanged;
            window2.ShowDialog();
        }
    }
}
