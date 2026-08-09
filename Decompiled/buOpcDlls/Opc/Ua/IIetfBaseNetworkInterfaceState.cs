using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIetfBaseNetworkInterfaceState : BaseInterfaceState
{
	private const string PhysAddress_InitializationString = "//////////8VYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAElJZXRmQmFzZU5ldHdvcmtJbnRlcmZhY2VUeXBlSW5zdGFuY2UBAFReAQBUXlReAAD/////BAAAABVgiQoCAAAAAAALAAAAQWRtaW5TdGF0dXMBAFVeAC8AP1VeAAABAJRe/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAE9wZXJTdGF0dXMBAFZeAC8AP1ZeAAABAJZe/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3BlZWQBAFheAC8BAFlEWF4AAAAJ/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAF1eAC4ARF1eAAAWAQB5AwFgAAAALwAAAGh0dHA6Ly93d3cub3BjZm91bmRhdGlvbi5vcmcvVUEvdW5pdHMvdW4vY2VmYWN0MDFCAAMCAAAAZW4FAAAAYml0L3MDAgAAAGVuDgAAAGJpdCBwZXIgc2Vjb25kAQB3A/////8BAf////8AAAAA";

	private BaseDataVariableState<InterfaceAdminStatus> m_adminStatus;

	private BaseDataVariableState<InterfaceOperStatus> m_operStatus;

	private BaseDataVariableState<string> m_physAddress;

	private AnalogUnitState<ulong> m_speed;

	public BaseDataVariableState<InterfaceAdminStatus> AdminStatus
	{
		get
		{
			return m_adminStatus;
		}
		set
		{
			if (m_adminStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_adminStatus = value;
		}
	}

	public BaseDataVariableState<InterfaceOperStatus> OperStatus
	{
		get
		{
			return m_operStatus;
		}
		set
		{
			if (m_operStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_operStatus = value;
		}
	}

	public BaseDataVariableState<string> PhysAddress
	{
		get
		{
			return m_physAddress;
		}
		set
		{
			if (m_physAddress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_physAddress = value;
		}
	}

	public AnalogUnitState<ulong> Speed
	{
		get
		{
			return m_speed;
		}
		set
		{
			if (m_speed != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_speed = value;
		}
	}

	public IIetfBaseNetworkInterfaceState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24148u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAElJZXRmQmFzZU5ldHdvcmtJbnRlcmZhY2VUeXBlSW5zdGFuY2UBAFReAQBUXlReAAD/////BAAAABVgiQoCAAAAAAALAAAAQWRtaW5TdGF0dXMBAFVeAC8AP1VeAAABAJRe/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAE9wZXJTdGF0dXMBAFZeAC8AP1ZeAAABAJZe/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3BlZWQBAFheAC8BAFlEWF4AAAAJ/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAF1eAC4ARF1eAAAWAQB5AwFgAAAALwAAAGh0dHA6Ly93d3cub3BjZm91bmRhdGlvbi5vcmcvVUEvdW5pdHMvdW4vY2VmYWN0MDFCAAMCAAAAZW4FAAAAYml0L3MDAgAAAGVuDgAAAGJpdCBwZXIgc2Vjb25kAQB3A/////8BAf////8AAAAA");
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
		if (PhysAddress != null)
		{
			PhysAddress.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_adminStatus != null)
		{
			children.Add(m_adminStatus);
		}
		if (m_operStatus != null)
		{
			children.Add(m_operStatus);
		}
		if (m_physAddress != null)
		{
			children.Add(m_physAddress);
		}
		if (m_speed != null)
		{
			children.Add(m_speed);
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
		case "AdminStatus":
			if (createOrReplace && AdminStatus == null)
			{
				if (replacement == null)
				{
					AdminStatus = new BaseDataVariableState<InterfaceAdminStatus>(this);
				}
				else
				{
					AdminStatus = (BaseDataVariableState<InterfaceAdminStatus>)replacement;
				}
			}
			baseInstanceState = AdminStatus;
			break;
		case "OperStatus":
			if (createOrReplace && OperStatus == null)
			{
				if (replacement == null)
				{
					OperStatus = new BaseDataVariableState<InterfaceOperStatus>(this);
				}
				else
				{
					OperStatus = (BaseDataVariableState<InterfaceOperStatus>)replacement;
				}
			}
			baseInstanceState = OperStatus;
			break;
		case "PhysAddress":
			if (createOrReplace && PhysAddress == null)
			{
				if (replacement == null)
				{
					PhysAddress = new BaseDataVariableState<string>(this);
				}
				else
				{
					PhysAddress = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = PhysAddress;
			break;
		case "Speed":
			if (createOrReplace && Speed == null)
			{
				if (replacement == null)
				{
					Speed = new AnalogUnitState<ulong>(this);
				}
				else
				{
					Speed = (AnalogUnitState<ulong>)replacement;
				}
			}
			baseInstanceState = Speed;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
