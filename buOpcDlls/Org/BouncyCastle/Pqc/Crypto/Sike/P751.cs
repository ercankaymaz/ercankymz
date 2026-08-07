// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.P751
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO.Compression;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P751 : Internal
{
  internal P751(bool isCompressed)
  {
    this.COMPRESS = isCompressed;
    this.CRYPTO_SECRETKEYBYTES = 644U;
    this.CRYPTO_PUBLICKEYBYTES = 564U;
    this.CRYPTO_BYTES = 32U /*0x20*/;
    this.CRYPTO_CIPHERTEXTBYTES = 596;
    if (isCompressed)
    {
      this.CRYPTO_SECRETKEYBYTES = 602U;
      this.CRYPTO_PUBLICKEYBYTES = 335U;
      this.CRYPTO_CIPHERTEXTBYTES = 410;
    }
    this.NWORDS_FIELD = 12U;
    this.PRIME_ZERO_WORDS = 5U;
    this.NBITS_FIELD = 751U;
    this.MAXBITS_FIELD = 768U /*0x0300*/;
    this.MAXWORDS_FIELD = (uint) ((int) this.MAXBITS_FIELD + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_FIELD = (this.NBITS_FIELD + 63U /*0x3F*/) / 64U /*0x40*/;
    this.NBITS_ORDER = 384U;
    this.NWORDS_ORDER = (uint) ((int) this.NBITS_ORDER + (int) Internal.RADIX - 1) / Internal.RADIX;
    this.NWORDS64_ORDER = (this.NBITS_ORDER + 63U /*0x3F*/) / 64U /*0x40*/;
    this.MAXBITS_ORDER = this.NBITS_ORDER;
    this.ALICE = 0U;
    this.BOB = 1U;
    this.OALICE_BITS = 372U;
    this.OBOB_BITS = 379U;
    this.OBOB_EXPON = 239U;
    this.MASK_ALICE = 15U;
    this.MASK_BOB = 3U;
    this.PARAM_A = 6U;
    this.PARAM_C = 1U;
    this.MAX_INT_POINTS_ALICE = 8U;
    this.MAX_INT_POINTS_BOB = 10U;
    this.MAX_Alice = 186U;
    this.MAX_Bob = 239U;
    this.MSG_BYTES = 32U /*0x20*/;
    this.SECRETKEY_A_BYTES = (this.OALICE_BITS + 7U) / 8U;
    this.SECRETKEY_B_BYTES = (uint) ((int) this.OBOB_BITS - 1 + 7) / 8U;
    this.FP2_ENCODED_BYTES = 2U * ((this.NBITS_FIELD + 7U) / 8U);
    this.PRIME = new ulong[12]
    {
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      17199246976927924223UL,
      16423667440329193640UL,
      15750665808104639606UL,
      598583372241692790UL,
      9611443585101748040UL,
      1014031881231588454UL,
      123032916064028UL
    };
    this.PRIMEx2 = new ulong[12]
    {
      18446744073709551614UL,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      15951749880146296831UL,
      14400590806948835665UL,
      13054587542499727597UL,
      1197166744483385581UL,
      776143096493944464UL,
      2028063762463176909UL,
      246065832128056UL
    };
    this.PRIMEx4 = new ulong[12]
    {
      18446744073709551612UL,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      ulong.MaxValue,
      13456755686583042047UL,
      10354437540188119715UL,
      7662431011289903579UL,
      2394333488966771163UL,
      1552286192987888928UL,
      4056127524926353818UL,
      492131664256112UL
    };
    this.PRIMEp1 = new ulong[12]
    {
      0UL,
      0UL,
      0UL,
      0UL,
      0UL,
      17199246976927924224UL /*0xEEB0000000000000*/,
      16423667440329193640UL,
      15750665808104639606UL,
      598583372241692790UL,
      9611443585101748040UL,
      1014031881231588454UL,
      123032916064028UL
    };
    this.PRIMEx16p = new ulong[24]
    {
      16UL /*0x10*/,
      0UL,
      0UL,
      0UL,
      0UL,
      3026418949592973312UL /*0x2A00000000000000*/,
      9398220047042800354UL,
      12487528204518977827UL,
      17738820235684933924UL,
      6028454529806440190UL,
      4444467948008272687UL,
      6389925372342901886UL,
      9183714343363691506UL,
      5885816994991374139UL,
      15511269745733968757UL,
      6605506351970878676UL,
      11826827898049043624UL,
      2354645367770068943UL,
      4229001520684072827UL,
      8116152847571104894UL,
      5904732737952813393UL,
      12541849493931687641UL,
      16092533092944000694UL,
      13129340006UL
    };
    ulong[] numArray = new ulong[6];
    numArray[5] = 4503599627370496UL /*0x10000000000000*/;
    this.Alice_order = numArray;
    this.Bob_order = new ulong[6]
    {
      14512942843351961323UL,
      6463124234301828670UL,
      16827274972312858025UL,
      3121071280576823428UL,
      2957168939937196118UL,
      503942824198258913UL
    };
    this.A_gen = new ulong[72]
    {
      9822147065185090216UL,
      13425902357697129504UL,
      13938563312470237261UL,
      586935199814300635UL,
      1231476659462315650UL,
      15200349552625419408UL,
      7720484030924475341UL,
      10594672674827951252UL,
      16258160073680417295UL,
      9900115913593791836UL,
      2594594101592586405UL,
      16460334914570UL,
      12589684371389518740UL,
      12332659108360031092UL,
      16510385560356170993UL,
      9730777839585202459UL,
      17903424488311508735UL,
      5769280992065803964UL,
      5532188670625076987UL,
      16579944219273134793UL,
      11273833143932675593UL,
      14491979851476136262UL,
      9207655709386969385UL,
      36625983307955UL,
      1122465274781142185UL,
      8515870630345178839UL,
      16522000615137270631UL,
      10711565273514878189UL,
      15314004285403374021UL,
      4840703288083784924UL,
      13590004812123635944UL,
      12882217991877249059UL,
      17191071062736800731UL,
      8865126078528016748UL,
      3693150086021936691UL,
      36658777259884UL,
      17077429180071124812UL,
      18158079048006766323UL,
      1672925350903708369UL,
      13862967679991471090UL,
      2382796300166624212UL,
      13977248558483123863UL,
      2278800419424555458UL,
      118108782222142818UL,
      1476285485934066847UL,
      16034197662737970158UL,
      2038060998052304781UL,
      107394058694173UL,
      1585483835096717809UL,
      11931875557452383223UL,
      7781638337591394101UL,
      6664888135375272208UL,
      2840823194606539793UL,
      12795682130246575520UL,
      2611282525231902794UL,
      6070226513535983789UL,
      14818409522906275305UL,
      15252419596163003285UL,
      7824800416788242299UL,
      58455551134839UL,
      11203073095899037416UL,
      15794937577346159166UL,
      2745271787383434087UL,
      11641405899540905191UL,
      10870594127288654381UL,
      11105192472711036386UL,
      14727745195886210467UL,
      1375411507907286301UL,
      14178291107140140658UL,
      5435466916003927824UL,
      8796316040578972826UL,
      31328095521215UL
    };
    this.B_gen = new ulong[72]
    {
      9613244219595815052UL,
      8392675302948378161UL,
      9147551389475264226UL,
      10681340829511687623UL,
      1891166766906289442UL,
      8726784965380087145UL,
      278069042628663236UL,
      321051512772386179UL,
      4418794039415165171UL,
      811238939992429693UL,
      11875834369919409703UL,
      56397746590099UL,
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
      0UL,
      0UL,
      10267279138215760704UL,
      15455480150741085920UL,
      18292544765444947000UL,
      601370936378187550UL,
      15472156581712037259UL,
      5596913087184264637UL,
      5895422123728360424UL,
      16546858821940167717UL,
      10412066657013232056UL,
      5132030994927125788UL,
      3098590566816827475UL,
      44009130331453UL,
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
      0UL,
      0UL,
      13070667682173250844UL,
      278885298517689489UL,
      16120934674390684754UL,
      12236545707274815619UL,
      9611450916420723852UL,
      2637748658071451261UL,
      3544807444712948572UL,
      16213618612546618337UL,
      16912673257488186033UL,
      13195093391319151071UL,
      17886130922126146806UL,
      59505860712722UL,
      6397758586429206260UL,
      9338639848856234571UL,
      4403427314326644353UL,
      10612695944165988144UL,
      11149562808784569047UL,
      16467442628418687666UL,
      15521226430153318UL,
      3328537178486072741UL,
      17900197353359942647UL,
      10368784128223943932UL,
      18031568085834724987UL,
      115645459333053UL
    };
    this.Montgomery_R2 = new ulong[12]
    {
      2535603850726686808UL,
      15780896088201250090UL,
      6788776303855402382UL,
      17585428585582356230UL,
      5274503137951975249UL,
      2266259624764636289UL,
      11695651972693921304UL,
      13072885652150159301UL,
      4908312795585420432UL,
      6229583484603254826UL,
      488927695601805643UL,
      72213483953973UL
    };
    this.Montgomery_one = new ulong[12]
    {
      149933UL,
      0UL,
      0UL,
      0UL,
      0UL,
      9444048418595930112UL /*0x8310000000000000*/,
      6136068611055053926UL,
      7599709743867700432UL,
      14455912356952952366UL,
      5522737203492907350UL,
      1222606818372667369UL,
      49869481633250UL
    };
    this.strat_Alice = new uint[185]
    {
      80U /*0x50*/,
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
      33U,
      20U,
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
      8U,
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
    this.strat_Bob = new uint[238]
    {
      112U /*0x70*/,
      63U /*0x3F*/,
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
      31U /*0x1F*/,
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
      49U,
      31U /*0x1F*/,
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
      21U,
      12U,
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
    if (!this.COMPRESS)
      return;
    this.MASK2_BOB = 0U;
    this.MASK3_BOB = (uint) byte.MaxValue;
    this.ORDER_A_ENCODED_BYTES = this.SECRETKEY_A_BYTES;
    this.ORDER_B_ENCODED_BYTES = this.SECRETKEY_B_BYTES;
    this.PARTIALLY_COMPRESSED_CHUNK_CT = (uint) (4 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.COMPRESSED_CHUNK_CT = (uint) (3 * (int) this.ORDER_A_ENCODED_BYTES + (int) this.FP2_ENCODED_BYTES + 2);
    this.UNCOMPRESSEDPK_BYTES = 564U;
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
    this.PLEN_2 = 94U;
    this.PLEN_3 = 81U;
    Dictionary<string, string> props = new Dictionary<string, string>();
    using (Stream manifestResourceStream = typeof (P751).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p751.bz2"))
    {
      using (StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(manifestResourceStream)))
      {
        string str1 = streamReader.ReadLine();
        int num = 0;
        while (str1 != null)
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
          }
          str1 = streamReader.ReadLine();
          ++num;
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
    this.ph3_T1 = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph3_T1", (uint) ((int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.ph3_T2 = Internal.ReadFromProperty((IDictionary<string, string>) props, "ph3_T2", (uint) ((int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2) * this.NWORDS64_FIELD);
    this.Montgomery_R = new ulong[(int) this.NWORDS64_FIELD];
    this.ph2_T1 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
    this.ph2_T2 = new ulong[2 * (((int) this.DLEN_2 - 1) * (int) (this.ELL2_W / 2U) + ((int) this.ph2_path[(int) this.PLEN_2 - 1] - 1))];
    this.ph3_T = new ulong[(int) this.DLEN_3 * (int) (this.ELL3_W >> 1) * 2 * (int) this.NWORDS64_FIELD];
  }
}
