// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ExclusiveLimitAlarmState
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
public class ExclusiveLimitAlarmState(NodeState parent) : LimitAlarmState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAEV4Y2x1c2l2ZUxpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAH0kAQB9JH0kAAD/////GwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAfiQALgBEfiQAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAfyQALgBEfyQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIAkAC4ARIAkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCBJAAuAESBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAgiQALgBEgiQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIMkAC4ARIMkAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIUkAC4ARIUkAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAhiQALgBEhiQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHgrAC4ARHgrAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHkrAC4ARHkrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQCHJAAuAESHJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAIgkAC4ARIgkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAIkkAC4ARIkkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAIokAC8BACMjiiQAAAAV/////wEBBQAAAAEALCMAAQCgJAEALCMAAQCpJAEALCMAAQC2JAEALCMAAQC/JAEALCMAAQDIJAEAAAAVYIkKAgAAAAAAAgAAAElkAQCLJAAuAESLJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAkyQALwEAKiOTJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQCUJAAuAESUJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAJUkAC8BACojlSQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAliQALgBEliQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAlyQALwEAKiOXJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQCYJAAuAESYJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAJkkAC4ARJkkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQCbJAAvAQBEI5skAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAJokAC8BAEMjmiQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAJwkAC8BAEUjnCQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCdJAAuAESdJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBAKAkAC8BACMjoCQAAAAV/////wEBAQAAAAEALCMBAQCKJAEAAAAVYIkKAgAAAAAAAgAAAElkAQChJAAuAEShJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBALIkAC8BAJcjsiQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCzJAAuAESzJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQC2JAAvAQAjI7YkAAAAFf////8BAQIAAAABACwjAQEAiiQBACwjAAEA7yQBAAAAFWCJCgIAAAAAAAIAAABJZAEAtyQALgBEtyQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAeisALgBEeisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAO0kAC4ARO0kAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaW1pdFN0YXRlAQDvJAAvAQBmJO8kAAABAAAAAQAsIwEBALYkAgAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDwJAAvAQDICvAkAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA8SQALgBE8SQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQD1JAAvAQDPCvUkAAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEA9iQALgBE9iQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD5JAAuAET5JAAAAQAmAf////8BAf////8AAAAA";
  private ExclusiveLimitStateMachineState m_limitState;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 9341U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAEV4Y2x1c2l2ZUxpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAH0kAQB9JH0kAAD/////GwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAfiQALgBEfiQAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAfyQALgBEfyQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAIAkAC4ARIAkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCBJAAuAESBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAgiQALgBEgiQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAIMkAC4ARIMkAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAIUkAC4ARIUkAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAhiQALgBEhiQAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHgrAC4ARHgrAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHkrAC4ARHkrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQCHJAAuAESHJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAIgkAC4ARIgkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAIkkAC4ARIkkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAIokAC8BACMjiiQAAAAV/////wEBBQAAAAEALCMAAQCgJAEALCMAAQCpJAEALCMAAQC2JAEALCMAAQC/JAEALCMAAQDIJAEAAAAVYIkKAgAAAAAAAgAAAElkAQCLJAAuAESLJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAkyQALwEAKiOTJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQCUJAAuAESUJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAJUkAC8BACojlSQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAliQALgBEliQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAlyQALwEAKiOXJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQCYJAAuAESYJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAJkkAC4ARJkkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQCbJAAvAQBEI5skAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAJokAC8BAEMjmiQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBAJwkAC8BAEUjnCQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCdJAAuAESdJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBAKAkAC8BACMjoCQAAAAV/////wEBAQAAAAEALCMBAQCKJAEAAAAVYIkKAgAAAAAAAgAAAElkAQChJAAuAEShJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBALIkAC8BAJcjsiQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCzJAAuAESzJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQC2JAAvAQAjI7YkAAAAFf////8BAQIAAAABACwjAQEAiiQBACwjAAEA7yQBAAAAFWCJCgIAAAAAAAIAAABJZAEAtyQALgBEtyQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAeisALgBEeisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAO0kAC4ARO0kAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaW1pdFN0YXRlAQDvJAAvAQBmJO8kAAABAAAAAQAsIwEBALYkAgAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQDwJAAvAQDICvAkAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA8SQALgBE8SQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQD1JAAvAQDPCvUkAAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEA9iQALgBE9iQAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQD5JAAuAET5JAAAAQAmAf////8BAf////8AAAAA");
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

  public ExclusiveLimitStateMachineState LimitState
  {
    get => this.m_limitState;
    set
    {
      if (this.m_limitState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_limitState = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_limitState != null)
      children.Add((BaseInstanceState) this.m_limitState);
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
    if (browseName.Name == "LimitState")
    {
      if (createOrReplace && this.LimitState == null)
        this.LimitState = replacement != null ? (ExclusiveLimitStateMachineState) replacement : new ExclusiveLimitStateMachineState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.LimitState;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  public override void SetActiveState(ISystemContext context, bool active)
  {
    if (!active)
      this.SetLimitState(context, LimitAlarmStates.Inactive);
    else if (this.LimitState.CurrentState.Id.Value != (object) null)
      base.SetActiveState(context, true);
    else if (this.HighLimit != null)
      this.SetLimitState(context, LimitAlarmStates.High);
    else
      this.SetLimitState(context, LimitAlarmStates.Low);
  }

  public virtual void SetLimitState(ISystemContext context, LimitAlarmStates limit)
  {
    switch (limit)
    {
      case LimitAlarmStates.HighHigh:
        this.LimitState.SetState(context, 9329U);
        break;
      case LimitAlarmStates.High:
        this.LimitState.SetState(context, 9331U);
        break;
      case LimitAlarmStates.Low:
        this.LimitState.SetState(context, 9333U);
        break;
      case LimitAlarmStates.LowLow:
        this.LimitState.SetState(context, 9335U);
        break;
      default:
        this.LimitState.SetState(context, 0U);
        break;
    }
    this.SetActiveEffectiveSubState(context, this.LimitState.CurrentState.Value, DateTime.UtcNow);
    base.SetActiveState(context, limit != 0);
  }
}
