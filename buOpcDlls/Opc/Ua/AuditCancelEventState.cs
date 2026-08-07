// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCancelEventState
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
public class AuditCancelEventState(NodeState parent) : AuditSessionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAEF1ZGl0Q2FuY2VsRXZlbnRUeXBlSW5zdGFuY2UBAB4IAQAeCB4IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA8wwALgBE8wwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA9AwALgBE9AwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAPUMAC4ARPUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQD2DAAuAET2DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA9wwALgBE9wwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAPgMAC4ARPgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPoMAC4ARPoMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA+wwALgBE+wwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA/AwALgBE/AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQD9DAAuAET9DAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAP4MAC4ARP4MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAP8MAC4ARP8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAANAC4ARAANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAAENAC4ARAENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZXF1ZXN0SGFuZGxlAQAfCAAuAEQfCAAAAAf/////AQH/////AAAAAA==";
  private PropertyState<uint> m_requestHandle;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2078U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAEF1ZGl0Q2FuY2VsRXZlbnRUeXBlSW5zdGFuY2UBAB4IAQAeCB4IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA8wwALgBE8wwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA9AwALgBE9AwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAPUMAC4ARPUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQD2DAAuAET2DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA9wwALgBE9wwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAPgMAC4ARPgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPoMAC4ARPoMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA+wwALgBE+wwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA/AwALgBE/AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQD9DAAuAET9DAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAP4MAC4ARP4MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAP8MAC4ARP8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAANAC4ARAANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAAENAC4ARAENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZXF1ZXN0SGFuZGxlAQAfCAAuAEQfCAAAAAf/////AQH/////AAAAAA==");
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

  public PropertyState<uint> RequestHandle
  {
    get => this.m_requestHandle;
    set
    {
      if (this.m_requestHandle != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_requestHandle = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_requestHandle != null)
      children.Add((BaseInstanceState) this.m_requestHandle);
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
    if (browseName.Name == "RequestHandle")
    {
      if (createOrReplace && this.RequestHandle == null)
        this.RequestHandle = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.RequestHandle;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
