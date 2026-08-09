using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTransferResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TransferResult")]
[ComVisible(true)]
public class TransferResultCollection : List<TransferResult>, ICloneable
{
	public TransferResultCollection()
	{
	}

	public TransferResultCollection(int capacity)
		: base(capacity)
	{
	}

	public TransferResultCollection(IEnumerable<TransferResult> collection)
		: base(collection)
	{
	}

	public static implicit operator TransferResultCollection(TransferResult[] values)
	{
		if (values != null)
		{
			return new TransferResultCollection(values);
		}
		return new TransferResultCollection();
	}

	public static explicit operator TransferResult[](TransferResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TransferResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TransferResultCollection transferResultCollection = new TransferResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			transferResultCollection.Add((TransferResult)Utils.Clone(base[i]));
		}
		return transferResultCollection;
	}
}
