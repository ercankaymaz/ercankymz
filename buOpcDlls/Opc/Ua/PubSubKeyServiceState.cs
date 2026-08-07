// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubKeyServiceState
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
public class PubSubKeyServiceState(NodeState parent) : BaseObjectState(parent)
{
  private const string GetSecurityKeys_InitializationString = "//////////8EYYIKBAAAAAAADwAAAEdldFNlY3VyaXR5S2V5cwEAIz4ALwEAIz4jPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACQ+AC4ARCQ+AACWAwAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIAAAAA8AAABTdGFydGluZ1Rva2VuSWQBACAB/////wAAAAAAAQAqAQEgAAAAEQAAAFJlcXVlc3RlZEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAlPgAuAEQlPgAAlgUAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHQAAAAwAAABGaXJzdFRva2VuSWQBACAB/////wAAAAAAAQAqAQEXAAAABAAAAEtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string GetSecurityGroup_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAEdldFNlY3VyaXR5R3JvdXABACY+AC8BACY+Jj4AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAnPgAuAEQnPgAAlgEAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAoPgAuAEQoPgAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string SecurityGroups_InitializationString = "//////////8EYIAKAQAAAAAADgAAAFNlY3VyaXR5R3JvdXBzAQApPgAvAQBcPCk+AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAKj4ALwEAZTwqPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACs+AC4ARCs+AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAsPgAuAEQsPgAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAC0+AC8BAGg8LT4AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAuPgAuAEQuPgAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YktleVNlcnZpY2VUeXBlSW5zdGFuY2UBACI+AQAiPiI+AAD/////AwAAAARhggoEAAAAAAAPAAAAR2V0U2VjdXJpdHlLZXlzAQAjPgAvAQAjPiM+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJD4ALgBEJD4AAJYDAAAAAQAqAQEeAAAADwAAAFNlY3VyaXR5R3JvdXBJZAAM/////wAAAAAAAQAqAQEgAAAADwAAAFN0YXJ0aW5nVG9rZW5JZAEAIAH/////AAAAAAABACoBASAAAAARAAAAUmVxdWVzdGVkS2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACU+AC4ARCU+AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEdAAAADAAAAEZpcnN0VG9rZW5JZAEAIAH/////AAAAAAABACoBARcAAAAEAAAAS2V5cwAPAQAAAAEAAAAAAAAAAAEAKgEBHgAAAA0AAABUaW1lVG9OZXh0S2V5AQAiAf////8AAAAAAAEAKgEBHAAAAAsAAABLZXlMaWZldGltZQEAIgH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAQAAAAR2V0U2VjdXJpdHlHcm91cAEAJj4ALwEAJj4mPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACc+AC4ARCc+AACWAQAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACg+AC4ARCg+AACWAQAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAOAAAAU2VjdXJpdHlHcm91cHMBACk+AC8BAFw8KT4AAP////8CAAAABGGCCgQAAAAAABAAAABBZGRTZWN1cml0eUdyb3VwAQAqPgAvAQBlPCo+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAKz4ALgBEKz4AAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACw+AC4ARCw+AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAATAAAAUmVtb3ZlU2VjdXJpdHlHcm91cAEALT4ALwEAaDwtPgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAC4+AC4ARC4+AACWAQAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private GetSecurityKeysMethodState m_getSecurityKeysMethod;
  private GetSecurityGroupMethodState m_getSecurityGroupMethod;
  private SecurityGroupFolderState m_securityGroups;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15906U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YktleVNlcnZpY2VUeXBlSW5zdGFuY2UBACI+AQAiPiI+AAD/////AwAAAARhggoEAAAAAAAPAAAAR2V0U2VjdXJpdHlLZXlzAQAjPgAvAQAjPiM+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAJD4ALgBEJD4AAJYDAAAAAQAqAQEeAAAADwAAAFNlY3VyaXR5R3JvdXBJZAAM/////wAAAAAAAQAqAQEgAAAADwAAAFN0YXJ0aW5nVG9rZW5JZAEAIAH/////AAAAAAABACoBASAAAAARAAAAUmVxdWVzdGVkS2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACU+AC4ARCU+AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEdAAAADAAAAEZpcnN0VG9rZW5JZAEAIAH/////AAAAAAABACoBARcAAAAEAAAAS2V5cwAPAQAAAAEAAAAAAAAAAAEAKgEBHgAAAA0AAABUaW1lVG9OZXh0S2V5AQAiAf////8AAAAAAAEAKgEBHAAAAAsAAABLZXlMaWZldGltZQEAIgH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAQAAAAR2V0U2VjdXJpdHlHcm91cAEAJj4ALwEAJj4mPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACc+AC4ARCc+AACWAQAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACg+AC4ARCg+AACWAQAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAAOAAAAU2VjdXJpdHlHcm91cHMBACk+AC8BAFw8KT4AAP////8CAAAABGGCCgQAAAAAABAAAABBZGRTZWN1cml0eUdyb3VwAQAqPgAvAQBlPCo+AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAKz4ALgBEKz4AAJYFAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5R3JvdXBOYW1lAAz/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACoBASAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQAB/////8AAAAAAAEAKgEBHgAAAA8AAABNYXhQYXN0S2V5Q291bnQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBACw+AC4ARCw+AACWAgAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAATAAAAUmVtb3ZlU2VjdXJpdHlHcm91cAEALT4ALwEAaDwtPgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAC4+AC4ARC4+AACWAQAAAAEAKgEBIgAAABMAAABTZWN1cml0eUdyb3VwTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    if (this.GetSecurityKeys != null)
      this.GetSecurityKeys.Initialize(context, "//////////8EYYIKBAAAAAAADwAAAEdldFNlY3VyaXR5S2V5cwEAIz4ALwEAIz4jPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACQ+AC4ARCQ+AACWAwAAAAEAKgEBHgAAAA8AAABTZWN1cml0eUdyb3VwSWQADP////8AAAAAAAEAKgEBIAAAAA8AAABTdGFydGluZ1Rva2VuSWQBACAB/////wAAAAAAAQAqAQEgAAAAEQAAAFJlcXVlc3RlZEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAlPgAuAEQlPgAAlgUAAAABACoBASAAAAARAAAAU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKgEBHQAAAAwAAABGaXJzdFRva2VuSWQBACAB/////wAAAAAAAQAqAQEXAAAABAAAAEtleXMADwEAAAABAAAAAAAAAAABACoBAR4AAAANAAAAVGltZVRvTmV4dEtleQEAIgH/////AAAAAAABACoBARwAAAALAAAAS2V5TGlmZXRpbWUBACIB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.GetSecurityGroup != null)
      this.GetSecurityGroup.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAEdldFNlY3VyaXR5R3JvdXABACY+AC8BACY+Jj4AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAnPgAuAEQnPgAAlgEAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAoPgAuAEQoPgAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.SecurityGroups == null)
      return;
    this.SecurityGroups.Initialize(context, "//////////8EYIAKAQAAAAAADgAAAFNlY3VyaXR5R3JvdXBzAQApPgAvAQBcPCk+AAD/////AgAAAARhggoEAAAAAAAQAAAAQWRkU2VjdXJpdHlHcm91cAEAKj4ALwEAZTwqPgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBACs+AC4ARCs+AACWBQAAAAEAKgEBIAAAABEAAABTZWN1cml0eUdyb3VwTmFtZQAM/////wAAAAAAAQAqAQEcAAAACwAAAEtleUxpZmV0aW1lAQAiAf////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAqAQEgAAAAEQAAAE1heEZ1dHVyZUtleUNvdW50AAf/////AAAAAAABACoBAR4AAAAPAAAATWF4UGFzdEtleUNvdW50AAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAsPgAuAEQsPgAAlgIAAAABACoBAR4AAAAPAAAAU2VjdXJpdHlHcm91cElkAAz/////AAAAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAFJlbW92ZVNlY3VyaXR5R3JvdXABAC0+AC8BAGg8LT4AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAuPgAuAEQuPgAAlgEAAAABACoBASIAAAATAAAAU2VjdXJpdHlHcm91cE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public GetSecurityKeysMethodState GetSecurityKeys
  {
    get => this.m_getSecurityKeysMethod;
    set
    {
      if (this.m_getSecurityKeysMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getSecurityKeysMethod = value;
    }
  }

  public GetSecurityGroupMethodState GetSecurityGroup
  {
    get => this.m_getSecurityGroupMethod;
    set
    {
      if (this.m_getSecurityGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getSecurityGroupMethod = value;
    }
  }

  public SecurityGroupFolderState SecurityGroups
  {
    get => this.m_securityGroups;
    set
    {
      if (this.m_securityGroups != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityGroups = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_getSecurityKeysMethod != null)
      children.Add((BaseInstanceState) this.m_getSecurityKeysMethod);
    if (this.m_getSecurityGroupMethod != null)
      children.Add((BaseInstanceState) this.m_getSecurityGroupMethod);
    if (this.m_securityGroups != null)
      children.Add((BaseInstanceState) this.m_securityGroups);
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
      case "GetSecurityKeys":
        if (createOrReplace && this.GetSecurityKeys == null)
          this.GetSecurityKeys = replacement != null ? (GetSecurityKeysMethodState) replacement : new GetSecurityKeysMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GetSecurityKeys;
        break;
      case "GetSecurityGroup":
        if (createOrReplace && this.GetSecurityGroup == null)
          this.GetSecurityGroup = replacement != null ? (GetSecurityGroupMethodState) replacement : new GetSecurityGroupMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GetSecurityGroup;
        break;
      case "SecurityGroups":
        if (createOrReplace && this.SecurityGroups == null)
          this.SecurityGroups = replacement != null ? (SecurityGroupFolderState) replacement : new SecurityGroupFolderState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityGroups;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
