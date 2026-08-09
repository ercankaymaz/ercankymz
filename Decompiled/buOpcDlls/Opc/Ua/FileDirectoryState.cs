using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FileDirectoryState : FolderState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAEZpbGVEaXJlY3RvcnlUeXBlSW5zdGFuY2UBACk0AQApNCk0AAD/////BAAAAARhggoEAAAAAAAPAAAAQ3JlYXRlRGlyZWN0b3J5AQBLNAAvAQBLNEs0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDQALgBETDQAAJYBAAAAAQAqAQEcAAAADQAAAERpcmVjdG9yeU5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAE00AC4ARE00AACWAQAAAAEAKgEBHgAAAA8AAABEaXJlY3RvcnlOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABDcmVhdGVGaWxlAQBONAAvAQBONE40AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATzQALgBETzQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBQNAAuAERQNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGHCCgQAAAAWAAAARGVsZXRlRmlsZVN5c3RlbU9iamVjdAAABgAAAERlbGV0ZQEAUTQALwEAUTRRNAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFI0AC4ARFI0AACWAQAAAAEAKgEBHQAAAA4AAABPYmplY3RUb0RlbGV0ZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAE1vdmVPckNvcHkBAFM0AC8BAFM0UzQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBUNAAuAERUNAAAlgQAAAABACoBASEAAAASAAAAT2JqZWN0VG9Nb3ZlT3JDb3B5ABH/////AAAAAAABACoBAR4AAAAPAAAAVGFyZ2V0RGlyZWN0b3J5ABH/////AAAAAAABACoBARkAAAAKAAAAQ3JlYXRlQ29weQAB/////wAAAAAAAQAqAQEWAAAABwAAAE5ld05hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFU0AC4ARFU0AACWAQAAAAEAKgEBGAAAAAkAAABOZXdOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private CreateDirectoryMethodState m_createDirectoryMethod;

	private CreateFileMethodState m_createFileMethod;

	private DeleteFileMethodState m_deleteFileSystemObjectMethod;

	private MoveOrCopyMethodState m_moveOrCopyMethod;

	public CreateDirectoryMethodState CreateDirectory
	{
		get
		{
			return m_createDirectoryMethod;
		}
		set
		{
			if (m_createDirectoryMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createDirectoryMethod = value;
		}
	}

	public CreateFileMethodState CreateFile
	{
		get
		{
			return m_createFileMethod;
		}
		set
		{
			if (m_createFileMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createFileMethod = value;
		}
	}

	public DeleteFileMethodState DeleteFileSystemObject
	{
		get
		{
			return m_deleteFileSystemObjectMethod;
		}
		set
		{
			if (m_deleteFileSystemObjectMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteFileSystemObjectMethod = value;
		}
	}

	public MoveOrCopyMethodState MoveOrCopy
	{
		get
		{
			return m_moveOrCopyMethod;
		}
		set
		{
			if (m_moveOrCopyMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_moveOrCopyMethod = value;
		}
	}

	public FileDirectoryState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(13353u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGQAAAEZpbGVEaXJlY3RvcnlUeXBlSW5zdGFuY2UBACk0AQApNCk0AAD/////BAAAAARhggoEAAAAAAAPAAAAQ3JlYXRlRGlyZWN0b3J5AQBLNAAvAQBLNEs0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDQALgBETDQAAJYBAAAAAQAqAQEcAAAADQAAAERpcmVjdG9yeU5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAE00AC4ARE00AACWAQAAAAEAKgEBHgAAAA8AAABEaXJlY3RvcnlOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABDcmVhdGVGaWxlAQBONAAvAQBONE40AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATzQALgBETzQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBQNAAuAERQNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGHCCgQAAAAWAAAARGVsZXRlRmlsZVN5c3RlbU9iamVjdAAABgAAAERlbGV0ZQEAUTQALwEAUTRRNAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFI0AC4ARFI0AACWAQAAAAEAKgEBHQAAAA4AAABPYmplY3RUb0RlbGV0ZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAE1vdmVPckNvcHkBAFM0AC8BAFM0UzQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBUNAAuAERUNAAAlgQAAAABACoBASEAAAASAAAAT2JqZWN0VG9Nb3ZlT3JDb3B5ABH/////AAAAAAABACoBAR4AAAAPAAAAVGFyZ2V0RGlyZWN0b3J5ABH/////AAAAAAABACoBARkAAAAKAAAAQ3JlYXRlQ29weQAB/////wAAAAAAAQAqAQEWAAAABwAAAE5ld05hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFU0AC4ARFU0AACWAQAAAAEAKgEBGAAAAAkAAABOZXdOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_createDirectoryMethod != null)
		{
			children.Add(m_createDirectoryMethod);
		}
		if (m_createFileMethod != null)
		{
			children.Add(m_createFileMethod);
		}
		if (m_deleteFileSystemObjectMethod != null)
		{
			children.Add(m_deleteFileSystemObjectMethod);
		}
		if (m_moveOrCopyMethod != null)
		{
			children.Add(m_moveOrCopyMethod);
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
		case "CreateDirectory":
			if (createOrReplace && CreateDirectory == null)
			{
				if (replacement == null)
				{
					CreateDirectory = new CreateDirectoryMethodState(this);
				}
				else
				{
					CreateDirectory = (CreateDirectoryMethodState)replacement;
				}
			}
			baseInstanceState = CreateDirectory;
			break;
		case "CreateFile":
			if (createOrReplace && CreateFile == null)
			{
				if (replacement == null)
				{
					CreateFile = new CreateFileMethodState(this);
				}
				else
				{
					CreateFile = (CreateFileMethodState)replacement;
				}
			}
			baseInstanceState = CreateFile;
			break;
		case "Delete":
			if (createOrReplace && DeleteFileSystemObject == null)
			{
				if (replacement == null)
				{
					DeleteFileSystemObject = new DeleteFileMethodState(this);
				}
				else
				{
					DeleteFileSystemObject = (DeleteFileMethodState)replacement;
				}
			}
			baseInstanceState = DeleteFileSystemObject;
			break;
		case "MoveOrCopy":
			if (createOrReplace && MoveOrCopy == null)
			{
				if (replacement == null)
				{
					MoveOrCopy = new MoveOrCopyMethodState(this);
				}
				else
				{
					MoveOrCopy = (MoveOrCopyMethodState)replacement;
				}
			}
			baseInstanceState = MoveOrCopy;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
