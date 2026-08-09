#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteRibbon : Storage
{
	private PaletteRedirect _redirect;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuOuterInherit;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuInnerInherit;

	private PaletteRibbonBackInheritRedirect _ribbonAppMenuDocsInherit;

	private PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsTitleInherit;

	private PaletteRibbonTextInheritRedirect _ribbonAppMenuDocsEntryInherit;

	private PaletteRibbonGeneralInheritRedirect _ribbonGeneralRedirect;

	private PaletteRibbonBackInheritRedirect _ribbonQATFullRedirect;

	private PaletteRibbonBackInheritRedirect _ribbonQATOverRedirect;

	private PaletteRibbonBackInheritRedirect _ribbonGalleryBackRedirect;

	private PaletteRibbonBackInheritRedirect _ribbonGalleryBorderRedirect;

	private PaletteRibbonGeneral _ribbonGeneral;

	private KryptonPaletteRibbonAppButton _ribbonAppButton;

	private KryptonPaletteRibbonGroupArea _ribbonGroupArea;

	private KryptonPaletteRibbonGroupButtonText _ribbonGroupButtonText;

	private KryptonPaletteRibbonGroupCheckBoxText _ribbonGroupCheckBoxText;

	private KryptonPaletteRibbonGroupNormalBorder _ribbonGroupNormalBorder;

	private KryptonPaletteRibbonGroupNormalTitle _ribbonGroupNormalTitle;

	private KryptonPaletteRibbonGroupCollapsedBorder _ribbonGroupCollapsedBorder;

	private KryptonPaletteRibbonGroupCollapsedBack _ribbonGroupCollapsedBack;

	private KryptonPaletteRibbonGroupCollapsedFrameBorder _ribbonGroupCollapsedFrameBorder;

	private KryptonPaletteRibbonGroupCollapsedFrameBack _ribbonGroupCollapsedFrameBack;

	private KryptonPaletteRibbonGroupCollapsedText _ribbonGroupCollapsedText;

	private KryptonPaletteRibbonGroupRadioButtonText _ribbonGroupRadioButtonText;

	private KryptonPaletteRibbonGroupLabelText _ribbonGroupLabelText;

	private PaletteRibbonBack _ribbonQATFullbar;

	private KryptonPaletteRibbonQATMinibar _ribbonQATMinibar;

	private PaletteRibbonBack _ribbonQATOverflow;

	private KryptonPaletteRibbonTab _ribbonTab;

	private PaletteRibbonBack _ribbonAppMenuInner;

	private PaletteRibbonBack _ribbonAppMenuOuter;

	private PaletteRibbonBack _ribbonAppMenuDocs;

	private PaletteRibbonText _ribbonAppMenuDocsTitle;

	private PaletteRibbonText _ribbonAppMenuDocsEntry;

	private PaletteRibbonBack _ribbonGalleryBack;

	private PaletteRibbonBack _ribbonGalleryBorder;

	public override bool IsDefault => RibbonAppButton.IsDefault && RibbonAppMenuOuter.IsDefault && RibbonAppMenuInner.IsDefault && RibbonAppMenuDocs.IsDefault && RibbonAppMenuDocsTitle.IsDefault && RibbonAppMenuDocsEntry.IsDefault && RibbonGeneral.IsDefault && RibbonGroupArea.IsDefault && RibbonGroupButtonText.IsDefault && RibbonGroupCheckBoxText.IsDefault && RibbonGroupNormalBorder.IsDefault && RibbonGroupNormalTitle.IsDefault && RibbonGroupCollapsedBorder.IsDefault && RibbonGroupCollapsedBack.IsDefault && RibbonGroupCollapsedFrameBorder.IsDefault && RibbonGroupCollapsedFrameBack.IsDefault && RibbonGroupCollapsedText.IsDefault && RibbonGroupLabelText.IsDefault && RibbonGroupRadioButtonText.IsDefault && RibbonQATFullbar.IsDefault && RibbonQATMinibar.IsDefault && RibbonTab.IsDefault && RibbonGalleryBack.IsDefault && RibbonGalleryBorder.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon application button specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonAppButton RibbonAppButton => _ribbonAppButton;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining application button menu outer appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuOuter => _ribbonAppMenuOuter;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining application button menu inner appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuInner => _ribbonAppMenuInner;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent docs appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonAppMenuDocs => _ribbonAppMenuDocs;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent documents title.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonAppMenuDocsTitle => _ribbonAppMenuDocsTitle;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining application button menu recent documents entry.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonText RibbonAppMenuDocsEntry => _ribbonAppMenuDocsEntry;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon general settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonGeneral RibbonGeneral => _ribbonGeneral;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group area specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupArea RibbonGroupArea => _ribbonGroupArea;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group button text specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupButtonText RibbonGroupButtonText => _ribbonGroupButtonText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group check box text specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCheckBoxText RibbonGroupCheckBoxText => _ribbonGroupCheckBoxText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group normal border specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupNormalBorder RibbonGroupNormalBorder => _ribbonGroupNormalBorder;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group normal title specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupNormalTitle RibbonGroupNormalTitle => _ribbonGroupNormalTitle;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group collapsed border specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCollapsedBorder RibbonGroupCollapsedBorder => _ribbonGroupCollapsedBorder;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group collapsed background specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCollapsedBack RibbonGroupCollapsedBack => _ribbonGroupCollapsedBack;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group collapsed frame border specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCollapsedFrameBorder RibbonGroupCollapsedFrameBorder => _ribbonGroupCollapsedFrameBorder;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group collapsed frame background specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCollapsedFrameBack RibbonGroupCollapsedFrameBack => _ribbonGroupCollapsedFrameBack;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group collapsed text specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupCollapsedText RibbonGroupCollapsedText => _ribbonGroupCollapsedText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group label text specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupLabelText RibbonGroupLabelText => _ribbonGroupLabelText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon group radio button text specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonGroupRadioButtonText RibbonGroupRadioButtonText => _ribbonGroupRadioButtonText;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon quick access toolbar full settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack RibbonQATFullbar => _ribbonQATFullbar;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon quick access toolbar mini settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonQATMinibar RibbonQATMinibar => _ribbonQATMinibar;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon quick access toolbar overflow settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteRibbonBack RibbonQATOverflow => _ribbonQATOverflow;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Ribbon tab specific settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbonTab RibbonTab => _ribbonTab;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ribbon gallery background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGalleryBack => _ribbonGalleryBack;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ribbon gallery border appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public virtual PaletteRibbonBack RibbonGalleryBorder => _ribbonGalleryBorder;

	internal KryptonPaletteRibbon(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		_ribbonGeneralRedirect = new PaletteRibbonGeneralInheritRedirect(redirect);
		_ribbonAppMenuInnerInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuInner);
		_ribbonAppMenuOuterInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuOuter);
		_ribbonAppMenuDocsInherit = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonAppMenuDocs);
		_ribbonAppMenuDocsTitleInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsTitle);
		_ribbonAppMenuDocsEntryInherit = new PaletteRibbonTextInheritRedirect(redirect, PaletteRibbonTextStyle.RibbonAppMenuDocsEntry);
		_ribbonQATFullRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATFullbar);
		_ribbonQATOverRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonQATOverflow);
		_ribbonGalleryBackRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBack);
		_ribbonGalleryBorderRedirect = new PaletteRibbonBackInheritRedirect(redirect, PaletteRibbonBackStyle.RibbonGalleryBorder);
		_ribbonGeneral = new PaletteRibbonGeneral(_ribbonGeneralRedirect, needPaint);
		_ribbonAppButton = new KryptonPaletteRibbonAppButton(redirect, needPaint);
		_ribbonAppMenuInner = new PaletteRibbonBack(_ribbonAppMenuInnerInherit, needPaint);
		_ribbonAppMenuOuter = new PaletteRibbonBack(_ribbonAppMenuOuterInherit, needPaint);
		_ribbonAppMenuDocs = new PaletteRibbonBack(_ribbonAppMenuDocsInherit, needPaint);
		_ribbonAppMenuDocsTitle = new PaletteRibbonText(_ribbonAppMenuDocsTitleInherit, needPaint);
		_ribbonAppMenuDocsEntry = new PaletteRibbonText(_ribbonAppMenuDocsEntryInherit, needPaint);
		_ribbonGroupArea = new KryptonPaletteRibbonGroupArea(redirect, needPaint);
		_ribbonGroupButtonText = new KryptonPaletteRibbonGroupButtonText(redirect, needPaint);
		_ribbonGroupCheckBoxText = new KryptonPaletteRibbonGroupCheckBoxText(redirect, needPaint);
		_ribbonGroupNormalBorder = new KryptonPaletteRibbonGroupNormalBorder(redirect, needPaint);
		_ribbonGroupNormalTitle = new KryptonPaletteRibbonGroupNormalTitle(redirect, needPaint);
		_ribbonGroupCollapsedBorder = new KryptonPaletteRibbonGroupCollapsedBorder(redirect, needPaint);
		_ribbonGroupCollapsedBack = new KryptonPaletteRibbonGroupCollapsedBack(redirect, needPaint);
		_ribbonGroupCollapsedFrameBorder = new KryptonPaletteRibbonGroupCollapsedFrameBorder(redirect, needPaint);
		_ribbonGroupCollapsedFrameBack = new KryptonPaletteRibbonGroupCollapsedFrameBack(redirect, needPaint);
		_ribbonGroupCollapsedText = new KryptonPaletteRibbonGroupCollapsedText(redirect, needPaint);
		_ribbonGroupRadioButtonText = new KryptonPaletteRibbonGroupRadioButtonText(redirect, needPaint);
		_ribbonGroupLabelText = new KryptonPaletteRibbonGroupLabelText(redirect, needPaint);
		_ribbonQATFullbar = new PaletteRibbonBack(_ribbonQATFullRedirect, needPaint);
		_ribbonQATMinibar = new KryptonPaletteRibbonQATMinibar(redirect, needPaint);
		_ribbonQATOverflow = new PaletteRibbonBack(_ribbonQATOverRedirect, needPaint);
		_ribbonTab = new KryptonPaletteRibbonTab(redirect, needPaint);
		_ribbonGalleryBack = new PaletteRibbonBack(_ribbonGalleryBackRedirect, needPaint);
		_ribbonGalleryBorder = new PaletteRibbonBack(_ribbonGalleryBorderRedirect, needPaint);
	}

	public void PopulateFromBase()
	{
		RibbonAppButton.PopulateFromBase();
		RibbonAppMenuOuter.PopulateFromBase(PaletteState.Normal);
		RibbonAppMenuInner.PopulateFromBase(PaletteState.Normal);
		RibbonAppMenuDocs.PopulateFromBase(PaletteState.Normal);
		RibbonAppMenuDocsTitle.PopulateFromBase(PaletteState.Normal);
		RibbonAppMenuDocsEntry.PopulateFromBase(PaletteState.Normal);
		RibbonGeneral.PopulateFromBase();
		RibbonGroupArea.PopulateFromBase();
		RibbonGroupButtonText.PopulateFromBase();
		RibbonGroupCheckBoxText.PopulateFromBase();
		RibbonGroupNormalBorder.PopulateFromBase();
		RibbonGroupNormalTitle.PopulateFromBase();
		RibbonGroupCollapsedBack.PopulateFromBase();
		RibbonGroupCollapsedBorder.PopulateFromBase();
		RibbonGroupCollapsedFrameBorder.PopulateFromBase();
		RibbonGroupCollapsedFrameBack.PopulateFromBase();
		RibbonGroupCollapsedText.PopulateFromBase();
		RibbonGroupRadioButtonText.PopulateFromBase();
		RibbonGroupLabelText.PopulateFromBase();
		RibbonQATFullbar.PopulateFromBase(PaletteState.Normal);
		RibbonQATMinibar.PopulateFromBase();
		RibbonQATOverflow.PopulateFromBase(PaletteState.Normal);
		RibbonTab.PopulateFromBase();
		RibbonGalleryBack.PopulateFromBase(PaletteState.Normal);
		RibbonGalleryBorder.PopulateFromBase(PaletteState.Normal);
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

	private bool ShouldSerializeRibbonGroupButtonText()
	{
		return !_ribbonGroupButtonText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupCheckBoxText()
	{
		return !_ribbonGroupCheckBoxText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupNormalBorder()
	{
		return !_ribbonGroupNormalBorder.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupNormalTitle()
	{
		return !_ribbonGroupNormalTitle.IsDefault;
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

	private bool ShouldSerializeRibbonGroupLabelText()
	{
		return !_ribbonGroupLabelText.IsDefault;
	}

	private bool ShouldSerializeRibbonGroupRadioButtonText()
	{
		return !_ribbonGroupRadioButtonText.IsDefault;
	}

	private bool ShouldSerializeRibbonQATFullbar()
	{
		return !_ribbonQATFullbar.IsDefault;
	}

	private bool ShouldSerializeRibbonQATMinibar()
	{
		return !_ribbonQATMinibar.IsDefault;
	}

	private bool ShouldSerializeRibbonQATOverflow()
	{
		return !_ribbonQATOverflow.IsDefault;
	}

	private bool ShouldSerializeRibbonTab()
	{
		return !_ribbonTab.IsDefault;
	}

	private bool ShouldSerializeRibbonGalleryBack()
	{
		return !_ribbonGalleryBack.IsDefault;
	}

	private bool ShouldSerializeRibbonGalleryBorder()
	{
		return !_ribbonGalleryBorder.IsDefault;
	}
}
