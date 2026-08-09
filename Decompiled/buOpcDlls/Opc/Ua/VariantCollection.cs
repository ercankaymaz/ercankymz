using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfVariant", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Variant")]
[ComVisible(true)]
public class VariantCollection : List<Variant>, ICloneable
{
	public VariantCollection()
	{
	}

	public VariantCollection(IEnumerable<Variant> collection)
		: base(collection)
	{
	}

	public VariantCollection(int capacity)
		: base(capacity)
	{
	}

	public static VariantCollection ToVariantCollection(Variant[] values)
	{
		if (values != null)
		{
			return new VariantCollection(values);
		}
		return new VariantCollection();
	}

	public static implicit operator VariantCollection(Variant[] values)
	{
		return ToVariantCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VariantCollection variantCollection = new VariantCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Variant current = enumerator.Current;
			variantCollection.Add((Variant)Utils.Clone(current));
		}
		return variantCollection;
	}
}
