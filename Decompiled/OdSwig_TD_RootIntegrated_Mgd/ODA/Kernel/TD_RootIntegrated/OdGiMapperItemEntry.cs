using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMapperItemEntry : OdRxObject
{
	public class MapInputTriangle : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGePoint3d inPt
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_MapInputTriangle_inPt_get(swigCPtr);
				OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_MapInputTriangle_inPt_set(swigCPtr, OdGePoint3d.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MapInputTriangle(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MapInputTriangle obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~MapInputTriangle()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapperItemEntry_MapInputTriangle(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public MapInputTriangle()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapperItemEntry_MapInputTriangle(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class MapOutputCoords : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGePoint2d outCoord
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_MapOutputCoords_outCoord_get(swigCPtr);
				OdGePoint2d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint2d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_MapOutputCoords_outCoord_set(swigCPtr, OdGePoint2d.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MapOutputCoords(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(MapOutputCoords obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~MapOutputCoords()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapperItemEntry_MapOutputCoords(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public MapOutputCoords()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapperItemEntry_MapOutputCoords(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_1();

	public delegate void SwigDelegateOdGiMapperItemEntry_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_3();

	public delegate void SwigDelegateOdGiMapperItemEntry_4(IntPtr pMapper, IntPtr pInheritMapper);

	public delegate void SwigDelegateOdGiMapperItemEntry_5(IntPtr pMapper, IntPtr pInheritMapper, IntPtr tm);

	public delegate void SwigDelegateOdGiMapperItemEntry_6(IntPtr pMaterialMapper);

	public delegate void SwigDelegateOdGiMapperItemEntry_7(IntPtr pMaterialMapper, IntPtr tm);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_8();

	public delegate void SwigDelegateOdGiMapperItemEntry_9(IntPtr tm);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_10();

	public delegate void SwigDelegateOdGiMapperItemEntry_11(IntPtr dtm);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_12();

	public delegate void SwigDelegateOdGiMapperItemEntry_13(IntPtr mtm);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_14();

	public delegate void SwigDelegateOdGiMapperItemEntry_15(IntPtr otm);

	public delegate IntPtr SwigDelegateOdGiMapperItemEntry_16();

	public delegate void SwigDelegateOdGiMapperItemEntry_17(IntPtr tm);

	public delegate void SwigDelegateOdGiMapperItemEntry_18();

	public delegate void SwigDelegateOdGiMapperItemEntry_19(IntPtr trg, IntPtr uv);

	public delegate void SwigDelegateOdGiMapperItemEntry_20(IntPtr trg, IntPtr uv);

	public delegate void SwigDelegateOdGiMapperItemEntry_21(IntPtr trg, IntPtr normal, IntPtr uv);

	public delegate void SwigDelegateOdGiMapperItemEntry_22(IntPtr trg, IntPtr normal, IntPtr uv);

	public delegate void SwigDelegateOdGiMapperItemEntry_23(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals, IntPtr pVertNormals, int oType);

	public delegate void SwigDelegateOdGiMapperItemEntry_24(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals, IntPtr pVertNormals);

	public delegate void SwigDelegateOdGiMapperItemEntry_25(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals);

	public delegate void SwigDelegateOdGiMapperItemEntry_26(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal);

	public delegate void SwigDelegateOdGiMapperItemEntry_27(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt);

	public delegate void SwigDelegateOdGiMapperItemEntry_28(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds);

	public delegate void SwigDelegateOdGiMapperItemEntry_29(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList);

	public delegate void SwigDelegateOdGiMapperItemEntry_30(uint nVerts, IntPtr pVerts, IntPtr pUV);

	public delegate void SwigDelegateOdGiMapperItemEntry_31(IntPtr pInUVW, IntPtr pOutUV, uint nPoints);

	public delegate bool SwigDelegateOdGiMapperItemEntry_32();

	public delegate bool SwigDelegateOdGiMapperItemEntry_33();

	public delegate bool SwigDelegateOdGiMapperItemEntry_34();

	public delegate bool SwigDelegateOdGiMapperItemEntry_35();

	public delegate bool SwigDelegateOdGiMapperItemEntry_36();

	public delegate void SwigDelegateOdGiMapperItemEntry_37(int nCount, IntPtr pPoints);

	public delegate void SwigDelegateOdGiMapperItemEntry_38(IntPtr exts);

	public delegate void SwigDelegateOdGiMapperItemEntry_39(int nCount, IntPtr pPoints);

	public delegate void SwigDelegateOdGiMapperItemEntry_40(IntPtr exts);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMapperItemEntry_0 swigDelegate0;

	private SwigDelegateOdGiMapperItemEntry_1 swigDelegate1;

	private SwigDelegateOdGiMapperItemEntry_2 swigDelegate2;

	private SwigDelegateOdGiMapperItemEntry_3 swigDelegate3;

	private SwigDelegateOdGiMapperItemEntry_4 swigDelegate4;

	private SwigDelegateOdGiMapperItemEntry_5 swigDelegate5;

	private SwigDelegateOdGiMapperItemEntry_6 swigDelegate6;

	private SwigDelegateOdGiMapperItemEntry_7 swigDelegate7;

	private SwigDelegateOdGiMapperItemEntry_8 swigDelegate8;

	private SwigDelegateOdGiMapperItemEntry_9 swigDelegate9;

	private SwigDelegateOdGiMapperItemEntry_10 swigDelegate10;

	private SwigDelegateOdGiMapperItemEntry_11 swigDelegate11;

	private SwigDelegateOdGiMapperItemEntry_12 swigDelegate12;

	private SwigDelegateOdGiMapperItemEntry_13 swigDelegate13;

	private SwigDelegateOdGiMapperItemEntry_14 swigDelegate14;

	private SwigDelegateOdGiMapperItemEntry_15 swigDelegate15;

	private SwigDelegateOdGiMapperItemEntry_16 swigDelegate16;

	private SwigDelegateOdGiMapperItemEntry_17 swigDelegate17;

	private SwigDelegateOdGiMapperItemEntry_18 swigDelegate18;

	private SwigDelegateOdGiMapperItemEntry_19 swigDelegate19;

	private SwigDelegateOdGiMapperItemEntry_20 swigDelegate20;

	private SwigDelegateOdGiMapperItemEntry_21 swigDelegate21;

	private SwigDelegateOdGiMapperItemEntry_22 swigDelegate22;

	private SwigDelegateOdGiMapperItemEntry_23 swigDelegate23;

	private SwigDelegateOdGiMapperItemEntry_24 swigDelegate24;

	private SwigDelegateOdGiMapperItemEntry_25 swigDelegate25;

	private SwigDelegateOdGiMapperItemEntry_26 swigDelegate26;

	private SwigDelegateOdGiMapperItemEntry_27 swigDelegate27;

	private SwigDelegateOdGiMapperItemEntry_28 swigDelegate28;

	private SwigDelegateOdGiMapperItemEntry_29 swigDelegate29;

	private SwigDelegateOdGiMapperItemEntry_30 swigDelegate30;

	private SwigDelegateOdGiMapperItemEntry_31 swigDelegate31;

	private SwigDelegateOdGiMapperItemEntry_32 swigDelegate32;

	private SwigDelegateOdGiMapperItemEntry_33 swigDelegate33;

	private SwigDelegateOdGiMapperItemEntry_34 swigDelegate34;

	private SwigDelegateOdGiMapperItemEntry_35 swigDelegate35;

	private SwigDelegateOdGiMapperItemEntry_36 swigDelegate36;

	private SwigDelegateOdGiMapperItemEntry_37 swigDelegate37;

	private SwigDelegateOdGiMapperItemEntry_38 swigDelegate38;

	private SwigDelegateOdGiMapperItemEntry_39 swigDelegate39;

	private SwigDelegateOdGiMapperItemEntry_40 swigDelegate40;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(OdGiMapper)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdGiMapper),
		typeof(OdGiMapper),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(MapInputTriangle),
		typeof(MapOutputCoords)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes21 = new Type[3]
	{
		typeof(MapInputTriangle),
		typeof(OdGeVector3d),
		typeof(MapOutputCoords)
	};

	private static Type[] swigMethodTypes22 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes23 = new Type[10]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int),
		typeof(OdGiMapperItemEntry_MappingIteratorType),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGiOrientationType)
	};

	private static Type[] swigMethodTypes24 = new Type[9]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int),
		typeof(OdGiMapperItemEntry_MappingIteratorType),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes25 = new Type[8]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int),
		typeof(OdGiMapperItemEntry_MappingIteratorType),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes26 = new Type[7]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int),
		typeof(OdGiMapperItemEntry_MappingIteratorType),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes27 = new Type[6]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int),
		typeof(OdGiMapperItemEntry_MappingIteratorType)
	};

	private static Type[] swigMethodTypes28 = new Type[5]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint),
		typeof(int)
	};

	private static Type[] swigMethodTypes29 = new Type[4]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes30 = new Type[3]
	{
		typeof(uint),
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes31 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGeExtents3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMapperItemEntry(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMapperItemEntry obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapperItemEntry(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMapperItemEntry cast(OdRxObject pObj)
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isASwigExplicitOdGiMapperItemEntry(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_queryXSwigExplicitOdGiMapperItemEntry(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMapperItemEntry createObject()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMapper mapper()
	{
		OdGiMapper result = new OdGiMapper(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapper(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMapper pInheritMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setMapper__SWIG_0(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMapper.getCPtr(pInheritMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMapper pInheritMapper, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setMapper__SWIG_1(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMapper.getCPtr(pInheritMapper), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMaterialMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMaterialMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMaterialMapper, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMaterialMapper), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d inputTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_inputTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setInputTransform(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setInputTransform(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d deviceTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_deviceTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDeviceTransform(OdGeMatrix3d dtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setDeviceTransform(swigCPtr, OdGeMatrix3d.getCPtr(dtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d modelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_modelTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setModelTransform(OdGeMatrix3d mtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setModelTransform(swigCPtr, OdGeMatrix3d.getCPtr(mtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d objectTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_objectTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setObjectTransform(OdGeMatrix3d otm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setObjectTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(otm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d outputTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_outputTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOutputTransform(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setOutputTransform(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void recomputeTransformations()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_recomputeTransformations(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(MapInputTriangle trg, MapOutputCoords uv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_0(swigCPtr, MapInputTriangle.getCPtr(trg), MapOutputCoords.getCPtr(uv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(OdGePoint3d trg, OdGePoint2d uv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(trg), OdGePoint2d.getCPtr(uv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(MapInputTriangle trg, OdGeVector3d normal, MapOutputCoords uv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_2(swigCPtr, MapInputTriangle.getCPtr(trg), OdGeVector3d.getCPtr(normal), MapOutputCoords.getCPtr(uv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(OdGePoint3d trg, OdGeVector3d normal, OdGePoint2d uv)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(trg), OdGeVector3d.getCPtr(normal), OdGePoint2d.getCPtr(uv));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds, OdGiMapperItemEntry_MappingIteratorType mapIt, OdGeVector3d pNormal, OdGeVector3d pFaceNormals, OdGeVector3d pVertNormals, OdGiOrientationType oType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_4(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds, (int)mapIt, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pFaceNormals), OdGeVector3d.getCPtr(pVertNormals), (int)oType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds, OdGiMapperItemEntry_MappingIteratorType mapIt, OdGeVector3d pNormal, OdGeVector3d pFaceNormals, OdGeVector3d pVertNormals)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_5(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds, (int)mapIt, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pFaceNormals), OdGeVector3d.getCPtr(pVertNormals));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds, OdGiMapperItemEntry_MappingIteratorType mapIt, OdGeVector3d pNormal, OdGeVector3d pFaceNormals)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_6(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds, (int)mapIt, OdGeVector3d.getCPtr(pNormal), OdGeVector3d.getCPtr(pFaceNormals));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds, OdGiMapperItemEntry_MappingIteratorType mapIt, OdGeVector3d pNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_7(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds, (int)mapIt, OdGeVector3d.getCPtr(pNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds, OdGiMapperItemEntry_MappingIteratorType mapIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_8(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds, (int)mapIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList, int pIds)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_9(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList, pIds);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV, uint nList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_10(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV), nList);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapCoords(uint nVerts, OdGePoint3d pVerts, OdGePoint2d pUV)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapCoords__SWIG_11(swigCPtr, nVerts, OdGePoint3d.getCPtr(pVerts), OdGePoint2d.getCPtr(pUV));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void mapPredefinedCoords(OdGePoint3d pInUVW, OdGePoint2d pOutUV, uint nPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_mapPredefinedCoords(swigCPtr, OdGePoint3d.getCPtr(pInUVW), OdGePoint2d.getCPtr(pOutUV), nPoints);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isEntityMapper()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isEntityMapper(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isObjectMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isObjectMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isModelMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isModelMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDependsFromObjectMatrix()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isDependsFromObjectMatrix(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isVertexTransformRequired()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_isVertexTransformRequired(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVertexTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setVertexTransform__SWIG_0(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVertexTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setVertexTransform__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setObjectTransform__SWIG_1(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_setObjectTransform__SWIG_2(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapperItemEntry()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapperItemEntry(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMapperItemEntry) != GetType();
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
		if (SwigDerivedClassHasMethod("mapper", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmapper;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetMapper__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetMapper__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("inputTransform", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodinputTransform;
		}
		if (SwigDerivedClassHasMethod("setInputTransform", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetInputTransform;
		}
		if (SwigDerivedClassHasMethod("deviceTransform", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoddeviceTransform;
		}
		if (SwigDerivedClassHasMethod("setDeviceTransform", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetDeviceTransform;
		}
		if (SwigDerivedClassHasMethod("modelTransform", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodmodelTransform;
		}
		if (SwigDerivedClassHasMethod("setModelTransform", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetModelTransform;
		}
		if (SwigDerivedClassHasMethod("objectTransform", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodobjectTransform;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetObjectTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("outputTransform", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodoutputTransform;
		}
		if (SwigDerivedClassHasMethod("setOutputTransform", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetOutputTransform;
		}
		if (SwigDerivedClassHasMethod("recomputeTransformations", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodrecomputeTransformations;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodmapCoords__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodmapCoords__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodmapCoords__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodmapCoords__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodmapCoords__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodmapCoords__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodmapCoords__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodmapCoords__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodmapCoords__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodmapCoords__SWIG_9;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodmapCoords__SWIG_10;
		}
		if (SwigDerivedClassHasMethod("mapCoords", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodmapCoords__SWIG_11;
		}
		if (SwigDerivedClassHasMethod("mapPredefinedCoords", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodmapPredefinedCoords;
		}
		if (SwigDerivedClassHasMethod("isEntityMapper", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodisEntityMapper;
		}
		if (SwigDerivedClassHasMethod("isObjectMatrixNeed", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodisObjectMatrixNeed;
		}
		if (SwigDerivedClassHasMethod("isModelMatrixNeed", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodisModelMatrixNeed;
		}
		if (SwigDerivedClassHasMethod("isDependsFromObjectMatrix", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodisDependsFromObjectMatrix;
		}
		if (SwigDerivedClassHasMethod("isVertexTransformRequired", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodisVertexTransformRequired;
		}
		if (SwigDerivedClassHasMethod("setVertexTransform", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetVertexTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setVertexTransform", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetVertexTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetObjectTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsetObjectTransform__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItemEntry_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMapperItemEntry));
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

	private IntPtr SwigDirectorMethodmapper()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMapper.getCPtr(mapper()).Handle;
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

	private void SwigDirectorMethodsetMapper__SWIG_0(IntPtr pMapper, IntPtr pInheritMapper)
	{
		try
		{
			setMapper(new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMapper(pInheritMapper, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_1(IntPtr pMapper, IntPtr pInheritMapper, IntPtr tm)
	{
		try
		{
			setMapper(new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMapper(pInheritMapper, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_2(IntPtr pMaterialMapper)
	{
		try
		{
			setMapper(new OdGiMapper(pMaterialMapper, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_3(IntPtr pMaterialMapper, IntPtr tm)
	{
		try
		{
			setMapper(new OdGiMapper(pMaterialMapper, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodinputTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(inputTransform()).Handle;
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

	private void SwigDirectorMethodsetInputTransform(IntPtr tm)
	{
		try
		{
			setInputTransform(new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethoddeviceTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(deviceTransform()).Handle;
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

	private void SwigDirectorMethodsetDeviceTransform(IntPtr dtm)
	{
		try
		{
			setDeviceTransform(new OdGeMatrix3d(dtm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetModelTransform(IntPtr mtm)
	{
		try
		{
			setModelTransform(new OdGeMatrix3d(mtm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodobjectTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(objectTransform()).Handle;
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_0(IntPtr otm)
	{
		try
		{
			setObjectTransform(new OdGeMatrix3d(otm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodoutputTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(outputTransform()).Handle;
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

	private void SwigDirectorMethodsetOutputTransform(IntPtr tm)
	{
		try
		{
			setOutputTransform(new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private void SwigDirectorMethodrecomputeTransformations()
	{
		try
		{
			recomputeTransformations();
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

	private void SwigDirectorMethodmapCoords__SWIG_0(IntPtr trg, IntPtr uv)
	{
		try
		{
			mapCoords(new MapInputTriangle(trg, cMemoryOwn: false), new MapOutputCoords(uv, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_1(IntPtr trg, IntPtr uv)
	{
		try
		{
			mapCoords((trg == IntPtr.Zero) ? null : new OdGePoint3d(trg, cMemoryOwn: false), (uv == IntPtr.Zero) ? null : new OdGePoint2d(uv, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_2(IntPtr trg, IntPtr normal, IntPtr uv)
	{
		try
		{
			mapCoords(new MapInputTriangle(trg, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), new MapOutputCoords(uv, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_3(IntPtr trg, IntPtr normal, IntPtr uv)
	{
		try
		{
			mapCoords((trg == IntPtr.Zero) ? null : new OdGePoint3d(trg, cMemoryOwn: false), new OdGeVector3d(normal, cMemoryOwn: false), (uv == IntPtr.Zero) ? null : new OdGePoint2d(uv, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_4(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals, IntPtr pVertNormals, int oType)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds, (OdGiMapperItemEntry_MappingIteratorType)mapIt, (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), (pFaceNormals == IntPtr.Zero) ? null : new OdGeVector3d(pFaceNormals, cMemoryOwn: false), (pVertNormals == IntPtr.Zero) ? null : new OdGeVector3d(pVertNormals, cMemoryOwn: false), (OdGiOrientationType)oType);
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

	private void SwigDirectorMethodmapCoords__SWIG_5(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals, IntPtr pVertNormals)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds, (OdGiMapperItemEntry_MappingIteratorType)mapIt, (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), (pFaceNormals == IntPtr.Zero) ? null : new OdGeVector3d(pFaceNormals, cMemoryOwn: false), (pVertNormals == IntPtr.Zero) ? null : new OdGeVector3d(pVertNormals, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_6(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal, IntPtr pFaceNormals)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds, (OdGiMapperItemEntry_MappingIteratorType)mapIt, (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false), (pFaceNormals == IntPtr.Zero) ? null : new OdGeVector3d(pFaceNormals, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_7(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt, IntPtr pNormal)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds, (OdGiMapperItemEntry_MappingIteratorType)mapIt, (pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapCoords__SWIG_8(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds, int mapIt)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds, (OdGiMapperItemEntry_MappingIteratorType)mapIt);
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

	private void SwigDirectorMethodmapCoords__SWIG_9(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList, int pIds)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList, pIds);
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

	private void SwigDirectorMethodmapCoords__SWIG_10(uint nVerts, IntPtr pVerts, IntPtr pUV, uint nList)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false), nList);
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

	private void SwigDirectorMethodmapCoords__SWIG_11(uint nVerts, IntPtr pVerts, IntPtr pUV)
	{
		try
		{
			mapCoords(nVerts, (pVerts == IntPtr.Zero) ? null : new OdGePoint3d(pVerts, cMemoryOwn: false), (pUV == IntPtr.Zero) ? null : new OdGePoint2d(pUV, cMemoryOwn: false));
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

	private void SwigDirectorMethodmapPredefinedCoords(IntPtr pInUVW, IntPtr pOutUV, uint nPoints)
	{
		try
		{
			mapPredefinedCoords((pInUVW == IntPtr.Zero) ? null : new OdGePoint3d(pInUVW, cMemoryOwn: false), (pOutUV == IntPtr.Zero) ? null : new OdGePoint2d(pOutUV, cMemoryOwn: false), nPoints);
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

	private bool SwigDirectorMethodisEntityMapper()
	{
		return isEntityMapper();
	}

	private bool SwigDirectorMethodisObjectMatrixNeed()
	{
		return isObjectMatrixNeed();
	}

	private bool SwigDirectorMethodisModelMatrixNeed()
	{
		return isModelMatrixNeed();
	}

	private bool SwigDirectorMethodisDependsFromObjectMatrix()
	{
		return isDependsFromObjectMatrix();
	}

	private bool SwigDirectorMethodisVertexTransformRequired()
	{
		return isVertexTransformRequired();
	}

	private void SwigDirectorMethodsetVertexTransform__SWIG_0(int nCount, IntPtr pPoints)
	{
		try
		{
			setVertexTransform(nCount, (pPoints == IntPtr.Zero) ? null : new OdGePoint3d(pPoints, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetVertexTransform__SWIG_1(IntPtr exts)
	{
		try
		{
			setVertexTransform(new OdGeExtents3d(exts, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_1(int nCount, IntPtr pPoints)
	{
		try
		{
			setObjectTransform(nCount, (pPoints == IntPtr.Zero) ? null : new OdGePoint3d(pPoints, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_2(IntPtr exts)
	{
		try
		{
			setObjectTransform(new OdGeExtents3d(exts, cMemoryOwn: false));
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
