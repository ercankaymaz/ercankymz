using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfParsingResult", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ParsingResult")]
[ComVisible(true)]
public class ParsingResultCollection : List<ParsingResult>, ICloneable
{
	public ParsingResultCollection()
	{
	}

	public ParsingResultCollection(int capacity)
		: base(capacity)
	{
	}

	public ParsingResultCollection(IEnumerable<ParsingResult> collection)
		: base(collection)
	{
	}

	public static implicit operator ParsingResultCollection(ParsingResult[] values)
	{
		if (values != null)
		{
			return new ParsingResultCollection(values);
		}
		return new ParsingResultCollection();
	}

	public static explicit operator ParsingResult[](ParsingResultCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ParsingResultCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ParsingResultCollection parsingResultCollection = new ParsingResultCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			parsingResultCollection.Add((ParsingResult)Utils.Clone(base[i]));
		}
		return parsingResultCollection;
	}
}
