﻿
namespace PsychologyVisitSite.WebUI.Authentication
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += this.Authenticate;
        }

        private void Authenticate(Object source, EventArgs e)
        {
            var app = (HttpApplication)source;
            var context = app.Context;

            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.HttpContext = context;

            context.User = auth.CurrentUser;
        }

        public void Dispose()
        {
        }
    }
}