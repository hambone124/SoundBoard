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

namespace SoundBoard
{
    /// <summary>
    /// Interaction logic for ButtonLoad.xaml
    /// </summary>
    public partial class ButtonLoad : Window
    {
        private UInt16 buttonNumber;

        public ButtonLoad()
        {
            InitializeComponent();
        }

        public int ResponseText
        {
            get {
                int response = int.Parse(ButtonNumberTextBox.Text);
                return response;
            }
            set {
                ButtonNumberTextBox.Text = value.ToString();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
