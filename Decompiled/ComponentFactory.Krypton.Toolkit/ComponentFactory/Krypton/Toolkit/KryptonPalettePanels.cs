#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPalettePanels : Storage
{
	private KryptonPalettePanel _panelCommon;

	private KryptonPalettePanel _panelClient;

	private KryptonPalettePanel _panelAlternate;

	private KryptonPalettePanel _panelRibbonInactive;

	private KryptonPalettePanel _panelCustom1;

	public override bool IsDefault => _panelCommon.IsDefault && _panelClient.IsDefault && _panelAlternate.IsDefault && _panelRibbonInactive.IsDefault && _panelCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanel PanelCommon => _panelCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining a client panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanel PanelClient => _panelClient;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining alternate panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanel PanelAlternate => _panelAlternate;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ribbon inactive panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanel PanelRibbonInactive => _panelRibbonInactive;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom panel appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanel PanelCustom1 => _panelCustom1;

	internal KryptonPalettePanels(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_panelCommon = new KryptonPalettePanel(redirector, PaletteBackStyle.PanelClient, needPaint);
		_panelClient = new KryptonPalettePanel(redirector, PaletteBackStyle.PanelClient, needPaint);
		_panelAlternate = new KryptonPalettePanel(redirector, PaletteBackStyle.PanelAlternate, needPaint);
		_panelRibbonInactive = new KryptonPalettePanel(redirector, PaletteBackStyle.PanelRibbonInactive, needPaint);
		_panelCustom1 = new KryptonPalettePanel(redirector, PaletteBackStyle.PanelCustom1, needPaint);
		PaletteRedirectBack redirector2 = new PaletteRedirectBack(redirector, _panelCommon.StateDisabled, _panelCommon.StateNormal);
		_panelClient.SetRedirector(redirector2);
		_panelAlternate.SetRedirector(redirector2);
		_panelRibbonInactive.SetRedirector(redirector2);
		_panelCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.PanelClient;
		_panelClient.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.PanelAlternate;
		_panelAlternate.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.PanelRibbonInactive;
		_panelRibbonInactive.PopulateFromBase();
	}

	private bool ShouldSerializePanelCommon()
	{
		return !_panelCommon.IsDefault;
	}

	private bool ShouldSerializePanelClient()
	{
		return !_panelClient.IsDefault;
	}

	private bool ShouldSerializePanelAlternate()
	{
		return !_panelAlternate.IsDefault;
	}

	private bool ShouldSerializePanelRibbonInactive()
	{
		return !_panelRibbonInactive.IsDefault;
	}

	private bool ShouldSerializePanelCustom1()
	{
		return !_panelCustom1.IsDefault;
	}
}
