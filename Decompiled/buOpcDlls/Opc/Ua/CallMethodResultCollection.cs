using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfCallMethodResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CallMethodResult")]
[ComVisible(true)]
public class CallMethodResultCollection : List<CallMethodResult>, ICloneable
{
	public CallMethodResultCollection()
	{
	}

	public CallMethodResultCollection(int capacity)
		: base(capacity)
	{
	}

	public CallMethodResultCollection(IEnumerable<CallMethodResult> collection)
		: base(collection)
	{
	}

	public static implicit operator CallMethodResultCollection(CallMethodResult[] values)
	{
		if (values != null)
		{
			return new CallMethodResultCollection(values);
		}
		return new CallMethodResultCollection();
	}

	public static explicit operator CallMethodResult[](CallMethodResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (CallMethodResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CallMethodResultCollection callMethodResultCollection = new CallMethodResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			callMethodResultCollection.Add((CallMethodResult)Utils.Clone(base[i]));
		}
		return callMethodResultCollection;
	}
}
