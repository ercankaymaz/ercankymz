// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.GenericKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

public class GenericKey
{
  private readonly AlgorithmIdentifier algorithmIdentifier;
  private readonly object representation;

  public GenericKey(object representation)
  {
    this.algorithmIdentifier = (AlgorithmIdentifier) null;
    this.representation = representation;
  }

  public GenericKey(AlgorithmIdentifier algorithmIdentifier, byte[] representation)
  {
    this.algorithmIdentifier = algorithmIdentifier;
    this.representation = (object) representation;
  }

  public GenericKey(AlgorithmIdentifier algorithmIdentifier, object representation)
  {
    this.algorithmIdentifier = algorithmIdentifier;
    this.representation = representation;
  }

  public AlgorithmIdentifier AlgorithmIdentifier => this.algorithmIdentifier;

  public object Representation => this.representation;
}
