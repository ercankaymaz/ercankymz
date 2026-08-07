// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.Fors
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class Fors
{
  private readonly SphincsPlusEngine engine;

  internal Fors(SphincsPlusEngine engine) => this.engine = engine;

  internal byte[] TreeHash(byte[] skSeed, uint s, int z, byte[] pkSeed, Adrs adrsParam)
  {
    if ((long) s % (long) (1 << z) != 0L)
      return (byte[]) null;
    Stack<NodeEntry> nodeEntryStack = new Stack<NodeEntry>();
    Adrs adrs = new Adrs(adrsParam);
    byte[] numArray1 = new byte[this.engine.N];
    for (uint index1 = 0; (long) index1 < (long) (1 << z); ++index1)
    {
      adrs.SetAdrsType(Adrs.FORS_PRF);
      adrs.SetKeyPairAddress(adrsParam.GetKeyPairAddress());
      adrs.SetTreeHeight(0U);
      adrs.SetTreeIndex(s + index1);
      this.engine.PRF(pkSeed, skSeed, adrs, numArray1, 0);
      adrs.ChangeAdrsType(Adrs.FORS_TREE);
      byte[] numArray2 = this.engine.F(pkSeed, adrs, numArray1);
      adrs.SetTreeHeight(1U);
      uint nodeHeight = 1;
      uint index2 = s + index1;
      for (; nodeEntryStack.Count > 0 && (int) nodeEntryStack.Peek().nodeHeight == (int) nodeHeight; adrs.SetTreeHeight(++nodeHeight))
      {
        index2 = (index2 - 1U) / 2U;
        adrs.SetTreeIndex(index2);
        this.engine.H(pkSeed, adrs, nodeEntryStack.Pop().nodeValue, numArray2, numArray2);
      }
      nodeEntryStack.Push(new NodeEntry(numArray2, nodeHeight));
    }
    return nodeEntryStack.Peek().nodeValue;
  }

  internal SIG_FORS[] Sign(byte[] md, byte[] skSeed, byte[] pkSeed, Adrs paramAdrs)
  {
    Adrs adrs = new Adrs(paramAdrs);
    SIG_FORS[] sigForsArray = new SIG_FORS[this.engine.K];
    uint t = this.engine.T;
    for (uint fors_tree = 0; (long) fors_tree < (long) this.engine.K; ++fors_tree)
    {
      uint messageIdx = Fors.GetMessageIdx(md, (int) fors_tree, this.engine.A);
      adrs.SetAdrsType(Adrs.FORS_PRF);
      adrs.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
      adrs.SetTreeHeight(0U);
      adrs.SetTreeIndex(fors_tree * t + messageIdx);
      byte[] numArray = new byte[this.engine.N];
      this.engine.PRF(pkSeed, skSeed, adrs, numArray, 0);
      adrs.ChangeAdrsType(Adrs.FORS_TREE);
      byte[][] authPath = new byte[this.engine.A][];
      for (int z = 0; z < this.engine.A; ++z)
      {
        uint num = messageIdx >> z ^ 1U;
        authPath[z] = this.TreeHash(skSeed, (uint) ((int) fors_tree * (int) t + ((int) num << z)), z, pkSeed, adrs);
      }
      sigForsArray[(int) fors_tree] = new SIG_FORS(numArray, authPath);
    }
    return sigForsArray;
  }

  internal byte[] PKFromSig(SIG_FORS[] sig_fors, byte[] message, byte[] pkSeed, Adrs adrs)
  {
    byte[][] numArray1 = new byte[this.engine.K][];
    uint t = this.engine.T;
    for (uint fors_tree = 0; (long) fors_tree < (long) this.engine.K; ++fors_tree)
    {
      uint messageIdx = Fors.GetMessageIdx(message, (int) fors_tree, this.engine.A);
      byte[] sk = sig_fors[(int) fors_tree].SK;
      adrs.SetTreeHeight(0U);
      adrs.SetTreeIndex(fors_tree * t + messageIdx);
      byte[] numArray2 = this.engine.F(pkSeed, adrs, sk);
      byte[][] authPath = sig_fors[(int) fors_tree].AuthPath;
      uint index1 = fors_tree * t + messageIdx;
      for (int index2 = 0; index2 < this.engine.A; ++index2)
      {
        adrs.SetTreeHeight((uint) (index2 + 1));
        if ((messageIdx >> index2) % 2U == 0U)
        {
          index1 /= 2U;
          adrs.SetTreeIndex(index1);
          this.engine.H(pkSeed, adrs, numArray2, authPath[index2], numArray2);
        }
        else
        {
          index1 = (index1 - 1U) / 2U;
          adrs.SetTreeIndex(index1);
          this.engine.H(pkSeed, adrs, authPath[index2], numArray2, numArray2);
        }
      }
      numArray1[(int) fors_tree] = numArray2;
    }
    Adrs adrs1 = new Adrs(adrs);
    adrs1.SetAdrsType(Adrs.FORS_PK);
    adrs1.SetKeyPairAddress(adrs.GetKeyPairAddress());
    byte[] output = new byte[this.engine.N];
    this.engine.T_l(pkSeed, adrs1, Arrays.ConcatenateAll(numArray1), output);
    return output;
  }

  private static uint GetMessageIdx(byte[] msg, int fors_tree, int fors_height)
  {
    int num = fors_tree * fors_height;
    uint messageIdx = 0;
    for (int index = 0; index < fors_height; ++index)
    {
      messageIdx ^= (uint) (((int) ((uint) msg[num >> 3] >> (num & 7)) & 1) << index);
      ++num;
    }
    return messageIdx;
  }
}
