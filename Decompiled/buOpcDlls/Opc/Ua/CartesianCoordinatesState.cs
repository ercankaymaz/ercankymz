using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class CartesianCoordinatesState : BaseDataVariableState<CartesianCoordinates>
{
	private const string LengthUnit_InitializationString = "//////////8VYIkKAgAAAAAACgAAAExlbmd0aFVuaXQBAFVJAC4ARFVJAAABAHcD/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAIAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBUSQEAVElUSQAAAQB5Sf////8BAf////8BAAAAFWCJCgIAAAAAAAoAAABMZW5ndGhVbml0AQBVSQAuAERVSQAAAQB3A/////8BAf////8AAAAA";

	private PropertyState<EUInformation> m_lengthUnit;

	public PropertyState<EUInformation> LengthUnit
	{
		get
		{
			return m_lengthUnit;
		}
		set
		{
			if (m_lengthUnit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lengthUnit = value;
		}
	}

	public CartesianCoordinatesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18772u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18809u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAIAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBUSQEAVElUSQAAAQB5Sf////8BAf////8BAAAAFWCJCgIAAAAAAAoAAABMZW5ndGhVbml0AQBVSQAuAERVSQAAAQB3A/////8BAf////8AAAAA");
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
		if (LengthUnit != null)
		{
			LengthUnit.Initialize(context, "//////////8VYIkKAgAAAAAACgAAAExlbmd0aFVuaXQBAFVJAC4ARFVJAAABAHcD/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_lengthUnit != null)
		{
			children.Add(m_lengthUnit);
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
		if (browseName.Name == "LengthUnit")
		{
			if (createOrReplace && LengthUnit == null)
			{
				if (replacement == null)
				{
					LengthUnit = new PropertyState<EUInformation>(this);
				}
				else
				{
					LengthUnit = (PropertyState<EUInformation>)replacement;
				}
			}
			baseInstanceState = LengthUnit;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
