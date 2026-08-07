// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FolderTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class FolderTypeState : BaseObjectTypeState
{
  protected override void Initialize(ISystemContext context)
  {
    this.SuperTypeId = NodeId.Create((object) 61U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.NodeId = NodeId.Create((object) 61U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.BrowseName = QualifiedName.Create("FolderType", "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.DisplayName = new LocalizedText("FolderType", string.Empty, "FolderType");
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.IsAbstract = false;
  }
}
