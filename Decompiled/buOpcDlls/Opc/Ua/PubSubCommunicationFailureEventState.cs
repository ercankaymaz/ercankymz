using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubCommunicationFailureEventState : PubSubStatusEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKwAAAFB1YlN1YkNvbW11bmljYXRpb25GYWlsdXJlRXZlbnRUeXBlSW5zdGFuY2UBAMs8AQDLPMs8AAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAzDwALgBEzDwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAzTwALgBEzTwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAM48AC4ARM48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDPPAAuAETPPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA0DwALgBE0DwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBANE8AC4ARNE8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBANM8AC4ARNM8AAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA1DwALgBE1DwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENvbm5lY3Rpb25JZAEA1TwALgBE1TwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAEdyb3VwSWQBANY8AC4ARNY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEA1zwALgBE1zwAAAEANzn/////AQH/////AAAAABVgiQoCAAAAAAAFAAAARXJyb3IBANg8AC4ARNg8AAAAE/////8BAf////8AAAAA";

	private PropertyState<StatusCode> m_error;

	public PropertyState<StatusCode> Error
	{
		get
		{
			return m_error;
		}
		set
		{
			if (m_error != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_error = value;
		}
	}

	public PubSubCommunicationFailureEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15563u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKwAAAFB1YlN1YkNvbW11bmljYXRpb25GYWlsdXJlRXZlbnRUeXBlSW5zdGFuY2UBAMs8AQDLPMs8AAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAzDwALgBEzDwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAzTwALgBEzTwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAM48AC4ARM48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDPPAAuAETPPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA0DwALgBE0DwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBANE8AC4ARNE8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBANM8AC4ARNM8AAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA1DwALgBE1DwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENvbm5lY3Rpb25JZAEA1TwALgBE1TwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAEdyb3VwSWQBANY8AC4ARNY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEA1zwALgBE1zwAAAEANzn/////AQH/////AAAAABVgiQoCAAAAAAAFAAAARXJyb3IBANg8AC4ARNg8AAAAE/////8BAf////8AAAAA");
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
		if (m_error != null)
		{
			children.Add(m_error);
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
		if (browseName.Name == "Error")
		{
			if (createOrReplace && Error == null)
			{
				if (replacement == null)
				{
					Error = new PropertyState<StatusCode>(this);
				}
				else
				{
					Error = (PropertyState<StatusCode>)replacement;
				}
			}
			baseInstanceState = Error;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
