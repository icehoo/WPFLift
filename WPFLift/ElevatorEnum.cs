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
		F1 = 0,	//floor 1
		F2 = 1,	//floor 2
		F3 = 2,	//floor 3
		F4 = 3	//floor 4
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

	public enum PersonState
	{ 
		In,		//进
		Out,	//出
		Wait	//等待
	}
}
