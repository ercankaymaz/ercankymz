using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[ComVisible(true)]
public class SessionClientBatched : SessionClient
{
	private OperationLimits m_operationLimits;

	public OperationLimits OperationLimits
	{
		get
		{
			return m_operationLimits;
		}
		internal set
		{
			if (value == null)
			{
				m_operationLimits = new OperationLimits();
			}
			else
			{
				m_operationLimits = value;
			}
		}
	}

	public SessionClientBatched(ITransportChannel channel)
		: base(channel)
	{
		m_operationLimits = new OperationLimits();
	}

	public override ResponseHeader AddNodes(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, out AddNodesResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<AddNodesResult, AddNodesResultCollection>(out results, out diagnosticInfos, out var stringTable, nodesToAdd.Count, maxNodesPerNodeManagement);
		foreach (AddNodesItemCollection item in nodesToAdd.Batch<AddNodesItem, AddNodesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.AddNodes(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<AddNodesResult, AddNodesResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<AddNodesResponse> AddNodesAsync(RequestHeader requestHeader, AddNodesItemCollection nodesToAdd, CancellationToken ct)
	{
		AddNodesResponse addNodesResponse = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<AddNodesResult, AddNodesResultCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToAdd.Count, maxNodesPerNodeManagement);
		foreach (AddNodesItemCollection batchNodesToAdd in nodesToAdd.Batch<AddNodesItem, AddNodesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			addNodesResponse = await base.AddNodesAsync(requestHeader, batchNodesToAdd, ct).ConfigureAwait(continueOnCapturedContext: false);
			AddNodesResultCollection results2 = addNodesResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = addNodesResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchNodesToAdd);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchNodesToAdd);
			AddResponses<AddNodesResult, AddNodesResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, addNodesResponse.ResponseHeader.StringTable);
		}
		addNodesResponse.Results = results;
		addNodesResponse.DiagnosticInfos = diagnosticInfos;
		addNodesResponse.ResponseHeader.StringTable = stringTable;
		return addNodesResponse;
	}

	public override ResponseHeader AddReferences(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, referencesToAdd.Count, maxNodesPerNodeManagement);
		foreach (AddReferencesItemCollection item in referencesToAdd.Batch<AddReferencesItem, AddReferencesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.AddReferences(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<AddReferencesResponse> AddReferencesAsync(RequestHeader requestHeader, AddReferencesItemCollection referencesToAdd, CancellationToken ct)
	{
		AddReferencesResponse addReferencesResponse = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, referencesToAdd.Count, maxNodesPerNodeManagement);
		foreach (AddReferencesItemCollection batchReferencesToAdd in referencesToAdd.Batch<AddReferencesItem, AddReferencesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			addReferencesResponse = await base.AddReferencesAsync(requestHeader, batchReferencesToAdd, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = addReferencesResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = addReferencesResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchReferencesToAdd);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchReferencesToAdd);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, addReferencesResponse.ResponseHeader.StringTable);
		}
		addReferencesResponse.Results = results;
		addReferencesResponse.DiagnosticInfos = diagnosticInfos;
		addReferencesResponse.ResponseHeader.StringTable = stringTable;
		return addReferencesResponse;
	}

	public override ResponseHeader DeleteNodes(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, nodesToDelete.Count, maxNodesPerNodeManagement);
		foreach (DeleteNodesItemCollection item in nodesToDelete.Batch<DeleteNodesItem, DeleteNodesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.DeleteNodes(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<DeleteNodesResponse> DeleteNodesAsync(RequestHeader requestHeader, DeleteNodesItemCollection nodesToDelete, CancellationToken ct)
	{
		DeleteNodesResponse deleteNodesResponse = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToDelete.Count, maxNodesPerNodeManagement);
		foreach (DeleteNodesItemCollection batchNodesToDelete in nodesToDelete.Batch<DeleteNodesItem, DeleteNodesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			deleteNodesResponse = await base.DeleteNodesAsync(requestHeader, batchNodesToDelete, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = deleteNodesResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = deleteNodesResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchNodesToDelete);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchNodesToDelete);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, deleteNodesResponse.ResponseHeader.StringTable);
		}
		deleteNodesResponse.Results = results;
		deleteNodesResponse.DiagnosticInfos = diagnosticInfos;
		deleteNodesResponse.ResponseHeader.StringTable = stringTable;
		return deleteNodesResponse;
	}

	public override ResponseHeader DeleteReferences(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, referencesToDelete.Count, maxNodesPerNodeManagement);
		foreach (DeleteReferencesItemCollection item in referencesToDelete.Batch<DeleteReferencesItem, DeleteReferencesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.DeleteReferences(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<DeleteReferencesResponse> DeleteReferencesAsync(RequestHeader requestHeader, DeleteReferencesItemCollection referencesToDelete, CancellationToken ct)
	{
		DeleteReferencesResponse deleteReferencesResponse = null;
		uint maxNodesPerNodeManagement = OperationLimits.MaxNodesPerNodeManagement;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, referencesToDelete.Count, maxNodesPerNodeManagement);
		foreach (DeleteReferencesItemCollection batchReferencesToDelete in referencesToDelete.Batch<DeleteReferencesItem, DeleteReferencesItemCollection>(maxNodesPerNodeManagement))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			deleteReferencesResponse = await base.DeleteReferencesAsync(requestHeader, batchReferencesToDelete, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = deleteReferencesResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = deleteReferencesResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchReferencesToDelete);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchReferencesToDelete);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, deleteReferencesResponse.ResponseHeader.StringTable);
		}
		deleteReferencesResponse.Results = results;
		deleteReferencesResponse.DiagnosticInfos = diagnosticInfos;
		deleteReferencesResponse.ResponseHeader.StringTable = stringTable;
		return deleteReferencesResponse;
	}

	public override ResponseHeader Browse(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, out BrowseResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerBrowse = OperationLimits.MaxNodesPerBrowse;
		InitResponseCollections<BrowseResult, BrowseResultCollection>(out results, out diagnosticInfos, out var stringTable, nodesToBrowse.Count, maxNodesPerBrowse);
		foreach (BrowseDescriptionCollection item in nodesToBrowse.Batch<BrowseDescription, BrowseDescriptionCollection>(maxNodesPerBrowse))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.Browse(requestHeader, view, requestedMaxReferencesPerNode, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<BrowseResult, BrowseResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<BrowseResponse> BrowseAsync(RequestHeader requestHeader, ViewDescription view, uint requestedMaxReferencesPerNode, BrowseDescriptionCollection nodesToBrowse, CancellationToken ct)
	{
		BrowseResponse browseResponse = null;
		uint maxNodesPerBrowse = OperationLimits.MaxNodesPerBrowse;
		InitResponseCollections<BrowseResult, BrowseResultCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToBrowse.Count, maxNodesPerBrowse);
		foreach (BrowseDescriptionCollection nodesToBrowseBatch in nodesToBrowse.Batch<BrowseDescription, BrowseDescriptionCollection>(maxNodesPerBrowse))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			browseResponse = await base.BrowseAsync(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowseBatch, ct).ConfigureAwait(continueOnCapturedContext: false);
			BrowseResultCollection results2 = browseResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = browseResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, nodesToBrowseBatch);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, nodesToBrowseBatch);
			AddResponses<BrowseResult, BrowseResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, browseResponse.ResponseHeader.StringTable);
		}
		browseResponse.Results = results;
		browseResponse.DiagnosticInfos = diagnosticInfos;
		browseResponse.ResponseHeader.StringTable = stringTable;
		return browseResponse;
	}

	public override ResponseHeader TranslateBrowsePathsToNodeIds(RequestHeader requestHeader, BrowsePathCollection browsePaths, out BrowsePathResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerTranslateBrowsePathsToNodeIds = OperationLimits.MaxNodesPerTranslateBrowsePathsToNodeIds;
		InitResponseCollections<BrowsePathResult, BrowsePathResultCollection>(out results, out diagnosticInfos, out var stringTable, browsePaths.Count, maxNodesPerTranslateBrowsePathsToNodeIds);
		foreach (BrowsePathCollection item in browsePaths.Batch<BrowsePath, BrowsePathCollection>(maxNodesPerTranslateBrowsePathsToNodeIds))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.TranslateBrowsePathsToNodeIds(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<BrowsePathResult, BrowsePathResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(RequestHeader requestHeader, BrowsePathCollection browsePaths, CancellationToken ct)
	{
		TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = null;
		uint maxNodesPerTranslateBrowsePathsToNodeIds = OperationLimits.MaxNodesPerTranslateBrowsePathsToNodeIds;
		InitResponseCollections<BrowsePathResult, BrowsePathResultCollection>(out var results, out var diagnosticInfos, out var stringTable, browsePaths.Count, maxNodesPerTranslateBrowsePathsToNodeIds);
		foreach (BrowsePathCollection batchBrowsePaths in browsePaths.Batch<BrowsePath, BrowsePathCollection>(maxNodesPerTranslateBrowsePathsToNodeIds))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			translateBrowsePathsToNodeIdsResponse = await base.TranslateBrowsePathsToNodeIdsAsync(requestHeader, batchBrowsePaths, ct).ConfigureAwait(continueOnCapturedContext: false);
			BrowsePathResultCollection results2 = translateBrowsePathsToNodeIdsResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = translateBrowsePathsToNodeIdsResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchBrowsePaths);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchBrowsePaths);
			AddResponses<BrowsePathResult, BrowsePathResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, translateBrowsePathsToNodeIdsResponse.ResponseHeader.StringTable);
		}
		translateBrowsePathsToNodeIdsResponse.Results = results;
		translateBrowsePathsToNodeIdsResponse.DiagnosticInfos = diagnosticInfos;
		translateBrowsePathsToNodeIdsResponse.ResponseHeader.StringTable = stringTable;
		return translateBrowsePathsToNodeIdsResponse;
	}

	public override ResponseHeader RegisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToRegister, out NodeIdCollection registeredNodeIds)
	{
		ResponseHeader result = null;
		registeredNodeIds = new NodeIdCollection();
		foreach (NodeIdCollection item in nodesToRegister.Batch<NodeId, NodeIdCollection>(OperationLimits.MaxNodesPerRegisterNodes))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			result = base.RegisterNodes(requestHeader, item, out var registeredNodeIds2);
			ClientBase.ValidateResponse(registeredNodeIds2, item);
			registeredNodeIds.AddRange(registeredNodeIds2);
		}
		return result;
	}

	public override async Task<RegisterNodesResponse> RegisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToRegister, CancellationToken ct)
	{
		RegisterNodesResponse registerNodesResponse = null;
		NodeIdCollection registeredNodeIds = new NodeIdCollection();
		foreach (NodeIdCollection batchNodesToRegister in nodesToRegister.Batch<NodeId, NodeIdCollection>(OperationLimits.MaxNodesPerRegisterNodes))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			registerNodesResponse = await base.RegisterNodesAsync(requestHeader, batchNodesToRegister, ct).ConfigureAwait(continueOnCapturedContext: false);
			NodeIdCollection registeredNodeIds2 = registerNodesResponse.RegisteredNodeIds;
			ClientBase.ValidateResponse(registeredNodeIds2, batchNodesToRegister);
			registeredNodeIds.AddRange(registeredNodeIds2);
		}
		registerNodesResponse.RegisteredNodeIds = registeredNodeIds;
		return registerNodesResponse;
	}

	public override ResponseHeader UnregisterNodes(RequestHeader requestHeader, NodeIdCollection nodesToUnregister)
	{
		ResponseHeader result = null;
		foreach (NodeIdCollection item in nodesToUnregister.Batch<NodeId, NodeIdCollection>(OperationLimits.MaxNodesPerRegisterNodes))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			result = base.UnregisterNodes(requestHeader, item);
		}
		return result;
	}

	public override async Task<UnregisterNodesResponse> UnregisterNodesAsync(RequestHeader requestHeader, NodeIdCollection nodesToUnregister, CancellationToken ct)
	{
		UnregisterNodesResponse result = null;
		foreach (NodeIdCollection item in nodesToUnregister.Batch<NodeId, NodeIdCollection>(OperationLimits.MaxNodesPerRegisterNodes))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			result = await base.UnregisterNodesAsync(requestHeader, item, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		return result;
	}

	public override ResponseHeader Read(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, out DataValueCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerRead = OperationLimits.MaxNodesPerRead;
		InitResponseCollections<DataValue, DataValueCollection>(out results, out diagnosticInfos, out var stringTable, nodesToRead.Count, maxNodesPerRead);
		foreach (ReadValueIdCollection item in nodesToRead.Batch<ReadValueId, ReadValueIdCollection>(maxNodesPerRead))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.Read(requestHeader, maxAge, timestampsToReturn, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<DataValue, DataValueCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<ReadResponse> ReadAsync(RequestHeader requestHeader, double maxAge, TimestampsToReturn timestampsToReturn, ReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		ReadResponse readResponse = null;
		uint maxNodesPerRead = OperationLimits.MaxNodesPerRead;
		InitResponseCollections<DataValue, DataValueCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToRead.Count, maxNodesPerRead);
		foreach (ReadValueIdCollection batchAttributesToRead in nodesToRead.Batch<ReadValueId, ReadValueIdCollection>(maxNodesPerRead))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			readResponse = await base.ReadAsync(requestHeader, maxAge, timestampsToReturn, batchAttributesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
			DataValueCollection results2 = readResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = readResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchAttributesToRead);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchAttributesToRead);
			AddResponses<DataValue, DataValueCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, readResponse.ResponseHeader.StringTable);
		}
		readResponse.Results = results;
		readResponse.DiagnosticInfos = diagnosticInfos;
		readResponse.ResponseHeader.StringTable = stringTable;
		return readResponse;
	}

	public override ResponseHeader HistoryRead(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, out HistoryReadResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint num = OperationLimits.MaxNodesPerHistoryReadData;
		if (historyReadDetails?.Body is ReadEventDetails)
		{
			num = OperationLimits.MaxNodesPerHistoryReadEvents;
		}
		InitResponseCollections<HistoryReadResult, HistoryReadResultCollection>(out results, out diagnosticInfos, out var stringTable, nodesToRead.Count, num);
		foreach (HistoryReadValueIdCollection item in nodesToRead.Batch<HistoryReadValueId, HistoryReadValueIdCollection>(num))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.HistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<HistoryReadResult, HistoryReadResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<HistoryReadResponse> HistoryReadAsync(RequestHeader requestHeader, ExtensionObject historyReadDetails, TimestampsToReturn timestampsToReturn, bool releaseContinuationPoints, HistoryReadValueIdCollection nodesToRead, CancellationToken ct)
	{
		HistoryReadResponse historyReadResponse = null;
		uint num = OperationLimits.MaxNodesPerHistoryReadData;
		if (historyReadDetails?.Body is ReadEventDetails)
		{
			num = OperationLimits.MaxNodesPerHistoryReadEvents;
		}
		InitResponseCollections<HistoryReadResult, HistoryReadResultCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToRead.Count, num);
		foreach (HistoryReadValueIdCollection batchNodesToRead in nodesToRead.Batch<HistoryReadValueId, HistoryReadValueIdCollection>(num))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			historyReadResponse = await base.HistoryReadAsync(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, batchNodesToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
			HistoryReadResultCollection results2 = historyReadResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = historyReadResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchNodesToRead);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchNodesToRead);
			AddResponses<HistoryReadResult, HistoryReadResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, historyReadResponse.ResponseHeader.StringTable);
		}
		historyReadResponse.Results = results;
		historyReadResponse.DiagnosticInfos = diagnosticInfos;
		historyReadResponse.ResponseHeader.StringTable = stringTable;
		return historyReadResponse;
	}

	public override ResponseHeader Write(RequestHeader requestHeader, WriteValueCollection nodesToWrite, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerWrite = OperationLimits.MaxNodesPerWrite;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, nodesToWrite.Count, maxNodesPerWrite);
		foreach (WriteValueCollection item in nodesToWrite.Batch<WriteValue, WriteValueCollection>(maxNodesPerWrite))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.Write(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<WriteResponse> WriteAsync(RequestHeader requestHeader, WriteValueCollection nodesToWrite, CancellationToken ct)
	{
		WriteResponse writeResponse = null;
		uint maxNodesPerWrite = OperationLimits.MaxNodesPerWrite;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, nodesToWrite.Count, maxNodesPerWrite);
		foreach (WriteValueCollection batchNodesToWrite in nodesToWrite.Batch<WriteValue, WriteValueCollection>(maxNodesPerWrite))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			writeResponse = await base.WriteAsync(requestHeader, batchNodesToWrite, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = writeResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = writeResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchNodesToWrite);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchNodesToWrite);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, writeResponse.ResponseHeader.StringTable);
		}
		writeResponse.Results = results;
		writeResponse.DiagnosticInfos = diagnosticInfos;
		writeResponse.ResponseHeader.StringTable = stringTable;
		return writeResponse;
	}

	public override ResponseHeader HistoryUpdate(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, out HistoryUpdateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint num = OperationLimits.MaxNodesPerHistoryUpdateData;
		if (historyUpdateDetails.Count > 0 && historyUpdateDetails[0]?.Body is UpdateEventDetails)
		{
			num = OperationLimits.MaxNodesPerHistoryUpdateEvents;
		}
		InitResponseCollections<HistoryUpdateResult, HistoryUpdateResultCollection>(out results, out diagnosticInfos, out var stringTable, historyUpdateDetails.Count, num);
		foreach (ExtensionObjectCollection item in historyUpdateDetails.Batch<ExtensionObject, ExtensionObjectCollection>(num))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.HistoryUpdate(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<HistoryUpdateResult, HistoryUpdateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<HistoryUpdateResponse> HistoryUpdateAsync(RequestHeader requestHeader, ExtensionObjectCollection historyUpdateDetails, CancellationToken ct)
	{
		HistoryUpdateResponse historyUpdateResponse = null;
		uint num = OperationLimits.MaxNodesPerHistoryUpdateData;
		if (historyUpdateDetails.Count > 0 && historyUpdateDetails[0].TypeId == DataTypeIds.UpdateEventDetails)
		{
			num = OperationLimits.MaxNodesPerHistoryUpdateEvents;
		}
		InitResponseCollections<HistoryUpdateResult, HistoryUpdateResultCollection>(out var results, out var diagnosticInfos, out var stringTable, historyUpdateDetails.Count, num);
		foreach (ExtensionObjectCollection batchHistoryUpdateDetails in historyUpdateDetails.Batch<ExtensionObject, ExtensionObjectCollection>(num))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			historyUpdateResponse = await base.HistoryUpdateAsync(requestHeader, batchHistoryUpdateDetails, ct).ConfigureAwait(continueOnCapturedContext: false);
			HistoryUpdateResultCollection results2 = historyUpdateResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = historyUpdateResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchHistoryUpdateDetails);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchHistoryUpdateDetails);
			AddResponses<HistoryUpdateResult, HistoryUpdateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, historyUpdateResponse.ResponseHeader.StringTable);
		}
		historyUpdateResponse.Results = results;
		historyUpdateResponse.DiagnosticInfos = diagnosticInfos;
		historyUpdateResponse.ResponseHeader.StringTable = stringTable;
		return historyUpdateResponse;
	}

	public override ResponseHeader Call(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, out CallMethodResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxNodesPerMethodCall = OperationLimits.MaxNodesPerMethodCall;
		InitResponseCollections<CallMethodResult, CallMethodResultCollection>(out results, out diagnosticInfos, out var stringTable, methodsToCall.Count, maxNodesPerMethodCall);
		foreach (CallMethodRequestCollection item in methodsToCall.Batch<CallMethodRequest, CallMethodRequestCollection>(maxNodesPerMethodCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.Call(requestHeader, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<CallMethodResult, CallMethodResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<CallResponse> CallAsync(RequestHeader requestHeader, CallMethodRequestCollection methodsToCall, CancellationToken ct)
	{
		CallResponse callResponse = null;
		uint maxNodesPerMethodCall = OperationLimits.MaxNodesPerMethodCall;
		InitResponseCollections<CallMethodResult, CallMethodResultCollection>(out var results, out var diagnosticInfos, out var stringTable, methodsToCall.Count, maxNodesPerMethodCall);
		foreach (CallMethodRequestCollection batchMethodsToCall in methodsToCall.Batch<CallMethodRequest, CallMethodRequestCollection>(maxNodesPerMethodCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			callResponse = await base.CallAsync(requestHeader, batchMethodsToCall, ct).ConfigureAwait(continueOnCapturedContext: false);
			CallMethodResultCollection results2 = callResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = callResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchMethodsToCall);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchMethodsToCall);
			AddResponses<CallMethodResult, CallMethodResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, callResponse.ResponseHeader.StringTable);
		}
		callResponse.Results = results;
		callResponse.DiagnosticInfos = diagnosticInfos;
		callResponse.ResponseHeader.StringTable = stringTable;
		return callResponse;
	}

	public override ResponseHeader CreateMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, out MonitoredItemCreateResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(out results, out diagnosticInfos, out var stringTable, itemsToCreate.Count, maxMonitoredItemsPerCall);
		foreach (MonitoredItemCreateRequestCollection item in itemsToCreate.Batch<MonitoredItemCreateRequest, MonitoredItemCreateRequestCollection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.CreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemCreateRequestCollection itemsToCreate, CancellationToken ct)
	{
		CreateMonitoredItemsResponse createMonitoredItemsResponse = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(out var results, out var diagnosticInfos, out var stringTable, itemsToCreate.Count, maxMonitoredItemsPerCall);
		foreach (MonitoredItemCreateRequestCollection batchItemsToCreate in itemsToCreate.Batch<MonitoredItemCreateRequest, MonitoredItemCreateRequestCollection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			createMonitoredItemsResponse = await base.CreateMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, batchItemsToCreate, ct).ConfigureAwait(continueOnCapturedContext: false);
			MonitoredItemCreateResultCollection results2 = createMonitoredItemsResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = createMonitoredItemsResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchItemsToCreate);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchItemsToCreate);
			AddResponses<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, createMonitoredItemsResponse.ResponseHeader.StringTable);
		}
		createMonitoredItemsResponse.Results = results;
		createMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		createMonitoredItemsResponse.ResponseHeader.StringTable = stringTable;
		return createMonitoredItemsResponse;
	}

	public override ResponseHeader ModifyMonitoredItems(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, out MonitoredItemModifyResultCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(out results, out diagnosticInfos, out var stringTable, itemsToModify.Count, maxMonitoredItemsPerCall);
		foreach (MonitoredItemModifyRequestCollection item in itemsToModify.Batch<MonitoredItemModifyRequest, MonitoredItemModifyRequestCollection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.ModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, TimestampsToReturn timestampsToReturn, MonitoredItemModifyRequestCollection itemsToModify, CancellationToken ct)
	{
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(out var results, out var diagnosticInfos, out var stringTable, itemsToModify.Count, maxMonitoredItemsPerCall);
		foreach (MonitoredItemModifyRequestCollection batchItemsToModify in itemsToModify.Batch<MonitoredItemModifyRequest, MonitoredItemModifyRequestCollection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			modifyMonitoredItemsResponse = await base.ModifyMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, batchItemsToModify, ct).ConfigureAwait(continueOnCapturedContext: false);
			MonitoredItemModifyResultCollection results2 = modifyMonitoredItemsResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = modifyMonitoredItemsResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchItemsToModify);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchItemsToModify);
			AddResponses<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, modifyMonitoredItemsResponse.ResponseHeader.StringTable);
		}
		modifyMonitoredItemsResponse.Results = results;
		modifyMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		modifyMonitoredItemsResponse.ResponseHeader.StringTable = stringTable;
		return modifyMonitoredItemsResponse;
	}

	public override ResponseHeader SetMonitoringMode(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, monitoredItemIds.Count, maxMonitoredItemsPerCall);
		foreach (UInt32Collection item in monitoredItemIds.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.SetMonitoringMode(requestHeader, subscriptionId, monitoringMode, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(RequestHeader requestHeader, uint subscriptionId, MonitoringMode monitoringMode, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		SetMonitoringModeResponse setMonitoringModeResponse = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, monitoredItemIds.Count, maxMonitoredItemsPerCall);
		foreach (UInt32Collection batchMonitoredItemIds in monitoredItemIds.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			setMonitoringModeResponse = await base.SetMonitoringModeAsync(requestHeader, subscriptionId, monitoringMode, batchMonitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = setMonitoringModeResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = setMonitoringModeResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchMonitoredItemIds);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchMonitoredItemIds);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, setMonitoringModeResponse.ResponseHeader.StringTable);
		}
		setMonitoringModeResponse.Results = results;
		setMonitoringModeResponse.DiagnosticInfos = diagnosticInfos;
		setMonitoringModeResponse.ResponseHeader.StringTable = stringTable;
		return setMonitoringModeResponse;
	}

	public override ResponseHeader SetTriggering(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, out StatusCodeCollection addResults, out DiagnosticInfoCollection addDiagnosticInfos, out StatusCodeCollection removeResults, out DiagnosticInfoCollection removeDiagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out addResults, out addDiagnosticInfos, out var stringTable, linksToAdd.Count, maxMonitoredItemsPerCall);
		InitResponseCollections<StatusCode, StatusCodeCollection>(out removeResults, out removeDiagnosticInfos, out var _, linksToRemove.Count, maxMonitoredItemsPerCall);
		foreach (UInt32Collection item in linksToAdd.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
		{
			UInt32Collection uInt32Collection;
			if (maxMonitoredItemsPerCall == 0)
			{
				uInt32Collection = linksToRemove;
				linksToRemove = new UInt32Collection();
			}
			else if (item.Count < maxMonitoredItemsPerCall)
			{
				uInt32Collection = new UInt32Collection(linksToRemove.Take((int)maxMonitoredItemsPerCall - item.Count));
				linksToRemove = new UInt32Collection(linksToRemove.Skip(uInt32Collection.Count));
			}
			else
			{
				uInt32Collection = new UInt32Collection();
			}
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.SetTriggering(requestHeader, subscriptionId, triggeringItemId, item, uInt32Collection, out var addResults2, out var addDiagnosticInfos2, out var removeResults2, out var removeDiagnosticInfos2);
			ClientBase.ValidateResponse(addResults2, item);
			ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos2, item);
			ClientBase.ValidateResponse(removeResults2, uInt32Collection);
			ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos2, uInt32Collection);
			AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults2, addDiagnosticInfos2, responseHeader.StringTable);
			AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults2, removeDiagnosticInfos2, responseHeader.StringTable);
		}
		if (linksToRemove.Count > 0)
		{
			foreach (UInt32Collection item2 in linksToRemove.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
			{
				if (requestHeader != null)
				{
					requestHeader.RequestHandle = 0u;
				}
				UInt32Collection uInt32Collection2 = new UInt32Collection();
				responseHeader = base.SetTriggering(requestHeader, subscriptionId, triggeringItemId, uInt32Collection2, item2, out var addResults3, out var addDiagnosticInfos3, out var removeResults3, out var removeDiagnosticInfos3);
				ClientBase.ValidateResponse(addResults3, uInt32Collection2);
				ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos3, uInt32Collection2);
				ClientBase.ValidateResponse(removeResults3, item2);
				ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos3, item2);
				AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults3, addDiagnosticInfos3, responseHeader.StringTable);
				AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults3, removeDiagnosticInfos3, responseHeader.StringTable);
			}
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<SetTriggeringResponse> SetTriggeringAsync(RequestHeader requestHeader, uint subscriptionId, uint triggeringItemId, UInt32Collection linksToAdd, UInt32Collection linksToRemove, CancellationToken ct)
	{
		SetTriggeringResponse setTriggeringResponse = null;
		uint operationLimit = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var addResults, out var addDiagnosticInfos, out var stringTable, linksToAdd.Count, operationLimit);
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var removeResults, out var removeDiagnosticInfos, out var _, linksToRemove.Count, operationLimit);
		foreach (UInt32Collection batchLinksToAdd in linksToAdd.Batch<uint, UInt32Collection>(operationLimit))
		{
			UInt32Collection batchLinksToRemove;
			if (operationLimit == 0)
			{
				batchLinksToRemove = linksToRemove;
				linksToRemove = new UInt32Collection();
			}
			else if (batchLinksToAdd.Count < operationLimit)
			{
				batchLinksToRemove = new UInt32Collection(linksToRemove.Take((int)operationLimit - batchLinksToAdd.Count));
				linksToRemove = new UInt32Collection(linksToRemove.Skip(batchLinksToRemove.Count));
			}
			else
			{
				batchLinksToRemove = new UInt32Collection();
			}
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			setTriggeringResponse = await base.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, batchLinksToAdd, batchLinksToRemove, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection addResults2 = setTriggeringResponse.AddResults;
			DiagnosticInfoCollection addDiagnosticInfos2 = setTriggeringResponse.AddDiagnosticInfos;
			StatusCodeCollection removeResults2 = setTriggeringResponse.RemoveResults;
			DiagnosticInfoCollection removeDiagnosticInfos2 = setTriggeringResponse.RemoveDiagnosticInfos;
			ClientBase.ValidateResponse(addResults2, batchLinksToAdd);
			ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos2, batchLinksToAdd);
			ClientBase.ValidateResponse(removeResults2, batchLinksToRemove);
			ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos2, batchLinksToRemove);
			AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults2, addDiagnosticInfos2, setTriggeringResponse.ResponseHeader.StringTable);
			AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults2, removeDiagnosticInfos2, setTriggeringResponse.ResponseHeader.StringTable);
		}
		if (linksToRemove.Count > 0)
		{
			foreach (UInt32Collection batchLinksToAdd in linksToRemove.Batch<uint, UInt32Collection>(operationLimit))
			{
				if (requestHeader != null)
				{
					requestHeader.RequestHandle = 0u;
				}
				UInt32Collection batchLinksToRemove = new UInt32Collection();
				setTriggeringResponse = await base.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, batchLinksToRemove, batchLinksToAdd, ct).ConfigureAwait(continueOnCapturedContext: false);
				StatusCodeCollection addResults3 = setTriggeringResponse.AddResults;
				DiagnosticInfoCollection addDiagnosticInfos3 = setTriggeringResponse.AddDiagnosticInfos;
				StatusCodeCollection removeResults3 = setTriggeringResponse.RemoveResults;
				DiagnosticInfoCollection removeDiagnosticInfos3 = setTriggeringResponse.RemoveDiagnosticInfos;
				ClientBase.ValidateResponse(addResults3, batchLinksToRemove);
				ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos3, batchLinksToRemove);
				ClientBase.ValidateResponse(removeResults3, batchLinksToAdd);
				ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos3, batchLinksToAdd);
				AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults3, addDiagnosticInfos3, setTriggeringResponse.ResponseHeader.StringTable);
				AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults3, removeDiagnosticInfos3, setTriggeringResponse.ResponseHeader.StringTable);
			}
		}
		setTriggeringResponse.AddResults = addResults;
		setTriggeringResponse.AddDiagnosticInfos = addDiagnosticInfos;
		setTriggeringResponse.RemoveResults = removeResults;
		setTriggeringResponse.RemoveDiagnosticInfos = removeDiagnosticInfos;
		setTriggeringResponse.ResponseHeader.StringTable = stringTable;
		return setTriggeringResponse;
	}

	public override ResponseHeader DeleteMonitoredItems(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, out StatusCodeCollection results, out DiagnosticInfoCollection diagnosticInfos)
	{
		ResponseHeader responseHeader = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out var stringTable, monitoredItemIds.Count, maxMonitoredItemsPerCall);
		foreach (UInt32Collection item in monitoredItemIds.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			responseHeader = base.DeleteMonitoredItems(requestHeader, subscriptionId, item, out var results2, out var diagnosticInfos2);
			ClientBase.ValidateResponse(results2, item);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, item);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, responseHeader.StringTable);
		}
		responseHeader.StringTable = stringTable;
		return responseHeader;
	}

	public override async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(RequestHeader requestHeader, uint subscriptionId, UInt32Collection monitoredItemIds, CancellationToken ct)
	{
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = null;
		uint maxMonitoredItemsPerCall = OperationLimits.MaxMonitoredItemsPerCall;
		InitResponseCollections<StatusCode, StatusCodeCollection>(out var results, out var diagnosticInfos, out var stringTable, monitoredItemIds.Count, maxMonitoredItemsPerCall);
		foreach (UInt32Collection batchMonitoredItemIds in monitoredItemIds.Batch<uint, UInt32Collection>(maxMonitoredItemsPerCall))
		{
			if (requestHeader != null)
			{
				requestHeader.RequestHandle = 0u;
			}
			deleteMonitoredItemsResponse = await base.DeleteMonitoredItemsAsync(requestHeader, subscriptionId, batchMonitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
			StatusCodeCollection results2 = deleteMonitoredItemsResponse.Results;
			DiagnosticInfoCollection diagnosticInfos2 = deleteMonitoredItemsResponse.DiagnosticInfos;
			ClientBase.ValidateResponse(results2, batchMonitoredItemIds);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos2, batchMonitoredItemIds);
			AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results2, diagnosticInfos2, deleteMonitoredItemsResponse.ResponseHeader.StringTable);
		}
		deleteMonitoredItemsResponse.Results = results;
		deleteMonitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
		deleteMonitoredItemsResponse.ResponseHeader.StringTable = stringTable;
		return deleteMonitoredItemsResponse;
	}

	private static void InitResponseCollections<T, C>(out C results, out DiagnosticInfoCollection diagnosticInfos, out StringCollection stringTable, int count, uint operationLimit) where C : List<T>, new()
	{
		if (count <= operationLimit)
		{
			results = null;
			diagnosticInfos = null;
			stringTable = null;
		}
		else
		{
			results = new C
			{
				Capacity = count
			};
			diagnosticInfos = new DiagnosticInfoCollection(count);
			stringTable = new StringCollection();
		}
	}

	private static void AddResponses<T, C>(ref C results, ref DiagnosticInfoCollection diagnosticInfos, ref StringCollection stringTable, C batchedResults, DiagnosticInfoCollection batchedDiagnosticInfos, StringCollection batchedStringTable) where C : List<T>
	{
		if (results == null)
		{
			results = batchedResults;
			diagnosticInfos = batchedDiagnosticInfos;
			stringTable = batchedStringTable;
			return;
		}
		bool flag = diagnosticInfos.Count > 0;
		bool flag2 = diagnosticInfos.Count == 0 && results.Count > 0;
		bool flag3 = batchedDiagnosticInfos.Count > 0;
		int num = 0;
		if (flag3 && flag2)
		{
			num = results.Count;
		}
		else if (!flag3 && flag)
		{
			num = batchedResults.Count;
		}
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				diagnosticInfos.Add(null);
			}
		}
		else if (batchedStringTable.Count > 0)
		{
			int count = stringTable.Count;
			foreach (DiagnosticInfo batchedDiagnosticInfo in batchedDiagnosticInfos)
			{
				UpdateDiagnosticInfoIndexes(batchedDiagnosticInfo, count);
			}
		}
		results.AddRange(batchedResults);
		diagnosticInfos.AddRange(batchedDiagnosticInfos);
		stringTable.AddRange(batchedStringTable);
	}

	private static void UpdateDiagnosticInfoIndexes(DiagnosticInfo diagnosticInfo, int stringTableOffset)
	{
		int num = 0;
		while (diagnosticInfo != null && num++ < DiagnosticInfo.MaxInnerDepth)
		{
			if (diagnosticInfo.LocalizedText >= 0)
			{
				diagnosticInfo.LocalizedText += stringTableOffset;
			}
			if (diagnosticInfo.Locale >= 0)
			{
				diagnosticInfo.Locale += stringTableOffset;
			}
			if (diagnosticInfo.NamespaceUri >= 0)
			{
				diagnosticInfo.NamespaceUri += stringTableOffset;
			}
			if (diagnosticInfo.SymbolicId >= 0)
			{
				diagnosticInfo.SymbolicId += stringTableOffset;
			}
			diagnosticInfo = diagnosticInfo.InnerDiagnosticInfo;
		}
	}
}
