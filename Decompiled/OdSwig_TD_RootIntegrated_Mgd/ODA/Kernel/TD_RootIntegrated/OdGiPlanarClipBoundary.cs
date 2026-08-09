using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPlanarClipBoundary : OdGiAbstractClipBoundary
{
	public class ClipPlane : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGePoint3d m_origin
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_m_origin_get(swigCPtr);
				OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_m_origin_set(swigCPtr, OdGePoint3d.getCPtr(value));
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
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_m_normal_get(swigCPtr);
				OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_m_normal_set(swigCPtr, OdGeVector3d.getCPtr(value));
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlanarClipBoundary_ClipPlane(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public ClipPlane()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary_ClipPlane__SWIG_0(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public ClipPlane(OdGePoint3d origin, OdGeVector3d normal)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary_ClipPlane__SWIG_1(OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(normal)), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public ClipPlane setOrigin(OdGePoint3d origin)
		{
			ClipPlane result = new ClipPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_setOrigin(swigCPtr, OdGePoint3d.getCPtr(origin)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdGePoint3d origin()
		{
			OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_origin(swigCPtr), cMemoryOwn: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ClipPlane setNormal(OdGeVector3d normal)
		{
			ClipPlane result = new ClipPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_setNormal(swigCPtr, OdGeVector3d.getCPtr(normal)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdGeVector3d normal()
		{
			OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlane_normal(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public delegate int SwigDelegateOdGiPlanarClipBoundary_0();

	public delegate IntPtr SwigDelegateOdGiPlanarClipBoundary_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPlanarClipBoundary_0 swigDelegate0;

	private SwigDelegateOdGiPlanarClipBoundary_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPlanarClipBoundary(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPlanarClipBoundary obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlanarClipBoundary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiPlanarClipBoundary()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPlanarClipBoundary) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiAbstractClipBoundary_BoundaryType type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_typeSwigExplicitOdGiPlanarClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiAbstractClipBoundary_BoundaryType)result;
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray clipPlanes()
	{
		OdGiPlanarClipBoundary_ClipPlaneArray result = new OdGiPlanarClipBoundary_ClipPlaneArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_clipPlanes(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setClipPlanes(OdGiPlanarClipBoundary_ClipPlaneArray pClipPlanes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_setClipPlanes(swigCPtr, OdGiPlanarClipBoundary_ClipPlaneArray.getCPtr(pClipPlanes));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiSectionGeometryOutput sectionGeometryOutput()
	{
		OdGiSectionGeometryOutput rXObject = Helpers.GetRXObject<OdGiSectionGeometryOutput>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_sectionGeometryOutput(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSectionGeometryOutput(OdGiSectionGeometryOutput pSectionOutput)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_setSectionGeometryOutput(swigCPtr, OdGiSectionGeometryOutput.getCPtr(pSectionOutput));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiCuttedGeometryOutput cuttedGeometryOutput()
	{
		OdGiCuttedGeometryOutput rXObject = Helpers.GetRXObject<OdGiCuttedGeometryOutput>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_cuttedGeometryOutput(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setCuttedGeometryOutput(OdGiCuttedGeometryOutput pCuttedOutput)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_setCuttedGeometryOutput(swigCPtr, OdGiCuttedGeometryOutput.getCPtr(pCuttedOutput));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiAbstractClipBoundary clone()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("clone", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_cloneSwigExplicitOdGiPlanarClipBoundary(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_clone(swigCPtr));
		OdGiAbstractClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodclone;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPlanarClipBoundary));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiAbstractClipBoundary.getCPtr(clone()).Handle;
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
