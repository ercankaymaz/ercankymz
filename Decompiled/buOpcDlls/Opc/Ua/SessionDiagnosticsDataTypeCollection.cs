using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSessionDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SessionDiagnosticsDataType")]
[ComVisible(true)]
public class SessionDiagnosticsDataTypeCollection : List<SessionDiagnosticsDataType>, ICloneable
{
	public SessionDiagnosticsDataTypeCollection()
	{
	}

	public SessionDiagnosticsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SessionDiagnosticsDataTypeCollection(IEnumerable<SessionDiagnosticsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SessionDiagnosticsDataTypeCollection(SessionDiagnosticsDataType[] values)
	{
		if (values != null)
		{
			return new SessionDiagnosticsDataTypeCollection(values);
		}
		return new SessionDiagnosticsDataTypeCollection();
	}

	public static explicit operator SessionDiagnosticsDataType[](SessionDiagnosticsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SessionDiagnosticsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionDiagnosticsDataTypeCollection sessionDiagnosticsDataTypeCollection = new SessionDiagnosticsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			sessionDiagnosticsDataTypeCollection.Add((SessionDiagnosticsDataType)Utils.Clone(base[i]));
		}
		return sessionDiagnosticsDataTypeCollection;
	}
}
