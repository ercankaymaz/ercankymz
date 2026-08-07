// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FolderState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class FolderState(NodeState parent) : BaseObjectState(parent)
{
  protected override void Initialize(ISystemContext context)
  {
    this.SymbolicName = Utils.Format("{0}_Instance1", (object) "FolderType");
    this.NodeId = (NodeId) null;
    this.BrowseName = new QualifiedName(this.SymbolicName, (ushort) 1);
    this.DisplayName = (LocalizedText) this.SymbolicName;
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.TypeDefinitionId = this.GetDefaultTypeDefinitionId(context.NamespaceUris);
    this.NumericId = 61U;
    this.EventNotifier = (byte) 0;
  }

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return (NodeId) 61U;
  }
}
