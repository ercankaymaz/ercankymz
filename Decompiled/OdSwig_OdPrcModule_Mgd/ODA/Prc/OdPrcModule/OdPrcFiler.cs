using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFiler : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcFiler_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcFiler_1();

	public delegate void SwigDelegateOdPrcFiler_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcFiler_3(IntPtr pFilerController);

	public delegate void SwigDelegateOdPrcFiler_4(uint version);

	public delegate uint SwigDelegateOdPrcFiler_5();

	public delegate IntPtr SwigDelegateOdPrcFiler_6();

	public delegate ulong SwigDelegateOdPrcFiler_7(long offset, int seekType);

	public delegate ulong SwigDelegateOdPrcFiler_8();

	public delegate ulong SwigDelegateOdPrcFiler_9();

	public delegate void SwigDelegateOdPrcFiler_10(string pBlockName);

	public delegate void SwigDelegateOdPrcFiler_11(string pArrayName, uint size);

	public delegate void SwigDelegateOdPrcFiler_12(string pElementName, uint index);

	public delegate void SwigDelegateOdPrcFiler_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcFiler_0 swigDelegate0;

	private SwigDelegateOdPrcFiler_1 swigDelegate1;

	private SwigDelegateOdPrcFiler_2 swigDelegate2;

	private SwigDelegateOdPrcFiler_3 swigDelegate3;

	private SwigDelegateOdPrcFiler_4 swigDelegate4;

	private SwigDelegateOdPrcFiler_5 swigDelegate5;

	private SwigDelegateOdPrcFiler_6 swigDelegate6;

	private SwigDelegateOdPrcFiler_7 swigDelegate7;

	private SwigDelegateOdPrcFiler_8 swigDelegate8;

	private SwigDelegateOdPrcFiler_9 swigDelegate9;

	private SwigDelegateOdPrcFiler_10 swigDelegate10;

	private SwigDelegateOdPrcFiler_11 swigDelegate11;

	private SwigDelegateOdPrcFiler_12 swigDelegate12;

	private SwigDelegateOdPrcFiler_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcFilerController) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(long),
		typeof(OdDb_FilerSeekType)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(string),
		typeof(uint)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(string),
		typeof(uint)
	};

	private static Type[] swigMethodTypes13 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcFiler(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcFiler_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFiler obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFiler(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcFiler(uint version)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFiler__SWIG_0(version), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcFiler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected OdPrcFiler()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFiler__SWIG_1(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcFiler) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcFiler cast(OdRxObject pObj)
	{
		OdPrcFiler rXObject = Helpers.GetRXObject<OdPrcFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcFiler_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcFiler_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcFiler_isASwigExplicitOdPrcFiler(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFiler_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcFiler_queryXSwigExplicitOdPrcFiler(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcFiler_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcFiler createObject()
	{
		OdPrcFiler rXObject = Helpers.GetRXObject<OdPrcFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcFiler_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setController(OdPrcFilerController pFilerController)
	{
		if (SwigDerivedClassHasMethod("setController", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_setControllerSwigExplicitOdPrcFiler(swigCPtr, OdPrcFilerController.getCPtr(pFilerController));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_setController(swigCPtr, OdPrcFilerController.getCPtr(pFilerController));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVersion(uint version)
	{
		if (SwigDerivedClassHasMethod("setVersion", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_setVersionSwigExplicitOdPrcFiler(swigCPtr, version);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_setVersion(swigCPtr, version);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint version()
	{
		uint result = (SwigDerivedClassHasMethod("version", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcFiler_versionSwigExplicitOdPrcFiler(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFiler_version(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPrcFilerController controller()
	{
		OdPrcFilerController rXObject = Helpers.GetRXObject<OdPrcFilerController>(SwigDerivedClassHasMethod("controller", swigMethodTypes6) ? OdPrcModule_GlobalsPINVOKE.OdPrcFiler_controllerSwigExplicitOdPrcFiler(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFiler_controller(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcFiler_seek(swigCPtr, offset, (int)seekType);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong tell()
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcFiler_tell(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong length()
	{
		ulong result = OdPrcModule_GlobalsPINVOKE.OdPrcFiler_length(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void levelIn(string pBlockName)
	{
		if (SwigDerivedClassHasMethod("levelIn", swigMethodTypes10))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_levelInSwigExplicitOdPrcFiler(swigCPtr, pBlockName);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_levelIn(swigCPtr, pBlockName);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void arrayIn(string pArrayName, uint size)
	{
		if (SwigDerivedClassHasMethod("arrayIn", swigMethodTypes11))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_arrayInSwigExplicitOdPrcFiler(swigCPtr, pArrayName, size);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_arrayIn(swigCPtr, pArrayName, size);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void arrayElemIn(string pElementName, uint index)
	{
		if (SwigDerivedClassHasMethod("arrayElemIn", swigMethodTypes12))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_arrayElemInSwigExplicitOdPrcFiler(swigCPtr, pElementName, index);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_arrayElemIn(swigCPtr, pElementName, index);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void levelOut()
	{
		if (SwigDerivedClassHasMethod("levelOut", swigMethodTypes13))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_levelOutSwigExplicitOdPrcFiler(swigCPtr);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFiler_levelOut(swigCPtr);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcAuditInfo getAuditInfo()
	{
		OdPrcAuditInfo rXObject = Helpers.GetRXObject<OdPrcAuditInfo>(OdPrcModule_GlobalsPINVOKE.OdPrcFiler_getAuditInfo(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFiler_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setController", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetController;
		}
		if (SwigDerivedClassHasMethod("setVersion", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetVersion;
		}
		if (SwigDerivedClassHasMethod("version", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodversion;
		}
		if (SwigDerivedClassHasMethod("controller", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcontroller;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("length", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodlength;
		}
		if (SwigDerivedClassHasMethod("levelIn", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodlevelIn;
		}
		if (SwigDerivedClassHasMethod("arrayIn", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodarrayIn;
		}
		if (SwigDerivedClassHasMethod("arrayElemIn", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodarrayElemIn;
		}
		if (SwigDerivedClassHasMethod("levelOut", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlevelOut;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcFiler_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcFiler));
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

	private void SwigDirectorMethodsetController(IntPtr pFilerController)
	{
		try
		{
			setController(Helpers.GetRXObject<OdPrcFilerController>(pFilerController, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetVersion(uint version)
	{
		try
		{
			setVersion(version);
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

	private uint SwigDirectorMethodversion()
	{
		return version();
	}

	private IntPtr SwigDirectorMethodcontroller()
	{
		return OdPrcFilerController.getCPtr(controller()).Handle;
	}

	private ulong SwigDirectorMethodseek(long offset, int seekType)
	{
		return seek(offset, (OdDb_FilerSeekType)seekType);
	}

	private ulong SwigDirectorMethodtell()
	{
		return tell();
	}

	private ulong SwigDirectorMethodlength()
	{
		return length();
	}

	private void SwigDirectorMethodlevelIn(string pBlockName)
	{
		try
		{
			levelIn(pBlockName);
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

	private void SwigDirectorMethodarrayIn(string pArrayName, uint size)
	{
		try
		{
			arrayIn(pArrayName, size);
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

	private void SwigDirectorMethodarrayElemIn(string pElementName, uint index)
	{
		try
		{
			arrayElemIn(pElementName, index);
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

	private void SwigDirectorMethodlevelOut()
	{
		try
		{
			levelOut();
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
