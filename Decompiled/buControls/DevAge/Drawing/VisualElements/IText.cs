using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IText : ICloneable, IVisualElement
{
	string Value { get; set; }

	Color ForeColor { get; set; }

	Font Font { get; set; }
}
