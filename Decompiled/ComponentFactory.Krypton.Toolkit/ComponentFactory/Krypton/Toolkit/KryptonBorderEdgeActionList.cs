using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBorderEdgeActionList : DesignerActionList
{
	private KryptonBorderEdge _borderEdge;

	private IComponentChangeService _service;

	private string _action;

	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _borderEdge.BorderStyle;
		}
		set
		{
			if (_borderEdge.BorderStyle != value)
			{
				_service.OnComponentChanged(_borderEdge, null, _borderEdge.BorderStyle, value);
				_borderEdge.BorderStyle = value;
			}
		}
	}

	public bool AutoSize
	{
		get
		{
			return _borderEdge.AutoSize;
		}
		set
		{
			if (_borderEdge.AutoSize != value)
			{
				_service.OnComponentChanged(_borderEdge, null, _borderEdge.AutoSize, value);
				_borderEdge.AutoSize = value;
			}
		}
	}

	public DockStyle Dock
	{
		get
		{
			return _borderEdge.Dock;
		}
		set
		{
			if (_borderEdge.Dock != value)
			{
				_service.OnComponentChanged(_borderEdge, null, _borderEdge.Dock, value);
				_borderEdge.Dock = value;
			}
		}
	}

	public PaletteMode PaletteMode
	{
		get
		{
			return _borderEdge.PaletteMode;
		}
		set
		{
			if (_borderEdge.PaletteMode != value)
			{
				_service.OnComponentChanged(_borderEdge, null, _borderEdge.PaletteMode, value);
				_borderEdge.PaletteMode = value;
			}
		}
	}

	public KryptonBorderEdgeActionList(KryptonBorderEdgeDesigner owner)
		: base(owner.Component)
	{
		_borderEdge = owner.Component as KryptonBorderEdge;
		if (_borderEdge != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_borderEdge)["Orientation"];
			if (propertyDescriptor != null)
			{
				if ((Orientation)propertyDescriptor.GetValue(_borderEdge) == Orientation.Vertical)
				{
					_action = "Horizontal border orientation";
				}
				else
				{
					_action = "Vertical border orientation";
				}
			}
		}
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_borderEdge != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderStyle", "Border style", "Appearance", "Border style"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Layout"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("AutoSize", "AutoSize", "Layout", "Determines whether the control resizes based on its contents."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Dock", "Dock", "Layout", "Determines how the control is sized with its parent."));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb(_action, OnOrientationClick), "Layout"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnOrientationClick(object sender, EventArgs e)
	{
		if (sender is DesignerVerb designerVerb)
		{
			Orientation orientation = ((!designerVerb.Text.Equals("Horizontal border orientation")) ? Orientation.Vertical : Orientation.Horizontal);
			if (orientation == Orientation.Vertical)
			{
				_action = "Horizontal border orientation";
			}
			else
			{
				_action = "Vertical border orientation";
			}
			TypeDescriptor.GetProperties(_borderEdge)["Orientation"]?.SetValue(_borderEdge, orientation);
			if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
			{
				designerActionUIService.Refresh(_borderEdge);
			}
		}
	}
}
