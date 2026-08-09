using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbFilteredBlockIterator : OdDbBlockIterator
{
	public delegate IntPtr SwigDelegateOdDbFilteredBlockIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbFilteredBlockIterator_1();

	public delegate void SwigDelegateOdDbFilteredBlockIterator_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbFilteredBlockIterator_3();

	public delegate IntPtr SwigDelegateOdDbFilteredBlockIterator_4();

	public delegate IntPtr SwigDelegateOdDbFilteredBlockIterator_5();

	public delegate bool SwigDelegateOdDbFilteredBlockIterator_6(IntPtr objectId);

	public delegate double SwigDelegateOdDbFilteredBlockIterator_7();

	public delegate bool SwigDelegateOdDbFilteredBlockIterator_8(IntPtr objectId);

	public delegate bool SwigDelegateOdDbFilteredBlockIterator_9();

	public delegate void SwigDelegateOdDbFilteredBlockIterator_10(IntPtr objectId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbFilteredBlockIterator_0 swigDelegate0;

	private SwigDelegateOdDbFilteredBlockIterator_1 swigDelegate1;

	private SwigDelegateOdDbFilteredBlockIterator_2 swigDelegate2;

	private SwigDelegateOdDbFilteredBlockIterator_3 swigDelegate3;

	private SwigDelegateOdDbFilteredBlockIterator_4 swigDelegate4;

	private SwigDelegateOdDbFilteredBlockIterator_5 swigDelegate5;

	private SwigDelegateOdDbFilteredBlockIterator_6 swigDelegate6;

	private SwigDelegateOdDbFilteredBlockIterator_7 swigDelegate7;

	private SwigDelegateOdDbFilteredBlockIterator_8 swigDelegate8;

	private SwigDelegateOdDbFilteredBlockIterator_9 swigDelegate9;

	private SwigDelegateOdDbFilteredBlockIterator_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbObjectId) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbFilteredBlockIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbFilteredBlockIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbFilteredBlockIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbFilteredBlockIterator cast(OdRxObject pObj)
	{
		OdDbFilteredBlockIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFilteredBlockIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_isASwigExplicitOdDbFilteredBlockIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_queryXSwigExplicitOdDbFilteredBlockIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbFilteredBlockIterator createObject()
	{
		OdDbFilteredBlockIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbFilteredBlockIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual double estimatedHitFraction()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_estimatedHitFraction(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool accepts(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_accepts(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool buffersForComposition()
	{
		bool result = (SwigDerivedClassHasMethod("buffersForComposition", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_buffersForCompositionSwigExplicitOdDbFilteredBlockIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_buffersForComposition(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addToBuffer(OdDbObjectId objectId)
	{
		if (SwigDerivedClassHasMethod("addToBuffer", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_addToBufferSwigExplicitOdDbFilteredBlockIterator(swigCPtr, OdDbObjectId.getCPtr(objectId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_addToBuffer(swigCPtr, OdDbObjectId.getCPtr(objectId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("start", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodstart;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodid;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("estimatedHitFraction", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodestimatedHitFraction;
		}
		if (SwigDerivedClassHasMethod("accepts", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaccepts;
		}
		if (SwigDerivedClassHasMethod("buffersForComposition", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodbuffersForComposition;
		}
		if (SwigDerivedClassHasMethod("addToBuffer", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodaddToBuffer;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbFilteredBlockIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbFilteredBlockIterator));
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

	private void SwigDirectorMethodstart()
	{
		try
		{
			start();
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

	private IntPtr SwigDirectorMethodnext()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(next()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodid()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(id()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodseek(IntPtr objectId)
	{
		return seek(new OdDbObjectId(objectId, cMemoryOwn: true));
	}

	private double SwigDirectorMethodestimatedHitFraction()
	{
		return estimatedHitFraction();
	}

	private bool SwigDirectorMethodaccepts(IntPtr objectId)
	{
		return accepts(new OdDbObjectId(objectId, cMemoryOwn: true));
	}

	private bool SwigDirectorMethodbuffersForComposition()
	{
		return buffersForComposition();
	}

	private void SwigDirectorMethodaddToBuffer(IntPtr objectId)
	{
		try
		{
			addToBuffer(new OdDbObjectId(objectId, cMemoryOwn: true));
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
