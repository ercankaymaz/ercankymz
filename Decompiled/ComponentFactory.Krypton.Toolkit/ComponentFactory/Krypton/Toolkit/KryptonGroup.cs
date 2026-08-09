using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonGroup), "ToolboxBitmaps.KryptonGroup.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("GroupBackStyle")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonGroupDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Enables you to group collections of controls.")]
[Docking(DockingBehavior.Ask)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonGroup : VisualControlContainment
{
	private ViewDrawDocker _drawDocker;

	private PaletteDoubleRedirect _stateCommon;

	private PaletteDouble _stateDisabled;

	private PaletteDouble _stateNormal;

	private ViewLayoutFill _layoutFill;

	private KryptonGroupPanel _panel;

	private bool _forcedLayout;

	private bool _layingOut;

	[Browsable(false)]
	public new string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
			_panel.Name = value + ".Panel";
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

	[Localizable(false)]
	[Category("Appearance")]
	[Description("The internal panel that contains group content.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonGroupPanel Panel => _panel;

	[Category("Visuals")]
	[Description("Border style.")]
	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Background style.")]
	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				_panel.PanelBackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common group appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDoubleRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDouble StateNormal => _stateNormal;

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(Panel.Location, Panel.Size);
		}
	}

	public KryptonGroup()
	{
		_stateCommon = new PaletteDoubleRedirect(base.Redirector, PaletteBackStyle.ControlClient, PaletteBorderStyle.ControlClient, base.NeedPaintDelegate);
		_stateDisabled = new PaletteDouble(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteDouble(_stateCommon, base.NeedPaintDelegate);
		_panel = new KryptonGroupPanel(this, _stateCommon, _stateDisabled, _stateNormal, OnGroupPanelPaint);
		_panel.PanelBackStyle = PaletteBackStyle.ControlClient;
		_layoutFill = new ViewLayoutFill(_panel);
		_drawDocker = new ViewDrawDocker(_stateNormal.Back, _stateNormal.Border);
		_drawDocker.Add(_layoutFill, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
		((KryptonReadOnlyControls)base.Controls).AddInternal(_panel);
	}

	private bool ShouldSerializeGroupBorderStyle()
	{
		return GroupBorderStyle != PaletteBorderStyle.ControlClient;
	}

	private void ResetGroupBorderStyle()
	{
		GroupBorderStyle = PaletteBorderStyle.ControlClient;
	}

	private bool ShouldSerializeGroupBackStyle()
	{
		return GroupBackStyle != PaletteBackStyle.ControlClient;
	}

	private void ResetGroupBackStyle()
	{
		GroupBackStyle = PaletteBackStyle.ControlClient;
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
		if (base.ViewManager != null)
		{
			Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, proposedSize);
			if (MaximumSize.Width > 0)
			{
				preferredSize.Width = Math.Min(MaximumSize.Width, preferredSize.Width);
			}
			if (MaximumSize.Height > 0)
			{
				preferredSize.Height = Math.Min(MaximumSize.Height, preferredSize.Width);
			}
			if (MinimumSize.Width > 0)
			{
				preferredSize.Width = Math.Max(MinimumSize.Width, preferredSize.Width);
			}
			if (MinimumSize.Height > 0)
			{
				preferredSize.Height = Math.Max(MinimumSize.Height, preferredSize.Height);
			}
			return preferredSize;
		}
		return base.GetPreferredSize(proposedSize);
	}

	public virtual void SetFixedState(PaletteState state)
	{
		_drawDocker.FixedState = state;
		_panel.SetFixedState(state);
	}

	protected void ForceControlLayout()
	{
		if (!base.IsInitialized)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		InvokeLayout();
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		OnLayout(new LayoutEventArgs(null, null));
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawDocker.SetPalettes(_stateNormal.Back, _stateNormal.Border);
		}
		else
		{
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateDisabled.Border);
		}
		_drawDocker.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ForceControlLayout();
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		_layingOut = true;
		base.OnLayout(levent);
		if (base.IsInitialized || _forcedLayout || (base.DesignMode && _panel != null))
		{
			Rectangle fillRect = _layoutFill.FillRect;
			_panel.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
		}
		_layingOut = false;
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsInitialized || !e.NeedLayout)
		{
			_panel.PerformNeedPaint(e.NeedLayout);
		}
		else
		{
			ForceControlLayout();
		}
		base.OnNeedPaint(sender, e);
	}

	private void OnGroupPanelPaint(object sender, NeedLayoutEventArgs e)
	{
		if (e.NeedLayout && !_layingOut && AutoSize)
		{
			PerformNeedPaint(needLayout: true);
		}
	}
}
