using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UadpDataSetWriterMessageState : DataSetWriterMessageState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAd1IBAHdSd1IAAP////8EAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQB4UgAuAER4UgAAAQAePf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDb25maWd1cmVkU2l6ZQEAeVIALgBEeVIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB6UgAuAER6UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEAe1IALgBEe1IAAAAF/////wEB/////wAAAAA=";

	private PropertyState<uint> m_dataSetMessageContentMask;

	private PropertyState<ushort> m_configuredSize;

	private PropertyState<ushort> m_networkMessageNumber;

	private PropertyState<ushort> m_dataSetOffset;

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

	public PropertyState<ushort> ConfiguredSize
	{
		get
		{
			return m_configuredSize;
		}
		set
		{
			if (m_configuredSize != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_configuredSize = value;
		}
	}

	public PropertyState<ushort> NetworkMessageNumber
	{
		get
		{
			return m_networkMessageNumber;
		}
		set
		{
			if (m_networkMessageNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkMessageNumber = value;
		}
	}

	public PropertyState<ushort> DataSetOffset
	{
		get
		{
			return m_dataSetOffset;
		}
		set
		{
			if (m_dataSetOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetOffset = value;
		}
	}

	public UadpDataSetWriterMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21111u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0V3JpdGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAd1IBAHdSd1IAAP////8EAAAAFWCJCgIAAAAAABkAAABEYXRhU2V0TWVzc2FnZUNvbnRlbnRNYXNrAQB4UgAuAER4UgAAAQAePf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDb25maWd1cmVkU2l6ZQEAeVIALgBEeVIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB6UgAuAER6UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEAe1IALgBEe1IAAAAF/////wEB/////wAAAAA=");
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
		if (m_configuredSize != null)
		{
			children.Add(m_configuredSize);
		}
		if (m_networkMessageNumber != null)
		{
			children.Add(m_networkMessageNumber);
		}
		if (m_dataSetOffset != null)
		{
			children.Add(m_dataSetOffset);
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
		case "DataSetMessageContentMask":
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
			break;
		case "ConfiguredSize":
			if (createOrReplace && ConfiguredSize == null)
			{
				if (replacement == null)
				{
					ConfiguredSize = new PropertyState<ushort>(this);
				}
				else
				{
					ConfiguredSize = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = ConfiguredSize;
			break;
		case "NetworkMessageNumber":
			if (createOrReplace && NetworkMessageNumber == null)
			{
				if (replacement == null)
				{
					NetworkMessageNumber = new PropertyState<ushort>(this);
				}
				else
				{
					NetworkMessageNumber = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = NetworkMessageNumber;
			break;
		case "DataSetOffset":
			if (createOrReplace && DataSetOffset == null)
			{
				if (replacement == null)
				{
					DataSetOffset = new PropertyState<ushort>(this);
				}
				else
				{
					DataSetOffset = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = DataSetOffset;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
