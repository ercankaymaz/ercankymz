using System;
using System.Reflection;

namespace buClass;

[Serializable]
public class SelectionFilter : buSerilization
{
	public bool Solid = true;

	public bool Wireframe = true;

	public bool Cam = false;

	public bool Text = true;

	public bool Image = true;

	public string MatchTag = "";

	public SelectionFilter()
	{
	}

	public SelectionFilter(bool solid, bool wireframe, bool cam, bool image, bool text)
	{
		Cam = cam;
		Solid = solid;
		Wireframe = wireframe;
		Image = image;
		Text = text;
	}

	public SelectionFilter(SelectedEntities data)
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
