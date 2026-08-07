// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateExpirationAlarmState
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
public class CertificateExpirationAlarmState(NodeState parent) : SystemOffNormalAlarmState(parent)
{
  private const string ExpirationLimit_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEV4cGlyYXRpb25MaW1pdAEANDoALgBENDoAAAEAIgH/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAENlcnRpZmljYXRlRXhwaXJhdGlvbkFsYXJtVHlwZUluc3RhbmNlAQCpMwEAqTOpMwAA/////x8AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKozAC4ARKozAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKszAC4ARKszAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCsMwAuAESsMwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEArTMALgBErTMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAK4zAC4ARK4zAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCvMwAuAESvMwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCxMwAuAESxMwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALIzAC4ARLIzAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQCzMwAuAESzMwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQC0MwAuAES0MwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAtTMALgBEtTMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQC2MwAuAES2MwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQC3MwAuAES3MwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQC4MwAvAQAjI7gzAAAAFf////8BAQUAAAABACwjAAEA0DMBACwjAAEA2TMBACwjAAEA5jMBACwjAAEA8DMBACwjAAEA+TMBAAAAFWCJCgIAAAAAAAIAAABJZAEAuTMALgBEuTMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAMEzAC8BACojwTMAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAwjMALgBEwjMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQDDMwAvAQAqI8MzAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAMQzAC4ARMQzAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAMUzAC8BACojxTMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAxjMALgBExjMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDHMwAuAETHMwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAyDMALwEARCPIMwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQDJMwAvAQBDI8kzAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQDKMwAvAQBFI8ozAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAyzMALgBEyzMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQDQMwAvAQAjI9AzAAAAFf////8BAQEAAAABACwjAQEAuDMBAAAAFWCJCgIAAAAAAAIAAABJZAEA0TMALgBE0TMAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQDiMwAvAQCXI+IzAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4zMALgBE4zMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEA5jMALwEAIyPmMwAAABX/////AQEBAAAAAQAsIwEBALgzAQAAABVgiQoCAAAAAAACAAAASWQBAOczAC4AROczAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAO8zAC4ARO8zAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQAKNAAuAEQKNAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATm9ybWFsU3RhdGUBAAw0AC4ARAw0AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABFeHBpcmF0aW9uRGF0ZQEADTQALgBEDTQAAAAN/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEV4cGlyYXRpb25MaW1pdAEANDoALgBENDoAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQAONAAuAEQONAAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQ2VydGlmaWNhdGUBAA80AC4ARA80AAAAD/////8BAf////8AAAAA";
  private PropertyState<DateTime> m_expirationDate;
  private PropertyState<double> m_expirationLimit;
  private PropertyState<NodeId> m_certificateType;
  private PropertyState<byte[]> m_certificate;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 13225U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAENlcnRpZmljYXRlRXhwaXJhdGlvbkFsYXJtVHlwZUluc3RhbmNlAQCpMwEAqTOpMwAA/////x8AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAKozAC4ARKozAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAKszAC4ARKszAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCsMwAuAESsMwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEArTMALgBErTMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAK4zAC4ARK4zAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCvMwAuAESvMwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCxMwAuAESxMwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBALIzAC4ARLIzAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQCzMwAuAESzMwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQC0MwAuAES0MwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAtTMALgBEtTMAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQC2MwAuAES2MwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQC3MwAuAES3MwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQC4MwAvAQAjI7gzAAAAFf////8BAQUAAAABACwjAAEA0DMBACwjAAEA2TMBACwjAAEA5jMBACwjAAEA8DMBACwjAAEA+TMBAAAAFWCJCgIAAAAAAAIAAABJZAEAuTMALgBEuTMAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAMEzAC8BACojwTMAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAwjMALgBEwjMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQDDMwAvAQAqI8MzAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAMQzAC4ARMQzAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAMUzAC8BACojxTMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAxjMALgBExjMAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDHMwAuAETHMwAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAyDMALwEARCPIMwAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQDJMwAvAQBDI8kzAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQDKMwAvAQBFI8ozAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAyzMALgBEyzMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQDQMwAvAQAjI9AzAAAAFf////8BAQEAAAABACwjAQEAuDMBAAAAFWCJCgIAAAAAAAIAAABJZAEA0TMALgBE0TMAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQDiMwAvAQCXI+IzAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4zMALgBE4zMAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEA5jMALwEAIyPmMwAAABX/////AQEBAAAAAQAsIwEBALgzAQAAABVgiQoCAAAAAAACAAAASWQBAOczAC4AROczAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAO8zAC4ARO8zAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQAKNAAuAEQKNAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAALAAAATm9ybWFsU3RhdGUBAAw0AC4ARAw0AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABFeHBpcmF0aW9uRGF0ZQEADTQALgBEDTQAAAAN/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEV4cGlyYXRpb25MaW1pdAEANDoALgBENDoAAAEAIgH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQAONAAuAEQONAAAABH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQ2VydGlmaWNhdGUBAA80AC4ARA80AAAAD/////8BAf////8AAAAA");
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
    if (this.ExpirationLimit == null)
      return;
    this.ExpirationLimit.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEV4cGlyYXRpb25MaW1pdAEANDoALgBENDoAAAEAIgH/////AQH/////AAAAAA==");
  }

  public PropertyState<DateTime> ExpirationDate
  {
    get => this.m_expirationDate;
    set
    {
      if (this.m_expirationDate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_expirationDate = value;
    }
  }

  public PropertyState<double> ExpirationLimit
  {
    get => this.m_expirationLimit;
    set
    {
      if (this.m_expirationLimit != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_expirationLimit = value;
    }
  }

  public PropertyState<NodeId> CertificateType
  {
    get => this.m_certificateType;
    set
    {
      if (this.m_certificateType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificateType = value;
    }
  }

  public PropertyState<byte[]> Certificate
  {
    get => this.m_certificate;
    set
    {
      if (this.m_certificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificate = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_expirationDate != null)
      children.Add((BaseInstanceState) this.m_expirationDate);
    if (this.m_expirationLimit != null)
      children.Add((BaseInstanceState) this.m_expirationLimit);
    if (this.m_certificateType != null)
      children.Add((BaseInstanceState) this.m_certificateType);
    if (this.m_certificate != null)
      children.Add((BaseInstanceState) this.m_certificate);
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
      case "ExpirationDate":
        if (createOrReplace && this.ExpirationDate == null)
          this.ExpirationDate = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ExpirationDate;
        break;
      case "ExpirationLimit":
        if (createOrReplace && this.ExpirationLimit == null)
          this.ExpirationLimit = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ExpirationLimit;
        break;
      case "CertificateType":
        if (createOrReplace && this.CertificateType == null)
          this.CertificateType = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CertificateType;
        break;
      case "Certificate":
        if (createOrReplace && this.Certificate == null)
          this.Certificate = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Certificate;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
