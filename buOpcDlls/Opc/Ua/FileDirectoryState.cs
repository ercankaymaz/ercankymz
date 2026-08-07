// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FileDirectoryState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FileDirectoryState(NodeState parent) : FolderState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAEZpbGVEaXJlY3RvcnlUeXBlSW5zdGFuY2UBACk0AQApNCk0AAD/////BAAAAARhggoEAAAAAAAPAAAAQ3JlYXRlRGlyZWN0b3J5AQBLNAAvAQBLNEs0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDQALgBETDQAAJYBAAAAAQAqAQEcAAAADQAAAERpcmVjdG9yeU5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAE00AC4ARE00AACWAQAAAAEAKgEBHgAAAA8AAABEaXJlY3RvcnlOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABDcmVhdGVGaWxlAQBONAAvAQBONE40AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATzQALgBETzQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBQNAAuAERQNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGHCCgQAAAAWAAAARGVsZXRlRmlsZVN5c3RlbU9iamVjdAAABgAAAERlbGV0ZQEAUTQALwEAUTRRNAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFI0AC4ARFI0AACWAQAAAAEAKgEBHQAAAA4AAABPYmplY3RUb0RlbGV0ZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAE1vdmVPckNvcHkBAFM0AC8BAFM0UzQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBUNAAuAERUNAAAlgQAAAABACoBASEAAAASAAAAT2JqZWN0VG9Nb3ZlT3JDb3B5ABH/////AAAAAAABACoBAR4AAAAPAAAAVGFyZ2V0RGlyZWN0b3J5ABH/////AAAAAAABACoBARkAAAAKAAAAQ3JlYXRlQ29weQAB/////wAAAAAAAQAqAQEWAAAABwAAAE5ld05hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFU0AC4ARFU0AACWAQAAAAEAKgEBGAAAAAkAAABOZXdOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private CreateDirectoryMethodState m_createDirectoryMethod;
  private CreateFileMethodState m_createFileMethod;
  private DeleteFileMethodState m_deleteFileSystemObjectMethod;
  private MoveOrCopyMethodState m_moveOrCopyMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 13353U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGQAAAEZpbGVEaXJlY3RvcnlUeXBlSW5zdGFuY2UBACk0AQApNCk0AAD/////BAAAAARhggoEAAAAAAAPAAAAQ3JlYXRlRGlyZWN0b3J5AQBLNAAvAQBLNEs0AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATDQALgBETDQAAJYBAAAAAQAqAQEcAAAADQAAAERpcmVjdG9yeU5hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAE00AC4ARE00AACWAQAAAAEAKgEBHgAAAA8AAABEaXJlY3RvcnlOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAoAAABDcmVhdGVGaWxlAQBONAAvAQBONE40AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEATzQALgBETzQAAJYCAAAAAQAqAQEXAAAACAAAAEZpbGVOYW1lAAz/////AAAAAAABACoBAR4AAAAPAAAAUmVxdWVzdEZpbGVPcGVuAAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBQNAAuAERQNAAAlgIAAAABACoBARkAAAAKAAAARmlsZU5vZGVJZAAR/////wAAAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGHCCgQAAAAWAAAARGVsZXRlRmlsZVN5c3RlbU9iamVjdAAABgAAAERlbGV0ZQEAUTQALwEAUTRRNAAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFI0AC4ARFI0AACWAQAAAAEAKgEBHQAAAA4AAABPYmplY3RUb0RlbGV0ZQAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAE1vdmVPckNvcHkBAFM0AC8BAFM0UzQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBUNAAuAERUNAAAlgQAAAABACoBASEAAAASAAAAT2JqZWN0VG9Nb3ZlT3JDb3B5ABH/////AAAAAAABACoBAR4AAAAPAAAAVGFyZ2V0RGlyZWN0b3J5ABH/////AAAAAAABACoBARkAAAAKAAAAQ3JlYXRlQ29weQAB/////wAAAAAAAQAqAQEWAAAABwAAAE5ld05hbWUADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAFU0AC4ARFU0AACWAQAAAAEAKgEBGAAAAAkAAABOZXdOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
  }

  public CreateDirectoryMethodState CreateDirectory
  {
    get => this.m_createDirectoryMethod;
    set
    {
      if (this.m_createDirectoryMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createDirectoryMethod = value;
    }
  }

  public CreateFileMethodState CreateFile
  {
    get => this.m_createFileMethod;
    set
    {
      if (this.m_createFileMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createFileMethod = value;
    }
  }

  public DeleteFileMethodState DeleteFileSystemObject
  {
    get => this.m_deleteFileSystemObjectMethod;
    set
    {
      if (this.m_deleteFileSystemObjectMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteFileSystemObjectMethod = value;
    }
  }

  public MoveOrCopyMethodState MoveOrCopy
  {
    get => this.m_moveOrCopyMethod;
    set
    {
      if (this.m_moveOrCopyMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_moveOrCopyMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_createDirectoryMethod != null)
      children.Add((BaseInstanceState) this.m_createDirectoryMethod);
    if (this.m_createFileMethod != null)
      children.Add((BaseInstanceState) this.m_createFileMethod);
    if (this.m_deleteFileSystemObjectMethod != null)
      children.Add((BaseInstanceState) this.m_deleteFileSystemObjectMethod);
    if (this.m_moveOrCopyMethod != null)
      children.Add((BaseInstanceState) this.m_moveOrCopyMethod);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    switch (browseName.Name)
    {
      case "CreateDirectory":
        if (createOrReplace && this.CreateDirectory == null)
          this.CreateDirectory = replacement != null ? (CreateDirectoryMethodState) replacement : new CreateDirectoryMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CreateDirectory;
        break;
      case "CreateFile":
        if (createOrReplace && this.CreateFile == null)
          this.CreateFile = replacement != null ? (CreateFileMethodState) replacement : new CreateFileMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CreateFile;
        break;
      case "Delete":
        if (createOrReplace && this.DeleteFileSystemObject == null)
          this.DeleteFileSystemObject = replacement != null ? (DeleteFileMethodState) replacement : new DeleteFileMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.DeleteFileSystemObject;
        break;
      case "MoveOrCopy":
        if (createOrReplace && this.MoveOrCopy == null)
          this.MoveOrCopy = replacement != null ? (MoveOrCopyMethodState) replacement : new MoveOrCopyMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MoveOrCopy;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
