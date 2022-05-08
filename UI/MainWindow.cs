using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Quarrel {
    class MainWindow : Window {
        [UI] private Label label1 = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) {
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow")) {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a) {
            Application.Quit();
        }
    }
}