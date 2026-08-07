// Decompiled with JetBrains decompiler
// Type: Opc.Ua.WriterGroupState
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
public class WriterGroupState(NodeState parent) : PubSubGroupState(parent)
{
  private const string TransportSettings_InitializationString = "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQBNRQAvAQBNRk1FAAD/////AAAAAA==";
  private const string MessageSettings_InitializationString = "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEATkUALwEATkZORQAA/////wAAAAA=";
  private const string Diagnostics_InitializationString = "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCURQAvAQB6TZRFAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAlUUALwA/lUUAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAlkUALwEADU2WRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCXRQAuAESXRQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJhFAC4ARJhFAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJlFAC4ARJlFAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAJtFAC8BAA1Nm0UAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAnEUALgBEnEUAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCdRQAuAESdRQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCeRQAuAESeRQAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAoEUALwEA6UygRQAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKFFAC8AP6FFAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAokUALwA6okUAAP////8JAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCjRQAvAQANTaNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKRFAC4ARKRFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEApUUALgBEpUUAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCmRQAuAESmRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAqEUALwEADU2oRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCpRQAuAESpRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAKpFAC4ARKpFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAq0UALgBEq0UAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAK1FAC8BAA1NrUUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEArkUALgBErkUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCvRQAuAESvRQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALBFAC4ARLBFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAskUALwEADU2yRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCzRQAuAESzRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALRFAC4ARLRFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAtUUALgBEtUUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC3RQAvAQANTbdFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBALhFAC4ARLhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAuUUALgBEuUUAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC6RQAuAES6RQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAvUUALwEADU29RQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC+RQAuAES+RQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAL9FAC4ARL9FAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAwEUALgBEwEUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTZW50TmV0d29ya01lc3NhZ2VzAQDDRQAvAQANTcNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAMhFAC4ARMhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAz0UALgBEz0UAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDQRQAuAETQRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAEZhaWxlZFRyYW5zbWlzc2lvbnMBANJFAC8BAA1N0kUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA1kUALgBE1kUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDdRQAuAETdRQAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAORFAC4ARORFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5jcnlwdGlvbkVycm9ycwEA7EUALwEADU3sRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtRQAuAETtRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5FAC4ARO5FAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70UALgBE70UAAAYBAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQDCRQAvADrCRQAA/////wIAAAAVYIkKAgAAAAAAGAAAAENvbmZpZ3VyZWREYXRhU2V0V3JpdGVycwEA+UUALwA/+UUAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAABGAC4ARABGAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAT3BlcmF0aW9uYWxEYXRhU2V0V3JpdGVycwEAB0YALwA/B0YAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAA5GAC4ARA5GAAAGAAAAAAEAC03/////AQH/////AAAAAA==";
  private const string AddDataSetWriter_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAEFkZERhdGFTZXRXcml0ZXIBADFGAC8BADFGMUYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQA4RgAuAEQ4RgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEA7Tz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBDRgAuAERDRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string RemoveDataSetWriter_InitializationString = "//////////8EYYIKBAAAAAAAEwAAAFJlbW92ZURhdGFTZXRXcml0ZXIBAEhGAC8BAEhGSEYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBJRgAuAERJRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAFwAAAFdyaXRlckdyb3VwVHlwZUluc3RhbmNlAQA9RQEAPUU9RQAA/////w8AAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPkUALgBEPkUAAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWF4TmV0d29ya01lc3NhZ2VTaXplAQBBRQAuAERBRQAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAR3JvdXBQcm9wZXJ0aWVzAQBRRAAuAERRRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAQkUALwEAMzlCRQAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBDRQAvAD9DRQAAAQA3Of////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBIRQAuAERIRQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQBJRQAuAERJRQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZWVwQWxpdmVUaW1lAQBKRQAuAERKRQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcmlvcml0eQEAS0UALgBES0UAAAAD/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEATEUALgBETEUAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAA8AAABIZWFkZXJMYXlvdXRVcmkBAJdEAC4ARJdEAAAADP////8BAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEATUUALwEATUZNRQAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEATkUALwEATkZORQAA/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCURQAvAQB6TZRFAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAlUUALwA/lUUAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAlkUALwEADU2WRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCXRQAuAESXRQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJhFAC4ARJhFAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJlFAC4ARJlFAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAJtFAC8BAA1Nm0UAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAnEUALgBEnEUAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCdRQAuAESdRQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCeRQAuAESeRQAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAoEUALwEA6UygRQAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKFFAC8AP6FFAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAokUALwA6okUAAP////8JAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCjRQAvAQANTaNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKRFAC4ARKRFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEApUUALgBEpUUAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCmRQAuAESmRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAqEUALwEADU2oRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCpRQAuAESpRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAKpFAC4ARKpFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAq0UALgBEq0UAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAK1FAC8BAA1NrUUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEArkUALgBErkUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCvRQAuAESvRQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALBFAC4ARLBFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAskUALwEADU2yRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCzRQAuAESzRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALRFAC4ARLRFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAtUUALgBEtUUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC3RQAvAQANTbdFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBALhFAC4ARLhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAuUUALgBEuUUAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC6RQAuAES6RQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAvUUALwEADU29RQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC+RQAuAES+RQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAL9FAC4ARL9FAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAwEUALgBEwEUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTZW50TmV0d29ya01lc3NhZ2VzAQDDRQAvAQANTcNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAMhFAC4ARMhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAz0UALgBEz0UAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDQRQAuAETQRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAEZhaWxlZFRyYW5zbWlzc2lvbnMBANJFAC8BAA1N0kUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA1kUALgBE1kUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDdRQAuAETdRQAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAORFAC4ARORFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5jcnlwdGlvbkVycm9ycwEA7EUALwEADU3sRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtRQAuAETtRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5FAC4ARO5FAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70UALgBE70UAAAYBAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQDCRQAvADrCRQAA/////wIAAAAVYIkKAgAAAAAAGAAAAENvbmZpZ3VyZWREYXRhU2V0V3JpdGVycwEA+UUALwA/+UUAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAABGAC4ARABGAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAT3BlcmF0aW9uYWxEYXRhU2V0V3JpdGVycwEAB0YALwA/B0YAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAA5GAC4ARA5GAAAGAAAAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAQAAAAQWRkRGF0YVNldFdyaXRlcgEAMUYALwEAMUYxRgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADhGAC4ARDhGAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQDtPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAENGAC4ARENGAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0V3JpdGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAATAAAAUmVtb3ZlRGF0YVNldFdyaXRlcgEASEYALwEASEZIRgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAElGAC4ARElGAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0V3JpdGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private PropertyState<ushort> m_writerGroupId;
  private PropertyState<double> m_publishingInterval;
  private PropertyState<double> m_keepAliveTime;
  private PropertyState<byte> m_priority;
  private PropertyState<string[]> m_localeIds;
  private PropertyState<string> m_headerLayoutUri;
  private WriterGroupTransportState m_transportSettings;
  private WriterGroupMessageState m_messageSettings;
  private PubSubDiagnosticsWriterGroupState m_diagnostics;
  private PubSubGroupTypeAddWriterMethodState m_addDataSetWriterMethod;
  private PubSubGroupTypeRemoveWriterMethodState m_removeDataSetWriterMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 17725U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFwAAAFdyaXRlckdyb3VwVHlwZUluc3RhbmNlAQA9RQEAPUU9RQAA/////w8AAAAVYIkKAgAAAAAADAAAAFNlY3VyaXR5TW9kZQEAPkUALgBEPkUAAAEALgH/////AQH/////AAAAABVgiQoCAAAAAAAVAAAATWF4TmV0d29ya01lc3NhZ2VTaXplAQBBRQAuAERBRQAAAAf/////AQH/////AAAAABdgiQoCAAAAAAAPAAAAR3JvdXBQcm9wZXJ0aWVzAQBRRAAuAERRRAAAAQDFOAEAAAABAAAAAAAAAAEB/////wAAAAAEYIAKAQAAAAAABgAAAFN0YXR1cwEAQkUALwEAMzlCRQAA/////wEAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBDRQAvAD9DRQAAAQA3Of////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABXcml0ZXJHcm91cElkAQBIRQAuAERIRQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAASAAAAUHVibGlzaGluZ0ludGVydmFsAQBJRQAuAERJRQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABLZWVwQWxpdmVUaW1lAQBKRQAuAERKRQAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcmlvcml0eQEAS0UALgBES0UAAAAD/////wEB/////wAAAAAXYIkKAgAAAAAACQAAAExvY2FsZUlkcwEATEUALgBETEUAAAEAJwEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAA8AAABIZWFkZXJMYXlvdXRVcmkBAJdEAC4ARJdEAAAADP////8BAf////8AAAAABGCACgEAAAAAABEAAABUcmFuc3BvcnRTZXR0aW5ncwEATUUALwEATUZNRQAA/////wAAAAAEYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEATkUALwEATkZORQAA/////wAAAAAEYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCURQAvAQB6TZRFAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAlUUALwA/lUUAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAlkUALwEADU2WRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCXRQAuAESXRQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJhFAC4ARJhFAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJlFAC4ARJlFAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAJtFAC8BAA1Nm0UAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAnEUALgBEnEUAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCdRQAuAESdRQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCeRQAuAESeRQAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAoEUALwEA6UygRQAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKFFAC8AP6FFAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAokUALwA6okUAAP////8JAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCjRQAvAQANTaNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKRFAC4ARKRFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEApUUALgBEpUUAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCmRQAuAESmRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAqEUALwEADU2oRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCpRQAuAESpRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAKpFAC4ARKpFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAq0UALgBEq0UAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAK1FAC8BAA1NrUUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEArkUALgBErkUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCvRQAuAESvRQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALBFAC4ARLBFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAskUALwEADU2yRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCzRQAuAESzRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALRFAC4ARLRFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAtUUALgBEtUUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC3RQAvAQANTbdFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBALhFAC4ARLhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAuUUALgBEuUUAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC6RQAuAES6RQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAvUUALwEADU29RQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC+RQAuAES+RQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAL9FAC4ARL9FAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAwEUALgBEwEUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTZW50TmV0d29ya01lc3NhZ2VzAQDDRQAvAQANTcNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAMhFAC4ARMhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAz0UALgBEz0UAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDQRQAuAETQRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAEZhaWxlZFRyYW5zbWlzc2lvbnMBANJFAC8BAA1N0kUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA1kUALgBE1kUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDdRQAuAETdRQAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAORFAC4ARORFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5jcnlwdGlvbkVycm9ycwEA7EUALwEADU3sRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtRQAuAETtRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5FAC4ARO5FAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70UALgBE70UAAAYBAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQDCRQAvADrCRQAA/////wIAAAAVYIkKAgAAAAAAGAAAAENvbmZpZ3VyZWREYXRhU2V0V3JpdGVycwEA+UUALwA/+UUAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAABGAC4ARABGAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAT3BlcmF0aW9uYWxEYXRhU2V0V3JpdGVycwEAB0YALwA/B0YAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAA5GAC4ARA5GAAAGAAAAAAEAC03/////AQH/////AAAAAARhggoEAAAAAAAQAAAAQWRkRGF0YVNldFdyaXRlcgEAMUYALwEAMUYxRgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADhGAC4ARDhGAACWAQAAAAEAKgEBHgAAAA0AAABDb25maWd1cmF0aW9uAQDtPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAENGAC4ARENGAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0V3JpdGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAATAAAAUmVtb3ZlRGF0YVNldFdyaXRlcgEASEYALwEASEZIRgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAElGAC4ARElGAACWAQAAAAEAKgEBIgAAABMAAABEYXRhU2V0V3JpdGVyTm9kZUlkABH/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
      this.TransportSettings.Initialize(context, "//////////8EYIAKAQAAAAAAEQAAAFRyYW5zcG9ydFNldHRpbmdzAQBNRQAvAQBNRk1FAAD/////AAAAAA==");
    if (this.MessageSettings != null)
      this.MessageSettings.Initialize(context, "//////////8EYIAKAQAAAAAADwAAAE1lc3NhZ2VTZXR0aW5ncwEATkUALwEATkZORQAA/////wAAAAA=");
    if (this.Diagnostics != null)
      this.Diagnostics.Initialize(context, "//////////8EYIAKAQAAAAAACwAAAERpYWdub3N0aWNzAQCURQAvAQB6TZRFAAD/////BwAAABVgiQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAlUUALwA/lUUAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAAVG90YWxJbmZvcm1hdGlvbgEAlkUALwEADU2WRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCXRQAuAESXRQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAJhFAC4ARJhFAAABABJN/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAJlFAC4ARJlFAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRvdGFsRXJyb3IBAJtFAC8BAA1Nm0UAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEAnEUALgBEnEUAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCdRQAuAESdRQAAAQASTf////8BAf////8AAAAAFWCJCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCeRQAuAESeRQAAAQALTf////8BAf////8AAAAABGGCCgQAAAAAAAUAAABSZXNldAEAoEUALwEA6UygRQAAAQH/////AAAAABVgiQoCAAAAAAAIAAAAU3ViRXJyb3IBAKFFAC8AP6FFAAAAAf////8BAf////8AAAAABGCACgEAAAAAAAgAAABDb3VudGVycwEAokUALwA6okUAAP////8JAAAAFWCJCgIAAAAAAAoAAABTdGF0ZUVycm9yAQCjRQAvAQANTaNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAKRFAC4ARKRFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEApUUALgBEpUUAAAYBAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQCmRQAuAESmRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAFN0YXRlT3BlcmF0aW9uYWxCeU1ldGhvZAEAqEUALwEADU2oRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCpRQAuAESpRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAKpFAC4ARKpFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAq0UALgBEq0UAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABgAAABTdGF0ZU9wZXJhdGlvbmFsQnlQYXJlbnQBAK1FAC8BAA1NrUUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEArkUALgBErkUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQCvRQAuAESvRQAABgAAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBALBFAC4ARLBFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAU3RhdGVPcGVyYXRpb25hbEZyb21FcnJvcgEAskUALwEADU2yRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQCzRQAuAESzRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BALRFAC4ARLRFAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAtUUALgBEtUUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTdGF0ZVBhdXNlZEJ5UGFyZW50AQC3RQAvAQANTbdFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBALhFAC4ARLhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAuUUALgBEuUUAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQC6RQAuAES6RQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAFQAAAFN0YXRlRGlzYWJsZWRCeU1ldGhvZAEAvUUALwEADU29RQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQC+RQAuAES+RQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAL9FAC4ARL9FAAAGAAAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEAwEUALgBEwEUAAAYAAAAAAQALTf////8BAf////8AAAAAFWCJCgIAAAAAABMAAABTZW50TmV0d29ya01lc3NhZ2VzAQDDRQAvAQANTcNFAAAAB/////8BAf////8DAAAAFWCJCgIAAAAAAAYAAABBY3RpdmUBAMhFAC4ARMhFAAAAAf////8BAf////8AAAAAFWCpCgIAAAAAAA4AAABDbGFzc2lmaWNhdGlvbgEAz0UALgBEz0UAAAYAAAAAAQASTf////8BAf////8AAAAAFWCpCgIAAAAAABAAAABEaWFnbm9zdGljc0xldmVsAQDQRQAuAETQRQAABgAAAAABAAtN/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAEZhaWxlZFRyYW5zbWlzc2lvbnMBANJFAC8BAA1N0kUAAAAH/////wEB/////wMAAAAVYIkKAgAAAAAABgAAAEFjdGl2ZQEA1kUALgBE1kUAAAAB/////wEB/////wAAAAAVYKkKAgAAAAAADgAAAENsYXNzaWZpY2F0aW9uAQDdRQAuAETdRQAABgEAAAABABJN/////wEB/////wAAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAORFAC4ARORFAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAQAAAARW5jcnlwdGlvbkVycm9ycwEA7EUALwEADU3sRQAAAAf/////AQH/////AwAAABVgiQoCAAAAAAAGAAAAQWN0aXZlAQDtRQAuAETtRQAAAAH/////AQH/////AAAAABVgqQoCAAAAAAAOAAAAQ2xhc3NpZmljYXRpb24BAO5FAC4ARO5FAAAGAQAAAAEAEk3/////AQH/////AAAAABVgqQoCAAAAAAAQAAAARGlhZ25vc3RpY3NMZXZlbAEA70UALgBE70UAAAYBAAAAAQALTf////8BAf////8AAAAABGCACgEAAAAAAAoAAABMaXZlVmFsdWVzAQDCRQAvADrCRQAA/////wIAAAAVYIkKAgAAAAAAGAAAAENvbmZpZ3VyZWREYXRhU2V0V3JpdGVycwEA+UUALwA/+UUAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAABGAC4ARABGAAAGAAAAAAEAC03/////AQH/////AAAAABVgiQoCAAAAAAAZAAAAT3BlcmF0aW9uYWxEYXRhU2V0V3JpdGVycwEAB0YALwA/B0YAAAAF/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAERpYWdub3N0aWNzTGV2ZWwBAA5GAC4ARA5GAAAGAAAAAAEAC03/////AQH/////AAAAAA==");
    if (this.AddDataSetWriter != null)
      this.AddDataSetWriter.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAEFkZERhdGFTZXRXcml0ZXIBADFGAC8BADFGMUYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQA4RgAuAEQ4RgAAlgEAAAABACoBAR4AAAANAAAAQ29uZmlndXJhdGlvbgEA7Tz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQBDRgAuAERDRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.RemoveDataSetWriter == null)
      return;
    this.RemoveDataSetWriter.Initialize(context, "//////////8EYYIKBAAAAAAAEwAAAFJlbW92ZURhdGFTZXRXcml0ZXIBAEhGAC8BAEhGSEYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBJRgAuAERJRgAAlgEAAAABACoBASIAAAATAAAARGF0YVNldFdyaXRlck5vZGVJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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

  public PropertyState<double> PublishingInterval
  {
    get => this.m_publishingInterval;
    set
    {
      if (this.m_publishingInterval != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_publishingInterval = value;
    }
  }

  public PropertyState<double> KeepAliveTime
  {
    get => this.m_keepAliveTime;
    set
    {
      if (this.m_keepAliveTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_keepAliveTime = value;
    }
  }

  public PropertyState<byte> Priority
  {
    get => this.m_priority;
    set
    {
      if (this.m_priority != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priority = value;
    }
  }

  public PropertyState<string[]> LocaleIds
  {
    get => this.m_localeIds;
    set
    {
      if (this.m_localeIds != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_localeIds = value;
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

  public WriterGroupTransportState TransportSettings
  {
    get => this.m_transportSettings;
    set
    {
      if (this.m_transportSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transportSettings = value;
    }
  }

  public WriterGroupMessageState MessageSettings
  {
    get => this.m_messageSettings;
    set
    {
      if (this.m_messageSettings != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_messageSettings = value;
    }
  }

  public PubSubDiagnosticsWriterGroupState Diagnostics
  {
    get => this.m_diagnostics;
    set
    {
      if (this.m_diagnostics != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_diagnostics = value;
    }
  }

  public PubSubGroupTypeAddWriterMethodState AddDataSetWriter
  {
    get => this.m_addDataSetWriterMethod;
    set
    {
      if (this.m_addDataSetWriterMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addDataSetWriterMethod = value;
    }
  }

  public PubSubGroupTypeRemoveWriterMethodState RemoveDataSetWriter
  {
    get => this.m_removeDataSetWriterMethod;
    set
    {
      if (this.m_removeDataSetWriterMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeDataSetWriterMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_writerGroupId != null)
      children.Add((BaseInstanceState) this.m_writerGroupId);
    if (this.m_publishingInterval != null)
      children.Add((BaseInstanceState) this.m_publishingInterval);
    if (this.m_keepAliveTime != null)
      children.Add((BaseInstanceState) this.m_keepAliveTime);
    if (this.m_priority != null)
      children.Add((BaseInstanceState) this.m_priority);
    if (this.m_localeIds != null)
      children.Add((BaseInstanceState) this.m_localeIds);
    if (this.m_headerLayoutUri != null)
      children.Add((BaseInstanceState) this.m_headerLayoutUri);
    if (this.m_transportSettings != null)
      children.Add((BaseInstanceState) this.m_transportSettings);
    if (this.m_messageSettings != null)
      children.Add((BaseInstanceState) this.m_messageSettings);
    if (this.m_diagnostics != null)
      children.Add((BaseInstanceState) this.m_diagnostics);
    if (this.m_addDataSetWriterMethod != null)
      children.Add((BaseInstanceState) this.m_addDataSetWriterMethod);
    if (this.m_removeDataSetWriterMethod != null)
      children.Add((BaseInstanceState) this.m_removeDataSetWriterMethod);
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
          if (name == "Priority")
          {
            if (createOrReplace && this.Priority == null)
              this.Priority = replacement != null ? (PropertyState<byte>) replacement : new PropertyState<byte>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Priority;
            break;
          }
          break;
        case 9:
          if (name == "LocaleIds")
          {
            if (createOrReplace && this.LocaleIds == null)
              this.LocaleIds = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.LocaleIds;
            break;
          }
          break;
        case 11:
          if (name == "Diagnostics")
          {
            if (createOrReplace && this.Diagnostics == null)
              this.Diagnostics = replacement != null ? (PubSubDiagnosticsWriterGroupState) replacement : new PubSubDiagnosticsWriterGroupState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Diagnostics;
            break;
          }
          break;
        case 13:
          switch (name[0])
          {
            case 'K':
              if (name == "KeepAliveTime")
              {
                if (createOrReplace && this.KeepAliveTime == null)
                  this.KeepAliveTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.KeepAliveTime;
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
          switch (name[0])
          {
            case 'H':
              if (name == "HeaderLayoutUri")
              {
                if (createOrReplace && this.HeaderLayoutUri == null)
                  this.HeaderLayoutUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.HeaderLayoutUri;
                break;
              }
              break;
            case 'M':
              if (name == "MessageSettings")
              {
                if (createOrReplace && this.MessageSettings == null)
                  this.MessageSettings = replacement != null ? (WriterGroupMessageState) replacement : new WriterGroupMessageState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.MessageSettings;
                break;
              }
              break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "AddDataSetWriter")
          {
            if (createOrReplace && this.AddDataSetWriter == null)
              this.AddDataSetWriter = replacement != null ? (PubSubGroupTypeAddWriterMethodState) replacement : new PubSubGroupTypeAddWriterMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.AddDataSetWriter;
            break;
          }
          break;
        case 17:
          if (name == "TransportSettings")
          {
            if (createOrReplace && this.TransportSettings == null)
              this.TransportSettings = replacement != null ? (WriterGroupTransportState) replacement : new WriterGroupTransportState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.TransportSettings;
            break;
          }
          break;
        case 18:
          if (name == "PublishingInterval")
          {
            if (createOrReplace && this.PublishingInterval == null)
              this.PublishingInterval = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.PublishingInterval;
            break;
          }
          break;
        case 19:
          if (name == "RemoveDataSetWriter")
          {
            if (createOrReplace && this.RemoveDataSetWriter == null)
              this.RemoveDataSetWriter = replacement != null ? (PubSubGroupTypeRemoveWriterMethodState) replacement : new PubSubGroupTypeRemoveWriterMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RemoveDataSetWriter;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
