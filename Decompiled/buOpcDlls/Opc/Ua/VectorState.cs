using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class VectorState : BaseDataVariableState<Vector>
{
	private const string VectorUnit_InitializationString = "//////////8VYIkKAgAAAAAACgAAAFZlY3RvclVuaXQBADNFAC4ARDNFAAABAHcD/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAEgAAAFZlY3RvclR5cGVJbnN0YW5jZQEAMkUBADJFMkUAAAEAd0n/////AQH/////AQAAABVgiQoCAAAAAAAKAAAAVmVjdG9yVW5pdAEAM0UALgBEM0UAAAEAdwP/////AQH/////AAAAAA==";

	private PropertyState<EUInformation> m_vectorUnit;

	public PropertyState<EUInformation> VectorUnit
	{
		get
		{
			return m_vectorUnit;
		}
		set
		{
			if (m_vectorUnit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_vectorUnit = value;
		}
	}

	public VectorState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17714u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18807u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAEgAAAFZlY3RvclR5cGVJbnN0YW5jZQEAMkUBADJFMkUAAAEAd0n/////AQH/////AQAAABVgiQoCAAAAAAAKAAAAVmVjdG9yVW5pdAEAM0UALgBEM0UAAAEAdwP/////AQH/////AAAAAA==");
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
		if (VectorUnit != null)
		{
			VectorUnit.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAFZlY3RvclVuaXQBADNFAC4ARDNFAAABAHcD/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_vectorUnit != null)
		{
			children.Add(m_vectorUnit);
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
		if (browseName.Name == "VectorUnit")
		{
			if (createOrReplace && VectorUnit == null)
			{
				if (replacement == null)
				{
					VectorUnit = new PropertyState<EUInformation>(this);
				}
				else
				{
					VectorUnit = (PropertyState<EUInformation>)replacement;
				}
			}
			baseInstanceState = VectorUnit;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
