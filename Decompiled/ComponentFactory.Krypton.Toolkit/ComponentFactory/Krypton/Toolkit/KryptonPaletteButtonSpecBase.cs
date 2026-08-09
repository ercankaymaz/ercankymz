#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteButtonSpecBase : Storage, IPaletteButtonSpec
{
	private PaletteRedirect _redirector;

	private PaletteButtonStyle _style;

	private PaletteButtonOrientation _orientation;

	private PaletteRelativeEdgeAlign _edge;

	public override bool IsDefault => Style == PaletteButtonStyle.Inherit && Orientation == PaletteButtonOrientation.Inherit && Edge == PaletteRelativeEdgeAlign.Inherit;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PaletteRedirect Redirector => _redirector;

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Button style.")]
	[DefaultValue(typeof(PaletteButtonStyle), "Inherit")]
	public PaletteButtonStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			if (_style != value)
			{
				_style = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("Defines the button orientation.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(PaletteButtonOrientation), "Inherit")]
	public PaletteButtonOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			if (_orientation != value)
			{
				_orientation = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist(false)]
	[Localizable(true)]
	[Category("Visuals")]
	[Description("The header edge to display the button against.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(PaletteRelativeEdgeAlign), "Inherit")]
	public PaletteRelativeEdgeAlign Edge
	{
		get
		{
			return _edge;
		}
		set
		{
			if (_edge != value)
			{
				_edge = value;
				OnButtonSpecChanged(this, EventArgs.Empty);
			}
		}
	}

	public event EventHandler ButtonSpecChanged;

	internal KryptonPaletteButtonSpecBase(PaletteRedirect redirector)
	{
		Debug.Assert(redirector != null);
		_redirector = redirector;
		_style = PaletteButtonStyle.Inherit;
		_orientation = PaletteButtonOrientation.Inherit;
		_edge = PaletteRelativeEdgeAlign.Inherit;
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_redirector = redirect;
	}

	public virtual void PopulateFromBase(PaletteButtonSpecStyle style)
	{
		Style = _redirector.GetButtonSpecStyle(style);
		Orientation = _redirector.GetButtonSpecOrientation(style);
		Edge = _redirector.GetButtonSpecEdge(style);
	}

	public void ResetStyle()
	{
		Style = PaletteButtonStyle.Inherit;
	}

	public void ResetOrientation()
	{
		Orientation = PaletteButtonOrientation.Inherit;
	}

	public void ResetEdge()
	{
		Edge = PaletteRelativeEdgeAlign.Inherit;
	}

	public virtual Icon GetButtonSpecIcon(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecIcon(style);
	}

	public virtual Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		return _redirector.GetButtonSpecImage(style, state);
	}

	public virtual Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecImageTransparentColor(style);
	}

	public virtual string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecShortText(style);
	}

	public virtual string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecLongText(style);
	}

	public virtual string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecToolTipTitle(style);
	}

	public virtual Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecColorMap(style);
	}

	public virtual PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style)
	{
		if (Style != PaletteButtonStyle.Inherit)
		{
			return Style;
		}
		return _redirector.GetButtonSpecStyle(style);
	}

	public virtual HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style)
	{
		return _redirector.GetButtonSpecLocation(style);
	}

	public virtual PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style)
	{
		if (Edge != PaletteRelativeEdgeAlign.Inherit)
		{
			return Edge;
		}
		return _redirector.GetButtonSpecEdge(style);
	}

	public virtual PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style)
	{
		if (Orientation != PaletteButtonOrientation.Inherit)
		{
			return Orientation;
		}
		return _redirector.GetButtonSpecOrientation(style);
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		if (this.ButtonSpecChanged != null)
		{
			this.ButtonSpecChanged(this, e);
		}
	}
}
