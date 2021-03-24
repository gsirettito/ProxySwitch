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

namespace SiretT.Dialogs {
    public enum MessageBoxButton {
        Yes,
        YesCancel,
        YesNoCancel
    }
    /// <summary>
    /// Lógica de interacción para MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window {
        private bool? result;

        public MessageBox(MessageBoxButton buttons) {
            InitializeComponent();
            switch (buttons) {
                case MessageBoxButton.Yes:
                    cancel_button.Visibility = Visibility.Collapsed;
                    no_button.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.YesCancel:
                    no_button.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public string Yes {
            set { yes_button.Content = value; }
            get { return yes_button.Content.ToString(); }
        }

        public string No {
            set { no_button.Content = value; }
            get { return no_button.Content.ToString(); }
        }

        public string Cancel {
            set { cancel_button.Content = value; }
            get { return cancel_button.Content.ToString(); }
        }

        public string Text {
            set { text.Text = value; }
            get { return text.Text; }
        }

        private void yes_button_Click(object sender, RoutedEventArgs e) {
            result = true;
            Close();
        }

        private void no_button_Click(object sender, RoutedEventArgs e) {
            result = false;
            Close();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e) {
            result = null;
            Close();
        }

        public new bool? ShowDialog() {
            base.ShowDialog();
            return result;
        }
    }
}
