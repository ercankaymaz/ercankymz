using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSamplingIntervalDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SamplingIntervalDiagnosticsDataType")]
[ComVisible(true)]
public class SamplingIntervalDiagnosticsDataTypeCollection : List<SamplingIntervalDiagnosticsDataType>, ICloneable
{
	public SamplingIntervalDiagnosticsDataTypeCollection()
	{
	}

	public SamplingIntervalDiagnosticsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SamplingIntervalDiagnosticsDataTypeCollection(IEnumerable<SamplingIntervalDiagnosticsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SamplingIntervalDiagnosticsDataTypeCollection(SamplingIntervalDiagnosticsDataType[] values)
	{
		if (values != null)
		{
			return new SamplingIntervalDiagnosticsDataTypeCollection(values);
		}
		return new SamplingIntervalDiagnosticsDataTypeCollection();
	}

	public static explicit operator SamplingIntervalDiagnosticsDataType[](SamplingIntervalDiagnosticsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SamplingIntervalDiagnosticsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SamplingIntervalDiagnosticsDataTypeCollection samplingIntervalDiagnosticsDataTypeCollection = new SamplingIntervalDiagnosticsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			samplingIntervalDiagnosticsDataTypeCollection.Add((SamplingIntervalDiagnosticsDataType)Utils.Clone(base[i]));
		}
		return samplingIntervalDiagnosticsDataTypeCollection;
	}
}
