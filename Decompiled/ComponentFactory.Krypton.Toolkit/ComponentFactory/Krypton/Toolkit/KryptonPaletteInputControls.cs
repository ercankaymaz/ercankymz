#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteInputControls : Storage
{
	private KryptonPaletteInputControl _inputControlCommon;

	private KryptonPaletteInputControl _inputControlStandalone;

	private KryptonPaletteInputControl _inputControlRibbon;

	private KryptonPaletteInputControl _inputControlCustom1;

	public override bool IsDefault => _inputControlCommon.IsDefault && _inputControlStandalone.IsDefault && _inputControlRibbon.IsDefault && _inputControlCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteInputControl InputControlCommon => _inputControlCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining standalone input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteInputControl InputControlStandalone => _inputControlStandalone;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining input control ribbon style appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteInputControl InputControlRibbon => _inputControlRibbon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the custom input control appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteInputControl InputControlCustom1 => _inputControlCustom1;

	internal KryptonPaletteInputControls(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_inputControlCommon = new KryptonPaletteInputControl(redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, needPaint);
		_inputControlStandalone = new KryptonPaletteInputControl(redirector, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, needPaint);
		_inputControlRibbon = new KryptonPaletteInputControl(redirector, PaletteBackStyle.InputControlRibbon, PaletteBorderStyle.InputControlRibbon, PaletteContentStyle.InputControlRibbon, needPaint);
		_inputControlCustom1 = new KryptonPaletteInputControl(redirector, PaletteBackStyle.InputControlCustom1, PaletteBorderStyle.InputControlCustom1, PaletteContentStyle.InputControlCustom1, needPaint);
		PaletteRedirectTriple redirector2 = new PaletteRedirectTriple(redirector, _inputControlCommon.StateDisabled, _inputControlCommon.StateNormal, _inputControlCommon.StateActive);
		_inputControlStandalone.SetRedirector(redirector2);
		_inputControlRibbon.SetRedirector(redirector2);
		_inputControlCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.InputControlStandalone;
		common.StateCommon.BorderStyle = PaletteBorderStyle.InputControlStandalone;
		common.StateCommon.ContentStyle = PaletteContentStyle.InputControlStandalone;
		_inputControlStandalone.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.InputControlRibbon;
		common.StateCommon.BorderStyle = PaletteBorderStyle.InputControlRibbon;
		common.StateCommon.ContentStyle = PaletteContentStyle.InputControlRibbon;
		_inputControlRibbon.PopulateFromBase();
	}

	private bool ShouldSerializeInputControlCommon()
	{
		return !_inputControlCommon.IsDefault;
	}

	private bool ShouldSerializeInputControlStandalone()
	{
		return !_inputControlStandalone.IsDefault;
	}

	private bool ShouldSerializeInputControlRibbon()
	{
		return !_inputControlRibbon.IsDefault;
	}

	private bool ShouldSerializeInputControlCustom1()
	{
		return !_inputControlCustom1.IsDefault;
	}
}
