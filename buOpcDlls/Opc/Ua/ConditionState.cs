// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ConditionState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ConditionState(NodeState parent) : BaseEventState(parent)
{
  private const string ConditionSubClassId_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string ConditionSubClassName_InitializationString = "//////////8XYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFQAAAENvbmRpdGlvblR5cGVJbnN0YW5jZQEA3goBAN4K3goAAP////8XAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAZDwAuAEQZDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQAaDwAuAEQaDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAGw8ALgBEGw8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABwPAC4ARBwPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAdDwAuAEQdDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAHg8ALgBEHg8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAIA8ALgBEIA8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAhDwAuAEQhDwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaCsALgBEaCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaSsALgBEaSsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAMSMALgBEMSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQAyIwAuAEQyIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQAiDwAuAEQiDwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQAzIwAvAQAjIzMjAAAAFf////8BAf////8GAAAAFWCJCgIAAAAAAAIAAABJZAEANCMALgBENCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQA3IwAuAEQ3IwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADgjAC4ARDgjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQA5IwAuAEQ5IwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBADojAC4ARDojAAAVAwIAAABlbgcAAABFbmFibGVkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAOyMALgBEOyMAABUDAgAAAGVuCAAAAERpc2FibGVkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAPCMALwEAKiM8IwAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQA9IwAuAEQ9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAD4jAC8BACojPiMAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAPyMALgBEPyMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAQCMALwEAKiNAIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBBIwAuAERBIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEIjAC4AREIjAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQBEIwAvAQBEI0QjAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAEMjAC8BAEMjQyMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAEUjAC8BAEUjRSMAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBGIwAuAERGIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<NodeId> m_conditionClassId;
  private PropertyState<LocalizedText> m_conditionClassName;
  private PropertyState<NodeId[]> m_conditionSubClassId;
  private PropertyState<LocalizedText[]> m_conditionSubClassName;
  private PropertyState<string> m_conditionName;
  private PropertyState<NodeId> m_branchId;
  private PropertyState<bool> m_retain;
  private TwoStateVariableState m_enabledState;
  private ConditionVariableState<StatusCode> m_quality;
  private ConditionVariableState<ushort> m_lastSeverity;
  private ConditionVariableState<LocalizedText> m_comment;
  private PropertyState<string> m_clientUserId;
  private MethodState m_disableMethod;
  private MethodState m_enableMethod;
  private AddCommentMethodState m_addCommentMethod;
  public ConditionEnableEventHandler OnEnableDisable;
  public ConditionAddCommentEventHandler OnAddComment;
  private bool m_autoReportStateChanges;
  protected Dictionary<string, ConditionState> m_branches;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2782U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFQAAAENvbmRpdGlvblR5cGVJbnN0YW5jZQEA3goBAN4K3goAAP////8XAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAZDwAuAEQZDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQAaDwAuAEQaDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAGw8ALgBEGw8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABwPAC4ARBwPAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAdDwAuAEQdDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAHg8ALgBEHg8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAIA8ALgBEIA8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAhDwAuAEQhDwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQ29uZGl0aW9uQ2xhc3NJZAEAaCsALgBEaCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENvbmRpdGlvbkNsYXNzTmFtZQEAaSsALgBEaSsAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAMSMALgBEMSMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQAyIwAuAEQyIwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQAiDwAuAEQiDwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQAzIwAvAQAjIzMjAAAAFf////8BAf////8GAAAAFWCJCgIAAAAAAAIAAABJZAEANCMALgBENCMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQA3IwAuAEQ3IwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADgjAC4ARDgjAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQA5IwAuAEQ5IwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBADojAC4ARDojAAAVAwIAAABlbgcAAABFbmFibGVkABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAOyMALgBEOyMAABUDAgAAAGVuCAAAAERpc2FibGVkABX/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAPCMALwEAKiM8IwAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQA9IwAuAEQ9IwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAD4jAC8BACojPiMAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAPyMALgBEPyMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAQCMALwEAKiNAIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQBBIwAuAERBIwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEIjAC4AREIjAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQBEIwAvAQBEI0QjAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAEMjAC8BAEMjQyMAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAEUjAC8BAEUjRSMAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBGIwAuAERGIwAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.ConditionSubClassId != null)
      this.ConditionSubClassId.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAENvbmRpdGlvblN1YkNsYXNzSWQBAOs/AC4AROs/AAAAEQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.ConditionSubClassName == null)
      return;
    this.ConditionSubClassName.Initialize(context, "//////////8XYIkKAgAAAAAAFQAAAENvbmRpdGlvblN1YkNsYXNzTmFtZQEA7D8ALgBE7D8AAAAVAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState<NodeId> ConditionClassId
  {
    get => this.m_conditionClassId;
    set
    {
      if (this.m_conditionClassId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionClassId = value;
    }
  }

  public PropertyState<LocalizedText> ConditionClassName
  {
    get => this.m_conditionClassName;
    set
    {
      if (this.m_conditionClassName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionClassName = value;
    }
  }

  public PropertyState<NodeId[]> ConditionSubClassId
  {
    get => this.m_conditionSubClassId;
    set
    {
      if (this.m_conditionSubClassId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionSubClassId = value;
    }
  }

  public PropertyState<LocalizedText[]> ConditionSubClassName
  {
    get => this.m_conditionSubClassName;
    set
    {
      if (this.m_conditionSubClassName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionSubClassName = value;
    }
  }

  public PropertyState<string> ConditionName
  {
    get => this.m_conditionName;
    set
    {
      if (this.m_conditionName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_conditionName = value;
    }
  }

  public PropertyState<NodeId> BranchId
  {
    get => this.m_branchId;
    set
    {
      if (this.m_branchId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_branchId = value;
    }
  }

  public PropertyState<bool> Retain
  {
    get => this.m_retain;
    set
    {
      if (this.m_retain != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_retain = value;
    }
  }

  public TwoStateVariableState EnabledState
  {
    get => this.m_enabledState;
    set
    {
      if (this.m_enabledState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enabledState = value;
    }
  }

  public ConditionVariableState<StatusCode> Quality
  {
    get => this.m_quality;
    set
    {
      if (this.m_quality != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_quality = value;
    }
  }

  public ConditionVariableState<ushort> LastSeverity
  {
    get => this.m_lastSeverity;
    set
    {
      if (this.m_lastSeverity != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lastSeverity = value;
    }
  }

  public ConditionVariableState<LocalizedText> Comment
  {
    get => this.m_comment;
    set
    {
      if (this.m_comment != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_comment = value;
    }
  }

  public PropertyState<string> ClientUserId
  {
    get => this.m_clientUserId;
    set
    {
      if (this.m_clientUserId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientUserId = value;
    }
  }

  public MethodState Disable
  {
    get => this.m_disableMethod;
    set
    {
      if (this.m_disableMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_disableMethod = value;
    }
  }

  public MethodState Enable
  {
    get => this.m_enableMethod;
    set
    {
      if (this.m_enableMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_enableMethod = value;
    }
  }

  public AddCommentMethodState AddComment
  {
    get => this.m_addCommentMethod;
    set
    {
      if (this.m_addCommentMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addCommentMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_conditionClassId != null)
      children.Add((BaseInstanceState) this.m_conditionClassId);
    if (this.m_conditionClassName != null)
      children.Add((BaseInstanceState) this.m_conditionClassName);
    if (this.m_conditionSubClassId != null)
      children.Add((BaseInstanceState) this.m_conditionSubClassId);
    if (this.m_conditionSubClassName != null)
      children.Add((BaseInstanceState) this.m_conditionSubClassName);
    if (this.m_conditionName != null)
      children.Add((BaseInstanceState) this.m_conditionName);
    if (this.m_branchId != null)
      children.Add((BaseInstanceState) this.m_branchId);
    if (this.m_retain != null)
      children.Add((BaseInstanceState) this.m_retain);
    if (this.m_enabledState != null)
      children.Add((BaseInstanceState) this.m_enabledState);
    if (this.m_quality != null)
      children.Add((BaseInstanceState) this.m_quality);
    if (this.m_lastSeverity != null)
      children.Add((BaseInstanceState) this.m_lastSeverity);
    if (this.m_comment != null)
      children.Add((BaseInstanceState) this.m_comment);
    if (this.m_clientUserId != null)
      children.Add((BaseInstanceState) this.m_clientUserId);
    if (this.m_disableMethod != null)
      children.Add((BaseInstanceState) this.m_disableMethod);
    if (this.m_enableMethod != null)
      children.Add((BaseInstanceState) this.m_enableMethod);
    if (this.m_addCommentMethod != null)
      children.Add((BaseInstanceState) this.m_addCommentMethod);
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
        case 6:
          switch (name[0])
          {
            case 'E':
              if (name == "Enable")
              {
                if (createOrReplace && this.Enable == null)
                  this.Enable = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Enable;
                break;
              }
              break;
            case 'R':
              if (name == "Retain")
              {
                if (createOrReplace && this.Retain == null)
                  this.Retain = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Retain;
                break;
              }
              break;
          }
          break;
        case 7:
          switch (name[0])
          {
            case 'C':
              if (name == "Comment")
              {
                if (createOrReplace && this.Comment == null)
                  this.Comment = replacement != null ? (ConditionVariableState<LocalizedText>) replacement : new ConditionVariableState<LocalizedText>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Comment;
                break;
              }
              break;
            case 'D':
              if (name == "Disable")
              {
                if (createOrReplace && this.Disable == null)
                  this.Disable = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Disable;
                break;
              }
              break;
            case 'Q':
              if (name == "Quality")
              {
                if (createOrReplace && this.Quality == null)
                  this.Quality = replacement != null ? (ConditionVariableState<StatusCode>) replacement : new ConditionVariableState<StatusCode>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Quality;
                break;
              }
              break;
          }
          break;
        case 8:
          if (name == "BranchId")
          {
            if (createOrReplace && this.BranchId == null)
              this.BranchId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.BranchId;
            break;
          }
          break;
        case 10:
          if (name == "AddComment")
          {
            if (createOrReplace && this.AddComment == null)
              this.AddComment = replacement != null ? (AddCommentMethodState) replacement : new AddCommentMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddComment;
            break;
          }
          break;
        case 12:
          switch (name[0])
          {
            case 'C':
              if (name == "ClientUserId")
              {
                if (createOrReplace && this.ClientUserId == null)
                  this.ClientUserId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ClientUserId;
                break;
              }
              break;
            case 'E':
              if (name == "EnabledState")
              {
                if (createOrReplace && this.EnabledState == null)
                  this.EnabledState = replacement != null ? (TwoStateVariableState) replacement : new TwoStateVariableState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.EnabledState;
                break;
              }
              break;
            case 'L':
              if (name == "LastSeverity")
              {
                if (createOrReplace && this.LastSeverity == null)
                  this.LastSeverity = replacement != null ? (ConditionVariableState<ushort>) replacement : new ConditionVariableState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.LastSeverity;
                break;
              }
              break;
          }
          break;
        case 13:
          if (name == "ConditionName")
          {
            if (createOrReplace && this.ConditionName == null)
              this.ConditionName = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConditionName;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "ConditionClassId")
          {
            if (createOrReplace && this.ConditionClassId == null)
              this.ConditionClassId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConditionClassId;
            break;
          }
          break;
        case 18:
          if (name == "ConditionClassName")
          {
            if (createOrReplace && this.ConditionClassName == null)
              this.ConditionClassName = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConditionClassName;
            break;
          }
          break;
        case 19:
          if (name == "ConditionSubClassId")
          {
            if (createOrReplace && this.ConditionSubClassId == null)
              this.ConditionSubClassId = replacement != null ? (PropertyState<NodeId[]>) replacement : new PropertyState<NodeId[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConditionSubClassId;
            break;
          }
          break;
        case 21:
          if (name == "ConditionSubClassName")
          {
            if (createOrReplace && this.ConditionSubClassName == null)
              this.ConditionSubClassName = replacement != null ? (PropertyState<LocalizedText[]>) replacement : new PropertyState<LocalizedText[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConditionSubClassName;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  protected override void OnAfterCreate(ISystemContext context, NodeState node)
  {
    base.OnAfterCreate(context, node);
    if (this.Enable != null)
      this.Enable.OnCallMethod = new GenericMethodCalledEventHandler(this.OnEnableCalled);
    if (this.Disable != null)
      this.Disable.OnCallMethod = new GenericMethodCalledEventHandler(this.OnDisableCalled);
    if (this.AddComment == null)
      return;
    this.AddComment.OnCall = new AddCommentMethodStateMethodCallHandler(this.OnAddCommentCalled);
  }

  public bool AutoReportStateChanges
  {
    get => this.m_autoReportStateChanges;
    set => this.m_autoReportStateChanges = value;
  }

  public virtual void SetEffectiveSubState(
    ISystemContext context,
    LocalizedText displayName,
    DateTime transitionTime)
  {
    if (this.EnabledState.EffectiveDisplayName != null)
      this.EnabledState.EffectiveDisplayName.Value = displayName;
    if (this.EnabledState.EffectiveTransitionTime == null)
      return;
    if (transitionTime != DateTime.MinValue)
      this.EnabledState.EffectiveTransitionTime.Value = transitionTime;
    else
      this.EnabledState.EffectiveTransitionTime.Value = DateTime.UtcNow;
  }

  public virtual void SetEnableState(ISystemContext context, bool enabled)
  {
    if (enabled)
      this.UpdateStateAfterEnable(context);
    else
      this.UpdateStateAfterDisable(context);
  }

  public virtual void SetSeverity(ISystemContext context, EventSeverity severity)
  {
    this.LastSeverity.Value = this.Severity.Value;
    this.Severity.Value = (ushort) severity;
    if (this.LastSeverity.SourceTimestamp == null)
      return;
    this.LastSeverity.SourceTimestamp.Value = DateTime.UtcNow;
  }

  public virtual void SetComment(
    ISystemContext context,
    LocalizedText comment,
    string clientUserId)
  {
    if (this.Comment == null)
      return;
    this.Comment.Value = comment;
    this.Comment.SourceTimestamp.Value = DateTime.UtcNow;
    if (this.ClientUserId == null)
      return;
    this.ClientUserId.Value = clientUserId;
  }

  public virtual ConditionState CreateBranch(ISystemContext context, NodeId branchId)
  {
    ConditionState branch = (ConditionState) null;
    object instance = Activator.CreateInstance(this.GetType(), (object) this);
    if (instance != null)
    {
      ConditionState conditionState = (ConditionState) instance;
      conditionState.Initialize(context, (NodeState) this);
      conditionState.BranchId.Value = branchId;
      conditionState.AutoReportStateChanges = this.AutoReportStateChanges;
      conditionState.ReportStateChange(context, false);
      string hexString = Utils.ToHexString(conditionState.EventId.Value);
      this.GetBranches().Add(hexString, conditionState);
      branch = conditionState;
    }
    return branch;
  }

  public Dictionary<string, ConditionState> GetBranches()
  {
    if (this.m_branches == null)
      this.m_branches = new Dictionary<string, ConditionState>();
    return this.m_branches;
  }

  public virtual ConditionState GetEventByEventId(byte[] eventId)
  {
    return !((IEnumerable<byte>) this.EventId.Value).SequenceEqual<byte>((IEnumerable<byte>) eventId) ? this.GetBranch(eventId) : this;
  }

  public ConditionState GetBranch(byte[] eventId)
  {
    ConditionState branch = (ConditionState) null;
    foreach (ConditionState conditionState in this.GetBranches().Values)
    {
      if (((IEnumerable<byte>) conditionState.EventId.Value).SequenceEqual<byte>((IEnumerable<byte>) eventId))
      {
        branch = conditionState;
        break;
      }
    }
    return branch;
  }

  protected void ReplaceBranchEvent(byte[] originalEventId, ConditionState alarm)
  {
    string hexString1 = Utils.ToHexString(originalEventId);
    string hexString2 = Utils.ToHexString(alarm.EventId.Value);
    Dictionary<string, ConditionState> branches = this.GetBranches();
    branches.Remove(hexString1);
    branches.Add(hexString2, alarm);
  }

  protected void RemoveBranchEvent(byte[] eventId)
  {
    string hexString = Utils.ToHexString(eventId);
    this.GetBranches().Remove(hexString);
  }

  public void ClearBranches() => this.GetBranches().Clear();

  protected virtual void UpdateRetainState()
  {
    bool retainState = this.GetRetainState();
    if (this.Retain.Value == retainState)
      return;
    this.Retain.Value = retainState;
  }

  protected virtual bool GetRetainState()
  {
    bool retainState = false;
    if (this.EnabledState.Id.Value)
    {
      foreach (ConditionState conditionState in this.GetBranches().Values)
      {
        conditionState.UpdateRetainState();
        if (conditionState.Retain.Value)
          retainState = true;
      }
    }
    return retainState;
  }

  public virtual int GetBranchCount() => this.GetBranches().Count;

  public bool EventsMonitored()
  {
    bool areEventsMonitored = this.AreEventsMonitored;
    if (this.IsBranch())
      areEventsMonitored = this.Parent.AreEventsMonitored;
    return areEventsMonitored;
  }

  public override void ConditionRefresh(
    ISystemContext context,
    List<IFilterTarget> events,
    bool includeChildren)
  {
    if (!this.Retain.Value)
      return;
    foreach (NodeState nodeState in this.GetBranches().Values)
      nodeState.ConditionRefresh(context, events, includeChildren);
    events.Add((IFilterTarget) this);
  }

  protected void ReportStateChange(ISystemContext context, bool ignoreDisabledState)
  {
    if (!ignoreDisabledState && !this.EnabledState.Id.Value || !this.AutoReportStateChanges)
      return;
    this.EventId.Value = Guid.NewGuid().ToByteArray();
    this.Time.Value = DateTime.UtcNow;
    this.ReceiveTime.Value = this.Time.Value;
    this.ClearChangeMasks(context, true);
    if (!this.EventsMonitored())
      return;
    InstanceStateSnapshot e = new InstanceStateSnapshot();
    e.Initialize(context, (BaseInstanceState) this);
    this.ReportEvent(context, (IFilterTarget) e);
  }

  protected virtual void UpdateEffectiveState(ISystemContext context)
  {
    this.SetEffectiveSubState(context, this.EnabledState.Value, DateTime.MinValue);
  }

  protected virtual ServiceResult OnAddCommentCalled(
    ISystemContext context,
    MethodState method,
    NodeId objectId,
    byte[] eventId,
    LocalizedText comment)
  {
    ServiceResult status = this.ProcessBeforeAddComment(context, eventId, comment);
    if (ServiceResult.IsGood(status))
    {
      string currentUserId = this.GetCurrentUserId(context);
      this.GetBranch(eventId)?.OnAddCommentCalled(context, method, objectId, eventId, comment);
      this.SetComment(context, comment, currentUserId);
    }
    if (this.EventsMonitored())
    {
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
      AuditConditionCommentEventState e = new AuditConditionCommentEventState((NodeState) null);
      TranslationInfo translationInfo = new TranslationInfo("AuditConditionComment", "en-US", "The AddComment method was called.");
      e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
      e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/AddComment", false);
      e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "InputArguments", (object) new object[2]
      {
        (object) eventId,
        (object) comment
      }, false);
      e.SetChildValue(context, (QualifiedName) "ConditionEventId", (object) eventId, false);
      e.SetChildValue(context, (QualifiedName) "Comment", (object) comment, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    return status;
  }

  protected string GetCurrentUserId(ISystemContext context)
  {
    return context is IOperationContext operationContext && operationContext.UserIdentity != null ? operationContext.UserIdentity.DisplayName : (string) null;
  }

  protected virtual ServiceResult ProcessBeforeAddComment(
    ISystemContext context,
    byte[] eventId,
    LocalizedText comment)
  {
    if (eventId == null)
      return (ServiceResult) 2157576192U /*0x809A0000*/;
    if (!this.EnabledState.Id.Value)
      return (ServiceResult) 2157510656U /*0x80990000*/;
    if (this.OnAddComment == null)
      return ServiceResult.Good;
    try
    {
      return this.OnAddComment(context, this, eventId, comment);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error adding a comment to a Condition.", objArray);
    }
  }

  protected virtual ServiceResult OnEnableCalled(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    ServiceResult status = this.ProcessBeforeEnableDisable(context, true);
    if (ServiceResult.IsGood(status))
    {
      foreach (ConditionState conditionState in this.GetBranches().Values)
        conditionState.OnEnableCalled(context, method, inputArguments, outputArguments);
      this.UpdateStateAfterEnable(context);
    }
    if (this.AreEventsMonitored)
    {
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, false);
      AuditConditionEnableEventState e = new AuditConditionEnableEventState((NodeState) null);
      TranslationInfo translationInfo = new TranslationInfo("AuditConditionEnable", "en-US", "The Enable method was called.");
      e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
      e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/Enable", false);
      e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    return status;
  }

  protected virtual ServiceResult OnDisableCalled(
    ISystemContext context,
    MethodState method,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    ServiceResult status = this.ProcessBeforeEnableDisable(context, false);
    if (ServiceResult.IsGood(status))
    {
      foreach (ConditionState conditionState in this.GetBranches().Values)
        conditionState.OnDisableCalled(context, method, inputArguments, outputArguments);
      this.UpdateStateAfterDisable(context);
    }
    if (this.AreEventsMonitored)
    {
      if (ServiceResult.IsGood(status))
        this.ReportStateChange(context, true);
      AuditConditionEnableEventState e = new AuditConditionEnableEventState((NodeState) null);
      TranslationInfo translationInfo = new TranslationInfo("AuditConditionEnable", "en-US", "The Disable method was called.");
      e.Initialize(context, (NodeState) this, EventSeverity.Low, new LocalizedText(translationInfo), ServiceResult.IsGood(status), DateTime.UtcNow);
      e.SetChildValue(context, (QualifiedName) "SourceNode", (object) this.NodeId, false);
      e.SetChildValue(context, (QualifiedName) "SourceName", (object) "Method/Disable", false);
      e.SetChildValue(context, (QualifiedName) "MethodId", (object) method.NodeId, false);
      this.ReportEvent(context, (IFilterTarget) e);
    }
    return status;
  }

  protected virtual ServiceResult ProcessBeforeEnableDisable(ISystemContext context, bool enabling)
  {
    if (enabling && this.EnabledState.Id.Value)
      return (ServiceResult) 2160852992U /*0x80CC0000*/;
    if (!enabling && !this.EnabledState.Id.Value)
      return (ServiceResult) 2157445120U /*0x80980000*/;
    if (this.OnEnableDisable == null)
      return ServiceResult.Good;
    try
    {
      return this.OnEnableDisable(context, this, enabling);
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      return ServiceResult.Create(ex, 2147549184U /*0x80010000*/, "Unexpected error enabling or disabling a Condition.", objArray);
    }
  }

  protected virtual void UpdateStateAfterEnable(ISystemContext context)
  {
    TranslationInfo translationInfo = new TranslationInfo("ConditionStateEnabled", "en-US", "Enabled");
    this.Retain.Value = true;
    this.EnabledState.Value = new LocalizedText(translationInfo);
    this.EnabledState.Id.Value = true;
    if (this.EnabledState.TransitionTime != null)
      this.EnabledState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected virtual void UpdateStateAfterDisable(ISystemContext context)
  {
    TranslationInfo translationInfo = new TranslationInfo("ConditionStateDisabled", "en-US", "Disabled");
    this.Retain.Value = false;
    this.EnabledState.Value = new LocalizedText(translationInfo);
    this.EnabledState.Id.Value = false;
    if (this.EnabledState.TransitionTime != null)
      this.EnabledState.TransitionTime.Value = DateTime.UtcNow;
    this.UpdateEffectiveState(context);
  }

  protected bool IsBranch() => !this.BranchId.Value.IsNullNodeId;
}
