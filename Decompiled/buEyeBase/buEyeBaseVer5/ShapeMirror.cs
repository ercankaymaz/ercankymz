using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class ShapeMirror : buSerilization5
{
	public bool MirrorEnable = false;

	public MirrorAxisXYType MirrorAxis = MirrorAxisXYType.X;

	public MinCenterMaxType MirrorLocation = MinCenterMaxType.Min;

	public double MirrorDistance = 0.0;

	public MirrorModeType MirrorMode = MirrorModeType.FromCenter;

	public ShapeMirror()
	{
	}

	public ShapeMirror(ShapeMirror data)
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
		return "Enable :" + MirrorEnable + " , Axis : " + MirrorAxis.ToString() + " , Location : " + MirrorLocation.ToString() + " , Mode : " + MirrorMode;
	}
}
