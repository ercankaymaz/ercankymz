#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonRedirect : PaletteMetricRedirect
{
	private PaletteRibbonBack _ribbonAppButton;

	private PaletteRibbonBack _ribbonAppMenuInner;

	private PaletteRibbonBack _ribbonAppMenuOuter;

	private PaletteRibbonBack _ribbonAppMenuDocs;

	private PaletteRibbonText _ribbonAppMenuDocsTitle;

	private PaletteRibbonText _ribbonAppMenuDocsEntry;

	private PaletteRibbonGeneral _ribbonGeneral;

	private PaletteRibbonBack _ribbonGroupArea;

	private PaletteRibbonText _ribbonGroupButtonText;

	private PaletteRibbonText _ribbonGroupCheckBoxText;

	private PaletteRibbonBack _ribbonGroupCollapsedBack;

	private PaletteRibbonBack _ribbonGroupCollapsedBorder;

	private PaletteRibbonBack _ribbonGroupCollapsedFrameBack;

	private PaletteRibbonBack _ribbonGroupCollapsedFrameBorder;

	private PaletteRibbonText _ribbonGroupCollapsedText;

	private PaletteRibbonBack _ribbonGroupNormalBorder;

	private PaletteRibbonDouble _ribbonGroupNormalTitle;

	private PaletteRibbonImages _ribbonImages;

	private PaletteRibbonText _ribbonGroupRadioButtonText;

	private PaletteRibbonText _ribbonGroupLabelText;

	private PaletteRibbonDouble _ribbonTab;

	private PaletteRibbonBack _ribbonQATFullbar;

	private PaletteRibbonBack _ribbonQATMinibarActive;

	private PaletteRibbonBack _ribbonQATMinibarInactive;

	private PaletteRibbonBack _ribbonQATOverflow;

	private PaletteRibbonBackInheritRedirect _ribbonAppButtonInherit;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuOuterInherit;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuInnerInherit;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuDocsInherit;

	private PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsTitleInherit;

	private PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsEntryInherit;

	private PaletteRibbonGeneralInheritRedirect _ribbonGeneralInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupAreaInherit;

	private PaletteRibbonTextInheritRedirect _ribbonGroupCheckBoxTextInherit;

	private PaletteRibbonTextInheritRedirect _ribbonGroupButtonTextInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupCollapsedBackInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupCollapsedBorderInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupCollapsedFrameBackInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupCollapsedFrameBorderInherit;

	private PaletteRibbonTextInheritRedirect _ribbonGroupCollapsedTextInherit;

	private PaletteRibbonBackInheritRedirect _ribbonGroupNormalBorderInherit;

	private PaletteRibbonDoubleInheritRedirect _ribbonGroupNormalTitleInherit;

	private PaletteRibbonTextInheritRedirect _ribbonGroupRadioButtonTextInherit;

	private PaletteRibbonTextInheritRedirect _ribbonGroupLabelTextInherit;

	private PaletteRibbonDoubleInheritRedirect _ribbonTabInherit;

	private PaletteRibbonBackInheritRedirect _ribbonQATFullbarInherit;

	private PaletteRibbonBackInheritRedirect _ribbonQATMinibarInherit;

	private PaletteRibbonBackInheritRedirect _ribbonQATOverflowInherit;

	private PaletteTripleRedirect _groupButtonInherit;

	private PaletteTripleRedirect _groupClusterButtonInherit;

	private PaletteTripleRedirect _groupCollapsedButtonInherit;

	private PaletteTripleRedirect _groupDialogButtonInherit;

	private PaletteTripleRedirect _keyTipInherit;

	private PaletteTripleRedirect _qatButtonInherit;

	private PaletteTripleRedirect _scrollerInherit;

	[Browsable(false)]
	public override bool IsDefault => RibbonAppButton.IsDefault && RibbonAppMenuOuter.IsDefault && RibbonAppMenuInner.IsDefault && RibbonAppMenuDocs.IsDefault && RibbonAppMenuDocsTitle.IsDefault && RibbonAppMenuDocsEntry.IsDefault && RibbonGeneral.IsDefault && RibbonGroupArea.IsDefault && RibbonGroupCheckBoxText.IsDefault && RibbonGroupNormalBorder.IsDefault && RibbonGroupNormalTitle.IsDefault && RibbonGroupButtonText.IsDefault && RibbonGroupCollapsedBorder.IsDefault && RibbonGroupCollapsedBack.IsDefault && RibbonGroupCollapsedFrameBorder.IsDefault && RibbonGroupCollapsedFrameBack.IsDefault && RibbonGroupCollapsedText.IsDefault && RibbonGroupRadioButtonText.IsDefault && RibbonGroupLabelText.IsDefault && RibbonImages.IsDefault && RibbonTab.IsDefault && RibbonQATFullbar.IsDefault && RibbonQATMinibarActive.IsDefault && RibbonQATMinibarInactive.IsDefault && RibbonQATOverflow.IsDefault;

	[Category("Visuals")]
	[Description("Overrides for defining application button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppButton => _ribbonAppButton;

	[Category("Visuals")]
	[Description("Overrides for defining application button menu outer appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuOuter => _ribbonAppMenuOuter;

	[Category("Visuals")]
	[Description("Overrides for defining application button menu inner appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuInner => _ribbonAppMenuInner;

	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent docs appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuDocs => _ribbonAppMenuDocs;

	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent documents title.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonAppMenuDocsTitle => _ribbonAppMenuDocsTitle;

	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent documents entry.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonAppMenuDocsEntry => _ribbonAppMenuDocsEntry;

	[Category("Visuals")]
	[Description("Overrides for defining general ribbon appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonGeneral RibbonGeneral => _ribbonGeneral;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group area appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupArea => _ribbonGroupArea;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group check box label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupCheckBoxText => _ribbonGroupCheckBoxText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group button text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupButtonText => _ribbonGroupButtonText;

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

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group normal border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGroupNormalBorder => _ribbonGroupNormalBorder;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group normal title appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonDouble RibbonGroupNormalTitle => _ribbonGroupNormalTitle;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group radio button label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupRadioButtonText => _ribbonGroupRadioButtonText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon group label text appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonGroupLabelText => _ribbonGroupLabelText;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonImages RibbonImages => _ribbonImages;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon tab appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonDouble RibbonTab => _ribbonTab;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon quick access toolbar in full mode.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonQATFullbar => _ribbonQATFullbar;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon quick access toolbar in mini mode when form active.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonQATMinibarActive => _ribbonQATMinibarActive;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon quick access toolbar in mini mode when form inactive.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonQATMinibarInactive => _ribbonQATMinibarInactive;

	[Category("Visuals")]
	[Description("Overrides for defining ribbon quick access toolbar overflow.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonQATOverflow => _ribbonQATOverflow;

	internal PaletteTripleRedirect RibbonGroupButton => _groupButtonInherit;

	internal PaletteTripleRedirect RibbonGroupClusterButton => _groupClusterButtonInherit;

	internal PaletteTripleRedirect RibbonGroupCollapsedButton => _groupCollapsedButtonInherit;

	internal PaletteTripleRedirect RibbonGroupDialogButton => _groupDialogButtonInherit;

	internal PaletteTripleRedirect RibbonKeyTip => _keyTipInherit;

	internal PaletteTripleRedirect RibbonQATButton => _qatButtonInherit;

	internal PaletteTripleRedirect RibbonScroller => _scrollerInherit;

	public PaletteRibbonRedirect(PaletteRedirect redirect, PaletteBackStyle panelBackStyle, NeedPaintHandler needPaint)
		: base(redirect)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_groupButtonInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_groupClusterButtonInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, needPaint);
		_groupCollapsedButtonInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_groupDialogButtonInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_keyTipInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, PaletteContentStyle.LabelKeyTip, needPaint);
		_qatButtonInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_scrollerInherit = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, needPaint);
		_ribbonAppButtonInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppButton);
		_ribbonAppMenuInnerInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuInner);
		_ribbonAppMenuOuterInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuOuter);
		_ribbonAppMenuDocsInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuDocs);
		_ribbonAppMenuDocsTitleInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsTitle);
		_ribbonAppMenuDocsEntryInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsEntry);
		_ribbonGeneralInherit = new PaletteRibbonGeneralInheritRedirect(redirect);
		_ribbonGroupAreaInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupArea);
		_ribbonGroupButtonTextInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupButtonText);
		_ribbonGroupCheckBoxTextInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupCheckBoxText);
		_ribbonGroupCollapsedBackInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupCollapsedBack);
		_ribbonGroupCollapsedBorderInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupCollapsedBorder);
		_ribbonGroupCollapsedFrameBackInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack);
		_ribbonGroupCollapsedFrameBorderInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder);
		_ribbonGroupCollapsedTextInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupCollapsedText);
		_ribbonGroupNormalBorderInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupNormalBorder);
		_ribbonGroupNormalTitleInherit = new PaletteRibbonDoubleInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGroupNormalTitle, PaletteRibbonTextStyle.RibbonGroupNormalTitle);
		_ribbonGroupRadioButtonTextInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupRadioButtonText);
		_ribbonGroupLabelTextInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonGroupLabelText);
		_ribbonTabInherit = new PaletteRibbonDoubleInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonTab, PaletteRibbonTextStyle.RibbonTab);
		_ribbonQATFullbarInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATFullbar);
		_ribbonQATMinibarInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATMinibar);
		_ribbonQATOverflowInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATOverflow);
		_ribbonAppButton = new PaletteRibbonBack(_ribbonAppButtonInherit, needPaint);
		_ribbonAppMenuInner = new PaletteRibbonBack(_ribbonAppMenuInnerInherit, needPaint);
		_ribbonAppMenuOuter = new PaletteRibbonBack(_ribbonAppMenuOuterInherit, needPaint);
		_ribbonAppMenuDocs = new PaletteRibbonBack(_ribbonAppMenuDocsInherit, needPaint);
		_ribbonAppMenuDocsTitle = new PaletteRibbonText(_ribbonAppMenuDocsTitleInherit, needPaint);
		_ribbonAppMenuDocsEntry = new PaletteRibbonText(_ribbonAppMenuDocsEntryInherit, needPaint);
		_ribbonGeneral = new PaletteRibbonGeneral(_ribbonGeneralInherit, needPaint);
		_ribbonGroupArea = new PaletteRibbonBack(_ribbonGroupAreaInherit, needPaint);
		_ribbonGroupButtonText = new PaletteRibbonText(_ribbonGroupButtonTextInherit, needPaint);
		_ribbonGroupCheckBoxText = new PaletteRibbonText(_ribbonGroupCheckBoxTextInherit, needPaint);
		_ribbonGroupCollapsedBack = new PaletteRibbonBack(_ribbonGroupCollapsedBackInherit, needPaint);
		_ribbonGroupCollapsedBorder = new PaletteRibbonBack(_ribbonGroupCollapsedBorderInherit, needPaint);
		_ribbonGroupCollapsedFrameBack = new PaletteRibbonBack(_ribbonGroupCollapsedFrameBackInherit, needPaint);
		_ribbonGroupCollapsedFrameBorder = new PaletteRibbonBack(_ribbonGroupCollapsedFrameBorderInherit, needPaint);
		_ribbonGroupCollapsedText = new PaletteRibbonText(_ribbonGroupCollapsedTextInherit, needPaint);
		_ribbonGroupNormalBorder = new PaletteRibbonBack(_ribbonGroupNormalBorderInherit, needPaint);
		_ribbonGroupNormalTitle = new PaletteRibbonDouble(_ribbonGroupNormalTitleInherit, _ribbonGroupNormalTitleInherit, needPaint);
		_ribbonGroupRadioButtonText = new PaletteRibbonText(_ribbonGroupRadioButtonTextInherit, needPaint);
		_ribbonGroupLabelText = new PaletteRibbonText(_ribbonGroupLabelTextInherit, needPaint);
		_ribbonTab = new PaletteRibbonDouble(_ribbonTabInherit, _ribbonTabInherit, needPaint);
		_ribbonQATFullbar = new PaletteRibbonBack(_ribbonQATFullbarInherit, needPaint);
		_ribbonQATMinibarActive = new PaletteRibbonBack(_ribbonQATMinibarInherit, needPaint);
		_ribbonQATMinibarInactive = new PaletteRibbonBack(_ribbonQATMinibarInherit, needPaint);
		_ribbonQATOverflow = new PaletteRibbonBack(_ribbonQATOverflowInherit, needPaint);
		_ribbonImages = new PaletteRibbonImages(redirect, base.NeedPaintDelegate);
	}

	public override void SetRedirector(PaletteRedirect redirect)
	{
		base.SetRedirector(redirect);
		_groupButtonInherit.SetRedirector(redirect);
		_groupClusterButtonInherit.SetRedirector(redirect);
		_groupCollapsedButtonInherit.SetRedirector(redirect);
		_groupDialogButtonInherit.SetRedirector(redirect);
		_keyTipInherit.SetRedirector(redirect);
		_qatButtonInherit.SetRedirector(redirect);
		_scrollerInherit.SetRedirector(redirect);
		_ribbonAppButtonInherit.SetRedirector(redirect);
		_ribbonAppMenuInnerInherit.SetRedirector(redirect);
		_ribbonAppMenuOuterInherit.SetRedirector(redirect);
		_ribbonAppMenuDocsInherit.SetRedirector(redirect);
		_ribbonAppMenuDocsTitleInherit.SetRedirector(redirect);
		_ribbonAppMenuDocsEntryInherit.SetRedirector(redirect);
		_ribbonGeneralInherit.SetRedirector(redirect);
		_ribbonGroupAreaInherit.SetRedirector(redirect);
		_ribbonGroupCheckBoxTextInherit.SetRedirector(redirect);
		_ribbonGroupNormalBorderInherit.SetRedirector(redirect);
		_ribbonGroupNormalTitleInherit.SetRedirector(redirect);
		_ribbonGroupButtonTextInherit.SetRedirector(redirect);
		_ribbonGroupCollapsedBackInherit.SetRedirector(redirect);
		_ribbonGroupCollapsedBorderInherit.SetRedirector(redirect);
		_ribbonGroupCollapsedFrameBackInherit.SetRedirector(redirect);
		_ribbonGroupCollapsedFrameBorderInherit.SetRedirector(redirect);
		_ribbonGroupCollapsedTextInherit.SetRedirector(redirect);
		_ribbonGroupRadioButtonTextInherit.SetRedirector(redirect);
		_ribbonGroupLabelTextInherit.SetRedirector(redirect);
		_ribbonTabInherit.SetRedirector(redirect);
		_ribbonQATFullbarInherit.SetRedirector(redirect);
		_ribbonQATMinibarInherit.SetRedirector(redirect);
		_ribbonQATOverflowInherit.SetRedirector(redirect);
	}

	private bool ShouldSerializeRibbonAppButton()
	{
		return !_ribbonAppButton.IsDefault;
	}

	private bool ShouldSerializeRibbonAppMenuOuter()
	{
		return !_ribbonAppMenuOuter.IsDefault;
	}

	private bool ShouldSerializeRibbonAppMenuInner()
	{
		return !_ribbonAppMenuInner.IsDefault;
	}

	private bool ShouldSerializeRibbonAppMenuDocs()
	{
		return !_ribbonAppMenuDocs.IsDefault;
	}

	private bool ShouldSerializeRibbonAppMenuDocsTitle()
	{
		return !_ribbonAppMenuDocsTitle.IsDefault;
	}

	private bool ShouldSerializeRibbonAppMenuDocsEntry()
	{
		return !_ribbonAppMenuDocsEntry.IsDefault;
	}

	private bool ShouldSerializeRibbonGeneral()
	{
		return !_ribbonGeneral.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupArea()
	{
		return !_ribbonGroupArea.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCheckBoxText()
	{
		return !_ribbonGroupCheckBoxText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupButtonText()
	{
		return !_ribbonGroupButtonText.IsDefault;
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

	private bool ShouldSerializeRibbonGroupNormalBorder()
	{
		return !_ribbonGroupNormalBorder.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupNormalTitle()
	{
		return !_ribbonGroupNormalTitle.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupRadioButtonText()
	{
		return !_ribbonGroupRadioButtonText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupLabelText()
	{
		return !_ribbonGroupLabelText.IsDefault;
	}

	private bool ShouldSerializeRibbonImages()
	{
		return !_ribbonImages.IsDefault;
	}

	private bool ShouldSerializeRibbonTab()
	{
		return !_ribbonTab.IsDefault;
	}

	private bool ShouldSerializeRibbonQATFullbar()
	{
		return !_ribbonQATFullbar.IsDefault;
	}

	private bool ShouldSerializeRibbonQATMinibarActive()
	{
		return !_ribbonQATMinibarActive.IsDefault;
	}

	private bool ShouldSerializeRibbonQATMinibarInactive()
	{
		return !_ribbonQATMinibarInactive.IsDefault;
	}

	private bool ShouldSerializeRibbonQATOverflow()
	{
		return !_ribbonQATOverflow.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
