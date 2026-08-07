// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseDataVariableState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BaseDataVariableState : BaseVariableState
{
  private PropertyState<LocalizedText[]> m_enumStrings;

  public BaseDataVariableState(NodeState parent)
    : base(parent)
  {
    if (parent == null)
      return;
    this.StatusCode = (StatusCode) 2150760448U /*0x80320000*/;
    this.ReferenceTypeId = ReferenceTypeIds.HasComponent;
  }

  public static NodeState Construct(NodeState parent)
  {
    return (NodeState) new BaseDataVariableState(parent);
  }

  protected override void Initialize(ISystemContext context)
  {
    this.SymbolicName = Utils.Format("{0}_Instance1", (object) "BaseDataVariableType");
    this.NodeId = (NodeId) null;
    this.BrowseName = new QualifiedName(this.SymbolicName, (ushort) 1);
    this.DisplayName = (LocalizedText) this.SymbolicName;
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.ReferenceTypeId = ReferenceTypeIds.HasComponent;
    this.TypeDefinitionId = this.GetDefaultTypeDefinitionId(context.NamespaceUris);
    this.NumericId = 63U /*0x3F*/;
    this.Value = (object) null;
    this.DataType = this.GetDefaultDataTypeId(context.NamespaceUris);
    this.ValueRank = this.GetDefaultValueRank();
    this.ArrayDimensions = (ReadOnlyList<uint>) null;
    this.AccessLevel = (byte) 3;
    this.UserAccessLevel = (byte) 3;
    this.MinimumSamplingInterval = 0.0;
    this.Historizing = false;
  }

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return (NodeId) 63U /*0x3F*/;
  }

  public PropertyState<LocalizedText[]> EnumStrings
  {
    get => this.m_enumStrings;
    set
    {
      if (this.m_enumStrings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enumStrings = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_enumStrings != null)
      children.Add((BaseInstanceState) this.m_enumStrings);
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
    if (browseName.Name == "EnumStrings")
    {
      if (createOrReplace && this.EnumStrings == null)
        this.EnumStrings = replacement != null ? (PropertyState<LocalizedText[]>) replacement : new PropertyState<LocalizedText[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.EnumStrings;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
