// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IAdvancedFilterTarget
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public interface IAdvancedFilterTarget : IFilterTarget
{
  bool IsInView(FilterContext context, NodeId viewId);

  bool IsRelatedTo(
    FilterContext context,
    NodeId intermediateNodeId,
    NodeId sourceTypeId,
    NodeId targetTypeId,
    NodeId referenceTypeId,
    int hops,
    bool includeTypeDefintionSubtypes,
    bool includeReferenceSubtypes);

  IList<NodeId> GetRelatedNodes(
    FilterContext context,
    NodeId intermediateNodeId,
    NodeId sourceTypeId,
    NodeId targetTypeId,
    NodeId referenceTypeId,
    int hops,
    bool includeTypeDefintionSubtypes,
    bool includeReferenceSubtypes);

  object GetRelatedAttributeValue(
    FilterContext context,
    NodeId typeDefinitionId,
    RelativePath relativePath,
    uint attributeId,
    NumericRange indexRange);
}
