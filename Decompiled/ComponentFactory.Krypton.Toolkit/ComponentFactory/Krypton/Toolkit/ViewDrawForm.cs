using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawForm : ViewDrawDocker
{
	private StatusStrip _renderStrip;

	private StatusStrip _statusStrip;

	public StatusStrip StatusStrip
	{
		get
		{
			return _statusStrip;
		}
		set
		{
			_statusStrip = value;
		}
	}

	public ViewDrawForm(IPaletteBack paletteBack, IPaletteBorder paletteBorder)
		: base(paletteBack, paletteBorder)
	{
		_renderStrip = new StatusStrip();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _renderStrip != null)
		{
			_renderStrip.Dispose();
			_renderStrip = null;
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewDrawForm:" + base.Id;
	}

	public override void RenderAfter(RenderContext context)
	{
		if (_statusStrip != null && _statusStrip.RenderMode == ToolStripRenderMode.ManagerRenderMode && context.Control is KryptonForm { RealWindowBorders: var realWindowBorders } kryptonForm)
		{
			ToolStripRenderer renderer = ToolStripManager.Renderer;
			_renderStrip.Width = kryptonForm.Width;
			_renderStrip.Height = _statusStrip.Height + realWindowBorders.Bottom;
			int num = _statusStrip.Top + realWindowBorders.Top;
			try
			{
				context.Graphics.TranslateTransform(0f, num);
				renderer.DrawToolStripBorder(new ToolStripRenderEventArgs(context.Graphics, _renderStrip));
				renderer.DrawToolStripBackground(new ToolStripRenderEventArgs(context.Graphics, _renderStrip));
			}
			finally
			{
				context.Graphics.TranslateTransform(0f, -num);
			}
		}
		base.RenderAfter(context);
	}
}
