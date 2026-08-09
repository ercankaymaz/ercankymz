using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGeOffsetSurface : OdGeSurface
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGeOffsetSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGeOffsetSurface obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGeOffsetSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new OdGeOffsetSurface copy()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_copy(swigCPtr);
		OdGeOffsetSurface result = ((intPtr == IntPtr.Zero) ? null : new OdGeOffsetSurface(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface transformBy(OdGeMatrix3d xfm)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface translateBy(OdGeVector3d translateVec)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_translateBy(swigCPtr, OdGeVector3d.getCPtr(translateVec)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface rotateBy(double angle, OdGeVector3d vect, OdGePoint3d basePoint)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_rotateBy__SWIG_0(swigCPtr, angle, OdGeVector3d.getCPtr(vect), OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface rotateBy(double angle, OdGeVector3d vect)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_rotateBy__SWIG_1(swigCPtr, angle, OdGeVector3d.getCPtr(vect)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface mirror(OdGePlane plane)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_mirror(swigCPtr, OdGePlane.getCPtr(plane)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface scaleBy(double scaleFactor, OdGePoint3d basePoint)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_scaleBy__SWIG_0(swigCPtr, scaleFactor, OdGePoint3d.getCPtr(basePoint)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdGeOffsetSurface scaleBy(double scaleFactor)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_scaleBy__SWIG_1(swigCPtr, scaleFactor), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetSurface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetSurface__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetSurface(OdGeSurface baseSurface, double offsetDistance, bool makeCopy)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetSurface__SWIG_1(OdGeSurface.getCPtr(baseSurface), offsetDistance, makeCopy), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetSurface(OdGeSurface baseSurface, double offsetDistance)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetSurface__SWIG_2(OdGeSurface.getCPtr(baseSurface), offsetDistance), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeOffsetSurface(OdGeOffsetSurface source)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGeOffsetSurface__SWIG_3(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPlane()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isPlane(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBoundedPlane()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isBoundedPlane(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSphere()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isSphere(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCylinder()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isEllipCylinder(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEllipCone()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isEllipCone(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTorus()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_isTorus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getSurface(out OdGeSurface simpleSurface)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_getSurface(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, bIsWrapperOwnNativeObject: true));
			simpleSurface = Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, currentTransaction == null);
		}
	}

	public void getConstructionSurface(out OdGeSurface baseSurface)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_getConstructionSurface(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, bIsWrapperOwnNativeObject: true));
			baseSurface = Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, currentTransaction == null);
		}
	}

	public double offsetDist()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_offsetDist(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetSurface set(OdGeSurface baseSurface, double offsetDistance, bool makeCopy)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_set__SWIG_0(swigCPtr, OdGeSurface.getCPtr(baseSurface), offsetDistance, makeCopy), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetSurface set(OdGeSurface baseSurface, double offsetDistance)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_set__SWIG_1(swigCPtr, OdGeSurface.getCPtr(baseSurface), offsetDistance), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeOffsetSurface Assign(OdGeOffsetSurface surface)
	{
		OdGeOffsetSurface result = new OdGeOffsetSurface(TD_RootIntegrated_GlobalsPINVOKE.OdGeOffsetSurface_Assign(swigCPtr, getCPtr(surface)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
