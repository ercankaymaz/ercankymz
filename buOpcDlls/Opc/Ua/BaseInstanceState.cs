// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BaseInstanceState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class BaseInstanceState : NodeState, IFilterTarget
{
  private NodeState m_parent;
  private NodeId m_referenceTypeId;
  private NodeId m_typeDefinitionId;
  private NodeId m_modellingRuleId;
  private uint m_numericId;

  protected BaseInstanceState(NodeClass nodeClass, NodeState parent)
    : base(nodeClass)
  {
    this.m_parent = parent;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is BaseInstanceState baseInstanceState)
    {
      this.m_referenceTypeId = baseInstanceState.m_referenceTypeId;
      this.m_typeDefinitionId = baseInstanceState.m_typeDefinitionId;
      this.m_modellingRuleId = baseInstanceState.m_modellingRuleId;
      this.m_numericId = baseInstanceState.m_numericId;
    }
    base.Initialize(context, source);
  }

  protected virtual NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return (NodeId) null;
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) new BaseInstanceState(this.NodeClass, this.Parent));
  }

  public NodeState Parent
  {
    get => this.m_parent;
    internal set => this.m_parent = value;
  }

  public virtual NodeId GetDefaultTypeDefinitionId(ISystemContext context)
  {
    return this.GetDefaultTypeDefinitionId(context.NamespaceUris);
  }

  public string GetDisplayPath() => this.GetDisplayPath(0, '.');

  public string GetDisplayText() => this.GetNonNullText((NodeState) this);

  public string GetDisplayPath(int maxLength, char seperator)
  {
    string nonNullText1 = this.GetNonNullText((NodeState) this);
    if (this.m_parent == null)
      return nonNullText1;
    StringBuilder stringBuilder = new StringBuilder();
    if (maxLength > 2)
    {
      NodeState parent = this.m_parent;
      List<string> stringList = new List<string>();
      while (parent != null && parent is BaseInstanceState baseInstanceState)
      {
        parent = baseInstanceState.Parent;
        string nonNullText2 = this.GetNonNullText(parent);
        stringList.Add(nonNullText2);
        if (stringList.Count == maxLength - 2)
          break;
      }
      for (int index = stringList.Count - 1; index >= 0; --index)
      {
        stringBuilder.Append(stringList[index]);
        stringBuilder.Append(seperator);
      }
    }
    stringBuilder.Append(this.GetNonNullText(this.m_parent));
    stringBuilder.Append(seperator);
    stringBuilder.Append(nonNullText1);
    return stringBuilder.ToString();
  }

  private string GetNonNullText(NodeState node)
  {
    if (node == null)
      return "(null)";
    if (!(node.DisplayName == (LocalizedText) null))
      return node.DisplayName.Text;
    return node.BrowseName != (QualifiedName) null ? node.BrowseName.Name : node.NodeClass.ToString();
  }

  public uint NumericId
  {
    get => this.m_numericId;
    set => this.m_numericId = value;
  }

  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set
    {
      if ((object) this.m_referenceTypeId != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.References;
      this.m_referenceTypeId = value;
    }
  }

  public NodeId TypeDefinitionId
  {
    get => this.m_typeDefinitionId;
    set
    {
      if ((object) this.m_typeDefinitionId != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.References;
      this.m_typeDefinitionId = value;
    }
  }

  public NodeId ModellingRuleId
  {
    get => this.m_modellingRuleId;
    set
    {
      if ((object) this.m_modellingRuleId != (object) value)
        this.ChangeMasks |= NodeStateChangeMasks.References;
      this.m_modellingRuleId = value;
    }
  }

  public override void ReportEvent(ISystemContext context, IFilterTarget e)
  {
    base.ReportEvent(context, e);
    if (this.m_parent == null)
      return;
    this.m_parent.ReportEvent(context, e);
  }

  public void Update(
    ISystemContext context,
    SimpleAttributeOperandCollection fields,
    EventFieldList e)
  {
    for (int index1 = 0; index1 < fields.Count; ++index1)
    {
      SimpleAttributeOperand field = fields[index1];
      object obj = e.EventFields[index1].Value;
      if (obj != null)
      {
        if (field.BrowsePath.Count == 0 && field.AttributeId == 1U)
          this.NodeId = obj as NodeId;
        else if (field.BrowsePath.Count == 1 && field.AttributeId == 13U && field.BrowsePath[0] == (QualifiedName) "EventType")
        {
          this.m_typeDefinitionId = obj as NodeId;
        }
        else
        {
          NodeState parent = (NodeState) this;
          for (int index2 = 0; index2 < field.BrowsePath.Count; ++index2)
          {
            BaseInstanceState child = parent.CreateChild(context, field.BrowsePath[index2]);
            if (child == null)
            {
              child = field.AttributeId != 13U ? (BaseInstanceState) new BaseObjectState(parent) : (BaseInstanceState) new BaseDataVariableState(parent);
              parent.AddChild(child);
            }
            if (QualifiedName.IsNull(child.BrowseName))
              child.BrowseName = field.BrowsePath[index2];
            if (LocalizedText.IsNullOrEmpty(child.DisplayName))
              child.DisplayName = (LocalizedText) child.BrowseName.Name;
            if (index2 < field.BrowsePath.Count - 1)
              parent = (NodeState) child;
            else if (field.AttributeId != 13U)
              child.NodeId = obj as NodeId;
            else if (child is BaseVariableState baseVariableState)
            {
              if (field.AttributeId == 13U)
              {
                try
                {
                  baseVariableState.WrappedValue = e.EventFields[index1];
                  break;
                }
                catch (Exception ex)
                {
                  baseVariableState.Value = (object) null;
                  break;
                }
              }
              else
                break;
            }
            else
              break;
          }
        }
      }
    }
  }

  public void SetMinimumSamplingInterval(ISystemContext context, double minimumSamplingInterval)
  {
    if (this is BaseVariableState baseVariableState1)
      baseVariableState1.MinimumSamplingInterval = minimumSamplingInterval;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      if (children[index] is BaseVariableState baseVariableState2)
        baseVariableState2.MinimumSamplingInterval = minimumSamplingInterval;
      children[index].SetMinimumSamplingInterval(context, minimumSamplingInterval);
    }
  }

  public virtual bool IsTypeOf(FilterContext context, NodeId typeDefinitionId)
  {
    return NodeId.IsNull(typeDefinitionId) || context.TypeTree.IsTypeOf(this.TypeDefinitionId, typeDefinitionId);
  }

  public virtual object GetAttributeValue(
    FilterContext context,
    NodeId typeDefinitionId,
    IList<QualifiedName> relativePath,
    uint attributeId,
    NumericRange indexRange)
  {
    if (!NodeId.IsNull(typeDefinitionId) && typeDefinitionId != (object) 2041U && !context.TypeTree.IsTypeOf(this.TypeDefinitionId, typeDefinitionId))
      return (object) null;
    DataValue dataValue = new DataValue();
    if (ServiceResult.IsBad(this.ReadChildAttribute((ISystemContext) null, relativePath, 0, attributeId, dataValue)))
      return (object) null;
    object obj = dataValue.Value;
    return obj != null && ServiceResult.IsBad((ServiceResult) indexRange.ApplyRange(ref obj)) ? (object) null : obj;
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (this.Parent != null)
    {
      NodeId nodeId = this.ReferenceTypeId;
      if (NodeId.IsNull(nodeId))
        nodeId = ReferenceTypeIds.HasComponent;
      node.ReferenceTable.Add(nodeId, true, (ExpandedNodeId) this.Parent.NodeId);
    }
    if (!NodeId.IsNull(this.m_typeDefinitionId) && this.IsObjectOrVariable)
      node.ReferenceTable.Add(ReferenceTypeIds.HasTypeDefinition, false, (ExpandedNodeId) this.TypeDefinitionId);
    if (NodeId.IsNull(this.ModellingRuleId))
      return;
    node.ReferenceTable.Add(ReferenceTypeIds.HasModellingRule, false, (ExpandedNodeId) this.ModellingRuleId);
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (!NodeId.IsNull(this.m_referenceTypeId))
      encoder.WriteNodeId("ReferenceTypeId", this.m_referenceTypeId);
    if (!NodeId.IsNull(this.m_typeDefinitionId))
      encoder.WriteNodeId("TypeDefinitionId", this.m_typeDefinitionId);
    if (!NodeId.IsNull(this.m_modellingRuleId))
      encoder.WriteNodeId("ModellingRuleId", this.m_modellingRuleId);
    if (this.m_numericId != 0U)
      encoder.WriteUInt32("NumericId", this.m_numericId);
    encoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (!NodeId.IsNull(this.m_referenceTypeId))
      attributesToSave |= NodeState.AttributesToSave.ReferenceTypeId;
    if (!NodeId.IsNull(this.m_typeDefinitionId))
      attributesToSave |= NodeState.AttributesToSave.TypeDefinitionId;
    if (!NodeId.IsNull(this.m_modellingRuleId))
      attributesToSave |= NodeState.AttributesToSave.ModellingRuleId;
    if (this.m_numericId != 0U)
      attributesToSave |= NodeState.AttributesToSave.NumericId;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.ReferenceTypeId) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_referenceTypeId);
    if ((attributesToSave & NodeState.AttributesToSave.TypeDefinitionId) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_typeDefinitionId);
    if ((attributesToSave & NodeState.AttributesToSave.ModellingRuleId) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_modellingRuleId);
    if ((attributesToSave & NodeState.AttributesToSave.NumericId) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteUInt32((string) null, this.m_numericId);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad)
  {
    base.Update(context, decoder, attributesToLoad);
    if ((attributesToLoad & NodeState.AttributesToSave.ReferenceTypeId) != NodeState.AttributesToSave.None)
      this.m_referenceTypeId = decoder.ReadNodeId((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.TypeDefinitionId) != NodeState.AttributesToSave.None)
      this.m_typeDefinitionId = decoder.ReadNodeId((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.ModellingRuleId) != NodeState.AttributesToSave.None)
      this.m_modellingRuleId = decoder.ReadNodeId((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.NumericId) == NodeState.AttributesToSave.None)
      return;
    this.m_numericId = decoder.ReadUInt32((string) null);
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("ReferenceTypeId"))
      this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    if (decoder.Peek("TypeDefinitionId"))
      this.TypeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
    if (decoder.Peek("ModellingRuleId"))
      this.ModellingRuleId = decoder.ReadNodeId("ModellingRuleId");
    if (decoder.Peek("NumericId"))
      this.NumericId = decoder.ReadUInt32("NumericId");
    decoder.PopNamespace();
  }

  protected override void PopulateBrowser(ISystemContext context, NodeBrowser browser)
  {
    base.PopulateBrowser(context, browser);
    if (!NodeId.IsNull(this.m_typeDefinitionId) && this.IsObjectOrVariable && browser.IsRequired(ReferenceTypeIds.HasTypeDefinition, false))
      browser.Add(ReferenceTypeIds.HasTypeDefinition, false, (ExpandedNodeId) this.m_typeDefinitionId);
    if (!NodeId.IsNull(this.m_modellingRuleId) && browser.IsRequired(ReferenceTypeIds.HasModellingRule, false))
      browser.Add(ReferenceTypeIds.HasModellingRule, false, (ExpandedNodeId) this.m_modellingRuleId);
    if (this.m_parent == null || NodeId.IsNull(this.m_referenceTypeId) || !browser.IsRequired(this.m_referenceTypeId, true))
      return;
    browser.Add(this.m_referenceTypeId, true, this.m_parent);
  }

  private bool IsObjectOrVariable
  {
    get => (this.NodeClass & (NodeClass.Object | NodeClass.Variable)) != 0;
  }
}
