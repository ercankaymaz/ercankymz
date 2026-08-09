using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonNumericUpDownColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewNumericUpDownColumn _numericUpDown;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_numericUpDown != null)
			{
				return _numericUpDown.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_numericUpDown = component as KryptonDataGridViewNumericUpDownColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_numericUpDown != null && e.Component == _numericUpDown)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _numericUpDown.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _numericUpDown.ButtonSpecs[num];
				_changeService.OnComponentChanging(_numericUpDown, null);
				_numericUpDown.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_numericUpDown, null, null, null);
			}
		}
	}
}
