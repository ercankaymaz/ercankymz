using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OrientationState : BaseDataVariableState<Orientation>
{
	private const string AngleUnit_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEFuZ2xlVW5pdAEAXEkALgBEXEkAAAEAdwP/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAFwAAAE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBbSQEAW0lbSQAAAQB7Sf////8BAf////8BAAAAFWCJCgIAAAAAAAkAAABBbmdsZVVuaXQBAFxJAC4ARFxJAAABAHcD/////wEB/////wAAAAA=";

	private PropertyState<EUInformation> m_angleUnit;

	public PropertyState<EUInformation> AngleUnit
	{
		get
		{
			return m_angleUnit;
		}
		set
		{
			if (m_angleUnit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_angleUnit = value;
		}
	}

	public OrientationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18779u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18811u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAFwAAAE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBbSQEAW0lbSQAAAQB7Sf////8BAf////8BAAAAFWCJCgIAAAAAAAkAAABBbmdsZVVuaXQBAFxJAC4ARFxJAAABAHcD/////wEB/////wAAAAA=");
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
		if (AngleUnit != null)
		{
			AngleUnit.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEFuZ2xlVW5pdAEAXEkALgBEXEkAAAEAdwP/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_angleUnit != null)
		{
			children.Add(m_angleUnit);
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
		if (browseName.Name == "AngleUnit")
		{
			if (createOrReplace && AngleUnit == null)
			{
				if (replacement == null)
				{
					AngleUnit = new PropertyState<EUInformation>(this);
				}
				else
				{
					AngleUnit = (PropertyState<EUInformation>)replacement;
				}
			}
			baseInstanceState = AngleUnit;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
