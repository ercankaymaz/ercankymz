using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class SimulationTimeLineConverter : ExpandableObjectConverter
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
		if (value is SimulationTimeLine && destinationType == typeof(InstanceDescriptor))
		{
			SimulationTimeLine simulationTimeLine = (SimulationTimeLine)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8];
			int num = 0;
			array2[num] = typeof(Color);
			array[num++] = simulationTimeLine.ThumbColor;
			array2[num] = typeof(Color);
			array[num++] = simulationTimeLine.HoveringColor;
			array2[num] = typeof(Color);
			array[num++] = simulationTimeLine.Color;
			array2[num] = typeof(Color);
			array[num++] = simulationTimeLine.CollisionColor;
			array2[num] = typeof(Color);
			array[num++] = simulationTimeLine.RapidColor;
			array2[num] = typeof(double);
			array[num++] = simulationTimeLine.DrawScale;
			array2[num] = typeof(bool);
			array[num++] = simulationTimeLine.Visible;
			array2[num] = typeof(double);
			array[num++] = simulationTimeLine.ThicknessFactor;
			return new InstanceDescriptor(typeof(SimulationTimeLine).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new SimulationTimeLine((Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588157)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588428)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588440)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588451)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588804)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588820)]);
	}
}
