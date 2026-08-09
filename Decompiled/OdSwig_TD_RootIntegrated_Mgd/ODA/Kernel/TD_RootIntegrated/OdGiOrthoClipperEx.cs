using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiOrthoClipperEx : OdGiOrthoClipper
{
	public class TolOverride : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public double m_tolOverride
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_TolOverride_m_tolOverride_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_TolOverride_m_tolOverride_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiOrthoClipperEx_TolOverride_OverrideType m_overrideType
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_TolOverride_m_overrideType_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiOrthoClipperEx_TolOverride_OverrideType)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_TolOverride_m_overrideType_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TolOverride(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(TolOverride obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~TolOverride()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiOrthoClipperEx_TolOverride(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public TolOverride()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiOrthoClipperEx_TolOverride(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class PolyTolOverride : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public TolOverride m_clipTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_clipTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_clipTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public TolOverride m_localTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_localTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_localTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public TolOverride m_sectionTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_sectionTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_sectionTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public TolOverride m_boundaryTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_boundaryTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_PolyTolOverride_m_boundaryTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PolyTolOverride(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(PolyTolOverride obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~PolyTolOverride()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiOrthoClipperEx_PolyTolOverride(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public PolyTolOverride()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiOrthoClipperEx_PolyTolOverride(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class ClipPlane : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGePoint3d m_origin
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_origin_get(swigCPtr);
				OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_origin_set(swigCPtr, OdGePoint3d.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGeVector3d m_normal
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_normal_get(swigCPtr);
				OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_normal_set(swigCPtr, OdGeVector3d.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiOrthoClipperEx_ClipPlane_MarkType m_markType
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_markType_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiOrthoClipperEx_ClipPlane_MarkType)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_markType_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public TolOverride m_clipTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_clipTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_clipTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public TolOverride m_sectionTolOverride
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_sectionTolOverride_get(swigCPtr);
				TolOverride result = ((intPtr == IntPtr.Zero) ? null : new TolOverride(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_ClipPlane_m_sectionTolOverride_set(swigCPtr, TolOverride.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ClipPlane(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ClipPlane obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ClipPlane()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiOrthoClipperEx_ClipPlane(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public ClipPlane()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiOrthoClipperEx_ClipPlane(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiOrthoClipperEx(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiOrthoClipperEx obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiOrthoClipperEx(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiOrthoClipperEx cast(OdRxObject pObj)
	{
		OdGiOrthoClipperEx rXObject = Helpers.GetRXObject<OdGiOrthoClipperEx>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiOrthoClipperEx createObject()
	{
		OdGiOrthoClipperEx rXObject = Helpers.GetRXObject<OdGiOrthoClipperEx>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void set(bool bInverted, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_0(swigCPtr, bInverted, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bInverted, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_1(swigCPtr, bInverted, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bInverted, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_2(swigCPtr, bInverted, intPtr, bClipLowerZ, dLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bInverted, OdGePoint2d[] nPoints, bool bClipLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_3(swigCPtr, bInverted, intPtr, bClipLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bInverted, OdGePoint2d[] nPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_4(swigCPtr, bInverted, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bInverted, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_5(swigCPtr, bInverted, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bInverted, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_6(swigCPtr, bInverted, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bInverted, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_7(swigCPtr, bInverted, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bInverted, OdGePoint2dArray points, bool bClipLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_8(swigCPtr, bInverted, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bInverted, OdGePoint2dArray points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_9(swigCPtr, bInverted, OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(out bool bInverted, OdGePoint2dArray points, out bool bClipLowerZ, out double dLowerZ, out bool bClipUpperZ, out double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_get__SWIG_0(swigCPtr, out bInverted, OdGePoint2dArray.getCPtr(points).Handle, out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bPreprocess, uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_10(swigCPtr, bPreprocess, nCounts, counts, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bPreprocess, uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_11(swigCPtr, bPreprocess, nCounts, counts, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bPreprocess, uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_12(swigCPtr, bPreprocess, nCounts, counts, intPtr, bClipLowerZ, dLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bPreprocess, uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_13(swigCPtr, bPreprocess, nCounts, counts, intPtr, bClipLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bPreprocess, uint nCounts, int counts, OdGePoint2d[] nPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_14(swigCPtr, bPreprocess, nCounts, counts, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(bool bPreprocess, OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_15(swigCPtr, bPreprocess, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bPreprocess, OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_16(swigCPtr, bPreprocess, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bPreprocess, OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_17(swigCPtr, bPreprocess, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bPreprocess, OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_18(swigCPtr, bPreprocess, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool bPreprocess, OdIntArray counts, OdGePoint2dArray points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_19(swigCPtr, bPreprocess, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdIntArray counts, OdGePoint2dArray points, out bool bClipLowerZ, out double dLowerZ, out bool bClipUpperZ, out double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_get__SWIG_1(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_20(swigCPtr, nCounts, counts, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void set(uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_21(swigCPtr, nCounts, counts, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void set(uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_22(swigCPtr, nCounts, counts, intPtr, bClipLowerZ, dLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void set(uint nCounts, int counts, OdGePoint2d[] nPoints, bool bClipLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_23(swigCPtr, nCounts, counts, intPtr, bClipLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void set(uint nCounts, int counts, OdGePoint2d[] nPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_24(swigCPtr, nCounts, counts, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void set(OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_25(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_26(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_27(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdIntArray counts, OdGePoint2dArray points, bool bClipLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_28(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdIntArray counts, OdGePoint2dArray points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_29(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isInverted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isInverted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isExtended()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isExtended(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSingleClipStage()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isSingleClipStage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEmptyClipSet()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isEmptyClipSet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void set(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo, OdGeMatrix3d pXform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_30(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo), OdGeMatrix3d.getCPtr(pXform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_31(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_set__SWIG_32(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiAbstractClipBoundary_BoundaryType getType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiAbstractClipBoundary_BoundaryType)result;
	}

	public virtual void enableAnalyticCurvesClipping(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_enableAnalyticCurvesClipping(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticCurvesClippingEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isAnalyticCurvesClippingEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enable()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_enable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void disable()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_disable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_enabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLimit(OdGiOrthoClipperEx_ClipLimit clipLimit, uint nLimit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_setLimit(swigCPtr, (int)clipLimit, nLimit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getLimit(OdGiOrthoClipperEx_ClipLimit clipLimit)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getLimit(swigCPtr, (int)clipLimit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void pushClipStage(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo, OdGeMatrix3d pXform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo), OdGeMatrix3d.getCPtr(pXform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_2(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint numPlanes, ClipPlane pPlanes, OdGeMatrix3d pXform, uint stageFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_3(swigCPtr, numPlanes, ClipPlane.getCPtr(pPlanes), OdGeMatrix3d.getCPtr(pXform), stageFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint numPlanes, ClipPlane pPlanes, OdGeMatrix3d pXform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_4(swigCPtr, numPlanes, ClipPlane.getCPtr(pPlanes), OdGeMatrix3d.getCPtr(pXform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint numPlanes, ClipPlane pPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_5(swigCPtr, numPlanes, ClipPlane.getCPtr(pPlanes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes, ClipPlane pPlanes, PolyTolOverride pPolyTol)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_6(swigCPtr, nCounts, counts, intPtr, stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes, ClipPlane.getCPtr(pPlanes), PolyTolOverride.getCPtr(pPolyTol));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes, ClipPlane pPlanes)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_7(swigCPtr, nCounts, counts, intPtr, stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes, ClipPlane.getCPtr(pPlanes));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_8(swigCPtr, nCounts, counts, intPtr, stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_9(swigCPtr, nCounts, counts, intPtr, stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_10(swigCPtr, nCounts, counts, intPtr, stageFlags, (int)countsClass);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints, uint stageFlags)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_11(swigCPtr, nCounts, counts, intPtr, stageFlags);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, OdGePoint2d[] nPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_12(swigCPtr, nCounts, counts, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes, ClipPlane pPlanes, PolyTolOverride pPolyTol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_13(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes, ClipPlane.getCPtr(pPlanes), PolyTolOverride.getCPtr(pPolyTol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes, ClipPlane pPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_14(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes, ClipPlane.getCPtr(pPlanes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform, uint numPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_15(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform), numPlanes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass, OdGeMatrix3d pXform)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_16(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags, (int)countsClass, OdGeMatrix3d.getCPtr(pXform));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags, OdGiOrthoClipperEx_CountsClassify countsClass)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_17(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags, (int)countsClass);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal, uint stageFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_18(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal), stageFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points, OdGeVector3d pNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_19(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points), OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipStage(uint nCounts, int counts, uint nPoints, OdGePoint3d points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_pushClipStage__SWIG_20(swigCPtr, nCounts, counts, nPoints, OdGePoint3d.getCPtr(points));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool popClipStage()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_popClipStage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearClipping(bool bClearCache)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_clearClipping__SWIG_0(swigCPtr, bClearCache);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearClipping()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_clearClipping__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearTemporaryArrays()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_clearTemporaryArrays(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint numClipStages()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_numClipStages(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void classifyClipStage(uint nStage, ref uint pNPlanes, ref uint pNPolys, bool bFirstPolyInverted)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_classifyClipStage__SWIG_0(swigCPtr, nStage, ref pNPlanes, ref pNPolys, bFirstPolyInverted);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void classifyClipStage(uint nStage, ref uint pNPlanes, ref uint pNPolys)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_classifyClipStage__SWIG_1(swigCPtr, nStage, ref pNPlanes, ref pNPolys);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void classifyClipStage(uint nStage, ref uint pNPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_classifyClipStage__SWIG_2(swigCPtr, nStage, ref pNPlanes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isClipStageSectionable(uint nStage)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isClipStageSectionable(swigCPtr, nStage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isClipStageCuttable(uint nStage)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isClipStageCuttable(swigCPtr, nStage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getClipStage(uint nStage, OdIntArray counts, OdGePoint2dArray points, OdGeVector3d pNormal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getClipStage__SWIG_0(swigCPtr, nStage, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle, OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getClipStage(uint nStage, OdIntArray counts, OdGePoint2dArray points)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getClipStage__SWIG_1(swigCPtr, nStage, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getClipStage(uint nStage, OdIntArray counts, OdGePoint3dArray points, OdGeVector3d pNormal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getClipStage__SWIG_2(swigCPtr, nStage, OdIntArray.getCPtr(counts).Handle, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getClipStage(uint nStage, OdIntArray counts, OdGePoint3dArray points)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getClipStage__SWIG_3(swigCPtr, nStage, OdIntArray.getCPtr(counts).Handle, OdGePoint3dArray.getCPtr(points));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getClipStage(uint nStage, OdGiOrthoClipperEx_ClipPlanesArray planes)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getClipStage__SWIG_4(swigCPtr, nStage, OdGiOrthoClipperEx_ClipPlanesArray.getCPtr(planes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableClipStage(uint nStage, bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_enableClipStage(swigCPtr, nStage, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isClipStageEnabled(uint nStage)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isClipStageEnabled(swigCPtr, nStage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint clipStatus()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_clipStatus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearClipStatus()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_clearClipStatus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiOrthoClipperEx_VisibilityStatus checkPointVisibility(OdGePoint3d pt)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_checkPointVisibility(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiOrthoClipperEx_VisibilityStatus)result;
	}

	public virtual OdGiOrthoClipperEx_VisibilityStatus checkSphereVisibility(OdGePoint3d origin, double radius)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_checkSphereVisibility(swigCPtr, OdGePoint3d.getCPtr(origin), radius);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiOrthoClipperEx_VisibilityStatus)result;
	}

	public virtual OdGiOrthoClipperEx_VisibilityStatus checkExtentsVisibility(OdGeExtents3d extents)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_checkExtentsVisibility(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiOrthoClipperEx_VisibilityStatus)result;
	}

	public virtual OdGiOrthoClipperEx_VisibilityStatus checkBoundsVisibility(OdGeBoundBlock3d bb)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_checkBoundsVisibility(swigCPtr, OdGeBoundBlock3d.getCPtr(bb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiOrthoClipperEx_VisibilityStatus)result;
	}

	public virtual void enableLogging(OdStreamBuf pStream)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_enableLogging(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void disableLogging()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_disableLogging(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isLoggingEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_isLoggingEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput sectionOutput(OdGiMultipleClippedOutputExt pExt)
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_sectionOutput__SWIG_0(swigCPtr, OdGiMultipleClippedOutputExt.getCPtr(pExt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput sectionOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_sectionOutput__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput cuttingOutput(OdGiMultipleClippedOutputExt pExt)
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_cuttingOutput__SWIG_0(swigCPtr, OdGiMultipleClippedOutputExt.getCPtr(pExt)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput cuttingOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_cuttingOutput__SWIG_1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiClippedGeometryOutput.ClippedGeometryOutputInterface nativeClippingGeometryInterface()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_nativeClippingGeometryInterface(swigCPtr);
		OdGiClippedGeometryOutput.ClippedGeometryOutputInterface result = ((intPtr == IntPtr.Zero) ? null : new OdGiClippedGeometryOutput.ClippedGeometryOutputInterface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void flushSection(bool bFlushClosed, bool bFlushOpened, bool bReleaseData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_flushSection__SWIG_0(swigCPtr, bFlushClosed, bFlushOpened, bReleaseData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void flushSection(bool bFlushClosed, bool bFlushOpened)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_flushSection__SWIG_1(swigCPtr, bFlushClosed, bFlushOpened);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void flushSection(bool bFlushClosed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_flushSection__SWIG_2(swigCPtr, bFlushClosed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void flushSection()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_flushSection__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSkipExtentsCheck(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_setSkipExtentsCheck(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTextsNoClip(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_setTextsNoClip(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipperEx_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
