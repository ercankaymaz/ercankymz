using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class OperationLimitsState : FolderState
{
	private const string MaxNodesPerRead_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heE5vZGVzUGVyUmVhZAEALS0ALgBELS0AAAAH/////wEB/////wAAAAA=";

	private const string MaxNodesPerHistoryReadData_InitializationString = "//////////8VYIkKAgAAAAAAGgAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWREYXRhAQCBLwAuAESBLwAAAAf/////AQH/////AAAAAA==";

	private const string MaxNodesPerHistoryReadEvents_InitializationString = "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAA";

	private const string MaxNodesPerWrite_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAE1heE5vZGVzUGVyV3JpdGUBAC8tAC4ARC8tAAAAB/////8BAf////8AAAAA";

	private const string MaxNodesPerHistoryUpdateData_InitializationString = "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZURhdGEBAIMvAC4ARIMvAAAAB/////8BAf////8AAAAA";

	private const string MaxNodesPerHistoryUpdateEvents_InitializationString = "//////////8VYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAA=";

	private const string MaxNodesPerMethodCall_InitializationString = "//////////8VYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAA=";

	private const string MaxNodesPerBrowse_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAAA==";

	private const string MaxNodesPerRegisterNodes_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAE1heE5vZGVzUGVyUmVnaXN0ZXJOb2RlcwEAMy0ALgBEMy0AAAAH/////wEB/////wAAAAA=";

	private const string MaxNodesPerTranslateBrowsePathsToNodeIds_InitializationString = "//////////8VYIkKAgAAAAAAKAAAAE1heE5vZGVzUGVyVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHMBADQtAC4ARDQtAAAAB/////8BAf////8AAAAA";

	private const string MaxNodesPerNodeManagement_InitializationString = "//////////8VYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAA";

	private const string MaxMonitoredItemsPerCall_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAE1heE1vbml0b3JlZEl0ZW1zUGVyQ2FsbAEANi0ALgBENi0AAAAH/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAE9wZXJhdGlvbkxpbWl0c1R5cGVJbnN0YW5jZQEALC0BACwtLC0AAP////8MAAAAFWCJCgIAAAAAAA8AAABNYXhOb2Rlc1BlclJlYWQBAC0tAC4ARC0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb2Rlc1Blckhpc3RvcnlSZWFkRGF0YQEAgS8ALgBEgS8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABNYXhOb2Rlc1BlcldyaXRlAQAvLQAuAEQvLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAATWF4Tm9kZXNQZXJIaXN0b3J5VXBkYXRlRGF0YQEAgy8ALgBEgy8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAATWF4Tm9kZXNQZXJSZWdpc3Rlck5vZGVzAQAzLQAuAEQzLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAoAAAATWF4Tm9kZXNQZXJUcmFuc2xhdGVCcm93c2VQYXRoc1RvTm9kZUlkcwEANC0ALgBENC0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABNYXhNb25pdG9yZWRJdGVtc1BlckNhbGwBADYtAC4ARDYtAAAAB/////8BAf////8AAAAA";

	private PropertyState<uint> m_maxNodesPerRead;

	private PropertyState<uint> m_maxNodesPerHistoryReadData;

	private PropertyState<uint> m_maxNodesPerHistoryReadEvents;

	private PropertyState<uint> m_maxNodesPerWrite;

	private PropertyState<uint> m_maxNodesPerHistoryUpdateData;

	private PropertyState<uint> m_maxNodesPerHistoryUpdateEvents;

	private PropertyState<uint> m_maxNodesPerMethodCall;

	private PropertyState<uint> m_maxNodesPerBrowse;

	private PropertyState<uint> m_maxNodesPerRegisterNodes;

	private PropertyState<uint> m_maxNodesPerTranslateBrowsePathsToNodeIds;

	private PropertyState<uint> m_maxNodesPerNodeManagement;

	private PropertyState<uint> m_maxMonitoredItemsPerCall;

	public PropertyState<uint> MaxNodesPerRead
	{
		get
		{
			return m_maxNodesPerRead;
		}
		set
		{
			if (m_maxNodesPerRead != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerRead = value;
		}
	}

	public PropertyState<uint> MaxNodesPerHistoryReadData
	{
		get
		{
			return m_maxNodesPerHistoryReadData;
		}
		set
		{
			if (m_maxNodesPerHistoryReadData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerHistoryReadData = value;
		}
	}

	public PropertyState<uint> MaxNodesPerHistoryReadEvents
	{
		get
		{
			return m_maxNodesPerHistoryReadEvents;
		}
		set
		{
			if (m_maxNodesPerHistoryReadEvents != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerHistoryReadEvents = value;
		}
	}

	public PropertyState<uint> MaxNodesPerWrite
	{
		get
		{
			return m_maxNodesPerWrite;
		}
		set
		{
			if (m_maxNodesPerWrite != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerWrite = value;
		}
	}

	public PropertyState<uint> MaxNodesPerHistoryUpdateData
	{
		get
		{
			return m_maxNodesPerHistoryUpdateData;
		}
		set
		{
			if (m_maxNodesPerHistoryUpdateData != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerHistoryUpdateData = value;
		}
	}

	public PropertyState<uint> MaxNodesPerHistoryUpdateEvents
	{
		get
		{
			return m_maxNodesPerHistoryUpdateEvents;
		}
		set
		{
			if (m_maxNodesPerHistoryUpdateEvents != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerHistoryUpdateEvents = value;
		}
	}

	public PropertyState<uint> MaxNodesPerMethodCall
	{
		get
		{
			return m_maxNodesPerMethodCall;
		}
		set
		{
			if (m_maxNodesPerMethodCall != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerMethodCall = value;
		}
	}

	public PropertyState<uint> MaxNodesPerBrowse
	{
		get
		{
			return m_maxNodesPerBrowse;
		}
		set
		{
			if (m_maxNodesPerBrowse != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerBrowse = value;
		}
	}

	public PropertyState<uint> MaxNodesPerRegisterNodes
	{
		get
		{
			return m_maxNodesPerRegisterNodes;
		}
		set
		{
			if (m_maxNodesPerRegisterNodes != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerRegisterNodes = value;
		}
	}

	public PropertyState<uint> MaxNodesPerTranslateBrowsePathsToNodeIds
	{
		get
		{
			return m_maxNodesPerTranslateBrowsePathsToNodeIds;
		}
		set
		{
			if (m_maxNodesPerTranslateBrowsePathsToNodeIds != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerTranslateBrowsePathsToNodeIds = value;
		}
	}

	public PropertyState<uint> MaxNodesPerNodeManagement
	{
		get
		{
			return m_maxNodesPerNodeManagement;
		}
		set
		{
			if (m_maxNodesPerNodeManagement != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxNodesPerNodeManagement = value;
		}
	}

	public PropertyState<uint> MaxMonitoredItemsPerCall
	{
		get
		{
			return m_maxMonitoredItemsPerCall;
		}
		set
		{
			if (m_maxMonitoredItemsPerCall != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxMonitoredItemsPerCall = value;
		}
	}

	public OperationLimitsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11564u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAE9wZXJhdGlvbkxpbWl0c1R5cGVJbnN0YW5jZQEALC0BACwtLC0AAP////8MAAAAFWCJCgIAAAAAAA8AAABNYXhOb2Rlc1BlclJlYWQBAC0tAC4ARC0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb2Rlc1Blckhpc3RvcnlSZWFkRGF0YQEAgS8ALgBEgS8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABNYXhOb2Rlc1BlcldyaXRlAQAvLQAuAEQvLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAATWF4Tm9kZXNQZXJIaXN0b3J5VXBkYXRlRGF0YQEAgy8ALgBEgy8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAATWF4Tm9kZXNQZXJSZWdpc3Rlck5vZGVzAQAzLQAuAEQzLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAoAAAATWF4Tm9kZXNQZXJUcmFuc2xhdGVCcm93c2VQYXRoc1RvTm9kZUlkcwEANC0ALgBENC0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABNYXhNb25pdG9yZWRJdGVtc1BlckNhbGwBADYtAC4ARDYtAAAAB/////8BAf////8AAAAA");
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
		if (MaxNodesPerRead != null)
		{
			MaxNodesPerRead.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heE5vZGVzUGVyUmVhZAEALS0ALgBELS0AAAAH/////wEB/////wAAAAA=");
		}
		if (MaxNodesPerHistoryReadData != null)
		{
			MaxNodesPerHistoryReadData.Initialize(context, "//////////8VYIkKAgAAAAAAGgAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWREYXRhAQCBLwAuAESBLwAAAAf/////AQH/////AAAAAA==");
		}
		if (MaxNodesPerHistoryReadEvents != null)
		{
			MaxNodesPerHistoryReadEvents.Initialize(context, "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAA");
		}
		if (MaxNodesPerWrite != null)
		{
			MaxNodesPerWrite.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAE1heE5vZGVzUGVyV3JpdGUBAC8tAC4ARC8tAAAAB/////8BAf////8AAAAA");
		}
		if (MaxNodesPerHistoryUpdateData != null)
		{
			MaxNodesPerHistoryUpdateData.Initialize(context, "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZURhdGEBAIMvAC4ARIMvAAAAB/////8BAf////8AAAAA");
		}
		if (MaxNodesPerHistoryUpdateEvents != null)
		{
			MaxNodesPerHistoryUpdateEvents.Initialize(context, "//////////8VYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAA=");
		}
		if (MaxNodesPerMethodCall != null)
		{
			MaxNodesPerMethodCall.Initialize(context, "//////////8VYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAA=");
		}
		if (MaxNodesPerBrowse != null)
		{
			MaxNodesPerBrowse.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAAA==");
		}
		if (MaxNodesPerRegisterNodes != null)
		{
			MaxNodesPerRegisterNodes.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAE1heE5vZGVzUGVyUmVnaXN0ZXJOb2RlcwEAMy0ALgBEMy0AAAAH/////wEB/////wAAAAA=");
		}
		if (MaxNodesPerTranslateBrowsePathsToNodeIds != null)
		{
			MaxNodesPerTranslateBrowsePathsToNodeIds.Initialize(context, "//////////8VYIkKAgAAAAAAKAAAAE1heE5vZGVzUGVyVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHMBADQtAC4ARDQtAAAAB/////8BAf////8AAAAA");
		}
		if (MaxNodesPerNodeManagement != null)
		{
			MaxNodesPerNodeManagement.Initialize(context, "//////////8VYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAA");
		}
		if (MaxMonitoredItemsPerCall != null)
		{
			MaxMonitoredItemsPerCall.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAE1heE1vbml0b3JlZEl0ZW1zUGVyQ2FsbAEANi0ALgBENi0AAAAH/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_maxNodesPerRead != null)
		{
			children.Add(m_maxNodesPerRead);
		}
		if (m_maxNodesPerHistoryReadData != null)
		{
			children.Add(m_maxNodesPerHistoryReadData);
		}
		if (m_maxNodesPerHistoryReadEvents != null)
		{
			children.Add(m_maxNodesPerHistoryReadEvents);
		}
		if (m_maxNodesPerWrite != null)
		{
			children.Add(m_maxNodesPerWrite);
		}
		if (m_maxNodesPerHistoryUpdateData != null)
		{
			children.Add(m_maxNodesPerHistoryUpdateData);
		}
		if (m_maxNodesPerHistoryUpdateEvents != null)
		{
			children.Add(m_maxNodesPerHistoryUpdateEvents);
		}
		if (m_maxNodesPerMethodCall != null)
		{
			children.Add(m_maxNodesPerMethodCall);
		}
		if (m_maxNodesPerBrowse != null)
		{
			children.Add(m_maxNodesPerBrowse);
		}
		if (m_maxNodesPerRegisterNodes != null)
		{
			children.Add(m_maxNodesPerRegisterNodes);
		}
		if (m_maxNodesPerTranslateBrowsePathsToNodeIds != null)
		{
			children.Add(m_maxNodesPerTranslateBrowsePathsToNodeIds);
		}
		if (m_maxNodesPerNodeManagement != null)
		{
			children.Add(m_maxNodesPerNodeManagement);
		}
		if (m_maxMonitoredItemsPerCall != null)
		{
			children.Add(m_maxMonitoredItemsPerCall);
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
		case "MaxNodesPerRead":
			if (createOrReplace && MaxNodesPerRead == null)
			{
				if (replacement == null)
				{
					MaxNodesPerRead = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerRead = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerRead;
			break;
		case "MaxNodesPerHistoryReadData":
			if (createOrReplace && MaxNodesPerHistoryReadData == null)
			{
				if (replacement == null)
				{
					MaxNodesPerHistoryReadData = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerHistoryReadData = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerHistoryReadData;
			break;
		case "MaxNodesPerHistoryReadEvents":
			if (createOrReplace && MaxNodesPerHistoryReadEvents == null)
			{
				if (replacement == null)
				{
					MaxNodesPerHistoryReadEvents = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerHistoryReadEvents = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerHistoryReadEvents;
			break;
		case "MaxNodesPerWrite":
			if (createOrReplace && MaxNodesPerWrite == null)
			{
				if (replacement == null)
				{
					MaxNodesPerWrite = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerWrite = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerWrite;
			break;
		case "MaxNodesPerHistoryUpdateData":
			if (createOrReplace && MaxNodesPerHistoryUpdateData == null)
			{
				if (replacement == null)
				{
					MaxNodesPerHistoryUpdateData = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerHistoryUpdateData = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerHistoryUpdateData;
			break;
		case "MaxNodesPerHistoryUpdateEvents":
			if (createOrReplace && MaxNodesPerHistoryUpdateEvents == null)
			{
				if (replacement == null)
				{
					MaxNodesPerHistoryUpdateEvents = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerHistoryUpdateEvents = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerHistoryUpdateEvents;
			break;
		case "MaxNodesPerMethodCall":
			if (createOrReplace && MaxNodesPerMethodCall == null)
			{
				if (replacement == null)
				{
					MaxNodesPerMethodCall = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerMethodCall = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerMethodCall;
			break;
		case "MaxNodesPerBrowse":
			if (createOrReplace && MaxNodesPerBrowse == null)
			{
				if (replacement == null)
				{
					MaxNodesPerBrowse = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerBrowse = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerBrowse;
			break;
		case "MaxNodesPerRegisterNodes":
			if (createOrReplace && MaxNodesPerRegisterNodes == null)
			{
				if (replacement == null)
				{
					MaxNodesPerRegisterNodes = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerRegisterNodes = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerRegisterNodes;
			break;
		case "MaxNodesPerTranslateBrowsePathsToNodeIds":
			if (createOrReplace && MaxNodesPerTranslateBrowsePathsToNodeIds == null)
			{
				if (replacement == null)
				{
					MaxNodesPerTranslateBrowsePathsToNodeIds = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerTranslateBrowsePathsToNodeIds = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerTranslateBrowsePathsToNodeIds;
			break;
		case "MaxNodesPerNodeManagement":
			if (createOrReplace && MaxNodesPerNodeManagement == null)
			{
				if (replacement == null)
				{
					MaxNodesPerNodeManagement = new PropertyState<uint>(this);
				}
				else
				{
					MaxNodesPerNodeManagement = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxNodesPerNodeManagement;
			break;
		case "MaxMonitoredItemsPerCall":
			if (createOrReplace && MaxMonitoredItemsPerCall == null)
			{
				if (replacement == null)
				{
					MaxMonitoredItemsPerCall = new PropertyState<uint>(this);
				}
				else
				{
					MaxMonitoredItemsPerCall = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxMonitoredItemsPerCall;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
