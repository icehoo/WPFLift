using System.Windows;
using System;

namespace WPFLift
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Version versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			//string major = version.Major.ToString();
			//string minor = version.Minor.ToString();
			tblVersion.Text = versionInfo.ToString();
		}
	}
}
