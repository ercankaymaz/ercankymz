using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class RowHeaderBase : HeaderBase, ICloneable, IVisualElement, IBackground, IHeader, IRowHeader
{
	public RowHeaderBase()
	{
	}

	public RowHeaderBase(RowHeaderBase other)
		: base(other)
	{
	}
}
