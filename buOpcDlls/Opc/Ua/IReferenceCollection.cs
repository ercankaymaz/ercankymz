// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IReferenceCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IReferenceCollection : ICollection<IReference>, IEnumerable<IReference>, IEnumerable
{
  void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId);

  bool Remove(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId);

  bool RemoveAll(NodeId referenceTypeId, bool isInverse);

  bool Exists(
    NodeId referenceTypeId,
    bool isInverse,
    ExpandedNodeId targetId,
    bool includeSubtypes,
    ITypeTable typeTree);

  IList<IReference> Find(
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    ITypeTable typeTree);

  ExpandedNodeId FindTarget(
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    ITypeTable typeTree,
    int index);

  IList<IReference> FindReferencesToTarget(ExpandedNodeId targetId);
}
