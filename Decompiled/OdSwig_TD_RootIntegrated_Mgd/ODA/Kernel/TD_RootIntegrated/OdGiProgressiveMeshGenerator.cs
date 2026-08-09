using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProgressiveMeshGenerator : IDisposable
{
	public delegate byte SwigDelegateOdGiProgressiveMeshGenerator_0(int nPoints, IntPtr points, int faceListSize, int faces);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_1(IntPtr pVertexData, IntPtr pFaceData, EdgeData pEdgeData);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_2(IntPtr pVertexData, IntPtr pFaceData);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_3(IntPtr pVertexData);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_4();

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_5(IntPtr pBuff, IntPtr pConverter, int version);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_6(IntPtr pBuff, IntPtr pConverter);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_7(IntPtr pBuff);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_8(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter, int version);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_9(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_10(IntPtr pBuff, IntPtr pDataExtractor);

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_11();

	public delegate IntPtr SwigDelegateOdGiProgressiveMeshGenerator_12();

	public delegate void SwigDelegateOdGiProgressiveMeshGenerator_13(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiProgressiveMeshGenerator_0 swigDelegate0;

	private SwigDelegateOdGiProgressiveMeshGenerator_1 swigDelegate1;

	private SwigDelegateOdGiProgressiveMeshGenerator_2 swigDelegate2;

	private SwigDelegateOdGiProgressiveMeshGenerator_3 swigDelegate3;

	private SwigDelegateOdGiProgressiveMeshGenerator_4 swigDelegate4;

	private SwigDelegateOdGiProgressiveMeshGenerator_5 swigDelegate5;

	private SwigDelegateOdGiProgressiveMeshGenerator_6 swigDelegate6;

	private SwigDelegateOdGiProgressiveMeshGenerator_7 swigDelegate7;

	private SwigDelegateOdGiProgressiveMeshGenerator_8 swigDelegate8;

	private SwigDelegateOdGiProgressiveMeshGenerator_9 swigDelegate9;

	private SwigDelegateOdGiProgressiveMeshGenerator_10 swigDelegate10;

	private SwigDelegateOdGiProgressiveMeshGenerator_11 swigDelegate11;

	private SwigDelegateOdGiProgressiveMeshGenerator_12 swigDelegate12;

	private SwigDelegateOdGiProgressiveMeshGenerator_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[4]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(OdGiVertexData),
		typeof(OdGiFaceData),
		typeof(EdgeData)
	};

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiVertexData),
		typeof(OdGiFaceData)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiVertexData) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor),
		typeof(OdGiProgressiveMeshObjectIdConverter),
		typeof(OdGiProgressiveMesh_ProgressiveMeshStreamVersion)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor),
		typeof(OdGiProgressiveMeshObjectIdConverter)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdGiDataExtractor)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGiProgressiveMeshGeneratorOptions) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProgressiveMeshGenerator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProgressiveMeshGenerator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiProgressiveMeshGenerator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProgressiveMeshGenerator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdGiProgressiveMeshGenerator createObject()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createObject();
		OdGiProgressiveMeshGenerator result = ((intPtr == IntPtr.Zero) ? null : new OdGiProgressiveMeshGenerator(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte setupInitialShell(int nPoints, OdGePoint3d points, int faceListSize, int faces)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_setupInitialShell(swigCPtr, nPoints, OdGePoint3d.getCPtr(points), faceListSize, faces);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiProgressiveMesh buildProgressiveMesh(OdGiVertexData pVertexData, OdGiFaceData pFaceData, EdgeData pEdgeData)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_buildProgressiveMesh__SWIG_0(swigCPtr, OdGiVertexData.getCPtr(pVertexData), OdGiFaceData.getCPtr(pFaceData), pEdgeData), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh buildProgressiveMesh(OdGiVertexData pVertexData, OdGiFaceData pFaceData)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_buildProgressiveMesh__SWIG_1(swigCPtr, OdGiVertexData.getCPtr(pVertexData), OdGiFaceData.getCPtr(pFaceData)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh buildProgressiveMesh(OdGiVertexData pVertexData)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_buildProgressiveMesh__SWIG_2(swigCPtr, OdGiVertexData.getCPtr(pVertexData)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh buildProgressiveMesh()
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_buildProgressiveMesh__SWIG_3(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createProgressiveMeshFrom(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createProgressiveMeshFrom__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createProgressiveMeshFrom(OdStreamBuf pBuff, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createProgressiveMeshFrom__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createProgressiveMeshFrom(OdStreamBuf pBuff)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createProgressiveMeshFrom__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createPartialProgressiveMeshFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor, OdGiProgressiveMeshObjectIdConverter pConverter, OdGiProgressiveMesh_ProgressiveMeshStreamVersion version)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createPartialProgressiveMeshFrom__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter), (int)version), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createPartialProgressiveMeshFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor, OdGiProgressiveMeshObjectIdConverter pConverter)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createPartialProgressiveMeshFrom__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor), OdGiProgressiveMeshObjectIdConverter.getCPtr(pConverter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMesh createPartialProgressiveMeshFrom(OdStreamBuf pBuff, OdGiDataExtractor pDataExtractor)
	{
		OdGiProgressiveMesh rXObject = Helpers.GetRXObject<OdGiProgressiveMesh>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_createPartialProgressiveMeshFrom__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pBuff), OdGiDataExtractor.getCPtr(pDataExtractor)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiProgressiveMeshGeneratorOptions options()
	{
		OdGiProgressiveMeshGeneratorOptions result = new OdGiProgressiveMeshGeneratorOptions(TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_options__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOptions(OdGiProgressiveMeshGeneratorOptions arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_setOptions(swigCPtr, OdGiProgressiveMeshGeneratorOptions.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiProgressiveMeshGenerator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProgressiveMeshGenerator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProgressiveMeshGenerator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setupInitialShell", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetupInitialShell;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodbuildProgressiveMesh__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodbuildProgressiveMesh__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodbuildProgressiveMesh__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("buildProgressiveMesh", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodbuildProgressiveMesh__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("createProgressiveMeshFrom", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createProgressiveMeshFrom", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createProgressiveMeshFrom", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("createPartialProgressiveMeshFrom", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createPartialProgressiveMeshFrom", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createPartialProgressiveMeshFrom", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("options", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodoptions__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("options", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodoptions__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setOptions", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetOptions;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProgressiveMeshGenerator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProgressiveMeshGenerator));
	}

	private byte SwigDirectorMethodsetupInitialShell(int nPoints, IntPtr points, int faceListSize, int faces)
	{
		return setupInitialShell(nPoints, (points == IntPtr.Zero) ? null : new OdGePoint3d(points, cMemoryOwn: false), faceListSize, faces);
	}

	private IntPtr SwigDirectorMethodbuildProgressiveMesh__SWIG_0(IntPtr pVertexData, IntPtr pFaceData, EdgeData pEdgeData)
	{
		return OdGiProgressiveMesh.getCPtr(buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false), (pFaceData == IntPtr.Zero) ? null : new OdGiFaceData(pFaceData, cMemoryOwn: false), pEdgeData)).Handle;
	}

	private IntPtr SwigDirectorMethodbuildProgressiveMesh__SWIG_1(IntPtr pVertexData, IntPtr pFaceData)
	{
		return OdGiProgressiveMesh.getCPtr(buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false), (pFaceData == IntPtr.Zero) ? null : new OdGiFaceData(pFaceData, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodbuildProgressiveMesh__SWIG_2(IntPtr pVertexData)
	{
		return OdGiProgressiveMesh.getCPtr(buildProgressiveMesh((pVertexData == IntPtr.Zero) ? null : new OdGiVertexData(pVertexData, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodbuildProgressiveMesh__SWIG_3()
	{
		return OdGiProgressiveMesh.getCPtr(buildProgressiveMesh()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_0(IntPtr pBuff, IntPtr pConverter, int version)
	{
		return OdGiProgressiveMesh.getCPtr(createProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false), (OdGiProgressiveMesh_ProgressiveMeshStreamVersion)version)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_1(IntPtr pBuff, IntPtr pConverter)
	{
		return OdGiProgressiveMesh.getCPtr(createProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateProgressiveMeshFrom__SWIG_2(IntPtr pBuff)
	{
		return OdGiProgressiveMesh.getCPtr(createProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_0(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter, int version)
	{
		return OdGiProgressiveMesh.getCPtr(createPartialProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false), (OdGiProgressiveMesh_ProgressiveMeshStreamVersion)version)).Handle;
	}

	private IntPtr SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_1(IntPtr pBuff, IntPtr pDataExtractor, IntPtr pConverter)
	{
		return OdGiProgressiveMesh.getCPtr(createPartialProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false), (pConverter == IntPtr.Zero) ? null : new OdGiProgressiveMeshObjectIdConverter(pConverter, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreatePartialProgressiveMeshFrom__SWIG_2(IntPtr pBuff, IntPtr pDataExtractor)
	{
		return OdGiProgressiveMesh.getCPtr(createPartialProgressiveMeshFrom(Helpers.GetRXObject<OdStreamBuf>(pBuff, bOwn: false, bTryAddToTransaction: false), (pDataExtractor == IntPtr.Zero) ? null : new OdGiDataExtractor(pDataExtractor, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodoptions__SWIG_0()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshGeneratorOptions.getCPtr(options()).Handle;
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

	private IntPtr SwigDirectorMethodoptions__SWIG_1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiProgressiveMeshGeneratorOptions.getCPtr(options()).Handle;
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

	private void SwigDirectorMethodsetOptions(IntPtr arg0)
	{
		try
		{
			setOptions(new OdGiProgressiveMeshGeneratorOptions(arg0, cMemoryOwn: false));
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
