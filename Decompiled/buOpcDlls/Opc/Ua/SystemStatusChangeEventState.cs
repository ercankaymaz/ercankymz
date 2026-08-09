using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SystemStatusChangeEventState : SystemEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAFN5c3RlbVN0YXR1c0NoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQC2LAEAtiy2LAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALcsAC4ARLcsAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALgsAC4ARLgsAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC5LAAuAES5LAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAuiwALgBEuiwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALssAC4ARLssAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC8LAAuAES8LAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC+LAAuAES+LAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAL8sAC4ARL8sAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTeXN0ZW1TdGF0ZQEAsC0ALgBEsC0AAAEAVAP/////AQH/////AAAAAA==";

	private PropertyState<ServerState> m_systemState;

	public PropertyState<ServerState> SystemState
	{
		get
		{
			return m_systemState;
		}
		set
		{
			if (m_systemState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_systemState = value;
		}
	}

	public SystemStatusChangeEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11446u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAFN5c3RlbVN0YXR1c0NoYW5nZUV2ZW50VHlwZUluc3RhbmNlAQC2LAEAtiy2LAAA/////wkAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBALcsAC4ARLcsAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBALgsAC4ARLgsAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC5LAAuAES5LAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAuiwALgBEuiwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBALssAC4ARLssAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQC8LAAuAES8LAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQC+LAAuAES+LAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAL8sAC4ARL8sAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABTeXN0ZW1TdGF0ZQEAsC0ALgBEsC0AAAEAVAP/////AQH/////AAAAAA==");
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
		if (m_systemState != null)
		{
			children.Add(m_systemState);
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
		if (browseName.Name == "SystemState")
		{
			if (createOrReplace && SystemState == null)
			{
				if (replacement == null)
				{
					SystemState = new PropertyState<ServerState>(this);
				}
				else
				{
					SystemState = (PropertyState<ServerState>)replacement;
				}
			}
			baseInstanceState = SystemState;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
