using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonDateTimePickerColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewDateTimePickerColumn _dateTimePicker;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_dateTimePicker != null)
			{
				return _dateTimePicker.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_dateTimePicker = component as KryptonDataGridViewDateTimePickerColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_dateTimePicker != null && e.Component == _dateTimePicker)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _dateTimePicker.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _dateTimePicker.ButtonSpecs[num];
				_changeService.OnComponentChanging(_dateTimePicker, null);
				_dateTimePicker.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_dateTimePicker, null, null, null);
			}
		}
	}
}
