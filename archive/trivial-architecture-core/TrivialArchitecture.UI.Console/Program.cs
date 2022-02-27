using Autofac;
using NLog;
using System;
using TrivialArchitecture.UI.Console.CommandHandlers;
using TrivialArchitecture.UI.Console.Infrastructure.IoC;

namespace TrivialArchitecture.UI.Console
{
	static class Program
	{
		public static readonly Logger Logger = LogManager.GetLogger("storageUILogger");

		private static DependencyResolverContainer DependencyResolver { get; }

		static Program()
		{
			DependencyResolver = new DependencyResolverContainer();
		}

		static void Main()
		{
			CoreCommandHandler coreCommandHandler = DependencyResolver.Container.Resolve<CoreCommandHandler>();

			string command = GetCommand();
			while (command != "exit")
			{
				coreCommandHandler.Handle(command);
				command = GetCommand();
			}
		}

		static string GetCommand()
		{
			System.Console.Write($"{Environment.NewLine}> ");
			return System.Console.ReadLine();
		}
	}
}