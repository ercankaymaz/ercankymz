using System.Drawing;
using System.Reflection;

namespace buClass;

public class CheckEntitesOption : buSerilization
{
	public bool ConvertCircleToArc = true;

	public bool DevideArcIfGreater180 = true;

	public bool CompositeCurveToEntities = true;

	public bool RemovePoints = true;

	public bool RemoveSameEntities = true;

	public bool ColorFromEntity = true;

	public Color EntityColor = Color.Black;

	public bool ThicknessFromEntity = true;

	public double EntityThickness = 2.0;

	public bool ForceDefaultLayer = true;

	public bool CurveToLinearPath = true;

	public CheckEntitesOption()
	{
	}

	public CheckEntitesOption(CheckEntitesOption data)
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
}
