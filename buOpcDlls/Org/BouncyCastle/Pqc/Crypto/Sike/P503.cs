// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.P503
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P503 : Internal
{
  internal P503(bool isCompressed)
  {
    this.COMPRESS = isCompressed;
    this.CRYPTO_SECRETKEYBYTES = 434U;
    this.CRYPTO_PUBLICKEYBYTES = 378U;
    this.CRYPTO_BYTES = 24U;
    this.CRYPTO_CIPHERTEXTBYTES = 402;
    if (isCompressed)
    {
      this.CRYPTO_SECRETKEYBYTES = 407U;
      this.CRYPTO_PUBLICKEYBYTES = 225U;
      this.CRYPTO_CIPHERTEXTBYTES = 280;
    }
    this.NWORDS_FIELD = 8U;
    this.PRIME_ZERO_WORDS = 3U;
    this.NBITS_FIELD = 503U;
    this.MAXBITS_FIELD = 512U /*0x0200*/;
    this.MAXWORDS_FIELD = (uint) ((int) this.MAXBITS_FIELD + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_FIELD = (this.NBITS_FIELD + 63U /*0x3F*/) / 64U /*0x40*/;
    this.NBITS_ORDER = 256U /*0x0100*/;
    this.NWORDS_ORDER = (uint) ((int) this.NBITS_ORDER + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_ORDER = (this.NBITS_ORDER + 63U /*0x3F*/) / 64U /*0x40*/;
    this.MAXBITS_ORDER = this.NBITS_ORDER;
    this.ALICE = 0U;
    this.BOB = 1U;
    this.OALICE_BITS = 250U;
    this.OBOB_BITS = 253U;
    this.OBOB_EXPON = 159U;
    this.MASK_ALICE = 3U;
    this.MASK_BOB = 15U;
    this.PARAM_A = 6U;
    this.PARAM_C = 1U;
    this.MAX_INT_POINTS_ALICE = 7U;
    this.MAX_INT_POINTS_BOB = 8U;
    this.MAX_Alice = 125U;
    this.MAX_Bob = 159U;
    this.MSG_BYTES = 24U;
    this.SECRETKEY_A_BYTES = (this.OALICE_BITS + 7U) / 8U;
    this.SECRETKEY_B_BYTES = (uint) ((int) this.OBOB_BITS - 1 + 7) / 8U;
    this.FP2_ENCODED_BYTES = 2U * ((this.NBITS_FIELD + 7U) / 8U);
    this.PRIME = new ulong[8]
    {
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      12393906174523604991UL,
      1371447078966912928UL,
      1989455001339985327UL,
      6937169319750509776UL,
      18127602061483550UL
    };
    this.PRIMEx2 = new ulong[8]
    {
      18446744073709551614UL,
      ulong.MaxValue,
      ulong.MaxValue,
      6341068275337658367UL,
      2742894157933825857UL,
      3978910002679970654UL,
      13874338639501019552UL,
      36255204122967100UL
    };
    this.PRIMEx4 = new ulong[8]
    {
      18446744073709551612UL,
      ulong.MaxValue,
      ulong.MaxValue,
      12682136550675316735UL /*0xAFFFFFFFFFFFFFFF*/,
      5485788315867651714UL,
      7957820005359941308UL,
      9301933205292487488UL,
      72510408245934201UL
    };
    this.PRIMEp1 = new ulong[8]
    {
      0UL,
      0UL,
      0UL,
      12393906174523604992UL /*0xAC00000000000000*/,
      1371447078966912928UL,
      1989455001339985327UL,
      6937169319750509776UL,
      18127602061483550UL
    };
    this.PRIMEp1x64 = new ulong[4]
    {
      13985636759044220971UL,
      16644655643501751236UL,
      1256978695003386886UL,
      1160166531934947224UL
    };
    this.PRIMEx16p = new ulong[16 /*0x10*/]
    {
      16UL /*0x10*/,
      0UL,
      0UL,
      9223372036854775808UL /*0x8000000000000000*/,
      11453925694187441130UL,
      10124416251958675997UL,
      17818254726207858172UL,
      3527199594194418739UL,
      1469206208402633719UL,
      16125476666494931876UL,
      3713841762384630283UL,
      5732158007287747578UL,
      16015846162495051931UL,
      13616710210549735357UL,
      5867348778409282426UL,
      285023702989702UL
    };
    this.Alice_order = new ulong[4]
    {
      0UL,
      0UL,
      0UL,
      288230376151711744UL /*0x0400000000000000*/
    };
    this.Bob_order = new ulong[4]
    {
      13985636759044220971UL,
      16644655643501751236UL,
      1256978695003386886UL,
      1160166531934947224UL
    };
    this.A_gen = new ulong[48 /*0x30*/]
    {
      6703660896400103571UL,
      12537332160849053239UL,
      3678485159306027873UL,
      17353623398657820066UL,
      2873992082182551772UL,
      7171536194148839865UL,
      10181624625838804804UL,
      16352189888232255UL,
      9094247284453741849UL,
      15253039841833755244UL,
      13880693959290797529UL,
      18392215330245950546UL,
      15398807590945265407UL,
      1922054504381246808UL,
      17050426384711021178UL,
      7612225463883843UL,
      5585423759613901741UL,
      2458739554285137871UL,
      8711841994324700402UL,
      7897112202292909028UL,
      5786141083180541608UL,
      17280526905686863908UL,
      14661266504429629391UL,
      4594121609494003UL,
      969679319129173575UL,
      16094612563470158573UL,
      13288942754001159038UL,
      9883757633938792291UL,
      11495715571241890913UL,
      9379070488088296136UL,
      16918015978071401965UL,
      1716330900454016UL,
      2133917679667870743UL,
      6131595433662066731UL,
      4132892201466249495UL,
      4243264721812232392UL,
      6868906156409292872UL,
      17926026206927608938UL,
      15578721314078959076UL,
      12061138545445877UL,
      14152221740469333595UL,
      8869864843183837084UL,
      9745375904961687712UL,
      13481433594105150145UL,
      11621254945640950360UL,
      9850236505881797121UL,
      3990273888349394775UL,
      1829864135412729UL
    };
    this.B_gen = new ulong[48 /*0x30*/]
    {
      16096726836148725979UL,
      14054702278015845390UL,
      4385548945328509436UL,
      17675320158140042461UL,
      4241169154243281967UL,
      9391123633589229008UL,
      7121043649763917783UL,
      8110065236168021UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      3329382374260773473UL,
      3539711558809017592UL,
      6589269349358072822UL,
      3923158083819410753UL,
      13173389878972436303UL,
      1859160943325703733UL,
      17652416194769656287UL,
      15124960556656395UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      3317107392457288018UL,
      15204737728010292594UL,
      2378317285299659333UL,
      2752067541212454492UL,
      5401008318620329606UL,
      14961513289750612371UL,
      17521159050955881097UL,
      3869545957505286UL,
      279293490929988356UL,
      11042087747279613526UL,
      9241719920557877023UL,
      1152299110578731394UL,
      16538596947068471601UL,
      1402013848611896279UL,
      564564276466162271UL,
      16163713578947404UL
    };
    this.Montgomery_R2 = new ulong[8]
    {
      5947461595517747487UL,
      11207248842288190137UL,
      11795883816894656890UL,
      6612826553991653612UL,
      11408068157014623267UL,
      13801731633100576405UL,
      5109635575176285622UL,
      17852757024708465UL
    };
    this.Montgomery_one = new ulong[8]
    {
      1017UL,
      0UL,
      0UL,
      12970366926827028480UL /*0xB400000000000000*/,
      7190870292575474356UL,
      5866111745285600125UL,
      10001782044489826626UL,
      10972777180780883UL
    };
    this.strat_Alice = new uint[124]
    {
      61U,
      32U /*0x20*/,
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
      29U,
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
      1U
    };
    this.strat_Bob = new uint[158]
    {
      71U,
      38U,
      21U,
      13U,
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
      1U
    };
    if (!this.COMPRESS)
      return;
    this.MASK2_BOB = 3U;
    this.MASK3_BOB = (uint) byte.MaxValue;
    this.ORDER_A_ENCODED_BYTES = this.SECRETKEY_A_BYTES;
    this.ORDER_B_ENCODED_BYTES = this.SECRETKEY_B_BYTES;
    this.PARTIALLY_COMPRESSED_CHUNK_CT = (uint) (4 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.COMPRESSED_CHUNK_CT = (uint) (3 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.UNCOMPRESSEDPK_BYTES = 378U;
    this.TABLE_R_LEN = 17U;
    this.TABLE_V_LEN = 34U;
    this.TABLE_V3_LEN = 20U;
    this.W_2 = 5U;
    this.W_3 = 3U;
    this.ELL2_W = 1U << (int) this.W_2;
    this.ELL3_W = 27U;
    this.ELL2_EMODW = 1U << (int) (this.OALICE_BITS % this.W_2);
    this.ELL3_EMODW = 1U;
    this.DLEN_2 = (uint) ((int) this.OALICE_BITS + (int) this.W_2 - 1) / this.W_2;
    this.DLEN_3 = (uint) ((int) this.OBOB_EXPON + (int) this.W_3 - 1) / this.W_3;
    this.PLEN_2 = 51U;
    this.PLEN_3 = 54U;
    Dictionary<string, string> props = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (P503).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p503.bz2"))
    {
      using (StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(manifestResourceStream)))
      {
        string str1 = streamReader.ReadLine();
        int num = 0;
        for (; str1 != null; str1 = streamReader.ReadLine())
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
    this.Montgomery_R2 = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_R2", this.NWORDS64_FIELD);
    this.Montgomery_RB1 = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_RB1", this.NWORDS64_FIELD);
    this.Montgomery_RB2 = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_RB2", this.NWORDS64_FIELD);
    this.Montgomery_one = Internal.ReadFromProperty((IDictionary<string, string>) props, "Montgomery_one", this.NWORDS64_FIELD);
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
    this.ph3_T = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph3_T", (uint) ((int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.Montgomery_R = new ulong[(int) this.NWORDS64_FIELD];
    this.ph3_T1 = new ulong[(int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2 * (int) this.NWORDS64_FIELD];
    this.ph3_T2 = new ulong[(int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2 * (int) this.NWORDS64_FIELD];
    this.ph2_T1 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
    this.ph2_T2 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
  }
}
