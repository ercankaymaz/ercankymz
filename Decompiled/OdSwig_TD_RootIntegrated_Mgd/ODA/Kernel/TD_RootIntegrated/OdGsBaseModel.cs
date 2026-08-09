using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseModel : OdGsModel
{
	public class SectioningSettings : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public bool m_bEnabled
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bEnabled_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bEnabled_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool m_bTopSet
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bTopSet_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bTopSet_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool m_bBottomSet
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bBottomSet_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bBottomSet_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public bool m_bVisualStyle
		{
			get
			{
				bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bVisualStyle_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_bVisualStyle_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGePoint3dArray m_points
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_points_get(swigCPtr);
				OdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3dArray(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_points_set(swigCPtr, OdGePoint3dArray.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGeVector3d m_upVector
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_upVector_get(swigCPtr);
				OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_upVector_set(swigCPtr, OdGeVector3d.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dTop
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_dTop_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_dTop_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dBottom
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_dBottom_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_dBottom_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdDbStub m_visualStyle
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_visualStyle_get(swigCPtr);
				OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_m_visualStyle_set(swigCPtr, OdDbStub.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SectioningSettings(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(SectioningSettings obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~SectioningSettings()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseModel_SectioningSettings(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public SectioningSettings()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModel_SectioningSettings(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isEnabled()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SectioningSettings_isEnabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public delegate IntPtr SwigDelegateOdGsBaseModel_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseModel_1();

	public delegate void SwigDelegateOdGsBaseModel_2(IntPtr pSource);

	public delegate void SwigDelegateOdGsBaseModel_3(IntPtr openDrawableFn);

	public delegate void SwigDelegateOdGsBaseModel_4(IntPtr pAdded, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_5(IntPtr pAdded, IntPtr parentID);

	public delegate void SwigDelegateOdGsBaseModel_6(IntPtr pModified, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_7(IntPtr pModified, IntPtr parentID);

	public delegate void SwigDelegateOdGsBaseModel_8(IntPtr pModified, IntPtr parentID);

	public delegate void SwigDelegateOdGsBaseModel_9(IntPtr pErased, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_10(IntPtr pErased, IntPtr parentID);

	public delegate void SwigDelegateOdGsBaseModel_11(IntPtr pUnerased, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_12(IntPtr pUnerased, IntPtr parentID);

	public delegate void SwigDelegateOdGsBaseModel_13(int hint);

	public delegate void SwigDelegateOdGsBaseModel_14(IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_15(IntPtr pDevice);

	public delegate void SwigDelegateOdGsBaseModel_16(IntPtr xForm);

	public delegate IntPtr SwigDelegateOdGsBaseModel_17();

	public delegate void SwigDelegateOdGsBaseModel_18(IntPtr path, bool bDoIt, uint nStyle, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_19(IntPtr path, bool bDoIt, uint nStyle);

	public delegate void SwigDelegateOdGsBaseModel_20(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_21(IntPtr path);

	public delegate void SwigDelegateOdGsBaseModel_22(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_23(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle);

	public delegate void SwigDelegateOdGsBaseModel_24(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_25(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsBaseModel_26(IntPtr path, bool bDoIt, bool bSelectHidden, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_27(IntPtr path, bool bDoIt, bool bSelectHidden);

	public delegate void SwigDelegateOdGsBaseModel_28(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_29(IntPtr path);

	public delegate void SwigDelegateOdGsBaseModel_30(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_31(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden);

	public delegate void SwigDelegateOdGsBaseModel_32(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_33(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsBaseModel_34(IntPtr path, bool bDoIt, IntPtr xForm, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_35(IntPtr path, bool bDoIt, IntPtr xForm);

	public delegate void SwigDelegateOdGsBaseModel_36(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_37(IntPtr path);

	public delegate void SwigDelegateOdGsBaseModel_38(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_39(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm);

	public delegate void SwigDelegateOdGsBaseModel_40(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_41(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate bool SwigDelegateOdGsBaseModel_42(IntPtr path, IntPtr xForm, IntPtr pView);

	public delegate bool SwigDelegateOdGsBaseModel_43(IntPtr path, IntPtr xForm);

	public delegate void SwigDelegateOdGsBaseModel_44(int renderType);

	public delegate int SwigDelegateOdGsBaseModel_45();

	public delegate void SwigDelegateOdGsBaseModel_46(int mode);

	public delegate void SwigDelegateOdGsBaseModel_47();

	public delegate int SwigDelegateOdGsBaseModel_48();

	public delegate void SwigDelegateOdGsBaseModel_49(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_50();

	public delegate void SwigDelegateOdGsBaseModel_51(IntPtr backgroundId);

	public delegate IntPtr SwigDelegateOdGsBaseModel_52();

	public delegate void SwigDelegateOdGsBaseModel_53(IntPtr visualStyleId);

	public delegate IntPtr SwigDelegateOdGsBaseModel_54();

	public delegate void SwigDelegateOdGsBaseModel_55(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsBaseModel_56(IntPtr visualStyle);

	public delegate void SwigDelegateOdGsBaseModel_57(IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseModel_58(IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseModel_59(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_60();

	public delegate bool SwigDelegateOdGsBaseModel_61(IntPtr points, IntPtr upVector);

	public delegate bool SwigDelegateOdGsBaseModel_62(IntPtr points, IntPtr upVector, double dTop, double dBottom);

	public delegate void SwigDelegateOdGsBaseModel_63(IntPtr visualStyleId);

	public delegate void SwigDelegateOdGsBaseModel_64(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_65();

	public delegate void SwigDelegateOdGsBaseModel_66(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_67();

	public delegate void SwigDelegateOdGsBaseModel_68(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_69();

	public delegate void SwigDelegateOdGsBaseModel_70(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_71();

	public delegate void SwigDelegateOdGsBaseModel_72(bool bEnable);

	public delegate bool SwigDelegateOdGsBaseModel_73();

	public delegate void SwigDelegateOdGsBaseModel_74(IntPtr pNode);

	public delegate void SwigDelegateOdGsBaseModel_75(IntPtr pDrawable, IntPtr pParent, bool bForceIfNoExtents);

	public delegate void SwigDelegateOdGsBaseModel_76(IntPtr pDrawable, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_77(IntPtr pNode, IntPtr pParent, bool bForceIfNoExtents);

	public delegate bool SwigDelegateOdGsBaseModel_78();

	public delegate void SwigDelegateOdGsBaseModel_79(IntPtr pView, IntPtr pFrom);

	public delegate void SwigDelegateOdGsBaseModel_80(IntPtr pView);

	public delegate uint SwigDelegateOdGsBaseModel_81(IntPtr pView);

	public delegate uint SwigDelegateOdGsBaseModel_82();

	public delegate void SwigDelegateOdGsBaseModel_83();

	public delegate IntPtr SwigDelegateOdGsBaseModel_84(IntPtr pDrawable);

	public delegate void SwigDelegateOdGsBaseModel_85(IntPtr pNode);

	public delegate void SwigDelegateOdGsBaseModel_86();

	public delegate void SwigDelegateOdGsBaseModel_87(IntPtr pAdded, IntPtr pParent, int additionMode);

	public delegate void SwigDelegateOdGsBaseModel_88(IntPtr pAdded, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_89(IntPtr pModified, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_90(IntPtr pErased, IntPtr pParent);

	public delegate void SwigDelegateOdGsBaseModel_91(IntPtr viewport);

	public delegate bool SwigDelegateOdGsBaseModel_92(uint viewportId);

	public delegate IntPtr SwigDelegateOdGsBaseModel_93(IntPtr layerId, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_94(IntPtr device);

	public delegate void SwigDelegateOdGsBaseModel_95(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_96(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle);

	public delegate void SwigDelegateOdGsBaseModel_97(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_98(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsBaseModel_99(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_100(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden);

	public delegate void SwigDelegateOdGsBaseModel_101(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_102(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsBaseModel_103(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView);

	public delegate void SwigDelegateOdGsBaseModel_104(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm);

	public delegate void SwigDelegateOdGsBaseModel_105(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsBaseModel_106(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate bool SwigDelegateOdGsBaseModel_107(IntPtr layoutId);

	public delegate void SwigDelegateOdGsBaseModel_108(IntPtr layoutId);

	public delegate bool SwigDelegateOdGsBaseModel_109(IntPtr pFiler, IntPtr pVectorizer);

	public delegate bool SwigDelegateOdGsBaseModel_110(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseModel_111(IntPtr pFiler, IntPtr pVectorizer);

	public delegate bool SwigDelegateOdGsBaseModel_112(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseModel_113(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseModel_114(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsBaseModel_115(int nProp);

	public delegate IntPtr SwigDelegateOdGsBaseModel_116(int ntp, IntPtr drawable, bool bSetGsNode);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseModel_0 swigDelegate0;

	private SwigDelegateOdGsBaseModel_1 swigDelegate1;

	private SwigDelegateOdGsBaseModel_2 swigDelegate2;

	private SwigDelegateOdGsBaseModel_3 swigDelegate3;

	private SwigDelegateOdGsBaseModel_4 swigDelegate4;

	private SwigDelegateOdGsBaseModel_5 swigDelegate5;

	private SwigDelegateOdGsBaseModel_6 swigDelegate6;

	private SwigDelegateOdGsBaseModel_7 swigDelegate7;

	private SwigDelegateOdGsBaseModel_8 swigDelegate8;

	private SwigDelegateOdGsBaseModel_9 swigDelegate9;

	private SwigDelegateOdGsBaseModel_10 swigDelegate10;

	private SwigDelegateOdGsBaseModel_11 swigDelegate11;

	private SwigDelegateOdGsBaseModel_12 swigDelegate12;

	private SwigDelegateOdGsBaseModel_13 swigDelegate13;

	private SwigDelegateOdGsBaseModel_14 swigDelegate14;

	private SwigDelegateOdGsBaseModel_15 swigDelegate15;

	private SwigDelegateOdGsBaseModel_16 swigDelegate16;

	private SwigDelegateOdGsBaseModel_17 swigDelegate17;

	private SwigDelegateOdGsBaseModel_18 swigDelegate18;

	private SwigDelegateOdGsBaseModel_19 swigDelegate19;

	private SwigDelegateOdGsBaseModel_20 swigDelegate20;

	private SwigDelegateOdGsBaseModel_21 swigDelegate21;

	private SwigDelegateOdGsBaseModel_22 swigDelegate22;

	private SwigDelegateOdGsBaseModel_23 swigDelegate23;

	private SwigDelegateOdGsBaseModel_24 swigDelegate24;

	private SwigDelegateOdGsBaseModel_25 swigDelegate25;

	private SwigDelegateOdGsBaseModel_26 swigDelegate26;

	private SwigDelegateOdGsBaseModel_27 swigDelegate27;

	private SwigDelegateOdGsBaseModel_28 swigDelegate28;

	private SwigDelegateOdGsBaseModel_29 swigDelegate29;

	private SwigDelegateOdGsBaseModel_30 swigDelegate30;

	private SwigDelegateOdGsBaseModel_31 swigDelegate31;

	private SwigDelegateOdGsBaseModel_32 swigDelegate32;

	private SwigDelegateOdGsBaseModel_33 swigDelegate33;

	private SwigDelegateOdGsBaseModel_34 swigDelegate34;

	private SwigDelegateOdGsBaseModel_35 swigDelegate35;

	private SwigDelegateOdGsBaseModel_36 swigDelegate36;

	private SwigDelegateOdGsBaseModel_37 swigDelegate37;

	private SwigDelegateOdGsBaseModel_38 swigDelegate38;

	private SwigDelegateOdGsBaseModel_39 swigDelegate39;

	private SwigDelegateOdGsBaseModel_40 swigDelegate40;

	private SwigDelegateOdGsBaseModel_41 swigDelegate41;

	private SwigDelegateOdGsBaseModel_42 swigDelegate42;

	private SwigDelegateOdGsBaseModel_43 swigDelegate43;

	private SwigDelegateOdGsBaseModel_44 swigDelegate44;

	private SwigDelegateOdGsBaseModel_45 swigDelegate45;

	private SwigDelegateOdGsBaseModel_46 swigDelegate46;

	private SwigDelegateOdGsBaseModel_47 swigDelegate47;

	private SwigDelegateOdGsBaseModel_48 swigDelegate48;

	private SwigDelegateOdGsBaseModel_49 swigDelegate49;

	private SwigDelegateOdGsBaseModel_50 swigDelegate50;

	private SwigDelegateOdGsBaseModel_51 swigDelegate51;

	private SwigDelegateOdGsBaseModel_52 swigDelegate52;

	private SwigDelegateOdGsBaseModel_53 swigDelegate53;

	private SwigDelegateOdGsBaseModel_54 swigDelegate54;

	private SwigDelegateOdGsBaseModel_55 swigDelegate55;

	private SwigDelegateOdGsBaseModel_56 swigDelegate56;

	private SwigDelegateOdGsBaseModel_57 swigDelegate57;

	private SwigDelegateOdGsBaseModel_58 swigDelegate58;

	private SwigDelegateOdGsBaseModel_59 swigDelegate59;

	private SwigDelegateOdGsBaseModel_60 swigDelegate60;

	private SwigDelegateOdGsBaseModel_61 swigDelegate61;

	private SwigDelegateOdGsBaseModel_62 swigDelegate62;

	private SwigDelegateOdGsBaseModel_63 swigDelegate63;

	private SwigDelegateOdGsBaseModel_64 swigDelegate64;

	private SwigDelegateOdGsBaseModel_65 swigDelegate65;

	private SwigDelegateOdGsBaseModel_66 swigDelegate66;

	private SwigDelegateOdGsBaseModel_67 swigDelegate67;

	private SwigDelegateOdGsBaseModel_68 swigDelegate68;

	private SwigDelegateOdGsBaseModel_69 swigDelegate69;

	private SwigDelegateOdGsBaseModel_70 swigDelegate70;

	private SwigDelegateOdGsBaseModel_71 swigDelegate71;

	private SwigDelegateOdGsBaseModel_72 swigDelegate72;

	private SwigDelegateOdGsBaseModel_73 swigDelegate73;

	private SwigDelegateOdGsBaseModel_74 swigDelegate74;

	private SwigDelegateOdGsBaseModel_75 swigDelegate75;

	private SwigDelegateOdGsBaseModel_76 swigDelegate76;

	private SwigDelegateOdGsBaseModel_77 swigDelegate77;

	private SwigDelegateOdGsBaseModel_78 swigDelegate78;

	private SwigDelegateOdGsBaseModel_79 swigDelegate79;

	private SwigDelegateOdGsBaseModel_80 swigDelegate80;

	private SwigDelegateOdGsBaseModel_81 swigDelegate81;

	private SwigDelegateOdGsBaseModel_82 swigDelegate82;

	private SwigDelegateOdGsBaseModel_83 swigDelegate83;

	private SwigDelegateOdGsBaseModel_84 swigDelegate84;

	private SwigDelegateOdGsBaseModel_85 swigDelegate85;

	private SwigDelegateOdGsBaseModel_86 swigDelegate86;

	private SwigDelegateOdGsBaseModel_87 swigDelegate87;

	private SwigDelegateOdGsBaseModel_88 swigDelegate88;

	private SwigDelegateOdGsBaseModel_89 swigDelegate89;

	private SwigDelegateOdGsBaseModel_90 swigDelegate90;

	private SwigDelegateOdGsBaseModel_91 swigDelegate91;

	private SwigDelegateOdGsBaseModel_92 swigDelegate92;

	private SwigDelegateOdGsBaseModel_93 swigDelegate93;

	private SwigDelegateOdGsBaseModel_94 swigDelegate94;

	private SwigDelegateOdGsBaseModel_95 swigDelegate95;

	private SwigDelegateOdGsBaseModel_96 swigDelegate96;

	private SwigDelegateOdGsBaseModel_97 swigDelegate97;

	private SwigDelegateOdGsBaseModel_98 swigDelegate98;

	private SwigDelegateOdGsBaseModel_99 swigDelegate99;

	private SwigDelegateOdGsBaseModel_100 swigDelegate100;

	private SwigDelegateOdGsBaseModel_101 swigDelegate101;

	private SwigDelegateOdGsBaseModel_102 swigDelegate102;

	private SwigDelegateOdGsBaseModel_103 swigDelegate103;

	private SwigDelegateOdGsBaseModel_104 swigDelegate104;

	private SwigDelegateOdGsBaseModel_105 swigDelegate105;

	private SwigDelegateOdGsBaseModel_106 swigDelegate106;

	private SwigDelegateOdGsBaseModel_107 swigDelegate107;

	private SwigDelegateOdGsBaseModel_108 swigDelegate108;

	private SwigDelegateOdGsBaseModel_109 swigDelegate109;

	private SwigDelegateOdGsBaseModel_110 swigDelegate110;

	private SwigDelegateOdGsBaseModel_111 swigDelegate111;

	private SwigDelegateOdGsBaseModel_112 swigDelegate112;

	private SwigDelegateOdGsBaseModel_113 swigDelegate113;

	private SwigDelegateOdGsBaseModel_114 swigDelegate114;

	private SwigDelegateOdGsBaseModel_115 swigDelegate115;

	private SwigDelegateOdGsBaseModel_116 swigDelegate116;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGsModel_InvalidationHint) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGsDevice) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(uint),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes19 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(uint)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes22 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes23 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint)
	};

	private static Type[] swigMethodTypes24 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes25 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes26 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(bool),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes27 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes30 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes31 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes32 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes33 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes34 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes38 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes39 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes40 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes41 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes42 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes43 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdGsModel_RenderType) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdGsView_RenderMode) };

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGiVisualStyle).MakeByRefType() };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGsModelReactor) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdGsModelReactor) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes62 = new Type[4]
	{
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes73 = new Type[0];

	private static Type[] swigMethodTypes74 = new Type[1] { typeof(OdGsNode) };

	private static Type[] swigMethodTypes75 = new Type[3]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable),
		typeof(bool)
	};

	private static Type[] swigMethodTypes76 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes77 = new Type[3]
	{
		typeof(OdGsEntityNode),
		typeof(OdGsContainerNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes78 = new Type[0];

	private static Type[] swigMethodTypes79 = new Type[2]
	{
		typeof(OdGsViewImpl),
		typeof(OdGsViewImpl)
	};

	private static Type[] swigMethodTypes80 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes81 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes82 = new Type[0];

	private static Type[] swigMethodTypes83 = new Type[0];

	private static Type[] swigMethodTypes84 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes85 = new Type[1] { typeof(OdGsNode) };

	private static Type[] swigMethodTypes86 = new Type[0];

	private static Type[] swigMethodTypes87 = new Type[3]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable),
		typeof(OdGsBaseModel_AdditionMode)
	};

	private static Type[] swigMethodTypes88 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes89 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes90 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes91 = new Type[1] { typeof(OdGsViewImpl) };

	private static Type[] swigMethodTypes92 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes93 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGsBaseVectorizer)
	};

	private static Type[] swigMethodTypes94 = new Type[1] { typeof(OdGsBaseVectorizeDevice).MakeByRefType() };

	private static Type[] swigMethodTypes95 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes96 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint)
	};

	private static Type[] swigMethodTypes97 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes98 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes99 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes100 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes101 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes102 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes103 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes104 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes105 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes106 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes107 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes108 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes109 = new Type[2]
	{
		typeof(OdGsFilerGSS),
		typeof(OdGsBaseVectorizer)
	};

	private static Type[] swigMethodTypes110 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes111 = new Type[2]
	{
		typeof(OdGsFilerGSS),
		typeof(OdGsBaseVectorizer)
	};

	private static Type[] swigMethodTypes112 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes113 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes114 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes115 = new Type[1] { typeof(OdGsBaseModelReactor_ModelProperty) };

	private static Type[] swigMethodTypes116 = new Type[3]
	{
		typeof(ENodeType),
		typeof(OdGiDrawable),
		typeof(bool)
	};

	public int m_nMfCached
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_m_nMfCached_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_m_nMfCached_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int m_nMfReused
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_m_nMfReused_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_m_nMfReused_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseModel(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseModel obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.deletePD_OdGsBaseModel(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public ViewRefArray GetMViews()
	{
		ViewRefArray result = new ViewRefArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_GetMViews(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetMViews(ViewRefArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SetMViews(swigCPtr, ViewRefArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ModuleRefArray GetMModules()
	{
		ModuleRefArray result = new ModuleRefArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_GetMModules(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetMModules(ModuleRefArray arr)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_SetMModules(swigCPtr, ModuleRefArray.getCPtr(arr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void addNode(OdGsNode pNode)
	{
		if (SwigDerivedClassHasMethod("addNode", swigMethodTypes74))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_addNodeSwigExplicitOdGsBaseModel(swigCPtr, OdGsNode.getCPtr(pNode));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_addNode(swigCPtr, OdGsNode.getCPtr(pNode));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateEntRect1(OdGiDrawable pDrawable, OdGiDrawable pParent, bool bForceIfNoExtents)
	{
		if (SwigDerivedClassHasMethod("invalidateEntRect1", swigMethodTypes75))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRect1SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent), bForceIfNoExtents);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRect1(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent), bForceIfNoExtents);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateEntRect(OdGiDrawable pDrawable, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("invalidateEntRect", swigMethodTypes76))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRectSwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRect(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateEntRect2(OdGsEntityNode pNode, OdGsContainerNode pParent, bool bForceIfNoExtents)
	{
		if (SwigDerivedClassHasMethod("invalidateEntRect2", swigMethodTypes77))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRect2SwigExplicitOdGsBaseModel(swigCPtr, OdGsEntityNode.getCPtr(pNode), OdGsContainerNode.getCPtr(pParent), bForceIfNoExtents);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateEntRect2(swigCPtr, OdGsEntityNode.getCPtr(pNode), OdGsContainerNode.getCPtr(pParent), bForceIfNoExtents);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool checkFaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_checkFaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCheckFaded(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setCheckFaded(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVectorizing()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setVectorizing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetVectorizing()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_resetVectorizing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool disableNotifications()
	{
		bool result = (SwigDerivedClassHasMethod("disableNotifications", swigMethodTypes78) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_disableNotificationsSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_disableNotifications(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDisableNotifications(bool bOn)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setDisableNotifications(swigCPtr, bOn);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public ViewPropsArray getViewProps()
	{
		ViewPropsArray result = new ViewPropsArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getViewProps(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsViewImpl refView()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_refView(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsBaseVectorizeDevice refDevice()
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_refDevice(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint refModulesCount()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_refModulesCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void attachLocalViewportId(OdGsViewImpl pView, OdGsViewImpl pFrom)
	{
		if (SwigDerivedClassHasMethod("attachLocalViewportId", swigMethodTypes79))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_attachLocalViewportIdSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGsViewImpl.getCPtr(pView), OdGsViewImpl.getCPtr(pFrom));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_attachLocalViewportId__SWIG_0(swigCPtr, OdGsViewImpl.getCPtr(pView), OdGsViewImpl.getCPtr(pFrom));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void attachLocalViewportId(OdGsViewImpl pView)
	{
		if (SwigDerivedClassHasMethod("attachLocalViewportId", swigMethodTypes80))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_attachLocalViewportIdSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGsViewImpl.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_attachLocalViewportId__SWIG_1(swigCPtr, OdGsViewImpl.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getLocalViewportId(OdGsViewImpl pView)
	{
		uint result = (SwigDerivedClassHasMethod("getLocalViewportId", swigMethodTypes81) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getLocalViewportIdSwigExplicitOdGsBaseModel(swigCPtr, OdGsViewImpl.getCPtr(pView)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getLocalViewportId(swigCPtr, OdGsViewImpl.getCPtr(pView)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getMaxLocalViewportId()
	{
		uint result = (SwigDerivedClassHasMethod("getMaxLocalViewportId", swigMethodTypes82) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getMaxLocalViewportIdSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getMaxLocalViewportId(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool invalidVp(uint viewportId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidVp(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void invalidateRegenDrawBlocks(ref OdGsViewImpl view, OdDbStub layoutId)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateRegenDrawBlocks(swigCPtr, ref jarg, OdDbStub.getCPtr(layoutId));
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

	public void invalidateSectionableBlocks()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateSectionableBlocks(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected virtual void clearChangedLayersList()
	{
		if (SwigDerivedClassHasMethod("clearChangedLayersList", swigMethodTypes83))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_clearChangedLayersListSwigExplicitOdGsBaseModel(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_clearChangedLayersList(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected OdGsBaseModel()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModel(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseModel) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdGsNode gsNode(OdGiDrawable pDrawable)
	{
		OdGsNode rXObject = Helpers.GetRXObject<OdGsNode>(SwigDerivedClassHasMethod("gsNode", swigMethodTypes84) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_gsNodeSwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pDrawable)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_gsNode(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void detach(OdGsNode pNode)
	{
		if (SwigDerivedClassHasMethod("detach", swigMethodTypes85))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_detachSwigExplicitOdGsBaseModel(swigCPtr, OdGsNode.getCPtr(pNode));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_detach(swigCPtr, OdGsNode.getCPtr(pNode));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void detachAll()
	{
		if (SwigDerivedClassHasMethod("detachAll", swigMethodTypes86))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_detachAllSwigExplicitOdGsBaseModel(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_detachAll(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void detachAllFromDb(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_detachAllFromDb(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDrawable open(OdDbStub objectId)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_open(swigCPtr, OdDbStub.getCPtr(objectId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setDrawableGsNode(OdGiDrawable pDrawable, OdGsCache pNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setDrawableGsNode(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGsCache.getCPtr(pNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCache drawableGsNode(OdGiDrawable pDrawable)
	{
		OdGsCache rXObject = Helpers.GetRXObject<OdGsCache>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_drawableGsNode(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setOpenDrawableFn(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate openDrawableFn)
	{
		TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative odGiOpenDrawableFnDelegateNative = null;
		if (openDrawableFn != null)
		{
			odGiOpenDrawableFnDelegateNative = (IntPtr id) => OdMarshalHelper.ObjectToPtr<OdGiDrawable>(openDrawableFn(OdMarshalHelper.PtrToObject<OdDbStub>(id)));
		}
		IntPtr jarg = ((openDrawableFn == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odGiOpenDrawableFnDelegateNative));
		DelegateHolder.Add(odGiOpenDrawableFnDelegateNative);
		if (SwigDerivedClassHasMethod("setOpenDrawableFn", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setOpenDrawableFnSwigExplicitOdGsBaseModel(swigCPtr, jarg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setOpenDrawableFn(swigCPtr, jarg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate openDrawableFn()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_openDrawableFn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbStub id) => OdMarshalHelper.PtrToObject<OdGiDrawable>((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)) as TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbStub>(id)));
		}
		return result;
	}

	public override void onAdded1(OdGiDrawable pAdded, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onAdded1", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAdded1SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAdded1(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onAdded2(OdGiDrawable pAdded, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onAdded2", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAdded2SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAdded2(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onAddedImpl(OdGiDrawable pAdded, OdGiDrawable pParent, OdGsBaseModel_AdditionMode additionMode)
	{
		if (SwigDerivedClassHasMethod("onAddedImpl", swigMethodTypes87))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAddedImplSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent), (int)additionMode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAddedImpl__SWIG_0(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent), (int)additionMode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onAddedImpl(OdGiDrawable pAdded, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onAddedImpl", swigMethodTypes88))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAddedImplSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onAddedImpl__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onModified1(OdGiDrawable pModified, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onModified1", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModified1SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModified1(swigCPtr, OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onModified2(OdGiDrawable pModified, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onModified2", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModified2SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModified2(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onModifiedImpl(OdGiDrawable pModified, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onModifiedImpl", swigMethodTypes89))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModifiedImplSwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModifiedImpl(swigCPtr, OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onModifiedGraphics(OdGiDrawable pModified, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onModifiedGraphics", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModifiedGraphicsSwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onModifiedGraphics(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onErased1(OdGiDrawable pErased, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onErased1", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErased1SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErased1(swigCPtr, OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onErased2(OdGiDrawable pErased, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onErased2", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErased2SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pErased), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErased2(swigCPtr, OdGiDrawable.getCPtr(pErased), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onErasedImpl(OdGiDrawable pErased, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onErasedImpl", swigMethodTypes90))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErasedImplSwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onErasedImpl(swigCPtr, OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onUnerased1(OdGiDrawable pUnerased, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onUnerased1", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onUnerased1SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onUnerased1(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void onUnerased2(OdGiDrawable pUnerased, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onUnerased2", swigMethodTypes12))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onUnerased2SwigExplicitOdGsBaseModel(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onUnerased2(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void invalidate(OdGsModel_InvalidationHint hint)
	{
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes13))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, (int)hint);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidate__SWIG_0(swigCPtr, (int)hint);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void invalidate2(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("invalidate2", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidate2SwigExplicitOdGsBaseModel(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidate2(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void invalidateVisible(OdGsDevice pDevice)
	{
		if (SwigDerivedClassHasMethod("invalidateVisible", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateVisibleSwigExplicitOdGsBaseModel(swigCPtr, OdGsDevice.getCPtr(pDevice));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidateVisible(swigCPtr, OdGsDevice.getCPtr(pDevice));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidate(ref OdGsViewImpl view, uint mask)
	{
		IntPtr jarg = ((view == null) ? IntPtr.Zero : OdGsViewImpl.getCPtr(view).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_invalidate__SWIG_1(swigCPtr, ref jarg, mask);
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

	public uint viewChanges(uint viewportId)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewChanges(swigCPtr, viewportId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint numViewProps()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_numViewProps(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ViewProps viewProps(uint viewportId)
	{
		ViewProps result = new ViewProps(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewProps(swigCPtr, viewportId), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void updateViewProps(OdGsViewImpl viewport)
	{
		if (SwigDerivedClassHasMethod("updateViewProps", swigMethodTypes91))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_updateViewPropsSwigExplicitOdGsBaseModel(swigCPtr, OdGsViewImpl.getCPtr(viewport));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_updateViewProps(swigCPtr, OdGsViewImpl.getCPtr(viewport));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isViewPropsValid(uint viewportId)
	{
		bool result = (SwigDerivedClassHasMethod("isViewPropsValid", swigMethodTypes92) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isViewPropsValidSwigExplicitOdGsBaseModel(swigCPtr, viewportId) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isViewPropsValid(swigCPtr, viewportId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsViewImpl viewById(uint viewportId)
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewById(swigCPtr, viewportId), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsLayerNode gsLayerNode(OdDbStub layerId, OdGsBaseVectorizer pView)
	{
		OdGsLayerNode rXObject = Helpers.GetRXObject<OdGsLayerNode>(SwigDerivedClassHasMethod("gsLayerNode", swigMethodTypes93) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_gsLayerNodeSwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(layerId), OdGsBaseVectorizer.getCPtr(pView)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_gsLayerNode(swigCPtr, OdDbStub.getCPtr(layerId), OdGsBaseVectorizer.getCPtr(pView)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void propagateLayerChanges(ref OdGsBaseVectorizeDevice device)
	{
		IntPtr jarg = ((device == null) ? IntPtr.Zero : OdGsBaseVectorizeDevice.getCPtr(device).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("propagateLayerChanges", swigMethodTypes94))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_propagateLayerChangesSwigExplicitOdGsBaseModel(swigCPtr, ref jarg);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_propagateLayerChanges(swigCPtr, ref jarg);
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
				device = null;
			}
			if (jarg != intPtr)
			{
				device = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void setTransform(OdGeMatrix3d xForm)
	{
		if (SwigDerivedClassHasMethod("setTransform", swigMethodTypes16))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setTransformSwigExplicitOdGsBaseModel(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setTransform(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeMatrix3d transform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("transform", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_transformSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_transform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isIdentityTransform()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isIdentityTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeExtents3d transformExtents(OdGeExtents3d pExts)
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_transformExtents(swigCPtr, OdGeExtents3d.getCPtr(pExts)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGsView_RenderMode renderModeOverride()
	{
		int result = (SwigDerivedClassHasMethod("renderModeOverride", swigMethodTypes48) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_renderModeOverrideSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_renderModeOverride(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_RenderMode)result;
	}

	public override void setRenderModeOverride(OdGsView_RenderMode mode)
	{
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes46))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderModeOverrideSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, (int)mode);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderModeOverride__SWIG_0(swigCPtr, (int)mode);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setRenderModeOverride()
	{
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes47))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderModeOverrideSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderModeOverride__SWIG_1(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight1(OdGiPathNode path, bool bDoIt, uint nStyle, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("highlight1", swigMethodTypes18))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight1SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path, bool bDoIt, uint nStyle)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes19))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes20))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("highlight2", swigMethodTypes22))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight2SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes23))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes24))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes25))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightSwigExplicitOdGsBaseModel__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlight__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlightImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes95))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImplSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImpl__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlightImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes96))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImplSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImpl__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlightImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes97))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImplSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImpl__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlightImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes98))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImplSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_highlightImpl__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide1(OdGiPathNode path, bool bDoIt, bool bSelectHidden, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("hide1", swigMethodTypes26))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide1SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path, bool bDoIt, bool bSelectHidden)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes27))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes28))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes29))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("hide2", swigMethodTypes30))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide2SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes31))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes32))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes33))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideSwigExplicitOdGsBaseModel__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hide__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hideImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes99))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImplSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImpl__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hideImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes100))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImplSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImpl__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hideImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes101))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImplSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImpl__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hideImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes102))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImplSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hideImpl__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform1(OdGiPathNode path, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("externalTransform1", swigMethodTypes34))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform1SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path, bool bDoIt, OdGsMatrixParam xForm)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes35))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes36))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes37))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("externalTransform2", swigMethodTypes38))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform2SwigExplicitOdGsBaseModel(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes39))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes40))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes41))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformSwigExplicitOdGsBaseModel__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransform__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransformImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes103))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImplSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImpl__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransformImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm)
	{
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes104))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImplSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImpl__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransformImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes105))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImplSwigExplicitOdGsBaseModel__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImpl__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransformImpl(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes106))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImplSwigExplicitOdGsBaseModel__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_externalTransformImpl__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool getExternalTransform(OdGiPathNode path, OdGsMatrixParam xForm, OdGsView pView)
	{
		bool result = (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes42) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getExternalTransformSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), xForm, OdGsView.getCPtr(pView)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getExternalTransform__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), xForm, OdGsView.getCPtr(pView)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool getExternalTransform(OdGiPathNode path, OdGsMatrixParam xForm)
	{
		bool result = (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getExternalTransformSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), xForm) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getExternalTransform__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), xForm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsMaterialCache materialCache()
	{
		OdGsMaterialCache rXObject = Helpers.GetRXObject<OdGsMaterialCache>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_materialCache(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setRenderType(OdGsModel_RenderType renderType)
	{
		if (SwigDerivedClassHasMethod("setRenderType", swigMethodTypes44))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderTypeSwigExplicitOdGsBaseModel(swigCPtr, (int)renderType);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setRenderType(swigCPtr, (int)renderType);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsModel_RenderType renderType()
	{
		int result = (SwigDerivedClassHasMethod("renderType", swigMethodTypes45) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_renderTypeSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_renderType(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsModel_RenderType)result;
	}

	public override void setBackground(OdDbStub backgroundId)
	{
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes51))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setBackgroundSwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(backgroundId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setBackground(swigCPtr, OdDbStub.getCPtr(backgroundId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub background()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("background", swigMethodTypes52) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_backgroundSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_background(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setVisualStyle1(OdDbStub visualStyleId)
	{
		if (SwigDerivedClassHasMethod("setVisualStyle1", swigMethodTypes53))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setVisualStyle1SwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setVisualStyle1(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub visualStyle1()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("visualStyle1", swigMethodTypes54) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_visualStyle1SwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_visualStyle1(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setVisualStyle2(OdGiVisualStyle visualStyle)
	{
		if (SwigDerivedClassHasMethod("setVisualStyle2", swigMethodTypes55))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setVisualStyle2SwigExplicitOdGsBaseModel(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setVisualStyle2(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool VisualStyle2(ref OdGiVisualStyle visualStyle)
	{
		IntPtr jarg = ((visualStyle == null) ? IntPtr.Zero : OdGiVisualStyle.getCPtr(visualStyle).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = (SwigDerivedClassHasMethod("VisualStyle2", swigMethodTypes56) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_VisualStyle2SwigExplicitOdGsBaseModel(swigCPtr, ref jarg) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_VisualStyle2(swigCPtr, ref jarg));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				visualStyle = null;
			}
			if (jarg != intPtr)
			{
				visualStyle = Helpers.GetRXObject<OdGiVisualStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiDrawable visualStyleDrawable()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_visualStyleDrawable(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool makeStock(OdDbStub layoutId)
	{
		bool result = (SwigDerivedClassHasMethod("makeStock", swigMethodTypes107) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_makeStockSwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(layoutId)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_makeStock(swigCPtr, OdDbStub.getCPtr(layoutId)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void releaseStock(OdDbStub layoutId)
	{
		if (SwigDerivedClassHasMethod("releaseStock", swigMethodTypes108))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_releaseStockSwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(layoutId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_releaseStock(swigCPtr, OdDbStub.getCPtr(layoutId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasChangedLayers()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_hasChangedLayers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void addModelReactor(OdGsModelReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("addModelReactor", swigMethodTypes57))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_addModelReactorSwigExplicitOdGsBaseModel(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_addModelReactor(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void removeModelReactor(OdGsModelReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("removeModelReactor", swigMethodTypes58))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_removeModelReactorSwigExplicitOdGsBaseModel(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_removeModelReactor(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setEnableSectioning(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setEnableSectioning", swigMethodTypes59))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableSectioningSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableSectioning(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSectioningEnabled()
	{
		bool result = (SwigDerivedClassHasMethod("isSectioningEnabled", swigMethodTypes60) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isSectioningEnabledSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isSectioningEnabled(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setSectioning1(OdGePoint3dArray points, OdGeVector3d upVector)
	{
		bool result = (SwigDerivedClassHasMethod("setSectioning1", swigMethodTypes61) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioning1SwigExplicitOdGsBaseModel(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioning1(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setSectioning2(OdGePoint3dArray points, OdGeVector3d upVector, double dTop, double dBottom)
	{
		bool result = (SwigDerivedClassHasMethod("setSectioning2", swigMethodTypes62) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioning2SwigExplicitOdGsBaseModel(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector), dTop, dBottom) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioning2(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector), dTop, dBottom));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSectioningVisualStyle(OdDbStub visualStyleId)
	{
		if (SwigDerivedClassHasMethod("setSectioningVisualStyle", swigMethodTypes63))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioningVisualStyleSwigExplicitOdGsBaseModel(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSectioningVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public SectioningSettings getSectioning()
	{
		SectioningSettings result = new SectioningSettings(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getSectioning(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setViewClippingOverride(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setViewClippingOverride", swigMethodTypes49))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setViewClippingOverrideSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setViewClippingOverride(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool viewClippingOverride()
	{
		bool result = (SwigDerivedClassHasMethod("viewClippingOverride", swigMethodTypes50) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewClippingOverrideSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewClippingOverride(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setEnableLinetypes(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setEnableLinetypes", swigMethodTypes64))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableLinetypesSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableLinetypes(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isLinetypesEnabled()
	{
		bool result = (SwigDerivedClassHasMethod("isLinetypesEnabled", swigMethodTypes65) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isLinetypesEnabledSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isLinetypesEnabled(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSelectable(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setSelectable", swigMethodTypes66))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSelectableSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setSelectable(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSelectable()
	{
		bool result = (SwigDerivedClassHasMethod("isSelectable", swigMethodTypes67) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isSelectableSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isSelectable(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setEnableViewExtentsCalculation(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setEnableViewExtentsCalculation", swigMethodTypes68))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableViewExtentsCalculationSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableViewExtentsCalculation(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isViewExtentsCalculationEnabled()
	{
		bool result = (SwigDerivedClassHasMethod("isViewExtentsCalculationEnabled", swigMethodTypes69) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isViewExtentsCalculationEnabledSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isViewExtentsCalculationEnabled(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setEnableLightsInBlocks(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setEnableLightsInBlocks", swigMethodTypes70))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableLightsInBlocksSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setEnableLightsInBlocks(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isLightsInBlocksEnabled()
	{
		bool result = (SwigDerivedClassHasMethod("isLightsInBlocksEnabled", swigMethodTypes71) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isLightsInBlocksEnabledSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_isLightsInBlocksEnabled(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setViewSectioningOverride(bool bEnable)
	{
		if (SwigDerivedClassHasMethod("setViewSectioningOverride", swigMethodTypes72))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setViewSectioningOverrideSwigExplicitOdGsBaseModel(swigCPtr, bEnable);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setViewSectioningOverride(swigCPtr, bEnable);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool viewSectioningOverride()
	{
		bool result = (SwigDerivedClassHasMethod("viewSectioningOverride", swigMethodTypes73) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewSectioningOverrideSwigExplicitOdGsBaseModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_viewSectioningOverride(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerExtensionLoadingReactor extLoadingReactor()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_extLoadingReactor(swigCPtr);
		OdGsFilerExtensionLoadingReactor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionLoadingReactor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExtLoadingReactor(OdGsFilerExtensionLoadingReactor pExtReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_setExtLoadingReactor(swigCPtr, OdGsFilerExtensionLoadingReactor.getCPtr(pExtReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool saveModelState(OdGsFilerGSS pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = (SwigDerivedClassHasMethod("saveModelState", swigMethodTypes109) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveModelStateSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGsFilerGSS.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveModelState__SWIG_0(swigCPtr, OdGsFilerGSS.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveModelState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveModelState", swigMethodTypes110) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveModelStateSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveModelState__SWIG_1(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadModelState(OdGsFilerGSS pFiler, OdGsBaseVectorizer pVectorizer)
	{
		bool result = (SwigDerivedClassHasMethod("loadModelState", swigMethodTypes111) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadModelStateSwigExplicitOdGsBaseModel__SWIG_0(swigCPtr, OdGsFilerGSS.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadModelState__SWIG_0(swigCPtr, OdGsFilerGSS.getCPtr(pFiler), OdGsBaseVectorizer.getCPtr(pVectorizer)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadModelState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadModelState", swigMethodTypes112) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadModelStateSwigExplicitOdGsBaseModel__SWIG_1(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadModelState__SWIG_1(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveClientModelState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("saveClientModelState", swigMethodTypes113) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveClientModelStateSwigExplicitOdGsBaseModel(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_saveClientModelState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadClientModelState(OdGsFilerGSS pFiler)
	{
		bool result = (SwigDerivedClassHasMethod("loadClientModelState", swigMethodTypes114) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadClientModelStateSwigExplicitOdGsBaseModel(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_loadClientModelState(swigCPtr, OdGsFilerGSS.getCPtr(pFiler)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool postprocessModelLoading(OdGsFilerGSS pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_postprocessModelLoading(swigCPtr, OdGsFilerGSS.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual bool onPropertyModified(OdGsBaseModelReactor_ModelProperty nProp)
	{
		bool result = (SwigDerivedClassHasMethod("onPropertyModified", swigMethodTypes115) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onPropertyModifiedSwigExplicitOdGsBaseModel(swigCPtr, (int)nProp) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_onPropertyModified(swigCPtr, (int)nProp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsNode newNode(ENodeType ntp, OdGiDrawable drawable, bool bSetGsNode)
	{
		OdGsNode rXObject = Helpers.GetRXObject<OdGsNode>(SwigDerivedClassHasMethod("newNode", swigMethodTypes116) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_newNodeSwigExplicitOdGsBaseModel(swigCPtr, (int)ntp, OdGiDrawable.getCPtr(drawable), bSetGsNode) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_newNode(swigCPtr, (int)ntp, OdGiDrawable.getCPtr(drawable), bSetGsNode), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("setOpenDrawableFn", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetOpenDrawableFn;
		}
		if (SwigDerivedClassHasMethod("onAdded1", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodonAdded1;
		}
		if (SwigDerivedClassHasMethod("onAdded2", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodonAdded2;
		}
		if (SwigDerivedClassHasMethod("onModified1", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodonModified1;
		}
		if (SwigDerivedClassHasMethod("onModified2", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodonModified2;
		}
		if (SwigDerivedClassHasMethod("onModifiedGraphics", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodonModifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("onErased1", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodonErased1;
		}
		if (SwigDerivedClassHasMethod("onErased2", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodonErased2;
		}
		if (SwigDerivedClassHasMethod("onUnerased1", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodonUnerased1;
		}
		if (SwigDerivedClassHasMethod("onUnerased2", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodonUnerased2;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodinvalidate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("invalidate2", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodinvalidate2;
		}
		if (SwigDerivedClassHasMethod("invalidateVisible", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodinvalidateVisible;
		}
		if (SwigDerivedClassHasMethod("setTransform", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetTransform;
		}
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodtransform;
		}
		if (SwigDerivedClassHasMethod("highlight1", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodhighlight1;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodhighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodhighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodhighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("highlight2", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodhighlight2;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodhighlight__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodhighlight__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodhighlight__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("hide1", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodhide1;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodhide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodhide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodhide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("hide2", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodhide2;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodhide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodhide__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodhide__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("externalTransform1", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodexternalTransform1;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodexternalTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodexternalTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodexternalTransform__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("externalTransform2", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodexternalTransform2;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodexternalTransform__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodexternalTransform__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodexternalTransform__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetExternalTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetExternalTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setRenderType", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetRenderType;
		}
		if (SwigDerivedClassHasMethod("renderType", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodrenderType;
		}
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetRenderModeOverride__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetRenderModeOverride__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("renderModeOverride", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodrenderModeOverride;
		}
		if (SwigDerivedClassHasMethod("setViewClippingOverride", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetViewClippingOverride;
		}
		if (SwigDerivedClassHasMethod("viewClippingOverride", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodviewClippingOverride;
		}
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetBackground;
		}
		if (SwigDerivedClassHasMethod("background", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodbackground;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle1", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetVisualStyle1;
		}
		if (SwigDerivedClassHasMethod("visualStyle1", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodvisualStyle1;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle2", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsetVisualStyle2;
		}
		if (SwigDerivedClassHasMethod("VisualStyle2", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodVisualStyle2;
		}
		if (SwigDerivedClassHasMethod("addModelReactor", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodaddModelReactor;
		}
		if (SwigDerivedClassHasMethod("removeModelReactor", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodremoveModelReactor;
		}
		if (SwigDerivedClassHasMethod("setEnableSectioning", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetEnableSectioning;
		}
		if (SwigDerivedClassHasMethod("isSectioningEnabled", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodisSectioningEnabled;
		}
		if (SwigDerivedClassHasMethod("setSectioning1", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetSectioning1;
		}
		if (SwigDerivedClassHasMethod("setSectioning2", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetSectioning2;
		}
		if (SwigDerivedClassHasMethod("setSectioningVisualStyle", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetSectioningVisualStyle;
		}
		if (SwigDerivedClassHasMethod("setEnableLinetypes", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetEnableLinetypes;
		}
		if (SwigDerivedClassHasMethod("isLinetypesEnabled", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodisLinetypesEnabled;
		}
		if (SwigDerivedClassHasMethod("setSelectable", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetSelectable;
		}
		if (SwigDerivedClassHasMethod("isSelectable", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodisSelectable;
		}
		if (SwigDerivedClassHasMethod("setEnableViewExtentsCalculation", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetEnableViewExtentsCalculation;
		}
		if (SwigDerivedClassHasMethod("isViewExtentsCalculationEnabled", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodisViewExtentsCalculationEnabled;
		}
		if (SwigDerivedClassHasMethod("setEnableLightsInBlocks", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetEnableLightsInBlocks;
		}
		if (SwigDerivedClassHasMethod("isLightsInBlocksEnabled", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodisLightsInBlocksEnabled;
		}
		if (SwigDerivedClassHasMethod("setViewSectioningOverride", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetViewSectioningOverride;
		}
		if (SwigDerivedClassHasMethod("viewSectioningOverride", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodviewSectioningOverride;
		}
		if (SwigDerivedClassHasMethod("addNode", swigMethodTypes74))
		{
			swigDelegate74 = SwigDirectorMethodaddNode;
		}
		if (SwigDerivedClassHasMethod("invalidateEntRect1", swigMethodTypes75))
		{
			swigDelegate75 = SwigDirectorMethodinvalidateEntRect1;
		}
		if (SwigDerivedClassHasMethod("invalidateEntRect", swigMethodTypes76))
		{
			swigDelegate76 = SwigDirectorMethodinvalidateEntRect;
		}
		if (SwigDerivedClassHasMethod("invalidateEntRect2", swigMethodTypes77))
		{
			swigDelegate77 = SwigDirectorMethodinvalidateEntRect2;
		}
		if (SwigDerivedClassHasMethod("disableNotifications", swigMethodTypes78))
		{
			swigDelegate78 = SwigDirectorMethoddisableNotifications;
		}
		if (SwigDerivedClassHasMethod("attachLocalViewportId", swigMethodTypes79))
		{
			swigDelegate79 = SwigDirectorMethodattachLocalViewportId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("attachLocalViewportId", swigMethodTypes80))
		{
			swigDelegate80 = SwigDirectorMethodattachLocalViewportId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getLocalViewportId", swigMethodTypes81))
		{
			swigDelegate81 = SwigDirectorMethodgetLocalViewportId;
		}
		if (SwigDerivedClassHasMethod("getMaxLocalViewportId", swigMethodTypes82))
		{
			swigDelegate82 = SwigDirectorMethodgetMaxLocalViewportId;
		}
		if (SwigDerivedClassHasMethod("clearChangedLayersList", swigMethodTypes83))
		{
			swigDelegate83 = SwigDirectorMethodclearChangedLayersList;
		}
		if (SwigDerivedClassHasMethod("gsNode", swigMethodTypes84))
		{
			swigDelegate84 = SwigDirectorMethodgsNode;
		}
		if (SwigDerivedClassHasMethod("detach", swigMethodTypes85))
		{
			swigDelegate85 = SwigDirectorMethoddetach;
		}
		if (SwigDerivedClassHasMethod("detachAll", swigMethodTypes86))
		{
			swigDelegate86 = SwigDirectorMethoddetachAll;
		}
		if (SwigDerivedClassHasMethod("onAddedImpl", swigMethodTypes87))
		{
			swigDelegate87 = SwigDirectorMethodonAddedImpl__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onAddedImpl", swigMethodTypes88))
		{
			swigDelegate88 = SwigDirectorMethodonAddedImpl__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onModifiedImpl", swigMethodTypes89))
		{
			swigDelegate89 = SwigDirectorMethodonModifiedImpl;
		}
		if (SwigDerivedClassHasMethod("onErasedImpl", swigMethodTypes90))
		{
			swigDelegate90 = SwigDirectorMethodonErasedImpl;
		}
		if (SwigDerivedClassHasMethod("updateViewProps", swigMethodTypes91))
		{
			swigDelegate91 = SwigDirectorMethodupdateViewProps;
		}
		if (SwigDerivedClassHasMethod("isViewPropsValid", swigMethodTypes92))
		{
			swigDelegate92 = SwigDirectorMethodisViewPropsValid;
		}
		if (SwigDerivedClassHasMethod("gsLayerNode", swigMethodTypes93))
		{
			swigDelegate93 = SwigDirectorMethodgsLayerNode;
		}
		if (SwigDerivedClassHasMethod("propagateLayerChanges", swigMethodTypes94))
		{
			swigDelegate94 = SwigDirectorMethodpropagateLayerChanges;
		}
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes95))
		{
			swigDelegate95 = SwigDirectorMethodhighlightImpl__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes96))
		{
			swigDelegate96 = SwigDirectorMethodhighlightImpl__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes97))
		{
			swigDelegate97 = SwigDirectorMethodhighlightImpl__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("highlightImpl", swigMethodTypes98))
		{
			swigDelegate98 = SwigDirectorMethodhighlightImpl__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes99))
		{
			swigDelegate99 = SwigDirectorMethodhideImpl__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes100))
		{
			swigDelegate100 = SwigDirectorMethodhideImpl__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes101))
		{
			swigDelegate101 = SwigDirectorMethodhideImpl__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("hideImpl", swigMethodTypes102))
		{
			swigDelegate102 = SwigDirectorMethodhideImpl__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes103))
		{
			swigDelegate103 = SwigDirectorMethodexternalTransformImpl__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes104))
		{
			swigDelegate104 = SwigDirectorMethodexternalTransformImpl__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes105))
		{
			swigDelegate105 = SwigDirectorMethodexternalTransformImpl__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("externalTransformImpl", swigMethodTypes106))
		{
			swigDelegate106 = SwigDirectorMethodexternalTransformImpl__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("makeStock", swigMethodTypes107))
		{
			swigDelegate107 = SwigDirectorMethodmakeStock;
		}
		if (SwigDerivedClassHasMethod("releaseStock", swigMethodTypes108))
		{
			swigDelegate108 = SwigDirectorMethodreleaseStock;
		}
		if (SwigDerivedClassHasMethod("saveModelState", swigMethodTypes109))
		{
			swigDelegate109 = SwigDirectorMethodsaveModelState__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("saveModelState", swigMethodTypes110))
		{
			swigDelegate110 = SwigDirectorMethodsaveModelState__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("loadModelState", swigMethodTypes111))
		{
			swigDelegate111 = SwigDirectorMethodloadModelState__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadModelState", swigMethodTypes112))
		{
			swigDelegate112 = SwigDirectorMethodloadModelState__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("saveClientModelState", swigMethodTypes113))
		{
			swigDelegate113 = SwigDirectorMethodsaveClientModelState;
		}
		if (SwigDerivedClassHasMethod("loadClientModelState", swigMethodTypes114))
		{
			swigDelegate114 = SwigDirectorMethodloadClientModelState;
		}
		if (SwigDerivedClassHasMethod("onPropertyModified", swigMethodTypes115))
		{
			swigDelegate115 = SwigDirectorMethodonPropertyModified;
		}
		if (SwigDerivedClassHasMethod("newNode", swigMethodTypes116))
		{
			swigDelegate116 = SwigDirectorMethodnewNode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModel_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73, swigDelegate74, swigDelegate75, swigDelegate76, swigDelegate77, swigDelegate78, swigDelegate79, swigDelegate80, swigDelegate81, swigDelegate82, swigDelegate83, swigDelegate84, swigDelegate85, swigDelegate86, swigDelegate87, swigDelegate88, swigDelegate89, swigDelegate90, swigDelegate91, swigDelegate92, swigDelegate93, swigDelegate94, swigDelegate95, swigDelegate96, swigDelegate97, swigDelegate98, swigDelegate99, swigDelegate100, swigDelegate101, swigDelegate102, swigDelegate103, swigDelegate104, swigDelegate105, swigDelegate106, swigDelegate107, swigDelegate108, swigDelegate109, swigDelegate110, swigDelegate111, swigDelegate112, swigDelegate113, swigDelegate114, swigDelegate115, swigDelegate116);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseModel));
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

	private void SwigDirectorMethodsetOpenDrawableFn(IntPtr openDrawableFn)
	{
		try
		{
			setOpenDrawableFn(((Func<TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate>)delegate
			{
				IntPtr nativeCallback = openDrawableFn;
				TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = (OdDbStub id) => OdMarshalHelper.PtrToObject<OdGiDrawable>((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)) as TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbStub>(id)));
				}
				return result;
			})());
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

	private void SwigDirectorMethodonAdded1(IntPtr pAdded, IntPtr pParent)
	{
		try
		{
			onAdded1(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonAdded2(IntPtr pAdded, IntPtr parentID)
	{
		try
		{
			onAdded2(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonModified1(IntPtr pModified, IntPtr pParent)
	{
		try
		{
			onModified1(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonModified2(IntPtr pModified, IntPtr parentID)
	{
		try
		{
			onModified2(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonModifiedGraphics(IntPtr pModified, IntPtr parentID)
	{
		try
		{
			onModifiedGraphics(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonErased1(IntPtr pErased, IntPtr pParent)
	{
		try
		{
			onErased1(Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonErased2(IntPtr pErased, IntPtr parentID)
	{
		try
		{
			onErased2(Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonUnerased1(IntPtr pUnerased, IntPtr pParent)
	{
		try
		{
			onUnerased1(Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonUnerased2(IntPtr pUnerased, IntPtr parentID)
	{
		try
		{
			onUnerased2(Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodinvalidate__SWIG_0(int hint)
	{
		try
		{
			invalidate((OdGsModel_InvalidationHint)hint);
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

	private void SwigDirectorMethodinvalidate2(IntPtr pView)
	{
		try
		{
			invalidate2(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidateVisible(IntPtr pDevice)
	{
		try
		{
			invalidateVisible(Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetTransform(IntPtr xForm)
	{
		try
		{
			setTransform(new OdGeMatrix3d(xForm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodtransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(transform()).Handle;
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

	private void SwigDirectorMethodhighlight1(IntPtr path, bool bDoIt, uint nStyle, IntPtr pView)
	{
		try
		{
			highlight1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, nStyle, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhighlight__SWIG_0(IntPtr path, bool bDoIt, uint nStyle)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, nStyle);
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

	private void SwigDirectorMethodhighlight__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodhighlight__SWIG_2(IntPtr path)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodhighlight2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView)
	{
		try
		{
			highlight2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhighlight__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
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

	private void SwigDirectorMethodhighlight__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhighlight__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodhide1(IntPtr path, bool bDoIt, bool bSelectHidden, IntPtr pView)
	{
		try
		{
			hide1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, bSelectHidden, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhide__SWIG_0(IntPtr path, bool bDoIt, bool bSelectHidden)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, bSelectHidden);
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

	private void SwigDirectorMethodhide__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodhide__SWIG_2(IntPtr path)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodhide2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView)
	{
		try
		{
			hide2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhide__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
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

	private void SwigDirectorMethodhide__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhide__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodexternalTransform1(IntPtr path, bool bDoIt, IntPtr xForm, IntPtr pView)
	{
		try
		{
			externalTransform1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_0(IntPtr path, bool bDoIt, IntPtr xForm)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodexternalTransform__SWIG_2(IntPtr path)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodexternalTransform2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView)
	{
		try
		{
			externalTransform2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodexternalTransform__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private bool SwigDirectorMethodgetExternalTransform__SWIG_0(IntPtr path, IntPtr xForm, IntPtr pView)
	{
		OdGsMatrixParam xForm2 = new OdGsMatrixParam(xForm, cMemoryOwn: true);
		return getExternalTransform(new OdGiPathNode(path, cMemoryOwn: false), xForm2, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetExternalTransform__SWIG_1(IntPtr path, IntPtr xForm)
	{
		OdGsMatrixParam xForm2 = new OdGsMatrixParam(xForm, cMemoryOwn: true);
		return getExternalTransform(new OdGiPathNode(path, cMemoryOwn: false), xForm2);
	}

	private void SwigDirectorMethodsetRenderType(int renderType)
	{
		try
		{
			setRenderType((OdGsModel_RenderType)renderType);
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

	private int SwigDirectorMethodrenderType()
	{
		return (int)renderType();
	}

	private void SwigDirectorMethodsetRenderModeOverride__SWIG_0(int mode)
	{
		try
		{
			setRenderModeOverride((OdGsView_RenderMode)mode);
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

	private void SwigDirectorMethodsetRenderModeOverride__SWIG_1()
	{
		try
		{
			setRenderModeOverride();
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

	private int SwigDirectorMethodrenderModeOverride()
	{
		return (int)renderModeOverride();
	}

	private void SwigDirectorMethodsetViewClippingOverride(bool bEnable)
	{
		try
		{
			setViewClippingOverride(bEnable);
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

	private bool SwigDirectorMethodviewClippingOverride()
	{
		return viewClippingOverride();
	}

	private void SwigDirectorMethodsetBackground(IntPtr backgroundId)
	{
		try
		{
			setBackground((backgroundId == IntPtr.Zero) ? null : new OdDbStub(backgroundId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodbackground()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background()).Handle;
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

	private void SwigDirectorMethodsetVisualStyle1(IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle1((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodvisualStyle1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle1()).Handle;
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

	private void SwigDirectorMethodsetVisualStyle2(IntPtr visualStyle)
	{
		try
		{
			setVisualStyle2(Helpers.GetRXObject<OdGiVisualStyle>(visualStyle, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodVisualStyle2(IntPtr visualStyle)
	{
		OdSwigDirectorHelper.director_UnpackData(visualStyle, out var pOriginalObject, out var pFunction);
		OdGiVisualStyle visualStyle2 = Helpers.GetRXObject<OdGiVisualStyle>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return VisualStyle2(ref visualStyle2);
		}
		finally
		{
			IntPtr handle = OdGiVisualStyle.getCPtr(visualStyle2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(visualStyle);
		}
	}

	private void SwigDirectorMethodaddModelReactor(IntPtr pReactor)
	{
		try
		{
			addModelReactor((pReactor == IntPtr.Zero) ? null : new OdGsModelReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodremoveModelReactor(IntPtr pReactor)
	{
		try
		{
			removeModelReactor((pReactor == IntPtr.Zero) ? null : new OdGsModelReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEnableSectioning(bool bEnable)
	{
		try
		{
			setEnableSectioning(bEnable);
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

	private bool SwigDirectorMethodisSectioningEnabled()
	{
		return isSectioningEnabled();
	}

	private bool SwigDirectorMethodsetSectioning1(IntPtr points, IntPtr upVector)
	{
		return setSectioning1(new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsetSectioning2(IntPtr points, IntPtr upVector, double dTop, double dBottom)
	{
		return setSectioning2(new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), dTop, dBottom);
	}

	private void SwigDirectorMethodsetSectioningVisualStyle(IntPtr visualStyleId)
	{
		try
		{
			setSectioningVisualStyle((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEnableLinetypes(bool bEnable)
	{
		try
		{
			setEnableLinetypes(bEnable);
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

	private bool SwigDirectorMethodisLinetypesEnabled()
	{
		return isLinetypesEnabled();
	}

	private void SwigDirectorMethodsetSelectable(bool bEnable)
	{
		try
		{
			setSelectable(bEnable);
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

	private bool SwigDirectorMethodisSelectable()
	{
		return isSelectable();
	}

	private void SwigDirectorMethodsetEnableViewExtentsCalculation(bool bEnable)
	{
		try
		{
			setEnableViewExtentsCalculation(bEnable);
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

	private bool SwigDirectorMethodisViewExtentsCalculationEnabled()
	{
		return isViewExtentsCalculationEnabled();
	}

	private void SwigDirectorMethodsetEnableLightsInBlocks(bool bEnable)
	{
		try
		{
			setEnableLightsInBlocks(bEnable);
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

	private bool SwigDirectorMethodisLightsInBlocksEnabled()
	{
		return isLightsInBlocksEnabled();
	}

	private void SwigDirectorMethodsetViewSectioningOverride(bool bEnable)
	{
		try
		{
			setViewSectioningOverride(bEnable);
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

	private bool SwigDirectorMethodviewSectioningOverride()
	{
		return viewSectioningOverride();
	}

	private void SwigDirectorMethodaddNode(IntPtr pNode)
	{
		try
		{
			addNode(Helpers.GetRXObject<OdGsNode>(pNode, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidateEntRect1(IntPtr pDrawable, IntPtr pParent, bool bForceIfNoExtents)
	{
		try
		{
			invalidateEntRect1(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false), bForceIfNoExtents);
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

	private void SwigDirectorMethodinvalidateEntRect(IntPtr pDrawable, IntPtr pParent)
	{
		try
		{
			invalidateEntRect(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidateEntRect2(IntPtr pNode, IntPtr pParent, bool bForceIfNoExtents)
	{
		try
		{
			invalidateEntRect2(Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsContainerNode>(pParent, bOwn: false, bTryAddToTransaction: false), bForceIfNoExtents);
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

	private bool SwigDirectorMethoddisableNotifications()
	{
		return disableNotifications();
	}

	private void SwigDirectorMethodattachLocalViewportId__SWIG_0(IntPtr pView, IntPtr pFrom)
	{
		try
		{
			attachLocalViewportId(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsViewImpl>(pFrom, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodattachLocalViewportId__SWIG_1(IntPtr pView)
	{
		try
		{
			attachLocalViewportId(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodgetLocalViewportId(IntPtr pView)
	{
		return getLocalViewportId(Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodgetMaxLocalViewportId()
	{
		return getMaxLocalViewportId();
	}

	private void SwigDirectorMethodclearChangedLayersList()
	{
		try
		{
			clearChangedLayersList();
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

	private IntPtr SwigDirectorMethodgsNode(IntPtr pDrawable)
	{
		return OdGsNode.getCPtr(gsNode(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethoddetach(IntPtr pNode)
	{
		try
		{
			detach(Helpers.GetRXObject<OdGsNode>(pNode, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddetachAll()
	{
		try
		{
			detachAll();
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

	private void SwigDirectorMethodonAddedImpl__SWIG_0(IntPtr pAdded, IntPtr pParent, int additionMode)
	{
		try
		{
			onAddedImpl(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false), (OdGsBaseModel_AdditionMode)additionMode);
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

	private void SwigDirectorMethodonAddedImpl__SWIG_1(IntPtr pAdded, IntPtr pParent)
	{
		try
		{
			onAddedImpl(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonModifiedImpl(IntPtr pModified, IntPtr pParent)
	{
		try
		{
			onModifiedImpl(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonErasedImpl(IntPtr pErased, IntPtr pParent)
	{
		try
		{
			onErasedImpl(Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodupdateViewProps(IntPtr viewport)
	{
		try
		{
			updateViewProps(Helpers.GetRXObject<OdGsViewImpl>(viewport, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodisViewPropsValid(uint viewportId)
	{
		return isViewPropsValid(viewportId);
	}

	private IntPtr SwigDirectorMethodgsLayerNode(IntPtr layerId, IntPtr pView)
	{
		return OdGsLayerNode.getCPtr(gsLayerNode((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false), (pView == IntPtr.Zero) ? null : new OdGsBaseVectorizer(pView, cMemoryOwn: false))).Handle;
	}

	private void SwigDirectorMethodpropagateLayerChanges(IntPtr device)
	{
		OdSwigDirectorHelper.director_UnpackData(device, out var pOriginalObject, out var pFunction);
		OdGsBaseVectorizeDevice device2 = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			propagateLayerChanges(ref device2);
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
			IntPtr handle = OdGsBaseVectorizeDevice.getCPtr(device2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(device);
		}
	}

	private void SwigDirectorMethodhighlightImpl__SWIG_0(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView)
	{
		try
		{
			highlightImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhighlightImpl__SWIG_1(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		try
		{
			highlightImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
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

	private void SwigDirectorMethodhighlightImpl__SWIG_2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			highlightImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhighlightImpl__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			highlightImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodhideImpl__SWIG_0(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView)
	{
		try
		{
			hideImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhideImpl__SWIG_1(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		try
		{
			hideImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
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

	private void SwigDirectorMethodhideImpl__SWIG_2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			hideImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhideImpl__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			hideImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodexternalTransformImpl__SWIG_0(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView)
	{
		try
		{
			externalTransformImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransformImpl__SWIG_1(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm)
	{
		try
		{
			externalTransformImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransformImpl__SWIG_2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			externalTransformImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodexternalTransformImpl__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			externalTransformImpl(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private bool SwigDirectorMethodmakeStock(IntPtr layoutId)
	{
		return makeStock((layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false));
	}

	private void SwigDirectorMethodreleaseStock(IntPtr layoutId)
	{
		try
		{
			releaseStock((layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false));
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

	private bool SwigDirectorMethodsaveModelState__SWIG_0(IntPtr pFiler, IntPtr pVectorizer)
	{
		return saveModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false), (pVectorizer == IntPtr.Zero) ? null : new OdGsBaseVectorizer(pVectorizer, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsaveModelState__SWIG_1(IntPtr pFiler)
	{
		return saveModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadModelState__SWIG_0(IntPtr pFiler, IntPtr pVectorizer)
	{
		return loadModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false), (pVectorizer == IntPtr.Zero) ? null : new OdGsBaseVectorizer(pVectorizer, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodloadModelState__SWIG_1(IntPtr pFiler)
	{
		return loadModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsaveClientModelState(IntPtr pFiler)
	{
		return saveClientModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadClientModelState(IntPtr pFiler)
	{
		return loadClientModelState(Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonPropertyModified(int nProp)
	{
		return onPropertyModified((OdGsBaseModelReactor_ModelProperty)nProp);
	}

	private IntPtr SwigDirectorMethodnewNode(int ntp, IntPtr drawable, bool bSetGsNode)
	{
		return OdGsNode.getCPtr(newNode((ENodeType)ntp, Helpers.GetRXObject<OdGiDrawable>(drawable, bOwn: false, bTryAddToTransaction: false), bSetGsNode)).Handle;
	}
}
