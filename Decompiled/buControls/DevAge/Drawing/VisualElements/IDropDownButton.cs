using System;

namespace DevAge.Drawing.VisualElements;

public interface IDropDownButton : ICloneable, IVisualElement
{
	ButtonStyle Style { get; set; }
}
