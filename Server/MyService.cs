using Server.Models;
using System.Data.Entity;
using System.Linq;

namespace Server
{
    public class MyService : IMyService
    {
        public bool AddSubscriber(string fio, string phone)
        {
            using (var context = new HelpDeskContext())
            {
                context.Subscribers.Add(new Subscriber(fio, phone));
                context.SaveChanges();
            }
            return true;
        }

        public string[] TryGetSubscribers(string data)
        {            
            var context = new HelpDeskContext();

            var subscribers = context.Subscribers
                .ToList()
                .Where(x => x.FIO.ToLower().Contains(data.ToLower()) || x.Phone.Contains(data))
                .Select(x => x.ToString());
            
            return subscribers.ToArray();
        }

        public bool DeleteSubscriber(string fio)
        {
            if (fio != null)
            {
                var context = new HelpDeskContext();

                var subscriber = context.Subscribers.FirstOrDefault(s => s.FIO == fio);
                context.Subscribers.Remove(subscriber);
                context.SaveChanges();
                
                return true;
            }

            return false;
        }

        public bool AddRequest(string typeStr, string text, string subscriberStr, string source)
        {
            var context = new HelpDeskContext();

            if (typeStr != "1" && typeStr != "2" && typeStr != "3") return false;

            TypeRequest type = TypeRequest.Phone;            
            if (typeStr == "2") type = TypeRequest.Email;
            if (typeStr == "3") type = TypeRequest.SMS;

            var subscriber = context.Subscribers.FirstOrDefault(x => x.FIO == subscriberStr);
                        
            context.Requests.Add(new Request(type, text, subscriber, source));
            context.SaveChanges();

            return true;
        }
        
        public string[] TryGetRequests(string input)
        {
            var context = new HelpDeskContext();
            
            var t1 = context.Requests
                .Include(x => x.Subscriber)
                .ToList();

            var t2 = t1.Where(r => r.Subscriber.FIO.ToLower().Contains(input.ToLower())
                     || r.Subscriber.Phone.Contains(input))
                ;
            var t3 = t2.Select(x => x.ToString()).ToArray();

            return t3;
        }

        public bool DeleteRequest(string id)
        {
            var context = new HelpDeskContext();
            
            var request = context.Requests.FirstOrDefault(x => x.Id.ToString() == id);

            if (request != null)
            {
                context.Requests.Remove(request);
                context.SaveChanges();
                return true;
            }
            
            return false;
        }
    }
}