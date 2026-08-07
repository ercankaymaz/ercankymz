// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.IndexedDigest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class IndexedDigest
{
  internal ulong idx_tree;
  internal uint idx_leaf;
  internal byte[] digest;

  internal IndexedDigest(ulong idx_tree, uint idx_leaf, byte[] digest)
  {
    this.idx_tree = idx_tree;
    this.idx_leaf = idx_leaf;
    this.digest = digest;
  }
}
