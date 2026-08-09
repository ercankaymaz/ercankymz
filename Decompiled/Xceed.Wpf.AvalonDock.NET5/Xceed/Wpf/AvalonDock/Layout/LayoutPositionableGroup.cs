using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Xml;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public abstract class LayoutPositionableGroup<T> : LayoutGroup<T>, ILayoutPositionableElement, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutElementForFloatingWindow, ILayoutPositionableElementWithActualSize where T : class, ILayoutElement
{
	private static GridLengthConverter _gridLengthConverter = new GridLengthConverter();

	private GridLength _dockWidth = new GridLength(1.0, GridUnitType.Star);

	private GridLength _dockHeight = new GridLength(1.0, GridUnitType.Star);

	private bool _allowDuplicateContent = true;

	private bool _canRepositionItems = true;

	private double _dockMinWidth = 25.0;

	private double _dockMinHeight = 25.0;

	private double _floatingWidth;

	private double _floatingHeight;

	private double _floatingLeft;

	private double _floatingTop;

	private bool _isMaximized;

	[NonSerialized]
	private double _actualWidth;

	[NonSerialized]
	private double _actualHeight;

	public GridLength DockWidth
	{
		get
		{
			return _dockWidth;
		}
		set
		{
			if (DockWidth != value)
			{
				RaisePropertyChanging("DockWidth");
				_dockWidth = value;
				RaisePropertyChanged("DockWidth");
				OnDockWidthChanged();
			}
		}
	}

	public GridLength DockHeight
	{
		get
		{
			return _dockHeight;
		}
		set
		{
			if (DockHeight != value)
			{
				RaisePropertyChanging("DockHeight");
				_dockHeight = value;
				RaisePropertyChanged("DockHeight");
				OnDockHeightChanged();
			}
		}
	}

	public bool AllowDuplicateContent
	{
		get
		{
			return _allowDuplicateContent;
		}
		set
		{
			if (_allowDuplicateContent != value)
			{
				RaisePropertyChanging("AllowDuplicateContent");
				_allowDuplicateContent = value;
				RaisePropertyChanged("AllowDuplicateContent");
			}
		}
	}

	public bool CanRepositionItems
	{
		get
		{
			return _canRepositionItems;
		}
		set
		{
			if (_canRepositionItems != value)
			{
				RaisePropertyChanging("CanRepositionItems");
				_canRepositionItems = value;
				RaisePropertyChanged("CanRepositionItems");
			}
		}
	}

	public double DockMinWidth
	{
		get
		{
			return _dockMinWidth;
		}
		set
		{
			if (_dockMinWidth != value)
			{
				MathHelper.AssertIsPositiveOrZero(value);
				RaisePropertyChanging("DockMinWidth");
				_dockMinWidth = value;
				RaisePropertyChanged("DockMinWidth");
			}
		}
	}

	public double DockMinHeight
	{
		get
		{
			return _dockMinHeight;
		}
		set
		{
			if (_dockMinHeight != value)
			{
				MathHelper.AssertIsPositiveOrZero(value);
				RaisePropertyChanging("DockMinHeight");
				_dockMinHeight = value;
				RaisePropertyChanged("DockMinHeight");
			}
		}
	}

	public double FloatingWidth
	{
		get
		{
			return _floatingWidth;
		}
		set
		{
			if (_floatingWidth != value)
			{
				RaisePropertyChanging("FloatingWidth");
				_floatingWidth = value;
				RaisePropertyChanged("FloatingWidth");
			}
		}
	}

	public double FloatingHeight
	{
		get
		{
			return _floatingHeight;
		}
		set
		{
			if (_floatingHeight != value)
			{
				RaisePropertyChanging("FloatingHeight");
				_floatingHeight = value;
				RaisePropertyChanged("FloatingHeight");
			}
		}
	}

	public double FloatingLeft
	{
		get
		{
			return _floatingLeft;
		}
		set
		{
			if (_floatingLeft != value)
			{
				RaisePropertyChanging("FloatingLeft");
				_floatingLeft = value;
				RaisePropertyChanged("FloatingLeft");
			}
		}
	}

	public double FloatingTop
	{
		get
		{
			return _floatingTop;
		}
		set
		{
			if (_floatingTop != value)
			{
				RaisePropertyChanging("FloatingTop");
				_floatingTop = value;
				RaisePropertyChanged("FloatingTop");
			}
		}
	}

	public bool IsMaximized
	{
		get
		{
			return _isMaximized;
		}
		set
		{
			if (_isMaximized != value)
			{
				_isMaximized = value;
				RaisePropertyChanged("IsMaximized");
			}
		}
	}

	double ILayoutPositionableElementWithActualSize.ActualWidth
	{
		get
		{
			return _actualWidth;
		}
		set
		{
			_actualWidth = value;
		}
	}

	double ILayoutPositionableElementWithActualSize.ActualHeight
	{
		get
		{
			return _actualHeight;
		}
		set
		{
			_actualHeight = value;
		}
	}

	public LayoutPositionableGroup()
	{
	}

	public override void WriteXml(XmlWriter writer)
	{
		if (DockWidth.Value != 1.0 || !DockWidth.IsStar)
		{
			writer.WriteAttributeString("DockWidth", _gridLengthConverter.ConvertToInvariantString(DockWidth));
		}
		if (DockHeight.Value != 1.0 || !DockHeight.IsStar)
		{
			writer.WriteAttributeString("DockHeight", _gridLengthConverter.ConvertToInvariantString(DockHeight));
		}
		if (DockMinWidth != 25.0)
		{
			writer.WriteAttributeString("DockMinWidth", DockMinWidth.ToString(CultureInfo.InvariantCulture));
		}
		if (DockMinHeight != 25.0)
		{
			writer.WriteAttributeString("DockMinHeight", DockMinHeight.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingWidth != 0.0)
		{
			writer.WriteAttributeString("FloatingWidth", FloatingWidth.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingHeight != 0.0)
		{
			writer.WriteAttributeString("FloatingHeight", FloatingHeight.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingLeft != 0.0)
		{
			writer.WriteAttributeString("FloatingLeft", FloatingLeft.ToString(CultureInfo.InvariantCulture));
		}
		if (FloatingTop != 0.0)
		{
			writer.WriteAttributeString("FloatingTop", FloatingTop.ToString(CultureInfo.InvariantCulture));
		}
		if (IsMaximized)
		{
			writer.WriteAttributeString("IsMaximized", IsMaximized.ToString());
		}
		base.WriteXml(writer);
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("DockWidth"))
		{
			_dockWidth = (GridLength)_gridLengthConverter.ConvertFromInvariantString(reader.Value);
		}
		if (reader.MoveToAttribute("DockHeight"))
		{
			_dockHeight = (GridLength)_gridLengthConverter.ConvertFromInvariantString(reader.Value);
		}
		if (reader.MoveToAttribute("DockMinWidth"))
		{
			_dockMinWidth = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("DockMinHeight"))
		{
			_dockMinHeight = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingWidth"))
		{
			_floatingWidth = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingHeight"))
		{
			_floatingHeight = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingLeft"))
		{
			_floatingLeft = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("FloatingTop"))
		{
			_floatingTop = double.Parse(reader.Value, CultureInfo.InvariantCulture);
		}
		if (reader.MoveToAttribute("IsMaximized"))
		{
			_isMaximized = bool.Parse(reader.Value);
		}
		base.ReadXml(reader);
	}

	protected virtual void OnDockWidthChanged()
	{
	}

	protected virtual void OnDockHeightChanged()
	{
	}
}
