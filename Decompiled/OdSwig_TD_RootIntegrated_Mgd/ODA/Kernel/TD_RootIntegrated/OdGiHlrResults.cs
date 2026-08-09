using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiHlrResults : OdRxObject
{
	public class Traits : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdDbStub plotStyle
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_plotStyle_get(swigCPtr);
				OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_plotStyle_set(swigCPtr, OdDbStub.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public IntPtr selMarker
		{
			get
			{
				IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_selMarker_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_selMarker_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdCmEntityColor color
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_color_get(swigCPtr);
				OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_color_set(swigCPtr, OdCmEntityColor.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdCmEntityColor obscuredColor
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_obscuredColor_get(swigCPtr);
				OdCmEntityColor result = ((intPtr == IntPtr.Zero) ? null : new OdCmEntityColor(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_obscuredColor_set(swigCPtr, OdCmEntityColor.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public LineWeight lineWeight
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_lineWeight_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (LineWeight)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Traits_lineWeight_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Traits(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Traits obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Traits()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHlrResults_Traits(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Traits()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHlrResults_Traits(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class Data : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public Traits pTraits
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_pTraits_get(swigCPtr);
				Traits result = ((intPtr == IntPtr.Zero) ? null : new Traits(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_pTraits_set(swigCPtr, Traits.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGePoint3dArray visible
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_visible_get(swigCPtr);
				OdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3dArray(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_visible_set(swigCPtr, OdGePoint3dArray.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGePoint3dArray hidden
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_hidden_get(swigCPtr);
				OdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3dArray(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_Data_hidden_set(swigCPtr, OdGePoint3dArray.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Data(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Data obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Data()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHlrResults_Data(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Data()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHlrResults_Data(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGiHlrResults_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiHlrResults_1();

	public delegate void SwigDelegateOdGiHlrResults_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiHlrResults_3();

	public delegate void SwigDelegateOdGiHlrResults_4();

	public delegate IntPtr SwigDelegateOdGiHlrResults_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiHlrResults_0 swigDelegate0;

	private SwigDelegateOdGiHlrResults_1 swigDelegate1;

	private SwigDelegateOdGiHlrResults_2 swigDelegate2;

	private SwigDelegateOdGiHlrResults_3 swigDelegate3;

	private SwigDelegateOdGiHlrResults_4 swigDelegate4;

	private SwigDelegateOdGiHlrResults_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiHlrResults(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiHlrResults obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHlrResults(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiHlrResults cast(OdRxObject pObj)
	{
		OdGiHlrResults rXObject = Helpers.GetRXObject<OdGiHlrResults>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_isASwigExplicitOdGiHlrResults(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_queryXSwigExplicitOdGiHlrResults(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiHlrResults createObject()
	{
		OdGiHlrResults rXObject = Helpers.GetRXObject<OdGiHlrResults>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual Data next()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_next(swigCPtr);
		Data result = ((intPtr == IntPtr.Zero) ? null : new Data(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void start()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_start(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStubPtrArray currentDrawablePath()
	{
		OdDbStubPtrArray result = new OdDbStubPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_currentDrawablePath(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiHlrResults()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHlrResults(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiHlrResults) != GetType();
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
		if (SwigDerivedClassHasMethod("next", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("start", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("currentDrawablePath", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcurrentDrawablePath;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHlrResults_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiHlrResults));
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

	private IntPtr SwigDirectorMethodnext()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return Data.getCPtr(next()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private IntPtr SwigDirectorMethodcurrentDrawablePath()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStubPtrArray.getCPtr(currentDrawablePath()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
