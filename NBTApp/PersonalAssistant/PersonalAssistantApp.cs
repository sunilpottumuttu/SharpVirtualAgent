using Microsoft.Cognitive.LUIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace NBTApp.PersonalAssistant
{
    public class PersonalAssistantApp
    {
        private LuisClient __luisClient;
        public IntentRouter __router;
        private CalendarResponse __Response;

        public PersonalAssistantApp()
        {
            this.__luisClient = new LuisClient(Globals.LUIS_APPID, Globals.LUIS_APPKEY, true);
            this.__router = IntentRouter.Setup<PersonalAssistantApp>(this.__luisClient);
        }

        public CalendarResponse Query(string sentence)
        {
            Task<bool> taskResult = this.__router.Route(sentence, this);
            taskResult.Wait();
            return this.__Response;
        }

        [IntentHandler(0, Name = "builtin.intent.calendar.create_calendar_entry")]
        public async static Task<bool> CreateCalendarEntry(LuisResult res, object personalAssistantAppObj)
        {
            var obj = (PersonalAssistantApp)personalAssistantAppObj;
            var response = obj.CreateCalendarEntry();
            return await Task.FromResult<bool>(true);
        }

        private CalendarResponse CreateCalendarEntry()
        {

            return this.__Response;
        }




    }
}
