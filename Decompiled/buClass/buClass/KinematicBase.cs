using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class KinematicBase : buSerilization
{
	public Pnt3D OffsetXYZ = new Pnt3D();

	public OrientationAngle OffsetABC = new OrientationAngle();

	public Pnt3D RotateCenterOffsetOfA = new Pnt3D();

	public Pnt3D RotateCenterOffsetOfB = new Pnt3D();

	public Pnt3D RotateCenterOffsetOfC = new Pnt3D();

	public Pnt3D MovePartRuntimeOffset = new Pnt3D();

	public KinemeticType Type = KinemeticType.CartezianXYZ_3Axis;

	public List<KinematicItem> Items = new List<KinematicItem>();

	public string Name = "Kinematic";

	public string FileName = "";

	public static List<string> Captions = new List<string>();

	public KinematicBase()
	{
	}

	public KinematicBase(KinematicBase data)
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
		Items.Clear();
		for (int j = 0; j <= data.Items.Count - 1; j++)
		{
			KinematicItem item = new KinematicItem(data.Items[j]);
			Items.Add(item);
		}
	}

	public override string ToString()
	{
		return "Type: " + Type;
	}
}
