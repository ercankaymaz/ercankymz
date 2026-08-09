using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P434 : Internal
{
	internal P434(bool isCompressed)
	{
		COMPRESS = isCompressed;
		CRYPTO_SECRETKEYBYTES = 374u;
		CRYPTO_PUBLICKEYBYTES = 330u;
		CRYPTO_BYTES = 16u;
		CRYPTO_CIPHERTEXTBYTES = 346;
		if (isCompressed)
		{
			CRYPTO_SECRETKEYBYTES = 350u;
			CRYPTO_PUBLICKEYBYTES = 197u;
			CRYPTO_CIPHERTEXTBYTES = 236;
		}
		NWORDS_FIELD = 7u;
		PRIME_ZERO_WORDS = 3u;
		NBITS_FIELD = 434u;
		MAXBITS_FIELD = 448u;
		MAXWORDS_FIELD = (MAXBITS_FIELD + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_FIELD = (NBITS_FIELD + 63) / 64;
		NBITS_ORDER = 256u;
		NWORDS_ORDER = (NBITS_ORDER + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_ORDER = (NBITS_ORDER + 63) / 64;
		MAXBITS_ORDER = NBITS_ORDER;
		ALICE = 0u;
		BOB = 1u;
		OALICE_BITS = 216u;
		OBOB_BITS = 218u;
		OBOB_EXPON = 137u;
		MASK_ALICE = 255u;
		MASK_BOB = 1u;
		PARAM_A = 6u;
		PARAM_C = 1u;
		MAX_INT_POINTS_ALICE = 7u;
		MAX_INT_POINTS_BOB = 8u;
		MAX_Alice = 108u;
		MAX_Bob = 137u;
		MSG_BYTES = 16u;
		SECRETKEY_A_BYTES = (OALICE_BITS + 7) / 8;
		SECRETKEY_B_BYTES = (OBOB_BITS - 1 + 7) / 8;
		FP2_ENCODED_BYTES = 2 * ((NBITS_FIELD + 7) / 8);
		PRIME = new ulong[7] { 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 18285026232267440127uL, 8918917783347572387uL, 7853257225132122198uL, 620258357900100uL };
		PRIMEx2 = new ulong[7] { 18446744073709551614uL, 18446744073709551615uL, 18446744073709551615uL, 18123308390825328639uL, 17837835566695144775uL, 15706514450264244396uL, 1240516715800200uL };
		PRIMEx4 = new ulong[7] { 18446744073709551612uL, 18446744073709551615uL, 18446744073709551615uL, 17799872707941105663uL, 17228927059680737935uL, 12966284826818937177uL, 2481033431600401uL };
		PRIMEp1 = new ulong[7] { 0uL, 0uL, 0uL, 18285026232267440128uL, 8918917783347572387uL, 7853257225132122198uL, 620258357900100uL };
		PRIMEx16p = new ulong[14]
		{
			16uL, 0uL, 0uL, 5174970926147567616uL, 9742536112230509440uL, 6950185827705812272uL, 6073522028379477874uL, 14222146884144505874uL, 8299186480726035350uL, 7225369840861796773uL,
			2456441653404885428uL, 12555258408051429121uL, 1781491355331495958uL, 333691781277uL
		};
		Alice_order = new ulong[4] { 0uL, 0uL, 0uL, 16777216uL };
		Bob_order = new ulong[4] { 6390225231553133283uL, 14204448314335459377uL, 1689769520075363969uL, 36970279uL };
		A_gen = new ulong[42]
		{
			409251790387889599uL, 10489829510628224043uL, 12674510860217942615uL, 8135632727773423537uL, 17840997995551181005uL, 2414452085739184671uL, 11115521240260uL, 8395851790856910728uL, 2986355008512957707uL, 14652235704098559445uL,
			10149113683644317610uL, 12102338175217582495uL, 15452390807072906892uL, 281073067659850uL, 18358614117343242043uL, 15178862300246045126uL, 17939401953738004679uL, 16301132844359752451uL, 1973682341831588061uL, 8312799048378913301uL,
			497853136119926uL, 12515775166124391894uL, 7710088909771808848uL, 7498146198864584751uL, 2174778336782639988uL, 16347399334629616021uL, 12025936272585254152uL, 438485524985150uL, 124497379906645117uL, 3220114552465917457uL,
			2709773247140401691uL, 6980995868580086445uL, 4225536559282510125uL, 4701685901084574963uL, 609687130428995uL, 13307499667408479562uL, 17265918823005609453uL, 6350294504100107936uL, 8618087912213766372uL, 308885086986017528uL,
			15792880328099440610uL, 202858940514502uL
		};
		B_gen = new ulong[42]
		{
			7950145635403778211uL, 3053921039650069509uL, 16974511502399211645uL, 6369396808518798415uL, 13295737116337704235uL, 2507423554624419257uL, 491294718579999uL, 0uL, 0uL, 0uL,
			0uL, 0uL, 0uL, 0uL, 18078192145093323662uL, 5280595860558773788uL, 17229246200424940156uL, 5300724274592529762uL, 12685182915280535178uL, 17596270270016357247uL,
			57208989669550uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 2898969037767559396uL, 10522929125730281031uL,
			9073321008578907802uL, 7539793830764276893uL, 9328908741686588507uL, 148738643701593348uL, 139132528504375uL, 12932288373210664113uL, 7856701733796155952uL, 16996962201367356265uL, 3113577795642755667uL, 4926779461749210259uL,
			13761095186437813579uL, 408994988652499uL
		};
		Montgomery_R2 = new ulong[7] { 2946862024238734128uL, 12460461157234743490uL, 12332992403615082637uL, 1683438818023996427uL, 12379712300517307518uL, 7629496211932212634uL, 41406098690346uL };
		Montgomery_one = new ulong[7] { 29740uL, 0uL, 0uL, 13335145323912232960uL, 15564903186549419220uL, 16803585881028378892uL, 260509760564954uL };
		strat_Alice = new uint[107]
		{
			48u, 28u, 16u, 8u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 8u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u,
			2u, 1u, 1u, 13u, 7u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 3u, 2u, 1u, 1u, 1u, 1u, 5u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 2u, 1u, 1u, 1u,
			21u, 12u, 7u, 4u, 2u, 1u, 1u, 2u, 1u, 1u,
			3u, 2u, 1u, 1u, 1u, 1u, 5u, 3u, 2u, 1u,
			1u, 1u, 1u, 2u, 1u, 1u, 1u, 9u, 5u, 3u,
			2u, 1u, 1u, 1u, 1u, 2u, 1u, 1u, 1u, 4u,
			2u, 1u, 1u, 1u, 2u, 1u, 1u
		};
		strat_Bob = new uint[136]
		{
			66u, 33u, 17u, 9u, 5u, 3u, 2u, 1u, 1u, 1u,
			1u, 2u, 1u, 1u, 1u, 4u, 2u, 1u, 1u, 1u,
			2u, 1u, 1u, 8u, 4u, 2u, 1u, 1u, 1u, 2u,
			1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 16u,
			8u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 8u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 32u, 16u, 8u, 4u, 3u, 1u, 1u, 1u, 1u,
			2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u,
			8u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 4u, 2u,
			1u, 1u, 2u, 1u, 1u, 16u, 8u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 8u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u
		};
		if (!isCompressed)
		{
			return;
		}
		MASK2_BOB = 0u;
		MASK3_BOB = 127u;
		ORDER_A_ENCODED_BYTES = SECRETKEY_A_BYTES;
		ORDER_B_ENCODED_BYTES = SECRETKEY_B_BYTES;
		PARTIALLY_COMPRESSED_CHUNK_CT = 4 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		COMPRESSED_CHUNK_CT = 3 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		UNCOMPRESSEDPK_BYTES = 330u;
		TABLE_R_LEN = 17u;
		TABLE_V_LEN = 34u;
		TABLE_V3_LEN = 20u;
		W_2 = 4u;
		W_3 = 3u;
		ELL2_W = (uint)(1 << (int)W_2);
		ELL3_W = 27u;
		ELL2_EMODW = (uint)(1 << (int)(OALICE_BITS % W_2));
		ELL3_EMODW = 9u;
		DLEN_2 = (OALICE_BITS + W_2 - 1) / W_2;
		DLEN_3 = (OBOB_EXPON + W_3 - 1) / W_3;
		PLEN_2 = 55u;
		PLEN_3 = 47u;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		using (Stream stream = typeof(P434).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p434.bz2"))
		{
			using StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(stream));
			int num = 0;
			for (string text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
			{
				string text2 = text;
				if (text2 != "")
				{
					if (num > 1)
					{
						text2 = text2.Replace(",", "");
					}
					int num2 = text2.IndexOf('=');
					string key = text2.Substring(0, num2).Trim();
					string value = text2.Substring(num2 + 1).Trim();
					dictionary.Add(key, value);
					num++;
				}
			}
		}
		ph2_path = Internal.ReadIntsFromProperty(dictionary, "ph2_path", PLEN_2);
		ph3_path = Internal.ReadIntsFromProperty(dictionary, "ph3_path", PLEN_3);
		A_gen = Internal.ReadFromProperty(dictionary, "A_gen", 6 * NWORDS64_FIELD);
		B_gen = Internal.ReadFromProperty(dictionary, "B_gen", 6 * NWORDS64_FIELD);
		XQB3 = Internal.ReadFromProperty(dictionary, "XQB3", 2 * NWORDS64_FIELD);
		A_basis_zero = Internal.ReadFromProperty(dictionary, "A_basis_zero", 8 * NWORDS64_FIELD);
		B_basis_zero = Internal.ReadFromProperty(dictionary, "B_basis_zero", 8 * NWORDS64_FIELD);
		B_gen_3_tors = Internal.ReadFromProperty(dictionary, "B_gen_3_tors", 16 * NWORDS64_FIELD);
		g_R_S_im = Internal.ReadFromProperty(dictionary, "g_R_S_im", NWORDS64_FIELD);
		g_phiR_phiS_re = Internal.ReadFromProperty(dictionary, "g_phiR_phiS_re", NWORDS64_FIELD);
		g_phiR_phiS_im = Internal.ReadFromProperty(dictionary, "g_phiR_phiS_im", NWORDS64_FIELD);
		Montgomery_RB1 = Internal.ReadFromProperty(dictionary, "Montgomery_RB1", NWORDS64_FIELD);
		Montgomery_RB2 = Internal.ReadFromProperty(dictionary, "Montgomery_RB2", NWORDS64_FIELD);
		threeinv = Internal.ReadFromProperty(dictionary, "threeinv", NWORDS64_FIELD);
		u_entang = Internal.ReadFromProperty(dictionary, "u_entang", 2 * NWORDS64_FIELD);
		u0_entang = Internal.ReadFromProperty(dictionary, "u0_entang", 2 * NWORDS64_FIELD);
		table_r_qr = Internal.ReadFromProperty(dictionary, "table_r_qr", TABLE_R_LEN, NWORDS64_FIELD);
		table_r_qnr = Internal.ReadFromProperty(dictionary, "table_r_qnr", TABLE_R_LEN, NWORDS64_FIELD);
		table_v_qr = Internal.ReadFromProperty(dictionary, "table_v_qr", TABLE_V_LEN, NWORDS64_FIELD);
		table_v_qnr = Internal.ReadFromProperty(dictionary, "table_v_qnr", TABLE_V_LEN, NWORDS64_FIELD);
		v_3_torsion = Internal.ReadFromProperty(dictionary, "v_3_torsion", TABLE_V3_LEN, 2u, NWORDS64_FIELD);
		T_tate3 = Internal.ReadFromProperty(dictionary, "T_tate3", (6 * (OBOB_EXPON - 1) + 4) * NWORDS64_FIELD);
		T_tate2_firststep_P = Internal.ReadFromProperty(dictionary, "T_tate2_firststep_P", 4 * NWORDS64_FIELD);
		T_tate2_P = Internal.ReadFromProperty(dictionary, "T_tate2_P", 3 * (OALICE_BITS - 2) * NWORDS64_FIELD);
		T_tate2_firststep_Q = Internal.ReadFromProperty(dictionary, "T_tate2_firststep_Q", 4 * NWORDS64_FIELD);
		T_tate2_Q = Internal.ReadFromProperty(dictionary, "T_tate2_Q", 3 * (OALICE_BITS - 2) * NWORDS64_FIELD);
		ph2_T = Internal.ReadFromProperty(dictionary, "ph2_T", DLEN_2 * (ELL2_W >> 1) * 2 * NWORDS64_FIELD);
		ph3_T1 = Internal.ReadFromProperty(dictionary, "ph3_T1", DLEN_3 * (ELL3_W >> 1) * 2 * NWORDS64_FIELD);
		ph3_T2 = Internal.ReadFromProperty(dictionary, "ph3_T2", DLEN_3 * (ELL3_W >> 1) * 2 * NWORDS64_FIELD);
		ph2_T1 = new ulong[2 * ((DLEN_2 - 1) * (ELL2_W / 2) + (ph2_path[PLEN_2 - 1] - 1))];
		ph2_T2 = new ulong[2 * ((DLEN_2 - 1) * (ELL2_W / 2) + (ph2_path[PLEN_2 - 1] - 1))];
		ph3_T = new ulong[2 * ((DLEN_3 - 1) * (ELL3_W / 2) + (ph3_path[PLEN_3 - 1] - 1))];
	}
}
