using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonMaskedTextBoxColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewMaskedTextBoxColumn _maskedTextBox;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_maskedTextBox != null)
			{
				return _maskedTextBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_maskedTextBox = component as KryptonDataGridViewMaskedTextBoxColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_maskedTextBox != null && e.Component == _maskedTextBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _maskedTextBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _maskedTextBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_maskedTextBox, null);
				_maskedTextBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_maskedTextBox, null, null, null);
			}
		}
	}
}
