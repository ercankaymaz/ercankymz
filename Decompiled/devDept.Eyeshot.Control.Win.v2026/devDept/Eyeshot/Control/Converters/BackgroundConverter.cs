using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Graphics;

namespace devDept.Eyeshot.Control.Converters;

public class BackgroundConverter : ExpandableObjectConverter
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
		if (value is BackgroundSettings && destinationType == typeof(InstanceDescriptor))
		{
			BackgroundSettings backgroundSettings = (BackgroundSettings)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8]
			{
				typeof(backgroundStyleType),
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			array[0] = backgroundSettings.StyleMode;
			array2[1] = typeof(Color);
			array[1] = backgroundSettings.BottomColor;
			array2[2] = typeof(Color);
			array[2] = backgroundSettings.IntermediateColor;
			array2[3] = typeof(Color);
			array[3] = backgroundSettings.TopColor;
			array2[4] = typeof(double);
			array[4] = backgroundSettings.IntermediateColorPosition;
			array2[5] = typeof(Image);
			array[5] = backgroundSettings.Image;
			array2[6] = typeof(colorThemeType);
			array[6] = backgroundSettings.ColorTheme;
			array2[7] = typeof(double);
			array[7] = backgroundSettings.ColorThemeTransparency;
			return new InstanceDescriptor(typeof(BackgroundSettings).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new BackgroundSettings((backgroundStyleType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650632)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650648)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650662)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650702)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650719)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650751)], (colorThemeType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650739)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650498)]);
	}
}
