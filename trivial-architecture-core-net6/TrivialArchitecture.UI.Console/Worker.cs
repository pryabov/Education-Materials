using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TrivialArchitecture.UI.Console.CommandHandlers;

namespace TrivialArchitecture.UI.Console
{
	public class Worker: BackgroundService
	{
		private readonly CoreCommandHandler coreCommandHandler;

		public Worker(CoreCommandHandler coreCommandHandler)
		{
			this.coreCommandHandler = coreCommandHandler;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			string command = GetCommand();
			while (command != "exit" && !stoppingToken.IsCancellationRequested)
			{
				coreCommandHandler.Handle(command);
				command = GetCommand();
			}

			System.Console.WriteLine("Click Ctrl+C");
			return Task.CompletedTask;
		}

		static string GetCommand()
		{
			System.Console.Write($"{Environment.NewLine}> ");
			return System.Console.ReadLine();
		}
	}
}
