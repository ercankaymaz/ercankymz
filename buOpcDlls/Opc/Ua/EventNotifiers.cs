// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventNotifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class EventNotifiers
{
  public const byte None = 0;
  public const byte SubscribeToEvents = 1;
  public const byte HistoryRead = 4;
  public const byte HistoryWrite = 8;
}
