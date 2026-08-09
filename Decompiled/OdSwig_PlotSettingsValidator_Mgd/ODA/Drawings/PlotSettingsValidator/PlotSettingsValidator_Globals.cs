using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.PlotSettingsValidator;

public class PlotSettingsValidator_Globals
{
	public static readonly uint UINT_MAX = PlotSettingsValidator_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = PlotSettingsValidator_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = PlotSettingsValidator_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = PlotSettingsValidator_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = PlotSettingsValidator_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = PlotSettingsValidator_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = PlotSettingsValidator_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = PlotSettingsValidator_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = PlotSettingsValidator_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = PlotSettingsValidator_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = PlotSettingsValidator_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = PlotSettingsValidator_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = PlotSettingsValidator_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public static void throw_native_exception_string(string msg)
	{
		PlotSettingsValidator_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		PlotSettingsValidator_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		PlotSettingsValidator_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		PlotSettingsValidator_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
