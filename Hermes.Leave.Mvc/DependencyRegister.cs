using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Hermes.Data.Repositories.Interfaces;
using Hermes.Leave.Mvc.Controllers;
using Hermes.Leave.Services;
using Hermes.Leave.Services.Model;

namespace Hermes.Leave.Mvc
{
    public static class DependencyRegister
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LeaveItemRepository>().As<IRepository<LeaveItem>>();
            builder.RegisterInstance(
                new LeavePolicy
                {
                    Allowance = 200,
                    HoursPerDay = 8
                }).As<ILeavePolicy>();
            builder.RegisterType<LeaveService>()
                .As<ILeaveCardService>()
                .As<ILeaveForUserService>()
                .SingleInstance();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var resolver = new AutofacDependencyResolver(builder.Build());
            DependencyResolver.SetResolver(resolver);
        }
    }
}