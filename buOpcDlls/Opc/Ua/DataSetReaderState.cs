// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetReaderState
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
public class DataSetReaderState(NodeState parent) : BaseObjectState(parent)
{
  private const string SecurityMode_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPD4ALgBEPD4AAAEALgH/////AQH/////AAAAAA==";
  private const string SecurityGroupId_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEAPT4ALgBEPT4AAAAM/////wEB/////wAAAAA=";
  private const string SecurityKeyServices_InitializationString = "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBAD4+AC4ARD4+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAA==";
  private const string MessageSettings_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAb1IALwEAcFJvUgAA/////wAAAAA=";
  private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAA";
  private const string CreateTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string CreateDataSetMirror_InitializationString = "//////////8EYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRSZWFkZXJUeXBlSW5zdGFuY2UBAMo7AQDKO8o7AAD/////EwAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAGlSAC4ARGlSAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBqUgAuAERqUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBrUgAuAERrUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQBsUgAuAERsUgAAAQC7OP////8BAf////8AAAAAFWCJCgIAAAAAABcAAABEYXRhU2V0RmllbGRDb250ZW50TWFzawEAbVIALgBEbVIAAAEA3zz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWVzc2FnZVJlY2VpdmVUaW1lb3V0AQBuUgAuAERuUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZXlGcmFtZUNvdW50AQCbRAAuAESbRAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAPAAAASGVhZGVyTGF5b3V0VXJpAQCcRAAuAEScRAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQA8PgAuAEQ8PgAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABTZWN1cml0eUdyb3VwSWQBAD0+AC4ARD0+AAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABTZWN1cml0eUtleVNlcnZpY2VzAQA+PgAuAEQ+PgAAAQA4AQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFwAAAERhdGFTZXRSZWFkZXJQcm9wZXJ0aWVzAQBWRAAuAERWRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAARggAoBAAAAAAAPAAAATWVzc2FnZVNldHRpbmdzAQBvUgAvAQBwUm9SAAD/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQDLOwAvAQAzOcs7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMw7AC8AP8w7AAABADc5/////wEB/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAABGCACgEAAAAAABEAAABTdWJzY3JpYmVkRGF0YVNldAEA1DsALwEABDvUOwAA/////wAAAAAEYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState m_publisherId;
  private PropertyState<ushort> m_writerGroupId;
  private PropertyState<ushort> m_dataSetWriterId;
  private PropertyState<DataSetMetaDataType> m_dataSetMetaData;
  private PropertyState<uint> m_dataSetFieldContentMask;
  private PropertyState<double> m_messageReceiveTimeout;
  private PropertyState<uint> m_keyFrameCount;
  private PropertyState<string> m_headerLayoutUri;
  private PropertyState<MessageSecurityMode> m_securityMode;
  private PropertyState<string> m_securityGroupId;
  private PropertyState<EndpointDescription[]> m_securityKeyServices;
  private PropertyState<KeyValuePair[]> m_dataSetReaderProperties;
  private DataSetReaderTransportState m_transportSettings;
  private DataSetReaderMessageState m_messageSettings;
  private PubSubStatusState m_status;
  private PubSubDiagnosticsDataSetReaderState m_diagnostics;
  private SubscribedDataSetState m_subscribedDataSet;
  private DataSetReaderTypeCreateTargetVariablesMethodState m_createTargetVariablesMethod;
  private DataSetReaderTypeCreateDataSetMirrorMethodState m_createDataSetMirrorMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15306U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGQAAAERhdGFTZXRSZWFkZXJUeXBlSW5zdGFuY2UBAMo7AQDKO8o7AAD/////EwAAABVgiQoCAAAAAAALAAAAUHVibGlzaGVySWQBAGlSAC4ARGlSAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBqUgAuAERqUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldFdyaXRlcklkAQBrUgAuAERrUgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQBsUgAuAERsUgAAAQC7OP////8BAf////8AAAAAFWCJCgIAAAAAABcAAABEYXRhU2V0RmllbGRDb250ZW50TWFzawEAbVIALgBEbVIAAAEA3zz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWVzc2FnZVJlY2VpdmVUaW1lb3V0AQBuUgAuAERuUgAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZXlGcmFtZUNvdW50AQCbRAAuAESbRAAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAPAAAASGVhZGVyTGF5b3V0VXJpAQCcRAAuAEScRAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAU2VjdXJpdHlNb2RlAQA8PgAuAEQ8PgAAAQAuAf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABTZWN1cml0eUdyb3VwSWQBAD0+AC4ARD0+AAAADP////8BAf////8AAAAAF2CJCgIAAAAAABMAAABTZWN1cml0eUtleVNlcnZpY2VzAQA+PgAuAEQ+PgAAAQA4AQEAAAABAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAFwAAAERhdGFTZXRSZWFkZXJQcm9wZXJ0aWVzAQBWRAAuAERWRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAARggAoBAAAAAAAPAAAATWVzc2FnZVNldHRpbmdzAQBvUgAvAQBwUm9SAAD/////AAAAAARggAoBAAAAAAAGAAAAU3RhdHVzAQDLOwAvAQAzOcs7AAD/////AQAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMw7AC8AP8w7AAABADc5/////wEB/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAABGCACgEAAAAAABEAAABTdWJzY3JpYmVkRGF0YVNldAEA1DsALwEABDvUOwAA/////wAAAAAEYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
    if (this.SecurityMode != null)
      this.SecurityMode.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPD4ALgBEPD4AAAEALgH/////AQH/////AAAAAA==");
    if (this.SecurityGroupId != null)
      this.SecurityGroupId.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFNlY3VyaXR5R3JvdXBJZAEAPT4ALgBEPT4AAAAM/////wEB/////wAAAAA=");
    if (this.SecurityKeyServices != null)
      this.SecurityKeyServices.Initialize(context, "//////////8XYIkKAgAAAAAAEwAAAFNlY3VyaXR5S2V5U2VydmljZXMBAD4+AC4ARD4+AAABADgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.TransportSettings != null)
      this.TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQDPOwAvAQDXO887AAD/////AAAAAA==");
    if (this.MessageSettings != null)
      this.MessageSettings.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEAb1IALwEAcFJvUgAA/////wAAAAA=");
    if (this.Diagnostics != null)
      this.Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCZTAAvAQA7TplMAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAmkwALwA/mkwAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAm0wALwEADU2bTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCcTAAuAEScTAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJ1MAC4ARJ1MAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJ5MAC4ARJ5MAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAKBMAC8BAA1NoEwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAoUwALgBEoUwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCiTAAuAESiTAAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCjTAAuAESjTAAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEApUwALwEA6UylTAAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKZMAC8AP6ZMAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAp0wALwA6p0wAAP////8HAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCoTAAvAQANTahMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKlMAC4ARKlMAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAqkwALgBEqkwAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCrTAAuAESrTAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEArUwALwEADU2tTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCuTAAuAESuTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAK9MAC4ARK9MAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAsEwALgBEsEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBALJMAC8BAA1NskwAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAs0wALgBEs0wAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQC0TAAuAES0TAAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALVMAC4ARLVMAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAt0wALwEADU23TAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC4TAAuAES4TAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALlMAC4ARLlMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAukwALgBEukwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC8TAAvAQANTbxMAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAL1MAC4ARL1MAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAvkwALgBEvkwAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC/TAAuAES/TAAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAwUwALwEADU3BTAAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDCTAAuAETCTAAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAMNMAC4ARMNMAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAxEwALgBExEwAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABUAAABGYWlsZWREYXRhU2V0TWVzc2FnZXMBAMdMAC8BAA1Nx0wAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAyEwALgBEyEwAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDJTAAuAETJTAAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAMpMAC4ARMpMAAAGAAAAAAEAC03/////AQH/////AAAAAARggAoBAAAAAAAKAAAATGl2ZVZhbHVlcwEAxkwALwA6xkwAAP////8AAAAA");
    if (this.CreateTargetVariables != null)
      this.CreateTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAENyZWF0ZVRhcmdldFZhcmlhYmxlcwEA6kMALwEA6kPqQwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAOtDAC4AROtDAACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAOxDAC4AROxDAACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.CreateDataSetMirror == null)
      return;
    this.CreateDataSetMirror.Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAENyZWF0ZURhdGFTZXRNaXJyb3IBAO1DAC8BAO1D7UMAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDuQwAuAETuQwAAlgIAAAABACoBAR0AAAAOAAAAUGFyZW50Tm9kZU5hbWUADP////8AAAAAAAEAKgEBIgAAAA8AAABSb2xlUGVybWlzc2lvbnMAYAEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQDvQwAuAETvQwAAlgEAAAABACoBARsAAAAMAAAAUGFyZW50Tm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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

  public PropertyState<ushort> WriterGroupId
  {
    get => this.m_writerGroupId;
    set
    {
      if (this.m_writerGroupId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_writerGroupId = value;
    }
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

  public PropertyState<DataSetMetaDataType> DataSetMetaData
  {
    get => this.m_dataSetMetaData;
    set
    {
      if (this.m_dataSetMetaData != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetMetaData = value;
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

  public PropertyState<double> MessageReceiveTimeout
  {
    get => this.m_messageReceiveTimeout;
    set
    {
      if (this.m_messageReceiveTimeout != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_messageReceiveTimeout = value;
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

  public PropertyState<string> HeaderLayoutUri
  {
    get => this.m_headerLayoutUri;
    set
    {
      if (this.m_headerLayoutUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_headerLayoutUri = value;
    }
  }

  public PropertyState<MessageSecurityMode> SecurityMode
  {
    get => this.m_securityMode;
    set
    {
      if (this.m_securityMode != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityMode = value;
    }
  }

  public PropertyState<string> SecurityGroupId
  {
    get => this.m_securityGroupId;
    set
    {
      if (this.m_securityGroupId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityGroupId = value;
    }
  }

  public PropertyState<EndpointDescription[]> SecurityKeyServices
  {
    get => this.m_securityKeyServices;
    set
    {
      if (this.m_securityKeyServices != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityKeyServices = value;
    }
  }

  public PropertyState<KeyValuePair[]> DataSetReaderProperties
  {
    get => this.m_dataSetReaderProperties;
    set
    {
      if (this.m_dataSetReaderProperties != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_dataSetReaderProperties = value;
    }
  }

  public DataSetReaderTransportState TransportSettings
  {
    get => this.m_transportSettings;
    set
    {
      if (this.m_transportSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportSettings = value;
    }
  }

  public DataSetReaderMessageState MessageSettings
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

  public PubSubDiagnosticsDataSetReaderState Diagnostics
  {
    get => this.m_diagnostics;
    set
    {
      if (this.m_diagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnostics = value;
    }
  }

  public SubscribedDataSetState SubscribedDataSet
  {
    get => this.m_subscribedDataSet;
    set
    {
      if (this.m_subscribedDataSet != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_subscribedDataSet = value;
    }
  }

  public DataSetReaderTypeCreateTargetVariablesMethodState CreateTargetVariables
  {
    get => this.m_createTargetVariablesMethod;
    set
    {
      if (this.m_createTargetVariablesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createTargetVariablesMethod = value;
    }
  }

  public DataSetReaderTypeCreateDataSetMirrorMethodState CreateDataSetMirror
  {
    get => this.m_createDataSetMirrorMethod;
    set
    {
      if (this.m_createDataSetMirrorMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createDataSetMirrorMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_publisherId != null)
      children.Add((BaseInstanceState) this.m_publisherId);
    if (this.m_writerGroupId != null)
      children.Add((BaseInstanceState) this.m_writerGroupId);
    if (this.m_dataSetWriterId != null)
      children.Add((BaseInstanceState) this.m_dataSetWriterId);
    if (this.m_dataSetMetaData != null)
      children.Add((BaseInstanceState) this.m_dataSetMetaData);
    if (this.m_dataSetFieldContentMask != null)
      children.Add((BaseInstanceState) this.m_dataSetFieldContentMask);
    if (this.m_messageReceiveTimeout != null)
      children.Add((BaseInstanceState) this.m_messageReceiveTimeout);
    if (this.m_keyFrameCount != null)
      children.Add((BaseInstanceState) this.m_keyFrameCount);
    if (this.m_headerLayoutUri != null)
      children.Add((BaseInstanceState) this.m_headerLayoutUri);
    if (this.m_securityMode != null)
      children.Add((BaseInstanceState) this.m_securityMode);
    if (this.m_securityGroupId != null)
      children.Add((BaseInstanceState) this.m_securityGroupId);
    if (this.m_securityKeyServices != null)
      children.Add((BaseInstanceState) this.m_securityKeyServices);
    if (this.m_dataSetReaderProperties != null)
      children.Add((BaseInstanceState) this.m_dataSetReaderProperties);
    if (this.m_transportSettings != null)
      children.Add((BaseInstanceState) this.m_transportSettings);
    if (this.m_messageSettings != null)
      children.Add((BaseInstanceState) this.m_messageSettings);
    if (this.m_status != null)
      children.Add((BaseInstanceState) this.m_status);
    if (this.m_diagnostics != null)
      children.Add((BaseInstanceState) this.m_diagnostics);
    if (this.m_subscribedDataSet != null)
      children.Add((BaseInstanceState) this.m_subscribedDataSet);
    if (this.m_createTargetVariablesMethod != null)
      children.Add((BaseInstanceState) this.m_createTargetVariablesMethod);
    if (this.m_createDataSetMirrorMethod != null)
      children.Add((BaseInstanceState) this.m_createDataSetMirrorMethod);
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
          switch (name[0])
          {
            case 'D':
              if (name == "Diagnostics")
              {
                if (createOrReplace && this.Diagnostics == null)
                  this.Diagnostics = replacement != null ? (PubSubDiagnosticsDataSetReaderState) replacement : new PubSubDiagnosticsDataSetReaderState((NodeState) this);
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
          }
          break;
        case 12:
          if (name == "SecurityMode")
          {
            if (createOrReplace && this.SecurityMode == null)
              this.SecurityMode = replacement != null ? (PropertyState<MessageSecurityMode>) replacement : new PropertyState<MessageSecurityMode>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SecurityMode;
            break;
          }
          break;
        case 13:
          switch (name[0])
          {
            case 'K':
              if (name == "KeyFrameCount")
              {
                if (createOrReplace && this.KeyFrameCount == null)
                  this.KeyFrameCount = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.KeyFrameCount;
                break;
              }
              break;
            case 'W':
              if (name == "WriterGroupId")
              {
                if (createOrReplace && this.WriterGroupId == null)
                  this.WriterGroupId = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.WriterGroupId;
                break;
              }
              break;
          }
          break;
        case 15:
          switch (name[7])
          {
            case 'M':
              if (name == "DataSetMetaData")
              {
                if (createOrReplace && this.DataSetMetaData == null)
                  this.DataSetMetaData = replacement != null ? (PropertyState<DataSetMetaDataType>) replacement : new PropertyState<DataSetMetaDataType>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetMetaData;
                break;
              }
              break;
            case 'S':
              if (name == "MessageSettings")
              {
                if (createOrReplace && this.MessageSettings == null)
                  this.MessageSettings = replacement != null ? (DataSetReaderMessageState) replacement : new DataSetReaderMessageState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MessageSettings;
                break;
              }
              break;
            case 'W':
              if (name == "DataSetWriterId")
              {
                if (createOrReplace && this.DataSetWriterId == null)
                  this.DataSetWriterId = replacement != null ? (PropertyState<ushort>) replacement : new PropertyState<ushort>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetWriterId;
                break;
              }
              break;
            case 'a':
              if (name == "HeaderLayoutUri")
              {
                if (createOrReplace && this.HeaderLayoutUri == null)
                  this.HeaderLayoutUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.HeaderLayoutUri;
                break;
              }
              break;
            case 'y':
              if (name == "SecurityGroupId")
              {
                if (createOrReplace && this.SecurityGroupId == null)
                  this.SecurityGroupId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SecurityGroupId;
                break;
              }
              break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'S':
              if (name == "SubscribedDataSet")
              {
                if (createOrReplace && this.SubscribedDataSet == null)
                  this.SubscribedDataSet = replacement != null ? (SubscribedDataSetState) replacement : new SubscribedDataSetState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SubscribedDataSet;
                break;
              }
              break;
            case 'T':
              if (name == "TransportSettings")
              {
                if (createOrReplace && this.TransportSettings == null)
                  this.TransportSettings = replacement != null ? (DataSetReaderTransportState) replacement : new DataSetReaderTransportState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.TransportSettings;
                break;
              }
              break;
          }
          break;
        case 19:
          switch (name[0])
          {
            case 'C':
              if (name == "CreateDataSetMirror")
              {
                if (createOrReplace && this.CreateDataSetMirror == null)
                  this.CreateDataSetMirror = replacement != null ? (DataSetReaderTypeCreateDataSetMirrorMethodState) replacement : new DataSetReaderTypeCreateDataSetMirrorMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CreateDataSetMirror;
                break;
              }
              break;
            case 'S':
              if (name == "SecurityKeyServices")
              {
                if (createOrReplace && this.SecurityKeyServices == null)
                  this.SecurityKeyServices = replacement != null ? (PropertyState<EndpointDescription[]>) replacement : new PropertyState<EndpointDescription[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.SecurityKeyServices;
                break;
              }
              break;
          }
          break;
        case 21:
          switch (name[0])
          {
            case 'C':
              if (name == "CreateTargetVariables")
              {
                if (createOrReplace && this.CreateTargetVariables == null)
                  this.CreateTargetVariables = replacement != null ? (DataSetReaderTypeCreateTargetVariablesMethodState) replacement : new DataSetReaderTypeCreateTargetVariablesMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CreateTargetVariables;
                break;
              }
              break;
            case 'M':
              if (name == "MessageReceiveTimeout")
              {
                if (createOrReplace && this.MessageReceiveTimeout == null)
                  this.MessageReceiveTimeout = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MessageReceiveTimeout;
                break;
              }
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
            case 'R':
              if (name == "DataSetReaderProperties")
              {
                if (createOrReplace && this.DataSetReaderProperties == null)
                  this.DataSetReaderProperties = replacement != null ? (PropertyState<KeyValuePair[]>) replacement : new PropertyState<KeyValuePair[]>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DataSetReaderProperties;
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
