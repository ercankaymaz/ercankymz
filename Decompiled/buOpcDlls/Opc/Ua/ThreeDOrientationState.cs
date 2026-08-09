using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ThreeDOrientationState : OrientationState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHQAAAFRocmVlRE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBdSQEAXUldSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQBfSQAvAD9fSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAYEkALwA/YEkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAGFJAC8AP2FJAAAAC/////8BAf////8AAAAA";

	private BaseDataVariableState<double> m_a;

	private BaseDataVariableState<double> m_b;

	private BaseDataVariableState<double> m_c;

	public BaseDataVariableState<double> A
	{
		get
		{
			return m_a;
		}
		set
		{
			if (m_a != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_a = value;
		}
	}

	public BaseDataVariableState<double> B
	{
		get
		{
			return m_b;
		}
		set
		{
			if (m_b != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_b = value;
		}
	}

	public BaseDataVariableState<double> C
	{
		get
		{
			return m_c;
		}
		set
		{
			if (m_c != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_c = value;
		}
	}

	public ThreeDOrientationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18781u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18812u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHQAAAFRocmVlRE9yaWVudGF0aW9uVHlwZUluc3RhbmNlAQBdSQEAXUldSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQBfSQAvAD9fSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAYEkALwA/YEkAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAGFJAC8AP2FJAAAAC/////8BAf////8AAAAA");
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
		if (m_a != null)
		{
			children.Add(m_a);
		}
		if (m_b != null)
		{
			children.Add(m_b);
		}
		if (m_c != null)
		{
			children.Add(m_c);
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
		case "A":
			if (createOrReplace && A == null)
			{
				if (replacement == null)
				{
					A = new BaseDataVariableState<double>(this);
				}
				else
				{
					A = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = A;
			break;
		case "B":
			if (createOrReplace && B == null)
			{
				if (replacement == null)
				{
					B = new BaseDataVariableState<double>(this);
				}
				else
				{
					B = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = B;
			break;
		case "C":
			if (createOrReplace && C == null)
			{
				if (replacement == null)
				{
					C = new BaseDataVariableState<double>(this);
				}
				else
				{
					C = (BaseDataVariableState<double>)replacement;
				}
			}
			baseInstanceState = C;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
