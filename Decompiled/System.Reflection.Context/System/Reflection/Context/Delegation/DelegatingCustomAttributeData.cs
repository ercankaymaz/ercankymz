using System.Collections.Generic;

namespace System.Reflection.Context.Delegation;

internal class DelegatingCustomAttributeData : CustomAttributeData
{
	public CustomAttributeData UnderlyingAttribute { get; }

	public override ConstructorInfo Constructor => UnderlyingAttribute.Constructor;

	public override IList<CustomAttributeTypedArgument> ConstructorArguments => UnderlyingAttribute.ConstructorArguments;

	public override IList<CustomAttributeNamedArgument> NamedArguments => UnderlyingAttribute.NamedArguments;

	public DelegatingCustomAttributeData(CustomAttributeData attribute)
	{
		UnderlyingAttribute = attribute;
	}

	public override string ToString()
	{
		return UnderlyingAttribute.ToString();
	}
}
