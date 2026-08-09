using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdAnimation : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdAnimation_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdAnimation_1();

	public delegate void SwigDelegateOdPdfPublish_OdAnimation_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdAnimation_3();

	public delegate bool SwigDelegateOdPdfPublish_OdAnimation_4();

	public delegate void SwigDelegateOdPdfPublish_OdAnimation_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdAnimation_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdAnimation_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdAnimation_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdAnimation_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdAnimation_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdAnimation_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdAnimation(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdAnimation obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdAnimation(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdAnimation()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdAnimation(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdAnimation) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdAnimation cast(OdRxObject pObj)
	{
		OdPdfPublish_OdAnimation rXObject = Helpers.GetRXObject<OdPdfPublish_OdAnimation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_isASwigExplicitOdPdfPublish_OdAnimation(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_queryXSwigExplicitOdPdfPublish_OdAnimation(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdAnimation createObject()
	{
		OdPdfPublish_OdAnimation rXObject = Helpers.GetRXObject<OdPdfPublish_OdAnimation>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPlayOnOpenDocument(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setPlayOnOpenDocument(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAutoReplay(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setAutoReplay(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFramesPerSecond(uint frame_per_second)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setFramesPerSecond(swigCPtr, frame_per_second);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFramesCount(ulong frame_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setFramesCount(swigCPtr, frame_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCameraMotion(ulong start_frame, ulong end_frame, OdPdfPublish_OdBaseCameraMotion motion)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_setCameraMotion(swigCPtr, start_frame, end_frame, OdPdfPublish_OdBaseCameraMotion.getCPtr(motion));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addNodeMotion(ulong start_frame, ulong end_frame, OdPdfPublish_OdBaseNodeMotion motion)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_addNodeMotion(swigCPtr, start_frame, end_frame, OdPdfPublish_OdBaseNodeMotion.getCPtr(motion));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getName(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getPlayOnOpenDocument(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getPlayOnOpenDocument(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAutoReplay(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getAutoReplay(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFramesPerSecond(out uint frame_per_second)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getFramesPerSecond(swigCPtr, out frame_per_second);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFramesCount(out ulong frame_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getFramesCount(swigCPtr, out frame_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCameraMotion(out ulong start_frame, out ulong end_frame, ref OdPdfPublish_OdBaseCameraMotion motion)
	{
		IntPtr jarg = ((motion == null) ? IntPtr.Zero : OdPdfPublish_OdBaseCameraMotion.getCPtr(motion).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getCameraMotion(swigCPtr, out start_frame, out end_frame, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				motion = null;
			}
			else if (jarg != intPtr)
			{
				motion = Helpers.GetObject<OdPdfPublish_OdBaseCameraMotion>(jarg, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public void getNodeMotions(OdUInt64Array starts_frame, OdUInt64Array ends_frame, OdPdfPublish_OdBaseNodeMotionPtrArray motions)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getNodeMotions(swigCPtr, OdUInt64Array.getCPtr(starts_frame).Handle, OdUInt64Array.getCPtr(ends_frame).Handle, OdPdfPublish_OdBaseNodeMotionPtrArray.getCPtr(motions));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisEmpty;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclear;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAnimation_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdAnimation));
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
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisEmpty()
	{
		return isEmpty();
	}

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
		}
		catch (OdEdEmptyInput err)
		{
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
