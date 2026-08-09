using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class ShapeEdit : buSerilization5
{
	public ShapeMirror MirrorData = new ShapeMirror();

	public ShapeArray ArrayData = new ShapeArray();

	public double RotateDegree = 0.0;

	public double HorizontanAngle = 0.0;

	public double VerticalAngle = 0.0;

	public ShapeEdit()
	{
	}

	public ShapeEdit(ShapeEdit data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		MirrorData = new ShapeMirror(data.MirrorData);
		ArrayData = new ShapeArray(data.ArrayData);
	}

	public void MmToInch()
	{
		ArrayData.LineerXDistance = Math.Round(ArrayData.LineerXDistance * buSystem.MmToInchRatio, 5);
		ArrayData.LineerYDistance = Math.Round(ArrayData.LineerYDistance * buSystem.MmToInchRatio, 5);
		MirrorData.MirrorDistance = Math.Round(MirrorData.MirrorDistance * buSystem.MmToInchRatio, 5);
	}

	public void InchToMm()
	{
		ArrayData.LineerXDistance = Math.Round(ArrayData.LineerXDistance * buSystem.InchToMmRatio, 5);
		ArrayData.LineerYDistance = Math.Round(ArrayData.LineerYDistance * buSystem.InchToMmRatio, 5);
		MirrorData.MirrorDistance = Math.Round(MirrorData.MirrorDistance * buSystem.InchToMmRatio, 5);
	}

	public override string ToString()
	{
		return "Degree: " + RotateDegree + " , Mirror : " + MirrorData.MirrorEnable + " , Lineer Array: " + ArrayData.LineerEnable + " , Circular Array: " + ArrayData.CircularEnable;
	}
}
