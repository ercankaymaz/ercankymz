using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingRuntimeSettings : buSerilization5
{
	public string pathTeachFile = Application.StartupPath;

	public double PunterizWidth = 2.0;

	public double PunterizHeigth = 3.0;

	public double PunterizLength = 30.0;

	public double MoveDistance = 1.0;

	public double RotateDegree = 10.0;

	public double FootHeight = 15.0;

	public double StitchLen = 0.0;

	public double SewingOffset = 0.0;

	public double SewingSpeed = 0.0;

	public int LockStitcCount = 0;

	public SewingAddStitchType LockStitchType = SewingAddStitchType.OneWay;

	public SewingPunterizType PunterizType = SewingPunterizType.CenterLeft;

	public LeftRightType OffsetType = LeftRightType.Left;

	public SortingNextGroupFindRulesType NextRules = SortingNextGroupFindRulesType.ClosestLength;

	public bool ShowDialog = false;

	public Point3D pntStart = new Point3D();

	public SewingRuntimeSettings()
	{
	}

	public SewingRuntimeSettings(SewingRuntimeSettings data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
