using System;

namespace Senai.Gufos.WebApi.Controllers
{
    internal class AutorhizeAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}