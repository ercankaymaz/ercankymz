// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ILocalNode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ILocalNode : INode
{
  object DataLock { get; }

  object Handle { get; set; }

  NodeId NodeId { get; }

  new QualifiedName BrowseName { get; set; }

  new LocalizedText DisplayName { get; set; }

  LocalizedText Description { get; set; }

  AttributeWriteMask WriteMask { get; set; }

  AttributeWriteMask UserWriteMask { get; set; }

  NodeId ModellingRule { get; }

  IReferenceCollection References { get; }

  ILocalNode CreateCopy(NodeId nodeId);

  bool SupportsAttribute(uint attributeId);

  ServiceResult Read(IOperationContext context, uint attributeId, DataValue value);

  ServiceResult Write(uint attributeId, DataValue value);
}
