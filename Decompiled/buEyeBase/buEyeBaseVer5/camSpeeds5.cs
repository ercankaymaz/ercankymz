using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camSpeeds5 : buSerilization5
{
	public double Feed = 100.0;

	public bool FeedEnable = false;

	public double BackwardFeed = 100.0;

	public bool BackwardEnable = false;

	public double Plunge = 20.0;

	public bool PlungeEnable = false;

	public double Rapid = 500.0;

	public bool RapidEnable = false;

	public double Leave = 300.0;

	public bool LeaveEnable = false;

	public double Finish = 20.0;

	public bool FinishEnable = false;

	public double FirstStep = 20.0;

	public double SpindleSpeed = 0.0;

	public bool SpindleEnable = false;

	public ClockDirectionType SpindleDirection = ClockDirectionType.CW;

	public bool SpindleDirectionEnable = false;

	public double AreaClearance = 0.0;

	public double Pocket = 0.0;

	public bool AreaClearanceEnable = false;

	public static List<string> Captions = new List<string>();

	public camSpeeds5()
	{
	}

	public camSpeeds5(double feed, double plunge, double rapid, double leave, double backwardfeed, double finish)
	{
		Feed = feed;
		Plunge = plunge;
		Rapid = rapid;
		Leave = leave;
		BackwardFeed = backwardfeed;
		Finish = finish;
	}

	public camSpeeds5(camSpeeds5 speeds)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(speeds, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Feed: " + Feed + " , Plunge: " + Plunge + " , Rapid: " + Rapid + " , Leave: " + Leave;
	}
}
