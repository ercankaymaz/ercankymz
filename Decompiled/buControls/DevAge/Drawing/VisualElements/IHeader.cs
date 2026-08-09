using System;

namespace DevAge.Drawing.VisualElements;

public interface IHeader : ICloneable, IVisualElement, IBackground
{
	ControlDrawStyle Style { get; set; }
}
