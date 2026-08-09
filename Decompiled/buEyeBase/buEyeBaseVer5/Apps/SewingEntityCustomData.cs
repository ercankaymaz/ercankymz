using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingEntityCustomData : buSerilization5
{
	public double StitchLen = 0.0;

	public bool isStitch = false;

	public int indexEntity = -1;

	public int indexVertex = -1;

	public entitySortDirection SortDir = entitySortDirection.Normal;

	public SewingDrawType DrawType = SewingDrawType.None;

	public SewingPunteriz Punteriz = null;

	public SewingEntityCustomData()
	{
	}

	public SewingEntityCustomData(int indexentity, int indexvertex, bool isstitch, double stitchlen, SewingDrawType drawType)
	{
		indexEntity = indexentity;
		indexVertex = indexvertex;
		isStitch = isstitch;
		StitchLen = stitchlen;
		DrawType = drawType;
	}

	public SewingEntityCustomData(SewingEntityCustomData data)
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
		if (data.Punteriz != null)
		{
			Punteriz = new SewingPunteriz(data.Punteriz);
		}
	}
}
