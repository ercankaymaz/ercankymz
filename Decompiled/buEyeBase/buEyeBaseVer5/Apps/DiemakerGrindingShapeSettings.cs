using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DiemakerGrindingShapeSettings : buSerilization5
{
	public double BaseMaterialHeight = 23.9;

	public double TargetMaterialHeight = 23.8;

	public double MaterialThickness = 0.71;

	public double VShapeTargetAngle = 42.0;

	public double VShapeHeightWidth = 5.0;

	public double VShapeHeightRoughDepth = 0.05;

	public double VShapeHeightFinishDepth = 0.01;

	public double VShapeHeightRoughVel = 40.0;

	public double VShapeHeightFinishVel = 5.0;

	public double VShapeHeightRoughSpindleSpeed = 3000.0;

	public double VShapeHeightFinishSpindleSpeed = 4000.0;

	public bool VShapeHeightZigzag = true;

	public int VShapeHeightToolNo = 2;

	public double FeedDistance = 3.0;

	public int FeedCount = 1;

	public double GrindingLength = 10.0;

	public double ToolPersentage = 80.0;

	public double NickWidth = 5.0;

	public double NickDepth = 22.0;

	public double NickFinishDepth = 0.01;

	public double NickRoughVel = 40.0;

	public double NickFinishVel = 5.0;

	public double NickRoughSpindleSpeed = 3000.0;

	public double NickFinishSpindleSpeed = 4000.0;

	public int NickToolNo = 2;

	public bool NickEnable = false;

	public bool NickReverseDir = false;

	public bool VShapeAngleEnable = true;

	public double VShapeAngleWidth = 5.0;

	public double VShapeAngleRoughDepth = 0.05;

	public double VShapeAngleFinishDepth = 0.01;

	public double VShapeAngleRoughVel = 40.0;

	public double VShapeAngleFinishVel = 5.0;

	public double VShapeAngleRoughSpindleSpeed = 3000.0;

	public double VShapeAngleFinishSpindleSpeed = 4000.0;

	public double VShapeAngleOffset = -0.02;

	public bool VShapeAngleZigzag = true;

	public int VShapeAngleToolNo = 2;

	public int VShapeAngleFinishCount = 1;

	public UpDownDirectionType VShapeAngleUpDownMode = UpDownDirectionType.UpToDown;

	public DiemakerGrindingShapeSettings()
	{
	}

	public DiemakerGrindingShapeSettings(DiemakerGrindingShapeSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
}
