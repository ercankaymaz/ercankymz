// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryServerCapabilitiesState
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
public class HistoryServerCapabilitiesState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEhpc3RvcnlTZXJ2ZXJDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBABoJAQAaCRoJAAD/////EAAAABVgiQoCAAAAAAAbAAAAQWNjZXNzSGlzdG9yeURhdGFDYXBhYmlsaXR5AQAbCQAuAEQbCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAdAAAAQWNjZXNzSGlzdG9yeUV2ZW50c0NhcGFiaWxpdHkBABwJAC4ARBwJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhSZXR1cm5EYXRhVmFsdWVzAQAELAAuAEQELAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAUAAAATWF4UmV0dXJuRXZlbnRWYWx1ZXMBAAUsAC4ARAUsAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABJbnNlcnREYXRhQ2FwYWJpbGl0eQEAHgkALgBEHgkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcGxhY2VEYXRhQ2FwYWJpbGl0eQEAHwkALgBEHwkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFVwZGF0ZURhdGFDYXBhYmlsaXR5AQAgCQAuAEQgCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAATAAAARGVsZXRlUmF3Q2FwYWJpbGl0eQEAIQkALgBEIQkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAERlbGV0ZUF0VGltZUNhcGFiaWxpdHkBACIJAC4ARCIJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABJbnNlcnRFdmVudENhcGFiaWxpdHkBAA4sAC4ARA4sAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABSZXBsYWNlRXZlbnRDYXBhYmlsaXR5AQAPLAAuAEQPLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAVXBkYXRlRXZlbnRDYXBhYmlsaXR5AQAQLAAuAEQQLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGVsZXRlRXZlbnRDYXBhYmlsaXR5AQDtLAAuAETtLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAASW5zZXJ0QW5ub3RhdGlvbkNhcGFiaWxpdHkBAAYsAC4ARAYsAAAAAf////8BAf////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBAKQrAC8APaQrAAD/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCWSgAuAESWSgAAAAH/////AQH/////AAAAAA==";
  private PropertyState<bool> m_accessHistoryDataCapability;
  private PropertyState<bool> m_accessHistoryEventsCapability;
  private PropertyState<uint> m_maxReturnDataValues;
  private PropertyState<uint> m_maxReturnEventValues;
  private PropertyState<bool> m_insertDataCapability;
  private PropertyState<bool> m_replaceDataCapability;
  private PropertyState<bool> m_updateDataCapability;
  private PropertyState<bool> m_deleteRawCapability;
  private PropertyState<bool> m_deleteAtTimeCapability;
  private PropertyState<bool> m_insertEventCapability;
  private PropertyState<bool> m_replaceEventCapability;
  private PropertyState<bool> m_updateEventCapability;
  private PropertyState<bool> m_deleteEventCapability;
  private PropertyState<bool> m_insertAnnotationCapability;
  private FolderState m_aggregateFunctions;
  private PropertyState<bool> m_serverTimestampSupported;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2330U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEhpc3RvcnlTZXJ2ZXJDYXBhYmlsaXRpZXNUeXBlSW5zdGFuY2UBABoJAQAaCRoJAAD/////EAAAABVgiQoCAAAAAAAbAAAAQWNjZXNzSGlzdG9yeURhdGFDYXBhYmlsaXR5AQAbCQAuAEQbCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAdAAAAQWNjZXNzSGlzdG9yeUV2ZW50c0NhcGFiaWxpdHkBABwJAC4ARBwJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABNYXhSZXR1cm5EYXRhVmFsdWVzAQAELAAuAEQELAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAUAAAATWF4UmV0dXJuRXZlbnRWYWx1ZXMBAAUsAC4ARAUsAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABJbnNlcnREYXRhQ2FwYWJpbGl0eQEAHgkALgBEHgkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlcGxhY2VEYXRhQ2FwYWJpbGl0eQEAHwkALgBEHwkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAFVwZGF0ZURhdGFDYXBhYmlsaXR5AQAgCQAuAEQgCQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAATAAAARGVsZXRlUmF3Q2FwYWJpbGl0eQEAIQkALgBEIQkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAAFgAAAERlbGV0ZUF0VGltZUNhcGFiaWxpdHkBACIJAC4ARCIJAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABJbnNlcnRFdmVudENhcGFiaWxpdHkBAA4sAC4ARA4sAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAABYAAABSZXBsYWNlRXZlbnRDYXBhYmlsaXR5AQAPLAAuAEQPLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAVXBkYXRlRXZlbnRDYXBhYmlsaXR5AQAQLAAuAEQQLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARGVsZXRlRXZlbnRDYXBhYmlsaXR5AQDtLAAuAETtLAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAaAAAASW5zZXJ0QW5ub3RhdGlvbkNhcGFiaWxpdHkBAAYsAC4ARAYsAAAAAf////8BAf////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBAKQrAC8APaQrAAD/////AAAAABVgiQoCAAAAAAAYAAAAU2VydmVyVGltZXN0YW1wU3VwcG9ydGVkAQCWSgAuAESWSgAAAAH/////AQH/////AAAAAA==");
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

  public PropertyState<bool> AccessHistoryDataCapability
  {
    get => this.m_accessHistoryDataCapability;
    set
    {
      if (this.m_accessHistoryDataCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_accessHistoryDataCapability = value;
    }
  }

  public PropertyState<bool> AccessHistoryEventsCapability
  {
    get => this.m_accessHistoryEventsCapability;
    set
    {
      if (this.m_accessHistoryEventsCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_accessHistoryEventsCapability = value;
    }
  }

  public PropertyState<uint> MaxReturnDataValues
  {
    get => this.m_maxReturnDataValues;
    set
    {
      if (this.m_maxReturnDataValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxReturnDataValues = value;
    }
  }

  public PropertyState<uint> MaxReturnEventValues
  {
    get => this.m_maxReturnEventValues;
    set
    {
      if (this.m_maxReturnEventValues != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxReturnEventValues = value;
    }
  }

  public PropertyState<bool> InsertDataCapability
  {
    get => this.m_insertDataCapability;
    set
    {
      if (this.m_insertDataCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_insertDataCapability = value;
    }
  }

  public PropertyState<bool> ReplaceDataCapability
  {
    get => this.m_replaceDataCapability;
    set
    {
      if (this.m_replaceDataCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_replaceDataCapability = value;
    }
  }

  public PropertyState<bool> UpdateDataCapability
  {
    get => this.m_updateDataCapability;
    set
    {
      if (this.m_updateDataCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updateDataCapability = value;
    }
  }

  public PropertyState<bool> DeleteRawCapability
  {
    get => this.m_deleteRawCapability;
    set
    {
      if (this.m_deleteRawCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteRawCapability = value;
    }
  }

  public PropertyState<bool> DeleteAtTimeCapability
  {
    get => this.m_deleteAtTimeCapability;
    set
    {
      if (this.m_deleteAtTimeCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteAtTimeCapability = value;
    }
  }

  public PropertyState<bool> InsertEventCapability
  {
    get => this.m_insertEventCapability;
    set
    {
      if (this.m_insertEventCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_insertEventCapability = value;
    }
  }

  public PropertyState<bool> ReplaceEventCapability
  {
    get => this.m_replaceEventCapability;
    set
    {
      if (this.m_replaceEventCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_replaceEventCapability = value;
    }
  }

  public PropertyState<bool> UpdateEventCapability
  {
    get => this.m_updateEventCapability;
    set
    {
      if (this.m_updateEventCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updateEventCapability = value;
    }
  }

  public PropertyState<bool> DeleteEventCapability
  {
    get => this.m_deleteEventCapability;
    set
    {
      if (this.m_deleteEventCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteEventCapability = value;
    }
  }

  public PropertyState<bool> InsertAnnotationCapability
  {
    get => this.m_insertAnnotationCapability;
    set
    {
      if (this.m_insertAnnotationCapability != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_insertAnnotationCapability = value;
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

  public PropertyState<bool> ServerTimestampSupported
  {
    get => this.m_serverTimestampSupported;
    set
    {
      if (this.m_serverTimestampSupported != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverTimestampSupported = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_accessHistoryDataCapability != null)
      children.Add((BaseInstanceState) this.m_accessHistoryDataCapability);
    if (this.m_accessHistoryEventsCapability != null)
      children.Add((BaseInstanceState) this.m_accessHistoryEventsCapability);
    if (this.m_maxReturnDataValues != null)
      children.Add((BaseInstanceState) this.m_maxReturnDataValues);
    if (this.m_maxReturnEventValues != null)
      children.Add((BaseInstanceState) this.m_maxReturnEventValues);
    if (this.m_insertDataCapability != null)
      children.Add((BaseInstanceState) this.m_insertDataCapability);
    if (this.m_replaceDataCapability != null)
      children.Add((BaseInstanceState) this.m_replaceDataCapability);
    if (this.m_updateDataCapability != null)
      children.Add((BaseInstanceState) this.m_updateDataCapability);
    if (this.m_deleteRawCapability != null)
      children.Add((BaseInstanceState) this.m_deleteRawCapability);
    if (this.m_deleteAtTimeCapability != null)
      children.Add((BaseInstanceState) this.m_deleteAtTimeCapability);
    if (this.m_insertEventCapability != null)
      children.Add((BaseInstanceState) this.m_insertEventCapability);
    if (this.m_replaceEventCapability != null)
      children.Add((BaseInstanceState) this.m_replaceEventCapability);
    if (this.m_updateEventCapability != null)
      children.Add((BaseInstanceState) this.m_updateEventCapability);
    if (this.m_deleteEventCapability != null)
      children.Add((BaseInstanceState) this.m_deleteEventCapability);
    if (this.m_insertAnnotationCapability != null)
      children.Add((BaseInstanceState) this.m_insertAnnotationCapability);
    if (this.m_aggregateFunctions != null)
      children.Add((BaseInstanceState) this.m_aggregateFunctions);
    if (this.m_serverTimestampSupported != null)
      children.Add((BaseInstanceState) this.m_serverTimestampSupported);
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
        case 18:
          if (name == "AggregateFunctions")
          {
            if (createOrReplace && this.AggregateFunctions == null)
              this.AggregateFunctions = replacement != null ? (FolderState) replacement : new FolderState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AggregateFunctions;
            break;
          }
          break;
        case 19:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteRawCapability")
              {
                if (createOrReplace && this.DeleteRawCapability == null)
                  this.DeleteRawCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteRawCapability;
                break;
              }
              break;
            case 'M':
              if (name == "MaxReturnDataValues")
              {
                if (createOrReplace && this.MaxReturnDataValues == null)
                  this.MaxReturnDataValues = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxReturnDataValues;
                break;
              }
              break;
          }
          break;
        case 20:
          switch (name[0])
          {
            case 'I':
              if (name == "InsertDataCapability")
              {
                if (createOrReplace && this.InsertDataCapability == null)
                  this.InsertDataCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.InsertDataCapability;
                break;
              }
              break;
            case 'M':
              if (name == "MaxReturnEventValues")
              {
                if (createOrReplace && this.MaxReturnEventValues == null)
                  this.MaxReturnEventValues = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MaxReturnEventValues;
                break;
              }
              break;
            case 'U':
              if (name == "UpdateDataCapability")
              {
                if (createOrReplace && this.UpdateDataCapability == null)
                  this.UpdateDataCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UpdateDataCapability;
                break;
              }
              break;
          }
          break;
        case 21:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteEventCapability")
              {
                if (createOrReplace && this.DeleteEventCapability == null)
                  this.DeleteEventCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteEventCapability;
                break;
              }
              break;
            case 'I':
              if (name == "InsertEventCapability")
              {
                if (createOrReplace && this.InsertEventCapability == null)
                  this.InsertEventCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.InsertEventCapability;
                break;
              }
              break;
            case 'R':
              if (name == "ReplaceDataCapability")
              {
                if (createOrReplace && this.ReplaceDataCapability == null)
                  this.ReplaceDataCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ReplaceDataCapability;
                break;
              }
              break;
            case 'U':
              if (name == "UpdateEventCapability")
              {
                if (createOrReplace && this.UpdateEventCapability == null)
                  this.UpdateEventCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UpdateEventCapability;
                break;
              }
              break;
          }
          break;
        case 22:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteAtTimeCapability")
              {
                if (createOrReplace && this.DeleteAtTimeCapability == null)
                  this.DeleteAtTimeCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteAtTimeCapability;
                break;
              }
              break;
            case 'R':
              if (name == "ReplaceEventCapability")
              {
                if (createOrReplace && this.ReplaceEventCapability == null)
                  this.ReplaceEventCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ReplaceEventCapability;
                break;
              }
              break;
          }
          break;
        case 24:
          if (name == "ServerTimestampSupported")
          {
            if (createOrReplace && this.ServerTimestampSupported == null)
              this.ServerTimestampSupported = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ServerTimestampSupported;
            break;
          }
          break;
        case 26:
          if (name == "InsertAnnotationCapability")
          {
            if (createOrReplace && this.InsertAnnotationCapability == null)
              this.InsertAnnotationCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.InsertAnnotationCapability;
            break;
          }
          break;
        case 27:
          if (name == "AccessHistoryDataCapability")
          {
            if (createOrReplace && this.AccessHistoryDataCapability == null)
              this.AccessHistoryDataCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AccessHistoryDataCapability;
            break;
          }
          break;
        case 29:
          if (name == "AccessHistoryEventsCapability")
          {
            if (createOrReplace && this.AccessHistoryEventsCapability == null)
              this.AccessHistoryEventsCapability = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AccessHistoryEventsCapability;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
