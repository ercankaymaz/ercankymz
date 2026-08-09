using System.Reflection;
using buClass;

namespace buCadCamResVer5;

public class ModuleWorksModes
{
	public bool Wireframe = false;

	public bool Drill = false;

	public bool TriangleMeshBasic = false;

	public bool TriangleMeshAdvanced = false;

	public ModuleWorksModes()
	{
	}

	public ModuleWorksModes(ModuleWorksModes data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
