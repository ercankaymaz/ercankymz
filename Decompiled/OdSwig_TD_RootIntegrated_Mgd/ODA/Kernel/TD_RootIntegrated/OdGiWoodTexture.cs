using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWoodTexture : OdGiProceduralTexture
{
	public delegate IntPtr SwigDelegateOdGiWoodTexture_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiWoodTexture_1();

	public delegate void SwigDelegateOdGiWoodTexture_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiWoodTexture_3();

	public delegate void SwigDelegateOdGiWoodTexture_4(IntPtr woodColor1);

	public delegate IntPtr SwigDelegateOdGiWoodTexture_5();

	public delegate void SwigDelegateOdGiWoodTexture_6(IntPtr woodColor2);

	public delegate IntPtr SwigDelegateOdGiWoodTexture_7();

	public delegate void SwigDelegateOdGiWoodTexture_8(double radialNoise);

	public delegate double SwigDelegateOdGiWoodTexture_9();

	public delegate void SwigDelegateOdGiWoodTexture_10(double axialNoise);

	public delegate double SwigDelegateOdGiWoodTexture_11();

	public delegate void SwigDelegateOdGiWoodTexture_12(double grainThickness);

	public delegate double SwigDelegateOdGiWoodTexture_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiWoodTexture_0 swigDelegate0;

	private SwigDelegateOdGiWoodTexture_1 swigDelegate1;

	private SwigDelegateOdGiWoodTexture_2 swigDelegate2;

	private SwigDelegateOdGiWoodTexture_3 swigDelegate3;

	private SwigDelegateOdGiWoodTexture_4 swigDelegate4;

	private SwigDelegateOdGiWoodTexture_5 swigDelegate5;

	private SwigDelegateOdGiWoodTexture_6 swigDelegate6;

	private SwigDelegateOdGiWoodTexture_7 swigDelegate7;

	private SwigDelegateOdGiWoodTexture_8 swigDelegate8;

	private SwigDelegateOdGiWoodTexture_9 swigDelegate9;

	private SwigDelegateOdGiWoodTexture_10 swigDelegate10;

	private SwigDelegateOdGiWoodTexture_11 swigDelegate11;

	private SwigDelegateOdGiWoodTexture_12 swigDelegate12;

	private SwigDelegateOdGiWoodTexture_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes13 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWoodTexture(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWoodTexture obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiWoodTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiWoodTexture cast(OdRxObject pObj)
	{
		OdGiWoodTexture rXObject = Helpers.GetRXObject<OdGiWoodTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_isASwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_queryXSwigExplicitOdGiWoodTexture(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiWoodTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiWoodTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiWoodTexture) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiProceduralTexture_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_typeSwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiProceduralTexture_Type)result;
	}

	public virtual void setColor1(OdGiMaterialColor woodColor1)
	{
		if (SwigDerivedClassHasMethod("setColor1", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setColor1SwigExplicitOdGiWoodTexture(swigCPtr, OdGiMaterialColor.getCPtr(woodColor1));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setColor1(swigCPtr, OdGiMaterialColor.getCPtr(woodColor1));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialColor color1()
	{
		OdGiMaterialColor result = new OdGiMaterialColor(SwigDerivedClassHasMethod("color1", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_color1SwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_color1(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColor2(OdGiMaterialColor woodColor2)
	{
		if (SwigDerivedClassHasMethod("setColor2", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setColor2SwigExplicitOdGiWoodTexture(swigCPtr, OdGiMaterialColor.getCPtr(woodColor2));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setColor2(swigCPtr, OdGiMaterialColor.getCPtr(woodColor2));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialColor color2()
	{
		OdGiMaterialColor result = new OdGiMaterialColor(SwigDerivedClassHasMethod("color2", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_color2SwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_color2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRadialNoise(double radialNoise)
	{
		if (SwigDerivedClassHasMethod("setRadialNoise", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setRadialNoiseSwigExplicitOdGiWoodTexture(swigCPtr, radialNoise);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setRadialNoise(swigCPtr, radialNoise);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double radialNoise()
	{
		double result = (SwigDerivedClassHasMethod("radialNoise", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_radialNoiseSwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_radialNoise(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAxialNoise(double axialNoise)
	{
		if (SwigDerivedClassHasMethod("setAxialNoise", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setAxialNoiseSwigExplicitOdGiWoodTexture(swigCPtr, axialNoise);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setAxialNoise(swigCPtr, axialNoise);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double axialNoise()
	{
		double result = (SwigDerivedClassHasMethod("axialNoise", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_axialNoiseSwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_axialNoise(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setGrainThickness(double grainThickness)
	{
		if (SwigDerivedClassHasMethod("setGrainThickness", swigMethodTypes12))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setGrainThicknessSwigExplicitOdGiWoodTexture(swigCPtr, grainThickness);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_setGrainThickness(swigCPtr, grainThickness);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double grainThickness()
	{
		double result = (SwigDerivedClassHasMethod("grainThickness", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_grainThicknessSwigExplicitOdGiWoodTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_grainThickness(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool IsEqual(OdGiMaterialTexture texture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_IsEqual(swigCPtr, OdGiMaterialTexture.getCPtr(texture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiWoodTexture Assign(OdGiWoodTexture texture)
	{
		OdGiWoodTexture rXObject = Helpers.GetRXObject<OdGiWoodTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_Assign(swigCPtr, getCPtr(texture)), bOwn: false, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_copyFromSwigExplicitOdGiWoodTexture(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiWoodTexture createObject()
	{
		OdGiWoodTexture rXObject = Helpers.GetRXObject<OdGiWoodTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("setColor1", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetColor1;
		}
		if (SwigDerivedClassHasMethod("color1", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcolor1;
		}
		if (SwigDerivedClassHasMethod("setColor2", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetColor2;
		}
		if (SwigDerivedClassHasMethod("color2", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcolor2;
		}
		if (SwigDerivedClassHasMethod("setRadialNoise", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetRadialNoise;
		}
		if (SwigDerivedClassHasMethod("radialNoise", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodradialNoise;
		}
		if (SwigDerivedClassHasMethod("setAxialNoise", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetAxialNoise;
		}
		if (SwigDerivedClassHasMethod("axialNoise", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodaxialNoise;
		}
		if (SwigDerivedClassHasMethod("setGrainThickness", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetGrainThickness;
		}
		if (SwigDerivedClassHasMethod("grainThickness", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgrainThickness;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWoodTexture_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiWoodTexture));
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

	private void SwigDirectorMethodsetColor1(IntPtr woodColor1)
	{
		try
		{
			setColor1(new OdGiMaterialColor(woodColor1, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolor1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMaterialColor.getCPtr(color1()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetColor2(IntPtr woodColor2)
	{
		try
		{
			setColor2(new OdGiMaterialColor(woodColor2, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolor2()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMaterialColor.getCPtr(color2()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetRadialNoise(double radialNoise)
	{
		try
		{
			setRadialNoise(radialNoise);
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

	private double SwigDirectorMethodradialNoise()
	{
		return radialNoise();
	}

	private void SwigDirectorMethodsetAxialNoise(double axialNoise)
	{
		try
		{
			setAxialNoise(axialNoise);
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

	private double SwigDirectorMethodaxialNoise()
	{
		return axialNoise();
	}

	private void SwigDirectorMethodsetGrainThickness(double grainThickness)
	{
		try
		{
			setGrainThickness(grainThickness);
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

	private double SwigDirectorMethodgrainThickness()
	{
		return grainThickness();
	}
}
