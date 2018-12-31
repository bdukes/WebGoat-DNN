namespace Engage.Modules.WebGoat.Models
{
    using System.Collections.Generic;

    public class InjectionViewModel
    {
        public IEnumerable<Injection> Injections { get; set; }

        public Injection NewInjection { get; set; }
    }
}