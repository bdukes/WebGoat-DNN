namespace Engage.Modules.WebGoat.API
{
    using System.Web.Http;

    using DotNetNuke.Web.Api;

    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ServiceRouteMapper : IServiceRouteMapper
    {
        /// <inheritdoc />
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                routeName: "verb-based",
                moduleFolderName: "Engage/WebGoat",
                url: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                namespaces: new[] { "Engage.Modules.WebGoat.API", });
            mapRouteManager.MapHttpRoute(
                routeName: "action-based",
                moduleFolderName: "Engage/WebGoat",
                url: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                namespaces: new[] { "Engage.Modules.WebGoat.API", });
        }
    }
}