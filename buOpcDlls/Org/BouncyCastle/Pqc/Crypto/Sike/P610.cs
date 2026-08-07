// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.P610
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P610 : Internal
{
  internal P610(bool isCompressed)
  {
    this.COMPRESS = isCompressed;
    this.CRYPTO_SECRETKEYBYTES = 524U;
    this.CRYPTO_PUBLICKEYBYTES = 462U;
    this.CRYPTO_BYTES = 24U;
    this.CRYPTO_CIPHERTEXTBYTES = 486;
    if (isCompressed)
    {
      this.CRYPTO_SECRETKEYBYTES = 491U;
      this.CRYPTO_PUBLICKEYBYTES = 274U;
      this.CRYPTO_CIPHERTEXTBYTES = 336;
    }
    this.NWORDS_FIELD = 10U;
    this.PRIME_ZERO_WORDS = 4U;
    this.NBITS_FIELD = 610U;
    this.MAXBITS_FIELD = 640U;
    this.MAXWORDS_FIELD = (uint) ((int) this.MAXBITS_FIELD + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_FIELD = (this.NBITS_FIELD + 63U /*0x3F*/) / 64U /*0x40*/;
    this.NBITS_ORDER = 320U;
    this.NWORDS_ORDER = (uint) ((int) this.NBITS_ORDER + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_ORDER = (this.NBITS_ORDER + 63U /*0x3F*/) / 64U /*0x40*/;
    this.MAXBITS_ORDER = this.NBITS_ORDER;
    this.ALICE = 0U;
    this.BOB = 1U;
    this.OALICE_BITS = 305U;
    this.OBOB_BITS = 305U;
    this.OBOB_EXPON = 192U /*0xC0*/;
    this.MASK_ALICE = 1U;
    this.MASK_BOB = (uint) byte.MaxValue;
    this.PARAM_A = 6U;
    this.PARAM_C = 1U;
    this.MAX_INT_POINTS_ALICE = 8U;
    this.MAX_INT_POINTS_BOB = 10U;
    this.MAX_Alice = 152U;
    this.MAX_Bob = 192U /*0xC0*/;
    this.MSG_BYTES = 24U;
    this.SECRETKEY_A_BYTES = (this.OALICE_BITS + 7U) / 8U;
    this.SECRETKEY_B_BYTES = (uint) ((int) this.OBOB_BITS - 1 + 7) / 8U;
    this.FP2_ENCODED_BYTES = 2U * ((this.NBITS_FIELD + 7U) / 8U);
    this.PRIME = new ulong[10]
    {
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      7926898294125494271UL,
      12788056803604344878UL,
      11162100504611256747UL,
      12850373898864436522UL,
      9335980454322886796UL,
      10669696872UL
    };
    this.PRIMEx2 = new ulong[10]
    {
      18446744073709551614UL,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      15853796588250988543UL,
      7129369533499138140UL,
      3877456935512961879UL,
      7254003724019321429UL,
      225216834936221977UL,
      21339393745UL
    };
    this.PRIMEx4 = new ulong[10]
    {
      18446744073709551612UL,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      13260849102792425471UL,
      14258739066998276281UL,
      7754913871025923758UL,
      14508007448038642858UL,
      450433669872443954UL,
      42678787490UL
    };
    this.PRIMEp1 = new ulong[10]
    {
      0UL,
      0UL,
      0UL,
      0UL,
      7926898294125494272UL /*0x6E02000000000000*/,
      12788056803604344878UL,
      11162100504611256747UL,
      12850373898864436522UL,
      9335980454322886796UL,
      10669696872UL
    };
    this.PRIMEx16p = new ulong[20]
    {
      16UL /*0x10*/,
      0UL,
      0UL,
      0UL,
      4593671619917905920UL /*0x3FC0000000000000*/,
      15057295979980651058UL,
      11747665326630816393UL,
      13063148931657718444UL,
      14843274714729999977UL,
      9213098133652443887UL,
      16184711284518687079UL,
      15152855274923543935UL,
      15339866525258615080UL,
      10917383248197352654UL,
      423414579105418765UL,
      10355422686146848012UL,
      17970659541427193412UL,
      4932507286707963453UL,
      13697982395128707963UL,
      98UL
    };
    this.Alice_order = new ulong[5]
    {
      0UL,
      0UL,
      0UL,
      0UL,
      562949953421312UL /*0x02000000000000*/
    };
    this.Bob_order = new ulong[5]
    {
      2806962120998467329UL,
      16114585662381217980UL,
      15671691495630785907UL,
      603808853150554410UL,
      349624627118280UL
    };
    this.A_gen = new ulong[60]
    {
      5771904529248994682UL,
      10009829002276161265UL,
      270330086766583390UL,
      6481898407746275289UL,
      7865854910092666580UL,
      15620069539765408586UL,
      10893576880820336051UL,
      9414097477218394383UL,
      5194719131280954495UL,
      1729770898UL,
      16481658151656772596UL,
      13633773755204448979UL,
      1977403254395278860UL,
      2726390535525409621UL,
      18198696508619478634UL,
      12992673620297984156UL,
      15585820391321559058UL,
      4095961562244124488UL,
      13529435761498453802UL,
      5102423139UL,
      2124736252400681868UL,
      11123746024777819577UL,
      2202127831239085027UL,
      15189163262449832501UL,
      4313963896834226850UL,
      13370300494042345640UL,
      4921946642166740880UL,
      14640789545148115673UL,
      15809041940818907362UL,
      7907518294UL,
      2200917311302176889UL,
      2939498022256786432UL,
      16162577001789154273UL,
      9557432669551130207UL,
      15389712118992921126UL,
      13586216826660735913UL,
      10514164377495492777UL,
      334500554730375393UL,
      6399318707077975086UL,
      8976719684UL,
      2746580562334225805UL,
      14004852227026191121UL,
      11466649160507921918UL,
      11799630227884196955UL,
      6714415832701611114UL,
      10112136743029452510UL,
      7010145936394111770UL,
      18042795605720766895UL,
      11307052907097731807UL,
      3478841981UL,
      13366757749870367424UL,
      3119472779256121459UL,
      4709779656408495164UL,
      16568419043672081405UL,
      14691179270073594708UL,
      5893360609436446022UL,
      6635037533545129430UL,
      5031143778661013925UL,
      2711723078310815363UL,
      10114015515UL
    };
    this.B_gen = new ulong[60]
    {
      14323946558550738106UL,
      2405435625630280597UL,
      14697550786434646162UL,
      15511184413509320248UL,
      7035179512456608727UL,
      17358557897062455236UL,
      2237320506219039519UL,
      14307448527707612354UL,
      16412911138814384653UL,
      5379123413UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      17692069297427191936UL,
      8155755975969367465UL,
      11338564383465294727UL,
      5678382275401384545UL,
      12501231795214209584UL,
      4726463275275376934UL,
      17083766455683877101UL,
      4479281637794437063UL,
      17540154893918510969UL,
      9074793307UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      8829176751768485847UL,
      4330345099806588278UL,
      6439066249656508832UL,
      17672114398665101563UL,
      12943163433490994938UL,
      9363570836893509813UL,
      16984122743018654352UL,
      9683040719332474896UL,
      16255205449832888349UL,
      9017845420UL,
      6790521807624498538UL,
      16155971635292829987UL,
      4283588130542979409UL,
      514645655039295889UL,
      8912678322428419353UL,
      6038404330050892853UL,
      17176157232408721930UL,
      9916604761775707332UL,
      910728456329037494UL,
      5513273805UL
    };
    this.Montgomery_R2 = new ulong[10]
    {
      16672146738007078695UL,
      16192790745003276590UL,
      7764610893679053117UL,
      15888490136859680965UL,
      8311396451547473226UL,
      9580492030289074780UL,
      9136860735727631175UL,
      14248068042486481075UL,
      8077651299688882586UL,
      2385055731UL
    };
    this.Montgomery_one = new ulong[10]
    {
      1728891110UL,
      0UL,
      0UL,
      0UL,
      11111506180629856256UL /*0x9A34000000000000*/,
      5591714530040314431UL,
      741431724485104668UL,
      15183360670812525026UL,
      1398651832995983165UL,
      4438944100UL
    };
    this.strat_Alice = new uint[151]
    {
      67U,
      37U,
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
      1U,
      16U /*0x10*/,
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
      16U /*0x10*/,
      8U,
      5U,
      2U,
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
    this.strat_Bob = new uint[191]
    {
      86U,
      48U /*0x30*/,
      27U,
      15U,
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
      1U,
      38U,
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
      1U
    };
    if (!this.COMPRESS)
      return;
    this.MASK2_BOB = 7U;
    this.MASK3_BOB = (uint) byte.MaxValue;
    this.ORDER_A_ENCODED_BYTES = this.SECRETKEY_A_BYTES;
    this.ORDER_B_ENCODED_BYTES = this.SECRETKEY_B_BYTES + 1U;
    this.PARTIALLY_COMPRESSED_CHUNK_CT = (uint) (4 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.COMPRESSED_CHUNK_CT = (uint) (3 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.UNCOMPRESSEDPK_BYTES = 480U;
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
    this.PLEN_2 = 62U;
    this.PLEN_3 = 65U;
    Dictionary<string, string> props = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (P610).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p610.bz2"))
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
