using demo_csharp.Workers.IWorkService;
using Model;
using ServiceStack.Redis;
using System;
using System.Configuration;

namespace demo_csharp.Workers
{
    public class RedisWorker : IMasterWorker
    {
        private static string REDIS_IP = ConfigurationManager.AppSettings["REDIS_IP"];
        private static int REDIS_PORT = Int32.Parse(ConfigurationManager.AppSettings["REDIS_PORT"]);

        public void Do()
        {
            RedisClient redisClient = new RedisClient(REDIS_IP, REDIS_PORT);

            Film film = new Film()
            {
                Name = "流浪地球",
                Year = 2020
            };

            redisClient.Set<Film>("film_1", film);

            Console.WriteLine(redisClient.Get<Film>("film_1"));
        }
    }
}
