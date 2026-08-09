using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrc3dTess : OdPrcBaseTessData
{
	public delegate IntPtr SwigDelegateOdPrc3dTess_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrc3dTess_1();

	public delegate void SwigDelegateOdPrc3dTess_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrc3dTess_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrc3dTess_4(IntPtr pStream);

	public delegate uint SwigDelegateOdPrc3dTess_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrc3dTess_0 swigDelegate0;

	private SwigDelegateOdPrc3dTess_1 swigDelegate1;

	private SwigDelegateOdPrc3dTess_2 swigDelegate2;

	private SwigDelegateOdPrc3dTess_3 swigDelegate3;

	private SwigDelegateOdPrc3dTess_4 swigDelegate4;

	private SwigDelegateOdPrc3dTess_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrc3dTess(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrc3dTess obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrc3dTess(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrc3dTess()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrc3dTess(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrc3dTess) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcTypeSwigExplicitOdPrc3dTess(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrc3dTess cast(OdRxObject pObj)
	{
		OdPrc3dTess rXObject = Helpers.GetRXObject<OdPrc3dTess>(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_isASwigExplicitOdPrc3dTess(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_queryXSwigExplicitOdPrc3dTess(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrc3dTess createObject()
	{
		OdPrc3dTess rXObject = Helpers.GetRXObject<OdPrc3dTess>(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcOutSwigExplicitOdPrc3dTess(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcInSwigExplicitOdPrc3dTess(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt32Array wireIndex()
	{
		OdUInt32Array result = new OdUInt32Array(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_wireIndex__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array triangulatedIndex()
	{
		OdUInt32Array result = new OdUInt32Array(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_triangulatedIndex__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFloatArray normalCoordinate()
	{
		OdFloatArray result = new OdFloatArray(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_normalCoordinate__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFloatArray textureCoordinate()
	{
		OdFloatArray result = new OdFloatArray(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_textureCoordinate__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcTessFaceArray faceTessellation()
	{
		OdPrcTessFaceArray result = new OdPrcTessFaceArray(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_faceTessellation__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFloatArray coordinates()
	{
		OdFloatArray result = new OdFloatArray(OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_coordinates__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNormalsRecalculationFlags(sbyte normals_recalculation_flags)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setNormalsRecalculationFlags(swigCPtr, normals_recalculation_flags);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public sbyte normalsRecalculationFlags()
	{
		sbyte result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_normalsRecalculationFlags(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCreaseAngle(double crease_angle)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setCreaseAngle(swigCPtr, crease_angle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double creaseAngle()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_creaseAngle(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHasFaces(bool has_faces)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setHasFaces(swigCPtr, has_faces);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasFaces()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_hasFaces(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHasLoops(bool has_loops)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setHasLoops(swigCPtr, has_loops);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasLoops()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_hasLoops(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMustRecalculateNormals(bool must_recalculate_normals)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setMustRecalculateNormals(swigCPtr, must_recalculate_normals);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool mustRecalculateNormals()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_mustRecalculateNormals(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsCalculated(bool is_calculated)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setIsCalculated(swigCPtr, is_calculated);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isCalculated()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_isCalculated(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool optimize(double dTolerance)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_optimize__SWIG_0(swigCPtr, dTolerance);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool optimize()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_optimize__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setcoordinates(OdFloatArray value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setcoordinates(swigCPtr, OdFloatArray.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setnormalCoordinate(OdFloatArray value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_setnormalCoordinate(swigCPtr, OdFloatArray.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void settriangulatedIndex(OdUInt32Array value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_settriangulatedIndex(swigCPtr, OdUInt32Array.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void settextureCoordinate(OdFloatArray value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_settextureCoordinate(swigCPtr, OdFloatArray.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
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
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprcType;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrc3dTess_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrc3dTess));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
	}
}
