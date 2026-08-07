// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoMatrixGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public abstract class FrodoMatrixGenerator
{
  private int n;
  private int q;

  public FrodoMatrixGenerator(int n, int q)
  {
    this.n = n;
    this.q = q;
  }

  internal abstract short[] GenMatrix(byte[] seedA);

  internal class Shake128MatrixGenerator(int n, int q) : FrodoMatrixGenerator(n, q)
  {
    internal override short[] GenMatrix(byte[] seedA)
    {
      short[] numArray1 = new short[this.n * this.n];
      byte[] numArray2 = new byte[16 /*0x10*/ * this.n / 8];
      byte[] numArray3 = new byte[2 + seedA.Length];
      Array.Copy((Array) seedA, 0, (Array) numArray3, 2, seedA.Length);
      uint num1 = (uint) (this.q - 1 << 16 /*0x10*/) | (uint) (ushort) (this.q - 1);
      IXof xof = (IXof) new ShakeDigest(128 /*0x80*/);
      for (ushort n = 0; (int) n < this.n; ++n)
      {
        Pack.UInt16_To_LE(n, numArray3);
        xof.BlockUpdate(numArray3, 0, numArray3.Length);
        xof.OutputFinal(numArray2, 0, numArray2.Length);
        for (ushort index = 0; (int) index < this.n; index += (ushort) 8)
        {
          uint num2 = Pack.LE_To_UInt32(numArray2, 2 * (int) index) & num1;
          uint num3 = Pack.LE_To_UInt32(numArray2, 2 * (int) index + 4) & num1;
          uint num4 = Pack.LE_To_UInt32(numArray2, 2 * (int) index + 8) & num1;
          uint num5 = Pack.LE_To_UInt32(numArray2, 2 * (int) index + 12) & num1;
          numArray1[(int) n * this.n + (int) index] = (short) num2;
          numArray1[(int) n * this.n + (int) index + 1] = (short) (num2 >> 16 /*0x10*/);
          numArray1[(int) n * this.n + (int) index + 2] = (short) num3;
          numArray1[(int) n * this.n + (int) index + 3] = (short) (num3 >> 16 /*0x10*/);
          numArray1[(int) n * this.n + (int) index + 4] = (short) num4;
          numArray1[(int) n * this.n + (int) index + 5] = (short) (num4 >> 16 /*0x10*/);
          numArray1[(int) n * this.n + (int) index + 6] = (short) num5;
          numArray1[(int) n * this.n + (int) index + 7] = (short) (num5 >> 16 /*0x10*/);
        }
      }
      return numArray1;
    }
  }

  internal class Aes128MatrixGenerator(int n, int q) : FrodoMatrixGenerator(n, q)
  {
    internal override short[] GenMatrix(byte[] seedA)
    {
      short[] numArray1 = new short[this.n * this.n];
      byte[] numArray2 = new byte[16 /*0x10*/];
      byte[] numArray3 = new byte[16 /*0x10*/];
      uint num1 = (uint) (this.q - 1 << 16 /*0x10*/) | (uint) (ushort) (this.q - 1);
      IBlockCipher engine = AesUtilities.CreateEngine();
      engine.Init(true, (ICipherParameters) new KeyParameter(seedA));
      for (int n1 = 0; n1 < this.n; ++n1)
      {
        Pack.UInt16_To_LE((ushort) n1, numArray2, 0);
        for (int n2 = 0; n2 < this.n; n2 += 8)
        {
          Pack.UInt16_To_LE((ushort) n2, numArray2, 2);
          engine.ProcessBlock(numArray2, 0, numArray3, 0);
          uint num2 = Pack.LE_To_UInt32(numArray3, 0) & num1;
          uint num3 = Pack.LE_To_UInt32(numArray3, 4) & num1;
          uint num4 = Pack.LE_To_UInt32(numArray3, 8) & num1;
          uint num5 = Pack.LE_To_UInt32(numArray3, 12) & num1;
          numArray1[n1 * this.n + n2] = (short) num2;
          numArray1[n1 * this.n + n2 + 1] = (short) (num2 >> 16 /*0x10*/);
          numArray1[n1 * this.n + n2 + 2] = (short) num3;
          numArray1[n1 * this.n + n2 + 3] = (short) (num3 >> 16 /*0x10*/);
          numArray1[n1 * this.n + n2 + 4] = (short) num4;
          numArray1[n1 * this.n + n2 + 5] = (short) (num4 >> 16 /*0x10*/);
          numArray1[n1 * this.n + n2 + 6] = (short) num5;
          numArray1[n1 * this.n + n2 + 7] = (short) (num5 >> 16 /*0x10*/);
        }
      }
      return numArray1;
    }
  }
}
