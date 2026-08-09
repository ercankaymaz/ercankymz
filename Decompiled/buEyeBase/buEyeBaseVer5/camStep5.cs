using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camStep5 : buSerilization5
{
	public bool Enable = false;

	public double FirstValue = 0.0;

	public double StartValue = 20.0;

	public double EndValue = 0.0;

	public double Distance = 10.0;

	public double DepthStep = 1.0;

	public double StartOffset = 0.0;

	public double EndOffset = 0.0;

	public int NumberOfSlice = 1;

	public int Count = 1;

	public double Step = 2.0;

	public double MoveUp = 1.0;

	public int NumberOfPasses4DepthStep = 0;

	public double FinalDepthStep = 0.0;

	public bool MoveUpEnable = false;

	public bool DepthStepEnable = false;

	public CamMoveUpType MoveUpType = CamMoveUpType.Absolute;

	public CamStepType StepType = CamStepType.StartToDistanceByCount;

	public CamStepDepthMode DepthStepMode = CamStepDepthMode.ConstantDepthStep;

	public CamHeightsType HeightType = CamHeightsType.ShpHtAutomatic;

	public static List<string> Captions = new List<string>();

	public camStep5()
	{
	}

	public camStep5(bool enable, double startValue, double endValue, double distance, int count, double step, CamStepType type)
	{
		Enable = enable;
		StartValue = startValue;
		EndValue = endValue;
		Distance = distance;
		Count = count;
		Step = step;
		StepType = type;
	}

	public camStep5(camStep5 step)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(step, ref CopiedClass);
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
		return Enable + " , Cnt: " + Count + " , Start: " + StartValue + " , Dis: " + Distance;
	}
}
