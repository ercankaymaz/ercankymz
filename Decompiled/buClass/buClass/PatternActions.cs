using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class PatternActions : buSerilization
{
	public CodeUsing AirDistance = new CodeUsing();

	public CodeUsing SafeDistance = new CodeUsing();

	public CodeUsing MoveToG53 = new CodeUsing();

	public CodeUsing MoveUpIncremental = new CodeUsing();

	public CodeUsing MoveOneStepUp = new CodeUsing();

	public CodeUsing MoveFirstPoint = new CodeUsing();

	public PatternActions()
	{
	}

	public PatternActions(PatternActions data)
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

	public PatternActions(bool air, bool safe, bool moveg53, bool moveupincremental, bool moveonestepup, bool movefirstpoint)
	{
		AirDistance.Enable = air;
		SafeDistance.Enable = safe;
		MoveToG53.Enable = moveg53;
		MoveUpIncremental.Enable = moveupincremental;
		MoveOneStepUp.Enable = moveonestepup;
		MoveFirstPoint.Enable = movefirstpoint;
	}
}
