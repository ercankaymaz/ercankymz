using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buControls.Controls;

[Serializable]
public class ColumbProperties
{
	public string Name = "Columb";

	public int Width = 100;

	public bool ReadOnly = false;

	public bool Visible = true;

	public DataGridViewColumnSortMode SortType = DataGridViewColumnSortMode.NotSortable;

	public Type Variable;

	public ColumbProperties()
	{
	}

	public ColumbProperties(ColumbProperties data)
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
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		Variable = data.Variable;
	}

	public ColumbProperties(string name, int width, bool readOnly, Type var)
	{
		Name = name;
		Width = width;
		ReadOnly = readOnly;
		Variable = var;
	}

	public ColumbProperties(string name, int width, bool readOnly, Type var, bool visible)
	{
		Name = name;
		Width = width;
		ReadOnly = readOnly;
		Variable = var;
		Visible = visible;
	}
}
