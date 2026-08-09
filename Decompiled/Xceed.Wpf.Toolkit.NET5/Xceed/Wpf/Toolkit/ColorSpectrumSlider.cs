using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_SpectrumDisplay", Type = typeof(Rectangle))]
public class ColorSpectrumSlider : Slider
{
	private const string PART_SpectrumDisplay = "PART_SpectrumDisplay";

	private Rectangle _spectrumDisplay;

	private LinearGradientBrush _pickerBrush;

	public static readonly DependencyProperty SelectedColorProperty;

	public Color SelectedColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(SelectedColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedColorProperty, (object)value);
		}
	}

	static ColorSpectrumSlider()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color), typeof(ColorSpectrumSlider), new PropertyMetadata((object)Colors.Transparent));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSpectrumSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ColorSpectrumSlider)));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_spectrumDisplay = (Rectangle)(object)GetTemplateChild("PART_SpectrumDisplay");
		CreateSpectrum();
		OnValueChanged(double.NaN, base.Value);
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		Color selectedColor = ColorUtilities.ConvertHsvToRgb(360.0 - newValue, 1.0, 1.0);
		SelectedColor = selectedColor;
	}

	private void CreateSpectrum()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		_pickerBrush = new LinearGradientBrush();
		_pickerBrush.StartPoint = new Point(0.5, 0.0);
		_pickerBrush.EndPoint = new Point(0.5, 1.0);
		_pickerBrush.ColorInterpolationMode = ColorInterpolationMode.SRgbLinearInterpolation;
		List<Color> list = ColorUtilities.GenerateHsvSpectrum();
		double num = 1.0 / (double)(list.Count - 1);
		int i;
		for (i = 0; i < list.Count; i++)
		{
			_pickerBrush.GradientStops.Add(new GradientStop(list[i], (double)i * num));
		}
		_pickerBrush.GradientStops[i - 1].Offset = 1.0;
		if (_spectrumDisplay != null)
		{
			_spectrumDisplay.Fill = _pickerBrush;
		}
	}
}
