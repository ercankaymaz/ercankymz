using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class VisualPopupShadow : Form
{
	private static readonly int SHADOW_SIZE;

	private static readonly Brush[] _brushes;

	private GraphicsPath _path1;

	private GraphicsPath _path2;

	private GraphicsPath _path3;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Parent = IntPtr.Zero;
			createParams.Style |= int.MinValue;
			createParams.ExStyle |= 136;
			return createParams;
		}
	}

	static VisualPopupShadow()
	{
		SHADOW_SIZE = 3;
		_brushes = new Brush[SHADOW_SIZE];
		for (int i = 0; i < SHADOW_SIZE; i++)
		{
			int num = i * 70;
			_brushes[i] = new SolidBrush(Color.FromArgb(num, num, num));
		}
	}

	public VisualPopupShadow()
	{
		base.StartPosition = FormStartPosition.Manual;
		base.FormBorderStyle = FormBorderStyle.None;
		base.ShowInTaskbar = false;
		base.TransparencyKey = Color.Magenta;
		base.Opacity = 0.18000000715255737;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ClearPaths();
		}
		base.Dispose(disposing);
	}

	public virtual void Show(Rectangle screenRect)
	{
		screenRect.X += SHADOW_SIZE;
		screenRect.Y += SHADOW_SIZE;
		base.Location = screenRect.Location;
		base.ClientSize = screenRect.Size;
		PI.ShowWindow(base.Handle, 4);
	}

	public void DefinePaths(GraphicsPath path1, GraphicsPath path2, GraphicsPath path3)
	{
		ClearPaths();
		_path1 = path1;
		_path2 = path2;
		_path3 = path3;
		Invalidate();
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		pevent.Graphics.FillRectangle(Brushes.Magenta, pevent.ClipRectangle);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (_path1 != null && _path2 != null && _path3 != null)
		{
			DrawPaths(e.Graphics);
		}
		else
		{
			DrawShadow(e.Graphics, base.ClientRectangle);
		}
	}

	private void ClearPaths()
	{
		if (_path1 != null)
		{
			_path1.Dispose();
			_path1 = null;
		}
		if (_path2 != null)
		{
			_path2.Dispose();
			_path2 = null;
		}
		if (_path3 != null)
		{
			_path3.Dispose();
			_path3 = null;
		}
	}

	private void DrawPaths(Graphics g)
	{
		g.FillPath(_brushes[2], _path1);
		g.FillPath(_brushes[1], _path2);
		g.FillPath(_brushes[0], _path3);
	}

	private void DrawShadow(Graphics g, Rectangle area)
	{
		using GraphicsPath path = CommonHelper.RoundedRectanglePath(area, 6);
		area.Inflate(-1, -1);
		g.FillPath(_brushes[2], path);
		using GraphicsPath path2 = CommonHelper.RoundedRectanglePath(area, 6);
		g.FillPath(_brushes[1], path2);
		area.Inflate(-1, -1);
		using GraphicsPath path3 = CommonHelper.RoundedRectanglePath(area, 6);
		g.FillPath(_brushes[0], path3);
	}
}
