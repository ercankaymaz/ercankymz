using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class OdIMaterialAndColorHelper : IDisposable
{
	public delegate int SwigDelegateOdIMaterialAndColorHelper_0(IntPtr fillerParams);

	public delegate int SwigDelegateOdIMaterialAndColorHelper_1(IntPtr sourceFace, IntPtr faceMaterial, IntPtr faceMaterialMapping, bool applyFaceMaterialMapping, IntPtr faceColor, bool applyFaceColor);

	public delegate int SwigDelegateOdIMaterialAndColorHelper_2(IntPtr edge, IntPtr edgeColor, bool applyEdgeColor);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdIMaterialAndColorHelper_0 swigDelegate0;

	private SwigDelegateOdIMaterialAndColorHelper_1 swigDelegate1;

	private SwigDelegateOdIMaterialAndColorHelper_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdBrepBuilderFillerParams) };

	private static Type[] swigMethodTypes1 = new Type[6]
	{
		typeof(OdBrFace),
		typeof(OdDbStub).MakeByRefType(),
		typeof(OdGiMapper),
		typeof(bool).MakeByRefType(),
		typeof(OdCmEntityColor),
		typeof(bool).MakeByRefType()
	};

	private static Type[] swigMethodTypes2 = new Type[3]
	{
		typeof(OdBrEdge),
		typeof(OdCmEntityColor),
		typeof(bool).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIMaterialAndColorHelper(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIMaterialAndColorHelper obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdIMaterialAndColorHelper()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_OdIMaterialAndColorHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	protected virtual OdResult init(OdBrepBuilderFillerParams fillerParams)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdIMaterialAndColorHelper_init(swigCPtr, OdBrepBuilderFillerParams.getCPtr(fillerParams));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getFaceVisualInfo(OdBrFace sourceFace, out OdDbStub faceMaterial, OdGiMapper faceMaterialMapping, out bool applyFaceMaterialMapping, OdCmEntityColor faceColor, out bool applyFaceColor)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdIMaterialAndColorHelper_getFaceVisualInfo(swigCPtr, OdBrFace.getCPtr(sourceFace), out jarg, OdGiMapper.getCPtr(faceMaterialMapping), out applyFaceMaterialMapping, OdCmEntityColor.getCPtr(faceColor), out applyFaceColor);
			if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			faceMaterial = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public virtual OdResult getEdgeVisualInfo(OdBrEdge edge, OdCmEntityColor edgeColor, out bool applyEdgeColor)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.OdIMaterialAndColorHelper_getEdgeVisualInfo(swigCPtr, OdBrEdge.getCPtr(edge), OdCmEntityColor.getCPtr(edgeColor), out applyEdgeColor);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdIMaterialAndColorHelper()
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_OdIMaterialAndColorHelper(), cMemoryOwn: true)
	{
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdIMaterialAndColorHelper) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("init", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodinit;
		}
		if (SwigDerivedClassHasMethod("getFaceVisualInfo", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetFaceVisualInfo;
		}
		if (SwigDerivedClassHasMethod("getEdgeVisualInfo", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetEdgeVisualInfo;
		}
		TD_BrepBuilderFiller_GlobalsPINVOKE.OdIMaterialAndColorHelper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdIMaterialAndColorHelper));
	}

	private int SwigDirectorMethodinit(IntPtr fillerParams)
	{
		return (int)init(new OdBrepBuilderFillerParams(fillerParams, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetFaceVisualInfo(IntPtr sourceFace, IntPtr faceMaterial, IntPtr faceMaterialMapping, bool applyFaceMaterialMapping, IntPtr faceColor, bool applyFaceColor)
	{
		OdDbStub faceMaterial2 = new OdDbStub(faceMaterial, cMemoryOwn: true);
		try
		{
			return (int)getFaceVisualInfo(new OdBrFace(sourceFace, cMemoryOwn: false), out faceMaterial2, new OdGiMapper(faceMaterialMapping, cMemoryOwn: false), out applyFaceMaterialMapping, new OdCmEntityColor(faceColor, cMemoryOwn: false), out applyFaceColor);
		}
		finally
		{
			faceMaterial = OdDbStub.getCPtr(faceMaterial2).Handle;
		}
	}

	private int SwigDirectorMethodgetEdgeVisualInfo(IntPtr edge, IntPtr edgeColor, bool applyEdgeColor)
	{
		return (int)getEdgeVisualInfo(new OdBrEdge(edge, cMemoryOwn: false), new OdCmEntityColor(edgeColor, cMemoryOwn: false), out applyEdgeColor);
	}
}
