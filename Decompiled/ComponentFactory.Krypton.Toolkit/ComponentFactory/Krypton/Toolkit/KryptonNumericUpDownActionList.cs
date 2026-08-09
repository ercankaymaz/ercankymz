using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonNumericUpDownActionList : DesignerActionList
{
	private KryptonNumericUpDown _numericUpDown;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _numericUpDown.PaletteMode;
		}
		set
		{
			if (_numericUpDown.PaletteMode != value)
			{
				_service.OnComponentChanged(_numericUpDown, null, _numericUpDown.PaletteMode, value);
				_numericUpDown.PaletteMode = value;
			}
		}
	}

	public InputControlStyle InputControlStyle
	{
		get
		{
			return _numericUpDown.InputControlStyle;
		}
		set
		{
			if (_numericUpDown.InputControlStyle != value)
			{
				_service.OnComponentChanged(_numericUpDown, null, _numericUpDown.InputControlStyle, value);
				_numericUpDown.InputControlStyle = value;
			}
		}
	}

	public decimal Increment
	{
		get
		{
			return _numericUpDown.Increment;
		}
		set
		{
			if (_numericUpDown.Increment != value)
			{
				_service.OnComponentChanged(_numericUpDown, null, _numericUpDown.Increment, value);
				_numericUpDown.Increment = value;
			}
		}
	}

	public decimal Maximum
	{
		get
		{
			return _numericUpDown.Maximum;
		}
		set
		{
			if (_numericUpDown.Maximum != value)
			{
				_service.OnComponentChanged(_numericUpDown, null, _numericUpDown.Maximum, value);
				_numericUpDown.Maximum = value;
			}
		}
	}

	public decimal Minimum
	{
		get
		{
			return _numericUpDown.Minimum;
		}
		set
		{
			if (_numericUpDown.Minimum != value)
			{
				_service.OnComponentChanged(_numericUpDown, null, _numericUpDown.Minimum, value);
				_numericUpDown.Minimum = value;
			}
		}
	}

	public KryptonNumericUpDownActionList(KryptonNumericUpDownDesigner owner)
		: base(owner.Component)
	{
		_numericUpDown = owner.Component as KryptonNumericUpDown;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_numericUpDown != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("InputControlStyle", "Style", "Appearance", "NumericUpDown display style."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Data"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Increment", "Increment", "Data", "NumericUpDown increment value."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Maximum", "Maximum", "Data", "NumericUpDown maximum value."));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Minimum", "Minimum", "Data", "NumericUpDown minimum value."));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}
