using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class PdfPublish_Globals
{
	public static readonly uint UINT_MAX = PdfPublish_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = PdfPublish_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = PdfPublish_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = PdfPublish_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = PdfPublish_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = PdfPublish_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = PdfPublish_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = PdfPublish_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = PdfPublish_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = PdfPublish_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = PdfPublish_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = PdfPublish_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = PdfPublish_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public static void throw_native_exception_string(string msg)
	{
		PdfPublish_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		PdfPublish_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		PdfPublish_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		PdfPublish_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
