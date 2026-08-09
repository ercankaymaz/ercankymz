using System;
using System.ComponentModel;
using ns24;
using ns27;

namespace ns23;

internal sealed class Class62 : TypeDescriptionProvider
{
	public Class62(Type type_0)
		: base(Class76.smethod_821(type_0))
	{
	}

	ICustomTypeDescriptor TypeDescriptionProvider.GetTypeDescriptor(Type objectType, object instance)
	{
		ICustomTypeDescriptor typeDescriptor = base.GetTypeDescriptor(objectType, instance);
		return new Class63(typeDescriptor, instance);
	}
}
