using System.Configuration;
using System.Web;
using System.Web.Caching;

namespace WebFormsChat.Frontend.Services {
    public class AspNetCacheService : ICacheService {
        static AspNetCacheService() {
            var cnnStr = ConfigurationManager.ConnectionStrings["WebFormsChat"].ConnectionString;
            SqlCacheDependencyAdmin.EnableTableForNotifications(cnnStr, "ChatMessages");
        }

        public void AddToCache(string key, object value, CacheDependency dependency) {
            HttpContext.Current.Cache.Insert(key, value, dependency);
        }

        public object Get(string key) {
            return HttpContext.Current.Cache[key];
        }
    }
}