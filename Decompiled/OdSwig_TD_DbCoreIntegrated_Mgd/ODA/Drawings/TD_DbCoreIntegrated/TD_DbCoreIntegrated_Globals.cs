using System;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class TD_DbCoreIntegrated_Globals
{
	public struct OdGeVector3dValue
	{
		private double x;

		private double y;

		private double z;
	}

	public delegate OdGeVector3dValue DimDataSetCustomStringFuncPtrDelegate(OdDbDimData pThis, OdDbEntity pEnt, string sCustomString, OdGeVector3d offset);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate OdGeVector3dValue DimDataSetCustomStringFuncPtrDelegateNative(IntPtr pThis, IntPtr pEnt, IntPtr sCustomString, IntPtr offset);

	public delegate OdGeVector3dValue DimDataSetValueFuncPtrDelegate(OdDbDimData pThis, OdDbEntity pEnt, double newValue, OdGeVector3d offset);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate OdGeVector3dValue DimDataSetValueFuncPtrDelegateNative(IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset);

	public delegate int OdDbMTextEnumDelegate(OdDbMTextFragment _fragment, IntPtr ptr_arg);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int OdDbMTextEnumDelegateNative(IntPtr _fragment, IntPtr ptr_arg);

	public delegate void MainHistStreamFuncDelegate(IntPtr __arg);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void MainHistStreamFuncDelegateNative(IntPtr __arg);

	public delegate OdResBuf GetFnDelegate(OdDbDatabase pDb);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr GetFnDelegateNative(IntPtr pDb);

	public delegate void SetFnDelegate(OdDbDatabase pDb, OdResBuf pRbValue);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SetFnDelegateNative(IntPtr pDb, IntPtr pRbValue);

	public delegate void MapTypeFnDelegate(OdDbDatabase pDb, OdResBuf pVal, int opt);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void MapTypeFnDelegateNative(IntPtr pDb, IntPtr pVal, int opt);

	public delegate string FormatFnDelegate(OdDbDatabase pDbCmdCtx, OdResBuf pRbValue);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr FormatFnDelegateNative(IntPtr pDbCmdCtx, IntPtr pRbValue);

	public delegate void PromptFnDelegate(OdDbCommandContext pDbCmdCtx, string varName, OdResBuf pVal);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void PromptFnDelegateNative(IntPtr pDbCmdCtx, IntPtr varName, IntPtr pVal);

	public delegate string PreferableFontCallbackDelegate(string arg1, string arg2, bool arg3);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr PreferableFontCallbackDelegateNative(IntPtr arg1, IntPtr arg2, bool arg3);

	public static readonly uint UINT_MAX = TD_DbCoreIntegrated_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = TD_DbCoreIntegrated_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = TD_DbCoreIntegrated_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = TD_DbCoreIntegrated_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = TD_DbCoreIntegrated_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = TD_DbCoreIntegrated_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = TD_DbCoreIntegrated_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = TD_DbCoreIntegrated_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = TD_DbCoreIntegrated_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = TD_DbCoreIntegrated_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = TD_DbCoreIntegrated_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = TD_DbCoreIntegrated_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = TD_DbCoreIntegrated_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public const int DBL_DIG = 15;

	public const int SECURITYPARAMS_ENCRYPT_DATA = 1;

	public const int SECURITYPARAMS_ENCRYPT_PROPS = 2;

	public const int SECURITYPARAMS_SIGN_DATA = 16;

	public const int SECURITYPARAMS_ADD_TIMESTAMP = 32;

	public const int SECURITYPARAMS_ALGID_RC4 = 26625;

	public const int kOdDbDwgClassMapSize = 0;

	public const int kDwgId_OdDbProxyObject = 0;

	public const int kDwgId_OdDbProxyEntity = 1;

	public const int kDwgId_OdDbVertex = 2;

	public const int kDwgId_OdDbDimension = 3;

	public const int kOdDbDwgClassMapSize_WithProxy = 4;

	public const int HATCH_PATTERN_NAME_LENGTH = 32;

	public const int OD_DBLEOD_H = 1;

	public const double ODDB_INFINITE_XCLIP_DEPTH = 1E+300;

	public const int MSTYLE_DXF_FILL_ON = 1;

	public const int MSTYLE_DXF_SHOW_MITERS = 2;

	public const int MSTYLE_DXF_START_SQUARE_CAP = 16;

	public const int MSTYLE_DXF_START_INNER_ARCS = 32;

	public const int MSTYLE_DXF_START_ROUND_CAP = 64;

	public const int MSTYLE_DXF_END_SQUARE_CAP = 256;

	public const int MSTYLE_DXF_END_INNER_ARCS = 512;

	public const int MSTYLE_DXF_END_ROUND_CAP = 1024;

	public const int MSTYLE_DXF_JUST_TOP = 4096;

	public const int MSTYLE_DXF_JUST_ZERO = 8192;

	public const int MSTYLE_DXF_JUST_BOT = 16384;

	public const int ODA_ARRREAD_PAGESIZE = 65535;

	public const int ODA_IDREAD_PAGESIZE = 65535;

	public const int MAX_LEADER_NUMBER = 5000;

	public const int MAX_LEADERLINE_NUMBER = 5000;

	public const bool NullIdAllowed = true;

	public static uint kPlineVerticesThrehold
	{
		get
		{
			uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.kPlineVerticesThrehold_get();
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static double OdDbMPolygonCrossingFuzz
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMPolygonCrossingFuzz_get();
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public static void throw_native_exception_string(string msg)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdStreamBuf newUndoStream(OdDbBaseHostAppServices srv)
	{
		OdStreamBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.newUndoStream(OdDbBaseHostAppServices.getCPtr(srv)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbUndoController newUndoController(bool undoType, OdStreamBuf str)
	{
		OdDbUndoController rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUndoController>(TD_DbCoreIntegrated_GlobalsPINVOKE.newUndoController(undoType, OdStreamBuf.getCPtr(str)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool oddbCompareRbChains(OdResBuf pRb1, OdResBuf pRb2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbCompareRbChains(OdResBuf.getCPtr(pRb1), OdResBuf.getCPtr(pRb2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResBuf oddbEntGet(OdDbObject pObj, string regapps)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntGet__SWIG_0(OdDbObject.getCPtr(pObj), regapps), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf oddbEntGet(OdDbObject pObj)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntGet__SWIG_1(OdDbObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf oddbEntGet(OdDbObjectId id, string regapps)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntGet__SWIG_2(OdDbObjectId.getCPtr(id), regapps), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf oddbEntGet(OdDbObjectId id)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntGet__SWIG_3(OdDbObjectId.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult oddbEntMod(OdDbObject pObj, OdResBuf pRb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntMod__SWIG_0(OdDbObject.getCPtr(pObj), OdResBuf.getCPtr(pRb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEntMod(OdDbObjectId id, OdResBuf pRb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntMod__SWIG_1(OdDbObjectId.getCPtr(id), OdResBuf.getCPtr(pRb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdDbObjectId oddbEntNext(OdDbObjectId id, OdDbDatabase db)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntNext(OdDbObjectId.getCPtr(id), OdDbDatabase.getCPtr(db)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbEntLast(OdDbDatabase db)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntLast(OdDbDatabase.getCPtr(db)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult oddbEntMake(OdDbDatabase pDb, OdResBuf pRb, ref OdDbObject pObj)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntMake(OdDbDatabase.getCPtr(pDb), OdResBuf.getCPtr(pRb), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pObj = null;
			}
			else if (jarg != intPtr)
			{
				pObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult oddbEntMakeX(OdDbDatabase pDb, OdResBuf pRb, ref OdDbObject pObj)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEntMakeX(OdDbDatabase.getCPtr(pDb), OdResBuf.getCPtr(pRb), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pObj = null;
			}
			else if (jarg != intPtr)
			{
				pObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool oddbAddAnnotationScaleReactor(OdDbAnnotationScaleReactor pReactor)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAddAnnotationScaleReactor(OdDbAnnotationScaleReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool oddbRemoveAnnotationScaleReactor(OdDbAnnotationScaleReactor pReactor)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbRemoveAnnotationScaleReactor(OdDbAnnotationScaleReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxSystemServices odSystemServices()
	{
		OdRxSystemServices result = new OdRxSystemServices(TD_DbCoreIntegrated_GlobalsPINVOKE.odSystemServices(), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odInitializeDbCore(OdRxSystemServices pSystemServices)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odInitializeDbCore(OdRxSystemServices.getCPtr(pSystemServices));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odInitialize(OdRxSystemServices pSystemServices)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odInitialize(OdRxSystemServices.getCPtr(pSystemServices));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odUninitialize()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odUninitialize();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odUninitializeDbCore()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odUninitializeDbCore();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static uint getGapsAmount(OdDbDatabase pDb)
	{
		uint gapsAmount = TD_DbCoreIntegrated_GlobalsPINVOKE.getGapsAmount(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return gapsAmount;
	}

	public static OdRxClass getClassByName(OdDbDatabase pDb, string className)
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.getClassByName(OdDbDatabase.getCPtr(pDb), className), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult validateDrawingSignature(string drawingFullPath, out OdCryptoServices_OdSignatureVerificationResult verificationResult, OdSignatureDescription signatureDesc)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.validateDrawingSignature(drawingFullPath, out verificationResult, OdSignatureDescription.getCPtr(signatureDesc).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void odDbGetPreviewBitmap(OdStreamBuf pStreamBuf, OdThumbnailImage pPreview)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGetPreviewBitmap(OdStreamBuf.getCPtr(pStreamBuf), OdThumbnailImage.getCPtr(pPreview));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void odDbSetDWGCODEPAGE(ref OdDbDatabase db, OdCodePageId val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetDWGCODEPAGE(ref jarg, (int)val);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetTDUCREATE(ref OdDbDatabase db, OdDbDate val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetTDUCREATE(ref jarg, OdDbDate.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetTDUUPDATE(ref OdDbDatabase db, OdDbDate val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetTDUUPDATE(ref jarg, OdDbDate.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetTDINDWG(ref OdDbDatabase db, OdDbDate val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetTDINDWG(ref jarg, OdDbDate.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetTDUSRTIMER(ref OdDbDatabase db, OdDbDate val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetTDUSRTIMER(ref jarg, OdDbDate.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetPSTYLEMODE(ref OdDbDatabase db, bool val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetPSTYLEMODE(ref jarg, val);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetUCSORG(ref OdDbDatabase db, OdGePoint3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetUCSORG(ref jarg, OdGePoint3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetUCSXDIR(ref OdDbDatabase db, OdGeVector3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetUCSXDIR(ref jarg, OdGeVector3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetUCSYDIR(ref OdDbDatabase db, OdGeVector3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetUCSYDIR(ref jarg, OdGeVector3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetPUCSORG(ref OdDbDatabase db, OdGePoint3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetPUCSORG(ref jarg, OdGePoint3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetPUCSXDIR(ref OdDbDatabase db, OdGeVector3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetPUCSXDIR(ref jarg, OdGeVector3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSetPUCSYDIR(ref OdDbDatabase db, OdGeVector3d val)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSetPUCSYDIR(ref jarg, OdGeVector3d.getCPtr(val));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSaveLineTypeFile(ref OdDbDatabase Db, ref OdStreamBuf filename, OdDb_TextFileEncoding encode)
	{
		IntPtr jarg = ((Db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(Db).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((filename == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(filename).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSaveLineTypeFile__SWIG_0(ref jarg, ref jarg2, (int)encode);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				Db = null;
			}
			if (jarg != intPtr)
			{
				Db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				filename = null;
			}
			if (jarg2 != intPtr2)
			{
				filename = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSaveLineTypeFile(ref OdDbDatabase Db, ref OdStreamBuf filename)
	{
		IntPtr jarg = ((Db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(Db).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((filename == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(filename).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSaveLineTypeFile__SWIG_1(ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				Db = null;
			}
			if (jarg != intPtr)
			{
				Db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				filename = null;
			}
			if (jarg2 != intPtr2)
			{
				filename = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbLoadMlineStyleFile(ref OdDbDatabase db, string patternName, ref OdStreamBuf filename, OdDb_DuplicateLinetypeLoading dlt)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((filename == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(filename).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbLoadMlineStyleFile__SWIG_0(ref jarg, patternName, ref jarg2, (int)dlt);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				filename = null;
			}
			if (jarg2 != intPtr2)
			{
				filename = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbLoadMlineStyleFile(ref OdDbDatabase db, string patternName, ref OdStreamBuf filename)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((filename == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(filename).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbLoadMlineStyleFile__SWIG_1(ref jarg, patternName, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				filename = null;
			}
			if (jarg2 != intPtr2)
			{
				filename = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void odDbSaveMlineStyleFile(ref OdDbDatabase db, ref OdStreamBuf filename)
	{
		IntPtr jarg = ((db == null) ? IntPtr.Zero : OdDbDatabase.getCPtr(db).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((filename == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(filename).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.odDbSaveMlineStyleFile(ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				db = null;
			}
			if (jarg != intPtr)
			{
				db = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				filename = null;
			}
			if (jarg2 != intPtr2)
			{
				filename = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool oddbSetDbNotificationSuppression(OdDbDatabase pDb, bool bValue)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbSetDbNotificationSuppression(OdDbDatabase.getCPtr(pDb), bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDb_DwgVersionToStr(DwgVersion ver)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb_DwgVersionToStr((int)ver);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static DwgVersion OdDb_DwgVersionFromStr(string str)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb_DwgVersionFromStr(str);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public static OdDbDataLinkManager odDbGetDataLinkManager(OdDbDatabase db)
	{
		OdDbDataLinkManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataLinkManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGetDataLinkManager(OdDbDatabase.getCPtr(db)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static string odFileWasSavedByODASoftware(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odFileWasSavedByODASoftware(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odPreviousProductInfo(OdDbDatabase pDb, ref string pYear, ref string pLicense)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pYear);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(pLicense);
		IntPtr intPtr2 = jarg2;
		try
		{
			string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odPreviousProductInfo__SWIG_0(OdDbDatabase.getCPtr(pDb), ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pYear = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 != intPtr2)
			{
				pLicense = Marshal.PtrToStringUni(jarg2);
			}
		}
	}

	public static string odPreviousProductInfo(OdDbDatabase pDb, ref string pYear)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pYear);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odPreviousProductInfo__SWIG_1(OdDbDatabase.getCPtr(pDb), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pYear = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static string odPreviousProductInfo(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odPreviousProductInfo__SWIG_2(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass oddbDwgClassMapDesc(ushort nDwgType)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbDwgClassMapDesc(nDwgType);
		OdRxClass result = ((intPtr == IntPtr.Zero) ? null : new OdRxClass(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult oddbGetObjectMesh(OdDbObject pObj, MeshFaceterSettings faceter, OdGePoint3dArray vertexArray, OdInt32Array faceArray, out OdGiFaceData faceData)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetObjectMesh(OdDbObject.getCPtr(pObj), MeshFaceterSettings.getCPtr(faceter), OdGePoint3dArray.getCPtr(vertexArray).Handle, OdInt32Array.getCPtr(faceArray).Handle, out jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGiFaceData>(typeof(OdGiFaceData), jarg, bIsWrapperOwnNativeObject: true));
			faceData = ODA.Kernel.TD_RootIntegrated.Helpers.odCreateObjectInternal<OdGiFaceData>(typeof(OdGiFaceData), jarg, currentTransaction == null);
		}
	}

	public static void giFromDbTextStyle(OdDbTextStyleTableRecord pTStyle, OdGiTextStyle giStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.giFromDbTextStyle__SWIG_0(OdDbTextStyleTableRecord.getCPtr(pTStyle), OdGiTextStyle.getCPtr(giStyle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void giFromDbTextStyle(OdDbObjectId styleId, OdGiTextStyle giStyle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.giFromDbTextStyle__SWIG_1(OdDbObjectId.getCPtr(styleId), OdGiTextStyle.getCPtr(giStyle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiTextStyle giTextStyleFromDb(OdDbTextStyleTableRecord pTStyle)
	{
		OdGiTextStyle result = new OdGiTextStyle(TD_DbCoreIntegrated_GlobalsPINVOKE.giTextStyleFromDb__SWIG_0(OdDbTextStyleTableRecord.getCPtr(pTStyle)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiTextStyle giTextStyleFromDb(OdDbObjectId styleId)
	{
		OdGiTextStyle result = new OdGiTextStyle(TD_DbCoreIntegrated_GlobalsPINVOKE.giTextStyleFromDb__SWIG_1(OdDbObjectId.getCPtr(styleId)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbField copyTextFieldToObject(OdDbField srcField, OdDbObject pObj)
	{
		OdDbField rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(TD_DbCoreIntegrated_GlobalsPINVOKE.copyTextFieldToObject(OdDbField.getCPtr(srcField), OdDbObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbField copyFieldWithChild(OdDbField srcField, bool addToDb)
	{
		OdDbField rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(TD_DbCoreIntegrated_GlobalsPINVOKE.copyFieldWithChild__SWIG_0(OdDbField.getCPtr(srcField), addToDb), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbField copyFieldWithChild(OdDbField srcField)
	{
		OdDbField rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbField>(TD_DbCoreIntegrated_GlobalsPINVOKE.copyFieldWithChild__SWIG_1(OdDbField.getCPtr(srcField)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult OdDbSymUtil_repairPreExtendedSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar, char symSubst, bool insertPrefix)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairPreExtendedSymbolName__SWIG_0(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar, symSubst, insertPrefix);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairPreExtendedSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar, char symSubst)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairPreExtendedSymbolName__SWIG_1(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar, symSubst);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairPreExtendedSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairPreExtendedSymbolName__SWIG_2(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairPreExtendedSymbolName(ref string newName, string oldName, OdDbDatabase pDb)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairPreExtendedSymbolName__SWIG_3(ref jarg, oldName, OdDbDatabase.getCPtr(pDb));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar, char symSubst, bool insertPrefix)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairSymbolName__SWIG_0(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar, symSubst, insertPrefix);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar, char symSubst)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairSymbolName__SWIG_1(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar, symSubst);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairSymbolName(ref string newName, string oldName, OdDbDatabase pDb, bool allowVerticalBar)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairSymbolName__SWIG_2(ref jarg, oldName, OdDbDatabase.getCPtr(pDb), allowVerticalBar);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_repairSymbolName(ref string newName, string oldName, OdDbDatabase pDb)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(newName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_repairSymbolName__SWIG_3(ref jarg, oldName, OdDbDatabase.getCPtr(pDb));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				newName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult OdDbSymUtil_validatePreExtendedSymbolName(string name, OdDbDatabase pDb, bool allowVerticalBar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_validatePreExtendedSymbolName__SWIG_0(name, OdDbDatabase.getCPtr(pDb), allowVerticalBar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult OdDbSymUtil_validatePreExtendedSymbolName(string name, OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_validatePreExtendedSymbolName__SWIG_1(name, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult OdDbSymUtil_validateSymbolName(string name, OdDbDatabase pDb, bool allowVerticalBar)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_validateSymbolName__SWIG_0(name, OdDbDatabase.getCPtr(pDb), allowVerticalBar);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult OdDbSymUtil_validateSymbolName(string name, OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_validateSymbolName__SWIG_1(name, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static bool OdDbSymUtil_getMaxSymbolNameLength(out uint maxLength, out uint maxSize, bool isNewName, bool compatibilityMode)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getMaxSymbolNameLength(out maxLength, out maxSize, isNewName, compatibilityMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_getSymbolName(OdDbObjectId objId)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getSymbolName(OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getViewportId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getViewportId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getBlockId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getBlockId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getDimStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getDimStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getLayerId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getLayerId__SWIG_0(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getLinetypeId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getLinetypeId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getRegAppId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getRegAppId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getTextStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getTextStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getUCSId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getUCSId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getViewId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getViewId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getPlotstyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getPlotstyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getMLStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getMLStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getTableStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getTableStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getMLeaderStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getMLeaderStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getVisualStyleId(string name, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getVisualStyleId(name, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_linetypeByLayerName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_linetypeByLayerName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isLinetypeByLayerName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isLinetypeByLayerName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_linetypeByBlockName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_linetypeByBlockName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isLinetypeByBlockName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isLinetypeByBlockName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_linetypeContinuousName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_linetypeContinuousName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isLinetypeContinuousName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isLinetypeContinuousName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_layerZeroName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_layerZeroName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isLayerZeroName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isLayerZeroName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_layerDefpointsName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_layerDefpointsName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isLayerDefpointsName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isLayerDefpointsName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_textStyleStandardName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_textStyleStandardName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_MLineStyleStandardName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_MLineStyleStandardName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isMLineStandardName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isMLineStandardName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_dimStyleStandardName(MeasurementValue measurement)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_dimStyleStandardName((int)measurement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_viewportActiveName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_viewportActiveName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isViewportActiveName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isViewportActiveName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isTextStyleStandardName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isTextStyleStandardName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_textStyleStandardId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_textStyleStandardId(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_dimStyleStandardId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_dimStyleStandardId(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_MLineStyleStandardId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_MLineStyleStandardId(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDbSymUtil_getLayerId(OdDbDatabase pDb, string strLayer)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_getLayerId__SWIG_1(OdDbDatabase.getCPtr(pDb), strLayer), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_blockModelSpaceName(DwgVersion version)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_blockModelSpaceName__SWIG_0((int)version);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_blockModelSpaceName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_blockModelSpaceName__SWIG_1();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isBlockModelSpaceName(string pN, DwgVersion version)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isBlockModelSpaceName__SWIG_0(pN, (int)version);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isBlockModelSpaceName(string pN)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isBlockModelSpaceName__SWIG_1(pN);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_blockPaperSpaceName(DwgVersion version)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_blockPaperSpaceName__SWIG_0((int)version);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_blockPaperSpaceName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_blockPaperSpaceName__SWIG_1();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isBlockPaperSpaceName(string pN, DwgVersion version)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isBlockPaperSpaceName__SWIG_0(pN, (int)version);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isBlockPaperSpaceName(string pN)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isBlockPaperSpaceName__SWIG_1(pN);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isKindOfBlockPaperSpaceName(string pN, DwgVersion version)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isKindOfBlockPaperSpaceName__SWIG_0(pN, (int)version);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isKindOfBlockPaperSpaceName(string pN)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isKindOfBlockPaperSpaceName__SWIG_1(pN);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_plotStyleNormalName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_plotStyleNormalName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_TableStyleStandardName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_TableStyleStandardName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isTableStandardName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isTableStandardName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_MLeaderStyleStandardName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_MLeaderStyleStandardName();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isMLeaderStandardName(string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isMLeaderStandardName(name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_DetailViewStyleStandardName(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_DetailViewStyleStandardName(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isDetailViewStyleStandardName(OdDbDatabase pDb, string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isDetailViewStyleStandardName(OdDbDatabase.getCPtr(pDb), name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDbSymUtil_SectionViewStyleStandardName(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_SectionViewStyleStandardName(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbSymUtil_isSectionViewStyleStandardName(OdDbDatabase pDb, string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSymUtil_isSectionViewStyleStandardName(OdDbDatabase.getCPtr(pDb), name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimfit(int dimatfit, int dimtmove)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimfit(dimatfit, dimtmove);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimunit(int dimlunit, int dimfrac)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimunit(dimlunit, dimfrac);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimatfit(int dimfit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimatfit(dimfit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimtmove(int dimfit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimtmove(dimfit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimlunit(int dimunit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimlunit(dimunit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static int OdDmUtil_dimfrac(int dimunit)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_dimfrac(dimunit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string OdDmUtil_arrowName(OdDbObjectId blockId)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_arrowName(OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDmUtil_isBuiltInArrow(string arrowheadName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_isBuiltInArrow(arrowheadName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDmUtil_isZeroLengthArrow(string arrowheadName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_isZeroLengthArrow(arrowheadName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDmUtil_findArrowId(string arrowheadName, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_findArrowId(arrowheadName, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId OdDmUtil_getArrowId(string arrowheadName, OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDmUtil_getArrowId(arrowheadName, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void decompTransform(OdGeVector3d normal, OdGePoint3d position, OdGeScale3d scale, out double rotationAngle, OdGeMatrix3d transformMat, OdDbBlockTableRecord pBlockTableRecord)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.decompTransform(OdGeVector3d.getCPtr(normal), OdGePoint3d.getCPtr(position).Handle, OdGeScale3d.getCPtr(scale), out rotationAngle, OdGeMatrix3d.getCPtr(transformMat), OdDbBlockTableRecord.getCPtr(pBlockTableRecord));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbIndexFilterManager_updateIndexes(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_updateIndexes(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbIndexFilterManager_addIndex(OdDbBlockTableRecord pBTR, OdDbIndex pIndex)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_addIndex(OdDbBlockTableRecord.getCPtr(pBTR), OdDbIndex.getCPtr(pIndex));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbIndexFilterManager_removeIndex(OdDbBlockTableRecord pBTR, OdRxClass key)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_removeIndex(OdDbBlockTableRecord.getCPtr(pBTR), OdRxClass.getCPtr(key));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbIndex OdDbIndexFilterManager_getIndex(OdDbBlockTableRecord pBTR, OdRxClass key, OdDb_OpenMode readOrWrite)
	{
		OdDbIndex rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIndex>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getIndex__SWIG_0(OdDbBlockTableRecord.getCPtr(pBTR), OdRxClass.getCPtr(key), (int)readOrWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbIndex OdDbIndexFilterManager_getIndex(OdDbBlockTableRecord pBTR, OdRxClass key)
	{
		OdDbIndex rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIndex>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getIndex__SWIG_1(OdDbBlockTableRecord.getCPtr(pBTR), OdRxClass.getCPtr(key)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbIndex OdDbIndexFilterManager_getIndex(OdDbBlockTableRecord pBTR, int btrIndex, OdDb_OpenMode readOrWrite)
	{
		OdDbIndex rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIndex>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getIndex__SWIG_2(OdDbBlockTableRecord.getCPtr(pBTR), btrIndex, (int)readOrWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbIndex OdDbIndexFilterManager_getIndex(OdDbBlockTableRecord pBTR, int btrIndex)
	{
		OdDbIndex rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIndex>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getIndex__SWIG_3(OdDbBlockTableRecord.getCPtr(pBTR), btrIndex), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static int OdDbIndexFilterManager_numIndexes(OdDbBlockTableRecord pBTR)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_numIndexes(OdDbBlockTableRecord.getCPtr(pBTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void OdDbIndexFilterManager_addFilter(OdDbBlockReference pBlkRef, OdDbFilter pFilter)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_addFilter(OdDbBlockReference.getCPtr(pBlkRef), OdDbFilter.getCPtr(pFilter));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbIndexFilterManager_removeFilter(OdDbBlockReference pBlkRef, OdRxClass key)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_removeFilter(OdDbBlockReference.getCPtr(pBlkRef), OdRxClass.getCPtr(key));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbFilter OdDbIndexFilterManager_getFilter(OdDbBlockReference pBlkRef, OdRxClass key, OdDb_OpenMode readOrWrite)
	{
		OdDbFilter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFilter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getFilter__SWIG_0(OdDbBlockReference.getCPtr(pBlkRef), OdRxClass.getCPtr(key), (int)readOrWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbFilter OdDbIndexFilterManager_getFilter(OdDbBlockReference pBlkRef, int btrIndex, OdDb_OpenMode readOrWrite)
	{
		OdDbFilter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFilter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_getFilter__SWIG_1(OdDbBlockReference.getCPtr(pBlkRef), btrIndex, (int)readOrWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static int OdDbIndexFilterManager_numFilters(OdDbBlockReference pBlkRef)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIndexFilterManager_numFilters(OdDbBlockReference.getCPtr(pBlkRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void pixelToModel(OdGeMatrix3d xfm, OdGePoint2d pixelPoint, OdGePoint3d modelPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.pixelToModel(OdGeMatrix3d.getCPtr(xfm), OdGePoint2d.getCPtr(pixelPoint), OdGePoint3d.getCPtr(modelPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void modelToPixel(OdGeMatrix3d xfm, OdGePoint3d modelPoint, OdGePoint2d pixelPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.modelToPixel__SWIG_0(OdGeMatrix3d.getCPtr(xfm), OdGePoint3d.getCPtr(modelPoint), OdGePoint2d.getCPtr(pixelPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void modelToPixel(OdGeVector3d viewDir, OdGeMatrix3d xfm, OdGePlane plane, OdGePoint3d modelPoint, OdGePoint2d pixelPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.modelToPixel__SWIG_1(OdGeVector3d.getCPtr(viewDir), OdGeMatrix3d.getCPtr(xfm), OdGePlane.getCPtr(plane), OdGePoint3d.getCPtr(modelPoint), OdGePoint2d.getCPtr(pixelPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGeMatrix3d pixelToModelTransform(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, double ySize)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_DbCoreIntegrated_GlobalsPINVOKE.pixelToModelTransform(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(u), OdGeVector3d.getCPtr(v), ySize), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxEvent odrxEvent()
	{
		OdRxEvent rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEvent>(TD_DbCoreIntegrated_GlobalsPINVOKE.odrxEvent(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult oddbAppendLoopFromPickPoint(OdDbDatabase pDb, OdDbHatch pHatch, OdGePoint3d pickPoint, OdGePlane hatchPlane, bool useInnerRegions, bool bProjToPlane, OdDbSelectionFilter selectFilter)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAppendLoopFromPickPoint__SWIG_0(OdDbDatabase.getCPtr(pDb), OdDbHatch.getCPtr(pHatch), OdGePoint3d.getCPtr(pickPoint), OdGePlane.getCPtr(hatchPlane), useInnerRegions, bProjToPlane, OdDbSelectionFilter.getCPtr(selectFilter));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbAppendLoopFromPickPoint(OdDbDatabase pDb, OdDbHatch pHatch, OdGePoint3d pickPoint, OdGePlane hatchPlane, bool useInnerRegions, bool bProjToPlane)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAppendLoopFromPickPoint__SWIG_1(OdDbDatabase.getCPtr(pDb), OdDbHatch.getCPtr(pHatch), OdGePoint3d.getCPtr(pickPoint), OdGePlane.getCPtr(hatchPlane), useInnerRegions, bProjToPlane);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbAppendLoopFromPickPoint(OdDbDatabase pDb, OdDbHatch pHatch, OdGePoint3d pickPoint, OdGePlane hatchPlane, bool useInnerRegions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAppendLoopFromPickPoint__SWIG_2(OdDbDatabase.getCPtr(pDb), OdDbHatch.getCPtr(pHatch), OdGePoint3d.getCPtr(pickPoint), OdGePlane.getCPtr(hatchPlane), useInnerRegions);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbAppendLoopFromPickPoint(OdDbDatabase pDb, OdDbHatch pHatch, OdGePoint3d pickPoint, OdGePlane hatchPlane, OdDbEntityPtrArray selectionSet, bool useInnerRegions, bool bProjToPlane)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAppendLoopFromPickPoint__SWIG_3(OdDbDatabase.getCPtr(pDb), OdDbHatch.getCPtr(pHatch), OdGePoint3d.getCPtr(pickPoint), OdGePlane.getCPtr(hatchPlane), OdDbEntityPtrArray.getCPtr(selectionSet), useInnerRegions, bProjToPlane);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbAppendLoopFromPickPoint(OdDbDatabase pDb, OdDbHatch pHatch, OdGePoint3d pickPoint, OdGePlane hatchPlane, OdDbEntityPtrArray selectionSet, bool useInnerRegions)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbAppendLoopFromPickPoint__SWIG_4(OdDbDatabase.getCPtr(pDb), OdDbHatch.getCPtr(pHatch), OdGePoint3d.getCPtr(pickPoint), OdGePlane.getCPtr(hatchPlane), OdDbEntityPtrArray.getCPtr(selectionSet), useInnerRegions);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdArray_OdGeCurve2d__p_OdObjectsAllocator oddbCreateEdgesFromEntity(OdDbEntity pEnt, OdGePlane hatchPlane, bool bLeadToXAxis)
	{
		OdArray_OdGeCurve2d__p_OdObjectsAllocator result = new OdArray_OdGeCurve2d__p_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbCreateEdgesFromEntity__SWIG_0(OdDbEntity.getCPtr(pEnt), OdGePlane.getCPtr(hatchPlane), bLeadToXAxis), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdArray_OdGeCurve2d__p_OdObjectsAllocator oddbCreateEdgesFromEntity(OdDbEntity pEnt, OdGePlane hatchPlane)
	{
		OdArray_OdGeCurve2d__p_OdObjectsAllocator result = new OdArray_OdGeCurve2d__p_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbCreateEdgesFromEntity__SWIG_1(OdDbEntity.getCPtr(pEnt), OdGePlane.getCPtr(hatchPlane)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void odDbPageObjects(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odDbPageObjects(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbObjectId oddbGetRenderSettingsDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderSettingsDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderSettingsDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderSettingsDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetRenderSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderSettingsDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetRenderSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderSettingsDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetRenderPlotSettingsDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderPlotSettingsDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderPlotSettingsDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderPlotSettingsDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetRenderPlotSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderPlotSettingsDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetRenderPlotSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderPlotSettingsDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetRenderGlobalObjectId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderGlobalObjectId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderGlobalObjectId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderGlobalObjectId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbRenderGlobal oddbGetRenderGlobalObject(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbRenderGlobal rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderGlobal>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderGlobalObject__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbRenderGlobal oddbGetRenderGlobalObject(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbRenderGlobal rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderGlobal>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderGlobalObject__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetRenderEnvironmentObjectId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEnvironmentObjectId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderEnvironmentObjectId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEnvironmentObjectId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbRenderEnvironment oddbGetRenderEnvironmentObject(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbRenderEnvironment rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderEnvironment>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEnvironmentObject__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbRenderEnvironment oddbGetRenderEnvironmentObject(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbRenderEnvironment rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderEnvironment>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEnvironmentObject__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetActiveRenderSettingsObjectId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderSettingsObjectId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetActiveRenderSettingsObjectId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderSettingsObjectId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbRenderSettings oddbGetActiveRenderSettingsObject(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbRenderSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderSettingsObject__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbRenderSettings oddbGetActiveRenderSettingsObject(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbRenderSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderSettingsObject__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetRenderEntriesDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEntriesDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderEntriesDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEntriesDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetRenderEntriesDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEntriesDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetRenderEntriesDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderEntriesDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetRenderRapidRTSettingsDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderRapidRTSettingsDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetRenderRapidRTSettingsDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderRapidRTSettingsDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetRenderRapidRTSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderRapidRTSettingsDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetRenderRapidRTSettingsDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetRenderRapidRTSettingsDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetActiveRenderRapidRTSettingsObjectId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderRapidRTSettingsObjectId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetActiveRenderRapidRTSettingsObjectId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderRapidRTSettingsObjectId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbRenderSettings oddbGetActiveRenderRapidRTSettingsObject(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbRenderSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderRapidRTSettingsObject__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbRenderSettings oddbGetActiveRenderRapidRTSettingsObject(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbRenderSettings rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbRenderSettings>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetActiveRenderRapidRTSettingsObject__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void oddbConvertRgbToHsl(OdGeVector3d rgb, OdGeVector3d hsl)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbConvertRgbToHsl(OdGeVector3d.getCPtr(rgb), OdGeVector3d.getCPtr(hsl));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void oddbConvertHslToRgb(OdGeVector3d hsl, OdGeVector3d rgb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbConvertHslToRgb(OdGeVector3d.getCPtr(hsl), OdGeVector3d.getCPtr(rgb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void oddbUnderlayHostGetAdjustedColor(OdGeVector3d rgbResult, OdGeVector3d rgbInputColor, OdGeVector3d rgbCurrentBackgroundColor, OdGeVector3d hslFadedContrastColor, OdDbUnderlayDrawContext drawContext)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbUnderlayHostGetAdjustedColor(OdGeVector3d.getCPtr(rgbResult), OdGeVector3d.getCPtr(rgbInputColor), OdGeVector3d.getCPtr(rgbCurrentBackgroundColor), OdGeVector3d.getCPtr(hslFadedContrastColor), OdDbUnderlayDrawContext.getCPtr(drawContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbTable odDbCreateDataLinkAndTable(OdDbDatabase pDb, string linkName, string linkDescription, string connectionString)
	{
		OdDbTable rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTable>(TD_DbCoreIntegrated_GlobalsPINVOKE.odDbCreateDataLinkAndTable(OdDbDatabase.getCPtr(pDb), linkName, linkDescription, connectionString), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult oddbGetGeoDataObjId(OdDbDatabase pDb, OdDbObjectId objId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetGeoDataObjId(OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbGetGeoDataTransform(OdDbDatabase pDbSource, OdDbDatabase pDbTarget, OdGePoint3d pt, out double dRotation, out double dScale)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetGeoDataTransform(OdDbDatabase.getCPtr(pDbSource), OdDbDatabase.getCPtr(pDbTarget), OdGePoint3d.getCPtr(pt), out dRotation, out dScale);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdEditor odedEditor()
	{
		OdEditor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEditor>(TD_DbCoreIntegrated_GlobalsPINVOKE.odedEditor(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void oddbUpdateAttributes(OdDbBlockReference pRef, OdDbBlockTableRecord pBlk)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbUpdateAttributes(OdDbBlockReference.getCPtr(pRef), OdDbBlockTableRecord.getCPtr(pBlk));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResult boundary(OdDbDatabase pDb, OdGePoint3d pickPoint, BoundaryTypeEnum boundaryType, bool bDetectIsland, OdDbEntityPtrArray boundaryEntityOut, OdGePlane plane, OdDbEntityPtrArray selectionSet, double dGap)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.boundary__SWIG_0(OdDbDatabase.getCPtr(pDb), OdGePoint3d.getCPtr(pickPoint), (int)boundaryType, bDetectIsland, OdDbEntityPtrArray.getCPtr(boundaryEntityOut), OdGePlane.getCPtr(plane), OdDbEntityPtrArray.getCPtr(selectionSet), dGap);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult boundary(OdDbDatabase pDb, OdGePoint3d pickPoint, BoundaryTypeEnum boundaryType, bool bDetectIsland, OdDbEntityPtrArray boundaryEntityOut, OdGePlane plane, OdDbEntityPtrArray selectionSet)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.boundary__SWIG_1(OdDbDatabase.getCPtr(pDb), OdGePoint3d.getCPtr(pickPoint), (int)boundaryType, bDetectIsland, OdDbEntityPtrArray.getCPtr(boundaryEntityOut), OdGePlane.getCPtr(plane), OdDbEntityPtrArray.getCPtr(selectionSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult boundary(OdDbDatabase pDb, OdGePoint3d pickPoint, BoundaryTypeEnum boundaryType, bool bDetectIsland, OdDbEntityPtrArray boundaryEntityOut, OdGePlane plane)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.boundary__SWIG_2(OdDbDatabase.getCPtr(pDb), OdGePoint3d.getCPtr(pickPoint), (int)boundaryType, bDetectIsland, OdDbEntityPtrArray.getCPtr(boundaryEntityOut), OdGePlane.getCPtr(plane));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult boundary(OdDbDatabase pDb, OdGePoint3d pickPoint, BoundaryTypeEnum boundaryType, bool bDetectIsland, OdDbEntityPtrArray boundaryEntityOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.boundary__SWIG_3(OdDbDatabase.getCPtr(pDb), OdGePoint3d.getCPtr(pickPoint), (int)boundaryType, bDetectIsland, OdDbEntityPtrArray.getCPtr(boundaryEntityOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void oddbUpdateViewTableRecordCamera(OdDbViewTableRecord pVTR)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbUpdateViewTableRecordCamera(OdDbViewTableRecord.getCPtr(pVTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void oddbInitialUpdateViewTableRecordCameras(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbInitialUpdateViewTableRecordCameras(OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiWorldDraw oddbBeginProxyGraphics(OdDbDatabase pDbCtx)
	{
		OdGiWorldDraw rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiWorldDraw>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbBeginProxyGraphics(OdDbDatabase.getCPtr(pDbCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void oddbEndProxyGraphics(OdGiWorldDraw pWdSaver, OdUInt8Array graphics)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEndProxyGraphics(OdGiWorldDraw.getCPtr(pWdSaver), OdUInt8Array.getCPtr(graphics).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool odGetSatFromProxy(OdDbProxyEntity adPart, ref string sat)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sat);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odGetSatFromProxy__SWIG_0(OdDbProxyEntity.getCPtr(adPart), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sat = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static bool odGetSatFromProxy(OdDbProxyEntity adPart, ref OdModelerGeometry pModelerGeometry)
	{
		IntPtr jarg = ((pModelerGeometry == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pModelerGeometry).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odGetSatFromProxy__SWIG_1(OdDbProxyEntity.getCPtr(adPart), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pModelerGeometry = null;
			}
			else if (jarg != intPtr)
			{
				pModelerGeometry = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdDbProxyEntity odEntityToProxy(OdDbEntity pEnt, DwgVersion dwgVer, MaintReleaseVer nMaintVer)
	{
		OdDbProxyEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.odEntityToProxy__SWIG_0(OdDbEntity.getCPtr(pEnt), (int)dwgVer, (int)nMaintVer), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyEntity odEntityToProxy(OdDbEntity pEnt, DwgVersion dwgVer)
	{
		OdDbProxyEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.odEntityToProxy__SWIG_1(OdDbEntity.getCPtr(pEnt), (int)dwgVer), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyEntity odEntityToProxy(OdDbEntity pEnt)
	{
		OdDbProxyEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.odEntityToProxy__SWIG_2(OdDbEntity.getCPtr(pEnt)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyObject odObjectToProxy(OdDbObject pObj, DwgVersion dwgVer, MaintReleaseVer nMaintVer)
	{
		OdDbProxyObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.odObjectToProxy__SWIG_0(OdDbObject.getCPtr(pObj), (int)dwgVer, (int)nMaintVer), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyObject odObjectToProxy(OdDbObject pObj, DwgVersion dwgVer)
	{
		OdDbProxyObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.odObjectToProxy__SWIG_1(OdDbObject.getCPtr(pObj), (int)dwgVer), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbProxyObject odObjectToProxy(OdDbObject pObj)
	{
		OdDbProxyObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbProxyObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.odObjectToProxy__SWIG_2(OdDbObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldEngine oddbGetFieldEngine()
	{
		OdFdFieldEngine rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEngine>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetFieldEngine(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static string oddbGetFieldEngineValueByError(string sPrevValue)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetFieldEngineValueByError(sPrevValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string oddbSetFieldEngineValueFormatByError(string sValue)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbSetFieldEngineValueFormatByError__SWIG_0(sValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string oddbSetFieldEngineValueFormatByError()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbSetFieldEngineValueFormatByError__SWIG_1();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate, string pszEvaluatorId, OdFd_EvalFields nEvalFlag, out int pNumFound, out int pNumEvaluated, bool countTextFields)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_0(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate), pszEvaluatorId, (int)nEvalFlag, out pNumFound, out pNumEvaluated, countTextFields);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate, string pszEvaluatorId, OdFd_EvalFields nEvalFlag, out int pNumFound, out int pNumEvaluated)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_1(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate), pszEvaluatorId, (int)nEvalFlag, out pNumFound, out pNumEvaluated);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate, string pszEvaluatorId, OdFd_EvalFields nEvalFlag, out int pNumFound)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_2(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate), pszEvaluatorId, (int)nEvalFlag, out pNumFound);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate, string pszEvaluatorId, OdFd_EvalFields nEvalFlag)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_3(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate), pszEvaluatorId, (int)nEvalFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate, string pszEvaluatorId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_4(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate), pszEvaluatorId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds, OdDbObjectIdArray pFieldsToEvaluate)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_5(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds), OdDbObjectIdArray.getCPtr(pFieldsToEvaluate));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext, OdDbObjectIdArray objIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_6(OdDbDatabase.getCPtr(pDb), nContext, OdDbObjectIdArray.getCPtr(objIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult oddbEvaluateFields(OdDbDatabase pDb, int nContext)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbEvaluateFields__SWIG_7(OdDbDatabase.getCPtr(pDb), nContext);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static void odfdGetSubStrings(string sString, OdStringArray aSubStrings)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.odfdGetSubStrings(sString, OdStringArray.getCPtr(aSubStrings).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool odfdGetAcVarData(string sString, ref string sName, ref string sFormat)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sName);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(sFormat);
		IntPtr intPtr2 = jarg2;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odfdGetAcVarData(sString, ref jarg, ref jarg2);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sName = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 != intPtr2)
			{
				sFormat = Marshal.PtrToStringUni(jarg2);
			}
		}
	}

	public static OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator getDSSections(OdDbDatabase db)
	{
		OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator result = new OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.getDSSections(OdDbDatabase.getCPtr(db)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetMotionPathDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetMotionPathDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetMotionPathDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetMotionPathDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetMotionPathDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetMotionPathDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetMotionPathDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetMotionPathDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetNamedPathDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetNamedPathDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetNamedPathDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetNamedPathDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetNamedPathDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetNamedPathDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetNamedPathDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetNamedPathDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDatabaseCollection oddbDatabaseCollection()
	{
		OdDbDatabaseCollection rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabaseCollection>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbDatabaseCollection(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResult OdDbAcisIO_readAcisData(OdDbDwgFiler pFiler, ref OdModelerGeometry pAcisData, bool bStandardSaveFlag, OdDbAuditInfo pAuditInfo, bool bEnableAcisAudit)
	{
		IntPtr jarg = ((pAcisData == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pAcisData).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_readAcisData__SWIG_0(OdDbDwgFiler.getCPtr(pFiler), ref jarg, bStandardSaveFlag, OdDbAuditInfo.getCPtr(pAuditInfo), bEnableAcisAudit);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pAcisData = null;
			}
			else if (jarg != intPtr)
			{
				pAcisData = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult OdDbAcisIO_readAcisData(OdDbDwgFiler pFiler, ref OdModelerGeometry pAcisData, bool bStandardSaveFlag, OdDbAuditInfo pAuditInfo)
	{
		IntPtr jarg = ((pAcisData == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pAcisData).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_readAcisData__SWIG_1(OdDbDwgFiler.getCPtr(pFiler), ref jarg, bStandardSaveFlag, OdDbAuditInfo.getCPtr(pAuditInfo));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pAcisData = null;
			}
			else if (jarg != intPtr)
			{
				pAcisData = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult OdDbAcisIO_readAcisData(OdDbDwgFiler pFiler, ref OdModelerGeometry pAcisData, bool bStandardSaveFlag)
	{
		IntPtr jarg = ((pAcisData == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pAcisData).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_readAcisData__SWIG_2(OdDbDwgFiler.getCPtr(pFiler), ref jarg, bStandardSaveFlag);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pAcisData = null;
			}
			else if (jarg != intPtr)
			{
				pAcisData = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult OdDbAcisIO_readAcisData(OdDbDwgFiler pFiler, ref OdModelerGeometry pAcisData)
	{
		IntPtr jarg = ((pAcisData == null) ? IntPtr.Zero : OdModelerGeometry.getCPtr(pAcisData).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_readAcisData__SWIG_3(OdDbDwgFiler.getCPtr(pFiler), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pAcisData = null;
			}
			else if (jarg != intPtr)
			{
				pAcisData = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool OdDbAcisIO_writeAcisData(OdDbDwgFiler pFiler, OdModelerGeometry pAcisData, bool bStandardSaveFlag, bool bEnableAcisAudit, bool bCheckForBody)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_0(OdDbDwgFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData), bStandardSaveFlag, bEnableAcisAudit, bCheckForBody);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbAcisIO_writeAcisData(OdDbDwgFiler pFiler, OdModelerGeometry pAcisData, bool bStandardSaveFlag, bool bEnableAcisAudit)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_1(OdDbDwgFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData), bStandardSaveFlag, bEnableAcisAudit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbAcisIO_writeAcisData(OdDbDwgFiler pFiler, OdModelerGeometry pAcisData, bool bStandardSaveFlag)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_2(OdDbDwgFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData), bStandardSaveFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbAcisIO_writeAcisData(OdDbDwgFiler pFiler, OdModelerGeometry pAcisData)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_3(OdDbDwgFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdModelerGeometry OdDbAcisIO_readAcisData(OdDbDxfFiler pFiler)
	{
		OdModelerGeometry rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdModelerGeometry>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_readAcisData__SWIG_4(OdDbDxfFiler.getCPtr(pFiler)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void OdDbAcisIO_writeAcisData(OdDbDxfFiler pFiler, OdModelerGeometry pAcisData, bool saveEmptyAllowed, bool bEnableAcisAudit)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_4(OdDbDxfFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData), saveEmptyAllowed, bEnableAcisAudit);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbAcisIO_writeAcisData(OdDbDxfFiler pFiler, OdModelerGeometry pAcisData, bool saveEmptyAllowed)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAcisIO_writeAcisData__SWIG_5(OdDbDxfFiler.getCPtr(pFiler), OdModelerGeometry.getCPtr(pAcisData), saveEmptyAllowed);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdOxOleLinkManager OdOxGetOleLinkManager()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdOxGetOleLinkManager();
		OdOxOleLinkManager result = ((intPtr == IntPtr.Zero) ? null : new OdOxOleLinkManager(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static uint OdDbMLeader_setRecomputeFlags(OdDbMLeader pMLeader, uint flags)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setRecomputeFlags(OdDbMLeader.getCPtr(pMLeader), flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbMLeader_setAcadBehaviour(OdDbMLeader pMLeader, uint bug, bool bValue)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_setAcadBehaviour(OdDbMLeader.getCPtr(pMLeader), bug, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGePoint3d OdDbMLeader_getPtInternal(OdDbMLeader pMLeader, uint index)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getPtInternal__SWIG_0(OdDbMLeader.getCPtr(pMLeader), index), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGePoint3d OdDbMLeader_getPtInternal(OdDbMLeader pMLeader)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_getPtInternal__SWIG_1(OdDbMLeader.getCPtr(pMLeader)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbMLeader_applyData(OdDbMLeader pMLeader, OdGePoint3dArray points, OdDbObject pObj, int ver)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_applyData__SWIG_0(OdDbMLeader.getCPtr(pMLeader), OdGePoint3dArray.getCPtr(points).Handle, OdDbObject.getCPtr(pObj), ver);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbMLeader_applyData(OdDbMLeader pMLeader, OdGePoint3dArray points, OdDbObject pObj)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_applyData__SWIG_1(OdDbMLeader.getCPtr(pMLeader), OdGePoint3dArray.getCPtr(points).Handle, OdDbObject.getCPtr(pObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool OdDbMLeader_applyData(OdDbMLeader pMLeader, OdGePoint3dArray points)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMLeader_applyData__SWIG_2(OdDbMLeader.getCPtr(pMLeader), OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void OdDbObject_clearDatabase(OdDbObject pObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObject_clearDatabase(OdDbObject.getCPtr(pObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbObject_setWorkingDatabase(OdDbObject pObj, OdDbDatabase pWrkDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObject_setWorkingDatabase(OdDbObject.getCPtr(pObj), OdDbDatabase.getCPtr(pWrkDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdLyLayerFilterManager odlyGetLayerFilterManager(OdDbDatabase pDb)
	{
		OdLyLayerFilterManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilterManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.odlyGetLayerFilterManager(OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsLayoutHelper OdDbGsManager_setupActiveLayoutViews(OdGsDevice pDevice, OdGiContextForDbDatabase pGiCtx)
	{
		OdGsLayoutHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsLayoutHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGsManager_setupActiveLayoutViews(OdGsDevice.getCPtr(pDevice), OdGiContextForDbDatabase.getCPtr(pGiCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsLayoutHelper OdDbGsManager_setupLayoutViews(OdDbObjectId layoutId, OdGsDevice pDevice, OdGiContextForDbDatabase pGiCtx)
	{
		OdGsLayoutHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsLayoutHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGsManager_setupLayoutViews(OdDbObjectId.getCPtr(layoutId), OdGsDevice.getCPtr(pDevice), OdGiContextForDbDatabase.getCPtr(pGiCtx)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void OdDbGsManager_setupPalette(OdGsDevice device, OdGiContextForDbDatabase giContext, OdDbStub layoutId, uint palBackground)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGsManager_setupPalette__SWIG_0(OdGsDevice.getCPtr(device), OdGiContextForDbDatabase.getCPtr(giContext), OdDbStub.getCPtr(layoutId), palBackground);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbGsManager_setupPalette(OdGsDevice device, OdGiContextForDbDatabase giContext, OdDbStub layoutId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGsManager_setupPalette__SWIG_1(OdGsDevice.getCPtr(device), OdGiContextForDbDatabase.getCPtr(giContext), OdDbStub.getCPtr(layoutId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void OdDbGsManager_setupPalette(OdGsDevice device, OdGiContextForDbDatabase giContext)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGsManager_setupPalette__SWIG_2(OdGsDevice.getCPtr(device), OdGiContextForDbDatabase.getCPtr(giContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string odDbGetObjectName(OdDbObject pObj)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGetObjectName(OdDbObject.getCPtr(pObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGetObjectIdName(OdDbObjectId id)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGetObjectIdName(OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGetHandleName(OdDbHandle handle)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGetHandleName(OdDbHandle.getCPtr(handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGenerateName(OdDbObjectId id, OdDbHostAppServices pHostApp)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGenerateName__SWIG_0(OdDbObjectId.getCPtr(id), OdDbHostAppServices.getCPtr(pHostApp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGenerateName(OdDbObjectId id)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGenerateName__SWIG_1(OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGenerateName(uint i, OdDbHostAppServices pHostApp)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGenerateName__SWIG_2(i, OdDbHostAppServices.getCPtr(pHostApp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string odDbGenerateName(uint i)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbGenerateName__SWIG_3(i);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColorIndex(out short colorIndex, OdDbAuditInfo pAuditInfo, OdDbHostAppServices pHostApp)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColorIndex__SWIG_0(out colorIndex, OdDbAuditInfo.getCPtr(pAuditInfo), OdDbHostAppServices.getCPtr(pHostApp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColorIndex(out short colorIndex, OdDbAuditInfo pAuditInfo)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColorIndex__SWIG_1(out colorIndex, OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColorIndex(out short colorIndex, OdDbAuditInfo pAuditInfo, OdDbHostAppServices pHostApp, OdDbObject pObj, uint sid, uint n)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColorIndex__SWIG_2(out colorIndex, OdDbAuditInfo.getCPtr(pAuditInfo), OdDbHostAppServices.getCPtr(pHostApp), OdDbObject.getCPtr(pObj), sid, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColor(OdCmColor color, OdDbAuditInfo pAuditInfo, OdDbHostAppServices pHostApp)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColor__SWIG_0(OdCmColor.getCPtr(color), OdDbAuditInfo.getCPtr(pAuditInfo), OdDbHostAppServices.getCPtr(pHostApp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColor(OdCmColor color, OdDbAuditInfo pAuditInfo)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColor__SWIG_1(OdCmColor.getCPtr(color), OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool odDbAuditColor(OdCmColor color, OdDbAuditInfo pAuditInfo, OdDbHostAppServices pHostApp, OdDbObject pObj, uint sid, uint n)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.odDbAuditColor__SWIG_2(OdCmColor.getCPtr(color), OdDbAuditInfo.getCPtr(pAuditInfo), OdDbHostAppServices.getCPtr(pHostApp), OdDbObject.getCPtr(pObj), sid, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdApLongTransactionManager odapLongTransactionManager()
	{
		OdApLongTransactionManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdApLongTransactionManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.odapLongTransactionManager(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectId oddbGetBackgroundDictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetBackgroundDictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId oddbGetBackgroundDictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetBackgroundDictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDictionary oddbGetBackgroundDictionary(OdDbDatabase pDb, OdDb_OpenMode mode, bool createIfNotFound)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetBackgroundDictionary__SWIG_0(OdDbDatabase.getCPtr(pDb), (int)mode, createIfNotFound), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDictionary oddbGetBackgroundDictionary(OdDbDatabase pDb, OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetBackgroundDictionary__SWIG_1(OdDbDatabase.getCPtr(pDb), (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbLibraryInfo oddbGetLibraryInfo()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetLibraryInfo();
		OdDbLibraryInfo result = ((intPtr == IntPtr.Zero) ? null : new OdDbLibraryInfo(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDatabaseSummaryInfo oddbGetSummaryInfo(OdDbDatabase pDb)
	{
		OdDbDatabaseSummaryInfo rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabaseSummaryInfo>(TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetSummaryInfo(OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void oddbPutSummaryInfo(OdDbDatabaseSummaryInfo pInfo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.oddbPutSummaryInfo(OdDbDatabaseSummaryInfo.getCPtr(pInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool oddbGetContextDataAndScale(OdGiCommonDraw pWd, OdDbObject pObject, ref OdDbAnnotScaleObjectContextData ctx, double scaleOut, bool getDefaultScale)
	{
		IntPtr jarg = ((ctx == null) ? IntPtr.Zero : OdDbAnnotScaleObjectContextData.getCPtr(ctx).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetContextDataAndScale__SWIG_0(OdGiCommonDraw.getCPtr(pWd), OdDbObject.getCPtr(pObject), ref jarg, scaleOut, getDefaultScale);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ctx = null;
			}
			else if (jarg != intPtr)
			{
				ctx = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotScaleObjectContextData>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool oddbGetContextDataAndScale(OdGiCommonDraw pWd, OdDbObject pObject, ref OdDbAnnotScaleObjectContextData ctx, double scaleOut)
	{
		IntPtr jarg = ((ctx == null) ? IntPtr.Zero : OdDbAnnotScaleObjectContextData.getCPtr(ctx).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetContextDataAndScale__SWIG_1(OdGiCommonDraw.getCPtr(pWd), OdDbObject.getCPtr(pObject), ref jarg, scaleOut);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ctx = null;
			}
			else if (jarg != intPtr)
			{
				ctx = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotScaleObjectContextData>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static bool oddbGetContextDataAndScale(OdGiCommonDraw pWd, OdDbObject pObject, ref OdDbAnnotScaleObjectContextData ctx)
	{
		IntPtr jarg = ((ctx == null) ? IntPtr.Zero : OdDbAnnotScaleObjectContextData.getCPtr(ctx).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.oddbGetContextDataAndScale__SWIG_2(OdGiCommonDraw.getCPtr(pWd), OdDbObject.getCPtr(pObject), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ctx = null;
			}
			else if (jarg != intPtr)
			{
				ctx = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotScaleObjectContextData>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}
}
