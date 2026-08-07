// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TypeTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TypeTable : ITypeTable
{
  private readonly object m_lock = new object();
  private NamespaceTable m_namespaceUris;
  private SortedDictionary<QualifiedName, TypeTable.TypeInfo> m_referenceTypes;
  private NodeIdDictionary<TypeTable.TypeInfo> m_nodes;
  private NodeIdDictionary<TypeTable.TypeInfo> m_encodings;

  public TypeTable(NamespaceTable namespaceUris)
  {
    this.m_namespaceUris = namespaceUris;
    this.m_referenceTypes = new SortedDictionary<QualifiedName, TypeTable.TypeInfo>();
    this.m_nodes = new NodeIdDictionary<TypeTable.TypeInfo>();
    this.m_encodings = new NodeIdDictionary<TypeTable.TypeInfo>();
  }

  public bool IsKnown(ExpandedNodeId typeId)
  {
    if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0U)
      return false;
    NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return false;
    lock (this.m_lock)
      return this.m_nodes.ContainsKey(nodeId);
  }

  public bool IsKnown(NodeId typeId)
  {
    if (NodeId.IsNull(typeId))
      return false;
    lock (this.m_lock)
      return this.m_nodes.ContainsKey(typeId);
  }

  public NodeId FindSuperType(ExpandedNodeId typeId)
  {
    if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0U)
      return NodeId.Null;
    NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return NodeId.Null;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_nodes.TryGetValue(nodeId, out typeInfo) || typeInfo.SuperType == null ? NodeId.Null : typeInfo.SuperType.NodeId;
    }
  }

  public NodeId FindSuperType(NodeId typeId)
  {
    if (typeId == (object) null)
      return NodeId.Null;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_nodes.TryGetValue(typeId, out typeInfo) || typeInfo.SuperType == null ? NodeId.Null : typeInfo.SuperType.NodeId;
    }
  }

  public Task<NodeId> FindSuperTypeAsync(ExpandedNodeId typeId, CancellationToken ct)
  {
    return Task.FromResult<NodeId>(this.FindSuperType(typeId));
  }

  public Task<NodeId> FindSuperTypeAsync(NodeId typeId, CancellationToken ct)
  {
    return Task.FromResult<NodeId>(this.FindSuperType(typeId));
  }

  public IList<NodeId> FindSubTypes(ExpandedNodeId typeId)
  {
    List<NodeId> nodeIds = new List<NodeId>();
    if (typeId == (object) null)
      return (IList<NodeId>) nodeIds;
    NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return (IList<NodeId>) nodeIds;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (this.m_nodes.TryGetValue(nodeId, out typeInfo))
        typeInfo.GetSubtypes(nodeIds);
      return (IList<NodeId>) nodeIds;
    }
  }

  public bool IsTypeOf(ExpandedNodeId subTypeId, ExpandedNodeId superTypeId)
  {
    if (NodeId.IsNull(subTypeId) || subTypeId.ServerIndex != 0U || NodeId.IsNull(superTypeId) || superTypeId.ServerIndex != 0U)
      return false;
    if (subTypeId == (object) superTypeId)
      return true;
    NodeId nodeId1 = ExpandedNodeId.ToNodeId(subTypeId, this.m_namespaceUris);
    if (nodeId1 == (object) null)
      return false;
    NodeId nodeId2 = ExpandedNodeId.ToNodeId(superTypeId, this.m_namespaceUris);
    if (nodeId2 == (object) null)
      return false;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return this.m_nodes.TryGetValue(nodeId1, out typeInfo) && typeInfo.IsTypeOf(nodeId2);
    }
  }

  public bool IsTypeOf(NodeId subTypeId, NodeId superTypeId)
  {
    if (subTypeId == (object) null || superTypeId == (object) null)
      return false;
    if (subTypeId == (object) superTypeId)
      return true;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return this.m_nodes.TryGetValue(subTypeId, out typeInfo) && typeInfo.IsTypeOf(superTypeId);
    }
  }

  public QualifiedName FindReferenceTypeName(NodeId referenceTypeId)
  {
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_nodes.TryGetValue(referenceTypeId, out typeInfo) ? (QualifiedName) null : typeInfo.BrowseName;
    }
  }

  public NodeId FindReferenceType(QualifiedName browseName)
  {
    if (QualifiedName.IsNull(browseName))
      return (NodeId) null;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_referenceTypes.TryGetValue(browseName, out typeInfo) ? (NodeId) null : typeInfo.NodeId;
    }
  }

  public bool IsEncodingOf(ExpandedNodeId encodingId, ExpandedNodeId datatypeId)
  {
    if (NodeId.IsNull(encodingId) || NodeId.IsNull(datatypeId))
      return false;
    NodeId nodeId1 = ExpandedNodeId.ToNodeId(encodingId, this.m_namespaceUris);
    if (nodeId1 == (object) null)
      return false;
    NodeId nodeId2 = ExpandedNodeId.ToNodeId(datatypeId, this.m_namespaceUris);
    if (nodeId2 == (object) null)
      return false;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (!this.m_encodings.TryGetValue(nodeId1, out typeInfo))
        return false;
      if (nodeId2 == (object) typeInfo.NodeId)
        return true;
      for (TypeTable.TypeInfo superType = typeInfo.SuperType; superType != null; superType = superType.SuperType)
      {
        if (!superType.Deleted && superType.NodeId == (object) nodeId2)
          return true;
      }
      return false;
    }
  }

  public bool IsEncodingFor(NodeId expectedTypeId, ExtensionObject value)
  {
    return value != null && this.IsEncodingOf(value.TypeId, (ExpandedNodeId) expectedTypeId);
  }

  public bool IsEncodingFor(NodeId expectedTypeId, object value)
  {
    if (value == null)
      return false;
    if (NodeId.IsNull(expectedTypeId))
      return true;
    NodeId dataTypeId = Opc.Ua.TypeInfo.GetDataTypeId(value);
    if (this.IsTypeOf(dataTypeId, expectedTypeId))
      return true;
    if (dataTypeId != (object) DataTypeIds.Structure)
      return this.IsTypeOf(expectedTypeId, dataTypeId);
    switch (value)
    {
      case ExtensionObject extensionObject:
        return this.IsEncodingFor(expectedTypeId, extensionObject);
      case ExtensionObject[] extensionObjectArray:
        for (int index = 0; index < extensionObjectArray.Length; ++index)
        {
          if (!this.IsEncodingFor(expectedTypeId, extensionObjectArray[index]))
            return false;
        }
        return true;
      default:
        return false;
    }
  }

  public NodeId FindDataTypeId(ExpandedNodeId encodingId)
  {
    NodeId nodeId = ExpandedNodeId.ToNodeId(encodingId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return NodeId.Null;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_encodings.TryGetValue(nodeId, out typeInfo) ? NodeId.Null : typeInfo.NodeId;
    }
  }

  public NodeId FindDataTypeId(NodeId encodingId)
  {
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      return !this.m_encodings.TryGetValue(encodingId, out typeInfo) ? NodeId.Null : typeInfo.NodeId;
    }
  }

  public void Clear()
  {
    lock (this.m_lock)
    {
      this.m_nodes.Clear();
      this.m_encodings.Clear();
      this.m_referenceTypes.Clear();
    }
  }

  public void Add(ILocalNode node)
  {
    if (node == null || NodeId.IsNull(node.NodeId) || (node.NodeClass & (NodeClass.ObjectType | NodeClass.VariableType | NodeClass.ReferenceType | NodeClass.DataType)) == NodeClass.Unspecified)
      return;
    NodeId key = (NodeId) null;
    ExpandedNodeId target = node.References.FindTarget(ReferenceTypeIds.HasSubtype, true, false, (ITypeTable) null, 0);
    if (target != (object) null)
    {
      key = ExpandedNodeId.ToNodeId(target, this.m_namespaceUris);
      if (key == (object) null)
        throw ServiceResultException.Create(2150825984U /*0x80330000*/, "A valid supertype identifier is required.");
    }
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (key != (object) null && !this.m_nodes.TryGetValue(key, out typeInfo))
        throw ServiceResultException.Create(2150825984U /*0x80330000*/, "A valid supertype identifier is required.");
      TypeTable.TypeInfo subType = (TypeTable.TypeInfo) null;
      if (!this.m_nodes.TryGetValue(node.NodeId, out subType))
      {
        subType = new TypeTable.TypeInfo();
        this.m_nodes.Add(node.NodeId, subType);
      }
      subType.NodeId = node.NodeId;
      subType.SuperType = typeInfo;
      subType.Deleted = false;
      typeInfo?.AddSubType(subType);
      if (subType.Encodings != null)
      {
        foreach (NodeId encoding in subType.Encodings)
          this.m_encodings.Remove(encoding);
      }
      IList<IReference> referenceList = node.References.Find(ReferenceTypeIds.HasEncoding, false, false, (ITypeTable) null);
      if (referenceList.Count > 0)
      {
        subType.Encodings = new NodeId[referenceList.Count];
        for (int index = 0; index < referenceList.Count; ++index)
        {
          subType.Encodings[index] = ExpandedNodeId.ToNodeId(referenceList[index].TargetId, this.m_namespaceUris);
          this.m_encodings[subType.Encodings[index]] = subType;
        }
      }
      if ((node.NodeClass & NodeClass.ReferenceType) == NodeClass.Unspecified)
        return;
      if (!QualifiedName.IsNull(subType.BrowseName))
        this.m_referenceTypes.Remove(subType.BrowseName);
      subType.BrowseName = node.BrowseName;
      this.m_referenceTypes[node.BrowseName] = subType;
    }
  }

  public void AddSubtype(NodeId subTypeId, NodeId superTypeId)
  {
    this.AddSubtype(subTypeId, superTypeId, (QualifiedName) null);
  }

  public void AddReferenceSubtype(NodeId subTypeId, NodeId superTypeId, QualifiedName browseName)
  {
    this.AddSubtype(subTypeId, superTypeId, browseName);
  }

  public bool AddEncoding(NodeId dataTypeId, ExpandedNodeId encodingId)
  {
    NodeId nodeId = ExpandedNodeId.ToNodeId(encodingId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return false;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (!this.m_nodes.TryGetValue(dataTypeId, out typeInfo))
        return false;
      if (typeInfo.Encodings == null)
      {
        typeInfo.Encodings = new NodeId[1]{ nodeId };
      }
      else
      {
        NodeId[] destinationArray = new NodeId[typeInfo.Encodings.Length + 1];
        Array.Copy((Array) typeInfo.Encodings, (Array) destinationArray, typeInfo.Encodings.Length);
        destinationArray[destinationArray.Length - 1] = nodeId;
        typeInfo.Encodings = destinationArray;
      }
      this.m_encodings[nodeId] = typeInfo;
      return true;
    }
  }

  private void AddSubtype(NodeId subTypeId, NodeId superTypeId, QualifiedName browseName)
  {
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (!NodeId.IsNull(superTypeId) && !this.m_nodes.TryGetValue(superTypeId, out typeInfo))
        throw ServiceResultException.Create(2150825984U /*0x80330000*/, "A valid supertype identifier is required.");
      TypeTable.TypeInfo subType = (TypeTable.TypeInfo) null;
      if (!this.m_nodes.TryGetValue(subTypeId, out subType))
      {
        subType = new TypeTable.TypeInfo();
        this.m_nodes.Add(subTypeId, subType);
      }
      subType.NodeId = subTypeId;
      subType.SuperType = typeInfo;
      subType.Deleted = false;
      typeInfo?.AddSubType(subType);
      if (subType.Encodings != null)
      {
        foreach (NodeId encoding in subType.Encodings)
          this.m_encodings.Remove(encoding);
      }
      if (QualifiedName.IsNull(browseName))
        return;
      subType.BrowseName = browseName;
      this.m_referenceTypes[browseName] = subType;
    }
  }

  public void Remove(ExpandedNodeId typeId)
  {
    if (NodeId.IsNull(typeId) || typeId.ServerIndex != 0U)
      return;
    NodeId nodeId = ExpandedNodeId.ToNodeId(typeId, this.m_namespaceUris);
    if (nodeId == (object) null)
      return;
    lock (this.m_lock)
    {
      TypeTable.TypeInfo typeInfo = (TypeTable.TypeInfo) null;
      if (!this.m_nodes.TryGetValue(nodeId, out typeInfo))
        return;
      this.m_nodes.Remove(nodeId);
      typeInfo.Deleted = true;
      if (typeInfo.SuperType != null)
        typeInfo.SuperType.RemoveSubType(nodeId);
      if (typeInfo.Encodings != null)
      {
        for (int index = 0; index < typeInfo.Encodings.Length; ++index)
          this.m_encodings.Remove(typeInfo.Encodings[index]);
      }
      if (QualifiedName.IsNull(typeInfo.BrowseName))
        return;
      this.m_referenceTypes.Remove(typeInfo.BrowseName);
    }
  }

  private class TypeInfo
  {
    public bool Deleted;
    public NodeId NodeId;
    public QualifiedName BrowseName;
    public TypeTable.TypeInfo SuperType;
    public NodeId[] Encodings;
    public NodeIdDictionary<TypeTable.TypeInfo> SubTypes;

    public bool IsTypeOf(NodeId nodeId)
    {
      for (TypeTable.TypeInfo superType = this.SuperType; superType != null; superType = superType.SuperType)
      {
        if (!superType.Deleted && superType.NodeId == (object) nodeId)
          return true;
      }
      return false;
    }

    public void AddSubType(TypeTable.TypeInfo subType)
    {
      if (subType == null)
        return;
      if (this.SubTypes == null)
        this.SubTypes = new NodeIdDictionary<TypeTable.TypeInfo>();
      this.SubTypes[subType.NodeId] = subType;
    }

    public void RemoveSubType(NodeId subtypeId)
    {
      if (!(subtypeId != (object) null) || this.SubTypes == null)
        return;
      this.SubTypes.Remove(subtypeId);
      if (this.SubTypes.Count != 0)
        return;
      this.SubTypes = (NodeIdDictionary<TypeTable.TypeInfo>) null;
    }

    public void GetSubtypes(List<NodeId> nodeIds)
    {
      if (this.SubTypes == null)
        return;
      nodeIds.AddRange((IEnumerable<NodeId>) this.SubTypes.Keys);
    }
  }
}
