using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeclarationDeVol.Startup))]
namespace DeclarationDeVol
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
