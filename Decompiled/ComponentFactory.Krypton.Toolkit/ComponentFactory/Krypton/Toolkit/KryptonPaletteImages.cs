#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImages : Storage
{
	private KryptonPaletteImagesCheckBox _imagesCheckBox;

	private KryptonPaletteImagesContextMenu _imagesContextMenu;

	private KryptonPaletteImagesDropDownButton _imagesDropDownButton;

	private KryptonPaletteImagesGalleryButtons _imagesGalleryButtons;

	private KryptonPaletteImagesRadioButton _imagesRadioButton;

	private KryptonPaletteImagesTreeView _imagesTreeView;

	public override bool IsDefault => _imagesCheckBox.IsDefault && _imagesContextMenu.IsDefault && _imagesDropDownButton.IsDefault && _imagesGalleryButtons.IsDefault && _imagesRadioButton.IsDefault && _imagesTreeView.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining check box images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesCheckBox CheckBox => _imagesCheckBox;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context menu images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesContextMenu ContextMenu => _imagesContextMenu;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining drop down button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesDropDownButton DropDownButton => _imagesDropDownButton;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining gallery button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesGalleryButtons GalleryButtons => _imagesGalleryButtons;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining radio button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesRadioButton RadioButton => _imagesRadioButton;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tree view images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesTreeView TreeView => _imagesTreeView;

	internal KryptonPaletteImages(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_imagesCheckBox = new KryptonPaletteImagesCheckBox(redirector, needPaint);
		_imagesContextMenu = new KryptonPaletteImagesContextMenu(redirector, needPaint);
		_imagesDropDownButton = new KryptonPaletteImagesDropDownButton(redirector, needPaint);
		_imagesGalleryButtons = new KryptonPaletteImagesGalleryButtons(redirector, needPaint);
		_imagesRadioButton = new KryptonPaletteImagesRadioButton(redirector, needPaint);
		_imagesTreeView = new KryptonPaletteImagesTreeView(redirector, needPaint);
	}

	public void PopulateFromBase()
	{
		_imagesCheckBox.PopulateFromBase();
		_imagesContextMenu.PopulateFromBase();
		_imagesDropDownButton.PopulateFromBase();
		_imagesGalleryButtons.PopulateFromBase();
		_imagesRadioButton.PopulateFromBase();
		_imagesTreeView.PopulateFromBase();
	}

	private bool ShouldSerializeCheckBox()
	{
		return !_imagesCheckBox.IsDefault;
	}

	private bool ShouldSerializeContextMenu()
	{
		return !_imagesContextMenu.IsDefault;
	}

	private bool ShouldSerializeDropDownButton()
	{
		return !_imagesDropDownButton.IsDefault;
	}

	private bool ShouldSerializeGalleryButtons()
	{
		return !_imagesGalleryButtons.IsDefault;
	}

	private bool ShouldSerializeRadioButton()
	{
		return !_imagesRadioButton.IsDefault;
	}

	private bool ShouldSerializeTreeView()
	{
		return !_imagesTreeView.IsDefault;
	}
}
