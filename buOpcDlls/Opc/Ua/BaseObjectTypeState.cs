// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseObjectTypeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseObjectTypeState : BaseTypeState
{
  public BaseObjectTypeState()
    : base(NodeClass.ObjectType)
  {
  }

  protected override void Initialize(ISystemContext context)
  {
    this.SuperTypeId = NodeId.Create((object) 58U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.NodeId = NodeId.Create((object) 58U, "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.BrowseName = QualifiedName.Create("BaseObjectType", "http://opcfoundation.org/UA/", context.NamespaceUris);
    this.DisplayName = new LocalizedText("BaseObjectType", string.Empty, "BaseObjectType");
    this.Description = (LocalizedText) null;
    this.WriteMask = AttributeWriteMask.None;
    this.UserWriteMask = AttributeWriteMask.None;
    this.IsAbstract = false;
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new BaseObjectTypeState();

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType()));
  }
}
