using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfSamplingRateGroup", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "SamplingRateGroup")]
[ComVisible(true)]
public class SamplingRateGroupCollection : List<SamplingRateGroup>
{
	public SamplingRateGroupCollection()
	{
	}

	public SamplingRateGroupCollection(IEnumerable<SamplingRateGroup> collection)
		: base(collection)
	{
	}

	public SamplingRateGroupCollection(int capacity)
		: base(capacity)
	{
	}
}
