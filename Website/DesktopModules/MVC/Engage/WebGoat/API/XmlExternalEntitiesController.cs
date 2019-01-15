namespace Engage.Modules.WebGoat.API
{
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    using DotNetNuke.Data;
    using DotNetNuke.Security;
    using DotNetNuke.Web.Api;

    using Engage.Modules.WebGoat.Models;

    [SupportedModules("WebGoat")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    public class XmlExternalEntitiesController : DnnApiController
    {
        public HttpResponseMessage Get(GetOptions options)
        {
            var injections = DataContext.Instance().ExecuteQuery<Injection>(
                CommandType.StoredProcedure,
                "WebGoat_GetInjections",
                ValidateTop(options.Top),
                ValidateOrder(options.Order));

            var messages = injections.Select(i => i.Message);
            return this.Request.CreateResponse(HttpStatusCode.OK, messages);
        }
        public HttpResponseMessage Post(PostOptions options)
        {
            if (!this.ModelState.IsValid)
            {
                var errors = this.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => (object)e.Exception ?? e.ErrorMessage);
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }

            var repo = DataContext.Instance().GetRepository<Injection>();
            var injection = new Injection { Message = options.Message, };
            repo.Insert(injection);

            return this.Request.CreateResponse(HttpStatusCode.Created, injection);
        }

        private static string ValidateTop(int top)
        {
            if (top < 1 || top > 1000)
            {
                top = 10;
            }

            return $"TOP {top}";
        }

        private static string ValidateOrder(string order)
        {
            switch (order?.Trim()?.ToUpperInvariant())
            {
                case "MESSAGE":
                case "MESSAGE DESC":
                    return "Message DESC";
                case "MESSAGE ASC":
                    return "Message ASC";
                case "ID ASC":
                    return "Id ASC";
                default:
                    return "Id DESC";
            }
        }

        public class GetOptions
        {
            public int Top { get; set; }
            public string Order { get; set; }
        }

        public class PostOptions
        {
            public string Message { get; set; }
        }
    }
}