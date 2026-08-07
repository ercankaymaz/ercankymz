// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerCapabilitiesState
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
public class ServerCapabilitiesState(NodeState parent) : BaseObjectState(parent)
{
  private const string MaxArrayLength_InitializationString = "//////////8VYIkKAgAAAAAADgAAAE1heEFycmF5TGVuZ3RoAQAdLQAuAEQdLQAAAAf/////AQH/////AAAAAA==";
  private const string MaxStringLength_InitializationString = "//////////8VYIkKAgAAAAAADwAAAE1heFN0cmluZ0xlbmd0aAEAHi0ALgBEHi0AAAAH/////wEB/////wAAAAA=";
  private const string MaxByteStringLength_InitializationString = "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBAG4yAC4ARG4yAAAAB/////8BAf////8AAAAA";
  private const string OperationLimits_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE9wZXJhdGlvbkxpbWl0cwEAHy0ALwEALC0fLQAA/////wAAAAA=";
  private const string RoleSet_InitializationString = "//////////8EYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAFNlcnZlckNhcGFiaWxpdGllc1R5cGVJbnN0YW5jZQEA3QcBAN0H3QcAAP////8OAAAAF2CJCgIAAAAAABIAAABTZXJ2ZXJQcm9maWxlQXJyYXkBAN4HAC4ARN4HAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAExvY2FsZUlkQXJyYXkBAOAHAC4AROAHAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAWAAAATWluU3VwcG9ydGVkU2FtcGxlUmF0ZQEA4QcALgBE4QcAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAbAAAATWF4QnJvd3NlQ29udGludWF0aW9uUG9pbnRzAQCsCgAuAESsCgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAaAAAATWF4UXVlcnlDb250aW51YXRpb25Qb2ludHMBAK0KAC4ARK0KAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNYXhIaXN0b3J5Q29udGludWF0aW9uUG9pbnRzAQCuCgAuAESuCgAAAAX/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAU29mdHdhcmVDZXJ0aWZpY2F0ZXMBAOkLAC4AROkLAAABAFgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4QXJyYXlMZW5ndGgBAB0tAC4ARB0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhTdHJpbmdMZW5ndGgBAB4tAC4ARB4tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQBuMgAuAERuMgAAAAf/////AQH/////AAAAAARggAoBAAAAAAAPAAAAT3BlcmF0aW9uTGltaXRzAQAfLQAvAQAsLR8tAAD/////AAAAAARggAoBAAAAAAAOAAAATW9kZWxsaW5nUnVsZXMBAOMHAC8APeMHAAD/////AAAAAARggAoBAAAAAAASAAAAQWdncmVnYXRlRnVuY3Rpb25zAQDCCgAvAD3CCgAA/////wAAAAAEYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<string[]> m_serverProfileArray;
  private PropertyState<string[]> m_localeIdArray;
  private PropertyState<double> m_minSupportedSampleRate;
  private PropertyState<ushort> m_maxBrowseContinuationPoints;
  private PropertyState<ushort> m_maxQueryContinuationPoints;
  private PropertyState<ushort> m_maxHistoryContinuationPoints;
  private PropertyState<SignedSoftwareCertificate[]> m_softwareCertificates;
  private PropertyState<uint> m_maxArrayLength;
  private PropertyState<uint> m_maxStringLength;
  private PropertyState<uint> m_maxByteStringLength;
  private OperationLimitsState m_operationLimits;
  private FolderState m_modellingRules;
  private FolderState m_aggregateFunctions;
  private RoleSetState m_roleSet;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2013U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAFNlcnZlckNhcGFiaWxpdGllc1R5cGVJbnN0YW5jZQEA3QcBAN0H3QcAAP////8OAAAAF2CJCgIAAAAAABIAAABTZXJ2ZXJQcm9maWxlQXJyYXkBAN4HAC4ARN4HAAAADAEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAADQAAAExvY2FsZUlkQXJyYXkBAOAHAC4AROAHAAABACcBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAWAAAATWluU3VwcG9ydGVkU2FtcGxlUmF0ZQEA4QcALgBE4QcAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAbAAAATWF4QnJvd3NlQ29udGludWF0aW9uUG9pbnRzAQCsCgAuAESsCgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAaAAAATWF4UXVlcnlDb250aW51YXRpb25Qb2ludHMBAK0KAC4ARK0KAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABwAAABNYXhIaXN0b3J5Q29udGludWF0aW9uUG9pbnRzAQCuCgAuAESuCgAAAAX/////AQH/////AAAAABdgiQoCAAAAAAAUAAAAU29mdHdhcmVDZXJ0aWZpY2F0ZXMBAOkLAC4AROkLAAABAFgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATWF4QXJyYXlMZW5ndGgBAB0tAC4ARB0tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhTdHJpbmdMZW5ndGgBAB4tAC4ARB4tAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhCeXRlU3RyaW5nTGVuZ3RoAQBuMgAuAERuMgAAAAf/////AQH/////AAAAAARggAoBAAAAAAAPAAAAT3BlcmF0aW9uTGltaXRzAQAfLQAvAQAsLR8tAAD/////AAAAAARggAoBAAAAAAAOAAAATW9kZWxsaW5nUnVsZXMBAOMHAC8APeMHAAD/////AAAAAARggAoBAAAAAAASAAAAQWdncmVnYXRlRnVuY3Rpb25zAQDCCgAvAD3CCgAA/////wAAAAAEYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.MaxArrayLength != null)
      this.MaxArrayLength.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAE1heEFycmF5TGVuZ3RoAQAdLQAuAEQdLQAAAAf/////AQH/////AAAAAA==");
    if (this.MaxStringLength != null)
      this.MaxStringLength.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAE1heFN0cmluZ0xlbmd0aAEAHi0ALgBEHi0AAAAH/////wEB/////wAAAAA=");
    if (this.MaxByteStringLength != null)
      this.MaxByteStringLength.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAE1heEJ5dGVTdHJpbmdMZW5ndGgBAG4yAC4ARG4yAAAAB/////8BAf////8AAAAA");
    if (this.OperationLimits != null)
      this.OperationLimits.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE9wZXJhdGlvbkxpbWl0cwEAHy0ALwEALC0fLQAA/////wAAAAA=");
    if (this.RoleSet == null)
      return;
    this.RoleSet.Initialize(context, "//////////8EYIAKAQAAAAAABwAAAFJvbGVTZXQBAKc/AC8BAPc8pz8AAP////8CAAAABGGCCgQAAAAAAAcAAABBZGRSb2xlAQCoPwAvAQB9Pqg/AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAqT8ALgBEqT8AAJYCAAAAAQAqAQEXAAAACAAAAFJvbGVOYW1lAAz/////AAAAAAABACoBARsAAAAMAAAATmFtZXNwYWNlVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCqPwAuAESqPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlbW92ZVJvbGUBAKs/AC8BAIA+qz8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCsPwAuAESsPwAAlgEAAAABACoBARkAAAAKAAAAUm9sZU5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
  }

  public PropertyState<string[]> ServerProfileArray
  {
    get => this.m_serverProfileArray;
    set
    {
      if (this.m_serverProfileArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverProfileArray = value;
    }
  }

  public PropertyState<string[]> LocaleIdArray
  {
    get => this.m_localeIdArray;
    set
    {
      if (this.m_localeIdArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_localeIdArray = value;
    }
  }

  public PropertyState<double> MinSupportedSampleRate
  {
    get => this.m_minSupportedSampleRate;
    set
    {
      if (this.m_minSupportedSampleRate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_minSupportedSampleRate = value;
    }
  }

  public PropertyState<ushort> MaxBrowseContinuationPoints
  {
    get => this.m_maxBrowseContinuationPoints;
    set
    {
      if (this.m_maxBrowseContinuationPoints != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxBrowseContinuationPoints = value;
    }
  }

  public PropertyState<ushort> MaxQueryContinuationPoints
  {
    get => this.m_maxQueryContinuationPoints;
    set
    {
      if (this.m_maxQueryContinuationPoints != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxQueryContinuationPoints = value;
    }
  }

  public PropertyState<ushort> MaxHistoryContinuationPoints
  {
    get => this.m_maxHistoryContinuationPoints;
    set
    {
      if (this.m_maxHistoryContinuationPoints != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxHistoryContinuationPoints = value;
    }
  }

  public PropertyState<SignedSoftwareCertificate[]> SoftwareCertificates
  {
    get => this.m_softwareCertificates;
    set
    {
      if (this.m_softwareCertificates != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_softwareCertificates = value;
    }
  }

  public PropertyState<uint> MaxArrayLength
  {
    get => this.m_maxArrayLength;
    set
    {
      if (this.m_maxArrayLength != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxArrayLength = value;
    }
  }

  public PropertyState<uint> MaxStringLength
  {
    get => this.m_maxStringLength;
    set
    {
      if (this.m_maxStringLength != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxStringLength = value;
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

  public OperationLimitsState OperationLimits
  {
    get => this.m_operationLimits;
    set
    {
      if (this.m_operationLimits != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_operationLimits = value;
    }
  }

  public FolderState ModellingRules
  {
    get => this.m_modellingRules;
    set
    {
      if (this.m_modellingRules != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_modellingRules = value;
    }
  }

  public FolderState AggregateFunctions
  {
    get => this.m_aggregateFunctions;
    set
    {
      if (this.m_aggregateFunctions != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_aggregateFunctions = value;
    }
  }

  public RoleSetState RoleSet
  {
    get => this.m_roleSet;
    set
    {
      if (this.m_roleSet != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_roleSet = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverProfileArray != null)
      children.Add((BaseInstanceState) this.m_serverProfileArray);
    if (this.m_localeIdArray != null)
      children.Add((BaseInstanceState) this.m_localeIdArray);
    if (this.m_minSupportedSampleRate != null)
      children.Add((BaseInstanceState) this.m_minSupportedSampleRate);
    if (this.m_maxBrowseContinuationPoints != null)
      children.Add((BaseInstanceState) this.m_maxBrowseContinuationPoints);
    if (this.m_maxQueryContinuationPoints != null)
      children.Add((BaseInstanceState) this.m_maxQueryContinuationPoints);
    if (this.m_maxHistoryContinuationPoints != null)
      children.Add((BaseInstanceState) this.m_maxHistoryContinuationPoints);
    if (this.m_softwareCertificates != null)
      children.Add((BaseInstanceState) this.m_softwareCertificates);
    if (this.m_maxArrayLength != null)
      children.Add((BaseInstanceState) this.m_maxArrayLength);
    if (this.m_maxStringLength != null)
      children.Add((BaseInstanceState) this.m_maxStringLength);
    if (this.m_maxByteStringLength != null)
      children.Add((BaseInstanceState) this.m_maxByteStringLength);
    if (this.m_operationLimits != null)
      children.Add((BaseInstanceState) this.m_operationLimits);
    if (this.m_modellingRules != null)
      children.Add((BaseInstanceState) this.m_modellingRules);
    if (this.m_aggregateFunctions != null)
      children.Add((BaseInstanceState) this.m_aggregateFunctions);
    if (this.m_roleSet != null)
      children.Add((BaseInstanceState) this.m_roleSet);
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
        case 7:
          if (name == "RoleSet")
          {
            if (createOrReplace && this.RoleSet == null)
              this.RoleSet = replacement != null ? (RoleSetState) replacement : new RoleSetState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RoleSet;
            break;
          }
          break;
        case 13:
          if (name == "LocaleIdArray")
          {
            if (createOrReplace && this.LocaleIdArray == null)
              this.LocaleIdArray = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LocaleIdArray;
            break;
          }
          break;
        case 14:
          switch (name[1])
          {
            case 'a':
              if (name == "MaxArrayLength")
              {
                if (createOrReplace && this.MaxArrayLength == null)
                  this.MaxArrayLength = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxArrayLength;
                break;
              }
              break;
            case 'o':
              if (name == "ModellingRules")
              {
                if (createOrReplace && this.ModellingRules == null)
                  this.ModellingRules = replacement != null ? (FolderState) replacement : new FolderState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ModellingRules;
                break;
              }
              break;
          }
          break;
        case 15:
          switch (name[0])
          {
            case 'M':
              if (name == "MaxStringLength")
              {
                if (createOrReplace && this.MaxStringLength == null)
                  this.MaxStringLength = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxStringLength;
                break;
              }
              break;
            case 'O':
              if (name == "OperationLimits")
              {
                if (createOrReplace && this.OperationLimits == null)
                  this.OperationLimits = replacement != null ? (OperationLimitsState) replacement : new OperationLimitsState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.OperationLimits;
                break;
              }
              break;
          }
          break;
        case 18:
          switch (name[0])
          {
            case 'A':
              if (name == "AggregateFunctions")
              {
                if (createOrReplace && this.AggregateFunctions == null)
                  this.AggregateFunctions = replacement != null ? (FolderState) replacement : new FolderState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AggregateFunctions;
                break;
              }
              break;
            case 'S':
              if (name == "ServerProfileArray")
              {
                if (createOrReplace && this.ServerProfileArray == null)
                  this.ServerProfileArray = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerProfileArray;
                break;
              }
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
        case 20:
          if (name == "SoftwareCertificates")
          {
            if (createOrReplace && this.SoftwareCertificates == null)
              this.SoftwareCertificates = replacement != null ? (PropertyState<SignedSoftwareCertificate[]>) replacement : new PropertyState<SignedSoftwareCertificate[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SoftwareCertificates;
            break;
          }
          break;
        case 22:
          if (name == "MinSupportedSampleRate")
          {
            if (createOrReplace && this.MinSupportedSampleRate == null)
              this.MinSupportedSampleRate = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MinSupportedSampleRate;
            break;
          }
          break;
        case 26:
          if (name == "MaxQueryContinuationPoints")
          {
            if (createOrReplace && this.MaxQueryContinuationPoints == null)
              this.MaxQueryContinuationPoints = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxQueryContinuationPoints;
            break;
          }
          break;
        case 27:
          if (name == "MaxBrowseContinuationPoints")
          {
            if (createOrReplace && this.MaxBrowseContinuationPoints == null)
              this.MaxBrowseContinuationPoints = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxBrowseContinuationPoints;
            break;
          }
          break;
        case 28:
          if (name == "MaxHistoryContinuationPoints")
          {
            if (createOrReplace && this.MaxHistoryContinuationPoints == null)
              this.MaxHistoryContinuationPoints = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxHistoryContinuationPoints;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
