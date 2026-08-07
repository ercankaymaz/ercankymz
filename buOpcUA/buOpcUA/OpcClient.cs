// Decompiled with JetBrains decompiler
// Type: buOpcUA.OpcClient
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace buOpcUA;

public class OpcClient
{
  public static byte f00000F;
  internal readonly string \u0001;
  private readonly string \u0002;
  public readonly NodeId _firstNode;

  public Session Session { get; [param: In] private set; }

  public bool IsConnected
  {
    get => ((OpcClient.\u0001) this).\u0001;
    set => ((OpcClient.\u0001) this).\u0001 = value;
  }

  public OpcClient(string applicationName, string serverUrl, string firstNode)
  {
    this.\u0001 = applicationName;
    this.\u0002 = serverUrl;
    this._firstNode = new NodeId(firstNode);
  }

  private void \u0001([In] ISession obj0, [In] KeepAliveEventArgs obj1)
  {
    if ((obj0 != null ? 0 : (!obj0.Connected ? 1 : 0)) != 0)
      this.IsConnected = false;
    else if ((obj1.Status == null ? 0 : (ServiceResult.IsNotGood(obj1.Status) ? 1 : 0)) != 0)
      this.IsConnected = false;
    else
      this.IsConnected = true;
  }

  public Task<Session> ConnectAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OpcClient.\u0001 stateMachine = new OpcClient.\u0001();
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = AsyncTaskMethodBuilder<Session>.Create();
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = this;
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001.Start<OpcClient.\u0001>(ref stateMachine);
    // ISSUE: reference to a compiler-generated field
    return stateMachine.\u0001.Task;
  }

  public Task DisconnectAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OpcClient.\u0002 stateMachine = new OpcClient.\u0002();
    // ISSUE: reference to a compiler-generated field
    ((OpcClient.\u0003) stateMachine).\u0001 = AsyncTaskMethodBuilder.Create();
    // ISSUE: reference to a compiler-generated field
    ((OpcClient.\u0003) stateMachine).\u0001 = this;
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((OpcClient.\u0003) stateMachine).\u0001.Start<OpcClient.\u0002>(ref stateMachine);
    // ISSUE: reference to a compiler-generated field
    return ((OpcClient.\u0003) stateMachine).\u0001.Task;
  }

  public Task ReconnectAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OpcClient.\u0003 stateMachine = new OpcClient.\u0003();
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = AsyncTaskMethodBuilder.Create();
    // ISSUE: reference to a compiler-generated field
    ((OpcUaConnector.\u0001) stateMachine).\u0001 = this;
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    stateMachine.\u0001.Start<OpcClient.\u0003>(ref stateMachine);
    // ISSUE: reference to a compiler-generated field
    return stateMachine.\u0001.Task;
  }

  public Dictionary<string, string> BrowseAllNodes(NodeId startNodeId)
  {
    Queue<NodeId> nodeIdQueue = new Queue<NodeId>();
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    nodeIdQueue.Enqueue(startNodeId);
    while (nodeIdQueue.Count > 0)
    {
      NodeId nodeId1 = nodeIdQueue.Dequeue();
      try
      {
        BrowseDescription browseDescription = new BrowseDescription()
        {
          NodeId = nodeId1,
          BrowseDirection = BrowseDirection.Forward,
          ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
          IncludeSubtypes = true,
          NodeClassMask = 3,
          ResultMask = 63 /*0x3F*/
        };
        Session session = this.Session;
        BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
        nodesToBrowse.Add(browseDescription);
        BrowseResultCollection resultCollection;
        ref BrowseResultCollection local1 = ref resultCollection;
        DiagnosticInfoCollection diagnosticInfoCollection;
        ref DiagnosticInfoCollection local2 = ref diagnosticInfoCollection;
        session.Browse((RequestHeader) null, (ViewDescription) null, 0U, nodesToBrowse, out local1, out local2);
        if ((resultCollection == null ? 0 : (resultCollection.Count > 0 ? 1 : 0)) != 0)
        {
          foreach (ReferenceDescription reference in (List<ReferenceDescription>) resultCollection[0].References)
          {
            NodeId nodeId2 = ExpandedNodeId.ToNodeId(reference.NodeId, this.Session.NamespaceUris);
            dictionary.Add(reference.BrowseName.Name, nodeId2.ToString());
            if (nodeId2 != (object) null)
              nodeIdQueue.Enqueue(nodeId2);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Hata: " + ex.Message);
      }
    }
    return dictionary;
  }

  public void Dispose() => this.Session?.Dispose();
}
