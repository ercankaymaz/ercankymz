using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionIdSaver : OdGsFilerExtension
{
	public class SubstitutionActuator : OdGsFilerExtensionSubstitutor.SubstitutionActuator
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SubstitutionActuator(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_SubstitutionActuator_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(SubstitutionActuator obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionIdSaver_SubstitutionActuator(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public SubstitutionActuator()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionIdSaver_SubstitutionActuator(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void selfDelete(IntPtr arg0)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_SubstitutionActuator_selfDelete(swigCPtr, arg0);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override void applySubstitution(IntPtr pPlace, IntPtr pValue, TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate pSetFunc)
		{
			TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegateNative substitutionActuator_SetPtrFuncDelegateNative = null;
			if (pSetFunc != null)
			{
				substitutionActuator_SetPtrFuncDelegateNative = delegate(IntPtr pPlace_, IntPtr pValue_)
				{
					pSetFunc(pPlace_, pValue_);
				};
			}
			IntPtr jarg = ((pSetFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(substitutionActuator_SetPtrFuncDelegateNative));
			DelegateHolder.Add(substitutionActuator_SetPtrFuncDelegateNative);
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_SubstitutionActuator_applySubstitution__SWIG_0_0(swigCPtr, pPlace, pValue, jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void applySubstitution(IntPtr pPlace, IntPtr pValue, TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate pSetFunc, IntPtr arg3)
		{
			TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegateNative substitutionActuator_SetPtrFuncDelegateNative = null;
			if (pSetFunc != null)
			{
				substitutionActuator_SetPtrFuncDelegateNative = delegate(IntPtr pPlace_, IntPtr pValue_)
				{
					pSetFunc(pPlace_, pValue_);
				};
			}
			IntPtr jarg = ((pSetFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(substitutionActuator_SetPtrFuncDelegateNative));
			DelegateHolder.Add(substitutionActuator_SetPtrFuncDelegateNative);
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_SubstitutionActuator_applySubstitution__SWIG_1(swigCPtr, pPlace, pValue, jarg, arg3);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionIdSaver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionIdSaver obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionIdSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionIdSaver cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionIdSaver result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionIdSaver(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setActiveModel(OdGsModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_setActiveModel(swigCPtr, OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsModel activeModel()
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_activeModel(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void linkObject(OdGsFilerObjectId gsId, OdRxObject pObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_linkObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unlinkObject(OdGsFilerObjectId gsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_unlinkObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hasLinkedObject(OdGsFilerObjectId gsId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_hasLinkedObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject linkedObject(OdGsFilerObjectId gsId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_linkedObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void regWrId(OdGsFilerObjectId gsId, IntPtr pLinkedObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_regWrId__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pLinkedObject);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void regWrId(OdGsFilerObjectId gsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_regWrId__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual IntPtr linkedWrIdObject(OdGsFilerObjectId gsId)
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_linkedWrIdObject(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void wrId(OdGsFiler pFiler, OdGsFilerObjectId gsId, IntPtr pLinkedObject, OdGsFilerExtensionIdSaver_WrIdType wrIdType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_wrId__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsFilerObjectId.getCPtr(gsId), pLinkedObject, (int)wrIdType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrId(OdGsFiler pFiler, OdGsFilerObjectId gsId, IntPtr pLinkedObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_wrId__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsFilerObjectId.getCPtr(gsId), pLinkedObject);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrId(OdGsFiler pFiler, OdGsFilerObjectId gsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_wrId__SWIG_2(swigCPtr, OdGsFiler.getCPtr(pFiler), OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrRequest(OdGsFilerObjectId gsId, IntPtr pLinkedObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_wrRequest__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pLinkedObject);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void wrRequest(OdGsFilerObjectId gsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_wrRequest__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processedWrId(OdGsFilerObjectId gsId, IntPtr pLinkedObject)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_processedWrId__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pLinkedObject);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processedWrId(OdGsFilerObjectId gsId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_processedWrId__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isWrittenId(OdGsFilerObjectId gsId, IntPtr pLinkedObject)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_isWrittenId__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pLinkedObject);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isWrittenId(OdGsFilerObjectId gsId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_isWrittenId__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clearWrIds(OdGsFilerObjectIdArray pFillArray)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_clearWrIds__SWIG_0(swigCPtr, OdGsFilerObjectIdArray.getCPtr(pFillArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearWrIds()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_clearWrIds__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsFilerObjectId rdId(OdGsFiler pFiler)
	{
		OdGsFilerObjectId result = new OdGsFilerObjectId(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_rdId__SWIG_0(swigCPtr, OdGsFiler.getCPtr(pFiler)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsFilerObjectId rdId(OdGsFiler pFiler, IntPtr pPlace, uint size)
	{
		OdGsFilerObjectId result = new OdGsFilerObjectId(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_rdId__SWIG_1(swigCPtr, OdGsFiler.getCPtr(pFiler), pPlace, size), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsFilerObjectId rdId(OdGsFiler pFiler, IntPtr pPlace)
	{
		OdGsFilerObjectId result = new OdGsFilerObjectId(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_rdId__SWIG_2(swigCPtr, OdGsFiler.getCPtr(pFiler), pPlace), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerObjectId rdId(OdGsFiler pFiler, out ulong pValue)
	{
		OdGsFilerObjectId result = new OdGsFilerObjectId(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_rdId__SWIG_3(swigCPtr, OdGsFiler.getCPtr(pFiler), out pValue), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void requestId(OdGsFilerObjectId gsId, IntPtr pPlace, uint size, SubstitutionActuator pActuator, IntPtr pArg)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_requestId__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pPlace, size, SubstitutionActuator.getCPtr(pActuator), pArg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void requestId(OdGsFilerObjectId gsId, IntPtr pPlace, uint size, SubstitutionActuator pActuator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_requestId__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pPlace, size, SubstitutionActuator.getCPtr(pActuator));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void requestId(OdGsFilerObjectId gsId, IntPtr pPlace, uint size)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_requestId__SWIG_2(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pPlace, size);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void requestId(OdGsFilerObjectId gsId, IntPtr pPlace)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_requestId__SWIG_3(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pPlace);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void registerId(OdGsFilerObjectId gsId, IntPtr pValue, uint size)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_registerId__SWIG_0(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pValue, size);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void registerId(OdGsFilerObjectId gsId, ulong pValue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_registerId__SWIG_1(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void registerId(OdGsFilerObjectId gsId, IntPtr pValue)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_registerId__SWIG_2(swigCPtr, OdGsFilerObjectId.getCPtr(gsId), pValue);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool referencedIds(OdGsFilerObjectIdArray pFillArray)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_referencedIds__SWIG_0(swigCPtr, OdGsFilerObjectIdArray.getCPtr(pFillArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool referencedIds()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionIdSaver_referencedIds__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
