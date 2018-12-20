using System.Drawing;
using TrivialArchitecture.UI.Console.Interfaces;

namespace TrivialArchitecture.UI.Console
{
    class StorageEventHandler
    {
        public IStorageService Storage { get; }

        private readonly IColorfulConsole _colorfulConsole;

        public StorageEventHandler(IStorageService storageService, IColorfulConsole colorfulConsole)
        {
            Storage = storageService;
            _colorfulConsole = colorfulConsole;

            Storage.UploadCompleated += Storage_UploadCompleated;
            Storage.DownloadCompleated += Storage_DownloadCompleated;
            Storage.MoveCompleated += Storage_MoveCompleated;
            Storage.RemoveCompleated += Storage_RemoveCompleated;
            Storage.FileChangedWarning += Storage_FileChangedWarning;
            Storage.MetainfoExportCompleated += Storage_MetainfoExportCompleated;
        }

        private void Storage_RemoveCompleated(object sender, RemoveCompleatedEventArgs e)
        {
            _colorfulConsole.WriteLineFormatted("{0} File {1} successfully removed!", Color.Green, Color.White, "Success!", e.FileName);
        }

        private void Storage_MoveCompleated(object sender, MoveCompleatedEventArgs e)
        {
            _colorfulConsole.WriteLineFormatted("{0} File \"{1}\" successfully renamed to \"{2}\"!", Color.Green, Color.White, "Success!", e.OldName, e.NewName);
        }

        private void Storage_DownloadCompleated(object sender, DownloadCompleatedEventArgs e)
        {
            _colorfulConsole.WriteLineFormatted("{0} File \"{1}\" successfully downloaded to \"{2}\"!", Color.Green, Color.White, "Success!", e.FileName, e.Destination);
        }

        private void Storage_UploadCompleated(object sender, UploadCompleatedEventArgs e)
        {
            _colorfulConsole.WriteLineFormatted("{0} File \"{1}\" successfully uploaded!", Color.Green, Color.White, "Success!", e.SourcePath);
        }

        private void Storage_FileChangedWarning(object sender, FileChangedWarningEventArgs e)
        {
            Program.Logger.Warn($"File {e.FileName}({e.Hash}) has changed!");
            _colorfulConsole.WriteLineFormatted("{0} File {1} has changed!", Color.Yellow, Color.WhiteSmoke, "WARNING!", $"{e.FileName}({e.Hash})");
        }

        private void Storage_MetainfoExportCompleated(object sender, MetainfoExportCompleatedEventArgs e)
        {
            _colorfulConsole.WriteLineFormatted("{0} The metainformation has been exported to \"{1}\"", Color.Green, Color.White, "Success!", e.Path);
        }
    }
}
