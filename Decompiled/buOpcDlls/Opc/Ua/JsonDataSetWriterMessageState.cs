using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class JsonDataSetWriterMessageState : DataSetWriterMessageState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEpzb25EYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAiFIBAIhSiFIAAP////8BAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQCJUgAuAESJUgAAAQAqPf////8BAf////8AAAAA";

	private PropertyState<uint> m_dataSetMessageContentMask;

	public PropertyState<uint> DataSetMessageContentMask
	{
		get
		{
			return m_dataSetMessageContentMask;
		}
		set
		{
			if (m_dataSetMessageContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetMessageContentMask = value;
		}
	}

	public JsonDataSetWriterMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21128u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEpzb25EYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAiFIBAIhSiFIAAP////8BAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQCJUgAuAESJUgAAAQAqPf////8BAf////8AAAAA");
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
		if (m_dataSetMessageContentMask != null)
		{
			children.Add(m_dataSetMessageContentMask);
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
		if (browseName.Name == "DataSetMessageContentMask")
		{
			if (createOrReplace && DataSetMessageContentMask == null)
			{
				if (replacement == null)
				{
					DataSetMessageContentMask = new PropertyState<uint>(this);
				}
				else
				{
					DataSetMessageContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = DataSetMessageContentMask;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
