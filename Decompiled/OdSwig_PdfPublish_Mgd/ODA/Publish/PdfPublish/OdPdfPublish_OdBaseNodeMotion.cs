using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdBaseNodeMotion : IDisposable
{
	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_0(IntPtr name);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_1(IntPtr matrix);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_2(uint color);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_3(double opacity);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_4(bool visible);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseNodeMotion_5(ulong frame);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdBaseNodeMotion_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGeMatrix3d).MakeByRefType() };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(uint).MakeByRefType() };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(bool).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(ulong) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdBaseNodeMotion(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdBaseNodeMotion obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPdfPublish_OdBaseNodeMotion()
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdBaseNodeMotion(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	protected OdPdfPublish_OdBaseNodeMotion()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBaseNodeMotion(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdBaseNodeMotion) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool getName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			bool result = (SwigDerivedClassHasMethod("getName", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getNameSwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, ref jarg) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getName(swigCPtr, ref jarg));
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getTransformation(out OdGeMatrix3d matrix)
	{
		bool result = (SwigDerivedClassHasMethod("getTransformation", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getTransformationSwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, out matrix) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getTransformation(swigCPtr, out matrix));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getColor(out uint color)
	{
		bool result = (SwigDerivedClassHasMethod("getColor", swigMethodTypes2) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getColorSwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, out color) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getColor(swigCPtr, out color));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getOpacity(out double opacity)
	{
		bool result = (SwigDerivedClassHasMethod("getOpacity", swigMethodTypes3) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getOpacitySwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, out opacity) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getOpacity(swigCPtr, out opacity));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getVisible(out bool visible)
	{
		bool result = (SwigDerivedClassHasMethod("getVisible", swigMethodTypes4) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getVisibleSwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, out visible) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getVisible(swigCPtr, out visible));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool step(ulong frame)
	{
		bool result = (SwigDerivedClassHasMethod("step", swigMethodTypes5) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_stepSwigExplicitOdPdfPublish_OdBaseNodeMotion(swigCPtr, frame) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_step(swigCPtr, frame));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetName;
		}
		if (SwigDerivedClassHasMethod("getTransformation", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetTransformation;
		}
		if (SwigDerivedClassHasMethod("getColor", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetColor;
		}
		if (SwigDerivedClassHasMethod("getOpacity", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetOpacity;
		}
		if (SwigDerivedClassHasMethod("getVisible", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetVisible;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodstep;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotion_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdBaseNodeMotion));
	}

	private bool SwigDirectorMethodgetName(IntPtr name)
	{
		OdSwigDirectorHelper.director_UnpackData(name, out var pOriginalObject, out var pFunction);
		string name2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = name2;
		try
		{
			return getName(ref name2);
		}
		finally
		{
			if (name2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(name2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(name);
		}
	}

	private bool SwigDirectorMethodgetTransformation(IntPtr matrix)
	{
		OdGeMatrix3d matrix2 = new OdGeMatrix3d(matrix, cMemoryOwn: true);
		try
		{
			return getTransformation(out matrix2);
		}
		finally
		{
			matrix = OdGeMatrix3d.getCPtr(matrix2).Handle;
		}
	}

	private bool SwigDirectorMethodgetColor(uint color)
	{
		return getColor(out color);
	}

	private bool SwigDirectorMethodgetOpacity(double opacity)
	{
		return getOpacity(out opacity);
	}

	private bool SwigDirectorMethodgetVisible(bool visible)
	{
		return getVisible(out visible);
	}

	private bool SwigDirectorMethodstep(ulong frame)
	{
		return step(frame);
	}
}
