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

namespace ProxySwitch {
    /// <summary>
    /// Lógica de interacción para SaveDialog.xaml
    /// </summary>
    public partial class SaveDialog : Window {
        public SaveDialog() {
            InitializeComponent();
            Loaded += (s, e) => label.Focus();
        }

        public string Description {
            get { return description.Content.ToString(); }
            set { description.Content = value; }
        }

        public string Label {
            get { return label.Text; }
            set { label.Text = value; }
        }

        private void yes_button_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            Close();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
