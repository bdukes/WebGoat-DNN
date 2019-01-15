/*
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
*/

namespace Engage.Modules.WebGoat.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    using DotNetNuke.Security;
    using DotNetNuke.Web.Mvc.Framework.ActionFilters;
    using DotNetNuke.Web.Mvc.Framework.Controllers;
    
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    [DnnHandleError]
    public class BrokenAccessControlController : DnnController
    {
        public ActionResult ViewBill()
        {
            var billId = this.Request.QueryString["id"];
            if (!string.IsNullOrEmpty(billId))
            {
                return File(
                    Path.Combine(this.PortalSettings.HomeDirectoryMapPath, "Bills", billId),
                    "application/pdf");
            }

            return View();
        }
    }
}
