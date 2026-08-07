// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IPriorityMappingEntryState
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
public class IPriorityMappingEntryState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string PriorityValue_PCP_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAAA==";
  private const string PriorityValue_DSCP_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAFByaW9yaXR5VmFsdWVfRFNDUAEAkV4ALwA/kV4AAAAH/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAElQcmlvcml0eU1hcHBpbmdFbnRyeVR5cGVJbnN0YW5jZQEAjV4BAI1ejV4AAP////8EAAAAFWCJCgIAAAAAAAoAAABNYXBwaW5nVXJpAQCOXgAvAD+OXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAAUHJpb3JpdHlMYWJlbAEAj14ALwA/j14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHJpb3JpdHlWYWx1ZV9EU0NQAQCRXgAvAD+RXgAAAAf/////AQH/////AAAAAA==";
  private BaseDataVariableState<string> m_mappingUri;
  private BaseDataVariableState<string> m_priorityLabel;
  private BaseDataVariableState<byte> m_priorityValue_PCP;
  private BaseDataVariableState<uint> m_priorityValue_DSCP;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24205U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAElQcmlvcml0eU1hcHBpbmdFbnRyeVR5cGVJbnN0YW5jZQEAjV4BAI1ejV4AAP////8EAAAAFWCJCgIAAAAAAAoAAABNYXBwaW5nVXJpAQCOXgAvAD+OXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAAUHJpb3JpdHlMYWJlbAEAj14ALwA/j14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHJpb3JpdHlWYWx1ZV9EU0NQAQCRXgAvAD+RXgAAAAf/////AQH/////AAAAAA==");
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
    if (this.PriorityValue_PCP != null)
      this.PriorityValue_PCP.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAAA==");
    if (this.PriorityValue_DSCP == null)
      return;
    this.PriorityValue_DSCP.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAFByaW9yaXR5VmFsdWVfRFNDUAEAkV4ALwA/kV4AAAAH/////wEB/////wAAAAA=");
  }

  public BaseDataVariableState<string> MappingUri
  {
    get => this.m_mappingUri;
    set
    {
      if (this.m_mappingUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_mappingUri = value;
    }
  }

  public BaseDataVariableState<string> PriorityLabel
  {
    get => this.m_priorityLabel;
    set
    {
      if (this.m_priorityLabel != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priorityLabel = value;
    }
  }

  public BaseDataVariableState<byte> PriorityValue_PCP
  {
    get => this.m_priorityValue_PCP;
    set
    {
      if (this.m_priorityValue_PCP != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priorityValue_PCP = value;
    }
  }

  public BaseDataVariableState<uint> PriorityValue_DSCP
  {
    get => this.m_priorityValue_DSCP;
    set
    {
      if (this.m_priorityValue_DSCP != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priorityValue_DSCP = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_mappingUri != null)
      children.Add((BaseInstanceState) this.m_mappingUri);
    if (this.m_priorityLabel != null)
      children.Add((BaseInstanceState) this.m_priorityLabel);
    if (this.m_priorityValue_PCP != null)
      children.Add((BaseInstanceState) this.m_priorityValue_PCP);
    if (this.m_priorityValue_DSCP != null)
      children.Add((BaseInstanceState) this.m_priorityValue_DSCP);
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
      case "MappingUri":
        if (createOrReplace && this.MappingUri == null)
          this.MappingUri = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MappingUri;
        break;
      case "PriorityLabel":
        if (createOrReplace && this.PriorityLabel == null)
          this.PriorityLabel = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PriorityLabel;
        break;
      case "PriorityValue_PCP":
        if (createOrReplace && this.PriorityValue_PCP == null)
          this.PriorityValue_PCP = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PriorityValue_PCP;
        break;
      case "PriorityValue_DSCP":
        if (createOrReplace && this.PriorityValue_DSCP == null)
          this.PriorityValue_DSCP = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PriorityValue_DSCP;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
