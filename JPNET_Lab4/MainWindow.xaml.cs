using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JPNET_Lab4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private PluginsManager pluginManager;

		public MainWindow()
		{
			InitializeComponent();

			pluginManager = new PluginsManager();
			pluginManager.FilesChanged += OnFilesChanged;

			foreach (var plugin in pluginManager.GetCalculators())
			{
				Tabs.Items.Add(new TabItem { Header = plugin.Name, Content = plugin.GetUserControl() });
			}
		}

		private void OnFilesChanged(object? sender, EventArgs e)
		{
			Dispatcher.BeginInvoke(
				new ThreadStart(() =>
				{
					Tabs.Items.Clear();

					foreach (var plugin in pluginManager.GetCalculators())
					{
						Tabs.Items.Add(new TabItem { Header = plugin.Name, Content = plugin.GetUserControl() });
					}
				})
			);
		}
	}
}
