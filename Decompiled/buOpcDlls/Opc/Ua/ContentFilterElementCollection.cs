using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfContentFilterElement", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilterElement")]
[ComVisible(true)]
public class ContentFilterElementCollection : List<ContentFilterElement>, ICloneable
{
	public ContentFilterElementCollection()
	{
	}

	public ContentFilterElementCollection(int capacity)
		: base(capacity)
	{
	}

	public ContentFilterElementCollection(IEnumerable<ContentFilterElement> collection)
		: base(collection)
	{
	}

	public static implicit operator ContentFilterElementCollection(ContentFilterElement[] values)
	{
		if (values != null)
		{
			return new ContentFilterElementCollection(values);
		}
		return new ContentFilterElementCollection();
	}

	public static explicit operator ContentFilterElement[](ContentFilterElementCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ContentFilterElementCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterElementCollection contentFilterElementCollection = new ContentFilterElementCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			contentFilterElementCollection.Add((ContentFilterElement)Utils.Clone(base[i]));
		}
		return contentFilterElementCollection;
	}
}
