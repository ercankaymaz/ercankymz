// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExtensionFieldsState
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
public class ExtensionFieldsState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAEV4dGVuc2lvbkZpZWxkc1R5cGVJbnN0YW5jZQEAgTwBAIE8gTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAgzwALwEAgzyDPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQ8AC4ARIQ8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCFPAAuAESFPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQCGPAAvAQCGPIY8AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhzwALgBEhzwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private AddExtensionFieldMethodState m_addExtensionFieldMethod;
  private RemoveExtensionFieldMethodState m_removeExtensionFieldMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15489U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAEV4dGVuc2lvbkZpZWxkc1R5cGVJbnN0YW5jZQEAgTwBAIE8gTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAgzwALwEAgzyDPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQ8AC4ARIQ8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCFPAAuAESFPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQCGPAAvAQCGPIY8AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhzwALgBEhzwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public AddExtensionFieldMethodState AddExtensionField
  {
    get => this.m_addExtensionFieldMethod;
    set
    {
      if (this.m_addExtensionFieldMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addExtensionFieldMethod = value;
    }
  }

  public RemoveExtensionFieldMethodState RemoveExtensionField
  {
    get => this.m_removeExtensionFieldMethod;
    set
    {
      if (this.m_removeExtensionFieldMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeExtensionFieldMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_addExtensionFieldMethod != null)
      children.Add((BaseInstanceState) this.m_addExtensionFieldMethod);
    if (this.m_removeExtensionFieldMethod != null)
      children.Add((BaseInstanceState) this.m_removeExtensionFieldMethod);
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
      case "AddExtensionField":
        if (createOrReplace && this.AddExtensionField == null)
          this.AddExtensionField = replacement != null ? (AddExtensionFieldMethodState) replacement : new AddExtensionFieldMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AddExtensionField;
        break;
      case "RemoveExtensionField":
        if (createOrReplace && this.RemoveExtensionField == null)
          this.RemoveExtensionField = replacement != null ? (RemoveExtensionFieldMethodState) replacement : new RemoveExtensionFieldMethodState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RemoveExtensionField;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
