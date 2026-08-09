using System.Reflection;
using System.Windows.Forms;

namespace buClass.UserFiles.buCad;

public class setLibrary : buSerilization
{
	public bool JoinAll = true;

	public bool MoveFromCenter = false;

	public bool ExtendOnlyNeighbor = false;

	public string pathLibrary = Application.StartupPath;

	public setLibrary()
	{
	}

	public setLibrary(setLibrary data)
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
