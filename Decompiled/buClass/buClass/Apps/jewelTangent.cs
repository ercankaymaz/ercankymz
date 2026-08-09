using System.Reflection;

namespace buClass.Apps;

public class jewelTangent : buSerilization
{
	public bool Enable = false;

	public double LimitAngle = 0.0;

	public double MinAngle = 0.0;

	public double MaxAngle = 180.0;

	public double Offset = 0.0;

	public double ContantAngle = 0.0;

	public bool UseLimitAngle = false;

	public bool UseContantAngle = false;

	public bool UseMirrorAngle = false;

	public bool UseNoScaleEntities = false;

	public bool LimitAngleUseNextCValue = true;

	public jewelTangentType Type = jewelTangentType.Continous;

	public jewelTangent()
	{
	}

	public jewelTangent(jewelTangent data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
