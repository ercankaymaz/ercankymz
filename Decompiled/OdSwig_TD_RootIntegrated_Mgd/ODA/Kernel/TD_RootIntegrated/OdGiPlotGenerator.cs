using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPlotGenerator : OdGiConveyorNode
{
	public class PolylineOut : IDisposable
	{
		public delegate bool SwigDelegatePolylineOut_0(IntPtr pPoints, int capStyle, int joinStyle, double fLwd);

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegatePolylineOut_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[4]
		{
			typeof(OdGePoint3d[]),
			typeof(OdPs_LineEndStyle),
			typeof(OdPs_LineJoinStyle),
			typeof(double)
		};

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PolylineOut(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PolylineOut obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PolylineOut()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlotGenerator_PolylineOut(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual bool plotGeneratorPolylineOut(OdGePoint3d[] pPoints, OdPs_LineEndStyle capStyle, OdPs_LineJoinStyle joinStyle, double fLwd)
		{
			IntPtr intPtr = Helpers.MarshalPoint3dArray(pPoints);
			try
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_PolylineOut_plotGeneratorPolylineOut(swigCPtr, intPtr, (int)capStyle, (int)joinStyle, fLwd);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			finally
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}

		public PolylineOut()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlotGenerator_PolylineOut(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(PolylineOut) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("plotGeneratorPolylineOut", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodplotGeneratorPolylineOut;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_PolylineOut_director_connect(swigCPtr, swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(PolylineOut));
		}

		private bool SwigDirectorMethodplotGeneratorPolylineOut(IntPtr pPoints, int capStyle, int joinStyle, double fLwd)
		{
			return plotGeneratorPolylineOut(Helpers.UnMarshalPoint3dArray(pPoints), (OdPs_LineEndStyle)capStyle, (OdPs_LineJoinStyle)joinStyle, fLwd);
		}
	}

	public class EllipseOut : IDisposable
	{
		public delegate bool SwigDelegateEllipseOut_0(IntPtr arc, double width);

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateEllipseOut_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[2]
		{
			typeof(OdGeEllipArc3d),
			typeof(double)
		};

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EllipseOut(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(EllipseOut obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~EllipseOut()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlotGenerator_EllipseOut(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual bool plotGeneratorEllipseOut(OdGeEllipArc3d arc, double width)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_EllipseOut_plotGeneratorEllipseOut(swigCPtr, OdGeEllipArc3d.getCPtr(arc), width);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public EllipseOut()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlotGenerator_EllipseOut(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(EllipseOut) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("plotGeneratorEllipseOut", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodplotGeneratorEllipseOut;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_EllipseOut_director_connect(swigCPtr, swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(EllipseOut));
		}

		private bool SwigDirectorMethodplotGeneratorEllipseOut(IntPtr arc, double width)
		{
			return plotGeneratorEllipseOut(new OdGeEllipArc3d(arc, cMemoryOwn: false), width);
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPlotGenerator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPlotGenerator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlotGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPlotGenerator cast(OdRxObject pObj)
	{
		OdGiPlotGenerator rXObject = Helpers.GetRXObject<OdGiPlotGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiPlotGenerator createObject()
	{
		OdGiPlotGenerator rXObject = Helpers.GetRXObject<OdGiPlotGenerator>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setDrawContext(swigCPtr, pDrawContext.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enable(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_enable(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_enabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void dot_per_inch(double dpi)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_dot_per_inch__SWIG_0(swigCPtr, dpi);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dot_per_inch()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_dot_per_inch__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void dot_per_mm(double dpmm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_dot_per_mm__SWIG_0(swigCPtr, dpmm);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double dot_per_mm()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_dot_per_mm__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPlotStyle(OdPsPlotStyleData psd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setPlotStyle(swigCPtr, OdPsPlotStyleData.getCPtr(psd));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExternalPolylineOut(PolylineOut pPolylineOut)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setExternalPolylineOut(swigCPtr, PolylineOut.getCPtr(pPolylineOut));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual PolylineOut externalPolylineOut()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_externalPolylineOut(swigCPtr);
		PolylineOut result = ((intPtr == IntPtr.Zero) ? null : new PolylineOut(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setExternalEllipseOut(EllipseOut pEllipseOut)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_setExternalEllipseOut(swigCPtr, EllipseOut.getCPtr(pEllipseOut));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual EllipseOut externalEllipseOut()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_externalEllipseOut(swigCPtr);
		EllipseOut result = ((intPtr == IntPtr.Zero) ? null : new EllipseOut(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlotGenerator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
