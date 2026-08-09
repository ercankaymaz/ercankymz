#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteControls : Storage
{
	private KryptonPaletteControl _controlCommon;

	private KryptonPaletteControl _controlClient;

	private KryptonPaletteControl _controlAlternate;

	private KryptonPaletteControl _controlGroupBox;

	private KryptonPaletteControl _controlToolTip;

	private KryptonPaletteControl _controlRibbon;

	private KryptonPaletteControl _controlRibbonAppMenu;

	private KryptonPaletteControl _controlCustom1;

	public override bool IsDefault => _controlCommon.IsDefault && _controlClient.IsDefault && _controlAlternate.IsDefault && _controlGroupBox.IsDefault && _controlToolTip.IsDefault && _controlRibbon.IsDefault && _controlRibbonAppMenu.IsDefault && _controlCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlCommon => _controlCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining client control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlClient => _controlClient;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining alternate control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlAlternate => _controlAlternate;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining group box control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlGroupBox => _controlGroupBox;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tooltip control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlToolTip => _controlToolTip;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining control ribbon style appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlRibbon => _controlRibbon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining control ribbon application menu style appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlRibbonAppMenu => _controlRibbonAppMenu;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControl ControlCustom1 => _controlCustom1;

	internal KryptonPaletteControls(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_controlCommon = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlClient, PaletteBorderStyle.ControlClient, needPaint);
		_controlClient = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlClient, PaletteBorderStyle.ControlClient, needPaint);
		_controlAlternate = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlAlternate, PaletteBorderStyle.ControlAlternate, needPaint);
		_controlGroupBox = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlGroupBox, PaletteBorderStyle.ControlGroupBox, needPaint);
		_controlToolTip = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, needPaint);
		_controlRibbon = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlRibbon, PaletteBorderStyle.ControlRibbon, needPaint);
		_controlRibbonAppMenu = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlRibbonAppMenu, PaletteBorderStyle.ControlRibbonAppMenu, needPaint);
		_controlCustom1 = new KryptonPaletteControl(redirector, PaletteBackStyle.ControlCustom1, PaletteBorderStyle.ControlCustom1, needPaint);
		PaletteRedirectDouble redirector2 = new PaletteRedirectDouble(redirector, _controlCommon.StateDisabled, _controlCommon.StateNormal);
		_controlClient.SetRedirector(redirector2);
		_controlAlternate.SetRedirector(redirector2);
		_controlGroupBox.SetRedirector(redirector2);
		_controlToolTip.SetRedirector(redirector2);
		_controlRibbon.SetRedirector(redirector2);
		_controlRibbonAppMenu.SetRedirector(redirector2);
		_controlCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ControlClient;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlClient;
		_controlClient.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ControlAlternate;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlAlternate;
		_controlAlternate.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ControlGroupBox;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlGroupBox;
		_controlGroupBox.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ControlToolTip;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlToolTip;
		_controlToolTip.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ControlRibbon;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlRibbon;
		_controlRibbon.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ControlRibbonAppMenu;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ControlRibbonAppMenu;
		_controlRibbonAppMenu.PopulateFromBase();
	}

	private bool ShouldSerializeControlCommon()
	{
		return !_controlCommon.IsDefault;
	}

	private bool ShouldSerializeControlClient()
	{
		return !_controlClient.IsDefault;
	}

	private bool ShouldSerializeControlAlternate()
	{
		return !_controlAlternate.IsDefault;
	}

	private bool ShouldSerializeControlGroupBox()
	{
		return !_controlGroupBox.IsDefault;
	}

	private bool ShouldSerializeControlToolTip()
	{
		return !_controlToolTip.IsDefault;
	}

	private bool ShouldSerializeControlRibbon()
	{
		return !_controlRibbon.IsDefault;
	}

	private bool ShouldSerializeControlRibbonAppMenu()
	{
		return !_controlRibbonAppMenu.IsDefault;
	}

	private bool ShouldSerializeControlCustom1()
	{
		return !_controlCustom1.IsDefault;
	}
}
