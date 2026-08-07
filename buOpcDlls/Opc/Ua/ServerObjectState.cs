// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerObjectState
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
public class ServerObjectState(NodeState parent) : BaseObjectState(parent)
{
  private const string UrisVersion_InitializationString = "//////////8VcIkKAgAAAAAACwAAAFVyaXNWZXJzaW9uAQCbOgAuAESbOgAAAQAGUv////8BAQAAAAAAQI9A/////wAAAAA=";
  private const string EstimatedReturnTime_InitializationString = "//////////8VcIkKAgAAAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUBAFIyAC4ARFIyAAAADf////8BAQAAAAAAQI9A/////wAAAAA=";
  private const string LocalTime_InitializationString = "//////////8VcIkKAgAAAAAACQAAAExvY2FsVGltZQEAzEQALgBEzEQAAAEA0CL/////AQEAAAAAAECPQP////8AAAAA";
  private const string Namespaces_InitializationString = "//////////8EYIAKAQAAAAAACgAAAE5hbWVzcGFjZXMBAActAC8BAH0tBy0AAP////8AAAAA";
  private const string GetMonitoredItems_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAEdldE1vbml0b3JlZEl0ZW1zAQDhLAAvAQDhLOEsAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4iwALgBE4iwAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjLAAuAETjLAAAlgIAAAABACoBASAAAAANAAAAU2VydmVySGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKgEBIAAAAA0AAABDbGllbnRIYW5kbGVzAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string ResendData_InitializationString = "//////////8EYYIKBAAAAAAACgAAAFJlc2VuZERhdGEBAEcyAC8BAEcyRzIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBIMgAuAERIMgAAlgEAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string SetSubscriptionDurable_InitializationString = "//////////8EYYIKBAAAAAAAFgAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGUBAMoxAC8BAMoxyjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDLMQAuAETLMQAAlgIAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKgEBHgAAAA8AAABMaWZldGltZUluSG91cnMAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAMwxAC4ARMwxAACWAQAAAAEAKgEBJQAAABYAAABSZXZpc2VkTGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string RequestServerStateChange_InitializationString = "//////////8EYYIKBAAAAAAAGAAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZQEAUzIALwEAUzJTMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFQyAC4ARFQyAACWBQAAAAEAKgEBFgAAAAUAAABTdGF0ZQEAVAP/////AAAAAAABACoBASIAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQAN/////wAAAAAAAQAqAQEiAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24AB/////8AAAAAAAEAKgEBFQAAAAYAAABSZWFzb24AFf////8AAAAAAAEAKgEBFgAAAAcAAABSZXN0YXJ0AAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAEgAAAFNlcnZlclR5cGVJbnN0YW5jZQEA1AcBANQH1AcAAP////8RAAAAF3CJCgIAAAAAAAsAAABTZXJ2ZXJBcnJheQEA1QcALgBE1QcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAF3CJCgIAAAAAAA4AAABOYW1lc3BhY2VBcnJheQEA1gcALgBE1gcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABVcmlzVmVyc2lvbgEAmzoALgBEmzoAAAEABlL/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAwAAABTZXJ2ZXJTdGF0dXMBANcHAC8BAFoI1wcAAAEAXgP/////AQEAAAAAAECPQP////8GAAAAFWCJCgIAAAAAAAkAAABTdGFydFRpbWUBAAIMAC8APwIMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEN1cnJlbnRUaW1lAQADDAAvAD8DDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEABAwALwA/BAwAAAEAVAP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQnVpbGRJbmZvAQAFDAAvAQDrCwUMAAABAFIB/////wEB/////wYAAAAVcIkKAgAAAAAACgAAAFByb2R1Y3RVcmkBAAYMAC8APwYMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAAEAAAAE1hbnVmYWN0dXJlck5hbWUBAAcMAC8APwcMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAFByb2R1Y3ROYW1lAQAIDAAvAD8IDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAA8AAABTb2Z0d2FyZVZlcnNpb24BAAkMAC8APwkMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAEJ1aWxkTnVtYmVyAQAKDAAvAD8KDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAkAAABCdWlsZERhdGUBAAsMAC8APwsMAAABACYB/////wEBAAAAAABAj0D/////AAAAABVgiQoCAAAAAAATAAAAU2Vjb25kc1RpbGxTaHV0ZG93bgEADAwALwA/DAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNodXRkb3duUmVhc29uAQANDAAvAD8NDAAAABX/////AQH/////AAAAABVwiQoCAAAAAAAMAAAAU2VydmljZUxldmVsAQDYBwAuAETYBwAAAAP/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAgAAABBdWRpdGluZwEAtgoALgBEtgoAAAAB/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQEAUjIALgBEUjIAAAAN/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAATG9jYWxUaW1lAQDMRAAuAETMRAAAAQDQIv////8BAQAAAAAAQI9A/////wAAAAAEYIAKAQAAAAAAEgAAAFNlcnZlckNhcGFiaWxpdGllcwEA2QcALwEA3QfZBwAA/////wkAAAAXYIkKAgAAAAAAEgAAAFNlcnZlclByb2ZpbGVBcnJheQEADgwALgBEDgwAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAANAAAATG9jYWxlSWRBcnJheQEADwwALgBEDwwAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABYAAABNaW5TdXBwb3J0ZWRTYW1wbGVSYXRlAQAQDAAuAEQQDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABsAAABNYXhCcm93c2VDb250aW51YXRpb25Qb2ludHMBABEMAC4ARBEMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhRdWVyeUNvbnRpbnVhdGlvblBvaW50cwEAEgwALgBEEgwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heEhpc3RvcnlDb250aW51YXRpb25Qb2ludHMBABMMAC4ARBMMAAAABf////8BAf////8AAAAAF2CJCgIAAAAAABQAAABTb2Z0d2FyZUNlcnRpZmljYXRlcwEAFAwALgBEFAwAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAA4AAABNb2RlbGxpbmdSdWxlcwEAFQwALwA9FQwAAP////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBABYMAC8APRYMAAD/////AAAAAARggAoBAAAAAAARAAAAU2VydmVyRGlhZ25vc3RpY3MBANoHAC8BAOQH2gcAAP////8EAAAAFWCJCgIAAAAAABgAAABTZXJ2ZXJEaWFnbm9zdGljc1N1bW1hcnkBABcMAC8BAGYIFwwAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQAYDAAvAD8YDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAGQwALwA/GQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAGgwALwA/GgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBABsMAC8APxsMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAHAwALwA/HAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAB0MAC8APx0MAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAHgwALwA/HgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQAgDAAvAD8gDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQAhDAAvAD8hDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBACIMAC8APyIMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVk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";
  private PropertyState<string[]> m_serverArray;
  private PropertyState<string[]> m_namespaceArray;
  private PropertyState<uint> m_urisVersion;
  private ServerStatusState m_serverStatus;
  private PropertyState<byte> m_serviceLevel;
  private PropertyState<bool> m_auditing;
  private PropertyState<DateTime> m_estimatedReturnTime;
  private PropertyState<TimeZoneDataType> m_localTime;
  private ServerCapabilitiesState m_serverCapabilities;
  private ServerDiagnosticsState m_serverDiagnostics;
  private VendorServerInfoState m_vendorServerInfo;
  private ServerRedundancyState m_serverRedundancy;
  private NamespacesState m_namespaces;
  private GetMonitoredItemsMethodState m_getMonitoredItemsMethod;
  private ResendDataMethodState m_resendDataMethod;
  private SetSubscriptionDurableMethodState m_setSubscriptionDurableMethod;
  private RequestServerStateChangeMethodState m_requestServerStateChangeMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2004U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAEgAAAFNlcnZlclR5cGVJbnN0YW5jZQEA1AcBANQH1AcAAP////8RAAAAF3CJCgIAAAAAAAsAAABTZXJ2ZXJBcnJheQEA1QcALgBE1QcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAF3CJCgIAAAAAAA4AAABOYW1lc3BhY2VBcnJheQEA1gcALgBE1gcAAAAMAQAAAAEAAAAAAAAAAQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAsAAABVcmlzVmVyc2lvbgEAmzoALgBEmzoAAAEABlL/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAwAAABTZXJ2ZXJTdGF0dXMBANcHAC8BAFoI1wcAAAEAXgP/////AQEAAAAAAECPQP////8GAAAAFWCJCgIAAAAAAAkAAABTdGFydFRpbWUBAAIMAC8APwIMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAEN1cnJlbnRUaW1lAQADDAAvAD8DDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEABAwALwA/BAwAAAEAVAP/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAQnVpbGRJbmZvAQAFDAAvAQDrCwUMAAABAFIB/////wEB/////wYAAAAVcIkKAgAAAAAACgAAAFByb2R1Y3RVcmkBAAYMAC8APwYMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAAEAAAAE1hbnVmYWN0dXJlck5hbWUBAAcMAC8APwcMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAFByb2R1Y3ROYW1lAQAIDAAvAD8IDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAA8AAABTb2Z0d2FyZVZlcnNpb24BAAkMAC8APwkMAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACwAAAEJ1aWxkTnVtYmVyAQAKDAAvAD8KDAAAAAz/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAkAAABCdWlsZERhdGUBAAsMAC8APwsMAAABACYB/////wEBAAAAAABAj0D/////AAAAABVgiQoCAAAAAAATAAAAU2Vjb25kc1RpbGxTaHV0ZG93bgEADAwALwA/DAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFNodXRkb3duUmVhc29uAQANDAAvAD8NDAAAABX/////AQH/////AAAAABVwiQoCAAAAAAAMAAAAU2VydmljZUxldmVsAQDYBwAuAETYBwAAAAP/////AQEAAAAAAECPQP////8AAAAAFXCJCgIAAAAAAAgAAABBdWRpdGluZwEAtgoALgBEtgoAAAAB/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQEAUjIALgBEUjIAAAAN/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAJAAAATG9jYWxUaW1lAQDMRAAuAETMRAAAAQDQIv////8BAQAAAAAAQI9A/////wAAAAAEYIAKAQAAAAAAEgAAAFNlcnZlckNhcGFiaWxpdGllcwEA2QcALwEA3QfZBwAA/////wkAAAAXYIkKAgAAAAAAEgAAAFNlcnZlclByb2ZpbGVBcnJheQEADgwALgBEDgwAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAANAAAATG9jYWxlSWRBcnJheQEADwwALgBEDwwAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABYAAABNaW5TdXBwb3J0ZWRTYW1wbGVSYXRlAQAQDAAuAEQQDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAABsAAABNYXhCcm93c2VDb250aW51YXRpb25Qb2ludHMBABEMAC4ARBEMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAABoAAABNYXhRdWVyeUNvbnRpbnVhdGlvblBvaW50cwEAEgwALgBEEgwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAE1heEhpc3RvcnlDb250aW51YXRpb25Qb2ludHMBABMMAC4ARBMMAAAABf////8BAf////8AAAAAF2CJCgIAAAAAABQAAABTb2Z0d2FyZUNlcnRpZmljYXRlcwEAFAwALgBEFAwAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAA4AAABNb2RlbGxpbmdSdWxlcwEAFQwALwA9FQwAAP////8AAAAABGCACgEAAAAAABIAAABBZ2dyZWdhdGVGdW5jdGlvbnMBABYMAC8APRYMAAD/////AAAAAARggAoBAAAAAAARAAAAU2VydmVyRGlhZ25vc3RpY3MBANoHAC8BAOQH2gcAAP////8EAAAAFWCJCgIAAAAAABgAAABTZXJ2ZXJEaWFnbm9zdGljc1N1bW1hcnkBABcMAC8BAGYIFwwAAAEAWwP/////AQH/////DAAAABVgiQoCAAAAAAAPAAAAU2VydmVyVmlld0NvdW50AQAYDAAvAD8YDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAATAAAAQ3VycmVudFNlc3Npb25Db3VudAEAGQwALwA/GQwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAEN1bXVsYXRlZFNlc3Npb25Db3VudAEAGgwALwA/GgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAHAAAAFNlY3VyaXR5UmVqZWN0ZWRTZXNzaW9uQ291bnQBABsMAC8APxsMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABSZWplY3RlZFNlc3Npb25Db3VudAEAHAwALwA/HAwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFNlc3Npb25UaW1lb3V0Q291bnQBAB0MAC8APx0MAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABEAAABTZXNzaW9uQWJvcnRDb3VudAEAHgwALwA/HgwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFwAAAFB1Ymxpc2hpbmdJbnRlcnZhbENvdW50AQAgDAAvAD8gDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAQ3VycmVudFN1YnNjcmlwdGlvbkNvdW50AQAhDAAvAD8hDAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAaAAAAQ3VtdWxhdGVkU3Vic2NyaXB0aW9uQ291bnQBACIMAC8APyIMAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAB0AAABTZWN1cml0eVJlamVjdGVkUmVxdWVzdHNDb3VudAEAIwwALwA/IwwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFJlamVjdGVkUmVxdWVzdHNDb3VudAEAJAwALwA/JAwAAAAH/////wEB/////wAAAAAXYIkKAgAAAAAAHAAAAFN1YnNjcmlwdGlvbkRpYWdub3N0aWNzQXJyYXkBACYMAC8BAHsIJgwAAAEAagMBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAABoAAABTZXNzaW9uc0RpYWdub3N0aWNzU3VtbWFyeQEAJwwALwEA6gcnDAAA/////wIAAAAXYIkKAgAAAAAAFwAAAFNlc3Npb25EaWFnbm9zdGljc0FycmF5AQAoDAAvAQCUCCgMAAABAGEDAQAAAAEAAAAAAAAAAQH/////AAAAABdgiQoCAAAAAAAfAAAAU2Vzc2lvblNlY3VyaXR5RGlhZ25vc3RpY3NBcnJheQEAKQwALwEAwwgpDAAAAQBkAwEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEVuYWJsZWRGbGFnAQAqDAAuAEQqDAAAAAH/////AwP/////AAAAAARggAoBAAAAAAAQAAAAVmVuZG9yU2VydmVySW5mbwEA2wcALwEA8QfbBwAA/////wAAAAAEYIAKAQAAAAAAEAAAAFNlcnZlclJlZHVuZGFuY3kBANwHAC8BAPIH3AcAAP////8BAAAAFWCJCgIAAAAAABEAAABSZWR1bmRhbmN5U3VwcG9ydAEAKwwALgBEKwwAAAEAUwP/////AQH/////AAAAAARggAoBAAAAAAAKAAAATmFtZXNwYWNlcwEABy0ALwEAfS0HLQAA/////wAAAAAEYYIKBAAAAAAAEQAAAEdldE1vbml0b3JlZEl0ZW1zAQDhLAAvAQDhLOEsAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4iwALgBE4iwAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjLAAuAETjLAAAlgIAAAABACoBASAAAAANAAAAU2VydmVySGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKgEBIAAAAA0AAABDbGllbnRIYW5kbGVzAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACgAAAFJlc2VuZERhdGEBAEcyAC8BAEcyRzIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBIMgAuAERIMgAAlgEAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABYAAABTZXRTdWJzY3JpcHRpb25EdXJhYmxlAQDKMQAvAQDKMcoxAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAyzEALgBEyzEAAJYCAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACoBAR4AAAAPAAAATGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDMMQAuAETMMQAAlgEAAAABACoBASUAAAAWAAAAUmV2aXNlZExpZmV0aW1lSW5Ib3VycwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAGAAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZQEAUzIALwEAUzJTMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFQyAC4ARFQyAACWBQAAAAEAKgEBFgAAAAUAAABTdGF0ZQEAVAP/////AAAAAAABACoBASIAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQAN/////wAAAAAAAQAqAQEiAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24AB/////8AAAAAAAEAKgEBFQAAAAYAAABSZWFzb24AFf////8AAAAAAAEAKgEBFgAAAAcAAABSZXN0YXJ0AAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    if (this.UrisVersion != null)
      this.UrisVersion.Initialize(context, "//////////8VcIkKAgAAAAAACwAAAFVyaXNWZXJzaW9uAQCbOgAuAESbOgAAAQAGUv////8BAQAAAAAAQI9A/////wAAAAA=");
    if (this.EstimatedReturnTime != null)
      this.EstimatedReturnTime.Initialize(context, "//////////8VcIkKAgAAAAAAEwAAAEVzdGltYXRlZFJldHVyblRpbWUBAFIyAC4ARFIyAAAADf////8BAQAAAAAAQI9A/////wAAAAA=");
    if (this.LocalTime != null)
      this.LocalTime.Initialize(context, "//////////8VcIkKAgAAAAAACQAAAExvY2FsVGltZQEAzEQALgBEzEQAAAEA0CL/////AQEAAAAAAECPQP////8AAAAA");
    if (this.Namespaces != null)
      this.Namespaces.Initialize(context, "//////////8EYIAKAQAAAAAACgAAAE5hbWVzcGFjZXMBAActAC8BAH0tBy0AAP////8AAAAA");
    if (this.GetMonitoredItems != null)
      this.GetMonitoredItems.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAEdldE1vbml0b3JlZEl0ZW1zAQDhLAAvAQDhLOEsAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEA4iwALgBE4iwAAJYBAAAAAQAqAQEdAAAADgAAAFN1YnNjcmlwdGlvbklkAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDjLAAuAETjLAAAlgIAAAABACoBASAAAAANAAAAU2VydmVySGFuZGxlcwAHAQAAAAEAAAAAAAAAAAEAKgEBIAAAAA0AAABDbGllbnRIYW5kbGVzAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.ResendData != null)
      this.ResendData.Initialize(context, "//////////8EYYIKBAAAAAAACgAAAFJlc2VuZERhdGEBAEcyAC8BAEcyRzIAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBIMgAuAERIMgAAlgEAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.SetSubscriptionDurable != null)
      this.SetSubscriptionDurable.Initialize(context, "//////////8EYYIKBAAAAAAAFgAAAFNldFN1YnNjcmlwdGlvbkR1cmFibGUBAMoxAC8BAMoxyjEAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDLMQAuAETLMQAAlgIAAAABACoBAR0AAAAOAAAAU3Vic2NyaXB0aW9uSWQAB/////8AAAAAAAEAKgEBHgAAAA8AAABMaWZldGltZUluSG91cnMAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAMwxAC4ARMwxAACWAQAAAAEAKgEBJQAAABYAAABSZXZpc2VkTGlmZXRpbWVJbkhvdXJzAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.RequestServerStateChange == null)
      return;
    this.RequestServerStateChange.Initialize(context, "//////////8EYYIKBAAAAAAAGAAAAFJlcXVlc3RTZXJ2ZXJTdGF0ZUNoYW5nZQEAUzIALwEAUzJTMgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAFQyAC4ARFQyAACWBQAAAAEAKgEBFgAAAAUAAABTdGF0ZQEAVAP/////AAAAAAABACoBASIAAAATAAAARXN0aW1hdGVkUmV0dXJuVGltZQAN/////wAAAAAAAQAqAQEiAAAAEwAAAFNlY29uZHNUaWxsU2h1dGRvd24AB/////8AAAAAAAEAKgEBFQAAAAYAAABSZWFzb24AFf////8AAAAAAAEAKgEBFgAAAAcAAABSZXN0YXJ0AAH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
  }

  public PropertyState<string[]> ServerArray
  {
    get => this.m_serverArray;
    set
    {
      if (this.m_serverArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverArray = value;
    }
  }

  public PropertyState<string[]> NamespaceArray
  {
    get => this.m_namespaceArray;
    set
    {
      if (this.m_namespaceArray != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespaceArray = value;
    }
  }

  public PropertyState<uint> UrisVersion
  {
    get => this.m_urisVersion;
    set
    {
      if (this.m_urisVersion != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_urisVersion = value;
    }
  }

  public ServerStatusState ServerStatus
  {
    get => this.m_serverStatus;
    set
    {
      if (this.m_serverStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverStatus = value;
    }
  }

  public PropertyState<byte> ServiceLevel
  {
    get => this.m_serviceLevel;
    set
    {
      if (this.m_serviceLevel != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serviceLevel = value;
    }
  }

  public PropertyState<bool> Auditing
  {
    get => this.m_auditing;
    set
    {
      if (this.m_auditing != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_auditing = value;
    }
  }

  public PropertyState<DateTime> EstimatedReturnTime
  {
    get => this.m_estimatedReturnTime;
    set
    {
      if (this.m_estimatedReturnTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_estimatedReturnTime = value;
    }
  }

  public PropertyState<TimeZoneDataType> LocalTime
  {
    get => this.m_localTime;
    set
    {
      if (this.m_localTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_localTime = value;
    }
  }

  public ServerCapabilitiesState ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      if (this.m_serverCapabilities != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverCapabilities = value;
    }
  }

  public ServerDiagnosticsState ServerDiagnostics
  {
    get => this.m_serverDiagnostics;
    set
    {
      if (this.m_serverDiagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverDiagnostics = value;
    }
  }

  public VendorServerInfoState VendorServerInfo
  {
    get => this.m_vendorServerInfo;
    set
    {
      if (this.m_vendorServerInfo != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_vendorServerInfo = value;
    }
  }

  public ServerRedundancyState ServerRedundancy
  {
    get => this.m_serverRedundancy;
    set
    {
      if (this.m_serverRedundancy != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverRedundancy = value;
    }
  }

  public NamespacesState Namespaces
  {
    get => this.m_namespaces;
    set
    {
      if (this.m_namespaces != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_namespaces = value;
    }
  }

  public GetMonitoredItemsMethodState GetMonitoredItems
  {
    get => this.m_getMonitoredItemsMethod;
    set
    {
      if (this.m_getMonitoredItemsMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getMonitoredItemsMethod = value;
    }
  }

  public ResendDataMethodState ResendData
  {
    get => this.m_resendDataMethod;
    set
    {
      if (this.m_resendDataMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resendDataMethod = value;
    }
  }

  public SetSubscriptionDurableMethodState SetSubscriptionDurable
  {
    get => this.m_setSubscriptionDurableMethod;
    set
    {
      if (this.m_setSubscriptionDurableMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_setSubscriptionDurableMethod = value;
    }
  }

  public RequestServerStateChangeMethodState RequestServerStateChange
  {
    get => this.m_requestServerStateChangeMethod;
    set
    {
      if (this.m_requestServerStateChangeMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_requestServerStateChangeMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_serverArray != null)
      children.Add((BaseInstanceState) this.m_serverArray);
    if (this.m_namespaceArray != null)
      children.Add((BaseInstanceState) this.m_namespaceArray);
    if (this.m_urisVersion != null)
      children.Add((BaseInstanceState) this.m_urisVersion);
    if (this.m_serverStatus != null)
      children.Add((BaseInstanceState) this.m_serverStatus);
    if (this.m_serviceLevel != null)
      children.Add((BaseInstanceState) this.m_serviceLevel);
    if (this.m_auditing != null)
      children.Add((BaseInstanceState) this.m_auditing);
    if (this.m_estimatedReturnTime != null)
      children.Add((BaseInstanceState) this.m_estimatedReturnTime);
    if (this.m_localTime != null)
      children.Add((BaseInstanceState) this.m_localTime);
    if (this.m_serverCapabilities != null)
      children.Add((BaseInstanceState) this.m_serverCapabilities);
    if (this.m_serverDiagnostics != null)
      children.Add((BaseInstanceState) this.m_serverDiagnostics);
    if (this.m_vendorServerInfo != null)
      children.Add((BaseInstanceState) this.m_vendorServerInfo);
    if (this.m_serverRedundancy != null)
      children.Add((BaseInstanceState) this.m_serverRedundancy);
    if (this.m_namespaces != null)
      children.Add((BaseInstanceState) this.m_namespaces);
    if (this.m_getMonitoredItemsMethod != null)
      children.Add((BaseInstanceState) this.m_getMonitoredItemsMethod);
    if (this.m_resendDataMethod != null)
      children.Add((BaseInstanceState) this.m_resendDataMethod);
    if (this.m_setSubscriptionDurableMethod != null)
      children.Add((BaseInstanceState) this.m_setSubscriptionDurableMethod);
    if (this.m_requestServerStateChangeMethod != null)
      children.Add((BaseInstanceState) this.m_requestServerStateChangeMethod);
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
          if (name == "Auditing")
          {
            if (createOrReplace && this.Auditing == null)
              this.Auditing = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Auditing;
            break;
          }
          break;
        case 9:
          if (name == "LocalTime")
          {
            if (createOrReplace && this.LocalTime == null)
              this.LocalTime = replacement != null ? (PropertyState<TimeZoneDataType>) replacement : new PropertyState<TimeZoneDataType>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LocalTime;
            break;
          }
          break;
        case 10:
          switch (name[0])
          {
            case 'N':
              if (name == "Namespaces")
              {
                if (createOrReplace && this.Namespaces == null)
                  this.Namespaces = replacement != null ? (NamespacesState) replacement : new NamespacesState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Namespaces;
                break;
              }
              break;
            case 'R':
              if (name == "ResendData")
              {
                if (createOrReplace && this.ResendData == null)
                  this.ResendData = replacement != null ? (ResendDataMethodState) replacement : new ResendDataMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ResendData;
                break;
              }
              break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'S':
              if (name == "ServerArray")
              {
                if (createOrReplace && this.ServerArray == null)
                  this.ServerArray = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerArray;
                break;
              }
              break;
            case 'U':
              if (name == "UrisVersion")
              {
                if (createOrReplace && this.UrisVersion == null)
                  this.UrisVersion = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UrisVersion;
                break;
              }
              break;
          }
          break;
        case 12:
          switch (name[4])
          {
            case 'e':
              if (name == "ServerStatus")
              {
                if (createOrReplace && this.ServerStatus == null)
                  this.ServerStatus = replacement != null ? (ServerStatusState) replacement : new ServerStatusState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerStatus;
                break;
              }
              break;
            case 'i':
              if (name == "ServiceLevel")
              {
                if (createOrReplace && this.ServiceLevel == null)
                  this.ServiceLevel = replacement != null ? (PropertyState<byte>) replacement : new PropertyState<byte>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServiceLevel;
                break;
              }
              break;
          }
          break;
        case 14:
          if (name == "NamespaceArray")
          {
            if (createOrReplace && this.NamespaceArray == null)
              this.NamespaceArray = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.NamespaceArray;
            break;
          }
          break;
        case 16 /*0x10*/:
          switch (name[0])
          {
            case 'S':
              if (name == "ServerRedundancy")
              {
                if (createOrReplace && this.ServerRedundancy == null)
                  this.ServerRedundancy = replacement != null ? (ServerRedundancyState) replacement : new ServerRedundancyState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerRedundancy;
                break;
              }
              break;
            case 'V':
              if (name == "VendorServerInfo")
              {
                if (createOrReplace && this.VendorServerInfo == null)
                  this.VendorServerInfo = replacement != null ? (VendorServerInfoState) replacement : new VendorServerInfoState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.VendorServerInfo;
                break;
              }
              break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'G':
              if (name == "GetMonitoredItems")
              {
                if (createOrReplace && this.GetMonitoredItems == null)
                  this.GetMonitoredItems = replacement != null ? (GetMonitoredItemsMethodState) replacement : new GetMonitoredItemsMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.GetMonitoredItems;
                break;
              }
              break;
            case 'S':
              if (name == "ServerDiagnostics")
              {
                if (createOrReplace && this.ServerDiagnostics == null)
                  this.ServerDiagnostics = replacement != null ? (ServerDiagnosticsState) replacement : new ServerDiagnosticsState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.ServerDiagnostics;
                break;
              }
              break;
          }
          break;
        case 18:
          if (name == "ServerCapabilities")
          {
            if (createOrReplace && this.ServerCapabilities == null)
              this.ServerCapabilities = replacement != null ? (ServerCapabilitiesState) replacement : new ServerCapabilitiesState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ServerCapabilities;
            break;
          }
          break;
        case 19:
          if (name == "EstimatedReturnTime")
          {
            if (createOrReplace && this.EstimatedReturnTime == null)
              this.EstimatedReturnTime = replacement != null ? (PropertyState<DateTime>) replacement : new PropertyState<DateTime>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.EstimatedReturnTime;
            break;
          }
          break;
        case 22:
          if (name == "SetSubscriptionDurable")
          {
            if (createOrReplace && this.SetSubscriptionDurable == null)
              this.SetSubscriptionDurable = replacement != null ? (SetSubscriptionDurableMethodState) replacement : new SetSubscriptionDurableMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SetSubscriptionDurable;
            break;
          }
          break;
        case 24:
          if (name == "RequestServerStateChange")
          {
            if (createOrReplace && this.RequestServerStateChange == null)
              this.RequestServerStateChange = replacement != null ? (RequestServerStateChangeMethodState) replacement : new RequestServerStateChangeMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RequestServerStateChange;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
