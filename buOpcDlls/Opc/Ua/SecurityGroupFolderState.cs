// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SecurityGroupFolderState
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
public class SecurityGroupFolderState(NodeState parent) : FolderState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNlY3VyaXR5R3JvdXBGb2xkZXJUeXBlSW5zdGFuY2UBAFw8AQBcPFw8AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAZTwALwEAZTxlPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGY8AC4ARGY8AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBnPAAuAERnPAAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAGg8AC8BAGg8aDwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBpPAAuAERpPAAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private AddSecurityGroupMethodState m_addSecurityGroupMethod;
  private RemoveSecurityGroupMethodState m_removeSecurityGroupMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15452U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlY3VyaXR5R3JvdXBGb2xkZXJUeXBlSW5zdGFuY2UBAFw8AQBcPFw8AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAZTwALwEAZTxlPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGY8AC4ARGY8AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBnPAAuAERnPAAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAGg8AC8BAGg8aDwAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBpPAAuAERpPAAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public AddSecurityGroupMethodState AddSecurityGroup
  {
    get => this.m_addSecurityGroupMethod;
    set
    {
      if (this.m_addSecurityGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addSecurityGroupMethod = value;
    }
  }

  public RemoveSecurityGroupMethodState RemoveSecurityGroup
  {
    get => this.m_removeSecurityGroupMethod;
    set
    {
      if (this.m_removeSecurityGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeSecurityGroupMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_addSecurityGroupMethod != null)
      children.Add((BaseInstanceState) this.m_addSecurityGroupMethod);
    if (this.m_removeSecurityGroupMethod != null)
      children.Add((BaseInstanceState) this.m_removeSecurityGroupMethod);
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
    switch (browseName.Name)
    {
      case "AddSecurityGroup":
        if (createOrReplace && this.AddSecurityGroup == null)
          this.AddSecurityGroup = replacement != null ? (AddSecurityGroupMethodState) replacement : new AddSecurityGroupMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddSecurityGroup;
        break;
      case "RemoveSecurityGroup":
        if (createOrReplace && this.RemoveSecurityGroup == null)
          this.RemoveSecurityGroup = replacement != null ? (RemoveSecurityGroupMethodState) replacement : new RemoveSecurityGroupMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveSecurityGroup;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
