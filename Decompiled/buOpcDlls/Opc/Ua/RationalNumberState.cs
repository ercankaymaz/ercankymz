using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RationalNumberState : BaseDataVariableState<RationalNumber>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAGgAAAFJhdGlvbmFsTnVtYmVyVHlwZUluc3RhbmNlAQAtRQEALUUtRQAAAQB2Sf////8BAf////8CAAAAFWCJCgIAAAAAAAkAAABOdW1lcmF0b3IBADBFAC8APzBFAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABEZW5vbWluYXRvcgEAMUUALwA/MUUAAAAH/////wEB/////wAAAAA=";

	private BaseDataVariableState<int> m_numerator;

	private BaseDataVariableState<uint> m_denominator;

	public BaseDataVariableState<int> Numerator
	{
		get
		{
			return m_numerator;
		}
		set
		{
			if (m_numerator != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_numerator = value;
		}
	}

	public BaseDataVariableState<uint> Denominator
	{
		get
		{
			return m_denominator;
		}
		set
		{
			if (m_denominator != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_denominator = value;
		}
	}

	public RationalNumberState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17709u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18806u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAGgAAAFJhdGlvbmFsTnVtYmVyVHlwZUluc3RhbmNlAQAtRQEALUUtRQAAAQB2Sf////8BAf////8CAAAAFWCJCgIAAAAAAAkAAABOdW1lcmF0b3IBADBFAC8APzBFAAAABv////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABEZW5vbWluYXRvcgEAMUUALwA/MUUAAAAH/////wEB/////wAAAAA=");
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
		if (m_numerator != null)
		{
			children.Add(m_numerator);
		}
		if (m_denominator != null)
		{
			children.Add(m_denominator);
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
		if (!(name == "Numerator"))
		{
			if (name == "Denominator")
			{
				if (createOrReplace && Denominator == null)
				{
					if (replacement == null)
					{
						Denominator = new BaseDataVariableState<uint>(this);
					}
					else
					{
						Denominator = (BaseDataVariableState<uint>)replacement;
					}
				}
				baseInstanceState = Denominator;
			}
		}
		else
		{
			if (createOrReplace && Numerator == null)
			{
				if (replacement == null)
				{
					Numerator = new BaseDataVariableState<int>(this);
				}
				else
				{
					Numerator = (BaseDataVariableState<int>)replacement;
				}
			}
			baseInstanceState = Numerator;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
