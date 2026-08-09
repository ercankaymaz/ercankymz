using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionSubstitutor : OdGsFilerExtension
{
	public class SubstitutionActuator : IDisposable
	{
		public delegate void SwigDelegateSubstitutionActuator_0(IntPtr pPlace, IntPtr pValue, IntPtr pSetFunc);

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateSubstitutionActuator_0 swigDelegate0;

		private static Type[] swigMethodTypes0 = new Type[3]
		{
			typeof(IntPtr),
			typeof(IntPtr),
			typeof(TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate)
		};

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SubstitutionActuator(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(SubstitutionActuator obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~SubstitutionActuator()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionSubstitutor_SubstitutionActuator(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public SubstitutionActuator()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionSubstitutor_SubstitutionActuator(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(SubstitutionActuator) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		public virtual void applySubstitution(IntPtr pPlace, IntPtr pValue, TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate pSetFunc)
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
			if (SwigDerivedClassHasMethod("applySubstitution", swigMethodTypes0))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_SubstitutionActuator_applySubstitutionSwigExplicitSubstitutionActuator(swigCPtr, pPlace, pValue, jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_SubstitutionActuator_applySubstitution(swigCPtr, pPlace, pValue, jarg);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("applySubstitution", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodapplySubstitution;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_SubstitutionActuator_director_connect(swigCPtr, swigDelegate0);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(SubstitutionActuator));
		}

		private void SwigDirectorMethodapplySubstitution(IntPtr pPlace, IntPtr pValue, IntPtr pSetFunc)
		{
			try
			{
				applySubstitution(pPlace, pValue, ((Func<TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate>)delegate
				{
					IntPtr nativeCallback = pSetFunc;
					TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegate result = null;
					if (nativeCallback != IntPtr.Zero)
					{
						result = delegate(IntPtr pPlace_, IntPtr pValue_)
						{
							(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegateNative)) as TD_RootIntegrated_Globals.SubstitutionActuator_SetPtrFuncDelegateNative)(pPlace_, pValue_);
						};
					}
					return result;
				})());
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

	public class Substitutor : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Substitutor(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Substitutor obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Substitutor()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionSubstitutor_Substitutor(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual void registerSubstitution(IntPtr pValue, IntPtr pSubstitution, uint size, bool bRegister, bool bImmediate)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_registerSubstitution__SWIG_0(swigCPtr, pValue, pSubstitution, size, bRegister, bImmediate);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void registerSubstitution(IntPtr pValue, IntPtr pSubstitution, uint size, bool bRegister)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_registerSubstitution__SWIG_1(swigCPtr, pValue, pSubstitution, size, bRegister);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void registerSubstitution(IntPtr pValue, IntPtr pSubstitution, uint size)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_registerSubstitution__SWIG_2(swigCPtr, pValue, pSubstitution, size);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void registerSubstitution(IntPtr pValue, IntPtr pSubstitution)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_registerSubstitution__SWIG_3(swigCPtr, pValue, pSubstitution);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, IntPtr pValue, uint size, bool bRegister, bool bImmediate)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_0(swigCPtr, pPlace, pValue, size, bRegister, bImmediate);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, IntPtr pValue, uint size, bool bRegister)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_1(swigCPtr, pPlace, pValue, size, bRegister);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, IntPtr pValue, uint size)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_2(swigCPtr, pPlace, pValue, size);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, IntPtr pValue)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_3(swigCPtr, pPlace, pValue);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(OdBaseObjectPtr pPlace, IntPtr pValue, bool bRegister, bool bImmediate)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_4(swigCPtr, OdBaseObjectPtr.getCPtr(pPlace), pValue, bRegister, bImmediate);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(OdBaseObjectPtr pPlace, IntPtr pValue, bool bRegister)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_5(swigCPtr, OdBaseObjectPtr.getCPtr(pPlace), pValue, bRegister);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(OdBaseObjectPtr pPlace, IntPtr pValue)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_6(swigCPtr, OdBaseObjectPtr.getCPtr(pPlace), pValue);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, SubstitutionActuator pActuator, IntPtr pValue, uint size, bool bRegister, bool bImmediate)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_7(swigCPtr, pPlace, SubstitutionActuator.getCPtr(pActuator), pValue, size, bRegister, bImmediate);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, SubstitutionActuator pActuator, IntPtr pValue, uint size, bool bRegister)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_8(swigCPtr, pPlace, SubstitutionActuator.getCPtr(pActuator), pValue, size, bRegister);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, SubstitutionActuator pActuator, IntPtr pValue, uint size)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_9(swigCPtr, pPlace, SubstitutionActuator.getCPtr(pActuator), pValue, size);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void requestSubstitution(IntPtr pPlace, SubstitutionActuator pActuator, IntPtr pValue)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_requestSubstitution__SWIG_10(swigCPtr, pPlace, SubstitutionActuator.getCPtr(pActuator), pValue);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void clearSubstitutions(IntPtr pValue, uint size)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_clearSubstitutions__SWIG_0(swigCPtr, pValue, size);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void clearSubstitutions(IntPtr pValue)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_clearSubstitutions__SWIG_1(swigCPtr, pValue);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void clearSubstitutions()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_clearSubstitutions__SWIG_2(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void runSubstitutions(IntPtr pValue, uint size, bool bClear)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_runSubstitutions__SWIG_0(swigCPtr, pValue, size, bClear);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void runSubstitutions(IntPtr pValue, uint size)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_runSubstitutions__SWIG_1(swigCPtr, pValue, size);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void runSubstitutions(IntPtr pValue)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_runSubstitutions__SWIG_2(swigCPtr, pValue);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void runSubstitutions()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_Substitutor_runSubstitutions__SWIG_3(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionSubstitutor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionSubstitutor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionSubstitutor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionSubstitutor cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionSubstitutor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionSubstitutor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual Substitutor subst()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_subst(swigCPtr);
		Substitutor result = ((intPtr == IntPtr.Zero) ? null : new Substitutor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void makeSubstitutions(bool bClear)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_makeSubstitutions__SWIG_0(swigCPtr, bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void makeSubstitutions()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_makeSubstitutions__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getSubstitutor()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_getSubstitutor(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSubstitutor(OdRxObject pSubst)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionSubstitutor_setSubstitutor(swigCPtr, OdRxObject.getCPtr(pSubst));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
