using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditWriteUpdateEventState : AuditUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0V3JpdGVVcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEANAgBADQINAgAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQC+DQAuAES+DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQC/DQAuAES/DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAwA0ALgBEwA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAMENAC4ARMENAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDCDQAuAETCDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAww0ALgBEww0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAxQ0ALgBExQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDGDQAuAETGDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDHDQAuAETHDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAMgNAC4ARMgNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAyQ0ALgBEyQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAyg0ALgBEyg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAyw0ALgBEyw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEF0dHJpYnV0ZUlkAQC+CgAuAES+CgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW5kZXhSYW5nZQEANQgALgBENQgAAAEAIwH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2xkVmFsdWUBADYIAC4ARDYIAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABOZXdWYWx1ZQEANwgALgBENwgAAAAY/////wEB/////wAAAAA=";

	private PropertyState<uint> m_attributeId;

	private PropertyState<string> m_indexRange;

	private PropertyState m_oldValue;

	private PropertyState m_newValue;

	public PropertyState<uint> AttributeId
	{
		get
		{
			return m_attributeId;
		}
		set
		{
			if (m_attributeId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_attributeId = value;
		}
	}

	public PropertyState<string> IndexRange
	{
		get
		{
			return m_indexRange;
		}
		set
		{
			if (m_indexRange != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_indexRange = value;
		}
	}

	public PropertyState OldValue
	{
		get
		{
			return m_oldValue;
		}
		set
		{
			if (m_oldValue != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_oldValue = value;
		}
	}

	public PropertyState NewValue
	{
		get
		{
			return m_newValue;
		}
		set
		{
			if (m_newValue != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_newValue = value;
		}
	}

	public AuditWriteUpdateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2100u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0V3JpdGVVcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEANAgBADQINAgAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQC+DQAuAES+DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQC/DQAuAES/DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAwA0ALgBEwA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAMENAC4ARMENAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDCDQAuAETCDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAww0ALgBEww0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAxQ0ALgBExQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDGDQAuAETGDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDHDQAuAETHDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAMgNAC4ARMgNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAyQ0ALgBEyQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAyg0ALgBEyg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAyw0ALgBEyw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEF0dHJpYnV0ZUlkAQC+CgAuAES+CgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW5kZXhSYW5nZQEANQgALgBENQgAAAEAIwH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAT2xkVmFsdWUBADYIAC4ARDYIAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABOZXdWYWx1ZQEANwgALgBENwgAAAAY/////wEB/////wAAAAA=");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_attributeId != null)
		{
			children.Add(m_attributeId);
		}
		if (m_indexRange != null)
		{
			children.Add(m_indexRange);
		}
		if (m_oldValue != null)
		{
			children.Add(m_oldValue);
		}
		if (m_newValue != null)
		{
			children.Add(m_newValue);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "AttributeId":
			if (createOrReplace && AttributeId == null)
			{
				if (replacement == null)
				{
					AttributeId = new PropertyState<uint>(this);
				}
				else
				{
					AttributeId = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = AttributeId;
			break;
		case "IndexRange":
			if (createOrReplace && IndexRange == null)
			{
				if (replacement == null)
				{
					IndexRange = new PropertyState<string>(this);
				}
				else
				{
					IndexRange = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = IndexRange;
			break;
		case "OldValue":
			if (createOrReplace && OldValue == null)
			{
				if (replacement == null)
				{
					OldValue = new PropertyState(this);
				}
				else
				{
					OldValue = (PropertyState)replacement;
				}
			}
			baseInstanceState = OldValue;
			break;
		case "NewValue":
			if (createOrReplace && NewValue == null)
			{
				if (replacement == null)
				{
					NewValue = new PropertyState(this);
				}
				else
				{
					NewValue = (PropertyState)replacement;
				}
			}
			baseInstanceState = NewValue;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
