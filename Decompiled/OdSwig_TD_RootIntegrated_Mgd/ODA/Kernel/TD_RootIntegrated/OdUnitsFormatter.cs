using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdUnitsFormatter : OdRxObject
{
	public class DimzinValues : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public const int kSuppressesZeroFeetAndPreciselyZeroInches = 0;

		public const int kIncludesZeroFeetAndPreciselyZeroInches = 1;

		public const int kIncludesZeroFeetAndSuppressesZeroInches = 2;

		public const int kIncludesZeroInchesAndSuppressesZeroFeet = 3;

		public const int kSuppressesLeadingZeros = 4;

		public const int kSuppressesTrailingZeros = 8;

		public const int kSuppressesBothLeadingAndTrailingZeros = 12;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DimzinValues(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DimzinValues obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DimzinValues()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdUnitsFormatter_DimzinValues(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DimzinValues()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUnitsFormatter_DimzinValues(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class DimazinValues : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public const int kIncludesLeadingAndTrailingZeros = 0;

		public const int kSuppressesLeadingZeros = 1;

		public const int kSuppressesTrailingZeros = 2;

		public const int kSuppressesBothLeadingAndTrailingZeros = 3;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DimazinValues(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DimazinValues obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DimazinValues()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdUnitsFormatter_DimazinValues(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DimazinValues()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUnitsFormatter_DimazinValues(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdUnitsFormatter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdUnitsFormatter_1();

	public delegate void SwigDelegateOdUnitsFormatter_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdUnitsFormatter_3(IntPtr value);

	public delegate IntPtr SwigDelegateOdUnitsFormatter_4([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdUnitsFormatter_5(double value);

	public delegate double SwigDelegateOdUnitsFormatter_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdUnitsFormatter_7(double value);

	public delegate double SwigDelegateOdUnitsFormatter_8([MarshalAs(UnmanagedType.LPWStr)] string string_);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdUnitsFormatter_0 swigDelegate0;

	private SwigDelegateOdUnitsFormatter_1 swigDelegate1;

	private SwigDelegateOdUnitsFormatter_2 swigDelegate2;

	private SwigDelegateOdUnitsFormatter_3 swigDelegate3;

	private SwigDelegateOdUnitsFormatter_4 swigDelegate4;

	private SwigDelegateOdUnitsFormatter_5 swigDelegate5;

	private SwigDelegateOdUnitsFormatter_6 swigDelegate6;

	private SwigDelegateOdUnitsFormatter_7 swigDelegate7;

	private SwigDelegateOdUnitsFormatter_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdUnitsFormatter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdUnitsFormatter obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdUnitsFormatter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdUnitsFormatter cast(OdRxObject pObj)
	{
		OdUnitsFormatter rXObject = Helpers.GetRXObject<OdUnitsFormatter>(TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isASwigExplicitOdUnitsFormatter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_queryXSwigExplicitOdUnitsFormatter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdUnitsFormatter createObject()
	{
		OdUnitsFormatter rXObject = Helpers.GetRXObject<OdUnitsFormatter>(TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string formatCmColor(OdCmColorBase value)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatCmColor(swigCPtr, OdCmColorBase.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColorBase unformatCmColor(string string_)
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatCmColor(swigCPtr, string_), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string formatLinear(double value)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatLinear(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double unformatLinear(string string_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatLinear(swigCPtr, string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string formatAngle(double value)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatAngle(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double unformatAngle(string string_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatAngle(swigCPtr, string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isZeroFeetSuppressed(int dimzin)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isZeroFeetSuppressed(dimzin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isZeroInchesSuppressed(int dimzin)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isZeroInchesSuppressed(dimzin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isZeroFeetSuppressed2(int dimzin)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isZeroFeetSuppressed2(dimzin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isZeroInchesSuppressed2(int dimzin)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_isZeroInchesSuppressed2(dimzin);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatL(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode, string decsep, string thsep, bool useStdRound)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatL__SWIG_0(value, (int)lUnits, precision, dimzin, unitMode, decsep, thsep, useStdRound);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatL(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode, string decsep, string thsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatL__SWIG_1(value, (int)lUnits, precision, dimzin, unitMode, decsep, thsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatL(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode, string decsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatL__SWIG_2(value, (int)lUnits, precision, dimzin, unitMode, decsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatL(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatL__SWIG_3(value, (int)lUnits, precision, dimzin, unitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatArea(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode, string decsep, string thsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatArea__SWIG_0(value, (int)lUnits, precision, dimzin, unitMode, decsep, thsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatArea(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode, string decsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatArea__SWIG_1(value, (int)lUnits, precision, dimzin, unitMode, decsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatArea(double value, OdUnitsFormatter_LUnits lUnits, int precision, int dimzin, int unitMode)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatArea__SWIG_2(value, (int)lUnits, precision, dimzin, unitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double unformatL(string string_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatL(string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatA(double value, OdUnitsFormatter_AUnits aUnits, int precision, int dimazin, int unitMode, string decsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatA__SWIG_0(value, (int)aUnits, precision, dimazin, unitMode, decsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatA(double value, OdUnitsFormatter_AUnits aUnits, int precision, int dimazin, int unitMode)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatA__SWIG_1(value, (int)aUnits, precision, dimazin, unitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatA_unnorm(double value, OdUnitsFormatter_AUnits aUnits, int precision, int dimazin, int unitMode, string decsep)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatA_unnorm__SWIG_0(value, (int)aUnits, precision, dimazin, unitMode, decsep);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string formatA_unnorm(double value, OdUnitsFormatter_AUnits aUnits, int precision, int dimazin, int unitMode)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_formatA_unnorm__SWIG_1(value, (int)aUnits, precision, dimazin, unitMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double unformatA(string string_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatA(string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double unformatA_unnorm(string string_, bool refuseDots)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatA_unnorm__SWIG_0(string_, refuseDots);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static double unformatA_unnorm(string string_)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_unformatA_unnorm__SWIG_1(string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUnitsFormatter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUnitsFormatter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdUnitsFormatter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("formatCmColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodformatCmColor;
		}
		if (SwigDerivedClassHasMethod("unformatCmColor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodunformatCmColor;
		}
		if (SwigDerivedClassHasMethod("formatLinear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodformatLinear;
		}
		if (SwigDerivedClassHasMethod("unformatLinear", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodunformatLinear;
		}
		if (SwigDerivedClassHasMethod("formatAngle", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodformatAngle;
		}
		if (SwigDerivedClassHasMethod("unformatAngle", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodunformatAngle;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdUnitsFormatter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdUnitsFormatter));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatCmColor(IntPtr value)
	{
		return formatCmColor(Helpers.GetObject<OdCmColorBase>(value, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodunformatCmColor([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return OdCmColorBase.getCPtr(unformatCmColor(string_)).Handle;
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatLinear(double value)
	{
		return formatLinear(value);
	}

	private double SwigDirectorMethodunformatLinear([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return unformatLinear(string_);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodformatAngle(double value)
	{
		return formatAngle(value);
	}

	private double SwigDirectorMethodunformatAngle([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		return unformatAngle(string_);
	}
}
