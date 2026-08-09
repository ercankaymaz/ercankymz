using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfLocalizedText", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "LocalizedText")]
[ComVisible(true)]
public class LocalizedTextCollection : List<LocalizedText>, ICloneable
{
	public LocalizedTextCollection()
	{
	}

	public LocalizedTextCollection(IEnumerable<LocalizedText> collection)
		: base(collection)
	{
	}

	public LocalizedTextCollection(int capacity)
		: base(capacity)
	{
	}

	public static LocalizedTextCollection ToLocalizedTextCollection(LocalizedText[] values)
	{
		if (values != null)
		{
			return new LocalizedTextCollection(values);
		}
		return new LocalizedTextCollection();
	}

	public static implicit operator LocalizedTextCollection(LocalizedText[] values)
	{
		return ToLocalizedTextCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		LocalizedTextCollection localizedTextCollection = new LocalizedTextCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			LocalizedText current = enumerator.Current;
			localizedTextCollection.Add((LocalizedText)Utils.Clone(current));
		}
		return localizedTextCollection;
	}
}
