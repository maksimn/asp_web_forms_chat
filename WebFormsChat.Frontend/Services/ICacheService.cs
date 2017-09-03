using System.Web.Caching;

namespace WebFormsChat.Frontend.Services {
    public interface ICacheService {
        void AddToCache(string key, object value, CacheDependency dependency);
        object Get(string key);
    }
}
