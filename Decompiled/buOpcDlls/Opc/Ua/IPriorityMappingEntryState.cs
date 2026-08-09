using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IPriorityMappingEntryState : BaseInterfaceState
{
	private const string PriorityValue_PCP_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAAA==";

	private const string PriorityValue_DSCP_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAFByaW9yaXR5VmFsdWVfRFNDUAEAkV4ALwA/kV4AAAAH/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAElQcmlvcml0eU1hcHBpbmdFbnRyeVR5cGVJbnN0YW5jZQEAjV4BAI1ejV4AAP////8EAAAAFWCJCgIAAAAAAAoAAABNYXBwaW5nVXJpAQCOXgAvAD+OXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAAUHJpb3JpdHlMYWJlbAEAj14ALwA/j14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHJpb3JpdHlWYWx1ZV9EU0NQAQCRXgAvAD+RXgAAAAf/////AQH/////AAAAAA==";

	private BaseDataVariableState<string> m_mappingUri;

	private BaseDataVariableState<string> m_priorityLabel;

	private BaseDataVariableState<byte> m_priorityValue_PCP;

	private BaseDataVariableState<uint> m_priorityValue_DSCP;

	public BaseDataVariableState<string> MappingUri
	{
		get
		{
			return m_mappingUri;
		}
		set
		{
			if (m_mappingUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_mappingUri = value;
		}
	}

	public BaseDataVariableState<string> PriorityLabel
	{
		get
		{
			return m_priorityLabel;
		}
		set
		{
			if (m_priorityLabel != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priorityLabel = value;
		}
	}

	public BaseDataVariableState<byte> PriorityValue_PCP
	{
		get
		{
			return m_priorityValue_PCP;
		}
		set
		{
			if (m_priorityValue_PCP != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priorityValue_PCP = value;
		}
	}

	public BaseDataVariableState<uint> PriorityValue_DSCP
	{
		get
		{
			return m_priorityValue_DSCP;
		}
		set
		{
			if (m_priorityValue_DSCP != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priorityValue_DSCP = value;
		}
	}

	public IPriorityMappingEntryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24205u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIQAAAElQcmlvcml0eU1hcHBpbmdFbnRyeVR5cGVJbnN0YW5jZQEAjV4BAI1ejV4AAP////8EAAAAFWCJCgIAAAAAAAoAAABNYXBwaW5nVXJpAQCOXgAvAD+OXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAANAAAAUHJpb3JpdHlMYWJlbAEAj14ALwA/j14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHJpb3JpdHlWYWx1ZV9EU0NQAQCRXgAvAD+RXgAAAAf/////AQH/////AAAAAA==");
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
		if (PriorityValue_PCP != null)
		{
			PriorityValue_PCP.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAFByaW9yaXR5VmFsdWVfUENQAQCQXgAvAD+QXgAAAAP/////AQH/////AAAAAA==");
		}
		if (PriorityValue_DSCP != null)
		{
			PriorityValue_DSCP.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAFByaW9yaXR5VmFsdWVfRFNDUAEAkV4ALwA/kV4AAAAH/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_mappingUri != null)
		{
			children.Add(m_mappingUri);
		}
		if (m_priorityLabel != null)
		{
			children.Add(m_priorityLabel);
		}
		if (m_priorityValue_PCP != null)
		{
			children.Add(m_priorityValue_PCP);
		}
		if (m_priorityValue_DSCP != null)
		{
			children.Add(m_priorityValue_DSCP);
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
		case "MappingUri":
			if (createOrReplace && MappingUri == null)
			{
				if (replacement == null)
				{
					MappingUri = new BaseDataVariableState<string>(this);
				}
				else
				{
					MappingUri = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = MappingUri;
			break;
		case "PriorityLabel":
			if (createOrReplace && PriorityLabel == null)
			{
				if (replacement == null)
				{
					PriorityLabel = new BaseDataVariableState<string>(this);
				}
				else
				{
					PriorityLabel = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = PriorityLabel;
			break;
		case "PriorityValue_PCP":
			if (createOrReplace && PriorityValue_PCP == null)
			{
				if (replacement == null)
				{
					PriorityValue_PCP = new BaseDataVariableState<byte>(this);
				}
				else
				{
					PriorityValue_PCP = (BaseDataVariableState<byte>)replacement;
				}
			}
			baseInstanceState = PriorityValue_PCP;
			break;
		case "PriorityValue_DSCP":
			if (createOrReplace && PriorityValue_DSCP == null)
			{
				if (replacement == null)
				{
					PriorityValue_DSCP = new BaseDataVariableState<uint>(this);
				}
				else
				{
					PriorityValue_DSCP = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = PriorityValue_DSCP;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
