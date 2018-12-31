using System;
using System.Linq;
using System.Web;

namespace Engage.Modules.WebGoat.Models
{
    using DotNetNuke.ComponentModel.DataAnnotations;

    [TableName("WebGoat_Injection")]
    public class Injection
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}