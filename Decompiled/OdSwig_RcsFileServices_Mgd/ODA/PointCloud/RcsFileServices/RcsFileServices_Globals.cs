using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class RcsFileServices_Globals
{
	public static readonly uint UINT_MAX = RcsFileServices_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = RcsFileServices_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = RcsFileServices_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = RcsFileServices_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = RcsFileServices_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = RcsFileServices_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = RcsFileServices_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = RcsFileServices_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = RcsFileServices_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = RcsFileServices_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = RcsFileServices_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = RcsFileServices_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = RcsFileServices_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public static void throw_native_exception_string(string msg)
	{
		RcsFileServices_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		RcsFileServices_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		RcsFileServices_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		RcsFileServices_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
