using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class MagnifierAdorner : Adorner
{
	private Magnifier _magnifier;

	private Point _currentMousePosition;

	private double _currentZoomFactor;

	protected override int VisualChildrenCount => 1;

	public MagnifierAdorner(UIElement element, Magnifier magnifier)
		: base(element)
	{
		_magnifier = magnifier;
		_currentZoomFactor = _magnifier.ZoomFactor;
		UpdateViewBox();
		AddVisualChild(_magnifier);
		base.Loaded += delegate
		{
			InputManager.Current.PostProcessInput += OnProcessInput;
		};
		base.Unloaded += delegate
		{
			InputManager.Current.PostProcessInput -= OnProcessInput;
		};
	}

	private void OnProcessInput(object sender, ProcessInputEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition(this);
		if ((!(_currentMousePosition == position) || _magnifier.ZoomFactor != _currentZoomFactor) && !_magnifier.IsFrozen)
		{
			_currentMousePosition = position;
			_currentZoomFactor = _magnifier.ZoomFactor;
			UpdateViewBox();
			InvalidateArrange();
		}
	}

	internal void UpdateViewBox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Point val = CalculateViewBoxLocation();
		Magnifier magnifier = _magnifier;
		Rect viewBox = _magnifier.ViewBox;
		magnifier.ViewBox = new Rect(val, ((Rect)(ref viewBox)).Size);
	}

	private Point CalculateViewBoxLocation()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		Point position = Mouse.GetPosition(this);
		Point position2 = Mouse.GetPosition(base.AdornedElement);
		num = ((Point)(ref position2)).X - ((Point)(ref position)).X;
		num2 = ((Point)(ref position2)).Y - ((Point)(ref position)).Y;
		Vector offset = VisualTreeHelper.GetOffset(_magnifier.Target);
		Point val = default(Point);
		((Point)(ref val))._002Ector(((Vector)(ref offset)).X, ((Vector)(ref offset)).Y);
		double x = ((Point)(ref _currentMousePosition)).X;
		Rect viewBox = _magnifier.ViewBox;
		double num3 = x - (((Rect)(ref viewBox)).Width / 2.0 + num) + ((Point)(ref val)).X;
		double y = ((Point)(ref _currentMousePosition)).Y;
		viewBox = _magnifier.ViewBox;
		double num4 = y - (((Rect)(ref viewBox)).Height / 2.0 + num2) + ((Point)(ref val)).Y;
		return new Point(num3, num4);
	}

	protected override Visual GetVisualChild(int index)
	{
		return _magnifier;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_magnifier.Measure(constraint);
		return base.MeasureOverride(constraint);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		double num = ((Point)(ref _currentMousePosition)).X - _magnifier.Width / 2.0;
		double num2 = ((Point)(ref _currentMousePosition)).Y - _magnifier.Height / 2.0;
		_magnifier.Arrange(new Rect(num, num2, _magnifier.Width, _magnifier.Height));
		return base.ArrangeOverride(finalSize);
	}
}
