// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetFolderState
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
public class DataSetFolderState(NodeState parent) : FolderState(parent)
{
  private const string AddPublishedDataItems_InitializationString = "//////////8EYYIKBAAAAAAAFQAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtcwEAnTgALwEAnTidOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJ44AC4ARJ44AACWBAAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBHwAAAAoAAABGaWVsZEZsYWdzAQAgPgEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ84AC4ARJ84AACWAwAAAAEAKgEBHAAAAA0AAABEYXRhU2V0Tm9kZUlkABH/////AAAAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string AddPublishedEvents_InitializationString = "//////////8EYYIKBAAAAAAAEgAAAEFkZFB1Ymxpc2hlZEV2ZW50cwEAoDgALwEAoDigOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKE4AC4ARKE4AACWBgAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBARwAAAANAAAARXZlbnROb3RpZmllcgAR/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACoBARcAAAAGAAAARmlsdGVyAQBKAv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKI4AC4ARKI4AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string AddPublishedDataItemsTemplate_InitializationString = "//////////8EYYIKBAAAAAAAHQAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlAQAnQgAvAQAnQidCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAPkIALgBEPkIAAJYDAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKgEBIAAAAA8AAABEYXRhU2V0TWV0YURhdGEBALs4/////wAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQA/QgAuAEQ/QgAAlgIAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string AddPublishedEventsTemplate_InitializationString = "//////////8EYYIKBAAAAAAAGgAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlAQBAQgAvAQBAQkBCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQUIALgBEQUIAAJYFAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKgEBIAAAAA8AAABEYXRhU2V0TWV0YURhdGEBALs4/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBLQgAuAERLQgAAlgEAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string RemovePublishedDataSet_InitializationString = "//////////8EYYIKBAAAAAAAFgAAAFJlbW92ZVB1Ymxpc2hlZERhdGFTZXQBAKM4AC8BAKM4ozgAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCkOAAuAESkOAAAlgEAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string AddDataSetFolder_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAEFkZERhdGFTZXRGb2xkZXIBAGJCAC8BAGJCYkIAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjQgAuAERjQgAAlgEAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEIALgBEZEIAAJYBAAAAAQAqAQEiAAAAEwAAAERhdGFTZXRGb2xkZXJOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string RemoveDataSetFolder_InitializationString = "//////////8EYYIKBAAAAAAAEwAAAFJlbW92ZURhdGFTZXRGb2xkZXIBAGVCAC8BAGVCZUIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBvQgAuAERvQgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldEZvbGRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "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";
  private AddPublishedDataItemsMethodState m_addPublishedDataItemsMethod;
  private AddPublishedEventsMethodState m_addPublishedEventsMethod;
  private AddPublishedDataItemsTemplateMethodState m_addPublishedDataItemsTemplateMethod;
  private AddPublishedEventsTemplateMethodState m_addPublishedEventsTemplateMethod;
  private RemovePublishedDataSetMethodState m_removePublishedDataSetMethod;
  private AddDataSetFolderMethodState m_addDataSetFolderMethod;
  private RemoveDataSetFolderMethodState m_removeDataSetFolderMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14477U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "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");
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
    if (this.AddPublishedDataItems != null)
      this.AddPublishedDataItems.Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtcwEAnTgALwEAnTidOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAJ44AC4ARJ44AACWBAAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBASMAAAAQAAAARmllbGROYW1lQWxpYXNlcwAMAQAAAAEAAAAAAAAAAAEAKgEBHwAAAAoAAABGaWVsZEZsYWdzAQAgPgEAAAABAAAAAAAAAAABACoBASMAAAAOAAAAVmFyaWFibGVzVG9BZGQBAME3AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAJ84AC4ARJ84AACWAwAAAAEAKgEBHAAAAA0AAABEYXRhU2V0Tm9kZUlkABH/////AAAAAAABACoBASUAAAAUAAAAQ29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.AddPublishedEvents != null)
      this.AddPublishedEvents.Initialize(context, "//////////8EYYIKBAAAAAAAEgAAAEFkZFB1Ymxpc2hlZEV2ZW50cwEAoDgALwEAoDigOAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAKE4AC4ARKE4AACWBgAAAAEAKgEBEwAAAAQAAABOYW1lAAz/////AAAAAAABACoBARwAAAANAAAARXZlbnROb3RpZmllcgAR/////wAAAAAAAQAqAQEjAAAAEAAAAEZpZWxkTmFtZUFsaWFzZXMADAEAAAABAAAAAAAAAAABACoBAR8AAAAKAAAARmllbGRGbGFncwEAID4BAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACoBARcAAAAGAAAARmlsdGVyAQBKAv////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAKI4AC4ARKI4AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.AddPublishedDataItemsTemplate != null)
      this.AddPublishedDataItemsTemplate.Initialize(context, "//////////8EYYIKBAAAAAAAHQAAAEFkZFB1Ymxpc2hlZERhdGFJdGVtc1RlbXBsYXRlAQAnQgAvAQAnQidCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAPkIALgBEPkIAAJYDAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKgEBIAAAAA8AAABEYXRhU2V0TWV0YURhdGEBALs4/////wAAAAAAAQAqAQEjAAAADgAAAFZhcmlhYmxlc1RvQWRkAQDBNwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQA/QgAuAEQ/QgAAlgIAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.AddPublishedEventsTemplate != null)
      this.AddPublishedEventsTemplate.Initialize(context, "//////////8EYYIKBAAAAAAAGgAAAEFkZFB1Ymxpc2hlZEV2ZW50c1RlbXBsYXRlAQBAQgAvAQBAQkBCAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAQUIALgBEQUIAAJYFAAAAAQAqAQETAAAABAAAAE5hbWUADP////8AAAAAAAEAKgEBIAAAAA8AAABEYXRhU2V0TWV0YURhdGEBALs4/////wAAAAAAAQAqAQEcAAAADQAAAEV2ZW50Tm90aWZpZXIAEf////8AAAAAAAEAKgEBIwAAAA4AAABTZWxlY3RlZEZpZWxkcwEAWQIBAAAAAQAAAAAAAAAAAQAqAQEXAAAABgAAAEZpbHRlcgEASgL/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBLQgAuAERLQgAAlgEAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.RemovePublishedDataSet != null)
      this.RemovePublishedDataSet.Initialize(context, "//////////8EYYIKBAAAAAAAFgAAAFJlbW92ZVB1Ymxpc2hlZERhdGFTZXQBAKM4AC8BAKM4ozgAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCkOAAuAESkOAAAlgEAAAABACoBARwAAAANAAAARGF0YVNldE5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.AddDataSetFolder != null)
      this.AddDataSetFolder.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAEFkZERhdGFTZXRGb2xkZXIBAGJCAC8BAGJCYkIAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjQgAuAERjQgAAlgEAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEIALgBEZEIAAJYBAAAAAQAqAQEiAAAAEwAAAERhdGFTZXRGb2xkZXJOb2RlSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.RemoveDataSetFolder == null)
      return;
    this.RemoveDataSetFolder.Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAFJlbW92ZURhdGFTZXRGb2xkZXIBAGVCAC8BAGVCZUIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBvQgAuAERvQgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldEZvbGRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public AddPublishedDataItemsMethodState AddPublishedDataItems
  {
    get => this.m_addPublishedDataItemsMethod;
    set
    {
      if (this.m_addPublishedDataItemsMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addPublishedDataItemsMethod = value;
    }
  }

  public AddPublishedEventsMethodState AddPublishedEvents
  {
    get => this.m_addPublishedEventsMethod;
    set
    {
      if (this.m_addPublishedEventsMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addPublishedEventsMethod = value;
    }
  }

  public AddPublishedDataItemsTemplateMethodState AddPublishedDataItemsTemplate
  {
    get => this.m_addPublishedDataItemsTemplateMethod;
    set
    {
      if (this.m_addPublishedDataItemsTemplateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addPublishedDataItemsTemplateMethod = value;
    }
  }

  public AddPublishedEventsTemplateMethodState AddPublishedEventsTemplate
  {
    get => this.m_addPublishedEventsTemplateMethod;
    set
    {
      if (this.m_addPublishedEventsTemplateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addPublishedEventsTemplateMethod = value;
    }
  }

  public RemovePublishedDataSetMethodState RemovePublishedDataSet
  {
    get => this.m_removePublishedDataSetMethod;
    set
    {
      if (this.m_removePublishedDataSetMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removePublishedDataSetMethod = value;
    }
  }

  public AddDataSetFolderMethodState AddDataSetFolder
  {
    get => this.m_addDataSetFolderMethod;
    set
    {
      if (this.m_addDataSetFolderMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addDataSetFolderMethod = value;
    }
  }

  public RemoveDataSetFolderMethodState RemoveDataSetFolder
  {
    get => this.m_removeDataSetFolderMethod;
    set
    {
      if (this.m_removeDataSetFolderMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeDataSetFolderMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_addPublishedDataItemsMethod != null)
      children.Add((BaseInstanceState) this.m_addPublishedDataItemsMethod);
    if (this.m_addPublishedEventsMethod != null)
      children.Add((BaseInstanceState) this.m_addPublishedEventsMethod);
    if (this.m_addPublishedDataItemsTemplateMethod != null)
      children.Add((BaseInstanceState) this.m_addPublishedDataItemsTemplateMethod);
    if (this.m_addPublishedEventsTemplateMethod != null)
      children.Add((BaseInstanceState) this.m_addPublishedEventsTemplateMethod);
    if (this.m_removePublishedDataSetMethod != null)
      children.Add((BaseInstanceState) this.m_removePublishedDataSetMethod);
    if (this.m_addDataSetFolderMethod != null)
      children.Add((BaseInstanceState) this.m_addDataSetFolderMethod);
    if (this.m_removeDataSetFolderMethod != null)
      children.Add((BaseInstanceState) this.m_removeDataSetFolderMethod);
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
        case 16 /*0x10*/:
          if (name == "AddDataSetFolder")
          {
            if (createOrReplace && this.AddDataSetFolder == null)
              this.AddDataSetFolder = replacement != null ? (AddDataSetFolderMethodState) replacement : new AddDataSetFolderMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddDataSetFolder;
            break;
          }
          break;
        case 18:
          if (name == "AddPublishedEvents")
          {
            if (createOrReplace && this.AddPublishedEvents == null)
              this.AddPublishedEvents = replacement != null ? (AddPublishedEventsMethodState) replacement : new AddPublishedEventsMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddPublishedEvents;
            break;
          }
          break;
        case 19:
          if (name == "RemoveDataSetFolder")
          {
            if (createOrReplace && this.RemoveDataSetFolder == null)
              this.RemoveDataSetFolder = replacement != null ? (RemoveDataSetFolderMethodState) replacement : new RemoveDataSetFolderMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RemoveDataSetFolder;
            break;
          }
          break;
        case 21:
          if (name == "AddPublishedDataItems")
          {
            if (createOrReplace && this.AddPublishedDataItems == null)
              this.AddPublishedDataItems = replacement != null ? (AddPublishedDataItemsMethodState) replacement : new AddPublishedDataItemsMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddPublishedDataItems;
            break;
          }
          break;
        case 22:
          if (name == "RemovePublishedDataSet")
          {
            if (createOrReplace && this.RemovePublishedDataSet == null)
              this.RemovePublishedDataSet = replacement != null ? (RemovePublishedDataSetMethodState) replacement : new RemovePublishedDataSetMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RemovePublishedDataSet;
            break;
          }
          break;
        case 26:
          if (name == "AddPublishedEventsTemplate")
          {
            if (createOrReplace && this.AddPublishedEventsTemplate == null)
              this.AddPublishedEventsTemplate = replacement != null ? (AddPublishedEventsTemplateMethodState) replacement : new AddPublishedEventsTemplateMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddPublishedEventsTemplate;
            break;
          }
          break;
        case 29:
          if (name == "AddPublishedDataItemsTemplate")
          {
            if (createOrReplace && this.AddPublishedDataItemsTemplate == null)
              this.AddPublishedDataItemsTemplate = replacement != null ? (AddPublishedDataItemsTemplateMethodState) replacement : new AddPublishedDataItemsTemplateMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddPublishedDataItemsTemplate;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
