using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class ProfileOperationMoveClamper : ProfileOperation
{
	public Pnt3D ClamperPosition = new Pnt3D();

	public ProfileOperationMoveClamper()
	{
	}

	public ProfileOperationMoveClamper(ProfileOperationMoveClamper data)
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
		SlopePlane = new Quad3D(data.SlopePlane);
		OperationData = new ProfileOperationData(data.OperationData);
		Plane = new WorkPlane(data.Plane);
		Depth = data.Depth;
		DrawPoints.Clear();
		DrawPoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.DrawPoints, ref DrawPoints);
		CamPoints.Clear();
		CamPoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(data.CamPoints, ref CamPoints);
		Tool = new ToolBase(data.Tool);
		CamCalculation.Clear();
		for (int j = 0; j <= data.CamCalculation.Count - 1; j++)
		{
			CamCalculation.Add(new camBase(data.CamCalculation[j]));
		}
		CamParMilling = new camParameters(data.CamParMilling);
		CamParNotch = new camParameters(data.CamParNotch);
	}

	public override string ToString()
	{
		return "Clamper ";
	}
}
