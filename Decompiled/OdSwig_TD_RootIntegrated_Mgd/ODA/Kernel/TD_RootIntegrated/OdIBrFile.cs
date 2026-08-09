using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrFile : OdIBrEntity
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrFile(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrFile obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrFile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void next(OdIBrBrep pFirstChild, ref OdIBrBrep pCurChild)
	{
		IntPtr jarg = OdIBrBrep.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_0(swigCPtr, OdIBrBrep.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrBrep.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrBrep>(typeof(OdIBrBrep), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrVertex pFirstChild, ref OdIBrVertex pCurChild)
	{
		IntPtr jarg = OdIBrVertex.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_1(swigCPtr, OdIBrVertex.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrVertex.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrVertex>(typeof(OdIBrVertex), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrShell pFirstChild, ref OdIBrShell pCurChild)
	{
		IntPtr jarg = OdIBrShell.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_2(swigCPtr, OdIBrShell.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrShell.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrShell>(typeof(OdIBrShell), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrFace pFirstChild, ref OdIBrFace pCurChild)
	{
		IntPtr jarg = OdIBrFace.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_3(swigCPtr, OdIBrFace.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrFace.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrFace>(typeof(OdIBrFace), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrEdge pFirstChild, ref OdIBrEdge pCurChild)
	{
		IntPtr jarg = OdIBrEdge.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_4(swigCPtr, OdIBrEdge.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrEdge.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrEdge>(typeof(OdIBrEdge), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual void next(OdIBrComplex pFirstChild, ref OdIBrComplex pCurChild)
	{
		IntPtr jarg = OdIBrComplex.getCPtr(pCurChild).Handle;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_next__SWIG_5(swigCPtr, OdIBrComplex.getCPtr(pFirstChild), ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (OdIBrComplex.getCPtr(pCurChild).Handle != jarg)
			{
				pCurChild = Helpers.odCreateObjectInternal<OdIBrComplex>(typeof(OdIBrComplex), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public virtual OdIBrEntity setSubentPath(int arg0, IntPtr arg1)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdIBrFile_setSubentPath(swigCPtr, arg0, arg1);
		OdIBrEntity result = ((intPtr == IntPtr.Zero) ? null : new OdIBrEntity(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
