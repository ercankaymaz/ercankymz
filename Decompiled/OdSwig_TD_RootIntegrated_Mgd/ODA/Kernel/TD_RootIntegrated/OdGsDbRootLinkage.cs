using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsDbRootLinkage : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsDbRootLinkage(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsDbRootLinkage obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsDbRootLinkage()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsDbRootLinkage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsDbRootLinkage()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsDbRootLinkage(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void initialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_initialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void uninitialize()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_uninitialize();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isInitialized();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isInitializedAny()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isInitializedAny();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass getDbBaseDatabasePEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseDatabasePEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseDatabasePE getDbBaseDatabasePE(OdRxObject pDb)
	{
		OdDbBaseDatabasePE rXObject = Helpers.GetRXObject<OdDbBaseDatabasePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseDatabasePE(OdRxObject.getCPtr(pDb)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseDatabasePE getDbBaseDatabasePEForDrawable(OdGiDrawable pDrw, ref OdRxObject pDb)
	{
		IntPtr jarg = OdRxObject.getCPtr(pDb).Handle;
		try
		{
			OdDbBaseDatabasePE rXObject = Helpers.GetRXObject<OdDbBaseDatabasePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseDatabasePEForDrawable(OdGiDrawable.getCPtr(pDrw), ref jarg), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (OdRxObject.getCPtr(pDb).Handle != jarg)
			{
				pDb = Helpers.odCreateObjectInternal<OdRxObject>(typeof(OdRxObject), jarg, bIsWrapperOwnNativeObject: false);
			}
		}
	}

	public static OdRxClass getDbBaseHostAppServicesClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseHostAppServicesClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseHostAppServices getDbBaseHostAppServices(OdRxObject pServices)
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseHostAppServices(OdRxObject.getCPtr(pServices)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseHostAppServices getDatabaseDbBaseHostAppServices(OdRxObject pDb)
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDatabaseDbBaseHostAppServices(OdRxObject.getCPtr(pDb)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool displayWarning(OdRxObject pDb, string message)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_displayWarning(OdRxObject.getCPtr(pDb), message);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass getDbBaseLayerPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLayerPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLayerPE getDbBaseLayerPE(OdRxObject pLayer)
	{
		OdDbBaseLayerPE rXObject = Helpers.GetRXObject<OdDbBaseLayerPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLayerPE(OdRxObject.getCPtr(pLayer)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseVisualStylePEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseVisualStylePEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseVisualStylePE getDbBaseVisualStylePE(OdRxObject pVisualStyle)
	{
		OdDbBaseVisualStylePE rXObject = Helpers.GetRXObject<OdDbBaseVisualStylePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseVisualStylePE(OdRxObject.getCPtr(pVisualStyle)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseAnnotationScalePEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseAnnotationScalePEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseAnnotationScalePE getDbBaseAnnotationScalePE(OdRxObject pView)
	{
		OdDbBaseAnnotationScalePE rXObject = Helpers.GetRXObject<OdDbBaseAnnotationScalePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseAnnotationScalePE(OdRxObject.getCPtr(pView)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseMaterialPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseMaterialPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseMaterialPE getDbBaseMaterialPE(OdRxObject pMaterial)
	{
		OdDbBaseMaterialPE rXObject = Helpers.GetRXObject<OdDbBaseMaterialPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseMaterialPE(OdRxObject.getCPtr(pMaterial)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseLayoutPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLayoutPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLayoutPE getDbBaseLayoutPE(OdRxObject pLayout)
	{
		OdDbBaseLayoutPE rXObject = Helpers.GetRXObject<OdDbBaseLayoutPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLayoutPE(OdRxObject.getCPtr(pLayout)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool isLayoutDrawable(OdGiDrawable pLayout)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isLayoutDrawable(OdGiDrawable.getCPtr(pLayout));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass getAbstractViewPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getAbstractViewPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdAbstractViewPE getAbstractViewPE(OdRxObject pViewport)
	{
		OdAbstractViewPE rXObject = Helpers.GetRXObject<OdAbstractViewPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getAbstractViewPE(OdRxObject.getCPtr(pViewport)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseBlockPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseBlockPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseBlockPE getDbBaseBlockPE(OdRxObject pBlock)
	{
		OdDbBaseBlockPE rXObject = Helpers.GetRXObject<OdDbBaseBlockPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseBlockPE(OdRxObject.getCPtr(pBlock)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseBlockRefPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseBlockRefPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseBlockRefPE getDbBaseBlockRefPE(OdRxObject pBlockRef)
	{
		OdDbBaseBlockRefPE rXObject = Helpers.GetRXObject<OdDbBaseBlockRefPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseBlockRefPE(OdRxObject.getCPtr(pBlockRef)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool isBlockRefDrawable(OdGiDrawable pBlockRef, bool bMInsert)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isBlockRefDrawable__SWIG_0(OdGiDrawable.getCPtr(pBlockRef), bMInsert);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isBlockRefDrawable(OdGiDrawable pBlockRef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isBlockRefDrawable__SWIG_1(OdGiDrawable.getCPtr(pBlockRef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass getDbBaseSortEntsPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseSortEntsPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseSortEntsPE getDbBaseSortEntsPE(OdRxObject pSortents)
	{
		OdDbBaseSortEntsPE rXObject = Helpers.GetRXObject<OdDbBaseSortEntsPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseSortEntsPE(OdRxObject.getCPtr(pSortents)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseLongTransactionPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLongTransactionPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLongTransactionPE getDbBaseLongTransactionPE(OdRxObject pLT)
	{
		OdDbBaseLongTransactionPE rXObject = Helpers.GetRXObject<OdDbBaseLongTransactionPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLongTransactionPE(OdRxObject.getCPtr(pLT)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxClass getDbBaseHatchPEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseHatchPEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseHatchPE getDbBaseHatchPE(OdRxObject pHatch)
	{
		OdDbBaseHatchPE rXObject = Helpers.GetRXObject<OdDbBaseHatchPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseHatchPE(OdRxObject.getCPtr(pHatch)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool isHatchDrawable(OdGiDrawable pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_isHatchDrawable(OdGiDrawable.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxClass getDbBaseLinetypePEClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLinetypePEClass(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLinetypePE getDbBaseLinetypePE(OdRxObject pLinetype)
	{
		OdDbBaseLinetypePE rXObject = Helpers.GetRXObject<OdDbBaseLinetypePE>(TD_RootIntegrated_GlobalsPINVOKE.OdGsDbRootLinkage_getDbBaseLinetypePE(OdRxObject.getCPtr(pLinetype)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
