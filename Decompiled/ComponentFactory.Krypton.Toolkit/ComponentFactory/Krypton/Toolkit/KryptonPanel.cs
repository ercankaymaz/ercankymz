#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonPanel), "ToolboxBitmaps.KryptonPanel.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("PanelStyle")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonPanelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Enables you to group collections of controls.")]
[Docking(DockingBehavior.Ask)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonPanel : VisualPanel
{
	private ViewDrawPanel _drawPanel;

	private PaletteDoubleRedirect _stateCommon;

	private PaletteDouble _stateDisabled;

	private PaletteDouble _stateNormal;

	[Category("Visuals")]
	[Description("Panel style.")]
	public PaletteBackStyle PanelBackStyle
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
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common panel appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateCommon => _stateCommon.Back;

	[Category("Visuals")]
	[Description("Overrides for defining disabled panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateDisabled => _stateDisabled.Back;

	[Category("Visuals")]
	[Description("Overrides for defining normal panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack StateNormal => _stateNormal.Back;

	protected ViewDrawPanel ViewDrawPanel => _drawPanel;

	public KryptonPanel()
	{
		_stateCommon = new PaletteDoubleRedirect(base.Redirector, PaletteBackStyle.PanelClient, PaletteBorderStyle.ControlClient, base.NeedPaintDelegate);
		_stateDisabled = new PaletteDouble(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteDouble(_stateCommon, base.NeedPaintDelegate);
		Construct();
	}

	public KryptonPanel(PaletteDoubleRedirect stateCommon, PaletteDouble stateDisabled, PaletteDouble stateNormal)
	{
		Debug.Assert(stateCommon != null);
		Debug.Assert(stateDisabled != null);
		Debug.Assert(stateNormal != null);
		_stateCommon = stateCommon;
		_stateDisabled = stateDisabled;
		_stateNormal = stateNormal;
		Construct();
	}

	private bool ShouldSerializePanelBackStyle()
	{
		return PanelBackStyle != PaletteBackStyle.PanelClient;
	}

	private void ResetPanelBackStyle()
	{
		PanelBackStyle = PaletteBackStyle.PanelClient;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.Back.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.Back.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.Back.IsDefault;
	}

	public virtual void SetFixedState(PaletteState state)
	{
		_drawPanel.FixedState = state;
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		_drawPanel.SetPalettes(base.Enabled ? _stateNormal.Back : _stateDisabled.Back);
		_drawPanel.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	private void Construct()
	{
		_drawPanel = new ViewDrawPanel(_stateNormal.Back);
		base.ViewManager = new ViewManager(this, _drawPanel);
	}
}
