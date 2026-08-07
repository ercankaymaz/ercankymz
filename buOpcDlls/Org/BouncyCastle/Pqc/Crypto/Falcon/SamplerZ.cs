// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.SamplerZ
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class SamplerZ
{
  private FalconRNG p;
  private FalconFPR sigma_min;
  private FprEngine fpre;

  internal SamplerZ(FalconRNG p, FalconFPR sigma_min, FprEngine fpre)
  {
    this.p = p;
    this.sigma_min = sigma_min;
    this.fpre = fpre;
  }

  internal int Sample(FalconFPR mu, FalconFPR isigma) => this.sampler(mu, isigma);

  private int gaussian0_sampler(FalconRNG p)
  {
    uint[] numArray = new uint[54]
    {
      10745844U,
      3068844U,
      3741698U,
      5559083U,
      1580863U,
      8248194U,
      2260429U,
      13669192U,
      2736639U,
      708981U,
      4421575U,
      10046180U,
      169348U,
      7122675U,
      4136815U,
      30538U,
      13063405U,
      7650655U,
      4132U,
      14505003U,
      7826148U,
      417U,
      16768101U,
      11363290U,
      31U /*0x1F*/,
      8444042U,
      8086568U,
      1U,
      12844466U,
      265321U,
      0U,
      1232676U,
      13644283U,
      0U,
      38047U,
      9111839U,
      0U,
      870U,
      6138264U,
      0U,
      14U,
      12545723U,
      0U,
      0U,
      3104126U,
      0U,
      0U,
      28824U,
      0U,
      0U,
      198U,
      0U,
      0U,
      1U
    };
    long u64 = (long) p.prng_get_u64();
    uint u8 = p.prng_get_u8();
    uint num1 = (uint) u64 & 16777215U /*0xFFFFFF*/;
    uint num2 = (uint) (u64 >>> 24) & 16777215U /*0xFFFFFF*/;
    uint num3 = (uint) (u64 >>> 48 /*0x30*/) | u8 << 16 /*0x10*/;
    int num4 = 0;
    for (int index = 0; index < numArray.Length; index += 3)
    {
      uint num5 = numArray[index + 2];
      uint num6 = numArray[index + 1];
      uint num7 = numArray[index];
      uint num8 = num1 - num5 >> 31 /*0x1F*/;
      uint num9 = num2 - num6 - num8 >> 31 /*0x1F*/;
      uint num10 = num3 - num7 - num9 >> 31 /*0x1F*/;
      num4 += (int) num10;
    }
    return num4;
  }

  private int BerExp(FalconRNG p, FalconFPR x, FalconFPR ccs)
  {
    int i = (int) this.fpre.fpr_trunc(this.fpre.fpr_mul(x, this.fpre.fpr_inv_log2));
    FalconFPR x1 = this.fpre.fpr_sub(x, this.fpre.fpr_mul(this.fpre.fpr_of((long) i), this.fpre.fpr_log2));
    uint num1 = (uint) i;
    int num2 = (int) (num1 ^ (uint) ((ulong) (num1 ^ 63U /*0x3F*/) & (ulong) -(63U /*0x3F*/ - num1 >> 31 /*0x1F*/)));
    ulong num3 = (ulong) (((long) this.fpre.fpr_expm_p63(x1, ccs) << 1) - 1L >>> num2);
    int num4 = 64 /*0x40*/;
    uint num5;
    do
    {
      num4 -= 8;
      num5 = p.prng_get_u8() - ((uint) (num3 >> num4) & (uint) byte.MaxValue);
    }
    while (num5 == 0U && num4 > 0);
    return (int) (num5 >> 31 /*0x1F*/);
  }

  private int sampler(FalconFPR mu, FalconFPR isigma)
  {
    int i1 = (int) this.fpre.fpr_floor(mu);
    FalconFPR y1 = this.fpre.fpr_sub(mu, this.fpre.fpr_of((long) i1));
    FalconFPR y2 = this.fpre.fpr_half(this.fpre.fpr_sqr(isigma));
    FalconFPR ccs = this.fpre.fpr_mul(isigma, this.sigma_min);
    int num1;
    int i2;
    do
    {
      num1 = this.gaussian0_sampler(this.p);
      int num2 = (int) this.p.prng_get_u8() & 1;
      i2 = num2 + ((num2 << 1) - 1) * num1;
    }
    while (this.BerExp(this.p, this.fpre.fpr_sub(this.fpre.fpr_mul(this.fpre.fpr_sqr(this.fpre.fpr_sub(this.fpre.fpr_of((long) i2), y1)), y2), this.fpre.fpr_mul(this.fpre.fpr_of((long) (num1 * num1)), this.fpre.fpr_inv_2sqrsigma0)), ccs) == 0);
    return i1 + i2;
  }
}
