using System.ComponentModel;
using System.Windows.Forms;
using ns25;

namespace ns24;

internal sealed class Class63 : CustomTypeDescriptor
{
	private ICustomTypeDescriptor icustomTypeDescriptor_0;

	private object object_0;

	public Class63(ICustomTypeDescriptor icustomTypeDescriptor_1, object object_1)
		: base(icustomTypeDescriptor_1)
	{
		icustomTypeDescriptor_0 = icustomTypeDescriptor_1;
		object_0 = object_1;
	}

	string CustomTypeDescriptor.GetComponentName()
	{
		return (object_0 is Control control) ? control.Name : null;
	}

	EventDescriptorCollection CustomTypeDescriptor.GetEvents()
	{
		EventDescriptorCollection events = base.GetEvents();
		EventDescriptor[] array = new EventDescriptor[events.Count];
		for (int i = 0; i < events.Count; i++)
		{
			if (!(events[i].Name == "TextChanged"))
			{
				array[i] = events[i];
			}
			else
			{
				array[i] = new Class64(events[i]);
			}
		}
		return new EventDescriptorCollection(array);
	}
}
