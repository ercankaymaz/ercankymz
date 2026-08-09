using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdBaseCameraMotion : IDisposable
{
	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_0(OdPdfPublish_Camera_Projection type);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_1(IntPtr position);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_2(IntPtr target);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_3(IntPtr vector);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_4(IntPtr node_name);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_5(double size);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_6(double size);

	public delegate bool SwigDelegateOdPdfPublish_OdBaseCameraMotion_7(ulong frame);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_5 swigDelegate5;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_6 swigDelegate6;

	private SwigDelegateOdPdfPublish_OdBaseCameraMotion_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdPdfPublish_Camera_Projection).MakeByRefType() };

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGePoint3d).MakeByRefType() };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdGePoint3d).MakeByRefType() };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGeVector3d).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(ulong) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdBaseCameraMotion(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdBaseCameraMotion obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPdfPublish_OdBaseCameraMotion()
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdBaseCameraMotion(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	protected OdPdfPublish_OdBaseCameraMotion()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBaseCameraMotion(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdBaseCameraMotion) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool getProjection(out OdPdfPublish_Camera_Projection type)
	{
		bool result = (SwigDerivedClassHasMethod("getProjection", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getProjectionSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out type) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getProjection(swigCPtr, out type));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPosition(out OdGePoint3d position)
	{
		bool result = (SwigDerivedClassHasMethod("getPosition", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getPositionSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out position) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getPosition(swigCPtr, out position));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getTarget(out OdGePoint3d target)
	{
		bool result = (SwigDerivedClassHasMethod("getTarget", swigMethodTypes2) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getTargetSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out target) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getTarget(swigCPtr, out target));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getUpVector(out OdGeVector3d vector)
	{
		bool result = (SwigDerivedClassHasMethod("getUpVector", swigMethodTypes3) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getUpVectorSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out vector) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getUpVector(swigCPtr, out vector));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getTargetNode(ref string node_name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(node_name);
		IntPtr intPtr = jarg;
		try
		{
			bool result = (SwigDerivedClassHasMethod("getTargetNode", swigMethodTypes4) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getTargetNodeSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, ref jarg) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getTargetNode(swigCPtr, ref jarg));
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
				node_name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual bool getViewPlaneSize(out double size)
	{
		bool result = (SwigDerivedClassHasMethod("getViewPlaneSize", swigMethodTypes5) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getViewPlaneSizeSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out size) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getViewPlaneSize(swigCPtr, out size));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getFov(out double size)
	{
		bool result = (SwigDerivedClassHasMethod("getFov", swigMethodTypes6) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getFovSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, out size) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getFov(swigCPtr, out size));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool step(ulong frame)
	{
		bool result = (SwigDerivedClassHasMethod("step", swigMethodTypes7) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_stepSwigExplicitOdPdfPublish_OdBaseCameraMotion(swigCPtr, frame) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_step(swigCPtr, frame));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getProjection", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetProjection;
		}
		if (SwigDerivedClassHasMethod("getPosition", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetPosition;
		}
		if (SwigDerivedClassHasMethod("getTarget", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetTarget;
		}
		if (SwigDerivedClassHasMethod("getUpVector", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetUpVector;
		}
		if (SwigDerivedClassHasMethod("getTargetNode", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetTargetNode;
		}
		if (SwigDerivedClassHasMethod("getViewPlaneSize", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetViewPlaneSize;
		}
		if (SwigDerivedClassHasMethod("getFov", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetFov;
		}
		if (SwigDerivedClassHasMethod("step", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodstep;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseCameraMotion_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdBaseCameraMotion));
	}

	private bool SwigDirectorMethodgetProjection(OdPdfPublish_Camera_Projection type)
	{
		return getProjection(out type);
	}

	private bool SwigDirectorMethodgetPosition(IntPtr position)
	{
		OdGePoint3d position2 = new OdGePoint3d(position, cMemoryOwn: true);
		try
		{
			return getPosition(out position2);
		}
		finally
		{
			position = OdGePoint3d.getCPtr(position2).Handle;
		}
	}

	private bool SwigDirectorMethodgetTarget(IntPtr target)
	{
		OdGePoint3d target2 = new OdGePoint3d(target, cMemoryOwn: true);
		try
		{
			return getTarget(out target2);
		}
		finally
		{
			target = OdGePoint3d.getCPtr(target2).Handle;
		}
	}

	private bool SwigDirectorMethodgetUpVector(IntPtr vector)
	{
		OdGeVector3d vector2 = new OdGeVector3d(vector, cMemoryOwn: true);
		try
		{
			return getUpVector(out vector2);
		}
		finally
		{
			vector = OdGeVector3d.getCPtr(vector2).Handle;
		}
	}

	private bool SwigDirectorMethodgetTargetNode(IntPtr node_name)
	{
		OdSwigDirectorHelper.director_UnpackData(node_name, out var pOriginalObject, out var pFunction);
		string node_name2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = node_name2;
		try
		{
			return getTargetNode(ref node_name2);
		}
		finally
		{
			if (node_name2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(node_name2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(node_name);
		}
	}

	private bool SwigDirectorMethodgetViewPlaneSize(double size)
	{
		return getViewPlaneSize(out size);
	}

	private bool SwigDirectorMethodgetFov(double size)
	{
		return getFov(out size);
	}

	private bool SwigDirectorMethodstep(ulong frame)
	{
		return step(frame);
	}
}
