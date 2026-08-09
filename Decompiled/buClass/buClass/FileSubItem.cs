using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class FileSubItem : buSerilization
{
	public string FileName = "";

	public string FullFileName = Application.StartupPath;

	public string FileFolder = Application.StartupPath;

	public string FileNameWithoutExtension = Application.StartupPath;

	public bool Enable = true;

	public int Index = -1;

	public FileSubItem()
	{
	}

	public FileSubItem(FileSubItem data)
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
		return FileName;
	}
}
