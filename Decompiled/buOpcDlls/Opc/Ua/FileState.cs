using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FileState : BaseObjectState
{
	private const string MimeType_InitializationString = "//////////8VYIkKAgAAAAAACAAAAE1pbWVUeXBlAQAdNAAuAEQdNAAAAAz/////AQH/////AAAAAA==";

	private const string MaxByteStringLength_InitializationString = "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBALReAC4ARLReAAAAB/////8BAf////8AAAAA";

	private const string InitializationString = "//////////8EYIACAQAAAAAAEAAAAEZpbGVUeXBlSW5zdGFuY2UBADctAQA3LTctAAD/////DAAAABVgiQoCAAAAAAAEAAAAU2l6ZQEAOC0ALgBEOC0AAAAJ/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFdyaXRhYmxlAQCOMQAuAESOMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVXNlcldyaXRhYmxlAQCPMQAuAESPMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAT3BlbkNvdW50AQA7LQAuAEQ7LQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWltZVR5cGUBAB00AC4ARB00AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQC0XgAuAES0XgAAAAf/////AQH/////AAAAAARhggoEAAAAAAAEAAAAT3BlbgEAPC0ALwEAPC08LQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD0tAC4ARD0tAACWAQAAAAEAKgEBEwAAAAQAAABNb2RlAAP/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQA+LQAuAEQ+LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAENsb3NlAQA/LQAvAQA/LT8tAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQC0ALgBEQC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAQAAABSZWFkAQBBLQAvAQBBLUEtAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQi0ALgBEQi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYAAABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAEMtAC4AREMtAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAV3JpdGUBAEQtAC8BAEQtRC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBFLQAuAERFLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABHZXRQb3NpdGlvbgEARi0ALwEARi1GLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEctAC4AREctAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBILQAuAERILQAAlgEAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABTZXRQb3NpdGlvbgEASS0ALwEASS1JLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEotAC4AREotAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<ulong> m_size;

	private PropertyState<bool> m_writable;

	private PropertyState<bool> m_userWritable;

	private PropertyState<ushort> m_openCount;

	private PropertyState<string> m_mimeType;

	private PropertyState<uint> m_maxByteStringLength;

	private OpenMethodState m_openMethod;

	private CloseMethodState m_closeMethod;

	private ReadMethodState m_readMethod;

	private WriteMethodState m_writeMethod;

	private GetPositionMethodState m_getPositionMethod;

	private SetPositionMethodState m_setPositionMethod;

	public PropertyState<ulong> Size
	{
		get
		{
			return m_size;
		}
		set
		{
			if (m_size != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_size = value;
		}
	}

	public PropertyState<bool> Writable
	{
		get
		{
			return m_writable;
		}
		set
		{
			if (m_writable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_writable = value;
		}
	}

	public PropertyState<bool> UserWritable
	{
		get
		{
			return m_userWritable;
		}
		set
		{
			if (m_userWritable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_userWritable = value;
		}
	}

	public PropertyState<ushort> OpenCount
	{
		get
		{
			return m_openCount;
		}
		set
		{
			if (m_openCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_openCount = value;
		}
	}

	public PropertyState<string> MimeType
	{
		get
		{
			return m_mimeType;
		}
		set
		{
			if (m_mimeType != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_mimeType = value;
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

	public OpenMethodState Open
	{
		get
		{
			return m_openMethod;
		}
		set
		{
			if (m_openMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_openMethod = value;
		}
	}

	public CloseMethodState Close
	{
		get
		{
			return m_closeMethod;
		}
		set
		{
			if (m_closeMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_closeMethod = value;
		}
	}

	public ReadMethodState Read
	{
		get
		{
			return m_readMethod;
		}
		set
		{
			if (m_readMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_readMethod = value;
		}
	}

	public WriteMethodState Write
	{
		get
		{
			return m_writeMethod;
		}
		set
		{
			if (m_writeMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_writeMethod = value;
		}
	}

	public GetPositionMethodState GetPosition
	{
		get
		{
			return m_getPositionMethod;
		}
		set
		{
			if (m_getPositionMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_getPositionMethod = value;
		}
	}

	public SetPositionMethodState SetPosition
	{
		get
		{
			return m_setPositionMethod;
		}
		set
		{
			if (m_setPositionMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_setPositionMethod = value;
		}
	}

	public FileState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11575u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAEAAAAEZpbGVUeXBlSW5zdGFuY2UBADctAQA3LTctAAD/////DAAAABVgiQoCAAAAAAAEAAAAU2l6ZQEAOC0ALgBEOC0AAAAJ/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFdyaXRhYmxlAQCOMQAuAESOMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVXNlcldyaXRhYmxlAQCPMQAuAESPMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAT3BlbkNvdW50AQA7LQAuAEQ7LQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWltZVR5cGUBAB00AC4ARB00AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQC0XgAuAES0XgAAAAf/////AQH/////AAAAAARhggoEAAAAAAAEAAAAT3BlbgEAPC0ALwEAPC08LQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD0tAC4ARD0tAACWAQAAAAEAKgEBEwAAAAQAAABNb2RlAAP/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQA+LQAuAEQ+LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAENsb3NlAQA/LQAvAQA/LT8tAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQC0ALgBEQC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAQAAABSZWFkAQBBLQAvAQBBLUEtAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQi0ALgBEQi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYAAABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAEMtAC4AREMtAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAV3JpdGUBAEQtAC8BAEQtRC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBFLQAuAERFLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABHZXRQb3NpdGlvbgEARi0ALwEARi1GLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEctAC4AREctAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBILQAuAERILQAAlgEAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABTZXRQb3NpdGlvbgEASS0ALwEASS1JLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEotAC4AREotAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (MimeType != null)
		{
			MimeType.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAE1pbWVUeXBlAQAdNAAuAEQdNAAAAAz/////AQH/////AAAAAA==");
		}
		if (MaxByteStringLength != null)
		{
			MaxByteStringLength.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBALReAC4ARLReAAAAB/////8BAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_size != null)
		{
			children.Add(m_size);
		}
		if (m_writable != null)
		{
			children.Add(m_writable);
		}
		if (m_userWritable != null)
		{
			children.Add(m_userWritable);
		}
		if (m_openCount != null)
		{
			children.Add(m_openCount);
		}
		if (m_mimeType != null)
		{
			children.Add(m_mimeType);
		}
		if (m_maxByteStringLength != null)
		{
			children.Add(m_maxByteStringLength);
		}
		if (m_openMethod != null)
		{
			children.Add(m_openMethod);
		}
		if (m_closeMethod != null)
		{
			children.Add(m_closeMethod);
		}
		if (m_readMethod != null)
		{
			children.Add(m_readMethod);
		}
		if (m_writeMethod != null)
		{
			children.Add(m_writeMethod);
		}
		if (m_getPositionMethod != null)
		{
			children.Add(m_getPositionMethod);
		}
		if (m_setPositionMethod != null)
		{
			children.Add(m_setPositionMethod);
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
		case "Size":
			if (createOrReplace && Size == null)
			{
				if (replacement == null)
				{
					Size = new PropertyState<ulong>(this);
				}
				else
				{
					Size = (PropertyState<ulong>)replacement;
				}
			}
			baseInstanceState = Size;
			break;
		case "Writable":
			if (createOrReplace && Writable == null)
			{
				if (replacement == null)
				{
					Writable = new PropertyState<bool>(this);
				}
				else
				{
					Writable = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Writable;
			break;
		case "UserWritable":
			if (createOrReplace && UserWritable == null)
			{
				if (replacement == null)
				{
					UserWritable = new PropertyState<bool>(this);
				}
				else
				{
					UserWritable = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = UserWritable;
			break;
		case "OpenCount":
			if (createOrReplace && OpenCount == null)
			{
				if (replacement == null)
				{
					OpenCount = new PropertyState<ushort>(this);
				}
				else
				{
					OpenCount = (PropertyState<ushort>)replacement;
				}
			}
			baseInstanceState = OpenCount;
			break;
		case "MimeType":
			if (createOrReplace && MimeType == null)
			{
				if (replacement == null)
				{
					MimeType = new PropertyState<string>(this);
				}
				else
				{
					MimeType = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = MimeType;
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
		case "Open":
			if (createOrReplace && Open == null)
			{
				if (replacement == null)
				{
					Open = new OpenMethodState(this);
				}
				else
				{
					Open = (OpenMethodState)replacement;
				}
			}
			baseInstanceState = Open;
			break;
		case "Close":
			if (createOrReplace && Close == null)
			{
				if (replacement == null)
				{
					Close = new CloseMethodState(this);
				}
				else
				{
					Close = (CloseMethodState)replacement;
				}
			}
			baseInstanceState = Close;
			break;
		case "Read":
			if (createOrReplace && Read == null)
			{
				if (replacement == null)
				{
					Read = new ReadMethodState(this);
				}
				else
				{
					Read = (ReadMethodState)replacement;
				}
			}
			baseInstanceState = Read;
			break;
		case "Write":
			if (createOrReplace && Write == null)
			{
				if (replacement == null)
				{
					Write = new WriteMethodState(this);
				}
				else
				{
					Write = (WriteMethodState)replacement;
				}
			}
			baseInstanceState = Write;
			break;
		case "GetPosition":
			if (createOrReplace && GetPosition == null)
			{
				if (replacement == null)
				{
					GetPosition = new GetPositionMethodState(this);
				}
				else
				{
					GetPosition = (GetPositionMethodState)replacement;
				}
			}
			baseInstanceState = GetPosition;
			break;
		case "SetPosition":
			if (createOrReplace && SetPosition == null)
			{
				if (replacement == null)
				{
					SetPosition = new SetPositionMethodState(this);
				}
				else
				{
					SetPosition = (SetPositionMethodState)replacement;
				}
			}
			baseInstanceState = SetPosition;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
