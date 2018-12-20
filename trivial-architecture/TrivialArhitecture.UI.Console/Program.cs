using System;
using Autofac;
using NLog;
using TrivialArchitecture.IoC;

namespace TrivialArchitecture.UI.Console
{
	static class Program
	{
		public static readonly Logger Logger = LogManager.GetLogger("storageUILogger");

		public static DependencyResolverContainer DependencyResolver { get; }

		static Program()
		{
			DependencyResolver = new DependencyResolverContainer();
		}

		static void Main(string[] args)
		{
			StorageHandler commandHandler = DependencyResolver.Container.Resolve<StorageHandler>();

			string command = GetCommand();
			while (command != "exit")
			{
				commandHandler.Handle(command);
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