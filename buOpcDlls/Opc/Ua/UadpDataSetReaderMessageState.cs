// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetReaderMessageState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class UadpDataSetReaderMessageState(NodeState parent) : DataSetReaderMessageState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAfFIBAHxSfFIAAP////8JAAAAFWCJCgIAAAAAAAwAAABHcm91cFZlcnNpb24BAH1SAC4ARH1SAAABAAZS/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB/UgAuAER/UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEARUQALgBERUQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQCAUgAuAESAUgAAAA7/////AQH/////AAAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAgVIALgBEgVIAAAEAGj3/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGF0YVNldE1lc3NhZ2VDb250ZW50TWFzawEAglIALgBEglIAAAEAHj3/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCDUgAuAESDUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABQcm9jZXNzaW5nT2Zmc2V0AQCEUgAuAESEUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCFUgAuAESFUgAAAQAiAf////8BAf////8AAAAA";
  private PropertyState<uint> m_groupVersion;
  private PropertyState<ushort> m_networkMessageNumber;
  private PropertyState<ushort> m_dataSetOffset;
  private PropertyState<Guid> m_dataSetClassId;
  private PropertyState<uint> m_networkMessageContentMask;
  private PropertyState<uint> m_dataSetMessageContentMask;
  private PropertyState<double> m_publishingInterval;
  private PropertyState<double> m_processingOffset;
  private PropertyState<double> m_receiveOffset;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21116U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJAAAAFVhZHBEYXRhU2V0UmVhZGVyTWVzc2FnZVR5cGVJbnN0YW5jZQEAfFIBAHxSfFIAAP////8JAAAAFWCJCgIAAAAAAAwAAABHcm91cFZlcnNpb24BAH1SAC4ARH1SAAABAAZS/////wEB/////wAAAAAVYIkKAgAAAAAAFAAAAE5ldHdvcmtNZXNzYWdlTnVtYmVyAQB/UgAuAER/UgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAANAAAARGF0YVNldE9mZnNldAEARUQALgBERUQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAERhdGFTZXRDbGFzc0lkAQCAUgAuAESAUgAAAA7/////AQH/////AAAAABVgiQoCAAAAAAAZAAAATmV0d29ya01lc3NhZ2VDb250ZW50TWFzawEAgVIALgBEgVIAAAEAGj3/////AQH/////AAAAABVgiQoCAAAAAAAZAAAARGF0YVNldE1lc3NhZ2VDb250ZW50TWFzawEAglIALgBEglIAAAEAHj3/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQCDUgAuAESDUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABQcm9jZXNzaW5nT2Zmc2V0AQCEUgAuAESEUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZWNlaXZlT2Zmc2V0AQCFUgAuAESFUgAAAQAiAf////8BAf////8AAAAA");
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

  public PropertyState<uint> GroupVersion
  {
    get => this.m_groupVersion;
    set
    {
      if (this.m_groupVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_groupVersion = value;
    }
  }

  public PropertyState<ushort> NetworkMessageNumber
  {
    get => this.m_networkMessageNumber;
    set
    {
      if (this.m_networkMessageNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkMessageNumber = value;
    }
  }

  public PropertyState<ushort> DataSetOffset
  {
    get => this.m_dataSetOffset;
    set
    {
      if (this.m_dataSetOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetOffset = value;
    }
  }

  public PropertyState<Guid> DataSetClassId
  {
    get => this.m_dataSetClassId;
    set
    {
      if (this.m_dataSetClassId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetClassId = value;
    }
  }

  public PropertyState<uint> NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set
    {
      if (this.m_networkMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_networkMessageContentMask = value;
    }
  }

  public PropertyState<uint> DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set
    {
      if (this.m_dataSetMessageContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetMessageContentMask = value;
    }
  }

  public PropertyState<double> PublishingInterval
  {
    get => this.m_publishingInterval;
    set
    {
      if (this.m_publishingInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingInterval = value;
    }
  }

  public PropertyState<double> ProcessingOffset
  {
    get => this.m_processingOffset;
    set
    {
      if (this.m_processingOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_processingOffset = value;
    }
  }

  public PropertyState<double> ReceiveOffset
  {
    get => this.m_receiveOffset;
    set
    {
      if (this.m_receiveOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_receiveOffset = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_groupVersion != null)
      children.Add((BaseInstanceState) this.m_groupVersion);
    if (this.m_networkMessageNumber != null)
      children.Add((BaseInstanceState) this.m_networkMessageNumber);
    if (this.m_dataSetOffset != null)
      children.Add((BaseInstanceState) this.m_dataSetOffset);
    if (this.m_dataSetClassId != null)
      children.Add((BaseInstanceState) this.m_dataSetClassId);
    if (this.m_networkMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_networkMessageContentMask);
    if (this.m_dataSetMessageContentMask != null)
      children.Add((BaseInstanceState) this.m_dataSetMessageContentMask);
    if (this.m_publishingInterval != null)
      children.Add((BaseInstanceState) this.m_publishingInterval);
    if (this.m_processingOffset != null)
      children.Add((BaseInstanceState) this.m_processingOffset);
    if (this.m_receiveOffset != null)
      children.Add((BaseInstanceState) this.m_receiveOffset);
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
        case 12:
          if (name == "GroupVersion")
          {
            if (createOrReplace && this.GroupVersion == null)
              this.GroupVersion = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.GroupVersion;
            break;
          }
          break;
        case 13:
          switch (name[0])
          {
            case 'D':
              if (name == "DataSetOffset")
              {
                if (createOrReplace && this.DataSetOffset == null)
                  this.DataSetOffset = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetOffset;
                break;
              }
              break;
            case 'R':
              if (name == "ReceiveOffset")
              {
                if (createOrReplace && this.ReceiveOffset == null)
                  this.ReceiveOffset = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ReceiveOffset;
                break;
              }
              break;
          }
          break;
        case 14:
          if (name == "DataSetClassId")
          {
            if (createOrReplace && this.DataSetClassId == null)
              this.DataSetClassId = replacement != null ? (PropertyState<Guid>) replacement : new PropertyState<Guid>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.DataSetClassId;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "ProcessingOffset")
          {
            if (createOrReplace && this.ProcessingOffset == null)
              this.ProcessingOffset = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ProcessingOffset;
            break;
          }
          break;
        case 18:
          if (name == "PublishingInterval")
          {
            if (createOrReplace && this.PublishingInterval == null)
              this.PublishingInterval = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.PublishingInterval;
            break;
          }
          break;
        case 20:
          if (name == "NetworkMessageNumber")
          {
            if (createOrReplace && this.NetworkMessageNumber == null)
              this.NetworkMessageNumber = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.NetworkMessageNumber;
            break;
          }
          break;
        case 25:
          switch (name[0])
          {
            case 'D':
              if (name == "DataSetMessageContentMask")
              {
                if (createOrReplace && this.DataSetMessageContentMask == null)
                  this.DataSetMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetMessageContentMask;
                break;
              }
              break;
            case 'N':
              if (name == "NetworkMessageContentMask")
              {
                if (createOrReplace && this.NetworkMessageContentMask == null)
                  this.NetworkMessageContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.NetworkMessageContentMask;
                break;
              }
              break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
