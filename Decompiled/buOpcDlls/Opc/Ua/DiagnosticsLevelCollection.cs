using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDiagnosticsLevel", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DiagnosticsLevel")]
[ComVisible(true)]
public class DiagnosticsLevelCollection : List<DiagnosticsLevel>, ICloneable
{
	public DiagnosticsLevelCollection()
	{
	}

	public DiagnosticsLevelCollection(int capacity)
		: base(capacity)
	{
	}

	public DiagnosticsLevelCollection(IEnumerable<DiagnosticsLevel> collection)
		: base(collection)
	{
	}

	public static implicit operator DiagnosticsLevelCollection(DiagnosticsLevel[] values)
	{
		if (values != null)
		{
			return new DiagnosticsLevelCollection(values);
		}
		return new DiagnosticsLevelCollection();
	}

	public static explicit operator DiagnosticsLevel[](DiagnosticsLevelCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DiagnosticsLevelCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DiagnosticsLevelCollection diagnosticsLevelCollection = new DiagnosticsLevelCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			diagnosticsLevelCollection.Add((DiagnosticsLevel)Utils.Clone(base[i]));
		}
		return diagnosticsLevelCollection;
	}
}
