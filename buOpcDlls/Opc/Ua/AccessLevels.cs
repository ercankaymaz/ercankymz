// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AccessLevels
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class AccessLevels
{
  public const byte None = 0;
  public const byte CurrentRead = 1;
  public const byte CurrentWrite = 2;
  public const byte CurrentReadOrWrite = 3;
  public const byte HistoryRead = 4;
  public const byte HistoryWrite = 8;
  public const byte HistoryReadOrWrite = 12;
  public const byte SemanticChange = 16 /*0x10*/;
  public const byte StatusWrite = 32 /*0x20*/;
  public const byte TimestampWrite = 64 /*0x40*/;
}
