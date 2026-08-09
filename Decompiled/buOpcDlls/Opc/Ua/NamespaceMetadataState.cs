using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NamespaceMetadataState : BaseObjectState
{
	private const string NamespaceFile_InitializationString = "//////////8EYIAKAQAAAAAADQAAAE5hbWVzcGFjZUZpbGUBAGgtAC8BAEstaC0AAP////8KAAAAFWCJCgIAAAAAAAQAAABTaXplAQBpLQAuAERpLQAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJIxAC4ARJIxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJMxAC4ARJMxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAGwtAC4ARGwtAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQBtLQAvAQA8LW0tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbi0ALgBEbi0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAG8tAC4ARG8tAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAHAtAC8BAD8tcC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBxLQAuAERxLQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAHItAC8BAEEtci0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzLQAuAERzLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdC0ALgBEdC0AAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEAdS0ALwEARC11LQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHYtAC4ARHYtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQB3LQAvAQBGLXctAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAeC0ALgBEeC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHktAC4ARHktAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQB6LQAvAQBJLXotAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAey0ALgBEey0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string DefaultRolePermissions_InitializationString = "//////////8XYIkKAgAAAAAAFgAAAERlZmF1bHRSb2xlUGVybWlzc2lvbnMBAAk/AC4ARAk/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string DefaultUserRolePermissions_InitializationString = "//////////8XYIkKAgAAAAAAGgAAAERlZmF1bHRVc2VyUm9sZVBlcm1pc3Npb25zAQAKPwAuAEQKPwAAAGABAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string DefaultAccessRestrictions_InitializationString = "//////////8VYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAE5hbWVzcGFjZU1ldGFkYXRhVHlwZUluc3RhbmNlAQBgLQEAYC1gLQAA/////wsAAAAVYIkKAgAAAAAADAAAAE5hbWVzcGFjZVVyaQEAYS0ALgBEYS0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE5hbWVzcGFjZVZlcnNpb24BAGItAC4ARGItAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABOYW1lc3BhY2VQdWJsaWNhdGlvbkRhdGUBAGMtAC4ARGMtAAAADf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABJc05hbWVzcGFjZVN1YnNldAEAZC0ALgBEZC0AAAAB/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFN0YXRpY05vZGVJZFR5cGVzAQBlLQAuAERlLQAAAQAAAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFN0YXRpY051bWVyaWNOb2RlSWRSYW5nZQEAZi0ALgBEZi0AAAEAIwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0aWNTdHJpbmdOb2RlSWRQYXR0ZXJuAQBnLQAuAERnLQAAAAz/////AQH/////AAAAAARggAoBAAAAAAANAAAATmFtZXNwYWNlRmlsZQEAaC0ALwEASy1oLQAA/////woAAAAVYIkKAgAAAAAABAAAAFNpemUBAGktAC4ARGktAAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAkjEALgBEkjEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAkzEALgBEkzEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAbC0ALgBEbC0AAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAG0tAC8BADwtbS0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBuLQAuAERuLQAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAby0ALgBEby0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAcC0ALwEAPy1wLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHEtAC4ARHEtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAci0ALwEAQS1yLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMtAC4ARHMtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB0LQAuAER0LQAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQB1LQAvAQBELXUtAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAdi0ALgBEdi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAHctAC8BAEYtdy0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB4LQAuAER4LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAeS0ALgBEeS0AAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAHotAC8BAEktei0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB7LQAuAER7LQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAARGVmYXVsdFJvbGVQZXJtaXNzaW9ucwEACT8ALgBECT8AAABgAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAaAAAARGVmYXVsdFVzZXJSb2xlUGVybWlzc2lvbnMBAAo/AC4ARAo/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA";

	private PropertyState<string> m_namespaceUri;

	private PropertyState<string> m_namespaceVersion;

	private PropertyState<DateTime> m_namespacePublicationDate;

	private PropertyState<bool> m_isNamespaceSubset;

	private PropertyState<IdType[]> m_staticNodeIdTypes;

	private PropertyState<string[]> m_staticNumericNodeIdRange;

	private PropertyState<string> m_staticStringNodeIdPattern;

	private AddressSpaceFileState m_namespaceFile;

	private PropertyState<RolePermissionType[]> m_defaultRolePermissions;

	private PropertyState<RolePermissionType[]> m_defaultUserRolePermissions;

	private PropertyState<ushort> m_defaultAccessRestrictions;

	public PropertyState<string> NamespaceUri
	{
		get
		{
			return m_namespaceUri;
		}
		set
		{
			if (m_namespaceUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespaceUri = value;
		}
	}

	public PropertyState<string> NamespaceVersion
	{
		get
		{
			return m_namespaceVersion;
		}
		set
		{
			if (m_namespaceVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespaceVersion = value;
		}
	}

	public PropertyState<DateTime> NamespacePublicationDate
	{
		get
		{
			return m_namespacePublicationDate;
		}
		set
		{
			if (m_namespacePublicationDate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespacePublicationDate = value;
		}
	}

	public PropertyState<bool> IsNamespaceSubset
	{
		get
		{
			return m_isNamespaceSubset;
		}
		set
		{
			if (m_isNamespaceSubset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_isNamespaceSubset = value;
		}
	}

	public PropertyState<IdType[]> StaticNodeIdTypes
	{
		get
		{
			return m_staticNodeIdTypes;
		}
		set
		{
			if (m_staticNodeIdTypes != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_staticNodeIdTypes = value;
		}
	}

	public PropertyState<string[]> StaticNumericNodeIdRange
	{
		get
		{
			return m_staticNumericNodeIdRange;
		}
		set
		{
			if (m_staticNumericNodeIdRange != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_staticNumericNodeIdRange = value;
		}
	}

	public PropertyState<string> StaticStringNodeIdPattern
	{
		get
		{
			return m_staticStringNodeIdPattern;
		}
		set
		{
			if (m_staticStringNodeIdPattern != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_staticStringNodeIdPattern = value;
		}
	}

	public AddressSpaceFileState NamespaceFile
	{
		get
		{
			return m_namespaceFile;
		}
		set
		{
			if (m_namespaceFile != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_namespaceFile = value;
		}
	}

	public PropertyState<RolePermissionType[]> DefaultRolePermissions
	{
		get
		{
			return m_defaultRolePermissions;
		}
		set
		{
			if (m_defaultRolePermissions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_defaultRolePermissions = value;
		}
	}

	public PropertyState<RolePermissionType[]> DefaultUserRolePermissions
	{
		get
		{
			return m_defaultUserRolePermissions;
		}
		set
		{
			if (m_defaultUserRolePermissions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_defaultUserRolePermissions = value;
		}
	}

	public PropertyState<ushort> DefaultAccessRestrictions
	{
		get
		{
			return m_defaultAccessRestrictions;
		}
		set
		{
			if (m_defaultAccessRestrictions != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_defaultAccessRestrictions = value;
		}
	}

	public NamespaceMetadataState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11616u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHQAAAE5hbWVzcGFjZU1ldGFkYXRhVHlwZUluc3RhbmNlAQBgLQEAYC1gLQAA/////wsAAAAVYIkKAgAAAAAADAAAAE5hbWVzcGFjZVVyaQEAYS0ALgBEYS0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE5hbWVzcGFjZVZlcnNpb24BAGItAC4ARGItAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABOYW1lc3BhY2VQdWJsaWNhdGlvbkRhdGUBAGMtAC4ARGMtAAAADf////8BAf////8AAAAAFWCJCgIAAAAAABEAAABJc05hbWVzcGFjZVN1YnNldAEAZC0ALgBEZC0AAAAB/////wEB/////wAAAAAXYIkKAgAAAAAAEQAAAFN0YXRpY05vZGVJZFR5cGVzAQBlLQAuAERlLQAAAQAAAQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFN0YXRpY051bWVyaWNOb2RlSWRSYW5nZQEAZi0ALgBEZi0AAAEAIwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0aWNTdHJpbmdOb2RlSWRQYXR0ZXJuAQBnLQAuAERnLQAAAAz/////AQH/////AAAAAARggAoBAAAAAAANAAAATmFtZXNwYWNlRmlsZQEAaC0ALwEASy1oLQAA/////woAAAAVYIkKAgAAAAAABAAAAFNpemUBAGktAC4ARGktAAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAkjEALgBEkjEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAkzEALgBEkzEAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAbC0ALgBEbC0AAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAG0tAC8BADwtbS0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBuLQAuAERuLQAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAby0ALgBEby0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAcC0ALwEAPy1wLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHEtAC4ARHEtAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAci0ALwEAQS1yLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHMtAC4ARHMtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQB0LQAuAER0LQAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQB1LQAvAQBELXUtAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAdi0ALgBEdi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAHctAC8BAEYtdy0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB4LQAuAER4LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAeS0ALgBEeS0AAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAHotAC8BAEktei0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB7LQAuAER7LQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAWAAAARGVmYXVsdFJvbGVQZXJtaXNzaW9ucwEACT8ALgBECT8AAABgAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAaAAAARGVmYXVsdFVzZXJSb2xlUGVybWlzc2lvbnMBAAo/AC4ARAo/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA");
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
		if (NamespaceFile != null)
		{
			NamespaceFile.Initialize(context, "//////////8EYIAKAQAAAAAADQAAAE5hbWVzcGFjZUZpbGUBAGgtAC8BAEstaC0AAP////8KAAAAFWCJCgIAAAAAAAQAAABTaXplAQBpLQAuAERpLQAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJIxAC4ARJIxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJMxAC4ARJMxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAGwtAC4ARGwtAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQBtLQAvAQA8LW0tAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAbi0ALgBEbi0AAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAG8tAC4ARG8tAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAHAtAC8BAD8tcC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBxLQAuAERxLQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAHItAC8BAEEtci0AAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBzLQAuAERzLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAdC0ALgBEdC0AAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEAdS0ALwEARC11LQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAHYtAC4ARHYtAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQB3LQAvAQBGLXctAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAeC0ALgBEeC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAHktAC4ARHktAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQB6LQAvAQBJLXotAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAey0ALgBEey0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (DefaultRolePermissions != null)
		{
			DefaultRolePermissions.Initialize(context, "//////////8XYIkKAgAAAAAAFgAAAERlZmF1bHRSb2xlUGVybWlzc2lvbnMBAAk/AC4ARAk/AAAAYAEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (DefaultUserRolePermissions != null)
		{
			DefaultUserRolePermissions.Initialize(context, "//////////8XYIkKAgAAAAAAGgAAAERlZmF1bHRVc2VyUm9sZVBlcm1pc3Npb25zAQAKPwAuAEQKPwAAAGABAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (DefaultAccessRestrictions != null)
		{
			DefaultAccessRestrictions.Initialize(context, "//////////8VYIkKAgAAAAAAGQAAAERlZmF1bHRBY2Nlc3NSZXN0cmljdGlvbnMBAAs/AC4ARAs/AAAAX/////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_namespaceUri != null)
		{
			children.Add(m_namespaceUri);
		}
		if (m_namespaceVersion != null)
		{
			children.Add(m_namespaceVersion);
		}
		if (m_namespacePublicationDate != null)
		{
			children.Add(m_namespacePublicationDate);
		}
		if (m_isNamespaceSubset != null)
		{
			children.Add(m_isNamespaceSubset);
		}
		if (m_staticNodeIdTypes != null)
		{
			children.Add(m_staticNodeIdTypes);
		}
		if (m_staticNumericNodeIdRange != null)
		{
			children.Add(m_staticNumericNodeIdRange);
		}
		if (m_staticStringNodeIdPattern != null)
		{
			children.Add(m_staticStringNodeIdPattern);
		}
		if (m_namespaceFile != null)
		{
			children.Add(m_namespaceFile);
		}
		if (m_defaultRolePermissions != null)
		{
			children.Add(m_defaultRolePermissions);
		}
		if (m_defaultUserRolePermissions != null)
		{
			children.Add(m_defaultUserRolePermissions);
		}
		if (m_defaultAccessRestrictions != null)
		{
			children.Add(m_defaultAccessRestrictions);
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
		case "NamespaceUri":
			if (createOrReplace && NamespaceUri == null)
			{
				if (replacement == null)
				{
					NamespaceUri = new PropertyState<string>(this);
				}
				else
				{
					NamespaceUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = NamespaceUri;
			break;
		case "NamespaceVersion":
			if (createOrReplace && NamespaceVersion == null)
			{
				if (replacement == null)
				{
					NamespaceVersion = new PropertyState<string>(this);
				}
				else
				{
					NamespaceVersion = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = NamespaceVersion;
			break;
		case "NamespacePublicationDate":
			if (createOrReplace && NamespacePublicationDate == null)
			{
				if (replacement == null)
				{
					NamespacePublicationDate = new PropertyState<DateTime>(this);
				}
				else
				{
					NamespacePublicationDate = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = NamespacePublicationDate;
			break;
		case "IsNamespaceSubset":
			if (createOrReplace && IsNamespaceSubset == null)
			{
				if (replacement == null)
				{
					IsNamespaceSubset = new PropertyState<bool>(this);
				}
				else
				{
					IsNamespaceSubset = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = IsNamespaceSubset;
			break;
		case "StaticNodeIdTypes":
			if (createOrReplace && StaticNodeIdTypes == null)
			{
				if (replacement == null)
				{
					StaticNodeIdTypes = new PropertyState<IdType[]>(this);
				}
				else
				{
					StaticNodeIdTypes = (PropertyState<IdType[]>)replacement;
				}
			}
			baseInstanceState = StaticNodeIdTypes;
			break;
		case "StaticNumericNodeIdRange":
			if (createOrReplace && StaticNumericNodeIdRange == null)
			{
				if (replacement == null)
				{
					StaticNumericNodeIdRange = new PropertyState<string[]>(this);
				}
				else
				{
					StaticNumericNodeIdRange = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = StaticNumericNodeIdRange;
			break;
		case "StaticStringNodeIdPattern":
			if (createOrReplace && StaticStringNodeIdPattern == null)
			{
				if (replacement == null)
				{
					StaticStringNodeIdPattern = new PropertyState<string>(this);
				}
				else
				{
					StaticStringNodeIdPattern = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = StaticStringNodeIdPattern;
			break;
		case "NamespaceFile":
			if (createOrReplace && NamespaceFile == null)
			{
				if (replacement == null)
				{
					NamespaceFile = new AddressSpaceFileState(this);
				}
				else
				{
					NamespaceFile = (AddressSpaceFileState)replacement;
				}
			}
			baseInstanceState = NamespaceFile;
			break;
		case "DefaultRolePermissions":
			if (createOrReplace && DefaultRolePermissions == null)
			{
				if (replacement == null)
				{
					DefaultRolePermissions = new PropertyState<RolePermissionType[]>(this);
				}
				else
				{
					DefaultRolePermissions = (PropertyState<RolePermissionType[]>)replacement;
				}
			}
			baseInstanceState = DefaultRolePermissions;
			break;
		case "DefaultUserRolePermissions":
			if (createOrReplace && DefaultUserRolePermissions == null)
			{
				if (replacement == null)
				{
					DefaultUserRolePermissions = new PropertyState<RolePermissionType[]>(this);
				}
				else
				{
					DefaultUserRolePermissions = (PropertyState<RolePermissionType[]>)replacement;
				}
			}
			baseInstanceState = DefaultUserRolePermissions;
			break;
		case "DefaultAccessRestrictions":
			if (createOrReplace && DefaultAccessRestrictions == null)
			{
				if (replacement == null)
				{
					DefaultAccessRestrictions = new PropertyState<ushort>(this);
				}
				else
				{
					DefaultAccessRestrictions = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = DefaultAccessRestrictions;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
