using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class BendMarkItem : buSerilization
{
	public double Height;

	public double Width;

	public double Offset;

	public bool Enable = true;

	public Pnt3D Start = new Pnt3D();

	public Pnt3D End = new Pnt3D();

	public double ExtractXPosition = 0.0;

	public ToolBase ToolBendMark = new ToolBase();

	public List<Pnt3D> CamPoints = new List<Pnt3D>();

	public BendMarkItem()
	{
	}

	public BendMarkItem(BendMarkItem data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "Extract X : " + ExtractXPosition.ToString("f2");
	}
}
