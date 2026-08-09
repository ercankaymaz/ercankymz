using System.Collections;
using System.Reflection;

namespace buClass.Apps;

public class jewelCamMCode : buSerilization
{
	public ArrayList SpinldeStartMCode = new ArrayList();

	public ArrayList SpinldeEndMCode = new ArrayList();

	public ArrayList KalemStartMCode = new ArrayList();

	public ArrayList KalemEndMCode = new ArrayList();

	public ArrayList GroupStartMCode = new ArrayList();

	public ArrayList GroupEndMCode = new ArrayList();

	public ArrayList FileStartMCode = new ArrayList();

	public ArrayList FileEndMCode = new ArrayList();

	public jewelCamMCode()
	{
	}

	public jewelCamMCode(jewelCamMCode data)
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
		SpinldeStartMCode.Clear();
		SpinldeStartMCode.AddRange(data.SpinldeStartMCode);
		SpinldeEndMCode.Clear();
		SpinldeEndMCode.AddRange(data.SpinldeEndMCode);
		KalemStartMCode.Clear();
		KalemStartMCode.AddRange(data.KalemStartMCode);
		KalemEndMCode.Clear();
		KalemEndMCode.AddRange(data.KalemEndMCode);
		GroupStartMCode.Clear();
		GroupStartMCode.AddRange(data.GroupStartMCode);
		GroupEndMCode.Clear();
		GroupEndMCode.AddRange(data.GroupEndMCode);
		FileStartMCode.Clear();
		FileStartMCode.AddRange(data.FileStartMCode);
		FileEndMCode.Clear();
		FileEndMCode.AddRange(data.FileEndMCode);
	}
}
