// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.TcpMessageType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public static class TcpMessageType
{
  public const uint Final = 1174405120 /*0x46000000*/;
  public const uint Intermediate = 1124073472 /*0x43000000*/;
  public const uint Abort = 1090519040 /*0x41000000*/;
  public const uint MessageTypeMask = 16777215 /*0xFFFFFF*/;
  public const uint ChunkTypeMask = 4278190080 /*0xFF000000*/;
  public const uint MessageIntermediate = 1128747853;
  public const uint MessageFinal = 1179079501;
  public const uint Message = 4674381;
  public const uint Open = 5132367;
  public const uint Close = 5196867;
  public const uint Hello = 1179403592;
  public const uint ReverseHello = 1178945618;
  public const uint Acknowledge = 1179337537;
  public const uint Error = 1179800133;

  public static bool IsType(uint actualType, uint expectedType)
  {
    return ((int) actualType & 16777215 /*0xFFFFFF*/) == (int) expectedType;
  }

  public static bool IsFinal(uint messageType)
  {
    return ((int) messageType & -16777216 /*0xFF000000*/) == 1174405120 /*0x46000000*/;
  }

  public static bool IsAbort(uint messageType)
  {
    return ((int) messageType & -16777216 /*0xFF000000*/) == 1090519040 /*0x41000000*/;
  }

  public static bool IsValid(uint messageType)
  {
    if (messageType <= 1179337537U)
    {
      if (messageType == 1178945618U || messageType == 1179337537U)
        goto label_8;
    }
    else if (messageType == 1179403592U || messageType == 1179800133U)
      goto label_8;
    if (((int) messageType & -16777216 /*0xFF000000*/) != 1174405120 /*0x46000000*/ && ((int) messageType & -16777216 /*0xFF000000*/) != 1124073472 /*0x43000000*/)
      return false;
    switch (messageType & 16777215U /*0xFFFFFF*/)
    {
      case 4674381:
      case 5132367:
      case 5196867:
        return true;
      default:
        return false;
    }
label_8:
    return true;
  }
}
