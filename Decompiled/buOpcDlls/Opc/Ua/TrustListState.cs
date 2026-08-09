using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TrustListState : FileState
{
	private const string UpdateFrequency_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFVwZGF0ZUZyZXF1ZW5jeQEAYEsALgBEYEsAAAEAIgH/////AQH/////AAAAAA==";

	private const string CloseAndUpdate_InitializationString = "//////////8EYYIKBAAAAAAADgAAAENsb3NlQW5kVXBkYXRlAQACMQAvAQACMQIxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoTEALgBEoTEAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAMxAC4ARAMxAACWAQAAAAEAKgEBIwAAABQAAABBcHBseUNoYW5nZXNSZXF1aXJlZAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string AddCertificate_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZENlcnRpZmljYXRlAQAEMQAvAQAEMQQxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABTEALgBEBTEAAJYCAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private const string RemoveCertificate_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAFRydXN0TGlzdFR5cGVJbnN0YW5jZQEA6jABAOow6jAAAP////8QAAAAFWCJCgIAAAAAAAQAAABTaXplAQDrMAAuAETrMAAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJoxAC4ARJoxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJsxAC4ARJsxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAO4wAC4ARO4wAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQDvMAAvAQA8Le8wAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA8DAALgBE8DAAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPEwAC4ARPEwAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAPIwAC8BAD8t8jAAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDzMAAuAETzMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAPQwAC8BAEEt9DAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD1MAAuAET1MAAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA9jAALgBE9jAAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEA9zAALwEARC33MAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPgwAC4ARPgwAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQD5MAAvAQBGLfkwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA+jAALgBE+jAAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPswAC4ARPswAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQD8MAAvAQBJLfwwAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA/TAALgBE/TAAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD+MAAuAET+MAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAGBLAC4ARGBLAAABACIB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBAP8wAC8BAP8w/zAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAAMQAuAEQAMQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAExAC4ARAExAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBAAIxAC8BAAIxAjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQChMQAuAEShMQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAAzEALgBEAzEAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hhbmdlc1JlcXVpcmVkAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkQ2VydGlmaWNhdGUBAAQxAC8BAAQxBDEAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAFMQAuAEQFMQAAlgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<DateTime> m_lastUpdateTime;

	private PropertyState<double> m_updateFrequency;

	private OpenWithMasksMethodState m_openWithMasksMethod;

	private CloseAndUpdateMethodState m_closeAndUpdateMethod;

	private AddCertificateMethodState m_addCertificateMethod;

	private RemoveCertificateMethodState m_removeCertificateMethod;

	public PropertyState<DateTime> LastUpdateTime
	{
		get
		{
			return m_lastUpdateTime;
		}
		set
		{
			if (m_lastUpdateTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lastUpdateTime = value;
		}
	}

	public PropertyState<double> UpdateFrequency
	{
		get
		{
			return m_updateFrequency;
		}
		set
		{
			if (m_updateFrequency != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateFrequency = value;
		}
	}

	public OpenWithMasksMethodState OpenWithMasks
	{
		get
		{
			return m_openWithMasksMethod;
		}
		set
		{
			if (m_openWithMasksMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_openWithMasksMethod = value;
		}
	}

	public CloseAndUpdateMethodState CloseAndUpdate
	{
		get
		{
			return m_closeAndUpdateMethod;
		}
		set
		{
			if (m_closeAndUpdateMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_closeAndUpdateMethod = value;
		}
	}

	public AddCertificateMethodState AddCertificate
	{
		get
		{
			return m_addCertificateMethod;
		}
		set
		{
			if (m_addCertificateMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addCertificateMethod = value;
		}
	}

	public RemoveCertificateMethodState RemoveCertificate
	{
		get
		{
			return m_removeCertificateMethod;
		}
		set
		{
			if (m_removeCertificateMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeCertificateMethod = value;
		}
	}

	public TrustListState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12522u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFQAAAFRydXN0TGlzdFR5cGVJbnN0YW5jZQEA6jABAOow6jAAAP////8QAAAAFWCJCgIAAAAAAAQAAABTaXplAQDrMAAuAETrMAAAAAn/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAV3JpdGFibGUBAJoxAC4ARJoxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABVc2VyV3JpdGFibGUBAJsxAC4ARJsxAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABPcGVuQ291bnQBAO4wAC4ARO4wAAAABf////8BAf////8AAAAABGGCCgQAAAAAAAQAAABPcGVuAQDvMAAvAQA8Le8wAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA8DAALgBE8DAAAJYBAAAAAQAqAQETAAAABAAAAE1vZGUAA/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPEwAC4ARPEwAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAQ2xvc2UBAPIwAC8BAD8t8jAAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDzMAAuAETzMAAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABAAAAFJlYWQBAPQwAC8BAEEt9DAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD1MAAuAET1MAAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEVAAAABgAAAExlbmd0aAAG/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEA9jAALgBE9jAAAJYBAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABXcml0ZQEA9zAALwEARC33MAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAPgwAC4ARPgwAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAEdldFBvc2l0aW9uAQD5MAAvAQBGLfkwAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA+jAALgBE+jAAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAPswAC4ARPswAACWAQAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFNldFBvc2l0aW9uAQD8MAAvAQBJLfwwAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA/TAALgBE/TAAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFwAAAAgAAABQb3NpdGlvbgAJ/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RVcGRhdGVUaW1lAQD+MAAuAET+MAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABVcGRhdGVGcmVxdWVuY3kBAGBLAC4ARGBLAAABACIB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5XaXRoTWFza3MBAP8wAC8BAP8w/zAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAAMQAuAEQAMQAAlgEAAAABACoBARQAAAAFAAAATWFza3MAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAExAC4ARAExAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQ2xvc2VBbmRVcGRhdGUBAAIxAC8BAAIxAjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQChMQAuAEShMQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAAzEALgBEAzEAAJYBAAAAAQAqAQEjAAAAFAAAAEFwcGx5Q2hhbmdlc1JlcXVpcmVkAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkQ2VydGlmaWNhdGUBAAQxAC8BAAQxBDEAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAFMQAuAEQFMQAAlgIAAAABACoBARoAAAALAAAAQ2VydGlmaWNhdGUAD/////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (UpdateFrequency != null)
		{
			UpdateFrequency.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFVwZGF0ZUZyZXF1ZW5jeQEAYEsALgBEYEsAAAEAIgH/////AQH/////AAAAAA==");
		}
		if (CloseAndUpdate != null)
		{
			CloseAndUpdate.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAENsb3NlQW5kVXBkYXRlAQACMQAvAQACMQIxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoTEALgBEoTEAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAAMxAC4ARAMxAACWAQAAAAEAKgEBIwAAABQAAABBcHBseUNoYW5nZXNSZXF1aXJlZAAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (AddCertificate != null)
		{
			AddCertificate.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZENlcnRpZmljYXRlAQAEMQAvAQAEMQQxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABTEALgBEBTEAAJYCAAAAAQAqAQEaAAAACwAAAENlcnRpZmljYXRlAA//////AAAAAAABACoBASMAAAAUAAAASXNUcnVzdGVkQ2VydGlmaWNhdGUAAf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (RemoveCertificate != null)
		{
			RemoveCertificate.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUNlcnRpZmljYXRlAQAGMQAvAQAGMQYxAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEABzEALgBEBzEAAJYCAAAAAQAqAQEZAAAACgAAAFRodW1icHJpbnQADP////8AAAAAAAEAKgEBIwAAABQAAABJc1RydXN0ZWRDZXJ0aWZpY2F0ZQAB/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_lastUpdateTime != null)
		{
			children.Add(m_lastUpdateTime);
		}
		if (m_updateFrequency != null)
		{
			children.Add(m_updateFrequency);
		}
		if (m_openWithMasksMethod != null)
		{
			children.Add(m_openWithMasksMethod);
		}
		if (m_closeAndUpdateMethod != null)
		{
			children.Add(m_closeAndUpdateMethod);
		}
		if (m_addCertificateMethod != null)
		{
			children.Add(m_addCertificateMethod);
		}
		if (m_removeCertificateMethod != null)
		{
			children.Add(m_removeCertificateMethod);
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
		case "LastUpdateTime":
			if (createOrReplace && LastUpdateTime == null)
			{
				if (replacement == null)
				{
					LastUpdateTime = new PropertyState<DateTime>(this);
				}
				else
				{
					LastUpdateTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = LastUpdateTime;
			break;
		case "UpdateFrequency":
			if (createOrReplace && UpdateFrequency == null)
			{
				if (replacement == null)
				{
					UpdateFrequency = new PropertyState<double>(this);
				}
				else
				{
					UpdateFrequency = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = UpdateFrequency;
			break;
		case "OpenWithMasks":
			if (createOrReplace && OpenWithMasks == null)
			{
				if (replacement == null)
				{
					OpenWithMasks = new OpenWithMasksMethodState(this);
				}
				else
				{
					OpenWithMasks = (OpenWithMasksMethodState)replacement;
				}
			}
			baseInstanceState = OpenWithMasks;
			break;
		case "CloseAndUpdate":
			if (createOrReplace && CloseAndUpdate == null)
			{
				if (replacement == null)
				{
					CloseAndUpdate = new CloseAndUpdateMethodState(this);
				}
				else
				{
					CloseAndUpdate = (CloseAndUpdateMethodState)replacement;
				}
			}
			baseInstanceState = CloseAndUpdate;
			break;
		case "AddCertificate":
			if (createOrReplace && AddCertificate == null)
			{
				if (replacement == null)
				{
					AddCertificate = new AddCertificateMethodState(this);
				}
				else
				{
					AddCertificate = (AddCertificateMethodState)replacement;
				}
			}
			baseInstanceState = AddCertificate;
			break;
		case "RemoveCertificate":
			if (createOrReplace && RemoveCertificate == null)
			{
				if (replacement == null)
				{
					RemoveCertificate = new RemoveCertificateMethodState(this);
				}
				else
				{
					RemoveCertificate = (RemoveCertificateMethodState)replacement;
				}
			}
			baseInstanceState = RemoveCertificate;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
