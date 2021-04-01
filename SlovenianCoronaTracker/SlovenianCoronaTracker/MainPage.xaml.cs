using Newtonsoft.Json.Linq;
using Scraper;
using SlovenianCoronaTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlovenianCoronaTracker
{
    public partial class MainPage : ContentPage
    {
        Data db = new Data();
        public MainPage()
        {
            InitializeComponent();
            Generator g = new Generator(db);
            Napolni_podatke();
            
        }

        public void Napolni_podatke()
        {

            st_Pozitivnih.Text = db.st_pozitivnih.ToString();
            st_Testiranih.Text = db.st_testov.ToString();
            proc_pozitivnih.Text = db.proc_pozitivnih.ToString();
            st_Umrlih.Text = "7";

        }
    }
}
