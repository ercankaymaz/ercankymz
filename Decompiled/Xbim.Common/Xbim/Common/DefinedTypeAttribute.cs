using System;

namespace Xbim.Common;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DefinedTypeAttribute : Attribute
{
	public Type UnderlyingType { get; private set; }

	public DefinedTypeAttribute(Type underlyingType)
	{
		UnderlyingType = underlyingType;
	}
}
