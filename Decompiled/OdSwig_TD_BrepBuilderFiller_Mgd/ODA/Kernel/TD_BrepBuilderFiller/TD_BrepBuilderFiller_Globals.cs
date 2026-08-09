using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class TD_BrepBuilderFiller_Globals
{
	public static readonly uint UINT_MAX = TD_BrepBuilderFiller_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = TD_BrepBuilderFiller_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = TD_BrepBuilderFiller_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = TD_BrepBuilderFiller_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = TD_BrepBuilderFiller_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = TD_BrepBuilderFiller_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = TD_BrepBuilderFiller_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = TD_BrepBuilderFiller_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = TD_BrepBuilderFiller_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = TD_BrepBuilderFiller_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = TD_BrepBuilderFiller_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = TD_BrepBuilderFiller_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = TD_BrepBuilderFiller_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public static void throw_native_exception_string(string msg)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
