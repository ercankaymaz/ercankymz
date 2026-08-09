using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AudioVariableState : BaseDataVariableState<byte[]>
{
	private const string ListId_InitializationString = "//////////8VYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAA=";

	private const string AgencyId_InitializationString = "//////////8VYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAAA==";

	private const string VersionId_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFZlcnNpb25JZAEARkYALgBERkYAAAAM/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAGQAAAEF1ZGlvVmFyaWFibGVUeXBlSW5zdGFuY2UBAEJGAQBCRkJGAAABALM//////wEB/////wMAAAAVYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVmVyc2lvbklkAQBGRgAuAERGRgAAAAz/////AQH/////AAAAAA==";

	private PropertyState<string> m_listId;

	private PropertyState<string> m_agencyId;

	private PropertyState<string> m_versionId;

	public PropertyState<string> ListId
	{
		get
		{
			return m_listId;
		}
		set
		{
			if (m_listId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_listId = value;
		}
	}

	public PropertyState<string> AgencyId
	{
		get
		{
			return m_agencyId;
		}
		set
		{
			if (m_agencyId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_agencyId = value;
		}
	}

	public PropertyState<string> VersionId
	{
		get
		{
			return m_versionId;
		}
		set
		{
			if (m_versionId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_versionId = value;
		}
	}

	public AudioVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(17986u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(16307u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAGQAAAEF1ZGlvVmFyaWFibGVUeXBlSW5zdGFuY2UBAEJGAQBCRkJGAAABALM//////wEB/////wMAAAAVYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVmVyc2lvbklkAQBGRgAuAERGRgAAAAz/////AQH/////AAAAAA==");
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
		if (ListId != null)
		{
			ListId.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAExpc3RJZAEAREYALgBEREYAAAAM/////wEB/////wAAAAA=");
		}
		if (AgencyId != null)
		{
			AgencyId.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAEFnZW5jeUlkAQBFRgAuAERFRgAAAAz/////AQH/////AAAAAA==");
		}
		if (VersionId != null)
		{
			VersionId.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFZlcnNpb25JZAEARkYALgBERkYAAAAM/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_listId != null)
		{
			children.Add(m_listId);
		}
		if (m_agencyId != null)
		{
			children.Add(m_agencyId);
		}
		if (m_versionId != null)
		{
			children.Add(m_versionId);
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
		case "ListId":
			if (createOrReplace && ListId == null)
			{
				if (replacement == null)
				{
					ListId = new PropertyState<string>(this);
				}
				else
				{
					ListId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ListId;
			break;
		case "AgencyId":
			if (createOrReplace && AgencyId == null)
			{
				if (replacement == null)
				{
					AgencyId = new PropertyState<string>(this);
				}
				else
				{
					AgencyId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = AgencyId;
			break;
		case "VersionId":
			if (createOrReplace && VersionId == null)
			{
				if (replacement == null)
				{
					VersionId = new PropertyState<string>(this);
				}
				else
				{
					VersionId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = VersionId;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
