using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfExtensionObject", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ExtensionObject")]
[ComVisible(true)]
public class ExtensionObjectCollection : List<ExtensionObject>, ICloneable
{
	public ExtensionObjectCollection()
	{
	}

	public ExtensionObjectCollection(IEnumerable<ExtensionObject> collection)
		: base(collection)
	{
	}

	public ExtensionObjectCollection(int capacity)
		: base(capacity)
	{
	}

	public static implicit operator ExtensionObjectCollection(ExtensionObject[] values)
	{
		if (values != null)
		{
			return new ExtensionObjectCollection(values);
		}
		return new ExtensionObjectCollection();
	}

	public static ExtensionObjectCollection ToExtensionObjects(IEnumerable<IEncodeable> encodeables)
	{
		if (encodeables == null)
		{
			return null;
		}
		ExtensionObjectCollection extensionObjectCollection = new ExtensionObjectCollection();
		if (encodeables != null)
		{
			foreach (IEncodeable encodeable in encodeables)
			{
				if (encodeable is ExtensionObject item)
				{
					extensionObjectCollection.Add(item);
				}
				else
				{
					extensionObjectCollection.Add(new ExtensionObject(encodeable));
				}
			}
		}
		return extensionObjectCollection;
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ExtensionObjectCollection extensionObjectCollection = new ExtensionObjectCollection(base.Count);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ExtensionObject current = enumerator.Current;
			extensionObjectCollection.Add((ExtensionObject)Utils.Clone(current));
		}
		return extensionObjectCollection;
	}
}
