using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Windows.Forms;

namespace devDept.Eyeshot.Control.Converters;

public class ShortcutKeysSettingsConverter : ExpandableObjectConverter
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
		if (value is ShortcutKeysSettings && destinationType == typeof(InstanceDescriptor))
		{
			ShortcutKeysSettings obj = (ShortcutKeysSettings)value;
			object[] array = new object[26];
			Type[] types = new Type[26];
			GetTypesAndProperties(obj, 0, types, array);
			return new InstanceDescriptor(typeof(ShortcutKeysSettings).GetConstructor(types), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	protected static void GetTypesAndProperties(ShortcutKeysSettings obj, int startIndex, Type[] types, object[] properties)
	{
		int num = startIndex;
		types[num] = typeof(Keys);
		properties[num++] = obj.SelectAll;
		types[num] = typeof(Keys);
		properties[num++] = obj.InvertSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.DeleteSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.ZoomFit;
		types[num] = typeof(Keys);
		properties[num++] = obj.ZoomIn;
		types[num] = typeof(Keys);
		properties[num++] = obj.ZoomOut;
		types[num] = typeof(Keys);
		properties[num++] = obj.CopySelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.PasteSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.CutSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.GroupSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.UngroupSelection;
		types[num] = typeof(Keys);
		properties[num++] = obj.RotateRight;
		types[num] = typeof(Keys);
		properties[num++] = obj.RotateUp;
		types[num] = typeof(Keys);
		properties[num++] = obj.RotateLeft;
		types[num] = typeof(Keys);
		properties[num++] = obj.RotateDown;
		types[num] = typeof(Keys);
		properties[num++] = obj.PanRight;
		types[num] = typeof(Keys);
		properties[num++] = obj.PanUp;
		types[num] = typeof(Keys);
		properties[num++] = obj.PanLeft;
		types[num] = typeof(Keys);
		properties[num++] = obj.PanDown;
		types[num] = typeof(Keys);
		properties[num++] = obj.CancelBackgroundWork;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationRight;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationLeft;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationUp;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationDown;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationForward;
		types[num] = typeof(Keys);
		properties[num++] = obj.NavigationBackward;
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ShortcutKeysSettings((Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649408)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649424)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649466)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649220)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649238)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649257)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649275)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649287)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649298)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649343)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648586)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648595)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648609)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648626)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648641)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648656)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648673)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648693)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648455)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648473)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648510)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648520)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648531)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648544)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648843)], (Keys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648851)]);
	}
}
