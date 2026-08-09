using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPathNode : IDisposable
{
	public delegate IntPtr SwigDelegateOdGiPathNode_0();

	public delegate IntPtr SwigDelegateOdGiPathNode_1();

	public delegate IntPtr SwigDelegateOdGiPathNode_2();

	public delegate IntPtr SwigDelegateOdGiPathNode_3();

	public delegate IntPtr SwigDelegateOdGiPathNode_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiPathNode_0 swigDelegate0;

	private SwigDelegateOdGiPathNode_1 swigDelegate1;

	private SwigDelegateOdGiPathNode_2 swigDelegate2;

	private SwigDelegateOdGiPathNode_3 swigDelegate3;

	private SwigDelegateOdGiPathNode_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPathNode(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPathNode obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPathNode()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPathNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdGiPathNode parent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_parent(swigCPtr);
		OdGiPathNode result = ((intPtr == IntPtr.Zero) ? null : new OdGiPathNode(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub persistentDrawableId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_persistentDrawableId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable transientDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_transientDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGeMatrix3d modelToWorld()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("modelToWorld", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_modelToWorldSwigExplicitOdGiPathNode(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_modelToWorld(swigCPtr));
		OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IntPtr selectionMarker()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_selectionMarker(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPathNode()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPathNode(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPathNode) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("parent", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodparent;
		}
		if (SwigDerivedClassHasMethod("persistentDrawableId", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodpersistentDrawableId;
		}
		if (SwigDerivedClassHasMethod("transientDrawable", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodtransientDrawable;
		}
		if (SwigDerivedClassHasMethod("modelToWorld", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmodelToWorld;
		}
		if (SwigDerivedClassHasMethod("selectionMarker", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodselectionMarker;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPathNode_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPathNode));
	}

	private IntPtr SwigDirectorMethodparent()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return getCPtr(parent()).Handle;
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

	private IntPtr SwigDirectorMethodpersistentDrawableId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(persistentDrawableId()).Handle;
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

	private IntPtr SwigDirectorMethodtransientDrawable()
	{
		return OdGiDrawable.getCPtr(transientDrawable()).Handle;
	}

	private IntPtr SwigDirectorMethodmodelToWorld()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(modelToWorld()).Handle;
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

	private IntPtr SwigDirectorMethodselectionMarker()
	{
		return selectionMarker();
	}
}
