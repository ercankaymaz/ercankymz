using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public sealed class ZoomboxViewConverter : TypeConverter
{
	private static ZoomboxViewConverter _converter;

	internal static ZoomboxViewConverter Converter
	{
		get
		{
			if (_converter == null)
			{
				_converter = new ZoomboxViewConverter();
			}
			return _converter;
		}
	}

	public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		if (!(type == typeof(string)) && !(type == typeof(double)) && !(type == typeof(Point)) && !(type == typeof(Rect)))
		{
			return base.CanConvertFrom(typeDescriptorContext, type);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type type)
	{
		if (!(type == typeof(string)))
		{
			return base.CanConvertTo(typeDescriptorContext, type);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		ZoomboxView zoomboxView = null;
		if (value is double)
		{
			zoomboxView = new ZoomboxView((double)value);
		}
		else if (value is Point)
		{
			zoomboxView = new ZoomboxView((Point)value);
		}
		else if (value is Rect)
		{
			zoomboxView = new ZoomboxView((Rect)value);
		}
		else if (value is string)
		{
			if (string.IsNullOrEmpty((value as string).Trim()))
			{
				zoomboxView = ZoomboxView.Empty;
			}
			else
			{
				switch ((value as string).Trim().ToLower())
				{
				case "center":
					zoomboxView = ZoomboxView.Center;
					break;
				case "empty":
					zoomboxView = ZoomboxView.Empty;
					break;
				case "fill":
					zoomboxView = ZoomboxView.Fill;
					break;
				case "fit":
					zoomboxView = ZoomboxView.Fit;
					break;
				default:
				{
					List<double> list = new List<double>();
					string[] array = (value as string).Split(new char[3] { ' ', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
					for (int i = 0; i < array.Length; i++)
					{
						if (double.TryParse(array[i], out var result))
						{
							list.Add(result);
						}
						if (list.Count >= 4)
						{
							break;
						}
					}
					switch (list.Count)
					{
					case 1:
						zoomboxView = new ZoomboxView(list[0]);
						break;
					case 2:
						zoomboxView = new ZoomboxView(list[0], list[1]);
						break;
					case 3:
						zoomboxView = new ZoomboxView(list[0], list[1], list[2]);
						break;
					case 4:
						zoomboxView = new ZoomboxView(list[0], list[1], list[2], list[3]);
						break;
					}
					break;
				}
				}
			}
		}
		if (!(zoomboxView == null))
		{
			return zoomboxView;
		}
		return base.ConvertFrom(typeDescriptorContext, cultureInfo, value);
	}

	public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		object obj = null;
		ZoomboxView zoomboxView = value as ZoomboxView;
		if (zoomboxView != null && destinationType == typeof(string))
		{
			obj = "Empty";
			switch (zoomboxView.ViewKind)
			{
			case ZoomboxViewKind.Absolute:
			{
				if (PointHelper.IsEmpty(zoomboxView.Position))
				{
					if (!DoubleHelper.IsNaN(zoomboxView.Scale))
					{
						obj = zoomboxView.Scale.ToString();
					}
					break;
				}
				Point position;
				if (DoubleHelper.IsNaN(zoomboxView.Scale))
				{
					position = zoomboxView.Position;
					string text = ((Point)(ref position)).X.ToString();
					position = zoomboxView.Position;
					obj = text + "," + ((Point)(ref position)).Y;
					break;
				}
				string[] obj2 = new string[5]
				{
					zoomboxView.Scale.ToString(),
					",",
					null,
					null,
					null
				};
				position = zoomboxView.Position;
				obj2[2] = ((Point)(ref position)).X.ToString();
				obj2[3] = ",";
				position = zoomboxView.Position;
				obj2[4] = ((Point)(ref position)).Y.ToString();
				obj = string.Concat(obj2);
				break;
			}
			case ZoomboxViewKind.Center:
				obj = "Center";
				break;
			case ZoomboxViewKind.Fill:
				obj = "Fill";
				break;
			case ZoomboxViewKind.Fit:
				obj = "Fit";
				break;
			case ZoomboxViewKind.Region:
			{
				string[] array = new string[7];
				Rect region = zoomboxView.Region;
				array[0] = ((Rect)(ref region)).X.ToString();
				array[1] = ",";
				region = zoomboxView.Region;
				array[2] = ((Rect)(ref region)).Y.ToString();
				array[3] = ",";
				region = zoomboxView.Region;
				array[4] = ((Rect)(ref region)).Width.ToString();
				array[5] = ",";
				region = zoomboxView.Region;
				array[6] = ((Rect)(ref region)).Height.ToString();
				obj = string.Concat(array);
				break;
			}
			}
		}
		if (obj != null)
		{
			return obj;
		}
		return base.ConvertTo(typeDescriptorContext, cultureInfo, value, destinationType);
	}
}
