using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfStatusResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "StatusResult")]
[ComVisible(true)]
public class StatusResultCollection : List<StatusResult>, ICloneable
{
	public StatusResultCollection()
	{
	}

	public StatusResultCollection(int capacity)
		: base(capacity)
	{
	}

	public StatusResultCollection(IEnumerable<StatusResult> collection)
		: base(collection)
	{
	}

	public static implicit operator StatusResultCollection(StatusResult[] values)
	{
		if (values != null)
		{
			return new StatusResultCollection(values);
		}
		return new StatusResultCollection();
	}

	public static explicit operator StatusResult[](StatusResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (StatusResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StatusResultCollection statusResultCollection = new StatusResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			statusResultCollection.Add((StatusResult)Utils.Clone(base[i]));
		}
		return statusResultCollection;
	}
}
