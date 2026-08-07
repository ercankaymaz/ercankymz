// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.P434
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P434 : Internal
{
  internal P434(bool isCompressed)
  {
    this.COMPRESS = isCompressed;
    this.CRYPTO_SECRETKEYBYTES = 374U;
    this.CRYPTO_PUBLICKEYBYTES = 330U;
    this.CRYPTO_BYTES = 16U /*0x10*/;
    this.CRYPTO_CIPHERTEXTBYTES = 346;
    if (isCompressed)
    {
      this.CRYPTO_SECRETKEYBYTES = 350U;
      this.CRYPTO_PUBLICKEYBYTES = 197U;
      this.CRYPTO_CIPHERTEXTBYTES = 236;
    }
    this.NWORDS_FIELD = 7U;
    this.PRIME_ZERO_WORDS = 3U;
    this.NBITS_FIELD = 434U;
    this.MAXBITS_FIELD = 448U;
    this.MAXWORDS_FIELD = (uint) ((int) this.MAXBITS_FIELD + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_FIELD = (this.NBITS_FIELD + 63U /*0x3F*/) / 64U /*0x40*/;
    this.NBITS_ORDER = 256U /*0x0100*/;
    this.NWORDS_ORDER = (uint) ((int) this.NBITS_ORDER + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_ORDER = (this.NBITS_ORDER + 63U /*0x3F*/) / 64U /*0x40*/;
    this.MAXBITS_ORDER = this.NBITS_ORDER;
    this.ALICE = 0U;
    this.BOB = 1U;
    this.OALICE_BITS = 216U;
    this.OBOB_BITS = 218U;
    this.OBOB_EXPON = 137U;
    this.MASK_ALICE = (uint) byte.MaxValue;
    this.MASK_BOB = 1U;
    this.PARAM_A = 6U;
    this.PARAM_C = 1U;
    this.MAX_INT_POINTS_ALICE = 7U;
    this.MAX_INT_POINTS_BOB = 8U;
    this.MAX_Alice = 108U;
    this.MAX_Bob = 137U;
    this.MSG_BYTES = 16U /*0x10*/;
    this.SECRETKEY_A_BYTES = (this.OALICE_BITS + 7U) / 8U;
    this.SECRETKEY_B_BYTES = (uint) ((int) this.OBOB_BITS - 1 + 7) / 8U;
    this.FP2_ENCODED_BYTES = 2U * ((this.NBITS_FIELD + 7U) / 8U);
    this.PRIME = new ulong[7]
    {
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      18285026232267440127UL,
      8918917783347572387UL,
      7853257225132122198UL,
      620258357900100UL
    };
    this.PRIMEx2 = new ulong[7]
    {
      18446744073709551614UL,
      ulong.MaxValue,
      ulong.MaxValue,
      18123308390825328639UL,
      17837835566695144775UL,
      15706514450264244396UL,
      1240516715800200UL
    };
    this.PRIMEx4 = new ulong[7]
    {
      18446744073709551612UL,
      ulong.MaxValue,
      ulong.MaxValue,
      17799872707941105663UL,
      17228927059680737935UL,
      12966284826818937177UL,
      2481033431600401UL
    };
    this.PRIMEp1 = new ulong[7]
    {
      0UL,
      0UL,
      0UL,
      18285026232267440128UL,
      8918917783347572387UL,
      7853257225132122198UL,
      620258357900100UL
    };
    this.PRIMEx16p = new ulong[14]
    {
      16UL /*0x10*/,
      0UL,
      0UL,
      5174970926147567616UL,
      9742536112230509440UL,
      6950185827705812272UL,
      6073522028379477874UL,
      14222146884144505874UL,
      8299186480726035350UL,
      7225369840861796773UL,
      2456441653404885428UL,
      12555258408051429121UL,
      1781491355331495958UL,
      333691781277UL
    };
    this.Alice_order = new ulong[4]
    {
      0UL,
      0UL,
      0UL,
      16777216UL /*0x01000000*/
    };
    this.Bob_order = new ulong[4]
    {
      6390225231553133283UL,
      14204448314335459377UL,
      1689769520075363969UL,
      36970279UL
    };
    this.A_gen = new ulong[42]
    {
      409251790387889599UL,
      10489829510628224043UL,
      12674510860217942615UL,
      8135632727773423537UL,
      17840997995551181005UL,
      2414452085739184671UL,
      11115521240260UL,
      8395851790856910728UL,
      2986355008512957707UL,
      14652235704098559445UL,
      10149113683644317610UL,
      12102338175217582495UL,
      15452390807072906892UL,
      281073067659850UL,
      18358614117343242043UL,
      15178862300246045126UL,
      17939401953738004679UL,
      16301132844359752451UL,
      1973682341831588061UL,
      8312799048378913301UL,
      497853136119926UL,
      12515775166124391894UL,
      7710088909771808848UL,
      7498146198864584751UL,
      2174778336782639988UL,
      16347399334629616021UL,
      12025936272585254152UL,
      438485524985150UL,
      124497379906645117UL,
      3220114552465917457UL,
      2709773247140401691UL,
      6980995868580086445UL,
      4225536559282510125UL,
      4701685901084574963UL,
      609687130428995UL,
      13307499667408479562UL,
      17265918823005609453UL,
      6350294504100107936UL,
      8618087912213766372UL,
      308885086986017528UL,
      15792880328099440610UL,
      202858940514502UL
    };
    this.B_gen = new ulong[42]
    {
      7950145635403778211UL,
      3053921039650069509UL,
      16974511502399211645UL,
      6369396808518798415UL,
      13295737116337704235UL,
      2507423554624419257UL,
      491294718579999UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      18078192145093323662UL,
      5280595860558773788UL,
      17229246200424940156UL,
      5300724274592529762UL,
      12685182915280535178UL,
      17596270270016357247UL,
      57208989669550UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      2898969037767559396UL,
      10522929125730281031UL,
      9073321008578907802UL,
      7539793830764276893UL,
      9328908741686588507UL,
      148738643701593348UL,
      139132528504375UL,
      12932288373210664113UL,
      7856701733796155952UL,
      16996962201367356265UL,
      3113577795642755667UL,
      4926779461749210259UL,
      13761095186437813579UL,
      408994988652499UL
    };
    this.Montgomery_R2 = new ulong[7]
    {
      2946862024238734128UL,
      12460461157234743490UL,
      12332992403615082637UL,
      1683438818023996427UL,
      12379712300517307518UL,
      7629496211932212634UL,
      41406098690346UL
    };
    this.Montgomery_one = new ulong[7]
    {
      29740UL,
      0UL,
      0UL,
      13335145323912232960UL,
      15564903186549419220UL,
      16803585881028378892UL,
      260509760564954UL
    };
    this.strat_Alice = new uint[107]
    {
      48U /*0x30*/,
      28U,
      16U /*0x10*/,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      13U,
      7U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      3U,
      2U,
      1U,
      1U,
      1U,
      1U,
      5U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      1U,
      21U,
      12U,
      7U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      3U,
      2U,
      1U,
      1U,
      1U,
      1U,
      5U,
      3U,
      2U,
      1U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      1U,
      9U,
      5U,
      3U,
      2U,
      1U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U
    };
    this.strat_Bob = new uint[136]
    {
      66U,
      33U,
      17U,
      9U,
      5U,
      3U,
      2U,
      1U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      8U,
      4U,
      2U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      16U /*0x10*/,
      8U,
      4U,
      2U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      32U /*0x20*/,
      16U /*0x10*/,
      8U,
      4U,
      3U,
      1U,
      1U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      16U /*0x10*/,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      8U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U,
      4U,
      2U,
      1U,
      1U,
      2U,
      1U,
      1U
    };
    if (!isCompressed)
      return;
    this.MASK2_BOB = 0U;
    this.MASK3_BOB = (uint) sbyte.MaxValue;
    this.ORDER_A_ENCODED_BYTES = this.SECRETKEY_A_BYTES;
    this.ORDER_B_ENCODED_BYTES = this.SECRETKEY_B_BYTES;
    this.PARTIALLY_COMPRESSED_CHUNK_CT = (uint) (4 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.COMPRESSED_CHUNK_CT = (uint) (3 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.UNCOMPRESSEDPK_BYTES = 330U;
    this.TABLE_R_LEN = 17U;
    this.TABLE_V_LEN = 34U;
    this.TABLE_V3_LEN = 20U;
    this.W_2 = 4U;
    this.W_3 = 3U;
    this.ELL2_W = 1U << (int) this.W_2;
    this.ELL3_W = 27U;
    this.ELL2_EMODW = 1U << (int) (this.OALICE_BITS % this.W_2);
    this.ELL3_EMODW = 9U;
    this.DLEN_2 = (uint) ((int) this.OALICE_BITS + (int) this.W_2 - 1) / this.W_2;
    this.DLEN_3 = (uint) ((int) this.OBOB_EXPON + (int) this.W_3 - 1) / this.W_3;
    this.PLEN_2 = 55U;
    this.PLEN_3 = 47U;
    Dictionary<string, string> props = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (P434).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p434.bz2"))
    {
      using (StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(manifestResourceStream)))
      {
        int num = 0;
        for (string str1 = streamReader.ReadLine(); str1 != null; str1 = streamReader.ReadLine())
        {
          string str2 = str1;
          if (str2 != "")
          {
            if (num > 1)
              str2 = str2.Replace(",", "");
            int length = str2.IndexOf('=');
            string key = str2.Substring(0, length).Trim();
            string str3 = str2.Substring(length + 1).Trim();
            props.Add(key, str3);
            ++num;
          }
        }
      }
    }
    this.ph2_path = Internal.ReadIntsFromProperty((IDictionary<string, string>) props, "ph2_path", this.PLEN_2);
    this.ph3_path = Internal.ReadIntsFromProperty((IDictionary<string, string>) props, "ph3_path", this.PLEN_3);
    this.A_gen = Internal.ReadFromProperty((IDictionary<string, string>) props, "A_gen", 6U * this.NWORDS64_FIELD);
    this.B_gen = Internal.ReadFromProperty((IDictionary<string, string>) props, "B_gen", 6U * this.NWORDS64_FIELD);
    this.XQB3 = Internal.ReadFromProperty((IDictionary<string, string>) props, "XQB3", 2U * this.NWORDS64_FIELD);
    this.A_basis_zero = Internal.ReadFromProperty((IDictionary<string, string>) props, "A_basis_zero", 8U * this.NWORDS64_FIELD);
    this.B_basis_zero = Internal.ReadFromProperty((IDictionary<string, string>) props, "B_basis_zero", 8U * this.NWORDS64_FIELD);
    this.B_gen_3_tors = Internal.ReadFromProperty((IDictionary<string, string>) props, "B_gen_3_tors", 16U /*0x10*/ * this.NWORDS64_FIELD);
    this.g_R_S_im = Internal.ReadFromProperty((IDictionary<string, string>) props, "g_R_S_im", this.NWORDS64_FIELD);
    this.g_phiR_phiS_re = Internal.ReadFromProperty((IDictionary<string, string>) props, "g_phiR_phiS_re", this.NWORDS64_FIELD);
    this.g_phiR_phiS_im = Internal.ReadFromProperty((IDictionary<string, string>) props, "g_phiR_phiS_im", this.NWORDS64_FIELD);
    this.Montgomery_RB1 = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_RB1", this.NWORDS64_FIELD);
    this.Montgomery_RB2 = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_RB2", this.NWORDS64_FIELD);
    this.threeinv = Internal.ReadFromProperty((IDictionary<string, string>) props, "threeinv", this.NWORDS64_FIELD);
    this.u_entang = Internal.ReadFromProperty((IDictionary<string, string>) props, "u_entang", 2U * this.NWORDS64_FIELD);
    this.u0_entang = Internal.ReadFromProperty((IDictionary<string, string>) props, "u0_entang", 2U * this.NWORDS64_FIELD);
    this.table_r_qr = Internal.ReadFromProperty((IDictionary<string, string>) props, "table_r_qr", this.TABLE_R_LEN, this.NWORDS64_FIELD);
    this.table_r_qnr = Internal.ReadFromProperty((IDictionary<string, string>) props, "table_r_qnr", this.TABLE_R_LEN, this.NWORDS64_FIELD);
    this.table_v_qr = Internal.ReadFromProperty((IDictionary<string, string>) props, "table_v_qr", this.TABLE_V_LEN, this.NWORDS64_FIELD);
    this.table_v_qnr = Internal.ReadFromProperty((IDictionary<string, string>) props, "table_v_qnr", this.TABLE_V_LEN, this.NWORDS64_FIELD);
    this.v_3_torsion = Internal.ReadFromProperty((IDictionary<string, string>) props, "v_3_torsion", this.TABLE_V3_LEN, 2U, this.NWORDS64_FIELD);
    this.T_tate3 = Internal.ReadFromProperty((IDictionary<string, string>) props, "T_tate3", (uint) (6 * ((int) this.OBOB_EXPON - 1) + 4) * this.NWORDS64_FIELD);
    this.T_tate2_firststep_P = Internal.ReadFromProperty((IDictionary<string, string>) props, "T_tate2_firststep_P", 4U * this.NWORDS64_FIELD);
    this.T_tate2_P = Internal.ReadFromProperty((IDictionary<string, string>) props, "T_tate2_P", (uint) (3 * ((int) this.OALICE_BITS - 2)) * this.NWORDS64_FIELD);
    this.T_tate2_firststep_Q = Internal.ReadFromProperty((IDictionary<string, string>) props, "T_tate2_firststep_Q", 4U * this.NWORDS64_FIELD);
    this.T_tate2_Q = Internal.ReadFromProperty((IDictionary<string, string>) props, "T_tate2_Q", (uint) (3 * ((int) this.OALICE_BITS - 2)) * this.NWORDS64_FIELD);
    this.ph2_T = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph2_T", (uint) ((int) this.DLEN_2 * (int) (this.ELL2_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.ph3_T1 = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph3_T1", (uint) ((int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.ph3_T2 = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph3_T2", (uint) ((int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.ph2_T1 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
    this.ph2_T2 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
    this.ph3_T = new ulong[2 * (((int) this.DLEN_3 - 1) * (int) (this.ELL3_W / 2U) + ((int) this.ph3_path[(int) this.PLEN_3 - 1] - 1))];
  }
}
