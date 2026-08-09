using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileClamperSettings : buSerilization5
{
	public double MinDistanceFor2Clamper = 250.0;

	public double MaxDistanceFor2Clamper = 3000.0;

	public double ClamperWidth = 80.0;

	public double ClamperSafeDistance = 10.0;

	public double OperationFrontLeftMinDistance = 360.0;

	public double OperationFrontRightMinDistance = 100.0;

	public double OperationBackLeftMinDistance = 100.0;

	public double OperationBackRightMinDistance = 100.0;

	public double OperationTopLeftMinDistance = 100.0;

	public double OperationTopRightMinDistance = 100.0;

	public double StartOffset = 50.0;

	public double EndOffset = 50.0;

	public double StartMaxDistance = 150.0;

	public double EndMaxDistance = 150.0;

	public double ClamperMaxHeight = 150.0;

	public double NotchSafeXDistance = 20.0;

	public double NextOperationsSearchDistance = 70.0;

	public double ClamperOptimisationLevel = 4.0;

	public bool ApplyManuelNewClamperToNext = true;

	public double FreePlaneToBackFrontAngleLimit = 15.0;

	public double ClamperProfileOutsideOffset = 500.0;

	public bool IfClamperOverOrCloseToAnotherOneMovetoLimit = true;

	public double OperationClamperLeftMaxDistance = 500.0;

	public double OperationClamperRightMaxDistance = 500.0;

	public double LastClamperExtensionLimit = 250.0;

	public profileSortSequenceAtSamePosition SortSequenceAtSamePosition = profileSortSequenceAtSamePosition.FrontTopBack;

	public int ClamperCalculationMode = 0;

	public ProfileClamperSettings()
	{
	}

	public ProfileClamperSettings(ProfileClamperSettings data)
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
