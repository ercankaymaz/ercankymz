using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGenericTexture : OdGiProceduralTexture
{
	public delegate IntPtr SwigDelegateOdGiGenericTexture_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiGenericTexture_1();

	public delegate void SwigDelegateOdGiGenericTexture_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiGenericTexture_3();

	public delegate void SwigDelegateOdGiGenericTexture_4(IntPtr definition);

	public delegate IntPtr SwigDelegateOdGiGenericTexture_5();

	public delegate void SwigDelegateOdGiGenericTexture_6(IntPtr pDefinition);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiGenericTexture_0 swigDelegate0;

	private SwigDelegateOdGiGenericTexture_1 swigDelegate1;

	private SwigDelegateOdGiGenericTexture_2 swigDelegate2;

	private SwigDelegateOdGiGenericTexture_3 swigDelegate3;

	private SwigDelegateOdGiGenericTexture_4 swigDelegate4;

	private SwigDelegateOdGiGenericTexture_5 swigDelegate5;

	private SwigDelegateOdGiGenericTexture_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiVariant) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiVariant).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGenericTexture(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGenericTexture obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGenericTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiGenericTexture cast(OdRxObject pObj)
	{
		OdGiGenericTexture rXObject = Helpers.GetRXObject<OdGiGenericTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_isASwigExplicitOdGiGenericTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_queryXSwigExplicitOdGiGenericTexture(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiGenericTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGenericTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiGenericTexture) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiProceduralTexture_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_typeSwigExplicitOdGiGenericTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiProceduralTexture_Type)result;
	}

	public virtual void setDefinition(OdGiVariant definition)
	{
		if (SwigDerivedClassHasMethod("setDefinition", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_setDefinitionSwigExplicitOdGiGenericTexture(swigCPtr, OdGiVariant.getCPtr(definition));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_setDefinition(swigCPtr, OdGiVariant.getCPtr(definition));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiVariant definition()
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(SwigDerivedClassHasMethod("definition", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_definitionSwigExplicitOdGiGenericTexture__SWIG_0(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_definition__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void definition(ref OdGiVariant pDefinition)
	{
		IntPtr jarg = ((pDefinition == null) ? IntPtr.Zero : OdGiVariant.getCPtr(pDefinition).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("definition", swigMethodTypes6))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_definitionSwigExplicitOdGiGenericTexture__SWIG_1(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_definition__SWIG_1(swigCPtr, ref jarg);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pDefinition = null;
			}
			else if (jarg != intPtr)
			{
				pDefinition = Helpers.GetRXObject<OdGiVariant>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override bool IsEqual(OdGiMaterialTexture texture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_IsEqual(swigCPtr, OdGiMaterialTexture.getCPtr(texture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGenericTexture Assign(OdGiGenericTexture texture)
	{
		OdGiGenericTexture rXObject = Helpers.GetRXObject<OdGiGenericTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_Assign(swigCPtr, getCPtr(texture)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_copyFromSwigExplicitOdGiGenericTexture(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiGenericTexture createObject()
	{
		OdGiGenericTexture rXObject = Helpers.GetRXObject<OdGiGenericTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("type", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("setDefinition", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetDefinition;
		}
		if (SwigDerivedClassHasMethod("definition", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoddefinition__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("definition", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddefinition__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGenericTexture_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiGenericTexture));
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

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodsetDefinition(IntPtr definition)
	{
		try
		{
			setDefinition(Helpers.GetRXObject<OdGiVariant>(definition, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethoddefinition__SWIG_0()
	{
		return OdGiVariant.getCPtr(definition()).Handle;
	}

	private void SwigDirectorMethoddefinition__SWIG_1(IntPtr pDefinition)
	{
		OdSwigDirectorHelper.director_UnpackData(pDefinition, out var pOriginalObject, out var pFunction);
		OdGiVariant pDefinition2 = Helpers.GetRXObject<OdGiVariant>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			definition(ref pDefinition2);
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
		finally
		{
			IntPtr handle = OdGiVariant.getCPtr(pDefinition2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pDefinition);
		}
	}
}
