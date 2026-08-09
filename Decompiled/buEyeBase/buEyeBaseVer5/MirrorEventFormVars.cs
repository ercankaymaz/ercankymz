using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class MirrorEventFormVars : buSerilization5
{
	public ContentAlignment Alignment = ContentAlignment.BottomLeft;

	public MirrorAxisXYType MirrorAxis = MirrorAxisXYType.X;

	public bool ShowAligment = true;

	public bool DeleteOriginal = true;

	public MirrorEventFormVars()
	{
	}

	public MirrorEventFormVars(MirrorEventFormVars data)
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
