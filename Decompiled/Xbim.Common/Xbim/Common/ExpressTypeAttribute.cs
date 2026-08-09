using System;

namespace Xbim.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
public sealed class ExpressTypeAttribute : Attribute
{
	public string Name { get; private set; }

	public int EntityTypeId { get; private set; }

	public ExpressTypeAttribute(string name, int id)
	{
		Name = name;
		EntityTypeId = id;
	}
}
