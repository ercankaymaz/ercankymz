using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfApplicationDescription", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ApplicationDescription")]
[ComVisible(true)]
public class ApplicationDescriptionCollection : List<ApplicationDescription>, ICloneable
{
	public ApplicationDescriptionCollection()
	{
	}

	public ApplicationDescriptionCollection(int capacity)
		: base(capacity)
	{
	}

	public ApplicationDescriptionCollection(IEnumerable<ApplicationDescription> collection)
		: base(collection)
	{
	}

	public static implicit operator ApplicationDescriptionCollection(ApplicationDescription[] values)
	{
		if (values != null)
		{
			return new ApplicationDescriptionCollection(values);
		}
		return new ApplicationDescriptionCollection();
	}

	public static explicit operator ApplicationDescription[](ApplicationDescriptionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ApplicationDescriptionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ApplicationDescriptionCollection applicationDescriptionCollection = new ApplicationDescriptionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			applicationDescriptionCollection.Add((ApplicationDescription)Utils.Clone(base[i]));
		}
		return applicationDescriptionCollection;
	}
}
