using Microsoft.AspNetCore.Mvc;

namespace ProductionPracticeGUAP.API.Extentions
{
    public static class ControllerExtension
    {
        public static string GetUri(this Controller c) =>
           $"{c.Request.Scheme}://{c.Request.Host.Value}{c.Request.Path.Value}";
    }
}
