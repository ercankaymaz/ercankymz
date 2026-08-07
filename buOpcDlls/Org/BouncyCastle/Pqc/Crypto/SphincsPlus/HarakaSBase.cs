// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.HarakaSBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal abstract class HarakaSBase
{
  private static readonly byte[] RC0 = Hex.DecodeStrict("0684704ce620c00ab2c5fef075817b9d");
  private static readonly byte[] RC1 = Hex.DecodeStrict("8b66b4e188f3a06b640f6ba42f08f717");
  private static readonly byte[] RC2 = Hex.DecodeStrict("3402de2d53f28498cf029d609f029114");
  private static readonly byte[] RC3 = Hex.DecodeStrict("0ed6eae62e7b4f08bbf3bcaffd5b4f79");
  private static readonly byte[] RC4 = Hex.DecodeStrict("cbcfb0cb4872448b79eecd1cbe397044");
  private static readonly byte[] RC5 = Hex.DecodeStrict("7eeacdee6e9032b78d5335ed2b8a057b");
  private static readonly byte[] RC6 = Hex.DecodeStrict("67c28f435e2e7cd0e2412761da4fef1b");
  private static readonly byte[] RC7 = Hex.DecodeStrict("2924d9b0afcacc07675ffde21fc70b3b");
  private static readonly byte[] RC8 = Hex.DecodeStrict("ab4d63f1e6867fe9ecdb8fcab9d465ee");
  private static readonly byte[] RC9 = Hex.DecodeStrict("1c30bf84d4b7cd645b2a404fad037e33");
  private static readonly byte[] RC10 = Hex.DecodeStrict("b2cc0bb9941723bf69028b2e8df69800");
  private static readonly byte[] RC11 = Hex.DecodeStrict("fa0478a6de6f55724aaa9ec85c9d2d8a");
  private static readonly byte[] RC12 = Hex.DecodeStrict("dfb49f2b6b772a120efa4f2e29129fd4");
  private static readonly byte[] RC13 = Hex.DecodeStrict("1ea10344f449a23632d611aebb6a12ee");
  private static readonly byte[] RC14 = Hex.DecodeStrict("af0449884b0500845f9600c99ca8eca6");
  private static readonly byte[] RC15 = Hex.DecodeStrict("21025ed89d199c4f78a2c7e327e593ec");
  private static readonly byte[] RC16 = Hex.DecodeStrict("bf3aaaf8a759c9b7b9282ecd82d40173");
  private static readonly byte[] RC17 = Hex.DecodeStrict("6260700d6186b01737f2efd910307d6b");
  private static readonly byte[] RC18 = Hex.DecodeStrict("5aca45c22130044381c29153f6fc9ac6");
  private static readonly byte[] RC19 = Hex.DecodeStrict("9223973c226b68bb2caf92e836d1943a");
  private static readonly byte[] RC20 = Hex.DecodeStrict("d3bf9238225886eb6cbab958e51071b4");
  private static readonly byte[] RC21 = Hex.DecodeStrict("db863ce5aef0c677933dfddd24e1128d");
  private static readonly byte[] RC22 = Hex.DecodeStrict("bb606268ffeba09c83e48de3cb2212b1");
  private static readonly byte[] RC23 = Hex.DecodeStrict("734bd3dce2e4d19c2db91a4ec72bf77d");
  private static readonly byte[] RC24 = Hex.DecodeStrict("43bb47c361301b434b1415c42cb3924e");
  private static readonly byte[] RC25 = Hex.DecodeStrict("dba775a8e707eff603b231dd16eb6899");
  private static readonly byte[] RC26 = Hex.DecodeStrict("6df3614b3c7559778e5e23027eca472c");
  private static readonly byte[] RC27 = Hex.DecodeStrict("cda75a17d6de7d776d1be5b9b88617f9");
  private static readonly byte[] RC28 = Hex.DecodeStrict("ec6b43f06ba8e9aa9d6c069da946ee5d");
  private static readonly byte[] RC29 = Hex.DecodeStrict("cb1e6950f957332ba25311593bf327c1");
  private static readonly byte[] RC30 = Hex.DecodeStrict("2cee0c7500da619ce4ed0353600ed0d9");
  private static readonly byte[] RC31 = Hex.DecodeStrict("f0b1a5a196e90cab80bbbabc63a4a350");
  private static readonly byte[] RC32 = Hex.DecodeStrict("ae3db1025e962988ab0dde30938dca39");
  private static readonly byte[] RC33 = Hex.DecodeStrict("17bb8f38d554a40b8814f3a82e75b442");
  private static readonly byte[] RC34 = Hex.DecodeStrict("34bb8a5b5f427fd7aeb6b779360a16f6");
  private static readonly byte[] RC35 = Hex.DecodeStrict("26f65241cbe5543843ce5918ffbaafde");
  private static readonly byte[] RC36 = Hex.DecodeStrict("4ce99a54b9f3026aa2ca9cf7839ec978");
  private static readonly byte[] RC37 = Hex.DecodeStrict("ae51a51a1bdff7be40c06e2822901235");
  private static readonly byte[] RC38 = Hex.DecodeStrict("a0c1613cba7ed22bc173bc0f48a659cf");
  private static readonly byte[] RC39 = Hex.DecodeStrict("756acc03022882884ad6bdfde9c59da1");
  private static readonly byte[][] RoundConstants = new byte[40][]
  {
    HarakaSBase.RC0,
    HarakaSBase.RC1,
    HarakaSBase.RC2,
    HarakaSBase.RC3,
    HarakaSBase.RC4,
    HarakaSBase.RC5,
    HarakaSBase.RC6,
    HarakaSBase.RC7,
    HarakaSBase.RC8,
    HarakaSBase.RC9,
    HarakaSBase.RC10,
    HarakaSBase.RC11,
    HarakaSBase.RC12,
    HarakaSBase.RC13,
    HarakaSBase.RC14,
    HarakaSBase.RC15,
    HarakaSBase.RC16,
    HarakaSBase.RC17,
    HarakaSBase.RC18,
    HarakaSBase.RC19,
    HarakaSBase.RC20,
    HarakaSBase.RC21,
    HarakaSBase.RC22,
    HarakaSBase.RC23,
    HarakaSBase.RC24,
    HarakaSBase.RC25,
    HarakaSBase.RC26,
    HarakaSBase.RC27,
    HarakaSBase.RC28,
    HarakaSBase.RC29,
    HarakaSBase.RC30,
    HarakaSBase.RC31,
    HarakaSBase.RC32,
    HarakaSBase.RC33,
    HarakaSBase.RC34,
    HarakaSBase.RC35,
    HarakaSBase.RC36,
    HarakaSBase.RC37,
    HarakaSBase.RC38,
    HarakaSBase.RC39
  };
  internal ulong[][] haraka512_rc = new ulong[10][]
  {
    new ulong[8]
    {
      2652350495371256459UL,
      13679383618923496322UL,
      15667935350676443303UL,
      12307783811503579017UL,
      4944264682582508575UL,
      5312892415214084856UL,
      390034814247088728UL,
      2584105839607850161UL
    },
    new ulong[8]
    {
      15616813271728675694UL,
      9137660425067592590UL,
      7974068014816832049UL,
      13780800007984394558UL,
      2602240152241800734UL,
      16921049717778260714UL,
      8634660511727056099UL,
      1757945485816280992UL
    },
    new ulong[8]
    {
      1181946526362588450UL,
      15681551453717171323UL,
      3395396416743122529UL,
      13330470973160179193UL,
      17161289763912047618UL,
      15083446463894380355UL,
      10085908215316552625UL,
      16075391737095583129UL
    },
    new ulong[8]
    {
      15945890618932795584UL,
      8465221333286591414UL,
      8817016078209461823UL,
      9067727467981428858UL,
      4244107674518258433UL,
      14099417613138662078UL,
      1711371409274742987UL,
      6486926172609168623UL
    },
    new ulong[8]
    {
      1689001080716996467UL,
      17955247947431300943UL,
      1273395568185090836UL,
      5805238412293617850UL,
      15005454302784166761UL,
      4592753210857527691UL,
      7062886034259989751UL,
      10472350096676379060UL
    },
    new ulong[8]
    {
      17648925974889833326UL,
      18405283813057758144UL,
      476036171179798187UL,
      7391697506481003962UL,
      17591081798538862141UL,
      14957403234123739981UL,
      13555218339221595128UL,
      9110006695579921767UL
    },
    new ulong[8]
    {
      17559805991765990826UL,
      4212830408327159617UL,
      14900069586142268981UL,
      16491364651582513327UL,
      3174578079917510314UL,
      5156046680874954380UL,
      18128198267874729785UL,
      12270330065560089274UL
    },
    new ulong[8]
    {
      2529785914229181047UL,
      2966313764524854080UL,
      6363694428402697361UL,
      8292109690175819701UL,
      9949197741574092029UL,
      15235635597554736000UL,
      12919805279922909295UL,
      13470774230082493846UL
    },
    new ulong[8]
    {
      3357847021085574721UL,
      13681906861144364558UL,
      17820352244308902924UL,
      2124133995575340009UL,
      7425858999829294301UL,
      15014711204803913845UL,
      1119301198758921294UL,
      1907812968586478892UL
    },
    new ulong[8]
    {
      9460219246996718814UL,
      3356175496741300052UL,
      12682143756069655254UL,
      4002747967109689317UL,
      9727818913976054419UL,
      16508680301122176955UL,
      10442994283813605781UL,
      7302960353763723932UL
    }
  };
  internal uint[][] haraka256_rc = new uint[10][];
  protected readonly byte[] buffer;
  protected int off;

  protected HarakaSBase()
  {
    this.buffer = new byte[64 /*0x40*/];
    this.off = 0;
    byte[] input = new byte[640];
    for (int index = 0; index < 40; ++index)
      Arrays.Reverse(HarakaSBase.RoundConstants[index]).CopyTo((Array) input, index << 4);
    for (int index = 0; index < 10; ++index)
      HarakaSBase.InterleaveConstant(this.haraka512_rc[index], input, index << 6);
  }

  protected void Reset()
  {
    this.off = 0;
    Arrays.Clear(this.buffer);
  }

  protected static void InterleaveConstant(ulong[] output, byte[] input, int startPos)
  {
    uint[] numArray = new uint[16 /*0x10*/];
    Pack.LE_To_UInt32(input, startPos, numArray);
    for (int qPos = 0; qPos < 4; ++qPos)
      HarakaSBase.BrAesCt64InterleaveIn(output, qPos, numArray, qPos << 2);
    HarakaSBase.BrAesCt64Ortho(output);
  }

  protected static void InterleaveConstant32(uint[] output, byte[] input, int startPos)
  {
    for (int index = 0; index < 4; ++index)
    {
      output[index << 1] = Pack.LE_To_UInt32(input, startPos + (index << 2));
      output[(index << 1) + 1] = Pack.LE_To_UInt32(input, startPos + (index << 2) + 16 /*0x10*/);
    }
    HarakaSBase.BrAesCtOrtho(output);
  }

  internal void Haraka512Perm(byte[] output)
  {
    uint[] numArray = new uint[16 /*0x10*/];
    ulong[] q = new ulong[8];
    Pack.LE_To_UInt32(this.buffer, 0, numArray);
    for (int qPos = 0; qPos < 4; ++qPos)
      HarakaSBase.BrAesCt64InterleaveIn(q, qPos, numArray, qPos << 2);
    HarakaSBase.BrAesCt64Ortho(q);
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        HarakaSBase.BrAesCt64BitsliceSbox(q);
        HarakaSBase.ShiftRows(q);
        HarakaSBase.MixColumns(q);
        HarakaSBase.AddRoundKey(q, this.haraka512_rc[(index1 << 1) + index2]);
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        ulong num = q[index3];
        q[index3] = (ulong) (((long) num & 281479271743489L /*0x01000100010001*/) << 5 | ((long) num & 562958543486978L /*0x02000200020002*/) << 12 | (long) ((num & 1125917086973956UL /*0x04000400040004*/) >> 1) | ((long) num & 2251834173947912L /*0x08000800080008*/) << 6 | ((long) num & 9007336695791648L /*0x20002000200020*/) << 9 | (long) ((num & 18014673391583296UL /*0x40004000400040*/) >> 4) | ((long) num & 36029346783166592L /*0x80008000800080*/) << 3 | (long) ((num & 2377936887688995072UL /*0x2100210021002100*/) >> 5) | ((long) num & 148621055480562192L) << 2 | ((long) num & 576469548530665472L /*0x0800080008000800*/) << 4) | (num & 1152939097061330944UL /*0x1000100010001000*/) >> 12 | (num & 4611756388245323776UL /*0x4000400040004000*/) >> 10 | (num & 9511747550755980288UL /*0x8400840084008400*/) >> 3;
      }
    }
    HarakaSBase.BrAesCt64Ortho(q);
    for (int pos = 0; pos < 4; ++pos)
      HarakaSBase.BrAesCt64InterleaveOut(numArray, q, pos);
    for (int index4 = 0; index4 < 16 /*0x10*/; ++index4)
    {
      for (int index5 = 0; index5 < 4; ++index5)
        output[(index4 << 2) + index5] = (byte) (numArray[index4] >> (index5 << 3));
    }
  }

  internal void Haraka256Perm(byte[] output)
  {
    uint[] numArray = new uint[8];
    HarakaSBase.InterleaveConstant32(numArray, this.buffer, 0);
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        HarakaSBase.BrAesCtBitsliceSbox(numArray);
        HarakaSBase.ShiftRows32(numArray);
        HarakaSBase.MixColumns32(numArray);
        HarakaSBase.AddRoundKey32(numArray, this.haraka256_rc[(index1 << 1) + index2]);
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        uint x = Bits.BitPermuteStep(numArray[index3], 202116108U, 2);
        numArray[index3] = Bits.BitPermuteStep(x, 572662306U /*0x22222222*/, 1);
      }
    }
    HarakaSBase.BrAesCtOrtho(numArray);
    for (int index = 0; index < 4; ++index)
    {
      Pack.UInt32_To_LE(numArray[index << 1], output, index << 2);
      Pack.UInt32_To_LE(numArray[(index << 1) + 1], output, (index << 2) + 16 /*0x10*/);
    }
  }

  private static void BrAesCt64InterleaveIn(ulong[] q, int qPos, uint[] w, int startPos)
  {
    ulong num1 = (ulong) w[startPos] & (ulong) uint.MaxValue;
    ulong num2 = (ulong) w[startPos + 1] & (ulong) uint.MaxValue;
    ulong num3 = (ulong) w[startPos + 2] & (ulong) uint.MaxValue;
    ulong num4 = (ulong) w[startPos + 3] & (ulong) uint.MaxValue;
    ulong num5 = num1 | num1 << 16 /*0x10*/;
    ulong num6 = num2 | num2 << 16 /*0x10*/;
    ulong num7 = num3 | num3 << 16 /*0x10*/;
    ulong num8 = num4 | num4 << 16 /*0x10*/;
    ulong num9 = num5 & 281470681808895UL;
    ulong num10 = num6 & 281470681808895UL;
    ulong num11 = num7 & 281470681808895UL;
    ulong num12 = num8 & 281470681808895UL;
    ulong num13 = num9 | num9 << 8;
    ulong num14 = num10 | num10 << 8;
    ulong num15 = num11 | num11 << 8;
    ulong num16 = num12 | num12 << 8;
    ulong num17 = num13 & 71777214294589695UL;
    ulong num18 = num14 & 71777214294589695UL;
    ulong num19 = num15 & 71777214294589695UL;
    ulong num20 = num16 & 71777214294589695UL;
    q[qPos] = num17 | num19 << 8;
    q[qPos + 4] = num18 | num20 << 8;
  }

  private static void BrAesCtBitsliceSbox(uint[] q)
  {
    uint num1 = q[7];
    uint num2 = q[6];
    uint num3 = q[5];
    uint num4 = q[4];
    int num5 = (int) q[3];
    uint num6 = q[2];
    uint num7 = q[1];
    uint num8 = q[0];
    uint num9 = num4 ^ num6;
    uint num10 = num1 ^ num7;
    uint num11 = num1 ^ num4;
    uint num12 = num1 ^ num6;
    uint num13 = num2 ^ num3;
    uint num14 = num13 ^ num8;
    uint num15 = num14 ^ num4;
    uint num16 = num10 ^ num9;
    uint num17 = num14 ^ num1;
    uint num18 = num14 ^ num7;
    uint num19 = num18 ^ num12;
    int num20 = (int) num16;
    int num21 = num5 ^ num20;
    uint num22 = (uint) num21 ^ num6;
    uint num23 = (uint) num21 ^ num2;
    uint num24 = num22 ^ num8;
    uint num25 = num22 ^ num13;
    uint num26 = num23 ^ num11;
    uint num27 = num8 ^ num26;
    uint num28 = num25 ^ num26;
    uint num29 = num25 ^ num12;
    uint num30 = num13 ^ num26;
    uint num31 = num10 ^ num30;
    uint num32 = num1 ^ num30;
    uint num33 = num16 & num22;
    int num34 = (int) num19 & (int) num24 ^ (int) num33;
    uint num35 = num15 & num8 ^ num33;
    uint num36 = num10 & num30;
    uint num37 = num18 & num14 ^ num36;
    uint num38 = num17 & num27 ^ num36;
    uint num39 = num11 & num26;
    uint num40 = num9 & num28 ^ num39;
    uint num41 = num12 & num25 ^ num39;
    int num42 = (int) num40;
    int num43 = num34 ^ num42;
    uint num44 = num35 ^ num41;
    uint num45 = num37 ^ num40;
    uint num46 = num38 ^ num41;
    int num47 = (int) num23;
    int num48 = num43 ^ num47;
    uint num49 = num44 ^ num29;
    uint num50 = num45 ^ num31;
    uint num51 = num46 ^ num32;
    uint num52 = (uint) num48 ^ num49;
    uint num53 = (uint) num48 & num50;
    uint num54 = num51 ^ num53;
    int num55 = (int) num52 & (int) num54 ^ (int) num49;
    uint num56 = num50 ^ num51;
    uint num57 = (num49 ^ num53) & num56 ^ num51;
    uint num58 = num50 ^ num57;
    uint num59 = num54 ^ num57;
    uint num60 = num51 & num59;
    uint num61 = num60 ^ num58;
    uint num62 = (uint) num55 & (num54 ^ num60);
    uint num63 = num52 ^ num62;
    uint num64 = num63 ^ num61;
    uint num65 = (uint) num55 ^ num57;
    uint num66 = (uint) num55 ^ num63;
    uint num67 = num57 ^ num61;
    uint num68 = num65 ^ num64;
    uint num69 = num67 & num22;
    uint num70 = num61 & num24;
    uint num71 = num57 & num8;
    uint num72 = num66 & num30;
    uint num73 = num63 & num14;
    uint num74 = (uint) num55 & num27;
    uint num75 = num65 & num26;
    uint num76 = num68 & num28;
    uint num77 = num64 & num25;
    uint num78 = num67 & num16;
    uint num79 = num61 & num19;
    uint num80 = num57 & num15;
    uint num81 = num66 & num10;
    uint num82 = num63 & num18;
    uint num83 = (uint) num55 & num17;
    int num84 = (int) num65 & (int) num11;
    uint num85 = num68 & num9;
    uint num86 = num64 & num12;
    int num87 = (int) num85;
    uint num88 = (uint) (num84 ^ num87);
    uint num89 = num79 ^ num80;
    uint num90 = num74 ^ num82;
    uint num91 = num78 ^ num79;
    uint num92 = num71 ^ num81;
    uint num93 = num71 ^ num74;
    uint num94 = num76 ^ num77;
    uint num95 = num69 ^ num72;
    uint num96 = num75 ^ num76;
    int num97 = (int) num85 ^ (int) num86;
    int num98 = (int) num81 ^ (int) num90;
    uint num99 = num92 ^ num95;
    uint num100 = num73 ^ num88;
    uint num101 = num72 ^ num96;
    uint num102 = num88 ^ num99;
    int num103 = (int) num83 ^ (int) num99;
    uint num104 = num94 ^ num100;
    uint num105 = num91 ^ num100;
    uint num106 = num73 ^ num101;
    int num107 = (int) num104;
    uint num108 = (uint) (num103 ^ num107);
    uint num109 = num70 ^ num105;
    uint num110 = num101 ^ num105;
    int num111 = ~(int) num104;
    uint num112 = (uint) (num98 ^ num111);
    uint num113 = num90 ^ ~num102;
    uint num114 = num106 ^ num108;
    uint num115 = num95 ^ num109;
    uint num116 = num93 ^ num109;
    uint num117 = num89 ^ num108;
    uint num118 = num106 ^ ~num115;
    int num119 = ~(int) num114;
    uint num120 = (uint) (num97 ^ num119);
    q[7] = num110;
    q[6] = num118;
    q[5] = num120;
    q[4] = num115;
    q[3] = num116;
    q[2] = num117;
    q[1] = num112;
    q[0] = num113;
  }

  private static void ShiftRows32(uint[] q)
  {
    for (int index = 0; index < 8; ++index)
    {
      uint x = Bits.BitPermuteStep(q[index], 202310400U /*0x0C0F0300*/, 4);
      q[index] = Bits.BitPermuteStep(x, 855651072U /*0x33003300*/, 2);
    }
  }

  private static void MixColumns32(uint[] q)
  {
    int i1 = (int) q[0];
    uint num1 = Integers.RotateRight((uint) i1, 8);
    uint i2 = (uint) i1 ^ num1;
    int i3 = (int) q[1];
    uint num2 = Integers.RotateRight((uint) i3, 8);
    uint i4 = (uint) i3 ^ num2;
    int i5 = (int) q[2];
    uint num3 = Integers.RotateRight((uint) i5, 8);
    uint i6 = (uint) i5 ^ num3;
    int i7 = (int) q[3];
    uint num4 = Integers.RotateRight((uint) i7, 8);
    uint i8 = (uint) i7 ^ num4;
    int i9 = (int) q[4];
    uint num5 = Integers.RotateRight((uint) i9, 8);
    uint i10 = (uint) i9 ^ num5;
    int i11 = (int) q[5];
    uint num6 = Integers.RotateRight((uint) i11, 8);
    uint i12 = (uint) i11 ^ num6;
    int i13 = (int) q[6];
    uint num7 = Integers.RotateRight((uint) i13, 8);
    uint i14 = (uint) i13 ^ num7;
    int i15 = (int) q[7];
    uint num8 = Integers.RotateRight((uint) i15, 8);
    uint i16 = (uint) i15 ^ num8;
    q[0] = num1 ^ i16 ^ Integers.RotateRight(i2, 16 /*0x10*/);
    q[1] = num2 ^ i2 ^ i16 ^ Integers.RotateRight(i4, 16 /*0x10*/);
    q[2] = num3 ^ i4 ^ Integers.RotateRight(i6, 16 /*0x10*/);
    q[3] = num4 ^ i6 ^ i16 ^ Integers.RotateRight(i8, 16 /*0x10*/);
    q[4] = num5 ^ i8 ^ i16 ^ Integers.RotateRight(i10, 16 /*0x10*/);
    q[5] = num6 ^ i10 ^ Integers.RotateRight(i12, 16 /*0x10*/);
    q[6] = num7 ^ i12 ^ Integers.RotateRight(i14, 16 /*0x10*/);
    q[7] = num8 ^ i14 ^ Integers.RotateRight(i16, 16 /*0x10*/);
  }

  private static void AddRoundKey32(uint[] q, uint[] sk)
  {
    q[0] ^= sk[0];
    q[1] ^= sk[1];
    q[2] ^= sk[2];
    q[3] ^= sk[3];
    q[4] ^= sk[4];
    q[5] ^= sk[5];
    q[6] ^= sk[6];
    q[7] ^= sk[7];
  }

  private static void BrAesCt64Ortho(ulong[] q)
  {
    ulong lo = q[0];
    ulong num1 = q[1];
    ulong num2 = q[2];
    ulong num3 = q[3];
    ulong num4 = q[4];
    ulong num5 = q[5];
    ulong num6 = q[6];
    ulong hi = q[7];
    Bits.BitPermuteStep2(ref num1, ref lo, 6148914691236517205UL /*0x5555555555555555*/, 1);
    Bits.BitPermuteStep2(ref num3, ref num2, 6148914691236517205UL /*0x5555555555555555*/, 1);
    Bits.BitPermuteStep2(ref num5, ref num4, 6148914691236517205UL /*0x5555555555555555*/, 1);
    Bits.BitPermuteStep2(ref hi, ref num6, 6148914691236517205UL /*0x5555555555555555*/, 1);
    Bits.BitPermuteStep2(ref num2, ref lo, 3689348814741910323UL /*0x3333333333333333*/, 2);
    Bits.BitPermuteStep2(ref num3, ref num1, 3689348814741910323UL /*0x3333333333333333*/, 2);
    Bits.BitPermuteStep2(ref num6, ref num4, 3689348814741910323UL /*0x3333333333333333*/, 2);
    Bits.BitPermuteStep2(ref hi, ref num5, 3689348814741910323UL /*0x3333333333333333*/, 2);
    Bits.BitPermuteStep2(ref num4, ref lo, 1085102592571150095UL, 4);
    Bits.BitPermuteStep2(ref num5, ref num1, 1085102592571150095UL, 4);
    Bits.BitPermuteStep2(ref num6, ref num2, 1085102592571150095UL, 4);
    Bits.BitPermuteStep2(ref hi, ref num3, 1085102592571150095UL, 4);
    q[0] = lo;
    q[1] = num1;
    q[2] = num2;
    q[3] = num3;
    q[4] = num4;
    q[5] = num5;
    q[6] = num6;
    q[7] = hi;
  }

  private static void BrAesCtOrtho(uint[] q)
  {
    uint lo = q[0];
    uint num1 = q[1];
    uint num2 = q[2];
    uint num3 = q[3];
    uint num4 = q[4];
    uint num5 = q[5];
    uint num6 = q[6];
    uint hi = q[7];
    Bits.BitPermuteStep2(ref num1, ref lo, 1431655765U /*0x55555555*/, 1);
    Bits.BitPermuteStep2(ref num3, ref num2, 1431655765U /*0x55555555*/, 1);
    Bits.BitPermuteStep2(ref num5, ref num4, 1431655765U /*0x55555555*/, 1);
    Bits.BitPermuteStep2(ref hi, ref num6, 1431655765U /*0x55555555*/, 1);
    Bits.BitPermuteStep2(ref num2, ref lo, 858993459U /*0x33333333*/, 2);
    Bits.BitPermuteStep2(ref num3, ref num1, 858993459U /*0x33333333*/, 2);
    Bits.BitPermuteStep2(ref num6, ref num4, 858993459U /*0x33333333*/, 2);
    Bits.BitPermuteStep2(ref hi, ref num5, 858993459U /*0x33333333*/, 2);
    Bits.BitPermuteStep2(ref num4, ref lo, 252645135U, 4);
    Bits.BitPermuteStep2(ref num5, ref num1, 252645135U, 4);
    Bits.BitPermuteStep2(ref num6, ref num2, 252645135U, 4);
    Bits.BitPermuteStep2(ref hi, ref num3, 252645135U, 4);
    q[0] = lo;
    q[1] = num1;
    q[2] = num2;
    q[3] = num3;
    q[4] = num4;
    q[5] = num5;
    q[6] = num6;
    q[7] = hi;
  }

  private static void BrAesCt64BitsliceSbox(ulong[] q)
  {
    ulong num1 = q[7];
    ulong num2 = q[6];
    ulong num3 = q[5];
    ulong num4 = q[4];
    long num5 = (long) q[3];
    ulong num6 = q[2];
    ulong num7 = q[1];
    ulong num8 = q[0];
    ulong num9 = num4 ^ num6;
    ulong num10 = num1 ^ num7;
    ulong num11 = num1 ^ num4;
    ulong num12 = num1 ^ num6;
    ulong num13 = num2 ^ num3;
    ulong num14 = num13 ^ num8;
    ulong num15 = num14 ^ num4;
    ulong num16 = num10 ^ num9;
    ulong num17 = num14 ^ num1;
    ulong num18 = num14 ^ num7;
    ulong num19 = num18 ^ num12;
    long num20 = (long) num16;
    long num21 = num5 ^ num20;
    ulong num22 = (ulong) num21 ^ num6;
    ulong num23 = (ulong) num21 ^ num2;
    ulong num24 = num22 ^ num8;
    ulong num25 = num22 ^ num13;
    ulong num26 = num23 ^ num11;
    ulong num27 = num8 ^ num26;
    ulong num28 = num25 ^ num26;
    ulong num29 = num25 ^ num12;
    ulong num30 = num13 ^ num26;
    ulong num31 = num10 ^ num30;
    ulong num32 = num1 ^ num30;
    ulong num33 = num16 & num22;
    long num34 = (long) num19 & (long) num24 ^ (long) num33;
    ulong num35 = num15 & num8 ^ num33;
    ulong num36 = num10 & num30;
    ulong num37 = num18 & num14 ^ num36;
    ulong num38 = num17 & num27 ^ num36;
    ulong num39 = num11 & num26;
    ulong num40 = num9 & num28 ^ num39;
    ulong num41 = num12 & num25 ^ num39;
    long num42 = (long) num40;
    long num43 = num34 ^ num42;
    ulong num44 = num35 ^ num41;
    ulong num45 = num37 ^ num40;
    ulong num46 = num38 ^ num41;
    long num47 = (long) num23;
    long num48 = num43 ^ num47;
    ulong num49 = num44 ^ num29;
    ulong num50 = num45 ^ num31;
    ulong num51 = num46 ^ num32;
    ulong num52 = (ulong) num48 ^ num49;
    ulong num53 = (ulong) num48 & num50;
    ulong num54 = num51 ^ num53;
    long num55 = (long) num52 & (long) num54 ^ (long) num49;
    ulong num56 = num50 ^ num51;
    ulong num57 = (num49 ^ num53) & num56 ^ num51;
    ulong num58 = num50 ^ num57;
    ulong num59 = num54 ^ num57;
    ulong num60 = num51 & num59;
    ulong num61 = num60 ^ num58;
    ulong num62 = (ulong) num55 & (num54 ^ num60);
    ulong num63 = num52 ^ num62;
    ulong num64 = num63 ^ num61;
    ulong num65 = (ulong) num55 ^ num57;
    ulong num66 = (ulong) num55 ^ num63;
    ulong num67 = num57 ^ num61;
    ulong num68 = num65 ^ num64;
    ulong num69 = num67 & num22;
    ulong num70 = num61 & num24;
    ulong num71 = num57 & num8;
    ulong num72 = num66 & num30;
    ulong num73 = num63 & num14;
    ulong num74 = (ulong) num55 & num27;
    ulong num75 = num65 & num26;
    ulong num76 = num68 & num28;
    ulong num77 = num64 & num25;
    ulong num78 = num67 & num16;
    ulong num79 = num61 & num19;
    ulong num80 = num57 & num15;
    ulong num81 = num66 & num10;
    ulong num82 = num63 & num18;
    ulong num83 = (ulong) num55 & num17;
    long num84 = (long) num65 & (long) num11;
    ulong num85 = num68 & num9;
    ulong num86 = num64 & num12;
    long num87 = (long) num85;
    ulong num88 = (ulong) (num84 ^ num87);
    ulong num89 = num79 ^ num80;
    ulong num90 = num74 ^ num82;
    ulong num91 = num78 ^ num79;
    ulong num92 = num71 ^ num81;
    ulong num93 = num71 ^ num74;
    ulong num94 = num76 ^ num77;
    ulong num95 = num69 ^ num72;
    ulong num96 = num75 ^ num76;
    long num97 = (long) num85 ^ (long) num86;
    long num98 = (long) num81 ^ (long) num90;
    ulong num99 = num92 ^ num95;
    ulong num100 = num73 ^ num88;
    ulong num101 = num72 ^ num96;
    ulong num102 = num88 ^ num99;
    long num103 = (long) num83 ^ (long) num99;
    ulong num104 = num94 ^ num100;
    ulong num105 = num91 ^ num100;
    ulong num106 = num73 ^ num101;
    long num107 = (long) num104;
    ulong num108 = (ulong) (num103 ^ num107);
    ulong num109 = num70 ^ num105;
    ulong num110 = num101 ^ num105;
    long num111 = ~(long) num104;
    ulong num112 = (ulong) (num98 ^ num111);
    ulong num113 = num90 ^ ~num102;
    ulong num114 = num106 ^ num108;
    ulong num115 = num95 ^ num109;
    ulong num116 = num93 ^ num109;
    ulong num117 = num89 ^ num108;
    ulong num118 = num106 ^ ~num115;
    long num119 = ~(long) num114;
    ulong num120 = (ulong) (num97 ^ num119);
    q[7] = num110;
    q[6] = num118;
    q[5] = num120;
    q[4] = num115;
    q[3] = num116;
    q[2] = num117;
    q[1] = num112;
    q[0] = num113;
  }

  private static void ShiftRows(ulong[] q)
  {
    for (int index = 0; index < 8; ++index)
    {
      ulong x = Bits.BitPermuteStep(q[index], 67555089628200960UL /*0xF000FF000F0000*/, 8);
      q[index] = Bits.BitPermuteStep(x, 1085086035472220160UL /*0x0F0F00000F0F0000*/, 4);
    }
  }

  private static void MixColumns(ulong[] q)
  {
    long i1 = (long) q[0];
    ulong num1 = Longs.RotateRight((ulong) i1, 16 /*0x10*/);
    ulong i2 = (ulong) i1 ^ num1;
    long i3 = (long) q[1];
    ulong num2 = Longs.RotateRight((ulong) i3, 16 /*0x10*/);
    ulong i4 = (ulong) i3 ^ num2;
    long i5 = (long) q[2];
    ulong num3 = Longs.RotateRight((ulong) i5, 16 /*0x10*/);
    ulong i6 = (ulong) i5 ^ num3;
    long i7 = (long) q[3];
    ulong num4 = Longs.RotateRight((ulong) i7, 16 /*0x10*/);
    ulong i8 = (ulong) i7 ^ num4;
    long i9 = (long) q[4];
    ulong num5 = Longs.RotateRight((ulong) i9, 16 /*0x10*/);
    ulong i10 = (ulong) i9 ^ num5;
    long i11 = (long) q[5];
    ulong num6 = Longs.RotateRight((ulong) i11, 16 /*0x10*/);
    ulong i12 = (ulong) i11 ^ num6;
    long i13 = (long) q[6];
    ulong num7 = Longs.RotateRight((ulong) i13, 16 /*0x10*/);
    ulong i14 = (ulong) i13 ^ num7;
    long i15 = (long) q[7];
    ulong num8 = Longs.RotateRight((ulong) i15, 16 /*0x10*/);
    ulong i16 = (ulong) i15 ^ num8;
    q[0] = num1 ^ i16 ^ Longs.RotateRight(i2, 32 /*0x20*/);
    q[1] = num2 ^ i2 ^ i16 ^ Longs.RotateRight(i4, 32 /*0x20*/);
    q[2] = num3 ^ i4 ^ Longs.RotateRight(i6, 32 /*0x20*/);
    q[3] = num4 ^ i6 ^ i16 ^ Longs.RotateRight(i8, 32 /*0x20*/);
    q[4] = num5 ^ i8 ^ i16 ^ Longs.RotateRight(i10, 32 /*0x20*/);
    q[5] = num6 ^ i10 ^ Longs.RotateRight(i12, 32 /*0x20*/);
    q[6] = num7 ^ i12 ^ Longs.RotateRight(i14, 32 /*0x20*/);
    q[7] = num8 ^ i14 ^ Longs.RotateRight(i16, 32 /*0x20*/);
  }

  private static void AddRoundKey(ulong[] q, ulong[] sk)
  {
    q[0] ^= sk[0];
    q[1] ^= sk[1];
    q[2] ^= sk[2];
    q[3] ^= sk[3];
    q[4] ^= sk[4];
    q[5] ^= sk[5];
    q[6] ^= sk[6];
    q[7] ^= sk[7];
  }

  private static void BrAesCt64InterleaveOut(uint[] w, ulong[] q, int pos)
  {
    ulong num1 = q[pos] & 71777214294589695UL;
    ulong num2 = q[pos + 4] & 71777214294589695UL;
    ulong num3 = q[pos] >> 8 & 71777214294589695UL;
    ulong num4 = q[pos + 4] >> 8 & 71777214294589695UL;
    ulong num5 = num1 | num1 >> 8;
    ulong num6 = num2 | num2 >> 8;
    ulong num7 = num3 | num3 >> 8;
    ulong num8 = num4 | num4 >> 8;
    ulong num9 = num5 & 281470681808895UL;
    ulong num10 = num6 & 281470681808895UL;
    ulong num11 = num7 & 281470681808895UL;
    ulong num12 = num8 & 281470681808895UL;
    pos <<= 2;
    w[pos] = (uint) (num9 | num9 >> 16 /*0x10*/);
    w[pos + 1] = (uint) (num10 | num10 >> 16 /*0x10*/);
    w[pos + 2] = (uint) (num11 | num11 >> 16 /*0x10*/);
    w[pos + 3] = (uint) (num12 | num12 >> 16 /*0x10*/);
  }

  protected static void Xor(
    byte[] x,
    int xOff,
    byte[] y,
    int yOff,
    byte[] z,
    int zOff,
    int zLen)
  {
    for (int index = 0; index < zLen; ++index)
      z[zOff + index] = (byte) ((uint) x[xOff + index] ^ (uint) y[yOff + index]);
  }
}
