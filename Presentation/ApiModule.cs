using Carter;

namespace Presentation
{
    public abstract class ApiModule : CarterModule, IModule
    {
        internal const string emptyPath = "/";
        public ApiModule(string basePath) : base(basePath)
        { }
    }
}
