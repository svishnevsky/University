﻿using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GrSU.University.Clients.Web.Controllers.Rooms;
using GrSU.University.Clients.Web.Mapping;
using GrSU.University.Data.EF;
using GrSU.University.Data.EF.Common;
using GrSU.University.Domain.Services;
using GrSU.University.Domain.Services.Common;

namespace GrSU.University.Clients.Web
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (RoomController).Assembly);

            builder.RegisterType<DataContext>()
                .InstancePerDependency()
                .WithParameter("connectionString", "defaultconnection");

            builder.RegisterTypes(typeof (RoomRepository).Assembly.GetTypes()
                .Where(
                    t =>
                        t.BaseType != null && t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == typeof (Repository<>)).ToArray())
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterTypes(typeof (RoomService).Assembly.GetTypes()
                .Where(
                    t =>
                        t.BaseType != null && t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == typeof (DomainServiceAsync<,>)).ToArray())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var profiles = typeof (RoomProfile).Assembly.GetTypes().Where(t => t.BaseType != null && t.BaseType == typeof (Profile)).ToList();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile((Profile)Activator.CreateInstance(profile));
                }
            });

            var mapper = mapperConfig.CreateMapper();

            builder.RegisterInstance(mapper).As<IMapper>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            var cultureCookie = Request.Cookies.Get("culture");
            if (cultureCookie == null)
            {
                return;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCookie.Value);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCookie.Value);
        }
    }
}
