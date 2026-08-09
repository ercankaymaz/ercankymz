#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawPanel : ViewComposite
{
	internal IPaletteBack _paletteBack;

	private IDisposable _memento;

	private VisualOrientation _orientation;

	private bool _ignoreRender;

	public bool IgnoreRender
	{
		get
		{
			return _ignoreRender;
		}
		set
		{
			_ignoreRender = value;
		}
	}

	public VisualOrientation VisualOrientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public ViewDrawPanel()
	{
		_orientation = VisualOrientation.Top;
		_ignoreRender = false;
	}

	public ViewDrawPanel(IPaletteBack paletteBack)
	{
		Debug.Assert(paletteBack != null);
		_paletteBack = paletteBack;
		_orientation = VisualOrientation.Top;
	}

	public override string ToString()
	{
		return "ViewDrawPanel:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		base.Dispose(disposing);
	}

	public void SetPalettes(IPaletteBack paletteBack)
	{
		Debug.Assert(paletteBack != null);
		_paletteBack = paletteBack;
	}

	public IPaletteBack GetPalette()
	{
		return _paletteBack;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		return context.Renderer.EvalTransparentPaint(_paletteBack, State);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (!IgnoreRender && _paletteBack.GetBackDraw(State) == InheritBool.True)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddRectangle(ClientRectangle);
				_memento = context.Renderer.RenderStandardBack.DrawBack(context, ClientRectangle, graphicsPath, _paletteBack, VisualOrientation, State, _memento);
			}
		}
	}
}
