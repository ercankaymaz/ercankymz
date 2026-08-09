using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDynBlockReferenceProperty : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbDynBlockReferenceProperty_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdDbDynBlockReferenceProperty_1();

	public delegate void SwigDelegateOdDbDynBlockReferenceProperty_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDynBlockReferenceProperty_0 swigDelegate0;

	private SwigDelegateOdDbDynBlockReferenceProperty_1 swigDelegate1;

	private SwigDelegateOdDbDynBlockReferenceProperty_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDynBlockReferenceProperty(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDynBlockReferenceProperty obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDynBlockReferenceProperty(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbDynBlockReferenceProperty()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReferenceProperty__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDynBlockReferenceProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbDynBlockReferenceProperty(OdDbDynBlockReferenceProperty other)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReferenceProperty__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDynBlockReferenceProperty) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbDynBlockReferenceProperty Assign(OdDbDynBlockReferenceProperty other)
	{
		OdDbDynBlockReferenceProperty result = new OdDbDynBlockReferenceProperty(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_Assign(swigCPtr, getCPtr(other)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId blockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_blockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string propertyName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_propertyName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public DwgDataType propertyType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_propertyType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgDataType)result;
	}

	public bool readOnly()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_readOnly(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool show()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_show(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool visibleInCurrentVisibilityState()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_visibleInCurrentVisibilityState(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string description()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_description(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDynBlockReferenceProperty_UnitsType unitsType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_unitsType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbDynBlockReferenceProperty_UnitsType)result;
	}

	public void getAllowedValues(OdDbEvalVariantArray allowedValues)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_getAllowedValues(swigCPtr, OdDbEvalVariantArray.getCPtr(allowedValues));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbEvalVariant value()
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_value(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool setValue(OdDbEvalVariant value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_setValue(swigCPtr, OdDbEvalVariant.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBlockParameter getParameter()
	{
		OdDbBlockParameter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParameter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_getParameter(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void getDescriptor(out uint parameterId, OdDbBlkParamPropertyDescriptor pDescriptor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_getDescriptor(swigCPtr, out parameterId, OdDbBlkParamPropertyDescriptor.getCPtr(pDescriptor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDynBlockReferenceProperty createObject()
	{
		OdDbDynBlockReferenceProperty rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDynBlockReferenceProperty>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferenceProperty_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDynBlockReferenceProperty));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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
}
