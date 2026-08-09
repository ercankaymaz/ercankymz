using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class OdBaseMaterialAndColorHelper : OdIMaterialAndColorHelper
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBaseMaterialAndColorHelper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBaseMaterialAndColorHelper obj)
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_OdBaseMaterialAndColorHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdBaseMaterialAndColorHelper(OdDbStub pDefaultMaterial)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_OdBaseMaterialAndColorHelper__SWIG_0(OdDbStub.getCPtr(pDefaultMaterial)), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBaseMaterialAndColorHelper()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_OdBaseMaterialAndColorHelper__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceEntityMaterial(OdDbStub pSourceEntityMaterial)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_setSourceEntityMaterial(swigCPtr, OdDbStub.getCPtr(pSourceEntityMaterial));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceEntityMaterialMapping(OdGiMapper materialMapper)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_setSourceEntityMaterialMapping(swigCPtr, OdGiMapper.getCPtr(materialMapper));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetSourceEntityMapping()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_resetSourceEntityMapping(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceEntityColor(OdCmEntityColor defaultColor)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_setSourceEntityColor(swigCPtr, OdCmEntityColor.getCPtr(defaultColor));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetSourceEntityColor()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_resetSourceEntityColor(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceFaceColor(OdCmEntityColor defaultColor)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_setSourceFaceColor(swigCPtr, OdCmEntityColor.getCPtr(defaultColor));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetSourceFaceColor()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_resetSourceFaceColor(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceEdgeColor(OdCmEntityColor defaultColor)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_setSourceEdgeColor(swigCPtr, OdCmEntityColor.getCPtr(defaultColor));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetSourceEdgeColor()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_resetSourceEdgeColor(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult getFaceVisualInfo(OdBrFace face, out OdDbStub faceMaterial, OdGiMapper faceMaterialMapping, out bool applyFaceMaterialMapping, OdCmEntityColor faceColor, out bool applyFaceColor)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_getFaceVisualInfo(swigCPtr, OdBrFace.getCPtr(face), out jarg, OdGiMapper.getCPtr(faceMaterialMapping), out applyFaceMaterialMapping, OdCmEntityColor.getCPtr(faceColor), out applyFaceColor);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			faceMaterial = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public override OdResult getEdgeVisualInfo(OdBrEdge edge, OdCmEntityColor edgeColor, out bool applyEdgeColor)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdBaseMaterialAndColorHelper_getEdgeVisualInfo(swigCPtr, OdBrEdge.getCPtr(edge), OdCmEntityColor.getCPtr(edgeColor), out applyEdgeColor);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
