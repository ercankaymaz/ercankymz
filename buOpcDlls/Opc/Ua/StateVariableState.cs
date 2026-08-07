// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StateVariableState
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
public class StateVariableState(NodeState parent) : BaseDataVariableState<LocalizedText>(parent)
{
  private const string Name_InitializationString = "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAA";
  private const string Number_InitializationString = "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAxgoALgBExgoAAAAH/////wEB/////wAAAAA=";
  private const string EffectiveDisplayName_InitializationString = "//////////8VYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQDHCgAuAETHCgAAABX/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8VYIkCAgAAAAAAGQAAAFN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMMKAQDDCsMKAAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEAxAoALgBExAoAAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAMYKAC4ARMYKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAxwoALgBExwoAAAAV/////wEB/////wAAAAA=";
  private PropertyState m_id;
  private PropertyState<QualifiedName> m_name;
  private PropertyState<uint> m_number;
  private PropertyState<LocalizedText> m_effectiveDisplayName;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2755U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIkCAgAAAAAAGQAAAFN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMMKAQDDCsMKAAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEAxAoALgBExAoAAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAMYKAC4ARMYKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAxwoALgBExwoAAAAV/////wEB/////wAAAAA=");
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
    if (this.Name != null)
      this.Name.Initialize(context, "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAA");
    if (this.Number != null)
      this.Number.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAxgoALgBExgoAAAAH/////wEB/////wAAAAA=");
    if (this.EffectiveDisplayName == null)
      return;
    this.EffectiveDisplayName.Initialize(context, "//////////8VYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQDHCgAuAETHCgAAABX/////AQH/////AAAAAA==");
  }

  public PropertyState Id
  {
    get => this.m_id;
    set
    {
      if (this.m_id != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_id = value;
    }
  }

  public PropertyState<QualifiedName> Name
  {
    get => this.m_name;
    set
    {
      if (this.m_name != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_name = value;
    }
  }

  public PropertyState<uint> Number
  {
    get => this.m_number;
    set
    {
      if (this.m_number != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_number = value;
    }
  }

  public PropertyState<LocalizedText> EffectiveDisplayName
  {
    get => this.m_effectiveDisplayName;
    set
    {
      if (this.m_effectiveDisplayName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_effectiveDisplayName = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_id != null)
      children.Add((BaseInstanceState) this.m_id);
    if (this.m_name != null)
      children.Add((BaseInstanceState) this.m_name);
    if (this.m_number != null)
      children.Add((BaseInstanceState) this.m_number);
    if (this.m_effectiveDisplayName != null)
      children.Add((BaseInstanceState) this.m_effectiveDisplayName);
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
      case "Id":
        if (createOrReplace && this.Id == null)
          this.Id = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Id;
        break;
      case "Name":
        if (createOrReplace && this.Name == null)
          this.Name = replacement != null ? (PropertyState<QualifiedName>) replacement : new PropertyState<QualifiedName>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Name;
        break;
      case "Number":
        if (createOrReplace && this.Number == null)
          this.Number = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Number;
        break;
      case "EffectiveDisplayName":
        if (createOrReplace && this.EffectiveDisplayName == null)
          this.EffectiveDisplayName = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.EffectiveDisplayName;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
