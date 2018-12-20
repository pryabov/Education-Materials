using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using CommandLine;
using TrivialArchitecture.UI.Console.Interfaces;
using TrivialArchitecture.UI.Console.UserOptions;

namespace TrivialArchitecture.UI.Console
{
	sealed class StorageHandler
	{
		public StorageEventHandler EventHandler { get; }

		private readonly ICommandLineSplitter splitter;
		private readonly IColorfulConsole colorfulConsole;
		
		public StorageHandler(ICommandLineSplitter splitter, IColorfulConsole colorfulConsole)
		{
			_splitter = splitter;
			_colorfulConsole = colorfulConsole;

			EventHandler = new StorageEventHandler(storage, colorfulConsole);
		}

		public void Handle(string commandLine)
		{
			try
			{
				Program.Logger.Info($"Processing the command \"{commandLine}\"");
				string[] args = splitter.Split(commandLine);
				if (args.Length == 0)
				{
					return;
				}

				//иначе никак, библиотека не предоставляет возможность парсинга двух подряд идущих глаголов, первый приходится обрезать
				switch (args.First())
				{
					case "file":
						ParseFileCommands(args.Skip(1).ToArray());
						break;

					case "user":
						ParseUserCommands(args.Skip(1).ToArray());
						break;

					case "--help":
					case "-help":
					case "help":
					case "/help":
						PrintHelp();
						break;

					default:
						throw new ArgumentException($"Command \"{args.First()}\" not recognized. Use file --help or user --help for more information.");
				}
			}
			catch (Exception exception)
			{
				Program.Logger.Error(exception);
				_colorfulConsole.WriteLineFormatted("{0} " + exception.Message, Color.Red, Color.WhiteSmoke, "ERROR: ");
			}
		}


		private void ParseUserCommands(string[] args)
		{
			Parser.Default.ParseArguments<InfoOptions, UsedOptions>(args)
				.WithParsed<UsedOptions>(opts => PrintUserUsage())
				.WithParsed<InfoOptions>(opts => PrintUserInfo());
		}


		private void ParseFileCommands(string[] args)
		{
			Parser.Default.ParseArguments<UploadOptions, DownloadOptions, MoveOptions, RemoveOptions, FileInfoOptions, ListOptions, ExportOptions>(args)
				.WithParsed<UploadOptions>(opts => UploadFile(opts.Path))
				.WithParsed<DownloadOptions>(opts => DownloadFile(opts.FileName, opts.Destination))
				.WithParsed<MoveOptions>(opts => MoveFile(opts.FileName, opts.NewFileName))
				.WithParsed<RemoveOptions>(opts => RemoveFile(opts.FileName))
				.WithParsed<FileInfoOptions>(opts => PrintFileInfo(opts.FileName))
				.WithParsed<ListOptions>(opts => ListFiles())
				.WithParsed<ExportOptions>(opts => ExportMetaInfo(opts.Path, opts.Format, opts.IsInfo));
		}


		private void UploadFile(string sourcePath)
		{
			Storage.Upload(sourcePath);
		}


		private void DownloadFile(string fileName, string destination)
		{
			var file = SearchAndChoice(fileName);
			Storage.Download(file.Hash, destination);
		}

		private void MoveFile(string fileName, string newFileName)
		{
			var file = SearchAndChoice(fileName);
			Storage.Move(file.Hash, newFileName);
		}

		private void RemoveFile(string fileName)
		{
			var file = SearchAndChoice(fileName);
			Storage.Remove(file.Hash);
		}

		private void PrintHelp()
		{
			_colorfulConsole.WriteLine("Use file --help or user --help for more information.");
		}

		private IFileMetaInfo SearchAndChoice(string fileName)
		{
			var files = Storage.Search(fileName);

			if (files.Length == 0)
				throw new FileNotFoundException("File not exist", fileName);

			return files.Length > 1 ? Choice(files) : files.First();
		}

		private void ListFiles()
		{
			var files = Storage.GetFiles();
			foreach (var file in files)
			{
				PrintFileInfo(file);
				_colorfulConsole.WriteLine();
			}
		}

		private void PrintFileInfo(string fileName)
		{
			var result = Storage.Search(fileName);

			if (result.Length == 0)
				throw new FileNotFoundException("File does not exist!", fileName);

			foreach (var file in result)
			{
				PrintFileInfo(file);
				_colorfulConsole.WriteLine();
			}
		}

		private void PrintFileInfo(IFileMetaInfo file)
		{
			_colorfulConsole.WriteLine(
					$"File name:\t\t{file.FileName}{Environment.NewLine}" +
					$"Creation date:\t\t{file.CreationDateTime:yyyy - MM - ddTHH\\:mm\\:ss.fffffffzzz}{Environment.NewLine}" +
					$"Size:\t\t\t{file.Size} b{Environment.NewLine}" +
					$"Download count:\t\t{file.DownloadsCount}{Environment.NewLine}" +
					$"Author:\t\t\t{file.Author}{Environment.NewLine}" +
					$"Checksum:\t\t{file.Hash}");
		}

		private void PrintUserInfo()
		{
			_colorfulConsole.WriteLine($"Login:\t\t\t{Storage.User.Login}{Environment.NewLine}" +
				$"Creation date:\t\t{Storage.User.CreationDate:yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz}{Environment.NewLine}" +
				$"Used:\t\t\t{Storage.Used} bytes{Environment.NewLine}" +
				$"Storage limit:\t\t{Storage.User.StorageLimit}{Environment.NewLine}" +
				$"Maximum file size:\t{Storage.User.MaximumSizeOfUploadedFiles}");
		}

		private void PrintUserUsage()
		{
			_colorfulConsole.WriteLine($"Used: {Storage.Used} bytes");
		}

		private IFileMetaInfo Choice(IFileMetaInfo[] files)
		{
			IFileMetaInfo file;
			for (int i = 0; i < files.Length; i++)
			{
				file = files[i];
				_colorfulConsole.Write($"{i + 1}. ");
				PrintFileInfo(file);
				_colorfulConsole.WriteLine();
			}

			_colorfulConsole.Write("Please, make a choice: ");
			int choice = Convert.ToInt32(_colorfulConsole.ReadLine());
			--choice;

			if (choice < 0 || choice >= files.Length)
				throw new ArgumentException("Incorrect choice!");

			return files[choice];
		}


		private void ExportMetaInfo(string path, string format, bool info)
		{
			if (info)
			{
				ShowExportInformation();
				return;
			}

			Storage.Export(path, format);
		}


		private void ShowExportInformation()
		{
			foreach (var format in Storage.ExportFormats)
				_colorfulConsole.WriteLine($"- {format}");
		}
	}
}
