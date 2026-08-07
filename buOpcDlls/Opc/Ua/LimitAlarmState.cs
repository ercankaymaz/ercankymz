// Decompiled with JetBrains decompiler
// Type: Opc.Ua.LimitAlarmState
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
public class LimitAlarmState(NodeState parent) : AlarmConditionState(parent)
{
  private const string HighHighLimit_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoTGltaXQBAHQrAC4ARHQrAAAAC/////8BAf////8AAAAA";
  private const string HighLimit_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEhpZ2hMaW1pdAEAdSsALgBEdSsAAAAL/////wEB/////wAAAAA=";
  private const string LowLimit_InitializationString = "//////////8VYIkKAgAAAAAACAAAAExvd0xpbWl0AQB2KwAuAER2KwAAAAv/////AQH/////AAAAAA==";
  private const string LowLowLimit_InitializationString = "//////////8VYIkKAgAAAAAACwAAAExvd0xvd0xpbWl0AQB3KwAuAER3KwAAAAv/////AQH/////AAAAAA==";
  private const string BaseHighHighLimit_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAAA==";
  private const string BaseHighLimit_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEJhc2VIaWdoTGltaXQBAL1AAC4ARL1AAAAAC/////8BAf////8AAAAA";
  private const string BaseLowLimit_InitializationString = "//////////8VYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAA=";
  private const string BaseLowLowLimit_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAExpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAIsLAQCLC4sLAAD/////IgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5BcALgBE5BcAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5RcALgBE5RcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYXAC4AROYXAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnFwAuAETnFwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6BcALgBE6BcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkXAC4AROkXAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsXAC4AROsXAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7BcALgBE7BcAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHErAC4ARHErAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHIrAC4ARHIrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQABJAAuAEQBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAAIkAC4ARAIkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAO0XAC4ARO0XAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAAMkAC8BACMjAyQAAAAV/////wEBBQAAAAEALCMAAQAXJAEALCMAAQAgJAEALCMAAQAtJAEALCMAAQA2JAEALCMAAQA/JAEAAAAVYIkKAgAAAAAAAgAAAElkAQAEJAAuAEQEJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEADCQALwEAKiMMJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQANJAAuAEQNJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAA4kAC8BACojDiQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEADyQALgBEDyQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAECQALwEAKiMQJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQARJAAuAEQRJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBABIkAC4ARBIkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQAUJAAvAQBEIxQkAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBABMkAC8BAEMjEyQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBABUkAC8BAEUjFSQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAWJAAuAEQWJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBABckAC8BACMjFyQAAAAV/////wEBAQAAAAEALCMBAQADJAEAAAAVYIkKAgAAAAAAAgAAAElkAQAYJAAuAEQYJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBACkkAC8BAJcjKSQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAqJAAuAEQqJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQAtJAAvAQAjIy0kAAAAFf////8BAQEAAAABACwjAQEAAyQBAAAAFWCJCgIAAAAAAAIAAABJZAEALiQALgBELiQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAcysALgBEcysAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAGQkAC4ARGQkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaExpbWl0AQB0KwAuAER0KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASGlnaExpbWl0AQB1KwAuAER1KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATG93TGltaXQBAHYrAC4ARHYrAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dMaW1pdAEAdysALgBEdysAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQmFzZUhpZ2hMaW1pdAEAvUAALgBEvUAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=";
  private PropertyState<double> m_highHighLimit;
  private PropertyState<double> m_highLimit;
  private PropertyState<double> m_lowLimit;
  private PropertyState<double> m_lowLowLimit;
  private PropertyState<double> m_baseHighHighLimit;
  private PropertyState<double> m_baseHighLimit;
  private PropertyState<double> m_baseLowLimit;
  private PropertyState<double> m_baseLowLowLimit;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2955U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFgAAAExpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAIsLAQCLC4sLAAD/////IgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5BcALgBE5BcAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5RcALgBE5RcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYXAC4AROYXAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnFwAuAETnFwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6BcALgBE6BcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkXAC4AROkXAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsXAC4AROsXAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7BcALgBE7BcAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHErAC4ARHErAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHIrAC4ARHIrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQABJAAuAEQBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAAIkAC4ARAIkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAO0XAC4ARO0XAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAAMkAC8BACMjAyQAAAAV/////wEBBQAAAAEALCMAAQAXJAEALCMAAQAgJAEALCMAAQAtJAEALCMAAQA2JAEALCMAAQA/JAEAAAAVYIkKAgAAAAAAAgAAAElkAQAEJAAuAEQEJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEADCQALwEAKiMMJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQANJAAuAEQNJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAA4kAC8BACojDiQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEADyQALgBEDyQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAECQALwEAKiMQJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQARJAAuAEQRJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBABIkAC4ARBIkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQAUJAAvAQBEIxQkAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBABMkAC8BAEMjEyQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBABUkAC8BAEUjFSQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAWJAAuAEQWJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBABckAC8BACMjFyQAAAAV/////wEBAQAAAAEALCMBAQADJAEAAAAVYIkKAgAAAAAAAgAAAElkAQAYJAAuAEQYJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBACkkAC8BAJcjKSQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAqJAAuAEQqJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQAtJAAvAQAjIy0kAAAAFf////8BAQEAAAABACwjAQEAAyQBAAAAFWCJCgIAAAAAAAIAAABJZAEALiQALgBELiQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAcysALgBEcysAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAGQkAC4ARGQkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaExpbWl0AQB0KwAuAER0KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASGlnaExpbWl0AQB1KwAuAER1KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATG93TGltaXQBAHYrAC4ARHYrAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dMaW1pdAEAdysALgBEdysAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQmFzZUhpZ2hMaW1pdAEAvUAALgBEvUAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=");
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
    if (this.HighHighLimit != null)
      this.HighHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoTGltaXQBAHQrAC4ARHQrAAAAC/////8BAf////8AAAAA");
    if (this.HighLimit != null)
      this.HighLimit.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEhpZ2hMaW1pdAEAdSsALgBEdSsAAAAL/////wEB/////wAAAAA=");
    if (this.LowLimit != null)
      this.LowLimit.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAExvd0xpbWl0AQB2KwAuAER2KwAAAAv/////AQH/////AAAAAA==");
    if (this.LowLowLimit != null)
      this.LowLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAExvd0xvd0xpbWl0AQB3KwAuAER3KwAAAAv/////AQH/////AAAAAA==");
    if (this.BaseHighHighLimit != null)
      this.BaseHighHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAAA==");
    if (this.BaseHighLimit != null)
      this.BaseHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEJhc2VIaWdoTGltaXQBAL1AAC4ARL1AAAAAC/////8BAf////8AAAAA");
    if (this.BaseLowLimit != null)
      this.BaseLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAA=");
    if (this.BaseLowLowLimit == null)
      return;
    this.BaseLowLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=");
  }

  public PropertyState<double> HighHighLimit
  {
    get => this.m_highHighLimit;
    set
    {
      if (this.m_highHighLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_highHighLimit = value;
    }
  }

  public PropertyState<double> HighLimit
  {
    get => this.m_highLimit;
    set
    {
      if (this.m_highLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_highLimit = value;
    }
  }

  public PropertyState<double> LowLimit
  {
    get => this.m_lowLimit;
    set
    {
      if (this.m_lowLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lowLimit = value;
    }
  }

  public PropertyState<double> LowLowLimit
  {
    get => this.m_lowLowLimit;
    set
    {
      if (this.m_lowLowLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_lowLowLimit = value;
    }
  }

  public PropertyState<double> BaseHighHighLimit
  {
    get => this.m_baseHighHighLimit;
    set
    {
      if (this.m_baseHighHighLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseHighHighLimit = value;
    }
  }

  public PropertyState<double> BaseHighLimit
  {
    get => this.m_baseHighLimit;
    set
    {
      if (this.m_baseHighLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseHighLimit = value;
    }
  }

  public PropertyState<double> BaseLowLimit
  {
    get => this.m_baseLowLimit;
    set
    {
      if (this.m_baseLowLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseLowLimit = value;
    }
  }

  public PropertyState<double> BaseLowLowLimit
  {
    get => this.m_baseLowLowLimit;
    set
    {
      if (this.m_baseLowLowLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseLowLowLimit = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_highHighLimit != null)
      children.Add((BaseInstanceState) this.m_highHighLimit);
    if (this.m_highLimit != null)
      children.Add((BaseInstanceState) this.m_highLimit);
    if (this.m_lowLimit != null)
      children.Add((BaseInstanceState) this.m_lowLimit);
    if (this.m_lowLowLimit != null)
      children.Add((BaseInstanceState) this.m_lowLowLimit);
    if (this.m_baseHighHighLimit != null)
      children.Add((BaseInstanceState) this.m_baseHighHighLimit);
    if (this.m_baseHighLimit != null)
      children.Add((BaseInstanceState) this.m_baseHighLimit);
    if (this.m_baseLowLimit != null)
      children.Add((BaseInstanceState) this.m_baseLowLimit);
    if (this.m_baseLowLowLimit != null)
      children.Add((BaseInstanceState) this.m_baseLowLowLimit);
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
        case 8:
          if (name == "LowLimit")
          {
            if (createOrReplace && this.LowLimit == null)
              this.LowLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LowLimit;
            break;
          }
          break;
        case 9:
          if (name == "HighLimit")
          {
            if (createOrReplace && this.HighLimit == null)
              this.HighLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.HighLimit;
            break;
          }
          break;
        case 11:
          if (name == "LowLowLimit")
          {
            if (createOrReplace && this.LowLowLimit == null)
              this.LowLowLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LowLowLimit;
            break;
          }
          break;
        case 12:
          if (name == "BaseLowLimit")
          {
            if (createOrReplace && this.BaseLowLimit == null)
              this.BaseLowLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.BaseLowLimit;
            break;
          }
          break;
        case 13:
          switch (name[0])
          {
            case 'B':
              if (name == "BaseHighLimit")
              {
                if (createOrReplace && this.BaseHighLimit == null)
                  this.BaseHighLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.BaseHighLimit;
                break;
              }
              break;
            case 'H':
              if (name == "HighHighLimit")
              {
                if (createOrReplace && this.HighHighLimit == null)
                  this.HighHighLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.HighHighLimit;
                break;
              }
              break;
          }
          break;
        case 15:
          if (name == "BaseLowLowLimit")
          {
            if (createOrReplace && this.BaseLowLowLimit == null)
              this.BaseLowLowLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.BaseLowLowLimit;
            break;
          }
          break;
        case 17:
          if (name == "BaseHighHighLimit")
          {
            if (createOrReplace && this.BaseHighHighLimit == null)
              this.BaseHighHighLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.BaseHighHighLimit;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
