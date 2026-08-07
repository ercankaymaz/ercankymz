// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PropertyState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PropertyState : BaseVariableState
{
  public PropertyState(NodeState parent)
    : base(parent)
  {
    this.StatusCode = (StatusCode) 2150760448U /*0x80320000*/;
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new PropertyState(parent);

  protected override void Initialize(ISystemContext context)
  {
    this.SymbolicName = Utils.Format("{0}_Instance1", (object) "PropertyType");
    this.NodeId = (NodeId) null;
    this.BrowseName = new QualifiedName(this.SymbolicName, (ushort) 1);
    this.DisplayName = (LocalizedText) this.SymbolicName;
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.ReferenceTypeId = ReferenceTypeIds.HasProperty;
    this.TypeDefinitionId = this.GetDefaultTypeDefinitionId(context.NamespaceUris);
    this.NumericId = 68U;
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
    return (NodeId) 68U;
  }
}
