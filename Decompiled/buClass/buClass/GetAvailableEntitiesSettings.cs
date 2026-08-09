using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

public class GetAvailableEntitiesSettings : buSerilization
{
	public List<string> EntitiesNotAddName = new List<string>();

	public List<string> LayerNameNotAdd = new List<string>();

	public List<Color> ColorsNotAdd = new List<Color>();

	public List<int> EntitiesNotAddIndex = new List<int>();

	public bool VisibleEntity = true;

	public bool AddTextEntities = false;

	public bool AddICurveEntities = true;

	public GetAvailableEntitiesSettings()
	{
	}

	public GetAvailableEntitiesSettings(GetAvailableEntitiesSettings data)
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
		ColorsNotAdd.Clear();
		for (int j = 0; j <= data.ColorsNotAdd.Count - 1; j++)
		{
			ColorsNotAdd.Add(Color.FromArgb(data.ColorsNotAdd[j].A, data.ColorsNotAdd[j].R, data.ColorsNotAdd[j].G, data.ColorsNotAdd[j].B));
		}
	}
}
