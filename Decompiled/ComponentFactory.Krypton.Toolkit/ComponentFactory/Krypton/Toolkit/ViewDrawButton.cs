#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawButton : ViewComposite
{
	private IPaletteTriple _paletteCurrent;

	private IPaletteTriple _paletteDisabled;

	private IPaletteTriple _paletteNormal;

	private IPaletteTriple _paletteTracking;

	private IPaletteTriple _palettePressed;

	private IPaletteTriple _paletteCheckedNormal;

	private IPaletteTriple _paletteCheckedTracking;

	private IPaletteTriple _paletteCheckedPressed;

	private PaletteBorderEdgeRedirect _edgeRedirect;

	private ViewDrawSplitCanvas _drawCanvas;

	private ViewDrawContent _drawContent;

	private ViewDrawBorderEdge _drawSplitBorder;

	private ViewLayoutCenter _drawDropDown;

	private ViewDrawDropDownButton _drawDropDownButton;

	private ViewLayoutDocker _layoutDocker;

	private VisualOrientation _dropDownPosition;

	private ViewLayoutSeparator _drawOuterSeparator;

	private Rectangle _splitRectangle;

	private Rectangle _nonSplitRectangle;

	private bool _dropDown;

	private bool _splitter;

	private bool _checked;

	private bool _allowUncheck;

	private bool _forcePaletteUpdate;

	public ViewLayoutDocker LayoutDocker => _layoutDocker;

	public IPaletteTriple CurrentPalette => _paletteCurrent;

	public bool DropDown
	{
		get
		{
			return _dropDown;
		}
		set
		{
			if (_dropDown != value)
			{
				_dropDown = value;
				UpdateDropDown();
			}
		}
	}

	public VisualOrientation DropDownPosition
	{
		get
		{
			return _dropDownPosition;
		}
		set
		{
			if (_dropDownPosition != value)
			{
				_dropDownPosition = value;
				UpdateDropDown();
			}
		}
	}

	public VisualOrientation DropDownOrientation
	{
		get
		{
			return _drawDropDownButton.Orientation;
		}
		set
		{
			if (_drawDropDownButton.Orientation != value)
			{
				_drawDropDownButton.Orientation = value;
				UpdateDropDown();
			}
		}
	}

	public IPalette DropDownPalette
	{
		get
		{
			return _drawDropDownButton.Palette;
		}
		set
		{
			_drawDropDownButton.Palette = value;
		}
	}

	public bool Splitter
	{
		get
		{
			return _splitter;
		}
		set
		{
			if (_splitter != value)
			{
				_splitter = value;
				UpdateDropDown();
			}
		}
	}

	public Rectangle SplitRectangle => _splitRectangle;

	public Rectangle NonSplitRectangle => _nonSplitRectangle;

	public IContentValues ButtonValues
	{
		get
		{
			return _drawContent.Values;
		}
		set
		{
			_drawContent.Values = value;
		}
	}

	public bool DrawTabBorder
	{
		get
		{
			return _drawCanvas.DrawTabBorder;
		}
		set
		{
			_drawCanvas.DrawTabBorder = value;
		}
	}

	public TabBorderStyle TabBorderStyle
	{
		get
		{
			return _drawCanvas.TabBorderStyle;
		}
		set
		{
			_drawCanvas.TabBorderStyle = value;
		}
	}

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			base.Enabled = value;
			if (Enabled && ElementState == PaletteState.Disabled)
			{
				if (Checked)
				{
					ElementState = PaletteState.CheckedNormal;
				}
				else
				{
					ElementState = PaletteState.Normal;
				}
			}
			_drawCanvas.Enabled = value;
			_drawContent.Enabled = value;
			_drawSplitBorder.Enabled = value;
			_drawDropDownButton.Enabled = value;
		}
	}

	public virtual VisualOrientation Orientation
	{
		get
		{
			return _drawCanvas.Orientation;
		}
		set
		{
			SetOrientation(value, value);
		}
	}

	public bool UseMnemonic
	{
		get
		{
			return _drawContent.UseMnemonic;
		}
		set
		{
			_drawContent.UseMnemonic = value;
		}
	}

	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			_checked = value;
		}
	}

	public bool AllowUncheck
	{
		get
		{
			return _allowUncheck;
		}
		set
		{
			_allowUncheck = value;
		}
	}

	public bool DrawButtonComposition
	{
		get
		{
			return _drawCanvas.DrawCanvasOnComposition;
		}
		set
		{
			_drawCanvas.DrawCanvasOnComposition = value;
		}
	}

	public bool TestForFocusCues
	{
		get
		{
			return _drawContent.TestForFocusCues;
		}
		set
		{
			_drawContent.TestForFocusCues = value;
		}
	}

	public ViewDrawButton(IPaletteTriple paletteDisabled, IPaletteTriple paletteNormal, IPaletteTriple paletteTracking, IPaletteTriple palettePressed, IPaletteMetric paletteMetric, IContentValues buttonValues, VisualOrientation orientation, bool useMnemonic)
		: this(paletteDisabled, paletteNormal, paletteTracking, palettePressed, paletteNormal, paletteTracking, palettePressed, paletteMetric, buttonValues, orientation, useMnemonic)
	{
	}

	public ViewDrawButton(IPaletteTriple paletteDisabled, IPaletteTriple paletteNormal, IPaletteTriple paletteTracking, IPaletteTriple palettePressed, IPaletteTriple paletteCheckedNormal, IPaletteTriple paletteCheckedTracking, IPaletteTriple paletteCheckedPressed, IPaletteMetric paletteMetric, IContentValues buttonValues, VisualOrientation orientation, bool useMnemonic)
	{
		_paletteDisabled = paletteDisabled;
		_paletteNormal = paletteNormal;
		_paletteTracking = paletteTracking;
		_palettePressed = palettePressed;
		_paletteCheckedNormal = paletteCheckedNormal;
		_paletteCheckedTracking = paletteCheckedTracking;
		_paletteCheckedPressed = paletteCheckedPressed;
		_paletteCurrent = _paletteNormal;
		_checked = false;
		_allowUncheck = true;
		_dropDown = false;
		_splitter = false;
		_dropDownPosition = VisualOrientation.Right;
		_drawDropDown = new ViewLayoutCenter(1);
		_drawDropDownButton = new ViewDrawDropDownButton();
		_drawDropDown.Add(_drawDropDownButton);
		_drawOuterSeparator = new ViewLayoutSeparator(1);
		_edgeRedirect = new PaletteBorderEdgeRedirect(_paletteNormal.PaletteBorder, null);
		_drawSplitBorder = new ViewDrawBorderEdge(new PaletteBorderEdge(_edgeRedirect, null), CommonHelper.VisualToOrientation(orientation));
		_drawContent = new ViewDrawContent(_paletteNormal.PaletteContent, buttonValues, orientation);
		_drawCanvas = new ViewDrawSplitCanvas(_paletteNormal.PaletteBack, _paletteNormal.PaletteBorder, paletteMetric, PaletteMetricPadding.None, orientation);
		_layoutDocker = new ViewLayoutDocker();
		_layoutDocker.Add(_drawContent, ViewDockStyle.Fill);
		_layoutDocker.Add(_drawSplitBorder, ViewDockStyle.Right);
		_layoutDocker.Add(_drawDropDown, ViewDockStyle.Right);
		_layoutDocker.Add(_drawOuterSeparator, ViewDockStyle.Right);
		_layoutDocker.Tag = this;
		_drawContent.UseMnemonic = useMnemonic;
		_drawCanvas.Add(_layoutDocker);
		UpdateDropDown();
		Add(_drawCanvas);
	}

	public override string ToString()
	{
		return "ViewDrawButton:" + base.Id;
	}

	public void SetOrientation(VisualOrientation borderBackOrient, VisualOrientation contentOrient)
	{
		_drawCanvas.Orientation = borderBackOrient;
		_drawContent.Orientation = contentOrient;
		UpdateDropDown();
	}

	public void SetPalettes(IPaletteTriple paletteDisabled, IPaletteTriple paletteNormal, IPaletteTriple paletteTracking, IPaletteTriple palettePressed)
	{
		Debug.Assert(paletteDisabled != null);
		Debug.Assert(paletteNormal != null);
		Debug.Assert(paletteTracking != null);
		Debug.Assert(palettePressed != null);
		_paletteDisabled = paletteDisabled;
		_paletteNormal = paletteNormal;
		_paletteTracking = paletteTracking;
		_palettePressed = palettePressed;
		_forcePaletteUpdate = true;
	}

	public void SetCheckedPalettes(IPaletteTriple paletteCheckedNormal, IPaletteTriple paletteCheckedTracking, IPaletteTriple paletteCheckedPressed)
	{
		Debug.Assert(paletteCheckedNormal != null);
		Debug.Assert(paletteCheckedTracking != null);
		Debug.Assert(paletteCheckedPressed != null);
		_paletteCheckedNormal = paletteCheckedNormal;
		_paletteCheckedTracking = paletteCheckedTracking;
		_paletteCheckedPressed = paletteCheckedPressed;
		_forcePaletteUpdate = true;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		CheckPaletteState(context);
		return _drawCanvas.EvalTransparentPaint(context);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Debug.Assert(_drawCanvas != null);
		CheckPaletteState(context);
		return _drawCanvas.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		CheckPaletteState(context);
		base.Layout(context);
		Rectangle clientRectangle = _drawSplitBorder.ClientRectangle;
		clientRectangle = ((_drawSplitBorder.Orientation != System.Windows.Forms.Orientation.Vertical) ? new Rectangle(ClientRectangle.X, clientRectangle.Y, ClientWidth, clientRectangle.Height) : new Rectangle(clientRectangle.X, ClientRectangle.Y, clientRectangle.Width, ClientHeight));
		_drawSplitBorder.ClientRectangle = clientRectangle;
		_nonSplitRectangle = ClientRectangle;
		if (_dropDown && _splitter)
		{
			switch (_dropDownPosition)
			{
			case VisualOrientation.Top:
				_splitRectangle = ClientRectangle;
				_splitRectangle.Height = _drawSplitBorder.ClientRectangle.Bottom;
				_nonSplitRectangle.Height = ClientHeight - _splitRectangle.Height;
				_nonSplitRectangle.Y = _splitRectangle.Bottom;
				break;
			case VisualOrientation.Bottom:
				_splitRectangle = ClientRectangle;
				_splitRectangle.Height = _splitRectangle.Bottom - _drawSplitBorder.ClientRectangle.Top;
				_splitRectangle.Y = ClientRectangle.Bottom - _splitRectangle.Height;
				_nonSplitRectangle.Height = ClientHeight - _splitRectangle.Height;
				break;
			case VisualOrientation.Left:
				_splitRectangle = ClientRectangle;
				_splitRectangle.Width = _drawSplitBorder.ClientRectangle.Right;
				_nonSplitRectangle.Width = ClientWidth - _splitRectangle.Width;
				_nonSplitRectangle.X = _splitRectangle.Right;
				break;
			case VisualOrientation.Right:
				_splitRectangle = ClientRectangle;
				_splitRectangle.Width = _splitRectangle.Right - _drawSplitBorder.ClientRectangle.Left;
				_splitRectangle.X = ClientRectangle.Right - _splitRectangle.Width;
				_nonSplitRectangle.Width = ClientWidth - _splitRectangle.Width;
				break;
			}
		}
		else
		{
			_splitRectangle = CommonHelper.NullRectangle;
		}
		_drawCanvas.SplitRectangle = _splitRectangle;
		_drawCanvas.NonSplitRectangle = _nonSplitRectangle;
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		CheckPaletteState(context);
		base.Render(context);
	}

	protected virtual void CheckPaletteState(ViewContext context)
	{
		PaletteState paletteState = State;
		if (!IsFixed && !context.Control.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		if (!IsFixed && Checked)
		{
			if (AllowUncheck)
			{
				switch (paletteState)
				{
				case PaletteState.Normal:
					paletteState = PaletteState.CheckedNormal;
					break;
				case PaletteState.Tracking:
					paletteState = PaletteState.CheckedTracking;
					break;
				case PaletteState.Pressed:
					paletteState = PaletteState.CheckedPressed;
					break;
				}
			}
			else
			{
				paletteState = PaletteState.CheckedNormal;
			}
		}
		if (_forcePaletteUpdate || _drawCanvas.ElementState != paletteState)
		{
			_forcePaletteUpdate = false;
			_drawCanvas.ElementState = paletteState;
			_drawContent.ElementState = paletteState;
			_drawSplitBorder.ElementState = paletteState;
			_drawDropDownButton.ElementState = paletteState;
			switch (paletteState)
			{
			case PaletteState.Disabled:
				_paletteCurrent = _paletteDisabled;
				break;
			case PaletteState.Normal:
				_paletteCurrent = _paletteNormal;
				break;
			case PaletteState.CheckedNormal:
				_paletteCurrent = _paletteCheckedNormal;
				break;
			case PaletteState.Pressed:
				_paletteCurrent = _palettePressed;
				break;
			case PaletteState.CheckedPressed:
				_paletteCurrent = _paletteCheckedPressed;
				break;
			case PaletteState.Tracking:
				_paletteCurrent = _paletteTracking;
				break;
			case PaletteState.CheckedTracking:
				_paletteCurrent = _paletteCheckedTracking;
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
			_drawCanvas.SetPalettes(_paletteCurrent.PaletteBack, _paletteCurrent.PaletteBorder);
			_drawContent.SetPalette(_paletteCurrent.PaletteContent);
			_edgeRedirect.SetPalette(_paletteCurrent.PaletteBorder);
		}
	}

	private void UpdateDropDown()
	{
		_drawDropDown.Visible = _dropDown;
		_drawSplitBorder.Visible = _splitter & _dropDown;
		_drawOuterSeparator.Visible = !_splitter & _dropDown;
		_drawCanvas.Splitter = _splitter & _dropDown;
		ViewDockStyle dock = ViewDockStyle.Right;
		Orientation orientation = System.Windows.Forms.Orientation.Vertical;
		switch (_dropDownPosition)
		{
		case VisualOrientation.Top:
			dock = ViewDockStyle.Top;
			orientation = System.Windows.Forms.Orientation.Horizontal;
			break;
		case VisualOrientation.Bottom:
			dock = ViewDockStyle.Bottom;
			orientation = System.Windows.Forms.Orientation.Horizontal;
			break;
		case VisualOrientation.Left:
			dock = ViewDockStyle.Left;
			orientation = System.Windows.Forms.Orientation.Vertical;
			break;
		case VisualOrientation.Right:
			dock = ViewDockStyle.Right;
			orientation = System.Windows.Forms.Orientation.Vertical;
			break;
		}
		_drawSplitBorder.Orientation = orientation;
		_drawSplitBorder.VisualOrientation = Orientation;
		_layoutDocker.SetDock(_drawSplitBorder, dock);
		_layoutDocker.SetDock(_drawDropDown, dock);
		_layoutDocker.SetDock(_drawOuterSeparator, dock);
	}
}
