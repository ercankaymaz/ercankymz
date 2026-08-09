#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteForms : Storage
{
	private KryptonPaletteForm _formCommon;

	private KryptonPaletteForm _formMain;

	private KryptonPaletteForm _formCustom1;

	public override bool IsDefault => _formCommon.IsDefault && _formMain.IsDefault && _formCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteForm FormCommon => _formCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining main form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteForm FormMain => _formMain;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom form appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteForm FormCustom1 => _formCustom1;

	internal KryptonPaletteForms(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_formCommon = new KryptonPaletteForm(redirector, PaletteBackStyle.FormMain, PaletteBorderStyle.FormMain, needPaint);
		_formMain = new KryptonPaletteForm(redirector, PaletteBackStyle.FormMain, PaletteBorderStyle.FormMain, needPaint);
		_formCustom1 = new KryptonPaletteForm(redirector, PaletteBackStyle.FormCustom1, PaletteBorderStyle.FormCustom1, needPaint);
		PaletteRedirectDouble redirector2 = new PaletteRedirectDouble(redirector, _formCommon.StateInactive, _formCommon.StateActive);
		_formMain.SetRedirector(redirector2);
		_formCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.FormMain;
		common.StateCommon.BorderStyle = PaletteBorderStyle.FormMain;
		_formMain.PopulateFromBase();
	}

	private bool ShouldSerializeFormCommon()
	{
		return !_formCommon.IsDefault;
	}

	private bool ShouldSerializeFormMain()
	{
		return !_formMain.IsDefault;
	}

	private bool ShouldSerializeFormCustom1()
	{
		return !_formCustom1.IsDefault;
	}
}
