/*
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
*/

namespace Engage.Modules.WebGoat.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Mvc;

    using DotNetNuke.Data;
    using DotNetNuke.Security;
    using DotNetNuke.Web.Mvc.Framework.ActionFilters;
    using DotNetNuke.Web.Mvc.Framework.Controllers;
    
    using Engage.Modules.WebGoat.Models;

    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    [DnnHandleError]
    public class InjectionController : DnnController
    {
        public ActionResult Index()
        {
            var injections = DataContext.Instance().ExecuteQuery<Injection>(
                CommandType.StoredProcedure,
                "WebGoat_GetInjections",
                Request.QueryString["top"] ?? string.Empty,
                Request.QueryString["order"] ?? "Id DESC");
            return View(new InjectionViewModel { Injections = injections, });
        }

        [HttpPost]
        public ActionResult Index(InjectionViewModel model)
        {
            var repo = DataContext.Instance().GetRepository<Injection>();
            repo.Insert(model.NewInjection);

            return View(new InjectionViewModel { Injections = repo.Get(), });
        }
        
    }
}
