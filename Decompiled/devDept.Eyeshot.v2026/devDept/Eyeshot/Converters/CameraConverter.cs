using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Converters;

public class CameraConverter : ExpandableObjectConverter
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
		if (value is Camera && destinationType == typeof(InstanceDescriptor))
		{
			Camera camera = (Camera)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8]
			{
				typeof(Point3D),
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			array[0] = camera.Target;
			array2[1] = typeof(double);
			array[1] = camera.Distance;
			array2[2] = typeof(Quaternion);
			array[2] = camera.Rotation;
			array2[3] = typeof(projectionType);
			array[3] = camera.ProjectionMode;
			array2[4] = typeof(double);
			array[4] = camera.FocalLength;
			array2[5] = typeof(double);
			array[5] = camera.ZoomFactor;
			array2[6] = typeof(bool);
			array[6] = camera.Anaglyph3D;
			array2[7] = typeof(double);
			array[7] = camera.NearPlaneDistanceFactor;
			return new InstanceDescriptor(typeof(Camera).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new Camera((Point3D)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952439)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952422)], (Quaternion)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952403)], (projectionType)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952378)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952365)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952351)], (bool)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952050)], (double)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952033)]);
	}
}
