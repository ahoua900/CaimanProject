﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaimanProject.Startup))]
namespace CaimanProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
