// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubConnectionState
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
public class PubSubConnectionState(NodeState parent) : BaseObjectState(parent)
{
  private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQAzQwAvAQA5RTNDAAD/////AAAAAA==";
  private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQApSwAvAQBKTSlLAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAKksALwA/KksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAK0sALwEADU0rSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAsSwAuAEQsSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAC1LAC4ARC1LAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAC5LAC4ARC5LAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBADBLAC8BAA1NMEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAMUsALgBEMUsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAySwAuAEQySwAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAzSwAuAEQzSwAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEANUsALwEA6Uw1SwAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBADZLAC8APzZLAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAN0sALwA6N0sAAP////8GAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQA4SwAvAQANTThLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBADlLAC4ARDlLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAOksALgBEOksAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQA7SwAuAEQ7SwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAPUsALwEADU09SwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQA+SwAuAEQ+SwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAD9LAC4ARD9LAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAQEsALgBEQEsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAEJLAC8BAA1NQksAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAQ0sALgBEQ0sAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBESwAuAERESwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAEVLAC4AREVLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAR0sALwEADU1HSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBISwAuAERISwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAElLAC4ARElLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEASksALgBESksAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQBMSwAvAQANTUxLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAE1LAC4ARE1LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEATksALgBETksAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBPSwAuAERPSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAUUsALwEADU1RSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBSSwAuAERSSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAFNLAC4ARFNLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAVEsALgBEVEsAAAYAAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQBWSwAvADpWSwAA/////wEAAAAVYIkKAgAAAAAADwAAAFJlc29sdmVkQWRkcmVzcwEAV0sALwA/V0sAAAAM/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAFhLAC4ARFhLAAAGAAAAAAEAC03/////AQH/////AAAAAA==";
  private const string AddWriterGroup_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZFdyaXRlckdyb3VwAQATRAAvAQATRBNEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFEQALgBEFEQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAMEQALgBEMEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string AddReaderGroup_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZFJlYWRlckdyb3VwAQA5RAAvAQA5RDlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAY0QALgBEY0QAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAKA8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEQALgBEZEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string RemoveGroup_InitializationString = "//////////8EYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlSW5zdGFuY2UBAIE3AQCBN4E3AAD/////CgAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAAM5AC4ARAM5AAAAGP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABUcmFuc3BvcnRQcm9maWxlVXJpAQCaQwAvAQC1P5pDAAAADP////8BAf////8BAAAAF2CJCgIAAAAAAAoAAABTZWxlY3Rpb25zAQAuRQAuAEQuRQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABDb25uZWN0aW9uUHJvcGVydGllcwEATUQALgBETUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAAcAAABBZGRyZXNzAQCNNwAvAQCZUo03AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMkMALwEAtT8yQwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAqEQALgBEqEQAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAARAAAAVHJhbnNwb3J0U2V0dGluZ3MBADNDAC8BADlFM0MAAP////8AAAAABGCACgEAAAAAAAYAAABTdGF0dXMBAAg5AC8BADM5CDkAAP////8BAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEACTkALwA/CTkAAAEANzn/////AQH/////AAAAAARggAoBAAAAAAALAAAARGlhZ25vc3RpY3MBAClLAC8BAEpNKUsAAP////8HAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAqSwAvAD8qSwAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABUb3RhbEluZm9ybWF0aW9uAQArSwAvAQANTStLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBACxLAC4ARCxLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEALUsALgBELUsAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEALksALgBELksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVG90YWxFcnJvcgEAMEsALwEADU0wSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAxSwAuAEQxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BADJLAC4ARDJLAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADNLAC4ARDNLAAABAAtN/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQA1SwAvAQDpTDVLAAABAf////8AAAAAFWCJCgIAAAAAAAgAAABTdWJFcnJvcgEANksALwA/NksAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAACAAAAENvdW50ZXJzAQA3SwAvADo3SwAA/////wYAAAAVYIkKAgAAAAAACgAAAFN0YXRlRXJyb3IBADhLAC8BAA1NOEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAOUsALgBEOUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQA6SwAuAEQ6SwAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADtLAC4ARDtLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5TWV0aG9kAQA9SwAvAQANTT1LAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAD5LAC4ARD5LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAP0sALgBEP0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBASwAuAERASwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeVBhcmVudAEAQksALwEADU1CSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBDSwAuAERDSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAERLAC4ARERLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEARUsALgBERUsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0ZU9wZXJhdGlvbmFsRnJvbUVycm9yAQBHSwAvAQANTUdLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAEhLAC4AREhLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEASUsALgBESUsAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBKSwAuAERKSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN0YXRlUGF1c2VkQnlQYXJlbnQBAExLAC8BAA1NTEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEATUsALgBETUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBOSwAuAEROSwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAE9LAC4ARE9LAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAU3RhdGVEaXNhYmxlZEJ5TWV0aG9kAQBRSwAvAQANTVFLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAFJLAC4ARFJLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAU0sALgBEU0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBUSwAuAERUSwAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAFZLAC8AOlZLAAD/////AQAAABVgiQoCAAAAAAAPAAAAUmVzb2x2ZWRBZGRyZXNzAQBXSwAvAD9XSwAAAAz/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAWEsALgBEWEsAAAYAAAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAA4AAABBZGRXcml0ZXJHcm91cAEAE0QALwEAE0QTRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABREAC4ARBREAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQB4PP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADBEAC4ARDBEAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkUmVhZGVyR3JvdXABADlEAC8BADlEOUQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjRAAuAERjRAAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEAoDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBkRAAuAERkRAAAlgEAAAABACoBARYAAAAHAAAAR3JvdXBJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState m_publisherId;
  private SelectionListState<string> m_transportProfileUri;
  private PropertyState<KeyValuePair[]> m_connectionProperties;
  private NetworkAddressState m_address;
  private ConnectionTransportState m_transportSettings;
  private PubSubStatusState m_status;
  private PubSubDiagnosticsConnectionState m_diagnostics;
  private PubSubConnectionTypeAddWriterGroupMethodState m_addWriterGroupMethod;
  private PubSubConnectionAddReaderGroupGroupMethodState m_addReaderGroupMethod;
  private PubSubConnectionTypeRemoveGroupMethodState m_removeGroupMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 14209U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHAAAAFB1YlN1YkNvbm5lY3Rpb25UeXBlSW5zdGFuY2UBAIE3AQCBN4E3AAD/////CgAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAAM5AC4ARAM5AAAAGP////8BAf////8AAAAAFWCJCgIAAAAAABMAAABUcmFuc3BvcnRQcm9maWxlVXJpAQCaQwAvAQC1P5pDAAAADP////8BAf////8BAAAAF2CJCgIAAAAAAAoAAABTZWxlY3Rpb25zAQAuRQAuAEQuRQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAABQAAABDb25uZWN0aW9uUHJvcGVydGllcwEATUQALgBETUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAAAcAAABBZGRyZXNzAQCNNwAvAQCZUo03AAD/////AQAAABVgiQoCAAAAAAAQAAAATmV0d29ya0ludGVyZmFjZQEAMkMALwEAtT8yQwAAAAz/////AQH/////AQAAABdgiQoCAAAAAAAKAAAAU2VsZWN0aW9ucwEAqEQALgBEqEQAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAAARggAoBAAAAAAARAAAAVHJhbnNwb3J0U2V0dGluZ3MBADNDAC8BADlFM0MAAP////8AAAAABGCACgEAAAAAAAYAAABTdGF0dXMBAAg5AC8BADM5CDkAAP////8BAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEACTkALwA/CTkAAAEANzn/////AQH/////AAAAAARggAoBAAAAAAALAAAARGlhZ25vc3RpY3MBAClLAC8BAEpNKUsAAP////8HAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAqSwAvAD8qSwAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABUb3RhbEluZm9ybWF0aW9uAQArSwAvAQANTStLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBACxLAC4ARCxLAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEALUsALgBELUsAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEALksALgBELksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVG90YWxFcnJvcgEAMEsALwEADU0wSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAxSwAuAEQxSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BADJLAC4ARDJLAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADNLAC4ARDNLAAABAAtN/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQA1SwAvAQDpTDVLAAABAf////8AAAAAFWCJCgIAAAAAAAgAAABTdWJFcnJvcgEANksALwA/NksAAAAB/////wEB/////wAAAAAEYIAKAQAAAAAACAAAAENvdW50ZXJzAQA3SwAvADo3SwAA/////wYAAAAVYIkKAgAAAAAACgAAAFN0YXRlRXJyb3IBADhLAC8BAA1NOEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAOUsALgBEOUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQA6SwAuAEQ6SwAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBADtLAC4ARDtLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5TWV0aG9kAQA9SwAvAQANTT1LAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAD5LAC4ARD5LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAP0sALgBEP0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBASwAuAERASwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeVBhcmVudAEAQksALwEADU1CSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBDSwAuAERDSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAERLAC4ARERLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEARUsALgBERUsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABkAAABTdGF0ZU9wZXJhdGlvbmFsRnJvbUVycm9yAQBHSwAvAQANTUdLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAEhLAC4AREhLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEASUsALgBESUsAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBKSwAuAERKSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN0YXRlUGF1c2VkQnlQYXJlbnQBAExLAC8BAA1NTEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEATUsALgBETUsAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBOSwAuAEROSwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAE9LAC4ARE9LAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAU3RhdGVEaXNhYmxlZEJ5TWV0aG9kAQBRSwAvAQANTVFLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAFJLAC4ARFJLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAU0sALgBEU0sAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBUSwAuAERUSwAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAFZLAC8AOlZLAAD/////AQAAABVgiQoCAAAAAAAPAAAAUmVzb2x2ZWRBZGRyZXNzAQBXSwAvAD9XSwAAAAz/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAWEsALgBEWEsAAAYAAAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAA4AAABBZGRXcml0ZXJHcm91cAEAE0QALwEAE0QTRAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBABREAC4ARBREAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQB4PP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBADBEAC4ARDBEAACWAQAAAAEAKgEBFgAAAAcAAABHcm91cElkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAQWRkUmVhZGVyR3JvdXABADlEAC8BADlEOUQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBjRAAuAERjRAAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEAoDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBkRAAuAERkRAAAlgEAAAABACoBARYAAAAHAAAAR3JvdXBJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
    if (this.TransportSettings != null)
      this.TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQAzQwAvAQA5RTNDAAD/////AAAAAA==");
    if (this.Diagnostics != null)
      this.Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQApSwAvAQBKTSlLAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAKksALwA/KksAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAK0sALwEADU0rSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQAsSwAuAEQsSwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAC1LAC4ARC1LAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAC5LAC4ARC5LAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBADBLAC8BAA1NMEsAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAMUsALgBEMUsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQAySwAuAEQySwAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQAzSwAuAEQzSwAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEANUsALwEA6Uw1SwAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBADZLAC8APzZLAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAN0sALwA6N0sAAP////8GAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQA4SwAvAQANTThLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBADlLAC4ARDlLAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAOksALgBEOksAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQA7SwAuAEQ7SwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAPUsALwEADU09SwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQA+SwAuAEQ+SwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAD9LAC4ARD9LAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAQEsALgBEQEsAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAEJLAC8BAA1NQksAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAQ0sALgBEQ0sAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBESwAuAERESwAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAEVLAC4AREVLAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAR0sALwEADU1HSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBISwAuAERISwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAElLAC4ARElLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEASksALgBESksAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQBMSwAvAQANTUxLAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAE1LAC4ARE1LAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEATksALgBETksAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBPSwAuAERPSwAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAUUsALwEADU1RSwAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBSSwAuAERSSwAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAFNLAC4ARFNLAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAVEsALgBEVEsAAAYAAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQBWSwAvADpWSwAA/////wEAAAAVYIkKAgAAAAAADwAAAFJlc29sdmVkQWRkcmVzcwEAV0sALwA/V0sAAAAM/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAFhLAC4ARFhLAAAGAAAAAAEAC03/////AQH/////AAAAAA==");
    if (this.AddWriterGroup != null)
      this.AddWriterGroup.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZFdyaXRlckdyb3VwAQATRAAvAQATRBNEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAFEQALgBEFEQAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAHg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAMEQALgBEMEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.AddReaderGroup != null)
      this.AddReaderGroup.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZFJlYWRlckdyb3VwAQA5RAAvAQA5RDlEAAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAY0QALgBEY0QAAJYBAAAAAQAqAQEeAAAADQAAAENvbmZpZ3VyYXRpb24BAKA8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAZEQALgBEZEQAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.RemoveGroup == null)
      return;
    this.RemoveGroup.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAFJlbW92ZUdyb3VwAQCRNwAvAQCRN5E3AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAkjcALgBEkjcAAJYBAAAAAQAqAQEWAAAABwAAAEdyb3VwSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
  }

  public PropertyState PublisherId
  {
    get => this.m_publisherId;
    set
    {
      if (this.m_publisherId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publisherId = value;
    }
  }

  public SelectionListState<string> TransportProfileUri
  {
    get => this.m_transportProfileUri;
    set
    {
      if (this.m_transportProfileUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportProfileUri = value;
    }
  }

  public PropertyState<KeyValuePair[]> ConnectionProperties
  {
    get => this.m_connectionProperties;
    set
    {
      if (this.m_connectionProperties != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_connectionProperties = value;
    }
  }

  public NetworkAddressState Address
  {
    get => this.m_address;
    set
    {
      if (this.m_address != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_address = value;
    }
  }

  public ConnectionTransportState TransportSettings
  {
    get => this.m_transportSettings;
    set
    {
      if (this.m_transportSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportSettings = value;
    }
  }

  public PubSubStatusState Status
  {
    get => this.m_status;
    set
    {
      if (this.m_status != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_status = value;
    }
  }

  public PubSubDiagnosticsConnectionState Diagnostics
  {
    get => this.m_diagnostics;
    set
    {
      if (this.m_diagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnostics = value;
    }
  }

  public PubSubConnectionTypeAddWriterGroupMethodState AddWriterGroup
  {
    get => this.m_addWriterGroupMethod;
    set
    {
      if (this.m_addWriterGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addWriterGroupMethod = value;
    }
  }

  public PubSubConnectionAddReaderGroupGroupMethodState AddReaderGroup
  {
    get => this.m_addReaderGroupMethod;
    set
    {
      if (this.m_addReaderGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addReaderGroupMethod = value;
    }
  }

  public PubSubConnectionTypeRemoveGroupMethodState RemoveGroup
  {
    get => this.m_removeGroupMethod;
    set
    {
      if (this.m_removeGroupMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeGroupMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_publisherId != null)
      children.Add((BaseInstanceState) this.m_publisherId);
    if (this.m_transportProfileUri != null)
      children.Add((BaseInstanceState) this.m_transportProfileUri);
    if (this.m_connectionProperties != null)
      children.Add((BaseInstanceState) this.m_connectionProperties);
    if (this.m_address != null)
      children.Add((BaseInstanceState) this.m_address);
    if (this.m_transportSettings != null)
      children.Add((BaseInstanceState) this.m_transportSettings);
    if (this.m_status != null)
      children.Add((BaseInstanceState) this.m_status);
    if (this.m_diagnostics != null)
      children.Add((BaseInstanceState) this.m_diagnostics);
    if (this.m_addWriterGroupMethod != null)
      children.Add((BaseInstanceState) this.m_addWriterGroupMethod);
    if (this.m_addReaderGroupMethod != null)
      children.Add((BaseInstanceState) this.m_addReaderGroupMethod);
    if (this.m_removeGroupMethod != null)
      children.Add((BaseInstanceState) this.m_removeGroupMethod);
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
        case 6:
          if (name == "Status")
          {
            if (createOrReplace && this.Status == null)
              this.Status = replacement != null ? (PubSubStatusState) replacement : new PubSubStatusState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Status;
            break;
          }
          break;
        case 7:
          if (name == "Address")
          {
            if (createOrReplace && this.Address == null)
              this.Address = replacement != null ? (NetworkAddressState) replacement : new NetworkAddressState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Address;
            break;
          }
          break;
        case 11:
          switch (name[0])
          {
            case 'D':
              if (name == "Diagnostics")
              {
                if (createOrReplace && this.Diagnostics == null)
                  this.Diagnostics = replacement != null ? (PubSubDiagnosticsConnectionState) replacement : new PubSubDiagnosticsConnectionState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.Diagnostics;
                break;
              }
              break;
            case 'P':
              if (name == "PublisherId")
              {
                if (createOrReplace && this.PublisherId == null)
                  this.PublisherId = replacement != null ? (PropertyState) replacement : new PropertyState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.PublisherId;
                break;
              }
              break;
            case 'R':
              if (name == "RemoveGroup")
              {
                if (createOrReplace && this.RemoveGroup == null)
                  this.RemoveGroup = replacement != null ? (PubSubConnectionTypeRemoveGroupMethodState) replacement : new PubSubConnectionTypeRemoveGroupMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RemoveGroup;
                break;
              }
              break;
          }
          break;
        case 14:
          switch (name[3])
          {
            case 'R':
              if (name == "AddReaderGroup")
              {
                if (createOrReplace && this.AddReaderGroup == null)
                  this.AddReaderGroup = replacement != null ? (PubSubConnectionAddReaderGroupGroupMethodState) replacement : new PubSubConnectionAddReaderGroupGroupMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddReaderGroup;
                break;
              }
              break;
            case 'W':
              if (name == "AddWriterGroup")
              {
                if (createOrReplace && this.AddWriterGroup == null)
                  this.AddWriterGroup = replacement != null ? (PubSubConnectionTypeAddWriterGroupMethodState) replacement : new PubSubConnectionTypeAddWriterGroupMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddWriterGroup;
                break;
              }
              break;
          }
          break;
        case 17:
          if (name == "TransportSettings")
          {
            if (createOrReplace && this.TransportSettings == null)
              this.TransportSettings = replacement != null ? (ConnectionTransportState) replacement : new ConnectionTransportState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TransportSettings;
            break;
          }
          break;
        case 19:
          if (name == "TransportProfileUri")
          {
            if (createOrReplace && this.TransportProfileUri == null)
              this.TransportProfileUri = replacement != null ? (SelectionListState<string>) replacement : new SelectionListState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TransportProfileUri;
            break;
          }
          break;
        case 20:
          if (name == "ConnectionProperties")
          {
            if (createOrReplace && this.ConnectionProperties == null)
              this.ConnectionProperties = replacement != null ? (PropertyState<KeyValuePair[]>) replacement : new PropertyState<KeyValuePair[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ConnectionProperties;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
