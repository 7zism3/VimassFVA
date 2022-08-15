using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace VimassFVA
{
    public class Service
    {
        static String urlService = "http://localhost:8082/vimass-tmdt/services/identity-fva";
        public static void SendWebrequest_POST_Method(string json)
        {
            try
            {
                string url = urlService;
                string result = "";
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    result = client.UploadString(url, "POST", json);
                }
                Debug.WriteLine(result);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
        }
    }
}
