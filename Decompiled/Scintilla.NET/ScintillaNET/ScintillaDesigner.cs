using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms.Design;

namespace ScintillaNET;

internal class ScintillaDesigner : ControlDesigner
{
	protected override void PreFilterProperties(IDictionary properties)
	{
		base.PreFilterProperties(properties);
		PropertyDescriptor propertyDescriptor = (PropertyDescriptor)properties["ScrollWidthTracking"];
		propertyDescriptor = (PropertyDescriptor)(properties["ScrollWidthTracking"] = TypeDescriptor.CreateProperty(propertyDescriptor.ComponentType, propertyDescriptor, propertyDescriptor.Attributes.Cast<Attribute>().Concat(new _003C_003Ez__ReadOnlySingleElementList<Attribute>(new RefreshPropertiesAttribute(RefreshProperties.All))).ToArray()));
		PropertyDescriptor propertyDescriptor3 = (PropertyDescriptor)properties["ScrollWidth"];
		if ((bool)propertyDescriptor.GetValue(base.Component))
		{
			propertyDescriptor3 = TypeDescriptor.CreateProperty(propertyDescriptor3.ComponentType, propertyDescriptor3, propertyDescriptor3.Attributes.Cast<Attribute>().Concat(new _003C_003Ez__ReadOnlyArray<Attribute>(new Attribute[2]
			{
				new BrowsableAttribute(browsable: false),
				new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)
			})).ToArray());
			properties["ScrollWidth"] = propertyDescriptor3;
		}
	}
}
