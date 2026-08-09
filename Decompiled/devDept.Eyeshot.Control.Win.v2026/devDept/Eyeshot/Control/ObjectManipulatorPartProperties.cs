using System;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(ObjectManipulatorPartPropertiesConverter))]
public class ObjectManipulatorPartProperties
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color Color { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Selectable { get; set; }

	public ObjectManipulatorPartProperties(Color color, bool visible, bool selectable)
	{
		Color = color;
		Visible = visible;
		Selectable = selectable;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is ObjectManipulatorPartProperties objectManipulatorPartProperties))
		{
			return false;
		}
		if (Visible == objectManipulatorPartProperties.Visible && Color == objectManipulatorPartProperties.Color)
		{
			return Selectable == objectManipulatorPartProperties.Selectable;
		}
		return false;
	}
}
