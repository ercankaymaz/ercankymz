using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteImagesGalleryButtons : Storage
{
	private KryptonPaletteImagesGalleryButton _up;

	private KryptonPaletteImagesGalleryButton _down;

	private KryptonPaletteImagesGalleryButton _dropDown;

	[Browsable(false)]
	public override bool IsDefault => _up.IsDefault && _down.IsDefault && _dropDown.IsDefault;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery up button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesGalleryButton Up => _up;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery down button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesGalleryButton Down => _down;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery drop down button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImagesGalleryButton DropDown => _dropDown;

	public KryptonPaletteImagesGalleryButtons(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_up = new KryptonPaletteImagesGalleryButton(PaletteRibbonGalleryButton.Up, redirector, needPaint);
		_down = new KryptonPaletteImagesGalleryButton(PaletteRibbonGalleryButton.Down, redirector, needPaint);
		_dropDown = new KryptonPaletteImagesGalleryButton(PaletteRibbonGalleryButton.DropDown, redirector, needPaint);
	}

	public void PopulateFromBase()
	{
		_up.PopulateFromBase();
		_down.PopulateFromBase();
		_dropDown.PopulateFromBase();
	}
}
