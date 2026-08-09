using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Converters;

public class LightConverter : ExpandableObjectConverter
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
		if (value is LightSettings && destinationType == typeof(InstanceDescriptor))
		{
			LightSettings lightSettings = (LightSettings)value;
			object[] array = new object[13];
			Type[] array2 = new Type[13];
			int num = 0;
			array2[num] = typeof(Vector3D);
			array[num++] = lightSettings.Direction;
			array2[num] = typeof(Color);
			array[num++] = lightSettings.Color;
			array2[num] = typeof(Color);
			array[num++] = lightSettings.Specular;
			array2[num] = typeof(bool);
			array[num++] = lightSettings.Stationary;
			array2[num] = typeof(bool);
			array[num++] = lightSettings.Active;
			array2[num] = typeof(bool);
			array[num++] = lightSettings.YieldShadow;
			array2[num] = typeof(lightType);
			array[num++] = lightSettings.Type;
			array2[num] = typeof(Point3D);
			array[num++] = lightSettings.Position;
			array2[num] = typeof(double);
			array[num++] = lightSettings.SpotHalfAngle;
			array2[num] = typeof(double);
			array[num++] = lightSettings.SpotExponent;
			array2[num] = typeof(double);
			array[num++] = lightSettings.ConstantAttenuation;
			array2[num] = typeof(double);
			array[num++] = lightSettings.LinearAttenuation;
			array2[num] = typeof(double);
			array[num++] = lightSettings.QuadraticAttenuation;
			return new InstanceDescriptor(typeof(LightSettings).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new LightSettings((Vector3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953730)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953970)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953983)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953824)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953938)], (lightType)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953924)], (Point3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953933)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953918)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953874)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953859)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953597)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953557)]);
	}
}
