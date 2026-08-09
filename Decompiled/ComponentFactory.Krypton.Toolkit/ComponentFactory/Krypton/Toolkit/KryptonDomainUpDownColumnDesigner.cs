using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDomainUpDownColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewDomainUpDownColumn _domainUpDown;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_domainUpDown != null)
			{
				return _domainUpDown.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_domainUpDown = component as KryptonDataGridViewDomainUpDownColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_domainUpDown != null && e.Component == _domainUpDown)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _domainUpDown.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _domainUpDown.ButtonSpecs[num];
				_changeService.OnComponentChanging(_domainUpDown, null);
				_domainUpDown.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_domainUpDown, null, null, null);
			}
		}
	}
}
