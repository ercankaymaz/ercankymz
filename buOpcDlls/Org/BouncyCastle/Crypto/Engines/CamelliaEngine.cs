// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.CamelliaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class CamelliaEngine : IBlockCipher
{
  private bool initialised;
  private bool _keyIs128;
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private uint[] subkey = new uint[96 /*0x60*/];
  private uint[] kw = new uint[8];
  private uint[] ke = new uint[12];
  private static readonly uint[] SIGMA = new uint[12]
  {
    2694735487U,
    1003262091U,
    3061508184U,
    1286239154U,
    3337565999U,
    3914302142U,
    1426019237U,
    4057165596U,
    283453434U,
    3731369245U,
    2958461122U,
    3018244605U
  };
  private static readonly uint[] SBOX1_1110 = new uint[256 /*0x0100*/]
  {
    1886416896U /*0x70707000*/,
    2189591040U,
    741092352U,
    3974949888U,
    3014898432U,
    656877312U,
    3233857536U /*0xC0C0C000*/,
    3857048832U,
    3840205824U,
    2240120064U,
    1465341696U,
    892679424U,
    3941263872U,
    202116096U /*0x0C0C0C00*/,
    2930683392U,
    1094795520U,
    589505280U,
    4025478912U,
    1802201856U,
    2475922176U,
    1162167552U,
    421075200U,
    2779096320U,
    555819264U,
    3991792896U,
    235802112U /*0x0E0E0E00*/,
    1330597632U,
    1313754624U,
    488447232U,
    1701143808U,
    2459079168U,
    3183328512U,
    2256963072U,
    3099113472U,
    2947526400U,
    2408550144U,
    2088532992U,
    3958106880U,
    522133248U,
    3469659648U,
    1044266496U,
    808464384U /*0x30303000*/,
    3705461760U,
    1600085760U,
    1583242752U,
    3318072576U,
    185273088U /*0x0B0B0B00*/,
    437918208U,
    2795939328U,
    3789676800U,
    960051456U,
    3402287616U,
    3587560704U,
    1195853568U,
    1566399744U,
    1027423488U,
    3654932736U,
    16843008U /*0x01010100*/,
    1515870720U,
    3604403712U,
    1364283648U,
    1448498688U,
    1819044864U,
    1296911616U,
    2341178112U,
    218959104U /*0x0D0D0D00*/,
    2593823232U,
    1717986816U,
    4227595008U,
    3435973632U,
    2964369408U /*0xB0B0B000*/,
    757935360U,
    1953788928U,
    303174144U,
    724249344U,
    538976256U /*0x20202000*/,
    4042321920U /*0xF0F0F000*/,
    2981212416U,
    2223277056U,
    2576980224U,
    3755990784U,
    1280068608U,
    3419130624U,
    3267543552U,
    875836416U,
    2122219008U,
    1987474944U,
    84215040U /*0x05050500*/,
    1835887872U,
    3082270464U,
    2846468352U,
    825307392U,
    3520188672U,
    387389184U,
    67372032U /*0x04040400*/,
    3621246720U,
    336860160U,
    1482184704U,
    976894464U,
    1633771776U,
    3739147776U,
    454761216U,
    286331136U,
    471604224U,
    842150400U,
    252645120U /*0x0F0F0F00*/,
    2627509248U,
    370546176U,
    1397969664U,
    404232192U,
    4076007936U,
    572662272U,
    4278124032U,
    1145324544U,
    3486502656U,
    2998055424U,
    3284386560U,
    3048584448U,
    2054846976U,
    2442236160U,
    606348288U,
    134744064U /*0x08080800*/,
    3907577856U,
    2829625344U,
    1616928768U /*0x60606000*/,
    4244438016U,
    1768515840U,
    1347440640U /*0x50505000*/,
    2863311360U,
    3503345664U /*0xD0D0D000*/,
    2694881280U /*0xA0A0A000*/,
    2105376000U,
    2711724288U,
    2307492096U,
    1650614784U,
    2543294208U,
    1414812672U,
    1532713728U,
    505290240U,
    2509608192U,
    3772833792U /*0xE0E0E000*/,
    4294967040U,
    1684300800U,
    3537031680U,
    269488128U /*0x10101000*/,
    3301229568U,
    0U,
    1212696576U,
    2745410304U,
    4160222976U,
    1970631936U,
    3688618752U,
    2324335104U,
    50529024U /*0x03030300*/,
    3873891840U,
    3671775744U,
    151587072U /*0x09090900*/,
    1061109504U,
    3722304768U,
    2492765184U,
    2273806080U,
    1549556736U,
    2206434048U,
    33686016U /*0x02020200*/,
    3452816640U,
    1246382592U,
    2425393152U /*0x90909000*/,
    858993408U,
    1936945920U,
    1734829824U,
    4143379968U,
    4092850944U,
    2644352256U,
    2139062016U,
    3217014528U,
    3806519808U,
    1381126656U,
    2610666240U,
    3638089728U,
    640034304U,
    3368601600U,
    926365440U,
    3334915584U,
    993737472U,
    2172748032U,
    2526451200U,
    1869573888U,
    1263225600U,
    320017152U,
    3200171520U,
    1667457792U,
    774778368U,
    3924420864U,
    2038003968U,
    2812782336U,
    2358021120U,
    2678038272U,
    1852730880U,
    3166485504U,
    2391707136U,
    690563328U,
    4126536960U,
    4193908992U,
    3065427456U,
    791621376U,
    4261281024U,
    3031741440U,
    1499027712U,
    2021160960U,
    2560137216U,
    101058048U /*0x06060600*/,
    1785358848U,
    3890734848U,
    1179010560U,
    1903259904U,
    3132799488U,
    3570717696U,
    623191296U,
    2880154368U,
    1111638528U,
    2290649088U,
    2728567296U,
    2374864128U,
    4210752000U,
    1920102912U,
    117901056U /*0x07070700*/,
    3115956480U,
    1431655680U,
    4177065984U,
    4008635904U,
    2896997376U,
    168430080U /*0x0A0A0A00*/,
    909522432U,
    1229539584U,
    707406336U,
    1751672832U,
    1010580480U,
    943208448U,
    4059164928U,
    2762253312U,
    1077952512U /*0x40404000*/,
    673720320U,
    3553874688U,
    2071689984U,
    3149642496U,
    3385444608U,
    1128481536U,
    3250700544U,
    353703168U,
    3823362816U,
    2913840384U,
    4109693952U,
    2004317952U,
    3351758592U,
    2155905024U /*0x80808000*/,
    2661195264U
  };
  private static readonly uint[] SBOX4_4404 = new uint[256 /*0x0100*/]
  {
    1886388336U /*0x70700070*/,
    741081132U,
    3014852787U,
    3233808576U /*0xC0C000C0*/,
    3840147684U,
    1465319511U,
    3941204202U,
    2930639022U,
    589496355U,
    1802174571U,
    1162149957U,
    2779054245U,
    3991732461U,
    1330577487U,
    488439837U,
    2459041938U,
    2256928902U,
    2947481775U,
    2088501372U,
    522125343U,
    1044250686U,
    3705405660U,
    1583218782U,
    185270283U /*0x0B0B000B*/,
    2795896998U,
    960036921U,
    3587506389U,
    1566376029U,
    3654877401U,
    1515847770U,
    1364262993U,
    1819017324U,
    2341142667U,
    2593783962U,
    4227531003U,
    2964324528U /*0xB0B000B0*/,
    1953759348U,
    724238379U,
    4042260720U /*0xF0F000F0*/,
    2223243396U,
    3755933919U,
    3419078859U,
    875823156U,
    1987444854U,
    1835860077U,
    2846425257U,
    3520135377U,
    67371012U /*0x04040004*/,
    336855060U,
    976879674U,
    3739091166U,
    286326801U,
    842137650U,
    2627469468U,
    1397948499U,
    4075946226U,
    4278059262U,
    3486449871U,
    3284336835U,
    2054815866U,
    606339108U,
    3907518696U,
    1616904288U /*0x60600060*/,
    1768489065U,
    2863268010U,
    2694840480U /*0xA0A000A0*/,
    2711683233U,
    1650589794U,
    1414791252U,
    505282590U,
    3772776672U /*0xE0E000E0*/,
    1684275300U,
    269484048U /*0x10100010*/,
    0U,
    2745368739U,
    1970602101U,
    2324299914U,
    3873833190U,
    151584777U /*0x09090009*/,
    3722248413U,
    2273771655U,
    2206400643U,
    3452764365U,
    2425356432U /*0x90900090*/,
    1936916595U,
    4143317238U,
    2644312221U,
    3216965823U,
    1381105746U,
    3638034648U,
    3368550600U,
    3334865094U,
    2172715137U,
    1869545583U,
    320012307U,
    1667432547U,
    3924361449U,
    2812739751U,
    2677997727U,
    3166437564U,
    690552873U,
    4193845497U,
    791609391U,
    3031695540U,
    2021130360U,
    101056518U /*0x06060006*/,
    3890675943U,
    1903231089U,
    3570663636U,
    2880110763U,
    2290614408U,
    2374828173U,
    1920073842U,
    3115909305U,
    4177002744U,
    2896953516U,
    909508662U,
    707395626U,
    1010565180U,
    4059103473U,
    1077936192U /*0x40400040*/,
    3553820883U,
    3149594811U,
    1128464451U,
    353697813U,
    2913796269U,
    2004287607U,
    2155872384U /*0x80800080*/,
    2189557890U,
    3974889708U,
    656867367U,
    3856990437U,
    2240086149U,
    892665909U,
    202113036U /*0x0C0C000C*/,
    1094778945U,
    4025417967U,
    2475884691U,
    421068825U,
    555810849U,
    235798542U /*0x0E0E000E*/,
    1313734734U,
    1701118053U,
    3183280317U,
    3099066552U,
    2408513679U,
    3958046955U,
    3469607118U,
    808452144U /*0x30300030*/,
    1600061535U,
    3318022341U,
    437911578U,
    3789619425U,
    3402236106U,
    1195835463U,
    1027407933U,
    16842753U /*0x01010001*/,
    3604349142U,
    1448476758U,
    1296891981U,
    218955789U /*0x0D0D000D*/,
    1717960806U,
    3435921612U,
    757923885U,
    303169554U,
    538968096U /*0x20200020*/,
    2981167281U,
    2576941209U,
    1280049228U,
    3267494082U,
    2122186878U,
    84213765U /*0x05050005*/,
    3082223799U,
    825294897U,
    387383319U,
    3621191895U,
    1482162264U,
    1633747041U,
    454754331U,
    471597084U,
    252641295U /*0x0F0F000F*/,
    370540566U,
    404226072U,
    572653602U,
    1145307204U,
    2998010034U,
    3048538293U,
    2442199185U,
    134742024U /*0x08080008*/,
    2829582504U,
    4244373756U,
    1347420240U /*0x50500050*/,
    3503292624U /*0xD0D000D0*/,
    2105344125U,
    2307457161U,
    2543255703U,
    1532690523U,
    2509570197U,
    4294902015U,
    3536978130U,
    3301179588U,
    1212678216U,
    4160159991U,
    3688562907U,
    50528259U /*0x03030003*/,
    3671720154U,
    1061093439U,
    2492727444U,
    1549533276U,
    33685506U /*0x02020002*/,
    1246363722U,
    858980403U,
    1734803559U,
    4092788979U,
    2139029631U,
    3806462178U,
    2610626715U,
    640024614U,
    926351415U,
    993722427U,
    2526412950U,
    1263206475U,
    3200123070U,
    774766638U,
    2037973113U,
    2357985420U,
    1852702830U,
    2391670926U,
    4126474485U,
    3065381046U,
    4261216509U,
    1499005017U,
    2560098456U,
    1785331818U,
    1178992710U,
    3132752058U,
    623181861U,
    1111621698U,
    2728525986U,
    4210688250U,
    117899271U /*0x07070007*/,
    1431634005U,
    4008575214U,
    168427530U /*0x0A0A000A*/,
    1229520969U,
    1751646312U,
    943194168U,
    2762211492U,
    673710120U,
    2071658619U,
    3385393353U,
    3250651329U,
    3823304931U,
    4109631732U,
    3351707847U,
    2661154974U
  };
  private static readonly uint[] SBOX2_0222 = new uint[256 /*0x0100*/]
  {
    14737632U /*0xE0E0E0*/,
    328965U,
    5789784U /*0x585858*/,
    14277081U /*0xD9D9D9*/,
    6776679U /*0x676767*/,
    5131854U /*0x4E4E4E*/,
    8487297U /*0x818181*/,
    13355979U /*0xCBCBCB*/,
    13224393U /*0xC9C9C9*/,
    723723U,
    11447982U /*0xAEAEAE*/,
    6974058U /*0x6A6A6A*/,
    14013909U /*0xD5D5D5*/,
    1579032U /*0x181818*/,
    6118749U /*0x5D5D5D*/,
    8553090U /*0x828282*/,
    4605510U /*0x464646*/,
    14671839U /*0xDFDFDF*/,
    14079702U /*0xD6D6D6*/,
    2565927U /*0x272727*/,
    9079434U /*0x8A8A8A*/,
    3289650U /*0x323232*/,
    4934475U /*0x4B4B4B*/,
    4342338U /*0x424242*/,
    14408667U /*0xDBDBDB*/,
    1842204U /*0x1C1C1C*/,
    10395294U /*0x9E9E9E*/,
    10263708U /*0x9C9C9C*/,
    3815994U /*0x3A3A3A*/,
    13290186U /*0xCACACA*/,
    2434341U /*0x252525*/,
    8092539U /*0x7B7B7B*/,
    855309U,
    7434609U /*0x717171*/,
    6250335U /*0x5F5F5F*/,
    2039583U /*0x1F1F1F*/,
    16316664U /*0xF8F8F8*/,
    14145495U /*0xD7D7D7*/,
    4079166U /*0x3E3E3E*/,
    10329501U /*0x9D9D9D*/,
    8158332U /*0x7C7C7C*/,
    6316128U /*0x606060*/,
    12171705U /*0xB9B9B9*/,
    12500670U /*0xBEBEBE*/,
    12369084U /*0xBCBCBC*/,
    9145227U /*0x8B8B8B*/,
    1447446U /*0x161616*/,
    3421236U /*0x343434*/,
    5066061U /*0x4D4D4D*/,
    12829635U /*0xC3C3C3*/,
    7500402U /*0x727272*/,
    9803157U /*0x959595*/,
    11250603U /*0xABABAB*/,
    9342606U /*0x8E8E8E*/,
    12237498U /*0xBABABA*/,
    8026746U /*0x7A7A7A*/,
    11776947U /*0xB3B3B3*/,
    131586U,
    11842740U /*0xB4B4B4*/,
    11382189U /*0xADADAD*/,
    10658466U /*0xA2A2A2*/,
    11316396U /*0xACACAC*/,
    14211288U /*0xD8D8D8*/,
    10132122U /*0x9A9A9A*/,
    1513239U /*0x171717*/,
    1710618U /*0x1A1A1A*/,
    3487029U /*0x353535*/,
    13421772U /*0xCCCCCC*/,
    16250871U /*0xF7F7F7*/,
    10066329U /*0x999999*/,
    6381921U /*0x616161*/,
    5921370U /*0x5A5A5A*/,
    15263976U /*0xE8E8E8*/,
    2368548U /*0x242424*/,
    5658198U /*0x565656*/,
    4210752U /*0x404040*/,
    14803425U /*0xE1E1E1*/,
    6513507U /*0x636363*/,
    592137U,
    3355443U /*0x333333*/,
    12566463U /*0xBFBFBF*/,
    10000536U /*0x989898*/,
    9934743U /*0x979797*/,
    8750469U /*0x858585*/,
    6842472U /*0x686868*/,
    16579836U /*0xFCFCFC*/,
    15527148U /*0xECECEC*/,
    657930U,
    14342874U /*0xDADADA*/,
    7303023U /*0x6F6F6F*/,
    5460819U /*0x535353*/,
    6447714U /*0x626262*/,
    10724259U /*0xA3A3A3*/,
    3026478U /*0x2E2E2E*/,
    526344U,
    11513775U /*0xAFAFAF*/,
    2631720U /*0x282828*/,
    11579568U /*0xB0B0B0*/,
    7631988U /*0x747474*/,
    12763842U /*0xC2C2C2*/,
    12434877U /*0xBDBDBD*/,
    3552822U /*0x363636*/,
    2236962U /*0x222222*/,
    3684408U /*0x383838*/,
    6579300U /*0x646464*/,
    1973790U /*0x1E1E1E*/,
    3750201U /*0x393939*/,
    2894892U /*0x2C2C2C*/,
    10921638U /*0xA6A6A6*/,
    3158064U /*0x303030*/,
    15066597U /*0xE5E5E5*/,
    4473924U /*0x444444*/,
    16645629U /*0xFDFDFD*/,
    8947848U /*0x888888*/,
    10461087U /*0x9F9F9F*/,
    6645093U /*0x656565*/,
    8882055U /*0x878787*/,
    7039851U /*0x6B6B6B*/,
    16053492U /*0xF4F4F4*/,
    2302755U /*0x232323*/,
    4737096U /*0x484848*/,
    1052688U /*0x101010*/,
    13750737U /*0xD1D1D1*/,
    5329233U /*0x515151*/,
    12632256U /*0xC0C0C0*/,
    16382457U /*0xF9F9F9*/,
    13816530U /*0xD2D2D2*/,
    10526880U /*0xA0A0A0*/,
    5592405U /*0x555555*/,
    10592673U /*0xA1A1A1*/,
    4276545U /*0x414141*/,
    16448250U /*0xFAFAFA*/,
    4408131U /*0x434343*/,
    1250067U /*0x131313*/,
    12895428U /*0xC4C4C4*/,
    3092271U /*0x2F2F2F*/,
    11053224U /*0xA8A8A8*/,
    11974326U /*0xB6B6B6*/,
    3947580U /*0x3C3C3C*/,
    2829099U /*0x2B2B2B*/,
    12698049U /*0xC1C1C1*/,
    16777215U /*0xFFFFFF*/,
    13158600U /*0xC8C8C8*/,
    10855845U /*0xA5A5A5*/,
    2105376U /*0x202020*/,
    9013641U /*0x898989*/,
    0U,
    9474192U /*0x909090*/,
    4671303U /*0x474747*/,
    15724527U /*0xEFEFEF*/,
    15395562U /*0xEAEAEA*/,
    12040119U /*0xB7B7B7*/,
    1381653U /*0x151515*/,
    394758U,
    13487565U /*0xCDCDCD*/,
    11908533U /*0xB5B5B5*/,
    1184274U /*0x121212*/,
    8289918U /*0x7E7E7E*/,
    12303291U /*0xBBBBBB*/,
    2697513U /*0x292929*/,
    986895U,
    12105912U /*0xB8B8B8*/,
    460551U,
    263172U,
    10197915U /*0x9B9B9B*/,
    9737364U /*0x949494*/,
    2171169U /*0x212121*/,
    6710886U /*0x666666*/,
    15132390U /*0xE6E6E6*/,
    13553358U /*0xCECECE*/,
    15592941U /*0xEDEDED*/,
    15198183U /*0xE7E7E7*/,
    3881787U /*0x3B3B3B*/,
    16711422U /*0xFEFEFE*/,
    8355711U /*0x7F7F7F*/,
    12961221U /*0xC5C5C5*/,
    10790052U /*0xA4A4A4*/,
    3618615U /*0x373737*/,
    11645361U /*0xB1B1B1*/,
    5000268U /*0x4C4C4C*/,
    9539985U /*0x919191*/,
    7237230U /*0x6E6E6E*/,
    9276813U /*0x8D8D8D*/,
    7763574U /*0x767676*/,
    197379U,
    2960685U /*0x2D2D2D*/,
    14606046U /*0xDEDEDE*/,
    9868950U /*0x969696*/,
    2500134U /*0x262626*/,
    8224125U /*0x7D7D7D*/,
    13027014U /*0xC6C6C6*/,
    6052956U /*0x5C5C5C*/,
    13882323U /*0xD3D3D3*/,
    15921906U /*0xF2F2F2*/,
    5197647U /*0x4F4F4F*/,
    1644825U /*0x191919*/,
    4144959U /*0x3F3F3F*/,
    14474460U /*0xDCDCDC*/,
    7960953U /*0x797979*/,
    1907997U /*0x1D1D1D*/,
    5395026U /*0x525252*/,
    15461355U /*0xEBEBEB*/,
    15987699U /*0xF3F3F3*/,
    7171437U /*0x6D6D6D*/,
    6184542U /*0x5E5E5E*/,
    16514043U /*0xFBFBFB*/,
    6908265U /*0x696969*/,
    11711154U /*0xB2B2B2*/,
    15790320U /*0xF0F0F0*/,
    3223857U /*0x313131*/,
    789516U,
    13948116U /*0xD4D4D4*/,
    13619151U /*0xCFCFCF*/,
    9211020U /*0x8C8C8C*/,
    14869218U /*0xE2E2E2*/,
    7697781U /*0x757575*/,
    11119017U /*0xA9A9A9*/,
    4868682U /*0x4A4A4A*/,
    5723991U /*0x575757*/,
    8684676U /*0x848484*/,
    1118481U /*0x111111*/,
    4539717U /*0x454545*/,
    1776411U /*0x1B1B1B*/,
    16119285U /*0xF5F5F5*/,
    15000804U /*0xE4E4E4*/,
    921102U,
    7566195U /*0x737373*/,
    11184810U /*0xAAAAAA*/,
    15856113U /*0xF1F1F1*/,
    14540253U /*0xDDDDDD*/,
    5855577U /*0x595959*/,
    1315860U /*0x141414*/,
    7105644U /*0x6C6C6C*/,
    9605778U /*0x929292*/,
    5526612U /*0x545454*/,
    13684944U /*0xD0D0D0*/,
    7895160U /*0x787878*/,
    7368816U /*0x707070*/,
    14935011U /*0xE3E3E3*/,
    4802889U /*0x494949*/,
    8421504U /*0x808080*/,
    5263440U /*0x505050*/,
    10987431U /*0xA7A7A7*/,
    16185078U /*0xF6F6F6*/,
    7829367U /*0x777777*/,
    9671571U /*0x939393*/,
    8816262U /*0x868686*/,
    8618883U /*0x838383*/,
    2763306U /*0x2A2A2A*/,
    13092807U /*0xC7C7C7*/,
    5987163U /*0x5B5B5B*/,
    15329769U /*0xE9E9E9*/,
    15658734U /*0xEEEEEE*/,
    9408399U /*0x8F8F8F*/,
    65793U,
    4013373U /*0x3D3D3D*/
  };
  private static readonly uint[] SBOX3_3033 = new uint[256 /*0x0100*/]
  {
    939538488U,
    1090535745U,
    369104406U,
    1979741814U,
    3640711641U,
    2466288531U,
    1610637408U /*0x60006060*/,
    4060148466U,
    1912631922U,
    3254829762U,
    2868947883U,
    2583730842U,
    1962964341U,
    100664838U /*0x06000606*/,
    1459640151U,
    2684395680U /*0xA000A0A0*/,
    2432733585U,
    4144035831U,
    3036722613U,
    3372272073U,
    2717950626U,
    2348846220U,
    3523269330U,
    2415956112U /*0x90009090*/,
    4127258358U,
    117442311U /*0x07000707*/,
    2801837991U,
    654321447U,
    2382401166U,
    2986390194U,
    1224755529U,
    3724599006U,
    1124090691U,
    1543527516U,
    3607156695U,
    3338717127U,
    1040203326U,
    4110480885U,
    2399178639U,
    1728079719U,
    520101663U,
    402659352U,
    1845522030U,
    2936057775U,
    788541231U,
    3791708898U,
    2231403909U,
    218107149U /*0x0D000D0D*/,
    1392530259U,
    4026593520U /*0xF000F0F0*/,
    2617285788U,
    1694524773U,
    3925928682U,
    2734728099U,
    2919280302U,
    2650840734U,
    3959483628U,
    2147516544U /*0x80008080*/,
    754986285U,
    1795189611U,
    2818615464U,
    721431339U,
    905983542U,
    2785060518U,
    3305162181U,
    2248181382U,
    1291865421U,
    855651123U,
    4244700669U,
    1711302246U,
    1476417624U,
    2516620950U,
    973093434U,
    150997257U /*0x09000909*/,
    2499843477U,
    268439568U /*0x10001010*/,
    2013296760U,
    3623934168U,
    1107313218U,
    3422604492U,
    4009816047U,
    637543974U,
    3842041317U,
    1627414881U,
    436214298U,
    1056980799U,
    989870907U,
    2181071490U,
    3053500086U,
    3674266587U,
    3556824276U,
    2550175896U,
    3892373736U,
    2332068747U,
    33554946U /*0x02000202*/,
    3942706155U,
    167774730U /*0x0A000A0A*/,
    738208812U,
    486546717U,
    2952835248U /*0xB000B0B0*/,
    1862299503U,
    2365623693U,
    2281736328U,
    234884622U /*0x0E000E0E*/,
    419436825U,
    2264958855U,
    1308642894U,
    184552203U /*0x0B000B0B*/,
    2835392937U,
    201329676U /*0x0C000C0C*/,
    2030074233U,
    285217041U,
    2130739071U,
    570434082U,
    3875596263U,
    1493195097U,
    3774931425U,
    3657489114U,
    1023425853U,
    3355494600U,
    301994514U,
    67109892U /*0x04000404*/,
    1946186868U,
    1409307732U,
    805318704U /*0x30003030*/,
    2113961598U,
    3019945140U,
    671098920U,
    1426085205U,
    1744857192U,
    1342197840U /*0x50005050*/,
    3187719870U,
    3489714384U /*0xD000D0D0*/,
    3288384708U,
    822096177U,
    3405827019U,
    704653866U,
    2902502829U,
    251662095U /*0x0F000F0F*/,
    3389049546U,
    1879076976U /*0x70007070*/,
    4278255615U,
    838873650U,
    1761634665U,
    134219784U /*0x08000808*/,
    1644192354U,
    0U,
    603989028U,
    3506491857U,
    4211145723U,
    3120609978U,
    3976261101U,
    1157645637U,
    2164294017U,
    1929409395U,
    1828744557U,
    2214626436U,
    2667618207U,
    3993038574U,
    1241533002U,
    3271607235U,
    771763758U,
    3238052289U,
    16777473U /*0x01000101*/,
    3858818790U,
    620766501U,
    1207978056U,
    2566953369U,
    3103832505U,
    3003167667U,
    2063629179U,
    4177590777U,
    3456159438U,
    3204497343U,
    3741376479U,
    1895854449U,
    687876393U,
    3439381965U,
    1811967084U,
    318771987U,
    1677747300U,
    2600508315U,
    1660969827U,
    2634063261U,
    3221274816U /*0xC000C0C0*/,
    1258310475U,
    3070277559U,
    2768283045U,
    2298513801U,
    1593859935U,
    2969612721U,
    385881879U,
    4093703412U,
    3154164924U,
    3540046803U,
    1174423110U,
    3472936911U,
    922761015U,
    1577082462U,
    1191200583U,
    2483066004U,
    4194368250U,
    4227923196U,
    1526750043U,
    2533398423U,
    4261478142U,
    1509972570U,
    2885725356U,
    1006648380U,
    1275087948U,
    50332419U /*0x03000303*/,
    889206069U,
    4076925939U,
    587211555U,
    3087055032U,
    1560304989U,
    1778412138U,
    2449511058U,
    3573601749U,
    553656609U,
    1140868164U,
    1358975313U,
    3321939654U,
    2097184125U,
    956315961U,
    2197848963U,
    3691044060U,
    2852170410U,
    2080406652U,
    1996519287U,
    1442862678U,
    83887365U /*0x05000505*/,
    452991771U,
    2751505572U,
    352326933U,
    872428596U,
    503324190U,
    469769244U,
    4160813304U,
    1375752786U,
    536879136U /*0x20002020*/,
    335549460U,
    3909151209U,
    3170942397U,
    3707821533U,
    3825263844U,
    2701173153U,
    3758153952U /*0xE000E0E0*/,
    2315291274U,
    4043370993U,
    3590379222U,
    2046851706U,
    3137387451U,
    3808486371U,
    1073758272U /*0x40004040*/,
    1325420367U
  };

  private static uint rightRotate(uint x, int s) => (x >> s) + (x << 32 /*0x20*/ - s);

  private static uint leftRotate(uint x, int s) => (x << s) + (x >> 32 /*0x20*/ - s);

  private static void roldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[ooff] = ki[ioff] << rot | ki[1 + ioff] >> 32 /*0x20*/ - rot;
    ko[1 + ooff] = ki[1 + ioff] << rot | ki[2 + ioff] >> 32 /*0x20*/ - rot;
    ko[2 + ooff] = ki[2 + ioff] << rot | ki[3 + ioff] >> 32 /*0x20*/ - rot;
    ko[3 + ooff] = ki[3 + ioff] << rot | ki[ioff] >> 32 /*0x20*/ - rot;
    ki[ioff] = ko[ooff];
    ki[1 + ioff] = ko[1 + ooff];
    ki[2 + ioff] = ko[2 + ooff];
    ki[3 + ioff] = ko[3 + ooff];
  }

  private static void decroldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[2 + ooff] = ki[ioff] << rot | ki[1 + ioff] >> 32 /*0x20*/ - rot;
    ko[3 + ooff] = ki[1 + ioff] << rot | ki[2 + ioff] >> 32 /*0x20*/ - rot;
    ko[ooff] = ki[2 + ioff] << rot | ki[3 + ioff] >> 32 /*0x20*/ - rot;
    ko[1 + ooff] = ki[3 + ioff] << rot | ki[ioff] >> 32 /*0x20*/ - rot;
    ki[ioff] = ko[2 + ooff];
    ki[1 + ioff] = ko[3 + ooff];
    ki[2 + ioff] = ko[ooff];
    ki[3 + ioff] = ko[1 + ooff];
  }

  private static void roldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[ooff] = ki[1 + ioff] << rot - 32 /*0x20*/ | ki[2 + ioff] >> 64 /*0x40*/ - rot;
    ko[1 + ooff] = ki[2 + ioff] << rot - 32 /*0x20*/ | ki[3 + ioff] >> 64 /*0x40*/ - rot;
    ko[2 + ooff] = ki[3 + ioff] << rot - 32 /*0x20*/ | ki[ioff] >> 64 /*0x40*/ - rot;
    ko[3 + ooff] = ki[ioff] << rot - 32 /*0x20*/ | ki[1 + ioff] >> 64 /*0x40*/ - rot;
    ki[ioff] = ko[ooff];
    ki[1 + ioff] = ko[1 + ooff];
    ki[2 + ioff] = ko[2 + ooff];
    ki[3 + ioff] = ko[3 + ooff];
  }

  private static void decroldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
  {
    ko[2 + ooff] = ki[1 + ioff] << rot - 32 /*0x20*/ | ki[2 + ioff] >> 64 /*0x40*/ - rot;
    ko[3 + ooff] = ki[2 + ioff] << rot - 32 /*0x20*/ | ki[3 + ioff] >> 64 /*0x40*/ - rot;
    ko[ooff] = ki[3 + ioff] << rot - 32 /*0x20*/ | ki[ioff] >> 64 /*0x40*/ - rot;
    ko[1 + ooff] = ki[ioff] << rot - 32 /*0x20*/ | ki[1 + ioff] >> 64 /*0x40*/ - rot;
    ki[ioff] = ko[2 + ooff];
    ki[1 + ioff] = ko[3 + ooff];
    ki[2 + ioff] = ko[ooff];
    ki[3 + ioff] = ko[1 + ooff];
  }

  private static void camelliaF2(uint[] s, uint[] skey, int keyoff)
  {
    uint index1 = s[0] ^ skey[keyoff];
    uint x1 = CamelliaEngine.SBOX4_4404[(int) (byte) index1] ^ CamelliaEngine.SBOX3_3033[(int) (byte) (index1 >> 8)] ^ CamelliaEngine.SBOX2_0222[(int) (byte) (index1 >> 16 /*0x10*/)] ^ CamelliaEngine.SBOX1_1110[(int) (byte) (index1 >> 24)];
    uint index2 = s[1] ^ skey[1 + keyoff];
    uint num1 = CamelliaEngine.SBOX1_1110[(int) (byte) index2] ^ CamelliaEngine.SBOX4_4404[(int) (byte) (index2 >> 8)] ^ CamelliaEngine.SBOX3_3033[(int) (byte) (index2 >> 16 /*0x10*/)] ^ CamelliaEngine.SBOX2_0222[(int) (byte) (index2 >> 24)];
    s[2] ^= x1 ^ num1;
    s[3] ^= x1 ^ num1 ^ CamelliaEngine.rightRotate(x1, 8);
    uint index3 = s[2] ^ skey[2 + keyoff];
    uint x2 = CamelliaEngine.SBOX4_4404[(int) (byte) index3] ^ CamelliaEngine.SBOX3_3033[(int) (byte) (index3 >> 8)] ^ CamelliaEngine.SBOX2_0222[(int) (byte) (index3 >> 16 /*0x10*/)] ^ CamelliaEngine.SBOX1_1110[(int) (byte) (index3 >> 24)];
    uint index4 = s[3] ^ skey[3 + keyoff];
    uint num2 = CamelliaEngine.SBOX1_1110[(int) (byte) index4] ^ CamelliaEngine.SBOX4_4404[(int) (byte) (index4 >> 8)] ^ CamelliaEngine.SBOX3_3033[(int) (byte) (index4 >> 16 /*0x10*/)] ^ CamelliaEngine.SBOX2_0222[(int) (byte) (index4 >> 24)];
    s[0] ^= x2 ^ num2;
    s[1] ^= x2 ^ num2 ^ CamelliaEngine.rightRotate(x2, 8);
  }

  private static void camelliaFLs(uint[] s, uint[] fkey, int keyoff)
  {
    s[1] ^= CamelliaEngine.leftRotate(s[0] & fkey[keyoff], 1);
    s[0] ^= fkey[1 + keyoff] | s[1];
    s[2] ^= fkey[3 + keyoff] | s[3];
    s[3] ^= CamelliaEngine.leftRotate(fkey[2 + keyoff] & s[2], 1);
  }

  private void setKey(bool forEncryption, byte[] key)
  {
    uint[] numArray1 = new uint[8];
    uint[] numArray2 = new uint[4];
    uint[] numArray3 = new uint[4];
    uint[] ko = new uint[4];
    switch (key.Length)
    {
      case 16 /*0x10*/:
        this._keyIs128 = true;
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 4);
        uint[] numArray4 = numArray1;
        uint[] numArray5 = numArray1;
        uint[] numArray6 = numArray1;
        numArray1[7] = 0U;
        numArray6[6] = 0U;
        numArray5[5] = 0U;
        numArray4[4] = 0U;
        break;
      case 24:
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 6);
        numArray1[6] = ~numArray1[4];
        numArray1[7] = ~numArray1[5];
        this._keyIs128 = false;
        break;
      case 32 /*0x20*/:
        Pack.BE_To_UInt32(key, 0, numArray1, 0, 8);
        this._keyIs128 = false;
        break;
      default:
        throw new ArgumentException("key sizes are only 16/24/32 bytes.");
    }
    for (int index = 0; index < 4; ++index)
      numArray2[index] = numArray1[index] ^ numArray1[index + 4];
    CamelliaEngine.camelliaF2(numArray2, CamelliaEngine.SIGMA, 0);
    for (int index = 0; index < 4; ++index)
      numArray2[index] ^= numArray1[index];
    CamelliaEngine.camelliaF2(numArray2, CamelliaEngine.SIGMA, 4);
    if (this._keyIs128)
    {
      if (forEncryption)
      {
        this.kw[0] = numArray1[0];
        this.kw[1] = numArray1[1];
        this.kw[2] = numArray1[2];
        this.kw[3] = numArray1[3];
        CamelliaEngine.roldq(15, numArray1, 0, this.subkey, 4);
        CamelliaEngine.roldq(30, numArray1, 0, this.subkey, 12);
        CamelliaEngine.roldq(15, numArray1, 0, ko, 0);
        this.subkey[18] = ko[2];
        this.subkey[19] = ko[3];
        CamelliaEngine.roldq(17, numArray1, 0, this.ke, 4);
        CamelliaEngine.roldq(17, numArray1, 0, this.subkey, 24);
        CamelliaEngine.roldq(17, numArray1, 0, this.subkey, 32 /*0x20*/);
        this.subkey[0] = numArray2[0];
        this.subkey[1] = numArray2[1];
        this.subkey[2] = numArray2[2];
        this.subkey[3] = numArray2[3];
        CamelliaEngine.roldq(15, numArray2, 0, this.subkey, 8);
        CamelliaEngine.roldq(15, numArray2, 0, this.ke, 0);
        CamelliaEngine.roldq(15, numArray2, 0, ko, 0);
        this.subkey[16 /*0x10*/] = ko[0];
        this.subkey[17] = ko[1];
        CamelliaEngine.roldq(15, numArray2, 0, this.subkey, 20);
        CamelliaEngine.roldqo32(34, numArray2, 0, this.subkey, 28);
        CamelliaEngine.roldq(17, numArray2, 0, this.kw, 4);
      }
      else
      {
        this.kw[4] = numArray1[0];
        this.kw[5] = numArray1[1];
        this.kw[6] = numArray1[2];
        this.kw[7] = numArray1[3];
        CamelliaEngine.decroldq(15, numArray1, 0, this.subkey, 28);
        CamelliaEngine.decroldq(30, numArray1, 0, this.subkey, 20);
        CamelliaEngine.decroldq(15, numArray1, 0, ko, 0);
        this.subkey[16 /*0x10*/] = ko[0];
        this.subkey[17] = ko[1];
        CamelliaEngine.decroldq(17, numArray1, 0, this.ke, 0);
        CamelliaEngine.decroldq(17, numArray1, 0, this.subkey, 8);
        CamelliaEngine.decroldq(17, numArray1, 0, this.subkey, 0);
        this.subkey[34] = numArray2[0];
        this.subkey[35] = numArray2[1];
        this.subkey[32 /*0x20*/] = numArray2[2];
        this.subkey[33] = numArray2[3];
        CamelliaEngine.decroldq(15, numArray2, 0, this.subkey, 24);
        CamelliaEngine.decroldq(15, numArray2, 0, this.ke, 4);
        CamelliaEngine.decroldq(15, numArray2, 0, ko, 0);
        this.subkey[18] = ko[2];
        this.subkey[19] = ko[3];
        CamelliaEngine.decroldq(15, numArray2, 0, this.subkey, 12);
        CamelliaEngine.decroldqo32(34, numArray2, 0, this.subkey, 4);
        CamelliaEngine.roldq(17, numArray2, 0, this.kw, 0);
      }
    }
    else
    {
      for (int index = 0; index < 4; ++index)
        numArray3[index] = numArray2[index] ^ numArray1[index + 4];
      CamelliaEngine.camelliaF2(numArray3, CamelliaEngine.SIGMA, 8);
      if (forEncryption)
      {
        this.kw[0] = numArray1[0];
        this.kw[1] = numArray1[1];
        this.kw[2] = numArray1[2];
        this.kw[3] = numArray1[3];
        CamelliaEngine.roldqo32(45, numArray1, 0, this.subkey, 16 /*0x10*/);
        CamelliaEngine.roldq(15, numArray1, 0, this.ke, 4);
        CamelliaEngine.roldq(17, numArray1, 0, this.subkey, 32 /*0x20*/);
        CamelliaEngine.roldqo32(34, numArray1, 0, this.subkey, 44);
        CamelliaEngine.roldq(15, numArray1, 4, this.subkey, 4);
        CamelliaEngine.roldq(15, numArray1, 4, this.ke, 0);
        CamelliaEngine.roldq(30, numArray1, 4, this.subkey, 24);
        CamelliaEngine.roldqo32(34, numArray1, 4, this.subkey, 36);
        CamelliaEngine.roldq(15, numArray2, 0, this.subkey, 8);
        CamelliaEngine.roldq(30, numArray2, 0, this.subkey, 20);
        this.ke[8] = numArray2[1];
        this.ke[9] = numArray2[2];
        this.ke[10] = numArray2[3];
        this.ke[11] = numArray2[0];
        CamelliaEngine.roldqo32(49, numArray2, 0, this.subkey, 40);
        this.subkey[0] = numArray3[0];
        this.subkey[1] = numArray3[1];
        this.subkey[2] = numArray3[2];
        this.subkey[3] = numArray3[3];
        CamelliaEngine.roldq(30, numArray3, 0, this.subkey, 12);
        CamelliaEngine.roldq(30, numArray3, 0, this.subkey, 28);
        CamelliaEngine.roldqo32(51, numArray3, 0, this.kw, 4);
      }
      else
      {
        this.kw[4] = numArray1[0];
        this.kw[5] = numArray1[1];
        this.kw[6] = numArray1[2];
        this.kw[7] = numArray1[3];
        CamelliaEngine.decroldqo32(45, numArray1, 0, this.subkey, 28);
        CamelliaEngine.decroldq(15, numArray1, 0, this.ke, 4);
        CamelliaEngine.decroldq(17, numArray1, 0, this.subkey, 12);
        CamelliaEngine.decroldqo32(34, numArray1, 0, this.subkey, 0);
        CamelliaEngine.decroldq(15, numArray1, 4, this.subkey, 40);
        CamelliaEngine.decroldq(15, numArray1, 4, this.ke, 8);
        CamelliaEngine.decroldq(30, numArray1, 4, this.subkey, 20);
        CamelliaEngine.decroldqo32(34, numArray1, 4, this.subkey, 8);
        CamelliaEngine.decroldq(15, numArray2, 0, this.subkey, 36);
        CamelliaEngine.decroldq(30, numArray2, 0, this.subkey, 24);
        this.ke[2] = numArray2[1];
        this.ke[3] = numArray2[2];
        this.ke[0] = numArray2[3];
        this.ke[1] = numArray2[0];
        CamelliaEngine.decroldqo32(49, numArray2, 0, this.subkey, 4);
        this.subkey[46] = numArray3[0];
        this.subkey[47] = numArray3[1];
        this.subkey[44] = numArray3[2];
        this.subkey[45] = numArray3[3];
        CamelliaEngine.decroldq(30, numArray3, 0, this.subkey, 32 /*0x20*/);
        CamelliaEngine.decroldq(30, numArray3, 0, this.subkey, 16 /*0x10*/);
        CamelliaEngine.roldqo32(51, numArray3, 0, this.kw, 0);
      }
    }
  }

  private int ProcessBlock128(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint[] s = new uint[4];
    for (int index = 0; index < 4; ++index)
      s[index] = Pack.BE_To_UInt32(input, inOff + index * 4) ^ this.kw[index];
    CamelliaEngine.camelliaF2(s, this.subkey, 0);
    CamelliaEngine.camelliaF2(s, this.subkey, 4);
    CamelliaEngine.camelliaF2(s, this.subkey, 8);
    CamelliaEngine.camelliaFLs(s, this.ke, 0);
    CamelliaEngine.camelliaF2(s, this.subkey, 12);
    CamelliaEngine.camelliaF2(s, this.subkey, 16 /*0x10*/);
    CamelliaEngine.camelliaF2(s, this.subkey, 20);
    CamelliaEngine.camelliaFLs(s, this.ke, 4);
    CamelliaEngine.camelliaF2(s, this.subkey, 24);
    CamelliaEngine.camelliaF2(s, this.subkey, 28);
    CamelliaEngine.camelliaF2(s, this.subkey, 32 /*0x20*/);
    Pack.UInt32_To_BE(s[2] ^ this.kw[4], output, outOff);
    Pack.UInt32_To_BE(s[3] ^ this.kw[5], output, outOff + 4);
    Pack.UInt32_To_BE(s[0] ^ this.kw[6], output, outOff + 8);
    Pack.UInt32_To_BE(s[1] ^ this.kw[7], output, outOff + 12);
    return 16 /*0x10*/;
  }

  private int ProcessBlock192or256(byte[] input, int inOff, byte[] output, int outOff)
  {
    uint[] s = new uint[4];
    for (int index = 0; index < 4; ++index)
      s[index] = Pack.BE_To_UInt32(input, inOff + index * 4) ^ this.kw[index];
    CamelliaEngine.camelliaF2(s, this.subkey, 0);
    CamelliaEngine.camelliaF2(s, this.subkey, 4);
    CamelliaEngine.camelliaF2(s, this.subkey, 8);
    CamelliaEngine.camelliaFLs(s, this.ke, 0);
    CamelliaEngine.camelliaF2(s, this.subkey, 12);
    CamelliaEngine.camelliaF2(s, this.subkey, 16 /*0x10*/);
    CamelliaEngine.camelliaF2(s, this.subkey, 20);
    CamelliaEngine.camelliaFLs(s, this.ke, 4);
    CamelliaEngine.camelliaF2(s, this.subkey, 24);
    CamelliaEngine.camelliaF2(s, this.subkey, 28);
    CamelliaEngine.camelliaF2(s, this.subkey, 32 /*0x20*/);
    CamelliaEngine.camelliaFLs(s, this.ke, 8);
    CamelliaEngine.camelliaF2(s, this.subkey, 36);
    CamelliaEngine.camelliaF2(s, this.subkey, 40);
    CamelliaEngine.camelliaF2(s, this.subkey, 44);
    Pack.UInt32_To_BE(s[2] ^ this.kw[4], output, outOff);
    Pack.UInt32_To_BE(s[3] ^ this.kw[5], output, outOff + 4);
    Pack.UInt32_To_BE(s[0] ^ this.kw[6], output, outOff + 8);
    Pack.UInt32_To_BE(s[1] ^ this.kw[7], output, outOff + 12);
    return 16 /*0x10*/;
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("only simple KeyParameter expected.");
    this.setKey(forEncryption, ((KeyParameter) parameters).GetKey());
    this.initialised = true;
  }

  public virtual string AlgorithmName => "Camellia";

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException("Camellia engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 16 /*0x10*/, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    return this._keyIs128 ? this.ProcessBlock128(input, inOff, output, outOff) : this.ProcessBlock192or256(input, inOff, output, outOff);
  }
}
