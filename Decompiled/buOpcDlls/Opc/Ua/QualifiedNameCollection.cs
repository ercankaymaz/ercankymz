using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfQualifiedName", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "QualifiedName")]
[ComVisible(true)]
public class QualifiedNameCollection : List<QualifiedName>, ICloneable
{
	public QualifiedNameCollection()
	{
	}

	public QualifiedNameCollection(IEnumerable<QualifiedName> collection)
		: base(collection)
	{
	}

	public QualifiedNameCollection(int capacity)
		: base(capacity)
	{
	}

	public static QualifiedNameCollection ToQualifiedNameCollection(QualifiedName[] values)
	{
		if (values != null)
		{
			return new QualifiedNameCollection(values);
		}
		return new QualifiedNameCollection();
	}

	public static implicit operator QualifiedNameCollection(QualifiedName[] values)
	{
		return ToQualifiedNameCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			QualifiedName current = enumerator.Current;
			qualifiedNameCollection.Add((QualifiedName)Utils.Clone(current));
		}
		return qualifiedNameCollection;
	}
}
