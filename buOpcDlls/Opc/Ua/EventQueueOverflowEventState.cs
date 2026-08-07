// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventQueueOverflowEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class EventQueueOverflowEventState(NodeState parent) : BaseEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEV2ZW50UXVldWVPdmVyZmxvd0V2ZW50VHlwZUluc3RhbmNlAQDbCwEA2wvbCwAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAHcMAC4ARHcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAHgMAC4ARHgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQB5DAAuAER5DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAegwALgBEegwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAHsMAC4ARHsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQB8DAAuAER8DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQB+DAAuAER+DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAH8MAC4ARH8MAAAABf////8BAf////8AAAAA";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 3035U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEV2ZW50UXVldWVPdmVyZmxvd0V2ZW50VHlwZUluc3RhbmNlAQDbCwEA2wvbCwAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAHcMAC4ARHcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAHgMAC4ARHgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQB5DAAuAER5DAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAegwALgBEegwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAHsMAC4ARHsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQB8DAAuAER8DAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQB+DAAuAER+DAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAH8MAC4ARH8MAAAABf////8BAf////8AAAAA");
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
}
