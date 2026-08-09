using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevAge.Drawing;

public class MeasureHelper : IDisposable
{
	private Bitmap bitmap_0;

	private Graphics graphics;

	private bool bool_0;

	public Graphics Graphics => graphics;

	public MeasureHelper(Control control)
	{
		graphics = control.CreateGraphics();
		bool_0 = true;
	}

	public MeasureHelper(Graphics graphics)
	{
		this.graphics = graphics;
		bool_0 = false;
	}

	public MeasureHelper(GraphicsCache graphics)
	{
		this.graphics = graphics.Graphics;
		bool_0 = false;
	}

	public void Dispose()
	{
		if (graphics != null && bool_0)
		{
			graphics.Dispose();
			graphics = null;
		}
		if (bitmap_0 != null)
		{
			bitmap_0.Dispose();
			bitmap_0 = null;
		}
	}
}
