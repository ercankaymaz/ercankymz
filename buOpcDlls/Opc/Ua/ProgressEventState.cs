// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgressEventState
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
public class ProgressEventState(NodeState parent) : BaseEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAFByb2dyZXNzRXZlbnRUeXBlSW5zdGFuY2UBAKwsAQCsLKwsAAD/////CgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEArSwALgBErSwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAriwALgBEriwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAK8sAC4ARK8sAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCwLAAuAESwLAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAsSwALgBEsSwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALIsAC4ARLIsAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALQsAC4ARLQsAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAtSwALgBEtSwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbnRleHQBANYwAC4ARNYwAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcm9ncmVzcwEA1zAALgBE1zAAAAAF/////wEB/////wAAAAA=";
  private PropertyState m_context;
  private PropertyState<ushort> m_progress;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11436U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGQAAAFByb2dyZXNzRXZlbnRUeXBlSW5zdGFuY2UBAKwsAQCsLKwsAAD/////CgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEArSwALgBErSwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAriwALgBEriwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAK8sAC4ARK8sAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCwLAAuAESwLAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAsSwALgBEsSwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALIsAC4ARLIsAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALQsAC4ARLQsAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAtSwALgBEtSwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbnRleHQBANYwAC4ARNYwAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcm9ncmVzcwEA1zAALgBE1zAAAAAF/////wEB/////wAAAAA=");
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

  public PropertyState Context
  {
    get => this.m_context;
    set
    {
      if (this.m_context != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_context = value;
    }
  }

  public PropertyState<ushort> Progress
  {
    get => this.m_progress;
    set
    {
      if (this.m_progress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_progress = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_context != null)
      children.Add((BaseInstanceState) this.m_context);
    if (this.m_progress != null)
      children.Add((BaseInstanceState) this.m_progress);
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
      case "Context":
        if (createOrReplace && this.Context == null)
          this.Context = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Context;
        break;
      case "Progress":
        if (createOrReplace && this.Progress == null)
          this.Progress = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Progress;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
