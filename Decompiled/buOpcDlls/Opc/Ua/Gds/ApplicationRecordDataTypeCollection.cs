using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Gds;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfApplicationRecordDataType", Namespace = "http://opcfoundation.org/UA/GDS/Types.xsd", ItemName = "ApplicationRecordDataType")]
[ComVisible(true)]
public class ApplicationRecordDataTypeCollection : List<ApplicationRecordDataType>, ICloneable
{
	public ApplicationRecordDataTypeCollection()
	{
	}

	public ApplicationRecordDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ApplicationRecordDataTypeCollection(IEnumerable<ApplicationRecordDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ApplicationRecordDataTypeCollection(ApplicationRecordDataType[] values)
	{
		if (values != null)
		{
			return new ApplicationRecordDataTypeCollection(values);
		}
		return new ApplicationRecordDataTypeCollection();
	}

	public static explicit operator ApplicationRecordDataType[](ApplicationRecordDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ApplicationRecordDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ApplicationRecordDataTypeCollection applicationRecordDataTypeCollection = new ApplicationRecordDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			applicationRecordDataTypeCollection.Add((ApplicationRecordDataType)Utils.Clone(base[i]));
		}
		return applicationRecordDataTypeCollection;
	}
}
