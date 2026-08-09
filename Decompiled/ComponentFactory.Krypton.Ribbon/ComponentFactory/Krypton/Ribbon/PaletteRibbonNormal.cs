using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonNormal : PaletteRibbonAppGroupTab
{
	private PaletteRibbonText _ribbonGroupCheckBoxText;

	private PaletteRibbonText _ribbonGroupButtonText;

	private PaletteRibbonText _ribbonGroupLabelText;

	private PaletteRibbonText _ribbonGroupRadioButtonText;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && RibbonGroupCheckBoxText.IsDefault && RibbonGroupButtonText.IsDefault && RibbonGroupLabelText.IsDefault && RibbonGroupRadioButtonText.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group check box label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupCheckBoxText => _ribbonGroupCheckBoxText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group button text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupButtonText => _ribbonGroupButtonText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group label text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupLabelText => _ribbonGroupLabelText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group radio button label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupRadioButtonText => _ribbonGroupRadioButtonText;

	public PaletteRibbonNormal(PaletteRibbonRedirect inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		_ribbonGroupCheckBoxText = new PaletteRibbonText(inherit.RibbonGroupCheckBoxText, needPaint);
		_ribbonGroupButtonText = new PaletteRibbonText(inherit.RibbonGroupButtonText, needPaint);
		_ribbonGroupLabelText = new PaletteRibbonText(inherit.RibbonGroupLabelText, needPaint);
		_ribbonGroupRadioButtonText = new PaletteRibbonText(inherit.RibbonGroupRadioButtonText, needPaint);
	}

	public override void PopulateFromBase(PaletteState state)
	{
		base.PopulateFromBase(state);
		_ribbonGroupCheckBoxText.PopulateFromBase(state);
		_ribbonGroupButtonText.PopulateFromBase(state);
		_ribbonGroupLabelText.PopulateFromBase(state);
		_ribbonGroupRadioButtonText.PopulateFromBase(state);
	}

	public override void SetInherit(PaletteRibbonRedirect inherit)
	{
		base.SetInherit(inherit);
		_ribbonGroupCheckBoxText.SetInherit(inherit.RibbonGroupCheckBoxText);
		_ribbonGroupButtonText.SetInherit(inherit.RibbonGroupButtonText);
		_ribbonGroupLabelText.SetInherit(inherit.RibbonGroupLabelText);
		_ribbonGroupRadioButtonText.SetInherit(inherit.RibbonGroupRadioButtonText);
	}

	private bool ShouldSerializeRibbonGroupCheckBoxText()
	{
		return !_ribbonGroupCheckBoxText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupButtonText()
	{
		return !_ribbonGroupButtonText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupLabelText()
	{
		return !_ribbonGroupLabelText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupRadioButtonText()
	{
		return !_ribbonGroupRadioButtonText.IsDefault;
	}
}
