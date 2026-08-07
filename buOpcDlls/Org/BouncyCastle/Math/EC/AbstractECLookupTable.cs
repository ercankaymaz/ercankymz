// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.AbstractECLookupTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class AbstractECLookupTable : ECLookupTable
{
  public abstract ECPoint Lookup(int index);

  public abstract int Size { get; }

  public virtual ECPoint LookupVar(int index) => this.Lookup(index);
}
