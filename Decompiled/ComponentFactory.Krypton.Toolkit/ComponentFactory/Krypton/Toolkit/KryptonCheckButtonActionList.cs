using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckButtonActionList : KryptonButtonActionList
{
	private KryptonCheckButton _checkButton;

	private IComponentChangeService _service;

	private string _action;

	public bool Checked
	{
		get
		{
			return _checkButton.Checked;
		}
		set
		{
			if (_checkButton.Checked != value)
			{
				_service.OnComponentChanged(_checkButton, null, _checkButton.Checked, value);
				_checkButton.Checked = value;
			}
		}
	}

	public KryptonCheckButtonActionList(KryptonCheckButtonDesigner owner)
		: base(owner)
	{
		_checkButton = owner.Component as KryptonCheckButton;
		if (_checkButton != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_checkButton)["Checked"];
			if (propertyDescriptor != null)
			{
				if ((bool)propertyDescriptor.GetValue(_checkButton))
				{
					_action = "Uncheck the button";
				}
				else
				{
					_action = "Check the button";
				}
			}
		}
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_checkButton != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb(_action, OnCheckedClick), "Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ButtonStyle", "Style", "Appearance", "Button style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Button orientation"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Values", "Button text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ExtraText", "ExtraText", "Values", "Button extra text"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Image", "Image", "Values", "Button image"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnCheckedClick(object sender, EventArgs e)
	{
		if (sender is DesignerVerb designerVerb)
		{
			bool flag = designerVerb.Text.Equals("Uncheck the button");
			if (flag)
			{
				_action = "Uncheck the button";
			}
			else
			{
				_action = "Check the button";
			}
			TypeDescriptor.GetProperties(_checkButton)["Checked"]?.SetValue(_checkButton, !flag);
			if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
			{
				designerActionUIService.Refresh(_checkButton);
			}
		}
	}
}
