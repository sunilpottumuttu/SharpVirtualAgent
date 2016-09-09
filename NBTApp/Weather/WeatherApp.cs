using Microsoft.Cognitive.LUIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NBTApp.Weather
{
    public class WeatherApp
    {
        private string _apiKey = Globals.OPENWEATHER_APIKEY;

        private LuisClient __luisClient;
        public IntentRouter __router;
        private WeatherReport __weatherReport;
        private string __url = "http://api.openweathermap.org/data/2.5/weather";

        public WeatherApp()
        {
            this.__luisClient = new LuisClient(Globals.LUIS_APPID, Globals.LUIS_APPKEY, true);
            this.__router = IntentRouter.Setup<WeatherApp>(this.__luisClient);
            
        }

        public Task<WeatherReport> Query(string sentence)
        {
            Task<bool> taskResult = this.__router.Route(sentence, this);
            taskResult.Wait();
            //return this.__weatherReport;
            return Task.FromResult<WeatherReport>(this.__weatherReport);
        }


        [IntentHandler(0, Name = "GetWeather")]
        public async static Task<bool> GetWeather(LuisResult res, object weatherObj)
        {

            var city = string.Empty;

            var entitiesList = res.Entities.ToList();
            foreach (var entity in entitiesList)
            {
                foreach (var val in entity.Value)
                {
                    city = val.Value;
                }
            }

            //call weather service
            var obj = (WeatherApp)weatherObj;
            Task<WeatherReport> weatherReportTask = obj.GetWeatherByCity(city);
            weatherReportTask.Wait();
            var result = weatherReportTask.Result;

            //Console.WriteLine("Top Scoring Intent " + res.TopScoringIntent.Name);
            return await Task.FromResult<bool>(true);
        }

        private async Task<WeatherReport> GetWeatherByCity(string cityName)
        {

            var client = new RestClient(this.__url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", cityName);
            request.AddParameter("appid", this._apiKey);

            var response = client.Execute(request);


            //var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName},uk&appid={_apiKey}";
            //return await weatherURL.GetJsonAsync<WeatherReport>();
            this.__weatherReport = new WeatherReport();
            return await Task.FromResult<WeatherReport>(this.__weatherReport);
        }


    }
}
