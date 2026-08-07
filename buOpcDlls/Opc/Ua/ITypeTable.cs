// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ITypeTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface ITypeTable
{
  bool IsKnown(ExpandedNodeId typeId);

  bool IsKnown(NodeId typeId);

  NodeId FindSuperType(ExpandedNodeId typeId);

  NodeId FindSuperType(NodeId typeId);

  Task<NodeId> FindSuperTypeAsync(ExpandedNodeId typeId, CancellationToken ct = default (CancellationToken));

  Task<NodeId> FindSuperTypeAsync(NodeId typeId, CancellationToken ct = default (CancellationToken));

  IList<NodeId> FindSubTypes(ExpandedNodeId typeId);

  bool IsTypeOf(ExpandedNodeId subTypeId, ExpandedNodeId superTypeId);

  bool IsTypeOf(NodeId subTypeId, NodeId superTypeId);

  QualifiedName FindReferenceTypeName(NodeId referenceTypeId);

  NodeId FindReferenceType(QualifiedName browseName);

  bool IsEncodingOf(ExpandedNodeId encodingId, ExpandedNodeId datatypeId);

  bool IsEncodingFor(NodeId expectedTypeId, ExtensionObject value);

  bool IsEncodingFor(NodeId expectedTypeId, object value);

  NodeId FindDataTypeId(ExpandedNodeId encodingId);

  NodeId FindDataTypeId(NodeId encodingId);
}
