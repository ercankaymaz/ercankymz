// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.HT
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class HT
{
  private byte[] skSeed;
  private byte[] pkSeed;
  private SphincsPlusEngine engine;
  private WotsPlus wots;
  internal byte[] HTPubKey;

  internal HT(SphincsPlusEngine engine, byte[] skSeed, byte[] pkSeed)
  {
    this.skSeed = skSeed;
    this.pkSeed = pkSeed;
    this.engine = engine;
    this.wots = new WotsPlus(engine);
    Adrs adrs = new Adrs();
    adrs.SetLayerAddress(engine.D - 1U);
    adrs.SetTreeAddress(0UL);
    if (skSeed != null)
      this.HTPubKey = this.xmss_PKgen(skSeed, pkSeed, adrs);
    else
      this.HTPubKey = (byte[]) null;
  }

  internal byte[] Sign(byte[] M, ulong idx_tree, uint idx_leaf)
  {
    Adrs paramAdrs = new Adrs();
    paramAdrs.SetLayerAddress(0U);
    paramAdrs.SetTreeAddress(idx_tree);
    SIG_XMSS sig_xmss1 = this.xmss_sign(M, this.skSeed, idx_leaf, this.pkSeed, paramAdrs);
    SIG_XMSS[] sigXmssArray = new SIG_XMSS[(int) this.engine.D];
    sigXmssArray[0] = sig_xmss1;
    paramAdrs.SetLayerAddress(0U);
    paramAdrs.SetTreeAddress(idx_tree);
    byte[] M1 = this.xmss_pkFromSig(idx_leaf, sig_xmss1, M, this.pkSeed, paramAdrs);
    for (uint layer = 1; layer < this.engine.D; ++layer)
    {
      idx_leaf = (uint) (idx_tree & (ulong) ((1 << (int) this.engine.H_PRIME) - 1));
      idx_tree >>= (int) this.engine.H_PRIME;
      paramAdrs.SetLayerAddress(layer);
      paramAdrs.SetTreeAddress(idx_tree);
      SIG_XMSS sig_xmss2 = this.xmss_sign(M1, this.skSeed, idx_leaf, this.pkSeed, paramAdrs);
      sigXmssArray[(int) layer] = sig_xmss2;
      if (layer < this.engine.D - 1U)
        M1 = this.xmss_pkFromSig(idx_leaf, sig_xmss2, M1, this.pkSeed, paramAdrs);
    }
    byte[][] numArray = new byte[sigXmssArray.Length][];
    for (int index = 0; index != numArray.Length; ++index)
      numArray[index] = Arrays.Concatenate(sigXmssArray[index].sig, Arrays.ConcatenateAll(sigXmssArray[index].auth));
    return Arrays.ConcatenateAll(numArray);
  }

  private byte[] xmss_PKgen(byte[] skSeed, byte[] pkSeed, Adrs adrs)
  {
    return this.TreeHash(skSeed, 0U, this.engine.H_PRIME, pkSeed, adrs);
  }

  private byte[] xmss_pkFromSig(
    uint idx,
    SIG_XMSS sig_xmss,
    byte[] M,
    byte[] pkSeed,
    Adrs paramAdrs)
  {
    Adrs adrs = new Adrs(paramAdrs);
    adrs.SetAdrsType(Adrs.WOTS_HASH);
    adrs.SetKeyPairAddress(idx);
    byte[] wotsSig = sig_xmss.WotsSig;
    byte[][] xmssAuth = sig_xmss.XmssAuth;
    byte[] numArray = new byte[this.engine.N];
    this.wots.PKFromSig(wotsSig, M, pkSeed, adrs, numArray);
    adrs.SetAdrsType(Adrs.TREE);
    adrs.SetTreeIndex(idx);
    for (uint index = 0; index < this.engine.H_PRIME; ++index)
    {
      adrs.SetTreeHeight(index + 1U);
      if ((long) idx / (long) (1 << (int) index) % 2L == 0L)
      {
        adrs.SetTreeIndex(adrs.GetTreeIndex() / 2U);
        this.engine.H(pkSeed, adrs, numArray, xmssAuth[(int) index], numArray);
      }
      else
      {
        adrs.SetTreeIndex((adrs.GetTreeIndex() - 1U) / 2U);
        this.engine.H(pkSeed, adrs, xmssAuth[(int) index], numArray, numArray);
      }
    }
    return numArray;
  }

  private SIG_XMSS xmss_sign(byte[] M, byte[] skSeed, uint idx, byte[] pkSeed, Adrs paramAdrs)
  {
    byte[][] auth = new byte[(int) this.engine.H_PRIME][];
    Adrs adrsParam = new Adrs(paramAdrs);
    adrsParam.SetAdrsType(Adrs.TREE);
    adrsParam.SetLayerAddress(paramAdrs.GetLayerAddress());
    adrsParam.SetTreeAddress(paramAdrs.GetTreeAddress());
    for (int z = 0; (long) z < (long) this.engine.H_PRIME; ++z)
    {
      uint num = (uint) ((ulong) idx / (ulong) (1 << z)) ^ 1U;
      auth[z] = this.TreeHash(skSeed, num * (uint) (1 << z), (uint) z, pkSeed, adrsParam);
    }
    Adrs paramAdrs1 = new Adrs(paramAdrs);
    paramAdrs1.SetAdrsType(Adrs.WOTS_PK);
    paramAdrs1.SetKeyPairAddress(idx);
    return new SIG_XMSS(this.wots.Sign(M, skSeed, pkSeed, paramAdrs1), auth);
  }

  private byte[] TreeHash(byte[] skSeed, uint s, uint z, byte[] pkSeed, Adrs adrsParam)
  {
    if ((long) s % (long) (1 << (int) z) != 0L)
      return (byte[]) null;
    Stack<NodeEntry> nodeEntryStack = new Stack<NodeEntry>();
    Adrs adrs = new Adrs(adrsParam);
    for (uint index1 = 0; (long) index1 < (long) (1 << (int) z); ++index1)
    {
      adrs.SetAdrsType(Adrs.WOTS_HASH);
      adrs.SetKeyPairAddress(s + index1);
      byte[] numArray = new byte[this.engine.N];
      this.wots.PKGen(skSeed, pkSeed, adrs, numArray);
      adrs.SetAdrsType(Adrs.TREE);
      adrs.SetTreeHeight(1U);
      adrs.SetTreeIndex(s + index1);
      uint nodeHeight = 1;
      uint index2 = s + index1;
      for (; nodeEntryStack.Count > 0 && (int) nodeEntryStack.Peek().nodeHeight == (int) nodeHeight; adrs.SetTreeHeight(++nodeHeight))
      {
        index2 = (index2 - 1U) / 2U;
        adrs.SetTreeIndex(index2);
        this.engine.H(pkSeed, adrs, nodeEntryStack.Pop().nodeValue, numArray, numArray);
      }
      nodeEntryStack.Push(new NodeEntry(numArray, nodeHeight));
    }
    return nodeEntryStack.Peek().nodeValue;
  }

  internal bool Verify(
    byte[] M,
    SIG_XMSS[] sig_ht,
    byte[] pkSeed,
    ulong idx_tree,
    uint idx_leaf,
    byte[] PK_HT)
  {
    Adrs paramAdrs = new Adrs();
    SIG_XMSS sig_xmss1 = sig_ht[0];
    paramAdrs.SetLayerAddress(0U);
    paramAdrs.SetTreeAddress(idx_tree);
    byte[] numArray = this.xmss_pkFromSig(idx_leaf, sig_xmss1, M, pkSeed, paramAdrs);
    for (uint layer = 1; layer < this.engine.D; ++layer)
    {
      idx_leaf = (uint) (idx_tree & (ulong) ((1 << (int) this.engine.H_PRIME) - 1));
      idx_tree >>= (int) this.engine.H_PRIME;
      SIG_XMSS sig_xmss2 = sig_ht[(int) layer];
      paramAdrs.SetLayerAddress(layer);
      paramAdrs.SetTreeAddress(idx_tree);
      numArray = this.xmss_pkFromSig(idx_leaf, sig_xmss2, numArray, pkSeed, paramAdrs);
    }
    return Arrays.AreEqual(PK_HT, numArray);
  }
}
