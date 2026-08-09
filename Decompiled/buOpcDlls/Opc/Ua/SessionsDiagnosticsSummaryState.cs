using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SessionsDiagnosticsSummaryState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAFNlc3Npb25zRGlhZ25vc3RpY3NTdW1tYXJ5VHlwZUluc3RhbmNlAQDqBwEA6gfqBwAA/////wIAAAAXYIkKAgAAAAAAFwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5AQDrBwAvAQCUCOsHAAABAGEDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAfAAAAU2Vzc2lvblNlY3VyaXR5RGlhZ25vc3RpY3NBcnJheQEA7AcALwEAwwjsBwAAAQBkAwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private SessionDiagnosticsArrayState m_sessionDiagnosticsArray;

	private SessionSecurityDiagnosticsArrayState m_sessionSecurityDiagnosticsArray;

	public SessionDiagnosticsArrayState SessionDiagnosticsArray
	{
		get
		{
			return m_sessionDiagnosticsArray;
		}
		set
		{
			if (m_sessionDiagnosticsArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionDiagnosticsArray = value;
		}
	}

	public SessionSecurityDiagnosticsArrayState SessionSecurityDiagnosticsArray
	{
		get
		{
			return m_sessionSecurityDiagnosticsArray;
		}
		set
		{
			if (m_sessionSecurityDiagnosticsArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_sessionSecurityDiagnosticsArray = value;
		}
	}

	public SessionsDiagnosticsSummaryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2026u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAFNlc3Npb25zRGlhZ25vc3RpY3NTdW1tYXJ5VHlwZUluc3RhbmNlAQDqBwEA6gfqBwAA/////wIAAAAXYIkKAgAAAAAAFwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5AQDrBwAvAQCUCOsHAAABAGEDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAfAAAAU2Vzc2lvblNlY3VyaXR5RGlhZ25vc3RpY3NBcnJheQEA7AcALwEAwwjsBwAAAQBkAwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_sessionDiagnosticsArray != null)
		{
			children.Add(m_sessionDiagnosticsArray);
		}
		if (m_sessionSecurityDiagnosticsArray != null)
		{
			children.Add(m_sessionSecurityDiagnosticsArray);
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
		string name = browseName.Name;
		if (!(name == "SessionDiagnosticsArray"))
		{
			if (name == "SessionSecurityDiagnosticsArray")
			{
				if (createOrReplace && SessionSecurityDiagnosticsArray == null)
				{
					if (replacement == null)
					{
						SessionSecurityDiagnosticsArray = new SessionSecurityDiagnosticsArrayState(this);
					}
					else
					{
						SessionSecurityDiagnosticsArray = (SessionSecurityDiagnosticsArrayState)replacement;
					}
				}
				baseInstanceState = SessionSecurityDiagnosticsArray;
			}
		}
		else
		{
			if (createOrReplace && SessionDiagnosticsArray == null)
			{
				if (replacement == null)
				{
					SessionDiagnosticsArray = new SessionDiagnosticsArrayState(this);
				}
				else
				{
					SessionDiagnosticsArray = (SessionDiagnosticsArrayState)replacement;
				}
			}
			baseInstanceState = SessionDiagnosticsArray;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
