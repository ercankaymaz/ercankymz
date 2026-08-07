// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NonExclusiveDeviationAlarmState
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
public class NonExclusiveDeviationAlarmState(NodeState parent) : NonExclusiveLimitAlarmState(parent)
{
  private const string BaseSetpointNode_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAEJhc2VTZXRwb2ludE5vZGUBAIhBAC4ARIhBAAAAEf////8BAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAE5vbkV4Y2x1c2l2ZURldmlhdGlvbkFsYXJtVHlwZUluc3RhbmNlAQCAKAEAgCiAKAAA/////xwAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAIEoAC4ARIEoAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAIIoAC4ARIIoAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCDKAAuAESDKAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAhCgALgBEhCgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAIUoAC4ARIUoAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCGKAAuAESGKAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCIKAAuAESIKAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAIkoAC4ARIkoAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQCNKwAuAESNKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQCOKwAuAESOKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAiigALgBEiigAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQCLKAAuAESLKAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQCMKAAuAESMKAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQCNKAAvAQAjI40oAAAAFf////8BAQUAAAABACwjAAEAoygBACwjAAEArCgBACwjAAEAuSgBACwjAAEAwigBACwjAAEAyygBAAAAFWCJCgIAAAAAAAIAAABJZAEAjigALgBEjigAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAJYoAC8BACojligAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAlygALgBElygAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQCYKAAvAQAqI5goAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAJkoAC4ARJkoAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAJooAC8BACojmigAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAmygALgBEmygAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCcKAAuAEScKAAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAnigALwEARCOeKAAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCdKAAvAQBDI50oAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCfKAAvAQBFI58oAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoCgALgBEoCgAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCjKAAvAQAjI6MoAAAAFf////8BAQEAAAABACwjAQEAjSgBAAAAFWCJCgIAAAAAAAIAAABJZAEApCgALgBEpCgAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQC1KAAvAQCXI7UoAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAtigALgBEtigAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAuSgALwEAIyO5KAAAABX/////AQEFAAAAAQAsIwEBAI0oAQAsIwABAPIoAQAsIwABAPsoAQAsIwABAAQpAQAsIwABAA0pAQAAABVgiQoCAAAAAAACAAAASWQBALooAC4ARLooAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAI8rAC4ARI8rAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQDwKAAuAETwKAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2V0cG9pbnROb2RlAQAaKQAuAEQaKQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQmFzZVNldHBvaW50Tm9kZQEAiEEALgBEiEEAAAAR/////wEB/////wAAAAA=";
  private PropertyState<NodeId> m_setpointNode;
  private PropertyState<NodeId> m_baseSetpointNode;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 10368U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAE5vbkV4Y2x1c2l2ZURldmlhdGlvbkFsYXJtVHlwZUluc3RhbmNlAQCAKAEAgCiAKAAA/////xwAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAIEoAC4ARIEoAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAIIoAC4ARIIoAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCDKAAuAESDKAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAhCgALgBEhCgAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAIUoAC4ARIUoAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCGKAAuAESGKAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCIKAAuAESIKAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAIkoAC4ARIkoAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABDb25kaXRpb25DbGFzc0lkAQCNKwAuAESNKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ29uZGl0aW9uQ2xhc3NOYW1lAQCOKwAuAESOKwAAABX/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQ29uZGl0aW9uTmFtZQEAiigALgBEiigAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAEJyYW5jaElkAQCLKAAuAESLKAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAUmV0YWluAQCMKAAuAESMKAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAARW5hYmxlZFN0YXRlAQCNKAAvAQAjI40oAAAAFf////8BAQUAAAABACwjAAEAoygBACwjAAEArCgBACwjAAEAuSgBACwjAAEAwigBACwjAAEAyygBAAAAFWCJCgIAAAAAAAIAAABJZAEAjigALgBEjigAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFF1YWxpdHkBAJYoAC8BACojligAAAAT/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAlygALgBElygAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATGFzdFNldmVyaXR5AQCYKAAvAQAqI5goAAAABf////8BAf////8BAAAAFWCJCgIAAAAAAA8AAABTb3VyY2VUaW1lc3RhbXABAJkoAC4ARJkoAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbW1lbnQBAJooAC8BACojmigAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAmygALgBEmygAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCcKAAuAEScKAAAAAz/////AQH/////AAAAAARhggoEAAAAAAAHAAAARGlzYWJsZQEAnigALwEARCOeKAAAAQEBAAAAAQD5CwABAPMKAAAAAARhggoEAAAAAAAGAAAARW5hYmxlAQCdKAAvAQBDI50oAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAoAAABBZGRDb21tZW50AQCfKAAvAQBFI58oAAABAQEAAAABAPkLAAEADQsBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAoCgALgBEoCgAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAoAAABBY2tlZFN0YXRlAQCjKAAvAQAjI6MoAAAAFf////8BAQEAAAABACwjAQEAjSgBAAAAFWCJCgIAAAAAAAIAAABJZAEApCgALgBEpCgAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFja25vd2xlZGdlAQC1KAAvAQCXI7UoAAABAQEAAAABAPkLAAEA8CIBAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAtigALgBEtigAAJYCAAAAAQAqAQFGAAAABwAAAEV2ZW50SWQAD/////8AAAAAAwAAAAAoAAAAVGhlIGlkZW50aWZpZXIgZm9yIHRoZSBldmVudCB0byBjb21tZW50LgEAKgEBQgAAAAcAAABDb21tZW50ABX/////AAAAAAMAAAAAJAAAAFRoZSBjb21tZW50IHRvIGFkZCB0byB0aGUgY29uZGl0aW9uLgEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABBY3RpdmVTdGF0ZQEAuSgALwEAIyO5KAAAABX/////AQEFAAAAAQAsIwEBAI0oAQAsIwABAPIoAQAsIwABAPsoAQAsIwABAAQpAQAsIwABAA0pAQAAABVgiQoCAAAAAAACAAAASWQBALooAC4ARLooAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABJbnB1dE5vZGUBAI8rAC4ARI8rAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdXBwcmVzc2VkT3JTaGVsdmVkAQDwKAAuAETwKAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2V0cG9pbnROb2RlAQAaKQAuAEQaKQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAQmFzZVNldHBvaW50Tm9kZQEAiEEALgBEiEEAAAAR/////wEB/////wAAAAA=");
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
    if (this.BaseSetpointNode == null)
      return;
    this.BaseSetpointNode.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEJhc2VTZXRwb2ludE5vZGUBAIhBAC4ARIhBAAAAEf////8BAf////8AAAAA");
  }

  public PropertyState<NodeId> SetpointNode
  {
    get => this.m_setpointNode;
    set
    {
      if (this.m_setpointNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setpointNode = value;
    }
  }

  public PropertyState<NodeId> BaseSetpointNode
  {
    get => this.m_baseSetpointNode;
    set
    {
      if (this.m_baseSetpointNode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_baseSetpointNode = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_setpointNode != null)
      children.Add((BaseInstanceState) this.m_setpointNode);
    if (this.m_baseSetpointNode != null)
      children.Add((BaseInstanceState) this.m_baseSetpointNode);
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
      case "SetpointNode":
        if (createOrReplace && this.SetpointNode == null)
          this.SetpointNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SetpointNode;
        break;
      case "BaseSetpointNode":
        if (createOrReplace && this.BaseSetpointNode == null)
          this.BaseSetpointNode = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.BaseSetpointNode;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
