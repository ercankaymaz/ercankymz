using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFdFieldEnginePE : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFdFieldEnginePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFdFieldEnginePE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFdFieldEnginePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFdFieldEnginePE cast(OdRxObject pObj)
	{
		OdFdFieldEnginePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEnginePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFdFieldEnginePE createObject()
	{
		OdFdFieldEnginePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldEnginePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getSheetSetProperty(ref string propValue, OdDbField pField, OdDbDatabase pDb)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(propValue);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getSheetSetProperty(swigCPtr, ref jarg, OdDbField.getCPtr(pField), OdDbDatabase.getCPtr(pDb));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				propValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool parseObjProp(string prop, OdDbDatabase pDb, OdDbObjectId objId, ref string propName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(propName);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_parseObjProp(swigCPtr, prop, OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(objId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				propName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getObjPropValue(string propName, int paramId, OdDbObjectId objId, ref OdFdFieldResult result)
	{
		IntPtr jarg = ((result == null) ? IntPtr.Zero : OdFdFieldResult.getCPtr(result).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result2 = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getObjPropValue(swigCPtr, propName, paramId, OdDbObjectId.getCPtr(objId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result2;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				result = null;
			}
			if (jarg != intPtr)
			{
				result = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFdFieldResult>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbDatabase getCurrentDb()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getCurrentDb(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getFileName(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getFileName(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getLispVariable(string lispVar, ref OdFieldValue fValue)
	{
		IntPtr jarg = ((fValue == null) ? IntPtr.Zero : OdFieldValue.getCPtr(fValue).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getLispVariable(swigCPtr, lispVar, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fValue = null;
			}
			if (jarg != intPtr)
			{
				fValue = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFieldValue>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbObjectId getOwnerTable(OdDbField field)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getOwnerTable(swigCPtr, OdDbField.getCPtr(field)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult cvUnit(double input, string from, string to, out double output)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_cvUnit(swigCPtr, input, from, to, out output);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFdFieldEnginePE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
