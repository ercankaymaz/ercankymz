using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camRotary5 : buSerilization5
{
	public CamTiltStrategy TiltStrategy = CamTiltStrategy.NoTilt;

	public CamSideTiltDefTypes SideTiltDefTypes = CamSideTiltDefTypes.OrthoToCutDirAtEachPos;

	public double LagAngle = 0.0;

	public double SideTiltAngle = 0.0;

	public double MaxAngleChange = 3.0;

	public bool LimitsFlg = true;

	public bool SmoothingFlg = true;

	public double MaxAngleFromInitialToolOrientation = 30.0;

	public bool UndercutsFlg = false;

	public double TiltAngleFixed = 0.0;

	public double RotaryAngle = 0.0;

	public bool AxisMeetTiltFlg = false;

	public bool MaintainTiltFlg = false;

	public CamExtAxis TiltAxis = CamExtAxis.ExtAxisZ;

	public bool BAngleLimitInXZPlaneFlg = false;

	public double BAngleLimitStartInXZPlane = 45.0;

	public double BAngleLimitEndInXZPlane = 135.0;

	public bool AAngleLimitInYZPlaneFlg = false;

	public double AAngleLimitStartInYZPlane = 45.0;

	public double AAngleLimitEndInYZPlane = 135.0;

	public bool CAngleLimitInXYPlaneFlg = false;

	public double CAngleLimitStartInXYPlane = 0.0;

	public double CAngleLimitEndInXYPlane = 360.0;

	public bool WOrtAngleLimitFlg = false;

	public double WOrtAngleLimitStart = 0.0;

	public double WOrtAngleLimitEnd = 100.0;

	public static List<string> Captions = new List<string>();

	public camRotary5()
	{
	}

	public camRotary5(camRotary5 data)
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

	public override string ToString()
	{
		return TiltStrategy.ToString();
	}
}
