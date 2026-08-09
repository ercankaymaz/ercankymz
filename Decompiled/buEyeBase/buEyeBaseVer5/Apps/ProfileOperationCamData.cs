using System;
using System.Collections;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationCamData : buSerilization5
{
	public double distanceSafe = 50.0;

	public double distanceRapid = 20.0;

	public double distanceFirstApproach = 30.0;

	public double velPlunge = 30.0;

	public double velFeed = 50.0;

	public double velFinish = 40.0;

	public double velLeave = 100.0;

	public double velAreaClearance = 60.0;

	public double stepDistance = 1.0;

	public int stepCount = 1;

	public double NotchCutPersentage = 90.0;

	public double NotchSafeDistance = 50.0;

	public double offsetFinish = 1.0;

	public bool LeadIn = false;

	public bool LeadOut = false;

	public bool enableAreaClearanceOperation = false;

	public bool enableFinishOperation = false;

	public bool enableStepOperation = false;

	public bool enableOpenContourTwoDirectionCutOperation = false;

	public InToOutType AreaClearanceDirection = InToOutType.InToOut;

	public ClockDirectionType directionContour = ClockDirectionType.CW;

	public CamClosedContourType typeClosedContour = CamClosedContourType.Inner;

	public CamOpenContourType typeOpenContour = CamOpenContourType.Center;

	public ProfileNotchCutType NotchCutType = ProfileNotchCutType.BySaw;

	public ProfileOperationCamData()
	{
	}

	public ProfileOperationCamData(ProfileOperationCamData data)
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
		string text = "Safe Dis: " + distanceSafe + " , Small Safe: " + distanceRapid + " , Offset Type: " + typeClosedContour;
		if (enableStepOperation)
		{
			text = text + "Step Dis : " + stepDistance + " , Count: " + stepCount;
		}
		return text;
	}

	public static ArrayList ToDefPars(ProfileOperationCamData P, string Char, int Space)
	{
		string text = "ProfileOperationCamDataPars";
		if (Char.Trim().Length > 0)
		{
			text = Char;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<" + text);
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</" + text);
		return arrayList;
	}

	public static ArrayList ToDefPars(ProfileOperationCamData P, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<ProfileOperationCamDataPars>");
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</ProfileOperationCamDataPars>");
		return arrayList;
	}

	public static string ToDefPars(ProfileOperationCamData P)
	{
		return buSerilization5.ClassToString(P);
	}
}
