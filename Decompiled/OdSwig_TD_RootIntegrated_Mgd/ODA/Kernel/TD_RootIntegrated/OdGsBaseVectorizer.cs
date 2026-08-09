using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseVectorizer : OdGiBaseVectorizerImpl
{
	public class BlockModificationListener : OdRxObject
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BlockModificationListener(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_BlockModificationListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(BlockModificationListener obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizer_BlockModificationListener(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public virtual void blockContentsRemoved(IntPtr pRefId)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_BlockModificationListener_blockContentsRemoved(swigCPtr, pRefId);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class BlockScopesCallback : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BlockScopesCallback(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(BlockScopesCallback obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~BlockScopesCallback()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizer_BlockScopesCallback(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual BlockModificationListener blockBegin(IntPtr pRefId)
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_BlockScopesCallback_blockBegin(swigCPtr, pRefId);
			BlockModificationListener result = ((intPtr == IntPtr.Zero) ? null : new BlockModificationListener(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual void blockEnd(IntPtr pRefId)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_BlockScopesCallback_blockEnd(swigCPtr, pRefId);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_1();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_2();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_3();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_4();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_5();

	public delegate bool SwigDelegateOdGsBaseVectorizer_6();

	public delegate bool SwigDelegateOdGsBaseVectorizer_7(IntPtr point);

	public delegate bool SwigDelegateOdGsBaseVectorizer_8(IntPtr point);

	public delegate void SwigDelegateOdGsBaseVectorizer_9(IntPtr point, IntPtr pixelDensity, bool includePerspective);

	public delegate void SwigDelegateOdGsBaseVectorizer_10(IntPtr point, IntPtr pixelDensity);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_11();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_12();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_13();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_14();

	public delegate uint SwigDelegateOdGsBaseVectorizer_15();

	public delegate short SwigDelegateOdGsBaseVectorizer_16();

	public delegate void SwigDelegateOdGsBaseVectorizer_17(IntPtr lowerLeft, IntPtr upperRight);

	public delegate bool SwigDelegateOdGsBaseVectorizer_18(bool clipFront, bool clipBack, double front, double back);

	public delegate double SwigDelegateOdGsBaseVectorizer_19();

	public delegate double SwigDelegateOdGsBaseVectorizer_20();

	public delegate bool SwigDelegateOdGsBaseVectorizer_21(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_22();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_23();

	public delegate void SwigDelegateOdGsBaseVectorizer_24(IntPtr view);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_25();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_26();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_27();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_28();

	public delegate void SwigDelegateOdGsBaseVectorizer_29(IntPtr normal);

	public delegate void SwigDelegateOdGsBaseVectorizer_30(IntPtr xfm);

	public delegate void SwigDelegateOdGsBaseVectorizer_31();

	public delegate void SwigDelegateOdGsBaseVectorizer_32(IntPtr firstPoint, IntPtr secondPoint);

	public delegate void SwigDelegateOdGsBaseVectorizer_33(IntPtr basePoint, IntPtr throughPoint);

	public delegate void SwigDelegateOdGsBaseVectorizer_34(IntPtr numVertices);

	public delegate void SwigDelegateOdGsBaseVectorizer_35(IntPtr numRows);

	public delegate void SwigDelegateOdGsBaseVectorizer_36(IntPtr newExtents);

	public delegate double SwigDelegateOdGsBaseVectorizer_37(int deviationType, IntPtr pointOnCurve);

	public delegate int SwigDelegateOdGsBaseVectorizer_38();

	public delegate uint SwigDelegateOdGsBaseVectorizer_39();

	public delegate bool SwigDelegateOdGsBaseVectorizer_40(uint viewportId);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_41();

	public delegate void SwigDelegateOdGsBaseVectorizer_42(IntPtr pNormal);

	public delegate void SwigDelegateOdGsBaseVectorizer_43();

	public delegate void SwigDelegateOdGsBaseVectorizer_44(int fillType);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_45();

	public delegate uint SwigDelegateOdGsBaseVectorizer_46();

	public delegate bool SwigDelegateOdGsBaseVectorizer_47(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizer_48();

	public delegate bool SwigDelegateOdGsBaseVectorizer_49(IntPtr pOverride);

	public delegate void SwigDelegateOdGsBaseVectorizer_50();

	public delegate bool SwigDelegateOdGsBaseVectorizer_51();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_52();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_53();

	public delegate double SwigDelegateOdGsBaseVectorizer_54();

	public delegate void SwigDelegateOdGsBaseVectorizer_55();

	public delegate void SwigDelegateOdGsBaseVectorizer_56();

	public delegate void SwigDelegateOdGsBaseVectorizer_57();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_58();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_59();

	public delegate void SwigDelegateOdGsBaseVectorizer_60(IntPtr pDrawable);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_61();

	public delegate void SwigDelegateOdGsBaseVectorizer_62(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizer_63(IntPtr pMetafile);

	public delegate void SwigDelegateOdGsBaseVectorizer_64(IntPtr pMetafile);

	public delegate bool SwigDelegateOdGsBaseVectorizer_65(IntPtr pMetafile, IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_66(IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizer_67();

	public delegate bool SwigDelegateOdGsBaseVectorizer_68();

	public delegate bool SwigDelegateOdGsBaseVectorizer_69();

	public delegate void SwigDelegateOdGsBaseVectorizer_70();

	public delegate void SwigDelegateOdGsBaseVectorizer_71();

	public delegate void SwigDelegateOdGsBaseVectorizer_72(IntPtr materialId, IntPtr pNode);

	public delegate bool SwigDelegateOdGsBaseVectorizer_73(IntPtr pNode, IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseVectorizer_74(IntPtr pNode, IntPtr pFiler);

	public delegate void SwigDelegateOdGsBaseVectorizer_75(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_76(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_77(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_78(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_79(IntPtr pBoundary);

	public delegate void SwigDelegateOdGsBaseVectorizer_80(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGsBaseVectorizer_81();

	public delegate void SwigDelegateOdGsBaseVectorizer_82();

	public delegate void SwigDelegateOdGsBaseVectorizer_83(int bit, bool value);

	public delegate void SwigDelegateOdGsBaseVectorizer_84(int bit);

	public delegate void SwigDelegateOdGsBaseVectorizer_85(IntPtr arg0, uint arg1);

	public delegate void SwigDelegateOdGsBaseVectorizer_86(IntPtr arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_87(uint arg0);

	public delegate void SwigDelegateOdGsBaseVectorizer_88();

	public delegate bool SwigDelegateOdGsBaseVectorizer_89();

	public delegate bool SwigDelegateOdGsBaseVectorizer_90();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_91();

	public delegate void SwigDelegateOdGsBaseVectorizer_92(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_93();

	public delegate void SwigDelegateOdGsBaseVectorizer_94(IntPtr arg0, IntPtr error);

	public delegate void SwigDelegateOdGsBaseVectorizer_95(IntPtr pXform);

	public delegate bool SwigDelegateOdGsBaseVectorizer_96();

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_97();

	public delegate void SwigDelegateOdGsBaseVectorizer_98(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizer_99();

	public delegate void SwigDelegateOdGsBaseVectorizer_100(bool analytic);

	public delegate bool SwigDelegateOdGsBaseVectorizer_101();

	public delegate bool SwigDelegateOdGsBaseVectorizer_102(IntPtr pdro, uint incFlags);

	public delegate bool SwigDelegateOdGsBaseVectorizer_103(IntPtr pdro);

	public delegate bool SwigDelegateOdGsBaseVectorizer_104();

	public delegate bool SwigDelegateOdGsBaseVectorizer_105();

	public delegate bool SwigDelegateOdGsBaseVectorizer_106(uint drawableFlags, IntPtr pDrawable);

	public delegate void SwigDelegateOdGsBaseVectorizer_107(IntPtr selectionMarker);

	public delegate IntPtr SwigDelegateOdGsBaseVectorizer_108();

	public delegate void SwigDelegateOdGsBaseVectorizer_109(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsBaseVectorizer_110();

	public delegate void SwigDelegateOdGsBaseVectorizer_111(IntPtr pGeomPortion);

	public delegate void SwigDelegateOdGsBaseVectorizer_112();

	public delegate void SwigDelegateOdGsBaseVectorizer_113(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize);

	public delegate void SwigDelegateOdGsBaseVectorizer_114(int overlayId);

	public delegate void SwigDelegateOdGsBaseVectorizer_115(IntPtr node, IntPtr ctx);

	public delegate void SwigDelegateOdGsBaseVectorizer_116(IntPtr node, IntPtr ctx, bool bHighlighted);

	public delegate bool SwigDelegateOdGsBaseVectorizer_117();

	public delegate uint SwigDelegateOdGsBaseVectorizer_118(IntPtr pDrawable);

	public delegate bool SwigDelegateOdGsBaseVectorizer_119();

	public delegate void SwigDelegateOdGsBaseVectorizer_120(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizer_121(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize);

	public delegate void SwigDelegateOdGsBaseVectorizer_122(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList);

	public delegate void SwigDelegateOdGsBaseVectorizer_123(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseVectorizer_124(IntPtr pReactor, IntPtr pCtx);

	public delegate void SwigDelegateOdGsBaseVectorizer_125(IntPtr pReactor);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseVectorizer_0 swigDelegate0;

	private SwigDelegateOdGsBaseVectorizer_1 swigDelegate1;

	private SwigDelegateOdGsBaseVectorizer_2 swigDelegate2;

	private SwigDelegateOdGsBaseVectorizer_3 swigDelegate3;

	private SwigDelegateOdGsBaseVectorizer_4 swigDelegate4;

	private SwigDelegateOdGsBaseVectorizer_5 swigDelegate5;

	private SwigDelegateOdGsBaseVectorizer_6 swigDelegate6;

	private SwigDelegateOdGsBaseVectorizer_7 swigDelegate7;

	private SwigDelegateOdGsBaseVectorizer_8 swigDelegate8;

	private SwigDelegateOdGsBaseVectorizer_9 swigDelegate9;

	private SwigDelegateOdGsBaseVectorizer_10 swigDelegate10;

	private SwigDelegateOdGsBaseVectorizer_11 swigDelegate11;

	private SwigDelegateOdGsBaseVectorizer_12 swigDelegate12;

	private SwigDelegateOdGsBaseVectorizer_13 swigDelegate13;

	private SwigDelegateOdGsBaseVectorizer_14 swigDelegate14;

	private SwigDelegateOdGsBaseVectorizer_15 swigDelegate15;

	private SwigDelegateOdGsBaseVectorizer_16 swigDelegate16;

	private SwigDelegateOdGsBaseVectorizer_17 swigDelegate17;

	private SwigDelegateOdGsBaseVectorizer_18 swigDelegate18;

	private SwigDelegateOdGsBaseVectorizer_19 swigDelegate19;

	private SwigDelegateOdGsBaseVectorizer_20 swigDelegate20;

	private SwigDelegateOdGsBaseVectorizer_21 swigDelegate21;

	private SwigDelegateOdGsBaseVectorizer_22 swigDelegate22;

	private SwigDelegateOdGsBaseVectorizer_23 swigDelegate23;

	private SwigDelegateOdGsBaseVectorizer_24 swigDelegate24;

	private SwigDelegateOdGsBaseVectorizer_25 swigDelegate25;

	private SwigDelegateOdGsBaseVectorizer_26 swigDelegate26;

	private SwigDelegateOdGsBaseVectorizer_27 swigDelegate27;

	private SwigDelegateOdGsBaseVectorizer_28 swigDelegate28;

	private SwigDelegateOdGsBaseVectorizer_29 swigDelegate29;

	private SwigDelegateOdGsBaseVectorizer_30 swigDelegate30;

	private SwigDelegateOdGsBaseVectorizer_31 swigDelegate31;

	private SwigDelegateOdGsBaseVectorizer_32 swigDelegate32;

	private SwigDelegateOdGsBaseVectorizer_33 swigDelegate33;

	private SwigDelegateOdGsBaseVectorizer_34 swigDelegate34;

	private SwigDelegateOdGsBaseVectorizer_35 swigDelegate35;

	private SwigDelegateOdGsBaseVectorizer_36 swigDelegate36;

	private SwigDelegateOdGsBaseVectorizer_37 swigDelegate37;

	private SwigDelegateOdGsBaseVectorizer_38 swigDelegate38;

	private SwigDelegateOdGsBaseVectorizer_39 swigDelegate39;

	private SwigDelegateOdGsBaseVectorizer_40 swigDelegate40;

	private SwigDelegateOdGsBaseVectorizer_41 swigDelegate41;

	private SwigDelegateOdGsBaseVectorizer_42 swigDelegate42;

	private SwigDelegateOdGsBaseVectorizer_43 swigDelegate43;

	private SwigDelegateOdGsBaseVectorizer_44 swigDelegate44;

	private SwigDelegateOdGsBaseVectorizer_45 swigDelegate45;

	private SwigDelegateOdGsBaseVectorizer_46 swigDelegate46;

	private SwigDelegateOdGsBaseVectorizer_47 swigDelegate47;

	private SwigDelegateOdGsBaseVectorizer_48 swigDelegate48;

	private SwigDelegateOdGsBaseVectorizer_49 swigDelegate49;

	private SwigDelegateOdGsBaseVectorizer_50 swigDelegate50;

	private SwigDelegateOdGsBaseVectorizer_51 swigDelegate51;

	private SwigDelegateOdGsBaseVectorizer_52 swigDelegate52;

	private SwigDelegateOdGsBaseVectorizer_53 swigDelegate53;

	private SwigDelegateOdGsBaseVectorizer_54 swigDelegate54;

	private SwigDelegateOdGsBaseVectorizer_55 swigDelegate55;

	private SwigDelegateOdGsBaseVectorizer_56 swigDelegate56;

	private SwigDelegateOdGsBaseVectorizer_57 swigDelegate57;

	private SwigDelegateOdGsBaseVectorizer_58 swigDelegate58;

	private SwigDelegateOdGsBaseVectorizer_59 swigDelegate59;

	private SwigDelegateOdGsBaseVectorizer_60 swigDelegate60;

	private SwigDelegateOdGsBaseVectorizer_61 swigDelegate61;

	private SwigDelegateOdGsBaseVectorizer_62 swigDelegate62;

	private SwigDelegateOdGsBaseVectorizer_63 swigDelegate63;

	private SwigDelegateOdGsBaseVectorizer_64 swigDelegate64;

	private SwigDelegateOdGsBaseVectorizer_65 swigDelegate65;

	private SwigDelegateOdGsBaseVectorizer_66 swigDelegate66;

	private SwigDelegateOdGsBaseVectorizer_67 swigDelegate67;

	private SwigDelegateOdGsBaseVectorizer_68 swigDelegate68;

	private SwigDelegateOdGsBaseVectorizer_69 swigDelegate69;

	private SwigDelegateOdGsBaseVectorizer_70 swigDelegate70;

	private SwigDelegateOdGsBaseVectorizer_71 swigDelegate71;

	private SwigDelegateOdGsBaseVectorizer_72 swigDelegate72;

	private SwigDelegateOdGsBaseVectorizer_73 swigDelegate73;

	private SwigDelegateOdGsBaseVectorizer_74 swigDelegate74;

	private SwigDelegateOdGsBaseVectorizer_75 swigDelegate75;

	private SwigDelegateOdGsBaseVectorizer_76 swigDelegate76;

	private SwigDelegateOdGsBaseVectorizer_77 swigDelegate77;

	private SwigDelegateOdGsBaseVectorizer_78 swigDelegate78;

	private SwigDelegateOdGsBaseVectorizer_79 swigDelegate79;

	private SwigDelegateOdGsBaseVectorizer_80 swigDelegate80;

	private SwigDelegateOdGsBaseVectorizer_81 swigDelegate81;

	private SwigDelegateOdGsBaseVectorizer_82 swigDelegate82;

	private SwigDelegateOdGsBaseVectorizer_83 swigDelegate83;

	private SwigDelegateOdGsBaseVectorizer_84 swigDelegate84;

	private SwigDelegateOdGsBaseVectorizer_85 swigDelegate85;

	private SwigDelegateOdGsBaseVectorizer_86 swigDelegate86;

	private SwigDelegateOdGsBaseVectorizer_87 swigDelegate87;

	private SwigDelegateOdGsBaseVectorizer_88 swigDelegate88;

	private SwigDelegateOdGsBaseVectorizer_89 swigDelegate89;

	private SwigDelegateOdGsBaseVectorizer_90 swigDelegate90;

	private SwigDelegateOdGsBaseVectorizer_91 swigDelegate91;

	private SwigDelegateOdGsBaseVectorizer_92 swigDelegate92;

	private SwigDelegateOdGsBaseVectorizer_93 swigDelegate93;

	private SwigDelegateOdGsBaseVectorizer_94 swigDelegate94;

	private SwigDelegateOdGsBaseVectorizer_95 swigDelegate95;

	private SwigDelegateOdGsBaseVectorizer_96 swigDelegate96;

	private SwigDelegateOdGsBaseVectorizer_97 swigDelegate97;

	private SwigDelegateOdGsBaseVectorizer_98 swigDelegate98;

	private SwigDelegateOdGsBaseVectorizer_99 swigDelegate99;

	private SwigDelegateOdGsBaseVectorizer_100 swigDelegate100;

	private SwigDelegateOdGsBaseVectorizer_101 swigDelegate101;

	private SwigDelegateOdGsBaseVectorizer_102 swigDelegate102;

	private SwigDelegateOdGsBaseVectorizer_103 swigDelegate103;

	private SwigDelegateOdGsBaseVectorizer_104 swigDelegate104;

	private SwigDelegateOdGsBaseVectorizer_105 swigDelegate105;

	private SwigDelegateOdGsBaseVectorizer_106 swigDelegate106;

	private SwigDelegateOdGsBaseVectorizer_107 swigDelegate107;

	private SwigDelegateOdGsBaseVectorizer_108 swigDelegate108;

	private SwigDelegateOdGsBaseVectorizer_109 swigDelegate109;

	private SwigDelegateOdGsBaseVectorizer_110 swigDelegate110;

	private SwigDelegateOdGsBaseVectorizer_111 swigDelegate111;

	private SwigDelegateOdGsBaseVectorizer_112 swigDelegate112;

	private SwigDelegateOdGsBaseVectorizer_113 swigDelegate113;

	private SwigDelegateOdGsBaseVectorizer_114 swigDelegate114;

	private SwigDelegateOdGsBaseVectorizer_115 swigDelegate115;

	private SwigDelegateOdGsBaseVectorizer_116 swigDelegate116;

	private SwigDelegateOdGsBaseVectorizer_117 swigDelegate117;

	private SwigDelegateOdGsBaseVectorizer_118 swigDelegate118;

	private SwigDelegateOdGsBaseVectorizer_119 swigDelegate119;

	private SwigDelegateOdGsBaseVectorizer_120 swigDelegate120;

	private SwigDelegateOdGsBaseVectorizer_121 swigDelegate121;

	private SwigDelegateOdGsBaseVectorizer_122 swigDelegate122;

	private SwigDelegateOdGsBaseVectorizer_123 swigDelegate123;

	private SwigDelegateOdGsBaseVectorizer_124 swigDelegate124;

	private SwigDelegateOdGsBaseVectorizer_125 swigDelegate125;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdGePoint2d),
		typeof(OdGePoint2d)
	};

	private static Type[] swigMethodTypes18 = new Type[4]
	{
		typeof(bool).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGsViewImpl).MakeByRefType() };

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes33 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(ShellData) };

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(MeshData) };

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdGiDeviationType),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes65 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(OdGsFiler) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[0];

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[0];

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGsMaterialNode)
	};

	private static Type[] swigMethodTypes73 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes74 = new Type[2]
	{
		typeof(OdGsMaterialNode),
		typeof(OdGsFiler)
	};

	private static Type[] swigMethodTypes75 = new Type[1] { typeof(OdGiPointLightTraitsData) };

	private static Type[] swigMethodTypes76 = new Type[1] { typeof(OdGiSpotLightTraitsData) };

	private static Type[] swigMethodTypes77 = new Type[1] { typeof(OdGiDistantLightTraitsData) };

	private static Type[] swigMethodTypes78 = new Type[1] { typeof(OdGiWebLightTraitsData) };

	private static Type[] swigMethodTypes79 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes80 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes81 = new Type[0];

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes85 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(uint)
	};

	private static Type[] swigMethodTypes86 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes87 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes88 = new Type[0];

	private static Type[] swigMethodTypes89 = new Type[0];

	private static Type[] swigMethodTypes90 = new Type[0];

	private static Type[] swigMethodTypes91 = new Type[0];

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes93 = new Type[0];

	private static Type[] swigMethodTypes94 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdError)
	};

	private static Type[] swigMethodTypes95 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes96 = new Type[0];

	private static Type[] swigMethodTypes97 = new Type[0];

	private static Type[] swigMethodTypes98 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes99 = new Type[0];

	private static Type[] swigMethodTypes100 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes101 = new Type[0];

	private static Type[] swigMethodTypes102 = new Type[2]
	{
		typeof(OdGsPropertiesDirectRenderOutput),
		typeof(uint)
	};

	private static Type[] swigMethodTypes103 = new Type[1] { typeof(OdGsPropertiesDirectRenderOutput) };

	private static Type[] swigMethodTypes104 = new Type[0];

	private static Type[] swigMethodTypes105 = new Type[0];

	private static Type[] swigMethodTypes106 = new Type[2]
	{
		typeof(uint),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes107 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes108 = new Type[0];

	private static Type[] swigMethodTypes109 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes110 = new Type[0];

	private static Type[] swigMethodTypes111 = new Type[1] { typeof(OdGsGeomPortion) };

	private static Type[] swigMethodTypes112 = new Type[0];

	private static Type[] swigMethodTypes113 = new Type[6]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGsRayTraceReactor),
		typeof(bool),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdGsOverlayId) };

	private static Type[] swigMethodTypes115 = new Type[2]
	{
		typeof(OdGsNode).MakeByRefType(),
		typeof(OdGsDisplayContext)
	};

	private static Type[] swigMethodTypes116 = new Type[3]
	{
		typeof(OdGsEntityNode).MakeByRefType(),
		typeof(OdGsDisplayContext),
		typeof(bool)
	};

	private static Type[] swigMethodTypes117 = new Type[0];

	private static Type[] swigMethodTypes118 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes119 = new Type[0];

	private static Type[] swigMethodTypes120 = new Type[6]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes121 = new Type[5]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes122 = new Type[4]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGiPathNode[])
	};

	private static Type[] swigMethodTypes123 = new Type[3]
	{
		typeof(OdGiPathNode[]),
		typeof(uint),
		typeof(OdGsCollisionDetectionReactor)
	};

	private static Type[] swigMethodTypes124 = new Type[2]
	{
		typeof(OdGsCollisionDetectionReactor),
		typeof(OdGsCollisionDetectionContext)
	};

	private static Type[] swigMethodTypes125 = new Type[1] { typeof(OdGsCollisionDetectionReactor) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseVectorizer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseVectorizer obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseVectorizer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdGsBaseVectorizer()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseVectorizer(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseVectorizer) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new virtual void draw(OdGiDrawable pDrawable)
	{
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes60))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_drawSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_draw(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsWriter gsWriter()
	{
		OdGsWriter result = new OdGsWriter(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_gsWriter__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsExtAccum gsExtentsAccum()
	{
		OdGsExtAccum rXObject = Helpers.GetRXObject<OdGsExtAccum>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_gsExtentsAccum(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject newGsMetafile()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("newGsMetafile", swigMethodTypes61) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_newGsMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_newGsMetafile(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void beginMetafile(OdRxObject pMetafile)
	{
		if (SwigDerivedClassHasMethod("beginMetafile", swigMethodTypes62))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endMetafile(OdRxObject pMetafile)
	{
		if (SwigDerivedClassHasMethod("endMetafile", swigMethodTypes63))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void playMetafile(OdRxObject pMetafile)
	{
		if (SwigDerivedClassHasMethod("playMetafile", swigMethodTypes64))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_playMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_playMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool saveMetafile(OdRxObject pMetafile, OdGsFiler pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveMetafile", swigMethodTypes65) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_saveMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr, OdRxObject.getCPtr(pMetafile), OdGsFiler.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_saveMetafile(swigCPtr, OdRxObject.getCPtr(pMetafile), OdGsFiler.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject loadMetafile(OdGsFiler pFiler)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("loadMetafile", swigMethodTypes66) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadMetafileSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGsFiler.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadMetafile(swigCPtr, OdGsFiler.getCPtr(pFiler)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isMetafileEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isMetafileEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong lastMetafileSize()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_lastMetafileSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void loadViewport()
	{
		if (SwigDerivedClassHasMethod("loadViewport", swigMethodTypes67))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadViewportSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadViewport(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool forceMetafilesDependence()
	{
		bool result = (SwigDerivedClassHasMethod("forceMetafilesDependence", swigMethodTypes68) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_forceMetafilesDependenceSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_forceMetafilesDependence(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isViewRegenerated()
	{
		bool result = (SwigDerivedClassHasMethod("isViewRegenerated", swigMethodTypes69) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isViewRegeneratedSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isViewRegenerated(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void drawViewportFrame()
	{
		if (SwigDerivedClassHasMethod("drawViewportFrame", swigMethodTypes70))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_drawViewportFrameSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_drawViewportFrame(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void updateViewport()
	{
		if (SwigDerivedClassHasMethod("updateViewport", swigMethodTypes71))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_updateViewportSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_updateViewport(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void processMaterialNode(OdDbStub materialId, OdGsMaterialNode pNode)
	{
		if (SwigDerivedClassHasMethod("processMaterialNode", swigMethodTypes72))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_processMaterialNodeSwigExplicitOdGsBaseVectorizer(swigCPtr, OdDbStub.getCPtr(materialId), OdGsMaterialNode.getCPtr(pNode));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_processMaterialNode(swigCPtr, OdDbStub.getCPtr(materialId), OdGsMaterialNode.getCPtr(pNode));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool saveMaterialCache(OdGsMaterialNode pNode, OdGsFiler pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveMaterialCache", swigMethodTypes73) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_saveMaterialCacheSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_saveMaterialCache(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadMaterialCache(OdGsMaterialNode pNode, OdGsFiler pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadMaterialCache", swigMethodTypes74) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadMaterialCacheSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_loadMaterialCache(swigCPtr, OdGsMaterialNode.getCPtr(pNode), OdGsFiler.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addPointLight(OdGiPointLightTraitsData arg0)
	{
		if (SwigDerivedClassHasMethod("addPointLight", swigMethodTypes75))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addPointLightSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiPointLightTraitsData.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addPointLight(swigCPtr, OdGiPointLightTraitsData.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addSpotLight(OdGiSpotLightTraitsData arg0)
	{
		if (SwigDerivedClassHasMethod("addSpotLight", swigMethodTypes76))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addSpotLightSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiSpotLightTraitsData.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addSpotLight(swigCPtr, OdGiSpotLightTraitsData.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addDistantLight(OdGiDistantLightTraitsData arg0)
	{
		if (SwigDerivedClassHasMethod("addDistantLight", swigMethodTypes77))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addDistantLightSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiDistantLightTraitsData.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addDistantLight(swigCPtr, OdGiDistantLightTraitsData.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addWebLight(OdGiWebLightTraitsData arg0)
	{
		if (SwigDerivedClassHasMethod("addWebLight", swigMethodTypes78))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addWebLightSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiWebLightTraitsData.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_addWebLight(swigCPtr, OdGiWebLightTraitsData.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushModelTransform(OdGeMatrix3d xfm)
	{
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes30))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushModelTransformSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushModelTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushModelTransform(OdGeVector3d normal)
	{
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes29))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushModelTransformSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushModelTransform__SWIG_1(swigCPtr, OdGeVector3d.getCPtr(normal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popModelTransform()
	{
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes31))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popModelTransformSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popModelTransform(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes79))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushClipBoundarySwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushClipBoundary__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void pushClipBoundary(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes80))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushClipBoundarySwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushClipBoundary__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void popClipBoundary()
	{
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes81))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popClipBoundarySwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popClipBoundary(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setEntityTraitsDataChanged()
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes82))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChanged__SWIG_0(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setEntityTraitsDataChanged(int bit, bool value)
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes83))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, bit, value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChanged__SWIG_1(swigCPtr, bit, value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setEntityTraitsDataChanged(int bit)
	{
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes84))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChangedSwigExplicitOdGsBaseVectorizer__SWIG_2(swigCPtr, bit);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setEntityTraitsDataChanged__SWIG_2(swigCPtr, bit);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeMatrix3d objectToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("objectToDeviceMatrix", swigMethodTypes25) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_objectToDeviceMatrixSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_objectToDeviceMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool pushPaletteOverride(OdGiPalette pOverride)
	{
		bool result = (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes49) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushPaletteOverrideSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiPalette.getCPtr(pOverride)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushPaletteOverride(swigCPtr, OdGiPalette.getCPtr(pOverride)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void popPaletteOverride()
	{
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes50))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popPaletteOverrideSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popPaletteOverride(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool hasPaletteOverrides()
	{
		bool result = (SwigDerivedClassHasMethod("hasPaletteOverrides", swigMethodTypes51) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_hasPaletteOverridesSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_hasPaletteOverrides(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool disableInfiniteGeomExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_disableInfiniteGeomExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool sectionableGeomExtentsOnly()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_sectionableGeomExtentsOnly(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSectionableGeomExtentsOnly(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSectionableGeomExtentsOnly(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public EMetafilePlayMode metafilePlayMode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_metafilePlayMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (EMetafilePlayMode)result;
	}

	public virtual void pushMetafileTransform(OdGeMatrix3d arg0, uint arg1)
	{
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes85))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushMetafileTransformSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(arg0), arg1);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushMetafileTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(arg0), arg1);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushMetafileTransform(OdGeMatrix3d arg0)
	{
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes86))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushMetafileTransformSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_pushMetafileTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popMetafileTransform(uint arg0)
	{
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes87))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popMetafileTransformSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, arg0);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popMetafileTransform__SWIG_0(swigCPtr, arg0);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popMetafileTransform()
	{
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes88))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popMetafileTransformSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_popMetafileTransform__SWIG_1(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d metafileTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("metafileTransform", swigMethodTypes59) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_metafileTransformSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_metafileTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool useSharedBlockReferences()
	{
		bool result = (SwigDerivedClassHasMethod("useSharedBlockReferences", swigMethodTypes89) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_useSharedBlockReferencesSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_useSharedBlockReferences(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool useMetafileAsGeometry()
	{
		bool result = (SwigDerivedClassHasMethod("useMetafileAsGeometry", swigMethodTypes90) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_useMetafileAsGeometrySwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_useMetafileAsGeometry(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput outputForMetafileGeometry()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(SwigDerivedClassHasMethod("outputForMetafileGeometry", swigMethodTypes91) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_outputForMetafileGeometrySwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_outputForMetafileGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTransformForMetafileGeometry(OdGeMatrix3d arg0)
	{
		if (SwigDerivedClassHasMethod("setTransformForMetafileGeometry", swigMethodTypes92))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setTransformForMetafileGeometrySwigExplicitOdGsBaseVectorizer(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setTransformForMetafileGeometry(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d getTransformForMetafileGeometry()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("getTransformForMetafileGeometry", swigMethodTypes93) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_getTransformForMetafileGeometrySwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_getTransformForMetafileGeometry(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void reportUpdateError(OdDbStub arg0, OdError error)
	{
		if (SwigDerivedClassHasMethod("reportUpdateError", swigMethodTypes94))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_reportUpdateErrorSwigExplicitOdGsBaseVectorizer(swigCPtr, OdDbStub.getCPtr(arg0), OdError.getCPtr(error));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_reportUpdateError(swigCPtr, OdDbStub.getCPtr(arg0), OdError.getCPtr(error));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsLayerNode gsLayerNode(OdDbStub layerId, OdGsBaseModel pModel)
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_gsLayerNode(swigCPtr, OdDbStub.getCPtr(layerId), OdGsBaseModel.getCPtr(pModel)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isFaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isFaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint fadingIntensity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_fadingIntensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isHighlighted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isHighlighted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSelecting()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isSelecting(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isHidden()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isHidden(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHidden(bool bHidden)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setHidden(swigCPtr, bHidden);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubentityTransform(bool bEnableTf, IntPtr refMarker, OdGsStateBranch pTfBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSubentityTransform__SWIG_0(swigCPtr, bEnableTf, refMarker, OdGsStateBranch.getCPtr(pTfBranch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubentityTransform(bool bEnableTf, IntPtr refMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSubentityTransform__SWIG_1(swigCPtr, bEnableTf, refMarker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubentityTransform(bool bEnableTf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSubentityTransform__SWIG_2(swigCPtr, bEnableTf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void applySubentityTransform(OdGeMatrix3d pXform)
	{
		if (SwigDerivedClassHasMethod("applySubentityTransform", swigMethodTypes95))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_applySubentityTransformSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGeMatrix3d.getCPtr(pXform));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_applySubentityTransform(swigCPtr, OdGeMatrix3d.getCPtr(pXform));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isDragging()
	{
		bool result = (SwigDerivedClassHasMethod("isDragging", swigMethodTypes96) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isDraggingSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isDragging(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput gsExtentsOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(SwigDerivedClassHasMethod("gsExtentsOutput", swigMethodTypes97) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_gsExtentsOutputSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_gsExtentsOutput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAnalyticLinetypingCircles(bool analytic)
	{
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingCircles", swigMethodTypes98))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAnalyticLinetypingCirclesSwigExplicitOdGsBaseVectorizer(swigCPtr, analytic);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAnalyticLinetypingCircles(swigCPtr, analytic);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticLinetypingCircles()
	{
		bool result = (SwigDerivedClassHasMethod("isAnalyticLinetypingCircles", swigMethodTypes99) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isAnalyticLinetypingCirclesSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isAnalyticLinetypingCircles(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAnalyticLinetypingComplexCurves(bool analytic)
	{
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingComplexCurves", swigMethodTypes100))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAnalyticLinetypingComplexCurvesSwigExplicitOdGsBaseVectorizer(swigCPtr, analytic);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAnalyticLinetypingComplexCurves(swigCPtr, analytic);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticLinetypingComplexCurves()
	{
		bool result = (SwigDerivedClassHasMethod("isAnalyticLinetypingComplexCurves", swigMethodTypes101) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isAnalyticLinetypingComplexCurvesSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isAnalyticLinetypingComplexCurves(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void checkSelection()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_checkSelection(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool handleSelectionByExtents(OdGeExtents3d extWc, bool bSectionable)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_handleSelectionByExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extWc), bSectionable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool handleSelectionByExtents(OdGeExtents3d extWc)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_handleSelectionByExtents__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(extWc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool displayViewportProperties(OdGsPropertiesDirectRenderOutput pdro, uint incFlags)
	{
		bool result = (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes102) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportPropertiesSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportProperties__SWIG_0(swigCPtr, OdGsPropertiesDirectRenderOutput.getCPtr(pdro), incFlags));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool displayViewportProperties(OdGsPropertiesDirectRenderOutput pdro)
	{
		bool result = (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes103) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportPropertiesSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, OdGsPropertiesDirectRenderOutput.getCPtr(pdro)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportProperties__SWIG_1(swigCPtr, OdGsPropertiesDirectRenderOutput.getCPtr(pdro)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool displayViewportProperties()
	{
		bool result = (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes104) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportPropertiesSwigExplicitOdGsBaseVectorizer__SWIG_2(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayViewportProperties__SWIG_2(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiConveyorOutput secondaryOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_secondaryOutput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUp(ref OdGsViewImpl view)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("setUp", swigMethodTypes24))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setUpSwigExplicitOdGsBaseVectorizer(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setUp(swigCPtr, ref jarg);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				view = null;
			}
			if (jarg != intPtr)
			{
				view = Helpers.GetRXObject<OdGsViewImpl>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void beginViewVectorization()
	{
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes55))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginViewVectorizationSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginViewVectorization(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void endViewVectorization()
	{
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes56))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endViewVectorizationSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endViewVectorization(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void onTraitsModified()
	{
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes57))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_onTraitsModifiedSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_onTraitsModified(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual double deviation(OdGiDeviationType deviationType, OdGePoint3d pointOnCurve)
	{
		double result = (SwigDerivedClassHasMethod("deviation", swigMethodTypes37) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_deviationSwigExplicitOdGsBaseVectorizer(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_deviation(swigCPtr, (int)deviationType, OdGePoint3d.getCPtr(pointOnCurve)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool regenAbort()
	{
		bool result = (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes105) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_regenAbortSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_regenAbort(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool doDraw(uint drawableFlags, OdGiDrawable pDrawable)
	{
		bool result = (SwigDerivedClassHasMethod("doDraw", swigMethodTypes106) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doDrawSwigExplicitOdGsBaseVectorizer(swigCPtr, drawableFlags, OdGiDrawable.getCPtr(pDrawable)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doDraw(swigCPtr, drawableFlags, OdGiDrawable.getCPtr(pDrawable)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void setSelectionMarker(IntPtr selectionMarker)
	{
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes107))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSelectionMarkerSwigExplicitOdGsBaseVectorizer(swigCPtr, selectionMarker);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setSelectionMarker(swigCPtr, selectionMarker);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiConveyorOutput output()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(SwigDerivedClassHasMethod("output", swigMethodTypes108) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_outputSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_output(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVisualStyle(OdGiVisualStyle visualStyle)
	{
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes109))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setVisualStyleSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setVisualStyle(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranch findSubnodeBranch(OdGsStateBranch_BranchType branchType)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_findSubnodeBranch__SWIG_0(swigCPtr, (int)branchType), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch findSubnodeBranch()
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_findSubnodeBranch__SWIG_1(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch currentStateBranch(OdGsStateBranch_BranchType branchType)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_currentStateBranch__SWIG_0(swigCPtr, (int)branchType), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch currentStateBranch()
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_currentStateBranch__SWIG_1(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void highlight(bool bHighlight, uint nSelStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_highlight__SWIG_0(swigCPtr, bHighlight, nSelStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void highlight(bool bHighlight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_highlight__SWIG_1(swigCPtr, bHighlight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint threadIndex()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_threadIndex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsLayerNode activeLayerNode(bool bSync)
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_activeLayerNode__SWIG_0(swigCPtr, bSync), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsLayerNode activeLayerNode()
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_activeLayerNode__SWIG_1(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsModel_RenderType activeRenderType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_activeRenderType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsModel_RenderType)result;
	}

	public OdGsOverlayId activeOverlay()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_activeOverlay(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsOverlayId)result;
	}

	public virtual bool isSpatialIndexDisabled()
	{
		bool result = (SwigDerivedClassHasMethod("isSpatialIndexDisabled", swigMethodTypes110) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isSpatialIndexDisabledSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isSpatialIndexDisabled(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void beginMetafileRecording(OdGsGeomPortion pGeomPortion)
	{
		if (SwigDerivedClassHasMethod("beginMetafileRecording", swigMethodTypes111))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginMetafileRecordingSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGsGeomPortion.getCPtr(pGeomPortion));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_beginMetafileRecording(swigCPtr, OdGsGeomPortion.getCPtr(pGeomPortion));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void endMetafileRecording()
	{
		if (SwigDerivedClassHasMethod("endMetafileRecording", swigMethodTypes112))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endMetafileRecordingSwigExplicitOdGsBaseVectorizer(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_endMetafileRecording(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doRayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		if (SwigDerivedClassHasMethod("doRayTrace", swigMethodTypes113))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doRayTraceSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList, nObjectListSize);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doRayTrace(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList, nObjectListSize);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void switchOverlay(OdGsOverlayId overlayId)
	{
		if (SwigDerivedClassHasMethod("switchOverlay", swigMethodTypes114))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_switchOverlaySwigExplicitOdGsBaseVectorizer(swigCPtr, (int)overlayId);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_switchOverlay(swigCPtr, (int)overlayId);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void displayNode(ref OdGsNode node, OdGsDisplayContext ctx)
	{
		IntPtr jarg = ((node == null) ? IntPtr.Zero : OdGsNode.getCPtr(node).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("displayNode", swigMethodTypes115))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayNodeSwigExplicitOdGsBaseVectorizer(swigCPtr, ref jarg, ctx);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displayNode(swigCPtr, ref jarg, ctx);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				node = null;
			}
			if (jarg != intPtr)
			{
				node = Helpers.GetRXObject<OdGsNode>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected virtual void displaySubnode(ref OdGsEntityNode node, OdGsDisplayContext ctx, bool bHighlighted)
	{
		IntPtr jarg = ((node == null) ? IntPtr.Zero : OdGsEntityNode.getCPtr(node).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("displaySubnode", swigMethodTypes116))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displaySubnodeSwigExplicitOdGsBaseVectorizer(swigCPtr, ref jarg, ctx, bHighlighted);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_displaySubnode(swigCPtr, ref jarg, ctx, bHighlighted);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				node = null;
			}
			if (jarg != intPtr)
			{
				node = Helpers.GetRXObject<OdGsEntityNode>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected override bool updateExtentsOnly()
	{
		bool result = (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes117) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_updateExtentsOnlySwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_updateExtentsOnly(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint setAttributes(OdGiDrawable pDrawable)
	{
		uint result = (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes118) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAttributesSwigExplicitOdGsBaseVectorizer(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setAttributes(swigCPtr, OdGiDrawable.getCPtr(pDrawable)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSharedRefCouldBeCanceled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_isSharedRefCouldBeCanceled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasAnyStateBranch(bool bMarkers)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_hasAnyStateBranch__SWIG_0(swigCPtr, bMarkers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasAnyStateBranch()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_hasAnyStateBranch__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint currentSelectionStyle()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_currentSelectionStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasSelectionStyle()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_hasSelectionStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int highlightingPass()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_highlightingPass(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRenderAbort(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_setRenderAbort(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool renderAbort()
	{
		bool result = (SwigDerivedClassHasMethod("renderAbort", swigMethodTypes119) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_renderAbortSwigExplicitOdGsBaseVectorizer(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_renderAbort(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual void doCollide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, OdGsCollisionDetectionContext pCtx)
	{
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes120))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize, OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollide__SWIG_0(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize, OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doCollide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes121))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollide__SWIG_1(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doCollide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList)
	{
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes122))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideSwigExplicitOdGsBaseVectorizer__SWIG_2(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollide__SWIG_2(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doCollide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes123))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideSwigExplicitOdGsBaseVectorizer__SWIG_3(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollide__SWIG_3(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doCollideAll(OdGsCollisionDetectionReactor pReactor, OdGsCollisionDetectionContext pCtx)
	{
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes124))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideAllSwigExplicitOdGsBaseVectorizer__SWIG_0(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor), OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideAll__SWIG_0(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor), OdGsCollisionDetectionContext.getCPtr(pCtx));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void doCollideAll(OdGsCollisionDetectionReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes125))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideAllSwigExplicitOdGsBaseVectorizer__SWIG_1(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_doCollideAll__SWIG_1(swigCPtr, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiViewport Viewport()
	{
		OdGiViewport rXObject = Helpers.GetRXObject<OdGiViewport>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_Viewport(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("getModelToEyeTransform", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetModelToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelTransform", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetEyeToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getWorldToEyeTransform", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetWorldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("getEyeToWorldTransform", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetEyeToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("isPerspective", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisPerspective;
		}
		if (SwigDerivedClassHasMethod("doPerspective", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddoPerspective;
		}
		if (SwigDerivedClassHasMethod("doInversePerspective", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddoInversePerspective;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getNumPixelsInUnitSquare", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getCameraLocation", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetCameraLocation;
		}
		if (SwigDerivedClassHasMethod("getCameraTarget", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetCameraTarget;
		}
		if (SwigDerivedClassHasMethod("getCameraUpVector", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetCameraUpVector;
		}
		if (SwigDerivedClassHasMethod("viewDir", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodviewDir;
		}
		if (SwigDerivedClassHasMethod("viewportId", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodviewportId;
		}
		if (SwigDerivedClassHasMethod("acadWindowId", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodacadWindowId;
		}
		if (SwigDerivedClassHasMethod("getViewportDcCorners", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetViewportDcCorners;
		}
		if (SwigDerivedClassHasMethod("getFrontAndBackClipValues", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodgetFrontAndBackClipValues;
		}
		if (SwigDerivedClassHasMethod("linetypeScaleMultiplier", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodlinetypeScaleMultiplier;
		}
		if (SwigDerivedClassHasMethod("linetypeGenerationCriteria", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodlinetypeGenerationCriteria;
		}
		if (SwigDerivedClassHasMethod("layerVisible", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodlayerVisible;
		}
		if (SwigDerivedClassHasMethod("contextualColors", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodcontextualColors;
		}
		if (SwigDerivedClassHasMethod("annotationScaleId", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodannotationScaleId;
		}
		if (SwigDerivedClassHasMethod("setUp", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetUp;
		}
		if (SwigDerivedClassHasMethod("objectToDeviceMatrix", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodobjectToDeviceMatrix;
		}
		if (SwigDerivedClassHasMethod("currentLineweightOverride", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodcurrentLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("getWorldToModelTransform", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodgetWorldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getModelToWorldTransform", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodgetModelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodpushModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodpushModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("xline", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodxline;
		}
		if (SwigDerivedClassHasMethod("ray", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodray;
		}
		if (SwigDerivedClassHasMethod("shell", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodshell;
		}
		if (SwigDerivedClassHasMethod("mesh", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodmesh;
		}
		if (SwigDerivedClassHasMethod("setExtents", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodsetExtents;
		}
		if (SwigDerivedClassHasMethod("deviation", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethoddeviation;
		}
		if (SwigDerivedClassHasMethod("regenType", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodregenType;
		}
		if (SwigDerivedClassHasMethod("sequenceNumber", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsequenceNumber;
		}
		if (SwigDerivedClassHasMethod("isValidId", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodisValidId;
		}
		if (SwigDerivedClassHasMethod("viewportObjectId", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodviewportObjectId;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("hasPaletteOverrides", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodhasPaletteOverrides;
		}
		if (SwigDerivedClassHasMethod("giViewport", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodgiViewport;
		}
		if (SwigDerivedClassHasMethod("gsView", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodgsView;
		}
		if (SwigDerivedClassHasMethod("annotationScale", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodannotationScale;
		}
		if (SwigDerivedClassHasMethod("beginViewVectorization", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodbeginViewVectorization;
		}
		if (SwigDerivedClassHasMethod("endViewVectorization", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodendViewVectorization;
		}
		if (SwigDerivedClassHasMethod("onTraitsModified", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodonTraitsModified;
		}
		if (SwigDerivedClassHasMethod("effectiveTraits", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodeffectiveTraits;
		}
		if (SwigDerivedClassHasMethod("metafileTransform", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodmetafileTransform;
		}
		if (SwigDerivedClassHasMethod("draw", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethoddraw;
		}
		if (SwigDerivedClassHasMethod("newGsMetafile", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodnewGsMetafile;
		}
		if (SwigDerivedClassHasMethod("beginMetafile", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodbeginMetafile;
		}
		if (SwigDerivedClassHasMethod("endMetafile", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodendMetafile;
		}
		if (SwigDerivedClassHasMethod("playMetafile", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodplayMetafile;
		}
		if (SwigDerivedClassHasMethod("saveMetafile", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodsaveMetafile;
		}
		if (SwigDerivedClassHasMethod("loadMetafile", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodloadMetafile;
		}
		if (SwigDerivedClassHasMethod("loadViewport", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodloadViewport;
		}
		if (SwigDerivedClassHasMethod("forceMetafilesDependence", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodforceMetafilesDependence;
		}
		if (SwigDerivedClassHasMethod("isViewRegenerated", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodisViewRegenerated;
		}
		if (SwigDerivedClassHasMethod("drawViewportFrame", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethoddrawViewportFrame;
		}
		if (SwigDerivedClassHasMethod("updateViewport", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodupdateViewport;
		}
		if (SwigDerivedClassHasMethod("processMaterialNode", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodprocessMaterialNode;
		}
		if (SwigDerivedClassHasMethod("saveMaterialCache", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodsaveMaterialCache;
		}
		if (SwigDerivedClassHasMethod("loadMaterialCache", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodloadMaterialCache;
		}
		if (SwigDerivedClassHasMethod("addPointLight", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodaddPointLight;
		}
		if (SwigDerivedClassHasMethod("addSpotLight", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodaddSpotLight;
		}
		if (SwigDerivedClassHasMethod("addDistantLight", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodaddDistantLight;
		}
		if (SwigDerivedClassHasMethod("addWebLight", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethodaddWebLight;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setEntityTraitsDataChanged", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethodpushMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushMetafileTransform", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethodpushMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodpopMetafileTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("popMetafileTransform", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodpopMetafileTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("useSharedBlockReferences", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethoduseSharedBlockReferences;
		}
		if (SwigDerivedClassHasMethod("useMetafileAsGeometry", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethoduseMetafileAsGeometry;
		}
		if (SwigDerivedClassHasMethod("outputForMetafileGeometry", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodoutputForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("setTransformForMetafileGeometry", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodsetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("getTransformForMetafileGeometry", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodgetTransformForMetafileGeometry;
		}
		if (SwigDerivedClassHasMethod("reportUpdateError", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodreportUpdateError;
		}
		if (SwigDerivedClassHasMethod("applySubentityTransform", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodapplySubentityTransform;
		}
		if (SwigDerivedClassHasMethod("isDragging", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodisDragging;
		}
		if (SwigDerivedClassHasMethod("gsExtentsOutput", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodgsExtentsOutput;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingCircles", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodsetAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingCircles", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodisAnalyticLinetypingCircles;
		}
		if (SwigDerivedClassHasMethod("setAnalyticLinetypingComplexCurves", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodsetAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("isAnalyticLinetypingComplexCurves", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodisAnalyticLinetypingComplexCurves;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethoddisplayViewportProperties__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethoddisplayViewportProperties__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("displayViewportProperties", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethoddisplayViewportProperties__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("regenAbort", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodregenAbort;
		}
		if (SwigDerivedClassHasMethod("doDraw", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethoddoDraw;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("isSpatialIndexDisabled", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodisSpatialIndexDisabled;
		}
		if (SwigDerivedClassHasMethod("beginMetafileRecording", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodbeginMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("endMetafileRecording", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodendMetafileRecording;
		}
		if (SwigDerivedClassHasMethod("doRayTrace", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethoddoRayTrace;
		}
		if (SwigDerivedClassHasMethod("switchOverlay", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodswitchOverlay;
		}
		if (SwigDerivedClassHasMethod("displayNode", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethoddisplayNode;
		}
		if (SwigDerivedClassHasMethod("displaySubnode", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethoddisplaySubnode;
		}
		if (SwigDerivedClassHasMethod("updateExtentsOnly", swigMethodTypes117))
		{
			swigDelegate117 = SwigDirectorMethodupdateExtentsOnly;
		}
		if (SwigDerivedClassHasMethod("setAttributes", swigMethodTypes118))
		{
			swigDelegate118 = SwigDirectorMethodsetAttributes;
		}
		if (SwigDerivedClassHasMethod("renderAbort", swigMethodTypes119))
		{
			swigDelegate119 = SwigDirectorMethodrenderAbort;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes120))
		{
			swigDelegate120 = SwigDirectorMethoddoCollide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes121))
		{
			swigDelegate121 = SwigDirectorMethoddoCollide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes122))
		{
			swigDelegate122 = SwigDirectorMethoddoCollide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("doCollide", swigMethodTypes123))
		{
			swigDelegate123 = SwigDirectorMethoddoCollide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes124))
		{
			swigDelegate124 = SwigDirectorMethoddoCollideAll__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("doCollideAll", swigMethodTypes125))
		{
			swigDelegate125 = SwigDirectorMethoddoCollideAll__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseVectorizer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116, swigDelegate117, swigDelegate118, swigDelegate119, swigDelegate120, swigDelegate121, swigDelegate122, swigDelegate123, swigDelegate124, swigDelegate125);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseVectorizer));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private IntPtr SwigDirectorMethodgetModelToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetEyeToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getEyeToWorldTransform()).Handle;
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

	private bool SwigDirectorMethodisPerspective()
	{
		return isPerspective();
	}

	private bool SwigDirectorMethoddoPerspective(IntPtr point)
	{
		return doPerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddoInversePerspective(IntPtr point)
	{
		return doInversePerspective(new OdGePoint3d(point, cMemoryOwn: false));
	}

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_0(IntPtr point, IntPtr pixelDensity, bool includePerspective)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false), includePerspective);
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

	private void SwigDirectorMethodgetNumPixelsInUnitSquare__SWIG_1(IntPtr point, IntPtr pixelDensity)
	{
		try
		{
			getNumPixelsInUnitSquare(new OdGePoint3d(point, cMemoryOwn: false), new OdGePoint2d(pixelDensity, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetCameraLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraLocation()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraTarget()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getCameraTarget()).Handle;
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

	private IntPtr SwigDirectorMethodgetCameraUpVector()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(getCameraUpVector()).Handle;
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

	private IntPtr SwigDirectorMethodviewDir()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(viewDir()).Handle;
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

	private uint SwigDirectorMethodviewportId()
	{
		return viewportId();
	}

	private short SwigDirectorMethodacadWindowId()
	{
		return acadWindowId();
	}

	private void SwigDirectorMethodgetViewportDcCorners(IntPtr lowerLeft, IntPtr upperRight)
	{
		try
		{
			getViewportDcCorners(new OdGePoint2d(lowerLeft, cMemoryOwn: false), new OdGePoint2d(upperRight, cMemoryOwn: false));
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

	private bool SwigDirectorMethodgetFrontAndBackClipValues(bool clipFront, bool clipBack, double front, double back)
	{
		return getFrontAndBackClipValues(out clipFront, out clipBack, out front, out back);
	}

	private double SwigDirectorMethodlinetypeScaleMultiplier()
	{
		return linetypeScaleMultiplier();
	}

	private double SwigDirectorMethodlinetypeGenerationCriteria()
	{
		return linetypeGenerationCriteria();
	}

	private bool SwigDirectorMethodlayerVisible(IntPtr layerId)
	{
		return layerVisible((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodcontextualColors()
	{
		return OdGiContextualColors.getCPtr(contextualColors()).Handle;
	}

	private IntPtr SwigDirectorMethodannotationScaleId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(annotationScaleId()).Handle;
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

	private void SwigDirectorMethodsetUp(IntPtr view)
	{
		OdSwigDirectorHelper.director_UnpackData(view, out var pOriginalObject, out var pFunction);
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			setUp(ref rXObject);
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
		finally
		{
			IntPtr handle = OdGsViewImpl.getCPtr(rXObject).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(view);
		}
	}

	private IntPtr SwigDirectorMethodobjectToDeviceMatrix()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(objectToDeviceMatrix()).Handle;
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

	private IntPtr SwigDirectorMethodcurrentLineweightOverride()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLineweightOverride.getCPtr(currentLineweightOverride()).Handle;
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

	private IntPtr SwigDirectorMethodgetWorldToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getWorldToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetModelToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getModelToWorldTransform()).Handle;
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

	private void SwigDirectorMethodpushModelTransform__SWIG_1(IntPtr normal)
	{
		try
		{
			pushModelTransform(new OdGeVector3d(normal, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushModelTransform__SWIG_0(IntPtr xfm)
	{
		try
		{
			pushModelTransform(new OdGeMatrix3d(xfm, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopModelTransform()
	{
		try
		{
			popModelTransform();
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

	private void SwigDirectorMethodxline(IntPtr firstPoint, IntPtr secondPoint)
	{
		try
		{
			xline(new OdGePoint3d(firstPoint, cMemoryOwn: false), new OdGePoint3d(secondPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodray(IntPtr basePoint, IntPtr throughPoint)
	{
		try
		{
			ray(new OdGePoint3d(basePoint, cMemoryOwn: false), new OdGePoint3d(throughPoint, cMemoryOwn: false));
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

	private void SwigDirectorMethodshell(IntPtr numVertices)
	{
		try
		{
			shell(Helpers.UnMarshalShellData(numVertices));
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

	private void SwigDirectorMethodmesh(IntPtr numRows)
	{
		try
		{
			mesh(Helpers.UnMarshalMeshData(numRows));
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

	private void SwigDirectorMethodsetExtents(IntPtr newExtents)
	{
		try
		{
			setExtents((newExtents == IntPtr.Zero) ? null : new OdGePoint3d(newExtents, cMemoryOwn: false));
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

	private double SwigDirectorMethoddeviation(int deviationType, IntPtr pointOnCurve)
	{
		return deviation((OdGiDeviationType)deviationType, new OdGePoint3d(pointOnCurve, cMemoryOwn: false));
	}

	private int SwigDirectorMethodregenType()
	{
		return (int)regenType();
	}

	private uint SwigDirectorMethodsequenceNumber()
	{
		return sequenceNumber();
	}

	private bool SwigDirectorMethodisValidId(uint viewportId)
	{
		return isValidId(viewportId);
	}

	private IntPtr SwigDirectorMethodviewportObjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(viewportObjectId()).Handle;
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

	private void SwigDirectorMethodsetFillPlane__SWIG_0(IntPtr pNormal)
	{
		try
		{
			setFillPlane((pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetFillPlane__SWIG_1()
	{
		try
		{
			setFillPlane();
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

	private void SwigDirectorMethodsetFillType(int fillType)
	{
		try
		{
			setFillType((OdGiFillType)fillType);
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

	private IntPtr SwigDirectorMethodvisualStyle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle()).Handle;
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

	private uint SwigDirectorMethodsetupForEntity()
	{
		return setupForEntity();
	}

	private bool SwigDirectorMethodpushLineweightOverride(IntPtr pOverride)
	{
		return pushLineweightOverride((pOverride == IntPtr.Zero) ? null : new OdGiLineweightOverride(pOverride, cMemoryOwn: false));
	}

	private void SwigDirectorMethodpopLineweightOverride()
	{
		try
		{
			popLineweightOverride();
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

	private bool SwigDirectorMethodpushPaletteOverride(IntPtr pOverride)
	{
		return pushPaletteOverride(Helpers.GetRXObject<OdGiPalette>(pOverride, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodpopPaletteOverride()
	{
		try
		{
			popPaletteOverride();
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

	private bool SwigDirectorMethodhasPaletteOverrides()
	{
		return hasPaletteOverrides();
	}

	private IntPtr SwigDirectorMethodgiViewport()
	{
		return OdGiViewport.getCPtr(giViewport()).Handle;
	}

	private IntPtr SwigDirectorMethodgsView()
	{
		return OdGsView.getCPtr(gsView()).Handle;
	}

	private double SwigDirectorMethodannotationScale()
	{
		return annotationScale();
	}

	private void SwigDirectorMethodbeginViewVectorization()
	{
		try
		{
			beginViewVectorization();
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

	private void SwigDirectorMethodendViewVectorization()
	{
		try
		{
			endViewVectorization();
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

	private void SwigDirectorMethodonTraitsModified()
	{
		try
		{
			onTraitsModified();
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

	private IntPtr SwigDirectorMethodeffectiveTraits()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiSubEntityTraitsData.getCPtr(effectiveTraits()).Handle;
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

	private IntPtr SwigDirectorMethodmetafileTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(metafileTransform()).Handle;
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

	private void SwigDirectorMethoddraw(IntPtr pDrawable)
	{
		try
		{
			draw(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodnewGsMetafile()
	{
		return OdRxObject.getCPtr(newGsMetafile()).Handle;
	}

	private void SwigDirectorMethodbeginMetafile(IntPtr pMetafile)
	{
		try
		{
			beginMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodendMetafile(IntPtr pMetafile)
	{
		try
		{
			endMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodplayMetafile(IntPtr pMetafile)
	{
		try
		{
			playMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodsaveMetafile(IntPtr pMetafile, IntPtr pFiler)
	{
		return saveMetafile(Helpers.GetRXObject<OdRxObject>(pMetafile, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodloadMetafile(IntPtr pFiler)
	{
		return OdRxObject.getCPtr(loadMetafile(Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodloadViewport()
	{
		try
		{
			loadViewport();
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

	private bool SwigDirectorMethodforceMetafilesDependence()
	{
		return forceMetafilesDependence();
	}

	private bool SwigDirectorMethodisViewRegenerated()
	{
		return isViewRegenerated();
	}

	private void SwigDirectorMethoddrawViewportFrame()
	{
		try
		{
			drawViewportFrame();
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

	private void SwigDirectorMethodupdateViewport()
	{
		try
		{
			updateViewport();
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

	private void SwigDirectorMethodprocessMaterialNode(IntPtr materialId, IntPtr pNode)
	{
		try
		{
			processMaterialNode((materialId == IntPtr.Zero) ? null : new OdDbStub(materialId, cMemoryOwn: false), Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodsaveMaterialCache(IntPtr pNode, IntPtr pFiler)
	{
		return saveMaterialCache(Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadMaterialCache(IntPtr pNode, IntPtr pFiler)
	{
		return loadMaterialCache(Helpers.GetRXObject<OdGsMaterialNode>(pNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodaddPointLight(IntPtr arg0)
	{
		try
		{
			addPointLight(new OdGiPointLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddSpotLight(IntPtr arg0)
	{
		try
		{
			addSpotLight(new OdGiSpotLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddDistantLight(IntPtr arg0)
	{
		try
		{
			addDistantLight(new OdGiDistantLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddWebLight(IntPtr arg0)
	{
		try
		{
			addWebLight(new OdGiWebLightTraitsData(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushClipBoundary__SWIG_0(IntPtr pBoundary)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushClipBoundary__SWIG_1(IntPtr pBoundary, IntPtr pClipInfo)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false), (pClipInfo == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(pClipInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopClipBoundary()
	{
		try
		{
			popClipBoundary();
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_0()
	{
		try
		{
			setEntityTraitsDataChanged();
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_1(int bit, bool value)
	{
		try
		{
			setEntityTraitsDataChanged(bit, value);
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

	private void SwigDirectorMethodsetEntityTraitsDataChanged__SWIG_2(int bit)
	{
		try
		{
			setEntityTraitsDataChanged(bit);
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

	private void SwigDirectorMethodpushMetafileTransform__SWIG_0(IntPtr arg0, uint arg1)
	{
		try
		{
			pushMetafileTransform(new OdGeMatrix3d(arg0, cMemoryOwn: false), arg1);
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

	private void SwigDirectorMethodpushMetafileTransform__SWIG_1(IntPtr arg0)
	{
		try
		{
			pushMetafileTransform(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopMetafileTransform__SWIG_0(uint arg0)
	{
		try
		{
			popMetafileTransform(arg0);
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

	private void SwigDirectorMethodpopMetafileTransform__SWIG_1()
	{
		try
		{
			popMetafileTransform();
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

	private bool SwigDirectorMethoduseSharedBlockReferences()
	{
		return useSharedBlockReferences();
	}

	private bool SwigDirectorMethoduseMetafileAsGeometry()
	{
		return useMetafileAsGeometry();
	}

	private IntPtr SwigDirectorMethodoutputForMetafileGeometry()
	{
		return outputForMetafileGeometry().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetTransformForMetafileGeometry(IntPtr arg0)
	{
		try
		{
			setTransformForMetafileGeometry(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgetTransformForMetafileGeometry()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(getTransformForMetafileGeometry()).Handle;
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

	private void SwigDirectorMethodreportUpdateError(IntPtr arg0, IntPtr error)
	{
		try
		{
			reportUpdateError((arg0 == IntPtr.Zero) ? null : new OdDbStub(arg0, cMemoryOwn: false), new OdError(error, cMemoryOwn: false));
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

	private void SwigDirectorMethodapplySubentityTransform(IntPtr pXform)
	{
		try
		{
			applySubentityTransform((pXform == IntPtr.Zero) ? null : new OdGeMatrix3d(pXform, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisDragging()
	{
		return isDragging();
	}

	private IntPtr SwigDirectorMethodgsExtentsOutput()
	{
		return gsExtentsOutput().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetAnalyticLinetypingCircles(bool analytic)
	{
		try
		{
			setAnalyticLinetypingCircles(analytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingCircles()
	{
		return isAnalyticLinetypingCircles();
	}

	private void SwigDirectorMethodsetAnalyticLinetypingComplexCurves(bool analytic)
	{
		try
		{
			setAnalyticLinetypingComplexCurves(analytic);
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

	private bool SwigDirectorMethodisAnalyticLinetypingComplexCurves()
	{
		return isAnalyticLinetypingComplexCurves();
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_0(IntPtr pdro, uint incFlags)
	{
		return displayViewportProperties((pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false), incFlags);
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_1(IntPtr pdro)
	{
		return displayViewportProperties((pdro == IntPtr.Zero) ? null : new OdGsPropertiesDirectRenderOutput(pdro, cMemoryOwn: false));
	}

	private bool SwigDirectorMethoddisplayViewportProperties__SWIG_2()
	{
		return displayViewportProperties();
	}

	private bool SwigDirectorMethodregenAbort()
	{
		return regenAbort();
	}

	private bool SwigDirectorMethoddoDraw(uint drawableFlags, IntPtr pDrawable)
	{
		return doDraw(drawableFlags, Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsetSelectionMarker(IntPtr selectionMarker)
	{
		try
		{
			setSelectionMarker(selectionMarker);
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

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetVisualStyle(IntPtr visualStyle)
	{
		try
		{
			setVisualStyle(Helpers.GetRXObject<OdGiVisualStyle>(visualStyle, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisSpatialIndexDisabled()
	{
		return isSpatialIndexDisabled();
	}

	private void SwigDirectorMethodbeginMetafileRecording(IntPtr pGeomPortion)
	{
		try
		{
			beginMetafileRecording((pGeomPortion == IntPtr.Zero) ? null : new OdGsGeomPortion(pGeomPortion, cMemoryOwn: false));
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

	private void SwigDirectorMethodendMetafileRecording()
	{
		try
		{
			endMetafileRecording();
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

	private void SwigDirectorMethoddoRayTrace(IntPtr rayOrigin, IntPtr rayDirection, IntPtr pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		try
		{
			doRayTrace(new OdGePoint3d(rayOrigin, cMemoryOwn: false), new OdGeVector3d(rayDirection, cMemoryOwn: false), (pReactor == IntPtr.Zero) ? null : new OdGsRayTraceReactor(pReactor, cMemoryOwn: false), bSortedSelection, pObjectList, nObjectListSize);
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

	private void SwigDirectorMethodswitchOverlay(int overlayId)
	{
		try
		{
			switchOverlay((OdGsOverlayId)overlayId);
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

	private void SwigDirectorMethoddisplayNode(IntPtr node, IntPtr ctx)
	{
		OdSwigDirectorHelper.director_UnpackData(node, out var pOriginalObject, out var pFunction);
		OdGsNode node2 = Helpers.GetRXObject<OdGsNode>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		OdGsDisplayContext ctx2 = new OdGsDisplayContext(ctx, cMemoryOwn: true);
		try
		{
			displayNode(ref node2, ctx2);
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
		finally
		{
			IntPtr handle = OdGsNode.getCPtr(node2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(node);
		}
	}

	private void SwigDirectorMethoddisplaySubnode(IntPtr node, IntPtr ctx, bool bHighlighted)
	{
		OdSwigDirectorHelper.director_UnpackData(node, out var pOriginalObject, out var pFunction);
		OdGsEntityNode node2 = Helpers.GetRXObject<OdGsEntityNode>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		OdGsDisplayContext ctx2 = new OdGsDisplayContext(ctx, cMemoryOwn: true);
		try
		{
			displaySubnode(ref node2, ctx2, bHighlighted);
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
		finally
		{
			IntPtr handle = OdGsEntityNode.getCPtr(node2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(node);
		}
	}

	private bool SwigDirectorMethodupdateExtentsOnly()
	{
		return updateExtentsOnly();
	}

	private uint SwigDirectorMethodsetAttributes(IntPtr pDrawable)
	{
		return setAttributes(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodrenderAbort()
	{
		return renderAbort();
	}

	private void SwigDirectorMethoddoCollide__SWIG_0(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, IntPtr pCtx)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize, (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollide__SWIG_1(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList, nCollisionWithListSize);
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

	private void SwigDirectorMethoddoCollide__SWIG_2(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor, OdGiPathNode[] pCollisionWithList)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), pCollisionWithList);
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

	private void SwigDirectorMethoddoCollide__SWIG_3(OdGiPathNode[] pInputList, uint nInputListSize, IntPtr pReactor)
	{
		try
		{
			doCollide(pInputList, nInputListSize, (pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollideAll__SWIG_0(IntPtr pReactor, IntPtr pCtx)
	{
		try
		{
			doCollideAll((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false), (pCtx == IntPtr.Zero) ? null : new OdGsCollisionDetectionContext(pCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethoddoCollideAll__SWIG_1(IntPtr pReactor)
	{
		try
		{
			doCollideAll((pReactor == IntPtr.Zero) ? null : new OdGsCollisionDetectionReactor(pReactor, cMemoryOwn: false));
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
