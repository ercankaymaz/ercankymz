using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class GalleryImages : Storage
{
	private GalleryButtonImages _up;

	private GalleryButtonImages _down;

	private GalleryButtonImages _dropDown;

	[Browsable(false)]
	public override bool IsDefault => _up.IsDefault && _down.IsDefault && _dropDown.IsDefault;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery up button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GalleryButtonImages Up => _up;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery down button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GalleryButtonImages Down => _down;

	[KryptonPersist(true)]
	[Category("Visuals")]
	[Description("Gallery drop down button images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public GalleryButtonImages DropDown => _dropDown;

	public GalleryImages(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
		_up = new GalleryButtonImages(needPaint);
		_down = new GalleryButtonImages(needPaint);
		_dropDown = new GalleryButtonImages(needPaint);
	}
}
