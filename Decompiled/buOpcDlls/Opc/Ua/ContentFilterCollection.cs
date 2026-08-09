using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfContentFilter", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilter")]
[ComVisible(true)]
public class ContentFilterCollection : List<ContentFilter>, ICloneable
{
	public ContentFilterCollection()
	{
	}

	public ContentFilterCollection(int capacity)
		: base(capacity)
	{
	}

	public ContentFilterCollection(IEnumerable<ContentFilter> collection)
		: base(collection)
	{
	}

	public static implicit operator ContentFilterCollection(ContentFilter[] values)
	{
		if (values != null)
		{
			return new ContentFilterCollection(values);
		}
		return new ContentFilterCollection();
	}

	public static explicit operator ContentFilter[](ContentFilterCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ContentFilterCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterCollection contentFilterCollection = new ContentFilterCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			contentFilterCollection.Add((ContentFilter)Utils.Clone(base[i]));
		}
		return contentFilterCollection;
	}
}
