using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class GCodePoint : buSerilization
{
	public Pnt9D Offset = new Pnt9D();

	public Pnt9D Positions = new Pnt9D();

	public int CodeType = 0;

	public bool isMCode = false;

	public bool isGCode = false;

	public bool isTCode = false;

	public bool isG0Move = false;

	public ToolBase Tool = new ToolBase();

	public IJK IJKValue = new IJK();

	public double SpindleSpeed = 0.0;

	public double Feed = 0.0;

	public double R = 0.0;

	public double MValue = 0.0;

	public double GValue = 0.0;

	public double TValue = 0.0;

	public string CodeString = "";

	public string Aux = "";

	public geoEntity Entity = new geoEntity();

	public GCodePoint()
	{
	}

	public GCodePoint(GCodePoint data)
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
		Tool = new ToolBase(data.Tool);
		Entity = new geoEntity(data.Entity);
		IJKValue = new IJK(data.IJKValue);
	}

	public override string ToString()
	{
		if (isMCode)
		{
			return "M" + CodeType + " X" + Positions.X.ToString("f2");
		}
		if (isTCode)
		{
			return "T" + CodeType;
		}
		if (isGCode)
		{
			return "G" + CodeType + " X" + Positions.X.ToString("f2") + " Y" + Positions.Y.ToString("f2") + " Z" + Positions.Z.ToString("f2") + " A" + Positions.A.ToString("f2") + " B" + Positions.B.ToString("f2") + " C" + Positions.C.ToString("f2");
		}
		return CodeString;
	}
}
