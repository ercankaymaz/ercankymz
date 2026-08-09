using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiViewportDraw_Stub : TEMPOdGiWrapperViewportDraw
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiViewportDraw_Stub(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_Stub_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiViewportDraw_Stub obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiViewportDraw_Stub(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	private static IntPtr SwigConstructOdGiViewportDraw_Stub(ref OdGiViewportDraw pVD, ref OdGiViewportGeometry pVG, ref OdGiSubEntityTraits pST)
	{
		IntPtr jarg = ((pVD == null) ? IntPtr.Zero : OdGiViewportDraw.getCPtr(pVD).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pVG == null) ? IntPtr.Zero : OdGiViewportGeometry.getCPtr(pVG).Handle);
		IntPtr intPtr2 = jarg2;
		IntPtr jarg3 = ((pST == null) ? IntPtr.Zero : OdGiSubEntityTraits.getCPtr(pST).Handle);
		IntPtr intPtr3 = jarg3;
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdGiViewportDraw_Stub(ref jarg, ref jarg2, ref jarg3);
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pVD = null;
			}
			if (jarg != intPtr)
			{
				pVD = Helpers.GetRXObject<OdGiViewportDraw>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pVG = null;
			}
			if (jarg2 != intPtr2)
			{
				pVG = Helpers.GetRXObject<OdGiViewportGeometry>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg3 == IntPtr.Zero)
			{
				pST = null;
			}
			if (jarg3 != intPtr3)
			{
				pST = Helpers.GetRXObject<OdGiSubEntityTraits>(jarg3, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiViewportDraw_Stub(ref OdGiViewportDraw pVD, ref OdGiViewportGeometry pVG, ref OdGiSubEntityTraits pST)
		: this(SwigConstructOdGiViewportDraw_Stub(ref pVD, ref pVG, ref pST), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiGeometry rawGeometry()
	{
		OdGiGeometry rXObject = Helpers.GetRXObject<OdGiGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_Stub_rawGeometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiSubEntityTraits subEntityTraits()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_Stub_subEntityTraits(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiViewportGeometry geometry()
	{
		OdGiViewportGeometry rXObject = Helpers.GetRXObject<OdGiViewportGeometry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiViewportDraw_Stub_geometry(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
