using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebUI.Models.Controls
{
    public class CtrlBaseModel
    {

        public string Id { get; set; }
        public string ViewName { get; set; }

        private string ReadFileText()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["PathTemplates"];
            string fileName = this.GetType().Name + ".html";

            path = System.Web.Hosting.HostingEnvironment.MapPath(path + fileName);

            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in GetType().GetProperties())
            {
                var value = prop.GetValue(this, null).ToString();
                var tag = $"-#{prop.Name}-";
                html = html.Replace(tag, value);
            }
            return html;
        }
    }
}