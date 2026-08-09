using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LibraryRuntime : buSerilization
{
	public double dX = 0.0;

	public double dY = 0.0;

	public bool isBasePositionMoved = false;

	public bool isCatchPositionMoved = false;

	public int EntitiyIndex = -1;

	public int DimensionEntityIndex = -1;

	public List<Pnt3D> MovedPoints = new List<Pnt3D>();

	public LibraryRuntime()
	{
	}

	public LibraryRuntime(LibraryRuntime data)
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
		MovedPoints.Clear();
		Pnt3D.Copy(data.MovedPoints, ref MovedPoints);
	}

	public LibraryRuntime(double dx, double dy, bool isBasePosition, bool isCatchPosition, int EntIndex)
	{
		dX = dx;
		dY = dy;
		isBasePositionMoved = isBasePosition;
		isCatchPositionMoved = isCatchPosition;
		EntitiyIndex = EntIndex;
	}

	public override string ToString()
	{
		return "Ent Index:" + EntitiyIndex + " - Dim Index:" + DimensionEntityIndex + " - Catch:" + isCatchPositionMoved + " - Base:" + isBasePositionMoved;
	}
}
