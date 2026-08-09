using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfDiagnosticInfo", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DiagnosticInfo")]
[ComVisible(true)]
public class DiagnosticInfoCollection : List<DiagnosticInfo>, ICloneable
{
	public DiagnosticInfoCollection()
	{
	}

	public DiagnosticInfoCollection(IEnumerable<DiagnosticInfo> collection)
		: base(collection)
	{
	}

	public DiagnosticInfoCollection(int capacity)
		: base(capacity)
	{
	}

	public static DiagnosticInfoCollection ToDiagnosticInfoCollection(DiagnosticInfo[] values)
	{
		if (values != null)
		{
			return new DiagnosticInfoCollection(values);
		}
		return new DiagnosticInfoCollection();
	}

	public static implicit operator DiagnosticInfoCollection(DiagnosticInfo[] values)
	{
		return ToDiagnosticInfoCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DiagnosticInfoCollection diagnosticInfoCollection = new DiagnosticInfoCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DiagnosticInfo current = enumerator.Current;
			diagnosticInfoCollection.Add((DiagnosticInfo)Utils.Clone(current));
		}
		return diagnosticInfoCollection;
	}
}
