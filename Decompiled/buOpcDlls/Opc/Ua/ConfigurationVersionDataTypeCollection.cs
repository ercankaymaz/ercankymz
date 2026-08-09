using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfConfigurationVersionDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ConfigurationVersionDataType")]
[ComVisible(true)]
public class ConfigurationVersionDataTypeCollection : List<ConfigurationVersionDataType>, ICloneable
{
	public ConfigurationVersionDataTypeCollection()
	{
	}

	public ConfigurationVersionDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ConfigurationVersionDataTypeCollection(IEnumerable<ConfigurationVersionDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ConfigurationVersionDataTypeCollection(ConfigurationVersionDataType[] values)
	{
		if (values != null)
		{
			return new ConfigurationVersionDataTypeCollection(values);
		}
		return new ConfigurationVersionDataTypeCollection();
	}

	public static explicit operator ConfigurationVersionDataType[](ConfigurationVersionDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ConfigurationVersionDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ConfigurationVersionDataTypeCollection configurationVersionDataTypeCollection = new ConfigurationVersionDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			configurationVersionDataTypeCollection.Add((ConfigurationVersionDataType)Utils.Clone(base[i]));
		}
		return configurationVersionDataTypeCollection;
	}
}
