using System.Reflection;
using buClass;
using buEyeBaseVer5;
using devDept.Geometry;

namespace buCadCamResVer5.Library;

public class LibraryConstraints : buSerilization5
{
	public int FirstIndex = -1;

	public int SecondIndex = -1;

	public Point3D refPoint = new Point3D();

	public ConstraintsType Type = ConstraintsType.EqualLength;

	public LibraryConstraints()
	{
	}

	public LibraryConstraints(LibraryConstraints data)
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

	public override string ToString()
	{
		string text = Type.ToString();
		if (FirstIndex >= 0)
		{
			text = text + " , First: " + FirstIndex;
		}
		if (SecondIndex >= 0)
		{
			text = text + " , Second: " + SecondIndex;
		}
		if ((refPoint.X != 0.0) | (refPoint.Y != 0.0) | (refPoint.Y != 0.0))
		{
			text = text + " - " + refPoint.ToString();
		}
		return text;
	}
}
