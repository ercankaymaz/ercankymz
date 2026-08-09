using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

public class ShapeLeadInOut : buSerilization5
{
	public double LeadInLength = 10.0;

	public double LeadOutLength = 10.0;

	public LeadInOutType LeadInType = LeadInOutType.Line;

	public LeadInOutType LeadOuType = LeadInOutType.Line;

	public ShapeLeadInOut()
	{
	}

	public ShapeLeadInOut(ShapeLeadInOut data)
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

	public override string ToString()
	{
		return "LeadInLength: " + LeadInLength + " , LeadOutLength: " + LeadOutLength;
	}
}
