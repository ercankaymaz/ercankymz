using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerCapabilitiesState : BaseObjectState
{
	private const string MaxArrayLength_InitializationString = "//////////8VYIkKAgAAAAAADgAAAE1heEFycmF5TGVuZ3RoAQAdLQAuAEQdLQAAAAf/////AQH/////AAAAAA==";

	private const string MaxStringLength_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heFN0cmluZ0xlbmd0aAEAHi0ALgBEHi0AAAAH/////wEB/////wAAAAA=";

	private const string MaxByteStringLength_InitializationString = "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBAG4yAC4ARG4yAAAAB/////8BAf////8AAAAA";

	private const string OperationLimits_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE9wZXJhdGlvbkxpbWl0cwEAHy0ALwEALC0fLQAA/////wAAAAA=";

	private const string RoleSet_InitializationString = "//////////8EYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFNlcnZlckNhcGFiaWxpdGllc1R5cGVJbnN0YW5jZQEA3QcBAN0H3QcAAP////8OAAAAF2CJCgIAAAAAABIAAABTZXJ2ZXJQcm9maWxlQXJyYXkBAN4HAC4ARN4HAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAExvY2FsZUlkQXJyYXkBAOAHAC4AROAHAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAWAAAATWluU3VwcG9ydGVkU2FtcGxlUmF0ZQEA4QcALgBE4QcAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAbAAAATWF4QnJvd3NlQ29udGludWF0aW9uUG9pbnRzAQCsCgAuAESsCgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAaAAAATWF4UXVlcnlDb250aW51YXRpb25Qb2ludHMBAK0KAC4ARK0KAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNYXhIaXN0b3J5Q29udGludWF0aW9uUG9pbnRzAQCuCgAuAESuCgAAAAX/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAU29mdHdhcmVDZXJ0aWZpY2F0ZXMBAOkLAC4AROkLAAABAFgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4QXJyYXlMZW5ndGgBAB0tAC4ARB0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhTdHJpbmdMZW5ndGgBAB4tAC4ARB4tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQBuMgAuAERuMgAAAAf/////AQH/////AAAAAARggAoBAAAAAAAPAAAAT3BlcmF0aW9uTGltaXRzAQAfLQAvAQAsLR8tAAD/////AAAAAARggAoBAAAAAAAOAAAATW9kZWxsaW5nUnVsZXMBAOMHAC8APeMHAAD/////AAAAAARggAoBAAAAAAASAAAAQWdncmVnYXRlRnVuY3Rpb25zAQDCCgAvAD3CCgAA/////wAAAAAEYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<string[]> m_serverProfileArray;

	private PropertyState<string[]> m_localeIdArray;

	private PropertyState<double> m_minSupportedSampleRate;

	private PropertyState<ushort> m_maxBrowseContinuationPoints;

	private PropertyState<ushort> m_maxQueryContinuationPoints;

	private PropertyState<ushort> m_maxHistoryContinuationPoints;

	private PropertyState<SignedSoftwareCertificate[]> m_softwareCertificates;

	private PropertyState<uint> m_maxArrayLength;

	private PropertyState<uint> m_maxStringLength;

	private PropertyState<uint> m_maxByteStringLength;

	private OperationLimitsState m_operationLimits;

	private FolderState m_modellingRules;

	private FolderState m_aggregateFunctions;

	private RoleSetState m_roleSet;

	public PropertyState<string[]> ServerProfileArray
	{
		get
		{
			return m_serverProfileArray;
		}
		set
		{
			if (m_serverProfileArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverProfileArray = value;
		}
	}

	public PropertyState<string[]> LocaleIdArray
	{
		get
		{
			return m_localeIdArray;
		}
		set
		{
			if (m_localeIdArray != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_localeIdArray = value;
		}
	}

	public PropertyState<double> MinSupportedSampleRate
	{
		get
		{
			return m_minSupportedSampleRate;
		}
		set
		{
			if (m_minSupportedSampleRate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_minSupportedSampleRate = value;
		}
	}

	public PropertyState<ushort> MaxBrowseContinuationPoints
	{
		get
		{
			return m_maxBrowseContinuationPoints;
		}
		set
		{
			if (m_maxBrowseContinuationPoints != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxBrowseContinuationPoints = value;
		}
	}

	public PropertyState<ushort> MaxQueryContinuationPoints
	{
		get
		{
			return m_maxQueryContinuationPoints;
		}
		set
		{
			if (m_maxQueryContinuationPoints != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxQueryContinuationPoints = value;
		}
	}

	public PropertyState<ushort> MaxHistoryContinuationPoints
	{
		get
		{
			return m_maxHistoryContinuationPoints;
		}
		set
		{
			if (m_maxHistoryContinuationPoints != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxHistoryContinuationPoints = value;
		}
	}

	public PropertyState<SignedSoftwareCertificate[]> SoftwareCertificates
	{
		get
		{
			return m_softwareCertificates;
		}
		set
		{
			if (m_softwareCertificates != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_softwareCertificates = value;
		}
	}

	public PropertyState<uint> MaxArrayLength
	{
		get
		{
			return m_maxArrayLength;
		}
		set
		{
			if (m_maxArrayLength != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxArrayLength = value;
		}
	}

	public PropertyState<uint> MaxStringLength
	{
		get
		{
			return m_maxStringLength;
		}
		set
		{
			if (m_maxStringLength != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxStringLength = value;
		}
	}

	public PropertyState<uint> MaxByteStringLength
	{
		get
		{
			return m_maxByteStringLength;
		}
		set
		{
			if (m_maxByteStringLength != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxByteStringLength = value;
		}
	}

	public OperationLimitsState OperationLimits
	{
		get
		{
			return m_operationLimits;
		}
		set
		{
			if (m_operationLimits != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_operationLimits = value;
		}
	}

	public FolderState ModellingRules
	{
		get
		{
			return m_modellingRules;
		}
		set
		{
			if (m_modellingRules != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_modellingRules = value;
		}
	}

	public FolderState AggregateFunctions
	{
		get
		{
			return m_aggregateFunctions;
		}
		set
		{
			if (m_aggregateFunctions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_aggregateFunctions = value;
		}
	}

	public RoleSetState RoleSet
	{
		get
		{
			return m_roleSet;
		}
		set
		{
			if (m_roleSet != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_roleSet = value;
		}
	}

	public ServerCapabilitiesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2013u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFNlcnZlckNhcGFiaWxpdGllc1R5cGVJbnN0YW5jZQEA3QcBAN0H3QcAAP////8OAAAAF2CJCgIAAAAAABIAAABTZXJ2ZXJQcm9maWxlQXJyYXkBAN4HAC4ARN4HAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAExvY2FsZUlkQXJyYXkBAOAHAC4AROAHAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAWAAAATWluU3VwcG9ydGVkU2FtcGxlUmF0ZQEA4QcALgBE4QcAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAbAAAATWF4QnJvd3NlQ29udGludWF0aW9uUG9pbnRzAQCsCgAuAESsCgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAaAAAATWF4UXVlcnlDb250aW51YXRpb25Qb2ludHMBAK0KAC4ARK0KAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNYXhIaXN0b3J5Q29udGludWF0aW9uUG9pbnRzAQCuCgAuAESuCgAAAAX/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAU29mdHdhcmVDZXJ0aWZpY2F0ZXMBAOkLAC4AROkLAAABAFgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4QXJyYXlMZW5ndGgBAB0tAC4ARB0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhTdHJpbmdMZW5ndGgBAB4tAC4ARB4tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQBuMgAuAERuMgAAAAf/////AQH/////AAAAAARggAoBAAAAAAAPAAAAT3BlcmF0aW9uTGltaXRzAQAfLQAvAQAsLR8tAAD/////AAAAAARggAoBAAAAAAAOAAAATW9kZWxsaW5nUnVsZXMBAOMHAC8APeMHAAD/////AAAAAARggAoBAAAAAAASAAAAQWdncmVnYXRlRnVuY3Rpb25zAQDCCgAvAD3CCgAA/////wAAAAAEYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (MaxArrayLength != null)
		{
			MaxArrayLength.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAE1heEFycmF5TGVuZ3RoAQAdLQAuAEQdLQAAAAf/////AQH/////AAAAAA==");
		}
		if (MaxStringLength != null)
		{
			MaxStringLength.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heFN0cmluZ0xlbmd0aAEAHi0ALgBEHi0AAAAH/////wEB/////wAAAAA=");
		}
		if (MaxByteStringLength != null)
		{
			MaxByteStringLength.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBAG4yAC4ARG4yAAAAB/////8BAf////8AAAAA");
		}
		if (OperationLimits != null)
		{
			OperationLimits.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE9wZXJhdGlvbkxpbWl0cwEAHy0ALwEALC0fLQAA/////wAAAAA=");
		}
		if (RoleSet != null)
		{
			RoleSet.Initialize(context, "//////////8EYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_serverProfileArray != null)
		{
			children.Add(m_serverProfileArray);
		}
		if (m_localeIdArray != null)
		{
			children.Add(m_localeIdArray);
		}
		if (m_minSupportedSampleRate != null)
		{
			children.Add(m_minSupportedSampleRate);
		}
		if (m_maxBrowseContinuationPoints != null)
		{
			children.Add(m_maxBrowseContinuationPoints);
		}
		if (m_maxQueryContinuationPoints != null)
		{
			children.Add(m_maxQueryContinuationPoints);
		}
		if (m_maxHistoryContinuationPoints != null)
		{
			children.Add(m_maxHistoryContinuationPoints);
		}
		if (m_softwareCertificates != null)
		{
			children.Add(m_softwareCertificates);
		}
		if (m_maxArrayLength != null)
		{
			children.Add(m_maxArrayLength);
		}
		if (m_maxStringLength != null)
		{
			children.Add(m_maxStringLength);
		}
		if (m_maxByteStringLength != null)
		{
			children.Add(m_maxByteStringLength);
		}
		if (m_operationLimits != null)
		{
			children.Add(m_operationLimits);
		}
		if (m_modellingRules != null)
		{
			children.Add(m_modellingRules);
		}
		if (m_aggregateFunctions != null)
		{
			children.Add(m_aggregateFunctions);
		}
		if (m_roleSet != null)
		{
			children.Add(m_roleSet);
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
		case "ServerProfileArray":
			if (createOrReplace && ServerProfileArray == null)
			{
				if (replacement == null)
				{
					ServerProfileArray = new PropertyState<string[]>(this);
				}
				else
				{
					ServerProfileArray = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = ServerProfileArray;
			break;
		case "LocaleIdArray":
			if (createOrReplace && LocaleIdArray == null)
			{
				if (replacement == null)
				{
					LocaleIdArray = new PropertyState<string[]>(this);
				}
				else
				{
					LocaleIdArray = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = LocaleIdArray;
			break;
		case "MinSupportedSampleRate":
			if (createOrReplace && MinSupportedSampleRate == null)
			{
				if (replacement == null)
				{
					MinSupportedSampleRate = new PropertyState<double>(this);
				}
				else
				{
					MinSupportedSampleRate = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = MinSupportedSampleRate;
			break;
		case "MaxBrowseContinuationPoints":
			if (createOrReplace && MaxBrowseContinuationPoints == null)
			{
				if (replacement == null)
				{
					MaxBrowseContinuationPoints = new PropertyState<ushort>(this);
				}
				else
				{
					MaxBrowseContinuationPoints = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = MaxBrowseContinuationPoints;
			break;
		case "MaxQueryContinuationPoints":
			if (createOrReplace && MaxQueryContinuationPoints == null)
			{
				if (replacement == null)
				{
					MaxQueryContinuationPoints = new PropertyState<ushort>(this);
				}
				else
				{
					MaxQueryContinuationPoints = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = MaxQueryContinuationPoints;
			break;
		case "MaxHistoryContinuationPoints":
			if (createOrReplace && MaxHistoryContinuationPoints == null)
			{
				if (replacement == null)
				{
					MaxHistoryContinuationPoints = new PropertyState<ushort>(this);
				}
				else
				{
					MaxHistoryContinuationPoints = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = MaxHistoryContinuationPoints;
			break;
		case "SoftwareCertificates":
			if (createOrReplace && SoftwareCertificates == null)
			{
				if (replacement == null)
				{
					SoftwareCertificates = new PropertyState<SignedSoftwareCertificate[]>(this);
				}
				else
				{
					SoftwareCertificates = (PropertyState<SignedSoftwareCertificate[]>)replacement;
				}
			}
			baseInstanceState = SoftwareCertificates;
			break;
		case "MaxArrayLength":
			if (createOrReplace && MaxArrayLength == null)
			{
				if (replacement == null)
				{
					MaxArrayLength = new PropertyState<uint>(this);
				}
				else
				{
					MaxArrayLength = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxArrayLength;
			break;
		case "MaxStringLength":
			if (createOrReplace && MaxStringLength == null)
			{
				if (replacement == null)
				{
					MaxStringLength = new PropertyState<uint>(this);
				}
				else
				{
					MaxStringLength = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxStringLength;
			break;
		case "MaxByteStringLength":
			if (createOrReplace && MaxByteStringLength == null)
			{
				if (replacement == null)
				{
					MaxByteStringLength = new PropertyState<uint>(this);
				}
				else
				{
					MaxByteStringLength = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxByteStringLength;
			break;
		case "OperationLimits":
			if (createOrReplace && OperationLimits == null)
			{
				if (replacement == null)
				{
					OperationLimits = new OperationLimitsState(this);
				}
				else
				{
					OperationLimits = (OperationLimitsState)replacement;
				}
			}
			baseInstanceState = OperationLimits;
			break;
		case "ModellingRules":
			if (createOrReplace && ModellingRules == null)
			{
				if (replacement == null)
				{
					ModellingRules = new FolderState(this);
				}
				else
				{
					ModellingRules = (FolderState)replacement;
				}
			}
			baseInstanceState = ModellingRules;
			break;
		case "AggregateFunctions":
			if (createOrReplace && AggregateFunctions == null)
			{
				if (replacement == null)
				{
					AggregateFunctions = new FolderState(this);
				}
				else
				{
					AggregateFunctions = (FolderState)replacement;
				}
			}
			baseInstanceState = AggregateFunctions;
			break;
		case "RoleSet":
			if (createOrReplace && RoleSet == null)
			{
				if (replacement == null)
				{
					RoleSet = new RoleSetState(this);
				}
				else
				{
					RoleSet = (RoleSetState)replacement;
				}
			}
			baseInstanceState = RoleSet;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
