#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonGalleryDesigner : ParentControlDesigner
{
	private KryptonGallery _gallery;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			foreach (KryptonGalleryRange dropButtonRange in _gallery.DropButtonRanges)
			{
				arrayList.Add(dropButtonRange);
			}
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonGalleryActionList(this));
			return designerActionListCollection;
		}
	}

	public KryptonGalleryDesigner()
	{
		base.AutoResizeHandles = true;
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_gallery = (KryptonGallery)component;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_changeService.ComponentRemoving += OnComponentRemoving;
	}

	public override bool CanParent(Control control)
	{
		return false;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				_changeService.ComponentRemoving -= OnComponentRemoving;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _gallery)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _gallery.DropButtonRanges.Count - 1; num >= 0; num--)
			{
				KryptonGalleryRange item = _gallery.DropButtonRanges[num];
				_gallery.DropButtonRanges.Remove(item);
				designerHost.DestroyComponent(item);
			}
		}
	}
}
