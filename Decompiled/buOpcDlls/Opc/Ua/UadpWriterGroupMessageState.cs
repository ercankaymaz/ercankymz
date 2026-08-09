using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UadpWriterGroupMessageState : WriterGroupMessageState
{
	private const string SamplingOffset_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAFVhZHBXcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAHFSAQBxUnFSAAD/////BQAAABVgiQoCAAAAAAAMAAAAR3JvdXBWZXJzaW9uAQByUgAuAERyUgAAAQAGUv////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABEYXRhU2V0T3JkZXJpbmcBAHNSAC4ARHNSAAABALhP/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE5ldHdvcmtNZXNzYWdlQ29udGVudE1hc2sBAHRSAC4ARHRSAAABABo9/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAAF2CJCgIAAAAAABAAAABQdWJsaXNoaW5nT2Zmc2V0AQB2UgAuAER2UgAAAQAiAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<uint> m_groupVersion;

	private PropertyState<DataSetOrderingType> m_dataSetOrdering;

	private PropertyState<uint> m_networkMessageContentMask;

	private PropertyState<double> m_samplingOffset;

	private PropertyState<double[]> m_publishingOffset;

	public PropertyState<uint> GroupVersion
	{
		get
		{
			return m_groupVersion;
		}
		set
		{
			if (m_groupVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_groupVersion = value;
		}
	}

	public PropertyState<DataSetOrderingType> DataSetOrdering
	{
		get
		{
			return m_dataSetOrdering;
		}
		set
		{
			if (m_dataSetOrdering != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_dataSetOrdering = value;
		}
	}

	public PropertyState<uint> NetworkMessageContentMask
	{
		get
		{
			return m_networkMessageContentMask;
		}
		set
		{
			if (m_networkMessageContentMask != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_networkMessageContentMask = value;
		}
	}

	public PropertyState<double> SamplingOffset
	{
		get
		{
			return m_samplingOffset;
		}
		set
		{
			if (m_samplingOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_samplingOffset = value;
		}
	}

	public PropertyState<double[]> PublishingOffset
	{
		get
		{
			return m_publishingOffset;
		}
		set
		{
			if (m_publishingOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_publishingOffset = value;
		}
	}

	public UadpWriterGroupMessageState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21105u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAFVhZHBXcml0ZXJHcm91cE1lc3NhZ2VUeXBlSW5zdGFuY2UBAHFSAQBxUnFSAAD/////BQAAABVgiQoCAAAAAAAMAAAAR3JvdXBWZXJzaW9uAQByUgAuAERyUgAAAQAGUv////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABEYXRhU2V0T3JkZXJpbmcBAHNSAC4ARHNSAAABALhP/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE5ldHdvcmtNZXNzYWdlQ29udGVudE1hc2sBAHRSAC4ARHRSAAABABo9/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAAF2CJCgIAAAAAABAAAABQdWJsaXNoaW5nT2Zmc2V0AQB2UgAuAER2UgAAAQAiAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (SamplingOffset != null)
		{
			SamplingOffset.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFNhbXBsaW5nT2Zmc2V0AQB1UgAuAER1UgAAAQAiAf////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_groupVersion != null)
		{
			children.Add(m_groupVersion);
		}
		if (m_dataSetOrdering != null)
		{
			children.Add(m_dataSetOrdering);
		}
		if (m_networkMessageContentMask != null)
		{
			children.Add(m_networkMessageContentMask);
		}
		if (m_samplingOffset != null)
		{
			children.Add(m_samplingOffset);
		}
		if (m_publishingOffset != null)
		{
			children.Add(m_publishingOffset);
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
		case "GroupVersion":
			if (createOrReplace && GroupVersion == null)
			{
				if (replacement == null)
				{
					GroupVersion = new PropertyState<uint>(this);
				}
				else
				{
					GroupVersion = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = GroupVersion;
			break;
		case "DataSetOrdering":
			if (createOrReplace && DataSetOrdering == null)
			{
				if (replacement == null)
				{
					DataSetOrdering = new PropertyState<DataSetOrderingType>(this);
				}
				else
				{
					DataSetOrdering = (PropertyState<DataSetOrderingType>)replacement;
				}
			}
			baseInstanceState = DataSetOrdering;
			break;
		case "NetworkMessageContentMask":
			if (createOrReplace && NetworkMessageContentMask == null)
			{
				if (replacement == null)
				{
					NetworkMessageContentMask = new PropertyState<uint>(this);
				}
				else
				{
					NetworkMessageContentMask = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = NetworkMessageContentMask;
			break;
		case "SamplingOffset":
			if (createOrReplace && SamplingOffset == null)
			{
				if (replacement == null)
				{
					SamplingOffset = new PropertyState<double>(this);
				}
				else
				{
					SamplingOffset = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = SamplingOffset;
			break;
		case "PublishingOffset":
			if (createOrReplace && PublishingOffset == null)
			{
				if (replacement == null)
				{
					PublishingOffset = new PropertyState<double[]>(this);
				}
				else
				{
					PublishingOffset = (PropertyState<double[]>)replacement;
				}
			}
			baseInstanceState = PublishingOffset;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
