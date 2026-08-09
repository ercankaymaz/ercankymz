using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class TD_PdfExport_Globals
{
	public static readonly uint UINT_MAX = TD_PdfExport_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = TD_PdfExport_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = TD_PdfExport_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = TD_PdfExport_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = TD_PdfExport_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = TD_PdfExport_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = TD_PdfExport_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = TD_PdfExport_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = TD_PdfExport_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = TD_PdfExport_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = TD_PdfExport_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = TD_PdfExport_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = TD_PdfExport_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public static void throw_native_exception_string(string msg)
	{
		TD_PdfExport_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		TD_PdfExport_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		TD_PdfExport_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		TD_PdfExport_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdRxObject odCreatePrcAllInSingleViewContextBase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_PdfExport_GlobalsPINVOKE.odCreatePrcAllInSingleViewContextBase(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static PdfExportServiceInterface getPdfExportService()
	{
		PdfExportServiceInterface rXObject = Helpers.GetRXObject<PdfExportServiceInterface>(TD_PdfExport_GlobalsPINVOKE.getPdfExportService(), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
