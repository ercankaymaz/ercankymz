using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonComboBoxColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewComboBoxColumn _comboBox;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_comboBox != null)
			{
				return _comboBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_comboBox = component as KryptonDataGridViewComboBoxColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_comboBox != null && e.Component == _comboBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _comboBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _comboBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_comboBox, null);
				_comboBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_comboBox, null, null, null);
			}
		}
	}
}
