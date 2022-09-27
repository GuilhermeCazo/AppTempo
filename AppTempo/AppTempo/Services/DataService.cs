using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using AppTempo.Model;

namespace AppTempo.Services
{
     class DataService
    {

        public static async Task<Tempo> GetPrevisaoDoTempo(string cidade)
        {
            string appId = "5c15ea9cd7c1832353892cbf30228d67";

            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + cidade + "&units=metric" + "&appid=" + appId;
            dynamic resultado = await getDataFromService(queryString).ConfigureAwait(false);

            if (resultado["weather"] != null)
            {
                Tempo previsao = new Tempo();

                previsao.Titulo = (string)resultado["name"];
                previsao.Temperatura = (string)resultado["main"]["temp"] + " C";
                previsao.Vento = (string)resultado["wind"]["speed"] + " mph";
                previsao.Umidade = (string)resultado["main"]["humidity"] + " %";
                previsao.Visibilidade = (string)resultado["weather"][0]["main"];

                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0);

                DateTime sunrise = time.AddSeconds((double)resultado["Sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)resultado["Sys"]["sunset"]);

                previsao.NascerSol = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunrise);
                previsao.PorSol = String.Format("{0:d/MM/yyyy HH:mm:ss}", sunset);

                //terminar...

            }
            

        }

    }
}
