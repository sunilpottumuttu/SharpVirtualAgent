using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace SharpVirtualAgentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var exchange = new ExchangeService(ExchangeVersion.Exchange2010);
            exchange.Credentials = new WebCredentials("xxxxxx", "xxxx", "xxx");
            exchange.AutodiscoverUrl("xxxx");

            TimeSpan ts = new TimeSpan(0, -1, 0, 0);
            DateTime date = DateTime.Now.Add(ts);
            SearchFilter.IsGreaterThanOrEqualTo filter = new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.DateTimeReceived, date);

            if (exchange != null)
            {
                FindItemsResults<Item> findResults = exchange.FindItems(WellKnownFolderName.Inbox, filter, new ItemView(50));
                

                foreach (Item item in findResults)
                {

                    EmailMessage message = EmailMessage.Bind(exchange, item.Id);
                    Console.WriteLine(message.DateTimeReceived.ToString(), message.From.Name.ToString() + "(" + message.From.Address.ToString() + ")", message.Subject, ((message.HasAttachments) ? "Yes" : "No"), message.Id.ToString());

                    if (findResults.Items.Count <= 0)
                    {

                        Console.WriteLine("No Messages found!!");

                    }
                }
            }


        }
    }
}


//http://stackoverflow.com/questions/17051198/find-all-unread-emails-using-exchange-web-service-2010-then-mark-as-read
//http://www.c-sharpcorner.com/uploadfile/jj12345678910/reading-email-and-attachment-from-microsoft-exchange-server/
//http://www.codeproject.com/Articles/399015/Exchange-Web-Services
//http://www.codeproject.com/Articles/28704/Programming-With-Exchange-Server-EWS-Part
//https://msdn.microsoft.com/en-us/library/office/dn567668(v=exchg.150).aspx#Setup
//https://github.com/OfficeDev/ews-managed-api
//https://www.nuget.org/packages/Microsoft.Exchange.WebServices/
//https://code.msdn.microsoft.com/office/Exchange-2013-101-Code-3c38582c/view/SamplePack#content
//https://msdn.microsoft.com/en-us/library/office/dn535506(v=exchg.150).aspx
//http://stackoverflow.com/questions/4925874/how-do-i-interface-with-exchange-server-using-c