#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonAppButton : Storage
{
	private PaletteRibbonBack _ribbonAppButton;

	private PaletteRibbonBack _ribbonGroupCollapsedBorder;

	private PaletteRibbonBack _ribbonGroupCollapsedBack;

	private PaletteRibbonBack _ribbonGroupCollapsedFrameBorder;

	private PaletteRibbonBack _ribbonGroupCollapsedFrameBack;

	private PaletteRibbonText _ribbonGroupCollapsedText;

	[Browsable(false)]
	public override bool IsDefault => RibbonAppButton.IsDefault && RibbonGroupCollapsedBorder.IsDefault && RibbonGroupCollapsedBack.IsDefault && RibbonGroupCollapsedFrameBorder.IsDefault && RibbonGroupCollapsedFrameBack.IsDefault && RibbonGroupCollapsedText.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining application button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppButton => _ribbonAppButton;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group collapsed border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupCollapsedBorder => _ribbonGroupCollapsedBorder;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group collapsed background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupCollapsedBack => _ribbonGroupCollapsedBack;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group collapsed frame border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupCollapsedFrameBorder => _ribbonGroupCollapsedFrameBorder;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group collapsed frame background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupCollapsedFrameBack => _ribbonGroupCollapsedFrameBack;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group collapsed text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupCollapsedText => _ribbonGroupCollapsedText;

	public PaletteRibbonAppButton(PaletteRibbonRedirect inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		NeedPaint = needPaint;
		_ribbonAppButton = new PaletteRibbonBack(inherit.RibbonAppButton, needPaint);
		_ribbonGroupCollapsedBorder = new PaletteRibbonBack(inherit.RibbonGroupCollapsedBorder, needPaint);
		_ribbonGroupCollapsedBack = new PaletteRibbonBack(inherit.RibbonGroupCollapsedBack, needPaint);
		_ribbonGroupCollapsedFrameBorder = new PaletteRibbonBack(inherit.RibbonGroupCollapsedFrameBorder, needPaint);
		_ribbonGroupCollapsedFrameBack = new PaletteRibbonBack(inherit.RibbonGroupCollapsedFrameBack, needPaint);
		_ribbonGroupCollapsedText = new PaletteRibbonText(inherit.RibbonGroupCollapsedText, needPaint);
	}

	public virtual void PopulateFromBase(PaletteState state)
	{
		_ribbonAppButton.PopulateFromBase(state);
		_ribbonGroupCollapsedBorder.PopulateFromBase(state);
		_ribbonGroupCollapsedBack.PopulateFromBase(state);
		_ribbonGroupCollapsedFrameBorder.PopulateFromBase(state);
		_ribbonGroupCollapsedFrameBack.PopulateFromBase(state);
		_ribbonGroupCollapsedText.PopulateFromBase(state);
	}

	public virtual void SetInherit(PaletteRibbonRedirect inherit)
	{
		_ribbonAppButton.SetInherit(inherit.RibbonAppButton);
		_ribbonGroupCollapsedBorder.SetInherit(inherit.RibbonGroupCollapsedBorder);
		_ribbonGroupCollapsedBack.SetInherit(inherit.RibbonGroupCollapsedBack);
		_ribbonGroupCollapsedFrameBorder.SetInherit(inherit.RibbonGroupCollapsedFrameBorder);
		_ribbonGroupCollapsedFrameBack.SetInherit(inherit.RibbonGroupCollapsedFrameBack);
		_ribbonGroupCollapsedText.SetInherit(inherit.RibbonGroupCollapsedText);
	}

	private bool ShouldSerializeRibbonAppButton()
	{
		return !_ribbonAppButton.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCollapsedBorder()
	{
		return !_ribbonGroupCollapsedBorder.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCollapsedBack()
	{
		return !_ribbonGroupCollapsedBack.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCollapsedFrameBorder()
	{
		return !_ribbonGroupCollapsedFrameBorder.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCollapsedFrameBack()
	{
		return !_ribbonGroupCollapsedFrameBack.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCollapsedText()
	{
		return !_ribbonGroupCollapsedText.IsDefault;
	}
}
