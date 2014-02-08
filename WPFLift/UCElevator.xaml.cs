using System.Windows.Controls;
using System;
using System.Windows.Media.Animation;
using System.Timers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace WPFLift
{
	/// <summary>
	/// 作者：xxh 
	/// 时间：2014-01-10 12:10:14
	/// 版本：V1.0.0 	 
	/// </summary>
	public partial class UCElevator : UserControl
	{
		#region 变量
		Storyboard story1;
		Storyboard story2;
		Storyboard story3;
		Storyboard story4;
		Timer timerWait;
		TranslateTransform translateMain;
		List<Storyboard> listStoryboard = new List<Storyboard>();
		ElevatorState elevatorState = ElevatorState.Stop;
		Floor currentFloor = Floor.F4;
		#endregion

		#region 属性

		#endregion

		#region 委托事件
		public event Action<Floor, RequestType> GoTargetFloorEvent;
		public void OnGoTargetFloorEvent(Floor targetFloor, RequestType reqType)
		{
			if (GoTargetFloorEvent != null)
			{
				GoTargetFloorEvent(targetFloor, reqType);
			}
		}
		#endregion

		#region 构造函数
		public UCElevator()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			NameScope.SetNameScope(this, new NameScope());
			InitStoryboard();
			InitTimer();
		}
		#endregion

		#region 业务
		#region 单击楼层
		private void chb1_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (currentFloor == Floor.F1)
			{
				chb1.IsChecked = false;
			}

			if ((bool)chb1.IsChecked)
			{
				listStoryboard.Add(story1);
			}
			else
			{
				listStoryboard.Remove(story1);
			}

			RestartTimer();
		}

		private void chb2_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (currentFloor == Floor.F2)
			{
				chb2.IsChecked = false;
			}

			if ((bool)chb2.IsChecked)
			{
				listStoryboard.Add(story2);
			}
			else
			{
				listStoryboard.Remove(story2);
			}

			RestartTimer();
		}

		private void chb3_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (currentFloor == Floor.F3)
			{
				chb3.IsChecked = false;
			}

			if ((bool)chb3.IsChecked)
			{
				listStoryboard.Add(story3);
			}
			else
			{
				listStoryboard.Remove(story3);
			}

			RestartTimer();
		}

		private void chb4_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (currentFloor == Floor.F4)
			{
				chb4.IsChecked = false;
			}

			if ((bool)chb4.IsChecked)
			{
				listStoryboard.Add(story4);
			}
			else
			{
				listStoryboard.Remove(story4);
			}

			RestartTimer();
		} 
		#endregion

		private void InitTimer()
		{
			timerWait = new Timer();
			timerWait.Interval = 3000;
			timerWait.Elapsed += new ElapsedEventHandler(timerWait_Elapsed);
		}

		void timerWait_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				BeginFirstAnimation(); 
			}));

			timerWait.Stop();
		}

		private void BeginFirstAnimation()
		{
			if (listStoryboard.Count > 0)
			{
				listStoryboard[0].Begin(this, true);
			}
		}

		private void RestartTimer()
		{
			timerWait.Stop();
			timerWait.Start();
		}

		private void InitStoryboard()
		{
			story1 = new Storyboard();
			story2 = new Storyboard();
			story3 = new Storyboard();
			story4 = new Storyboard();

			translateMain = new TranslateTransform();
			((TransformGroup)this.RenderTransform).Children.Add(translateMain);
			string RenderName = "UCRender";
			this.RegisterName(RenderName, translateMain);

			DoubleAnimation daFloor1 = new DoubleAnimation();
			DoubleAnimation daFloor2 = new DoubleAnimation();
			DoubleAnimation daFloor3 = new DoubleAnimation();
			DoubleAnimation daFloor4 = new DoubleAnimation();
			TimeSpan tsMain = TimeSpan.FromSeconds(2);

			daFloor1.Duration = tsMain;
			daFloor2.Duration = tsMain;
			daFloor3.Duration = tsMain;
			daFloor4.Duration = tsMain;

			daFloor1.To = (double)Floor.F1;
			daFloor2.To = (double)Floor.F2;
			daFloor3.To = (double)Floor.F3;
			daFloor4.To = (double)Floor.F4;

			Storyboard.SetTargetName(daFloor1, RenderName);
			Storyboard.SetTargetProperty(daFloor1, new PropertyPath(TranslateTransform.YProperty));
			Storyboard.SetTargetName(daFloor2, RenderName);
			Storyboard.SetTargetProperty(daFloor2, new PropertyPath(TranslateTransform.YProperty));
			Storyboard.SetTargetName(daFloor3, RenderName);
			Storyboard.SetTargetProperty(daFloor3, new PropertyPath(TranslateTransform.YProperty));
			Storyboard.SetTargetName(daFloor4, RenderName);
			Storyboard.SetTargetProperty(daFloor4, new PropertyPath(TranslateTransform.YProperty));

			story1.Children.Add(daFloor1);
			story2.Children.Add(daFloor2);
			story3.Children.Add(daFloor3);
			story4.Children.Add(daFloor4);

			story1.Completed += new EventHandler(story1_Completed);
			story2.Completed += new EventHandler(story2_Completed);
			story3.Completed += new EventHandler(story3_Completed);
			story4.Completed += new EventHandler(story4_Completed);
			story1.CurrentTimeInvalidated += new EventHandler(story_CurrentTimeInvalidated);
			story2.CurrentTimeInvalidated += new EventHandler(story_CurrentTimeInvalidated);
			story3.CurrentTimeInvalidated += new EventHandler(story_CurrentTimeInvalidated);
			story4.CurrentTimeInvalidated += new EventHandler(story_CurrentTimeInvalidated);
		}

		void story1_Completed(object sender, EventArgs e)
		{
			listStoryboard.Remove(story1);
			chb1.IsChecked = false;
			currentFloor = Floor.F1;
			RestartTimer();
		}

		void story2_Completed(object sender, EventArgs e)
		{
			listStoryboard.Remove(story2);
			chb2.IsChecked = false;
			currentFloor = Floor.F2;

			RestartTimer();
		}

		void story3_Completed(object sender, EventArgs e)
		{
			listStoryboard.Remove(story3);
			chb3.IsChecked = false;
			currentFloor = Floor.F3;
			RestartTimer();
		}

		void story4_Completed(object sender, EventArgs e)
		{
			listStoryboard.Remove(story4);
			chb4.IsChecked = false;
			currentFloor = Floor.F4;
			RestartTimer();
		}

		void story_CurrentTimeInvalidated(object sender, EventArgs e)
		{
			double height = translateMain.Y;
			if (height >= 0 && height < (double)Floor.F3)
			{
				currentFloor = Floor.F4;
			}
			else if (height >= (double)Floor.F3 && height < (double)Floor.F2)
			{
				currentFloor = Floor.F3;
			}
			else if (height >= (double)Floor.F2 && height < (double)Floor.F1)
			{
				currentFloor = Floor.F2;
			}
			else
			{
				currentFloor = Floor.F1;
			}
		}

		#region 单步执行
		private void GoFloor1()
		{
			story1.Begin(this, true);
		}

		private void GoFloor2()
		{
			story2.Begin(this, true);
		}

		private void GoFloor3()
		{
			story3.Begin(this, true);
		}

		private void GoFloor4()
		{
			story4.Begin(this, true);
		} 
		#endregion

		
		#endregion


	}
}
