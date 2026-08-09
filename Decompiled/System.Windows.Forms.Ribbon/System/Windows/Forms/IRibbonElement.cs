using System.Drawing;

namespace System.Windows.Forms;

public interface IRibbonElement
{
	Rectangle Bounds { get; }

	Ribbon Owner { get; }

	void OnPaint(object sender, RibbonElementPaintEventArgs e);

	Size MeasureSize(object sender, RibbonElementMeasureSizeEventArgs e);

	void SetBounds(Rectangle bounds);
}
