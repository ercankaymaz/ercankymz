using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcPreviewGenerator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcPreviewGenerator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcPreviewGenerator_1();

	public delegate void SwigDelegateOdPrcPreviewGenerator_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcPreviewGenerator_0 swigDelegate0;

	private SwigDelegateOdPrcPreviewGenerator_1 swigDelegate1;

	private SwigDelegateOdPrcPreviewGenerator_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcPreviewGenerator(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcPreviewGenerator obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcPreviewGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcPreviewGenerator()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcPreviewGenerator(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcPreviewGenerator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcPreviewGenerator cast(OdRxObject pObj)
	{
		OdPrcPreviewGenerator rXObject = Helpers.GetRXObject<OdPrcPreviewGenerator>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_isASwigExplicitOdPrcPreviewGenerator(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_queryXSwigExplicitOdPrcPreviewGenerator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcPreviewGenerator createObject()
	{
		OdPrcPreviewGenerator rXObject = Helpers.GetRXObject<OdPrcPreviewGenerator>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult init(OdPrcFile pPRCFile)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_init(swigCPtr, OdPrcFile.getCPtr(pPRCFile));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcFile getPRCFile()
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getPRCFile(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setCamera(OdGePoint3d ptCameraPos, OdGePoint3d ptCameraTarget, OdGeVector3d vrCameraUp, double dCameraWidth, double dCameraHeight, bool bPerspective)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setCamera__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(ptCameraPos), OdGePoint3d.getCPtr(ptCameraTarget), OdGeVector3d.getCPtr(vrCameraUp), dCameraWidth, dCameraHeight, bPerspective);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setCamera(OdGePoint3d ptCameraPos, OdGePoint3d ptCameraTarget, OdGeVector3d vrCameraUp, double dCameraWidth, double dCameraHeight)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setCamera__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(ptCameraPos), OdGePoint3d.getCPtr(ptCameraTarget), OdGeVector3d.getCPtr(vrCameraUp), dCameraWidth, dCameraHeight);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setCamera(OdGePoint3d ptCameraPos, OdGePoint3d ptCameraTarget, OdGeVector3d vrCameraUp, double dCameraWidth)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setCamera__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(ptCameraPos), OdGePoint3d.getCPtr(ptCameraTarget), OdGeVector3d.getCPtr(vrCameraUp), dCameraWidth);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setCamera(OdGePoint3d ptCameraPos, OdGePoint3d ptCameraTarget, OdGeVector3d vrCameraUp)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setCamera__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(ptCameraPos), OdGePoint3d.getCPtr(ptCameraTarget), OdGeVector3d.getCPtr(vrCameraUp));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getCamera(OdGePoint3d ptCameraPos, OdGePoint3d ptCameraTarget, OdGeVector3d vrCameraUp, out double dCameraWidth, out double dCameraHeight, out bool bPerspective)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getCamera(swigCPtr, OdGePoint3d.getCPtr(ptCameraPos), OdGePoint3d.getCPtr(ptCameraTarget), OdGeVector3d.getCPtr(vrCameraUp), out dCameraWidth, out dCameraHeight, out bPerspective);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setBitmapSize(int width, int height)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setBitmapSize(swigCPtr, width, height);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getBitmapSize(out int width, out int height)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getBitmapSize(swigCPtr, out width, out height);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setRenderMode(OdGsView_RenderMode rMode)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setRenderMode(swigCPtr, (int)rMode);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getRenderMode(out OdGsView_RenderMode rMode)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getRenderMode(swigCPtr, out rMode);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setBackground(uint backgroundColor)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setBackground(swigCPtr, backgroundColor);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getBackground(out uint backgroundColor)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getBackground(swigCPtr, out backgroundColor);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setDefaultColor(uint defColor)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_setDefaultColor(swigCPtr, defColor);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getDefaultColor(out uint defColor)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getDefaultColor(swigCPtr, out defColor);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult generate(ref OdGiRasterImage pOutPreview, bool bZoomToExtents)
	{
		IntPtr jarg = ((pOutPreview == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pOutPreview).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_generate__SWIG_0(swigCPtr, ref jarg, bZoomToExtents);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pOutPreview = null;
			}
			else if (jarg != intPtr)
			{
				pOutPreview = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult generate(ref OdGiRasterImage pOutPreview)
	{
		IntPtr jarg = ((pOutPreview == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pOutPreview).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_generate__SWIG_1(swigCPtr, ref jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pOutPreview = null;
			}
			else if (jarg != intPtr)
			{
				pOutPreview = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiRasterImage generateByView(PrcPreviewGenerator_ViewType viewType, out OdResult pResult)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_generateByView__SWIG_0(swigCPtr, (int)viewType, out pResult), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage generateByView(PrcPreviewGenerator_ViewType viewType)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_generateByView__SWIG_1(swigCPtr, (int)viewType), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult generatePreviewSet(OdGiRasterImagePtrArray arrRasImg)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_generatePreviewSet(swigCPtr, OdGiRasterImagePtrArray.getCPtr(arrRasImg).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		OdPrcModule_GlobalsPINVOKE.OdPrcPreviewGenerator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcPreviewGenerator));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
