// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SessionClientBatched
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class SessionClientBatched : SessionClient
{
  private OperationLimits m_operationLimits;

  public SessionClientBatched(ITransportChannel channel)
    : base(channel)
  {
    this.m_operationLimits = new OperationLimits();
  }

  public OperationLimits OperationLimits
  {
    get => this.m_operationLimits;
    internal set
    {
      if (value == null)
        this.m_operationLimits = new OperationLimits();
      else
        this.m_operationLimits = value;
    }
  }

  public override ResponseHeader AddNodes(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    out AddNodesResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<AddNodesResult, AddNodesResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToAdd.Count, perNodeManagement);
    foreach (AddNodesItemCollection nodesItemCollection in nodesToAdd.Batch<AddNodesItem, AddNodesItemCollection>(perNodeManagement))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      AddNodesResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.AddNodes(requestHeader, nodesItemCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) nodesItemCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) nodesItemCollection);
      SessionClientBatched.AddResponses<AddNodesResult, AddNodesResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<AddNodesResponse> AddNodesAsync(
    RequestHeader requestHeader,
    AddNodesItemCollection nodesToAdd,
    CancellationToken ct)
  {
    AddNodesResponse addNodesResponse1 = (AddNodesResponse) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    AddNodesResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<AddNodesResult, AddNodesResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToAdd.Count, perNodeManagement);
    foreach (AddNodesItemCollection nodesItemCollection in nodesToAdd.Batch<AddNodesItem, AddNodesItemCollection>(perNodeManagement))
    {
      AddNodesItemCollection batchNodesToAdd = nodesItemCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<AddNodesResponse>.ConfiguredTaskAwaiter awaiter = base.AddNodesAsync(requestHeader, batchNodesToAdd, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        addNodesResponse1 = awaiter.GetResult();
        AddNodesResultCollection results1 = addNodesResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = addNodesResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchNodesToAdd);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchNodesToAdd);
        SessionClientBatched.AddResponses<AddNodesResult, AddNodesResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, addNodesResponse1.ResponseHeader.StringTable);
        batchNodesToAdd = (AddNodesItemCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<AddNodesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<AddNodesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CAddNodesAsync\u003Ed__5>(ref awaiter, this);
        return;
      }
    }
    addNodesResponse1.Results = results;
    addNodesResponse1.DiagnosticInfos = diagnosticInfos;
    addNodesResponse1.ResponseHeader.StringTable = stringTable;
    AddNodesResponse addNodesResponse2 = addNodesResponse1;
    results = (AddNodesResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return addNodesResponse2;
  }

  public override ResponseHeader AddReferences(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, referencesToAdd.Count, perNodeManagement);
    foreach (AddReferencesItemCollection referencesItemCollection in referencesToAdd.Batch<AddReferencesItem, AddReferencesItemCollection>(perNodeManagement))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.AddReferences(requestHeader, referencesItemCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) referencesItemCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) referencesItemCollection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<AddReferencesResponse> AddReferencesAsync(
    RequestHeader requestHeader,
    AddReferencesItemCollection referencesToAdd,
    CancellationToken ct)
  {
    AddReferencesResponse referencesResponse1 = (AddReferencesResponse) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, referencesToAdd.Count, perNodeManagement);
    foreach (AddReferencesItemCollection referencesItemCollection in referencesToAdd.Batch<AddReferencesItem, AddReferencesItemCollection>(perNodeManagement))
    {
      AddReferencesItemCollection batchReferencesToAdd = referencesItemCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<AddReferencesResponse>.ConfiguredTaskAwaiter awaiter = base.AddReferencesAsync(requestHeader, batchReferencesToAdd, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        referencesResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = referencesResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = referencesResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchReferencesToAdd);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchReferencesToAdd);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, referencesResponse1.ResponseHeader.StringTable);
        batchReferencesToAdd = (AddReferencesItemCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<AddReferencesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<AddReferencesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CAddReferencesAsync\u003Ed__7>(ref awaiter, this);
        return;
      }
    }
    referencesResponse1.Results = results;
    referencesResponse1.DiagnosticInfos = diagnosticInfos;
    referencesResponse1.ResponseHeader.StringTable = stringTable;
    AddReferencesResponse referencesResponse2 = referencesResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return referencesResponse2;
  }

  public override ResponseHeader DeleteNodes(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, nodesToDelete.Count, perNodeManagement);
    foreach (DeleteNodesItemCollection nodesItemCollection in nodesToDelete.Batch<DeleteNodesItem, DeleteNodesItemCollection>(perNodeManagement))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.DeleteNodes(requestHeader, nodesItemCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) nodesItemCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) nodesItemCollection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<DeleteNodesResponse> DeleteNodesAsync(
    RequestHeader requestHeader,
    DeleteNodesItemCollection nodesToDelete,
    CancellationToken ct)
  {
    DeleteNodesResponse deleteNodesResponse1 = (DeleteNodesResponse) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, nodesToDelete.Count, perNodeManagement);
    foreach (DeleteNodesItemCollection nodesItemCollection in nodesToDelete.Batch<DeleteNodesItem, DeleteNodesItemCollection>(perNodeManagement))
    {
      DeleteNodesItemCollection batchNodesToDelete = nodesItemCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<DeleteNodesResponse>.ConfiguredTaskAwaiter awaiter = base.DeleteNodesAsync(requestHeader, batchNodesToDelete, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        deleteNodesResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = deleteNodesResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = deleteNodesResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchNodesToDelete);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchNodesToDelete);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, deleteNodesResponse1.ResponseHeader.StringTable);
        batchNodesToDelete = (DeleteNodesItemCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<DeleteNodesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<DeleteNodesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CDeleteNodesAsync\u003Ed__9>(ref awaiter, this);
        return;
      }
    }
    deleteNodesResponse1.Results = results;
    deleteNodesResponse1.DiagnosticInfos = diagnosticInfos;
    deleteNodesResponse1.ResponseHeader.StringTable = stringTable;
    DeleteNodesResponse deleteNodesResponse2 = deleteNodesResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return deleteNodesResponse2;
  }

  public override ResponseHeader DeleteReferences(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, referencesToDelete.Count, perNodeManagement);
    foreach (DeleteReferencesItemCollection referencesItemCollection in referencesToDelete.Batch<DeleteReferencesItem, DeleteReferencesItemCollection>(perNodeManagement))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.DeleteReferences(requestHeader, referencesItemCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) referencesItemCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) referencesItemCollection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<DeleteReferencesResponse> DeleteReferencesAsync(
    RequestHeader requestHeader,
    DeleteReferencesItemCollection referencesToDelete,
    CancellationToken ct)
  {
    DeleteReferencesResponse referencesResponse1 = (DeleteReferencesResponse) null;
    uint perNodeManagement = this.OperationLimits.MaxNodesPerNodeManagement;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, referencesToDelete.Count, perNodeManagement);
    foreach (DeleteReferencesItemCollection referencesItemCollection in referencesToDelete.Batch<DeleteReferencesItem, DeleteReferencesItemCollection>(perNodeManagement))
    {
      DeleteReferencesItemCollection batchReferencesToDelete = referencesItemCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<DeleteReferencesResponse>.ConfiguredTaskAwaiter awaiter = base.DeleteReferencesAsync(requestHeader, batchReferencesToDelete, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        referencesResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = referencesResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = referencesResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchReferencesToDelete);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchReferencesToDelete);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, referencesResponse1.ResponseHeader.StringTable);
        batchReferencesToDelete = (DeleteReferencesItemCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<DeleteReferencesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<DeleteReferencesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CDeleteReferencesAsync\u003Ed__11>(ref awaiter, this);
        return;
      }
    }
    referencesResponse1.Results = results;
    referencesResponse1.DiagnosticInfos = diagnosticInfos;
    referencesResponse1.ResponseHeader.StringTable = stringTable;
    DeleteReferencesResponse referencesResponse2 = referencesResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return referencesResponse2;
  }

  public override ResponseHeader Browse(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    out BrowseResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint maxNodesPerBrowse = this.OperationLimits.MaxNodesPerBrowse;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<BrowseResult, BrowseResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToBrowse.Count, maxNodesPerBrowse);
    foreach (BrowseDescriptionCollection descriptionCollection in nodesToBrowse.Batch<BrowseDescription, BrowseDescriptionCollection>(maxNodesPerBrowse))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      BrowseResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.Browse(requestHeader, view, requestedMaxReferencesPerNode, descriptionCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) descriptionCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) descriptionCollection);
      SessionClientBatched.AddResponses<BrowseResult, BrowseResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<BrowseResponse> BrowseAsync(
    RequestHeader requestHeader,
    ViewDescription view,
    uint requestedMaxReferencesPerNode,
    BrowseDescriptionCollection nodesToBrowse,
    CancellationToken ct)
  {
    BrowseResponse browseResponse1 = (BrowseResponse) null;
    uint maxNodesPerBrowse = this.OperationLimits.MaxNodesPerBrowse;
    BrowseResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<BrowseResult, BrowseResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToBrowse.Count, maxNodesPerBrowse);
    foreach (BrowseDescriptionCollection descriptionCollection in nodesToBrowse.Batch<BrowseDescription, BrowseDescriptionCollection>(maxNodesPerBrowse))
    {
      BrowseDescriptionCollection nodesToBrowseBatch = descriptionCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<BrowseResponse>.ConfiguredTaskAwaiter awaiter = base.BrowseAsync(requestHeader, view, requestedMaxReferencesPerNode, nodesToBrowseBatch, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        browseResponse1 = awaiter.GetResult();
        BrowseResultCollection results1 = browseResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = browseResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) nodesToBrowseBatch);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) nodesToBrowseBatch);
        SessionClientBatched.AddResponses<BrowseResult, BrowseResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, browseResponse1.ResponseHeader.StringTable);
        nodesToBrowseBatch = (BrowseDescriptionCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<BrowseResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<BrowseResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CBrowseAsync\u003Ed__13>(ref awaiter, this);
        return;
      }
    }
    browseResponse1.Results = results;
    browseResponse1.DiagnosticInfos = diagnosticInfos;
    browseResponse1.ResponseHeader.StringTable = stringTable;
    BrowseResponse browseResponse2 = browseResponse1;
    results = (BrowseResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return browseResponse2;
  }

  public override ResponseHeader TranslateBrowsePathsToNodeIds(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    out BrowsePathResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader nodeIds = (ResponseHeader) null;
    uint browsePathsToNodeIds = this.OperationLimits.MaxNodesPerTranslateBrowsePathsToNodeIds;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<BrowsePathResult, BrowsePathResultCollection>(out results, out diagnosticInfos, out stringTable, browsePaths.Count, browsePathsToNodeIds);
    foreach (BrowsePathCollection browsePathCollection in browsePaths.Batch<BrowsePath, BrowsePathCollection>(browsePathsToNodeIds))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      BrowsePathResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      nodeIds = base.TranslateBrowsePathsToNodeIds(requestHeader, browsePathCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) browsePathCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) browsePathCollection);
      SessionClientBatched.AddResponses<BrowsePathResult, BrowsePathResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, nodeIds.StringTable);
    }
    nodeIds.StringTable = stringTable;
    return nodeIds;
  }

  public override async Task<TranslateBrowsePathsToNodeIdsResponse> TranslateBrowsePathsToNodeIdsAsync(
    RequestHeader requestHeader,
    BrowsePathCollection browsePaths,
    CancellationToken ct)
  {
    TranslateBrowsePathsToNodeIdsResponse toNodeIdsResponse = (TranslateBrowsePathsToNodeIdsResponse) null;
    uint browsePathsToNodeIds = this.OperationLimits.MaxNodesPerTranslateBrowsePathsToNodeIds;
    BrowsePathResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<BrowsePathResult, BrowsePathResultCollection>(out results, out diagnosticInfos, out stringTable, browsePaths.Count, browsePathsToNodeIds);
    foreach (BrowsePathCollection browsePathCollection in browsePaths.Batch<BrowsePath, BrowsePathCollection>(browsePathsToNodeIds))
    {
      BrowsePathCollection batchBrowsePaths = browsePathCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<TranslateBrowsePathsToNodeIdsResponse>.ConfiguredTaskAwaiter awaiter = base.TranslateBrowsePathsToNodeIdsAsync(requestHeader, batchBrowsePaths, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        toNodeIdsResponse = awaiter.GetResult();
        BrowsePathResultCollection results1 = toNodeIdsResponse.Results;
        DiagnosticInfoCollection diagnosticInfos1 = toNodeIdsResponse.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchBrowsePaths);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchBrowsePaths);
        SessionClientBatched.AddResponses<BrowsePathResult, BrowsePathResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, toNodeIdsResponse.ResponseHeader.StringTable);
        batchBrowsePaths = (BrowsePathCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<TranslateBrowsePathsToNodeIdsResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<TranslateBrowsePathsToNodeIdsResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CTranslateBrowsePathsToNodeIdsAsync\u003Ed__15>(ref awaiter, this);
        return;
      }
    }
    toNodeIdsResponse.Results = results;
    toNodeIdsResponse.DiagnosticInfos = diagnosticInfos;
    toNodeIdsResponse.ResponseHeader.StringTable = stringTable;
    TranslateBrowsePathsToNodeIdsResponse nodeIdsAsync = toNodeIdsResponse;
    results = (BrowsePathResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return nodeIdsAsync;
  }

  public override ResponseHeader RegisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    out NodeIdCollection registeredNodeIds)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    registeredNodeIds = new NodeIdCollection();
    foreach (NodeIdCollection nodeIdCollection in nodesToRegister.Batch<NodeId, NodeIdCollection>(this.OperationLimits.MaxNodesPerRegisterNodes))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      NodeIdCollection registeredNodeIds1;
      responseHeader = base.RegisterNodes(requestHeader, nodeIdCollection, out registeredNodeIds1);
      ClientBase.ValidateResponse((IList) registeredNodeIds1, (IList) nodeIdCollection);
      registeredNodeIds.AddRange((IEnumerable<NodeId>) registeredNodeIds1);
    }
    return responseHeader;
  }

  public override async Task<RegisterNodesResponse> RegisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToRegister,
    CancellationToken ct)
  {
    RegisterNodesResponse registerNodesResponse1 = (RegisterNodesResponse) null;
    NodeIdCollection registeredNodeIds = new NodeIdCollection();
    foreach (NodeIdCollection nodeIdCollection in nodesToRegister.Batch<NodeId, NodeIdCollection>(this.OperationLimits.MaxNodesPerRegisterNodes))
    {
      NodeIdCollection batchNodesToRegister = nodeIdCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<RegisterNodesResponse>.ConfiguredTaskAwaiter awaiter = base.RegisterNodesAsync(requestHeader, batchNodesToRegister, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        registerNodesResponse1 = awaiter.GetResult();
        NodeIdCollection registeredNodeIds1 = registerNodesResponse1.RegisteredNodeIds;
        ClientBase.ValidateResponse((IList) registeredNodeIds1, (IList) batchNodesToRegister);
        registeredNodeIds.AddRange((IEnumerable<NodeId>) registeredNodeIds1);
        batchNodesToRegister = (NodeIdCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<RegisterNodesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<RegisterNodesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CRegisterNodesAsync\u003Ed__17>(ref awaiter, this);
        return;
      }
    }
    registerNodesResponse1.RegisteredNodeIds = registeredNodeIds;
    RegisterNodesResponse registerNodesResponse2 = registerNodesResponse1;
    registeredNodeIds = (NodeIdCollection) null;
    return registerNodesResponse2;
  }

  public override ResponseHeader UnregisterNodes(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    foreach (NodeIdCollection nodesToUnregister1 in nodesToUnregister.Batch<NodeId, NodeIdCollection>(this.OperationLimits.MaxNodesPerRegisterNodes))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      responseHeader = base.UnregisterNodes(requestHeader, nodesToUnregister1);
    }
    return responseHeader;
  }

  public override async Task<UnregisterNodesResponse> UnregisterNodesAsync(
    RequestHeader requestHeader,
    NodeIdCollection nodesToUnregister,
    CancellationToken ct)
  {
    UnregisterNodesResponse unregisterNodesResponse = (UnregisterNodesResponse) null;
    foreach (NodeIdCollection nodesToUnregister1 in nodesToUnregister.Batch<NodeId, NodeIdCollection>(this.OperationLimits.MaxNodesPerRegisterNodes))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<UnregisterNodesResponse>.ConfiguredTaskAwaiter awaiter = base.UnregisterNodesAsync(requestHeader, nodesToUnregister1, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        unregisterNodesResponse = awaiter.GetResult();
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<UnregisterNodesResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<UnregisterNodesResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CUnregisterNodesAsync\u003Ed__19>(ref awaiter, this);
        return;
      }
    }
    return unregisterNodesResponse;
  }

  public override ResponseHeader Read(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    out DataValueCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint maxNodesPerRead = this.OperationLimits.MaxNodesPerRead;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<DataValue, DataValueCollection>(out results, out diagnosticInfos, out stringTable, nodesToRead.Count, maxNodesPerRead);
    foreach (ReadValueIdCollection valueIdCollection in nodesToRead.Batch<ReadValueId, ReadValueIdCollection>(maxNodesPerRead))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      DataValueCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.Read(requestHeader, maxAge, timestampsToReturn, valueIdCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) valueIdCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) valueIdCollection);
      SessionClientBatched.AddResponses<DataValue, DataValueCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<ReadResponse> ReadAsync(
    RequestHeader requestHeader,
    double maxAge,
    TimestampsToReturn timestampsToReturn,
    ReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    ReadResponse readResponse1 = (ReadResponse) null;
    uint maxNodesPerRead = this.OperationLimits.MaxNodesPerRead;
    DataValueCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<DataValue, DataValueCollection>(out results, out diagnosticInfos, out stringTable, nodesToRead.Count, maxNodesPerRead);
    foreach (ReadValueIdCollection valueIdCollection in nodesToRead.Batch<ReadValueId, ReadValueIdCollection>(maxNodesPerRead))
    {
      ReadValueIdCollection batchAttributesToRead = valueIdCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<ReadResponse>.ConfiguredTaskAwaiter awaiter = base.ReadAsync(requestHeader, maxAge, timestampsToReturn, batchAttributesToRead, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        readResponse1 = awaiter.GetResult();
        DataValueCollection results1 = readResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = readResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchAttributesToRead);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchAttributesToRead);
        SessionClientBatched.AddResponses<DataValue, DataValueCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, readResponse1.ResponseHeader.StringTable);
        batchAttributesToRead = (ReadValueIdCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<ReadResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<ReadResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CReadAsync\u003Ed__21>(ref awaiter, this);
        return;
      }
    }
    readResponse1.Results = results;
    readResponse1.DiagnosticInfos = diagnosticInfos;
    readResponse1.ResponseHeader.StringTable = stringTable;
    ReadResponse readResponse2 = readResponse1;
    results = (DataValueCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return readResponse2;
  }

  public override ResponseHeader HistoryRead(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    out HistoryReadResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint num = this.OperationLimits.MaxNodesPerHistoryReadData;
    if (historyReadDetails?.Body is ReadEventDetails)
      num = this.OperationLimits.MaxNodesPerHistoryReadEvents;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<HistoryReadResult, HistoryReadResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToRead.Count, num);
    foreach (HistoryReadValueIdCollection valueIdCollection in nodesToRead.Batch<HistoryReadValueId, HistoryReadValueIdCollection>(num))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      HistoryReadResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.HistoryRead(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, valueIdCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) valueIdCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) valueIdCollection);
      SessionClientBatched.AddResponses<HistoryReadResult, HistoryReadResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<HistoryReadResponse> HistoryReadAsync(
    RequestHeader requestHeader,
    ExtensionObject historyReadDetails,
    TimestampsToReturn timestampsToReturn,
    bool releaseContinuationPoints,
    HistoryReadValueIdCollection nodesToRead,
    CancellationToken ct)
  {
    HistoryReadResponse historyReadResponse1 = (HistoryReadResponse) null;
    uint num = this.OperationLimits.MaxNodesPerHistoryReadData;
    if (historyReadDetails?.Body is ReadEventDetails)
      num = this.OperationLimits.MaxNodesPerHistoryReadEvents;
    HistoryReadResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<HistoryReadResult, HistoryReadResultCollection>(out results, out diagnosticInfos, out stringTable, nodesToRead.Count, num);
    foreach (HistoryReadValueIdCollection valueIdCollection in nodesToRead.Batch<HistoryReadValueId, HistoryReadValueIdCollection>(num))
    {
      HistoryReadValueIdCollection batchNodesToRead = valueIdCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<HistoryReadResponse>.ConfiguredTaskAwaiter awaiter = base.HistoryReadAsync(requestHeader, historyReadDetails, timestampsToReturn, releaseContinuationPoints, batchNodesToRead, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        historyReadResponse1 = awaiter.GetResult();
        HistoryReadResultCollection results1 = historyReadResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = historyReadResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchNodesToRead);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchNodesToRead);
        SessionClientBatched.AddResponses<HistoryReadResult, HistoryReadResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, historyReadResponse1.ResponseHeader.StringTable);
        batchNodesToRead = (HistoryReadValueIdCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<HistoryReadResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<HistoryReadResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CHistoryReadAsync\u003Ed__23>(ref awaiter, this);
        return;
      }
    }
    historyReadResponse1.Results = results;
    historyReadResponse1.DiagnosticInfos = diagnosticInfos;
    historyReadResponse1.ResponseHeader.StringTable = stringTable;
    HistoryReadResponse historyReadResponse2 = historyReadResponse1;
    results = (HistoryReadResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return historyReadResponse2;
  }

  public override ResponseHeader Write(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint maxNodesPerWrite = this.OperationLimits.MaxNodesPerWrite;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, nodesToWrite.Count, maxNodesPerWrite);
    foreach (WriteValueCollection writeValueCollection in nodesToWrite.Batch<WriteValue, WriteValueCollection>(maxNodesPerWrite))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.Write(requestHeader, writeValueCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) writeValueCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) writeValueCollection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<WriteResponse> WriteAsync(
    RequestHeader requestHeader,
    WriteValueCollection nodesToWrite,
    CancellationToken ct)
  {
    WriteResponse writeResponse1 = (WriteResponse) null;
    uint maxNodesPerWrite = this.OperationLimits.MaxNodesPerWrite;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, nodesToWrite.Count, maxNodesPerWrite);
    foreach (WriteValueCollection writeValueCollection in nodesToWrite.Batch<WriteValue, WriteValueCollection>(maxNodesPerWrite))
    {
      WriteValueCollection batchNodesToWrite = writeValueCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<WriteResponse>.ConfiguredTaskAwaiter awaiter = base.WriteAsync(requestHeader, batchNodesToWrite, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        writeResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = writeResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = writeResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchNodesToWrite);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchNodesToWrite);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, writeResponse1.ResponseHeader.StringTable);
        batchNodesToWrite = (WriteValueCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<WriteResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<WriteResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CWriteAsync\u003Ed__25>(ref awaiter, this);
        return;
      }
    }
    writeResponse1.Results = results;
    writeResponse1.DiagnosticInfos = diagnosticInfos;
    writeResponse1.ResponseHeader.StringTable = stringTable;
    WriteResponse writeResponse2 = writeResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return writeResponse2;
  }

  public override ResponseHeader HistoryUpdate(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    out HistoryUpdateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint num = this.OperationLimits.MaxNodesPerHistoryUpdateData;
    if (historyUpdateDetails.Count > 0 && historyUpdateDetails[0]?.Body is UpdateEventDetails)
      num = this.OperationLimits.MaxNodesPerHistoryUpdateEvents;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<HistoryUpdateResult, HistoryUpdateResultCollection>(out results, out diagnosticInfos, out stringTable, historyUpdateDetails.Count, num);
    foreach (ExtensionObjectCollection objectCollection in historyUpdateDetails.Batch<ExtensionObject, ExtensionObjectCollection>(num))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      HistoryUpdateResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.HistoryUpdate(requestHeader, objectCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) objectCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) objectCollection);
      SessionClientBatched.AddResponses<HistoryUpdateResult, HistoryUpdateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<HistoryUpdateResponse> HistoryUpdateAsync(
    RequestHeader requestHeader,
    ExtensionObjectCollection historyUpdateDetails,
    CancellationToken ct)
  {
    HistoryUpdateResponse historyUpdateResponse1 = (HistoryUpdateResponse) null;
    uint num = this.OperationLimits.MaxNodesPerHistoryUpdateData;
    if (historyUpdateDetails.Count > 0 && historyUpdateDetails[0].TypeId == (object) DataTypeIds.UpdateEventDetails)
      num = this.OperationLimits.MaxNodesPerHistoryUpdateEvents;
    HistoryUpdateResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<HistoryUpdateResult, HistoryUpdateResultCollection>(out results, out diagnosticInfos, out stringTable, historyUpdateDetails.Count, num);
    foreach (ExtensionObjectCollection objectCollection in historyUpdateDetails.Batch<ExtensionObject, ExtensionObjectCollection>(num))
    {
      ExtensionObjectCollection batchHistoryUpdateDetails = objectCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<HistoryUpdateResponse>.ConfiguredTaskAwaiter awaiter = base.HistoryUpdateAsync(requestHeader, batchHistoryUpdateDetails, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        historyUpdateResponse1 = awaiter.GetResult();
        HistoryUpdateResultCollection results1 = historyUpdateResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = historyUpdateResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchHistoryUpdateDetails);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchHistoryUpdateDetails);
        SessionClientBatched.AddResponses<HistoryUpdateResult, HistoryUpdateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, historyUpdateResponse1.ResponseHeader.StringTable);
        batchHistoryUpdateDetails = (ExtensionObjectCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<HistoryUpdateResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<HistoryUpdateResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CHistoryUpdateAsync\u003Ed__27>(ref awaiter, this);
        return;
      }
    }
    historyUpdateResponse1.Results = results;
    historyUpdateResponse1.DiagnosticInfos = diagnosticInfos;
    historyUpdateResponse1.ResponseHeader.StringTable = stringTable;
    HistoryUpdateResponse historyUpdateResponse2 = historyUpdateResponse1;
    results = (HistoryUpdateResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return historyUpdateResponse2;
  }

  public override ResponseHeader Call(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    out CallMethodResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint nodesPerMethodCall = this.OperationLimits.MaxNodesPerMethodCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<CallMethodResult, CallMethodResultCollection>(out results, out diagnosticInfos, out stringTable, methodsToCall.Count, nodesPerMethodCall);
    foreach (CallMethodRequestCollection requestCollection in methodsToCall.Batch<CallMethodRequest, CallMethodRequestCollection>(nodesPerMethodCall))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      CallMethodResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.Call(requestHeader, requestCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) requestCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) requestCollection);
      SessionClientBatched.AddResponses<CallMethodResult, CallMethodResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<CallResponse> CallAsync(
    RequestHeader requestHeader,
    CallMethodRequestCollection methodsToCall,
    CancellationToken ct)
  {
    CallResponse callResponse1 = (CallResponse) null;
    uint nodesPerMethodCall = this.OperationLimits.MaxNodesPerMethodCall;
    CallMethodResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<CallMethodResult, CallMethodResultCollection>(out results, out diagnosticInfos, out stringTable, methodsToCall.Count, nodesPerMethodCall);
    foreach (CallMethodRequestCollection requestCollection in methodsToCall.Batch<CallMethodRequest, CallMethodRequestCollection>(nodesPerMethodCall))
    {
      CallMethodRequestCollection batchMethodsToCall = requestCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<CallResponse>.ConfiguredTaskAwaiter awaiter = base.CallAsync(requestHeader, batchMethodsToCall, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        callResponse1 = awaiter.GetResult();
        CallMethodResultCollection results1 = callResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = callResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchMethodsToCall);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchMethodsToCall);
        SessionClientBatched.AddResponses<CallMethodResult, CallMethodResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, callResponse1.ResponseHeader.StringTable);
        batchMethodsToCall = (CallMethodRequestCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<CallResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<CallResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CCallAsync\u003Ed__29>(ref awaiter, this);
        return;
      }
    }
    callResponse1.Results = results;
    callResponse1.DiagnosticInfos = diagnosticInfos;
    callResponse1.ResponseHeader.StringTable = stringTable;
    CallResponse callResponse2 = callResponse1;
    results = (CallMethodResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return callResponse2;
  }

  public override ResponseHeader CreateMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    out MonitoredItemCreateResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader monitoredItems = (ResponseHeader) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(out results, out diagnosticInfos, out stringTable, itemsToCreate.Count, monitoredItemsPerCall);
    foreach (MonitoredItemCreateRequestCollection requestCollection in itemsToCreate.Batch<MonitoredItemCreateRequest, MonitoredItemCreateRequestCollection>(monitoredItemsPerCall))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      MonitoredItemCreateResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      monitoredItems = base.CreateMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, requestCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) requestCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) requestCollection);
      SessionClientBatched.AddResponses<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, monitoredItems.StringTable);
    }
    monitoredItems.StringTable = stringTable;
    return monitoredItems;
  }

  public override async Task<CreateMonitoredItemsResponse> CreateMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemCreateRequestCollection itemsToCreate,
    CancellationToken ct)
  {
    CreateMonitoredItemsResponse monitoredItemsResponse = (CreateMonitoredItemsResponse) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    MonitoredItemCreateResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(out results, out diagnosticInfos, out stringTable, itemsToCreate.Count, monitoredItemsPerCall);
    foreach (MonitoredItemCreateRequestCollection requestCollection in itemsToCreate.Batch<MonitoredItemCreateRequest, MonitoredItemCreateRequestCollection>(monitoredItemsPerCall))
    {
      MonitoredItemCreateRequestCollection batchItemsToCreate = requestCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<CreateMonitoredItemsResponse>.ConfiguredTaskAwaiter awaiter = base.CreateMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, batchItemsToCreate, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        monitoredItemsResponse = awaiter.GetResult();
        MonitoredItemCreateResultCollection results1 = monitoredItemsResponse.Results;
        DiagnosticInfoCollection diagnosticInfos1 = monitoredItemsResponse.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchItemsToCreate);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchItemsToCreate);
        SessionClientBatched.AddResponses<MonitoredItemCreateResult, MonitoredItemCreateResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, monitoredItemsResponse.ResponseHeader.StringTable);
        batchItemsToCreate = (MonitoredItemCreateRequestCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<CreateMonitoredItemsResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<CreateMonitoredItemsResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CCreateMonitoredItemsAsync\u003Ed__31>(ref awaiter, this);
        return;
      }
    }
    monitoredItemsResponse.Results = results;
    monitoredItemsResponse.DiagnosticInfos = diagnosticInfos;
    monitoredItemsResponse.ResponseHeader.StringTable = stringTable;
    CreateMonitoredItemsResponse monitoredItemsAsync = monitoredItemsResponse;
    results = (MonitoredItemCreateResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return monitoredItemsAsync;
  }

  public override ResponseHeader ModifyMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    out MonitoredItemModifyResultCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(out results, out diagnosticInfos, out stringTable, itemsToModify.Count, monitoredItemsPerCall);
    foreach (MonitoredItemModifyRequestCollection requestCollection in itemsToModify.Batch<MonitoredItemModifyRequest, MonitoredItemModifyRequestCollection>(monitoredItemsPerCall))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      MonitoredItemModifyResultCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.ModifyMonitoredItems(requestHeader, subscriptionId, timestampsToReturn, requestCollection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) requestCollection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) requestCollection);
      SessionClientBatched.AddResponses<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<ModifyMonitoredItemsResponse> ModifyMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    TimestampsToReturn timestampsToReturn,
    MonitoredItemModifyRequestCollection itemsToModify,
    CancellationToken ct)
  {
    ModifyMonitoredItemsResponse monitoredItemsResponse1 = (ModifyMonitoredItemsResponse) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    MonitoredItemModifyResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(out results, out diagnosticInfos, out stringTable, itemsToModify.Count, monitoredItemsPerCall);
    foreach (MonitoredItemModifyRequestCollection requestCollection in itemsToModify.Batch<MonitoredItemModifyRequest, MonitoredItemModifyRequestCollection>(monitoredItemsPerCall))
    {
      MonitoredItemModifyRequestCollection batchItemsToModify = requestCollection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<ModifyMonitoredItemsResponse>.ConfiguredTaskAwaiter awaiter = base.ModifyMonitoredItemsAsync(requestHeader, subscriptionId, timestampsToReturn, batchItemsToModify, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        monitoredItemsResponse1 = awaiter.GetResult();
        MonitoredItemModifyResultCollection results1 = monitoredItemsResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = monitoredItemsResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchItemsToModify);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchItemsToModify);
        SessionClientBatched.AddResponses<MonitoredItemModifyResult, MonitoredItemModifyResultCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, monitoredItemsResponse1.ResponseHeader.StringTable);
        batchItemsToModify = (MonitoredItemModifyRequestCollection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<ModifyMonitoredItemsResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<ModifyMonitoredItemsResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CModifyMonitoredItemsAsync\u003Ed__33>(ref awaiter, this);
        return;
      }
    }
    monitoredItemsResponse1.Results = results;
    monitoredItemsResponse1.DiagnosticInfos = diagnosticInfos;
    monitoredItemsResponse1.ResponseHeader.StringTable = stringTable;
    ModifyMonitoredItemsResponse monitoredItemsResponse2 = monitoredItemsResponse1;
    results = (MonitoredItemModifyResultCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return monitoredItemsResponse2;
  }

  public override ResponseHeader SetMonitoringMode(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, monitoredItemIds.Count, monitoredItemsPerCall);
    foreach (UInt32Collection uint32Collection in monitoredItemIds.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.SetMonitoringMode(requestHeader, subscriptionId, monitoringMode, uint32Collection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) uint32Collection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) uint32Collection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<SetMonitoringModeResponse> SetMonitoringModeAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    MonitoringMode monitoringMode,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    SetMonitoringModeResponse monitoringModeResponse1 = (SetMonitoringModeResponse) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, monitoredItemIds.Count, monitoredItemsPerCall);
    foreach (UInt32Collection uint32Collection in monitoredItemIds.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
    {
      UInt32Collection batchMonitoredItemIds = uint32Collection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<SetMonitoringModeResponse>.ConfiguredTaskAwaiter awaiter = base.SetMonitoringModeAsync(requestHeader, subscriptionId, monitoringMode, batchMonitoredItemIds, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        monitoringModeResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = monitoringModeResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = monitoringModeResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchMonitoredItemIds);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchMonitoredItemIds);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, monitoringModeResponse1.ResponseHeader.StringTable);
        batchMonitoredItemIds = (UInt32Collection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<SetMonitoringModeResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<SetMonitoringModeResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CSetMonitoringModeAsync\u003Ed__35>(ref awaiter, this);
        return;
      }
    }
    monitoringModeResponse1.Results = results;
    monitoringModeResponse1.DiagnosticInfos = diagnosticInfos;
    monitoringModeResponse1.ResponseHeader.StringTable = stringTable;
    SetMonitoringModeResponse monitoringModeResponse2 = monitoringModeResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return monitoringModeResponse2;
  }

  public override ResponseHeader SetTriggering(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    out StatusCodeCollection addResults,
    out DiagnosticInfoCollection addDiagnosticInfos,
    out StatusCodeCollection removeResults,
    out DiagnosticInfoCollection removeDiagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out addResults, out addDiagnosticInfos, out stringTable, linksToAdd.Count, monitoredItemsPerCall);
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out removeResults, out removeDiagnosticInfos, out StringCollection _, linksToRemove.Count, monitoredItemsPerCall);
    foreach (UInt32Collection uint32Collection1 in linksToAdd.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
    {
      UInt32Collection uint32Collection2;
      if (monitoredItemsPerCall == 0U)
      {
        uint32Collection2 = linksToRemove;
        linksToRemove = new UInt32Collection();
      }
      else if ((long) uint32Collection1.Count < (long) monitoredItemsPerCall)
      {
        uint32Collection2 = new UInt32Collection(linksToRemove.Take<uint>((int) monitoredItemsPerCall - uint32Collection1.Count));
        linksToRemove = new UInt32Collection(linksToRemove.Skip<uint>(uint32Collection2.Count));
      }
      else
        uint32Collection2 = new UInt32Collection();
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection addResults1;
      DiagnosticInfoCollection addDiagnosticInfos1;
      StatusCodeCollection removeResults1;
      DiagnosticInfoCollection removeDiagnosticInfos1;
      responseHeader = base.SetTriggering(requestHeader, subscriptionId, triggeringItemId, uint32Collection1, uint32Collection2, out addResults1, out addDiagnosticInfos1, out removeResults1, out removeDiagnosticInfos1);
      ClientBase.ValidateResponse((IList) addResults1, (IList) uint32Collection1);
      ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos1, (IList) uint32Collection1);
      ClientBase.ValidateResponse((IList) removeResults1, (IList) uint32Collection2);
      ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos1, (IList) uint32Collection2);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults1, addDiagnosticInfos1, responseHeader.StringTable);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults1, removeDiagnosticInfos1, responseHeader.StringTable);
    }
    if (linksToRemove.Count > 0)
    {
      foreach (UInt32Collection uint32Collection3 in linksToRemove.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
      {
        if (requestHeader != null)
          requestHeader.RequestHandle = 0U;
        UInt32Collection uint32Collection4 = new UInt32Collection();
        StatusCodeCollection addResults2;
        DiagnosticInfoCollection addDiagnosticInfos2;
        StatusCodeCollection removeResults2;
        DiagnosticInfoCollection removeDiagnosticInfos2;
        responseHeader = base.SetTriggering(requestHeader, subscriptionId, triggeringItemId, uint32Collection4, uint32Collection3, out addResults2, out addDiagnosticInfos2, out removeResults2, out removeDiagnosticInfos2);
        ClientBase.ValidateResponse((IList) addResults2, (IList) uint32Collection4);
        ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos2, (IList) uint32Collection4);
        ClientBase.ValidateResponse((IList) removeResults2, (IList) uint32Collection3);
        ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos2, (IList) uint32Collection3);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults2, addDiagnosticInfos2, responseHeader.StringTable);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults2, removeDiagnosticInfos2, responseHeader.StringTable);
      }
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<SetTriggeringResponse> SetTriggeringAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    uint triggeringItemId,
    UInt32Collection linksToAdd,
    UInt32Collection linksToRemove,
    CancellationToken ct)
  {
    SetTriggeringResponse triggeringResponse1 = (SetTriggeringResponse) null;
    uint operationLimit = this.OperationLimits.MaxMonitoredItemsPerCall;
    StatusCodeCollection addResults;
    DiagnosticInfoCollection addDiagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out addResults, out addDiagnosticInfos, out stringTable, linksToAdd.Count, operationLimit);
    StatusCodeCollection removeResults;
    DiagnosticInfoCollection removeDiagnosticInfos;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out removeResults, out removeDiagnosticInfos, out StringCollection _, linksToRemove.Count, operationLimit);
    UInt32Collection batchLinksToAdd;
    UInt32Collection batchLinksToRemove;
    ConfiguredTaskAwaitable<SetTriggeringResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter;
    int num;
    foreach (UInt32Collection uint32Collection in linksToAdd.Batch<uint, UInt32Collection>(operationLimit))
    {
      batchLinksToAdd = uint32Collection;
      if (operationLimit == 0U)
      {
        batchLinksToRemove = linksToRemove;
        linksToRemove = new UInt32Collection();
      }
      else if ((long) batchLinksToAdd.Count < (long) operationLimit)
      {
        batchLinksToRemove = new UInt32Collection(linksToRemove.Take<uint>((int) operationLimit - batchLinksToAdd.Count));
        linksToRemove = new UInt32Collection(linksToRemove.Skip<uint>(batchLinksToRemove.Count));
      }
      else
        batchLinksToRemove = new UInt32Collection();
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<SetTriggeringResponse>.ConfiguredTaskAwaiter awaiter = base.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, batchLinksToAdd, batchLinksToRemove, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        triggeringResponse1 = awaiter.GetResult();
        StatusCodeCollection addResults1 = triggeringResponse1.AddResults;
        DiagnosticInfoCollection addDiagnosticInfos1 = triggeringResponse1.AddDiagnosticInfos;
        StatusCodeCollection removeResults1 = triggeringResponse1.RemoveResults;
        DiagnosticInfoCollection removeDiagnosticInfos1 = triggeringResponse1.RemoveDiagnosticInfos;
        ClientBase.ValidateResponse((IList) addResults1, (IList) batchLinksToAdd);
        ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos1, (IList) batchLinksToAdd);
        ClientBase.ValidateResponse((IList) removeResults1, (IList) batchLinksToRemove);
        ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos1, (IList) batchLinksToRemove);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults1, addDiagnosticInfos1, triggeringResponse1.ResponseHeader.StringTable);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults1, removeDiagnosticInfos1, triggeringResponse1.ResponseHeader.StringTable);
        batchLinksToRemove = (UInt32Collection) null;
        batchLinksToAdd = (UInt32Collection) null;
      }
      else
      {
        num = 0;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<SetTriggeringResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CSetTriggeringAsync\u003Ed__37>(ref awaiter, this);
        return;
      }
    }
    if (linksToRemove.Count > 0)
    {
      foreach (UInt32Collection uint32Collection in linksToRemove.Batch<uint, UInt32Collection>(operationLimit))
      {
        batchLinksToAdd = uint32Collection;
        if (requestHeader != null)
          requestHeader.RequestHandle = 0U;
        batchLinksToRemove = new UInt32Collection();
        ConfiguredTaskAwaitable<SetTriggeringResponse>.ConfiguredTaskAwaiter awaiter = base.SetTriggeringAsync(requestHeader, subscriptionId, triggeringItemId, batchLinksToRemove, batchLinksToAdd, ct).ConfigureAwait(false).GetAwaiter();
        if (awaiter.IsCompleted)
        {
          triggeringResponse1 = awaiter.GetResult();
          StatusCodeCollection addResults2 = triggeringResponse1.AddResults;
          DiagnosticInfoCollection addDiagnosticInfos2 = triggeringResponse1.AddDiagnosticInfos;
          StatusCodeCollection removeResults2 = triggeringResponse1.RemoveResults;
          DiagnosticInfoCollection removeDiagnosticInfos2 = triggeringResponse1.RemoveDiagnosticInfos;
          ClientBase.ValidateResponse((IList) addResults2, (IList) batchLinksToRemove);
          ClientBase.ValidateDiagnosticInfos(addDiagnosticInfos2, (IList) batchLinksToRemove);
          ClientBase.ValidateResponse((IList) removeResults2, (IList) batchLinksToAdd);
          ClientBase.ValidateDiagnosticInfos(removeDiagnosticInfos2, (IList) batchLinksToAdd);
          SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref addResults, ref addDiagnosticInfos, ref stringTable, addResults2, addDiagnosticInfos2, triggeringResponse1.ResponseHeader.StringTable);
          SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref removeResults, ref removeDiagnosticInfos, ref stringTable, removeResults2, removeDiagnosticInfos2, triggeringResponse1.ResponseHeader.StringTable);
          batchLinksToRemove = (UInt32Collection) null;
          batchLinksToAdd = (UInt32Collection) null;
        }
        else
        {
          num = 1;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<SetTriggeringResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CSetTriggeringAsync\u003Ed__37>(ref awaiter, this);
          return;
        }
      }
    }
    triggeringResponse1.AddResults = addResults;
    triggeringResponse1.AddDiagnosticInfos = addDiagnosticInfos;
    triggeringResponse1.RemoveResults = removeResults;
    triggeringResponse1.RemoveDiagnosticInfos = removeDiagnosticInfos;
    triggeringResponse1.ResponseHeader.StringTable = stringTable;
    SetTriggeringResponse triggeringResponse2 = triggeringResponse1;
    addResults = (StatusCodeCollection) null;
    addDiagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    removeResults = (StatusCodeCollection) null;
    removeDiagnosticInfos = (DiagnosticInfoCollection) null;
    return triggeringResponse2;
  }

  public override ResponseHeader DeleteMonitoredItems(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    out StatusCodeCollection results,
    out DiagnosticInfoCollection diagnosticInfos)
  {
    ResponseHeader responseHeader = (ResponseHeader) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, monitoredItemIds.Count, monitoredItemsPerCall);
    foreach (UInt32Collection uint32Collection in monitoredItemIds.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
    {
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      StatusCodeCollection results1;
      DiagnosticInfoCollection diagnosticInfos1;
      responseHeader = base.DeleteMonitoredItems(requestHeader, subscriptionId, uint32Collection, out results1, out diagnosticInfos1);
      ClientBase.ValidateResponse((IList) results1, (IList) uint32Collection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) uint32Collection);
      SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, responseHeader.StringTable);
    }
    responseHeader.StringTable = stringTable;
    return responseHeader;
  }

  public override async Task<DeleteMonitoredItemsResponse> DeleteMonitoredItemsAsync(
    RequestHeader requestHeader,
    uint subscriptionId,
    UInt32Collection monitoredItemIds,
    CancellationToken ct)
  {
    DeleteMonitoredItemsResponse monitoredItemsResponse1 = (DeleteMonitoredItemsResponse) null;
    uint monitoredItemsPerCall = this.OperationLimits.MaxMonitoredItemsPerCall;
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    StringCollection stringTable;
    SessionClientBatched.InitResponseCollections<StatusCode, StatusCodeCollection>(out results, out diagnosticInfos, out stringTable, monitoredItemIds.Count, monitoredItemsPerCall);
    foreach (UInt32Collection uint32Collection in monitoredItemIds.Batch<uint, UInt32Collection>(monitoredItemsPerCall))
    {
      UInt32Collection batchMonitoredItemIds = uint32Collection;
      if (requestHeader != null)
        requestHeader.RequestHandle = 0U;
      ConfiguredTaskAwaitable<DeleteMonitoredItemsResponse>.ConfiguredTaskAwaiter awaiter = base.DeleteMonitoredItemsAsync(requestHeader, subscriptionId, batchMonitoredItemIds, ct).ConfigureAwait(false).GetAwaiter();
      if (awaiter.IsCompleted)
      {
        monitoredItemsResponse1 = awaiter.GetResult();
        StatusCodeCollection results1 = monitoredItemsResponse1.Results;
        DiagnosticInfoCollection diagnosticInfos1 = monitoredItemsResponse1.DiagnosticInfos;
        ClientBase.ValidateResponse((IList) results1, (IList) batchMonitoredItemIds);
        ClientBase.ValidateDiagnosticInfos(diagnosticInfos1, (IList) batchMonitoredItemIds);
        SessionClientBatched.AddResponses<StatusCode, StatusCodeCollection>(ref results, ref diagnosticInfos, ref stringTable, results1, diagnosticInfos1, monitoredItemsResponse1.ResponseHeader.StringTable);
        batchMonitoredItemIds = (UInt32Collection) null;
      }
      else
      {
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 0;
        ConfiguredTaskAwaitable<DeleteMonitoredItemsResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<DeleteMonitoredItemsResponse>.ConfiguredTaskAwaiter, SessionClientBatched.\u003CDeleteMonitoredItemsAsync\u003Ed__39>(ref awaiter, this);
        return;
      }
    }
    monitoredItemsResponse1.Results = results;
    monitoredItemsResponse1.DiagnosticInfos = diagnosticInfos;
    monitoredItemsResponse1.ResponseHeader.StringTable = stringTable;
    DeleteMonitoredItemsResponse monitoredItemsResponse2 = monitoredItemsResponse1;
    results = (StatusCodeCollection) null;
    diagnosticInfos = (DiagnosticInfoCollection) null;
    stringTable = (StringCollection) null;
    return monitoredItemsResponse2;
  }

  private static void InitResponseCollections<T, C>(
    out C results,
    out DiagnosticInfoCollection diagnosticInfos,
    out StringCollection stringTable,
    int count,
    uint operationLimit)
    where C : List<T>, new()
  {
    if ((long) count <= (long) operationLimit)
    {
      results = default (C);
      diagnosticInfos = (DiagnosticInfoCollection) null;
      stringTable = (StringCollection) null;
    }
    else
    {
      ref C local = ref results;
      C c = new C();
      c.Capacity = count;
      local = c;
      diagnosticInfos = new DiagnosticInfoCollection(count);
      stringTable = new StringCollection();
    }
  }

  private static void AddResponses<T, C>(
    ref C results,
    ref DiagnosticInfoCollection diagnosticInfos,
    ref StringCollection stringTable,
    C batchedResults,
    DiagnosticInfoCollection batchedDiagnosticInfos,
    StringCollection batchedStringTable)
    where C : List<T>
  {
    if ((object) results == null)
    {
      results = batchedResults;
      diagnosticInfos = batchedDiagnosticInfos;
      stringTable = batchedStringTable;
    }
    else
    {
      bool flag1 = diagnosticInfos.Count > 0;
      bool flag2 = diagnosticInfos.Count == 0 && results.Count > 0;
      bool flag3 = batchedDiagnosticInfos.Count > 0;
      int num = 0;
      if (flag3 & flag2)
        num = results.Count;
      else if (!flag3 & flag1)
        num = batchedResults.Count;
      if (num > 0)
      {
        for (int index = 0; index < num; ++index)
          diagnosticInfos.Add((DiagnosticInfo) null);
      }
      else if (batchedStringTable.Count > 0)
      {
        int count = stringTable.Count;
        foreach (DiagnosticInfo batchedDiagnosticInfo in (List<DiagnosticInfo>) batchedDiagnosticInfos)
          SessionClientBatched.UpdateDiagnosticInfoIndexes(batchedDiagnosticInfo, count);
      }
      results.AddRange((IEnumerable<T>) batchedResults);
      diagnosticInfos.AddRange((IEnumerable<DiagnosticInfo>) batchedDiagnosticInfos);
      stringTable.AddRange((IEnumerable<string>) batchedStringTable);
    }
  }

  private static void UpdateDiagnosticInfoIndexes(
    DiagnosticInfo diagnosticInfo,
    int stringTableOffset)
  {
    for (int index = 0; diagnosticInfo != null && index++ < DiagnosticInfo.MaxInnerDepth; diagnosticInfo = diagnosticInfo.InnerDiagnosticInfo)
    {
      if (diagnosticInfo.LocalizedText >= 0)
        diagnosticInfo.LocalizedText += stringTableOffset;
      if (diagnosticInfo.Locale >= 0)
        diagnosticInfo.Locale += stringTableOffset;
      if (diagnosticInfo.NamespaceUri >= 0)
        diagnosticInfo.NamespaceUri += stringTableOffset;
      if (diagnosticInfo.SymbolicId >= 0)
        diagnosticInfo.SymbolicId += stringTableOffset;
    }
  }
}
