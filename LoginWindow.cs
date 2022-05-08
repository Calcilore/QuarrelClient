using System;
using System.Collections.Generic;
using System.Net.Http;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Pisscord {
    public class LoginWindow : Window {
        [UI] private Button loginButton = null;
        [UI] private Button registerButton = null;
        [UI] private Label loginStatus = null;
        
        [UI] private Entry usernameField = null;
        [UI] private Entry passwordField = null;

        public LoginWindow() : this(new Builder("LoginWindow.glade")) {
        }

        private LoginWindow(Builder builder) : base(builder.GetRawOwnedObject("LoginWindow")) {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            loginButton.Clicked += LoginButtonClicked;
            registerButton.Clicked += RegisterButtonClicked;
        }

        private void LoginButtonClicked(object sender, EventArgs a) {
            string username = usernameField.Text;
            string password = passwordField.Text;

            if (username != "admin" || password != "admin") {
                loginStatus.Text = "Invalid username or password";
                return;
            }

            MainWindow window = new MainWindow();
            Application.AddWindow(window);
            window.Show();
            Destroy();
        }

        private void RegisterButtonClicked(object sender, EventArgs a) {
            string username = usernameField.Text;
            string password = passwordField.Text;
            
            Program.SendPostRequest(out HttpResponseMessage aa, "users", "", new Dictionary<string, string>() {{"Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(username + ":" + password))}});
            Console.WriteLine(aa);
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) {
            Application.Quit();
        }
    }
}