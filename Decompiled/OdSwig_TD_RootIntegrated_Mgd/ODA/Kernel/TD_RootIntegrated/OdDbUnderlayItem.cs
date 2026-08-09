using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbUnderlayItem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbUnderlayItem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbUnderlayItem_1();

	public delegate void SwigDelegateOdDbUnderlayItem_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbUnderlayItem_3();

	public delegate IntPtr SwigDelegateOdDbUnderlayItem_4();

	public delegate IntPtr SwigDelegateOdDbUnderlayItem_5(int width, int height);

	public delegate void SwigDelegateOdDbUnderlayItem_6(IntPtr min, IntPtr max);

	public delegate int SwigDelegateOdDbUnderlayItem_7();

	public delegate bool SwigDelegateOdDbUnderlayItem_8();

	public delegate bool SwigDelegateOdDbUnderlayItem_9(IntPtr pWd, IntPtr context);

	public delegate void SwigDelegateOdDbUnderlayItem_10(IntPtr pVd, IntPtr context);

	public delegate IntPtr SwigDelegateOdDbUnderlayItem_11();

	public delegate int SwigDelegateOdDbUnderlayItem_12(IntPtr min, IntPtr max);

	public delegate int SwigDelegateOdDbUnderlayItem_13(IntPtr modelToWorld, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr viewXform, IntPtr ucs, IntPtr snapPoints, IntPtr geomIds);

	public delegate IntPtr SwigDelegateOdDbUnderlayItem_14(IntPtr modelToWorld, IntPtr gsSelectionMark);

	public delegate int SwigDelegateOdDbUnderlayItem_15(IntPtr modelToWorld, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker);

	public delegate uint SwigDelegateOdDbUnderlayItem_16();

	public delegate int SwigDelegateOdDbUnderlayItem_17(int idx, IntPtr layer);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbUnderlayItem_0 swigDelegate0;

	private SwigDelegateOdDbUnderlayItem_1 swigDelegate1;

	private SwigDelegateOdDbUnderlayItem_2 swigDelegate2;

	private SwigDelegateOdDbUnderlayItem_3 swigDelegate3;

	private SwigDelegateOdDbUnderlayItem_4 swigDelegate4;

	private SwigDelegateOdDbUnderlayItem_5 swigDelegate5;

	private SwigDelegateOdDbUnderlayItem_6 swigDelegate6;

	private SwigDelegateOdDbUnderlayItem_7 swigDelegate7;

	private SwigDelegateOdDbUnderlayItem_8 swigDelegate8;

	private SwigDelegateOdDbUnderlayItem_9 swigDelegate9;

	private SwigDelegateOdDbUnderlayItem_10 swigDelegate10;

	private SwigDelegateOdDbUnderlayItem_11 swigDelegate11;

	private SwigDelegateOdDbUnderlayItem_12 swigDelegate12;

	private SwigDelegateOdDbUnderlayItem_13 swigDelegate13;

	private SwigDelegateOdDbUnderlayItem_14 swigDelegate14;

	private SwigDelegateOdDbUnderlayItem_15 swigDelegate15;

	private SwigDelegateOdDbUnderlayItem_16 swigDelegate16;

	private SwigDelegateOdDbUnderlayItem_17 swigDelegate17;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUnderlayItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUnderlayItem obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbUnderlayItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbUnderlayItem cast(OdRxObject pObj)
	{
		OdDbUnderlayItem rXObject = Helpers.GetRXObject<OdDbUnderlayItem>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_isASwigExplicitOdDbUnderlayItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_queryXSwigExplicitOdDbUnderlayItem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbUnderlayItem createObject()
	{
		OdDbUnderlayItem rXObject = Helpers.GetRXObject<OdDbUnderlayItem>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiRasterImage getThumbnail()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getThumbnail__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiRasterImage getThumbnail(int width, int height)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("getThumbnail", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getThumbnailSwigExplicitOdDbUnderlayItem__SWIG_1(swigCPtr, width, height) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getThumbnail__SWIG_1(swigCPtr, width, height), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void getExtents(OdGePoint2d min, OdGePoint2d max)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getExtents(swigCPtr, OdGePoint2d.getCPtr(min), OdGePoint2d.getCPtr(max));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual UnitsValue getUnits()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getUnits(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (UnitsValue)result;
	}

	public virtual bool usingPartialContent()
	{
		bool result = (SwigDerivedClassHasMethod("usingPartialContent", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_usingPartialContentSwigExplicitOdDbUnderlayItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_usingPartialContent(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool worldDraw(OdGiWorldDraw pWd, OdDbUnderlayDrawContext context)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_worldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd), OdDbUnderlayDrawContext.getCPtr(context));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void viewportDraw(OdGiViewportDraw pVd, OdDbUnderlayDrawContext context)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_viewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(pVd), OdDbUnderlayDrawContext.getCPtr(context));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d modelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("modelTransform", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_modelTransformSwigExplicitOdDbUnderlayItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_modelTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getMediaBox(OdGePoint2d min, OdGePoint2d max)
	{
		int result = (SwigDerivedClassHasMethod("getMediaBox", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getMediaBoxSwigExplicitOdDbUnderlayItem(swigCPtr, OdGePoint2d.getCPtr(min), OdGePoint2d.getCPtr(max)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getMediaBox(swigCPtr, OdGePoint2d.getCPtr(min), OdGePoint2d.getCPtr(max)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getOsnapPoints(OdGeMatrix3d modelToWorld, OsnapMode osnapMode, IntPtr gsSelectionMark, OdGePoint3d pickPoint, OdGePoint3d lastPoint, OdGeMatrix3d viewXform, OdGeMatrix3d ucs, OdGePoint3dArray snapPoints, OdIntArray geomIds)
	{
		int result = (SwigDerivedClassHasMethod("getOsnapPoints", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getOsnapPointsSwigExplicitOdDbUnderlayItem(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(viewXform), OdGeMatrix3d.getCPtr(ucs), OdGePoint3dArray.getCPtr(snapPoints), OdIntArray.getCPtr(geomIds).Handle) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getOsnapPoints(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), (int)osnapMode, gsSelectionMark, OdGePoint3d.getCPtr(pickPoint), OdGePoint3d.getCPtr(lastPoint), OdGeMatrix3d.getCPtr(viewXform), OdGeMatrix3d.getCPtr(ucs), OdGePoint3dArray.getCPtr(snapPoints), OdIntArray.getCPtr(geomIds).Handle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdRxObject getSubEntityAtGsMarker(OdGeMatrix3d modelToWorld, IntPtr gsSelectionMark)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("getSubEntityAtGsMarker", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getSubEntityAtGsMarkerSwigExplicitOdDbUnderlayItem(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), gsSelectionMark) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getSubEntityAtGsMarker(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), gsSelectionMark), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult intersectWith(OdGeMatrix3d modelToWorld, OdRxObject pEnt, Intersect intType, OdGePlane projPlane, OdGePoint3dArray points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		int result = (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_intersectWithSwigExplicitOdDbUnderlayItem(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), OdRxObject.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points), thisGsMarker, otherGsMarker) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_intersectWith(swigCPtr, OdGeMatrix3d.getCPtr(modelToWorld), OdRxObject.getCPtr(pEnt), (int)intType, OdGePlane.getCPtr(projPlane), OdGePoint3dArray.getCPtr(points), thisGsMarker, otherGsMarker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual uint underlayLayerCount()
	{
		uint result = (SwigDerivedClassHasMethod("underlayLayerCount", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_underlayLayerCountSwigExplicitOdDbUnderlayItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_underlayLayerCount(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getUnderlayLayer(int idx, OdUnderlayLayer layer)
	{
		int result = (SwigDerivedClassHasMethod("getUnderlayLayer", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getUnderlayLayerSwigExplicitOdDbUnderlayItem(swigCPtr, idx, OdUnderlayLayer.getCPtr(layer)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getUnderlayLayer(swigCPtr, idx, OdUnderlayLayer.getCPtr(layer)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public int version()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_version(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbUnderlayItem()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbUnderlayItem(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbUnderlayItem) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdDbUnderlayItem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbUnderlayItem));
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
		return worldDraw(Helpers.GetRXObject<OdGiWorldDraw>(pWd, bOwn: false, bTryAddToTransaction: false), new OdDbUnderlayDrawContext(context, cMemoryOwn: false));
	}

	private void SwigDirectorMethodviewportDraw(IntPtr pVd, IntPtr context)
	{
		try
		{
			viewportDraw(Helpers.GetRXObject<OdGiViewportDraw>(pVd, bOwn: false, bTryAddToTransaction: false), new OdDbUnderlayDrawContext(context, cMemoryOwn: false));
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

	private int SwigDirectorMethodgetMediaBox(IntPtr min, IntPtr max)
	{
		return (int)getMediaBox(new OdGePoint2d(min, cMemoryOwn: false), new OdGePoint2d(max, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetOsnapPoints(IntPtr modelToWorld, int osnapMode, IntPtr gsSelectionMark, IntPtr pickPoint, IntPtr lastPoint, IntPtr viewXform, IntPtr ucs, IntPtr snapPoints, IntPtr geomIds)
	{
		return (int)getOsnapPoints(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), (OsnapMode)osnapMode, gsSelectionMark, new OdGePoint3d(pickPoint, cMemoryOwn: false), new OdGePoint3d(lastPoint, cMemoryOwn: false), new OdGeMatrix3d(viewXform, cMemoryOwn: false), new OdGeMatrix3d(ucs, cMemoryOwn: false), new OdGePoint3dArray(snapPoints, cMemoryOwn: false), new OdIntArray(geomIds, cMemoryOwn: true));
	}

	private IntPtr SwigDirectorMethodgetSubEntityAtGsMarker(IntPtr modelToWorld, IntPtr gsSelectionMark)
	{
		return OdRxObject.getCPtr(getSubEntityAtGsMarker(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), gsSelectionMark)).Handle;
	}

	private int SwigDirectorMethodintersectWith(IntPtr modelToWorld, IntPtr pEnt, int intType, IntPtr projPlane, IntPtr points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		return (int)intersectWith(new OdGeMatrix3d(modelToWorld, cMemoryOwn: false), Helpers.GetRXObject<OdRxObject>(pEnt, bOwn: false, bTryAddToTransaction: false), (Intersect)intType, (projPlane == IntPtr.Zero) ? null : new OdGePlane(projPlane, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false), thisGsMarker, otherGsMarker);
	}

	private uint SwigDirectorMethodunderlayLayerCount()
	{
		return underlayLayerCount();
	}

	private int SwigDirectorMethodgetUnderlayLayer(int idx, IntPtr layer)
	{
		return (int)getUnderlayLayer(idx, new OdUnderlayLayer(layer, cMemoryOwn: false));
	}
}
