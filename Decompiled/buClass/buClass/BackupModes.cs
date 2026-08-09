using System.Reflection;

namespace buClass;

public class BackupModes : buSerilization
{
	public bool Settings = true;

	public bool Macro = true;

	public bool ShortKeys = true;

	public bool mnbucf = true;

	public bool Runtime = true;

	public bool AppVars = true;

	public bool Post = true;

	public bool ScreenShot = true;

	public bool LastLoadedFile = true;

	public bool LastImportedFile = true;

	public bool ActualOperation = true;

	public bool LastCreatedCode = true;

	public bool Nesting = true;

	public bool Diemaker = true;

	public bool Marble = true;

	public bool Profile = true;

	public BackupModes()
	{
	}

	public BackupModes(BackupModes data)
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
