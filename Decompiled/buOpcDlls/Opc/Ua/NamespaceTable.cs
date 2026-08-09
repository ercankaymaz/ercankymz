using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NamespaceTable : StringTable
{
	public NamespaceTable()
	{
		Append("http://opcfoundation.org/UA/");
	}

	public NamespaceTable(bool shared)
	{
		Append("http://opcfoundation.org/UA/");
	}

	public NamespaceTable(IEnumerable<string> namespaceUris)
	{
		Update(namespaceUris);
	}

	public new void Update(IEnumerable<string> namespaceUris)
	{
		if (namespaceUris == null)
		{
			throw new ArgumentNullException("namespaceUris");
		}
		int num = 0;
		foreach (string namespaceUri in namespaceUris)
		{
			if (num == 0 && namespaceUri != "http://opcfoundation.org/UA/")
			{
				throw new ArgumentException("The first namespace in the table must be the OPC-UA namespace.");
			}
			num++;
			if (num == 2)
			{
				break;
			}
		}
		base.Update(namespaceUris);
	}
}
