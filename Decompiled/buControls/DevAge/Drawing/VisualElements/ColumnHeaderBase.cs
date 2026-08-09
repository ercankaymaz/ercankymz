using System;

namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class ColumnHeaderBase : HeaderBase, ICloneable, IVisualElement, IBackground, IHeader, IColumnHeader
{
	public ColumnHeaderBase()
	{
	}

	public ColumnHeaderBase(ColumnHeaderBase other)
		: base(other)
	{
	}
}
