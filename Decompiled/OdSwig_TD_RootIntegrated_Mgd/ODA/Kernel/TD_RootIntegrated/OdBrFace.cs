using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBrFace : OdBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBrFace(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBrFace obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBrFace(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBrErrorStatus getSurfaceAsNurb(OdGeNurbSurface nurb)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getSurfaceAsNurb(swigCPtr, OdGeNurbSurface.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdGeSurface getSurface()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getSurface(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrErrorStatus getSurfaceType(out OdGe_EntityId surfaceType)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getSurfaceType(swigCPtr, out surfaceType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getArea(out double area, double tolRequired, double tolAchieved)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getArea__SWIG_0(swigCPtr, out area, tolRequired, tolAchieved);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getArea(out double area, double tolRequired)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getArea__SWIG_1(swigCPtr, out area, tolRequired);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public OdBrErrorStatus getArea(out double area)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getArea__SWIG_2(swigCPtr, out area);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdBrErrorStatus)result;
	}

	public bool getOrientToSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getOrientToSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getColor(OdCmEntityColor color)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getMaterialID(out ulong id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getMaterialID(swigCPtr, out id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getMaterialString(ref string strMatName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(strMatName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getMaterialString(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				strMatName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool getMaterialMapper(OdGeMatrix3d mx, OdBrFace_Projection projection, OdBrFace_Tiling tiling, OdBrFace_AutoTransform autoTransform)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getMaterialMapper(swigCPtr, OdGeMatrix3d.getCPtr(mx), projection, tiling, autoTransform);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFillPatternId(out ulong id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getFillPatternId(swigCPtr, out id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFillingAttributes(bool isFaceForward, OdGePoint2d origin, out double rotAngle, out bool swapUv, OdGeScale3d scaleUv, out double uDerScale)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getFillingAttributes(swigCPtr, isFaceForward, OdGePoint2d.getCPtr(origin), out rotAngle, out swapUv, OdGeScale3d.getCPtr(scaleUv), out uDerScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getFaceOpacity(out double opacity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getFaceOpacity(swigCPtr, out opacity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getExtraFillingAttributes(OdGiFill pFill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getExtraFillingAttributes(swigCPtr, OdGiFill.getCPtr(pFill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFill getFill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getFill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool getFirstFaceRegion(OdBrFace face)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getFirstFaceRegion(swigCPtr, getCPtr(face));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getNextFaceRegion(OdBrFace face)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getNextFaceRegion(swigCPtr, getCPtr(face));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getMaterialAttributes(OdGePoint2d origin, out double angle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_getMaterialAttributes(swigCPtr, OdGePoint2d.getCPtr(origin), out angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBrFace()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrFace__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrFace) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrFace(OdBrFace arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBrFace__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdBrFace) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdBrFace Assign(OdBrFace arg0)
	{
		OdBrFace result = new OdBrFace(TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_Assign__SWIG_0(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBrFace_director_connect(swigCPtr);
	}
}
