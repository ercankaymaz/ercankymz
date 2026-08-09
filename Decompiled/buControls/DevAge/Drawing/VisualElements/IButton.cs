using System;

namespace DevAge.Drawing.VisualElements;

public interface IButton : ICloneable, IVisualElement, IBackground
{
	ButtonStyle Style { get; set; }
}
