using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonContextMenuDesigner : ComponentDesigner
{
	private KryptonContextMenu _contextMenu;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			if (_contextMenu != null)
			{
				arrayList.AddRange(_contextMenu.Items);
			}
			return arrayList;
		}
	}

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			DesignerActionListCollection designerActionListCollection = new DesignerActionListCollection();
			designerActionListCollection.Add(new KryptonContextMenuActionList(this));
			return designerActionListCollection;
		}
	}

	public override void Initialize(IComponent component)
	{
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_contextMenu = component as KryptonContextMenu;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_changeService.ComponentRemoving += OnComponentRemoving;
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
		if (_contextMenu != null && e.Component == _contextMenu)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _contextMenu.Items.Count - 1; num >= 0; num--)
			{
				Component value = _contextMenu.Items[num];
				_contextMenu.Items.Remove(value);
				designerHost.DestroyComponent(value);
			}
		}
	}
}
