using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit;

public sealed class DateElement : IComparable<DateElement>
{
	internal Rect PlacementRectangle;

	private readonly int _originalIndex;

	private readonly DateTime _date;

	private readonly DateTime _dateEnd;

	private readonly UIElement _element;

	public DateTime Date => _date;

	public DateTime DateEnd => _dateEnd;

	public UIElement Element => _element;

	internal DateElement(UIElement element, DateTime date, DateTime dateEnd)
		: this(element, date, dateEnd, -1)
	{
	}

	internal DateElement(UIElement element, DateTime date, DateTime dateEnd, int originalIndex)
	{
		_element = element;
		_date = date;
		_dateEnd = dateEnd;
		_originalIndex = originalIndex;
	}

	public override string ToString()
	{
		if (!(Element is FrameworkElement frameworkElement))
		{
			return base.ToString();
		}
		if (frameworkElement.Tag != null)
		{
			return frameworkElement.Tag.ToString();
		}
		return frameworkElement.Name;
	}

	public int CompareTo(DateElement d)
	{
		int num = Date.CompareTo(d.Date);
		if (num != 0)
		{
			return num;
		}
		if (_originalIndex >= 0)
		{
			if (_originalIndex >= d._originalIndex)
			{
				return 1;
			}
			return -1;
		}
		return -DateEnd.CompareTo(d.DateEnd);
	}
}
