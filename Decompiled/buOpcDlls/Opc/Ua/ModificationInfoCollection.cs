using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfModificationInfo", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ModificationInfo")]
[ComVisible(true)]
public class ModificationInfoCollection : List<ModificationInfo>, ICloneable
{
	public ModificationInfoCollection()
	{
	}

	public ModificationInfoCollection(int capacity)
		: base(capacity)
	{
	}

	public ModificationInfoCollection(IEnumerable<ModificationInfo> collection)
		: base(collection)
	{
	}

	public static implicit operator ModificationInfoCollection(ModificationInfo[] values)
	{
		if (values != null)
		{
			return new ModificationInfoCollection(values);
		}
		return new ModificationInfoCollection();
	}

	public static explicit operator ModificationInfo[](ModificationInfoCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ModificationInfoCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModificationInfoCollection modificationInfoCollection = new ModificationInfoCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			modificationInfoCollection.Add((ModificationInfo)Utils.Clone(base[i]));
		}
		return modificationInfoCollection;
	}
}
