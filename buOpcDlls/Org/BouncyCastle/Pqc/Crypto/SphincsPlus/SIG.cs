// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class SIG
{
  private byte[] r;
  private Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_FORS[] sig_fors;
  private SIG_XMSS[] sig_ht;

  public SIG(int n, int k, int a, uint d, uint hPrime, int wots_len, byte[] signature)
  {
    this.r = new byte[n];
    Array.Copy((Array) signature, 0, (Array) this.r, 0, n);
    this.sig_fors = new Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_FORS[k];
    int sourceIndex = n;
    for (int index1 = 0; index1 != k; ++index1)
    {
      byte[] numArray = new byte[n];
      Array.Copy((Array) signature, sourceIndex, (Array) numArray, 0, n);
      sourceIndex += n;
      byte[][] authPath = new byte[a][];
      for (int index2 = 0; index2 != a; ++index2)
      {
        authPath[index2] = new byte[n];
        Array.Copy((Array) signature, sourceIndex, (Array) authPath[index2], 0, n);
        sourceIndex += n;
      }
      this.sig_fors[index1] = new Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_FORS(numArray, authPath);
    }
    this.sig_ht = new SIG_XMSS[(int) d];
    for (int index3 = 0; (long) index3 != (long) d; ++index3)
    {
      byte[] numArray = new byte[wots_len * n];
      Array.Copy((Array) signature, sourceIndex, (Array) numArray, 0, numArray.Length);
      sourceIndex += numArray.Length;
      byte[][] auth = new byte[(int) hPrime][];
      for (int index4 = 0; (long) index4 != (long) hPrime; ++index4)
      {
        auth[index4] = new byte[n];
        Array.Copy((Array) signature, sourceIndex, (Array) auth[index4], 0, n);
        sourceIndex += n;
      }
      this.sig_ht[index3] = new SIG_XMSS(numArray, auth);
    }
    if (sourceIndex != signature.Length)
      throw new ArgumentException("signature wrong length");
  }

  public byte[] R => this.r;

  public Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_FORS[] SIG_FORS => this.sig_fors;

  public SIG_XMSS[] SIG_HT => this.sig_ht;
}
