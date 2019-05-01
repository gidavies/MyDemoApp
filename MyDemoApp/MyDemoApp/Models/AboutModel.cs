using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDemoApp.Web.Models
{
    public class AboutModel
    {
        public string OSVersion { get; }

        public AboutModel()
        {
            this.OSVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        }
    }
}
