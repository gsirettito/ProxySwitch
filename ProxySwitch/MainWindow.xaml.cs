using Microsoft.Win32;
using MS.Interop.WinUser;
using SiretT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Interop;

namespace ProxySwitch {
    public class Proxy {
        public string Label { get; set; }
        public string Http { get; set; }
        public int Port { get; set; }
        public string Bypass { get; set; }
    }
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        private System.Windows.Forms.NotifyIcon notify;
        private ContextMenu menu;
        private IniFile ini;
        private bool isEnable;
        private string pServer;
        private string pBypass;
        private string proxyKey;
        private AssemblyName assembly;
        private Proxy unsaved;
        private bool entryNotSaved;

        public MainWindow() {
            InitializeComponent();
            notify = new System.Windows.Forms.NotifyIcon();
            notify.MouseDoubleClick += Notify_MouseDoubleClick;
            notify.MouseClick += Notify_MouseClick;
            notify.Visible = true;
            notify.Text = "ProxySwitch";
            menu = (ContextMenu)this.FindResource("NotifierContextMenu");
            menu.PlacementTarget = this;
            menu.Placement = PlacementMode.MousePoint;
            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;

            Binding b = new Binding("IsChecked") {
                Mode = BindingMode.TwoWay,
                Source = menu.Items[1],
            };
            BindingOperations.SetBinding(enable, CheckBox.IsCheckedProperty, b);

            assembly = Assembly.GetExecutingAssembly().GetName();
            this.Title = assembly.Name + " - " + assembly.Version;

            proxyKey = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(proxyKey);
            isEnable = (int)rk.GetValue("ProxyEnable", 0) == 0 ? false : true;
            pServer = rk.GetValue("ProxyServer", "").ToString();
            pBypass = rk.GetValue("ProxyOverride", "").ToString();
            rk.Close();

            ini = new IniFile("config.ini");

            WindowState = WindowState.Minimized;
            autorun.IsChecked = (bool)ini.GetValue("Main\\Autorun", false);
            enable.IsChecked = isEnable;

            bool isKnowed = false;
            if (ini["Proxys"] != null)
                foreach (var i in ini["Proxys"].Properties) {
                    string value = i.Value.ToString();
                    var pxy = value.Split('|');
                    var label = pxy[0];
                    string http = pxy[1].Substring(0, pxy[1].IndexOf(':'));
                    string port = pxy[1].Substring(pxy[1].IndexOf(':') + 1);
                    string bypass = pxy[2];
                    Proxy p = new Proxy() {
                        Http = http,
                        Port = Int32.Parse(port),
                        Label = label,
                        Bypass = bypass,
                    };
                    var rb = new RadioButton() {
                        Content = p.Label,
                        Tag = p,
                    };
                    AddNotifyMenuItem(rb, p);
                    if (pServer == http + ":" + port && pBypass == bypass) {
                        rb.IsChecked = true;
                        isKnowed = true;
                    }
                    rb.Checked += Mi_Checked;
                    list.Items.Add(rb);
                }
            this.Loaded += MainWindow_Loaded;
            notify.Text = pServer;
            var ico = Properties.Resources.large_computer_network_query_color_flat;
            if (!(bool)enable.IsChecked)
                ico = Properties.Resources.large_computer_network_query_flat;
            notify.Icon = ico;
            if (!isKnowed && !string.IsNullOrEmpty(pServer)) {
                Uri uri;
                if (pServer.StartsWith("http"))
                    uri = new Uri(pServer);
                else uri = new Uri("http://" + pServer);

                string http = uri.Host;
                int port = uri.Port;
                Proxy p = new Proxy() {
                    Http = http,
                    Port = port,
                    Label = $"*{http}:{port}",
                    Bypass = pBypass,
                };
                var rb = new RadioButton() {
                    Content = p.Label,
                    Tag = p,
                };
                rb.Checked += Mi_Checked;
                list.Items.Insert(0, rb);
                MenuItem mi = new MenuItem() {
                    IsChecked = true,
                    Header = p.Label,
                };
                menu.Items.Insert(3, mi);
                Binding b1 = new Binding("IsChecked") {
                    Mode = BindingMode.TwoWay,
                    Source = mi,
                };
                BindingOperations.SetBinding(rb, RadioButton.IsCheckedProperty, b1);
            }
        }

        protected override void OnSourceInitialized(EventArgs e) {
            base.OnSourceInitialized(e);
            HwndSource hwnd = PresentationSource.FromVisual(this) as HwndSource;
            hwnd.AddHook(WindowFilterMessage);
        }

        #region messageFilter

        /// <summary>
        ///     This is the hook to HwndSource that is called when window messages related to
        ///     this window occur.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WindowFilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            IntPtr retInt = IntPtr.Zero;
            WindowMessage message = (WindowMessage)msg;

            //
            // we need to process WM_GETMINMAXINFO before _swh is assigned to
            // b/c we want to store the max/min size allowed by win32 for the hwnd
            // which is later used in GetWindowMinMax.  WmGetMinMaxInfo can handle
            // _swh == null case.
            switch (message) {
                case WindowMessage.WM_KILLFOCUS:
                    menu.IsOpen = false;
                    break;
            }

            return retInt;
        }

        #endregion

        private void NetChangeRefresh() {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            var left = ini.GetValue("Main\\Left", (int)Left);
            var top = ini.GetValue("Main\\Top", (int)Top);
            var width = ini.GetValue("Main\\Width", (int)440);
            var height = ini.GetValue("Main\\Height", (int)370);
            Left = left is int ? (int)left : Left;
            Top = top is int ? (int)top : Top;
            Width = width is int ? (int)width : 440;
            Height = height is int ? (int)height : 370;
            if (WindowState == WindowState.Minimized)
                this.Hide();
        }

        private void AddNotifyMenuItem(RadioButton radioButton, Proxy p) {
            MenuItem mi = new MenuItem() {
                IsCheckable = true,
                Header = p.Label,
            };
            menu.Items.Insert(4, mi);
            Binding b = new Binding("IsChecked") {
                Mode = BindingMode.TwoWay,
                Source = mi,
            };
            BindingOperations.SetBinding(radioButton, RadioButton.IsCheckedProperty, b);
        }

        private void MainWindow_Closed(object sender, EventArgs e) {
            if (notify != null) notify.Dispose();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e) {
            this.WindowState = WindowState.Minimized;
            SaveConfig();
            e.Cancel = true;
        }

        private void SaveConfig() {
            SaveProxys();
            ini.AddOrUpdate("Main\\State", (uint)this.WindowState);
            ini.AddOrUpdate("Main\\Left", this.Left);
            ini.AddOrUpdate("Main\\Top", this.Top);
            ini.AddOrUpdate("Main\\Width", (int)this.Width);
            ini.AddOrUpdate("Main\\Height", (int)this.Height);
            ini.AddOrUpdate("Main\\Autorun", this.autorun.IsChecked);
            ini.Save();
        }

        private void SaveProxys() {
            int i = 1;
            entryNotSaved = false;
            foreach (RadioButton rb in list.Items) {
                Proxy p = rb.Tag as Proxy;
                if (string.IsNullOrEmpty(p.Label)) continue;
                if (p.Label.StartsWith("*")) {
                    unsaved = p;
                    entryNotSaved = true;
                    continue;
                }

                string pxy = $"{p.Label}|{p.Http}:{p.Port}|{p.Bypass}";

                ini.AddOrUpdate($"Proxys\\Proxy{i}", pxy);
                i++;
            }
            ini.Save();
        }

        private void Notify_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Clicks == 0 && e.Button == System.Windows.Forms.MouseButtons.Right) {
                menu.IsOpen = true;
                HwndSource hwnd = PresentationSource.FromVisual(menu) as HwndSource;
                WinUser.SetForegroundWindow(hwnd.Handle);
                hwnd.AddHook(WindowFilterMessage);
            }
        }

        private void Notify_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2) {
                enable.IsChecked = !enable.IsChecked;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(proxy.Text) ||
                !string.IsNullOrEmpty(port.Text) ||
                !string.IsNullOrEmpty(label.Text)) {
                Proxy p = new Proxy() {
                    Label = label.Text,
                    Http = proxy.Text,
                    Port = Int32.Parse(port.Text),
                    Bypass = nproxy.Text,
                };

                int indx = 0;
                int indexer = -1;
                foreach (RadioButton i in list.Items) {
                    Proxy _p = i.Tag as Proxy;
                    if (p.Label == _p.Label) {
                        indexer = indx;
                        break;
                    }
                    indx++;
                }
                if (indexer > -1) {
                    (list.Items[indexer] as RadioButton).Tag = p;

                    pServer = p.Http + ":" + p.Port;
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey(proxyKey, true);
                    rk.SetValue("ProxyServer", p.Http + ":" + p.Port, RegistryValueKind.String);
                    rk.SetValue("ProxyOverride", p.Bypass, RegistryValueKind.String);
                    rk.Close();

                    NetChangeRefresh();
                    notify.Text = pServer;
                } else {
                    var rb = new RadioButton() {
                        Content = p.Label,
                        Tag = p,
                    };
                    AddNotifyMenuItem(rb, p);
                    rb.Checked += Mi_Checked;
                    list.Items.Add(rb);
                }
                SaveProxys();
            }
        }

        private void Mi_Checked(object sender, RoutedEventArgs e) {
            Proxy p;
            if (sender is MenuItem)
                sender = (((sender as MenuItem).Parent as ContextMenu).PlacementTarget as RadioButton);
            p = ((FrameworkElement)sender).Tag as Proxy;
            pServer = p.Http + ":" + p.Port;
            //RegistrySecurity rs = new RegistrySecurity();
            //string user = Environment.UserDomainName + "\\" + Environment.UserName;
            // Allow the current user to read and delete the key.
            //
            //rs.AddAccessRule(new RegistryAccessRule(user,
            //    RegistryRights.WriteKey |
            //    RegistryRights.ReadKey |
            //    RegistryRights.Delete |
            //    RegistryRights.FullControl,
            //    AccessControlType.Allow));

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(proxyKey, true);
            rk.SetValue("ProxyServer", p.Http + ":" + p.Port, RegistryValueKind.String);
            rk.SetValue("ProxyOverride", p.Bypass, RegistryValueKind.String);
            rk.Close();

            NetChangeRefresh();
            if (sender is RadioButton)
                (sender as RadioButton).IsChecked = true;
            notify.Text = pServer;
        }

        private void Window_StateChanged(object sender, EventArgs e) {
            if (this.WindowState == WindowState.Minimized) {
                this.Hide();
            }
        }

        private void Menu_Open(object sender, RoutedEventArgs e) {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Topmost = true;
            this.Focus();
            this.Topmost = false;
        }

        private void Menu_Close(object sender, RoutedEventArgs e) {
            SaveConfig();
            if (!entryNotSaved)
                App.Current.Shutdown();
            SiretT.Dialogs.MessageBox messageBox = new SiretT.Dialogs.MessageBox(
                SiretT.Dialogs.MessageBoxButton.YesNoCancel) {
                Title = this.Title,
                Text = "There is an unsaved entry. Do you want to save? ",
                Yes = "Save",//true
                No = "Don't",//false
            };
            var result = messageBox.ShowDialog();
            if (result == false) App.Current.Shutdown();
            else {
                SaveDialog saveDialog = new SaveDialog() {
                    Title = this.Title + " - Save",
                    Description = $"{unsaved.Http}:{unsaved.Port}"
                };
                result = saveDialog.ShowDialog();
                if (result == true) {
                    string pxy = $"{saveDialog.Label}|{unsaved.Http}:{unsaved.Port}|{unsaved.Bypass}";
                    int i = 1;
                    do { i++; } while (ini.Contains($"Proxys\\Proxy{i}"));
                    ini.AddOrUpdate($"Proxys\\Proxy{i}", pxy);
                    ini.Save();
                    App.Current.Shutdown();
                }
            }
        }

        private void enable_Checked(object sender, RoutedEventArgs e) {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(proxyKey, true);
            rk.SetValue("ProxyEnable", enable.IsChecked, RegistryValueKind.DWord);
            rk.Close();

            NetChangeRefresh();
            var ico = Properties.Resources.large_computer_network_query_color_flat;
            if (!(bool)enable.IsChecked)
                ico = Properties.Resources.large_computer_network_query_flat;
            notify.Icon = ico;

            notify.Text = pServer;
        }

        private void autorun_Checked(object sender, RoutedEventArgs e) {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (autorun.IsChecked == true)
                rk.SetValue(assembly.Name, '"' + Environment.GetCommandLineArgs()[0] + '"', RegistryValueKind.String);
            else
                rk.DeleteValue(assembly.Name);
            rk.Close();

            NetChangeRefresh();
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            Proxy p;
            if (sender is MenuItem)
                sender = (((sender as MenuItem).Parent as ContextMenu).PlacementTarget as RadioButton);
            p = ((FrameworkElement)sender).Tag as Proxy;

            MenuItem mi = new MenuItem() {
                IsCheckable = true,
                Header = p.Label,
                IsChecked = (bool)(sender as RadioButton).IsChecked
            };
            int indx = 0;
            int indexer = -1;
            foreach (RadioButton i in list.Items) {
                Proxy _p = i.Tag as Proxy;
                if (p.Label == _p.Label) {
                    indexer = indx;
                    break;
                }
                indx++;
            }
            if (indexer > -1)
                list.Items.RemoveAt(indexer);

            indx = 0;
            indexer = -1;
            foreach (var i in menu.Items) {
                if (i is MenuItem)
                    if ((i as MenuItem).Header.ToString() == p.Label) {
                        indexer = indx;
                        break;
                    }
                indx++;
            }
            if (indexer > -1)
                menu.Items.RemoveAt(indexer);

            indx = 0;
            indexer = -1;
            foreach (var i in ini["Proxys"].Properties) {
                if (Regex.IsMatch(i.Value.ToString(), $"^{p.Label}")) {
                    indexer = indx;
                    break;
                }
                indx++;
            }
            ini["Proxys"].RemoveAt(indexer);
            ini.Save();
        }

        private void Edit_Checked(object sender, RoutedEventArgs e) {
            Proxy p;
            if (sender is MenuItem)
                sender = (((sender as MenuItem).Parent as ContextMenu).PlacementTarget as RadioButton);
            p = ((FrameworkElement)sender).Tag as Proxy;

            label.Text = p.Label;
            proxy.Text = p.Http;
            port.Text = p.Port.ToString();
            nproxy.Text = p.Bypass;
        }
    }
}
