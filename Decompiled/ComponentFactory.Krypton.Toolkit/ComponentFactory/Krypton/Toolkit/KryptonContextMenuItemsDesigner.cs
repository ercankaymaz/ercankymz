using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonContextMenuItemsDesigner : ComponentDesigner
{
	private KryptonContextMenuItems _contextMenuItems;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			if (_contextMenuItems != null)
			{
				arrayList.AddRange(_contextMenuItems.Items);
			}
			return arrayList;
		}
	}

	public override void Initialize(IComponent component)
	{
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_contextMenuItems = component as KryptonContextMenuItems;
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
		if (_contextMenuItems != null && e.Component == _contextMenuItems)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _contextMenuItems.Items.Count - 1; num >= 0; num--)
			{
				Component value = _contextMenuItems.Items[num];
				_contextMenuItems.Items.Remove(value);
				designerHost.DestroyComponent(value);
			}
		}
	}
}
