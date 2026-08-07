// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseDataVariableTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseDataVariableTypeState : BaseVariableTypeState
{
  public static NodeState Construct(NodeState parent)
  {
    return (NodeState) new BaseDataVariableTypeState();
  }

  protected override void Initialize(ISystemContext context)
  {
    this.SuperTypeId = NodeId.Create((object) 62U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.NodeId = NodeId.Create((object) 63U /*0x3F*/, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.BrowseName = QualifiedName.Create("BaseDataVariableType", "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.DisplayName = new LocalizedText("BaseDataVariableType", string.Empty, "BaseDataVariableType");
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.IsAbstract = false;
    this.Value = (object) null;
    this.DataType = NodeId.Create((object) 24U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.ValueRank = -2;
    this.ArrayDimensions = (ReadOnlyList<uint>) null;
  }
}
