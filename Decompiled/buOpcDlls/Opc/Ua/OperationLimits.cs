using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OperationLimits
{
	[DataMember(Order = 10)]
	public uint MaxNodesPerRead { get; set; }

	[DataMember(Order = 20)]
	public uint MaxNodesPerHistoryReadData { get; set; }

	[DataMember(Order = 30)]
	public uint MaxNodesPerHistoryReadEvents { get; set; }

	[DataMember(Order = 40)]
	public uint MaxNodesPerWrite { get; set; }

	[DataMember(Order = 50)]
	public uint MaxNodesPerHistoryUpdateData { get; set; }

	[DataMember(Order = 60)]
	public uint MaxNodesPerHistoryUpdateEvents { get; set; }

	[DataMember(Order = 70)]
	public uint MaxNodesPerMethodCall { get; set; }

	[DataMember(Order = 80)]
	public uint MaxNodesPerBrowse { get; set; }

	[DataMember(Order = 90)]
	public uint MaxNodesPerRegisterNodes { get; set; }

	[DataMember(Order = 100)]
	public uint MaxNodesPerTranslateBrowsePathsToNodeIds { get; set; }

	[DataMember(Order = 110)]
	public uint MaxNodesPerNodeManagement { get; set; }

	[DataMember(Order = 120)]
	public uint MaxMonitoredItemsPerCall { get; set; }

	public OperationLimits()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		MaxNodesPerRead = 0u;
		MaxNodesPerHistoryReadData = 0u;
		MaxNodesPerHistoryReadEvents = 0u;
		MaxNodesPerWrite = 0u;
		MaxNodesPerHistoryUpdateData = 0u;
		MaxNodesPerHistoryUpdateEvents = 0u;
		MaxNodesPerMethodCall = 0u;
		MaxNodesPerBrowse = 0u;
		MaxNodesPerRegisterNodes = 0u;
		MaxNodesPerTranslateBrowsePathsToNodeIds = 0u;
		MaxNodesPerNodeManagement = 0u;
		MaxMonitoredItemsPerCall = 0u;
	}
}
