// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FileState
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
public class FileState(NodeState parent) : BaseObjectState(parent)
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

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11575U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAEAAAAEZpbGVUeXBlSW5zdGFuY2UBADctAQA3LTctAAD/////DAAAABVgiQoCAAAAAAAEAAAAU2l6ZQEAOC0ALgBEOC0AAAAJ/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFdyaXRhYmxlAQCOMQAuAESOMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAVXNlcldyaXRhYmxlAQCPMQAuAESPMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAT3BlbkNvdW50AQA7LQAuAEQ7LQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWltZVR5cGUBAB00AC4ARB00AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQC0XgAuAES0XgAAAAf/////AQH/////AAAAAARhggoEAAAAAAAEAAAAT3BlbgEAPC0ALwEAPC08LQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAD0tAC4ARD0tAACWAQAAAAEAKgEBEwAAAAQAAABNb2RlAAP/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQA+LQAuAEQ+LQAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAENsb3NlAQA/LQAvAQA/LT8tAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQC0ALgBEQC0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAQAAABSZWFkAQBBLQAvAQBBLUEtAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQi0ALgBEQi0AAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBFQAAAAYAAABMZW5ndGgABv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAEMtAC4AREMtAACWAQAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAFAAAAV3JpdGUBAEQtAC8BAEQtRC0AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBFLQAuAERFLQAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQETAAAABAAAAERhdGEAD/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABHZXRQb3NpdGlvbgEARi0ALwEARi1GLQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEctAC4AREctAACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBILQAuAERILQAAlgEAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABTZXRQb3NpdGlvbgEASS0ALwEASS1JLQAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAEotAC4AREotAACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARcAAAAIAAAAUG9zaXRpb24ACf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.MimeType != null)
      this.MimeType.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAE1pbWVUeXBlAQAdNAAuAEQdNAAAAAz/////AQH/////AAAAAA==");
    if (this.MaxByteStringLength == null)
      return;
    this.MaxByteStringLength.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBALReAC4ARLReAAAAB/////8BAf////8AAAAA");
  }

  public PropertyState<ulong> Size
  {
    get => this.m_size;
    set
    {
      if (this.m_size != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_size = value;
    }
  }

  public PropertyState<bool> Writable
  {
    get => this.m_writable;
    set
    {
      if (this.m_writable != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_writable = value;
    }
  }

  public PropertyState<bool> UserWritable
  {
    get => this.m_userWritable;
    set
    {
      if (this.m_userWritable != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_userWritable = value;
    }
  }

  public PropertyState<ushort> OpenCount
  {
    get => this.m_openCount;
    set
    {
      if (this.m_openCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_openCount = value;
    }
  }

  public PropertyState<string> MimeType
  {
    get => this.m_mimeType;
    set
    {
      if (this.m_mimeType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_mimeType = value;
    }
  }

  public PropertyState<uint> MaxByteStringLength
  {
    get => this.m_maxByteStringLength;
    set
    {
      if (this.m_maxByteStringLength != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxByteStringLength = value;
    }
  }

  public OpenMethodState Open
  {
    get => this.m_openMethod;
    set
    {
      if (this.m_openMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_openMethod = value;
    }
  }

  public CloseMethodState Close
  {
    get => this.m_closeMethod;
    set
    {
      if (this.m_closeMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_closeMethod = value;
    }
  }

  public ReadMethodState Read
  {
    get => this.m_readMethod;
    set
    {
      if (this.m_readMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_readMethod = value;
    }
  }

  public WriteMethodState Write
  {
    get => this.m_writeMethod;
    set
    {
      if (this.m_writeMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_writeMethod = value;
    }
  }

  public GetPositionMethodState GetPosition
  {
    get => this.m_getPositionMethod;
    set
    {
      if (this.m_getPositionMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getPositionMethod = value;
    }
  }

  public SetPositionMethodState SetPosition
  {
    get => this.m_setPositionMethod;
    set
    {
      if (this.m_setPositionMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setPositionMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_size != null)
      children.Add((BaseInstanceState) this.m_size);
    if (this.m_writable != null)
      children.Add((BaseInstanceState) this.m_writable);
    if (this.m_userWritable != null)
      children.Add((BaseInstanceState) this.m_userWritable);
    if (this.m_openCount != null)
      children.Add((BaseInstanceState) this.m_openCount);
    if (this.m_mimeType != null)
      children.Add((BaseInstanceState) this.m_mimeType);
    if (this.m_maxByteStringLength != null)
      children.Add((BaseInstanceState) this.m_maxByteStringLength);
    if (this.m_openMethod != null)
      children.Add((BaseInstanceState) this.m_openMethod);
    if (this.m_closeMethod != null)
      children.Add((BaseInstanceState) this.m_closeMethod);
    if (this.m_readMethod != null)
      children.Add((BaseInstanceState) this.m_readMethod);
    if (this.m_writeMethod != null)
      children.Add((BaseInstanceState) this.m_writeMethod);
    if (this.m_getPositionMethod != null)
      children.Add((BaseInstanceState) this.m_getPositionMethod);
    if (this.m_setPositionMethod != null)
      children.Add((BaseInstanceState) this.m_setPositionMethod);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 4:
          switch (name[0])
          {
            case 'O':
              if (name == "Open")
              {
                if (createOrReplace && this.Open == null)
                  this.Open = replacement != null ? (OpenMethodState) replacement : new OpenMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Open;
                break;
              }
              break;
            case 'R':
              if (name == "Read")
              {
                if (createOrReplace && this.Read == null)
                  this.Read = replacement != null ? (ReadMethodState) replacement : new ReadMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Read;
                break;
              }
              break;
            case 'S':
              if (name == "Size")
              {
                if (createOrReplace && this.Size == null)
                  this.Size = replacement != null ? (PropertyState<ulong>) replacement : new PropertyState<ulong>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Size;
                break;
              }
              break;
          }
          break;
        case 5:
          switch (name[0])
          {
            case 'C':
              if (name == "Close")
              {
                if (createOrReplace && this.Close == null)
                  this.Close = replacement != null ? (CloseMethodState) replacement : new CloseMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Close;
                break;
              }
              break;
            case 'W':
              if (name == "Write")
              {
                if (createOrReplace && this.Write == null)
                  this.Write = replacement != null ? (WriteMethodState) replacement : new WriteMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Write;
                break;
              }
              break;
          }
          break;
        case 8:
          switch (name[0])
          {
            case 'M':
              if (name == "MimeType")
              {
                if (createOrReplace && this.MimeType == null)
                  this.MimeType = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MimeType;
                break;
              }
              break;
            case 'W':
              if (name == "Writable")
              {
                if (createOrReplace && this.Writable == null)
                  this.Writable = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Writable;
                break;
              }
              break;
          }
          break;
        case 9:
          if (name == "OpenCount")
          {
            if (createOrReplace && this.OpenCount == null)
              this.OpenCount = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.OpenCount;
            break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'G':
              if (name == "GetPosition")
              {
                if (createOrReplace && this.GetPosition == null)
                  this.GetPosition = replacement != null ? (GetPositionMethodState) replacement : new GetPositionMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.GetPosition;
                break;
              }
              break;
            case 'S':
              if (name == "SetPosition")
              {
                if (createOrReplace && this.SetPosition == null)
                  this.SetPosition = replacement != null ? (SetPositionMethodState) replacement : new SetPositionMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SetPosition;
                break;
              }
              break;
          }
          break;
        case 12:
          if (name == "UserWritable")
          {
            if (createOrReplace && this.UserWritable == null)
              this.UserWritable = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.UserWritable;
            break;
          }
          break;
        case 19:
          if (name == "MaxByteStringLength")
          {
            if (createOrReplace && this.MaxByteStringLength == null)
              this.MaxByteStringLength = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxByteStringLength;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
