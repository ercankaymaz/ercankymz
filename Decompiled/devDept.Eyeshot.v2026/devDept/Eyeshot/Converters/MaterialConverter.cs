using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Converters;

public class MaterialConverter : ExpandableObjectConverter
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
		if (value is Material && destinationType == typeof(InstanceDescriptor))
		{
			Material material = (Material)value;
			object[] array = new object[6];
			Type[] array2 = new Type[6];
			int num = 0;
			array2[num] = typeof(string);
			array[num++] = material.Name;
			array2[num] = typeof(Color);
			array[num++] = material.Ambient;
			array2[num] = typeof(Color);
			array[num++] = material.Diffuse;
			array2[num] = typeof(Color);
			array[num++] = material.Specular;
			array2[num] = typeof(float);
			array[num++] = material.Shininess;
			array2[num] = typeof(float);
			array[num++] = material.Environment;
			return new InstanceDescriptor(typeof(Material).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new Material((string)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953522)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953536)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953970)], (float)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953518)], (float)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953502)]);
	}
}
