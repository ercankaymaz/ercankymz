// Decompiled with JetBrains decompiler
// Type: System.Runtime.Versioning.System.Security.Cryptography.Cng3636096.OSPlatformAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Runtime.Versioning;

internal abstract class System\u002ESecurity\u002ECryptography\u002ECng3636096\u002EOSPlatformAttribute : 
  Attribute
{
  private protected System\u002ESecurity\u002ECryptography\u002ECng3636096\u002EOSPlatformAttribute(
    string platformName)
  {
    this.PlatformName = platformName;
  }

  public string PlatformName { get; }
}
