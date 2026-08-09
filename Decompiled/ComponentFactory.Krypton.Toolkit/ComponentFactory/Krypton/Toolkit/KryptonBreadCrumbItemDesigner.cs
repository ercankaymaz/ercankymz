using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBreadCrumbItemDesigner : ComponentDesigner
{
	private KryptonBreadCrumbItem _crumbItem;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			if (_crumbItem != null)
			{
				arrayList.AddRange(_crumbItem.Items);
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
		_crumbItem = component as KryptonBreadCrumbItem;
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
		if (_crumbItem != null && e.Component == _crumbItem)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _crumbItem.Items.Count - 1; num >= 0; num--)
			{
				Component value = _crumbItem.Items[num];
				_crumbItem.Items.Remove(value);
				designerHost.DestroyComponent(value);
			}
		}
	}
}
