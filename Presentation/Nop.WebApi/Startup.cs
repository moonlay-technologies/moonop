﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Owin;

[assembly: OwinStartup(typeof(Nop.WebApi.Startup))]

namespace Nop.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);

            EngineContext.Initialize(false);

            GlobalConfiguration.Configure(config => {
                config.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);

                WebApiConfig.Register(config);

                app.UseAutofacMiddleware(EngineContext.Current.ContainerManager.Container);
                app.UseAutofacWebApi(config);
                app.UseWebApi(config);
            });

            //log application start
            try
            {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Information("Application started", null, null);
            }
            catch (Exception)
            {
                //don't throw new exception if occurs
            }
        }
    }
}
