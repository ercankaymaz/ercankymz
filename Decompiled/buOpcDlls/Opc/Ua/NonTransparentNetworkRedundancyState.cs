using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NonTransparentNetworkRedundancyState : NonTransparentRedundancyState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKwAAAE5vblRyYW5zcGFyZW50TmV0d29ya1JlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAKkuAQCpLqkuAAD/////AwAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAKouAC4ARKouAAABAFMD/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAFNlcnZlclVyaUFycmF5AQCrLgAuAESrLgAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABMAAABTZXJ2ZXJOZXR3b3JrR3JvdXBzAQCsLgAuAESsLgAAAQCoLgEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<NetworkGroupDataType[]> m_serverNetworkGroups;

	public PropertyState<NetworkGroupDataType[]> ServerNetworkGroups
	{
		get
		{
			return m_serverNetworkGroups;
		}
		set
		{
			if (m_serverNetworkGroups != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverNetworkGroups = value;
		}
	}

	public NonTransparentNetworkRedundancyState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11945u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKwAAAE5vblRyYW5zcGFyZW50TmV0d29ya1JlZHVuZGFuY3lUeXBlSW5zdGFuY2UBAKkuAQCpLqkuAAD/////AwAAABVgiQoCAAAAAAARAAAAUmVkdW5kYW5jeVN1cHBvcnQBAKouAC4ARKouAAABAFMD/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAFNlcnZlclVyaUFycmF5AQCrLgAuAESrLgAAAAwBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABMAAABTZXJ2ZXJOZXR3b3JrR3JvdXBzAQCsLgAuAESsLgAAAQCoLgEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_serverNetworkGroups != null)
		{
			children.Add(m_serverNetworkGroups);
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
		if (browseName.Name == "ServerNetworkGroups")
		{
			if (createOrReplace && ServerNetworkGroups == null)
			{
				if (replacement == null)
				{
					ServerNetworkGroups = new PropertyState<NetworkGroupDataType[]>(this);
				}
				else
				{
					ServerNetworkGroups = (PropertyState<NetworkGroupDataType[]>)replacement;
				}
			}
			baseInstanceState = ServerNetworkGroups;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
