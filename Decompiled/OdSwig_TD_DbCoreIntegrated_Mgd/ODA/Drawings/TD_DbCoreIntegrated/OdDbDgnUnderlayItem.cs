using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDgnUnderlayItem : OdDbUnderlayItem
{
	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_1();

	public delegate void SwigDelegateOdDbDgnUnderlayItem_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbDgnUnderlayItem_3();

	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_4();

	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_5(int width, int height);

	public delegate void SwigDelegateOdDbDgnUnderlayItem_6(IntPtr min, IntPtr max);

	public delegate int SwigDelegateOdDbDgnUnderlayItem_7();

	public delegate bool SwigDelegateOdDbDgnUnderlayItem_8();

	public delegate bool SwigDelegateOdDbDgnUnderlayItem_9(IntPtr pWd, IntPtr context);

	public delegate void SwigDelegateOdDbDgnUnderlayItem_10(IntPtr pVd, IntPtr context);

	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_11();

	public delegate int SwigDelegateOdDbDgnUnderlayItem_12(IntPtr min, IntPtr max);

	public delegate int SwigDelegateOdDbDgnUnderlayItem_13(IntPtr modelToWorld, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr viewXform, IntPtr ucs, IntPtr snapPoints, IntPtr geomIds);

	public delegate IntPtr SwigDelegateOdDbDgnUnderlayItem_14(IntPtr modelToWorld, IntPtr gsSelectionMark);

	public delegate int SwigDelegateOdDbDgnUnderlayItem_15(IntPtr modelToWorld, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate uint SwigDelegateOdDbDgnUnderlayItem_16();

	public delegate int SwigDelegateOdDbDgnUnderlayItem_17(int idx, IntPtr layer);

	public delegate bool SwigDelegateOdDbDgnUnderlayItem_18();

	public delegate void SwigDelegateOdDbDgnUnderlayItem_19(bool useMaster);

	public delegate bool SwigDelegateOdDbDgnUnderlayItem_20();

	public delegate void SwigDelegateOdDbDgnUnderlayItem_21(bool bShow);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDgnUnderlayItem_0 swigDelegate0;

	private SwigDelegateOdDbDgnUnderlayItem_1 swigDelegate1;

	private SwigDelegateOdDbDgnUnderlayItem_2 swigDelegate2;

	private SwigDelegateOdDbDgnUnderlayItem_3 swigDelegate3;

	private SwigDelegateOdDbDgnUnderlayItem_4 swigDelegate4;

	private SwigDelegateOdDbDgnUnderlayItem_5 swigDelegate5;

	private SwigDelegateOdDbDgnUnderlayItem_6 swigDelegate6;

	private SwigDelegateOdDbDgnUnderlayItem_7 swigDelegate7;

	private SwigDelegateOdDbDgnUnderlayItem_8 swigDelegate8;

	private SwigDelegateOdDbDgnUnderlayItem_9 swigDelegate9;

	private SwigDelegateOdDbDgnUnderlayItem_10 swigDelegate10;

	private SwigDelegateOdDbDgnUnderlayItem_11 swigDelegate11;

	private SwigDelegateOdDbDgnUnderlayItem_12 swigDelegate12;

	private SwigDelegateOdDbDgnUnderlayItem_13 swigDelegate13;

	private SwigDelegateOdDbDgnUnderlayItem_14 swigDelegate14;

	private SwigDelegateOdDbDgnUnderlayItem_15 swigDelegate15;

	private SwigDelegateOdDbDgnUnderlayItem_16 swigDelegate16;

	private SwigDelegateOdDbDgnUnderlayItem_17 swigDelegate17;

	private SwigDelegateOdDbDgnUnderlayItem_18 swigDelegate18;

	private SwigDelegateOdDbDgnUnderlayItem_19 swigDelegate19;

	private SwigDelegateOdDbDgnUnderlayItem_20 swigDelegate20;

	private SwigDelegateOdDbDgnUnderlayItem_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiWorldDraw),
		typeof(OdDbUnderlayDrawContext)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiViewportDraw),
		typeof(OdDbUnderlayDrawContext)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes13 = new Type[9]
	{
		typeof(OdGeMatrix3d),
		typeof(OsnapMode),
		typeof(IntPtr),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d),
		typeof(OdGeMatrix3d),
		typeof(OdGeMatrix3d),
		typeof(OdGePoint3dArray),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes15 = new Type[7]
	{
		typeof(OdGeMatrix3d),
		typeof(OdRxObject),
		typeof(Intersect),
		typeof(OdGePlane),
		typeof(OdGePoint3dArray),
		typeof(IntPtr),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(int),
		typeof(OdUnderlayLayer)
	};

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(bool) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDgnUnderlayItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDgnUnderlayItem obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDgnUnderlayItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDgnUnderlayItem cast(OdRxObject pObj)
	{
		OdDbDgnUnderlayItem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDgnUnderlayItem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_isASwigExplicitOdDbDgnUnderlayItem(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_queryXSwigExplicitOdDbDgnUnderlayItem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDgnUnderlayItem createObject()
	{
		OdDbDgnUnderlayItem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDgnUnderlayItem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool useMasterUnits()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_useMasterUnits(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setUseMasterUnits(bool useMaster)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_setUseMasterUnits(swigCPtr, useMaster);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool showRasterRef()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_showRasterRef(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setShowRasterRef(bool bShow)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_setShowRasterRef(swigCPtr, bShow);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDgnUnderlayItem()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDgnUnderlayItem(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDgnUnderlayItem) != GetType();
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
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetName;
		}
		if (SwigDerivedClassHasMethod("getThumbnail", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetThumbnail__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getThumbnail", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetThumbnail__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("getUnits", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetUnits;
		}
		if (SwigDerivedClassHasMethod("usingPartialContent", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodusingPartialContent;
		}
		if (SwigDerivedClassHasMethod("worldDraw", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodworldDraw;
		}
		if (SwigDerivedClassHasMethod("viewportDraw", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodviewportDraw;
		}
		if (SwigDerivedClassHasMethod("modelTransform", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodmodelTransform;
		}
		if (SwigDerivedClassHasMethod("getMediaBox", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetMediaBox;
		}
		if (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetOsnapPoints;
		}
		if (SwigDerivedClassHasMethod("getSubEntityAtGsMarker", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetSubEntityAtGsMarker;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodintersectWith;
		}
		if (SwigDerivedClassHasMethod("underlayLayerCount", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodunderlayLayerCount;
		}
		if (SwigDerivedClassHasMethod("getUnderlayLayer", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetUnderlayLayer;
		}
		if (SwigDerivedClassHasMethod("useMasterUnits", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoduseMasterUnits;
		}
		if (SwigDerivedClassHasMethod("setUseMasterUnits", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetUseMasterUnits;
		}
		if (SwigDerivedClassHasMethod("showRasterRef", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodshowRasterRef;
		}
		if (SwigDerivedClassHasMethod("setShowRasterRef", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetShowRasterRef;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDgnUnderlayItem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDgnUnderlayItem));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetName()
	{
		return getName();
	}

	private IntPtr SwigDirectorMethodgetThumbnail__SWIG_0()
	{
		return OdGiRasterImage.getCPtr(getThumbnail()).Handle;
	}

	private IntPtr SwigDirectorMethodgetThumbnail__SWIG_1(int width, int height)
	{
		return OdGiRasterImage.getCPtr(getThumbnail(width, height)).Handle;
	}

	private void SwigDirectorMethodgetExtents(IntPtr min, IntPtr max)
	{
		try
		{
			getExtents(new OdGePoint2d(min, cMemoryOwn: false), new OdGePoint2d(max, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetUnits()
	{
		return (int)getUnits();
	}

	private bool SwigDirectorMethodusingPartialContent()
	{
		return usingPartialContent();
	}

	private bool SwigDirectorMethodworldDraw(IntPtr pWd, IntPtr context)
	{
		return worldDraw(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiWorldDraw>(pWd, bOwn: false, bTryAddToTransaction: false), new OdDbUnderlayDrawContext(context, cMemoryOwn: false));
	}

	private void SwigDirectorMethodviewportDraw(IntPtr pVd, IntPtr context)
	{
		try
		{
			viewportDraw(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiViewportDraw>(pVd, bOwn: false, bTryAddToTransaction: false), new OdDbUnderlayDrawContext(context, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodmodelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(modelTransform()).Handle;
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

	private int SwigDirectorMethodgetMediaBox(IntPtr min, IntPtr max)
	{
		return (int)getMediaBox(new OdGePoint2d(min, cMemoryOwn: false), new OdGePoint2d(max, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetOsnapPoints(IntPtr modelToWorld, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr viewXform, IntPtr ucs, IntPtr snapPoints, IntPtr geomIds)
	{
		return (int)getOsnapPoints(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(viewXform, cMemoryOwn: false), new OdGeMatrix3d(ucs, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: true), new OdIntArray(geomIds, cMemoryOwn: true));
	}

	private IntPtr SwigDirectorMethodgetSubEntityAtGsMarker(IntPtr modelToWorld, IntPtr gsSelectionMark)
	{
		return OdRxObject.getCPtr(getSubEntityAtGsMarker(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), gsSelectionMark)).Handle;
	}

	private int SwigDirectorMethodintersectWith(IntPtr modelToWorld, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)intersectWith(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, (projPlane == IntPtr.Zero) ? null : new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: true), thisGsMarker, otherGsMarker);
	}

	private uint SwigDirectorMethodunderlayLayerCount()
	{
		return underlayLayerCount();
	}

	private int SwigDirectorMethodgetUnderlayLayer(int idx, IntPtr layer)
	{
		return (int)getUnderlayLayer(idx, new OdUnderlayLayer(layer, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoduseMasterUnits()
	{
		return useMasterUnits();
	}

	private void SwigDirectorMethodsetUseMasterUnits(bool useMaster)
	{
		try
		{
			setUseMasterUnits(useMaster);
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

	private bool SwigDirectorMethodshowRasterRef()
	{
		return showRasterRef();
	}

	private void SwigDirectorMethodsetShowRasterRef(bool bShow)
	{
		try
		{
			setShowRasterRef(bShow);
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
