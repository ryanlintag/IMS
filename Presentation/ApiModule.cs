using Carter;
using Microsoft.AspNetCore.Routing;

namespace Presentation
{
    public abstract class ApiModule : CarterModule, IModule
    {
        internal const string emptyPath = "/";
        public ApiModule(string basePath) : base(basePath)
        { }
    }
}
