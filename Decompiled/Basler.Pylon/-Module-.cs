using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using _003CCppImplementationDetails_003E;
using _003CCrtImplementationDetails_003E;
using _003FA0x6565c3d8;
using _003FA0xe82174f0;
using Baselibs;
using Basler.Pylon;
using Basler.Pylon.Internal;
using GenApi_3_1_Basler_pylon;
using GenICam_3_1_Basler_pylon;
using Pylon;
using PylonInternal;
using bclog;
using boost;
using boost.detail;
using gtl;
using msclr.interop.details;
using std;

internal class _003CModule_003E
{
	internal static _0024ArrayType_0024_0024_0024BY06_0024_0024CBD _003F_003F_C_0040_06LHGEHABH_0040_003F_0024CINULL_003F_0024CJ_0040/* Not supported: data(28 4E 55 4C 4C 29 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BF_0040_0024_0024CB_W _003F_003F_C_0040_1CK_0040PLDANGII_0040_003F_0024AAA_003F_0024AAc_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAm_003F_0024AAa_003F_0024AAn_003F_0024AAd_003F_0024AAT_003F_0024AAr_0040/* Not supported: data(41 00 63 00 74 00 69 00 6F 00 6E 00 43 00 6F 00 6D 00 6D 00 61 00 6E 00 64 00 54 00 72 00 69 00 67 00 67 00 65 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BD_0040_0024_0024CBD _003F_003F_C_0040_0BD_0040OLBABOEK_0040vector_003F_0024DMT_003F_0024DO_003F5too_003F5long_0040/* Not supported: data(76 65 63 74 6F 72 3C 54 3E 20 74 6F 6F 20 6C 6F 6E 67 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_20 _003F_003F_R0_003FAVexception_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 65 78 63 65 70 74 69 6F 6E 40 73 74 64 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_48 _003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 47 65 6E 65 72 69 63 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_52 _003F_003F_R0_003FAVDynamicCastException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 44 79 6E 61 6D 69 63 43 61 73 74 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_48 _003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 52 75 6E 74 69 6D 65 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_49 _003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 42 61 64 41 6C 6C 6F 63 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_53 _003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 4C 6F 67 69 63 61 6C 45 72 72 6F 72 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_48 _003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 54 69 6D 65 6F 75 74 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_47 _003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 41 63 63 65 73 73 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_51 _003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 4F 75 74 4F 66 52 61 6E 67 65 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_56 _003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 49 6E 76 61 6C 69 64 41 72 67 75 6D 65 6E 74 45 78 63 65 70 74 69 6F 6E 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_28 _003F_003F_R0_003FAUITransportLayer_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_32 _003F_003F_R0_003FAUIGigETransportLayer_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 47 69 67 45 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040_0024_0024CBD _003F_003F_C_0040_0L_0040JJBMFOCK_0040BaslerGigE_0040/* Not supported: data(42 61 73 6C 65 72 47 69 67 45 00) */;

	internal unsafe static sbyte* Pylon_002E_003FA0xe82174f0_002EBaslerGigEDeviceClass/* Not supported: data(30 03 0D 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0BC_0040_0024_0024CBD _003F_003F_C_0040_0BC_0040EOODALEL_0040Unknown_003F5exception_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BB_0040_0024_0024CBD _003F_003F_C_0040_0BB_0040CDLLKKB_0040RuntimeException_0040/* Not supported: data(52 75 6E 74 69 6D 65 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BB_0040_0024_0024CBD _003F_003F_C_0040_0BB_0040FPCMMNPH_0040PylonNET_003F4Library_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 4C 69 62 72 61 72 79 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040_0024_0024CBD _003F_003F_C_0040_0BA_0040CKJGGAGJ_0040PylonNET_003F4Camera_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 43 61 6D 65 72 61 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DO_0040_0024_0024CBD _003F_003F_C_0040_0DO_0040DEPAAFCK_0040Exception_003F5caught_003F5in_003F5propagating_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 69 6E 20 70 72 6F 70 61 67 61 74 69 6E 67 20 65 76 65 6E 74 20 68 61 6E 64 6C 65 72 20 27 25 68 73 27 2E 20 4D 73 67 3A 20 25 68 73 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DD_0040_0024_0024CBD _003F_003F_C_0040_0DD_0040JBNJDNLE_0040Unknown_003F5exception_003F5occurred_003F5in_003F5e_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 6F 63 63 75 72 72 65 64 20 69 6E 20 65 76 65 6E 74 20 68 61 6E 64 6C 65 72 20 27 25 68 73 27 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040JGFIJDKF_0040Exception_003F5caught_003F5and_003F5ignored_003F5in_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 61 6E 64 20 69 67 6E 6F 72 65 64 20 69 6E 20 6E 6F 6E 2D 70 72 6F 70 61 67 61 74 69 6E 67 20 65 76 65 6E 74 20 68 61 6E 64 6C 65 72 20 27 25 68 73 27 2E 20 4D 73 67 3A 20 25 68 73 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EN_0040_0024_0024CBD _003F_003F_C_0040_0EN_0040KBDJLEMF_0040Unknown_003F5exception_003F5caught_003F5and_003F5ig_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 61 6E 64 20 69 67 6E 6F 72 65 64 20 69 6E 20 6E 6F 6E 2D 70 72 6F 70 61 67 61 74 69 6E 67 20 65 76 65 6E 74 20 68 61 6E 64 6C 65 72 20 27 25 68 73 27 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FF_0040_0024_0024CBD _003F_003F_C_0040_0FF_0040NGHBGAHE_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 5C 70 79 6C 6F 6E 62 61 73 65 5C 77 61 69 74 61 62 6C 65 74 69 6D 65 72 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CM_0040_0024_0024CBD _003F_003F_C_0040_0CM_0040BJFBNIAA_0040Error_003F50x_003F_0024CF08x_003F5creating_003F5waitable_003F5_0040/* Not supported: data(45 72 72 6F 72 20 30 78 25 30 38 78 20 63 72 65 61 74 69 6E 67 20 77 61 69 74 61 62 6C 65 20 74 69 6D 65 72 20 25 23 30 31 30 78 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CL_0040_0024_0024CBD _003F_003F_C_0040_0CL_0040PNCNDGOD_0040Error_003F50x_003F_0024CF08x_003F5setting_003F5waitable_003F5t_0040/* Not supported: data(45 72 72 6F 72 20 30 78 25 30 38 78 20 73 65 74 74 69 6E 67 20 77 61 69 74 61 62 6C 65 20 74 69 6D 65 72 20 25 23 30 31 30 78 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BC_0040_0024_0024CB_W _003F_003F_C_0040_1CE_0040PJHNKPMC_0040_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_003F_0024AAA_003F_0024AAd_003F_0024AAa_003F_0024AAp_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAt_003F_0024AAr_003F_0024AAe_0040/* Not supported: data(46 00 69 00 6C 00 65 00 41 00 64 00 61 00 70 00 74 00 65 00 72 00 53 00 74 00 72 00 65 00 61 00 6D 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY06_0024_0024CB_W _003F_003F_C_0040_1O_0040NJAJGJMG_0040_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAr_003F_0024AAa_0040/* Not supported: data(43 00 61 00 6D 00 65 00 72 00 61 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FI_0040_0024_0024CBD _003F_003F_C_0040_0FI_0040DJMFIIND_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EK_0040_0024_0024CBD _003F_003F_C_0040_0EK_0040KGLAAOBL_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EC_0040_0024_0024CBD _003F_003F_C_0040_0EC_0040HEPIKMHP_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DP_0040_0024_0024CBD _003F_003F_C_0040_0DP_0040GDOEIJLO_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 4F 70 65 6E 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GH_0040_0024_0024CBD _003F_003F_C_0040_0GH_0040FGLCDNKF_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 43 61 6D 65 72 61 44 65 76 69 63 65 52 65 6D 6F 76 65 64 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FJ_0040_0024_0024CBD _003F_003F_C_0040_0FJ_0040FBGEKAFC_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 43 61 6D 65 72 61 44 65 76 69 63 65 52 65 6D 6F 76 65 64 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FB_0040_0024_0024CBD _003F_003F_C_0040_0FB_0040GBFGDKPA_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 43 61 6D 65 72 61 44 65 76 69 63 65 52 65 6D 6F 76 65 64 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040INFEBDIN_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 3A 3A 49 73 43 61 6D 65 72 61 44 65 76 69 63 65 52 65 6D 6F 76 65 64 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EP_0040_0024_0024CBD _003F_003F_C_0040_0EP_0040EAOICBBN_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 6C 6F 73 69 6E 67 20 6E 61 74 69 76 65 20 63 61 6D 65 72 61 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EB_0040_0024_0024CBD _003F_003F_C_0040_0EB_0040LGMHGNPN_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 6C 6F 73 69 6E 67 20 6E 61 74 69 76 65 20 63 61 6D 65 72 61 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DJ_0040_0024_0024CBD _003F_003F_C_0040_0DJ_0040IHGFCNEE_0040Exception_003F5caught_003F5while_003F5closing_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 6C 6F 73 69 6E 67 20 6E 61 74 69 76 65 20 63 61 6D 65 72 61 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DG_0040_0024_0024CBD _003F_003F_C_0040_0DG_0040MFJOIIN_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 6C 6F 73 69 6E 67 20 6E 61 74 69 76 65 20 63 61 6D 65 72 61 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0IL_0040_0024_0024CBD _003F_003F_C_0040_0IL_0040LDDCMHLK_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 61 63 6B 61 67 65 73 5C 67 65 6E 69 63 61 6D 66 6F 72 70 79 6C 6F 6E 2E 33 2E 31 2E 30 2E 35 32 34 36 5C 6C 69 62 5C 6E 61 74 69 76 65 5C 6C 69 62 72 61 72 79 5C 63 70 70 5C 69 6E 63 6C 75 64 65 5C 62 61 73 65 5C 67 63 75 74 69 6C 69 74 69 65 73 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BF_0040_0024_0024CBD _003F_003F_C_0040_0BF_0040GELNLOGJ_0040INTEGRAL_CAST_003F5failed_0040/* Not supported: data(49 4E 54 45 47 52 41 4C 5F 43 41 53 54 20 66 61 69 6C 65 64 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(A8 01 1B 10 DC 01 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(28 02 1B 10 DC 01 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CInstantCameraLockProvider_0040Pylon_0040Basler_0040_00408/* Not supported: data(A0 FC 1A 10 0C FC 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2IExternalLock_0040Pylon_0040_00408/* Not supported: data(0C FC 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_24 _003F_003F_R2CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00408/* Not supported: data(EC FC 1A 10 CC FD 1A 10 74 FD 1A 10 90 FD 1A 10 1C FE 1A 10 6C FE 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CInstantCamera_0040Pylon_0040_00408/* Not supported: data(CC FD 1A 10 74 FD 1A 10 90 FD 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CInstantCameraParams_Params_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(08 FD 1A 10 3C FD 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CInstantCameraParams_Params_v7_2_0_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(3C FD 1A 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_20 _003F_003F_R2_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(60 FF 1A 10 B8 00 1B 10 40 00 1B 10 5C 00 1B 10 78 00 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_20 _003F_003F_R2_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(10 01 1B 10 50 01 1B 10 40 00 1B 10 5C 00 1B 10 78 00 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2FileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(74 02 1B 10 A8 02 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2IFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(A8 02 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2gcstring_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(F0 FE 1A 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(28 CE 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 04 02 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_52 _003F_003F_R0_003FAV_003F_0024basic_streambuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 73 74 72 65 61 6D 62 75 66 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024basic_streambuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(DC 01 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_streambuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 C4 01 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_streambuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(7C CE 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 CC 01 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(B8 CE 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 50 02 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInstantCameraLockProvider_0040Pylon_0040Basler_0040_00408/* Not supported: data(E0 CA 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 C8 FC 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IExternalLock_0040Pylon_0040_00408/* Not supported: data(A0 CA 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 30 FC 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1GI_0040_003F0A_0040EA_0040CImageEventHandler_0040Pylon_0040_00408/* Not supported: data(3C CC 1B 10 00 00 00 00 68 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 5C FE 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1GA_0040_003F0A_0040EA_0040CConfigurationEventHandler_0040Pylon_0040_00408/* Not supported: data(0C CC 1B 10 00 00 00 00 60 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 0C FE 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00408/* Not supported: data(18 CB 1B 10 05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 A4 FE 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CInstantCameraParams_Params_v7_2_0_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(C0 CB 1B 10 00 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 2C FD 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CInstantCameraParams_Params_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(78 CB 1B 10 01 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 64 FD 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInstantCamera_0040Pylon_0040_00408/* Not supported: data(50 CB 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 BC FD 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInstantCameraParams_Params_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(78 CB 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 64 FD 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInstantCameraParams_Params_v7_2_0_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(C0 CB 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 2C FD 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_50 _003F_003F_R0_003FAV_003F_0024basic_istream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 69 73 74 72 65 61 6D 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_16 _003F_003F_R2_003F_0024basic_istream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(B8 00 1B 10 40 00 1B 10 5C 00 1B 10 78 00 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_istream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 04 00 00 00 94 00 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_istream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(EC CC 1B 10 03 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 A8 00 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(98 CC 1B 10 04 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 EC 00 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_50 _003F_003F_R0_003FAV_003F_0024basic_ostream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 6F 73 74 72 65 61 6D 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_46 _003F_003F_R0_003FAV_003F_0024basic_ios_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 69 6F 73 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_ios_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(28 CD 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 30 00 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2_003F_0024basic_ios_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(7C FF 1A 10 04 00 1B 10 CC FF 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_ios_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 20 00 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040A_00403FA_0040_003F_0024basic_ios_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(28 CD 1B 10 02 00 00 00 00 00 00 00 00 00 00 00 04 00 00 00 50 00 00 00 30 00 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_19 _003F_003F_R0_003FAVios_base_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 69 6F 73 5F 62 61 73 65 40 73 74 64 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040ios_base_0040std_0040_00408/* Not supported: data(60 CD 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 F4 FF 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R17_003F0A_0040EA_0040_003F_0024_Iosb_0040H_0040std_0040_00408/* Not supported: data(7C CD 1B 10 00 00 00 00 08 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 BC FF 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2ios_base_0040std_0040_00408/* Not supported: data(04 00 1B 10 CC FF 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3ios_base_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 E8 FF 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040A_00403EA_0040ios_base_0040std_0040_00408/* Not supported: data(60 CD 1B 10 01 00 00 00 00 00 00 00 00 00 00 00 04 00 00 00 40 00 00 00 F4 FF 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_20 _003F_003F_R0_003FAV_003F_0024_Iosb_0040H_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 5F 49 6F 73 62 40 48 40 73 74 64 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024_Iosb_0040H_0040std_0040_00408/* Not supported: data(7C CD 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 BC FF 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024_Iosb_0040H_0040std_0040_00408/* Not supported: data(98 FF 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024_Iosb_0040H_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 B4 FF 1A 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R17A_00403EA_0040_003F_0024_Iosb_0040H_0040std_0040_00408/* Not supported: data(7C CD 1B 10 00 00 00 00 08 00 00 00 00 00 00 00 04 00 00 00 40 00 00 00 BC FF 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_16 _003F_003F_R2_003F_0024basic_ostream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(50 01 1B 10 40 00 1B 10 5C 00 1B 10 78 00 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_ostream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 04 00 00 00 2C 01 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_ostream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(EC CD 1B 10 03 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 40 01 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(98 CD 1B 10 04 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 84 01 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040FileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(0C CF 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 D0 02 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(48 CF 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 98 02 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040gcstring_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(64 CC 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 14 FF 1A 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 F8 01 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_74 _003F_003F_R0_003FAV_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 4F 44 65 76 46 69 6C 65 53 74 72 65 61 6D 42 75 66 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 44 02 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_74 _003F_003F_R0_003FAV_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 49 44 65 76 46 69 6C 65 53 74 72 65 61 6D 42 75 66 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IExternalLock_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 28 FC 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_26 _003F_003F_R0_003FAVIExternalLock_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 49 45 78 74 65 72 6E 61 6C 4C 6F 63 6B 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInstantCameraLockProvider_0040Pylon_0040Basler_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 BC FC 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_46 _003F_003F_R0_003FAVCInstantCameraLockProvider_0040Pylon_0040Basler_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 4C 6F 63 6B 50 72 6F 76 69 64 65 72 40 50 79 6C 6F 6E 40 42 61 73 6C 65 72 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInstantCamera_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 AC FD 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_27 _003F_003F_R0_003FAVCInstantCamera_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInstantCameraParams_Params_v7_2_0_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 24 FD 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_68 _003F_003F_R0_003FAVCInstantCameraParams_Params_v7_2_0_0040Basler_InstantCameraParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 5F 76 37 5F 32 5F 30 40 42 61 73 6C 65 72 5F 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInstantCameraParams_Params_0040Basler_InstantCameraParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 58 FD 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_61 _003F_003F_R0_003FAVCInstantCameraParams_Params_0040Basler_InstantCameraParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 40 42 61 73 6C 65 72 5F 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00408/* Not supported: data(00 00 00 00 01 00 00 00 06 00 00 00 88 FE 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_45 _003F_003F_R0_003FAVCInstantCameraForPylonNET_0040Pylon_0040Basler_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 73 74 61 6E 74 43 61 6D 65 72 61 46 6F 72 50 79 6C 6F 6E 4E 45 54 40 50 79 6C 6F 6E 40 42 61 73 6C 65 72 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 05 00 00 00 D4 00 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_75 _003F_003F_R0_003FAV_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 49 44 65 76 46 69 6C 65 53 74 72 65 61 6D 42 61 73 65 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 05 00 00 00 6C 01 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_75 _003F_003F_R0_003FAV_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 4F 44 65 76 46 69 6C 65 53 74 72 65 61 6D 42 61 73 65 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 90 02 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_51 _003F_003F_R0_003FAUIFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 46 69 6C 65 50 72 6F 74 6F 63 6F 6C 41 64 61 70 74 65 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3FileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 C4 02 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_50 _003F_003F_R0_003FAVFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 46 69 6C 65 50 72 6F 74 6F 63 6F 6C 41 64 61 70 74 65 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3gcstring_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 0C FF 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_40 _003F_003F_R0_003FAVgcstring_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 67 63 73 74 72 69 6E 67 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 28 CE 1B 10 04 02 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 B8 CE 1B 10 50 02 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4IExternalLock_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 A0 CA 1B 10 30 FC 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CInstantCameraLockProvider_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 E0 CA 1B 10 C8 FC 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCImageEventHandler_00401_0040_0040/* Not supported: data(00 00 00 00 68 00 00 00 00 00 00 00 18 CB 1B 10 A4 FE 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCConfigurationEventHandler_00401_0040_0040/* Not supported: data(00 00 00 00 60 00 00 00 00 00 00 00 18 CB 1B 10 A4 FE 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCInstantCamera_00401_0040_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 18 CB 1B 10 A4 FE 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 B8 00 00 00 04 00 00 00 98 CC 1B 10 EC 00 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 60 00 00 00 04 00 00 00 98 CD 1B 10 84 01 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4FileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 0C CF 1B 10 D0 02 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4gcstring_0040GenICam_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 64 CC 1B 10 14 FF 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY08Q6AXXZ _003F_003F_SFileProtocolAdapter_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(5B AA 0C 10 6B AA 0C 10 7B AA 0C 10 8B AA 0C 10 9B AA 0C 10 AB AA 0C 10 BB AA 0C 10 B0 91 02 10 47 00 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(90 8D 02 10 14 02 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY01_0024_0024CBH _003F_003F_8_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00407B_0040/* Not supported: data(00 00 00 00 60 00 00 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_19 _003F_003F_R0_003FAVbad_cast_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 62 61 64 5F 63 61 73 74 40 73 74 64 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040bad_cast_0040std_0040_00408/* Not supported: data(C4 CA 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 7C FC 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2bad_cast_0040std_0040_00408/* Not supported: data(54 FC 1A 10 C4 FB 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3bad_cast_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 70 FC 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4bad_cast_0040std_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 C4 CA 1B 10 7C FC 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY02Q6AXXZ _003F_003F_7bad_cast_0040std_0040_00406B_0040/* Not supported: data(40 7E 02 10 E0 7A 02 10 4B 00 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(F8 89 02 10 94 01 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY01_0024_0024CBH _003F_003F_8_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00407B_0040/* Not supported: data(00 00 00 00 B8 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040Q6AXXZ _003F_003F_7_003F_0024IDevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(F4 90 02 10 43 A4 0C 10 49 A4 0C 10 91 A4 0C 10 00 91 02 10 55 A4 0C 10 70 91 02 10 61 A4 0C 10 67 A4 0C 10 97 A4 0C 10 6D A4 0C 10 73 A4 0C 10 79 A4 0C 10 9D A4 0C 10 7F A4 0C 10 E0 02 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040Q6AXXZ _003F_003F_7_003F_0024ODevFileStreamBuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(E8 8D 02 10 43 A4 0C 10 49 A4 0C 10 F0 8D 02 10 4F A4 0C 10 55 A4 0C 10 5B A4 0C 10 61 A4 0C 10 67 A4 0C 10 30 8E 02 10 6D A4 0C 10 73 A4 0C 10 79 A4 0C 10 00 8F 02 10 7F A4 0C 10 4E 00 00 06) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetCameraCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetCameraCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040exception_0040std_0040_00408/* Not supported: data(84 CA 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 E8 FB 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2exception_0040std_0040_00408/* Not supported: data(C4 FB 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3exception_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 E0 FB 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4exception_0040std_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 84 CA 1B 10 E8 FB 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY02Q6AXXZ _003F_003F_7exception_0040std_0040_00406B_0040/* Not supported: data(60 7A 02 10 E0 7A 02 10 40 FC 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0BL_0040Q6AXXZ _003F_003F_Sgcstring_0040GenICam_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(70 83 02 10 5A A5 0C 10 6A A5 0C 10 7A A5 0C 10 8A A5 0C 10 9A A5 0C 10 AA A5 0C 10 BA A5 0C 10 CA A5 0C 10 DA A5 0C 10 EA A5 0C 10 FA A5 0C 10 0A A6 0C 10 1A A6 0C 10 2A A6 0C 10 3A A6 0C 10 4A A6 0C 10 5A A6 0C 10 6A A6 0C 10 7A A6 0C 10 8A A6 0C 10 9A A6 0C 10 AA A6 0C 10 BA A6 0C 10 CA A6 0C 10 DA A6 0C 10 4C 00 00 06) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0RuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 D8 C9 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 3A A5 0C 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 E4 14 1B 10 00 15 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 19 A5 0C 10 00 00 00 00 1C 15 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY06Q6AXXZ _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCImageEventHandler_00401_0040_0040/* Not supported: data(E0 82 02 10 FC 82 02 10 20 82 02 10 20 82 02 10 10 83 02 10 34 83 02 10 00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BF_0040Q6AXXZ _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCConfigurationEventHandler_00401_0040_0040/* Not supported: data(20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 3B 82 02 10 5B 82 02 10 7C 82 02 10 9B 82 02 10 20 82 02 10 20 82 02 10 B0 82 02 10 D4 82 02 10 DC FE 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0CO_0040Q6AXXZ _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCInstantCamera_00401_0040_0040/* Not supported: data(0C 82 02 10 3C AF 0C 10 5D AF 0C 10 6D AF 0C 10 7D AF 0C 10 8D AF 0C 10 9D AF 0C 10 AD AF 0C 10 BD AF 0C 10 CD AF 0C 10 DD AF 0C 10 ED AF 0C 10 FE AF 0C 10 0E B0 0C 10 1E B0 0C 10 2E B0 0C 10 3E B0 0C 10 4E B0 0C 10 5E B0 0C 10 6E B0 0C 10 7E B0 0C 10 8E B0 0C 10 9E B0 0C 10 AE B0 0C 10 BE B0 0C 10 CE B0 0C 10 DE B0 0C 10 EE B0 0C 10 FE B0 0C 10 0E B1 0C 10 1E B1 0C 10 2E B1 0C 10 3E B1 0C 10 4E B1 0C 10 5E B1 0C 10 6E B1 0C 10 7E B1 0C 10 8E B1 0C 10 9E B1 0C 10 AE B1 0C 10 BE B1 0C 10 CE B1 0C 10 DE B1 0C 10 EE B1 0C 10 FE B1 0C 10 C8 FE 1A 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_31 _003F_003F_R0_003FAVCImageEventHandler_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6D 61 67 65 45 76 65 6E 74 48 61 6E 64 6C 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CImageEventHandler_0040Pylon_0040_00408/* Not supported: data(3C CC 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 5C FE 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CImageEventHandler_0040Pylon_0040_00408/* Not supported: data(38 FE 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CImageEventHandler_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 54 FE 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CImageEventHandler_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 3C CC 1B 10 5C FE 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY06Q6AXXZ _003F_003F_7CImageEventHandler_0040Pylon_0040_00406B_0040/* Not supported: data(E0 82 02 10 E0 82 02 10 20 82 02 10 20 82 02 10 10 83 02 10 A0 88 02 10 1D 00 00 06) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAVCConfigurationEventHandler_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 43 6F 6E 66 69 67 75 72 61 74 69 6F 6E 45 76 65 6E 74 48 61 6E 64 6C 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CConfigurationEventHandler_0040Pylon_0040_00408/* Not supported: data(0C CC 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 0C FE 1A 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CConfigurationEventHandler_0040Pylon_0040_00408/* Not supported: data(E8 FD 1A 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CConfigurationEventHandler_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 04 FE 1A 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CConfigurationEventHandler_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 0C CC 1B 10 0C FE 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0BF_0040Q6AXXZ _003F_003F_7CConfigurationEventHandler_0040Pylon_0040_00406B_0040/* Not supported: data(20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 E0 82 02 10 20 82 02 10 20 82 02 10 20 82 02 10 B0 82 02 10 30 88 02 10 4C FF 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY02Q6AXXZ _003F_003F_7IExternalLock_0040Pylon_0040_00406B_0040/* Not supported: data(52 D9 0C 10 52 D9 0C 10 8C FC 1A 10) */;

	internal static _0024ArrayType_0024_0024_0024BY02Q6AXXZ _003F_003F_7CInstantCameraLockProvider_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(0F 7F 02 10 2F 7F 02 10 B4 FE 1A 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0GenericException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 4C CA 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 4A A5 0C 10) */;

	internal static ulong _003F_OptionsStorage_0040_003F1_003F_003F__local_stdio_printf_options_0040_0040YAPA_KXZ_00404_KA/* Not supported: data(00 00 00 00 00 00 00 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetLibraryCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetLibraryCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0N_0040_0024_0024CB_W _003F_003F_C_0040_1BK_0040NOLBIPEH_0040_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAr_003F_0024AAa_003F_0024AAF_003F_0024AAi_003F_0024AAn_003F_0024AAd_003F_0024AAe_003F_0024AAr_0040/* Not supported: data(43 00 61 00 6D 00 65 00 72 00 61 00 46 00 69 00 6E 00 64 00 65 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EM_0040_0024_0024CBD _003F_003F_C_0040_0EM_0040LHPBPJID_0040Enumeration_003F5by_003F5serial_003F5number_003F5_003F8_003F_0024CF_0040/* Not supported: data(45 6E 75 6D 65 72 61 74 69 6F 6E 20 62 79 20 73 65 72 69 61 6C 20 6E 75 6D 62 65 72 20 27 25 68 73 27 20 72 65 74 75 72 6E 65 64 20 25 75 20 72 65 73 75 6C 74 73 2E 20 55 73 69 6E 67 20 66 69 72 73 74 20 72 65 73 75 6C 74 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0O_0040_0024_0024CB_W _003F_003F_C_0040_1BM_0040ICBIINEM_0040_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_0040/* Not supported: data(43 00 6F 00 6E 00 66 00 69 00 67 00 75 00 72 00 61 00 74 00 69 00 6F 00 6E 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0O_0040_0024_0024CBD _003F_003F_C_0040_0O_0040KIEAILHB_0040PylonNET_003F4Info_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 49 6E 66 6F 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CL_0040_0024_0024CBD _003F_003F_C_0040_0CL_0040OHBEGOAC_0040Required_003F5device_003F5info_003F5object_003F5not_0040/* Not supported: data(52 65 71 75 69 72 65 64 20 64 65 76 69 63 65 20 69 6E 66 6F 20 6F 62 6A 65 63 74 20 6E 6F 74 20 61 76 61 69 6C 61 62 6C 65 2E 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CDeviceInfo_0040Pylon_0040_00408/* Not supported: data(F4 02 1B 10 60 03 1B 10 28 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CInfoBase_0040Pylon_0040_00408/* Not supported: data(60 03 1B 10 28 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2IProperties_0040Pylon_0040_00408/* Not supported: data(28 03 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CDeviceInfo_0040Pylon_0040_00408/* Not supported: data(84 CF 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 8C 03 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInfoBase_0040Pylon_0040_00408/* Not supported: data(A4 CF 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 50 03 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IProperties_0040Pylon_0040_00408/* Not supported: data(C4 CF 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 18 03 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInfoBase_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 44 03 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IProperties_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 10 03 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_24 _003F_003F_R0_003FAUIProperties_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 50 72 6F 70 65 72 74 69 65 73 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CDeviceInfo_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 7C 03 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CDeviceInfo_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 84 CF 1B 10 8C 03 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_22 _003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 66 6F 42 61 73 65 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_24 _003F_003F_R0_003FAVCDeviceInfo_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 44 65 76 69 63 65 49 6E 66 6F 40 50 79 6C 6F 6E 40 40 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetInfoCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetInfoCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY07Q6AXXZ _003F_003F_SCDeviceInfo_0040Pylon_0040_00406B_0040/* Not supported: data(1E B2 0C 10 2E B2 0C 10 3E B2 0C 10 4E B2 0C 10 5E B2 0C 10 6E B2 0C 10 C0 C8 02 10 E4 03 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0O_0040_0024_0024CB_W _003F_003F_C_0040_1BM_0040KJGKLHLF_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAo_003F_0024AAn_003F_0024AAe_003F_0024AAn_003F_0024AAt_0040/* Not supported: data(44 00 61 00 74 00 61 00 43 00 6F 00 6D 00 70 00 6F 00 6E 00 65 00 6E 00 74 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0O_0040_0024_0024CB_W _003F_003F_C_0040_1BM_0040IACFPHHC_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAt_003F_0024AAa_003F_0024AAi_003F_0024AAn_003F_0024AAe_003F_0024AAr_0040/* Not supported: data(44 00 61 00 74 00 61 00 43 00 6F 00 6E 00 74 00 61 00 69 00 6E 00 65 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY08_0024_0024CBD _003F_003F_C_0040_08EPJLHIJG_0040bad_003F5cast_0040/* Not supported: data(62 61 64 20 63 61 73 74 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BE_0040_0024_0024CBD _003F_003F_C_0040_0BE_0040DPOFGLGK_0040OutOfRangeException_0040/* Not supported: data(4F 75 74 4F 66 52 61 6E 67 65 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BE_0040_0024_0024CBD _003F_003F_C_0040_0BE_0040KOOIPLDH_0040PayloadSize_003F5too_003F5big_0040/* Not supported: data(50 61 79 6C 6F 61 64 53 69 7A 65 20 74 6F 6F 20 62 69 67 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BJ_0040_0024_0024CBD _003F_003F_C_0040_0BJ_0040NPEJAJGA_0040InvalidArgumentException_0040/* Not supported: data(49 6E 76 61 6C 69 64 41 72 67 75 6D 65 6E 74 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BI_0040_0024_0024CBD _003F_003F_C_0040_0BI_0040CFPLBAOH_0040invalid_003F5string_003F5position_0040/* Not supported: data(69 6E 76 61 6C 69 64 20 73 74 72 69 6E 67 20 70 6F 73 69 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040_0024_0024CBD _003F_003F_C_0040_0BA_0040JFNIOLAK_0040string_003F5too_003F5long_0040/* Not supported: data(73 74 72 69 6E 67 20 74 6F 6F 20 6C 6F 6E 67 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FN_0040_0024_0024CBD _003F_003F_C_0040_0FN_0040EAMMAGKC_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 6E 65 74 5C 70 79 6C 6F 6E 6E 65 74 5C 6E 61 74 69 76 65 62 75 66 66 65 72 66 61 63 74 6F 72 79 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CE_0040_0024_0024CBD _003F_003F_C_0040_0CE_0040CPGNCONO_0040Argument_003F5pCreatedBuffer_003F5is_003F5null_0040/* Not supported: data(41 72 67 75 6D 65 6E 74 20 70 43 72 65 61 74 65 64 42 75 66 66 65 72 20 69 73 20 6E 75 6C 6C 70 74 72 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BC_0040_0024_0024CBD _003F_003F_C_0040_0BC_0040KBLGPICI_0040BadAllocException_0040/* Not supported: data(42 61 64 41 6C 6C 6F 63 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DF_0040_0024_0024CBD _003F_003F_C_0040_0DF_0040HDFLIINE_0040Could_003F5not_003F5allocate_003F5buffer_003F5in_003F5ma_0040/* Not supported: data(43 6F 75 6C 64 20 6E 6F 74 20 61 6C 6C 6F 63 61 74 65 20 62 75 66 66 65 72 20 69 6E 20 6D 61 6E 61 67 65 64 20 62 75 66 66 65 72 20 66 61 63 74 6F 72 79 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GC_0040_0024_0024CBD _003F_003F_C_0040_0GC_0040GCEMICGO_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 5C 69 6E 63 6C 75 64 65 5C 70 79 6C 6F 6E 5C 69 6E 74 65 72 6E 61 6C 5C 72 65 73 75 6C 74 70 72 69 76 61 74 65 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FP_0040_0024_0024CBD _003F_003F_C_0040_0FP_0040CLGIBDGD_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 5C 69 6E 63 6C 75 64 65 5C 70 79 6C 6F 6E 5C 69 6E 74 65 72 6E 61 6C 5C 62 75 66 66 65 72 64 61 74 61 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BC_0040_0024_0024CBD _003F_003F_C_0040_0BC_0040BABECPGA_0040Out_003F5of_003F5memory_003F4_003F5_003F_0024CFs_0040/* Not supported: data(4F 75 74 20 6F 66 20 6D 65 6D 6F 72 79 2E 20 25 73 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(58 05 1B 10 F8 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(0C 05 1B 10 F8 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00408/* Not supported: data(5C 06 1B 10 90 06 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CGrabResultData_0040Pylon_0040_00408/* Not supported: data(90 06 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00408/* Not supported: data(40 04 1B 10 74 04 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2sp_counted_base_0040detail_0040boost_0040_00408/* Not supported: data(F8 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CNativeBufferFactory_0040Pylon_0040Basler_0040_00408/* Not supported: data(10 06 1B 10 B0 03 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_20 _003F_003F_R2_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(B8 05 1B 10 B8 00 1B 10 40 00 1B 10 5C 00 1B 10 78 00 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(C0 04 1B 10 DC 01 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(58 D1 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 80 05 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(F0 D0 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 34 05 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00408/* Not supported: data(28 D2 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 B8 06 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CGrabResultData_0040Pylon_0040_00408/* Not supported: data(6C D2 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 80 06 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00408/* Not supported: data(38 D0 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 9C 04 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040sp_counted_base_0040detail_0040boost_0040_00408/* Not supported: data(08 D0 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 1C 04 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CNativeBufferFactory_0040Pylon_0040Basler_0040_00408/* Not supported: data(D8 D1 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 38 06 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(9C D1 1B 10 04 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 EC 05 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(B0 D0 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 E8 04 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 74 05 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_60 _003F_003F_R0_003FAV_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 73 70 5F 63 6F 75 6E 74 65 64 5F 69 6D 70 6C 5F 70 40 56 43 42 75 66 66 65 72 44 61 74 61 40 50 79 6C 6F 6E 40 40 40 64 65 74 61 69 6C 40 62 6F 6F 73 74 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 28 05 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_95 _003F_003F_R0_003FAV_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 73 70 5F 63 6F 75 6E 74 65 64 5F 69 6D 70 6C 5F 70 40 56 43 72 65 61 74 61 62 6C 65 47 72 61 62 52 65 73 75 6C 74 44 61 74 61 40 4D 6F 63 6B 47 72 61 62 52 65 73 75 6C 74 40 50 79 6C 6F 6E 49 6E 74 65 72 6E 61 6C 40 40 40 64 65 74 61 69 6C 40 62 6F 6F 73 74 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CGrabResultData_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 78 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_28 _003F_003F_R0_003FAVCGrabResultData_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 47 72 61 62 52 65 73 75 6C 74 44 61 74 61 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 AC 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_59 _003F_003F_R0_003FAVCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 72 65 61 74 61 62 6C 65 47 72 61 62 52 65 73 75 6C 74 44 61 74 61 40 4D 6F 63 6B 47 72 61 62 52 65 73 75 6C 74 40 50 79 6C 6F 6E 49 6E 74 65 72 6E 61 6C 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 90 04 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_84 _003F_003F_R0_003FAV_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 47 72 61 62 52 65 73 75 6C 74 50 74 72 49 6D 61 67 65 54 40 41 42 56 3F 24 73 68 61 72 65 64 5F 70 74 72 40 56 43 47 72 61 62 52 65 73 75 6C 74 44 61 74 61 40 50 79 6C 6F 6E 40 40 40 62 6F 6F 73 74 40 40 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3sp_counted_base_0040detail_0040boost_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 14 04 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_35 _003F_003F_R0_003FAVsp_counted_base_0040detail_0040boost_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 73 70 5F 63 6F 75 6E 74 65 64 5F 62 61 73 65 40 64 65 74 61 69 6C 40 62 6F 6F 73 74 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CNativeBufferFactory_0040Pylon_0040Basler_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 2C 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_40 _003F_003F_R0_003FAVCNativeBufferFactory_0040Pylon_0040Basler_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 4E 61 74 69 76 65 42 75 66 66 65 72 46 61 63 74 6F 72 79 40 50 79 6C 6F 6E 40 42 61 73 6C 65 72 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 05 00 00 00 D4 05 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_51 _003F_003F_R0_003FAV_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 69 66 73 74 72 65 61 6D 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 DC 04 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_50 _003F_003F_R0_003FAV_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 62 61 73 69 63 5F 66 69 6C 65 62 75 66 40 44 55 3F 24 63 68 61 72 5F 74 72 61 69 74 73 40 44 40 73 74 64 40 40 40 73 74 64 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 58 D1 1B 10 80 05 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 F0 D0 1B 10 34 05 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 28 D2 1B 10 B8 06 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 38 D0 1B 10 9C 04 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4sp_counted_base_0040detail_0040boost_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 08 D0 1B 10 1C 04 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CNativeBufferFactory_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 D8 D1 1B 10 38 06 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040/* Not supported: data(00 00 00 00 70 00 00 00 04 00 00 00 9C D1 1B 10 EC 05 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 B0 D0 1B 10 E8 04 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY06Q6AXXZ _003F_003F_7_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00406B_0040/* Not supported: data(58 47 03 10 77 47 03 10 BE 3A 03 10 7D 47 03 10 83 47 03 10 89 47 03 10 A4 05 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY06Q6AXXZ _003F_003F_7_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00406B_0040/* Not supported: data(B8 46 03 10 E1 46 03 10 BE 3A 03 10 F6 46 03 10 FC 46 03 10 02 47 03 10 90 05 1B 10) */;

	internal unsafe static locale.facet* _003F_Psave_0040_003F_0024_Facetptr_0040V_003F_0024codecvt_0040DDU_Mbstatet_0040_0040_0040std_0040_0040_0040std_0040_00402PBVfacet_0040locale_00402_0040B/* Not supported: data(00 00 00 00) */;

	internal static _Mbstatet _003F_Stinit_0040_003F1_003F_003F_Init_0040_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040IAEXPAU_iobuf_0040_0040W4_Initfl_004023_0040_0040Z_00404U_Mbstatet_0040_0040A/* Not supported: data(00 00 00 00 00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040Q6AXXZ _003F_003F_7_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040/* Not supported: data(FC 3E 03 10 20 3F 03 10 44 3F 03 10 6E 40 03 10 7D 41 03 10 55 A4 0C 10 E2 41 03 10 74 43 03 10 FB 43 03 10 7B 44 03 10 13 45 03 10 89 45 03 10 CF 45 03 10 23 46 03 10 61 46 03 10 44 05 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVbad_cast_0040std_0040_0040_00408_003F_003F0bad_cast_0040std_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z12/* Not supported: data(00 00 00 00 C4 CA 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 0C 00 00 00 38 8C 01 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVbad_cast_0040std_0040_0040/* Not supported: data(02 00 00 00 A0 19 1B 10 BC 19 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVbad_cast_0040std_0040_0040/* Not supported: data(00 00 00 00 E0 87 02 10 00 00 00 00 D8 19 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY01_0024_0024CBH _003F_003F_8_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00407B_0040/* Not supported: data(00 00 00 00 70 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040/* Not supported: data(18 48 03 10 48 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_19 _003F_003F_R0_003FAUIImage_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 49 6D 61 67 65 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IImage_0040Pylon_0040_00408/* Not supported: data(94 D0 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 64 04 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2IImage_0040Pylon_0040_00408/* Not supported: data(74 04 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IImage_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 5C 04 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4IImage_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 94 D0 1B 10 64 04 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0N_0040Q6AXXZ _003F_003F_7IImage_0040Pylon_0040_00406B_0040/* Not supported: data(52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 FC 05 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0N_0040Q6AXXZ _003F_003F_7_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040/* Not supported: data(18 3B 03 10 6F 3B 03 10 9F 3B 03 10 CA 3B 03 10 F2 3B 03 10 1A 3C 03 10 20 3C 03 10 4A 3C 03 10 50 3C 03 10 7A 3C 03 10 FC 3C 03 10 2A 3D 03 10 F8 04 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVexception_0040std_0040_0040_00408_003F_003F0exception_0040std_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z12/* Not supported: data(00 00 00 00 84 CA 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 0C 00 00 00 20 6D 00 10) */;

	internal static _0024ArrayType_0024_0024_0024BY03Q6AXXZ _003F_003F_7CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00406B_0040/* Not supported: data(90 52 03 10 8E B2 0C 10 9E B2 0C 10 60 00 00 06) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_20 _003F_003F_R0_003FAVbad_alloc_0040std_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 62 61 64 5F 61 6C 6C 6F 63 40 73 74 64 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY06Q6AXXZ _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040/* Not supported: data(B8 3A 03 10 52 D9 0C 10 BE 3A 03 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 AC 04 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0OutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 B0 C8 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 5A A7 0C 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 04 19 1B 10 00 15 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 4A A7 0C 10 00 00 00 00 20 19 1B 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 3C 19 1B 10 00 15 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0BadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 9C C9 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 7A A7 0C 10) */;

	internal static _s__ThrowInfo _TI2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 6A A7 0C 10 00 00 00 00 58 19 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0InvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 70 C8 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 AA A7 0C 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 28 1A 1B 10 00 15 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 9A A7 0C 10 00 00 00 00 44 1A 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY04Q6AXXZ _003F_003F_7CNativeBufferFactory_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(4C 49 03 10 8B 50 03 10 AC 50 03 10 CF 50 03 10 C8 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_27 _003F_003F_R0_003FAUIBufferFactory_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 42 75 66 66 65 72 46 61 63 74 6F 72 79 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IBufferFactory_0040Pylon_0040_00408/* Not supported: data(E4 CF 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 D4 03 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2IBufferFactory_0040Pylon_0040_00408/* Not supported: data(B0 03 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IBufferFactory_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 CC 03 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4IBufferFactory_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 E4 CF 1B 10 D4 03 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY04Q6AXXZ _003F_003F_7IBufferFactory_0040Pylon_0040_00406B_0040/* Not supported: data(52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 52 D9 0C 10 2C 04 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_36 _003F_003F_R0_003FAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 4E 6F 64 65 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_40 _003F_003F_R0_003FAUIRegister_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 52 65 67 69 73 74 65 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAUICommand_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 43 6F 6D 6D 61 6E 64 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAUIInteger_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 49 6E 74 65 67 65 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_37 _003F_003F_R0_003FAUIFloat_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 46 6C 6F 61 74 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_36 _003F_003F_R0_003FAUIPort_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 50 6F 72 74 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040_0024_0024CBD _003F_003F_C_0040_0BA_0040FKMMAIFC_0040AccessException_0040/* Not supported: data(41 63 63 65 73 73 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0IM_0040_0024_0024CBD _003F_003F_C_0040_0IM_0040BDBNPAAA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 61 63 6B 61 67 65 73 5C 67 65 6E 69 63 61 6D 66 6F 72 70 79 6C 6F 6E 2E 33 2E 31 2E 30 2E 35 32 34 36 5C 6C 69 62 5C 6E 61 74 69 76 65 5C 6C 69 62 72 61 72 79 5C 63 70 70 5C 69 6E 63 6C 75 64 65 5C 67 65 6E 61 70 69 5C 6E 6F 64 65 6D 61 70 72 65 66 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CK_0040_0024_0024CBD _003F_003F_C_0040_0CK_0040MIBKMBOE_0040Feature_003F5not_003F5present_003F5_003F_0024CIreference_003F5_0040/* Not supported: data(46 65 61 74 75 72 65 20 6E 6F 74 20 70 72 65 73 65 6E 74 20 28 72 65 66 65 72 65 6E 63 65 20 6E 6F 74 20 76 61 6C 69 64 29 00) */;

	internal static _0024ArrayType_0024_0024_0024BY06_0024_0024CBD _003F_003F_C_0040_06OIEJKIHP_0040Device_0040/* Not supported: data(44 65 76 69 63 65 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CB_W _003F_003F_C_0040_1BI_0040LJIHCIPI_0040_003F_0024AAG_003F_0024AAe_003F_0024AAn_003F_0024AAI_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_0040/* Not supported: data(47 00 65 00 6E 00 49 00 43 00 61 00 6D 00 46 00 69 00 6C 00 65 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(DC 06 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(A8 D3 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 00 07 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 F8 06 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_46 _003F_003F_R0_003FAVCNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 4E 6F 64 65 4D 61 70 46 61 63 74 6F 72 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 A8 D3 1B 10 00 07 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 84 D4 1B 10 48 07 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(20 82 02 10 BD 00 00 06) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_42 _003F_003F_R0_003FAVCNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 4E 6F 64 65 4D 61 70 52 65 66 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(E0 D3 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 BC 07 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(24 07 1B 10 90 07 1B 10 58 07 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 AC 07 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 E0 D3 1B 10 BC 07 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_97 _003F_003F_R0_003FAV_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 4E 6F 64 65 4D 61 70 52 65 66 54 40 56 43 47 65 6E 65 72 69 63 5F 58 4D 4C 4C 6F 61 64 65 72 50 61 72 61 6D 73 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(18 D4 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 80 07 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_55 _003F_003F_R0_003FAVCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 47 65 6E 65 72 69 63 5F 58 4D 4C 4C 6F 61 64 65 72 50 61 72 61 6D 73 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(58 07 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 40 07 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(84 D4 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 48 07 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(90 07 1B 10 58 07 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 74 07 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 18 D4 1B 10 80 07 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040Q6AXXZ _003F_003F_7_003F_0024CNodeMapRefT_0040VCGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(20 82 02 10 CC 59 04 10 40 53 04 10 A0 53 04 10 B0 54 04 10 50 55 04 10 F0 55 04 10 90 56 04 10 30 57 04 10 D0 57 04 10 80 58 04 10 BE 00 00 06) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAUIDestroy_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 44 65 73 74 72 6F 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAUINodeMap_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 4E 6F 64 65 4D 61 70 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0AccessException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 EC C8 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 FA A7 0C 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 9C 1B 1B 10 00 15 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVAccessException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 EA A7 0C 10 00 00 00 00 B8 1B 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040Q6AXXZ _003F_003F_7CNodeMapRef_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(20 82 02 10 70 52 04 10 40 53 04 10 A0 53 04 10 B0 54 04 10 50 55 04 10 F0 55 04 10 90 56 04 10 30 57 04 10 D0 57 04 10 80 58 04 10 E0 07 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_SCNodeMapFactory_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(C0 50 04 10 CC 07 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040_0024_0024CB_W _003F_003F_C_0040_1BG_0040FPAEOFNE_0040_003F_0024AAG_003F_0024AAr_003F_0024AAa_003F_0024AAb_003F_0024AAR_003F_0024AAe_003F_0024AAs_003F_0024AAu_003F_0024AAl_003F_0024AAt_0040/* Not supported: data(47 00 72 00 61 00 62 00 52 00 65 00 73 00 75 00 6C 00 74 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0P_0040_0024_0024CBD _003F_003F_C_0040_0P_0040OLEEINBC_0040PylonNET_003F4Image_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 49 6D 61 67 65 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FL_0040_0024_0024CBD _003F_003F_C_0040_0FL_0040MFKIOCJI_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 72 61 62 52 65 73 75 6C 74 3A 3A 53 74 72 69 64 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EN_0040_0024_0024CBD _003F_003F_C_0040_0EN_0040NIEGAGOG_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 72 61 62 52 65 73 75 6C 74 3A 3A 53 74 72 69 64 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EF_0040_0024_0024CBD _003F_003F_C_0040_0EF_0040HDKOHCAB_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 72 61 62 52 65 73 75 6C 74 3A 3A 53 74 72 69 64 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EC_0040_0024_0024CBD _003F_003F_C_0040_0EC_0040HJAIIOK_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 72 61 62 52 65 73 75 6C 74 3A 3A 53 74 72 69 64 65 3A 3A 67 65 74 28 29 2E 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetImageCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetImageCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_20 _003F_003F_R2CImageAdapter_0040Pylon_0040Basler_0040_00408/* Not supported: data(08 08 1B 10 BC 08 1B 10 7C 08 1B 10 40 08 1B 10 74 04 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_16 _003F_003F_R2CPylonImage_0040Pylon_0040_00408/* Not supported: data(BC 08 1B 10 7C 08 1B 10 40 08 1B 10 74 04 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CPylonImageBase_0040Pylon_0040_00408/* Not supported: data(7C 08 1B 10 40 08 1B 10 74 04 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CImageAdapter_0040Pylon_0040Basler_0040_00408/* Not supported: data(24 D5 1B 10 04 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 F0 08 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CPylonImage_0040Pylon_0040_00408/* Not supported: data(50 D5 1B 10 03 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 AC 08 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_27 _003F_003F_R0_003FAUIReusableImage_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 52 65 75 73 61 62 6C 65 49 6D 61 67 65 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2IReusableImage_0040Pylon_0040_00408/* Not supported: data(40 08 1B 10 74 04 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3IReusableImage_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 24 08 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040IReusableImage_0040Pylon_0040_00408/* Not supported: data(94 D5 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 30 08 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CPylonImageBase_0040Pylon_0040_00408/* Not supported: data(70 D5 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 6C 08 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CPylonImage_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 04 00 00 00 98 08 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_24 _003F_003F_R0_003FAVCPylonImage_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 50 79 6C 6F 6E 49 6D 61 67 65 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CPylonImageBase_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 5C 08 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_28 _003F_003F_R0_003FAVCPylonImageBase_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 50 79 6C 6F 6E 49 6D 61 67 65 42 61 73 65 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CImageAdapter_0040Pylon_0040Basler_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 05 00 00 00 D8 08 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_33 _003F_003F_R0_003FAVCImageAdapter_0040Pylon_0040Basler_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6D 61 67 65 41 64 61 70 74 65 72 40 50 79 6C 6F 6E 40 42 61 73 6C 65 72 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CImageAdapter_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 24 D5 1B 10 F0 08 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0CD_0040Q6AXXZ _003F_003F_7CImageAdapter_0040Pylon_0040Basler_0040_00406B_0040/* Not supported: data(E8 6A 04 10 0B AB 0C 10 2C AB 0C 10 3C AB 0C 10 4C AB 0C 10 5C AB 0C 10 6C AB 0C 10 7C AB 0C 10 8C AB 0C 10 9C AB 0C 10 AC AB 0C 10 BC AB 0C 10 CC AB 0C 10 DC AB 0C 10 EC AB 0C 10 FC AB 0C 10 0C AC 0C 10 1C AC 0C 10 2C AC 0C 10 3C AC 0C 10 4C AC 0C 10 5C AC 0C 10 6C AC 0C 10 7C AC 0C 10 8C AC 0C 10 9C AC 0C 10 AC AC 0C 10 BC AC 0C 10 CC AC 0C 10 DC AC 0C 10 EC AC 0C 10 FC AC 0C 10 0C AD 0C 10 1C AD 0C 10 C2 00 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY0BC_0040_0024_0024CB_W _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040/* Not supported: data(49 00 6D 00 61 00 67 00 65 00 44 00 65 00 63 00 6F 00 6D 00 70 00 72 00 65 00 73 00 73 00 6F 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BD_0040_0024_0024CBD _003F_003F_C_0040_0BD_0040PDFJHOKG_0040PylonNET_003F4Interface_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 49 6E 74 65 72 66 61 63 65 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GD_0040_0024_0024CBD _003F_003F_C_0040_0GD_0040EIGBINIJ_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 3A 3A 44 65 73 74 72 6F 79 49 6E 74 65 72 66 61 63 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FF_0040_0024_0024CBD _003F_003F_C_0040_0FF_0040JMPCKEHC_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 3A 3A 44 65 73 74 72 6F 79 49 6E 74 65 72 66 61 63 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EN_0040_0024_0024CBD _003F_003F_C_0040_0EN_0040PACAELFK_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 3A 3A 44 65 73 74 72 6F 79 49 6E 74 65 72 66 61 63 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EK_0040_0024_0024CBD _003F_003F_C_0040_0EK_0040OENPABGH_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 54 72 61 6E 73 70 6F 72 74 4C 61 79 65 72 3A 3A 44 65 73 74 72 6F 79 49 6E 74 65 72 66 61 63 65 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FH_0040_0024_0024CBD _003F_003F_C_0040_0FH_0040NJHEGMDL_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 54 6C 46 61 63 74 6F 72 79 3A 3A 52 65 6C 65 61 73 65 54 6C 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EJ_0040_0024_0024CBD _003F_003F_C_0040_0EJ_0040KOMACKCL_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 54 6C 46 61 63 74 6F 72 79 3A 3A 52 65 6C 65 61 73 65 54 6C 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EB_0040_0024_0024CBD _003F_003F_C_0040_0EB_0040OLOHLDAN_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 54 6C 46 61 63 74 6F 72 79 3A 3A 52 65 6C 65 61 73 65 54 6C 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DO_0040_0024_0024CBD _003F_003F_C_0040_0DO_0040FOKEADJK_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 54 6C 46 61 63 74 6F 72 79 3A 3A 52 65 6C 65 61 73 65 54 6C 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FE_0040_0024_0024CBD _003F_003F_C_0040_0FE_0040EFELNAAF_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EG_0040_0024_0024CBD _003F_003F_C_0040_0EG_0040MLIIEOAE_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DO_0040_0024_0024CBD _003F_003F_C_0040_0DO_0040FBOKPCOA_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 49 73 4F 70 65 6E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DL_0040_0024_0024CBD _003F_003F_C_0040_0DL_0040GFJICLNB_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 49 73 4F 70 65 6E 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FD_0040_0024_0024CBD _003F_003F_C_0040_0FD_0040PFNMKPFA_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 43 6C 6F 73 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EF_0040_0024_0024CBD _003F_003F_C_0040_0EF_0040MJLGJOK_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 43 6C 6F 73 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DN_0040_0024_0024CBD _003F_003F_C_0040_0DN_0040NBJEDLGL_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 43 6C 6F 73 65 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DK_0040_0024_0024CBD _003F_003F_C_0040_0DK_0040IBNJDKHI_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 49 6E 74 65 72 66 61 63 65 3A 3A 43 6C 6F 73 65 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FO_0040_0024_0024CBD _003F_003F_C_0040_0FO_0040IDOOEOJG_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 50 61 72 61 6D 65 74 65 72 43 6F 6C 6C 65 63 74 69 6F 6E 3A 3A 41 74 74 61 63 68 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FA_0040_0024_0024CBD _003F_003F_C_0040_0FA_0040IKHPBCAL_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 50 61 72 61 6D 65 74 65 72 43 6F 6C 6C 65 63 74 69 6F 6E 3A 3A 41 74 74 61 63 68 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EI_0040_0024_0024CBD _003F_003F_C_0040_0EI_0040MDFAACDN_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 50 61 72 61 6D 65 74 65 72 43 6F 6C 6C 65 63 74 69 6F 6E 3A 3A 41 74 74 61 63 68 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EF_0040_0024_0024CBD _003F_003F_C_0040_0EF_0040KGJOBFGC_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 50 61 72 61 6D 65 74 65 72 43 6F 6C 6C 65 63 74 69 6F 6E 3A 3A 41 74 74 61 63 68 2E 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetInterfaceCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetInterfaceCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0HA_0040_0024_0024CBD _003F_003F_C_0040_0HA_0040POIDNMJJ_0040System_003F4Exception_003F5caught_003F5while_003F5e_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 65 6E 75 6D 65 72 61 74 69 6E 67 20 69 6E 74 65 72 66 61 63 65 73 20 69 6E 20 49 6E 74 65 72 66 61 63 65 46 69 6E 64 65 72 3A 3A 45 6E 75 6D 65 72 61 74 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GC_0040_0024_0024CBD _003F_003F_C_0040_0GC_0040EKODEHPE_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 65 6E 75 6D 65 72 61 74 69 6E 67 20 69 6E 74 65 72 66 61 63 65 73 20 69 6E 20 49 6E 74 65 72 66 61 63 65 46 69 6E 64 65 72 3A 3A 45 6E 75 6D 65 72 61 74 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FK_0040_0024_0024CBD _003F_003F_C_0040_0FK_0040FHHPGHB_0040Exception_003F5caught_003F5while_003F5enumerat_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 65 6E 75 6D 65 72 61 74 69 6E 67 20 69 6E 74 65 72 66 61 63 65 73 20 69 6E 20 49 6E 74 65 72 66 61 63 65 46 69 6E 64 65 72 3A 3A 45 6E 75 6D 65 72 61 74 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FH_0040_0024_0024CBD _003F_003F_C_0040_0FH_0040NOEPHMEN_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 65 6E 75 6D 65 72 61 74 69 6E 67 20 69 6E 74 65 72 66 61 63 65 73 20 69 6E 20 49 6E 74 65 72 66 61 63 65 46 69 6E 64 65 72 3A 3A 45 6E 75 6D 65 72 61 74 65 28 29 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040_0024_0024CB_W _003F_003F_C_0040_1CA_0040ENPBIIMI_0040_003F_0024AAI_003F_0024AAn_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAf_003F_0024AAa_003F_0024AAc_003F_0024AAe_003F_0024AAF_003F_0024AAi_003F_0024AAn_003F_0024AAd_003F_0024AAe_003F_0024AAr_0040/* Not supported: data(49 00 6E 00 74 00 65 00 72 00 66 00 61 00 63 00 65 00 46 00 69 00 6E 00 64 00 65 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CO_0040_0024_0024CBD _003F_003F_C_0040_0CO_0040KNLMHBLD_0040Required_003F5interface_003F5info_003F5object_003F5_0040/* Not supported: data(52 65 71 75 69 72 65 64 20 69 6E 74 65 72 66 61 63 65 20 69 6E 66 6F 20 6F 62 6A 65 63 74 20 6E 6F 74 20 61 76 61 69 6C 61 62 6C 65 2E 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CInterfaceInfo_0040Pylon_0040_00408/* Not supported: data(14 09 1B 10 60 03 1B 10 28 03 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CInterfaceInfo_0040Pylon_0040_00408/* Not supported: data(B8 D5 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 40 09 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CInterfaceInfo_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 30 09 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CInterfaceInfo_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 B8 D5 1B 10 40 09 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_27 _003F_003F_R0_003FAVCInterfaceInfo_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6E 74 65 72 66 61 63 65 49 6E 66 6F 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY07Q6AXXZ _003F_003F_SCInterfaceInfo_0040Pylon_0040_00406B_0040/* Not supported: data(1E B2 0C 10 2E B2 0C 10 3E B2 0C 10 1E B3 0C 10 2E B3 0C 10 6E B2 0C 10 70 DB 06 10 44 0A 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0P_0040_0024_0024CB_W _003F_003F_C_0040_1BO_0040NPADJIBL_0040_003F_0024AAI_003F_0024AAp_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAo_003F_0024AAr_0040/* Not supported: data(49 00 70 00 43 00 6F 00 6E 00 66 00 69 00 67 00 75 00 72 00 61 00 74 00 6F 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY09_0024_0024CBD _003F_003F_C_0040_09CBEPGMLJ_0040255_003F40_003F40_003F40_0040/* Not supported: data(32 35 35 2E 30 2E 30 2E 30 00) */;

	internal static _0024ArrayType_0024_0024_0024BY07_0024_0024CBD _003F_003F_C_0040_07OHKHACFK_00400_003F40_003F40_003F40_0040/* Not supported: data(30 2E 30 2E 30 2E 30 00) */;

	internal unsafe static sbyte* Pylon_002E_003FA0x6565c3d8_002EBaslerGigEDeviceClass/* Not supported: data(30 03 0D 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0DG_0040_0024_0024CBD _003F_003F_C_0040_0DG_0040CCOAJJFO_0040Element_003F5is_003F5undefined_003F4_003F5Move_003F5inde_0040/* Not supported: data(45 6C 65 6D 65 6E 74 20 69 73 20 75 6E 64 65 66 69 6E 65 64 2E 20 4D 6F 76 65 20 69 6E 64 65 78 20 74 6F 20 61 20 76 61 6C 69 64 20 70 6F 73 69 74 69 6F 6E 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BO_0040_0024_0024CB_W _003F_003F_C_0040_1DM_0040GEPOEKKO_0040_003F_0024AAP_003F_0024AAa_003F_0024AAr_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAC_003F_0024AAo_003F_0024AAl_003F_0024AAl_003F_0024AAe_003F_0024AAc_0040/* Not supported: data(50 00 61 00 72 00 61 00 6D 00 65 00 74 00 65 00 72 00 43 00 6F 00 6C 00 6C 00 65 00 63 00 74 00 69 00 6F 00 6E 00 45 00 6E 00 75 00 6D 00 65 00 72 00 61 00 74 00 6F 00 72 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY09_0024_0024CB_W _003F_003F_C_0040_1BE_0040KNEJKFBF_0040_003F_0024AAp_003F_0024AAi_003F_0024AAx_003F_0024AAe_003F_0024AAl_003F_0024AAT_003F_0024AAy_003F_0024AAp_003F_0024AAe_0040/* Not supported: data(70 00 69 00 78 00 65 00 6C 00 54 00 79 00 70 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CB_W _003F_003F_C_0040_1BI_0040FCJIEANP_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAW_003F_0024AAi_003F_0024AAd_003F_0024AAt_003F_0024AAh_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 57 00 69 00 64 00 74 00 68 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0N_0040_0024_0024CB_W _003F_003F_C_0040_1BK_0040KGMHIFHA_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAH_003F_0024AAe_003F_0024AAi_003F_0024AAg_003F_0024AAh_003F_0024AAt_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 48 00 65 00 69 00 67 00 68 00 74 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BA_0040_0024_0024CB_W _003F_003F_C_0040_1CA_0040HEBABCJF_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAP_003F_0024AAi_003F_0024AAx_003F_0024AAe_003F_0024AAl_003F_0024AAT_003F_0024AAy_003F_0024AAp_003F_0024AAe_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 50 00 69 00 78 00 65 00 6C 00 54 00 79 00 70 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BL_0040_0024_0024CB_W _003F_003F_C_0040_1DG_0040KOBFFOGC_0040_003F_0024AAd_003F_0024AAe_003F_0024AAs_003F_0024AAt_003F_0024AAi_003F_0024AAn_003F_0024AAa_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_003F_0024AAB_003F_0024AAu_003F_0024AAf_003F_0024AAf_0040/* Not supported: data(64 00 65 00 73 00 74 00 69 00 6E 00 61 00 74 00 69 00 6F 00 6E 00 42 00 75 00 66 00 66 00 65 00 72 00 53 00 69 00 7A 00 65 00 42 00 79 00 74 00 65 00 73 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CB_W _003F_003F_C_0040_1BI_0040IBJCHIML_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 49 00 6D 00 61 00 67 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BG_0040_0024_0024CB_W _003F_003F_C_0040_1CM_0040HIIIJIFA_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAB_003F_0024AAu_003F_0024AAf_003F_0024AAf_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAi_003F_0024AAz_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 42 00 75 00 66 00 66 00 65 00 72 00 53 00 69 00 7A 00 65 00 42 00 79 00 74 00 65 00 73 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0P_0040_0024_0024CB_W _003F_003F_C_0040_1BO_0040DJJHMOJ_0040_003F_0024AAs_003F_0024AAo_003F_0024AAu_003F_0024AAr_003F_0024AAc_003F_0024AAe_003F_0024AAP_003F_0024AAa_003F_0024AAd_003F_0024AAd_003F_0024AAi_003F_0024AAn_003F_0024AAg_003F_0024AAX_0040/* Not supported: data(73 00 6F 00 75 00 72 00 63 00 65 00 50 00 61 00 64 00 64 00 69 00 6E 00 67 00 58 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CImageFormatConverter_0040Pylon_0040_00408/* Not supported: data(64 09 1B 10 EC 09 1B 10 08 0A 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CImageFormatConverterParams_Params_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(80 09 1B 10 B4 09 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CImageFormatConverterParams_Params_v7_2_0_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(B4 09 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CImageFormatConverterParams_Params_v7_2_0_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(60 D6 1B 10 00 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 A4 09 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CImageFormatConverterParams_Params_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(08 D6 1B 10 01 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 DC 09 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CImageFormatConverter_0040Pylon_0040_00408/* Not supported: data(DC D5 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 34 0A 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CImageFormatConverterParams_Params_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(08 D6 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 DC 09 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CImageFormatConverterParams_Params_v7_2_0_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(60 D6 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 A4 09 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CImageFormatConverterParams_Params_v7_2_0_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 9C 09 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_82 _003F_003F_R0_003FAVCImageFormatConverterParams_Params_v7_2_0_0040Basler_ImageFormatConverterParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6D 61 67 65 46 6F 72 6D 61 74 43 6F 6E 76 65 72 74 65 72 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 5F 76 37 5F 32 5F 30 40 42 61 73 6C 65 72 5F 49 6D 61 67 65 46 6F 72 6D 61 74 43 6F 6E 76 65 72 74 65 72 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CImageFormatConverterParams_Params_0040Basler_ImageFormatConverterParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 D0 09 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_75 _003F_003F_R0_003FAVCImageFormatConverterParams_Params_0040Basler_ImageFormatConverterParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6D 61 67 65 46 6F 72 6D 61 74 43 6F 6E 76 65 72 74 65 72 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 40 42 61 73 6C 65 72 5F 49 6D 61 67 65 46 6F 72 6D 61 74 43 6F 6E 76 65 72 74 65 72 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CImageFormatConverter_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 24 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_34 _003F_003F_R0_003FAVCImageFormatConverter_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 49 6D 61 67 65 46 6F 72 6D 61 74 43 6F 6E 76 65 72 74 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CImageFormatConverter_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 DC D5 1B 10 34 0A 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0O_0040Q6AXXZ _003F_003F_SCImageFormatConverter_0040Pylon_0040_00406B_0040/* Not supported: data(F0 87 07 10 2C AD 0C 10 3C AD 0C 10 4C AD 0C 10 5C AD 0C 10 6C AD 0C 10 7C AD 0C 10 8C AD 0C 10 9C AD 0C 10 AC AD 0C 10 BC AD 0C 10 CC AD 0C 10 DC AD 0C 10 8C 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_39 _003F_003F_R0_003FAUIBoolean_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 42 6F 6F 6C 65 61 6E 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BK_0040_0024_0024CBD _003F_003F_C_0040_0BK_0040EEBBNCLF_0040PylonNET_003F4Camera_003F4Parameter_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 43 61 6D 65 72 61 2E 50 61 72 61 6D 65 74 65 72 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BG_0040_0024_0024CBD _003F_003F_C_0040_0BG_0040NCFAIKFK_0040LogicalErrorException_0040/* Not supported: data(4C 6F 67 69 63 61 6C 45 72 72 6F 72 45 78 63 65 70 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0IJ_0040_0024_0024CBD _003F_003F_C_0040_0IJ_0040KKCHFAFL_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 61 63 6B 61 67 65 73 5C 67 65 6E 69 63 61 6D 66 6F 72 70 79 6C 6F 6E 2E 33 2E 31 2E 30 2E 35 32 34 36 5C 6C 69 62 5C 6E 61 74 69 76 65 5C 6C 69 62 72 61 72 79 5C 63 70 70 5C 69 6E 63 6C 75 64 65 5C 67 65 6E 61 70 69 5C 70 6F 69 6E 74 65 72 2E 68 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BK_0040_0024_0024CBD _003F_003F_C_0040_0BK_0040GPKLLMPP_0040NULL_003F5pointer_003F5dereferenced_0040/* Not supported: data(4E 55 4C 4C 20 70 6F 69 6E 74 65 72 20 64 65 72 65 66 65 72 65 6E 63 65 64 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GE_0040_0024_0024CBD _003F_003F_C_0040_0GE_0040GFIGOIMH_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 45 6E 75 6D 50 61 72 61 6D 65 74 65 72 3A 3A 43 61 6E 53 65 74 56 61 6C 75 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FG_0040_0024_0024CBD _003F_003F_C_0040_0FG_0040FOHGNNID_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 45 6E 75 6D 50 61 72 61 6D 65 74 65 72 3A 3A 43 61 6E 53 65 74 56 61 6C 75 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040GLKPKHJG_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 45 6E 75 6D 50 61 72 61 6D 65 74 65 72 3A 3A 43 61 6E 53 65 74 56 61 6C 75 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EL_0040_0024_0024CBD _003F_003F_C_0040_0EL_0040NFJIBLOO_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 45 6E 75 6D 50 61 72 61 6D 65 74 65 72 3A 3A 43 61 6E 53 65 74 56 61 6C 75 65 28 29 2E 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(58 0A 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(80 D7 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 7C 0A 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 74 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_88 _003F_003F_R0_003FAV_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 50 6F 69 6E 74 65 72 40 55 49 45 6E 75 6D 45 6E 74 72 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 55 49 42 61 73 65 40 32 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 80 D7 1B 10 7C 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_43 _003F_003F_R0_003FAUIEnumeration_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 45 6E 75 6D 65 72 61 74 69 6F 6E 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_36 _003F_003F_R0_003FAUIBase_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 42 61 73 65 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024CPointer_0040UIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(E4 F2 07 10 DC 00 00 06) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0LogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 5C C9 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 2A A8 0C 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 C8 1D 1B 10 00 15 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVLogicalErrorException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 1A A8 0C 10 00 00 00 00 E4 1D 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_41 _003F_003F_R0_003FAUIEnumEntry_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 45 6E 75 6D 45 6E 74 72 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetParameterCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetParameterCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DA_0040_0024_0024CBD _003F_003F_C_0040_0DA_0040FNFHBBJE_0040Attaching_003F5node_003F5to_003F5parameter_003F5fai_0040/* Not supported: data(41 74 74 61 63 68 69 6E 67 20 6E 6F 64 65 20 74 6F 20 70 61 72 61 6D 65 74 65 72 20 66 61 69 6C 65 64 2C 20 56 61 6C 75 65 3D 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CG_0040_0024_0024CBD _003F_003F_C_0040_0CG_0040DIIHKGJP_0040Attaching_003F5node_003F5map_003F5failed_003F_0024CB_003F5kvp_003F3_0040/* Not supported: data(41 74 74 61 63 68 69 6E 67 20 6E 6F 64 65 20 6D 61 70 20 66 61 69 6C 65 64 21 20 6B 76 70 3A 20 27 25 68 73 27 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(E8 0A 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(A0 0A 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(A0 D8 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 0C 0B 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(10 D8 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 C4 0A 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 04 0B 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_87 _003F_003F_R0_003FAV_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 50 6F 69 6E 74 65 72 40 55 49 53 65 6C 65 63 74 6F 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 55 49 42 61 73 65 40 32 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 BC 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_87 _003F_003F_R0_003FAV_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 50 6F 69 6E 74 65 72 40 55 49 43 61 74 65 67 6F 72 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 55 49 42 61 73 65 40 32 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 A0 D8 1B 10 0C 0B 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 10 D8 1B 10 C4 0A 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_40 _003F_003F_R0_003FAUICategory_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 43 61 74 65 67 6F 72 79 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024CPointer_0040UICategory_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(44 9A 08 10 1C 0B 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_40 _003F_003F_R0_003FAUISelector_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 53 65 6C 65 63 74 6F 72 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024CPointer_0040UISelector_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(98 9A 08 10 E1 00 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY0GE_0040_0024_0024CBD _003F_003F_C_0040_0GE_0040NFEIOINN_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 52 65 61 64 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FG_0040_0024_0024CBD _003F_003F_C_0040_0FG_0040JAAFGIBB_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 52 65 61 64 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040KFNMBCAE_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 52 65 61 64 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EL_0040_0024_0024CBD _003F_003F_C_0040_0EL_0040GEEPGEEA_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 52 65 61 64 61 62 6C 65 3A 3A 67 65 74 28 29 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0GE_0040_0024_0024CBD _003F_003F_C_0040_0GE_0040EOICKHBP_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 57 72 69 74 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FG_0040_0024_0024CBD _003F_003F_C_0040_0FG_0040BGPIIGHJ_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 57 72 69 74 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040CDCBPMGM_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 57 72 69 74 61 62 6C 65 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EL_0040_0024_0024CBD _003F_003F_C_0040_0EL_0040CCAELOMM_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 47 65 6E 41 70 69 50 61 72 61 6D 65 74 65 72 3A 3A 49 73 57 72 69 74 61 62 6C 65 3A 3A 67 65 74 28 29 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY06_0024_0024CBD _003F_003F_C_0040_06HPGEIPLA_0040_003F_0024DMnull_003F_0024DO_0040/* Not supported: data(3C 6E 75 6C 6C 3E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EB_0040_0024_0024CBD _003F_003F_C_0040_0EB_0040MLIPDIGG_0040Registered_003F5genapi_003F5callback_003F5for_003F5_0040/* Not supported: data(52 65 67 69 73 74 65 72 65 64 20 67 65 6E 61 70 69 20 63 61 6C 6C 62 61 63 6B 20 66 6F 72 20 6E 6F 64 65 20 27 25 68 73 27 2E 20 48 61 6E 64 6C 65 3A 20 25 70 3B 20 25 41 64 64 72 3A 20 25 70 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DJ_0040_0024_0024CBD _003F_003F_C_0040_0DJ_0040JMFONCO_0040Unregistering_003F5genapi_003F5callback_003F5f_0040/* Not supported: data(55 6E 72 65 67 69 73 74 65 72 69 6E 67 20 67 65 6E 61 70 69 20 63 61 6C 6C 62 61 63 6B 20 66 6F 72 20 6E 6F 64 65 20 27 25 68 73 27 2E 20 48 61 6E 64 6C 65 3A 20 25 70 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FL_0040_0024_0024CBD _003F_003F_C_0040_0FL_0040IGFFBLOP_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 6E 65 74 5C 70 79 6C 6F 6E 6E 65 74 5C 67 65 6E 61 70 69 70 61 72 61 6D 65 74 65 72 2E 63 70 70 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(C0 0B 1B 10 78 0B 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(30 0B 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(C0 D9 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 E8 0B 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(30 D9 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 54 0B 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 DC 0B 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_95 _003F_003F_R0_003FAV_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 46 75 6E 63 74 69 6F 6E 5F 4E 6F 64 65 43 61 6C 6C 62 61 63 6B 40 50 36 47 58 50 41 55 49 4E 6F 64 65 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 40 5A 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 4C 0B 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_84 _003F_003F_R0_003FAV_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 3F 24 43 50 6F 69 6E 74 65 72 40 55 49 56 61 6C 75 65 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 55 49 42 61 73 65 40 32 40 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 C0 D9 1B 10 E8 0B 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 30 D9 1B 10 54 0B 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY03Q6AXXZ _003F_003F_7_003F_0024Function_NodeCallback_0040P6GXPAUINode_0040GenApi_3_1_Basler_pylon_0040_0040_0040Z_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(3C CC 08 10 50 CC 08 10 70 CC 08 10 E2 00 00 06) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_44 _003F_003F_R0_003FAVCNodeCallback_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 4E 6F 64 65 43 61 6C 6C 62 61 63 6B 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CNodeCallback_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(8C D9 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 9C 0B 1B 10) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CNodeCallback_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(78 0B 1B 10 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CNodeCallback_0040GenApi_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 94 0B 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CNodeCallback_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 8C D9 1B 10 9C 0B 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY03Q6AXXZ _003F_003F_7CNodeCallback_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(70 CB 08 10 52 D9 0C 10 52 D9 0C 10 F8 0B 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_37 _003F_003F_R0_003FAUIValue_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 56 61 6C 75 65 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7_003F_0024CPointer_0040UIValue_0040GenApi_3_1_Basler_pylon_0040_0040UIBase_00402_0040_0040GenApi_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(64 CB 08 10 AC 0B 1B 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_4 _CTA1_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(01 00 00 00 00 15 1B 10) */;

	internal static _0024_s__CatchableTypeArray_0024_extraBytes_8 _CTA2_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(02 00 00 00 58 1E 1B 10 00 15 1B 10) */;

	internal static _s__CatchableType _CT_003F_003F_R0_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_00408_003F_003F0TimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040_0024_0024FQAE_0040ABV01_0040_0040Z440/* Not supported: data(00 00 00 00 24 C9 1B 10 00 00 00 00 FF FF FF FF 00 00 00 00 B8 01 00 00 5A A8 0C 10) */;

	internal static _s__ThrowInfo _TI1_003FAVGenericException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 6A A8 0C 10 00 00 00 00 90 1E 1B 10) */;

	internal static _s__ThrowInfo _TI2_003FAVTimeoutException_0040GenICam_3_1_Basler_pylon_0040_0040/* Not supported: data(00 00 00 00 4A A8 0C 10 00 00 00 00 74 1E 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_38 _003F_003F_R0_003FAUIString_0040GenApi_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 55 49 53 74 72 69 6E 67 40 47 65 6E 41 70 69 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY05_0024_0024CB_W _003F_003F_C_0040_1M_0040MDIKEACL_0040_003F_0024AAw_003F_0024AAi_003F_0024AAd_003F_0024AAt_003F_0024AAh_0040/* Not supported: data(77 00 69 00 64 00 74 00 68 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY06_0024_0024CB_W _003F_003F_C_0040_1O_0040NGBHDANL_0040_003F_0024AAh_003F_0024AAe_003F_0024AAi_003F_0024AAg_003F_0024AAh_003F_0024AAt_0040/* Not supported: data(68 00 65 00 69 00 67 00 68 00 74 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY08_0024_0024CB_W _003F_003F_C_0040_1BC_0040ILFLGKDF_0040_003F_0024AAp_003F_0024AAa_003F_0024AAd_003F_0024AAd_003F_0024AAi_003F_0024AAn_003F_0024AAg_003F_0024AAX_0040/* Not supported: data(70 00 61 00 64 00 64 00 69 00 6E 00 67 00 58 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040_0024_0024CB_W _003F_003F_C_0040_1BG_0040KHLBHMGI_0040_003F_0024AAb_003F_0024AAu_003F_0024AAf_003F_0024AAf_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAi_003F_0024AAz_003F_0024AAe_0040/* Not supported: data(62 00 75 00 66 00 66 00 65 00 72 00 53 00 69 00 7A 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BB_0040_0024_0024CB_W _003F_003F_C_0040_1CC_0040JAFAPEPH_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAP_003F_0024AAe_003F_0024AAr_003F_0024AAs_003F_0024AAi_003F_0024AAs_003F_0024AAt_003F_0024AAe_003F_0024AAn_003F_0024AAc_0040/* Not supported: data(49 00 6D 00 61 00 67 00 65 00 50 00 65 00 72 00 73 00 69 00 73 00 74 00 65 00 6E 00 63 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BF_0040_0024_0024CBD _003F_003F_C_0040_0BF_0040MOJDGEGH_0040PylonNET_003F4ImageWindow_0040/* Not supported: data(50 79 6C 6F 6E 4E 45 54 2E 49 6D 61 67 65 57 69 6E 64 6F 77 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CB_W _003F_003F_C_0040_1BI_0040PFLHCHCF_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAW_003F_0024AAi_003F_0024AAn_003F_0024AAd_003F_0024AAo_003F_0024AAw_0040/* Not supported: data(49 00 6D 00 61 00 67 00 65 00 57 00 69 00 6E 00 64 00 6F 00 77 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FG_0040_0024_0024CBD _003F_003F_C_0040_0FG_0040MNGGAFPC_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 6D 61 67 65 57 69 6E 64 6F 77 3A 3A 43 6C 6F 73 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EI_0040_0024_0024CBD _003F_003F_C_0040_0EI_0040EHDHDKPN_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 6D 61 67 65 57 69 6E 64 6F 77 3A 3A 43 6C 6F 73 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EA_0040_0024_0024CBD _003F_003F_C_0040_0EA_0040LPPCGJNA_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 6D 61 67 65 57 69 6E 64 6F 77 3A 3A 43 6C 6F 73 65 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DN_0040_0024_0024CBD _003F_003F_C_0040_0DN_0040OCJLAIJN_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 49 6D 61 67 65 57 69 6E 64 6F 77 3A 3A 43 6C 6F 73 65 28 29 2E 00) */;

	internal static int _003F_0024TSS0_0040_003F1_003F_003FGetImageWindowCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404HA/* Not supported: data(00 00 00 00) */;

	internal static uint _003FcatID_0040_003F1_003F_003FGetImageWindowCatID_0040Pylon_0040Basler_0040_0040YAIXZ_00404IB/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY08_0024_0024CB_W _003F_003F_C_0040_1BC_0040OKDABLBD_0040_003F_0024AAI_003F_0024AAn_003F_0024AAf_003F_0024AAo_003F_0024AAB_003F_0024AAa_003F_0024AAs_003F_0024AAe_0040/* Not supported: data(49 00 6E 00 66 00 6F 00 42 00 61 00 73 00 65 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DH_0040_0024_0024CBD _003F_003F_C_0040_0DH_0040PBHIFLIC_0040Unknown_003F5exception_003F5when_003F5destroyi_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 77 68 65 6E 20 64 65 73 74 72 6F 79 69 6E 67 20 6B 65 79 20 6C 69 73 74 20 73 75 70 70 72 65 73 73 65 64 21 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DE_0040_0024_0024CBD _003F_003F_C_0040_0DE_0040EMHLLLC_0040Element_003F5is_003F5undefined_003F4_003F5Move_003F5inde_0040/* Not supported: data(45 6C 65 6D 65 6E 74 20 69 73 20 75 6E 64 65 66 69 6E 65 64 2E 20 4D 6F 76 65 20 69 6E 64 65 78 20 74 6F 20 76 61 6C 69 64 20 70 6F 73 69 74 69 6F 6E 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0CC_0040_0024_0024CBD _003F_003F_C_0040_0CC_0040PAGJOKLO_0040Key_003F5_003F8_003F_0024CFhs_003F8_003F5not_003F5found_003F5in_003F5collecti_0040/* Not supported: data(4B 65 79 20 27 25 68 73 27 20 6E 6F 74 20 66 6F 75 6E 64 20 69 6E 20 63 6F 6C 6C 65 63 74 69 6F 6E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BN_0040_0024_0024CBD _003F_003F_C_0040_0BN_0040LBJBJLEA_0040Native_003F5info_003F5is_003F5not_003F5provided_003F4_0040/* Not supported: data(4E 61 74 69 76 65 20 69 6E 66 6F 20 69 73 20 6E 6F 74 20 70 72 6F 76 69 64 65 64 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0DP_0040_0024_0024CBD _003F_003F_C_0040_0DP_0040DCKNGMKK_0040Unknown_003F5exception_003F5when_003F5destroyi_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 77 68 65 6E 20 64 65 73 74 72 6F 79 69 6E 67 20 43 49 6E 66 6F 42 61 73 65 20 6F 62 6A 65 63 74 20 73 75 70 70 72 65 73 73 65 64 21 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2gcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(0C 0C 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040gcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(74 DA 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 30 0C 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3gcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 28 0C 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_47 _003F_003F_R0_003FAVgcstring_vector_0040GenICam_3_1_Basler_pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 67 63 73 74 72 69 6E 67 5F 76 65 63 74 6F 72 40 47 65 6E 49 43 61 6D 5F 33 5F 31 5F 42 61 73 6C 65 72 5F 70 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4gcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 74 DA 1B 10 30 0C 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_20 _003F_003F_R0_003FAVCTlInfo_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 54 6C 49 6E 66 6F 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0BM_0040Q6AXXZ _003F_003F_Sgcstring_vector_0040GenICam_3_1_Basler_pylon_0040_00406B_0040/* Not supported: data(90 9C 0A 10 7A A8 0C 10 8A A8 0C 10 9A A8 0C 10 AA A8 0C 10 BA A8 0C 10 CA A8 0C 10 DA A8 0C 10 EA A8 0C 10 FA A8 0C 10 0A A9 0C 10 1A A9 0C 10 2A A9 0C 10 3A A9 0C 10 4A A9 0C 10 5A A9 0C 10 6A A9 0C 10 7A A9 0C 10 8A A9 0C 10 9A A9 0C 10 AA A9 0C 10 BA A9 0C 10 CA A9 0C 10 DA A9 0C 10 EA A9 0C 10 FA A9 0C 10 0A AA 0C 10 90 0C 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY07_0024_0024CB_W _003F_003F_C_0040_1BA_0040MCNKKFDK_0040_003F_0024AAL_003F_0024AAi_003F_0024AAb_003F_0024AAr_003F_0024AAa_003F_0024AAr_003F_0024AAy_0040/* Not supported: data(4C 00 69 00 62 00 72 00 61 00 72 00 79 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CTlInfo_0040Pylon_0040_00408/* Not supported: data(54 0C 1B 10 60 03 1B 10 28 03 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CTlInfo_0040Pylon_0040_00408/* Not supported: data(58 DA 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 80 0C 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CTlInfo_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 70 0C 1B 10) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CTlInfo_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 58 DA 1B 10 80 0C 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CBD _003F_003F_C_0040_0M_0040BOIAAHIL_0040DeviceClass_0040/* Not supported: data(44 65 76 69 63 65 43 6C 61 73 73 00) */;

	internal unsafe static sbyte* Pylon_002EKey_002E_003FA0x79069b40_002EDeviceClassKey/* Not supported: data(C4 22 0D 10) */;

	internal static _0024ArrayType_0024_0024_0024BY07Q6AXXZ _003F_003F_SCTlInfo_0040Pylon_0040_00406B_0040/* Not supported: data(1E B2 0C 10 2E B2 0C 10 3E B2 0C 10 1E B3 0C 10 2E B3 0C 10 6E B2 0C 10 00 C4 0A 10 D8 0C 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0BE_0040_0024_0024CB_W _003F_003F_C_0040_1CI_0040JGCKFEPO_0040_003F_0024AAP_003F_0024AAi_003F_0024AAx_003F_0024AAe_003F_0024AAl_003F_0024AAT_003F_0024AAy_003F_0024AAp_003F_0024AAe_003F_0024AAE_003F_0024AAx_003F_0024AAt_003F_0024AAe_003F_0024AAn_003F_0024AAs_0040/* Not supported: data(50 00 69 00 78 00 65 00 6C 00 54 00 79 00 70 00 65 00 45 00 78 00 74 00 65 00 6E 00 73 00 69 00 6F 00 6E 00 73 00 00 00) */;

	internal static CPylonLibraryNative _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00) */;

	internal unsafe static delegate*<void> _003FA0x7e5ac1d5_002E_003Fm_instance_0024initializer_0024_0040CPylonLibraryNative_0040_00400P6MXXZA/* Not supported: data(E6 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_1_4_0/*Field data (rva=0x1be4bc) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_1_4_0_0024initializer_0024/* Not supported: data(F6 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_1_2_1/*Field data (rva=0x1be4a8) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_1_2_1_0024initializer_0024/* Not supported: data(F2 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_1_0/*Field data (rva=0x1be494) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_1_0_0024initializer_0024/* Not supported: data(FE 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_1_3_0/*Field data (rva=0x1be480) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_1_3_0_0024initializer_0024/* Not supported: data(F4 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_VersionUndefined/*Field data (rva=0x1be46c) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_VersionUndefined_0024initializer_0024/* Not supported: data(F0 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_3_0/*Field data (rva=0x1be458) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_3_0_0024initializer_0024/* Not supported: data(02 01 00 06) */;

	internal static int ___0040_0040_PchSym__004000_0040UqvmprmhxlivUdliphkzxvUkbolmRivovzhvPivovzhvPHOCOBUkbolmmvgUkbolmmvgUcIGUivovzhvUhgwzucOlyq_00404B2008FD98C1DD4/* Not supported: data(00 00 00 00) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_0_0/*Field data (rva=0x1be444) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_0_0_0024initializer_0024/* Not supported: data(FC 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_4_0/*Field data (rva=0x1be430) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_4_0_0024initializer_0024/* Not supported: data(04 01 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_0/*Field data (rva=0x1be41c) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_0_0024initializer_0024/* Not supported: data(F8 00 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_5_0/*Field data (rva=0x1be408) could not be found in any section!*/;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_5_0_0024initializer_0024/* Not supported: data(06 01 00 06) */;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_2_2_0/*Invalid size 20 for field data!*/;

	internal static VersionInfo Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_1/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00) */;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_2_2_0_0024initializer_0024/* Not supported: data(00 01 00 06) */;

	internal unsafe static delegate*<void> Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_1_0024initializer_0024/* Not supported: data(FA 00 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY0GH_0040_0024_0024CBD _003F_003F_C_0040_0GH_0040LOOIIPJD_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 49 73 47 72 61 62 62 69 6E 67 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FJ_0040_0024_0024CBD _003F_003F_C_0040_0FJ_0040ODBOBGHA_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 49 73 47 72 61 62 62 69 6E 67 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FB_0040_0024_0024CBD _003F_003F_C_0040_0FB_0040NDCMIMNC_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 49 73 47 72 61 62 62 69 6E 67 3A 3A 67 65 74 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040PLKMBHJD_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 49 73 47 72 61 62 62 69 6E 67 3A 3A 67 65 74 28 29 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FM_0040_0024_0024CBD _003F_003F_C_0040_0FM_0040IFGIBBLO_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EO_0040_0024_0024CBD _003F_003F_C_0040_0EO_0040GEMNJFBD_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EG_0040_0024_0024CBD _003F_003F_C_0040_0EG_0040FKAIAKLM_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0ED_0040_0024_0024CBD _003F_003F_C_0040_0ED_0040HNKDNPML_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FN_0040_0024_0024CBD _003F_003F_C_0040_0FN_0040NODGCMJN_0040System_003F4Exception_003F5caught_003F5while_003F5c_0040/* Not supported: data(53 79 73 74 65 6D 2E 45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 2E 20 4D 73 67 3A 20 27 25 68 73 27 3B 20 53 6F 75 72 63 65 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EP_0040_0024_0024CBD _003F_003F_C_0040_0EP_0040OMJKMALN_0040GenICam_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(47 65 6E 49 43 61 6D 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EH_0040_0024_0024CBD _003F_003F_C_0040_0EH_0040KKMNLLFL_0040Exception_003F5caught_003F5while_003F5calling_003F5_0040/* Not supported: data(45 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 2E 20 4D 73 67 3A 20 27 25 68 73 27 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0EE_0040_0024_0024CBD _003F_003F_C_0040_0EE_0040HMMLBML_0040Unknown_003F5exception_003F5caught_003F5while_003F5_0040/* Not supported: data(55 6E 6B 6E 6F 77 6E 20 65 78 63 65 70 74 69 6F 6E 20 63 61 75 67 68 74 20 77 68 69 6C 65 20 63 61 6C 6C 69 6E 67 20 43 53 74 72 65 61 6D 47 72 61 62 62 65 72 49 6D 70 6C 3A 3A 53 74 6F 70 28 29 2E 2E 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0FN_0040_0024_0024CBD _003F_003F_C_0040_0FN_0040PDIKHPPA_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040/* Not supported: data(64 3A 5C 6A 65 6E 6B 69 6E 73 63 6F 72 65 5C 77 6F 72 6B 73 70 61 63 65 5C 70 79 6C 6F 6E 2D 72 65 6C 65 61 73 65 5F 72 65 6C 65 61 73 65 5F 37 2E 32 2E 31 5C 70 79 6C 6F 6E 6E 65 74 5C 70 79 6C 6F 6E 6E 65 74 5C 73 74 72 65 61 6D 67 72 61 62 62 65 72 69 6D 70 6C 2E 63 70 70 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0P_0040_0024_0024CB_W _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040/* Not supported: data(41 00 76 00 69 00 56 00 69 00 64 00 65 00 6F 00 57 00 72 00 69 00 74 00 65 00 72 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CAviWriter_0040Pylon_0040_00408/* Not supported: data(A4 0C 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CAviWriter_0040Pylon_0040_00408/* Not supported: data(AC DA 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 C8 0C 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CAviWriter_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 C0 0C 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_23 _003F_003F_R0_003FAVCAviWriter_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 41 76 69 57 72 69 74 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CAviWriter_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 AC DA 1B 10 C8 0C 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040Q6AXXZ _003F_003F_SCAviWriter_0040Pylon_0040_00406B_0040/* Not supported: data(20 70 0C 10 FC AD 0C 10 0C AE 0C 10 1C AE 0C 10 2C AE 0C 10 3C AE 0C 10 4C AE 0C 10 5C AE 0C 10 6C AE 0C 10 7C AE 0C 10 CC 0D 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0M_0040_0024_0024CB_W _003F_003F_C_0040_1BI_0040JKCNHBJF_0040_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040/* Not supported: data(56 00 69 00 64 00 65 00 6F 00 57 00 72 00 69 00 74 00 65 00 72 00 00 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_12 _003F_003F_R2CVideoWriter_0040Pylon_0040_00408/* Not supported: data(EC 0C 1B 10 74 0D 1B 10 90 0D 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_8 _003F_003F_R2CVideoWriterParams_Params_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(08 0D 1B 10 3C 0D 1B 10 00) */;

	internal static _0024_s__RTTIBaseClassArray_0024_extraBytes_4 _003F_003F_R2CVideoWriterParams_Params_v7_2_0_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(3C 0D 1B 10 00) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CVideoWriterParams_Params_v7_2_0_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(38 DB 1B 10 00 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 2C 0D 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R13_003F0A_0040EA_0040CVideoWriterParams_Params_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(F0 DA 1B 10 01 00 00 00 04 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 64 0D 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CVideoWriter_0040Pylon_0040_00408/* Not supported: data(CC DA 1B 10 02 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 BC 0D 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CVideoWriterParams_Params_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(F0 DA 1B 10 01 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 64 0D 1B 10) */;

	internal static _s__RTTIBaseClassDescriptor _003F_003F_R1A_0040_003F0A_0040EA_0040CVideoWriterParams_Params_v7_2_0_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(38 DB 1B 10 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 40 00 00 00 2C 0D 1B 10) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CVideoWriterParams_Params_v7_2_0_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 01 00 00 00 24 0D 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_64 _003F_003F_R0_003FAVCVideoWriterParams_Params_v7_2_0_0040Basler_VideoWriterParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 56 69 64 65 6F 57 72 69 74 65 72 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 5F 76 37 5F 32 5F 30 40 42 61 73 6C 65 72 5F 56 69 64 65 6F 57 72 69 74 65 72 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CVideoWriterParams_Params_0040Basler_VideoWriterParams_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 02 00 00 00 58 0D 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_57 _003F_003F_R0_003FAVCVideoWriterParams_Params_0040Basler_VideoWriterParams_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 56 69 64 65 6F 57 72 69 74 65 72 50 61 72 61 6D 73 5F 50 61 72 61 6D 73 40 42 61 73 6C 65 72 5F 56 69 64 65 6F 57 72 69 74 65 72 50 61 72 61 6D 73 40 40 00) */;

	internal static _s__RTTIClassHierarchyDescriptor _003F_003F_R3CVideoWriter_0040Pylon_0040_00408/* Not supported: data(00 00 00 00 00 00 00 00 03 00 00 00 AC 0D 1B 10) */;

	internal static _0024_TypeDescriptor_0024_extraBytes_25 _003F_003F_R0_003FAVCVideoWriter_0040Pylon_0040_0040_00408/* Not supported: data(48 28 0D 10 00 00 00 00 2E 3F 41 56 43 56 69 64 65 6F 57 72 69 74 65 72 40 50 79 6C 6F 6E 40 40 00) */;

	internal static _s__RTTICompleteObjectLocator _003F_003F_R4CVideoWriter_0040Pylon_0040_00406B_0040/* Not supported: data(00 00 00 00 00 00 00 00 00 00 00 00 CC DA 1B 10 BC 0D 1B 10) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040Q6AXXZ _003F_003F_SCVideoWriter_0040Pylon_0040_00406B_0040/* Not supported: data(40 A3 0C 10 9C AE 0C 10 AC AE 0C 10 BC AE 0C 10 CC AE 0C 10 DC AE 0C 10 EC AE 0C 10 FC AE 0C 10 0C AF 0C 10 1C AF 0C 10 B1 19 BF 44) */;

	internal static _0024ArrayType_0024_0024_0024BY0L_0040_0024_0024CB_W _003F_003F_C_0040_1BG_0040OIPNDMGI_0040_003F_0024AAW_003F_0024AAa_003F_0024AAi_003F_0024AAt_003F_0024AAO_003F_0024AAb_003F_0024AAj_003F_0024AAe_003F_0024AAc_003F_0024AAt_0040/* Not supported: data(57 00 61 00 69 00 74 00 4F 00 62 00 6A 00 65 00 63 00 74 00 00 00) */;

	internal static __s_GUID _GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e/* Not supported: data(23 67 2F CB 3A AB D2 11 9C 40 00 C0 4F A3 0A 3E) */;

	[FixedAddressValueType]
	internal static Progress _003FInitializedPerProcess_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FInitializedPerProcess_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(22 01 00 06) */;

	internal static __s_GUID _GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e/* Not supported: data(22 67 2F CB 3A AB D2 11 9C 40 00 C0 4F A3 0A 3E) */;

	internal static __s_GUID _GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02/* Not supported: data(6C A0 F1 90 12 77 62 47 86 B5 7A 5E BA 6B DB 02) */;

	internal static __s_GUID _GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02/* Not supported: data(6E A0 F1 90 12 77 62 47 86 B5 7A 5E BA 6B DB 02) */;

	[FixedAddressValueType]
	internal static int _003FUninitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA;

	[FixedAddressValueType]
	internal static Progress _003FInitializedPerAppDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A;

	internal static bool _003FEntered_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA/*Field data (rva=0x1be874) could not be found in any section!*/;

	internal static TriBool _003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A/* Not supported: data() */;

	internal static bool _003FInitializedPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA/*Field data (rva=0x1be877) could not be found in any section!*/;

	internal static int _003FCount_0040AllDomains_0040_003CCrtImplementationDetails_003E_0040_00402HA/*Field data (rva=0x1be870) could not be found in any section!*/;

	[FixedAddressValueType]
	internal static int _003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA;

	[FixedAddressValueType]
	internal static Progress _003FInitializedNative_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A;

	internal static bool _003FInitializedNativeFromCCTOR_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA/*Field data (rva=0x1be876) could not be found in any section!*/;

	[FixedAddressValueType]
	internal static bool _003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA;

	[FixedAddressValueType]
	internal static Progress _003FInitializedVtables_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A;

	internal static bool _003FInitializedNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA/*Field data (rva=0x1be875) could not be found in any section!*/;

	internal static TriBool _003FhasPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A/* Not supported: data() */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xc_mp_z/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xi_vt_z/* Not supported: data(00 00 00 00) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FIsDefaultDomain_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(1F 01 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xc_ma_a/* Not supported: data(00 00 00 00) */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xc_ma_z/* Not supported: data(00 00 00 00) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FInitialized_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(1D 01 00 06) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FInitializedPerAppDomain_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(23 01 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xi_vt_a/* Not supported: data(00 00 00 00) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FInitializedNative_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(21 01 00 06) */;

	internal static _0024ArrayType_0024_0024_0024BY00Q6MPBXXZ __xc_mp_a/* Not supported: data(00 00 00 00) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FInitializedVtables_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(20 01 00 06) */;

	internal unsafe static delegate*<void> _003FA0x1cf8fe9a_002E_003FUninitialized_0024initializer_0024_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2P6MXXZA/* Not supported: data(1E 01 00 06) */;

	public unsafe static int** __unep_0040_003FDoNothing_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024FCGJPAX_0040Z/* Not supported: data(7D D1 0C 10) */;

	public unsafe static int** __unep_0040_003F_UninitializeDefaultDomain_0040LanguageSupport_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024FCGJPAX_0040Z/* Not supported: data(83 D1 0C 10) */;

	internal static _Fac_tidy_reg_t std_002E_003FA0x5fdfc975_002E_Fac_tidy_reg/*Field data (rva=0x1be984) could not be found in any section!*/;

	internal unsafe static delegate*<void> std_002E_003FA0x5fdfc975_002E_Fac_tidy_reg_0024initializer_0024/* Not supported: data(3B 01 00 06) */;

	internal unsafe static _Fac_node* std_002E_003FA0x5fdfc975_002E_Fac_head/*Field data (rva=0x1be97c) could not be found in any section!*/;

	internal unsafe static delegate*<void>* _003FA0x288572bd_002E__onexitbegin_m/*Field data (rva=0x1be9c4) could not be found in any section!*/;

	internal static uint _003FA0x288572bd_002E__exit_list_size/*Field data (rva=0x1be9c0) could not be found in any section!*/;

	[FixedAddressValueType]
	internal unsafe static delegate*<void>* __onexitend_app_domain;

	[FixedAddressValueType]
	internal unsafe static void* _003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA;

	[FixedAddressValueType]
	internal static int _003F_ref_count_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0HA;

	internal unsafe static delegate*<void>* _003FA0x288572bd_002E__onexitend_m/*Field data (rva=0x1be9c8) could not be found in any section!*/;

	[FixedAddressValueType]
	internal static uint __exit_list_size_app_domain;

	[FixedAddressValueType]
	internal unsafe static delegate*<void>* __onexitbegin_app_domain;

	internal static _0024ArrayType_0024_0024_0024BY01Q6AXXZ _003F_003F_7type_info_0040_00406B_0040/* Not supported: data(54 B3 0C 10 00 00 00 00) */;

	internal static int _Init_thread_epoch/* Not supported: data(00 00 00 80) */;

	internal unsafe static locale.id* __imp__003Fid_0040_003F_0024codecvt_0040DDU_Mbstatet_0040_0040_0040std_0040_00402V0locale_00402_0040A/* Not supported: data(82 A9 1B 00) */;

	internal static _0024ArrayType_0024_0024_0024BY0A_0040P6AHXZ __xi_z/* Not supported: data(00) */;

	internal static __scrt_native_startup_state __scrt_current_native_startup_state/* Not supported: data() */;

	internal unsafe static void* __scrt_native_startup_lock/*Field data (rva=0x1be830) could not be found in any section!*/;

	internal static _0024ArrayType_0024_0024_0024BY0A_0040P6AXXZ __xc_a/* Not supported: data(00) */;

	internal static _0024ArrayType_0024_0024_0024BY0A_0040P6AHXZ __xi_a/* Not supported: data(00) */;

	internal static uint __scrt_native_dllmain_reason/* Not supported: data(FF FF FF FF) */;

	internal static _0024ArrayType_0024_0024_0024BY0A_0040P6AXXZ __xc_z/* Not supported: data(00) */;

	internal unsafe static uint msclr_002Einterop_002Edetails_002EGetAnsiStringSize(string _str)
	{
		ref byte reference = ref *(byte*)_str;
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != null)
		{
			reference = ref *(byte*)((ref *(_003F*)RuntimeHelpers.OffsetToStringData) + (ref System.Runtime.CompilerServices.Unsafe.As<byte, _003F>(ref reference)));
		}
		fixed (char* ptr = &System.Runtime.CompilerServices.Unsafe.As<byte, char>(ref reference))
		{
			uint num = (uint)WideCharToMultiByte(3u, 1024u, ptr, _str.Length, null, 0, null, null);
			if (num == 0 && _str.Length != 0)
			{
				throw new ArgumentException("Conversion from WideChar to MultiByte failed.  Please check the content of the string and/or locale settings.");
			}
			return num + 1;
		}
	}

	internal unsafe static void msclr_002Einterop_002Edetails_002EWriteAnsiString(sbyte* _buf, uint _size, string _str)
	{
		ref byte reference = ref *(byte*)_str;
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != null)
		{
			reference = ref *(byte*)((ref *(_003F*)RuntimeHelpers.OffsetToStringData) + (ref System.Runtime.CompilerServices.Unsafe.As<byte, _003F>(ref reference)));
		}
		fixed (char* ptr = &System.Runtime.CompilerServices.Unsafe.As<byte, char>(ref reference))
		{
			if (_size > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("Size of string exceeds INT_MAX.");
			}
			uint num = (uint)WideCharToMultiByte(3u, 1024u, ptr, _str.Length, _buf, (int)_size, null, null);
			if (num < _size && (num != 0 || _size == 1))
			{
				*((int)num + _buf) = 0;
				return;
			}
			throw new ArgumentException("Conversion from WideChar to MultiByte failed.  Please check the content of the string and/or locale settings.");
		}
	}

	internal unsafe static uint msclr_002Einterop_002Edetails_002EGetUnicodeStringSize(sbyte* _str, uint _count)
	{
		if (_count > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException("Size of string exceeds INT_MAX.");
		}
		uint num = (uint)MultiByteToWideChar(3u, 0u, _str, (int)_count, null, 0);
		if (num == 0 && _count != 0)
		{
			throw new ArgumentException("Conversion from MultiByte to WideChar failed.  Please check the content of the string and/or locale settings.");
		}
		return num + 1;
	}

	internal unsafe static void msclr_002Einterop_002Edetails_002EWriteUnicodeString(char* _dest, uint _size, sbyte* _src, uint _count)
	{
		if (_size <= int.MaxValue && _count <= int.MaxValue)
		{
			uint num = (uint)MultiByteToWideChar(3u, 0u, _src, (int)_count, _dest, (int)_size);
			if (num < _size && (num != 0 || _size == 1))
			{
				*(short*)((int)(num * 2) + (byte*)_dest) = 0;
				return;
			}
			throw new ArgumentException("Conversion from MultiByte to WideChar failed.  Please check the content of the string and/or locale settings.");
		}
		throw new ArgumentOutOfRangeException("Size of string exceeds INT_MAX.");
	}

	internal unsafe static string msclr_002Einterop_002Edetails_002EInternalAnsiToStringHelper(sbyte* _src, uint _count)
	{
		//Discarded unreachable code: IL_0066
		uint num = msclr_002Einterop_002Edetails_002EGetUnicodeStringSize(_src, _count);
		if (num - 1 <= 2147483646)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out char_buffer_003Cwchar_t_003E char_buffer_003Cwchar_t_003E2);
			*(int*)(&char_buffer_003Cwchar_t_003E2) = (int)new_005B_005D(num << 1);
			string result;
			try
			{
				if (*(int*)(&char_buffer_003Cwchar_t_003E2) == 0)
				{
					throw new InsufficientMemoryException();
				}
				msclr_002Einterop_002Edetails_002EWriteUnicodeString((char*)(int)(*(uint*)(&char_buffer_003Cwchar_t_003E2)), num, _src, _count);
				result = new string((char*)(int)(*(uint*)(&char_buffer_003Cwchar_t_003E2)), 0, (int)(num - 1));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<char_buffer_003Cwchar_t_003E*, void>)(&msclr_002Einterop_002Edetails_002Echar_buffer_003Cwchar_t_003E_002E_007Bdtor_007D), &char_buffer_003Cwchar_t_003E2);
				throw;
			}
			delete_005B_005D((void*)(int)(*(uint*)(&char_buffer_003Cwchar_t_003E2)));
			return result;
		}
		throw new ArgumentOutOfRangeException("Size of string exceeds INT_MAX.");
	}

	internal unsafe static gcstring* msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(gcstring* P_0, string* _from_obj)
	{
		uint num = 0u;
		if (*_from_obj == null)
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(P_0, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_06LHGEHABH_0040_003F_0024CINULL_003F_0024CJ_0040));
			try
			{
				num = 1u;
				return P_0;
			}
			catch
			{
				//try-fault
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), P_0);
				}
				throw;
			}
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
		try
		{
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out StringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E stringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E);
				Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002E_007Bctor_007D(&stringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E);
				try
				{
					ref byte reference = ref *(byte*)(*_from_obj);
					if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != null)
					{
						reference = ref *(byte*)((ref *(_003F*)RuntimeHelpers.OffsetToStringData) + (ref System.Runtime.CompilerServices.Unsafe.As<byte, _003F>(ref reference)));
					}
					fixed (char* ptr = &System.Runtime.CompilerServices.Unsafe.As<byte, char>(ref reference))
					{
						int num2 = Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002EconvertString(ptr, null, 0);
						if (num2 > 1)
						{
							GenICam_3_1_Basler_pylon_002Egcstring_002Eresize(&gcstring2, (uint)(num2 - 1));
							sbyte* ptr2 = GenICam_3_1_Basler_pylon_002Egcstring_002E_002EPBD(&gcstring2);
							Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002EconvertString(ptr, ptr2, num2);
						}
						GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(P_0, &gcstring2);
						num = 1u;
					}
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<StringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E*, void>)(&Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002E_007Bdtor_007D), &stringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E);
					throw;
				}
				Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002E_007Bdtor_007D(&stringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
				throw;
			}
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	internal unsafe static string msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_002Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_003E(gcstring* _from_obj)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
		StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* ptr = Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bctor_007D(&stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E, ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)_from_obj + 44)))((nint)_from_obj));
		string result;
		try
		{
			result = new string(Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002Ec_str(ptr));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E*, void>)(&Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bdtor_007D), &stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
			throw;
		}
		Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bdtor_007D(&stringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E);
		return result;
	}

	internal unsafe static void _003FA0xe82174f0_002EAutoTlReleaser_002E_007Bdtor_007D(_003FA0xe82174f0.AutoTlReleaser* P_0)
	{
		uint num = *(uint*)P_0;
		if (num != 0)
		{
			Pylon_002ECTlFactory_002EReleaseTl(Pylon_002ECTlFactory_002EGetInstance(), (ITransportLayer*)(int)num);
		}
	}

	internal unsafe static void msclr_002Einterop_002Edetails_002Echar_buffer_003Cchar_003E_002E_007Bdtor_007D(char_buffer_003Cchar_003E* P_0)
	{
		delete_005B_005D((void*)(int)(*(uint*)P_0));
	}

	internal unsafe static void msclr_002Einterop_002Edetails_002Echar_buffer_003Cwchar_t_003E_002E_007Bdtor_007D(char_buffer_003Cwchar_t_003E* P_0)
	{
		delete_005B_005D((void*)(int)(*(uint*)P_0));
	}

	internal unsafe static ArgumentNullException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(ArgumentNullException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static ArgumentException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(ArgumentException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static NotSupportedException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(NotSupportedException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static string msclr_002Einterop_002Emarshal_as_003Cclass_0020System_003A_003AString_0020_005E_003E(sbyte* _from_object)
	{
		if (_from_object == null)
		{
			return null;
		}
		sbyte* ptr = _from_object;
		if (*_from_object != 0)
		{
			do
			{
				ptr++;
			}
			while (*ptr != 0);
		}
		int count = (int)(ptr - (nuint)_from_object);
		return msclr_002Einterop_002Edetails_002EInternalAnsiToStringHelper(_from_object, (uint)count);
	}

	internal unsafe static InvalidOperationException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(InvalidOperationException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static ArgumentOutOfRangeException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(ArgumentOutOfRangeException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static void* Basler_002EPylon_002ENativeBufferContext_002E__delDtor(NativeBufferContext* P_0, uint A_0)
	{
		Basler_002EPylon_002ENativeBufferContext_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 20u);
		}
		return P_0;
	}

	internal unsafe static void Basler_002EPylon_002ENativeBufferContext_002E_007Bdtor_007D(NativeBufferContext* P_0)
	{
		try
		{
			try
			{
				try
				{
					try
					{
						gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)((byte*)P_0 + 16));
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AObject_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 12);
						throw;
					}
					gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)P_0 + 12));
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 8);
					throw;
				}
				gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)P_0 + 8));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AObject_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 4);
				throw;
			}
			gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)P_0 + 4));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D), P_0);
			throw;
		}
		gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)P_0);
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraLockProvider_002ELock(CInstantCameraLockProvider* P_0)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<byte, void>)(int)((uint*)P_0)[1])(1);
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraLockProvider_002EUnlock(CInstantCameraLockProvider* P_0)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<byte, void>)(int)((uint*)P_0)[1])(0);
	}

	internal unsafe static CInstantCameraForPylonNET* Basler_002EPylon_002ECInstantCameraForPylonNET_002E_007Bctor_007D(CInstantCameraForPylonNET* P_0, Camera camera, IExternalLock* pExternalLock)
	{
		Pylon_002ECInstantCamera_002E_007Bctor_007D((CInstantCamera*)P_0);
		try
		{
			CInstantCameraForPylonNET* ptr = (CInstantCameraForPylonNET*)((byte*)P_0 + 96);
			Pylon_002ECConfigurationEventHandler_002E_007Bctor_007D((CConfigurationEventHandler*)ptr);
			try
			{
				CInstantCameraForPylonNET* ptr2 = (CInstantCameraForPylonNET*)((byte*)P_0 + 104);
				Pylon_002ECImageEventHandler_002E_007Bctor_007D((CImageEventHandler*)ptr2);
				try
				{
					*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCInstantCamera_00401_0040_0040);
					*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCConfigurationEventHandler_00401_0040_0040);
					*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCImageEventHandler_00401_0040_0040);
					CInstantCameraForPylonNET* ptr3 = (CInstantCameraForPylonNET*)((byte*)P_0 + 116);
					gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr3);
					try
					{
						gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 124));
						try
						{
							gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 132));
							try
							{
								gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 140));
								try
								{
									gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 148));
									try
									{
										((int*)P_0)[38] = (int)((IntPtr)GCHandle.Alloc(camera)).ToPointer();
										try
										{
											gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E*)((byte*)P_0 + 156));
											try
											{
												IInstantCameraExtensions* ptr4 = Pylon_002ECInstantCamera_002EGetExtensionInterface((CInstantCamera*)P_0);
												((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, IExternalLock*, void>)(int)(*(uint*)(*(int*)ptr4 + 4)))((nint)ptr4, pExternalLock);
												IInstantCameraExtensions* ptr5 = Pylon_002ECInstantCamera_002EGetExtensionInterface((CInstantCamera*)P_0);
												((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, byte, void>)(int)(*(uint*)(*(int*)ptr5 + 8)))((nint)ptr5, 0);
												CInstantCameraForPylonNET* ptr6 = ptr;
												Pylon_002ECInstantCamera_002ERegisterConfiguration((CInstantCamera*)P_0, (CConfigurationEventHandler*)ptr6, (ERegistrationMode)1, (ECleanup)0);
												CInstantCameraForPylonNET* ptr7 = ptr2;
												Pylon_002ECInstantCamera_002ERegisterImageEventHandler((CInstantCamera*)P_0, (CImageEventHandler*)ptr7, (ERegistrationMode)1, (ECleanup)0);
												gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr3, camera.OnConnectionLost);
												((int*)P_0)[28] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGenericCallbackDelegate_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr3)).ToPointer();
												return P_0;
											}
											catch
											{
												//try-fault
												___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 156);
												throw;
											}
										}
										catch
										{
											//try-fault
											___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 152);
											throw;
										}
									}
									catch
									{
										//try-fault
										___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 148);
										throw;
									}
								}
								catch
								{
									//try-fault
									___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 140);
									throw;
								}
							}
							catch
							{
								//try-fault
								___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 132);
								throw;
							}
						}
						catch
						{
							//try-fault
							___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 124);
							throw;
						}
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 116);
						throw;
					}
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CImageEventHandler*, void>)(&Pylon_002ECImageEventHandler_002E_007Bdtor_007D), (byte*)P_0 + 104);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CConfigurationEventHandler*, void>)(&Pylon_002ECConfigurationEventHandler_002E_007Bdtor_007D), (byte*)P_0 + 96);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CInstantCamera*, void>)(&Pylon_002ECInstantCamera_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002ESetStreamGrabber(CInstantCameraForPylonNET* P_0, CStreamGrabberImpl streamGrabber)
	{
		CInstantCameraForPylonNET* ptr = (CInstantCameraForPylonNET*)((byte*)P_0 + 132);
		gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr, streamGrabber.OnGrabStopped);
		((int*)P_0)[32] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGenericCallbackDelegate_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr)).ToPointer();
		CInstantCameraForPylonNET* ptr2 = (CInstantCameraForPylonNET*)((byte*)P_0 + 124);
		gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr2, streamGrabber.OnGrabStopping);
		((int*)P_0)[30] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGenericCallbackDelegate_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)ptr2)).ToPointer();
		CInstantCameraForPylonNET* ptr3 = (CInstantCameraForPylonNET*)((byte*)P_0 + 140);
		gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*)ptr3, streamGrabber.OnImageGrabbedNative);
		((int*)P_0)[34] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVImageGrabbedCallbackDelegate_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*)ptr3)).ToPointer();
		CInstantCameraForPylonNET* ptr4 = (CInstantCameraForPylonNET*)((byte*)P_0 + 148);
		gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*)ptr4, streamGrabber.OnGrabError);
		((int*)P_0)[36] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGrabErrorCallbackDelegate_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*)ptr4)).ToPointer();
		gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E*)((byte*)P_0 + 156), streamGrabber);
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002E_007Bdtor_007D(CInstantCameraForPylonNET* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCInstantCamera_00401_0040_0040);
		CInstantCameraForPylonNET* ptr = (CInstantCameraForPylonNET*)((byte*)P_0 + 96);
		*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCConfigurationEventHandler_00401_0040_0040);
		CInstantCameraForPylonNET* ptr2 = (CInstantCameraForPylonNET*)((byte*)P_0 + 104);
		*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CInstantCameraForPylonNET_0040Pylon_0040Basler_0040_00406BCImageEventHandler_00401_0040_0040);
		try
		{
			try
			{
				try
				{
					try
					{
						try
						{
							try
							{
								try
								{
									try
									{
										try
										{
											try
											{
												Pylon_002ECInstantCamera_002ERegisterConfiguration((CInstantCamera*)P_0, null, (ERegistrationMode)1, (ECleanup)0);
												Pylon_002ECInstantCamera_002ERegisterImageEventHandler((CInstantCamera*)P_0, null, (ERegistrationMode)1, (ECleanup)0);
											}
											catch
											{
												//try-fault
												___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 156);
												throw;
											}
											gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E*)((byte*)P_0 + 156));
										}
										catch
										{
											//try-fault
											___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 152);
											throw;
										}
										gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E*)((byte*)P_0 + 152));
									}
									catch
									{
										//try-fault
										___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 148);
										throw;
									}
									gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 148));
								}
								catch
								{
									//try-fault
									___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 140);
									throw;
								}
								gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 140));
							}
							catch
							{
								//try-fault
								___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 132);
								throw;
							}
							gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 132));
						}
						catch
						{
							//try-fault
							___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 124);
							throw;
						}
						gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 124));
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 116);
						throw;
					}
					gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E*)((byte*)P_0 + 116));
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CImageEventHandler*, void>)(&Pylon_002ECImageEventHandler_002E_007Bdtor_007D), (byte*)P_0 + 104);
					throw;
				}
				Pylon_002ECImageEventHandler_002E_007Bdtor_007D((CImageEventHandler*)ptr2);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CConfigurationEventHandler*, void>)(&Pylon_002ECConfigurationEventHandler_002E_007Bdtor_007D), (byte*)P_0 + 96);
				throw;
			}
			Pylon_002ECConfigurationEventHandler_002E_007Bdtor_007D((CConfigurationEventHandler*)ptr);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CInstantCamera*, void>)(&Pylon_002ECInstantCamera_002E_007Bdtor_007D), P_0);
			throw;
		}
		Pylon_002ECInstantCamera_002E_007Bdtor_007D((CInstantCamera*)P_0);
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002EOnCameraDeviceRemoved(CInstantCameraForPylonNET* P_0, CInstantCamera* camera)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<void>)(int)((uint*)P_0)[4])();
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002EOnGrabStop(CInstantCameraForPylonNET* P_0, CInstantCamera* camera)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<void>)(int)((uint*)P_0)[6])();
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002EOnGrabStopped(CInstantCameraForPylonNET* P_0, CInstantCamera* camera)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<void>)(int)((uint*)P_0)[8])();
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002EOnGrabError(CInstantCameraForPylonNET* P_0, CInstantCamera* camera, sbyte* errorMessage)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<sbyte*, void>)(int)((uint*)P_0)[12])(errorMessage);
	}

	internal unsafe static void Basler_002EPylon_002ECInstantCameraForPylonNET_002EOnImageGrabbed(CInstantCameraForPylonNET* P_0, CInstantCamera* __unnamed000, CGrabResultPtr* grabResult)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<CGrabResultPtr*, void>)(int)((uint*)P_0)[8])(grabResult);
	}

	internal unsafe static void* Basler_002EPylon_002ECInstantCameraForPylonNET_002E__vecDelDtor(CInstantCameraForPylonNET* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CInstantCameraForPylonNET* ptr = (CInstantCameraForPylonNET*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 160u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CInstantCameraForPylonNET*, void>)(&Basler_002EPylon_002ECInstantCameraForPylonNET_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 160 + 4));
			}
			return ptr;
		}
		Basler_002EPylon_002ECInstantCameraForPylonNET_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 160u);
		}
		return P_0;
	}

	internal unsafe static void Pylon_002ECWaitableTimer_002E_007Bdtor_007D(CWaitableTimer* P_0)
	{
		Pylon_002EWaitObjectEx_002E_007Bdtor_007D((WaitObjectEx*)P_0);
	}

	internal unsafe static void Pylon_002ECWaitableTimer_002ECreate(CWaitableTimer* P_0)
	{
		void* ptr = CreateWaitableTimerW(null, 1, null);
		if (ptr == null)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
			ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* ptr2 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FF_0040NGHBGAHE_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 76, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BB_0040CDLLKKB_0040RuntimeException_0040));
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException ex);
				RuntimeException* ptr3 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002EReport(ptr2, &ex, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0CM_0040BJFBNIAA_0040Error_003F50x_003F_0024CF08x_003F5creating_003F5waitable_003F5_0040), __arglist(GetLastError(), (void*)null));
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException ex2);
					GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bctor_007D(&ex2, ptr3);
					_CxxThrowException(&ex2, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040));
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<RuntimeException*, void>)(&GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bdtor_007D), &ex);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
				throw;
			}
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out WaitObjectEx waitObjectEx);
		WaitObjectEx* ptr4 = Pylon_002EWaitObjectEx_002E_007Bctor_007D(&waitObjectEx, ptr, false);
		try
		{
			Pylon_002EWaitObjectEx_002E_003D((WaitObjectEx*)P_0, ptr4);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<WaitObjectEx*, void>)(&Pylon_002EWaitObjectEx_002E_007Bdtor_007D), &waitObjectEx);
			throw;
		}
		Pylon_002EWaitObjectEx_002E_007Bdtor_007D(&waitObjectEx);
	}

	internal unsafe static void Pylon_002ECWaitableTimer_002ESet(CWaitableTimer* P_0, uint timeout_ms)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out _LARGE_INTEGER lARGE_INTEGER);
		if (timeout_ms == uint.MaxValue)
		{
			*(long*)(&lARGE_INTEGER) = long.MaxValue;
		}
		else
		{
			*(long*)(&lARGE_INTEGER) = timeout_ms * -10000L;
		}
		if (SetWaitableTimer(Pylon_002EWaitObject_002E_002EPAX((WaitObject*)P_0), &lARGE_INTEGER, 0, null, null, 0) != 0)
		{
			return;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
		ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* ptr = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FF_0040NGHBGAHE_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 179, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BB_0040CDLLKKB_0040RuntimeException_0040));
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException ex);
			RuntimeException* ptr2 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002EReport(ptr, &ex, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0CL_0040PNCNDGOD_0040Error_003F50x_003F_0024CF08x_003F5setting_003F5waitable_003F5t_0040), __arglist(GetLastError(), Pylon_002EWaitObject_002E_002EPAX((WaitObject*)P_0)));
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out RuntimeException ex2);
				GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bctor_007D(&ex2, ptr2);
				_CxxThrowException(&ex2, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVRuntimeException_0040GenICam_3_1_Basler_pylon_0040_0040));
				return;
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<RuntimeException*, void>)(&GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bdtor_007D), &ex);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E);
			throw;
		}
	}

	internal unsafe static CDeviceInfo* Basler_002EPylon_002EFindCamera(CDeviceInfo* P_0, CDeviceInfo* filter, CameraSelectionStrategy selectionStrategy)
	{
		//Discarded unreachable code: IL_0099
		uint num = 0u;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out DeviceInfoList deviceInfoList);
		Pylon_002EDeviceInfoList_002E_007Bctor_007D(&deviceInfoList);
		try
		{
			try
			{
				Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Epush_back((TList_003CPylon_003A_003ACDeviceInfo_003E*)(&deviceInfoList), filter);
				List<ICameraInfo> list = CameraFinder.Enumerate(&deviceInfoList);
				if (list.Count == 0)
				{
					throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("No matching camera found."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1O_0040NJAJGJMG_0040_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAr_003F_0024AAa_0040));
				}
				if (CameraSelectionStrategy.Unambiguous == selectionStrategy && list.Count > 1)
				{
					throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException($"Multiple matching cameras found. There are {list.Count} cameras available."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1O_0040NJAJGJMG_0040_003F_0024AAC_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAr_003F_0024AAa_0040));
				}
				Pylon_002ECDeviceInfo_002E_007Bctor_007D(P_0, ((CCameraInfoImpl)list[0]).GetDeviceInfo());
				num = 1u;
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<DeviceInfoList*, void>)(&Pylon_002EDeviceInfoList_002E_007Bdtor_007D), &deviceInfoList);
				throw;
			}
			Pylon_002EDeviceInfoList_002E_007Bdtor_007D(&deviceInfoList);
			return P_0;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CDeviceInfo*, void>)(&Pylon_002ECDeviceInfo_002E_007Bdtor_007D), P_0);
			}
			throw;
		}
	}

	internal unsafe static int Basler_002EPylon_002EAddToToDeviceInfo(IEnumerable<KeyValuePair<string, string>> cameraInfoFilter, CDeviceInfo* deviceInfoOut_nat)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring2);
		int num;
		try
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring3);
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(&gcstring3);
			try
			{
				num = 0;
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring4);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring5);
				foreach (KeyValuePair<string, string> item in cameraInfoFilter)
				{
					string key = item.Key;
					gcstring* ptr = msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring4, &key);
					try
					{
						GenICam_3_1_Basler_pylon_002Egcstring_002E_003D(&gcstring2, ptr);
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring4);
						throw;
					}
					GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring4);
					string value = item.Value;
					gcstring* ptr2 = msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring5, &value);
					try
					{
						GenICam_3_1_Basler_pylon_002Egcstring_002E_003D(&gcstring3, ptr2);
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring5);
						throw;
					}
					GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring5);
					((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, gcstring*, gcstring*, CDeviceInfo*>)(int)(*(uint*)(*(int*)deviceInfoOut_nat + 12)))((nint)deviceInfoOut_nat, &gcstring2, &gcstring3);
					num++;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring3);
				throw;
			}
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring3);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		return num;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E* P_0, CStreamGrabberImpl t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003ACStreamGrabberImpl_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003ACamera_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[SecuritySafeCritical]
	internal unsafe static GrabErrorCallbackDelegate gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGrabErrorCallbackDelegate_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (GrabErrorCallbackDelegate)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* P_0, GrabErrorCallbackDelegate t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AGrabErrorCallbackDelegate_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecuritySafeCritical]
	internal unsafe static ImageGrabbedCallbackDelegate gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVImageGrabbedCallbackDelegate_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ImageGrabbedCallbackDelegate)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* P_0, ImageGrabbedCallbackDelegate t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AImageGrabbedCallbackDelegate_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecuritySafeCritical]
	internal unsafe static GenericCallbackDelegate gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_002EP_0024AAVGenericCallbackDelegate_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (GenericCallbackDelegate)((GCHandle)intPtr).Target;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* P_0, GenericCallbackDelegate t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[SecuritySafeCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AGenericCallbackDelegate_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecuritySafeCritical]
	internal unsafe static ValueType gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_002D_003E(gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ValueType)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[SecuritySafeCritical]
	internal unsafe static ValueType gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002EP_0024AA__ZVIntPtr_0040System_0040_0040(gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ValueType)((GCHandle)intPtr).Target;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[SecuritySafeCritical]
	internal unsafe static object gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040(gcroot_003CSystem_003A_003AObject_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return ((GCHandle)intPtr).Target;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CSystem_003A_003AObject_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[SecuritySafeCritical]
	internal unsafe static Basler.Pylon.IBufferFactory gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002D_003E(gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (Basler.Pylon.IBufferFactory)((GCHandle)intPtr).Target;
	}

	[SecuritySafeCritical]
	internal unsafe static Basler.Pylon.IBufferFactory gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002EP_0024AAUIBufferFactory_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (Basler.Pylon.IBufferFactory)((GCHandle)intPtr).Target;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002EODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 80u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&GenApi_3_1_Basler_pylon_002EODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 80 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002EODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 80u);
		}
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002EIDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 160u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&GenApi_3_1_Basler_pylon_002EIDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 160 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002EIDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 160u);
		}
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 188);
			__ehvec_dtor((byte*)P_0 - 184, 256u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 256 + 4));
			}
			return ptr;
		}
		IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 184);
		GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor(ptr2);
		if ((A_0 & 1) != 0)
		{
			delete(ptr2, 256u);
		}
		return ptr2;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 100);
			__ehvec_dtor((byte*)P_0 - 96, 168u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 168 + 4));
			}
			return ptr;
		}
		ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 96);
		GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor(ptr2);
		if ((A_0 & 1) != 0)
		{
			delete(ptr2, 168u);
		}
		return ptr2;
	}

	internal unsafe static void GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 184);
		IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = ptr;
		try
		{
			GenApi_3_1_Basler_pylon_002EIDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)ptr2 - 168));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)ptr2 - 184 + 24);
			throw;
		}
		std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)ptr2 - 160));
		std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr);
	}

	internal unsafe static void GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 96);
		ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = ptr;
		ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr3;
		try
		{
			ptr3 = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)ptr2 - 88);
			GenApi_3_1_Basler_pylon_002EODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr3);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)ptr2 - 96 + 8);
			throw;
		}
		std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr3);
		std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr);
	}

	internal static InvalidOperationException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_002Cclass_0020System_003A_003AString_0020_005E_003E(InvalidOperationException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal static ArgumentException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_002Cclass_0020System_003A_003AString_0020_005E_003E(ArgumentException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal static System.TimeoutException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ATimeoutException_002Cclass_0020System_003A_003AString_0020_005E_003E(System.TimeoutException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal static ObjectDisposedException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_002Cclass_0020System_003A_003AString_0020_005E_003E(ObjectDisposedException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal static ArgumentNullException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_002Cclass_0020System_003A_003AString_0020_005E_003E(ArgumentNullException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal unsafe static void* _003F_003F_E_003F_0024ODevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_0024_0024F_00244PPPPPPPM_0040A_0040AEPAXI_0040Z(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* num = P_0;
		P_0 = (ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)num - *(int*)((byte*)num + -4));
		return GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(P_0, A_0);
	}

	internal unsafe static void* _003F_003F_E_003F_0024IDevFileStreamBase_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040GenApi_3_1_Basler_pylon_0040_0040_0024_0024F_00244PPPPPPPM_0040A_0040AEPAXI_0040Z(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* num = P_0;
		P_0 = (IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)num - *(int*)((byte*)num + -4));
		return GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(P_0, A_0);
	}

	internal unsafe static void* _003F_003F_ECInstantCameraForPylonNET_0040Pylon_0040Basler_0040_0040_0024_0024FWGA_0040AEPAXI_0040Z(CInstantCameraForPylonNET* P_0, uint A_0)
	{
		P_0 = (CInstantCameraForPylonNET*)((byte*)P_0 - 96);
		return Basler_002EPylon_002ECInstantCameraForPylonNET_002E__vecDelDtor(P_0, A_0);
	}

	internal unsafe static void* _003F_003F_ECInstantCameraForPylonNET_0040Pylon_0040Basler_0040_0040_0024_0024FWGI_0040AEPAXI_0040Z(CInstantCameraForPylonNET* P_0, uint A_0)
	{
		P_0 = (CInstantCameraForPylonNET*)((byte*)P_0 - 104);
		return Basler_002EPylon_002ECInstantCameraForPylonNET_002E__vecDelDtor(P_0, A_0);
	}

	[SpecialName]
	internal unsafe static bad_cast* std_002Ebad_cast_002E_007Bctor_007D(bad_cast* P_0, bad_cast* A_0)
	{
		std_002Eexception_002E_007Bctor_007D((exception*)P_0, (exception*)A_0);
		try
		{
			*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7bad_cast_0040std_0040_00406B_0040);
			return P_0;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<exception*, void>)(&std_002Eexception_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	internal unsafe static void std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_007Bdtor_007D(_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E* P_0)
	{
		std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D((_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty*)P_0);
	}

	internal unsafe static void std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D(_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E* P_0)
	{
		std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D((_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty*)P_0);
	}

	internal unsafe static void std_002E_String_alloc_003Cstd_003A_003A_String_base_types_003Cchar_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E_002E_007Bdtor_007D(_String_alloc_003Cstd_003A_003A_String_base_types_003Cchar_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_0020_003E* P_0)
	{
		std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D((_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty*)P_0);
	}

	internal unsafe static NullReferenceException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(NullReferenceException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static object Basler_002EPylon_002EAllocAndCopy_003Cunsigned_0020short_003E(void* src, uint nBytes)
	{
		ushort[] array = new ushort[nBytes >> 1];
		fixed (ushort* ptr = &array[array.GetLowerBound(0)])
		{
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr, src, nBytes);
			return array;
		}
	}

	internal unsafe static object Basler_002EPylon_002EAllocAndCopy_003Cfloat_003E(void* src, uint nBytes)
	{
		float[] array = new float[nBytes >> 2];
		fixed (float* ptr = &array[array.GetLowerBound(0)])
		{
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr, src, nBytes);
			return array;
		}
	}

	internal unsafe static object Basler_002EPylon_002EAllocAndCopy_003Cdouble_003E(void* src, uint nBytes)
	{
		double[] array = new double[nBytes >> 3];
		fixed (double* ptr = &array[array.GetLowerBound(0)])
		{
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr, src, nBytes);
			return array;
		}
	}

	internal unsafe static object Basler_002EPylon_002EAllocAndCopy_003Cunsigned_0020char_003E(void* src, uint nBytes)
	{
		byte[] array = new byte[nBytes];
		fixed (byte* ptr = &array[array.GetLowerBound(0)])
		{
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr, src, nBytes);
			return array;
		}
	}

	internal unsafe static CNativeBufferFactory* Basler_002EPylon_002ECNativeBufferFactory_002E_007Bctor_007D(CNativeBufferFactory* P_0, Basler.Pylon.IBufferFactory bufferFactory_man, BufferReleaser bufferReleaser)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7IBufferFactory_0040Pylon_0040_00406B_0040);
		try
		{
			*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CNativeBufferFactory_0040Pylon_0040Basler_0040_00406B_0040);
			((int*)P_0)[1] = (int)((IntPtr)GCHandle.Alloc(bufferFactory_man)).ToPointer();
			try
			{
				CNativeBufferFactory* ptr = (CNativeBufferFactory*)((byte*)P_0 + 8);
				gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*)ptr);
				try
				{
					gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*)ptr, bufferReleaser.DoFree);
					((int*)P_0)[3] = (int)Marshal.GetFunctionPointerForDelegate((Delegate)gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_002EP_0024AAVBufferCallbackDelegateXY_0040BufferReleaser_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*)ptr)).ToPointer();
					return P_0;
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 8);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 4);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.IBufferFactory*, void>)(&Pylon_002EIBufferFactory_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	internal unsafe static void Basler_002EPylon_002ECNativeBufferFactory_002EAllocateBuffer(CNativeBufferFactory* P_0, uint bufferSize, void** pCreatedBuffer, int* bufferContext)
	{
		object obj = null;
		object obj2 = null;
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		if (null == pCreatedBuffer)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E);
			ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E* ptr = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FN_0040EAMMAGKC_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 84, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BJ_0040NPEJAJGA_0040InvalidArgumentException_0040));
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out InvalidArgumentException ex);
				GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002EReport(ptr, &ex, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0CE_0040CPGNCONO_0040Argument_003F5pCreatedBuffer_003F5is_003F5null_0040), __arglist());
				_CxxThrowException(&ex, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVInvalidArgumentException_0040GenICam_3_1_Basler_pylon_0040_0040));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E);
				throw;
			}
		}
		NativeBufferContext* ptr2 = (NativeBufferContext*)@new(20u);
		NativeBufferContext* ptr3;
		try
		{
			if (ptr2 != null)
			{
				// IL initblk instruction
				System.Runtime.CompilerServices.Unsafe.InitBlock(ptr2, 0, 20);
				ptr3 = Basler_002EPylon_002ENativeBufferContext_002E_007Bctor_007D(ptr2);
			}
			else
			{
				ptr3 = null;
			}
		}
		catch
		{
			//try-fault
			delete(ptr2, 20u);
			throw;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E obj3);
		std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_003E_002C0_003E(&obj3, ptr3);
		try
		{
			if (std_002Eoperator_003D_003D_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_002Cstruct_0020std_003A_003Adefault_delete_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E(null, &obj3))
			{
				*(int*)pCreatedBuffer = 0;
				goto IL_00a3;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E*, void>)(&std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D), &obj3);
			throw;
		}
		try
		{
			if (null == gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002EP_0024AAUIBufferFactory_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)((byte*)P_0 + 4)))
			{
				try
				{
					gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 4), new byte[bufferSize]);
					GCHandle gCHandle = GCHandle.Alloc(gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 4)), GCHandleType.Pinned);
					GCHandle gCHandle2 = gCHandle;
					gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 16), gCHandle);
					IntPtr intPtr = ((GCHandle)gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_002D_003E((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 16))).AddrOfPinnedObject();
					IntPtr intPtr2 = intPtr;
					gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 8), intPtr);
					*(int*)pCreatedBuffer = (int)((IntPtr)gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002D_003E((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 8))).ToPointer();
					IntPtr intPtr3 = (IntPtr)(GCHandle)gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_002EP_0024AA__ZVGCHandle_0040InteropServices_0040Runtime_0040System_0040_0040((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 16));
					IntPtr intPtr4 = intPtr3;
					*bufferContext = (int)intPtr3;
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
				}).Invoke())
				{
					uint num2 = 0u;
					__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
					try
					{
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E);
							ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* ptr4 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FN_0040EAMMAGKC_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 107, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BC_0040KBLGPICI_0040BadAllocException_0040));
							try
							{
								System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException ex2);
								GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002EReport(ptr4, &ex2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0DF_0040HDFLIINE_0040Could_003F5not_003F5allocate_003F5buffer_003F5in_003F5ma_0040), __arglist());
								_CxxThrowException(&ex2, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040));
							}
							catch
							{
								//try-fault
								___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E);
								throw;
							}
						}
						catch when (((Func<bool>)delegate
						{
							// Could not convert BlockContainer to single expression
							num2 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
							return (byte)num2 != 0;
						}).Invoke())
						{
						}
						if (num2 != 0)
						{
							throw;
						}
					}
					finally
					{
						__CxxUnregisterExceptionObject((void*)num, (int)num2);
					}
				}
				goto IL_0352;
			}
			obj = null;
			IntPtr createdPinnedBuffer = IntPtr.Zero;
			obj2 = null;
			try
			{
				gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002D_003E((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)((byte*)P_0 + 4)).AllocateBuffer(bufferSize, ref obj, ref createdPinnedBuffer, ref obj2);
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E2);
						ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* ptr5 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FN_0040EAMMAGKC_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 123, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BC_0040KBLGPICI_0040BadAllocException_0040));
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException ex3);
							GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002EReport(ptr5, &ex3, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0DF_0040HDFLIINE_0040Could_003F5not_003F5allocate_003F5buffer_003F5in_003F5ma_0040), __arglist());
							_CxxThrowException(&ex3, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040));
						}
						catch
						{
							//try-fault
							___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E2);
							throw;
						}
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
			if (null != obj && !(IntPtr.Zero == createdPinnedBuffer))
			{
				*(int*)pCreatedBuffer = (int)createdPinnedBuffer.ToPointer();
				gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* ptr6 = (gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3);
				Basler.Pylon.IBufferFactory target = gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002EP_0024AAUIBufferFactory_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)((byte*)P_0 + 4));
				IntPtr intPtr5 = new IntPtr((void*)(int)(*(uint*)ptr6));
				GCHandle gCHandle3 = (GCHandle)intPtr5;
				gCHandle3.Target = target;
				gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 4), obj);
				gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 8), createdPinnedBuffer);
				gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(&obj3) + 12), obj2);
				goto IL_0352;
			}
			goto end_IL_00b0;
			IL_0352:
			*bufferContext = (int)std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002Erelease(&obj3);
			goto IL_036b;
			end_IL_00b0:;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E*, void>)(&std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D), &obj3);
			throw;
		}
		try
		{
			*(int*)pCreatedBuffer = 0;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E*, void>)(&std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D), &obj3);
			throw;
		}
		std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D(&obj3);
		goto IL_0390;
		IL_0390:
		try
		{
			return;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E*, void>)(&std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D), &obj3);
			throw;
		}
		IL_00a3:
		std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D(&obj3);
		goto IL_0390;
		IL_036b:
		std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D(&obj3);
		goto IL_0390;
	}

	internal unsafe static void Basler_002EPylon_002ECNativeBufferFactory_002EFreeBuffer(CNativeBufferFactory* P_0, void* pCreatedBuffer, int bufferContext)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<int, void>)(int)((uint*)P_0)[3])(bufferContext);
	}

	internal unsafe static void Basler_002EPylon_002ECNativeBufferFactory_002EDestroyBufferFactory(CNativeBufferFactory* P_0)
	{
		if (P_0 != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)P_0)))((nint)P_0, 1u);
		}
	}

	internal unsafe static void* Basler_002EPylon_002ECNativeBufferFactory_002E__vecDelDtor(CNativeBufferFactory* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CNativeBufferFactory* ptr = (CNativeBufferFactory*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 16u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CNativeBufferFactory*, void>)(&Basler_002EPylon_002ECNativeBufferFactory_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 16 + 4));
			}
			return ptr;
		}
		try
		{
			try
			{
				gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*)((byte*)P_0 + 8));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 4);
				throw;
			}
			gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)((byte*)P_0 + 4));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.IBufferFactory*, void>)(&Pylon_002EIBufferFactory_002E_007Bdtor_007D), P_0);
			throw;
		}
		Pylon_002EIBufferFactory_002E_007Bdtor_007D((Pylon.IBufferFactory*)P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 16u);
		}
		return P_0;
	}

	internal unsafe static void Basler_002EPylon_002ECNativeBufferFactory_002E_007Bdtor_007D(CNativeBufferFactory* P_0)
	{
		try
		{
			try
			{
				gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E*)((byte*)P_0 + 8));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 4);
				throw;
			}
			gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)((byte*)P_0 + 4));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.IBufferFactory*, void>)(&Pylon_002EIBufferFactory_002E_007Bdtor_007D), P_0);
			throw;
		}
		Pylon_002EIBufferFactory_002E_007Bdtor_007D((Pylon.IBufferFactory*)P_0);
	}

	internal unsafe static NativeBufferContext* Basler_002EPylon_002ENativeBufferContext_002E_007Bctor_007D(NativeBufferContext* P_0)
	{
		gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)P_0);
		try
		{
			gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bctor_007D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)P_0 + 4));
			try
			{
				gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bctor_007D((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)((byte*)P_0 + 8));
				try
				{
					gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bctor_007D((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)((byte*)P_0 + 12));
					try
					{
						gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_007Bctor_007D((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)((byte*)P_0 + 16));
						return P_0;
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AObject_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 12);
						throw;
					}
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 8);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CSystem_003A_003AObject_0020_005E_003E*, void>)(&gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 4);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	internal unsafe static void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* P_0)
	{
		try
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)((byte*)P_0 + 76));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), P_0);
			throw;
		}
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)P_0);
	}

	internal unsafe static void Pylon_002EGrabResultPrivate_002ESetPayloadSize(GrabResultPrivate* P_0, ulong payloadSize)
	{
		if (payloadSize > 4294967295L)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E);
			ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E* ptr = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0GC_0040GCEMICGO_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 199, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BE_0040DPOFGLGK_0040OutOfRangeException_0040));
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out OutOfRangeException ex);
				GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002EReport(ptr, &ex, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BE_0040KOOIPLDH_0040PayloadSize_003F5too_003F5big_0040), __arglist());
				_CxxThrowException(&ex, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVOutOfRangeException_0040GenICam_3_1_Basler_pylon_0040_0040));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E);
				throw;
			}
		}
		((long*)P_0)[8] = (long)payloadSize;
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_base_002E_007Bdtor_007D(sp_counted_base* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_base_002Edestroy(sp_counted_base* P_0)
	{
		if (P_0 != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)P_0)))((nint)P_0, 1u);
		}
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_base_002Erelease(sp_counted_base* P_0)
	{
		if (Interlocked.Decrement(ref *(int*)((byte*)P_0 + 4)) == 0)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)P_0 + 4)))((nint)P_0);
			if (Interlocked.Decrement(ref *(int*)((byte*)P_0 + 8)) == 0)
			{
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, void>)(int)(*(uint*)(*(int*)P_0 + 8)))((nint)P_0);
			}
		}
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_base_002E__vecDelDtor(sp_counted_base* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			sp_counted_base* ptr = (sp_counted_base*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 12u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<sp_counted_base*, void>)(&boost_002Edetail_002Esp_counted_base_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 12 + 4));
			}
			return ptr;
		}
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 12u);
		}
		return P_0;
	}

	internal unsafe static void boost_002Edetail_002Eshared_count_002E_007Bdtor_007D(shared_count* P_0)
	{
		uint num = *(uint*)P_0;
		if (num != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num);
		}
	}

	internal unsafe static CBufferData* Pylon_002ECBufferData_002E_007Bctor_007D(CBufferData* P_0)
	{
		*(int*)P_0 = 0;
		((int*)P_0)[1] = 0;
		((int*)P_0)[2] = 0;
		((sbyte*)P_0)[12] = 0;
		((int*)P_0)[4] = 0;
		((int*)P_0)[5] = 0;
		shared_ptr_003CPylon_003A_003ACBufferData_003E* ptr = (shared_ptr_003CPylon_003A_003ACBufferData_003E*)((byte*)P_0 + 24);
		*(int*)ptr = 0;
		((int*)ptr)[1] = 0;
		return P_0;
	}

	internal unsafe static CBufferData* Pylon_002ECBufferData_002ENew(uint bufferSize, void* externalBuffer, int theFactoryContext)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		CBufferData* ptr = null;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out bad_alloc* ptr6);
		try
		{
			CBufferData* ptr2 = (CBufferData*)@new(32u);
			CBufferData* ptr3;
			try
			{
				ptr3 = ((ptr2 == null) ? null : Pylon_002ECBufferData_002E_007Bctor_007D(ptr2));
				CBufferData* ptr4 = ptr3;
			}
			catch
			{
				//try-fault
				delete(ptr2, 32u);
				throw;
			}
			ptr = ptr3;
			((int*)ptr3)[2] = theFactoryContext;
			void* ptr5 = ((externalBuffer == null) ? new_005B_005D(bufferSize) : externalBuffer);
			((int*)ptr3)[1] = (int)ptr5;
			int num2 = ((externalBuffer != null) ? 1 : 0);
			((sbyte*)ptr3)[12] = (sbyte)num2;
			*(uint*)ptr3 = bufferSize;
		}
		catch when (__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_R0_003FAVbad_alloc_0040std_0040_0040_00408), 9, &ptr6) != 0)
		{
			uint num3 = 0u;
			__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					System.Runtime.CompilerServices.Unsafe.SkipInit(out ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E);
					ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* ptr7 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bctor_007D(&exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0FP_0040CLGIBDGD_0040d_003F3_003F2jenkinscore_003F2workspace_003F2pylon_003F9_0040), 52, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BC_0040KBLGPICI_0040BadAllocException_0040));
					try
					{
						bad_alloc* intPtr = ptr6;
						System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException ex);
						BadAllocException* ptr8 = GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002EReport(ptr7, &ex, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_0BC_0040BABECPGA_0040Out_003F5of_003F5memory_003F4_003F5_003F_0024CFs_0040), __arglist(((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, sbyte*>)(int)(*(uint*)(*(int*)intPtr + 4)))((nint)intPtr)));
						try
						{
							System.Runtime.CompilerServices.Unsafe.SkipInit(out BadAllocException ex2);
							GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bctor_007D(&ex2, ptr8);
							_CxxThrowException(&ex2, (_s__ThrowInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _TI2_003FAVBadAllocException_0040GenICam_3_1_Basler_pylon_0040_0040));
						}
						catch
						{
							//try-fault
							___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<BadAllocException*, void>)(&GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bdtor_007D), &ex);
							throw;
						}
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E*, void>)(&GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bdtor_007D), &exceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E);
						throw;
					}
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				__CxxUnregisterExceptionObject((void*)num, (int)num3);
			}
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num3 = 0u;
			__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					CBufferData* ptr9 = ptr;
					CBufferData* ptr10 = ptr;
					if (ptr != null)
					{
						void* ptr11 = Pylon_002ECBufferData_002E__delDtor(ptr, 1u);
					}
					else
					{
						void* ptr11 = null;
					}
					_CxxThrowException(null, null);
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num3 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num3 != 0;
				}).Invoke())
				{
				}
				if (num3 != 0)
				{
					throw;
				}
			}
			finally
			{
				__CxxUnregisterExceptionObject((void*)num, (int)num3);
			}
		}
		return ptr;
	}

	internal unsafe static void Pylon_002ECBufferData_002E_007Bdtor_007D(CBufferData* P_0)
	{
		try
		{
			if (((byte*)P_0)[12] == 0)
			{
				CBufferData* ptr = (CBufferData*)((byte*)P_0 + 4);
				int num = *(int*)ptr;
				*(int*)ptr = 0;
				delete_005B_005D((void*)num);
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACBufferData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACBufferData_003E_002E_007Bdtor_007D), (byte*)P_0 + 24);
			throw;
		}
		shared_ptr_003CPylon_003A_003ACBufferData_003E* ptr2 = (shared_ptr_003CPylon_003A_003ACBufferData_003E*)((byte*)P_0 + 24);
		uint num2 = ((uint*)ptr2)[1];
		if (num2 != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num2);
		}
	}

	internal unsafe static void boost_002Eshared_ptr_003CPylon_003A_003ACBufferData_003E_002E_007Bdtor_007D(shared_ptr_003CPylon_003A_003ACBufferData_003E* P_0)
	{
		uint num = ((uint*)P_0)[1];
		if (num != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num);
		}
	}

	internal unsafe static void* Pylon_002ECBufferData_002E__delDtor(CBufferData* P_0, uint A_0)
	{
		Pylon_002ECBufferData_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 32u);
		}
		return P_0;
	}

	internal unsafe static void Pylon_002ECGrabResultProperties_002E_007Bdtor_007D(CGrabResultProperties* P_0)
	{
		try
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)((byte*)P_0 + 228));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.GrabResult*, void>)(&Pylon_002EGrabResult_002E_007Bdtor_007D), P_0);
			throw;
		}
		Pylon_002EGrabResult_002E_007Bdtor_007D((Pylon.GrabResult*)P_0);
	}

	internal unsafe static CGrabResultProperties* Pylon_002ECGrabResultProperties_002E_007Bctor_007D(CGrabResultProperties* P_0, Pylon.GrabResult* r)
	{
		Pylon_002EGrabResult_002E_007Bctor_007D((Pylon.GrabResult*)P_0);
		try
		{
			CGrabResultProperties* ptr = (CGrabResultProperties*)((byte*)P_0 + 228);
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D((gcstring*)ptr);
			try
			{
				Pylon_002EGrabResult_002E_003D((Pylon.GrabResult*)P_0, r);
				((int*)P_0)[40] = (int)Pylon_002EGrabResult_002EBuffer(r);
				((int*)P_0)[41] = (int)Pylon_002EGrabResult_002EGetBufferSize(r);
				((sbyte*)P_0)[168] = (Pylon_002EGrabResult_002ESucceeded(r) ? ((sbyte)1) : ((sbyte)0));
				((int*)P_0)[43] = (int)Pylon_002EGrabResult_002EGetPayloadType(r);
				((int*)P_0)[44] = (int)Pylon_002EGrabResult_002EGetPixelType(r);
				((long*)P_0)[23] = (long)Pylon_002EGrabResult_002EGetTimeStamp(r);
				int num = Pylon_002EGrabResult_002EGetSizeX(r);
				int num2 = ((num >= 0) ? num : 0);
				((int*)P_0)[48] = num2;
				int num3 = Pylon_002EGrabResult_002EGetSizeY(r);
				int num4 = ((num3 >= 0) ? num3 : 0);
				((int*)P_0)[49] = num4;
				int num5 = Pylon_002EGrabResult_002EGetOffsetX(r);
				int num6 = ((num5 >= 0) ? num5 : 0);
				((int*)P_0)[50] = num6;
				int num7 = Pylon_002EGrabResult_002EGetOffsetY(r);
				int num8 = ((num7 >= 0) ? num7 : 0);
				((int*)P_0)[51] = num8;
				int num9 = Pylon_002EGrabResult_002EGetPaddingX(r);
				int num10 = ((num9 >= 0) ? num9 : 0);
				((int*)P_0)[52] = num10;
				int num11 = Pylon_002EGrabResult_002EGetPaddingY(r);
				int num12 = ((num11 >= 0) ? num11 : 0);
				((int*)P_0)[53] = num12;
				long num13 = Pylon_002EGrabResult_002EGetPayloadSize(r);
				long num14 = ((num13 >= 0) ? num13 : 0);
				((long*)P_0)[27] = num14;
				((int*)P_0)[56] = (int)Pylon_002EGrabResult_002EGetErrorCode(r);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
				gcstring* ptr2 = Pylon_002EGrabResult_002EGetErrorDescription(r, &gcstring2);
				try
				{
					GenICam_3_1_Basler_pylon_002Egcstring_002E_003D((gcstring*)ptr, ptr2);
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
					throw;
				}
				GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
				((long*)P_0)[38] = (long)Pylon_002EGrabResult_002EGetBlockID(r);
				return P_0;
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), (byte*)P_0 + 228);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.GrabResult*, void>)(&Pylon_002EGrabResult_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool Pylon_002EGrabResultPtrIsUnique(shared_ptr_003CPylon_003A_003ACGrabResultData_003E* ptr)
	{
		int num5;
		if ((byte)((*(int*)ptr != 0) ? 1u : 0u) != 0)
		{
			uint num = ((uint*)ptr)[1];
			int num2 = ((num != 0 && *(int*)(int)(num + 4) == 1) ? 1 : 0);
			if ((byte)num2 != 0)
			{
				uint num3 = ((uint*)Pylon_002ECGrabResultData_002EGetGrabResultDataImpl((CGrabResultData*)(int)(*(uint*)ptr)))[89];
				int num4 = ((num3 != 0 && *(int*)(int)(num3 + 4) == 1) ? 1 : 0);
				if ((byte)num4 != 0)
				{
					num5 = 1;
					goto IL_0055;
				}
			}
		}
		num5 = 0;
		goto IL_0055;
		IL_0055:
		return (byte)num5 != 0;
	}

	internal unsafe static CGrabResultPtr.CGrabResultPtrImpl* Pylon_002ECGrabResultPtr_002ECGrabResultPtrImpl_002E_007Bctor_007D(CGrabResultPtr.CGrabResultPtrImpl* P_0, shared_ptr_003CPylon_003A_003ACGrabResultData_003E* data)
	{
		shared_ptr_003CPylon_003A_003ACGrabResultData_003E* ptr;
		try
		{
			*(int*)P_0 = *(int*)data;
			byte* num = (byte*)P_0 + 4;
			ptr = (shared_ptr_003CPylon_003A_003ACGrabResultData_003E*)((byte*)data + 4);
			int num2 = (*(int*)num = *(int*)ptr);
			if (num2 != 0)
			{
				Interlocked.Increment(ref *(int*)(num2 + 4));
			}
			try
			{
				CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* ptr2 = (CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E*)((byte*)P_0 + 8);
				*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7IImage_0040Pylon_0040_00406B_0040);
				try
				{
					*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040);
					((int*)ptr2)[1] = (int)P_0;
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.IImage*, void>)(&Pylon_002EIImage_002E_007Bdtor_007D), ptr2);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACGrabResultData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACGrabResultData_003E_002E_007Bdtor_007D), P_0);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACGrabResultData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACGrabResultData_003E_002E_007Bdtor_007D), data);
			throw;
		}
		uint num3 = *(uint*)ptr;
		if (num3 != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num3);
		}
		return P_0;
	}

	internal unsafe static void Pylon_002ECGrabResultPtr_002ECGrabResultPtrImpl_002E_007Bdtor_007D(CGrabResultPtr.CGrabResultPtrImpl* P_0)
	{
		try
		{
			CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* ptr = (CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E*)((byte*)P_0 + 8);
			*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040);
			Pylon_002EIImage_002E_007Bdtor_007D((Pylon.IImage*)ptr);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACGrabResultData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACGrabResultData_003E_002E_007Bdtor_007D), P_0);
			throw;
		}
		uint num = ((uint*)P_0)[1];
		if (num != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num);
		}
	}

	internal unsafe static void boost_002Eshared_ptr_003CPylon_003A_003ACGrabResultData_003E_002E_007Bdtor_007D(shared_ptr_003CPylon_003A_003ACGrabResultData_003E* P_0)
	{
		uint num = ((uint*)P_0)[1];
		if (num != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num);
		}
	}

	internal unsafe static CGrabResultPtr* PylonInternal_002EMockGrabResult_002EGetGrabResultPtr(MockGrabResult* P_0, CGrabResultPtr* P_1)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out uint num);
		try
		{
			num = 0u;
			MockGrabResult.CreatableGrabResultData* ptr = (MockGrabResult.CreatableGrabResultData*)@new(92u);
			MockGrabResult.CreatableGrabResultData* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : PylonInternal_002EMockGrabResult_002ECreatableGrabResultData_002E_007Bctor_007D(ptr, (Pylon.GrabResult*)P_0));
			}
			catch
			{
				//try-fault
				delete(ptr, 92u);
				throw;
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003CPylon_003A_003ACGrabResultData_003E shared_ptr_003CPylon_003A_003ACGrabResultData_003E2);
			*(int*)(&shared_ptr_003CPylon_003A_003ACGrabResultData_003E2) = (int)ptr2;
			System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)) = 0;
			try
			{
				boost_002Edetail_002Esp_pointer_construct_003Cclass_0020Pylon_003A_003ACGrabResultData_002Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(&shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, ptr2, (shared_count*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_count*, void>)(&boost_002Edetail_002Eshared_count_002E_007Bdtor_007D), System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)));
				throw;
			}
			try
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003CPylon_003A_003ACGrabResultData_003E shared_ptr_003CPylon_003A_003ACGrabResultData_003E3);
				shared_ptr_003CPylon_003A_003ACGrabResultData_003E* ptr3 = &shared_ptr_003CPylon_003A_003ACGrabResultData_003E3;
				*(int*)(&shared_ptr_003CPylon_003A_003ACGrabResultData_003E3) = *(int*)(&shared_ptr_003CPylon_003A_003ACGrabResultData_003E2);
				System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E3, 4)) = System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4));
				if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)) != 0)
				{
					Interlocked.Increment(ref *(int*)(System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)) + 4));
				}
				System.Runtime.CompilerServices.Unsafe.SkipInit(out CGrabResultPtr.CGrabResultPtrImpl cGrabResultPtrImpl);
				Pylon_002ECGrabResultPtr_002ECGrabResultPtrImpl_002E_007Bctor_007D(&cGrabResultPtrImpl, &shared_ptr_003CPylon_003A_003ACGrabResultData_003E3);
				try
				{
					Pylon_002ECGrabResultPtr_002E_007Bctor_007D(P_1);
					num = 1u;
					Pylon_002ECGrabResultPtr_002E_003D(P_1, &cGrabResultPtrImpl);
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultPtr.CGrabResultPtrImpl*, void>)(&Pylon_002ECGrabResultPtr_002ECGrabResultPtrImpl_002E_007Bdtor_007D), &cGrabResultPtrImpl);
					throw;
				}
				Pylon_002ECGrabResultPtr_002ECGrabResultPtrImpl_002E_007Bdtor_007D(&cGrabResultPtrImpl);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACGrabResultData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACGrabResultData_003E_002E_007Bdtor_007D), &shared_ptr_003CPylon_003A_003ACGrabResultData_003E2);
				throw;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)) != 0)
			{
				boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACGrabResultData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACGrabResultData_003E2, 4)));
			}
			return P_1;
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultPtr*, void>)(&Pylon_002ECGrabResultPtr_002E_007Bdtor_007D), P_1);
			}
			throw;
		}
	}

	internal unsafe static MockGrabResult.CreatableGrabResultData* PylonInternal_002EMockGrabResult_002ECreatableGrabResultData_002E_007Bctor_007D(MockGrabResult.CreatableGrabResultData* P_0, Pylon.GrabResult* grabResult)
	{
		Pylon_002ECGrabResultData_002E_007Bctor_007D((CGrabResultData*)P_0);
		try
		{
			*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_00406B_0040);
			CGrabResultData.CGrabResultDataImpl* ptr = Pylon_002ECGrabResultData_002EGetGrabResultDataImpl((CGrabResultData*)P_0);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out CGrabResultProperties cGrabResultProperties);
			Pylon_002ECGrabResultProperties_002E_007Bctor_007D(&cGrabResultProperties, grabResult);
			try
			{
				Pylon_002ECGrabResultProperties_002E_003D((CGrabResultProperties*)((byte*)ptr + 40), &cGrabResultProperties);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultProperties*, void>)(&Pylon_002ECGrabResultProperties_002E_007Bdtor_007D), &cGrabResultProperties);
				throw;
			}
			try
			{
				GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref cGrabResultProperties, 228)));
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<Pylon.GrabResult*, void>)(&Pylon_002EGrabResult_002E_007Bdtor_007D), &cGrabResultProperties);
				throw;
			}
			Pylon_002EGrabResult_002E_007Bdtor_007D((Pylon.GrabResult*)(&cGrabResultProperties));
			((int*)ptr)[107] = (int)Pylon_002EGrabResult_002EContext(grabResult);
			boost_002Eshared_ptr_003CPylon_003A_003ACBufferData_003E_002Ereset_003Cclass_0020Pylon_003A_003ACBufferData_003E((shared_ptr_003CPylon_003A_003ACBufferData_003E*)((byte*)ptr + 352), Pylon_002ECBufferData_002ENew(0u, null, 0));
			return P_0;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CGrabResultData*, void>)(&Pylon_002ECGrabResultData_002E_007Bdtor_007D), P_0);
			throw;
		}
	}

	internal unsafe static void Pylon_002EGrabResultPrivate_002E_007Bdtor_007D(GrabResultPrivate* P_0)
	{
		Pylon_002EGrabResult_002E_007Bdtor_007D((Pylon.GrabResult*)P_0);
	}

	internal unsafe static void* PylonInternal_002EMockGrabResult_002ECreatableGrabResultData_002E__vecDelDtor(MockGrabResult.CreatableGrabResultData* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			MockGrabResult.CreatableGrabResultData* ptr = (MockGrabResult.CreatableGrabResultData*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 92u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<MockGrabResult.CreatableGrabResultData*, void>)(&PylonInternal_002EMockGrabResult_002ECreatableGrabResultData_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 92 + 4));
			}
			return ptr;
		}
		Pylon_002ECGrabResultData_002E_007Bdtor_007D((CGrabResultData*)P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 92u);
		}
		return P_0;
	}

	internal unsafe static void PylonInternal_002EMockGrabResult_002ECreatableGrabResultData_002E_007Bdtor_007D(MockGrabResult.CreatableGrabResultData* P_0)
	{
		Pylon_002ECGrabResultData_002E_007Bdtor_007D((CGrabResultData*)P_0);
	}

	internal unsafe static CGrabResultProperties* Pylon_002ECGrabResultProperties_002E_003D(CGrabResultProperties* P_0, CGrabResultProperties* A_0)
	{
		Pylon_002EGrabResult_002E_003D((Pylon.GrabResult*)P_0, (Pylon.GrabResult*)A_0);
		((int*)P_0)[40] = ((int*)A_0)[40];
		((int*)P_0)[41] = ((int*)A_0)[41];
		((sbyte*)P_0)[168] = ((sbyte*)A_0)[168];
		((int*)P_0)[43] = ((int*)A_0)[43];
		((int*)P_0)[44] = ((int*)A_0)[44];
		((long*)P_0)[23] = ((long*)A_0)[23];
		((int*)P_0)[48] = ((int*)A_0)[48];
		((int*)P_0)[49] = ((int*)A_0)[49];
		((int*)P_0)[50] = ((int*)A_0)[50];
		((int*)P_0)[51] = ((int*)A_0)[51];
		((int*)P_0)[52] = ((int*)A_0)[52];
		((int*)P_0)[53] = ((int*)A_0)[53];
		((long*)P_0)[27] = ((long*)A_0)[27];
		((int*)P_0)[56] = ((int*)A_0)[56];
		GenICam_3_1_Basler_pylon_002Egcstring_002E_003D((gcstring*)((byte*)P_0 + 228), (gcstring*)((byte*)A_0 + 228));
		((long*)P_0)[38] = ((long*)A_0)[38];
		return P_0;
	}

	internal unsafe static void std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 112);
		std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(ptr);
		std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetStride(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0, uint* strideBytes)
	{
		if (Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0))
		{
			return Pylon_002ECGrabResultData_002EGetStride((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1]), strideBytes);
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsUnique(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002EGrabResultPtrIsUnique((shared_ptr_003CPylon_003A_003ACGrabResultData_003E*)(int)((uint*)P_0)[1]);
	}

	internal unsafe static uint Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetImageSize(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetImageSize((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : 0u;
	}

	internal unsafe static void* Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetBuffer(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetBuffer((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : null;
	}

	internal unsafe static void* Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetBuffer(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetBuffer((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : null;
	}

	internal unsafe static EImageOrientation Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetOrientation(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return (EImageOrientation)0;
	}

	internal unsafe static uint Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetPaddingX(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetPaddingX((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : 0u;
	}

	internal unsafe static uint Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetHeight(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetHeight((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : 0u;
	}

	internal unsafe static uint Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetWidth(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0) ? Pylon_002ECGrabResultData_002EGetWidth((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1])) : 0u;
	}

	internal unsafe static EPixelType Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EGetPixelType(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return (!Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0)) ? ((EPixelType)(-1)) : Pylon_002ECGrabResultData_002EGetPixelType((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1]));
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValid(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		return Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(P_0);
	}

	internal unsafe static void Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002E_007Bdtor_007D(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040);
		Pylon_002EIImage_002E_007Bdtor_007D((Pylon.IImage*)P_0);
	}

	[SecuritySafeCritical]
	internal unsafe static BufferReleaser.BufferCallbackDelegateXY gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_002EP_0024AAVBufferCallbackDelegateXY_0040BufferReleaser_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (BufferReleaser.BufferCallbackDelegateXY)((GCHandle)intPtr).Target;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* P_0, BufferReleaser.BufferCallbackDelegateXY t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003ABufferReleaser_003A_003ABufferCallbackDelegateXY_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecuritySafeCritical]
	internal unsafe static ValueType gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_002EP_0024AA__ZVGCHandle_0040InteropServices_0040Runtime_0040System_0040_0040(gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ValueType)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_003D(gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* P_0, ValueType t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_007Bctor_007D(gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[SecuritySafeCritical]
	internal unsafe static ValueType gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002D_003E(gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ValueType)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_003D(gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* P_0, ValueType t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_007Bctor_007D(gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CSystem_003A_003AObject_0020_005E_003E* gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_003D(gcroot_003CSystem_003A_003AObject_0020_005E_003E* P_0, object t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CSystem_003A_003AObject_0020_005E_003E* gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_007Bctor_007D(gcroot_003CSystem_003A_003AObject_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	internal unsafe static void std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 112);
		*((int*)((byte*)P_0 + *(int*)(*(int*)ptr + 4)) - 28) = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040);
		int num = *(int*)(*(int*)ptr + 4);
		*((int*)((byte*)P_0 + num) - 29) = num - 112;
		try
		{
			std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 96));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)P_0 - 112 + 24);
			throw;
		}
		std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 88));
	}

	internal unsafe static void std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, char* _Filename, int _Mode, int _Prot)
	{
		if (std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen((basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 16), _Filename, _Mode | 1, _Prot) == null)
		{
			std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetstate((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)(*(int*)(*(int*)P_0 + 4) + (byte*)P_0), 2, false);
		}
		else
		{
			std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclear((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)(*(int*)(*(int*)P_0 + 4) + (byte*)P_0), 0, false);
		}
	}

	internal unsafe static basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1)
	{
		uint num = 0u;
		if (P_1 != 0)
		{
			*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_8_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00407B_0040);
			std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 112));
			try
			{
				num = 1u;
			}
			catch
			{
				//try-fault
				if ((num & 1) != 0)
				{
					num &= 0xFFFFFFFEu;
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)P_0 + 112);
				}
				throw;
			}
		}
		try
		{
			basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 16);
			std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D((basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, (basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr, false, 0);
			try
			{
				*(int*)(*(int*)(*(int*)P_0 + 4) + (byte*)P_0) = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040);
				int num2 = *(int*)(*(int*)P_0 + 4);
				*((int*)((byte*)P_0 + num2) - 1) = num2 - 112;
				basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr;
				std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr2);
				try
				{
					*(int*)ptr2 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040);
					std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(ptr2, null, (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl)0);
					return P_0;
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), ptr2);
					throw;
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)P_0 + 24);
				throw;
			}
		}
		catch
		{
			//try-fault
			if ((num & 1) != 0)
			{
				num &= 0xFFFFFFFEu;
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), (byte*)P_0 + 112);
			}
			throw;
		}
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eimbue(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, locale* _Loc)
	{
		codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* ptr = std_002Euse_facet_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020_003E(_Loc);
		if (std_002Ecodecvt_base_002Ealways_noconv((codecvt_base*)ptr))
		{
			((int*)P_0)[14] = 0;
			return;
		}
		((int*)P_0)[14] = (int)std_002Eaddressof_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020const_0020_003E(ptr);
		std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
	}

	internal unsafe static int std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esync(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		if (((int*)P_0)[19] != 0)
		{
			int num = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, int, int>)(int)(*(uint*)(*(int*)P_0 + 12)))((nint)P_0, std_002Echar_traits_003Cchar_003E_002Eeof());
			int num2 = std_002Echar_traits_003Cchar_003E_002Eeof();
			if (!std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num2, &num) && 0 > fflush((_iobuf*)(int)((uint*)P_0)[19]))
			{
				return -1;
			}
		}
		return 0;
	}

	internal unsafe static basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetbuf(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* _Buffer, long _Count)
	{
		uint num = ((uint*)P_0)[19];
		if (num != 0)
		{
			int num2 = ((_Buffer == null && _Count == 0) ? 4 : 0);
			if (setvbuf((_iobuf*)(int)num, _Buffer, num2, (uint)_Count) == 0)
			{
				std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(P_0, (_iobuf*)(int)((uint*)P_0)[19], (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl)1);
				return (basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0;
			}
		}
		return null;
	}

	internal unsafe static fpos_003C_Mbstatet_003E* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eseekpos(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, fpos_003C_Mbstatet_003E* P_1, fpos_003C_Mbstatet_003E _Pos, int __unnamed001)
	{
		long num = std_002Efpos_003C_Mbstatet_003E_002E_002E_J(&_Pos);
		if (((int*)P_0)[19] != 0 && std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Endwrite(P_0) && fsetpos((_iobuf*)(int)((uint*)P_0)[19], &num) == 0)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out _Mbstatet mbstatet);
			_Mbstatet* ptr = std_002Efpos_003C_Mbstatet_003E_002Estate(&_Pos, &mbstatet);
			basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 64);
			// IL cpblk instruction
			System.Runtime.CompilerServices.Unsafe.CopyBlock(ptr2, ptr, 8);
			std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
			std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(P_1, *(_Mbstatet*)ptr2, num);
			return P_1;
		}
		std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(P_1, -1L);
		return P_1;
	}

	internal unsafe static fpos_003C_Mbstatet_003E* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eseekoff(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, fpos_003C_Mbstatet_003E* P_1, long _Off, int _Way, int __unnamed002)
	{
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) == (byte*)P_0 + 60 && _Way == 1 && ((int*)P_0)[14] == 0)
		{
			_Off += -1L;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out long num);
		if (((int*)P_0)[19] != 0 && std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Endwrite(P_0) && ((_Off == 0 && _Way == 1) || _fseeki64((_iobuf*)(int)((uint*)P_0)[19], _Off, _Way) == 0) && fgetpos((_iobuf*)(int)((uint*)P_0)[19], &num) == 0)
		{
			std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
			std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(P_1, *(_Mbstatet*)((byte*)P_0 + 64), num);
			return P_1;
		}
		std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(P_1, -1L);
		return P_1;
	}

	internal unsafe static long std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsputn(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* _Ptr, long _Count)
	{
		if (((int*)P_0)[14] != 0)
		{
			return std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsputn((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, _Ptr, _Count);
		}
		long num = _Count;
		long num2 = std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Pnavail((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
		if (0 < _Count)
		{
			if (0 < num2)
			{
				if (_Count < num2)
				{
					num2 = _Count;
				}
				std_002Echar_traits_003Cchar_003E_002Ecopy(std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0), _Ptr, (uint)num2);
				int num3 = (int)num2;
				_Ptr = num3 + _Ptr;
				_Count -= num2;
				std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epbump((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, num3);
			}
			if (0 < _Count)
			{
				uint num4 = ((uint*)P_0)[19];
				if (num4 != 0)
				{
					_Count -= fwrite(_Ptr, 1u, (uint)_Count, (_iobuf*)(int)num4);
				}
			}
		}
		return num - _Count;
	}

	internal unsafe static long std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsgetn(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* _Ptr, long _Count)
	{
		if (((int*)P_0)[14] != 0)
		{
			return std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsgetn((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, _Ptr, _Count);
		}
		long num = _Count;
		long num2 = std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gnavail((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
		if (0 < _Count)
		{
			if (0 < num2)
			{
				if (_Count < num2)
				{
					num2 = _Count;
				}
				std_002Echar_traits_003Cchar_003E_002Ecopy(_Ptr, std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0), (uint)num2);
				int num3 = (int)num2;
				_Ptr = num3 + _Ptr;
				_Count -= num2;
				std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egbump((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, num3);
			}
			if (0 < _Count && ((int*)P_0)[19] != 0)
			{
				std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
				_Count -= fread(_Ptr, 1u, (uint)_Count, (_iobuf*)(int)((uint*)P_0)[19]);
			}
		}
		return num - _Count;
	}

	internal unsafe static int std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Euflow(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != null && std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) < std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eegptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0))
		{
			return std_002Echar_traits_003Cchar_003E_002Eto_int_type(std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gninc((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0));
		}
		if (((int*)P_0)[19] == 0)
		{
			return std_002Echar_traits_003Cchar_003E_002Eeof();
		}
		std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
		if (((int*)P_0)[14] == 0)
		{
			int num = fgetc((_iobuf*)(int)((uint*)P_0)[19]);
			int result;
			if (num != -1)
			{
				sbyte b = (sbyte)num;
				result = std_002Echar_traits_003Cchar_003E_002Eto_int_type(&b);
			}
			else
			{
				result = std_002Echar_traits_003Cchar_003E_002Eeof();
			}
			return result;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj);
		std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bctor_007D(&obj);
		int result2;
		try
		{
			int num2 = fgetc((_iobuf*)(int)((uint*)P_0)[19]);
			if (num2 == -1)
			{
				goto IL_00e6;
			}
			basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 64);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte* ptr2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte b2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte* ptr3);
			while (true)
			{
				std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Epush_back(&obj, (sbyte)num2);
				int num3 = std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Ein((codecvt_003Cchar_002Cchar_002C_Mbstatet_003E*)(int)((uint*)P_0)[14], (_Mbstatet*)ptr, std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Edata(&obj), std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Edata(&obj) + (int)std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Esize(&obj), &ptr2, &b2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.Add(ref b2, 1)), &ptr3);
				if (num3 >= 0)
				{
					if (num3 <= 1)
					{
						if (ptr3 != &b2)
						{
							break;
						}
						std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Eerase(&obj, 0u, (uint)(ptr2 - (nuint)std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Edata(&obj)));
						num2 = fgetc((_iobuf*)(int)((uint*)P_0)[19]);
						if (num2 != -1)
						{
							continue;
						}
						goto IL_00e6;
					}
					if (num3 == 3)
					{
						goto IL_00f3;
					}
				}
				result2 = std_002Echar_traits_003Cchar_003E_002Eeof();
				goto end_IL_0069;
			}
			int num4 = (int)(std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Edata(&obj) - (nuint)ptr2);
			int num5 = (int)std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Esize(&obj) + num4;
			if (0 < num5)
			{
				do
				{
					num5--;
					ungetc(*(num5 + ptr2), (_iobuf*)(int)((uint*)P_0)[19]);
				}
				while (num5 > 0);
			}
			int num6 = std_002Echar_traits_003Cchar_003E_002Eto_int_type(&b2);
			goto IL_0139;
			IL_0139:
			int num7 = num6;
			goto IL_013d;
			IL_00f3:
			num7 = *std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Efront(&obj);
			goto IL_013d;
			IL_013d:
			result2 = num7;
			goto end_IL_0069;
			IL_00e6:
			num6 = std_002Echar_traits_003Cchar_003E_002Eeof();
			goto IL_0139;
			end_IL_0069:;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj);
			throw;
		}
		std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D(&obj);
		return result2;
	}

	internal unsafe static int std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eunderflow(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != null && std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) < std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eegptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0))
		{
			return std_002Echar_traits_003Cchar_003E_002Eto_int_type(std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0));
		}
		int num = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, int>)(int)(*(uint*)(*(int*)P_0 + 28)))((nint)P_0);
		int num2 = std_002Echar_traits_003Cchar_003E_002Eeof();
		if (std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num2, &num))
		{
			return num;
		}
		((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, int, int>)(int)(*(uint*)(*(int*)P_0 + 16)))((nint)P_0, num);
		return num;
	}

	internal unsafe static int std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epbackfail(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int _Meta)
	{
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != null && std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eeback((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) < std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0))
		{
			int num = std_002Echar_traits_003Cchar_003E_002Eeof();
			if (!std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num, &_Meta))
			{
				int num2 = std_002Echar_traits_003Cchar_003E_002Eto_int_type(std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) - 1);
				if (!std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num2, &_Meta))
				{
					goto IL_0051;
				}
			}
			std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gndec((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
			return std_002Echar_traits_003Cchar_003E_002Enot_eof(&_Meta);
		}
		goto IL_0051;
		IL_0051:
		if (((int*)P_0)[19] != 0)
		{
			int num3 = std_002Echar_traits_003Cchar_003E_002Eeof();
			if (!std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num3, &_Meta))
			{
				if (((int*)P_0)[14] == 0)
				{
					sbyte b = std_002Echar_traits_003Cchar_003E_002Eto_char_type(&_Meta);
					_iobuf* ptr = (_iobuf*)(int)((uint*)P_0)[19];
					if (ungetc((byte)b, ptr) != -1)
					{
						return _Meta;
					}
				}
				basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 60);
				if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != ptr2)
				{
					*(sbyte*)ptr2 = std_002Echar_traits_003Cchar_003E_002Eto_char_type(&_Meta);
					std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Set_back(P_0);
					return _Meta;
				}
				return std_002Echar_traits_003Cchar_003E_002Eeof();
			}
		}
		return std_002Echar_traits_003Cchar_003E_002Eeof();
	}

	internal unsafe static int std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eoverflow(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int _Meta)
	{
		int num = std_002Echar_traits_003Cchar_003E_002Eeof();
		if (std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num, &_Meta))
		{
			return std_002Echar_traits_003Cchar_003E_002Enot_eof(&_Meta);
		}
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != null && std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) < std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eepptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0))
		{
			*std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Pninc((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) = std_002Echar_traits_003Cchar_003E_002Eto_char_type(&_Meta);
			return _Meta;
		}
		if (((int*)P_0)[19] == 0)
		{
			return std_002Echar_traits_003Cchar_003E_002Eeof();
		}
		std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
		if (((int*)P_0)[14] == 0)
		{
			_iobuf* ptr = (_iobuf*)(int)((uint*)P_0)[19];
			sbyte b = std_002Echar_traits_003Cchar_003E_002Eto_char_type(&_Meta);
			return (!(fputc(b, ptr) != -1)) ? std_002Echar_traits_003Cchar_003E_002Eeof() : _Meta;
		}
		sbyte b2 = std_002Echar_traits_003Cchar_003E_002Eto_char_type(&_Meta);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte* ptr2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out _0024ArrayType_0024_0024_0024BY0CA_0040D _0024ArrayType_0024_0024_0024BY0CA_0040D2);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte* ptr3);
		switch (std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Eout((codecvt_003Cchar_002Cchar_002C_Mbstatet_003E*)(int)((uint*)P_0)[14], (_Mbstatet*)((byte*)P_0 + 64), &b2, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.Add(ref b2, 1)), &ptr2, (sbyte*)(&_0024ArrayType_0024_0024_0024BY0CA_0040D2), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY0CA_0040D2, 32)), &ptr3))
		{
		case 3:
		{
			_iobuf* ptr4 = (_iobuf*)(int)((uint*)P_0)[19];
			return (!(fputc(b2, ptr4) != -1)) ? std_002Echar_traits_003Cchar_003E_002Eeof() : _Meta;
		}
		case 0:
		case 1:
		{
			uint num2 = (uint)((ref *(_003F*)ptr3) - (ref *(_003F*)(&_0024ArrayType_0024_0024_0024BY0CA_0040D2)));
			if (0 < num2 && num2 != fwrite(&_0024ArrayType_0024_0024_0024BY0CA_0040D2, 1u, num2, (_iobuf*)(int)((uint*)P_0)[19]))
			{
				return std_002Echar_traits_003Cchar_003E_002Eeof();
			}
			((sbyte*)P_0)[61] = 1;
			if (ptr2 != &b2)
			{
				return _Meta;
			}
			return std_002Echar_traits_003Cchar_003E_002Eeof();
		}
		default:
			return std_002Echar_traits_003Cchar_003E_002Eeof();
		}
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Unlock(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		uint num = ((uint*)P_0)[19];
		if (num != 0)
		{
			_unlock_file((_iobuf*)(int)num);
		}
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Lock(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		uint num = ((uint*)P_0)[19];
		if (num != 0)
		{
			_lock_file((_iobuf*)(int)num);
		}
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_00406B_0040);
		try
		{
			if (((int*)P_0)[19] != 0)
			{
				std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(P_0);
			}
			if (((bool*)P_0)[72])
			{
				std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(P_0);
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D), P_0);
			throw;
		}
		std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
	}

	internal unsafe static void* Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002E__vecDelDtor(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* ptr = (CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 8u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E*, void>)(&Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 8 + 4));
			}
			return ptr;
		}
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024CGrabResultPtrImageT_0040ABV_003F_0024shared_ptr_0040VCGrabResultData_0040Pylon_0040_0040_0040boost_0040_0040_0040Pylon_0040_00406B_0040);
		Pylon_002EIImage_002E_007Bdtor_007D((Pylon.IImage*)P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 8u);
		}
		return P_0;
	}

	internal unsafe static void* std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 116);
			__ehvec_dtor((byte*)P_0 - 112, 184u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vbaseDtor));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 184 + 4));
			}
			return ptr;
		}
		basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr2 = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 112);
		basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr3 = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)ptr2 + 112);
		std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(ptr3);
		std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D((basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)ptr3);
		if ((A_0 & 1) != 0)
		{
			delete(ptr2, 184u);
		}
		return ptr2;
	}

	internal unsafe static void* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 88u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*, void>)(&std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 88 + 4));
			}
			return ptr;
		}
		std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 88u);
		}
		return P_0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool Pylon_002ECGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E_002EIsValidImpl(CGrabResultPtrImageT_003Cboost_003A_003Ashared_ptr_003CPylon_003A_003ACGrabResultData_003E_0020const_0020_0026_003E* P_0)
	{
		uint num = *(uint*)(int)((uint*)P_0)[1];
		int num2 = (((byte)((num != 0) ? 1u : 0u) != 0 && Pylon_002ECGrabResultData_002EGetPixelType((CGrabResultData*)(int)num) != (EPixelType)(-1) && Pylon_002ECGrabResultData_002EGrabSucceeded((CGrabResultData*)(int)(*(uint*)(int)((uint*)P_0)[1]))) ? 1 : 0);
		return (byte)num2 != 0;
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Set_back(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)P_0 + 60);
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eeback((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) != ptr)
		{
			((int*)P_0)[20] = (int)std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eeback((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
			((int*)P_0)[21] = (int)std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eegptr((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
		}
		std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetg((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, (sbyte*)ptr, (sbyte*)ptr, (sbyte*)P_0 + 61);
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Reset_back(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		if (std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eeback((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0) == (byte*)P_0 + 60)
		{
			int num = ((int*)P_0)[20];
			std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetg((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, (sbyte*)num, (sbyte*)num, (sbyte*)(int)((uint*)P_0)[21]);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Endwrite(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		if (((int*)P_0)[14] != 0 && ((bool*)P_0)[61])
		{
			int num = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, int, int>)(int)(*(uint*)(*(int*)P_0 + 12)))((nint)P_0, std_002Echar_traits_003Cchar_003E_002Eeof());
			int num2 = std_002Echar_traits_003Cchar_003E_002Eeof();
			if (std_002Echar_traits_003Cchar_003E_002Eeq_int_type(&num2, &num))
			{
				return false;
			}
			System.Runtime.CompilerServices.Unsafe.SkipInit(out _0024ArrayType_0024_0024_0024BY0CA_0040D _0024ArrayType_0024_0024_0024BY0CA_0040D2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out sbyte* ptr);
			int num3 = std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Eunshift((codecvt_003Cchar_002Cchar_002C_Mbstatet_003E*)(int)((uint*)P_0)[14], (_Mbstatet*)((byte*)P_0 + 64), (sbyte*)(&_0024ArrayType_0024_0024_0024BY0CA_0040D2), (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _0024ArrayType_0024_0024_0024BY0CA_0040D2, 32)), &ptr);
			if (num3 != 0)
			{
				if (num3 != 1)
				{
					return num3 == 3;
				}
			}
			else
			{
				((sbyte*)P_0)[61] = 0;
			}
			uint num4 = (uint)((ref *(_003F*)ptr) - (ref *(_003F*)(&_0024ArrayType_0024_0024_0024BY0CA_0040D2)));
			if (0 < num4 && num4 != fwrite(&_0024ArrayType_0024_0024_0024BY0CA_0040D2, 1u, num4, (_iobuf*)(int)((uint*)P_0)[19]))
			{
				return false;
			}
			return ((byte*)P_0)[61] == 0;
		}
		return true;
	}

	internal unsafe static void std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, _iobuf* _File, basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl _Which)
	{
		int num = ((_Which == (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl)1) ? 1 : 0);
		((sbyte*)P_0)[72] = (sbyte)num;
		((sbyte*)P_0)[61] = 0;
		std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
		if (_File != null)
		{
			sbyte** ptr = null;
			sbyte** ptr2 = null;
			int* ptr3 = null;
			_get_stream_buffer_pointers(_File, &ptr, &ptr2, &ptr3);
			std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, ptr, ptr2, ptr3, ptr, ptr2, ptr3);
		}
		((int*)P_0)[19] = (int)_File;
		// IL cpblk instruction
		System.Runtime.CompilerServices.Unsafe.CopyBlock((byte*)P_0 + 64, ref _003F_Stinit_0040_003F1_003F_003F_Init_0040_003F_0024basic_filebuf_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040IAEXPAU_iobuf_0040_0040W4_Initfl_004023_0040_0040Z_00404U_Mbstatet_0040_0040A, 8);
		((int*)P_0)[14] = 0;
	}

	internal unsafe static basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0)
	{
		basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* ptr = P_0;
		if (((int*)P_0)[19] == 0)
		{
			ptr = null;
		}
		else
		{
			ptr = (std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Endwrite(P_0) ? ptr : null);
			ptr = ((fclose((_iobuf*)(int)((uint*)P_0)[19]) == 0) ? ptr : null);
		}
		std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(P_0, null, (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl)2);
		return ptr;
	}

	internal unsafe static basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, char* _Filename, int _Mode, int _Prot)
	{
		if (((int*)P_0)[19] == 0)
		{
			_iobuf* ptr = std_002E_Fiopen(_Filename, _Mode, _Prot);
			if (ptr != null)
			{
				std_002Ebasic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(P_0, ptr, (basic_filebuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E._Initfl)1);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out locale locale2);
				locale* ptr2 = std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egetloc((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0, &locale2);
				try
				{
					codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* ptr3 = std_002Euse_facet_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020_003E(ptr2);
					if (std_002Ecodecvt_base_002Ealways_noconv((codecvt_base*)ptr3))
					{
						((int*)P_0)[14] = 0;
					}
					else
					{
						((int*)P_0)[14] = (int)std_002Eaddressof_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020const_0020_003E(ptr3);
						std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init((basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)P_0);
					}
				}
				catch
				{
					//try-fault
					___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<locale*, void>)(&std_002Elocale_002E_007Bdtor_007D), &locale2);
					throw;
				}
				std_002Elocale_002E_007Bdtor_007D(&locale2);
				return P_0;
			}
		}
		return null;
	}

	internal unsafe static void boost_002Eshared_ptr_003CPylon_003A_003ACBufferData_003E_002Ereset_003Cclass_0020Pylon_003A_003ACBufferData_003E(shared_ptr_003CPylon_003A_003ACBufferData_003E* P_0, CBufferData* p)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_ptr_003CPylon_003A_003ACBufferData_003E shared_ptr_003CPylon_003A_003ACBufferData_003E2);
		*(int*)(&shared_ptr_003CPylon_003A_003ACBufferData_003E2) = (int)p;
		System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACBufferData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)) = 0;
		try
		{
			boost_002Edetail_002Esp_pointer_construct_003Cclass_0020Pylon_003A_003ACBufferData_002Cclass_0020Pylon_003A_003ACBufferData_003E(&shared_ptr_003CPylon_003A_003ACBufferData_003E2, p, (shared_count*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_count*, void>)(&boost_002Edetail_002Eshared_count_002E_007Bdtor_007D), System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)));
			throw;
		}
		try
		{
			std_002Eswap_003Cclass_0020Pylon_003A_003ACBufferData_0020_002A_002Cvoid_003E((CBufferData**)(&shared_ptr_003CPylon_003A_003ACBufferData_003E2), (CBufferData**)P_0);
			sp_counted_base* ptr = (sp_counted_base*)(int)((uint*)P_0)[1];
			((int*)P_0)[1] = System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACBufferData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4));
			System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACBufferData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)) = (int)ptr;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_ptr_003CPylon_003A_003ACBufferData_003E*, void>)(&boost_002Eshared_ptr_003CPylon_003A_003ACBufferData_003E_002E_007Bdtor_007D), &shared_ptr_003CPylon_003A_003ACBufferData_003E2);
			throw;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACBufferData_003E, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)) != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)System.Runtime.CompilerServices.Unsafe.As<shared_ptr_003CPylon_003A_003ACBufferData_003E, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref shared_ptr_003CPylon_003A_003ACBufferData_003E2, 4)));
		}
	}

	internal unsafe static void boost_002Edetail_002Esp_pointer_construct_003Cclass_0020Pylon_003A_003ACGrabResultData_002Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(shared_ptr_003CPylon_003A_003ACGrabResultData_003E* ppx, MockGrabResult.CreatableGrabResultData* p, shared_count* pn)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_count shared_count2);
		shared_count* ptr = boost_002Edetail_002Eshared_count_002E_007Bctor_007D_003Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(&shared_count2, p);
		try
		{
			sp_counted_base* ptr2 = (sp_counted_base*)(int)(*(uint*)pn);
			*(int*)pn = *(int*)ptr;
			*(int*)ptr = (int)ptr2;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_count*, void>)(&boost_002Edetail_002Eshared_count_002E_007Bdtor_007D), &shared_count2);
			throw;
		}
		if (*(int*)(&shared_count2) != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)(*(uint*)(&shared_count2)));
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer3);
		sp_any_pointer sp_any_pointer2 = sp_any_pointer3;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer5);
		sp_any_pointer sp_any_pointer4 = sp_any_pointer5;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer7);
		sp_any_pointer sp_any_pointer6 = sp_any_pointer7;
	}

	internal unsafe static shared_count* boost_002Edetail_002Eshared_count_002E_007Bctor_007D_003Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(shared_count* P_0, MockGrabResult.CreatableGrabResultData* p)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		*(int*)P_0 = 0;
		try
		{
			sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* ptr = (sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E*)@new(16u);
			sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* ptr2;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
					((int*)ptr)[1] = 1;
					((int*)ptr)[2] = 1;
					try
					{
						*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024sp_counted_impl_p_0040VCreatableGrabResultData_0040MockGrabResult_0040PylonInternal_0040_0040_0040detail_0040boost_0040_00406B_0040);
						((int*)ptr)[3] = (int)p;
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<sp_counted_base*, void>)(&boost_002Edetail_002Esp_counted_base_002E_007Bdtor_007D), ptr);
						throw;
					}
					ptr2 = ptr;
				}
				else
				{
					ptr2 = null;
				}
				sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				delete(ptr, 16u);
				throw;
			}
			*(int*)P_0 = (int)ptr2;
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num2 = 0u;
			__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					boost_002Echecked_delete_003Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(p);
					_CxxThrowException(null, null);
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		return P_0;
	}

	internal unsafe static void boost_002Edetail_002Esp_pointer_construct_003Cclass_0020Pylon_003A_003ACBufferData_002Cclass_0020Pylon_003A_003ACBufferData_003E(shared_ptr_003CPylon_003A_003ACBufferData_003E* ppx, CBufferData* p, shared_count* pn)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out shared_count shared_count2);
		shared_count* ptr = boost_002Edetail_002Eshared_count_002E_007Bctor_007D_003Cclass_0020Pylon_003A_003ACBufferData_003E(&shared_count2, p);
		try
		{
			sp_counted_base* ptr2 = (sp_counted_base*)(int)(*(uint*)pn);
			*(int*)pn = *(int*)ptr;
			*(int*)ptr = (int)ptr2;
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<shared_count*, void>)(&boost_002Edetail_002Eshared_count_002E_007Bdtor_007D), &shared_count2);
			throw;
		}
		if (*(int*)(&shared_count2) != 0)
		{
			boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)(*(uint*)(&shared_count2)));
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer3);
		sp_any_pointer sp_any_pointer2 = sp_any_pointer3;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer5);
		sp_any_pointer sp_any_pointer4 = sp_any_pointer5;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out sp_any_pointer sp_any_pointer7);
		sp_any_pointer sp_any_pointer6 = sp_any_pointer7;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002Eget_untyped_deleter(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0)
	{
		return null;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002Eget_local_deleter(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0, type_info* A_0)
	{
		return null;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002Eget_deleter(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0, type_info* A_0)
	{
		return null;
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002Edispose(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0)
	{
		MockGrabResult.CreatableGrabResultData* ptr = (MockGrabResult.CreatableGrabResultData*)(int)((uint*)P_0)[3];
		if (ptr != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)ptr)))((nint)ptr, 1u);
		}
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002E__vecDelDtor(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* ptr = (sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 16u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E*, void>)(&boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 16 + 4));
			}
			return ptr;
		}
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 16u);
		}
		return P_0;
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E_002E_007Bdtor_007D(sp_counted_impl_p_003CPylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
	}

	internal unsafe static void boost_002Echecked_delete_003Cclass_0020PylonInternal_003A_003AMockGrabResult_003A_003ACreatableGrabResultData_003E(MockGrabResult.CreatableGrabResultData* x)
	{
		if (x != null)
		{
			((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)(int)(*(uint*)(int)(*(uint*)x)))((nint)x, 1u);
		}
	}

	internal unsafe static shared_count* boost_002Edetail_002Eshared_count_002E_007Bctor_007D_003Cclass_0020Pylon_003A_003ACBufferData_003E(shared_count* P_0, CBufferData* p)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		*(int*)P_0 = 0;
		try
		{
			sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* ptr = (sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E*)@new(16u);
			sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* ptr2;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
					((int*)ptr)[1] = 1;
					((int*)ptr)[2] = 1;
					try
					{
						*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7_003F_0024sp_counted_impl_p_0040VCBufferData_0040Pylon_0040_0040_0040detail_0040boost_0040_00406B_0040);
						((int*)ptr)[3] = (int)p;
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<sp_counted_base*, void>)(&boost_002Edetail_002Esp_counted_base_002E_007Bdtor_007D), ptr);
						throw;
					}
					ptr2 = ptr;
				}
				else
				{
					ptr2 = null;
				}
				sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* ptr3 = ptr2;
			}
			catch
			{
				//try-fault
				delete(ptr, 16u);
				throw;
			}
			*(int*)P_0 = (int)ptr2;
		}
		catch when (((Func<bool>)delegate
		{
			// Could not convert BlockContainer to single expression
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
		}).Invoke())
		{
			uint num2 = 0u;
			__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
			try
			{
				try
				{
					boost_002Echecked_delete_003Cclass_0020Pylon_003A_003ACBufferData_003E(p);
					_CxxThrowException(null, null);
				}
				catch when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					num2 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
					return (byte)num2 != 0;
				}).Invoke())
				{
				}
				if (num2 != 0)
				{
					throw;
				}
			}
			finally
			{
				__CxxUnregisterExceptionObject((void*)num, (int)num2);
			}
		}
		return P_0;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002Eget_untyped_deleter(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0)
	{
		return null;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002Eget_local_deleter(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0, type_info* A_0)
	{
		return null;
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002Eget_deleter(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0, type_info* A_0)
	{
		return null;
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002Edispose(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0)
	{
		boost_002Echecked_delete_003Cclass_0020Pylon_003A_003ACBufferData_003E((CBufferData*)(int)((uint*)P_0)[3]);
	}

	internal unsafe static void* boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002E__vecDelDtor(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* ptr = (sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 16u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E*, void>)(&boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 16 + 4));
			}
			return ptr;
		}
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 16u);
		}
		return P_0;
	}

	internal unsafe static void boost_002Edetail_002Esp_counted_impl_p_003CPylon_003A_003ACBufferData_003E_002E_007Bdtor_007D(sp_counted_impl_p_003CPylon_003A_003ACBufferData_003E* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7sp_counted_base_0040detail_0040boost_0040_00406B_0040);
	}

	internal unsafe static void boost_002Echecked_delete_003Cclass_0020Pylon_003A_003ACBufferData_003E(CBufferData* x)
	{
		if (x != null)
		{
			Pylon_002ECBufferData_002E_007Bdtor_007D(x);
			delete(x, 32u);
		}
	}

	internal unsafe static void* _003F_003F_E_003F_0024basic_ifstream_0040DU_003F_0024char_traits_0040D_0040std_0040_0040_0040std_0040_0040_0024_0024F_00244PPPPPPPM_0040A_0040AEPAXI_0040Z(basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, uint A_0)
	{
		basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* num = P_0;
		P_0 = (basic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E*)((byte*)num - *(int*)((byte*)num + -4));
		return std_002Ebasic_ifstream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E__vecDelDtor(P_0, A_0);
	}

	internal static NotSupportedException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_002Cclass_0020System_003A_003AString_0020_005E_003E(NotSupportedException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal unsafe static CGeneric_XMLLoaderParams* GenApi_3_1_Basler_pylon_002ECGeneric_XMLLoaderParams_002E_007Bctor_007D(CGeneric_XMLLoaderParams* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CGeneric_XMLLoaderParams_0040GenApi_3_1_Basler_pylon_0040_00406B_0040);
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002ECNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E_002E__vecDelDtor(CNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E* ptr = (CNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 84u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E*, void>)(&GenApi_3_1_Basler_pylon_002ECNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 84 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 84u);
		}
		return P_0;
	}

	internal unsafe static void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AAccessException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AAccessException_003E* P_0)
	{
		try
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)((byte*)P_0 + 76));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), P_0);
			throw;
		}
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)P_0);
	}

	internal unsafe static ObjectDisposedException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AObjectDisposedException_003E(ObjectDisposedException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static CImageAdapter* Basler_002EPylon_002ECImageAdapter_002E_007Bctor_007D(CImageAdapter* P_0, Basler.Pylon.IImage image, string exceptionSrc, string argName)
	{
		Pylon_002ECPylonImage_002E_007Bctor_007D((CPylonImage*)P_0);
		try
		{
			*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CImageAdapter_0040Pylon_0040Basler_0040_00406B_0040);
			CImageAdapter* ptr = (CImageAdapter*)((byte*)P_0 + 8);
			gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr);
			try
			{
				gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr, null);
				if (image != null && image.IsValid)
				{
					gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr, new ScopedBufferFixation(image, exceptionSrc, argName));
					IntPtr pointerToBuffer = gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_002D_003E((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr).PointerToBuffer;
					Pylon_002ECPylonImage_002EAttachUserBuffer((CPylonImage*)P_0, (void*)pointerToBuffer, gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_002D_003E((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr).BufferSize, (EPixelType)image.PixelTypeValue, (uint)image.Width, (uint)image.Height, (uint)image.PaddingX, (EImageOrientation)image.Orientation, null);
				}
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 8);
				throw;
			}
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPylonImage*, void>)(&Pylon_002ECPylonImage_002E_007Bdtor_007D), P_0);
			throw;
		}
		return P_0;
	}

	internal unsafe static void* Basler_002EPylon_002ECImageAdapter_002E__vecDelDtor(CImageAdapter* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CImageAdapter* ptr = (CImageAdapter*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 12u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CImageAdapter*, void>)(&Basler_002EPylon_002ECImageAdapter_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 12 + 4));
			}
			return ptr;
		}
		Basler_002EPylon_002ECImageAdapter_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 12u);
		}
		return P_0;
	}

	internal unsafe static void Basler_002EPylon_002ECImageAdapter_002E_007Bdtor_007D(CImageAdapter* P_0)
	{
		*(int*)P_0 = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_7CImageAdapter_0040Pylon_0040Basler_0040_00406B_0040);
		try
		{
			CImageAdapter* ptr;
			try
			{
				ptr = (CImageAdapter*)((byte*)P_0 + 8);
				((IDisposable)gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_002EP_0024AAVScopedBufferFixation_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr))?.Dispose();
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bdtor_007D), (byte*)P_0 + 8);
				throw;
			}
			gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E*)ptr);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CPylonImage*, void>)(&Pylon_002ECPylonImage_002E_007Bdtor_007D), P_0);
			throw;
		}
		Pylon_002ECPylonImage_002E_007Bdtor_007D((CPylonImage*)P_0);
	}

	[SecuritySafeCritical]
	internal unsafe static ScopedBufferFixation gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_002D_003E(gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ScopedBufferFixation)((GCHandle)intPtr).Target;
	}

	[SecuritySafeCritical]
	internal unsafe static ScopedBufferFixation gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_002EP_0024AAVScopedBufferFixation_0040Pylon_0040Basler_0040_0040(gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (ScopedBufferFixation)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* P_0, ScopedBufferFixation t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AScopedBufferFixation_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	internal unsafe static void Basler_002EPylon_002EGetNodeMap(INodeMap** pNodeMap, ref object @lock, ICamera camera)
	{
		if (null == camera)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException("camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
		}
		IParameterCollection parameters = camera.Parameters;
		if (null == parameters)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Could not get parameter collection from camera."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
		}
		GenApiParameterCollection obj = parameters as GenApiParameterCollection;
		string nodeMapName = "CameraDevice";
		GenApiNodeMapWrapper wrapper = obj.GetWrapper(nodeMapName);
		if (null == wrapper)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Could not retrieve camera node map."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
		}
		INodeMap* nodeMap = wrapper.GetNodeMap();
		*(int*)pNodeMap = (int)nodeMap;
		if (null == nodeMap)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Could not get camera node map."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
		}
		if (null == (@lock = wrapper.GetLock()))
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Could not get camera node map lock."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
		}
	}

	internal unsafe static CompressionInfo Basler_002EPylon_002EConvertCompressionInfo(CompressionInfo_t* compressionInfo)
	{
		return new CompressionInfo
		{
			HasCompressedImage = *(bool*)compressionInfo,
			CompressionStatus = ((CompressionStatus*)compressionInfo)[1],
			Lossy = ((bool*)compressionInfo)[8],
			PixelType = ((PixelType*)compressionInfo)[3],
			Width = ((int*)compressionInfo)[4],
			Height = ((int*)compressionInfo)[5],
			OffsetX = ((int*)compressionInfo)[6],
			OffsetY = ((int*)compressionInfo)[7],
			PaddingX = ((int*)compressionInfo)[8],
			PaddingY = ((int*)compressionInfo)[9],
			DecompressedImageSize = ((int*)compressionInfo)[10],
			DecompressedPayloadSize = ((int*)compressionInfo)[11]
		};
	}

	internal unsafe static uint Basler_002EPylon_002ECastPayloadSize(long payloadSize)
	{
		long num = std_002Enumeric_limits_003Cunsigned_0020int_003E_002Emax();
		if (num < 0)
		{
			num = long.MaxValue;
		}
		if (payloadSize >= std_002Enumeric_limits_003Cunsigned_0020int_003E_002Emin() && payloadSize <= num)
		{
			return (uint)payloadSize;
		}
		throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Invalid payload size found in grab result.", "grabResult"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1CE_0040PICAPMIG_0040_003F_0024AAI_003F_0024AAm_003F_0024AAa_003F_0024AAg_003F_0024AAe_003F_0024AAD_003F_0024AAe_003F_0024AAc_003F_0024AAo_003F_0024AAm_003F_0024AAp_003F_0024AAr_003F_0024AAe_003F_0024AAs_003F_0024AAs_0040));
	}

	internal unsafe static OutOfMemoryException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AOutOfMemoryException_003E(OutOfMemoryException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal static NullReferenceException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_002Cclass_0020System_003A_003AString_0020_005E_003E(NullReferenceException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal unsafe static void std_002Esort_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		std_002E_Adl_verify_range_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(&_First, &_Last);
		TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* ptr = std_002E_Get_unwrapped_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002C0_003E(&_First);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator first);
		// IL cpblk instruction
		System.Runtime.CompilerServices.Unsafe.CopyBlock(ref first, ptr, 4);
		TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* ptr2 = std_002E_Get_unwrapped_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002C0_003E(&_Last);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator last);
		// IL cpblk instruction
		System.Runtime.CompilerServices.Unsafe.CopyBlock(ref last, ptr2, 4);
		less_003Cvoid_003E pred = std_002E_Pass_fn_003Cstruct_0020std_003A_003Aless_003Cvoid_003E_002C0_003E(_Pred);
		std_002E_Sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(first, last, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&last, &first), pred);
	}

	internal unsafe static void std_002E_Sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, int _Ideal, less_003Cvoid_003E _Pred)
	{
		int num = Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First);
		if (32 < num)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2);
			do
			{
				if (0 < _Ideal)
				{
					std_002E_Partition_by_median_guess_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(&pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2, _First, _Last, _Pred);
					_Ideal = (_Ideal >> 2) + (_Ideal >> 1);
					if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D((TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*)(&pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2), &_First) < Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, (TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2, 4))))
					{
						std_002E_Sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, *(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator*)(&pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2), _Ideal, _Pred);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref _First, ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2, 4), 4);
					}
					else
					{
						std_002E_Sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(System.Runtime.CompilerServices.Unsafe.As<pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2, 4)), _Last, _Ideal, _Pred);
						// IL cpblk instruction
						System.Runtime.CompilerServices.Unsafe.CopyBlock(ref _Last, ref pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E2, 4);
					}
					num = Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First);
					continue;
				}
				if (32 >= num)
				{
					break;
				}
				std_002E_Make_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, _Last, _Pred);
				std_002E_Sort_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, _Last, _Pred);
				return;
			}
			while (32 < num);
		}
		if (2 <= num)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
			std_002E_Insertion_sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(&iterator, _First, _Last, _Pred);
		}
	}

	internal unsafe static pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E* std_002E_Partition_by_median_guess_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
		Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First) >> 1);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2);
		std_002E_Guess_median_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, iterator, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &iterator2, 1), _Pred);
		TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3 = iterator;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4);
		Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&iterator3, &iterator4, 1);
		if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator3)))
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator6);
			while (!std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator3, &iterator5, 1)), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3)) && !std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator3, &iterator6, 1))))
			{
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator3);
				if (!Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator3)))
				{
					break;
				}
			}
		}
		if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator4), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
		{
			while (!std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator4), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3)) && !std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator4)))
			{
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator4);
				if (!Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator4), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
				{
					break;
				}
			}
		}
		TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator7 = iterator4;
		TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator8 = iterator3;
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator9);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator10);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator11);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator12);
		while (true)
		{
			if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
			{
				do
				{
					if (!std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator7)))
					{
						if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator7), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3)))
						{
							break;
						}
						if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator4), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7)))
						{
							std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator4, iterator7);
							Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator4);
						}
						else
						{
							Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator4);
						}
					}
					Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator7);
				}
				while (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)));
			}
			if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator8)))
			{
				do
				{
					if (!std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator8, &iterator9, 1)), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3)))
					{
						if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator3), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator8, &iterator10, 1))))
						{
							break;
						}
						if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator3), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator8, &iterator11, 1)))
						{
							std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator3, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&iterator8, &iterator12, 1));
						}
					}
					Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator8);
				}
				while (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator8)));
			}
			if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003D_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator8), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First)) && Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003D_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
			{
				break;
			}
			if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003D_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator8), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First)))
			{
				if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator4), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7)))
				{
					std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator3, iterator4);
				}
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator4);
				std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator3, iterator7);
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator3);
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator7);
			}
			else if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003D_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&iterator7), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
			{
				if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator8), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator3)))
				{
					std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator8, iterator3);
				}
				std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator3, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator4));
			}
			else
			{
				std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(iterator7, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator8));
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator7);
			}
		}
		std_002Epair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E_002E_007Bctor_007D_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_0020_0026_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_0020_0026_002C0_003E(P_0, &iterator3, &iterator4);
		return P_0;
	}

	internal unsafe static void std_002E_Make_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		int num = Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First);
		int num2 = num >> 1;
		if (0 >= num2)
		{
			return;
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out CInterfaceInfo cInterfaceInfo);
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
		do
		{
			num2--;
			Pylon_002ECInterfaceInfo_002E_007Bctor_007D(&cInterfaceInfo, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator, num2))));
			try
			{
				std_002E_Pop_heap_hole_by_index_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, num2, num, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&cInterfaceInfo), _Pred);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CInterfaceInfo*, void>)(&Pylon_002ECInterfaceInfo_002E_007Bdtor_007D), &cInterfaceInfo);
				throw;
			}
			Pylon_002ECInterfaceInfo_002E_007Bdtor_007D(&cInterfaceInfo);
		}
		while (num2 > 0);
	}

	internal unsafe static void std_002E_Sort_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		if (2 <= Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First))
		{
			do
			{
				std_002E_Pop_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, _Last, _Pred);
				Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&_Last);
			}
			while (2 <= Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First));
		}
	}

	internal unsafe static TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* std_002E_Insertion_sort_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_First), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
		{
			TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator = _First;
			if (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)))
			{
				System.Runtime.CompilerServices.Unsafe.SkipInit(out CInterfaceInfo cInterfaceInfo);
				System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3);
				do
				{
					TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2 = iterator;
					Pylon_002ECInterfaceInfo_002E_007Bctor_007D(&cInterfaceInfo, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator)));
					try
					{
						if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, &cInterfaceInfo, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_First)))
						{
							std_002E_Move_backward_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(&iterator3, _First, iterator, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator2));
							Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_First), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&cInterfaceInfo));
						}
						else
						{
							TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4 = iterator2;
							if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, &cInterfaceInfo, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator4))))
							{
								do
								{
									Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator2), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator4)));
									iterator2 = iterator4;
								}
								while (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, &cInterfaceInfo, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&iterator4))));
							}
							Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&iterator2), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&cInterfaceInfo));
						}
					}
					catch
					{
						//try-fault
						___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CInterfaceInfo*, void>)(&Pylon_002ECInterfaceInfo_002E_007Bdtor_007D), &cInterfaceInfo);
						throw;
					}
					Pylon_002ECInterfaceInfo_002E_007Bdtor_007D(&cInterfaceInfo);
				}
				while (Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D((TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(&iterator), (TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator*)(&_Last)));
			}
		}
		// IL cpblk instruction
		System.Runtime.CompilerServices.Unsafe.CopyBlock(P_0, ref _Last, 4);
		return P_0;
	}

	internal unsafe static void std_002E_Guess_median_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Mid, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		int num = Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First);
		if (40 < num)
		{
			int num2 = num + 1 >> 3;
			int num3 = num2 << 1;
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2);
			std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator, num2), *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator2, num3), _Pred);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4);
			std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(*Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Mid, &iterator3, num2), _Mid, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_Mid, &iterator4, num2), _Pred);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator6);
			std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(*Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &iterator5, num3), *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &iterator6, num2), _Last, _Pred);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator7);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator8);
			std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(*Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator7, num2), _Mid, *Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &iterator8, num2), _Pred);
		}
		else
		{
			std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, _Mid, _Last, _Pred);
		}
	}

	internal unsafe static void std_002E_Pop_heap_hole_by_index_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, int _Hole, int _Bottom, CInterfaceInfo* _Val, less_003Cvoid_003E _Pred)
	{
		int top = _Hole;
		int num = _Hole;
		int num2 = _Bottom - 1 >> 1;
		if (_Hole < num2)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4);
			do
			{
				num = num * 2 + 2;
				num = (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator, num)), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator2, num - 1))) ? (num - 1) : num);
				Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator3, _Hole)), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator4, num))));
				_Hole = num;
			}
			while (num < num2);
		}
		if (num == num2 && _Bottom % 2 == 0)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator5);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator6);
			Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator5, _Hole)), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator6, _Bottom - 1))));
			_Hole = _Bottom - 1;
		}
		std_002E_Push_heap_by_index_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, _Hole, top, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(_Val), _Pred);
	}

	internal unsafe static void std_002E_Pop_heap_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		if (2 <= Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First))
		{
			Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(&_Last);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out CInterfaceInfo cInterfaceInfo);
			Pylon_002ECInterfaceInfo_002E_007Bctor_007D(&cInterfaceInfo, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Last)));
			try
			{
				TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator first = _First;
				TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator = _Last;
				std_002E_Pop_heap_hole_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(first, iterator, iterator, std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&cInterfaceInfo), _Pred);
			}
			catch
			{
				//try-fault
				___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<CInterfaceInfo*, void>)(&Pylon_002ECInterfaceInfo_002E_007Bdtor_007D), &cInterfaceInfo);
				throw;
			}
			Pylon_002ECInterfaceInfo_002E_007Bdtor_007D(&cInterfaceInfo);
		}
	}

	internal unsafe static void std_002E_Med3_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Mid, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, less_003Cvoid_003E _Pred)
	{
		if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Mid), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_First)))
		{
			std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(_Mid, _First);
		}
		if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Last), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Mid)))
		{
			std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(_Last, _Mid);
			if (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Mid), Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_First)))
			{
				std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(_Mid, _First);
			}
		}
	}

	internal unsafe static void std_002E_Push_heap_by_index_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, int _Hole, int _Top, CInterfaceInfo* _Val, less_003Cvoid_003E _Pred)
	{
		int num = _Hole - 1 >> 1;
		if (_Top < _Hole)
		{
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator2);
			System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator3);
			while (std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(&_Pred, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator, num)), _Val))
			{
				Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator2, _Hole)), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator3, num))));
				_Hole = num;
				num = num - 1 >> 1;
				if (_Top >= _Hole)
				{
					break;
				}
			}
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator iterator4);
		Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(&_First, &iterator4, _Hole)), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(_Val));
	}

	internal unsafe static void std_002E_Pop_heap_hole_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _First, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Last, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator _Dest, CInterfaceInfo* _Val, less_003Cvoid_003E _Pred)
	{
		Pylon_002ECInterfaceInfo_002E_003D(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_Dest), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(&_First)));
		std_002E_Pop_heap_hole_by_index_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ACInterfaceInfo_002Cstruct_0020std_003A_003Aless_003Cvoid_003E_0020_003E(_First, 0, Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(&_Last, &_First), std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(_Val), _Pred);
	}

	internal unsafe static void _003FA0x6565c3d8_002EAutoTlReleaser_002E_007Bdtor_007D(_003FA0x6565c3d8.AutoTlReleaser* P_0)
	{
		uint num = *(uint*)P_0;
		if (num != 0)
		{
			Pylon_002ECTlFactory_002EReleaseTl(Pylon_002ECTlFactory_002EGetInstance(), (ITransportLayer*)(int)num);
		}
	}

	internal unsafe static ulong Basler_002EPylon_002E_003FA0x6565c3d8_002EGetCameraInfoValue(ICameraInfo cameraInfo, string key, string argumentName)
	{
		if (cameraInfo == null)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentNullException_003E(new ArgumentNullException(argumentName), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040NPADJIBL_0040_003F_0024AAI_003F_0024AAp_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAo_003F_0024AAr_0040));
		}
		if (!(cameraInfo is CCameraInfoImpl cCameraInfoImpl))
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Type of camera info object not supported. Camera info objects must be created by the CameraFinder.", argumentName), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040NPADJIBL_0040_003F_0024AAI_003F_0024AAp_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAo_003F_0024AAr_0040));
		}
		if (cCameraInfoImpl.GetDeviceInfo() == null)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Camera info object is invalid. Camera info objects must be created by the CameraFinder.", argumentName), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040NPADJIBL_0040_003F_0024AAI_003F_0024AAp_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAo_003F_0024AAr_0040));
		}
		return Convert.ToUInt64(cCameraInfoImpl.GetValueOrDefault(key, "0"));
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E__vecDelDtor(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr = (CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 8u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 8 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 8u);
		}
		return P_0;
	}

	internal unsafe static void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ALogicalErrorException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ALogicalErrorException_003E* P_0)
	{
		try
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)((byte*)P_0 + 76));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), P_0);
			throw;
		}
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D((gcstring*)P_0);
	}

	internal static void Basler_002EPylon_002ESetValuePercentOfRangeImpl(IFloatParameter parameter, double percentOfRange)
	{
		if (percentOfRange <= 0.0)
		{
			parameter.SetValue(parameter.GetMinimum());
			return;
		}
		if (percentOfRange >= 100.0)
		{
			parameter.SetValue(parameter.GetMaximum());
			return;
		}
		double minimum = parameter.GetMinimum();
		double maximum = parameter.GetMaximum();
		double num = percentOfRange / 100.0;
		double value = gtl_002ECorrectDoubleValue(minimum, maximum, minimum - num * minimum + num * maximum);
		parameter.SetValue(value);
	}

	internal static void Basler_002EPylon_002ESetValuePercentOfRangeImpl(IIntegerParameter parameter, double percentOfRange)
	{
		if (percentOfRange <= 0.0)
		{
			parameter.SetValue(parameter.GetMinimum());
			return;
		}
		if (percentOfRange >= 100.0)
		{
			parameter.SetValue(parameter.GetMaximum());
			return;
		}
		long minimum = parameter.GetMinimum();
		long maximum = parameter.GetMaximum();
		long increment = parameter.GetIncrement();
		double num = percentOfRange / 100.0;
		double num2 = minimum;
		long num3 = (long)Math.Round(num2 - num2 * num + (double)maximum * num);
		long value = gtl_002ECorrectIntValue(minimum, maximum, increment, num3, (EValueCorrection)3);
		parameter.SetValue(value);
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E__vecDelDtor(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr = (CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 8u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 8 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 8u);
		}
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E__vecDelDtor(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr = (CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 8u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 8 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 8u);
		}
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E__vecDelDtor(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* ptr = (CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 8u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E*, void>)(&GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 8 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 8u);
		}
		return P_0;
	}

	internal unsafe static void* GenApi_3_1_Basler_pylon_002EFunction_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E_002E__vecDelDtor(Function_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E* P_0, uint A_0)
	{
		if ((A_0 & 2) != 0)
		{
			Function_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E* ptr = (Function_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E*)((byte*)P_0 - 4);
			__ehvec_dtor(P_0, 16u, *(uint*)ptr, (delegate*<void*, void>)(delegate*<Function_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E*, void>)(&GenApi_3_1_Basler_pylon_002EFunction_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E_002E_007Bdtor_007D));
			if ((A_0 & 1) != 0)
			{
				delete_005B_005D(ptr, (uint)(*(int*)ptr * 16 + 4));
			}
			return ptr;
		}
		GenApi_3_1_Basler_pylon_002ECNodeCallback_002E_007Bdtor_007D((CNodeCallback*)P_0);
		if ((A_0 & 1) != 0)
		{
			delete(P_0, 16u);
		}
		return P_0;
	}

	internal unsafe static void GenApi_3_1_Basler_pylon_002EFunction_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E_002E_007Bdtor_007D(Function_NodeCallback_003Cvoid_0020_0028__stdcall_002A_0029_0028GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E* P_0)
	{
		GenApi_3_1_Basler_pylon_002ECNodeCallback_002E_007Bdtor_007D((CNodeCallback*)P_0);
	}

	internal unsafe static FileNotFoundException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AIO_003A_003AFileNotFoundException_003E(FileNotFoundException ex, char* src)
	{
		ex.Source = new string(src);
		return ex;
	}

	internal unsafe static void _003FA0x7e5ac1d5_002E_003F_003F__E_003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A_0040_0040YMXXZ()
	{
		gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_007Bctor_007D((gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A, 12)));
		try
		{
			InitializeSRWLock((_RTL_SRWLOCK*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A, 8)));
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E*, void>)(&gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_007Bdtor_007D), System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A, 12)));
			throw;
		}
		_atexit_m((delegate*<void>)(&_003FA0x7e5ac1d5_002E_003F_003F__F_003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7e5ac1d5_002E_003F_003F__F_003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A_0040_0040YMXXZ()
	{
		gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A, 12)));
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool CPylonLibraryNative_002EInit(CPylonLibraryNative* P_0)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		bool result = false;
		AcquireSRWLockExclusive((_RTL_SRWLOCK*)((byte*)P_0 + 8));
		if (*(int*)P_0 == 0 && ((byte*)P_0)[4] == 0)
		{
			try
			{
				Pylon_002EPylonInitialize();
				((sbyte*)P_0)[4] = 1;
				gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_003D((gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E*)((byte*)P_0 + 12), new PylonFinalizer(P_0));
				result = true;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num2 = 0u;
				__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						ReleaseSRWLockExclusive((_RTL_SRWLOCK*)((byte*)P_0 + 8));
						return result;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num2 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num2 != 0;
					}).Invoke())
					{
					}
					if (num2 != 0)
					{
						throw;
					}
				}
				finally
				{
					__CxxUnregisterExceptionObject((void*)num, (int)num2);
				}
			}
		}
		(*(int*)P_0)++;
		ReleaseSRWLockExclusive((_RTL_SRWLOCK*)((byte*)P_0 + 8));
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool CPylonLibraryNative_002ERelease(CPylonLibraryNative* P_0)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		bool result = false;
		CPylonLibraryNative* ptr = (CPylonLibraryNative*)((byte*)P_0 + 8);
		AcquireSRWLockExclusive((_RTL_SRWLOCK*)ptr);
		int num2 = *(int*)P_0;
		if (num2 <= 0)
		{
			ReleaseSRWLockExclusive((_RTL_SRWLOCK*)ptr);
			return false;
		}
		if ((*(int*)P_0 = num2 - 1) == 0 && ((bool*)P_0)[4] && ((bool*)P_0)[5])
		{
			try
			{
				Pylon_002EPylonTerminate(true);
				((sbyte*)P_0)[4] = 0;
				result = true;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num3 = 0u;
				__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						(*(int*)P_0)++;
						goto end_IL_0072;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num3 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num3 != 0;
					}).Invoke())
					{
					}
					if (num3 != 0)
					{
						throw;
					}
					end_IL_0072:;
				}
				finally
				{
					__CxxUnregisterExceptionObject((void*)num, (int)num3);
				}
			}
		}
		ReleaseSRWLockExclusive((_RTL_SRWLOCK*)((byte*)P_0 + 8));
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool CPylonLibraryNative_002EShutdown(CPylonLibraryNative* P_0)
	{
		int num = (int)stackalloc byte[__CxxQueryExceptionSize()];
		bool result = false;
		CPylonLibraryNative* ptr = (CPylonLibraryNative*)((byte*)P_0 + 8);
		AcquireSRWLockExclusive((_RTL_SRWLOCK*)ptr);
		int num2 = *(int*)P_0;
		if (num2 > 0)
		{
			ReleaseSRWLockExclusive((_RTL_SRWLOCK*)ptr);
			return false;
		}
		if (num2 == 0 && ((bool*)P_0)[4])
		{
			try
			{
				Pylon_002EPylonTerminate(true);
				((sbyte*)P_0)[4] = 0;
				result = true;
			}
			catch when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				return (byte)__CxxExceptionFilter((void*)Marshal.GetExceptionPointers(), null, 0, null) != 0;
			}).Invoke())
			{
				uint num3 = 0u;
				__CxxRegisterExceptionObject((void*)Marshal.GetExceptionPointers(), (void*)num);
				try
				{
					try
					{
						(*(int*)P_0)++;
						goto end_IL_0063;
					}
					catch when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						num3 = (uint)__CxxDetectRethrow((void*)Marshal.GetExceptionPointers());
						return (byte)num3 != 0;
					}).Invoke())
					{
					}
					if (num3 != 0)
					{
						throw;
					}
					end_IL_0063:;
				}
				finally
				{
					__CxxUnregisterExceptionObject((void*)num, (int)num3);
				}
			}
		}
		ReleaseSRWLockExclusive((_RTL_SRWLOCK*)((byte*)P_0 + 8));
		return result;
	}

	internal unsafe static int CPylonLibraryNative_002EGetRefCount(CPylonLibraryNative* P_0)
	{
		CPylonLibraryNative* ptr = (CPylonLibraryNative*)((byte*)P_0 + 8);
		AcquireSRWLockShared((_RTL_SRWLOCK*)ptr);
		int result = *(int*)P_0;
		ReleaseSRWLockShared((_RTL_SRWLOCK*)ptr);
		return result;
	}

	internal unsafe static CPylonLibraryNative* CPylonLibraryNative_002EgetInstance()
	{
		return (CPylonLibraryNative*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003Fm_instance_0040CPylonLibraryNative_0040_00400V1_0040A);
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_003D(gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E* P_0, PylonFinalizer t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E* gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E_002E_007Bctor_007D(gcroot_003CBasler_003A_003APylon_003A_003AInternal_003A_003APylonFinalizer_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_VersionUndefined_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_VersionUndefined), 0u, 0u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_VersionUndefined_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_VersionUndefined_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_VersionUndefined));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_1_2_1_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_2_1), 1u, 2u, 1u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_2_1_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_2_1_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_2_1));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_1_3_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_3_0), 1u, 3u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_3_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_3_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_3_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_1_4_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_4_0), 1u, 4u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_4_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_4_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_4_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_1_5_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_0), 1u, 5u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_5_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_5_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_1_5_1_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_1), 1u, 5u, 1u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_5_1_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_1_5_1_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_1_5_1));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_0_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_0_0), 2u, 0u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_0_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_0_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_0_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_1_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_1_0), 2u, 1u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_1_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_1_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_1_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_2_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_2_0), 2u, 2u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_2_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_2_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_2_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_3_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_3_0), 2u, 3u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_3_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_3_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_3_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_4_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_4_0), 2u, 4u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_4_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_4_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_4_0));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__E_003FA0x7d4773d9_0040Sfnc_2_5_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bctor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_5_0), 2u, 5u, 0u);
		_atexit_m((delegate*<void>)(&_003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_5_0_0040Pylon_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x7d4773d9_002E_003F_003F__F_003FA0x7d4773d9_0040Sfnc_2_5_0_0040Pylon_0040_0040YMXXZ()
	{
		Pylon_002EVersionInfo_002E_007Bdtor_007D((VersionInfo*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref Pylon_002E_003FA0x7d4773d9_002ESfnc_2_5_0));
	}

	internal static OutOfMemoryException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AOutOfMemoryException_002Cclass_0020System_003A_003AString_0020_005E_003E(OutOfMemoryException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal static ArgumentOutOfRangeException Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_002Cclass_0020System_003A_003AString_0020_005E_003E(ArgumentOutOfRangeException ex, string src)
	{
		ex.Source = src;
		return ex;
	}

	internal unsafe static void _003FA0xcad5cde4_002EVerifyAndConvertInputParameter(string filename, gcstring* filename_nat, double playbackFramesPerSecond, PixelType pixelType, EPixelType* pixelTypeForVideo_nat, int width, uint* width_clipped, int height, uint* height_clipped)
	{
		uint num = 0u;
		if (string.IsNullOrEmpty(filename))
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_003E(new ArgumentException("Parameter cannot be empty.", "filename"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		if (!Path.HasExtension(filename) || string.Compare(Path.GetExtension(filename), ".avi", ignoreCase: true) != 0)
		{
			filename += ".avi";
		}
		System.Runtime.CompilerServices.Unsafe.SkipInit(out gcstring gcstring2);
		gcstring* ptr = msclr_002Einterop_002Emarshal_as_003Cclass_0020GenICam_3_1_Basler_pylon_003A_003Agcstring_002Cclass_0020System_003A_003AString_0020_005E_003E(&gcstring2, &filename);
		try
		{
			GenICam_3_1_Basler_pylon_002Egcstring_002E_003D(filename_nat, ptr);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<gcstring*, void>)(&GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D), &gcstring2);
			throw;
		}
		GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(&gcstring2);
		if (playbackFramesPerSecond <= 0.0)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "playbackFramesPerSeond"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		*pixelTypeForVideo_nat = (EPixelType)(-1);
		if (Pylon_002EIsMonoImage((EPixelType)pixelType))
		{
			*pixelTypeForVideo_nat = (EPixelType)17301505;
		}
		else if (Pylon_002EHasAlpha((EPixelType)pixelType) && Pylon_002EIsColorImage((EPixelType)pixelType))
		{
			*pixelTypeForVideo_nat = (EPixelType)35651607;
		}
		else
		{
			if (!Pylon_002EIsColorImage((EPixelType)pixelType))
			{
				throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed", "camera"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
			}
			*pixelTypeForVideo_nat = (EPixelType)35127317;
		}
		if (width <= 0)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "width"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		if (height <= 0)
		{
			throw Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentOutOfRangeException_003E(new ArgumentOutOfRangeException("Invalid value passed.", "height"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003F_003F_C_0040_1BO_0040KBFBPHIG_0040_003F_0024AAA_003F_0024AAv_003F_0024AAi_003F_0024AAV_003F_0024AAi_003F_0024AAd_003F_0024AAe_003F_0024AAo_003F_0024AAW_003F_0024AAr_003F_0024AAi_003F_0024AAt_003F_0024AAe_003F_0024AAr_0040));
		}
		*width_clipped = (uint)width;
		*height_clipped = (uint)height;
	}

	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[HandleProcessCorruptedStateExceptions]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindDtor(delegate*<void*, void> pDtor, void* pThis)
	{
		try
		{
			pDtor(pThis);
		}
		catch when (__FrameUnwindFilter((_EXCEPTION_POINTERS*)Marshal.GetExceptionPointers()) != 0)
		{
		}
	}

	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindDelDtor(delegate*<void*, void> pDtor, void* pThis)
	{
		try
		{
			pDtor(pThis);
		}
		catch when (__FrameUnwindFilter((_EXCEPTION_POINTERS*)Marshal.GetExceptionPointers()) != 0)
		{
		}
	}

	internal static void _003CCrtImplementationDetails_003E_002EThrowNestedModuleLoadException(Exception innerException, Exception nestedException)
	{
		throw new ModuleLoadExceptionHandlerException("A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n", innerException, nestedException);
	}

	internal static void _003CCrtImplementationDetails_003E_002EThrowModuleLoadException(string errorMessage)
	{
		throw new ModuleLoadException(errorMessage);
	}

	internal static void _003CCrtImplementationDetails_003E_002EThrowModuleLoadException(string errorMessage, Exception innerException)
	{
		throw new ModuleLoadException(errorMessage, innerException);
	}

	internal static void _003CCrtImplementationDetails_003E_002ERegisterModuleUninitializer(EventHandler handler)
	{
		ModuleUninitializer._ModuleUninitializer.AddHandler(handler);
	}

	[SecuritySafeCritical]
	internal unsafe static Guid _003CCrtImplementationDetails_003E_002EFromGUID(_GUID* guid)
	{
		return new Guid(*(uint*)guid, ((ushort*)guid)[2], ((ushort*)guid)[3], ((byte*)guid)[8], ((byte*)guid)[9], ((byte*)guid)[10], ((byte*)guid)[11], ((byte*)guid)[12], ((byte*)guid)[13], ((byte*)guid)[14], ((byte*)guid)[15]);
	}

	[SecurityCritical]
	internal unsafe static int __get_default_appdomain(IUnknown** ppUnk)
	{
		ICorRuntimeHost* ptr = null;
		int num;
		try
		{
			Guid riid = _003CCrtImplementationDetails_003E_002EFromGUID((_GUID*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e));
			ptr = (ICorRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(_003CCrtImplementationDetails_003E_002EFromGUID((_GUID*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e)), riid).ToPointer();
		}
		catch (Exception e)
		{
			num = Marshal.GetHRForException(e);
			goto IL_0031;
		}
		goto IL_0035;
		IL_0031:
		if (num >= 0)
		{
			goto IL_0035;
		}
		goto IL_0051;
		IL_0035:
		int num2 = *(int*)(*(int*)ptr + 52);
		num = ((delegate* unmanaged[Stdcall, Stdcall]<IntPtr, IUnknown**, int>)num2)((nint)ptr, ppUnk);
		ICorRuntimeHost* intPtr = ptr;
		((delegate* unmanaged[Stdcall, Stdcall]<IntPtr, uint>)(int)(*(uint*)(*(int*)intPtr + 8)))((nint)intPtr);
		goto IL_0051;
		IL_0051:
		return num;
	}

	internal unsafe static void __release_appdomain(IUnknown* ppUnk)
	{
		((delegate* unmanaged[Stdcall, Stdcall]<IntPtr, uint>)(int)(*(uint*)(*(int*)ppUnk + 8)))((nint)ppUnk);
	}

	[SecurityCritical]
	internal unsafe static AppDomain _003CCrtImplementationDetails_003E_002EGetDefaultDomain()
	{
		IUnknown* ptr = null;
		int num = __get_default_appdomain(&ptr);
		if (num >= 0)
		{
			try
			{
				IntPtr pUnk = new IntPtr(ptr);
				return (AppDomain)Marshal.GetObjectForIUnknown(pUnk);
			}
			finally
			{
				__release_appdomain(ptr);
			}
		}
		Marshal.ThrowExceptionForHR(num);
		return null;
	}

	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002EDoCallBackInDefaultDomain(delegate* unmanaged[Stdcall, Stdcall]<void*, int> function, void* cookie)
	{
		Guid riid = _003CCrtImplementationDetails_003E_002EFromGUID((_GUID*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02));
		ICLRRuntimeHost* ptr = (ICLRRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(_003CCrtImplementationDetails_003E_002EFromGUID((_GUID*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02)), riid).ToPointer();
		try
		{
			AppDomain appDomain = _003CCrtImplementationDetails_003E_002EGetDefaultDomain();
			int num = *(int*)(*(int*)ptr + 32);
			int num2 = ((delegate* unmanaged[Stdcall, Stdcall]<IntPtr, uint, delegate* unmanaged[Stdcall, Stdcall]<void*, int>, void*, int>)num)((nint)ptr, (uint)appDomain.Id, function, cookie);
			if (num2 < 0)
			{
				Marshal.ThrowExceptionForHR(num2);
			}
		}
		finally
		{
			((delegate* unmanaged[Stdcall, Stdcall]<IntPtr, uint>)(int)(*(uint*)(*(int*)ptr + 8)))((nint)ptr);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __scrt_is_safe_for_managed_code()
	{
		return __scrt_native_dllmain_reason > 1;
	}

	[SecuritySafeCritical]
	internal unsafe static int _003CCrtImplementationDetails_003E_002EDefaultDomain_002EDoNothing(void* cookie)
	{
		GC.KeepAlive(int.MaxValue);
		return 0;
	}

	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool _003CCrtImplementationDetails_003E_002EDefaultDomain_002EHasPerProcess()
	{
		if (_003FhasPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A == (TriBool)2)
		{
			void** ptr = (void**)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_mp_a);
			if (System.Runtime.CompilerServices.Unsafe.IsAddressLessThan(ref __xc_mp_a, ref __xc_mp_z))
			{
				do
				{
					if (*(int*)ptr == 0)
					{
						ptr = (void**)((byte*)ptr + 4);
						continue;
					}
					_003FhasPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A = (TriBool)(-1);
					return true;
				}
				while (ptr < System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_mp_z));
			}
			_003FhasPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A = (TriBool)0;
			return false;
		}
		return _003FhasPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A == (TriBool)(-1);
	}

	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool _003CCrtImplementationDetails_003E_002EDefaultDomain_002EHasNative()
	{
		if (_003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A == (TriBool)2)
		{
			void** ptr = (void**)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_a);
			if (System.Runtime.CompilerServices.Unsafe.IsAddressLessThan(ref __xi_a, ref __xi_z))
			{
				do
				{
					if (*(int*)ptr == 0)
					{
						ptr = (void**)((byte*)ptr + 4);
						continue;
					}
					_003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A = (TriBool)(-1);
					return true;
				}
				while (ptr < System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_z));
			}
			void** ptr2 = (void**)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_a);
			if (System.Runtime.CompilerServices.Unsafe.IsAddressLessThan(ref __xc_a, ref __xc_z))
			{
				do
				{
					if (*(int*)ptr2 == 0)
					{
						ptr2 = (void**)((byte*)ptr2 + 4);
						continue;
					}
					_003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A = (TriBool)(-1);
					return true;
				}
				while (ptr2 < System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_z));
			}
			_003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A = (TriBool)0;
			return false;
		}
		return _003FhasNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00400W4TriBool_00402_0040A == (TriBool)(-1);
	}

	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003CCrtImplementationDetails_003E_002EDefaultDomain_002ENeedsInitialization()
	{
		int num = (((_003CCrtImplementationDetails_003E_002EDefaultDomain_002EHasPerProcess() && !_003FInitializedPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA) || (_003CCrtImplementationDetails_003E_002EDefaultDomain_002EHasNative() && !_003FInitializedNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA && __scrt_current_native_startup_state == (__scrt_native_startup_state)0)) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003CCrtImplementationDetails_003E_002EDefaultDomain_002ENeedsUninitialization()
	{
		return _003FEntered_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA;
	}

	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002EDefaultDomain_002EInitialize()
	{
		_003CCrtImplementationDetails_003E_002EDoCallBackInDefaultDomain((delegate* unmanaged[Stdcall, Stdcall]<void*, int>)__unep_0040_003FDoNothing_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024FCGJPAX_0040Z, null);
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA_0040_0040YMXXZ()
	{
		_003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA = 0;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FUninitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA_0040_0040YMXXZ()
	{
		_003FUninitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA = 0;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA_0040_0040YMXXZ()
	{
		_003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA = false;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FInitializedVtables_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A_0040_0040YMXXZ()
	{
		_003FInitializedVtables_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)0;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FInitializedNative_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A_0040_0040YMXXZ()
	{
		_003FInitializedNative_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)0;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FInitializedPerProcess_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A_0040_0040YMXXZ()
	{
		_003FInitializedPerProcess_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)0;
	}

	internal static void _003FA0x1cf8fe9a_002E_003F_003F__E_003FInitializedPerAppDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A_0040_0040YMXXZ()
	{
		_003FInitializedPerAppDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)0;
	}

	[SecuritySafeCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeVtables(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load during vtable initialization.\n");
		_003FInitializedVtables_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)1;
		_initterm_m((delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_vt_a), (delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_vt_z));
		_003FInitializedVtables_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)2;
	}

	[SecuritySafeCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeDefaultAppDomain(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load while attempting to initialize the default appdomain.\n");
		_003CCrtImplementationDetails_003E_002EDefaultDomain_002EInitialize();
	}

	[SecuritySafeCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeNative(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load during native initialization.\n");
		__security_init_cookie();
		_003FInitializedNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = true;
		if (!__scrt_is_safe_for_managed_code())
		{
			abort();
		}
		if (__scrt_current_native_startup_state == (__scrt_native_startup_state)1)
		{
			abort();
		}
		if (__scrt_current_native_startup_state == (__scrt_native_startup_state)0)
		{
			_003FInitializedNative_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)1;
			__scrt_current_native_startup_state = (__scrt_native_startup_state)1;
			if (_initterm_e((delegate* unmanaged[Cdecl, Cdecl]<int>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_a), (delegate* unmanaged[Cdecl, Cdecl]<int>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xi_z)) != 0)
			{
				_003CCrtImplementationDetails_003E_002EThrowModuleLoadException(gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_002EP_0024AAVString_0040System_0040_0040((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0));
			}
			_initterm((delegate* unmanaged[Cdecl, Cdecl]<void>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_a), (delegate* unmanaged[Cdecl, Cdecl]<void>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_z));
			__scrt_current_native_startup_state = (__scrt_native_startup_state)2;
			_003FInitializedNativeFromCCTOR_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = true;
			_003FInitializedNative_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)2;
		}
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializePerProcess(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load during process initialization.\n");
		_003FInitializedPerProcess_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)1;
		_initatexit_m();
		_initterm_m((delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_mp_a), (delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_mp_z));
		_003FInitializedPerProcess_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)2;
		_003FInitializedPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = true;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializePerAppDomain(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load during appdomain initialization.\n");
		_003FInitializedPerAppDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)1;
		_initatexit_app_domain();
		_initterm_m((delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_ma_a), (delegate*<void*>*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref __xc_ma_z));
		_003FInitializedPerAppDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2W4Progress_00402_0040A = (Progress)2;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeUninitializer(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load during registration for the unload events.\n");
		_003CCrtImplementationDetails_003E_002ERegisterModuleUninitializer([SecurityCritical] [PrePrepareMethod] [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] (object A_0, EventArgs A_1) =>
		{
			if (_003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA != 0 && Interlocked.Exchange(ref _003FUninitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA, 1) == 0)
			{
				bool num = Interlocked.Decrement(ref _003FCount_0040AllDomains_0040_003CCrtImplementationDetails_003E_0040_00402HA) == 0;
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeAppDomain();
				if (num)
				{
					_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeDefaultDomain();
				}
			}
		});
	}

	[DebuggerStepThrough]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002E_Initialize(LanguageSupport* P_0)
	{
		_003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA = AppDomain.CurrentDomain.IsDefaultAppDomain();
		if (_003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA)
		{
			_003FEntered_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = true;
		}
		void* ptr = _getFiberPtrId();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			while (num2 == 0)
			{
				try
				{
				}
				finally
				{
					IntPtr intPtr = (IntPtr)0;
					IntPtr intPtr2 = intPtr;
					IntPtr intPtr3 = (IntPtr)ptr;
					IntPtr intPtr4 = intPtr3;
					IntPtr intPtr5 = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<void*, IntPtr>(ref __scrt_native_startup_lock), intPtr3, intPtr);
					IntPtr intPtr6 = intPtr5;
					void* ptr2 = (void*)intPtr5;
					if (ptr2 == null)
					{
						num2 = 1;
					}
					else if (ptr2 == ptr)
					{
						num = 1;
						num2 = 1;
					}
				}
				if (num2 == 0)
				{
					Sleep(1000u);
				}
			}
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeVtables(P_0);
			if (_003FIsDefaultDomain_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2_NA)
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeNative(P_0);
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializePerProcess(P_0);
			}
			else if (_003CCrtImplementationDetails_003E_002EDefaultDomain_002ENeedsInitialization())
			{
				num3 = 1;
			}
		}
		finally
		{
			if (num == 0)
			{
				IntPtr value = (IntPtr)0;
				Interlocked.Exchange(ref System.Runtime.CompilerServices.Unsafe.As<void*, IntPtr>(ref __scrt_native_startup_lock), value);
			}
		}
		if (num3 != 0)
		{
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeDefaultAppDomain(P_0);
		}
		_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializePerAppDomain(P_0);
		_003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA = 1;
		_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitializeUninitializer(P_0);
	}

	[SecurityCritical]
	internal static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeAppDomain()
	{
		_app_exit_callback();
	}

	[SecurityCritical]
	internal unsafe static int _003CCrtImplementationDetails_003E_002ELanguageSupport_002E_UninitializeDefaultDomain(void* cookie)
	{
		_exit_callback();
		_003FInitializedPerProcess_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = false;
		if (_003FInitializedNativeFromCCTOR_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA)
		{
			_cexit();
			__scrt_current_native_startup_state = (__scrt_native_startup_state)0;
			_003FInitializedNativeFromCCTOR_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = false;
		}
		_003FInitializedNative_0040DefaultDomain_0040_003CCrtImplementationDetails_003E_0040_00402_NA = false;
		return 0;
	}

	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeDefaultDomain()
	{
		if (_003CCrtImplementationDetails_003E_002EDefaultDomain_002ENeedsUninitialization())
		{
			if (AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002E_UninitializeDefaultDomain(null);
			}
			else
			{
				_003CCrtImplementationDetails_003E_002EDoCallBackInDefaultDomain((delegate* unmanaged[Stdcall, Stdcall]<void*, int>)__unep_0040_003F_UninitializeDefaultDomain_0040LanguageSupport_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024FCGJPAX_0040Z, null);
			}
		}
	}

	[SecurityCritical]
	[PrePrepareMethod]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	internal static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EDomainUnload(object A_0, EventArgs A_1)
	{
		if (_003FInitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA != 0 && Interlocked.Exchange(ref _003FUninitialized_0040CurrentDomain_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q2HA, 1) == 0)
		{
			bool num = Interlocked.Decrement(ref _003FCount_0040AllDomains_0040_003CCrtImplementationDetails_003E_0040_00402HA) == 0;
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeAppDomain();
			if (num)
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeDefaultDomain();
			}
		}
	}

	[DebuggerStepThrough]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002ECleanup(LanguageSupport* P_0, Exception innerException)
	{
		try
		{
			bool flag = Interlocked.Decrement(ref _003FCount_0040AllDomains_0040_003CCrtImplementationDetails_003E_0040_00402HA) == 0;
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeAppDomain();
			if (flag)
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002EUninitializeDefaultDomain();
			}
		}
		catch (Exception nestedException)
		{
			_003CCrtImplementationDetails_003E_002EThrowNestedModuleLoadException(innerException, nestedException);
		}
		catch
		{
			_003CCrtImplementationDetails_003E_002EThrowNestedModuleLoadException(innerException, null);
		}
	}

	[SecurityCritical]
	internal unsafe static LanguageSupport* _003CCrtImplementationDetails_003E_002ELanguageSupport_002E_007Bctor_007D(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_007Bctor_007D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0);
		return P_0;
	}

	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002E_007Bdtor_007D(LanguageSupport* P_0)
	{
		gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0);
	}

	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void _003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitialize(LanguageSupport* P_0)
	{
		bool flag = false;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0, "The C++ module failed to load.\n");
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				Interlocked.Increment(ref _003FCount_0040AllDomains_0040_003CCrtImplementationDetails_003E_0040_00402HA);
				flag = true;
			}
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002E_Initialize(P_0);
		}
		catch (Exception innerException)
		{
			if (flag)
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002ECleanup(P_0, innerException);
			}
			_003CCrtImplementationDetails_003E_002EThrowModuleLoadException(gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_002EP_0024AAVString_0040System_0040_0040((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0), innerException);
		}
		catch
		{
			if (flag)
			{
				_003CCrtImplementationDetails_003E_002ELanguageSupport_002ECleanup(P_0, null);
			}
			_003CCrtImplementationDetails_003E_002EThrowModuleLoadException(gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_002EP_0024AAVString_0040System_0040_0040((gcroot_003CSystem_003A_003AString_0020_005E_003E*)P_0), null);
		}
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	static unsafe _003CModule_003E()
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out LanguageSupport languageSupport);
		_003CCrtImplementationDetails_003E_002ELanguageSupport_002E_007Bctor_007D(&languageSupport);
		try
		{
			_003CCrtImplementationDetails_003E_002ELanguageSupport_002EInitialize(&languageSupport);
		}
		catch
		{
			//try-fault
			___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<LanguageSupport*, void>)(&_003CCrtImplementationDetails_003E_002ELanguageSupport_002E_007Bdtor_007D), &languageSupport);
			throw;
		}
		_003CCrtImplementationDetails_003E_002ELanguageSupport_002E_007Bdtor_007D(&languageSupport);
	}

	[SecuritySafeCritical]
	internal unsafe static string gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_002EP_0024AAVString_0040System_0040_0040(gcroot_003CSystem_003A_003AString_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		return (string)((GCHandle)intPtr).Target;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static gcroot_003CSystem_003A_003AString_0020_005E_003E* gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_003D(gcroot_003CSystem_003A_003AString_0020_005E_003E* P_0, string t)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		GCHandle gCHandle = (GCHandle)intPtr;
		gCHandle.Target = t;
		return P_0;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_007Bdtor_007D(gcroot_003CSystem_003A_003AString_0020_005E_003E* P_0)
	{
		IntPtr intPtr = new IntPtr((void*)(int)(*(uint*)P_0));
		((GCHandle)intPtr).Free();
		*(int*)P_0 = 0;
	}

	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot_003CSystem_003A_003AString_0020_005E_003E* gcroot_003CSystem_003A_003AString_0020_005E_003E_002E_007Bctor_007D(gcroot_003CSystem_003A_003AString_0020_005E_003E* P_0)
	{
		*(int*)P_0 = (int)((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return P_0;
	}

	[HandleProcessCorruptedStateExceptions]
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	internal unsafe static void __ehvec_dtor(void* ptr, uint size, uint count, delegate*<void*, void> destructor)
	{
		bool flag = false;
		ptr = (int)(size * count) + (byte*)ptr;
		try
		{
			while (true)
			{
				uint num = count;
				count--;
				if (num == 0)
				{
					break;
				}
				ptr = (byte*)ptr - (int)size;
				destructor(ptr);
			}
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				__ArrayUnwind(ptr, size, count, destructor);
			}
		}
	}

	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static int _003FA0x1265e5f1_002EArrayUnwindFilter(_EXCEPTION_POINTERS* pExPtrs)
	{
		if (*(int*)(int)(*(uint*)pExPtrs) != -529697949)
		{
			return 0;
		}
		terminate();
		return 0;
	}

	[SecurityCritical]
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	internal unsafe static void __ArrayUnwind(void* ptr, uint size, uint count, delegate*<void*, void> destructor)
	{
		try
		{
			for (uint num = 0u; num != count; num++)
			{
				ptr = (byte*)ptr - (int)size;
				destructor(ptr);
			}
		}
		catch when (_003FA0x1265e5f1_002EArrayUnwindFilter((_EXCEPTION_POINTERS*)Marshal.GetExceptionPointers()) != 0)
		{
		}
	}

	internal unsafe static void _003FA0x5fdfc975_002E_003F_003F__E_003FA0x5fdfc975_0040_Fac_tidy_reg_0040std_0040_0040YMXXZ()
	{
		_atexit_m((delegate*<void>)(&_003FA0x5fdfc975_002E_003F_003F__F_003FA0x5fdfc975_0040_Fac_tidy_reg_0040std_0040_0040YMXXZ));
	}

	internal unsafe static void _003FA0x5fdfc975_002E_003F_003F__F_003FA0x5fdfc975_0040_Fac_tidy_reg_0040std_0040_0040YMXXZ()
	{
		if (std_002E_003FA0x5fdfc975_002E_Fac_head == null)
		{
			return;
		}
		do
		{
			_Fac_node* ptr = std_002E_003FA0x5fdfc975_002E_Fac_head;
			std_002E_003FA0x5fdfc975_002E_Fac_head = (_Fac_node*)(int)(*(uint*)std_002E_003FA0x5fdfc975_002E_Fac_head);
			int num = ((int*)ptr)[1];
			_Facet_base* ptr2 = ((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, _Facet_base*>)(int)(*(uint*)(*(int*)num + 8)))((IntPtr)num);
			if (ptr2 != null)
			{
				int num2 = *(int*)(int)(*(uint*)ptr2);
				((delegate* unmanaged[Thiscall, Thiscall]<IntPtr, uint, void*>)num2)((nint)ptr2, 1u);
			}
			delete(ptr, 8u);
		}
		while (std_002E_003FA0x5fdfc975_002E_Fac_head != null);
	}

	internal unsafe static void std_002E_Facet_Register_m(_Facet_base* _This)
	{
		_Fac_node* ptr = (_Fac_node*)@new(8u);
		_Fac_node* ptr2;
		try
		{
			if (ptr != null)
			{
				*(int*)ptr = (int)std_002E_003FA0x5fdfc975_002E_Fac_head;
				((int*)ptr)[1] = (int)_This;
				ptr2 = ptr;
			}
			else
			{
				ptr2 = null;
			}
		}
		catch
		{
			//try-fault
			delete(ptr, 8u);
			throw;
		}
		std_002E_003FA0x5fdfc975_002E_Fac_head = ptr2;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static ValueType _003CCrtImplementationDetails_003E_002EAtExitLock_002E_handle()
	{
		if (_003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA != null)
		{
			IntPtr value = new IntPtr(_003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA);
			return GCHandle.FromIntPtr(value);
		}
		return null;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Construct(object value)
	{
		_003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA = null;
		_003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Set(value);
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Set(object value)
	{
		ValueType valueType = _003CCrtImplementationDetails_003E_002EAtExitLock_002E_handle();
		if (valueType == null)
		{
			valueType = GCHandle.Alloc(value);
			_003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA = GCHandle.ToIntPtr((GCHandle)valueType).ToPointer();
		}
		else
		{
			((GCHandle)valueType).Target = value;
		}
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal static object _003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Get()
	{
		ValueType valueType = _003CCrtImplementationDetails_003E_002EAtExitLock_002E_handle();
		if (valueType != null)
		{
			return ((GCHandle)valueType).Target;
		}
		return null;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Destruct()
	{
		ValueType valueType = _003CCrtImplementationDetails_003E_002EAtExitLock_002E_handle();
		if (valueType != null)
		{
			((GCHandle)valueType).Free();
			_003F_lock_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0PAXA = null;
		}
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003CCrtImplementationDetails_003E_002EAtExitLock_002EIsInitialized()
	{
		return _003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Get() != null;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void _003CCrtImplementationDetails_003E_002EAtExitLock_002EAddRef()
	{
		if (!_003CCrtImplementationDetails_003E_002EAtExitLock_002EIsInitialized())
		{
			_003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Construct(new object());
			_003F_ref_count_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0HA = 0;
		}
		_003F_ref_count_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0HA++;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void _003CCrtImplementationDetails_003E_002EAtExitLock_002ERemoveRef()
	{
		_003F_ref_count_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0HA--;
		if (_003F_ref_count_0040AtExitLock_0040_003CCrtImplementationDetails_003E_0040_0040_0024_0024Q0HA == 0)
		{
			_003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Destruct();
		}
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void _003CCrtImplementationDetails_003E_002EAtExitLock_002EEnter()
	{
		Monitor.Enter(_003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Get());
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void _003CCrtImplementationDetails_003E_002EAtExitLock_002EExit()
	{
		Monitor.Exit(_003CCrtImplementationDetails_003E_002EAtExitLock_002E_lock_Get());
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003FA0x288572bd_002E__global_lock()
	{
		bool result = false;
		if (_003CCrtImplementationDetails_003E_002EAtExitLock_002EIsInitialized())
		{
			_003CCrtImplementationDetails_003E_002EAtExitLock_002EEnter();
			result = true;
		}
		return result;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003FA0x288572bd_002E__global_unlock()
	{
		bool result = false;
		if (_003CCrtImplementationDetails_003E_002EAtExitLock_002EIsInitialized())
		{
			_003CCrtImplementationDetails_003E_002EAtExitLock_002EExit();
			result = true;
		}
		return result;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool _003FA0x288572bd_002E__alloc_global_lock()
	{
		_003CCrtImplementationDetails_003E_002EAtExitLock_002EAddRef();
		return _003CCrtImplementationDetails_003E_002EAtExitLock_002EIsInitialized();
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void _003FA0x288572bd_002E__dealloc_global_lock()
	{
		_003CCrtImplementationDetails_003E_002EAtExitLock_002ERemoveRef();
	}

	[SecurityCritical]
	internal unsafe static int _atexit_helper(delegate*<void> func, uint* __pexit_list_size, delegate*<void>** __ponexitend_e, delegate*<void>** __ponexitbegin_e)
	{
		delegate*<void> delegate_002A = null;
		if (func == (delegate*<void>)null)
		{
			return -1;
		}
		if (_003FA0x288572bd_002E__global_lock())
		{
			try
			{
				delegate*<void>* ptr = (delegate*<void>*)DecodePointer((void*)(int)(*(uint*)__ponexitbegin_e));
				delegate*<void>* ptr2 = (delegate*<void>*)DecodePointer((void*)(int)(*(uint*)__ponexitend_e));
				int num = (int)((byte*)ptr2 - (nuint)ptr);
				if (*__pexit_list_size - 1 < (uint)(num >>> 2))
				{
					try
					{
						uint num2 = *__pexit_list_size * 4;
						uint num3 = ((num2 >= 2048) ? 2048u : num2);
						IntPtr cb = new IntPtr((int)(num2 + num3));
						IntPtr pv = new IntPtr(ptr);
						IntPtr intPtr = Marshal.ReAllocHGlobal(pv, cb);
						IntPtr intPtr2 = intPtr;
						IntPtr intPtr3 = intPtr;
						ptr2 = (delegate*<void>*)((byte*)intPtr3.ToPointer() + num);
						ptr = (delegate*<void>*)intPtr3.ToPointer();
						uint num4 = *__pexit_list_size;
						uint num5 = ((512 >= num4) ? num4 : 512u);
						*__pexit_list_size = num4 + num5;
					}
					catch (OutOfMemoryException)
					{
						IntPtr cb2 = new IntPtr((int)(*__pexit_list_size * 4 + 8));
						IntPtr pv2 = new IntPtr(ptr);
						IntPtr intPtr4 = Marshal.ReAllocHGlobal(pv2, cb2);
						IntPtr intPtr5 = intPtr4;
						IntPtr intPtr6 = intPtr4;
						ptr2 = (delegate*<void>*)((byte*)intPtr6.ToPointer() - (nuint)ptr + (nuint)ptr2);
						ptr = (delegate*<void>*)intPtr6.ToPointer();
						*__pexit_list_size += 4u;
					}
				}
				*(int*)ptr2 = (int)func;
				ptr2 = (delegate*<void>*)((byte*)ptr2 + 4);
				delegate_002A = func;
				*(int*)__ponexitbegin_e = (int)EncodePointer(ptr);
				*(int*)__ponexitend_e = (int)EncodePointer(ptr2);
			}
			catch (OutOfMemoryException)
			{
			}
			finally
			{
				_003FA0x288572bd_002E__global_unlock();
			}
			if (delegate_002A != (delegate*<void>)null)
			{
				return 0;
			}
		}
		return -1;
	}

	[SecurityCritical]
	internal unsafe static void _exit_callback()
	{
		if (_003FA0x288572bd_002E__exit_list_size == 0)
		{
			return;
		}
		delegate*<void>* ptr = (delegate*<void>*)DecodePointer(_003FA0x288572bd_002E__onexitbegin_m);
		delegate*<void>* ptr2 = (delegate*<void>*)DecodePointer(_003FA0x288572bd_002E__onexitend_m);
		if (ptr != (delegate*<void>*)(-1) && ptr != null && ptr2 != null)
		{
			delegate*<void>* ptr3 = ptr;
			delegate*<void>* ptr4 = ptr2;
			while (true)
			{
				ptr2 = (delegate*<void>*)((byte*)ptr2 - 4);
				if (ptr2 < ptr)
				{
					break;
				}
				if ((void*)(*(int*)ptr2) != EncodePointer(null))
				{
					void* intPtr = DecodePointer((void*)(int)(*(uint*)ptr2));
					*(int*)ptr2 = (int)EncodePointer(null);
					((delegate*<void>)intPtr)();
					delegate*<void>* ptr5 = (delegate*<void>*)DecodePointer(_003FA0x288572bd_002E__onexitbegin_m);
					delegate*<void>* ptr6 = (delegate*<void>*)DecodePointer(_003FA0x288572bd_002E__onexitend_m);
					if (ptr3 != ptr5 || ptr4 != ptr6)
					{
						ptr3 = ptr5;
						ptr = ptr5;
						ptr4 = ptr6;
						ptr2 = ptr6;
					}
				}
			}
			IntPtr hglobal = new IntPtr(ptr);
			Marshal.FreeHGlobal(hglobal);
		}
		_003FA0x288572bd_002E__dealloc_global_lock();
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static int _initatexit_m()
	{
		int result = 0;
		if (_003FA0x288572bd_002E__alloc_global_lock())
		{
			_003FA0x288572bd_002E__onexitbegin_m = (delegate*<void>*)EncodePointer(Marshal.AllocHGlobal(128).ToPointer());
			_003FA0x288572bd_002E__onexitend_m = _003FA0x288572bd_002E__onexitbegin_m;
			_003FA0x288572bd_002E__exit_list_size = 32u;
			result = 1;
		}
		return result;
	}

	[SecurityCritical]
	internal unsafe static int _atexit_m(delegate*<void> func)
	{
		return _atexit_helper((delegate*<void>)EncodePointer(func), (uint*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003FA0x288572bd_002E__exit_list_size), (delegate*<void>**)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003FA0x288572bd_002E__onexitend_m), (delegate*<void>**)System.Runtime.CompilerServices.Unsafe.AsPointer(ref _003FA0x288572bd_002E__onexitbegin_m));
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static int _initatexit_app_domain()
	{
		if (_003FA0x288572bd_002E__alloc_global_lock())
		{
			__onexitbegin_app_domain = (delegate*<void>*)EncodePointer(Marshal.AllocHGlobal(128).ToPointer());
			__onexitend_app_domain = __onexitbegin_app_domain;
			__exit_list_size_app_domain = 32u;
		}
		return 1;
	}

	[HandleProcessCorruptedStateExceptions]
	[SecurityCritical]
	internal unsafe static void _app_exit_callback()
	{
		if (__exit_list_size_app_domain == 0)
		{
			return;
		}
		delegate*<void>* ptr = (delegate*<void>*)DecodePointer(__onexitbegin_app_domain);
		delegate*<void>* ptr2 = (delegate*<void>*)DecodePointer(__onexitend_app_domain);
		try
		{
			if (ptr == (delegate*<void>*)(-1) || ptr == null || ptr2 == null)
			{
				return;
			}
			delegate*<void> delegate_002A = null;
			delegate*<void>* ptr3 = ptr;
			delegate*<void>* ptr4 = ptr2;
			while (true)
			{
				delegate*<void>* ptr5 = null;
				delegate*<void>* ptr6 = null;
				do
				{
					ptr2 = (delegate*<void>*)((byte*)ptr2 - 4);
				}
				while (ptr2 >= ptr && (void*)(*(int*)ptr2) == EncodePointer(null));
				if (ptr2 >= ptr)
				{
					delegate_002A = (delegate*<void>)DecodePointer((void*)(int)(*(uint*)ptr2));
					*(int*)ptr2 = (int)EncodePointer(null);
					delegate_002A();
					delegate*<void>* ptr7 = (delegate*<void>*)DecodePointer(__onexitbegin_app_domain);
					delegate*<void>* ptr8 = (delegate*<void>*)DecodePointer(__onexitend_app_domain);
					if (ptr3 != ptr7 || ptr4 != ptr8)
					{
						ptr3 = ptr7;
						ptr = ptr7;
						ptr4 = ptr8;
						ptr2 = ptr8;
					}
					continue;
				}
				break;
			}
		}
		finally
		{
			IntPtr hglobal = new IntPtr(ptr);
			Marshal.FreeHGlobal(hglobal);
			_003FA0x288572bd_002E__dealloc_global_lock();
		}
	}

	[DllImport("KERNEL32.dll")]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* DecodePointer(void* _Ptr);

	[DllImport("KERNEL32.dll")]
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* EncodePointer(void* _Ptr);

	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static int _initterm_e(delegate* unmanaged[Cdecl, Cdecl]<int>* pfbegin, delegate* unmanaged[Cdecl, Cdecl]<int>* pfend)
	{
		int num = 0;
		if (pfbegin < pfend)
		{
			while (num == 0)
			{
				uint num2 = *(uint*)pfbegin;
				if (num2 != 0)
				{
					num = ((delegate* unmanaged[Cdecl, Cdecl]<int>)(int)num2)();
				}
				pfbegin = (delegate* unmanaged[Cdecl, Cdecl]<int>*)((byte*)pfbegin + 4);
				if (pfbegin >= pfend)
				{
					break;
				}
			}
		}
		return num;
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void _initterm(delegate* unmanaged[Cdecl, Cdecl]<void>* pfbegin, delegate* unmanaged[Cdecl, Cdecl]<void>* pfend)
	{
		if (pfbegin >= pfend)
		{
			return;
		}
		do
		{
			uint num = *(uint*)pfbegin;
			if (num != 0)
			{
				((delegate* unmanaged[Cdecl, Cdecl]<void>)(int)num)();
			}
			pfbegin = (delegate* unmanaged[Cdecl, Cdecl]<void>*)((byte*)pfbegin + 4);
		}
		while (pfbegin < pfend);
	}

	[DebuggerStepThrough]
	internal static ModuleHandle _003CCrtImplementationDetails_003E_002EThisModule_002EHandle()
	{
		return typeof(ThisModule).Module.ModuleHandle;
	}

	[DebuggerStepThrough]
	[SecurityCritical]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void _initterm_m(delegate*<void*>* pfbegin, delegate*<void*>* pfend)
	{
		if (pfbegin >= pfend)
		{
			return;
		}
		do
		{
			uint num = *(uint*)pfbegin;
			if (num != 0)
			{
				_003CCrtImplementationDetails_003E_002EThisModule_002EResolveMethod_003Cvoid_0020const_0020_002A_0020__clrcall_0028void_0029_003E((delegate*<void*>)(int)num)();
			}
			pfbegin = (delegate*<void*>*)((byte*)pfbegin + 4);
		}
		while (pfbegin < pfend);
	}

	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static delegate*<void*> _003CCrtImplementationDetails_003E_002EThisModule_002EResolveMethod_003Cvoid_0020const_0020_002A_0020__clrcall_0028void_0029_003E(delegate*<void*> methodToken)
	{
		return (delegate*<void*>)_003CCrtImplementationDetails_003E_002EThisModule_002EHandle().ResolveMethodHandle((int)methodToken).GetFunctionPointer().ToPointer();
	}

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern GigEActionCommandResult* std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_005B_005D(vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E* P_0, uint P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern GigEActionCommandResult* std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002Edata(vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bdtor_007D(vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E* std_002Evector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E_002E_007Bctor_007D(vector_003CPylon_003A_003AGigEActionCommandResult_002Cstd_003A_003Aallocator_003CPylon_003A_003AGigEActionCommandResult_003E_0020_003E* P_0, uint P_1, allocator_003CPylon_003A_003AGigEActionCommandResult_003E* P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern allocator_003CPylon_003A_003AGigEActionCommandResult_003E* std_002Eallocator_003CPylon_003A_003AGigEActionCommandResult_003E_002E_007Bctor_007D(allocator_003CPylon_003A_003AGigEActionCommandResult_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002EconvertString(char* P_0, sbyte* P_1, int P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002E_007Bdtor_007D(StringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern StringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E* Baselibs_002EStringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E_002E_007Bctor_007D(StringConverter_003C2_002C1_002Cwchar_t_002Cchar_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern char* Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002Ec_str(StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bdtor_007D(StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* Baselibs_002EStringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E_002E_007Bctor_007D(StringConverter_003C1_002C2_002Cchar_002Cwchar_t_003E* P_0, sbyte* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* new_005B_005D(uint P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void __CxxUnregisterExceptionObject(void* P_0, int P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern int __CxxQueryExceptionSize();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int __CxxDetectRethrow(void* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int __CxxRegisterExceptionObject(void* P_0, void* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int __CxxExceptionFilter(void* P_0, void* P_1, int P_2, void* P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ITransportLayer* Pylon_002ECTlFactory_002ECreateTl(CTlFactory* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* __RTDynamicCast(void* P_0, int P_1, void* P_2, void* P_3, int P_4);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlFactory* Pylon_002ECTlFactory_002EGetInstance();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECTlFactory_002EReleaseTl(CTlFactory* P_0, ITransportLayer* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(gcstring* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* GenICam_3_1_Basler_pylon_002Egcstring_002E_002EPBD(gcstring* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002Egcstring_002Eresize(gcstring* P_0, uint P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(gcstring* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bdtor_007D(gcstring* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenICam_3_1_Basler_pylon_002Egcstring_002E_007Bctor_007D(gcstring* P_0, sbyte* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void delete_005B_005D(void* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int MultiByteToWideChar(uint P_0, uint P_1, sbyte* P_2, int P_3, char* P_4, int P_5);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int WideCharToMultiByte(uint P_0, uint P_1, char* P_2, int P_3, sbyte* P_4, int P_5, sbyte* P_6, int* P_7);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern WaitObjectEx* Pylon_002EWaitObjectEx_002E_003D(WaitObjectEx* P_0, WaitObjectEx* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern RuntimeException* GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bctor_007D(RuntimeException* P_0, RuntimeException* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(ODevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EIDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(IDevFileStreamBuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, INodeMap* P_1, sbyte* P_2, int P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* GenApi_3_1_Basler_pylon_002EIDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(IDevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclose(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eopen(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, INodeMap* P_1, sbyte* P_2, int P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* GenApi_3_1_Basler_pylon_002EODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(ODevFileStreamBase_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Ewrite(basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* P_1, long P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egcount(basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eread(basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* P_1, long P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EVersionInfo_002EgetMajor(VersionInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EVersionInfo_002EgetMinor(VersionInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EVersionInfo_002EgetSubminor(VersionInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EVersionInfo_002E_007Bdtor_007D(VersionInfo* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern VersionInfo* Pylon_002ECInstantCamera_002EGetSfncVersion(CInstantCamera* P_0, VersionInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002EWaitObject_002EWait(WaitObject* P_0, uint P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetCameraCatID();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ECDeviceInfo_002ESetDeviceClass(CDeviceInfo* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ECDeviceInfo_002E_007Bctor_007D(CDeviceInfo* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenICam_3_1_Basler_pylon_002Egcstring_002E_003D(gcstring* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECDeviceInfo_002E_007Bdtor_007D(CDeviceInfo* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ECDeviceInfo_002E_007Bctor_007D(CDeviceInfo* P_0, CDeviceInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Epush_back(TList_003CPylon_003A_003ACDeviceInfo_003E* P_0, CDeviceInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EDeviceInfoList_002E_007Bdtor_007D(DeviceInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern DeviceInfoList* Pylon_002EDeviceInfoList_002E_007Bctor_007D(DeviceInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eios_base_002Eeof(ios_base* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eios_base_002Egood(ios_base* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Bxty_002E_007Bdtor_007D(_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E._Bxty* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eexception_002E_007Bdtor_007D(exception* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern exception* std_002Eexception_002E_007Bctor_007D(exception* P_0, exception* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eflush(basic_ostream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eios_base_002Efail(ios_base* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002Egcstring_002Edelete(void* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* GenICam_3_1_Basler_pylon_002Egcstring_002Enew(uint P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* Pylon_002EWaitObject_002E_002EPAX(WaitObject* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int SetWaitableTimer(void* P_0, _LARGE_INTEGER* P_1, int P_2, delegate* unmanaged[Stdcall, Stdcall]<void*, uint, uint, void> P_3, void* P_4, int P_5);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern WaitObjectEx* Pylon_002EWaitObjectEx_002E_007Bctor_007D(WaitObjectEx* P_0, void* P_1, [MarshalAs(UnmanagedType.U1)] bool P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern RuntimeException* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002EReport(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* P_0, RuntimeException* P_1, sbyte* P_2, __arglist);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint GetLastError();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E_002E_007Bctor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ARuntimeException_003E* P_0, sbyte* P_1, int P_2, sbyte* P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002ERuntimeException_002E_007Bdtor_007D(RuntimeException* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* CreateWaitableTimerW(_SECURITY_ATTRIBUTES* P_0, int P_1, char* P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EWaitObjectEx_002E_007Bdtor_007D(WaitObjectEx* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern WaitObjectEx* Pylon_002EWaitObjectEx_002E_007Bctor_007D(WaitObjectEx* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECInstantCamera_002ERegisterImageEventHandler(CInstantCamera* P_0, CImageEventHandler* P_1, ERegistrationMode P_2, ECleanup P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECInstantCamera_002ERegisterConfiguration(CInstantCamera* P_0, CConfigurationEventHandler* P_1, ERegistrationMode P_2, ECleanup P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern IInstantCameraExtensions* Pylon_002ECInstantCamera_002EGetExtensionInterface(CInstantCamera* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageEventHandler_002E_007Bdtor_007D(CImageEventHandler* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageEventHandler* Pylon_002ECImageEventHandler_002E_007Bctor_007D(CImageEventHandler* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECConfigurationEventHandler_002E_007Bdtor_007D(CConfigurationEventHandler* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CConfigurationEventHandler* Pylon_002ECConfigurationEventHandler_002E_007Bctor_007D(CConfigurationEventHandler* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECInstantCamera_002E_007Bdtor_007D(CInstantCamera* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CInstantCamera* Pylon_002ECInstantCamera_002E_007Bctor_007D(CInstantCamera* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void delete_005B_005D(void* P_0, uint P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* @new(uint P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void delete(void* P_0, uint P_1);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void _CxxThrowException(void* P_0, _s__ThrowInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern byte bclog_002ELogTrace(uint P_0, LogLevel P_1, sbyte* P_2, __arglist);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetLibraryCatID();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern AccessModeSet* Pylon_002EAccessModeSet_002E_007Bctor_007D(AccessModeSet* P_0, AccessModeSet* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EAccessModeSet_002E_007Bdtor_007D(AccessModeSet* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern AccessModeSet* Pylon_002EAccessModeSet_002E_007Bctor_007D(AccessModeSet* P_0, EDeviceAccessMode P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002E_005B_005D(TList_003CPylon_003A_003ACDeviceInfo_003E* P_0, uint P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECInfoBase_002E_003D_003D(CInfoBase* P_0, CInfoBase* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002ECDeviceInfo_002EGetSerialNumber(CDeviceInfo* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ECDeviceInfo_002ESetSerialNumber(CDeviceInfo* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002ECInfoBase_002EGetDeviceClass(CInfoBase* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Econst_iterator_002E_002A(TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Econst_iterator_002E_0021_003D(TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* P_0, TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Econst_iterator_002E_002B_002B(TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetInfoCatID();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ulong Pylon_002ECPylonDataComponent_002EGetTimeStamp(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002ECGrabResultData_002EGetBufferContext(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultData* Pylon_002ECGrabResultPtr_002E_002D_003E(CGrabResultPtr* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* Pylon_002ECGrabResultData_002EGetBuffer(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* Pylon_002ECPylonDataComponent_002EGetData(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetDataSize(CPylonDataComponent* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsPacked(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002ESamplesPerPixel(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EBitPerPixel(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultPtr_002E_002E_N(CGrabResultPtr* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetPaddingX(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetOffsetY(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetOffsetX(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetHeight(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataComponent_002EGetWidth(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPixelType Pylon_002ECPylonDataComponent_002EGetPixelType(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EComponentType Pylon_002ECPylonDataComponent_002EGetComponentType(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECPylonDataComponent_002EIsValid(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonDataComponent_002E_007Bdtor_007D(CPylonDataComponent* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonDataComponent* Pylon_002ECPylonDataComponent_002E_007Bctor_007D(CPylonDataComponent* P_0, CPylonDataComponent* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonDataContainer_002ELoad(CPylonDataContainer* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonDataContainer_002ESave(CPylonDataContainer* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonDataComponent* Pylon_002ECPylonDataContainer_002EGetDataComponent(CPylonDataContainer* P_0, CPylonDataComponent* P_1, uint P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonDataContainer_002EGetDataComponentCount(CPylonDataContainer* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECGrabResultPtr_002E_007Bdtor_007D(CGrabResultPtr* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonDataContainer_002E_007Bdtor_007D(CPylonDataContainer* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultPtr* Pylon_002ECGrabResultPtr_002E_007Bctor_007D(CGrabResultPtr* P_0, CGrabResultPtr* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonDataContainer* Pylon_002ECPylonDataContainer_002E_007Bctor_007D(CPylonDataContainer* P_0, CPylonDataContainer* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bdtor_007D(BadAllocException* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern BadAllocException* GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bctor_007D(BadAllocException* P_0, BadAllocException* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern Pylon.GrabResult* Pylon_002EGrabResult_002E_003D(Pylon.GrabResult* P_0, Pylon.GrabResult* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern BadAllocException* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002EReport(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* P_0, BadAllocException* P_1, sbyte* P_2, __arglist);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E_002E_007Bctor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003ABadAllocException_003E* P_0, sbyte* P_1, int P_2, sbyte* P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern NativeBufferContext* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002Erelease(unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern NativeBufferContext* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_002D_003E(unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bdtor_007D(unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Eout(codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* P_0, _Mbstatet* P_1, sbyte* P_2, sbyte* P_3, sbyte** P_4, sbyte* P_5, sbyte* P_6, sbyte** P_7);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Ein(codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* P_0, _Mbstatet* P_1, sbyte* P_2, sbyte* P_3, sbyte** P_4, sbyte* P_5, sbyte* P_6, sbyte** P_7);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Edata(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Efront(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Eerase(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0, uint P_1, uint P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gndec(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern _Mbstatet* std_002Efpos_003C_Mbstatet_003E_002Estate(fpos_003C_Mbstatet_003E* P_0, _Mbstatet* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern fpos_003C_Mbstatet_003E* std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(fpos_003C_Mbstatet_003E* P_0, _Mbstatet P_1, long P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int std_002Ecodecvt_003Cchar_002Cchar_002C_Mbstatet_003E_002Eunshift(codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* P_0, _Mbstatet* P_1, sbyte* P_2, sbyte* P_3, sbyte** P_4);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte** P_1, sbyte** P_2, int* P_3, sbyte** P_4, sbyte** P_5, int* P_6);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern locale* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egetloc(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, locale* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_003E_002C0_003E(unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* P_0, NativeBufferContext* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eoperator_003D_003D_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_002Cstruct_0020std_003A_003Adefault_delete_003Cstruct_0020Basler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E(void* P_0, unique_ptr_003CBasler_003A_003APylon_003A_003ANativeBufferContext_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ANativeBufferContext_003E_0020_003E* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* std_002Euse_facet_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020_003E(locale* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eswap_003Cclass_0020Pylon_003A_003ACBufferData_0020_002A_002Cvoid_003E(CBufferData** P_0, CBufferData** P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* std_002Eaddressof_003Cclass_0020std_003A_003Acodecvt_003Cchar_002Cchar_002Cstruct_0020_Mbstatet_003E_0020const_0020_003E(codecvt_003Cchar_002Cchar_002C_Mbstatet_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern _iobuf* std_002E_Fiopen(char* P_0, int P_1, int P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fclose(_iobuf* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int _get_stream_buffer_pointers(_iobuf* P_0, sbyte*** P_1, sbyte*** P_2, int** P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Init(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Ecodecvt_base_002Ealways_noconv(codecvt_base* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetg(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* P_1, sbyte* P_2, sbyte* P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultData_002EGrabSucceeded(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void _lock_file(_iobuf* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void _unlock_file(_iobuf* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Pninc(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eepptr(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int std_002Echar_traits_003Cchar_003E_002Enot_eof(int* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eeback(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Epush_back(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0, sbyte P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eegptr(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint fread(void* P_0, uint P_1, uint P_2, _iobuf* P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gnavail(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egbump(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Gninc(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte std_002Echar_traits_003Cchar_003E_002Eto_char_type(int* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsgetn(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* P_1, long P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint fwrite(void* P_0, uint P_1, uint P_2, _iobuf* P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_Pnavail(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epptr(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Epbump(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int std_002Echar_traits_003Cchar_003E_002Eto_int_type(sbyte* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Exsputn(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, sbyte* P_1, long P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fgetpos(_iobuf* P_0, long* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int _fseeki64(_iobuf* P_0, long P_1, int P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Ebasic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Egptr(basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern fpos_003C_Mbstatet_003E* std_002Efpos_003C_Mbstatet_003E_002E_007Bctor_007D(fpos_003C_Mbstatet_003E* P_0, long P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fsetpos(_iobuf* P_0, long* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long std_002Efpos_003C_Mbstatet_003E_002E_002E_J(fpos_003C_Mbstatet_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int setvbuf(_iobuf* P_0, sbyte* P_1, int P_2, uint P_3);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fflush(_iobuf* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern int std_002Echar_traits_003Cchar_003E_002Eeof();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Echar_traits_003Cchar_003E_002Eeq_int_type(int* P_0, int* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Elocale_002E_007Bdtor_007D(locale* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_istream_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, basic_streambuf_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_1, [MarshalAs(UnmanagedType.U1)] bool P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Eclear(basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1, [MarshalAs(UnmanagedType.U1)] bool P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E_002Esetstate(basic_ios_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_0020_003E* P_0, int P_1, [MarshalAs(UnmanagedType.U1)] bool P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EIImage_002E_007Bdtor_007D(Pylon.IImage* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPixelType Pylon_002ECGrabResultData_002EGetPixelType(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetWidth(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetHeight(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetPaddingX(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetImageSize(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultData_002EGetStride(CGrabResultData* P_0, uint* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonDataContainer* Pylon_002EGrabResult_002EGetDataContainer(Pylon.GrabResult* P_0, CPylonDataContainer* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002Esize(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eios_base_002Eexceptions(ios_base* P_0, int P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* Pylon_002EGrabResult_002EContext(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECGrabResultData_002E_007Bdtor_007D(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultData* Pylon_002ECGrabResultData_002E_007Bctor_007D(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultPtr* Pylon_002ECGrabResultPtr_002E_003D(CGrabResultPtr* P_0, CGrabResultPtr.CGrabResultPtrImpl* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultPtr* Pylon_002ECGrabResultPtr_002E_007Bctor_007D(CGrabResultPtr* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int ungetc(int P_0, _iobuf* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fputc(int P_0, _iobuf* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int fgetc(_iobuf* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CGrabResultData.CGrabResultDataImpl* Pylon_002ECGrabResultData_002EGetGrabResultDataImpl(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ulong Pylon_002EGrabResult_002EGetBlockID(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002EGrabResult_002EGetErrorDescription(Pylon.GrabResult* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EGrabResult_002EGetErrorCode(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long Pylon_002EGrabResult_002EGetPayloadSize(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetPaddingY(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetPaddingX(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetOffsetY(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetOffsetX(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetSizeY(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002EGrabResult_002EGetSizeX(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ulong Pylon_002EGrabResult_002EGetTimeStamp(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPixelType Pylon_002EGrabResult_002EGetPixelType(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPayloadType Pylon_002EGrabResult_002EGetPayloadType(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002EGrabResult_002ESucceeded(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EGrabResult_002EGetBufferSize(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* Pylon_002EGrabResult_002EBuffer(Pylon.GrabResult* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern sbyte* std_002Echar_traits_003Cchar_003E_002Ecopy(sbyte* P_0, sbyte* P_1, uint P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002E_007Bctor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E* P_0, sbyte* P_1, int P_2, sbyte* P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern OutOfRangeException* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E_002EReport(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AOutOfRangeException_003E* P_0, OutOfRangeException* P_1, sbyte* P_2, __arglist);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EGrabResult_002E_007Bdtor_007D(Pylon.GrabResult* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern Pylon.GrabResult* Pylon_002EGrabResult_002E_007Bctor_007D(Pylon.GrabResult* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002E_007Bdtor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002E_007Bctor_007D(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E* P_0, sbyte* P_1, int P_2, sbyte* P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern InvalidArgumentException* GenICam_3_1_Basler_pylon_002EExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E_002EReport(ExceptionReporter_003CGenICam_3_1_Basler_pylon_003A_003AInvalidArgumentException_003E* P_0, InvalidArgumentException* P_1, sbyte* P_2, __arglist);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EIBufferFactory_002E_007Bdtor_007D(Pylon.IBufferFactory* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EComputeBufferSize(EPixelType P_0, uint P_1, uint P_2, uint P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EIsReadable(IBase* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EEAccessModeClass_002EFromString(gcstring* P_0, _EAccessMode* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EEVisibilityClass_002EFromString(gcstring* P_0, _EVisibility* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EEDisplayNotationClass_002EToString(gcstring* P_0, _EDisplayNotation P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EERepresentationClass_002EToString(gcstring* P_0, _ERepresentation P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EEAccessModeClass_002EToString(gcstring* P_0, _EAccessMode P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EECachingModeClass_002EToString(gcstring* P_0, _ECachingMode P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EEYesNoClass_002EToString(gcstring* P_0, _EYesNo P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EENameSpaceClass_002EToString(gcstring* P_0, _ENameSpace P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* GenApi_3_1_Basler_pylon_002EEVisibilityClass_002EToString(gcstring* P_0, _EVisibility P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNodeMapFactory* GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002EExtractSubtree(CNodeMapFactory* P_0, CNodeMapFactory* P_1, gcstring* P_2, [MarshalAs(UnmanagedType.U1)] bool P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern INodeMap* GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002ECreateNodeMap(CNodeMapFactory* P_0, gcstring* P_1, [MarshalAs(UnmanagedType.U1)] bool P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E_002E_007Bdtor_007D(CNodeMapRefT_003CGenApi_3_1_Basler_pylon_003A_003ACGeneric_XMLLoaderParams_003E* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bdtor_007D(CNodeMapFactory* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNodeMapRef* GenApi_3_1_Basler_pylon_002ECNodeMapRef_002E_007Bctor_007D(CNodeMapRef* P_0, INodeMap* P_1, gcstring* P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNodeMapFactory* GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bctor_007D(CNodeMapFactory* P_0, gcstring* P_1, ECacheUsage_t P_2, [MarshalAs(UnmanagedType.U1)] bool P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNodeMapFactory* GenApi_3_1_Basler_pylon_002ECNodeMapFactory_002E_007Bctor_007D(CNodeMapFactory* P_0, EContentType_t P_1, gcstring* P_2, ECacheUsage_t P_3, [MarshalAs(UnmanagedType.U1)] bool P_4);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long Pylon_002ECGrabResultData_002EGetImageNumber(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonDataContainer* Pylon_002ECGrabResultData_002EGetDataContainer(CGrabResultData* P_0, CPylonDataContainer* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long Pylon_002ECGrabResultData_002EGetNumberOfSkippedImages(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern long Pylon_002ECGrabResultData_002EGetID(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ulong Pylon_002ECGrabResultData_002EGetTimeStamp(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ulong Pylon_002ECGrabResultData_002EGetBlockID(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultData_002ECheckCRC(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultData_002EHasCRC(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultData_002EIsChunkDataAvailable(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002ECGrabResultData_002EGetErrorDescription(CGrabResultData* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetErrorCode(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetOffsetY(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetOffsetX(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetPaddingY(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECGrabResultData_002EGetPayloadSize(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPayloadType Pylon_002ECGrabResultData_002EGetPayloadType(CGrabResultData* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECGrabResultPtr_002EIsUnique(CGrabResultPtr* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern INodeMap* Pylon_002ECGrabResultData_002EGetChunkDataNodeMap(CGrabResultData* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetImageCatID();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002EComputeStride(uint* P_0, EPixelType P_1, uint P_2, uint P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonImage_002EAttachUserBuffer(CPylonImage* P_0, void* P_1, uint P_2, EPixelType P_3, uint P_4, uint P_5, uint P_6, EImageOrientation P_7, CPylonImageUserBufferEventHandler* P_8);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonImage_002E_007Bdtor_007D(CPylonImage* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonImage* Pylon_002ECPylonImage_002E_007Bctor_007D(CPylonImage* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECImageDecompressor_002E_003D_003D(CImageDecompressor* P_0, CImageDecompressor* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CompressionInfo_t* Pylon_002ECImageDecompressor_002EDecompressImage(CImageDecompressor* P_0, CompressionInfo_t* P_1, void* P_2, uint* P_3, void* P_4, uint P_5);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECImageDecompressor_002EGetImageSizeForDecompression(INodeMap* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EGetCompressionDescriptorHash(void* P_0, uint* P_1, void* P_2, uint P_3, EEndianness P_4);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EGetCompressionDescriptorHash(void* P_0, uint* P_1, INodeMap* P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EGetCompressionDescriptorHash(CImageDecompressor* P_0, void* P_1, uint* P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EComputeCompressionDescriptorHash(void* P_0, uint* P_1, void* P_2, uint P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint std_002Enumeric_limits_003Cunsigned_0020int_003E_002Emin();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint std_002Enumeric_limits_003Cunsigned_0020int_003E_002Emax();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECImageDecompressor_002EGetCompressionInfo(CompressionInfo_t* P_0, void* P_1, uint P_2, EEndianness P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CompressionInfo_t* Pylon_002ECompressionInfo_t_002E_007Bctor_007D(CompressionInfo_t* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EGetCompressionDescriptor(void* P_0, uint* P_1, INodeMap* P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EGetCompressionDescriptor(CImageDecompressor* P_0, void* P_1, uint* P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ECompressionMode Pylon_002ECImageDecompressor_002EGetCompressionMode(INodeMap* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002ESetCompressionDescriptor(CImageDecompressor* P_0, INodeMap* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002ESetCompressionDescriptor(CImageDecompressor* P_0, void* P_1, uint P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002EResetCompressionDescriptor(CImageDecompressor* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECImageDecompressor_002EHasCompressionDescriptor(CImageDecompressor* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImageDecompressor_002E_007Bdtor_007D(CImageDecompressor* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageDecompressor* Pylon_002ECImageDecompressor_002E_007Bctor_007D(CImageDecompressor* P_0, INodeMap* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageDecompressor* Pylon_002ECImageDecompressor_002E_007Bctor_007D(CImageDecompressor* P_0, void* P_1, uint P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageDecompressor* Pylon_002ECImageDecompressor_002E_007Bctor_007D(CImageDecompressor* P_0, CImageDecompressor* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageDecompressor* Pylon_002ECImageDecompressor_002E_007Bctor_007D(CImageDecompressor* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Eiterator_002E_002A(TList_003CPylon_003A_003ACDeviceInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACDeviceInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Eiterator_002E_002B_002B(TList_003CPylon_003A_003ACDeviceInfo_003E.iterator* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetInterfaceCatID();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002E_Adl_verify_range_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* std_002E_Get_unwrapped_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002C0_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern less_003Cvoid_003E std_002E_Pass_fn_003Cstruct_0020std_003A_003Aless_003Cvoid_003E_002C0_003E(less_003Cvoid_003E P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CInterfaceInfo* Pylon_002ECInterfaceInfo_002E_003D(CInterfaceInfo* P_0, CInterfaceInfo* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eless_003Cvoid_003E_002Eoperator_0028_0029_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_002Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(less_003Cvoid_003E* P_0, CInterfaceInfo* P_1, CInterfaceInfo* P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void std_002Eiter_swap_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E* std_002Epair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E_002E_007Bctor_007D_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_0020_0026_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_0020_0026_002C0_003E(pair_003CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002CPylon_003A_003ATList_003CPylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_1, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CInterfaceInfo* std_002Emove_003Cclass_0020Pylon_003A_003ACInterfaceInfo_0020_0026_003E(CInterfaceInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* std_002E_Move_backward_unchecked_003Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_002Cclass_0020Pylon_003A_003ATList_003Cclass_0020Pylon_003A_003ACInterfaceInfo_003E_003A_003Aiterator_003E(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator P_1, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator P_2, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECInterfaceInfo_002E_007Bdtor_007D(CInterfaceInfo* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CInterfaceInfo* Pylon_002ECInterfaceInfo_002E_007Bctor_007D(CInterfaceInfo* P_0, CInterfaceInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003D_003D(TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D_002D(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_003C(TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_1, int P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_1, int P_2);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002D(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CInterfaceInfo* Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002A(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Econst_iterator_002E_0021_003D(TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_0, TList_003CPylon_003A_003ACInterfaceInfo_003E.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACInterfaceInfo_003E_002Eiterator_002E_002B_002B(TList_003CPylon_003A_003ACInterfaceInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ITransportLayer* Pylon_002ECTlFactory_002ECreateTl(CTlFactory* P_0, CTlInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlInfo* Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Eiterator_002E_002A(TList_003CPylon_003A_003ACTlInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Econst_iterator_002E_0021_003D(TList_003CPylon_003A_003ACTlInfo_003E.const_iterator* P_0, TList_003CPylon_003A_003ACTlInfo_003E.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACTlInfo_003E.iterator* Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Eiterator_002E_002B_002B(TList_003CPylon_003A_003ACTlInfo_003E.iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EInterfaceInfoList_002E_007Bdtor_007D(InterfaceInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern InterfaceInfoList* Pylon_002EInterfaceInfoList_002E_007Bctor_007D(InterfaceInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int Pylon_002ECTlFactory_002EEnumerateTls(CTlFactory* P_0, TlInfoList* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ETlInfoList_002E_007Bdtor_007D(TlInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TlInfoList* Pylon_002ETlInfoList_002E_007Bctor_007D(TlInfoList* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002ECDeviceInfo_002EGetUserDefinedName(CDeviceInfo* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CDeviceInfo* Pylon_002ETList_003CPylon_003A_003ACDeviceInfo_003E_002Econst_iterator_002E_002D_003E(TList_003CPylon_003A_003ACDeviceInfo_003E.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring* Pylon_002ECDeviceInfo_002EGetMacAddress(CDeviceInfo* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002ECImageFormatConverter_002EIsSupportedOutputFormat(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002ECImageFormatConverter_002EIsSupportedInputFormat(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CImageFormatConverter* Pylon_002ECImageFormatConverter_002E_007Bctor_007D(CImageFormatConverter* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern IEnumEntry* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIEnumEntry_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, IBase* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern INode** GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002A(node_vector.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_0021_003D(node_vector.const_iterator* P_0, node_vector.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern node_vector.const_iterator* GenApi_3_1_Basler_pylon_002Enode_vector_002Econst_iterator_002E_002B_002B(node_vector.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern INode** GenApi_3_1_Basler_pylon_002Enode_vector_002E_005B_005D(node_vector* P_0, uint P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EIsImplemented(IBase* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002Enode_vector_002E_007Bdtor_007D(node_vector* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern node_vector* GenApi_3_1_Basler_pylon_002Enode_vector_002E_007Bctor_007D(node_vector* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetParameterCatID();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EIsAvailable(IBase* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002EIsWritable(IBase* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern double gtl_002ECorrectDoubleValue(double P_0, double P_1, double P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern long gtl_002ECorrectIntValue(long P_0, long P_1, long P_2, long P_3, EValueCorrection P_4);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002E_N(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ISelector* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AISelector_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, IBase* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002E_N(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern ICategory* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AICategory_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, IBase* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern IValue** GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002A(value_vector.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_0021_003D(value_vector.const_iterator* P_0, value_vector.const_iterator* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern value_vector.const_iterator* GenApi_3_1_Basler_pylon_002Evalue_vector_002Econst_iterator_002E_002B_002B(value_vector.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bdtor_007D(value_vector* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern value_vector* GenApi_3_1_Basler_pylon_002Evalue_vector_002E_007Bctor_007D(value_vector* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECFeaturePersistence_002ELoad(gcstring* P_0, INodeMap* P_1, [MarshalAs(UnmanagedType.U1)] bool P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECFeaturePersistence_002ESave(gcstring* P_0, INodeMap* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern IValue* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_002D_003E(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bdtor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* GenApi_3_1_Basler_pylon_002ECPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E_002E_007Bctor_007D(CPointer_003CGenApi_3_1_Basler_pylon_003A_003AIValue_002CGenApi_3_1_Basler_pylon_003A_003AIBase_003E* P_0, IBase* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int GenApi_3_1_Basler_pylon_002ERegister_003Cvoid_0020_0028__stdcall_002A_0029_0028struct_0020GenApi_3_1_Basler_pylon_003A_003AINode_0020_002A_0029_003E(INode* P_0, delegate* unmanaged[Stdcall, Stdcall]<INode*, void> P_1, _ECallbackType P_2);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenApi_3_1_Basler_pylon_002ECNodeCallback_002E_007Bdtor_007D(CNodeCallback* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern GenericException* GenICam_3_1_Basler_pylon_002EGenericException_002E_007Bctor_007D(GenericException* P_0, sbyte* P_1, sbyte* P_2, uint P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern BadAllocException* GenICam_3_1_Basler_pylon_002EBadAllocException_002E_007Bctor_007D(BadAllocException* P_0, sbyte* P_1, sbyte* P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern LogicalErrorException* GenICam_3_1_Basler_pylon_002ELogicalErrorException_002E_007Bctor_007D(LogicalErrorException* P_0, sbyte* P_1, sbyte* P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern GenICam_3_1_Basler_pylon.TimeoutException* GenICam_3_1_Basler_pylon_002ETimeoutException_002E_007Bctor_007D(GenICam_3_1_Basler_pylon.TimeoutException* P_0, sbyte* P_1, sbyte* P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern InvalidArgumentException* GenICam_3_1_Basler_pylon_002EInvalidArgumentException_002E_007Bctor_007D(InvalidArgumentException* P_0, sbyte* P_1, sbyte* P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern OutOfRangeException* GenICam_3_1_Basler_pylon_002EOutOfRangeException_002E_007Bctor_007D(OutOfRangeException* P_0, sbyte* P_1, sbyte* P_2, int P_3);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void GenApi_3_1_Basler_pylon_002EDeregister(int P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImagePersistence_002ELoad(gcstring* P_0, IReusableImage* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImagePersistence_002ESave(EImageFileFormat P_0, gcstring* P_1, Pylon.IImage* P_2, CImagePersistenceOptions* P_3);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECImagePersistence_002ESave(EImageFileFormat P_0, gcstring* P_1, void* P_2, uint P_3, EPixelType P_4, uint P_5, uint P_6, uint P_7, EImageOrientation P_8, CImagePersistenceOptions* P_9);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern HWND__* Pylon_002ECPylonImageWindow_002EGetWindowHandle(CPylonImageWindow* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002ECPylonImageWindow_002EDetach(CPylonImageWindow* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonImageWindow_002EShow(CPylonImageWindow* P_0, int P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Basler_002EPylon_002EGetImageWindowCatID();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECPylonImageWindow_002EClose(CPylonImageWindow* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonImageWindow_002EAttach(CPylonImageWindow* P_0, uint P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECPylonImageWindow_002E_007Bdtor_007D(CPylonImageWindow* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CPylonImageWindow* Pylon_002ECPylonImageWindow_002E_007Bctor_007D(CPylonImageWindow* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002EDisplayImage(uint P_0, Pylon.IImage* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern gcstring_vector* GenICam_3_1_Basler_pylon_002Egcstring_vector_002E_007Bctor_007D(gcstring_vector* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void GenICam_3_1_Basler_pylon_002Egcstring_vector_002Edelete(void* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* GenICam_3_1_Basler_pylon_002Egcstring_vector_002Enew(uint P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlInfo* Pylon_002ECTlInfo_002E_007Bctor_007D(CTlInfo* P_0, CTlInfo* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlInfo* std_002Eauto_ptr_003CPylon_003A_003ACTlInfo_003E_002Erelease(auto_ptr_003CPylon_003A_003ACTlInfo_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eauto_ptr_003CPylon_003A_003ACTlInfo_003E_002E_007Bdtor_007D(auto_ptr_003CPylon_003A_003ACTlInfo_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern auto_ptr_003CPylon_003A_003ACTlInfo_003E* std_002Eauto_ptr_003CPylon_003A_003ACTlInfo_003E_002E_007Bctor_007D(auto_ptr_003CPylon_003A_003ACTlInfo_003E* P_0, CTlInfo* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool GenICam_3_1_Basler_pylon_002Egcstring_002E_003D_003D(gcstring* P_0, gcstring* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlInfo* Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Econst_iterator_002E_002A(TList_003CPylon_003A_003ACTlInfo_003E.const_iterator* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern TList_003CPylon_003A_003ACTlInfo_003E.const_iterator* Pylon_002ETList_003CPylon_003A_003ACTlInfo_003E_002Econst_iterator_002E_002B_002B(TList_003CPylon_003A_003ACTlInfo_003E.const_iterator* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern uint Pylon_002EVersionInfo_002EgetBuild(VersionInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern VersionInfo* Pylon_002EVersionInfo_002E_007Bctor_007D(VersionInfo* P_0, [MarshalAs(UnmanagedType.U1)] bool P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ESetProperty(int P_0, void* P_1, uint P_2);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EBitDepth(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EGetPixelIncrementY(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EGetPixelIncrementX(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsFloatingPoint(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EHasAlpha(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsColorImage(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsMonoImage(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsMono(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsBayer(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsBGR(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsBGRA(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsRGB(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsRGBA(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsYUV(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern EPixelColorFilter Pylon_002EGetPixelColorFilter(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsPlanar(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern EPixelType Pylon_002EGetPlanePixelType(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern uint Pylon_002EPlaneCount(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsPackedInLsbFormat(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsBGRPacked(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsRGBPacked(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsBayerPacked(EPixelType P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002EIsMonoPacked(EPixelType P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPixelType Pylon_002ECPixelTypeMapper_002EGetPylonPixelTypeByName(sbyte* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void ReleaseSRWLockShared(_RTL_SRWLOCK* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void AcquireSRWLockShared(_RTL_SRWLOCK* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void Pylon_002EPylonTerminate([MarshalAs(UnmanagedType.U1)] bool P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void ReleaseSRWLockExclusive(_RTL_SRWLOCK* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void Pylon_002EPylonInitialize();

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void AcquireSRWLockExclusive(_RTL_SRWLOCK* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void InitializeSRWLock(_RTL_SRWLOCK* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern VersionInfo* Pylon_002EVersionInfo_002E_007Bctor_007D(VersionInfo* P_0, uint P_1, uint P_2, uint P_3);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bctor_007D(basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_0, basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNativeBufferFactory* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Erelease(unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CNativeBufferFactory* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002Eget(unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bdtor_007D(unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* std_002Eunique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_002C0_003E(unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* P_0, CNativeBufferFactory* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool std_002Eoperator_003D_003D_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstruct_0020std_003A_003Adefault_delete_003Cclass_0020Basler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E(void* P_0, unique_ptr_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_002Cstd_003A_003Adefault_delete_003CBasler_003A_003APylon_003A_003ACNativeBufferFactory_003E_0020_003E* P_1);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static extern bool Pylon_002ECInstantCamera_002ERetrieveResult(CInstantCamera* P_0, uint P_1, CGrabResultPtr* P_2, ETimeoutHandling P_3);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void Pylon_002ECTlInfo_002E_007Bdtor_007D(CTlInfo* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CTlInfo* Pylon_002ECTlInfo_002E_007Bctor_007D(CTlInfo* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern byte* std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002Eget(unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bdtor_007D(unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_003D(unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_0, unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_003E(unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_0, void* P_1);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* std_002Eunique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E_002E_007Bctor_007D_003Cunsigned_0020char_0020_002A_002Cstruct_0020std_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_002C0_002Cvoid_003E(unique_ptr_003Cunsigned_0020char_0020_005B0_005D_002Cstd_003A_003Adefault_delete_003Cunsigned_0020char_0020_005B0_005D_003E_0020_003E* P_0, byte* P_1);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern EPixelType Pylon_002ECPixelTypeMapper_002EGetPylonPixelTypeByName(gcstring* P_0);

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CAviWriter* Pylon_002ECAviWriter_002E_007Bctor_007D(CAviWriter* P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool Pylon_002ECVideoWriter_002EIsSupported();

	[DllImport("", CallingConvention = CallingConvention.ThisCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern CVideoWriter* Pylon_002ECVideoWriter_002E_007Bctor_007D(CVideoWriter* P_0);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int DuplicateHandle(void* P_0, void* P_1, void* P_2, void** P_3, uint P_4, int P_5, uint P_6);

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* GetCurrentProcess();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern int __FrameUnwindFilter(_EXCEPTION_POINTERS* P_0);

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal unsafe static extern void* _getFiberPtrId();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void _cexit();

	[DllImport("", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void Sleep(uint P_0);

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void abort();

	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void __security_init_cookie();

	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged, MethodCodeType = MethodCodeType.Native)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern void terminate();
}
