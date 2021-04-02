using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using SlovenianCoronaTracker.Model;
using SlovenianCoronaTracker;

namespace Scraper
{
    public class Generator
    {
        public Generator(Data db)
        {
            start_get(db);
        }

        private static void start_get(Data db)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.sledilnik.org/api/summary"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())  
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            string[] delimiter = { "}," };
            string shorted = jsonString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[13].Replace("\"","") + "}," + jsonString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[14].Replace("\"", "") + "}";

            db.st_testov = Convert.ToInt32(shorted.Split(':')[2].Split(',')[0]);
            db.st_pozitivnih = Convert.ToInt32(shorted.Split(':')[4].Split(',')[0]);
            db.proc_pozitivnih = Convert.ToDouble(shorted.Split(':')[5].Split('}')[0]);
            db.datum_podatkov = Convert.ToDateTime(shorted.Split(':')[7].Split(',')[0] + "/" + shorted.Split(':')[8].Split(',')[0].Split('}')[0] + '/' + shorted.Split(':')[6].Split(',')[0]);

            shorted = jsonString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[7].Replace("\"", "");
            db.st_umrlih = Convert.ToInt32(shorted.Split(':')[6]);

        }
     
    }
}