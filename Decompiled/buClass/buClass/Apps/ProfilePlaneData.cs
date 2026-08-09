using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfilePlaneData : buSerilization
{
	public planeNames PlaneSelectedName = planeNames.Top;

	public WorkPlane PlaneSelected = new WorkPlane();

	public Pnt3D PlaneCreateSlopeDistance = new Pnt3D();

	public planeInclineType PlaneCreateProfileType = planeInclineType.Distance;

	public LeftRightLocationType PlaneCreateSlopeDirection = LeftRightLocationType.Left;

	public double PlaneCreateProfileAngle = 0.0;

	public double PlaneCreateProfileLength = 0.0;

	public ProfilePlaneData()
	{
	}

	public ProfilePlaneData(ProfilePlaneData data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		PlaneSelected = new WorkPlane(data.PlaneSelected);
	}
}
