#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawContent : ViewLeaf
{
	private static PropertyInfo _pi;

	internal IPaletteContent _paletteContent;

	private IDisposable _memento;

	private IContentValues _values;

	private VisualOrientation _orientation;

	private bool _useMnemonic;

	private bool _drawOnComposition;

	private bool _testForFocusCues;

	public bool DrawContentOnComposition
	{
		get
		{
			return _drawOnComposition;
		}
		set
		{
			_drawOnComposition = value;
		}
	}

	public bool TestForFocusCues
	{
		get
		{
			return _testForFocusCues;
		}
		set
		{
			_testForFocusCues = value;
		}
	}

	public IContentValues Values
	{
		get
		{
			return _values;
		}
		set
		{
			_values = value;
		}
	}

	public VisualOrientation Orientation
	{
		[DebuggerStepThrough]
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public bool UseMnemonic
	{
		[DebuggerStepThrough]
		get
		{
			return _useMnemonic;
		}
		set
		{
			_useMnemonic = value;
		}
	}

	public ViewDrawContent(IPaletteContent paletteContent, IContentValues values, VisualOrientation orientation)
	{
		_paletteContent = paletteContent;
		_values = values;
		_orientation = orientation;
		_drawOnComposition = false;
		_testForFocusCues = false;
	}

	public override string ToString()
	{
		return "ViewDrawContent:" + base.Id;
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

	public void SetPalette(IPaletteContent paletteContent)
	{
		Debug.Assert(paletteContent != null);
		_paletteContent = paletteContent;
	}

	public IPaletteContent GetPalette()
	{
		return _paletteContent;
	}

	public bool IsImageDisplayed(ViewContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		bool result = false;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			result = context.Renderer.RenderStandardContent.GetContentImageDisplayed(_memento);
		}
		return result;
	}

	public Rectangle ImageRectangle(ViewContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle result = Rectangle.Empty;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			result = context.Renderer.RenderStandardContent.GetContentImageRectangle(_memento);
		}
		return result;
	}

	public Rectangle ShortTextRect(ViewContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle result = Rectangle.Empty;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			result = context.Renderer.RenderStandardContent.GetContentShortTextRectangle(_memento);
		}
		return result;
	}

	public Rectangle LongTextRect(ViewContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Rectangle result = Rectangle.Empty;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			result = context.Renderer.RenderStandardContent.GetContentLongTextRectangle(_memento);
		}
		return result;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Size result = Size.Empty;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			result = context.Renderer.RenderStandardContent.GetContentPreferredSize(context, _paletteContent, _values, Orientation, State, DrawContentOnComposition);
		}
		return result;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			if (_memento != null)
			{
				_memento.Dispose();
				_memento = null;
			}
			_memento = context.Renderer.RenderStandardContent.LayoutContent(context, ClientRectangle, _paletteContent, _values, Orientation, State, DrawContentOnComposition);
		}
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_paletteContent.GetContentDraw(State) == InheritBool.True)
		{
			bool allowFocusRect = !_testForFocusCues || ShowFocusCues(context.Control);
			context.Renderer.RenderStandardContent.DrawContent(context, ClientRectangle, _paletteContent, _memento, Orientation, State, DrawContentOnComposition, allowFocusRect);
		}
	}

	private bool ShowFocusCues(Control c)
	{
		if (_pi == null)
		{
			_pi = typeof(Control).GetProperty("ShowFocusCues", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
		}
		return (bool)_pi.GetValue(c, null);
	}
}
