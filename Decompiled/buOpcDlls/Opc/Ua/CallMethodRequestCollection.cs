using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfCallMethodRequest", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CallMethodRequest")]
[ComVisible(true)]
public class CallMethodRequestCollection : List<CallMethodRequest>, ICloneable
{
	public CallMethodRequestCollection()
	{
	}

	public CallMethodRequestCollection(int capacity)
		: base(capacity)
	{
	}

	public CallMethodRequestCollection(IEnumerable<CallMethodRequest> collection)
		: base(collection)
	{
	}

	public static implicit operator CallMethodRequestCollection(CallMethodRequest[] values)
	{
		if (values != null)
		{
			return new CallMethodRequestCollection(values);
		}
		return new CallMethodRequestCollection();
	}

	public static explicit operator CallMethodRequest[](CallMethodRequestCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (CallMethodRequestCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CallMethodRequestCollection callMethodRequestCollection = new CallMethodRequestCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			callMethodRequestCollection.Add((CallMethodRequest)Utils.Clone(base[i]));
		}
		return callMethodRequestCollection;
	}
}
