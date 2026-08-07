// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TemporaryFileTransferState
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
public class TemporaryFileTransferState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAFRlbXBvcmFyeUZpbGVUcmFuc2ZlclR5cGVJbnN0YW5jZQEAgD0BAIA9gD0AAP////8EAAAAFWCJCgIAAAAAABcAAABDbGllbnRQcm9jZXNzaW5nVGltZW91dAEAgT0ALgBEgT0AAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAATAAAAR2VuZXJhdGVGaWxlRm9yUmVhZAEAgj0ALwEAgj2CPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIM9AC4ARIM9AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIQ9AC4ARIQ9AACWAwAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQElAAAAFgAAAENvbXBsZXRpb25TdGF0ZU1hY2hpbmUAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABQAAABHZW5lcmF0ZUZpbGVGb3JXcml0ZQEAhT0ALwEAhT2FPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOc/AC4AROc/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIY9AC4ARIY9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAENsb3NlQW5kQ29tbWl0AQCHPQAvAQCHPYc9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAiD0ALgBEiD0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIk9AC4ARIk9AACWAQAAAAEAKgEBJQAAABYAAABDb21wbGV0aW9uU3RhdGVNYWNoaW5lABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<double> m_clientProcessingTimeout;
  private GenerateFileForReadMethodState m_generateFileForReadMethod;
  private GenerateFileForWriteMethodState m_generateFileForWriteMethod;
  private CloseAndCommitMethodState m_closeAndCommitMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15744U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAFRlbXBvcmFyeUZpbGVUcmFuc2ZlclR5cGVJbnN0YW5jZQEAgD0BAIA9gD0AAP////8EAAAAFWCJCgIAAAAAABcAAABDbGllbnRQcm9jZXNzaW5nVGltZW91dAEAgT0ALgBEgT0AAAEAIgH/////AQH/////AAAAAARhggoEAAAAAAATAAAAR2VuZXJhdGVGaWxlRm9yUmVhZAEAgj0ALwEAgj2CPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIM9AC4ARIM9AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIQ9AC4ARIQ9AACWAwAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQElAAAAFgAAAENvbXBsZXRpb25TdGF0ZU1hY2hpbmUAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABQAAABHZW5lcmF0ZUZpbGVGb3JXcml0ZQEAhT0ALwEAhT2FPQAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOc/AC4AROc/AACWAQAAAAEAKgEBHgAAAA8AAABHZW5lcmF0ZU9wdGlvbnMAGP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIY9AC4ARIY9AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlTm9kZUlkABH/////AAAAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAENsb3NlQW5kQ29tbWl0AQCHPQAvAQCHPYc9AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAiD0ALgBEiD0AAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIk9AC4ARIk9AACWAQAAAAEAKgEBJQAAABYAAABDb21wbGV0aW9uU3RhdGVNYWNoaW5lABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<double> ClientProcessingTimeout
  {
    get => this.m_clientProcessingTimeout;
    set
    {
      if (this.m_clientProcessingTimeout != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientProcessingTimeout = value;
    }
  }

  public GenerateFileForReadMethodState GenerateFileForRead
  {
    get => this.m_generateFileForReadMethod;
    set
    {
      if (this.m_generateFileForReadMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_generateFileForReadMethod = value;
    }
  }

  public GenerateFileForWriteMethodState GenerateFileForWrite
  {
    get => this.m_generateFileForWriteMethod;
    set
    {
      if (this.m_generateFileForWriteMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_generateFileForWriteMethod = value;
    }
  }

  public CloseAndCommitMethodState CloseAndCommit
  {
    get => this.m_closeAndCommitMethod;
    set
    {
      if (this.m_closeAndCommitMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_closeAndCommitMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_clientProcessingTimeout != null)
      children.Add((BaseInstanceState) this.m_clientProcessingTimeout);
    if (this.m_generateFileForReadMethod != null)
      children.Add((BaseInstanceState) this.m_generateFileForReadMethod);
    if (this.m_generateFileForWriteMethod != null)
      children.Add((BaseInstanceState) this.m_generateFileForWriteMethod);
    if (this.m_closeAndCommitMethod != null)
      children.Add((BaseInstanceState) this.m_closeAndCommitMethod);
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
      case "ClientProcessingTimeout":
        if (createOrReplace && this.ClientProcessingTimeout == null)
          this.ClientProcessingTimeout = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientProcessingTimeout;
        break;
      case "GenerateFileForRead":
        if (createOrReplace && this.GenerateFileForRead == null)
          this.GenerateFileForRead = replacement != null ? (GenerateFileForReadMethodState) replacement : new GenerateFileForReadMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GenerateFileForRead;
        break;
      case "GenerateFileForWrite":
        if (createOrReplace && this.GenerateFileForWrite == null)
          this.GenerateFileForWrite = replacement != null ? (GenerateFileForWriteMethodState) replacement : new GenerateFileForWriteMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.GenerateFileForWrite;
        break;
      case "CloseAndCommit":
        if (createOrReplace && this.CloseAndCommit == null)
          this.CloseAndCommit = replacement != null ? (CloseAndCommitMethodState) replacement : new CloseAndCommitMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CloseAndCommit;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
