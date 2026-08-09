using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfRegisteredServer", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RegisteredServer")]
[ComVisible(true)]
public class RegisteredServerCollection : List<RegisteredServer>, ICloneable
{
	public RegisteredServerCollection()
	{
	}

	public RegisteredServerCollection(int capacity)
		: base(capacity)
	{
	}

	public RegisteredServerCollection(IEnumerable<RegisteredServer> collection)
		: base(collection)
	{
	}

	public static implicit operator RegisteredServerCollection(RegisteredServer[] values)
	{
		if (values != null)
		{
			return new RegisteredServerCollection(values);
		}
		return new RegisteredServerCollection();
	}

	public static explicit operator RegisteredServer[](RegisteredServerCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (RegisteredServerCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisteredServerCollection registeredServerCollection = new RegisteredServerCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			registeredServerCollection.Add((RegisteredServer)Utils.Clone(base[i]));
		}
		return registeredServerCollection;
	}
}
