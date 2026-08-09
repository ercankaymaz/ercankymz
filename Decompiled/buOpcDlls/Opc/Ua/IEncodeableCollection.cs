using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfEncodeable", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Encodeable")]
[ComVisible(true)]
public class IEncodeableCollection : List<IEncodeable>
{
	public IEncodeableCollection()
	{
	}

	public IEncodeableCollection(IEnumerable<IEncodeable> collection)
		: base(collection)
	{
	}

	public IEncodeableCollection(int capacity)
		: base(capacity)
	{
	}

	public static IEncodeableCollection ToIEncodeableCollection(IEncodeable[] values)
	{
		if (values != null)
		{
			return new IEncodeableCollection(values);
		}
		return new IEncodeableCollection();
	}

	public static implicit operator IEncodeableCollection(IEncodeable[] values)
	{
		return ToIEncodeableCollection(values);
	}
}
