using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IImage : ICloneable, IVisualElement
{
	System.Drawing.Image Value { get; set; }
}
