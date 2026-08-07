// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Store.X509CertPairStoreSelector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using System;

#nullable disable
namespace Org.BouncyCastle.X509.Store;

public class X509CertPairStoreSelector : ISelector<X509CertificatePair>, ICloneable
{
  private X509CertificatePair certPair;
  private X509CertStoreSelector forwardSelector;
  private X509CertStoreSelector reverseSelector;

  private static X509CertStoreSelector CloneSelector(X509CertStoreSelector s)
  {
    return s != null ? (X509CertStoreSelector) s.Clone() : (X509CertStoreSelector) null;
  }

  public X509CertPairStoreSelector()
  {
  }

  private X509CertPairStoreSelector(X509CertPairStoreSelector o)
  {
    this.certPair = o.CertPair;
    this.forwardSelector = o.ForwardSelector;
    this.reverseSelector = o.ReverseSelector;
  }

  public X509CertificatePair CertPair
  {
    get => this.certPair;
    set => this.certPair = value;
  }

  public X509CertStoreSelector ForwardSelector
  {
    get => X509CertPairStoreSelector.CloneSelector(this.forwardSelector);
    set => this.forwardSelector = X509CertPairStoreSelector.CloneSelector(value);
  }

  public X509CertStoreSelector ReverseSelector
  {
    get => X509CertPairStoreSelector.CloneSelector(this.reverseSelector);
    set => this.reverseSelector = X509CertPairStoreSelector.CloneSelector(value);
  }

  public bool Match(X509CertificatePair pair)
  {
    return pair != null && (this.certPair == null || this.certPair.Equals((object) pair)) && (this.forwardSelector == null || this.forwardSelector.Match(pair.Forward)) && (this.reverseSelector == null || this.reverseSelector.Match(pair.Reverse));
  }

  public object Clone() => (object) new X509CertPairStoreSelector(this);
}
