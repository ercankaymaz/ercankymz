using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfOpenFileMode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "OpenFileMode")]
[ComVisible(true)]
public class OpenFileModeCollection : List<OpenFileMode>, ICloneable
{
	public OpenFileModeCollection()
	{
	}

	public OpenFileModeCollection(int capacity)
		: base(capacity)
	{
	}

	public OpenFileModeCollection(IEnumerable<OpenFileMode> collection)
		: base(collection)
	{
	}

	public static implicit operator OpenFileModeCollection(OpenFileMode[] values)
	{
		if (values != null)
		{
			return new OpenFileModeCollection(values);
		}
		return new OpenFileModeCollection();
	}

	public static explicit operator OpenFileMode[](OpenFileModeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (OpenFileModeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OpenFileModeCollection openFileModeCollection = new OpenFileModeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			openFileModeCollection.Add((OpenFileMode)Utils.Clone(base[i]));
		}
		return openFileModeCollection;
	}
}
