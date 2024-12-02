using RestSharp;

namespace SneakersShop.Services
{
    public abstract class BaseService
    {
        protected virtual string BaseUrl => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api" : "http://localhost:5000/api";

        //protected virtual string BaseUrl => "http://192.168.48.189:5000/api";

        protected RestClient Client { get; }

        protected BaseService()
        {
            Client = new RestClient(BaseUrl);
        }
    }
}
