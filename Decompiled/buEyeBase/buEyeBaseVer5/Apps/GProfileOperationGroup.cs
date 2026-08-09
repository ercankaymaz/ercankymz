using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps;

public class GProfileOperationGroup
{
	public List<GProfileOperation> OpList = new List<GProfileOperation>();

	public BoxSize5 Size = new BoxSize5();

	public GProfileOperationGroup()
	{
	}

	public GProfileOperationGroup(GProfileOperationGroup data)
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
		Size = new BoxSize5(data.Size);
		OpList.Clear();
		for (int j = 0; j <= data.OpList.Count - 1; j++)
		{
			GProfileOperation item = new GProfileOperation(data.OpList[j]);
			OpList.Add(item);
		}
	}

	public override string ToString()
	{
		return "Op Cnt: " + OpList.Count + " - MinX: " + Size.MinPoint.X.ToString("f2") + " , MaxX: " + Size.MaxPoint.X.ToString("f2") + " |  dX: " + Size.Delta.X.ToString("f2");
	}
}
