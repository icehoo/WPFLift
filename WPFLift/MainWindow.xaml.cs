using System.Windows;
using System;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Timers;
using System.Collections.Generic;

namespace WPFLift
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		#region 变量
		
		#endregion

		#region 属性

		#endregion

		#region 委托事件

		#endregion

		#region 构造函数
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Version versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			tblVersion.Text = versionInfo.ToString();
		}
		#endregion

		#region 业务
		
		#endregion
	}
}
