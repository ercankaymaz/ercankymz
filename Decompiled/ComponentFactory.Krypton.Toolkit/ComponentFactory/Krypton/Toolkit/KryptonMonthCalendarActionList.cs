using System.ComponentModel.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonMonthCalendarActionList : DesignerActionList
{
	private KryptonMonthCalendar _monthCalendar;

	private IComponentChangeService _service;

	public PaletteMode PaletteMode
	{
		get
		{
			return _monthCalendar.PaletteMode;
		}
		set
		{
			if (_monthCalendar.PaletteMode != value)
			{
				_service.OnComponentChanged(_monthCalendar, null, _monthCalendar.PaletteMode, value);
				_monthCalendar.PaletteMode = value;
			}
		}
	}

	public int MaxSelectionCount
	{
		get
		{
			return _monthCalendar.MaxSelectionCount;
		}
		set
		{
			if (_monthCalendar.MaxSelectionCount != value)
			{
				_service.OnComponentChanged(_monthCalendar, null, _monthCalendar.MaxSelectionCount, value);
				_monthCalendar.MaxSelectionCount = value;
			}
		}
	}

	public bool ShowToday
	{
		get
		{
			return _monthCalendar.ShowToday;
		}
		set
		{
			if (_monthCalendar.ShowToday != value)
			{
				_service.OnComponentChanged(_monthCalendar, null, _monthCalendar.ShowToday, value);
				_monthCalendar.ShowToday = value;
			}
		}
	}

	public bool ShowTodayCircle
	{
		get
		{
			return _monthCalendar.ShowTodayCircle;
		}
		set
		{
			if (_monthCalendar.ShowTodayCircle != value)
			{
				_service.OnComponentChanged(_monthCalendar, null, _monthCalendar.ShowTodayCircle, value);
				_monthCalendar.ShowTodayCircle = value;
			}
		}
	}

	public bool ShowWeekNumbers
	{
		get
		{
			return _monthCalendar.ShowWeekNumbers;
		}
		set
		{
			if (_monthCalendar.ShowWeekNumbers != value)
			{
				_service.OnComponentChanged(_monthCalendar, null, _monthCalendar.ShowWeekNumbers, value);
				_monthCalendar.ShowWeekNumbers = value;
			}
		}
	}

	public KryptonMonthCalendarActionList(KryptonMonthCalendarDesigner owner)
		: base(owner.Component)
	{
		_monthCalendar = owner.Component as KryptonMonthCalendar;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_monthCalendar != null)
		{
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Behavior"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("MaxSelectionCount", "MaxSelectionCount", "Behavior", "Maximum number of selected days"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowToday", "ShowToday", "Behavior", "Show the today button"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowTodayCircle", "ShowTodayCircle", "Behavior", "Show a circle around the today entry"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowWeekNumbers", "ShowWeekNumbers", "Behavior", "Show the week numbers"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Visuals"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
		}
		return designerActionItemCollection;
	}
}
