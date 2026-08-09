using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrFace : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrFace(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrFace obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrFace(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual bool getSurfaceAsNurb(OdGeNurbSurface nurb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getSurfaceAsNurb(swigCPtr, OdGeNurbSurface.getCPtr(nurb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeSurface getSurface()
	{
		OdGeSurface result = Helpers.GetObject<OdGeSurface>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getSurface(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSurfaceType(out OdGe_EntityId type)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getSurfaceType(swigCPtr, out type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getOrientToSurface()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getOrientToSurface(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrShell getShell()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getShell(swigCPtr);
		OdIBrShell result = ((intPtr == IntPtr.Zero) ? null : new OdIBrShell(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void next(OdIBrLoop pFirstChild, ref OdIBrLoop pCurChild)
	{
		IntPtr jarg = OdIBrLoop.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_next(swigCPtr, OdIBrLoop.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrLoop.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrLoop>(typeof(OdIBrLoop), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual bool getTrueColor(out uint rgb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getTrueColor(swigCPtr, out rgb);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getColorIndex(out ushort indx)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getColorIndex(swigCPtr, out indx);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMaterial(out ulong id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getMaterial__SWIG_0(swigCPtr, out id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMaterial(ref string strMatName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(strMatName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getMaterial__SWIG_1(swigCPtr, ref jarg);
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

	public virtual bool getFillPattern(out ulong id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getFillPattern(swigCPtr, out id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getFillingAttributes(bool isFaceForward, OdGePoint2d origin, out double rotAngle, out bool swapUv, OdGeScale3d scaleUv, out double uDerScale)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getFillingAttributes(swigCPtr, isFaceForward, OdGePoint2d.getCPtr(origin), out rotAngle, out swapUv, OdGeScale3d.getCPtr(scaleUv), out uDerScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getFaceOpacity(out double opacity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getFaceOpacity(swigCPtr, out opacity);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMaterialMapper(OdGeMatrix3d mx, out byte projection, out byte tiling, out byte autoTransform)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getMaterialMapper(swigCPtr, OdGeMatrix3d.getCPtr(mx), out projection, out tiling, out autoTransform);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getExtraFillingAttributes(OdGiFill pFill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getExtraFillingAttributes(swigCPtr, OdGiFill.getCPtr(pFill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFill getFill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getFill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdIBrFace getFirstFaceRegion()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getFirstFaceRegion(swigCPtr);
		OdIBrFace result = ((intPtr == IntPtr.Zero) ? null : new OdIBrFace(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdIBrFace getNextFaceRegion(OdIBrFace pFace)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getNextFaceRegion(swigCPtr, getCPtr(pFace));
		OdIBrFace result = ((intPtr == IntPtr.Zero) ? null : new OdIBrFace(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMaterialAttributes(OdGePoint2d origin, out double angle)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFace_getMaterialAttributes(swigCPtr, OdGePoint2d.getCPtr(origin), out angle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
