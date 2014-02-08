using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFLift
{
	/// <summary>
	/// 楼层
	/// </summary>
	public enum Floor
	{
		F1 = 480,	//floor 1
		F2 = 320,	//floor 2
		F3 = 160,	//floor 3
		F4 = 0		//floor 4
	}

	/// <summary>
	/// 电梯状态
	/// </summary>
	public enum ElevatorState
	{
		Up,		//上
		Down,	//下
		Stop	//停止
	}

	/// <summary>
	/// 请求
	/// </summary>
	public enum Request
	{
		Up,	//上
		Down//下
	}

	/// <summary>
	/// 人员状态
	/// </summary>
	public enum PersonState
	{
		In,		//进
		Out,	//出
		Wait	//等待
	}

	/// <summary>
	/// 请求类型
	/// </summary>
	public enum RequestType
	{ 
		Add,	//添加请求
		Remove	//移除请求
	}
}
