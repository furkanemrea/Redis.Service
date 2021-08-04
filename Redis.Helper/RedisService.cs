using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Helper
{
    public class RedisService
    {
        private readonly RedisManager _redisManager;
        public RedisService(RedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public List<TModel> GetList<TModel>(string key)
        {
            List<TModel> returnList = new();
            _redisManager.GetDb(1).ListRange(key).ToList().ForEach(x =>
            {
                 TModel modelElement=JsonConvert.DeserializeObject<TModel>(x);
                 returnList.Add(modelElement);
            });
            return returnList;
        }
        public ResponseCodes ListPush<TModel>(string key,TModel model) 
        {
            if (model is null)
            {
                return ResponseCodes.IsEmpty;
            }
            string serializeModel = JsonConvert.SerializeObject(model);
            _redisManager.GetDb(1).ListLeftPush(key,serializeModel);
            return ResponseCodes.Success;
        }
    }
}
