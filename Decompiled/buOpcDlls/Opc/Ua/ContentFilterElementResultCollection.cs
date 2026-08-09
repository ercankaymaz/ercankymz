using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfContentFilterElementResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ContentFilterElementResult")]
[ComVisible(true)]
public class ContentFilterElementResultCollection : List<ContentFilterElementResult>, ICloneable
{
	public ContentFilterElementResultCollection()
	{
	}

	public ContentFilterElementResultCollection(int capacity)
		: base(capacity)
	{
	}

	public ContentFilterElementResultCollection(IEnumerable<ContentFilterElementResult> collection)
		: base(collection)
	{
	}

	public static implicit operator ContentFilterElementResultCollection(ContentFilterElementResult[] values)
	{
		if (values != null)
		{
			return new ContentFilterElementResultCollection(values);
		}
		return new ContentFilterElementResultCollection();
	}

	public static explicit operator ContentFilterElementResult[](ContentFilterElementResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ContentFilterElementResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterElementResultCollection contentFilterElementResultCollection = new ContentFilterElementResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			contentFilterElementResultCollection.Add((ContentFilterElementResult)Utils.Clone(base[i]));
		}
		return contentFilterElementResultCollection;
	}
}
