using System;

namespace DevAge.Drawing.VisualElements;

public interface ISortIndicator : ICloneable, IVisualElement
{
	HeaderSortStyle SortStyle { get; set; }
}
