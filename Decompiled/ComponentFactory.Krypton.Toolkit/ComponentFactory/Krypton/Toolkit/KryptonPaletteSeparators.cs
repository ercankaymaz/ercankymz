#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteSeparators : Storage
{
	private KryptonPaletteSeparator _separatorCommon;

	private KryptonPaletteSeparator _separatorLowProfile;

	private KryptonPaletteSeparator _separatorHighProfile;

	private KryptonPaletteSeparator _separatorHighInternalProfile;

	private KryptonPaletteSeparator _separatorCustom1;

	public override bool IsDefault => _separatorCommon.IsDefault && _separatorLowProfile.IsDefault && _separatorHighProfile.IsDefault && _separatorHighInternalProfile.IsDefault && _separatorCustom1.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparator SeparatorCommon => _separatorCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining low profile separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparator SeparatorLowProfile => _separatorLowProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining high profile separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparator SeparatorHighProfile => _separatorHighProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining high profile for internal separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparator SeparatorHighInternalProfile => _separatorHighInternalProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining first custom separator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparator SeparatorCustom1 => _separatorCustom1;

	internal KryptonPaletteSeparators(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_separatorCommon = new KryptonPaletteSeparator(redirector, PaletteBackStyle.SeparatorLowProfile, PaletteBorderStyle.SeparatorLowProfile, needPaint);
		_separatorLowProfile = new KryptonPaletteSeparator(redirector, PaletteBackStyle.SeparatorLowProfile, PaletteBorderStyle.SeparatorLowProfile, needPaint);
		_separatorHighProfile = new KryptonPaletteSeparator(redirector, PaletteBackStyle.SeparatorHighProfile, PaletteBorderStyle.SeparatorHighProfile, needPaint);
		_separatorHighInternalProfile = new KryptonPaletteSeparator(redirector, PaletteBackStyle.SeparatorHighInternalProfile, PaletteBorderStyle.SeparatorHighInternalProfile, needPaint);
		_separatorCustom1 = new KryptonPaletteSeparator(redirector, PaletteBackStyle.SeparatorCustom1, PaletteBorderStyle.SeparatorCustom1, needPaint);
		PaletteRedirectDouble redirector2 = new PaletteRedirectDouble(redirector, _separatorCommon.StateDisabled, _separatorCommon.StateNormal, _separatorCommon.StatePressed, _separatorCommon.StateTracking);
		_separatorLowProfile.SetRedirector(redirector2);
		_separatorHighProfile.SetRedirector(redirector2);
		_separatorHighInternalProfile.SetRedirector(redirector2);
		_separatorCustom1.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.SeparatorLowProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.SeparatorLowProfile;
		_separatorLowProfile.PopulateFromBase(PaletteMetricPadding.SeparatorPaddingLowProfile);
		common.StateCommon.BackStyle = PaletteBackStyle.SeparatorHighProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.SeparatorHighProfile;
		_separatorHighProfile.PopulateFromBase(PaletteMetricPadding.SeparatorPaddingHighProfile);
		common.StateCommon.BackStyle = PaletteBackStyle.SeparatorHighInternalProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.SeparatorHighInternalProfile;
		_separatorHighInternalProfile.PopulateFromBase(PaletteMetricPadding.SeparatorPaddingHighInternalProfile);
	}

	private bool ShouldSerializeSeparatorCommon()
	{
		return !_separatorCommon.IsDefault;
	}

	private bool ShouldSerializeSeparatorLowProfile()
	{
		return !_separatorLowProfile.IsDefault;
	}

	private bool ShouldSerializeSeparatorHighProfile()
	{
		return !_separatorHighProfile.IsDefault;
	}

	private bool ShouldSerializeSeparatorHighInternalProfile()
	{
		return !_separatorHighInternalProfile.IsDefault;
	}

	private bool ShouldSerializeSeparatorCustom1()
	{
		return !_separatorCustom1.IsDefault;
	}
}
