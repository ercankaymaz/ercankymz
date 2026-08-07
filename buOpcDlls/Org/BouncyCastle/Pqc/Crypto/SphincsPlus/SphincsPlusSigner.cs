// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusSigner : IMessageSigner
{
  private SphincsPlusPrivateKeyParameters m_privKey;
  private SphincsPlusPublicKeyParameters m_pubKey;
  private SecureRandom m_random;

  public void Init(bool forSigning, ICipherParameters param)
  {
    if (forSigning)
    {
      this.m_pubKey = (SphincsPlusPublicKeyParameters) null;
      if (param is ParametersWithRandom parametersWithRandom)
      {
        this.m_privKey = (SphincsPlusPrivateKeyParameters) parametersWithRandom.Parameters;
        this.m_random = parametersWithRandom.Random;
      }
      else
      {
        this.m_privKey = (SphincsPlusPrivateKeyParameters) param;
        this.m_random = (SecureRandom) null;
      }
    }
    else
    {
      this.m_pubKey = (SphincsPlusPublicKeyParameters) param;
      this.m_privKey = (SphincsPlusPrivateKeyParameters) null;
      this.m_random = (SecureRandom) null;
    }
  }

  public byte[] GenerateSignature(byte[] message)
  {
    SphincsPlusEngine engine = this.m_privKey.Parameters.GetEngine();
    engine.Init(this.m_privKey.GetPublicSeed());
    byte[] numArray1 = new byte[engine.N];
    if (this.m_random != null)
      this.m_random.NextBytes(numArray1);
    else
      Array.Copy((Array) this.m_privKey.m_pk.seed, 0, (Array) numArray1, 0, numArray1.Length);
    Fors fors = new Fors(engine);
    byte[] prf = engine.PRF_msg(this.m_privKey.m_sk.prf, numArray1, message);
    IndexedDigest indexedDigest = engine.H_msg(prf, this.m_privKey.m_pk.seed, this.m_privKey.m_pk.root, message);
    byte[] digest = indexedDigest.digest;
    ulong idxTree = indexedDigest.idx_tree;
    uint idxLeaf = indexedDigest.idx_leaf;
    Adrs paramAdrs = new Adrs();
    paramAdrs.SetAdrsType(Adrs.FORS_TREE);
    paramAdrs.SetTreeAddress(idxTree);
    paramAdrs.SetKeyPairAddress(idxLeaf);
    SIG_FORS[] sig_fors = fors.Sign(digest, this.m_privKey.m_sk.seed, this.m_privKey.m_pk.seed, paramAdrs);
    Adrs adrs = new Adrs();
    adrs.SetAdrsType(Adrs.FORS_TREE);
    adrs.SetTreeAddress(idxTree);
    adrs.SetKeyPairAddress(idxLeaf);
    byte[] M = fors.PKFromSig(sig_fors, digest, this.m_privKey.m_pk.seed, adrs);
    new Adrs().SetAdrsType(Adrs.TREE);
    byte[] numArray2 = new HT(engine, this.m_privKey.GetSeed(), this.m_privKey.GetPublicSeed()).Sign(M, idxTree, idxLeaf);
    byte[][] numArray3 = new byte[sig_fors.Length + 2][];
    numArray3[0] = prf;
    for (int index = 0; index != sig_fors.Length; ++index)
      numArray3[1 + index] = Arrays.Concatenate(sig_fors[index].sk, Arrays.ConcatenateAll(sig_fors[index].authPath));
    numArray3[numArray3.Length - 1] = numArray2;
    return Arrays.ConcatenateAll(numArray3);
  }

  public bool VerifySignature(byte[] message, byte[] signature)
  {
    SphincsPlusEngine engine = this.m_pubKey.Parameters.GetEngine();
    engine.Init(this.m_pubKey.GetSeed());
    Adrs adrs = new Adrs();
    SIG sig = new SIG(engine.N, engine.K, engine.A, engine.D, engine.H_PRIME, engine.WOTS_LEN, signature);
    byte[] r = sig.R;
    SIG_FORS[] sigFors = sig.SIG_FORS;
    SIG_XMSS[] sigHt = sig.SIG_HT;
    IndexedDigest indexedDigest = engine.H_msg(r, this.m_pubKey.GetSeed(), this.m_pubKey.GetRoot(), message);
    byte[] digest = indexedDigest.digest;
    ulong idxTree = indexedDigest.idx_tree;
    uint idxLeaf = indexedDigest.idx_leaf;
    adrs.SetAdrsType(Adrs.FORS_TREE);
    adrs.SetLayerAddress(0U);
    adrs.SetTreeAddress(idxTree);
    adrs.SetKeyPairAddress(idxLeaf);
    byte[] M = new Fors(engine).PKFromSig(sigFors, digest, this.m_pubKey.GetSeed(), adrs);
    adrs.SetAdrsType(Adrs.TREE);
    adrs.SetLayerAddress(0U);
    adrs.SetTreeAddress(idxTree);
    adrs.SetKeyPairAddress(idxLeaf);
    return new HT(engine, (byte[]) null, this.m_pubKey.GetSeed()).Verify(M, sigHt, this.m_pubKey.GetSeed(), idxTree, idxLeaf, this.m_pubKey.GetRoot());
  }
}
