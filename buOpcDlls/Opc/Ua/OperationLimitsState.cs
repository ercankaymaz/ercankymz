// Decompiled with JetBrains decompiler
// Type: Opc.Ua.OperationLimitsState
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
public class OperationLimitsState(NodeState parent) : FolderState(parent)
{
  private const string MaxNodesPerRead_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heE5vZGVzUGVyUmVhZAEALS0ALgBELS0AAAAH/////wEB/////wAAAAA=";
  private const string MaxNodesPerHistoryReadData_InitializationString = "//////////8VYIkKAgAAAAAAGgAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWREYXRhAQCBLwAuAESBLwAAAAf/////AQH/////AAAAAA==";
  private const string MaxNodesPerHistoryReadEvents_InitializationString = "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAA";
  private const string MaxNodesPerWrite_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAE1heE5vZGVzUGVyV3JpdGUBAC8tAC4ARC8tAAAAB/////8BAf////8AAAAA";
  private const string MaxNodesPerHistoryUpdateData_InitializationString = "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZURhdGEBAIMvAC4ARIMvAAAAB/////8BAf////8AAAAA";
  private const string MaxNodesPerHistoryUpdateEvents_InitializationString = "//////////8VYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAA=";
  private const string MaxNodesPerMethodCall_InitializationString = "//////////8VYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAA=";
  private const string MaxNodesPerBrowse_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAAA==";
  private const string MaxNodesPerRegisterNodes_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAE1heE5vZGVzUGVyUmVnaXN0ZXJOb2RlcwEAMy0ALgBEMy0AAAAH/////wEB/////wAAAAA=";
  private const string MaxNodesPerTranslateBrowsePathsToNodeIds_InitializationString = "//////////8VYIkKAgAAAAAAKAAAAE1heE5vZGVzUGVyVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHMBADQtAC4ARDQtAAAAB/////8BAf////8AAAAA";
  private const string MaxNodesPerNodeManagement_InitializationString = "//////////8VYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAA";
  private const string MaxMonitoredItemsPerCall_InitializationString = "//////////8VYIkKAgAAAAAAGAAAAE1heE1vbml0b3JlZEl0ZW1zUGVyQ2FsbAEANi0ALgBENi0AAAAH/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAE9wZXJhdGlvbkxpbWl0c1R5cGVJbnN0YW5jZQEALC0BACwtLC0AAP////8MAAAAFWCJCgIAAAAAAA8AAABNYXhOb2Rlc1BlclJlYWQBAC0tAC4ARC0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb2Rlc1Blckhpc3RvcnlSZWFkRGF0YQEAgS8ALgBEgS8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABNYXhOb2Rlc1BlcldyaXRlAQAvLQAuAEQvLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAATWF4Tm9kZXNQZXJIaXN0b3J5VXBkYXRlRGF0YQEAgy8ALgBEgy8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAATWF4Tm9kZXNQZXJSZWdpc3Rlck5vZGVzAQAzLQAuAEQzLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAoAAAATWF4Tm9kZXNQZXJUcmFuc2xhdGVCcm93c2VQYXRoc1RvTm9kZUlkcwEANC0ALgBENC0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABNYXhNb25pdG9yZWRJdGVtc1BlckNhbGwBADYtAC4ARDYtAAAAB/////8BAf////8AAAAA";
  private PropertyState<uint> m_maxNodesPerRead;
  private PropertyState<uint> m_maxNodesPerHistoryReadData;
  private PropertyState<uint> m_maxNodesPerHistoryReadEvents;
  private PropertyState<uint> m_maxNodesPerWrite;
  private PropertyState<uint> m_maxNodesPerHistoryUpdateData;
  private PropertyState<uint> m_maxNodesPerHistoryUpdateEvents;
  private PropertyState<uint> m_maxNodesPerMethodCall;
  private PropertyState<uint> m_maxNodesPerBrowse;
  private PropertyState<uint> m_maxNodesPerRegisterNodes;
  private PropertyState<uint> m_maxNodesPerTranslateBrowsePathsToNodeIds;
  private PropertyState<uint> m_maxNodesPerNodeManagement;
  private PropertyState<uint> m_maxMonitoredItemsPerCall;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11564U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAE9wZXJhdGlvbkxpbWl0c1R5cGVJbnN0YW5jZQEALC0BACwtLC0AAP////8MAAAAFWCJCgIAAAAAAA8AAABNYXhOb2Rlc1BlclJlYWQBAC0tAC4ARC0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhOb2Rlc1Blckhpc3RvcnlSZWFkRGF0YQEAgS8ALgBEgS8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABAAAABNYXhOb2Rlc1BlcldyaXRlAQAvLQAuAEQvLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAcAAAATWF4Tm9kZXNQZXJIaXN0b3J5VXBkYXRlRGF0YQEAgy8ALgBEgy8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAATWF4Tm9kZXNQZXJSZWdpc3Rlck5vZGVzAQAzLQAuAEQzLQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAoAAAATWF4Tm9kZXNQZXJUcmFuc2xhdGVCcm93c2VQYXRoc1RvTm9kZUlkcwEANC0ALgBENC0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABgAAABNYXhNb25pdG9yZWRJdGVtc1BlckNhbGwBADYtAC4ARDYtAAAAB/////8BAf////8AAAAA");
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
    if (this.MaxNodesPerRead != null)
      this.MaxNodesPerRead.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heE5vZGVzUGVyUmVhZAEALS0ALgBELS0AAAAH/////wEB/////wAAAAA=");
    if (this.MaxNodesPerHistoryReadData != null)
      this.MaxNodesPerHistoryReadData.Initialize(context, "//////////8VYIkKAgAAAAAAGgAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWREYXRhAQCBLwAuAESBLwAAAAf/////AQH/////AAAAAA==");
    if (this.MaxNodesPerHistoryReadEvents != null)
      this.MaxNodesPerHistoryReadEvents.Initialize(context, "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVJlYWRFdmVudHMBAIIvAC4ARIIvAAAAB/////8BAf////8AAAAA");
    if (this.MaxNodesPerWrite != null)
      this.MaxNodesPerWrite.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAE1heE5vZGVzUGVyV3JpdGUBAC8tAC4ARC8tAAAAB/////8BAf////8AAAAA");
    if (this.MaxNodesPerHistoryUpdateData != null)
      this.MaxNodesPerHistoryUpdateData.Initialize(context, "//////////8VYIkKAgAAAAAAHAAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZURhdGEBAIMvAC4ARIMvAAAAB/////8BAf////8AAAAA");
    if (this.MaxNodesPerHistoryUpdateEvents != null)
      this.MaxNodesPerHistoryUpdateEvents.Initialize(context, "//////////8VYIkKAgAAAAAAHgAAAE1heE5vZGVzUGVySGlzdG9yeVVwZGF0ZUV2ZW50cwEAhC8ALgBEhC8AAAAH/////wEB/////wAAAAA=");
    if (this.MaxNodesPerMethodCall != null)
      this.MaxNodesPerMethodCall.Initialize(context, "//////////8VYIkKAgAAAAAAFQAAAE1heE5vZGVzUGVyTWV0aG9kQ2FsbAEAMS0ALgBEMS0AAAAH/////wEB/////wAAAAA=");
    if (this.MaxNodesPerBrowse != null)
      this.MaxNodesPerBrowse.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAE1heE5vZGVzUGVyQnJvd3NlAQAyLQAuAEQyLQAAAAf/////AQH/////AAAAAA==");
    if (this.MaxNodesPerRegisterNodes != null)
      this.MaxNodesPerRegisterNodes.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAE1heE5vZGVzUGVyUmVnaXN0ZXJOb2RlcwEAMy0ALgBEMy0AAAAH/////wEB/////wAAAAA=");
    if (this.MaxNodesPerTranslateBrowsePathsToNodeIds != null)
      this.MaxNodesPerTranslateBrowsePathsToNodeIds.Initialize(context, "//////////8VYIkKAgAAAAAAKAAAAE1heE5vZGVzUGVyVHJhbnNsYXRlQnJvd3NlUGF0aHNUb05vZGVJZHMBADQtAC4ARDQtAAAAB/////8BAf////8AAAAA");
    if (this.MaxNodesPerNodeManagement != null)
      this.MaxNodesPerNodeManagement.Initialize(context, "//////////8VYIkKAgAAAAAAGQAAAE1heE5vZGVzUGVyTm9kZU1hbmFnZW1lbnQBADUtAC4ARDUtAAAAB/////8BAf////8AAAAA");
    if (this.MaxMonitoredItemsPerCall == null)
      return;
    this.MaxMonitoredItemsPerCall.Initialize(context, "//////////8VYIkKAgAAAAAAGAAAAE1heE1vbml0b3JlZEl0ZW1zUGVyQ2FsbAEANi0ALgBENi0AAAAH/////wEB/////wAAAAA=");
  }

  public PropertyState<uint> MaxNodesPerRead
  {
    get => this.m_maxNodesPerRead;
    set
    {
      if (this.m_maxNodesPerRead != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerRead = value;
    }
  }

  public PropertyState<uint> MaxNodesPerHistoryReadData
  {
    get => this.m_maxNodesPerHistoryReadData;
    set
    {
      if (this.m_maxNodesPerHistoryReadData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerHistoryReadData = value;
    }
  }

  public PropertyState<uint> MaxNodesPerHistoryReadEvents
  {
    get => this.m_maxNodesPerHistoryReadEvents;
    set
    {
      if (this.m_maxNodesPerHistoryReadEvents != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerHistoryReadEvents = value;
    }
  }

  public PropertyState<uint> MaxNodesPerWrite
  {
    get => this.m_maxNodesPerWrite;
    set
    {
      if (this.m_maxNodesPerWrite != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerWrite = value;
    }
  }

  public PropertyState<uint> MaxNodesPerHistoryUpdateData
  {
    get => this.m_maxNodesPerHistoryUpdateData;
    set
    {
      if (this.m_maxNodesPerHistoryUpdateData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerHistoryUpdateData = value;
    }
  }

  public PropertyState<uint> MaxNodesPerHistoryUpdateEvents
  {
    get => this.m_maxNodesPerHistoryUpdateEvents;
    set
    {
      if (this.m_maxNodesPerHistoryUpdateEvents != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerHistoryUpdateEvents = value;
    }
  }

  public PropertyState<uint> MaxNodesPerMethodCall
  {
    get => this.m_maxNodesPerMethodCall;
    set
    {
      if (this.m_maxNodesPerMethodCall != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerMethodCall = value;
    }
  }

  public PropertyState<uint> MaxNodesPerBrowse
  {
    get => this.m_maxNodesPerBrowse;
    set
    {
      if (this.m_maxNodesPerBrowse != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerBrowse = value;
    }
  }

  public PropertyState<uint> MaxNodesPerRegisterNodes
  {
    get => this.m_maxNodesPerRegisterNodes;
    set
    {
      if (this.m_maxNodesPerRegisterNodes != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerRegisterNodes = value;
    }
  }

  public PropertyState<uint> MaxNodesPerTranslateBrowsePathsToNodeIds
  {
    get => this.m_maxNodesPerTranslateBrowsePathsToNodeIds;
    set
    {
      if (this.m_maxNodesPerTranslateBrowsePathsToNodeIds != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerTranslateBrowsePathsToNodeIds = value;
    }
  }

  public PropertyState<uint> MaxNodesPerNodeManagement
  {
    get => this.m_maxNodesPerNodeManagement;
    set
    {
      if (this.m_maxNodesPerNodeManagement != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxNodesPerNodeManagement = value;
    }
  }

  public PropertyState<uint> MaxMonitoredItemsPerCall
  {
    get => this.m_maxMonitoredItemsPerCall;
    set
    {
      if (this.m_maxMonitoredItemsPerCall != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxMonitoredItemsPerCall = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_maxNodesPerRead != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerRead);
    if (this.m_maxNodesPerHistoryReadData != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerHistoryReadData);
    if (this.m_maxNodesPerHistoryReadEvents != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerHistoryReadEvents);
    if (this.m_maxNodesPerWrite != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerWrite);
    if (this.m_maxNodesPerHistoryUpdateData != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerHistoryUpdateData);
    if (this.m_maxNodesPerHistoryUpdateEvents != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerHistoryUpdateEvents);
    if (this.m_maxNodesPerMethodCall != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerMethodCall);
    if (this.m_maxNodesPerBrowse != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerBrowse);
    if (this.m_maxNodesPerRegisterNodes != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerRegisterNodes);
    if (this.m_maxNodesPerTranslateBrowsePathsToNodeIds != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerTranslateBrowsePathsToNodeIds);
    if (this.m_maxNodesPerNodeManagement != null)
      children.Add((BaseInstanceState) this.m_maxNodesPerNodeManagement);
    if (this.m_maxMonitoredItemsPerCall != null)
      children.Add((BaseInstanceState) this.m_maxMonitoredItemsPerCall);
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
        case 15:
          if (name == "MaxNodesPerRead")
          {
            if (createOrReplace && this.MaxNodesPerRead == null)
              this.MaxNodesPerRead = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerRead;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "MaxNodesPerWrite")
          {
            if (createOrReplace && this.MaxNodesPerWrite == null)
              this.MaxNodesPerWrite = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerWrite;
            break;
          }
          break;
        case 17:
          if (name == "MaxNodesPerBrowse")
          {
            if (createOrReplace && this.MaxNodesPerBrowse == null)
              this.MaxNodesPerBrowse = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerBrowse;
            break;
          }
          break;
        case 21:
          if (name == "MaxNodesPerMethodCall")
          {
            if (createOrReplace && this.MaxNodesPerMethodCall == null)
              this.MaxNodesPerMethodCall = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerMethodCall;
            break;
          }
          break;
        case 24:
          switch (name[3])
          {
            case 'M':
              if (name == "MaxMonitoredItemsPerCall")
              {
                if (createOrReplace && this.MaxMonitoredItemsPerCall == null)
                  this.MaxMonitoredItemsPerCall = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxMonitoredItemsPerCall;
                break;
              }
              break;
            case 'N':
              if (name == "MaxNodesPerRegisterNodes")
              {
                if (createOrReplace && this.MaxNodesPerRegisterNodes == null)
                  this.MaxNodesPerRegisterNodes = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxNodesPerRegisterNodes;
                break;
              }
              break;
          }
          break;
        case 25:
          if (name == "MaxNodesPerNodeManagement")
          {
            if (createOrReplace && this.MaxNodesPerNodeManagement == null)
              this.MaxNodesPerNodeManagement = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerNodeManagement;
            break;
          }
          break;
        case 26:
          if (name == "MaxNodesPerHistoryReadData")
          {
            if (createOrReplace && this.MaxNodesPerHistoryReadData == null)
              this.MaxNodesPerHistoryReadData = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerHistoryReadData;
            break;
          }
          break;
        case 28:
          switch (name[18])
          {
            case 'R':
              if (name == "MaxNodesPerHistoryReadEvents")
              {
                if (createOrReplace && this.MaxNodesPerHistoryReadEvents == null)
                  this.MaxNodesPerHistoryReadEvents = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxNodesPerHistoryReadEvents;
                break;
              }
              break;
            case 'U':
              if (name == "MaxNodesPerHistoryUpdateData")
              {
                if (createOrReplace && this.MaxNodesPerHistoryUpdateData == null)
                  this.MaxNodesPerHistoryUpdateData = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxNodesPerHistoryUpdateData;
                break;
              }
              break;
          }
          break;
        case 30:
          if (name == "MaxNodesPerHistoryUpdateEvents")
          {
            if (createOrReplace && this.MaxNodesPerHistoryUpdateEvents == null)
              this.MaxNodesPerHistoryUpdateEvents = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerHistoryUpdateEvents;
            break;
          }
          break;
        case 40:
          if (name == "MaxNodesPerTranslateBrowsePathsToNodeIds")
          {
            if (createOrReplace && this.MaxNodesPerTranslateBrowsePathsToNodeIds == null)
              this.MaxNodesPerTranslateBrowsePathsToNodeIds = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxNodesPerTranslateBrowsePathsToNodeIds;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
