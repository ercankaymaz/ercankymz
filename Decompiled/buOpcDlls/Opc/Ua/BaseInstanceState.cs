using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseInstanceState : NodeState, IFilterTarget
{
	private NodeState m_parent;

	private NodeId m_referenceTypeId;

	private NodeId m_typeDefinitionId;

	private NodeId m_modellingRuleId;

	private uint m_numericId;

	public NodeState Parent
	{
		get
		{
			return m_parent;
		}
		internal set
		{
			m_parent = value;
		}
	}

	public uint NumericId
	{
		get
		{
			return m_numericId;
		}
		set
		{
			m_numericId = value;
		}
	}

	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			if ((object)m_referenceTypeId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.References;
			}
			m_referenceTypeId = value;
		}
	}

	public NodeId TypeDefinitionId
	{
		get
		{
			return m_typeDefinitionId;
		}
		set
		{
			if ((object)m_typeDefinitionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.References;
			}
			m_typeDefinitionId = value;
		}
	}

	public NodeId ModellingRuleId
	{
		get
		{
			return m_modellingRuleId;
		}
		set
		{
			if ((object)m_modellingRuleId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.References;
			}
			m_modellingRuleId = value;
		}
	}

	private bool IsObjectOrVariable => (base.NodeClass & (NodeClass)3) != 0;

	protected BaseInstanceState(NodeClass nodeClass, NodeState parent)
		: base(nodeClass)
	{
		m_parent = parent;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is BaseInstanceState baseInstanceState)
		{
			m_referenceTypeId = baseInstanceState.m_referenceTypeId;
			m_typeDefinitionId = baseInstanceState.m_typeDefinitionId;
			m_modellingRuleId = baseInstanceState.m_modellingRuleId;
			m_numericId = baseInstanceState.m_numericId;
		}
		base.Initialize(context, source);
	}

	protected virtual NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return null;
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BaseInstanceState clone = new BaseInstanceState(base.NodeClass, Parent);
		return CloneChildren(clone);
	}

	public virtual NodeId GetDefaultTypeDefinitionId(ISystemContext context)
	{
		return GetDefaultTypeDefinitionId(context.NamespaceUris);
	}

	public string GetDisplayPath()
	{
		return GetDisplayPath(0, '.');
	}

	public string GetDisplayText()
	{
		return GetNonNullText(this);
	}

	public string GetDisplayPath(int maxLength, char seperator)
	{
		string nonNullText = GetNonNullText(this);
		if (m_parent == null)
		{
			return nonNullText;
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (maxLength > 2)
		{
			NodeState parent = m_parent;
			List<string> list = new List<string>();
			while (parent != null && parent is BaseInstanceState baseInstanceState)
			{
				parent = baseInstanceState.Parent;
				string nonNullText2 = GetNonNullText(parent);
				list.Add(nonNullText2);
				if (list.Count == maxLength - 2)
				{
					break;
				}
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				stringBuilder.Append(list[num]);
				stringBuilder.Append(seperator);
			}
		}
		stringBuilder.Append(GetNonNullText(m_parent));
		stringBuilder.Append(seperator);
		stringBuilder.Append(nonNullText);
		return stringBuilder.ToString();
	}

	private string GetNonNullText(NodeState node)
	{
		if (node == null)
		{
			return "(null)";
		}
		if (node.DisplayName == null)
		{
			if (node.BrowseName != null)
			{
				return node.BrowseName.Name;
			}
			return node.NodeClass.ToString();
		}
		return node.DisplayName.Text;
	}

	public override void ReportEvent(ISystemContext context, IFilterTarget e)
	{
		base.ReportEvent(context, e);
		if (m_parent != null)
		{
			m_parent.ReportEvent(context, e);
		}
	}

	public void Update(ISystemContext context, SimpleAttributeOperandCollection fields, EventFieldList e)
	{
		for (int i = 0; i < fields.Count; i++)
		{
			SimpleAttributeOperand simpleAttributeOperand = fields[i];
			object value = e.EventFields[i].Value;
			if (value == null)
			{
				continue;
			}
			if (simpleAttributeOperand.BrowsePath.Count == 0 && simpleAttributeOperand.AttributeId == 1)
			{
				base.NodeId = value as NodeId;
				continue;
			}
			if (simpleAttributeOperand.BrowsePath.Count == 1 && simpleAttributeOperand.AttributeId == 13 && simpleAttributeOperand.BrowsePath[0] == "EventType")
			{
				m_typeDefinitionId = value as NodeId;
				continue;
			}
			NodeState nodeState = this;
			for (int j = 0; j < simpleAttributeOperand.BrowsePath.Count; j++)
			{
				BaseInstanceState baseInstanceState = nodeState.CreateChild(context, simpleAttributeOperand.BrowsePath[j]);
				if (baseInstanceState == null)
				{
					baseInstanceState = ((simpleAttributeOperand.AttributeId != 13) ? ((BaseInstanceState)new BaseObjectState(nodeState)) : ((BaseInstanceState)new BaseDataVariableState(nodeState)));
					nodeState.AddChild(baseInstanceState);
				}
				if (QualifiedName.IsNull(baseInstanceState.BrowseName))
				{
					baseInstanceState.BrowseName = simpleAttributeOperand.BrowsePath[j];
				}
				if (LocalizedText.IsNullOrEmpty(baseInstanceState.DisplayName))
				{
					baseInstanceState.DisplayName = baseInstanceState.BrowseName.Name;
				}
				if (j < simpleAttributeOperand.BrowsePath.Count - 1)
				{
					nodeState = baseInstanceState;
					continue;
				}
				if (simpleAttributeOperand.AttributeId == 13)
				{
					if (baseInstanceState is BaseVariableState baseVariableState && simpleAttributeOperand.AttributeId == 13)
					{
						try
						{
							baseVariableState.WrappedValue = e.EventFields[i];
						}
						catch (Exception)
						{
							baseVariableState.Value = null;
						}
					}
					break;
				}
				baseInstanceState.NodeId = value as NodeId;
			}
		}
	}

	public void SetMinimumSamplingInterval(ISystemContext context, double minimumSamplingInterval)
	{
		if (this is BaseVariableState baseVariableState)
		{
			baseVariableState.MinimumSamplingInterval = minimumSamplingInterval;
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is BaseVariableState baseVariableState2)
			{
				baseVariableState2.MinimumSamplingInterval = minimumSamplingInterval;
			}
			list[i].SetMinimumSamplingInterval(context, minimumSamplingInterval);
		}
	}

	public virtual bool IsTypeOf(FilterContext context, NodeId typeDefinitionId)
	{
		if (!NodeId.IsNull(typeDefinitionId) && !context.TypeTree.IsTypeOf(TypeDefinitionId, typeDefinitionId))
		{
			return false;
		}
		return true;
	}

	public virtual object GetAttributeValue(FilterContext context, NodeId typeDefinitionId, IList<QualifiedName> relativePath, uint attributeId, NumericRange indexRange)
	{
		if (!NodeId.IsNull(typeDefinitionId) && typeDefinitionId != 2041u && !context.TypeTree.IsTypeOf(TypeDefinitionId, typeDefinitionId))
		{
			return null;
		}
		DataValue dataValue = new DataValue();
		if (ServiceResult.IsBad(ReadChildAttribute(null, relativePath, 0, attributeId, dataValue)))
		{
			return null;
		}
		object value = dataValue.Value;
		if (value != null && ServiceResult.IsBad(indexRange.ApplyRange(ref value)))
		{
			return null;
		}
		return value;
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (Parent != null)
		{
			NodeId nodeId = ReferenceTypeId;
			if (NodeId.IsNull(nodeId))
			{
				nodeId = ReferenceTypeIds.HasComponent;
			}
			node.ReferenceTable.Add(nodeId, isInverse: true, Parent.NodeId);
		}
		if (!NodeId.IsNull(m_typeDefinitionId) && IsObjectOrVariable)
		{
			node.ReferenceTable.Add(ReferenceTypeIds.HasTypeDefinition, isInverse: false, TypeDefinitionId);
		}
		if (!NodeId.IsNull(ModellingRuleId))
		{
			node.ReferenceTable.Add(ReferenceTypeIds.HasModellingRule, isInverse: false, ModellingRuleId);
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (!NodeId.IsNull(m_referenceTypeId))
		{
			encoder.WriteNodeId("ReferenceTypeId", m_referenceTypeId);
		}
		if (!NodeId.IsNull(m_typeDefinitionId))
		{
			encoder.WriteNodeId("TypeDefinitionId", m_typeDefinitionId);
		}
		if (!NodeId.IsNull(m_modellingRuleId))
		{
			encoder.WriteNodeId("ModellingRuleId", m_modellingRuleId);
		}
		if (m_numericId != 0)
		{
			encoder.WriteUInt32("NumericId", m_numericId);
		}
		encoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (!NodeId.IsNull(m_referenceTypeId))
		{
			attributesToSave |= AttributesToSave.ReferenceTypeId;
		}
		if (!NodeId.IsNull(m_typeDefinitionId))
		{
			attributesToSave |= AttributesToSave.TypeDefinitionId;
		}
		if (!NodeId.IsNull(m_modellingRuleId))
		{
			attributesToSave |= AttributesToSave.ModellingRuleId;
		}
		if (m_numericId != 0)
		{
			attributesToSave |= AttributesToSave.NumericId;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.ReferenceTypeId) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_referenceTypeId);
		}
		if ((attributesToSave & AttributesToSave.TypeDefinitionId) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_typeDefinitionId);
		}
		if ((attributesToSave & AttributesToSave.ModellingRuleId) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_modellingRuleId);
		}
		if ((attributesToSave & AttributesToSave.NumericId) != AttributesToSave.None)
		{
			encoder.WriteUInt32(null, m_numericId);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad)
	{
		base.Update(context, decoder, attributesToLoad);
		if ((attributesToLoad & AttributesToSave.ReferenceTypeId) != AttributesToSave.None)
		{
			m_referenceTypeId = decoder.ReadNodeId(null);
		}
		if ((attributesToLoad & AttributesToSave.TypeDefinitionId) != AttributesToSave.None)
		{
			m_typeDefinitionId = decoder.ReadNodeId(null);
		}
		if ((attributesToLoad & AttributesToSave.ModellingRuleId) != AttributesToSave.None)
		{
			m_modellingRuleId = decoder.ReadNodeId(null);
		}
		if ((attributesToLoad & AttributesToSave.NumericId) != AttributesToSave.None)
		{
			m_numericId = decoder.ReadUInt32(null);
		}
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("ReferenceTypeId"))
		{
			ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		}
		if (decoder.Peek("TypeDefinitionId"))
		{
			TypeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
		}
		if (decoder.Peek("ModellingRuleId"))
		{
			ModellingRuleId = decoder.ReadNodeId("ModellingRuleId");
		}
		if (decoder.Peek("NumericId"))
		{
			NumericId = decoder.ReadUInt32("NumericId");
		}
		decoder.PopNamespace();
	}

	protected override void PopulateBrowser(ISystemContext context, NodeBrowser browser)
	{
		base.PopulateBrowser(context, browser);
		if (!NodeId.IsNull(m_typeDefinitionId) && IsObjectOrVariable && browser.IsRequired(ReferenceTypeIds.HasTypeDefinition, isInverse: false))
		{
			browser.Add(ReferenceTypeIds.HasTypeDefinition, isInverse: false, m_typeDefinitionId);
		}
		if (!NodeId.IsNull(m_modellingRuleId) && browser.IsRequired(ReferenceTypeIds.HasModellingRule, isInverse: false))
		{
			browser.Add(ReferenceTypeIds.HasModellingRule, isInverse: false, m_modellingRuleId);
		}
		if (m_parent != null && !NodeId.IsNull(m_referenceTypeId) && browser.IsRequired(m_referenceTypeId, isInverse: true))
		{
			browser.Add(m_referenceTypeId, isInverse: true, m_parent);
		}
	}
}
