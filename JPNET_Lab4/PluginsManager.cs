using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace JPNET_Lab4
{
	public class PluginsManager
	{
		[ImportMany(typeof(ICalculator), AllowRecomposition = true)]
		private readonly List<ICalculator> calculators = new();
		public List<ICalculator> GetCalculators() => calculators;


		private readonly FileSystemWatcher fileSystemWatcher;
		private readonly AggregateCatalog aggregateCatalog;
		private readonly string pluginsPath;
		public event EventHandler? FilesChanged;

		public PluginsManager()
		{
			if (ConfigurationManager.AppSettings["pluginsPath"] == null)
				return;

			pluginsPath = ConfigurationManager.AppSettings["pluginsPath"].ToString();
			aggregateCatalog = new AggregateCatalog();
			fileSystemWatcher = new FileSystemWatcher(pluginsPath);

			SetUp();
		}

		private void SetUp()
		{
			var compositionBatch = new CompositionBatch();
			compositionBatch.AddPart(this);

			fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
								   | NotifyFilters.CreationTime
								   | NotifyFilters.DirectoryName
								   | NotifyFilters.FileName
								   | NotifyFilters.LastAccess
								   | NotifyFilters.LastWrite
								   | NotifyFilters.Security
								   | NotifyFilters.Size;

			fileSystemWatcher.Created += OnFilesChange;
			fileSystemWatcher.Deleted += OnFilesChange;
			fileSystemWatcher.Filter = "*.dll";
			fileSystemWatcher.EnableRaisingEvents = true;

			aggregateCatalog.Catalogs.Add(new DirectoryCatalog(pluginsPath));

			var compositionContainer = new CompositionContainer(aggregateCatalog);
			compositionContainer.Compose(compositionBatch);
		}

		private void OnFilesChange(object sender, FileSystemEventArgs e)
		{
			aggregateCatalog.Catalogs.Clear();
			aggregateCatalog.Catalogs.Add(new DirectoryCatalog(pluginsPath));

			FilesChanged?.Invoke(this, e);
		}
	}
}
