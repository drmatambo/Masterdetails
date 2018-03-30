using System.Web.Routing;

namespace VumbaSoft.Masterdetails.Controllers
{
    public interface IRouteConfig
    {
        void RegisterRoutes(RouteCollection routes);
    }
}
