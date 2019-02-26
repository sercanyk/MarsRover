using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MarsRover
{
    public static class ContainerConfig
    {
        public static IContainer Container { get; private set; }
        public static IContainer Configure()
        {
            var assembly = Assembly.Load("MarsRover.Engine");
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            Container = builder.Build();
            return Container;
        }
    }
}
