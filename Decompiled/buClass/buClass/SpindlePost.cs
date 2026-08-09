using System;
using System.Collections;
using System.Reflection;

namespace buClass;

[Serializable]
public class SpindlePost : buSerilization
{
	public bool UseSpindle;

	public string SpindleCWCode = "";

	public string SpindleCCWCode = "";

	public string SpindleStopCode = "";

	public bool SpindleAtToolLine = false;

	public bool SpindleMCommandFirst = false;

	public ArrayList PreCode = new ArrayList();

	public ArrayList AfterCode = new ArrayList();

	public SpindlePost()
	{
	}

	public SpindlePost(SpindlePost data)
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

	public SpindlePost(bool usespindle, bool spindleattoolline, string spindleCWcode, string spindleCCWcode, string spindlestopcode)
	{
		UseSpindle = usespindle;
		SpindleCWCode = spindleCWcode;
		SpindleCCWCode = spindleCCWcode;
		SpindleStopCode = spindlestopcode;
		SpindleAtToolLine = spindleattoolline;
	}

	public override string ToString()
	{
		return "Use: " + UseSpindle;
	}
}
