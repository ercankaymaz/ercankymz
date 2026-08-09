using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonSplitContainerActionList : DesignerActionList
{
	private KryptonSplitContainer _splitContainer;

	private IComponentChangeService _service;

	private string _action;

	public PaletteBackStyle ContainerBackStyle
	{
		get
		{
			return _splitContainer.ContainerBackStyle;
		}
		set
		{
			if (_splitContainer.ContainerBackStyle != value)
			{
				_service.OnComponentChanged(_splitContainer, null, _splitContainer.ContainerBackStyle, value);
				_splitContainer.ContainerBackStyle = value;
			}
		}
	}

	public SeparatorStyle SeparatorStyle
	{
		get
		{
			return _splitContainer.SeparatorStyle;
		}
		set
		{
			if (_splitContainer.SeparatorStyle != value)
			{
				_service.OnComponentChanged(_splitContainer, null, _splitContainer.SeparatorStyle, value);
				_splitContainer.SeparatorStyle = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _splitContainer.PaletteMode;
		}
		set
		{
			if (_splitContainer.PaletteMode != value)
			{
				_service.OnComponentChanged(_splitContainer, null, _splitContainer.PaletteMode, value);
				_splitContainer.PaletteMode = value;
			}
		}
	}

	public KryptonSplitContainerActionList(KryptonSplitContainerDesigner owner)
		: base(owner.Component)
	{
		_splitContainer = owner.Component as KryptonSplitContainer;
		if (_splitContainer != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_splitContainer)["Orientation"];
			if (propertyDescriptor != null)
			{
				if ((Orientation)propertyDescriptor.GetValue(_splitContainer) == Orientation.Vertical)
				{
					_action = "Horizontal splitter orientation";
				}
				else
				{
					_action = "Vertical splitter orientation";
				}
			}
		}
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_splitContainer != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ContainerBackStyle", "Back style", "Appearance", "Background style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Splitter"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb(_action, OnOrientationClick), "Splitter"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("SeparatorStyle", "Separator style", "Splitter", "Separator style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnOrientationClick(object sender, EventArgs e)
	{
		if (sender is DesignerVerb designerVerb)
		{
			Orientation orientation = ((!designerVerb.Text.Equals("Horizontal splitter orientation")) ? Orientation.Vertical : Orientation.Horizontal);
			if (orientation == Orientation.Vertical)
			{
				_action = "Horizontal splitter orientation";
			}
			else
			{
				_action = "Vertical splitter orientation";
			}
			TypeDescriptor.GetProperties(_splitContainer)["Orientation"]?.SetValue(_splitContainer, orientation);
			if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
			{
				designerActionUIService.Refresh(_splitContainer);
			}
		}
	}
}
