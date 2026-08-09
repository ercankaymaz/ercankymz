using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSessionSecurityDiagnosticsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SessionSecurityDiagnosticsDataType")]
[ComVisible(true)]
public class SessionSecurityDiagnosticsDataTypeCollection : List<SessionSecurityDiagnosticsDataType>, ICloneable
{
	public SessionSecurityDiagnosticsDataTypeCollection()
	{
	}

	public SessionSecurityDiagnosticsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SessionSecurityDiagnosticsDataTypeCollection(IEnumerable<SessionSecurityDiagnosticsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SessionSecurityDiagnosticsDataTypeCollection(SessionSecurityDiagnosticsDataType[] values)
	{
		if (values != null)
		{
			return new SessionSecurityDiagnosticsDataTypeCollection(values);
		}
		return new SessionSecurityDiagnosticsDataTypeCollection();
	}

	public static explicit operator SessionSecurityDiagnosticsDataType[](SessionSecurityDiagnosticsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SessionSecurityDiagnosticsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionSecurityDiagnosticsDataTypeCollection sessionSecurityDiagnosticsDataTypeCollection = new SessionSecurityDiagnosticsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			sessionSecurityDiagnosticsDataTypeCollection.Add((SessionSecurityDiagnosticsDataType)Utils.Clone(base[i]));
		}
		return sessionSecurityDiagnosticsDataTypeCollection;
	}
}
