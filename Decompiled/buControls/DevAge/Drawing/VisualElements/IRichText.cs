using System;
using System.Drawing;
using DevAge.Windows.Forms;

namespace DevAge.Drawing.VisualElements;

public interface IRichText : ICloneable, IVisualElement
{
	DevAge.Windows.Forms.RichText Value { get; set; }

	Color ForeColor { get; set; }

	ContentAlignment TextAlignment { get; set; }

	Font Font { get; set; }

	RotateFlipType RotateFlipType { get; set; }
}
