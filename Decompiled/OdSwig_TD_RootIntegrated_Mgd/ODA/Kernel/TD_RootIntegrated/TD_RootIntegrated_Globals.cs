using System;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class TD_RootIntegrated_Globals
{
	public delegate bool GripWorldDrawPtrDelegate(OdDbGripData pThis, OdGiWorldDraw pWd, OdDbStub entId, OdDbGripOperations_DrawType type, OdGePoint3d imageGripPoint, double dGripSize);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate bool GripWorldDrawPtrDelegateNative(IntPtr pThis, IntPtr pWd, IntPtr entId, OdDbGripOperations_DrawType type, IntPtr imageGripPoint, double dGripSize);

	public delegate void GripViewportDrawPtrDelegate(OdDbGripData pThis, OdGiViewportDraw pWd, OdDbStub entId, OdDbGripOperations_DrawType type, OdGePoint3d imageGripPoint, int gripSize);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GripViewportDrawPtrDelegateNative(IntPtr pThis, IntPtr pWd, IntPtr entId, OdDbGripOperations_DrawType type, IntPtr imageGripPoint, int gripSize);

	public delegate void GripOpStatusPtrDelegate(OdDbGripData pThis, OdDbStub entId, OdDbGripOperations_GripStatus status);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GripOpStatusPtrDelegateNative(IntPtr pThis, IntPtr entId, OdDbGripOperations_GripStatus status);

	public delegate OdResult GripOperationPtrDelegate(OdDbGripData pThis, OdDbStub entId, int iContextFlags);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate OdResult GripOperationPtrDelegateNative(IntPtr pThis, IntPtr entId, int iContextFlags);

	public delegate void PgetLocalTimeDelegate(OdTimeStamp _parameter);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void PgetLocalTimeDelegateNative(IntPtr _parameter);

	public delegate string GripToolTipPtrDelegate(OdDbGripData pThis);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr GripToolTipPtrDelegateNative(IntPtr pThis);

	public delegate void ContextMenuItemIndexPtrDelegate(uint itemIndex);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ContextMenuItemIndexPtrDelegateNative(uint itemIndex);

	public delegate OdResult GripRtClkHandlerDelegate(OdDbGripDataArray hotGrips, OdDbStubPtrArray ents, ref string menuName, ref IntPtr menu, ref ContextMenuItemIndexPtrDelegate cb);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate OdResult GripRtClkHandlerDelegateNative(IntPtr hotGrips, IntPtr ents, IntPtr menuName, ref IntPtr menu, ref ContextMenuItemIndexPtrDelegateNative cb);

	public delegate void OdEdCommandFunctionDelegate(OdEdCommandContext pCmdCtx);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdEdCommandFunctionDelegateNative(IntPtr pCmdCtx);

	public delegate void ODAUDITINFO_CALLBACKDelegate(OdAuditInfo info);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ODAUDITINFO_CALLBACKDelegateNative(IntPtr info);

	public delegate void ODRXOBJECT_CALLBACKDelegate(OdRxObject obj);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ODRXOBJECT_CALLBACKDelegateNative(IntPtr obj);

	public delegate OdRxObject OdPseudoConstructorTypeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr OdPseudoConstructorTypeDelegateNative();

	public delegate void OdAssertFuncDelegate(string expresssion, string filename, int nLineNo);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdAssertFuncDelegateNative(string expresssion, string filename, int nLineNo);

	public delegate bool OdCheckAssertGroupFuncDelegate(string group);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate bool OdCheckAssertGroupFuncDelegateNative(string group);

	public delegate void OdTraceFuncDelegate(string debugString);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdTraceFuncDelegateNative(IntPtr debugString);

	public delegate void ODDBHYPERLINK_CALLBACKDelegate(OdDbHyperlink obj);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ODDBHYPERLINK_CALLBACKDelegateNative(IntPtr obj);

	public delegate OdRxModule StaticModuleEntryPointDelegate(string szModuleName);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr StaticModuleEntryPointDelegateNative(IntPtr szModuleName);

	public delegate void MainThreadFuncDelegate(IntPtr arg1);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void MainThreadFuncDelegateNative(IntPtr arg1);

	public delegate void ExecuteMainThreadFuncDelegate(MainThreadFuncDelegate _func, IntPtr _arg);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ExecuteMainThreadFuncDelegateNative(MainThreadFuncDelegateNative _func, IntPtr _arg);

	public delegate void AppNameChangeFuncPtrDelegate(OdRxClass classObj, ref string newAppName, int saveVer);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void AppNameChangeFuncPtrDelegateNative(IntPtr classObj, IntPtr newAppName, int saveVer);

	public delegate OdRxPropertyBase FindPropertyCallbackDelegate(OdRxObject pObject, string pszPropName);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr FindPropertyCallbackDelegateNative(IntPtr pObject, IntPtr pszPropName);

	public delegate bool ConvertValueCallbackDelegate(OdRxPropertyBase pProperty, OdRxValue value);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate bool ConvertValueCallbackDelegateNative(IntPtr pProperty, IntPtr value);

	public delegate void OdApcEntryPointVoidParamDelegate(IntPtr _parameter);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdApcEntryPointVoidParamDelegateNative(IntPtr _parameter);

	public delegate void OdApcEntryPointRxObjParamDelegate(OdRxObject parameter_);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdApcEntryPointRxObjParamDelegateNative(IntPtr parameter_);

	public delegate void UpdateManagerProcessCallbackDelegate(OdGsUpdateManager_Action action, uint viewportId, OdDbStub drawableId, OdGsEntityNode pNode, OdGsUpdateManager.OdGsUpdateManagerElement pElement);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void UpdateManagerProcessCallbackDelegateNative(OdGsUpdateManager_Action action, uint viewportId, IntPtr drawableId, IntPtr pNode, IntPtr pElement);

	public delegate void SetPtrFuncDelegate(IntPtr pPlace_, IntPtr pValue_);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SetPtrFuncDelegateNative(IntPtr pPlace_, IntPtr pValue_);

	public delegate void OdRxMemberCollectionConstructorPtrDelegate(OdRxMemberCollectionBuilder arg1, IntPtr arg2);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void OdRxMemberCollectionConstructorPtrDelegateNative(IntPtr arg1, IntPtr arg2);

	public delegate int PrintConsoleInsideFuncDelegate(string sArg);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public delegate int PrintConsoleInsideFuncDelegateNative(IntPtr sArg);

	public delegate OdGeVector3d OdGiCalculateNormalCallbackDelegate(OdGiShellToolkit pToolkit, uint nVertexIndex);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr OdGiCalculateNormalCallbackDelegateNative(IntPtr pToolkit, uint nVertexIndex);

	public delegate OdGiDrawable OdGiOpenDrawableFnDelegate(OdDbStub id);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr OdGiOpenDrawableFnDelegateNative(IntPtr id);

	public delegate void SubstitutionActuator_SetPtrFuncDelegate(IntPtr pPlace_, IntPtr pValue_);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SubstitutionActuator_SetPtrFuncDelegateNative(IntPtr pPlace_, IntPtr pValue_);

	public static readonly uint UINT_MAX = TD_RootIntegrated_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = TD_RootIntegrated_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = TD_RootIntegrated_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = TD_RootIntegrated_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = TD_RootIntegrated_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = TD_RootIntegrated_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = TD_RootIntegrated_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = TD_RootIntegrated_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = TD_RootIntegrated_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = TD_RootIntegrated_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = TD_RootIntegrated_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = TD_RootIntegrated_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = TD_RootIntegrated_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public const int SEEK_SET = 0;

	public const int SEEK_CUR = 1;

	public const int SEEK_END = 2;

	public const int _WIN32_WINNT = 1281;

	public const double OdaPI = Math.PI;

	public const double OdaPI2 = Math.PI / 2.0;

	public const double OdaPI4 = Math.PI / 4.0;

	public const double Oda2PI = Math.PI * 2.0;

	public const int IMAGE_MAJOR_VER = 2;

	public const int IMAGE_MINOR_VER = 0;

	public const int IMAGE_CORRECTIVE_VER = 0;

	public const int IMAGE_INTERNAL_VER = 0;

	public const double INVALIDEXTENTS = 1E+20;

	public const int SCALAR_MIN = int.MinValue;

	public const int SCALAR_MAX = int.MaxValue;

	public const int kOdGiIncludeScores = 2;

	public const int kOdGiRawText = 4;

	public const int kOdGiIncludePenups = 8;

	public const int kOdGiDrawShape = 16;

	public const int kOdGiIgnoreMIF = 32;

	public const int kOdGiLastPosOnly = 64;

	public const int kForMTextExtents = 128;

	public const uint kOdDbIdAllBits = uint.MaxValue;

	public const int kOdDbIdModified = 1;

	public const int kOdDbIdErased = 2;

	public const int kOdDbIdProcessed = 4;

	public const int kOdDbIdLoading = 8;

	public const int kOdDbIdTruncXref = 16;

	public const int kOdDbIdOwned = 32;

	public const int kOdDbIdReferenced = 64;

	public const int kOdDbIdJustAppended = 128;

	public const int kOdDbIdUserMask = 255;

	public const int kErasedPermanently = 268435456;

	public const int kObjectLeftOnDisk = 536870912;

	public const int kObjectSameOnDisk = 1073741824;

	public const uint kObjectPageOnDisk = 2147483648u;

	public const int kOdDbIdMapping = 16777216;

	public const int kOdDbIdMapFlag = 33554432;

	public const int kOdDbIdMapOwnerXlated = 67108864;

	public const int kOdDbIdMapCloned = 134217728;

	public const int kOdDbIdMapPrimary = 4096;

	public const int kOdDbIdMapMask = 234885120;

	public const int kOdDbIdMappingMask = 251662336;

	public const int kOdDbIdRedirected = 256;

	public const int kOdDbIdNoAutoLock = 512;

	public const int kOdDbObjectLocked = 1024;

	public const int kComposeForLoadCalled = 2048;

	public const int kOdDatabaseFlag = 1048576;

	public const int kOdDbIdBlkChgIterFlag = 2097152;

	public const int kOdDbIdNdxUpdtDataFlag = 4194304;

	public const int kOdDbIdSingleAuxData = 8388608;

	public const int kOdDbIdIndexData = 65536;

	public const int kOdDbIdMappingData = 131072;

	public const int kOdDbIdPaging = 262144;

	public const int kOdDbNullTransResident = 524288;

	public const double SKIP_RATIO = 0.00035;

	public const int POINTS_LIMIT = 7500;

	public const int lit_ = 32;

	public const int lit_0 = 48;

	public const int lit_1 = 49;

	public const int lit_2 = 50;

	public const int lit_3 = 51;

	public const int lit_4 = 52;

	public const int lit_5 = 53;

	public const int lit_6 = 54;

	public const int lit_7 = 55;

	public const int lit_8 = 56;

	public const int lit_9 = 57;

	public const int lit_A = 65;

	public const int lit_B = 66;

	public const int lit_C = 67;

	public const int lit_D = 68;

	public const int lit_E = 69;

	public const int lit_F = 70;

	public const int lit_G = 71;

	public const int lit_H = 72;

	public const int lit_I = 73;

	public const int lit_J = 74;

	public const int lit_K = 75;

	public const int lit_L = 76;

	public const int lit_M = 77;

	public const int lit_N = 78;

	public const int lit_O = 79;

	public const int lit_P = 80;

	public const int lit_Q = 81;

	public const int lit_R = 82;

	public const int lit_S = 83;

	public const int lit_T = 84;

	public const int lit_U = 85;

	public const int lit_V = 86;

	public const int lit_W = 87;

	public const int lit_X = 88;

	public const int lit_Y = 89;

	public const int lit_Z = 90;

	public const int lit_a = 97;

	public const int lit_b = 98;

	public const int lit_c = 99;

	public const int lit_d = 100;

	public const int lit_e = 101;

	public const int lit_f = 102;

	public const int lit_g = 103;

	public const int lit_h = 104;

	public const int lit_i = 105;

	public const int lit_j = 106;

	public const int lit_k = 107;

	public const int lit_l = 108;

	public const int lit_m = 109;

	public const int lit_n = 110;

	public const int lit_o = 111;

	public const int lit_p = 112;

	public const int lit_q = 113;

	public const int lit_r = 114;

	public const int lit_s = 115;

	public const int lit_t = 116;

	public const int lit_u = 117;

	public const int lit_v = 118;

	public const int lit_w = 119;

	public const int lit_x = 120;

	public const int lit_y = 121;

	public const int lit_z = 122;

	public const string ODRX_STATIC_MODULE_PATH = "";

	public const string ABSTREAM_BINARY = "ACIS BinaryFile";

	public const string ABSTREAM_BINARY_ASM = "ASM BinaryFile4";

	public const int AB_TYPE_LENGTH = 15;

	public const int WRITING_BUFFER_LENGTH = 8192;

	public const int ENABLE_GENERATION_TYPEMAP_MODULE_DICTIONARY = 1;

	public static double kMmPerInch
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.kMmPerInch_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static PgetLocalTimeDelegate g_pLocalTimeFunc
	{
		get
		{
			IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.g_pLocalTimeFunc_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			PgetLocalTimeDelegate result = null;
			if (nativeCallback != IntPtr.Zero)
			{
				result = delegate(OdTimeStamp _parameter)
				{
					(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(PgetLocalTimeDelegateNative)) as PgetLocalTimeDelegateNative)(OdMarshalHelper.ObjectToPtr<OdTimeStamp>(_parameter));
				};
			}
			return result;
		}
		set
		{
			PgetLocalTimeDelegateNative pgetLocalTimeDelegateNative = null;
			if (value != null)
			{
				pgetLocalTimeDelegateNative = delegate(IntPtr _parameter)
				{
					value(OdMarshalHelper.PtrToObject<OdTimeStamp>(_parameter));
				};
			}
			IntPtr jarg = ((pgetLocalTimeDelegateNative == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(pgetLocalTimeDelegateNative));
			DelegateHolder.Add(pgetLocalTimeDelegateNative);
			TD_RootIntegrated_GlobalsPINVOKE.g_pLocalTimeFunc_set(jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public static int nOdVariantDataSize
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.nOdVariantDataSize_get();
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static void throw_native_exception_string(string msg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		TD_RootIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		TD_RootIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		TD_RootIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool OdPositive(double x, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPositive__SWIG_0(x, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdPositive(double x)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdPositive__SWIG_1(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdNegative(double x, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdNegative__SWIG_0(x, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdNegative(double x)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdNegative__SWIG_1(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdZero(double x, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdZero__SWIG_0(x, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdZero(double x)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdZero__SWIG_1(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdNonZero(double x, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdNonZero__SWIG_0(x, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdNonZero(double x)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdNonZero__SWIG_1(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdEqual(double x, double y, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdEqual__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdEqual(double x, double y)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdEqual__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdLess(double x, double y, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdLess__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdLess(double x, double y)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdLess__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdLessOrEqual(double x, double y, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdLessOrEqual__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdLessOrEqual(double x, double y)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdLessOrEqual__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdGreater(double x, double y, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGreater__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdGreater(double x, double y)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGreater__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdGreaterOrEqual(double x, double y, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGreaterOrEqual__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdGreaterOrEqual(double x, double y)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGreaterOrEqual__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double OdSign(double x)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdSign__SWIG_0(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdSign(int x)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdSign__SWIG_1(x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdCmpDouble(double x, double y, double tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmpDouble__SWIG_0(x, y, tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdCmpDouble(double x, double y)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCmpDouble__SWIG_1(x, y);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double safeDivide(double a, double b)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.safeDivide(a, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void DeleteVariant(IntPtr jarg1)
	{
		TD_RootIntegrated_GlobalsPINVOKE.DeleteVariant(jarg1);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odDbRootInitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odDbRootInitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odDbRootUninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odDbRootUninitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgiInitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiInitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgiUninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiUninitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgsInitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgsInitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgsUninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgsUninitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdRxObject odrxCreateObject(string sClassName)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.odrxCreateObject(sClassName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void odrxRegisterDestructorCallback(ODRXOBJECT_CALLBACKDelegate callbackFunc)
	{
		ODRXOBJECT_CALLBACKDelegateNative oDRXOBJECT_CALLBACKDelegateNative = null;
		if (callbackFunc != null)
		{
			oDRXOBJECT_CALLBACKDelegateNative = delegate(IntPtr obj)
			{
				callbackFunc(OdMarshalHelper.PtrToObject<OdRxObject>(obj));
			};
		}
		IntPtr jarg = ((callbackFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(oDRXOBJECT_CALLBACKDelegateNative));
		DelegateHolder.Add(oDRXOBJECT_CALLBACKDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.odrxRegisterDestructorCallback(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odrxUnregisterDestructorCallback()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odrxUnregisterDestructorCallback();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgeHeapCleanup()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgeHeapCleanup();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGe_ErrorCondition geValidSolid(OdGePoint3dArray points, out bool isValid, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geValidSolid__SWIG_0(OdGePoint3dArray.getCPtr(points), out isValid, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geValidSolid(OdGePoint3dArray points, out bool isValid)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geValidSolid__SWIG_1(OdGePoint3dArray.getCPtr(points), out isValid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geSolidSignedVolume(OdGePoint3dArray points, out double volume, OdGePoint3d basePoint)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geSolidSignedVolume(OdGePoint3dArray.getCPtr(points), out volume, OdGePoint3d.getCPtr(basePoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculateNormal(OdGePoint3dArray points, OdGeVector3d pNormal, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculateNormal__SWIG_0(OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(pNormal), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculateNormal(OdGePoint3dArray points, OdGeVector3d pNormal)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculateNormal__SWIG_1(OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculateNormal(OdGePoint3d[] points, OdGeVector3d pNormal, OdGeTol tol)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(points);
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculateNormal__SWIG_2(intPtr, OdGeVector3d.getCPtr(pNormal), OdGeTol.getCPtr(tol));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGe_ErrorCondition)result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdGe_ErrorCondition geCalculateNormal(OdGePoint3d[] points, OdGeVector3d pNormal)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(points);
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculateNormal__SWIG_3(intPtr, OdGeVector3d.getCPtr(pNormal));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGe_ErrorCondition)result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3dArray points, OdGePlane plane, OdGeTol tol, bool validateCoplanar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_0(OdGePoint3dArray.getCPtr(points), OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol), validateCoplanar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3dArray points, OdGePlane plane, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_1(OdGePoint3dArray.getCPtr(points), OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3dArray points, OdGePlane plane)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_2(OdGePoint3dArray.getCPtr(points), OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3d[] points, OdGePlane plane, OdGeTol tol, bool validateCoplanar)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(points);
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_3(intPtr, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol), validateCoplanar);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGe_ErrorCondition)result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3d[] points, OdGePlane plane, OdGeTol tol)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(points);
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_4(intPtr, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGe_ErrorCondition)result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGePoint3d[] points, OdGePlane plane)
	{
		IntPtr intPtr = Helpers.MarshalPoint3dArray(points);
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_5(intPtr, OdGePlane.getCPtr(plane));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGe_ErrorCondition)result;
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, uint numCurves, OdGePlane plane, OdGeTol tol, bool validateCoplanar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_6(curves, numCurves, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol), validateCoplanar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, uint numCurves, OdGePlane plane, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_7(curves, numCurves, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, uint numCurves, OdGePlane plane)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_8(curves, numCurves, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, bool reverseFlags, uint numCurves, OdGePlane plane, OdGeTol tol, bool validateCoplanar)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_9(curves, reverseFlags, numCurves, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol), validateCoplanar);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, bool reverseFlags, uint numCurves, OdGePlane plane, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_10(curves, reverseFlags, numCurves, OdGePlane.getCPtr(plane), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static OdGe_ErrorCondition geCalculatePlane(OdGeCurve3d[] curves, bool reverseFlags, uint numCurves, OdGePlane plane)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geCalculatePlane__SWIG_11(curves, reverseFlags, numCurves, OdGePlane.getCPtr(plane));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGe_ErrorCondition)result;
	}

	public static bool geNurb3dTo2d(OdGeNurbCurve3d nurb3d, OdGePlane plane, OdGeNurbCurve2d nurb2d, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.geNurb3dTo2d__SWIG_0(OdGeNurbCurve3d.getCPtr(nurb3d), OdGePlane.getCPtr(plane), OdGeNurbCurve2d.getCPtr(nurb2d), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool geNurb3dTo2d(OdGeNurbCurve3d nurb3d, OdGePlane plane, OdGeNurbCurve2d nurb2d)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.geNurb3dTo2d__SWIG_1(OdGeNurbCurve3d.getCPtr(nurb3d), OdGePlane.getCPtr(plane), OdGeNurbCurve2d.getCPtr(nurb2d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool geSurfaceProp(OdGeSurface pS, out OdGe_NurbSurfaceProperties propU, out OdGe_NurbSurfaceProperties propV, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.geSurfaceProp(OdGeSurface.getCPtr(pS), out propU, out propV, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string geToString(OdGe_EntityId val)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.geToString((int)val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult geIsDir2dOnSurfCoincide3d(OdGeSurface pSurf, OdGeCurve3d pCurve, OdGeCurve2d pParamCurve, out bool isCoincide, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geIsDir2dOnSurfCoincide3d__SWIG_0(OdGeSurface.getCPtr(pSurf), OdGeCurve3d.getCPtr(pCurve), OdGeCurve2d.getCPtr(pParamCurve), out isCoincide, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult geIsDir2dOnSurfCoincide3d(OdGeSurface pSurf, OdGeCurve3d pCurve, OdGeCurve2d pParamCurve, out bool isCoincide)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.geIsDir2dOnSurfCoincide3d__SWIG_1(OdGeSurface.getCPtr(pSurf), OdGeCurve3d.getCPtr(pCurve), OdGeCurve2d.getCPtr(pParamCurve), out isCoincide);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static double getSignedArea(OdGePoint2dArray arrPoints)
	{
		double signedArea = TD_RootIntegrated_GlobalsPINVOKE.getSignedArea(OdGePoint2dArray.getCPtr(arrPoints).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return signedArea;
	}

	public static bool isPolygonOutOfRect2d(uint numPt, OdGePoint2d pPoints, OdGePoint2d minPt, OdGePoint2d maxPt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.isPolygonOutOfRect2d(numPt, OdGePoint2d.getCPtr(pPoints), OdGePoint2d.getCPtr(minPt), OdGePoint2d.getCPtr(maxPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void GE_ERROR(OdResult res)
	{
		TD_RootIntegrated_GlobalsPINVOKE.GE_ERROR((int)res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGeVector2d Mul(OdGeMatrix2d xfm, OdGeVector2d vect)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_0(OdGeMatrix2d.getCPtr(xfm), OdGeVector2d.getCPtr(vect).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeVector2d Mul(double scale, OdGeVector2d vector)
	{
		OdGeVector2d result = new OdGeVector2d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_1(scale, OdGeVector2d.getCPtr(vector).Handle), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGePoint2d Mul(OdGeMatrix2d matrix, OdGePoint2d point)
	{
		OdGePoint2d result = new OdGePoint2d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_2(OdGeMatrix2d.getCPtr(matrix), OdGePoint2d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeVector3d Mul(OdGeMatrix3d matrix, OdGeVector3d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_3(OdGeMatrix3d.getCPtr(matrix), OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeVector3d Mul(double scale, OdGeVector3d vect)
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_4(scale, OdGeVector3d.getCPtr(vect)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGePoint3d Mul(OdGeMatrix3d matrix, OdGePoint3d point)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_5(OdGeMatrix3d.getCPtr(matrix), OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGePoint3d Mul(double scale, OdGePoint3d point)
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_6(scale, OdGePoint3d.getCPtr(point)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double OdRound(double a)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdRound(a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdRoundToLong(double a)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRoundToLong(a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdTruncateToLong(double a)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdTruncateToLong(a);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odrxGetErrorDescriptionLiteral(OdError err)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.odrxGetErrorDescriptionLiteral(OdError.getCPtr(err));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odDToStr(string dst, double val, char fmt, int prec, int cropzeros)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odDToStr__SWIG_0(dst, val, fmt, prec, cropzeros);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odDToStr(string dst, double val, char fmt, int prec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odDToStr__SWIG_1(dst, val, fmt, prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string odDToStr(double val, char fmt, int prec, int cropzeros)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.odDToStr__SWIG_2(val, fmt, prec, cropzeros);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDToStr(double val, char fmt, int prec)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.odDToStr__SWIG_3(val, fmt, prec);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int getHexValue(int hexDigit)
	{
		int hexValue = TD_RootIntegrated_GlobalsPINVOKE.getHexValue(hexDigit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return hexValue;
	}

	public static void odgiImageViewport(ref OdGiViewportGeometry pGeom, OdGiRasterImage pImage, OdGePoint3d pBoundary, bool bFilter, double brightness, double contrast, double fade)
	{
		IntPtr jarg = ((pGeom == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pGeom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.odgiImageViewport__SWIG_0(ref jarg, OdGiRasterImage.getCPtr(pImage), OdGePoint3d.getCPtr(pBoundary), bFilter, brightness, contrast, fade);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeom = null;
			}
			if (jarg != intPtr)
			{
				pGeom = Helpers.GetRXObject<OdGiViewportGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odgiImageViewport(ref OdGiViewportGeometry pGeom, OdGiRasterImage pImage, OdGePoint3d pBoundary, bool bFilter, double brightness, double contrast)
	{
		IntPtr jarg = ((pGeom == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pGeom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.odgiImageViewport__SWIG_1(ref jarg, OdGiRasterImage.getCPtr(pImage), OdGePoint3d.getCPtr(pBoundary), bFilter, brightness, contrast);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeom = null;
			}
			if (jarg != intPtr)
			{
				pGeom = Helpers.GetRXObject<OdGiViewportGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odgiImageViewport(ref OdGiViewportGeometry pGeom, OdGiRasterImage pImage, OdGePoint3d pBoundary, bool bFilter, double brightness)
	{
		IntPtr jarg = ((pGeom == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pGeom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.odgiImageViewport__SWIG_2(ref jarg, OdGiRasterImage.getCPtr(pImage), OdGePoint3d.getCPtr(pBoundary), bFilter, brightness);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeom = null;
			}
			if (jarg != intPtr)
			{
				pGeom = Helpers.GetRXObject<OdGiViewportGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odgiImageViewport(ref OdGiViewportGeometry pGeom, OdGiRasterImage pImage, OdGePoint3d pBoundary, bool bFilter)
	{
		IntPtr jarg = ((pGeom == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pGeom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.odgiImageViewport__SWIG_3(ref jarg, OdGiRasterImage.getCPtr(pImage), OdGePoint3d.getCPtr(pBoundary), bFilter);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeom = null;
			}
			if (jarg != intPtr)
			{
				pGeom = Helpers.GetRXObject<OdGiViewportGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odgiImageViewport(ref OdGiViewportGeometry pGeom, OdGiRasterImage pImage, OdGePoint3d pBoundary)
	{
		IntPtr jarg = ((pGeom == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pGeom).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.odgiImageViewport__SWIG_4(ref jarg, OdGiRasterImage.getCPtr(pImage), OdGePoint3d.getCPtr(pBoundary));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeom = null;
			}
			if (jarg != intPtr)
			{
				pGeom = Helpers.GetRXObject<OdGiViewportGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdRxDictionary odrxSysRegistry()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxSysRegistry(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary odrxClassDictionary()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxClassDictionary(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass odrxGetClassDesc(string className)
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.odrxGetClassDesc(className), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass odrxSafeGetClassDesc(string className)
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.odrxSafeGetClassDesc(className), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary odrxServiceDictionary()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxServiceDictionary(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary odrxCreateRxDictionary()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxCreateRxDictionary(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary odrxCreateSyncRxDictionary()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxCreateSyncRxDictionary(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary odrxCreateSharedRxDictionary()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.odrxCreateSharedRxDictionary(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDoubleArray odgiGetAllDeviations(OdGiDeviation deviationObj, OdGePoint3d pointOnCurve)
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.odgiGetAllDeviations__SWIG_0(deviationObj.GetInterfaceCPtr(), OdGePoint3d.getCPtr(pointOnCurve)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDoubleArray odgiGetAllDeviations(OdGiDeviation deviationObj)
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.odgiGetAllDeviations__SWIG_1(deviationObj.GetInterfaceCPtr()), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxObject baseDatabaseBy(OdDbStub id)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.baseDatabaseBy(OdDbStub.getCPtr(id)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void addBaseDatabaseByResolver(OdBaseDatabaseByResolver pResolver)
	{
		TD_RootIntegrated_GlobalsPINVOKE.addBaseDatabaseByResolver(OdBaseDatabaseByResolver.getCPtr(pResolver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void removeBaseDatabaseByResolver(OdBaseDatabaseByResolver pResolver)
	{
		TD_RootIntegrated_GlobalsPINVOKE.removeBaseDatabaseByResolver(OdBaseDatabaseByResolver.getCPtr(pResolver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool odgiIsValidClipBoundary(OdGePoint2dArray points)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odgiIsValidClipBoundary(OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odgiEmptyClipBoundary(OdGiClipBoundary clipBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiEmptyClipBoundary(OdGiClipBoundary.getCPtr(clipBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static ThreadsCounter odThreadsCounter()
	{
		ThreadsCounter result = new ThreadsCounter(TD_RootIntegrated_GlobalsPINVOKE.odThreadsCounter(), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odExecuteMainThreadAction(MainThreadFuncDelegate mtFunc, IntPtr pArg, bool bExecST)
	{
		MainThreadFuncDelegateNative mainThreadFuncDelegateNative = null;
		if (mtFunc != null)
		{
			mainThreadFuncDelegateNative = delegate(IntPtr arg1)
			{
				mtFunc(arg1);
			};
		}
		IntPtr jarg = ((mtFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mainThreadFuncDelegateNative));
		DelegateHolder.Add(mainThreadFuncDelegateNative);
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odExecuteMainThreadAction__SWIG_0(jarg, pArg, bExecST);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odExecuteMainThreadAction(MainThreadFuncDelegate mtFunc, IntPtr pArg)
	{
		MainThreadFuncDelegateNative mainThreadFuncDelegateNative = null;
		if (mtFunc != null)
		{
			mainThreadFuncDelegateNative = delegate(IntPtr arg1)
			{
				mtFunc(arg1);
			};
		}
		IntPtr jarg = ((mtFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mainThreadFuncDelegateNative));
		DelegateHolder.Add(mainThreadFuncDelegateNative);
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odExecuteMainThreadAction__SWIG_1(jarg, pArg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odGetCurrentThreadId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odGetCurrentThreadId();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odThreadYield()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odThreadYield();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isInvalid(ViewPropsArray props)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.isInvalid(ViewPropsArray.getCPtr(props));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool sameSortedArrays(OdDbStubPtrArray ar1, OdDbStubPtrArray ar2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.sameSortedArrays(OdDbStubPtrArray.getCPtr(ar1), OdDbStubPtrArray.getCPtr(ar2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double calcFocalLength(double lensLength, double fieldWidth, double fieldHeight)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.calcFocalLength(lensLength, fieldWidth, fieldHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odgiCalculateTextBasis(OdGeVector3d u, OdGeVector3d v, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, bool bMirrorX, bool bMirrorY)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiCalculateTextBasis__SWIG_0(OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, bMirrorX, bMirrorY);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgiCalculateTextBasis(OdGeVector3d u, OdGeVector3d v, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique, bool bMirrorX)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiCalculateTextBasis__SWIG_1(OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique, bMirrorX);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgiCalculateTextBasis(OdGeVector3d u, OdGeVector3d v, OdGeVector3d normal, OdGeVector3d direction, double height, double width, double oblique)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiCalculateTextBasis__SWIG_2(OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), OdGeVector3d.getCPtr(normal), OdGeVector3d.getCPtr(direction), height, width, oblique);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiTextStyle odgiPrepareTextStyle(OdGiTextStyle pStyle, OdGiTextStyle res)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odgiPrepareTextStyle(OdGiTextStyle.getCPtr(pStyle), OdGiTextStyle.getCPtr(res));
		OdGiTextStyle result = ((intPtr == IntPtr.Zero) ? null : new OdGiTextStyle(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odgiGetTextExtentsCacheCapacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odgiGetTextExtentsCacheCapacity();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odgiSetTextExtentsCacheCapacity(uint size)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiSetTextExtentsCacheCapacity(size);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void pointsExtents(OdGePoint2d minPt, OdGePoint2d maxPt, OdGePoint2d pt1, OdGePoint2d pt2)
	{
		TD_RootIntegrated_GlobalsPINVOKE.pointsExtents(OdGePoint2d.getCPtr(minPt), OdGePoint2d.getCPtr(maxPt), OdGePoint2d.getCPtr(pt1), OdGePoint2d.getCPtr(pt2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool extendExtents(out double minValue, out double maxValue, double value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.extendExtents__SWIG_0(out minValue, out maxValue, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool extendExtents(OdGePoint2d minPt, OdGePoint2d maxPt, OdGePoint2d pt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.extendExtents__SWIG_1(OdGePoint2d.getCPtr(minPt), OdGePoint2d.getCPtr(maxPt), OdGePoint2d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isBoxContainsPoint(OdGePoint2d minPt, OdGePoint2d maxPt, OdGePoint2d pt, OdGeTol tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.isBoxContainsPoint__SWIG_0(OdGePoint2d.getCPtr(minPt), OdGePoint2d.getCPtr(maxPt), OdGePoint2d.getCPtr(pt), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isBoxContainsPoint(OdGePoint2d minPt, OdGePoint2d maxPt, OdGePoint2d pt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.isBoxContainsPoint__SWIG_1(OdGePoint2d.getCPtr(minPt), OdGePoint2d.getCPtr(maxPt), OdGePoint2d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void addLocalHeaps(uint nThreadId, uint aThreadId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.addLocalHeaps(nThreadId, aThreadId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void releaseLocalHeaps(uint nThreadId, uint aThreadId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.releaseLocalHeaps(nThreadId, aThreadId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiColorRGB Add(OdGiColorRGB c1, OdGiColorRGB c2)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Add__SWIG_0(OdGiColorRGB.getCPtr(c1), OdGiColorRGB.getCPtr(c2)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Add(OdGiColorRGB c, double s)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Add__SWIG_1(OdGiColorRGB.getCPtr(c), s), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Add(double s, OdGiColorRGB c)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Add__SWIG_2(s, OdGiColorRGB.getCPtr(c)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Sub(OdGiColorRGB c1, OdGiColorRGB c2)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Sub__SWIG_0(OdGiColorRGB.getCPtr(c1), OdGiColorRGB.getCPtr(c2)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Sub(OdGiColorRGB c, double s)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Sub__SWIG_1(OdGiColorRGB.getCPtr(c), s), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Sub(double s, OdGiColorRGB c)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Sub__SWIG_2(s, OdGiColorRGB.getCPtr(c)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Mul(OdGiColorRGB c1, OdGiColorRGB c2)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_7(OdGiColorRGB.getCPtr(c1), OdGiColorRGB.getCPtr(c2)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Mul(OdGiColorRGB c, double s)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_8(OdGiColorRGB.getCPtr(c), s), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Mul(double s, OdGiColorRGB c)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Mul__SWIG_9(s, OdGiColorRGB.getCPtr(c)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Div(OdGiColorRGB c1, OdGiColorRGB c2)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Div__SWIG_0(OdGiColorRGB.getCPtr(c1), OdGiColorRGB.getCPtr(c2)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Div(OdGiColorRGB c, double s)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Div__SWIG_1(OdGiColorRGB.getCPtr(c), s), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiColorRGB Div(double s, OdGiColorRGB c)
	{
		OdGiColorRGB result = new OdGiColorRGB(TD_RootIntegrated_GlobalsPINVOKE.Div__SWIG_2(s, OdGiColorRGB.getCPtr(c)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdSi_properExtents(OdGeExtents3d ext)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSi_properExtents(OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxSystemServices odrxSystemServices()
	{
		OdRxSystemServices result = new OdRxSystemServices(TD_RootIntegrated_GlobalsPINVOKE.odrxSystemServices(), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxDynamicLinker odrxDynamicLinker()
	{
		OdRxDynamicLinker rXObject = Helpers.GetRXObject<OdRxDynamicLinker>(TD_RootIntegrated_GlobalsPINVOKE.odrxDynamicLinker(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxModule odrxLoadApp(string applicationName)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.odrxLoadApp(applicationName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxModule odrxSafeLoadApp(string applicationName)
	{
		OdRxModule rXObject = Helpers.GetRXObject<OdRxModule>(TD_RootIntegrated_GlobalsPINVOKE.odrxSafeLoadApp(applicationName), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static double OdGeEllipArc_calibrateAngle(double val, double input)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc_calibrateAngle(val, input);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double OdGeEllipArc_angleFromParam(double param, double radiusRatio)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc_angleFromParam(param, radiusRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double OdGeEllipArc_paramFromAngle(double angle, double radiusRatio)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeEllipArc_paramFromAngle(angle, radiusRatio);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void OdGeDrawSegmentHatch(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol, OdArray_OdGeStrokeData_OdObjectsAllocator pStrokeData, OdGeShellData pShell, bool bIncludeBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatch__SWIG_0(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol), OdArray_OdGeStrokeData_OdObjectsAllocator.getCPtr(pStrokeData), OdGeShellData.getCPtr(pShell), bIncludeBoundary);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatch(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol, OdArray_OdGeStrokeData_OdObjectsAllocator pStrokeData, OdGeShellData pShell)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatch__SWIG_1(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol), OdArray_OdGeStrokeData_OdObjectsAllocator.getCPtr(pStrokeData), OdGeShellData.getCPtr(pShell));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatch(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol, OdArray_OdGeStrokeData_OdObjectsAllocator pStrokeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatch__SWIG_2(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol), OdArray_OdGeStrokeData_OdObjectsAllocator.getCPtr(pStrokeData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatch(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatch__SWIG_3(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatch(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatch__SWIG_4(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatchXY(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol, OdArray_OdGeStrokeData_OdObjectsAllocator pStrokeData, OdGeShellData pShell)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatchXY__SWIG_0(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol), OdArray_OdGeStrokeData_OdObjectsAllocator.getCPtr(pStrokeData), OdGeShellData.getCPtr(pShell));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatchXY(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol, OdArray_OdGeStrokeData_OdObjectsAllocator pStrokeData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatchXY__SWIG_1(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol), OdArray_OdGeStrokeData_OdObjectsAllocator.getCPtr(pStrokeData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatchXY(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes, OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatchXY__SWIG_2(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdGeDrawSegmentHatchXY(OdGeLineSeg2dArray segments, OdIntArray loops, OdIntArray loopTypes, OdGeHatchStrokes StrokeParams, OdGeIslandStyle iStyle, bool isSolid, OdGeLineSeg2dArray strokes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGeDrawSegmentHatchXY__SWIG_3(OdGeLineSeg2dArray.getCPtr(segments), OdIntArray.getCPtr(loops).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeHatchStrokes.getCPtr(StrokeParams), (int)iStyle, isSolid, OdGeLineSeg2dArray.getCPtr(strokes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult build2dShell(OdGePoint2dArrayArray contours, short style, OdGePoint2dArray vertixes, OdInt32Array indexes, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.build2dShell(OdGePoint2dArrayArray.getCPtr(contours), style, OdGePoint2dArray.getCPtr(vertixes).Handle, OdInt32Array.getCPtr(indexes).Handle, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult odgeDrawDashedHatch(OdHatchPattern pattern, OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, OdGeTol hatchTolerance, OdGeIslandStyle islandStyle, uint maxHatchDensity, OdGeHatchDashTaker dashTaker, bool bCheckDense, bool bIncludeBoundary)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.odgeDrawDashedHatch__SWIG_0(OdHatchPattern.getCPtr(pattern), OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeTol.getCPtr(hatchTolerance), (int)islandStyle, maxHatchDensity, OdGeHatchDashTaker.getCPtr(dashTaker), bCheckDense, bIncludeBoundary);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult odgeDrawDashedHatch(OdHatchPattern pattern, OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, OdGeTol hatchTolerance, OdGeIslandStyle islandStyle, uint maxHatchDensity, OdGeHatchDashTaker dashTaker, bool bCheckDense)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.odgeDrawDashedHatch__SWIG_1(OdHatchPattern.getCPtr(pattern), OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeTol.getCPtr(hatchTolerance), (int)islandStyle, maxHatchDensity, OdGeHatchDashTaker.getCPtr(dashTaker), bCheckDense);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult odgeDrawDashedHatch(OdHatchPattern pattern, OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, OdGeTol hatchTolerance, OdGeIslandStyle islandStyle, uint maxHatchDensity, OdGeHatchDashTaker dashTaker)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.odgeDrawDashedHatch__SWIG_2(OdHatchPattern.getCPtr(pattern), OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, OdGeTol.getCPtr(hatchTolerance), (int)islandStyle, maxHatchDensity, OdGeHatchDashTaker.getCPtr(dashTaker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void fillSegmentLoopLtArrays(OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, GiLoopListCustom loopListCustom, OdGeVector2d vOffset, double dDeviation, uint pointLimit, short nHPSmooth, bool bGradientFill, bool bSolid, bool isEvaluateHatchArea, bool isRegionCreate)
	{
		TD_RootIntegrated_GlobalsPINVOKE.fillSegmentLoopLtArrays__SWIG_0(OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, GiLoopListCustom.getCPtr(loopListCustom), OdGeVector2d.getCPtr(vOffset), dDeviation, pointLimit, nHPSmooth, bGradientFill, bSolid, isEvaluateHatchArea, isRegionCreate);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void fillSegmentLoopLtArrays(OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, GiLoopListCustom loopListCustom, OdGeVector2d vOffset, double dDeviation, uint pointLimit, short nHPSmooth, bool bGradientFill, bool bSolid, bool isEvaluateHatchArea)
	{
		TD_RootIntegrated_GlobalsPINVOKE.fillSegmentLoopLtArrays__SWIG_1(OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, GiLoopListCustom.getCPtr(loopListCustom), OdGeVector2d.getCPtr(vOffset), dDeviation, pointLimit, nHPSmooth, bGradientFill, bSolid, isEvaluateHatchArea);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void fillSegmentLoopLtArrays(OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdIntArray loopTypes, GiLoopListCustom loopListCustom, OdGeVector2d vOffset, double dDeviation, uint pointLimit, short nHPSmooth, bool bGradientFill, bool bSolid)
	{
		TD_RootIntegrated_GlobalsPINVOKE.fillSegmentLoopLtArrays__SWIG_2(OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdIntArray.getCPtr(loopTypes).Handle, GiLoopListCustom.getCPtr(loopListCustom), OdGeVector2d.getCPtr(vOffset), dDeviation, pointLimit, nHPSmooth, bGradientFill, bSolid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool processGradientHatch(ref OdGeShellData pShell, string gradName, double dShift, double dAngle, int r1, int g1, int b1, int r2, int g2, int b2)
	{
		IntPtr jarg = ((pShell == null) ? IntPtr.Zero : OdGeShellData.getCPtr(pShell).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.processGradientHatch(ref jarg, gradName, dShift, dAngle, r1, g1, b1, r2, g2, b2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pShell = null;
			}
			else if (jarg != intPtr)
			{
				pShell = Helpers.GetObject<OdGeShellData>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public static OdGeTol calculateEffectiveTolerance(OdGeLineSeg2dArray segments, double absTol, OdGeExtents2d ext)
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.calculateEffectiveTolerance__SWIG_0(OdGeLineSeg2dArray.getCPtr(segments), absTol, OdGeExtents2d.getCPtr(ext)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGeTol calculateEffectiveTolerance(OdGeExtents2d ext, double absTol)
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.calculateEffectiveTolerance__SWIG_1(OdGeExtents2d.getCPtr(ext), absTol), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double calculateDashTakerDeviation(OdGeExtents2d ext, double deviation)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.calculateDashTakerDeviation(OdGeExtents2d.getCPtr(ext), deviation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool checkDenstiy(OdGeLineSeg2dArray segmentArray, OdIntArray loopArray, OdHatchPattern hp, OdGeExtents2d ext, uint loopAmount, uint maxHatchDensity, bool isMPolygon, out bool bHatchTooDense)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.checkDenstiy(OdGeLineSeg2dArray.getCPtr(segmentArray), OdIntArray.getCPtr(loopArray).Handle, OdHatchPattern.getCPtr(hp), OdGeExtents2d.getCPtr(ext), loopAmount, maxHatchDensity, isMPolygon, out bHatchTooDense);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult evaluateDashedHatch(GiLoopListCustom giLoopList, OdHatchPattern hatchPattern, OdGeIslandStyle eHatchStyle, double dViewRotation, double dDeviation, uint loopAmount, uint pointLimit, uint maxHatchDensity, uint maxPointsToDraw, short nHPSmooth, bool bSolidFill, bool bGradientFill, bool isEvaluateHatchArea, bool isMPolygon, bool isDBRO, out bool bHatchTooDense, OdGeHatchDashTaker dashTaker, OdGeLineSeg2dArray segmentArrayOut, OdIntArray loopArrayOut, OdIntArray loopTypesOut, OdGeExtents2d ext2dOut, OdGeTol tol)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.evaluateDashedHatch(GiLoopListCustom.getCPtr(giLoopList), OdHatchPattern.getCPtr(hatchPattern), (int)eHatchStyle, dViewRotation, dDeviation, loopAmount, pointLimit, maxHatchDensity, maxPointsToDraw, nHPSmooth, bSolidFill, bGradientFill, isEvaluateHatchArea, isMPolygon, isDBRO, out bHatchTooDense, OdGeHatchDashTaker.getCPtr(dashTaker), OdGeLineSeg2dArray.getCPtr(segmentArrayOut), OdIntArray.getCPtr(loopArrayOut).Handle, OdIntArray.getCPtr(loopTypesOut).Handle, OdGeExtents2d.getCPtr(ext2dOut), OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static bool GeMesh_triangulateProfile(OdGePoint2dArray vertexSource, IntVectorStd inFaceData, OdLongArray vecTriangles, double tol)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_triangulateProfile__SWIG_0(OdGePoint2dArray.getCPtr(vertexSource).Handle, IntVectorStd.getCPtr(inFaceData), OdLongArray.getCPtr(vecTriangles), tol);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool GeMesh_triangulateProfile(OdGePoint2dArray vertexSource, IntVectorStd inFaceData, OdLongArray vecTriangles)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_triangulateProfile__SWIG_1(OdGePoint2dArray.getCPtr(vertexSource).Handle, IntVectorStd.getCPtr(inFaceData), OdLongArray.getCPtr(vecTriangles));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool GeMesh_compareMeshes(GeMesh_OdGeTrMesh meshTemplate, GeMesh_OdGeTrMesh mesh, double tolCoef, bool bDebugOutput)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.GeMesh_compareMeshes(GeMesh_OdGeTrMesh.getCPtr(meshTemplate), GeMesh_OdGeTrMesh.getCPtr(mesh), tolCoef, bDebugOutput);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxObject odgsDbGetDatabase(OdDbStub pId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.odgsDbGetDatabase(OdDbStub.getCPtr(pId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbStub odgsDbGetOwner(OdDbStub pId)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odgsDbGetOwner(OdDbStub.getCPtr(pId));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbStub odgsDbRedirectID(out OdDbStub pId)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odgsDbRedirectID(out jarg);
			OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			pId = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public static bool odgsDbObjectIDRedirected(OdDbStub pId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odgsDbObjectIDRedirected(OdDbStub.getCPtr(pId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odgsDbObjectIDSetRedirected(OdDbStub pId, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgsDbObjectIDSetRedirected(OdDbStub.getCPtr(pId), bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odgsDbObjectIDSetLockingFlag(OdDbStub pId, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgsDbObjectIDSetLockingFlag(OdDbStub.getCPtr(pId), bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdRxObject odgsDbObjectIDRedirectedDatabase(OdDbStub pId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.odgsDbObjectIDRedirectedDatabase(OdDbStub.getCPtr(pId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool odgsDbObjectIDErased(OdDbStub pId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odgsDbObjectIDErased(OdDbStub.getCPtr(pId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int lineWeightIndex(LineWeight lw)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.lineWeightIndex((int)lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static LineWeight lineWeightByIndex(int lw)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.lineWeightByIndex(lw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public static OdGiPsLinetypes odgiGetPsLinetypesManager(uint nDefs)
	{
		OdGiPsLinetypes result = new OdGiPsLinetypes(TD_RootIntegrated_GlobalsPINVOKE.odgiGetPsLinetypesManager__SWIG_0(nDefs), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPsLinetypes odgiGetPsLinetypesManager()
	{
		OdGiPsLinetypes result = new OdGiPsLinetypes(TD_RootIntegrated_GlobalsPINVOKE.odgiGetPsLinetypesManager__SWIG_1(), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPsFillstyles odgiGetPsFillstylesManager()
	{
		OdGiPsFillstyles result = new OdGiPsFillstyles(TD_RootIntegrated_GlobalsPINVOKE.odgiGetPsFillstylesManager(), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiTransientManager odgiGetTransientManager(OdRxObject pObject)
	{
		OdGiTransientManager rXObject = Helpers.GetRXObject<OdGiTransientManager>(TD_RootIntegrated_GlobalsPINVOKE.odgiGetTransientManager(OdRxObject.getCPtr(pObject)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void odgiSetTransientManager(OdGiTransientManager pManager, OdRxObject pObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odgiSetTransientManager(OdGiTransientManager.getCPtr(pManager), OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint odFNV32HashBuf(IntPtr buf, uint len, uint hval)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32HashBuf__SWIG_0(buf, len, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32HashBuf(IntPtr buf, uint len)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32HashBuf__SWIG_1(buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32HashStr(string str, uint hval)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32HashStr__SWIG_0(str, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32HashStr(string str)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32HashStr__SWIG_1(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32aHashBuf(IntPtr buf, uint len, uint hval)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32aHashBuf__SWIG_0(buf, len, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32aHashBuf(IntPtr buf, uint len)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32aHashBuf__SWIG_1(buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32aHashStr(string str, uint hval)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32aHashStr__SWIG_0(str, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odFNV32aHashStr(string str)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odFNV32aHashStr__SWIG_1(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64HashBuf(IntPtr buf, uint len, ulong hval)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64HashBuf__SWIG_0(buf, len, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64HashBuf(IntPtr buf, uint len)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64HashBuf__SWIG_1(buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64HashStr(string str, ulong hval)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64HashStr__SWIG_0(str, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64HashStr(string str)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64HashStr__SWIG_1(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64aHashBuf(IntPtr buf, uint len, ulong hval)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64aHashBuf__SWIG_0(buf, len, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64aHashBuf(IntPtr buf, uint len)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64aHashBuf__SWIG_1(buf, len);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64aHashStr(string str, ulong hval)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64aHashStr__SWIG_0(str, hval);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static ulong odFNV64aHashStr(string str)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.odFNV64aHashStr__SWIG_1(str);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odgiCalculateTriangleShellLoops(OdUInt32Array triangleIndicies, OdUInt32Array2d loops, OdBoolArray isClosed)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odgiCalculateTriangleShellLoops__SWIG_0(OdUInt32Array.getCPtr(triangleIndicies).Handle, OdUInt32Array2d.getCPtr(loops), OdBoolArray.getCPtr(isClosed).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odgiCalculateTriangleShellLoops(OdUInt32Array triangleIndicies, OdUInt32Array2d loops)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odgiCalculateTriangleShellLoops__SWIG_1(OdUInt32Array.getCPtr(triangleIndicies).Handle, OdUInt32Array2d.getCPtr(loops));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odrxRegisterHyperlinkDestructorCallback(ODDBHYPERLINK_CALLBACKDelegate callbackFunc)
	{
		ODDBHYPERLINK_CALLBACKDelegateNative oDDBHYPERLINK_CALLBACKDelegateNative = null;
		if (callbackFunc != null)
		{
			oDDBHYPERLINK_CALLBACKDelegateNative = delegate(IntPtr obj)
			{
				callbackFunc(OdMarshalHelper.PtrToObject<OdDbHyperlink>(obj));
			};
		}
		IntPtr jarg = ((callbackFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(oDDBHYPERLINK_CALLBACKDelegateNative));
		DelegateHolder.Add(oDDBHYPERLINK_CALLBACKDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.odrxRegisterHyperlinkDestructorCallback(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odrxUnregisterHyperlinkDestructorCallback()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odrxUnregisterHyperlinkDestructorCallback();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odrxRegisterAuditInfoDestructorCallback(ODAUDITINFO_CALLBACKDelegate callbackFunc)
	{
		ODAUDITINFO_CALLBACKDelegateNative oDAUDITINFO_CALLBACKDelegateNative = null;
		if (callbackFunc != null)
		{
			oDAUDITINFO_CALLBACKDelegateNative = delegate(IntPtr info)
			{
				callbackFunc(OdMarshalHelper.PtrToObject<OdAuditInfo>(info));
			};
		}
		IntPtr jarg = ((callbackFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(oDAUDITINFO_CALLBACKDelegateNative));
		DelegateHolder.Add(oDAUDITINFO_CALLBACKDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.odrxRegisterAuditInfoDestructorCallback(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odrxUnregisterAuditInfoDestructorCallback()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odrxUnregisterAuditInfoDestructorCallback();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string convertTextToCodePage(string source, OdCodePageId arg1, OdCodePageId arg2)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.convertTextToCodePage(source, (int)arg1, (int)arg2);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId mapCodepage(short cp)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.mapCodepage(cp);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public static short reMapCodepage(OdCodePageId id)
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.reMapCodepage((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isAsianCodepage(OdCodePageId codePage)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.isAsianCodepage((int)codePage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId GetCPageIdByName(string CodePage)
	{
		int cPageIdByName = TD_RootIntegrated_GlobalsPINVOKE.GetCPageIdByName(CodePage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)cPageIdByName;
	}

	public static string getCodePageStr(int index)
	{
		string codePageStr = TD_RootIntegrated_GlobalsPINVOKE.getCodePageStr(index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return codePageStr;
	}

	public static bool IsMultiByteCodePage(OdCodePageId id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.IsMultiByteCodePage((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string oddbConvertTextToCodePage(string source, OdCodePageId sourceId, OdCodePageId destId)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.oddbConvertTextToCodePage(source, (int)sourceId, (int)destId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static char checkSpecialSymbol(OdFont pFont, char sym, out bool isSpecSym)
	{
		char result = TD_RootIntegrated_GlobalsPINVOKE.checkSpecialSymbol(OdFont.getCPtr(pFont), sym, out isSpecSym);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odInitAsyncIOService(OdAsyncIORequestHandler pRequestHandler)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odInitAsyncIOService(OdAsyncIORequestHandler.getCPtr(pRequestHandler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdAsyncIOService odGetAsyncIOService()
	{
		OdAsyncIOService rXObject = Helpers.GetRXObject<OdAsyncIOService>(TD_RootIntegrated_GlobalsPINVOKE.odGetAsyncIOService(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void odUninitAsyncIOService()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odUninitAsyncIOService();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool odcmIsBackgroundLight(uint backgroung)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odcmIsBackgroundLight(backgroung);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint[] odcmAcadDarkPalette()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odcmAcadDarkPalette();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public static uint[] odcmAcadLightPalette()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odcmAcadLightPalette();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public static uint[] odcmAcadPlotPalette()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odcmAcadPlotPalette();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public static uint[] odcmAcadPalette(uint backgr)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odcmAcadPalette(backgr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public static uint[] odcmAcadDynamicPalette(uint background)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.odcmAcadDynamicPalette(background);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		int num = 257;
		int[] array = new int[num];
		Marshal.Copy(intPtr, array, 0, num);
		return Array.ConvertAll(array, (int in_value) => (uint)in_value);
	}

	public static uint odcmLookupRGB(int index, uint[] pPalette)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odcmLookupRGB(index, pPalette);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int odcmLookupACI(uint rgb, uint[] pPalette)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.odcmLookupACI(rgb, pPalette);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odutWcMatch(string string_, string wcPattern)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odutWcMatch__SWIG_0(string_, wcPattern);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odutWcMatchNoCase(string string_, string wcPattern)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odutWcMatchNoCase(string_, wcPattern);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odutWcMatch(string string_, string wcPattern, ref string remainString)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(remainString);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.odutWcMatch__SWIG_1(string_, wcPattern, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				remainString = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static bool odutWcReplace(string string_, string wcPatternOld, string wcPatternNew, ref string resultString)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(resultString);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.odutWcReplace(string_, wcPatternOld, wcPatternNew, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				resultString = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static void OdClearFontTable()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdClearFontTable();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint odrxMultiCast(OdRxObject pObject, ref OdRxObject pPointers, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointers == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointers).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCast(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointers = null;
			}
			else if (jarg != intPtr)
			{
				pPointers = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastObject(OdRxObject pObject, bool pCasts, OdRxClass pClasses, uint nClasses)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastObject(OdRxObject.getCPtr(pObject), pCasts, OdRxClass.getCPtr(pClasses).Handle, nClasses);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odrxMultiCastX(OdRxObject pObject, ref OdRxObject pPointers, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointers == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointers).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastX(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointers = null;
			}
			else if (jarg != intPtr)
			{
				pPointers = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwd_(OdRxClass pClass, OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwd_(OdRxClass.getCPtr(pClass), OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwd(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwd(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwdXPrior_(OdRxClass pClass, OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdXPrior_(OdRxClass.getCPtr(pClass), OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwdXPrior(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdXPrior(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwdObject_(OdRxClass pClass, OdRxObject pObject, OdRxClass pClasses, uint nClasses)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdObject_(OdRxClass.getCPtr(pClass), OdRxObject.getCPtr(pObject), OdRxClass.getCPtr(pClasses).Handle, nClasses);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odrxMultiCastFwdObject(OdRxObject pObject, OdRxClass pClasses, uint nClasses)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdObject(OdRxObject.getCPtr(pObject), OdRxClass.getCPtr(pClasses).Handle, nClasses);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odrxMultiCastFwdX_(OdRxClass pClass, OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdX_(OdRxClass.getCPtr(pClass), OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastFwdX(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastFwdX(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastBk(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastBk(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastBkXPrior(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastBkXPrior(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static uint odrxMultiCastBkObject(OdRxObject pObject, OdRxClass pClasses, uint nClasses)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastBkObject(OdRxObject.getCPtr(pObject), OdRxClass.getCPtr(pClasses).Handle, nClasses);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint odrxMultiCastBkX(OdRxObject pObject, ref OdRxObject pPointer, OdRxClass pClasses, uint nClasses)
	{
		IntPtr jarg = ((pPointer == null) ? IntPtr.Zero : OdRxObject.getCPtr(pPointer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.odrxMultiCastBkX(OdRxObject.getCPtr(pObject), ref jarg, OdRxClass.getCPtr(pClasses).Handle, nClasses);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPointer = null;
			}
			else if (jarg != intPtr)
			{
				pPointer = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool odrxInitialize(OdRxSystemServices pSysSvcs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.odrxInitialize(OdRxSystemServices.getCPtr(pSysSvcs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odrxUninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odrxUninitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odActivate(string userInfo, string userSignature)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odActivate(userInfo, userSignature);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odCleanUpStaticData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odCleanUpStaticData();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static int OdCharConverter_getMIFIndex(OdCodePageId id)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharConverter_getMIFIndex((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdCharConverter_isMBCBCodepage(OdCodePageId id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharConverter_isMBCBCodepage((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdCharConverter_isMIFCodepage(OdCodePageId id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdCharConverter_isMIFCodepage((int)id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdCodePageId OdCharConverter_checkTheSameCP(OdCodePageId cp)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdCharConverter_checkTheSameCP((int)cp);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public static OdError OdErrorByCodeAndMessage(OdResult iResCode, string iMessage)
	{
		OdError result = new OdError(TD_RootIntegrated_GlobalsPINVOKE.OdErrorByCodeAndMessage((int)iResCode, iMessage), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdError OdErrorByCodeAndMessageFormat(OdResult iResCode, string iMessageFormat)
	{
		OdError result = new OdError(TD_RootIntegrated_GlobalsPINVOKE.OdErrorByCodeAndMessageFormat((int)iResCode, iMessageFormat), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdEdCommandStack odedRegCmds()
	{
		OdEdCommandStack rXObject = Helpers.GetRXObject<OdEdCommandStack>(TD_RootIntegrated_GlobalsPINVOKE.odedRegCmds(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdTraceFuncDelegate odSetTraceFunc(OdTraceFuncDelegate traceFunc)
	{
		OdTraceFuncDelegateNative odTraceFuncDelegateNative = null;
		if (traceFunc != null)
		{
			odTraceFuncDelegateNative = delegate(IntPtr debugString)
			{
				traceFunc(Marshal.PtrToStringUni(debugString));
			};
		}
		IntPtr jarg = ((traceFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odTraceFuncDelegateNative));
		DelegateHolder.Add(odTraceFuncDelegateNative);
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.odSetTraceFunc(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		OdTraceFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(string debugString)
			{
				(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(OdTraceFuncDelegateNative)) as OdTraceFuncDelegateNative)(Marshal.StringToCoTaskMemUni(debugString));
			};
		}
		return result;
	}

	public static OdAssertFuncDelegate odSetAssertFunc(OdAssertFuncDelegate assertFunc)
	{
		OdAssertFuncDelegateNative odAssertFuncDelegateNative = null;
		if (assertFunc != null)
		{
			odAssertFuncDelegateNative = delegate(string expresssion, string filename, int nLineNo)
			{
				assertFunc(expresssion, filename, nLineNo);
			};
		}
		IntPtr jarg = ((assertFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odAssertFuncDelegateNative));
		DelegateHolder.Add(odAssertFuncDelegateNative);
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.odSetAssertFunc(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		OdAssertFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(string expresssion, string filename, int nLineNo)
			{
				(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(OdAssertFuncDelegateNative)) as OdAssertFuncDelegateNative)(expresssion, filename, nLineNo);
			};
		}
		return result;
	}

	public static OdCheckAssertGroupFuncDelegate odSetCheckAssertGroupFunc(OdCheckAssertGroupFuncDelegate checkFunc)
	{
		OdCheckAssertGroupFuncDelegateNative odCheckAssertGroupFuncDelegateNative = null;
		if (checkFunc != null)
		{
			odCheckAssertGroupFuncDelegateNative = (string group) => checkFunc(group);
		}
		IntPtr jarg = ((checkFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odCheckAssertGroupFuncDelegateNative));
		DelegateHolder.Add(odCheckAssertGroupFuncDelegateNative);
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.odSetCheckAssertGroupFunc(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		OdCheckAssertGroupFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (string group) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(OdCheckAssertGroupFuncDelegateNative)) as OdCheckAssertGroupFuncDelegateNative)(group);
		}
		return result;
	}

	public static void OdAssert(string expresssion, string filename, int nLineNo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAssert__SWIG_0(expresssion, filename, nLineNo);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdAssert(string group, string expresssion, string fileName, int nLineNo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdAssert__SWIG_1(group, expresssion, fileName, nLineNo);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odExSetPrintConsoleInsideFunc(PrintConsoleInsideFuncDelegate writeConsoleFunc)
	{
		PrintConsoleInsideFuncDelegateNative printConsoleInsideFuncDelegateNative = null;
		if (writeConsoleFunc != null)
		{
			printConsoleInsideFuncDelegateNative = (IntPtr sArg) => writeConsoleFunc(OdString2StringConvHelper.OdStringToString(sArg));
		}
		IntPtr jarg = ((writeConsoleFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(printConsoleInsideFuncDelegateNative));
		DelegateHolder.Add(printConsoleInsideFuncDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.odExSetPrintConsoleInsideFunc(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static PrintConsoleInsideFuncDelegate odExGetPrintConsoleInsideFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.odExGetPrintConsoleInsideFunc();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		PrintConsoleInsideFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (string sArg) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(PrintConsoleInsideFuncDelegateNative)) as PrintConsoleInsideFuncDelegateNative)(OdString2StringConvHelper.StringToOdString(sArg));
		}
		return result;
	}

	public static void odPrintConsoleString(string fmt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odPrintConsoleString(fmt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odPrintErrorString(string fmt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odPrintErrorString(fmt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool exTtfFileNameByDescriptor(OdTtfDescriptor descr, ref string fileName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(fileName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.exTtfFileNameByDescriptor(OdTtfDescriptor.getCPtr(descr), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				fileName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	internal static void Free_OdSmartPtrMemoryManagment()
	{
		TD_RootIntegrated_GlobalsPINVOKE.Free_OdSmartPtrMemoryManagment();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
