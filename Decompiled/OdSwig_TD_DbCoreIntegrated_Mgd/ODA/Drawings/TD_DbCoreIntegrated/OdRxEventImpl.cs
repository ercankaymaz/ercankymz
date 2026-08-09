using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdRxEventImpl : OdEditor
{
	public delegate IntPtr SwigDelegateOdRxEventImpl_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxEventImpl_1();

	public delegate void SwigDelegateOdRxEventImpl_2(IntPtr pSource);

	public delegate void SwigDelegateOdRxEventImpl_3(IntPtr pReactor);

	public delegate void SwigDelegateOdRxEventImpl_4(IntPtr pReactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxEventImpl_0 swigDelegate0;

	private SwigDelegateOdRxEventImpl_1 swigDelegate1;

	private SwigDelegateOdRxEventImpl_2 swigDelegate2;

	private SwigDelegateOdRxEventImpl_3 swigDelegate3;

	private SwigDelegateOdRxEventImpl_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxEventReactor) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxEventReactor) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxEventImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxEventImpl obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdRxEventImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdRxEventImpl()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdRxEventImpl(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxEventImpl) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdRxEventImpl cast(OdRxObject pObj)
	{
		OdRxEventImpl rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventImpl>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_isASwigExplicitOdRxEventImpl(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_queryXSwigExplicitOdRxEventImpl(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void addReactor(OdRxEventReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_addReactorSwigExplicitOdRxEventImpl(swigCPtr, OdRxEventReactor.getCPtr(pReactor));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_addReactor(swigCPtr, OdRxEventReactor.getCPtr(pReactor));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void removeReactor(OdRxEventReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_removeReactorSwigExplicitOdRxEventImpl(swigCPtr, OdRxEventReactor.getCPtr(pReactor));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_removeReactor(swigCPtr, OdRxEventReactor.getCPtr(pReactor));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_dwgFileOpened(OdDbDatabase db, string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_dwgFileOpened(swigCPtr, OdDbDatabase.getCPtr(db), filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_initialDwgFileOpenComplete(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_initialDwgFileOpenComplete(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_databaseConstructed(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_databaseConstructed(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_databaseToBeDestroyed(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_databaseToBeDestroyed(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginSave(OdDbDatabase db, string pIntendedName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginSave(swigCPtr, OdDbDatabase.getCPtr(db), pIntendedName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_saveComplete(OdDbDatabase db, string pActualName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_saveComplete(swigCPtr, OdDbDatabase.getCPtr(db), pActualName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_abortSave(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortSave(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginDxfIn(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDxfIn(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_abortDxfIn(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortDxfIn(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_dxfInComplete(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_dxfInComplete(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginDxfOut(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDxfOut(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_abortDxfOut(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortDxfOut(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_dxfOutComplete(OdDbDatabase db)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_dxfOutComplete(swigCPtr, OdDbDatabase.getCPtr(db));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginInsert(OdDbDatabase pTo, string pBlockName, OdDbDatabase pFrom)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginInsert__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pTo), pBlockName, OdDbDatabase.getCPtr(pFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginInsert(OdDbDatabase pTo, OdGeMatrix3d xform, OdDbDatabase pFrom)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginInsert__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pTo), OdGeMatrix3d.getCPtr(xform), OdDbDatabase.getCPtr(pFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_otherInsert(OdDbDatabase pTo, ref OdDbIdMapping idMap, OdDbDatabase pFrom)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_otherInsert(swigCPtr, OdDbDatabase.getCPtr(pTo), ref jarg, OdDbDatabase.getCPtr(pFrom));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_abortInsert(OdDbDatabase pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortInsert(swigCPtr, OdDbDatabase.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_endInsert(OdDbDatabase pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endInsert(swigCPtr, OdDbDatabase.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_wblockNotice(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_wblockNotice(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginWblock(OdDbDatabase pTo, OdDbDatabase pFrom, OdGePoint3d insertionPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginWblock__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pTo), OdDbDatabase.getCPtr(pFrom), OdGePoint3d.getCPtr(insertionPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginWblock(OdDbDatabase pTo, OdDbDatabase pFrom, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginWblock__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pTo), OdDbDatabase.getCPtr(pFrom), OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginWblock(OdDbDatabase pTo, OdDbDatabase pFrom)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginWblock__SWIG_2(swigCPtr, OdDbDatabase.getCPtr(pTo), OdDbDatabase.getCPtr(pFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_otherWblock(OdDbDatabase pTo, ref OdDbIdMapping m, OdDbDatabase pFrom)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_otherWblock(swigCPtr, OdDbDatabase.getCPtr(pTo), ref jarg, OdDbDatabase.getCPtr(pFrom));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_abortWblock(OdDbDatabase pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortWblock(swigCPtr, OdDbDatabase.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_endWblock(OdDbDatabase pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endWblock(swigCPtr, OdDbDatabase.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginWblockObjects(OdDbDatabase pDb, ref OdDbIdMapping m)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginWblockObjects(swigCPtr, OdDbDatabase.getCPtr(pDb), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_beginDeepClone(OdDbDatabase pTo, ref OdDbIdMapping m)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDeepClone(swigCPtr, OdDbDatabase.getCPtr(pTo), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_beginDeepCloneXlation(ref OdDbIdMapping m)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDeepCloneXlation(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_abortDeepClone(ref OdDbIdMapping m)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortDeepClone(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_endDeepClone(ref OdDbIdMapping m)
	{
		IntPtr jarg = ((m == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(m).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endDeepClone(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				m = null;
			}
			if (jarg != intPtr)
			{
				m = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void fire_partialOpenNotice(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_partialOpenNotice(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubCommandStart(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths, out bool vetoOp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubCommandStart__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle, out vetoOp);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubCommandEnd(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubCommandEnd(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubCommandAborted(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubCommandAborted(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginDwgOpen(string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDwgOpen(swigCPtr, filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_endDwgOpen(string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endDwgOpen(swigCPtr, filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginClose(OdDbDatabase pDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginClose(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginAttach(OdDbDatabase pToDb, string filename, OdDbDatabase pFromDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_otherAttach(OdDbDatabase pToDb, OdDbDatabase pFromDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_otherAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbDatabase.getCPtr(pFromDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_abortAttach(OdDbDatabase pFromDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortAttach(swigCPtr, OdDbDatabase.getCPtr(pFromDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_endAttach(OdDbDatabase pToDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endAttach(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_redirected(OdDbObjectId newId, OdDbObjectId oldId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_redirected(swigCPtr, OdDbObjectId.getCPtr(newId), OdDbObjectId.getCPtr(oldId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_comandeered(OdDbDatabase pToDb, OdDbObjectId id, OdDbDatabase pFromDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_comandeered(swigCPtr, OdDbDatabase.getCPtr(pToDb), OdDbObjectId.getCPtr(id), OdDbDatabase.getCPtr(pFromDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginRestore(OdDbDatabase pToDb, string filename, OdDbDatabase pFromDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb), filename, OdDbDatabase.getCPtr(pFromDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_abortRestore(OdDbDatabase pToDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_abortRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_endRestore(OdDbDatabase pToDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_endRestore(swigCPtr, OdDbDatabase.getCPtr(pToDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubCommandStart(OdDbDatabase pHostDb, OdXrefSubCommand subCmd, OdDbObjectIdArray btrIds, OdStringArray btrNames, OdStringArray paths)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubCommandStart__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pHostDb), (int)subCmd, OdDbObjectIdArray.getCPtr(btrIds), OdStringArray.getCPtr(btrNames).Handle, OdStringArray.getCPtr(paths).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandBindItem(int activity, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandBindItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandAttachItem(int activity, string xrefPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandAttachItem(swigCPtr, activity, xrefPath);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandOverlayItem(int activity, string xrefPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandOverlayItem(swigCPtr, activity, xrefPath);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandDetachItem(int activity, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandDetachItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandPathItem(int activity, OdDbObjectId blockId, string newPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandPathItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId), newPath);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandReloadItem(int activity, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandReloadItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_xrefSubcommandUnloadItem(int activity, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_xrefSubcommandUnloadItem(swigCPtr, activity, OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandAuto(int activity, bool state)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandAuto(swigCPtr, activity, state);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandControl(int activity, int option)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandControl(swigCPtr, activity, option);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandBegin(int activity)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandBegin(swigCPtr, activity);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandEnd(int activity)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandEnd(swigCPtr, activity);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandMark(int activity)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandMark(swigCPtr, activity);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandBack(int activity)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandBack(swigCPtr, activity);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_undoSubcommandNumber(int activity, int num)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_undoSubcommandNumber(swigCPtr, activity, num);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_pickfirstModified()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_pickfirstModified(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_layoutSwitched(string newLayoutName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_layoutSwitched(swigCPtr, newLayoutName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_docFrameMovedOrResized(ulong hwndDocFrame, bool moved)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_docFrameMovedOrResized(swigCPtr, hwndDocFrame, moved);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_mainFrameMovedOrResized(ulong hwndMainFrame, bool moved)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_mainFrameMovedOrResized(swigCPtr, hwndMainFrame, moved);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginDoubleClick(OdGePoint3d clickPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginDoubleClick(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginRightClick(OdGePoint3d clickPoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginRightClick(swigCPtr, OdGePoint3d.getCPtr(clickPoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_toolbarBitmapSizeWillChange(bool largeBitmaps)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_toolbarBitmapSizeWillChange(swigCPtr, largeBitmaps);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_toolbarBitmapSizeChanged(bool largeBitmaps)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_toolbarBitmapSizeChanged(swigCPtr, largeBitmaps);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_objectsLazyLoaded(OdDbObjectIdArray objectIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_objectsLazyLoaded(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_beginQuit()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_beginQuit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_quitAborted()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_quitAborted(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_quitWillStart()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_quitWillStart(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_modelessOperationWillStart(string contextString)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_modelessOperationWillStart(swigCPtr, contextString);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_modelessOperationEnded(string contextString)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_modelessOperationEnded(swigCPtr, contextString);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_sysVarChanged(OdDbDatabase pDb, string varName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_sysVarChanged(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fire_sysVarWillChange(OdDbDatabase pDb, string varName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_fire_sysVarWillChange(swigCPtr, OdDbDatabase.getCPtr(pDb), varName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdRxEventImpl createObject()
	{
		OdRxEventImpl rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventImpl>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremoveReactor;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxEventImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxEventImpl));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodaddReactor(IntPtr pReactor)
	{
		try
		{
			addReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodremoveReactor(IntPtr pReactor)
	{
		try
		{
			removeReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxEventReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
