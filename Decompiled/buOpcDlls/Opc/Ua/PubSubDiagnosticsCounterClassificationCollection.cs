using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPubSubDiagnosticsCounterClassification", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubDiagnosticsCounterClassification")]
[ComVisible(true)]
public class PubSubDiagnosticsCounterClassificationCollection : List<PubSubDiagnosticsCounterClassification>, ICloneable
{
	public PubSubDiagnosticsCounterClassificationCollection()
	{
	}

	public PubSubDiagnosticsCounterClassificationCollection(int capacity)
		: base(capacity)
	{
	}

	public PubSubDiagnosticsCounterClassificationCollection(IEnumerable<PubSubDiagnosticsCounterClassification> collection)
		: base(collection)
	{
	}

	public static implicit operator PubSubDiagnosticsCounterClassificationCollection(PubSubDiagnosticsCounterClassification[] values)
	{
		if (values != null)
		{
			return new PubSubDiagnosticsCounterClassificationCollection(values);
		}
		return new PubSubDiagnosticsCounterClassificationCollection();
	}

	public static explicit operator PubSubDiagnosticsCounterClassification[](PubSubDiagnosticsCounterClassificationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PubSubDiagnosticsCounterClassificationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubDiagnosticsCounterClassificationCollection pubSubDiagnosticsCounterClassificationCollection = new PubSubDiagnosticsCounterClassificationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			pubSubDiagnosticsCounterClassificationCollection.Add((PubSubDiagnosticsCounterClassification)Utils.Clone(base[i]));
		}
		return pubSubDiagnosticsCounterClassificationCollection;
	}
}
