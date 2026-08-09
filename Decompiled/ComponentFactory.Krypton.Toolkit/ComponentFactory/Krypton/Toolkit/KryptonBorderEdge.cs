using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonBorderEdge), "ToolboxBitmaps.KryptonBorderEdge.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("Orientation")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonBorderEdgeDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays a vertical or horizontal border edge.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonBorderEdge : VisualControlBase
{
	private Orientation _orientation;

	private PaletteBorderInheritRedirect _borderRedirect;

	private PaletteBorderEdgeRedirect _stateCommon;

	private PaletteBorderEdge _stateDisabled;

	private PaletteBorderEdge _stateNormal;

	private PaletteBorderEdge _stateCurrent;

	private PaletteState _state;

	private ViewDrawPanel _drawPanel;

	[Browsable(false)]
	[Bindable(false)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
		}
	}

	[Browsable(false)]
	[Bindable(false)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new int TabIndex
	{
		get
		{
			return base.TabIndex;
		}
		set
		{
			base.TabIndex = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Browsable(true)]
	[Localizable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(true)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies if the control grows and shrinks to fit the contents exactly.")]
	[DefaultValue(typeof(AutoSizeMode), "GrowAndShrink")]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			if (value != GetAutoSizeMode())
			{
				SetAutoSizeMode(value);
				if (AutoSize)
				{
					PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Category("Visuals")]
	[Description("Border style.")]
	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _borderRedirect.Style;
		}
		set
		{
			if (_borderRedirect.Style != value)
			{
				_borderRedirect.Style = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Orientation of border edge used to determine sizing.")]
	[DefaultValue(typeof(Orientation), "Horizontal")]
	public virtual Orientation Orientation
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common border edge appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorderEdgeRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled border edge appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorderEdge StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal border edge appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBorderEdge StateNormal => _stateNormal;

	protected override Size DefaultSize => new Size(50, 50);

	public KryptonBorderEdge()
	{
		SetStyle(ControlStyles.Selectable, value: false);
		_orientation = Orientation.Horizontal;
		_borderRedirect = new PaletteBorderInheritRedirect(base.Redirector, PaletteBorderStyle.ControlClient);
		_stateCommon = new PaletteBorderEdgeRedirect(_borderRedirect, base.NeedPaintDelegate);
		_stateDisabled = new PaletteBorderEdge(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteBorderEdge(_stateCommon, base.NeedPaintDelegate);
		_stateCurrent = _stateNormal;
		_state = PaletteState.Normal;
		_drawPanel = new ViewDrawPanel(_stateNormal);
		base.ViewManager = new ViewManager(this, _drawPanel);
		AutoSize = true;
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
	}

	private void ResetBorderStyle()
	{
		BorderStyle = PaletteBorderStyle.ControlClient;
	}

	private bool ShouldSerializeBorderStyle()
	{
		return BorderStyle != PaletteBorderStyle.ControlClient;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		proposedSize = base.GetPreferredSize(proposedSize);
		if (AutoSize)
		{
			if (Orientation == Orientation.Horizontal)
			{
				proposedSize.Height = _stateCurrent.GetBorderWidth(_state);
			}
			else
			{
				proposedSize.Width = _stateCurrent.GetBorderWidth(_state);
			}
		}
		return proposedSize;
	}

	public virtual void SetFixedState(PaletteState state)
	{
		_drawPanel.FixedState = state;
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_stateCurrent = _stateNormal;
			_state = PaletteState.Normal;
		}
		else
		{
			_stateCurrent = _stateDisabled;
			_state = PaletteState.Disabled;
		}
		_drawPanel.SetPalettes(_stateCurrent);
		_drawPanel.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}
}
