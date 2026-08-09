#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteCommon : Storage
{
	private PaletteTripleRedirect _stateCommon;

	private PaletteTriple _stateDisabled;

	private PaletteTriple _stateOthers;

	public override bool IsDefault => _stateCommon.IsDefault && _stateDisabled.IsDefault && _stateOthers.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the all appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the non-disabled appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateOthers => _stateOthers;

	internal KryptonPaletteCommon(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_stateCommon = new PaletteTripleRedirect(redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, needPaint);
		_stateDisabled = new PaletteTriple(_stateCommon, needPaint);
		_stateOthers = new PaletteTriple(_stateCommon, needPaint);
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateOthers()
	{
		return !_stateOthers.IsDefault;
	}
}
