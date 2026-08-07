// Decompiled with JetBrains decompiler
// Type: Opc.Ua.InstanceStateSnapshot
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class InstanceStateSnapshot : IFilterTarget
{
  private NodeId m_typeDefinitionId;
  private InstanceStateSnapshot.ChildNode m_snapshot;
  private object m_handle;

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public void Initialize(ISystemContext context, BaseInstanceState state)
  {
    this.m_typeDefinitionId = state.TypeDefinitionId;
    this.m_snapshot = this.CreateChildNode(context, state);
    this.m_handle = (object) state;
  }

  public void SetChildValue(QualifiedName browseName, NodeClass nodeClass, object value)
  {
    this.SetChildValue(this.m_snapshot, browseName, nodeClass, value);
  }

  public bool IsTypeOf(FilterContext context, NodeId typeDefinitionId)
  {
    return NodeId.IsNull(typeDefinitionId) || context.TypeTree.IsTypeOf(this.m_typeDefinitionId, typeDefinitionId);
  }

  public object GetAttributeValue(
    FilterContext context,
    NodeId typeDefinitionId,
    IList<QualifiedName> relativePath,
    uint attributeId,
    NumericRange indexRange)
  {
    if (!NodeId.IsNull(typeDefinitionId) && !context.TypeTree.IsTypeOf(this.m_typeDefinitionId, typeDefinitionId))
      return (object) null;
    object attributeValue = this.GetAttributeValue(this.m_snapshot, relativePath, 0, attributeId);
    if (indexRange != NumericRange.Empty && StatusCode.IsBad(indexRange.ApplyRange(ref attributeValue)))
      attributeValue = (object) null;
    return attributeValue;
  }

  private void SetChildValue(
    InstanceStateSnapshot.ChildNode node,
    QualifiedName browseName,
    NodeClass nodeClass,
    object value)
  {
    InstanceStateSnapshot.ChildNode childNode = (InstanceStateSnapshot.ChildNode) null;
    if (node.Children != null)
    {
      for (int index = 0; index < node.Children.Count; ++index)
      {
        childNode = node.Children[index];
        if (!(childNode.BrowseName == browseName))
          childNode = (InstanceStateSnapshot.ChildNode) null;
        else
          break;
      }
    }
    else
      node.Children = new List<InstanceStateSnapshot.ChildNode>();
    if (childNode == null)
    {
      childNode = new InstanceStateSnapshot.ChildNode();
      node.Children.Add(childNode);
    }
    childNode.BrowseName = browseName;
    childNode.NodeClass = nodeClass;
    childNode.Value = value;
  }

  private InstanceStateSnapshot.ChildNode CreateChildNode(
    ISystemContext context,
    BaseInstanceState state)
  {
    InstanceStateSnapshot.ChildNode childNode = new InstanceStateSnapshot.ChildNode();
    childNode.NodeClass = state.NodeClass;
    childNode.BrowseName = state.BrowseName;
    if (state is BaseVariableState baseVariableState && !StatusCode.IsBad(baseVariableState.StatusCode))
      childNode.Value = Utils.Clone(baseVariableState.Value);
    if (state is BaseObjectState baseObjectState)
      childNode.Value = (object) baseObjectState.NodeId;
    childNode.Children = this.CreateChildNodes(context, state);
    return childNode;
  }

  private List<InstanceStateSnapshot.ChildNode> CreateChildNodes(
    ISystemContext context,
    BaseInstanceState state)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    state.GetChildren(context, (IList<BaseInstanceState>) children);
    List<InstanceStateSnapshot.ChildNode> childNodes = new List<InstanceStateSnapshot.ChildNode>();
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState state1 = children[index];
      if (state1 != null && (state1.NodeClass == NodeClass.Object || state1.NodeClass == NodeClass.Variable))
      {
        InstanceStateSnapshot.ChildNode childNode = this.CreateChildNode(context, state1);
        childNodes.Add(childNode);
      }
    }
    return childNodes;
  }

  private object GetAttributeValue(
    InstanceStateSnapshot.ChildNode node,
    IList<QualifiedName> relativePath,
    int index,
    uint attributeId)
  {
    if (index >= relativePath.Count)
    {
      if (attributeId == 1U || node.NodeClass == NodeClass.Variable && attributeId == 13U)
        return node.Value;
      if (attributeId == 2U)
        return (object) node.NodeClass;
      return attributeId == 3U ? (object) node.BrowseName : (object) null;
    }
    for (int index1 = 0; index1 < node.Children.Count; ++index1)
    {
      if (node.Children[index1].BrowseName == relativePath[index])
        return this.GetAttributeValue(node.Children[index1], relativePath, index + 1, attributeId);
    }
    return (object) null;
  }

  private class ChildNode
  {
    public NodeClass NodeClass;
    public QualifiedName BrowseName;
    public object Value;
    public List<InstanceStateSnapshot.ChildNode> Children;
  }
}
