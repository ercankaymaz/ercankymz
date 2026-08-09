using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Utilities.IO.Compression;

namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal class P610 : Internal
{
	internal P610(bool isCompressed)
	{
		COMPRESS = isCompressed;
		CRYPTO_SECRETKEYBYTES = 524u;
		CRYPTO_PUBLICKEYBYTES = 462u;
		CRYPTO_BYTES = 24u;
		CRYPTO_CIPHERTEXTBYTES = 486;
		if (isCompressed)
		{
			CRYPTO_SECRETKEYBYTES = 491u;
			CRYPTO_PUBLICKEYBYTES = 274u;
			CRYPTO_CIPHERTEXTBYTES = 336;
		}
		NWORDS_FIELD = 10u;
		PRIME_ZERO_WORDS = 4u;
		NBITS_FIELD = 610u;
		MAXBITS_FIELD = 640u;
		MAXWORDS_FIELD = (MAXBITS_FIELD + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_FIELD = (NBITS_FIELD + 63) / 64;
		NBITS_ORDER = 320u;
		NWORDS_ORDER = (NBITS_ORDER + Internal.RADIX - 1) / Internal.RADIX;
		NWORDS64_ORDER = (NBITS_ORDER + 63) / 64;
		MAXBITS_ORDER = NBITS_ORDER;
		ALICE = 0u;
		BOB = 1u;
		OALICE_BITS = 305u;
		OBOB_BITS = 305u;
		OBOB_EXPON = 192u;
		MASK_ALICE = 1u;
		MASK_BOB = 255u;
		PARAM_A = 6u;
		PARAM_C = 1u;
		MAX_INT_POINTS_ALICE = 8u;
		MAX_INT_POINTS_BOB = 10u;
		MAX_Alice = 152u;
		MAX_Bob = 192u;
		MSG_BYTES = 24u;
		SECRETKEY_A_BYTES = (OALICE_BITS + 7) / 8;
		SECRETKEY_B_BYTES = (OBOB_BITS - 1 + 7) / 8;
		FP2_ENCODED_BYTES = 2 * ((NBITS_FIELD + 7) / 8);
		PRIME = new ulong[10] { 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 7926898294125494271uL, 12788056803604344878uL, 11162100504611256747uL, 12850373898864436522uL, 9335980454322886796uL, 10669696872uL };
		PRIMEx2 = new ulong[10] { 18446744073709551614uL, 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 15853796588250988543uL, 7129369533499138140uL, 3877456935512961879uL, 7254003724019321429uL, 225216834936221977uL, 21339393745uL };
		PRIMEx4 = new ulong[10] { 18446744073709551612uL, 18446744073709551615uL, 18446744073709551615uL, 18446744073709551615uL, 13260849102792425471uL, 14258739066998276281uL, 7754913871025923758uL, 14508007448038642858uL, 450433669872443954uL, 42678787490uL };
		PRIMEp1 = new ulong[10] { 0uL, 0uL, 0uL, 0uL, 7926898294125494272uL, 12788056803604344878uL, 11162100504611256747uL, 12850373898864436522uL, 9335980454322886796uL, 10669696872uL };
		PRIMEx16p = new ulong[20]
		{
			16uL, 0uL, 0uL, 0uL, 4593671619917905920uL, 15057295979980651058uL, 11747665326630816393uL, 13063148931657718444uL, 14843274714729999977uL, 9213098133652443887uL,
			16184711284518687079uL, 15152855274923543935uL, 15339866525258615080uL, 10917383248197352654uL, 423414579105418765uL, 10355422686146848012uL, 17970659541427193412uL, 4932507286707963453uL, 13697982395128707963uL, 98uL
		};
		Alice_order = new ulong[5] { 0uL, 0uL, 0uL, 0uL, 562949953421312uL };
		Bob_order = new ulong[5] { 2806962120998467329uL, 16114585662381217980uL, 15671691495630785907uL, 603808853150554410uL, 349624627118280uL };
		A_gen = new ulong[60]
		{
			5771904529248994682uL, 10009829002276161265uL, 270330086766583390uL, 6481898407746275289uL, 7865854910092666580uL, 15620069539765408586uL, 10893576880820336051uL, 9414097477218394383uL, 5194719131280954495uL, 1729770898uL,
			16481658151656772596uL, 13633773755204448979uL, 1977403254395278860uL, 2726390535525409621uL, 18198696508619478634uL, 12992673620297984156uL, 15585820391321559058uL, 4095961562244124488uL, 13529435761498453802uL, 5102423139uL,
			2124736252400681868uL, 11123746024777819577uL, 2202127831239085027uL, 15189163262449832501uL, 4313963896834226850uL, 13370300494042345640uL, 4921946642166740880uL, 14640789545148115673uL, 15809041940818907362uL, 7907518294uL,
			2200917311302176889uL, 2939498022256786432uL, 16162577001789154273uL, 9557432669551130207uL, 15389712118992921126uL, 13586216826660735913uL, 10514164377495492777uL, 334500554730375393uL, 6399318707077975086uL, 8976719684uL,
			2746580562334225805uL, 14004852227026191121uL, 11466649160507921918uL, 11799630227884196955uL, 6714415832701611114uL, 10112136743029452510uL, 7010145936394111770uL, 18042795605720766895uL, 11307052907097731807uL, 3478841981uL,
			13366757749870367424uL, 3119472779256121459uL, 4709779656408495164uL, 16568419043672081405uL, 14691179270073594708uL, 5893360609436446022uL, 6635037533545129430uL, 5031143778661013925uL, 2711723078310815363uL, 10114015515uL
		};
		B_gen = new ulong[60]
		{
			14323946558550738106uL, 2405435625630280597uL, 14697550786434646162uL, 15511184413509320248uL, 7035179512456608727uL, 17358557897062455236uL, 2237320506219039519uL, 14307448527707612354uL, 16412911138814384653uL, 5379123413uL,
			0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL,
			17692069297427191936uL, 8155755975969367465uL, 11338564383465294727uL, 5678382275401384545uL, 12501231795214209584uL, 4726463275275376934uL, 17083766455683877101uL, 4479281637794437063uL, 17540154893918510969uL, 9074793307uL,
			0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL, 0uL,
			8829176751768485847uL, 4330345099806588278uL, 6439066249656508832uL, 17672114398665101563uL, 12943163433490994938uL, 9363570836893509813uL, 16984122743018654352uL, 9683040719332474896uL, 16255205449832888349uL, 9017845420uL,
			6790521807624498538uL, 16155971635292829987uL, 4283588130542979409uL, 514645655039295889uL, 8912678322428419353uL, 6038404330050892853uL, 17176157232408721930uL, 9916604761775707332uL, 910728456329037494uL, 5513273805uL
		};
		Montgomery_R2 = new ulong[10] { 16672146738007078695uL, 16192790745003276590uL, 7764610893679053117uL, 15888490136859680965uL, 8311396451547473226uL, 9580492030289074780uL, 9136860735727631175uL, 14248068042486481075uL, 8077651299688882586uL, 2385055731uL };
		Montgomery_one = new ulong[10] { 1728891110uL, 0uL, 0uL, 0uL, 11111506180629856256uL, 5591714530040314431uL, 741431724485104668uL, 15183360670812525026uL, 1398651832995983165uL, 4438944100uL };
		strat_Alice = new uint[151]
		{
			67u, 37u, 21u, 12u, 7u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 3u, 2u, 1u, 1u, 1u, 1u, 5u, 3u,
			2u, 1u, 1u, 1u, 1u, 2u, 1u, 1u, 1u, 9u,
			5u, 3u, 2u, 1u, 1u, 1u, 1u, 2u, 1u, 1u,
			1u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u, 16u,
			9u, 5u, 3u, 2u, 1u, 1u, 1u, 1u, 2u, 1u,
			1u, 1u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u,
			8u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 4u, 2u,
			1u, 1u, 2u, 1u, 1u, 33u, 16u, 8u, 5u, 2u,
			1u, 1u, 1u, 2u, 1u, 1u, 1u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 8u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 16u,
			8u, 4u, 2u, 1u, 1u, 1u, 2u, 1u, 1u, 4u,
			2u, 1u, 1u, 2u, 1u, 1u, 8u, 4u, 2u, 1u,
			1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u
		};
		strat_Bob = new uint[191]
		{
			86u, 48u, 27u, 15u, 8u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 7u,
			4u, 2u, 1u, 1u, 2u, 1u, 1u, 3u, 2u, 1u,
			1u, 1u, 1u, 12u, 7u, 4u, 2u, 1u, 1u, 2u,
			1u, 1u, 3u, 2u, 1u, 1u, 1u, 1u, 5u, 3u,
			2u, 1u, 1u, 1u, 1u, 2u, 1u, 1u, 1u, 21u,
			12u, 7u, 4u, 2u, 1u, 1u, 2u, 1u, 1u, 3u,
			2u, 1u, 1u, 1u, 1u, 5u, 3u, 2u, 1u, 1u,
			1u, 1u, 2u, 1u, 1u, 1u, 9u, 5u, 3u, 2u,
			1u, 1u, 1u, 1u, 2u, 1u, 1u, 1u, 4u, 2u,
			1u, 1u, 1u, 2u, 1u, 1u, 38u, 21u, 12u, 7u,
			4u, 2u, 1u, 1u, 2u, 1u, 1u, 3u, 2u, 1u,
			1u, 1u, 1u, 5u, 3u, 2u, 1u, 1u, 1u, 1u,
			2u, 1u, 1u, 1u, 9u, 5u, 3u, 2u, 1u, 1u,
			1u, 1u, 2u, 1u, 1u, 1u, 4u, 2u, 1u, 1u,
			1u, 2u, 1u, 1u, 17u, 9u, 5u, 3u, 2u, 1u,
			1u, 1u, 1u, 2u, 1u, 1u, 1u, 4u, 2u, 1u,
			1u, 1u, 2u, 1u, 1u, 8u, 4u, 2u, 1u, 1u,
			1u, 2u, 1u, 1u, 4u, 2u, 1u, 1u, 2u, 1u,
			1u
		};
		if (!COMPRESS)
		{
			return;
		}
		MASK2_BOB = 7u;
		MASK3_BOB = 255u;
		ORDER_A_ENCODED_BYTES = SECRETKEY_A_BYTES;
		ORDER_B_ENCODED_BYTES = SECRETKEY_B_BYTES + 1;
		PARTIALLY_COMPRESSED_CHUNK_CT = 4 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		COMPRESSED_CHUNK_CT = 3 * ORDER_A_ENCODED_BYTES + FP2_ENCODED_BYTES + 2;
		UNCOMPRESSEDPK_BYTES = 480u;
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
		PLEN_2 = 62u;
		PLEN_3 = 65u;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		using (Stream stream = typeof(P610).Assembly.GetManifestResourceStream("Org.BouncyCastle.pqc.crypto.sike.p610.bz2"))
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
