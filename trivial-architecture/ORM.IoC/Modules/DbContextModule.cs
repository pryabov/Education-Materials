﻿using System.Data.Entity;
using Autofac;
using TrivialArchitecture.DAL;

namespace TrivialArchitecture.IoC.Modules
{
	public class DbContextModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterType<TrivialArchitectureDbContext>()
				.As<DbContext>()
				.InstancePerRequest();
		}
	}
}
