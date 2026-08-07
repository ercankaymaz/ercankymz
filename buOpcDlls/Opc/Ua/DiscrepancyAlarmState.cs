// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DiscrepancyAlarmState
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
public class DiscrepancyAlarmState(NodeState parent) : AlarmConditionState(parent)
{
  private const string Tolerance_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFRvbGVyYW5jZQEAQUMALgBEQUMAAAAL/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAERpc2NyZXBhbmN5QWxhcm1UeXBlSW5zdGFuY2UBALhCAQC4QrhCAAD/////HQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAuUIALgBEuUIAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAukIALgBEukIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBALtCAC4ARLtCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQC8QgAuAES8QgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAvUIALgBEvUIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAL5CAC4ARL5CAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAMBCAC4ARMBCAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAwUIALgBEwUIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAMJCAC4ARMJCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAMNCAC4ARMNCAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQDGQgAuAETGQgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAMdCAC4ARMdCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAMhCAC4ARMhCAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAMlCAC8BACMjyUIAAAAV/////wEBBQAAAAEALCMAAQDhQgEALCMAAQDqQgEALCMAAQD3QgEALCMAAQABQwEALCMAAQAcQwEAAAAVYIkKAgAAAAAAAgAAAElkAQDKQgAuAETKQgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEA0kIALwEAKiPSQgAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDTQgAuAETTQgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBANRCAC8BACoj1EIAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEA1UIALgBE1UIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEA1kIALwEAKiPWQgAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDXQgAuAETXQgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBANhCAC4ARNhCAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQDZQgAvAQBEI9lCAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBANpCAC8BAEMj2kIAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBANtCAC8BAEUj20IAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDcQgAuAETcQgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBAOFCAC8BACMj4UIAAAAV/////wEBAQAAAAEALCMBAQDJQgEAAAAVYIkKAgAAAAAAAgAAAElkAQDiQgAuAETiQgAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBAPNCAC8BAJcj80IAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QgAuAET0QgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQD3QgAvAQAjI/dCAAAAFf////8BAQEAAAABACwjAQEAyUIBAAAAFWCJCgIAAAAAAAIAAABJZAEA+EIALgBE+EIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAAEMALgBEAEMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAC1DAC4ARC1DAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUYXJnZXRWYWx1ZU5vZGUBAD9DAC4ARD9DAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFeHBlY3RlZFRpbWUBAEBDAC4AREBDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRvbGVyYW5jZQEAQUMALgBEQUMAAAAL/////wEB/////wAAAAA=";
  private PropertyState<NodeId> m_targetValueNode;
  private PropertyState<double> m_expectedTime;
  private PropertyState<double> m_tolerance;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17080U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAERpc2NyZXBhbmN5QWxhcm1UeXBlSW5zdGFuY2UBALhCAQC4QrhCAAD/////HQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAuUIALgBEuUIAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAukIALgBEukIAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBALtCAC4ARLtCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQC8QgAuAES8QgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAvUIALgBEvUIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAL5CAC4ARL5CAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAMBCAC4ARMBCAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAwUIALgBEwUIAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAMJCAC4ARMJCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAMNCAC4ARMNCAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQDGQgAuAETGQgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAMdCAC4ARMdCAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAMhCAC4ARMhCAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAMlCAC8BACMjyUIAAAAV/////wEBBQAAAAEALCMAAQDhQgEALCMAAQDqQgEALCMAAQD3QgEALCMAAQABQwEALCMAAQAcQwEAAAAVYIkKAgAAAAAAAgAAAElkAQDKQgAuAETKQgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEA0kIALwEAKiPSQgAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDTQgAuAETTQgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBANRCAC8BACoj1EIAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEA1UIALgBE1UIAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEA1kIALwEAKiPWQgAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDXQgAuAETXQgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBANhCAC4ARNhCAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQDZQgAvAQBEI9lCAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBANpCAC8BAEMj2kIAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBANtCAC8BAEUj20IAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDcQgAuAETcQgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBAOFCAC8BACMj4UIAAAAV/////wEBAQAAAAEALCMBAQDJQgEAAAAVYIkKAgAAAAAAAgAAAElkAQDiQgAuAETiQgAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBAPNCAC8BAJcj80IAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQD0QgAuAET0QgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQD3QgAvAQAjI/dCAAAAFf////8BAQEAAAABACwjAQEAyUIBAAAAFWCJCgIAAAAAAAIAAABJZAEA+EIALgBE+EIAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAAEMALgBEAEMAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAC1DAC4ARC1DAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABUYXJnZXRWYWx1ZU5vZGUBAD9DAC4ARD9DAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFeHBlY3RlZFRpbWUBAEBDAC4AREBDAAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRvbGVyYW5jZQEAQUMALgBEQUMAAAAL/////wEB/////wAAAAA=");
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
    if (this.Tolerance == null)
      return;
    this.Tolerance.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFRvbGVyYW5jZQEAQUMALgBEQUMAAAAL/////wEB/////wAAAAA=");
  }

  public PropertyState<NodeId> TargetValueNode
  {
    get => this.m_targetValueNode;
    set
    {
      if (this.m_targetValueNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_targetValueNode = value;
    }
  }

  public PropertyState<double> ExpectedTime
  {
    get => this.m_expectedTime;
    set
    {
      if (this.m_expectedTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_expectedTime = value;
    }
  }

  public PropertyState<double> Tolerance
  {
    get => this.m_tolerance;
    set
    {
      if (this.m_tolerance != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_tolerance = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_targetValueNode != null)
      children.Add((BaseInstanceState) this.m_targetValueNode);
    if (this.m_expectedTime != null)
      children.Add((BaseInstanceState) this.m_expectedTime);
    if (this.m_tolerance != null)
      children.Add((BaseInstanceState) this.m_tolerance);
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
      case "TargetValueNode":
        if (createOrReplace && this.TargetValueNode == null)
          this.TargetValueNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TargetValueNode;
        break;
      case "ExpectedTime":
        if (createOrReplace && this.ExpectedTime == null)
          this.ExpectedTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ExpectedTime;
        break;
      case "Tolerance":
        if (createOrReplace && this.Tolerance == null)
          this.Tolerance = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Tolerance;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
