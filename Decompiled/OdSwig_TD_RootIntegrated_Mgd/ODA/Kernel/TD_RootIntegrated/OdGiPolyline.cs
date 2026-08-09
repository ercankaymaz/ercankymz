using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPolyline : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiPolyline_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPolyline_1();

	public delegate void SwigDelegateOdGiPolyline_2(IntPtr pSource);

	public delegate uint SwigDelegateOdGiPolyline_3();

	public delegate bool SwigDelegateOdGiPolyline_4();

	public delegate IntPtr SwigDelegateOdGiPolyline_5();

	public delegate double SwigDelegateOdGiPolyline_6();

	public delegate double SwigDelegateOdGiPolyline_7();

	public delegate bool SwigDelegateOdGiPolyline_8();

	public delegate bool SwigDelegateOdGiPolyline_9();

	public delegate double SwigDelegateOdGiPolyline_10();

	public delegate int SwigDelegateOdGiPolyline_11(uint index);

	public delegate void SwigDelegateOdGiPolyline_12(uint index, IntPtr ln);

	public delegate void SwigDelegateOdGiPolyline_13(uint index, IntPtr ln);

	public delegate void SwigDelegateOdGiPolyline_14(uint index, IntPtr arc);

	public delegate void SwigDelegateOdGiPolyline_15(uint index, IntPtr arc);

	public delegate void SwigDelegateOdGiPolyline_16(uint index, IntPtr pt);

	public delegate double SwigDelegateOdGiPolyline_17(uint index);

	public delegate void SwigDelegateOdGiPolyline_18(uint index, double startWidth, double endWidth);

	public delegate IntPtr SwigDelegateOdGiPolyline_19();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPolyline_0 swigDelegate0;

	private SwigDelegateOdGiPolyline_1 swigDelegate1;

	private SwigDelegateOdGiPolyline_2 swigDelegate2;

	private SwigDelegateOdGiPolyline_3 swigDelegate3;

	private SwigDelegateOdGiPolyline_4 swigDelegate4;

	private SwigDelegateOdGiPolyline_5 swigDelegate5;

	private SwigDelegateOdGiPolyline_6 swigDelegate6;

	private SwigDelegateOdGiPolyline_7 swigDelegate7;

	private SwigDelegateOdGiPolyline_8 swigDelegate8;

	private SwigDelegateOdGiPolyline_9 swigDelegate9;

	private SwigDelegateOdGiPolyline_10 swigDelegate10;

	private SwigDelegateOdGiPolyline_11 swigDelegate11;

	private SwigDelegateOdGiPolyline_12 swigDelegate12;

	private SwigDelegateOdGiPolyline_13 swigDelegate13;

	private SwigDelegateOdGiPolyline_14 swigDelegate14;

	private SwigDelegateOdGiPolyline_15 swigDelegate15;

	private SwigDelegateOdGiPolyline_16 swigDelegate16;

	private SwigDelegateOdGiPolyline_17 swigDelegate17;

	private SwigDelegateOdGiPolyline_18 swigDelegate18;

	private SwigDelegateOdGiPolyline_19 swigDelegate19;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(uint),
		typeof(OdGeLineSeg2d)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(uint),
		typeof(OdGeLineSeg3d)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(uint),
		typeof(OdGeCircArc2d)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(uint),
		typeof(OdGeCircArc3d)
	};

	private static Type[] swigMethodTypes16 = new Type[2]
	{
		typeof(uint),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(uint),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes19 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPolyline(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPolyline obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPolyline(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPolyline cast(OdRxObject pObj)
	{
		OdGiPolyline rXObject = Helpers.GetRXObject<OdGiPolyline>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_isASwigExplicitOdGiPolyline(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_queryXSwigExplicitOdGiPolyline(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPolyline createObject()
	{
		OdGiPolyline rXObject = Helpers.GetRXObject<OdGiPolyline>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint numVerts()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_numVerts(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isClosed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_isClosed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d normal()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_normal(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getConstantWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getConstantWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasWidth()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_hasWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasPlinegen()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_hasPlinegen(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double elevation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_elevation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiPolyline_SegType segType(uint index)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_segType(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPolyline_SegType)result;
	}

	public virtual void getLineSegAt(uint index, OdGeLineSeg2d ln)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getLineSegAt__SWIG_0(swigCPtr, index, OdGeLineSeg2d.getCPtr(ln));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getLineSegAt(uint index, OdGeLineSeg3d ln)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getLineSegAt__SWIG_1(swigCPtr, index, OdGeLineSeg3d.getCPtr(ln));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getArcSegAt(uint index, OdGeCircArc2d arc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getArcSegAt__SWIG_0(swigCPtr, index, OdGeCircArc2d.getCPtr(arc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getArcSegAt(uint index, OdGeCircArc3d arc)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getArcSegAt__SWIG_1(swigCPtr, index, OdGeCircArc3d.getCPtr(arc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getPointAt(uint index, OdGePoint2d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getPointAt(swigCPtr, index, OdGePoint2d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double getBulgeAt(uint index)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getBulgeAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getWidthsAt(uint index, out double startWidth, out double endWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getWidthsAt(swigCPtr, index, out startWidth, out endWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getDbPolyline()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getDbPolyline(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPolyline()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPolyline(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPolyline) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("numVerts", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodnumVerts;
		}
		if (SwigDerivedClassHasMethod("isClosed", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisClosed;
		}
		if (SwigDerivedClassHasMethod("normal", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnormal;
		}
		if (SwigDerivedClassHasMethod("thickness", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodthickness;
		}
		if (SwigDerivedClassHasMethod("getConstantWidth", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetConstantWidth;
		}
		if (SwigDerivedClassHasMethod("hasWidth", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodhasWidth;
		}
		if (SwigDerivedClassHasMethod("hasPlinegen", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodhasPlinegen;
		}
		if (SwigDerivedClassHasMethod("elevation", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodelevation;
		}
		if (SwigDerivedClassHasMethod("segType", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsegType;
		}
		if (SwigDerivedClassHasMethod("getLineSegAt", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetLineSegAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getLineSegAt", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetLineSegAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getArcSegAt", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetArcSegAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getArcSegAt", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetArcSegAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPointAt", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetPointAt;
		}
		if (SwigDerivedClassHasMethod("getBulgeAt", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetBulgeAt;
		}
		if (SwigDerivedClassHasMethod("getWidthsAt", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetWidthsAt;
		}
		if (SwigDerivedClassHasMethod("getDbPolyline", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodgetDbPolyline;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPolyline_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPolyline));
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

	private uint SwigDirectorMethodnumVerts()
	{
		return numVerts();
	}

	private bool SwigDirectorMethodisClosed()
	{
		return isClosed();
	}

	private IntPtr SwigDirectorMethodnormal()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(normal()).Handle;
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

	private double SwigDirectorMethodthickness()
	{
		return thickness();
	}

	private double SwigDirectorMethodgetConstantWidth()
	{
		return getConstantWidth();
	}

	private bool SwigDirectorMethodhasWidth()
	{
		return hasWidth();
	}

	private bool SwigDirectorMethodhasPlinegen()
	{
		return hasPlinegen();
	}

	private double SwigDirectorMethodelevation()
	{
		return elevation();
	}

	private int SwigDirectorMethodsegType(uint index)
	{
		return (int)segType(index);
	}

	private void SwigDirectorMethodgetLineSegAt__SWIG_0(uint index, IntPtr ln)
	{
		try
		{
			getLineSegAt(index, new OdGeLineSeg2d(ln, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetLineSegAt__SWIG_1(uint index, IntPtr ln)
	{
		try
		{
			getLineSegAt(index, new OdGeLineSeg3d(ln, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetArcSegAt__SWIG_0(uint index, IntPtr arc)
	{
		try
		{
			getArcSegAt(index, new OdGeCircArc2d(arc, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetArcSegAt__SWIG_1(uint index, IntPtr arc)
	{
		try
		{
			getArcSegAt(index, new OdGeCircArc3d(arc, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetPointAt(uint index, IntPtr pt)
	{
		try
		{
			getPointAt(index, new OdGePoint2d(pt, cMemoryOwn: false));
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

	private double SwigDirectorMethodgetBulgeAt(uint index)
	{
		return getBulgeAt(index);
	}

	private void SwigDirectorMethodgetWidthsAt(uint index, double startWidth, double endWidth)
	{
		try
		{
			getWidthsAt(index, out startWidth, out endWidth);
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

	private IntPtr SwigDirectorMethodgetDbPolyline()
	{
		return OdRxObject.getCPtr(getDbPolyline()).Handle;
	}
}
