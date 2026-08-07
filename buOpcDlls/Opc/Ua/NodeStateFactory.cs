// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeStateFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateFactory
{
  private NodeIdDictionary<Type> m_types;

  public virtual NodeState CreateInstance(
    ISystemContext context,
    NodeState parent,
    NodeClass nodeClass,
    QualifiedName browseName,
    NodeId referenceTypeId,
    NodeId typeDefinitionId)
  {
    if (this.m_types != null && !NodeId.IsNull(typeDefinitionId))
    {
      Type type = (Type) null;
      if (this.m_types.TryGetValue(typeDefinitionId, out type))
        return Activator.CreateInstance(type, (object) parent) as NodeState;
    }
    NodeState instance;
    switch (nodeClass)
    {
      case NodeClass.Object:
        instance = (NodeState) new BaseObjectState(parent);
        break;
      case NodeClass.Variable:
        instance = context.TypeTable == null || !context.TypeTable.IsTypeOf(referenceTypeId, ReferenceTypeIds.HasProperty) ? (NodeState) new BaseDataVariableState(parent) : (NodeState) new PropertyState(parent);
        break;
      case NodeClass.Method:
        instance = (NodeState) new MethodState(parent);
        break;
      case NodeClass.ObjectType:
        instance = (NodeState) new BaseObjectTypeState();
        break;
      case NodeClass.VariableType:
        instance = (NodeState) new BaseDataVariableTypeState();
        break;
      case NodeClass.ReferenceType:
        instance = (NodeState) new ReferenceTypeState();
        break;
      case NodeClass.DataType:
        instance = (NodeState) new DataTypeState();
        break;
      case NodeClass.View:
        instance = (NodeState) new ViewState();
        break;
      default:
        instance = (NodeState) null;
        break;
    }
    return instance;
  }

  public void RegisterType(NodeId typeDefinitionId, Type type)
  {
    if (NodeId.IsNull(typeDefinitionId))
      throw new ArgumentNullException(nameof (typeDefinitionId));
    if (type == (Type) null)
      throw new ArgumentNullException(nameof (type));
    if (this.m_types == null)
      this.m_types = new NodeIdDictionary<Type>();
    this.m_types[typeDefinitionId] = type;
  }

  public void UnRegisterType(NodeId typeDefinitionId)
  {
    if (NodeId.IsNull(typeDefinitionId))
      throw new ArgumentNullException(nameof (typeDefinitionId));
    if (this.m_types == null)
      return;
    this.m_types.Remove(typeDefinitionId);
  }
}
