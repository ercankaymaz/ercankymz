using System;

namespace Xbim.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class InverseProperty : Attribute
{
	public string RemoteProperty { get; private set; }

	public InverseProperty(string remoteProperty)
	{
		RemoteProperty = remoteProperty;
	}
}
