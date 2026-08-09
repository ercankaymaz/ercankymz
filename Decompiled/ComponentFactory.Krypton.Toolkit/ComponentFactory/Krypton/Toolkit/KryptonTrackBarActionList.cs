using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonTrackBarActionList : DesignerActionList
{
	private KryptonTrackBar _trackBar;

	private IComponentChangeService _service;

	private string _action;

	public PaletteMode PaletteMode
	{
		get
		{
			return _trackBar.PaletteMode;
		}
		set
		{
			if (_trackBar.PaletteMode != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.PaletteMode, value);
				_trackBar.PaletteMode = value;
			}
		}
	}

	public TickStyle TickStyle
	{
		get
		{
			return _trackBar.TickStyle;
		}
		set
		{
			if (_trackBar.TickStyle != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.TickStyle, value);
				_trackBar.TickStyle = value;
			}
		}
	}

	public PaletteTrackBarSize TrackBarSize
	{
		get
		{
			return _trackBar.TrackBarSize;
		}
		set
		{
			if (_trackBar.TrackBarSize != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.TrackBarSize, value);
				_trackBar.TrackBarSize = value;
			}
		}
	}

	public int Minimum
	{
		get
		{
			return _trackBar.Minimum;
		}
		set
		{
			if (_trackBar.Minimum != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.Minimum, value);
				_trackBar.Minimum = value;
			}
		}
	}

	public int Maximum
	{
		get
		{
			return _trackBar.Maximum;
		}
		set
		{
			if (_trackBar.Maximum != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.Maximum, value);
				_trackBar.Maximum = value;
			}
		}
	}

	public int SmallChange
	{
		get
		{
			return _trackBar.SmallChange;
		}
		set
		{
			if (_trackBar.SmallChange != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.SmallChange, value);
				_trackBar.SmallChange = value;
			}
		}
	}

	public int LargeChange
	{
		get
		{
			return _trackBar.LargeChange;
		}
		set
		{
			if (_trackBar.LargeChange != value)
			{
				_service.OnComponentChanged(_trackBar, null, _trackBar.LargeChange, value);
				_trackBar.LargeChange = value;
			}
		}
	}

	public KryptonTrackBarActionList(KryptonTrackBarDesigner owner)
		: base(owner.Component)
	{
		_trackBar = owner.Component as KryptonTrackBar;
		if (_trackBar != null)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_trackBar)["Orientation"];
			if (propertyDescriptor != null)
			{
				if ((Orientation)propertyDescriptor.GetValue(_trackBar) == Orientation.Vertical)
				{
					_action = "Horizontal orientation";
				}
				else
				{
					_action = "Vertical orientation";
				}
			}
		}
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_trackBar != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Layout"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("TickStyle", "Tick Style", "Layout", "Tick style"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("TrackBarSize", "TrackBar Size", "Layout", "Size of the track bar"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb(_action, OnOrientationClick), "Layout"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Values"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Minimum", "Minimum", "Values", "Minium value"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Maximum", "Maximum", "Values", "Maximum value"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("SmallChange", "Small Change", "Values", "Small change value"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("LargeChange", "Large Change", "Values", "Large change value"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}

	private void OnOrientationClick(object sender, EventArgs e)
	{
		if (sender is DesignerVerb designerVerb)
		{
			Orientation orientation = ((!designerVerb.Text.Equals("Horizontal orientation")) ? Orientation.Vertical : Orientation.Horizontal);
			if (orientation == Orientation.Vertical)
			{
				_action = "Horizontal orientation";
			}
			else
			{
				_action = "Vertical orientation";
			}
			TypeDescriptor.GetProperties(_trackBar)["Orientation"]?.SetValue(_trackBar, orientation);
			if (GetService(typeof(DesignerActionUIService)) is DesignerActionUIService designerActionUIService)
			{
				designerActionUIService.Refresh(_trackBar);
			}
		}
	}
}
