using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class PlaneConverter : ExpandableObjectConverter
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
		if (value is Plane && destinationType == typeof(InstanceDescriptor))
		{
			Plane plane = (Plane)value;
			object[] array = new object[3];
			Type[] array2 = new Type[3];
			int num = 0;
			array2[num] = typeof(Point3D);
			array[num++] = plane.Origin;
			array2[num] = typeof(Vector3D);
			array[num++] = plane.AxisX;
			array2[num] = typeof(Vector3D);
			array[num++] = plane.AxisY;
			return new InstanceDescriptor(typeof(Plane).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new Plane((Point3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951300)], (Vector3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658003)], (Vector3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658015)]);
	}
}
