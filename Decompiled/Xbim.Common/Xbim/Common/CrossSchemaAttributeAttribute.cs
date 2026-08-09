using System;

namespace Xbim.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class CrossSchemaAttributeAttribute : Attribute
{
	public Type ForType { get; private set; }

	public int Order { get; private set; }

	public CrossSchemaAttributeAttribute(Type forType, int order)
	{
		ForType = forType;
		Order = order;
	}
}
