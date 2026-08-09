using System;
using System.ComponentModel;

namespace devDept.Eyeshot.Control.Converters;

public abstract class MovementConverterBase : ExpandableObjectConverter
{
	protected void GetTypesAndProperties(MovementSettingsBase settings, Type[] types, object[] properties)
	{
		types[0] = typeof(MouseButton);
		properties[0] = settings.MouseButton;
		types[1] = typeof(int);
		properties[1] = settings.KeysStep;
		types[2] = typeof(bool);
		properties[2] = settings.Enabled;
	}
}
