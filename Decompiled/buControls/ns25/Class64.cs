using System;
using System.ComponentModel;
using buMutliTextbox;

namespace ns25;

internal sealed class Class64 : EventDescriptor
{
	Type EventDescriptor.ComponentType => typeof(buMultiTextBox);

	Type EventDescriptor.EventType => typeof(EventHandler);

	bool EventDescriptor.IsMulticast => true;

	public Class64(MemberDescriptor memberDescriptor_0)
		: base(memberDescriptor_0)
	{
	}

	void EventDescriptor.AddEventHandler(object component, Delegate value)
	{
		(component as buMultiTextBox).method_0(value as EventHandler);
	}

	void EventDescriptor.RemoveEventHandler(object component, Delegate value)
	{
		(component as buMultiTextBox).method_1(value as EventHandler);
	}
}
