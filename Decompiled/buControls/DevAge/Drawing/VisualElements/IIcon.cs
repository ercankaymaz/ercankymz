using System;
using System.Drawing;

namespace DevAge.Drawing.VisualElements;

public interface IIcon : ICloneable, IVisualElement
{
	System.Drawing.Icon Value { get; set; }
}
