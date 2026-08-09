using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

public class SewingMain : buSerilization5
{
	public List<buEntity> MainEntityList = new List<buEntity>();

	public SimulationTp SimilationPoint = new SimulationTp();

	public bool isSorted = false;

	public SewingMain()
	{
	}

	public SewingMain(SewingMain data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		buEntity.Copy(data.MainEntityList, ref MainEntityList);
		SimilationPoint = new SimulationTp(data.SimilationPoint);
	}
}
