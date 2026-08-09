using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryUpdateEventState : AuditUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeVVwZGF0ZUV2ZW50VHlwZUluc3RhbmNlAQA4CAEAOAg4CAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMwNAC4ARMwNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAM0NAC4ARM0NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDODQAuAETODQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAzw0ALgBEzw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBANANAC4ARNANAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDRDQAuAETRDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDTDQAuAETTDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBANQNAC4ARNQNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABANUNAC4ARNUNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA1g0ALgBE1g0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDXDQAuAETXDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDYDQAuAETYDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDZDQAuAETZDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAvwoALgBEvwoAAAAR/////wEB/////wAAAAA=";

	private PropertyState<NodeId> m_parameterDataTypeId;

	public PropertyState<NodeId> ParameterDataTypeId
	{
		get
		{
			return m_parameterDataTypeId;
		}
		set
		{
			if (m_parameterDataTypeId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_parameterDataTypeId = value;
		}
	}

	public AuditHistoryUpdateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2104u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0SGlzdG9yeVVwZGF0ZUV2ZW50VHlwZUluc3RhbmNlAQA4CAEAOAg4CAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMwNAC4ARMwNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAM0NAC4ARM0NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDODQAuAETODQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAzw0ALgBEzw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBANANAC4ARNANAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDRDQAuAETRDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDTDQAuAETTDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBANQNAC4ARNQNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABANUNAC4ARNUNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEA1g0ALgBE1g0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDXDQAuAETXDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDYDQAuAETYDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDZDQAuAETZDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAATAAAAUGFyYW1ldGVyRGF0YVR5cGVJZAEAvwoALgBEvwoAAAAR/////wEB/////wAAAAA=");
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
		if (m_parameterDataTypeId != null)
		{
			children.Add(m_parameterDataTypeId);
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
		if (browseName.Name == "ParameterDataTypeId")
		{
			if (createOrReplace && ParameterDataTypeId == null)
			{
				if (replacement == null)
				{
					ParameterDataTypeId = new PropertyState<NodeId>(this);
				}
				else
				{
					ParameterDataTypeId = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = ParameterDataTypeId;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
