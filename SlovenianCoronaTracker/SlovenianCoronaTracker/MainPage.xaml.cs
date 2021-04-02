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
            try
            {
                InitializeComponent();
                Generator g = new Generator(db);
                Napolni_podatke();
            }
            catch (Exception)
            {
                DisplayAlert("Napaka","Prišlo je do napake. Preverite internetno povezavo!","Ok");
            }
            
            
        }

        public void Napolni_podatke()
        {
            st_Pozitivnih.Text = db.st_pozitivnih.ToString();
            st_Testiranih.Text = db.st_testov.ToString();
            proc_pozitivnih.Text = db.proc_pozitivnih.ToString();
            datum_podatkov.Text = "Podatki veljavni za: " + db.datum_podatkov.ToString("dd MM yyyy");
            st_Umrlih.Text = db.st_umrlih.ToString();
            
        }
    }
}
