using System;
using System.ComponentModel;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(MouseButtonConverter))]
public struct MouseButton
{
	[TypeConverter(typeof(EnumDescriptionConverter))]
	public mouseButtonsZPR Button { get; set; }

	[TypeConverter(typeof(EnumDescriptionConverter))]
	public modifierKeys ModifierKey { get; set; }

	public MouseButton(MouseButtons button, modifierKeys modifierKey)
	{
		this = default(MouseButton);
		Button = (mouseButtonsZPR)button;
		ModifierKey = modifierKey;
	}

	public MouseButton(mouseButtonsZPR button, modifierKeys modifierKey)
	{
		this = default(MouseButton);
		Button = button;
		ModifierKey = modifierKey;
	}

	public override string ToString()
	{
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587829), Button, EnumDescription.GetDescription(typeof(modifierKeys), ModifierKey.ToString()));
	}

	public static bool operator ==(MouseButton b1, MouseButton b2)
	{
		if (b1.Button == b2.Button)
		{
			return b1.ModifierKey == b2.ModifierKey;
		}
		return false;
	}

	public static bool operator !=(MouseButton b1, MouseButton b2)
	{
		return !(b1 == b2);
	}
}
