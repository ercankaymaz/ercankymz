using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ThreeDCartesianCoordinatesState : CartesianCoordinatesState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAJgAAAFRocmVlRENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBWSQEAVklWSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBYSQAvAD9YSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAWUkALwA/WUkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAFpJAC8AP1pJAAAAC/////8BAf////8AAAAA";

	private BaseDataVariableState<double> m_x;

	private BaseDataVariableState<double> m_y;

	private BaseDataVariableState<double> m_z;

	public BaseDataVariableState<double> X
	{
		get
		{
			return m_x;
		}
		set
		{
			if (m_x != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_x = value;
		}
	}

	public BaseDataVariableState<double> Y
	{
		get
		{
			return m_y;
		}
		set
		{
			if (m_y != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_y = value;
		}
	}

	public BaseDataVariableState<double> Z
	{
		get
		{
			return m_z;
		}
		set
		{
			if (m_z != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_z = value;
		}
	}

	public ThreeDCartesianCoordinatesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18774u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18810u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAJgAAAFRocmVlRENhcnRlc2lhbkNvb3JkaW5hdGVzVHlwZUluc3RhbmNlAQBWSQEAVklWSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBYSQAvAD9YSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAWUkALwA/WUkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAFpJAC8AP1pJAAAAC/////8BAf////8AAAAA");
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
		if (m_x != null)
		{
			children.Add(m_x);
		}
		if (m_y != null)
		{
			children.Add(m_y);
		}
		if (m_z != null)
		{
			children.Add(m_z);
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
		case "X":
			if (createOrReplace && X == null)
			{
				if (replacement == null)
				{
					X = new BaseDataVariableState<double>(this);
				}
				else
				{
					X = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = X;
			break;
		case "Y":
			if (createOrReplace && Y == null)
			{
				if (replacement == null)
				{
					Y = new BaseDataVariableState<double>(this);
				}
				else
				{
					Y = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = Y;
			break;
		case "Z":
			if (createOrReplace && Z == null)
			{
				if (replacement == null)
				{
					Z = new BaseDataVariableState<double>(this);
				}
				else
				{
					Z = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = Z;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
