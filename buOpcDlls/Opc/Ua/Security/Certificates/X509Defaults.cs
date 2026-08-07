// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Certificates.X509Defaults
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509Defaults
{
  public static readonly ushort RSAKeySize = 2048 /*0x0800*/;
  public static readonly ushort RSAKeySizeMin = 1024 /*0x0400*/;
  public static readonly ushort RSAKeySizeMax = 4096 /*0x1000*/;
  public static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;
  public static readonly ushort LifeTime = 24;
  public static readonly int SerialNumberLengthMin = 10;
  public static readonly int SerialNumberLengthMax = 20;
}
