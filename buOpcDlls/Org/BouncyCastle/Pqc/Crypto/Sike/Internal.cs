// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.Internal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal abstract class Internal
{
  protected internal static uint RADIX = 64 /*0x40*/;
  protected internal static uint LOG2RADIX = 6;
  protected internal uint CRYPTO_PUBLICKEYBYTES;
  protected internal int CRYPTO_CIPHERTEXTBYTES;
  protected internal uint CRYPTO_BYTES;
  protected internal uint CRYPTO_SECRETKEYBYTES;
  protected internal uint NWORDS_FIELD;
  protected internal uint PRIME_ZERO_WORDS;
  protected internal uint NBITS_FIELD;
  protected internal uint MAXBITS_FIELD;
  protected uint MAXWORDS_FIELD;
  protected uint NWORDS64_FIELD;
  protected internal uint NBITS_ORDER;
  protected internal uint NWORDS_ORDER;
  protected uint NWORDS64_ORDER;
  protected internal uint MAXBITS_ORDER;
  protected internal uint ALICE;
  protected internal uint BOB;
  protected internal uint OALICE_BITS;
  protected internal uint OBOB_BITS;
  protected internal uint OBOB_EXPON;
  protected internal uint MASK_ALICE;
  protected internal uint MASK_BOB;
  protected uint PARAM_A;
  protected uint PARAM_C;
  protected internal uint MAX_INT_POINTS_ALICE;
  protected internal uint MAX_INT_POINTS_BOB;
  protected internal uint MAX_Alice;
  protected internal uint MAX_Bob;
  protected internal uint MSG_BYTES;
  protected internal uint SECRETKEY_A_BYTES;
  protected internal uint SECRETKEY_B_BYTES;
  protected internal uint FP2_ENCODED_BYTES;
  protected bool COMPRESS;
  protected internal uint MASK2_BOB;
  protected internal uint MASK3_BOB;
  protected internal uint ORDER_A_ENCODED_BYTES;
  protected internal uint ORDER_B_ENCODED_BYTES;
  protected internal uint PARTIALLY_COMPRESSED_CHUNK_CT;
  protected uint COMPRESSED_CHUNK_CT;
  protected uint UNCOMPRESSEDPK_BYTES;
  protected uint TABLE_R_LEN;
  protected internal uint TABLE_V_LEN;
  protected uint TABLE_V3_LEN;
  protected internal uint W_2;
  protected internal uint W_3;
  protected internal uint ELL2_W;
  protected internal uint ELL3_W;
  protected internal uint ELL2_EMODW;
  protected internal uint ELL3_EMODW;
  protected internal uint DLEN_2;
  protected internal uint DLEN_3;
  protected internal uint PLEN_2;
  protected internal uint PLEN_3;
  protected internal ulong[] PRIME;
  protected internal ulong[] PRIMEx2;
  protected internal ulong[] PRIMEx4;
  protected internal ulong[] PRIMEp1;
  protected ulong[] PRIMEx16p;
  protected ulong[] PRIMEp1x64;
  protected internal ulong[] Alice_order;
  protected internal ulong[] Bob_order;
  protected internal ulong[] A_gen;
  protected internal ulong[] B_gen;
  protected internal ulong[] Montgomery_R2;
  protected internal ulong[] Montgomery_one;
  protected internal uint[] strat_Alice;
  protected internal uint[] strat_Bob;
  protected internal ulong[] XQB3;
  protected internal ulong[] A_basis_zero;
  protected ulong[] B_basis_zero;
  protected internal ulong[] B_gen_3_tors;
  protected internal ulong[] g_R_S_im;
  protected ulong[] g_phiR_phiS_re;
  protected ulong[] g_phiR_phiS_im;
  protected ulong[] Montgomery_R;
  protected internal ulong[] Montgomery_RB1;
  protected internal ulong[] Montgomery_RB2;
  protected ulong[] threeinv;
  protected internal uint[] ph2_path;
  protected internal uint[] ph3_path;
  protected ulong[] u_entang;
  protected ulong[] u0_entang;
  protected internal ulong[][] table_r_qr;
  protected internal ulong[][] table_r_qnr;
  protected internal ulong[][] table_v_qr;
  protected internal ulong[][] table_v_qnr;
  protected internal ulong[][][] v_3_torsion;
  protected internal ulong[] T_tate3;
  protected internal ulong[] T_tate2_firststep_P;
  protected internal ulong[] T_tate2_P;
  protected internal ulong[] T_tate2_firststep_Q;
  protected internal ulong[] T_tate2_Q;
  protected internal ulong[] ph2_T;
  protected internal ulong[] ph2_T1;
  protected internal ulong[] ph2_T2;
  protected internal ulong[] ph3_T;
  protected internal ulong[] ph3_T1;
  protected internal ulong[] ph3_T2;

  internal static uint[] ReadIntsFromProperty(
    IDictionary<string, string> props,
    string key,
    uint intSize)
  {
    uint[] numArray = new uint[(int) intSize];
    string prop = props[key];
    uint index = 0;
    char[] chArray = new char[1]{ ',' };
    foreach (string s in prop.Split(chArray))
    {
      numArray[(int) index] = uint.Parse(s);
      ++index;
    }
    return numArray;
  }

  internal static ulong[] ReadFromProperty(
    IDictionary<string, string> props,
    string key,
    uint ulongSize)
  {
    byte[] bs = Hex.Decode(props[key].Replace(",", ""));
    ulong[] numArray = new ulong[(int) ulongSize];
    for (int index = 0; index < bs.Length / 8; ++index)
      numArray[index] = Pack.BE_To_UInt64(bs, index * 8);
    return numArray;
  }

  internal static ulong[][] ReadFromProperty(
    IDictionary<string, string> props,
    string key,
    uint d1Size,
    uint d2Size)
  {
    byte[] bs = Hex.Decode(props[key].Replace(",", ""));
    ulong[][] numArray = new ulong[(int) d1Size][];
    for (int index = 0; (long) index < (long) d1Size; ++index)
      numArray[index] = new ulong[(int) d2Size];
    for (uint index1 = 0; (long) index1 < (long) (bs.Length / 8); ++index1)
    {
      uint index2 = index1 / d2Size;
      uint index3 = index1 % d2Size;
      numArray[(int) index2][(int) index3] = Pack.BE_To_UInt64(bs, (int) index1 * 8);
    }
    return numArray;
  }

  internal static ulong[][][] ReadFromProperty(
    IDictionary<string, string> props,
    string key,
    uint d1Size,
    uint d2Size,
    uint d3Size)
  {
    byte[] bs = Hex.Decode(props[key].Replace(",", ""));
    ulong[][][] numArray = new ulong[(int) d1Size][][];
    for (int index1 = 0; (long) index1 < (long) d1Size; ++index1)
    {
      numArray[index1] = new ulong[(int) d2Size][];
      for (int index2 = 0; (long) index2 < (long) d2Size; ++index2)
        numArray[index1][index2] = new ulong[(int) d3Size];
    }
    for (uint index3 = 0; (long) index3 < (long) (bs.Length / 8); ++index3)
    {
      uint index4 = index3 / (d2Size * d3Size);
      uint index5 = index3 % (d2Size * d3Size) / d3Size;
      uint index6 = index3 % d3Size;
      numArray[(int) index4][(int) index5][(int) index6] = Pack.BE_To_UInt64(bs, (int) index3 * 8);
    }
    return numArray;
  }
}
