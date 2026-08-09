using System.ComponentModel.Design;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonGalleryActionList : DesignerActionList
{
	private KryptonGallery _gallery;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _gallery.PaletteMode;
		}
		set
		{
			if (_gallery.PaletteMode != value)
			{
				_service.OnComponentChanged(_gallery, null, _gallery.PaletteMode, value);
				_gallery.PaletteMode = value;
			}
		}
	}

	public KryptonGalleryActionList(KryptonGalleryDesigner owner)
		: base(owner.Component)
	{
		_gallery = (KryptonGallery)owner.Component;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_gallery != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}
