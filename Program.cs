using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Gtk;

namespace Pisscord {
    class Program {

        public static string Url = "http://homeworktrack.serble.net:9898/api/";

        [STAThread]
        public static void Main(string[] args) {
            Application.Init();

            Application app = new Application("org.Pisscord.Pisscord", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            LoginWindow window = new LoginWindow();
            app.AddWindow(window);

            window.Show();
            Application.Run();
        }

        public static bool SendPostRequest(out HttpResponseMessage response, string path, string body, Dictionary<string, string> header = null) {
            try {
                StringContent data = new StringContent(body);
                HttpClient client = new HttpClient();

                foreach (KeyValuePair<string, string> aa in header) {
                    client.DefaultRequestHeaders.Add(aa.Key, aa.Value);
                }
            
                response = client.PostAsync(Url + path, data).Result;
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                
                response = null;
                return false;
            }
        }
    }
}