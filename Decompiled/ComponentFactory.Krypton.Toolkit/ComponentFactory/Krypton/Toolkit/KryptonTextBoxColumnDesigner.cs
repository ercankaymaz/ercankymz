using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTextBoxColumnDesigner : ComponentDesigner
{
	private KryptonDataGridViewTextBoxColumn _textBox;

	private IComponentChangeService _changeService;

	public override ICollection AssociatedComponents
	{
		get
		{
			if (_textBox != null)
			{
				return _textBox.ButtonSpecs;
			}
			return base.AssociatedComponents;
		}
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_textBox = component as KryptonDataGridViewTextBoxColumn;
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (_textBox != null && e.Component == _textBox)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _textBox.ButtonSpecs.Count - 1; num >= 0; num--)
			{
				ButtonSpec value = _textBox.ButtonSpecs[num];
				_changeService.OnComponentChanging(_textBox, null);
				_textBox.ButtonSpecs.Remove(value);
				designerHost.DestroyComponent(value);
				_changeService.OnComponentChanged(_textBox, null, null, null);
			}
		}
	}
}
