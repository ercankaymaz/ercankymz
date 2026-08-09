using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Converters;

public class ClippingPlaneConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is ClippingPlane && destinationType == typeof(InstanceDescriptor))
		{
			ClippingPlane clippingPlane = (ClippingPlane)value;
			object[] array = new object[6];
			Type[] array2 = new Type[6]
			{
				typeof(Vector3D),
				null,
				null,
				null,
				null,
				null
			};
			array[0] = clippingPlane.Normal;
			array2[1] = typeof(double);
			array[1] = clippingPlane.Distance;
			array2[2] = typeof(bool);
			array[2] = clippingPlane.Active;
			array2[3] = typeof(Color);
			array[3] = clippingPlane.CappingColor;
			array2[4] = typeof(bool);
			array[4] = clippingPlane.ShowPlane;
			array2[5] = typeof(ClippingPlane.cappingType);
			array[5] = clippingPlane.CappingMode;
			return new InstanceDescriptor(typeof(ClippingPlane).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ClippingPlane((Vector3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953809)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952422)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953824)], (ClippingPlane.cappingType)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953803)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953789)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953746)]);
	}
}
