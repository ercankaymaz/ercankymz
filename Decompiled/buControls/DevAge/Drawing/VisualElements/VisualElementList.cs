using System;
using System.Collections.Generic;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public class VisualElementList : List<IVisualElement>, ICloneable
{
	public object Clone()
	{
		VisualElementList visualElementList = new VisualElementList();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IVisualElement current = enumerator.Current;
				visualElementList.Add((IVisualElement)current.Clone());
			}
		}
		return visualElementList;
	}
}
