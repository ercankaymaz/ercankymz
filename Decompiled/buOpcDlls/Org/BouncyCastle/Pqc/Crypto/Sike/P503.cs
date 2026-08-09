using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P503 : Internal
{
	internal P503(bool isCompressed)
	{
		COMPRESS = isCompressed;
		CRYPTO_SECRETKEYBYTES = 434u;
		CRYPTO_PUBLICKEYBYTES = 378u;
		CRYPTO_BYTES = 24u;
		CRYPTO_CIPHERTEXTBYTES = 402;
		if (isCompressed)
		{
			CRYPTO_SECRETKEYBYTES = 407u;
			CRYPTO_PUBLICKEYBYTES = 225u;
			CRYPTO_CIPHERTEXTBYTES = 280;
		}
		NWORDS_FIELD = 8u;
		PRIME_ZERO_WORDS = 3u;
		NBITS_FIELD = 503u;
		MAXBITS_FIELD = 512u;
		MAXWORDS_FIELD = (MAXBITS_FIELD + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_FIELD = (NBITS_FIELD + 63) / 64;
		NBITS_ORDER = 256u;
		NWORDS_ORDER = (NBITS_ORDER + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_ORDER = (NBITS_ORDER + 63) / 64;
		MAXBITS_ORDER = NBITS_ORDER;
		ALICE = 0u;
		BOB = 1u;
		OALICE_BITS = 250u;
		OBOB_BITS = 253u;
		OBOB_EXPON = 159u;
		MASK_ALICE = 3u;
		MASK_BOB = 15u;
		PARAM_A = 6u;
		PARAM_C = 1u;
		MAX_INT_POINTS_ALICE = 7u;
		MAX_INT_POINTS_BOB = 8u;
		MAX_Alice = 125u;
		MAX_Bob = 159u;
		MSG_BYTES = 24u;
		SECRETKEY_A_BYTES = (OALICE_BITS + 7) / 8;
		SECRETKEY_B_BYTES = (OBOB_BITS - 1 + 7) / 8;
		FP2_ENCODED_BYTES = 2 * ((NBITS_FIELD + 7) / 8);
		PRIME = new ulong[8] { 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 12393906174523604991uL, 1371447078966912928uL, 1989455001339985327uL, 6937169319750509776uL, 18127602061483550uL };
		PRIMEx2 = new ulong[8] { 18446744073709551614uL, 18446744073709551615uL, 18446744073709551615uL, 6341068275337658367uL, 2742894157933825857uL, 3978910002679970654uL, 13874338639501019552uL, 36255204122967100uL };
		PRIMEx4 = new ulong[8] { 18446744073709551612uL, 18446744073709551615uL, 18446744073709551615uL, 12682136550675316735uL, 5485788315867651714uL, 7957820005359941308uL, 9301933205292487488uL, 72510408245934201uL };
		PRIMEp1 = new ulong[8] { 0uL, 0uL, 0uL, 12393906174523604992uL, 1371447078966912928uL, 1989455001339985327uL, 6937169319750509776uL, 18127602061483550uL };
		PRIMEp1x64 = new ulong[4] { 13985636759044220971uL, 16644655643501751236uL, 1256978695003386886uL, 1160166531934947224uL };
		PRIMEx16p = new ulong[16]
		{
			16uL, 0uL, 0uL, 9223372036854775808uL, 11453925694187441130uL, 10124416251958675997uL, 17818254726207858172uL, 3527199594194418739uL, 1469206208402633719uL, 16125476666494931876uL,
			3713841762384630283uL, 5732158007287747578uL, 16015846162495051931uL, 13616710210549735357uL, 5867348778409282426uL, 285023702989702uL
		};
		Alice_order = new ulong[4] { 0uL, 0uL, 0uL, 288230376151711744uL };
		Bob_order = new ulong[4] { 13985636759044220971uL, 16644655643501751236uL, 1256978695003386886uL, 1160166531934947224uL };
		A_gen = new ulong[48]
		{
			6703660896400103571uL, 12537332160849053239uL, 3678485159306027873uL, 17353623398657820066uL, 2873992082182551772uL, 7171536194148839865uL, 10181624625838804804uL, 16352189888232255uL, 9094247284453741849uL, 15253039841833755244uL,
			13880693959290797529uL, 18392215330245950546uL, 15398807590945265407uL, 1922054504381246808uL, 17050426384711021178uL, 7612225463883843uL, 5585423759613901741uL, 2458739554285137871uL, 8711841994324700402uL, 7897112202292909028uL,
			5786141083180541608uL, 17280526905686863908uL, 14661266504429629391uL, 4594121609494003uL, 969679319129173575uL, 16094612563470158573uL, 13288942754001159038uL, 9883757633938792291uL, 11495715571241890913uL, 9379070488088296136uL,
			16918015978071401965uL, 1716330900454016uL, 2133917679667870743uL, 6131595433662066731uL, 4132892201466249495uL, 4243264721812232392uL, 6868906156409292872uL, 17926026206927608938uL, 15578721314078959076uL, 12061138545445877uL,
			14152221740469333595uL, 8869864843183837084uL, 9745375904961687712uL, 13481433594105150145uL, 11621254945640950360uL, 9850236505881797121uL, 3990273888349394775uL, 1829864135412729uL
		};
		B_gen = new ulong[48]
		{
			16096726836148725979uL, 14054702278015845390uL, 4385548945328509436uL, 17675320158140042461uL, 4241169154243281967uL, 9391123633589229008uL, 7121043649763917783uL, 8110065236168021uL, 0uL, 0uL,
			0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 3329382374260773473uL, 3539711558809017592uL, 6589269349358072822uL, 3923158083819410753uL,
			13173389878972436303uL, 1859160943325703733uL, 17652416194769656287uL, 15124960556656395uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL,
			0uL, 0uL, 3317107392457288018uL, 15204737728010292594uL, 2378317285299659333uL, 2752067541212454492uL, 5401008318620329606uL, 14961513289750612371uL, 17521159050955881097uL, 3869545957505286uL,
			279293490929988356uL, 11042087747279613526uL, 9241719920557877023uL, 1152299110578731394uL, 16538596947068471601uL, 1402013848611896279uL, 564564276466162271uL, 16163713578947404uL
		};
		Montgomery_R2 = new ulong[8] { 5947461595517747487uL, 11207248842288190137uL, 11795883816894656890uL, 6612826553991653612uL, 11408068157014623267uL, 13801731633100576405uL, 5109635575176285622uL, 17852757024708465uL };
		Montgomery_one = new ulong[8] { 1017uL, 0uL, 0uL, 12970366926827028480uL, 7190870292575474356uL, 5866111745285600125uL, 10001782044489826626uL, 10972777180780883uL };
		strat_Alice = new uint[124]
		{
			61u, 32u, 16u, 8u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 8u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u,
			2u, 1u, 1u, 16u, 8u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 8u,
			4u, 2u, 1u, 1u, 2u, 1u, 1u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 29u, 16u, 8u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 8u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 13u, 8u, 4u, 2u,
			1u, 1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 5u, 4u, 2u, 1u, 1u, 2u, 1u, 1u,
			2u, 1u, 1u, 1u
		};
		strat_Bob = new uint[158]
		{
			71u, 38u, 21u, 13u, 8u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 5u,
			4u, 2u, 1u, 1u, 2u, 1u, 1u, 2u, 1u, 1u,
			1u, 9u, 5u, 3u, 2u, 1u, 1u, 1u, 1u, 2u,
			1u, 1u, 1u, 4u, 2u, 1u, 1u, 1u, 2u, 1u,
			1u, 17u, 9u, 5u, 3u, 2u, 1u, 1u, 1u, 1u,
			2u, 1u, 1u, 1u, 4u, 2u, 1u, 1u, 1u, 2u,
			1u, 1u, 8u, 4u, 2u, 1u, 1u, 1u, 2u, 1u,
			1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 33u, 17u,
			9u, 5u, 3u, 2u, 1u, 1u, 1u, 1u, 2u, 1u,
			1u, 1u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u,
			8u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 16u, 8u, 4u, 2u,
			1u, 1u, 1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u,
			2u, 1u, 1u, 8u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u
		};
		if (!COMPRESS)
		{
			return;
		}
		MASK2_BOB = 3u;
		MASK3_BOB = 255u;
		ORDER_A_ENCODED_BYTES = SECRETKEY_A_BYTES;
		ORDER_B_ENCODED_BYTES = SECRETKEY_B_BYTES;
		PARTIALLY_COMPRESSED_CHUNK_CT = 4 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		COMPRESSED_CHUNK_CT = 3 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		UNCOMPRESSEDPK_BYTES = 378u;
		TABLE_R_LEN = 17u;
		TABLE_V_LEN = 34u;
		TABLE_V3_LEN = 20u;
		W_2 = 5u;
		W_3 = 3u;
		ELL2_W = (uint)(1 << (int)W_2);
		ELL3_W = 27u;
		ELL2_EMODW = (uint)(1 << (int)(OALICE_BITS % W_2));
		ELL3_EMODW = 1u;
		DLEN_2 = (OALICE_BITS + W_2 - 1) / W_2;
		DLEN_3 = (OBOB_EXPON + W_3 - 1) / W_3;
		PLEN_2 = 51u;
		PLEN_3 = 54u;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		using (Stream stream = typeof(P503).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p503.bz2"))
		{
			using StreamReader streamReader = new StreamReader(Bzip2.DecompressInput(stream));
			string text = streamReader.ReadLine();
			int num = 0;
			while (text != null)
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
				text = streamReader.ReadLine();
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
		Montgomery_R2 = Internal.ReadFromProperty(dictionary, "Montgomery_R2", NWORDS64_FIELD);
		Montgomery_RB1 = Internal.ReadFromProperty(dictionary, "Montgomery_RB1", NWORDS64_FIELD);
		Montgomery_RB2 = Internal.ReadFromProperty(dictionary, "Montgomery_RB2", NWORDS64_FIELD);
		Montgomery_one = Internal.ReadFromProperty(dictionary, "Montgomery_one", NWORDS64_FIELD);
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
		ph3_T = Internal.ReadFromProperty(dictionary, "ph3_T", DLEN_3 * (ELL3_W >> 1) * 2 * NWORDS64_FIELD);
		Montgomery_R = new ulong[NWORDS64_FIELD];
		ph3_T1 = new ulong[DLEN_3 * (ELL3_W >> 1) * 2 * NWORDS64_FIELD];
		ph3_T2 = new ulong[DLEN_3 * (ELL3_W >> 1) * 2 * NWORDS64_FIELD];
		ph2_T1 = new ulong[2 * ((DLEN_2 - 1) * (ELL2_W / 2) + (ph2_path[PLEN_2 - 1] - 1))];
		ph2_T2 = new ulong[2 * ((DLEN_2 - 1) * (ELL2_W / 2) + (ph2_path[PLEN_2 - 1] - 1))];
	}
}
