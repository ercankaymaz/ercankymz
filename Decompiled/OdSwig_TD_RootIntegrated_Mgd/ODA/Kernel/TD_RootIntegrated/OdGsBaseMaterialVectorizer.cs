using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseMaterialVectorizer : OdGsBaseVectorizer
{
	public class DelayCacheEntry : IDisposable
	{
		public delegate int SwigDelegateDelayCacheEntry_0();

		public delegate void SwigDelegateDelayCacheEntry_1(IntPtr mView);

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateDelayCacheEntry_0 swigDelegate0;

		private SwigDelegateDelayCacheEntry_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[0];

		private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGsBaseMaterialVectorizer) };

		public DelayCacheEntry m_pNext
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_m_pNext_get(swigCPtr);
				DelayCacheEntry result = ((intPtr == IntPtr.Zero) ? null : new DelayCacheEntry(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_m_pNext_set(swigCPtr, getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DelayCacheEntry(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DelayCacheEntry obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DelayCacheEntry()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseMaterialVectorizer_DelayCacheEntry(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DelayCacheEntry()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseMaterialVectorizer_DelayCacheEntry(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(DelayCacheEntry) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		public virtual OdGsBaseMaterialVectorizer_DelayCacheEntryType internalType()
		{
			int result = (SwigDerivedClassHasMethod("internalType", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_internalTypeSwigExplicitDelayCacheEntry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_internalType(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGsBaseMaterialVectorizer_DelayCacheEntryType)result;
		}

		public DelayCacheEntry nextEntry()
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_nextEntry(swigCPtr);
			DelayCacheEntry result = ((intPtr == IntPtr.Zero) ? null : new DelayCacheEntry(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setNextEntry(DelayCacheEntry pNext)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_setNextEntry(swigCPtr, getCPtr(pNext));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void play(OdGsBaseMaterialVectorizer mView)
		{
			if (SwigDerivedClassHasMethod("play", swigMethodTypes1))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_playSwigExplicitDelayCacheEntry(swigCPtr, OdGsBaseMaterialVectorizer.getCPtr(mView));
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_play(swigCPtr, OdGsBaseMaterialVectorizer.getCPtr(mView));
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("internalType", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodinternalType;
			}
			if (SwigDerivedClassHasMethod("play", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorMethodplay;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_DelayCacheEntry_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(DelayCacheEntry));
		}

		private int SwigDirectorMethodinternalType()
		{
			return (int)internalType();
		}

		private void SwigDirectorMethodplay(IntPtr mView)
		{
			try
			{
				play(new OdGsBaseMaterialVectorizer(mView, cMemoryOwn: false));
			}
			catch (OdEdEmptyInput err)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err);
			}
			catch (OdEdOtherInput err2)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err2);
			}
			catch (OdError err3)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err3);
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseMaterialVectorizer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseMaterialVectorizer obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseMaterialVectorizer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual void onTraitsModified()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_onTraitsModified(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void beginMetafile(OdRxObject pMetafile)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void endMetafile(OdRxObject pMetafile)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_endMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void beginViewVectorization()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginViewVectorization(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void endViewVectorization()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_endViewVectorization(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void processMaterialNode(OdDbStub materialId, OdGsMaterialNode node)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_processMaterialNode(swigCPtr, OdDbStub.getCPtr(materialId), OdGsMaterialNode.getCPtr(node));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool saveMaterialCache(OdGsMaterialNode pNode, OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_saveMaterialCache(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool loadMaterialCache(OdGsMaterialNode pNode, OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_loadMaterialCache(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool doDraw(uint drawableFlags, OdGiDrawable pDrawable)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_doDraw(swigCPtr, drawableFlags, OdGiDrawable.getCPtr(pDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void beginLightsAccumulation(bool bAccumNonCached, bool bAccumCached, bool bClear)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginLightsAccumulation__SWIG_0(swigCPtr, bAccumNonCached, bAccumCached, bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void beginLightsAccumulation(bool bAccumNonCached, bool bAccumCached)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginLightsAccumulation__SWIG_1(swigCPtr, bAccumNonCached, bAccumCached);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void beginLightsAccumulation(bool bAccumNonCached)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginLightsAccumulation__SWIG_2(swigCPtr, bAccumNonCached);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void beginLightsAccumulation()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_beginLightsAccumulation__SWIG_3(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void playAccumulatedLights(OdGsLightsAccumulationContainter pAccumLights, bool bClear)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_playAccumulatedLights__SWIG_0(swigCPtr, OdGsLightsAccumulationContainter.getCPtr(pAccumLights), bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void playAccumulatedLights(OdGsLightsAccumulationContainter pAccumLights)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_playAccumulatedLights__SWIG_1(swigCPtr, OdGsLightsAccumulationContainter.getCPtr(pAccumLights));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void playAccumulatedLights()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_playAccumulatedLights__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsLightsAccumulationContainter getAccumulatedLights()
	{
		OdGsLightsAccumulationContainter result = new OdGsLightsAccumulationContainter(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_getAccumulatedLights__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isLightsAccumulation()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isLightsAccumulation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void addPointLight(OdGiPointLightTraitsData arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_addPointLight(swigCPtr, OdGiPointLightTraitsData.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void addSpotLight(OdGiSpotLightTraitsData arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_addSpotLight(swigCPtr, OdGiSpotLightTraitsData.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void addDistantLight(OdGiDistantLightTraitsData arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_addDistantLight(swigCPtr, OdGiDistantLightTraitsData.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void addWebLight(OdGiWebLightTraitsData arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_addWebLight(swigCPtr, OdGiWebLightTraitsData.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialItem currentMaterial()
	{
		OdGiMaterialItem rXObject = Helpers.GetRXObject<OdGiMaterialItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_currentMaterial(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void resetCurrentMaterial(OdGiMaterialItem pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_resetCurrentMaterial__SWIG_0(swigCPtr, OdGiMaterialItem.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMaterialEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isMaterialEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMaterialAvailable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isMaterialAvailable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetCurrentMaterial()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_resetCurrentMaterial__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMapperItem currentMapper(bool bForCoords)
	{
		OdGiMapperItem rXObject = Helpers.GetRXObject<OdGiMapperItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_currentMapper__SWIG_0(swigCPtr, bForCoords), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiMapperItem currentMapper()
	{
		OdGiMapperItem rXObject = Helpers.GetRXObject<OdGiMapperItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_currentMapper__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void resetCurrentMapper(OdGiMapperItem pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_resetCurrentMapper(swigCPtr, OdGiMapperItem.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMapperEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isMapperEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMapperAvailable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isMapperAvailable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMappingDelayed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_isMappingDelayed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getDeviceMapperMatrix(OdGeMatrix3d dm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_getDeviceMapperMatrix(swigCPtr, OdGeMatrix3d.getCPtr(dm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool skipMaterialProcess(OdDbStub materialId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_skipMaterialProcess(swigCPtr, OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void nullMaterialStub()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_nullMaterialStub(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialItem fillMaterialCache(OdGiMaterialItem prevCache, OdDbStub materialId, OdGiMaterialTraitsData materialData)
	{
		OdGiMaterialItem rXObject = Helpers.GetRXObject<OdGiMaterialItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_fillMaterialCache(swigCPtr, OdGiMaterialItem.getCPtr(prevCache), OdDbStub.getCPtr(materialId), OdGiMaterialTraitsData.getCPtr(materialData)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void renderMaterialCache(OdGiMaterialItem pCache, OdDbStub materialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_renderMaterialCache(swigCPtr, OdGiMaterialItem.getCPtr(pCache), OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void playDelayCacheEntry(DelayCacheEntry pEntry)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_playDelayCacheEntry(swigCPtr, DelayCacheEntry.getCPtr(pEntry));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendDelayCacheEntry(DelayCacheEntry pEntry)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_appendDelayCacheEntry(swigCPtr, DelayCacheEntry.getCPtr(pEntry));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapperChangedForDelayCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_mapperChangedForDelayCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void delayCacheProcessed(OdGiDrawable pDrawable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_delayCacheProcessed(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool saveMaterialItem(OdGiMaterialItem pMatItem, OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_saveMaterialItem(swigCPtr, OdGiMaterialItem.getCPtr(pMatItem), OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialItem loadMaterialItem(OdGsFiler pFiler)
	{
		OdGiMaterialItem rXObject = Helpers.GetRXObject<OdGiMaterialItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_loadMaterialItem(swigCPtr, OdGsFiler.getCPtr(pFiler)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool saveMaterialTexture(OdGiMaterialTexture pTexture, OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_saveMaterialTexture(OdGiMaterialTexture.getCPtr(pTexture), OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiMaterialTexture loadMaterialTexture(OdGsFiler pFiler)
	{
		OdGiMaterialTexture rXObject = Helpers.GetRXObject<OdGiMaterialTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_loadMaterialTexture(OdGsFiler.getCPtr(pFiler)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static bool saveMaterialTextureManager(OdGiMaterialTextureManager pManager, OdGsFiler pFiler, OdGsMaterialTextureDataFiler pSaver)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_saveMaterialTextureManager(OdGiMaterialTextureManager.getCPtr(pManager), OdGsFiler.getCPtr(pFiler), OdGsMaterialTextureDataFiler.getCPtr(pSaver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool loadMaterialTextureManager(OdGiMaterialTextureManager pManager, OdGsFiler pFiler, OdGsMaterialTextureDataFiler pSaver)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_loadMaterialTextureManager(OdGiMaterialTextureManager.getCPtr(pManager), OdGsFiler.getCPtr(pFiler), OdGsMaterialTextureDataFiler.getCPtr(pSaver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveClientMaterialCache(OdRxObject pMtl, OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_saveClientMaterialCache(swigCPtr, OdRxObject.getCPtr(pMtl), OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject loadClientMaterialCache(OdGsFiler pFiler, OdGiMaterialItem pMatItem)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseMaterialVectorizer_loadClientMaterialCache(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGiMaterialItem.getCPtr(pMatItem)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
