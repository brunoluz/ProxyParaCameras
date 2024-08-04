using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProxyParaCameras.Models.Settings
{
    public class Camera
    {
        public string Name { get; set; }

        public string Shortname { get; set; }

        public string Url { get; set; }
    }

    internal class ProxySettings
    {
        readonly string fileName = "c:\\camerasconfiguration.json";

        static bool firstExecution = true;
        static string globalUser;
        static string globalPassword;
        static Camera[] globalCameras;

        public ProxySettings()
        {
            if (firstExecution)
            {
                string jsontext = File.ReadAllText(fileName);

                var jobject = JObject.Parse(jsontext);

                globalUser = jobject["user"].ToString();
                globalPassword = jobject["password"].ToString();

                List<Camera> cameras = new List<Camera>();
                foreach (var item in jobject["cameras"])
                {
                    Camera camera = new Camera();
                    camera.Name = item["name"].ToString();
                    camera.Shortname = item["shortname"].ToString();
                    camera.Url = item["url"].ToString();

                    cameras.Add(camera);
                }
                globalCameras = cameras.ToArray();

                firstExecution = false;
            }
        }

        public string User
        {
            get { return globalUser; }
        }

        public string Password
        {
            get { return globalPassword; }
        }

        public Camera[] cameras
        {
            get { return globalCameras; }
        }
    }
}
