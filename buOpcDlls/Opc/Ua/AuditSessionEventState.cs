// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditSessionEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditSessionEventState(NodeState parent) : AuditSecurityEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0U2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAVCAEAFQgVCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALQMAC4ARLQMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALUMAC4ARLUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC2DAAuAES2DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAtwwALgBEtwwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALgMAC4ARLgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC5DAAuAES5DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC7DAAuAES7DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALwMAC4ARLwMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAL0MAC4ARL0MAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAvgwALgBEvgwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQC/DAAuAES/DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDADAAuAETADAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDBDAAuAETBDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQAWCAAuAEQWCAAAABH/////AQH/////AAAAAA==";
  private PropertyState<NodeId> m_sessionId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2069U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0U2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAVCAEAFQgVCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALQMAC4ARLQMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALUMAC4ARLUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC2DAAuAES2DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAtwwALgBEtwwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALgMAC4ARLgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC5DAAuAES5DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC7DAAuAES7DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALwMAC4ARLwMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAL0MAC4ARL0MAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAvgwALgBEvgwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQC/DAAuAES/DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDADAAuAETADAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDBDAAuAETBDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQAWCAAuAEQWCAAAABH/////AQH/////AAAAAA==");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  public PropertyState<NodeId> SessionId
  {
    get => this.m_sessionId;
    set
    {
      if (this.m_sessionId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_sessionId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_sessionId != null)
      children.Add((BaseInstanceState) this.m_sessionId);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    if (browseName.Name == "SessionId")
    {
      if (createOrReplace && this.SessionId == null)
        this.SessionId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.SessionId;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
