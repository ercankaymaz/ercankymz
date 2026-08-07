// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetWriterState
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
public class DataSetWriterState(NodeState parent) : BaseObjectState(parent)
{
  private const string KeyFrameCount_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAA";
  private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDHOwAvAQDJO8c7AAD/////AAAAAA==";
  private const string MessageSettings_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAA=";
  private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQBeTAAvAQAATl5MAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAX0wALwA/X0wAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAYEwALwEADU1gTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBhTAAuAERhTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAGJMAC4ARGJMAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAGNMAC4ARGNMAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAGVMAC8BAA1NZUwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAZkwALgBEZkwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBnTAAuAERnTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBoTAAuAERoTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAakwALwEA6UxqTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAGtMAC8AP2tMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAbEwALwA6bEwAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQBtTAAvAQANTW1MAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAG5MAC4ARG5MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAb0wALgBEb0wAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBwTAAuAERwTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAckwALwEADU1yTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBzTAAuAERzTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAHRMAC4ARHRMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAdUwALgBEdUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAHdMAC8BAA1Nd0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAeEwALgBEeEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB5TAAuAER5TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHpMAC4ARHpMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAfEwALwEADU18TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQB9TAAuAER9TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAH5MAC4ARH5MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAf0wALgBEf0wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQCBTAAvAQANTYFMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAIJMAC4ARIJMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAg0wALgBEg0wAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCETAAuAESETAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAhkwALwEADU2GTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCHTAAuAESHTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAIhMAC4ARIhMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAiUwALgBEiUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAIxMAC8BAA1NjEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAjUwALgBEjUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCOTAAuAESOTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAI9MAC4ARI9MAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAi0wALwA6i0wAAP////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRXcml0ZXJUeXBlSW5zdGFuY2UBAMI7AQDCO8I7AAD/////CAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBkUgAuAERkUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARGF0YVNldEZpZWxkQ29udGVudE1hc2sBAGVSAC4ARGVSAAABAN88/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAABcAAABEYXRhU2V0V3JpdGVyUHJvcGVydGllcwEAVUQALgBEVUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEAxzsALwEAyTvHOwAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAwzsALwEAMznDOwAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQDEOwAvAD/EOwAAAQA3Of////8BAf////8AAAAABGCACgEAAAAAAAsAAABEaWFnbm9zdGljcwEAXkwALwEAAE5eTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAF9MAC8AP19MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAGBMAC8BAA1NYEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAYUwALgBEYUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBiTAAuAERiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBjTAAuAERjTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQBlTAAvAQANTWVMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAGZMAC4ARGZMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAZ0wALgBEZ0wAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAaEwALgBEaEwAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAGpMAC8BAOlMakwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQBrTAAvAD9rTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAGxMAC8AOmxMAAD/////BwAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEAbUwALwEADU1tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBuTAAuAERuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAG9MAC4ARG9MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAcEwALgBEcEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAHJMAC8BAA1NckwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAc0wALgBEc0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB0TAAuAER0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHVMAC4ARHVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQB3TAAvAQANTXdMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAHhMAC4ARHhMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAeUwALgBEeUwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQB6TAAuAER6TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAHxMAC8BAA1NfEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAfUwALgBEfUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB+TAAuAER+TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAH9MAC4ARH9MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAgUwALwEADU2BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCCTAAuAESCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAINMAC4ARINMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAhEwALgBEhEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAIZMAC8BAA1NhkwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAh0wALgBEh0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCITAAuAESITAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAIlMAC4ARIlMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARmFpbGVkRGF0YVNldE1lc3NhZ2VzAQCMTAAvAQANTYxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAI1MAC4ARI1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAjkwALgBEjkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCPTAAuAESPTAAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAItMAC8AOotMAAD/////AAAAAA==";
  private PropertyState<ushort> m_dataSetWriterId;
  private PropertyState<uint> m_dataSetFieldContentMask;
  private PropertyState<uint> m_keyFrameCount;
  private PropertyState<KeyValuePair[]> m_dataSetWriterProperties;
  private DataSetWriterTransportState m_transportSettings;
  private DataSetWriterMessageState m_messageSettings;
  private PubSubStatusState m_status;
  private PubSubDiagnosticsDataSetWriterState m_diagnostics;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15298U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRXcml0ZXJUeXBlSW5zdGFuY2UBAMI7AQDCO8I7AAD/////CAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBkUgAuAERkUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAXAAAARGF0YVNldEZpZWxkQ29udGVudE1hc2sBAGVSAC4ARGVSAAABAN88/////wEB/////wAAAAAVYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAAF2CJCgIAAAAAABcAAABEYXRhU2V0V3JpdGVyUHJvcGVydGllcwEAVUQALgBEVUQAAAEAxTgBAAAAAQAAAAAAAAABAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEAxzsALwEAyTvHOwAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAwzsALwEAMznDOwAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQDEOwAvAD/EOwAAAQA3Of////8BAf////8AAAAABGCACgEAAAAAAAsAAABEaWFnbm9zdGljcwEAXkwALwEAAE5eTAAA/////wcAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAF9MAC8AP19MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAFRvdGFsSW5mb3JtYXRpb24BAGBMAC8BAA1NYEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAYUwALgBEYUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBiTAAuAERiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBjTAAuAERjTAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABUb3RhbEVycm9yAQBlTAAvAQANTWVMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAGZMAC4ARGZMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAZ0wALgBEZ0wAAAEAEk3/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAaEwALgBEaEwAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAGpMAC8BAOlMakwAAAEB/////wAAAAAVYIkKAgAAAAAACAAAAFN1YkVycm9yAQBrTAAvAD9rTAAAAAH/////AQH/////AAAAAARggAoBAAAAAAAIAAAAQ291bnRlcnMBAGxMAC8AOmxMAAD/////BwAAABVgiQoCAAAAAAAKAAAAU3RhdGVFcnJvcgEAbUwALwEADU1tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBuTAAuAERuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAG9MAC4ARG9MAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAcEwALgBEcEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlNZXRob2QBAHJMAC8BAA1NckwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAc0wALgBEc0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB0TAAuAER0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHVMAC4ARHVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAYAAAAU3RhdGVPcGVyYXRpb25hbEJ5UGFyZW50AQB3TAAvAQANTXdMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAHhMAC4ARHhMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAeUwALgBEeUwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQB6TAAuAER6TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGQAAAFN0YXRlT3BlcmF0aW9uYWxGcm9tRXJyb3IBAHxMAC8BAA1NfEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAfUwALgBEfUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB+TAAuAER+TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAH9MAC4ARH9MAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAATAAAAU3RhdGVQYXVzZWRCeVBhcmVudAEAgUwALwEADU2BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCCTAAuAESCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAINMAC4ARINMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAhEwALgBEhEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABTdGF0ZURpc2FibGVkQnlNZXRob2QBAIZMAC8BAA1NhkwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAh0wALgBEh0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCITAAuAESITAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAIlMAC4ARIlMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAVAAAARmFpbGVkRGF0YVNldE1lc3NhZ2VzAQCMTAAvAQANTYxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAI1MAC4ARI1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAjkwALgBEjkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCPTAAuAESPTAAABgAAAAABAAtN/////wEB/////wAAAAAEYIAKAQAAAAAACgAAAExpdmVWYWx1ZXMBAItMAC8AOotMAAD/////AAAAAA==");
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
    if (this.KeyFrameCount != null)
      this.KeyFrameCount.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEtleUZyYW1lQ291bnQBAGZSAC4ARGZSAAAAB/////8BAf////8AAAAA");
    if (this.TransportSettings != null)
      this.TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDHOwAvAQDJO8c7AAD/////AAAAAA==");
    if (this.MessageSettings != null)
      this.MessageSettings.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAZ1IALwEAaFJnUgAA/////wAAAAA=");
    if (this.Diagnostics == null)
      return;
    this.Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQBeTAAvAQAATl5MAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAX0wALwA/X0wAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAYEwALwEADU1gTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBhTAAuAERhTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAGJMAC4ARGJMAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAGNMAC4ARGNMAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAGVMAC8BAA1NZUwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAZkwALgBEZkwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQBnTAAuAERnTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBoTAAuAERoTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAakwALwEA6UxqTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAGtMAC8AP2tMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAbEwALwA6bEwAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQBtTAAvAQANTW1MAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAG5MAC4ARG5MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAb0wALgBEb0wAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQBwTAAuAERwTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAckwALwEADU1yTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQBzTAAuAERzTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAHRMAC4ARHRMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAdUwALgBEdUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAHdMAC8BAA1Nd0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAeEwALgBEeEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQB5TAAuAER5TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAHpMAC4ARHpMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAfEwALwEADU18TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQB9TAAuAER9TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAH5MAC4ARH5MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAf0wALgBEf0wAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQCBTAAvAQANTYFMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAIJMAC4ARIJMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAg0wALgBEg0wAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCETAAuAESETAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAhkwALwEADU2GTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCHTAAuAESHTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAIhMAC4ARIhMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAiUwALgBEiUwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAIxMAC8BAA1NjEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAjUwALgBEjUwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCOTAAuAESOTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAI9MAC4ARI9MAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAi0wALwA6i0wAAP////8AAAAA");
  }

  public PropertyState<ushort> DataSetWriterId
  {
    get => this.m_dataSetWriterId;
    set
    {
      if (this.m_dataSetWriterId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetWriterId = value;
    }
  }

  public PropertyState<uint> DataSetFieldContentMask
  {
    get => this.m_dataSetFieldContentMask;
    set
    {
      if (this.m_dataSetFieldContentMask != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetFieldContentMask = value;
    }
  }

  public PropertyState<uint> KeyFrameCount
  {
    get => this.m_keyFrameCount;
    set
    {
      if (this.m_keyFrameCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_keyFrameCount = value;
    }
  }

  public PropertyState<KeyValuePair[]> DataSetWriterProperties
  {
    get => this.m_dataSetWriterProperties;
    set
    {
      if (this.m_dataSetWriterProperties != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetWriterProperties = value;
    }
  }

  public DataSetWriterTransportState TransportSettings
  {
    get => this.m_transportSettings;
    set
    {
      if (this.m_transportSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportSettings = value;
    }
  }

  public DataSetWriterMessageState MessageSettings
  {
    get => this.m_messageSettings;
    set
    {
      if (this.m_messageSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_messageSettings = value;
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

  public PubSubDiagnosticsDataSetWriterState Diagnostics
  {
    get => this.m_diagnostics;
    set
    {
      if (this.m_diagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnostics = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_dataSetWriterId != null)
      children.Add((BaseInstanceState) this.m_dataSetWriterId);
    if (this.m_dataSetFieldContentMask != null)
      children.Add((BaseInstanceState) this.m_dataSetFieldContentMask);
    if (this.m_keyFrameCount != null)
      children.Add((BaseInstanceState) this.m_keyFrameCount);
    if (this.m_dataSetWriterProperties != null)
      children.Add((BaseInstanceState) this.m_dataSetWriterProperties);
    if (this.m_transportSettings != null)
      children.Add((BaseInstanceState) this.m_transportSettings);
    if (this.m_messageSettings != null)
      children.Add((BaseInstanceState) this.m_messageSettings);
    if (this.m_status != null)
      children.Add((BaseInstanceState) this.m_status);
    if (this.m_diagnostics != null)
      children.Add((BaseInstanceState) this.m_diagnostics);
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
        case 11:
          if (name == "Diagnostics")
          {
            if (createOrReplace && this.Diagnostics == null)
              this.Diagnostics = replacement != null ? (PubSubDiagnosticsDataSetWriterState) replacement : new PubSubDiagnosticsDataSetWriterState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Diagnostics;
            break;
          }
          break;
        case 13:
          if (name == "KeyFrameCount")
          {
            if (createOrReplace && this.KeyFrameCount == null)
              this.KeyFrameCount = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.KeyFrameCount;
            break;
          }
          break;
        case 15:
          switch (name[0])
          {
            case 'D':
              if (name == "DataSetWriterId")
              {
                if (createOrReplace && this.DataSetWriterId == null)
                  this.DataSetWriterId = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetWriterId;
                break;
              }
              break;
            case 'M':
              if (name == "MessageSettings")
              {
                if (createOrReplace && this.MessageSettings == null)
                  this.MessageSettings = replacement != null ? (DataSetWriterMessageState) replacement : new DataSetWriterMessageState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MessageSettings;
                break;
              }
              break;
          }
          break;
        case 17:
          if (name == "TransportSettings")
          {
            if (createOrReplace && this.TransportSettings == null)
              this.TransportSettings = replacement != null ? (DataSetWriterTransportState) replacement : new DataSetWriterTransportState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TransportSettings;
            break;
          }
          break;
        case 23:
          switch (name[7])
          {
            case 'F':
              if (name == "DataSetFieldContentMask")
              {
                if (createOrReplace && this.DataSetFieldContentMask == null)
                  this.DataSetFieldContentMask = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetFieldContentMask;
                break;
              }
              break;
            case 'W':
              if (name == "DataSetWriterProperties")
              {
                if (createOrReplace && this.DataSetWriterProperties == null)
                  this.DataSetWriterProperties = replacement != null ? (PropertyState<KeyValuePair[]>) replacement : new PropertyState<KeyValuePair[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetWriterProperties;
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
