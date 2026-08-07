// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Type
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal abstract class Asn1Type
{
  internal readonly Type m_platformType;

  internal Asn1Type(Type platformType) => this.m_platformType = platformType;

  internal Type PlatformType => this.m_platformType;

  public sealed override bool Equals(object that) => this == that;

  public sealed override int GetHashCode() => base.GetHashCode();
}
