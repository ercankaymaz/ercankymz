using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVisualStyleDataContainer : OdStaticRxObject_OdGiVisualStyle
{
	public class OdCmColorBaseAdapt : OdCmColorBase
	{
		public delegate int SwigDelegateOdCmColorBaseAdapt_0();

		public delegate void SwigDelegateOdCmColorBaseAdapt_1(int colorMethod);

		public delegate bool SwigDelegateOdCmColorBaseAdapt_2();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_3();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_4();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_5();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_6();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_7();

		public delegate uint SwigDelegateOdCmColorBaseAdapt_8();

		public delegate void SwigDelegateOdCmColorBaseAdapt_9(uint color);

		public delegate void SwigDelegateOdCmColorBaseAdapt_10(byte red, byte green, byte blue);

		public delegate void SwigDelegateOdCmColorBaseAdapt_11(byte red);

		public delegate void SwigDelegateOdCmColorBaseAdapt_12(byte green);

		public delegate void SwigDelegateOdCmColorBaseAdapt_13(byte blue);

		public delegate byte SwigDelegateOdCmColorBaseAdapt_14();

		public delegate byte SwigDelegateOdCmColorBaseAdapt_15();

		public delegate byte SwigDelegateOdCmColorBaseAdapt_16();

		public delegate ushort SwigDelegateOdCmColorBaseAdapt_17();

		public delegate void SwigDelegateOdCmColorBaseAdapt_18(ushort colorIndex);

		public delegate bool SwigDelegateOdCmColorBaseAdapt_19([MarshalAs(UnmanagedType.LPWStr)] string arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1);

		public delegate bool SwigDelegateOdCmColorBaseAdapt_20([MarshalAs(UnmanagedType.LPWStr)] string arg0);

		[return: MarshalAs(UnmanagedType.LPWStr)]
		public delegate string SwigDelegateOdCmColorBaseAdapt_21();

		[return: MarshalAs(UnmanagedType.LPWStr)]
		public delegate string SwigDelegateOdCmColorBaseAdapt_22();

		[return: MarshalAs(UnmanagedType.LPWStr)]
		public delegate string SwigDelegateOdCmColorBaseAdapt_23();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_24();

		public delegate bool SwigDelegateOdCmColorBaseAdapt_25();

		private object locker = new object();

		private HandleRef swigCPtr;

		private SwigDelegateOdCmColorBaseAdapt_0 swigDelegate0;

		private SwigDelegateOdCmColorBaseAdapt_1 swigDelegate1;

		private SwigDelegateOdCmColorBaseAdapt_2 swigDelegate2;

		private SwigDelegateOdCmColorBaseAdapt_3 swigDelegate3;

		private SwigDelegateOdCmColorBaseAdapt_4 swigDelegate4;

		private SwigDelegateOdCmColorBaseAdapt_5 swigDelegate5;

		private SwigDelegateOdCmColorBaseAdapt_6 swigDelegate6;

		private SwigDelegateOdCmColorBaseAdapt_7 swigDelegate7;

		private SwigDelegateOdCmColorBaseAdapt_8 swigDelegate8;

		private SwigDelegateOdCmColorBaseAdapt_9 swigDelegate9;

		private SwigDelegateOdCmColorBaseAdapt_10 swigDelegate10;

		private SwigDelegateOdCmColorBaseAdapt_11 swigDelegate11;

		private SwigDelegateOdCmColorBaseAdapt_12 swigDelegate12;

		private SwigDelegateOdCmColorBaseAdapt_13 swigDelegate13;

		private SwigDelegateOdCmColorBaseAdapt_14 swigDelegate14;

		private SwigDelegateOdCmColorBaseAdapt_15 swigDelegate15;

		private SwigDelegateOdCmColorBaseAdapt_16 swigDelegate16;

		private SwigDelegateOdCmColorBaseAdapt_17 swigDelegate17;

		private SwigDelegateOdCmColorBaseAdapt_18 swigDelegate18;

		private SwigDelegateOdCmColorBaseAdapt_19 swigDelegate19;

		private SwigDelegateOdCmColorBaseAdapt_20 swigDelegate20;

		private SwigDelegateOdCmColorBaseAdapt_21 swigDelegate21;

		private SwigDelegateOdCmColorBaseAdapt_22 swigDelegate22;

		private SwigDelegateOdCmColorBaseAdapt_23 swigDelegate23;

		private SwigDelegateOdCmColorBaseAdapt_24 swigDelegate24;

		private SwigDelegateOdCmColorBaseAdapt_25 swigDelegate25;

		private static Type[] swigMethodTypes0 = new Type[0];

		private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdCmEntityColor_ColorMethod) };

		private static Type[] swigMethodTypes2 = new Type[0];

		private static Type[] swigMethodTypes3 = new Type[0];

		private static Type[] swigMethodTypes4 = new Type[0];

		private static Type[] swigMethodTypes5 = new Type[0];

		private static Type[] swigMethodTypes6 = new Type[0];

		private static Type[] swigMethodTypes7 = new Type[0];

		private static Type[] swigMethodTypes8 = new Type[0];

		private static Type[] swigMethodTypes9 = new Type[1] { typeof(uint) };

		private static Type[] swigMethodTypes10 = new Type[3]
		{
			typeof(byte),
			typeof(byte),
			typeof(byte)
		};

		private static Type[] swigMethodTypes11 = new Type[1] { typeof(byte) };

		private static Type[] swigMethodTypes12 = new Type[1] { typeof(byte) };

		private static Type[] swigMethodTypes13 = new Type[1] { typeof(byte) };

		private static Type[] swigMethodTypes14 = new Type[0];

		private static Type[] swigMethodTypes15 = new Type[0];

		private static Type[] swigMethodTypes16 = new Type[0];

		private static Type[] swigMethodTypes17 = new Type[0];

		private static Type[] swigMethodTypes18 = new Type[1] { typeof(ushort) };

		private static Type[] swigMethodTypes19 = new Type[2]
		{
			typeof(string),
			typeof(string)
		};

		private static Type[] swigMethodTypes20 = new Type[1] { typeof(string) };

		private static Type[] swigMethodTypes21 = new Type[0];

		private static Type[] swigMethodTypes22 = new Type[0];

		private static Type[] swigMethodTypes23 = new Type[0];

		private static Type[] swigMethodTypes24 = new Type[0];

		private static Type[] swigMethodTypes25 = new Type[0];

		public OdGiVariant m_pVar
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_m_pVar_get(swigCPtr);
				OdGiVariant result = ((intPtr == IntPtr.Zero) ? null : new OdGiVariant(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_m_pVar_set(swigCPtr, OdGiVariant.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdCmColorBaseAdapt(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdCmColorBaseAdapt obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleDataContainer_OdCmColorBaseAdapt(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public OdCmColorBaseAdapt()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVisualStyleDataContainer_OdCmColorBaseAdapt(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(OdCmColorBaseAdapt) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		public void setBase(OdGiVariant pVar)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setBase(swigCPtr, OdGiVariant.getCPtr(pVar));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiVariant base_()
		{
			OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_base_(swigCPtr), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public OdCmEntityColor entColor()
		{
			OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_entColor__SWIG_0(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override OdCmEntityColor_ColorMethod colorMethod()
		{
			int result = (SwigDerivedClassHasMethod("colorMethod", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorMethodSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorMethod(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdCmEntityColor_ColorMethod)result;
		}

		public override void setColorMethod(OdCmEntityColor_ColorMethod colorMethod)
		{
			if (SwigDerivedClassHasMethod("setColorMethod", swigMethodTypes1))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColorMethodSwigExplicitOdCmColorBaseAdapt(swigCPtr, (int)colorMethod);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColorMethod(swigCPtr, (int)colorMethod);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override bool isByColor()
		{
			bool result = (SwigDerivedClassHasMethod("isByColor", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByColorSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByColor(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool isByLayer()
		{
			bool result = (SwigDerivedClassHasMethod("isByLayer", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByLayerSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByLayer(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool isByBlock()
		{
			bool result = (SwigDerivedClassHasMethod("isByBlock", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByBlockSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByBlock(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool isByACI()
		{
			bool result = (SwigDerivedClassHasMethod("isByACI", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByACISwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByACI(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool isForeground()
		{
			bool result = (SwigDerivedClassHasMethod("isForeground", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isForegroundSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isForeground(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool isByDgnIndex()
		{
			bool result = (SwigDerivedClassHasMethod("isByDgnIndex", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByDgnIndexSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_isByDgnIndex(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override uint color()
		{
			uint result = (SwigDerivedClassHasMethod("color", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_color(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setColor(uint color)
		{
			if (SwigDerivedClassHasMethod("setColor", swigMethodTypes9))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColorSwigExplicitOdCmColorBaseAdapt(swigCPtr, color);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColor(swigCPtr, color);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override void setRGB(byte red, byte green, byte blue)
		{
			if (SwigDerivedClassHasMethod("setRGB", swigMethodTypes10))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setRGBSwigExplicitOdCmColorBaseAdapt(swigCPtr, red, green, blue);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setRGB(swigCPtr, red, green, blue);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override void setRed(byte red)
		{
			if (SwigDerivedClassHasMethod("setRed", swigMethodTypes11))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setRedSwigExplicitOdCmColorBaseAdapt(swigCPtr, red);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setRed(swigCPtr, red);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override void setGreen(byte green)
		{
			if (SwigDerivedClassHasMethod("setGreen", swigMethodTypes12))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setGreenSwigExplicitOdCmColorBaseAdapt(swigCPtr, green);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setGreen(swigCPtr, green);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override void setBlue(byte blue)
		{
			if (SwigDerivedClassHasMethod("setBlue", swigMethodTypes13))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setBlueSwigExplicitOdCmColorBaseAdapt(swigCPtr, blue);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setBlue(swigCPtr, blue);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override byte red()
		{
			byte result = (SwigDerivedClassHasMethod("red", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_redSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_red(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override byte green()
		{
			byte result = (SwigDerivedClassHasMethod("green", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_greenSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_green(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override byte blue()
		{
			byte result = (SwigDerivedClassHasMethod("blue", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_blueSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_blue(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override ushort colorIndex()
		{
			ushort result = (SwigDerivedClassHasMethod("colorIndex", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorIndexSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorIndex(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setColorIndex(ushort colorIndex)
		{
			if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes18))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColorIndexSwigExplicitOdCmColorBaseAdapt(swigCPtr, colorIndex);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setColorIndex(swigCPtr, colorIndex);
			}
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override bool setNames(string arg0, string arg1)
		{
			bool result = (SwigDerivedClassHasMethod("setNames", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setNamesSwigExplicitOdCmColorBaseAdapt__SWIG_0(swigCPtr, arg0, arg1) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setNames__SWIG_0(swigCPtr, arg0, arg1));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool setNames(string arg0)
		{
			bool result = (SwigDerivedClassHasMethod("setNames", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setNamesSwigExplicitOdCmColorBaseAdapt__SWIG_1(swigCPtr, arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_setNames__SWIG_1(swigCPtr, arg0));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override string colorName()
		{
			string result = (SwigDerivedClassHasMethod("colorName", swigMethodTypes21) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorNameSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorName(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override string bookName()
		{
			string result = (SwigDerivedClassHasMethod("bookName", swigMethodTypes22) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_bookNameSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_bookName(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override string colorNameForDisplay()
		{
			string result = (SwigDerivedClassHasMethod("colorNameForDisplay", swigMethodTypes23) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorNameForDisplaySwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_colorNameForDisplay(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool hasColorName()
		{
			bool result = (SwigDerivedClassHasMethod("hasColorName", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_hasColorNameSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_hasColorName(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override bool hasBookName()
		{
			bool result = (SwigDerivedClassHasMethod("hasBookName", swigMethodTypes25) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_hasBookNameSwigExplicitOdCmColorBaseAdapt(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_hasBookName(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("colorMethod", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodcolorMethod;
			}
			if (SwigDerivedClassHasMethod("setColorMethod", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorMethodsetColorMethod;
			}
			if (SwigDerivedClassHasMethod("isByColor", swigMethodTypes2))
			{
				swigDelegate2 = SwigDirectorMethodisByColor;
			}
			if (SwigDerivedClassHasMethod("isByLayer", swigMethodTypes3))
			{
				swigDelegate3 = SwigDirectorMethodisByLayer;
			}
			if (SwigDerivedClassHasMethod("isByBlock", swigMethodTypes4))
			{
				swigDelegate4 = SwigDirectorMethodisByBlock;
			}
			if (SwigDerivedClassHasMethod("isByACI", swigMethodTypes5))
			{
				swigDelegate5 = SwigDirectorMethodisByACI;
			}
			if (SwigDerivedClassHasMethod("isForeground", swigMethodTypes6))
			{
				swigDelegate6 = SwigDirectorMethodisForeground;
			}
			if (SwigDerivedClassHasMethod("isByDgnIndex", swigMethodTypes7))
			{
				swigDelegate7 = SwigDirectorMethodisByDgnIndex;
			}
			if (SwigDerivedClassHasMethod("color", swigMethodTypes8))
			{
				swigDelegate8 = SwigDirectorMethodcolor;
			}
			if (SwigDerivedClassHasMethod("setColor", swigMethodTypes9))
			{
				swigDelegate9 = SwigDirectorMethodsetColor;
			}
			if (SwigDerivedClassHasMethod("setRGB", swigMethodTypes10))
			{
				swigDelegate10 = SwigDirectorMethodsetRGB;
			}
			if (SwigDerivedClassHasMethod("setRed", swigMethodTypes11))
			{
				swigDelegate11 = SwigDirectorMethodsetRed;
			}
			if (SwigDerivedClassHasMethod("setGreen", swigMethodTypes12))
			{
				swigDelegate12 = SwigDirectorMethodsetGreen;
			}
			if (SwigDerivedClassHasMethod("setBlue", swigMethodTypes13))
			{
				swigDelegate13 = SwigDirectorMethodsetBlue;
			}
			if (SwigDerivedClassHasMethod("red", swigMethodTypes14))
			{
				swigDelegate14 = SwigDirectorMethodred;
			}
			if (SwigDerivedClassHasMethod("green", swigMethodTypes15))
			{
				swigDelegate15 = SwigDirectorMethodgreen;
			}
			if (SwigDerivedClassHasMethod("blue", swigMethodTypes16))
			{
				swigDelegate16 = SwigDirectorMethodblue;
			}
			if (SwigDerivedClassHasMethod("colorIndex", swigMethodTypes17))
			{
				swigDelegate17 = SwigDirectorMethodcolorIndex;
			}
			if (SwigDerivedClassHasMethod("setColorIndex", swigMethodTypes18))
			{
				swigDelegate18 = SwigDirectorMethodsetColorIndex;
			}
			if (SwigDerivedClassHasMethod("setNames", swigMethodTypes19))
			{
				swigDelegate19 = SwigDirectorMethodsetNames__SWIG_0;
			}
			if (SwigDerivedClassHasMethod("setNames", swigMethodTypes20))
			{
				swigDelegate20 = SwigDirectorMethodsetNames__SWIG_1;
			}
			if (SwigDerivedClassHasMethod("colorName", swigMethodTypes21))
			{
				swigDelegate21 = SwigDirectorMethodcolorName;
			}
			if (SwigDerivedClassHasMethod("bookName", swigMethodTypes22))
			{
				swigDelegate22 = SwigDirectorMethodbookName;
			}
			if (SwigDerivedClassHasMethod("colorNameForDisplay", swigMethodTypes23))
			{
				swigDelegate23 = SwigDirectorMethodcolorNameForDisplay;
			}
			if (SwigDerivedClassHasMethod("hasColorName", swigMethodTypes24))
			{
				swigDelegate24 = SwigDirectorMethodhasColorName;
			}
			if (SwigDerivedClassHasMethod("hasBookName", swigMethodTypes25))
			{
				swigDelegate25 = SwigDirectorMethodhasBookName;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdCmColorBaseAdapt_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdCmColorBaseAdapt));
		}

		private int SwigDirectorMethodcolorMethod()
		{
			return (int)colorMethod();
		}

		private void SwigDirectorMethodsetColorMethod(int colorMethod)
		{
			try
			{
				setColorMethod((OdCmEntityColor_ColorMethod)colorMethod);
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

		private bool SwigDirectorMethodisByColor()
		{
			return isByColor();
		}

		private bool SwigDirectorMethodisByLayer()
		{
			return isByLayer();
		}

		private bool SwigDirectorMethodisByBlock()
		{
			return isByBlock();
		}

		private bool SwigDirectorMethodisByACI()
		{
			return isByACI();
		}

		private bool SwigDirectorMethodisForeground()
		{
			return isForeground();
		}

		private bool SwigDirectorMethodisByDgnIndex()
		{
			return isByDgnIndex();
		}

		private uint SwigDirectorMethodcolor()
		{
			return color();
		}

		private void SwigDirectorMethodsetColor(uint color)
		{
			try
			{
				setColor(color);
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

		private void SwigDirectorMethodsetRGB(byte red, byte green, byte blue)
		{
			try
			{
				setRGB(red, green, blue);
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

		private void SwigDirectorMethodsetRed(byte red)
		{
			try
			{
				setRed(red);
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

		private void SwigDirectorMethodsetGreen(byte green)
		{
			try
			{
				setGreen(green);
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

		private void SwigDirectorMethodsetBlue(byte blue)
		{
			try
			{
				setBlue(blue);
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

		private byte SwigDirectorMethodred()
		{
			return red();
		}

		private byte SwigDirectorMethodgreen()
		{
			return green();
		}

		private byte SwigDirectorMethodblue()
		{
			return blue();
		}

		private ushort SwigDirectorMethodcolorIndex()
		{
			return colorIndex();
		}

		private void SwigDirectorMethodsetColorIndex(ushort colorIndex)
		{
			try
			{
				setColorIndex(colorIndex);
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

		private bool SwigDirectorMethodsetNames__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string arg0, [MarshalAs(UnmanagedType.LPWStr)] string arg1)
		{
			return setNames(arg0, arg1);
		}

		private bool SwigDirectorMethodsetNames__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string arg0)
		{
			return setNames(arg0);
		}

		[return: MarshalAs(UnmanagedType.LPWStr)]
		private string SwigDirectorMethodcolorName()
		{
			return colorName();
		}

		[return: MarshalAs(UnmanagedType.LPWStr)]
		private string SwigDirectorMethodbookName()
		{
			return bookName();
		}

		[return: MarshalAs(UnmanagedType.LPWStr)]
		private string SwigDirectorMethodcolorNameForDisplay()
		{
			return colorNameForDisplay();
		}

		private bool SwigDirectorMethodhasColorName()
		{
			return hasColorName();
		}

		private bool SwigDirectorMethodhasBookName()
		{
			return hasBookName();
		}
	}

	public class OdGiFaceStyleDataContainer : OdStaticRxObject_OdGiFaceStyle
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiFaceStyleDataContainer(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiFaceStyleDataContainer obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public void setBase(OdGiVisualStyle pBase)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setBase(swigCPtr, OdGiVisualStyle.getCPtr(pBase));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiVisualStyle base_()
		{
			OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_base_(swigCPtr), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public new virtual void setLightingModel(OdGiFaceStyle_LightingModel lightingModel)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setLightingModel(swigCPtr, (int)lightingModel);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiFaceStyle_LightingModel lightingModel()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_lightingModel(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiFaceStyle_LightingModel)result;
		}

		public new virtual void setLightingQuality(OdGiFaceStyle_LightingQuality lightingQuality)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setLightingQuality(swigCPtr, (int)lightingQuality);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiFaceStyle_LightingQuality lightingQuality()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_lightingQuality(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiFaceStyle_LightingQuality)result;
		}

		public override void setFaceModifiers(uint nModifiers)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setFaceModifiers(swigCPtr, nModifiers);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new virtual void setFaceModifierFlag(OdGiFaceStyle_FaceModifier flag, bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setFaceModifierFlag(swigCPtr, (int)flag, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override uint faceModifiers()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_faceModifiers(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual bool isFaceModifierFlagSet(OdGiFaceStyle_FaceModifier flag)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_isFaceModifierFlagSet(swigCPtr, (int)flag);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setOpacityLevel(double nLevel, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setOpacityLevel(swigCPtr, nLevel, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override double opacityLevel()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_opacityLevel(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setSpecularAmount(double nAmount, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setSpecularAmount(swigCPtr, nAmount, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override double specularAmount()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_specularAmount(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setMonoColor(OdCmColorBase color, bool bEnableMode)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_setMonoColor(swigCPtr, OdCmColorBase.getCPtr(color), bEnableMode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdCmColorBase monoColor()
		{
			OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_monoColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		protected new static string getRealClassName(IntPtr ptr)
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiFaceStyleDataContainer_getRealClassName(ptr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class OdGiEdgeStyleDataContainer : OdStaticRxObject_OdGiEdgeStyle
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiEdgeStyleDataContainer(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiEdgeStyleDataContainer obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public void setBase(OdGiVisualStyle pBase)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setBase(swigCPtr, OdGiVisualStyle.getCPtr(pBase));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiVisualStyle base_()
		{
			OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_base_(swigCPtr), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public override void setEdgeStyles(uint nStyles)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeStyles(swigCPtr, nStyles);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new virtual void setEdgeStyleFlag(OdGiEdgeStyle_EdgeStyle flag, bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeStyleFlag(swigCPtr, (int)flag, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override uint edgeStyles()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_edgeStyles(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual bool isEdgeStyleFlagSet(OdGiEdgeStyle_EdgeStyle flag)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_isEdgeStyleFlagSet(swigCPtr, (int)flag);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setIntersectionColor(OdCmColorBase color)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setIntersectionColor(swigCPtr, OdCmColorBase.getCPtr(color));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdCmColorBase intersectionColor()
		{
			OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_intersectionColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setObscuredColor(OdCmColorBase color)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setObscuredColor(swigCPtr, OdCmColorBase.getCPtr(color));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdCmColorBase obscuredColor()
		{
			OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_obscuredColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual void setObscuredLinetype(OdGiEdgeStyle_LineType ltype)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setObscuredLinetype(swigCPtr, (int)ltype);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiEdgeStyle_LineType obscuredLinetype()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_obscuredLinetype(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiEdgeStyle_LineType)result;
		}

		public new virtual void setIntersectionLinetype(OdGiEdgeStyle_LineType ltype)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setIntersectionLinetype(swigCPtr, (int)ltype);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiEdgeStyle_LineType intersectionLinetype()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_intersectionLinetype(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiEdgeStyle_LineType)result;
		}

		public override void setCreaseAngle(double nAngle)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setCreaseAngle(swigCPtr, nAngle);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override double creaseAngle()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_creaseAngle(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setEdgeModifiers(uint nModifiers)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeModifiers(swigCPtr, nModifiers);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new virtual void setEdgeModifierFlag(OdGiEdgeStyle_EdgeModifier flag, bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeModifierFlag(swigCPtr, (int)flag, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override uint edgeModifiers()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_edgeModifiers(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual bool isEdgeModifierFlagSet(OdGiEdgeStyle_EdgeModifier flag)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_isEdgeModifierFlagSet(swigCPtr, (int)flag);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setEdgeColor(OdCmColorBase color, bool arg1)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeColor(swigCPtr, OdCmColorBase.getCPtr(color), arg1);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdCmColorBase edgeColor()
		{
			OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_edgeColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setOpacityLevel(double nLevel, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setOpacityLevel(swigCPtr, nLevel, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override double opacityLevel()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_opacityLevel(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setEdgeWidth(int nWidth, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeWidth(swigCPtr, nWidth, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override int edgeWidth()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_edgeWidth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setOverhangAmount(int nAmount, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setOverhangAmount(swigCPtr, nAmount, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override int overhangAmount()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_overhangAmount(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual void setJitterAmount(OdGiEdgeStyle_JitterAmount amount, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setJitterAmount(swigCPtr, (int)amount, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiEdgeStyle_JitterAmount jitterAmount()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_jitterAmount(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiEdgeStyle_JitterAmount)result;
		}

		public new virtual void setWiggleAmount(OdGiEdgeStyle_WiggleAmount amount, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setWiggleAmount(swigCPtr, (int)amount, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiEdgeStyle_WiggleAmount wiggleAmount()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_wiggleAmount(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiEdgeStyle_WiggleAmount)result;
		}

		public override void setSilhouetteColor(OdCmColorBase color)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setSilhouetteColor(swigCPtr, OdCmColorBase.getCPtr(color));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdCmColorBase silhouetteColor()
		{
			OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_silhouetteColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setSilhouetteWidth(short nWidth)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setSilhouetteWidth(swigCPtr, nWidth);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override short silhouetteWidth()
		{
			short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_silhouetteWidth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setHaloGap(int nHaloGap, bool bEnableModifier)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setHaloGap(swigCPtr, nHaloGap, bEnableModifier);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override int haloGap()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_haloGap(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setIsolines(ushort nIsolines)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setIsolines(swigCPtr, nIsolines);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override ushort isolines()
		{
			ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_isolines(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setHidePrecision(bool bHidePrecision)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setHidePrecision(swigCPtr, bHidePrecision);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override bool hidePrecision()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_hidePrecision(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual void setEdgeStyleApply(OdGiEdgeStyle_EdgeStyleApply apply)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_setEdgeStyleApply(swigCPtr, (int)apply);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiEdgeStyle_EdgeStyleApply edgeStyleApply()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_edgeStyleApply(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiEdgeStyle_EdgeStyleApply)result;
		}

		protected new static string getRealClassName(IntPtr ptr)
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiEdgeStyleDataContainer_getRealClassName(ptr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class OdGiDisplayStyleDataContainer : OdStaticRxObject_OdGiDisplayStyle
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGiDisplayStyleDataContainer(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGiDisplayStyleDataContainer obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public void setBase(OdGiVisualStyle pBase)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_setBase(swigCPtr, OdGiVisualStyle.getCPtr(pBase));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiVisualStyle base_()
		{
			OdGiVisualStyle rXObject = Helpers.GetRXObject<OdGiVisualStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_base_(swigCPtr), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}

		public override void setDisplaySettings(uint nSettings)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_setDisplaySettings(swigCPtr, nSettings);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new virtual void setDisplaySettingsFlag(OdGiDisplayStyle_DisplaySettings flag, bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_setDisplaySettingsFlag(swigCPtr, (int)flag, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override uint displaySettings()
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_displaySettings(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual bool isDisplaySettingsFlagSet(OdGiDisplayStyle_DisplaySettings flag)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_isDisplaySettingsFlagSet(swigCPtr, (int)flag);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public override void setBrightness(double value)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_setBrightness(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override double brightness()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_brightness(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new virtual void setShadowType(OdGiDisplayStyle_ShadowType type)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_setShadowType(swigCPtr, (int)type);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public override OdGiDisplayStyle_ShadowType shadowType()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_shadowType(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiDisplayStyle_ShadowType)result;
		}

		protected new static string getRealClassName(IntPtr ptr)
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_OdGiDisplayStyleDataContainer_getRealClassName(ptr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVisualStyleDataContainer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVisualStyleDataContainer obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVisualStyleDataContainer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGiFaceStyle faceStyle()
	{
		OdGiFaceStyle rXObject = Helpers.GetRXObject<OdGiFaceStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_faceStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiEdgeStyle edgeStyle()
	{
		OdGiEdgeStyle rXObject = Helpers.GetRXObject<OdGiEdgeStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_edgeStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiDisplayStyle displayStyle()
	{
		OdGiDisplayStyle rXObject = Helpers.GetRXObject<OdGiDisplayStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_displayStyle__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setFaceStyle(OdGiFaceStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setFaceStyle(swigCPtr, OdGiFaceStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setEdgeStyle(OdGiEdgeStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setEdgeStyle(swigCPtr, OdGiEdgeStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setDisplayStyle(OdGiDisplayStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setDisplayStyle(swigCPtr, OdGiDisplayStyle.getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool setType(OdGiVisualStyle_Type type)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGiVisualStyle_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualStyle_Type)result;
	}

	public new virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setTrait__SWIG_0(swigCPtr, (int)prop, (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVariant pVal, OdGiVisualStyleOperations_Operation op)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setTrait__SWIG_1(swigCPtr, (int)prop, OdGiVariant.getCPtr(pVal), (int)op);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool setTrait(OdGiVisualStyleProperties_Property prop, OdGiVariant pVal)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_setTrait__SWIG_2(swigCPtr, (int)prop, OdGiVariant.getCPtr(pVal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiVariant trait(OdGiVisualStyleProperties_Property prop, out OdGiVisualStyleOperations_Operation pOp)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_trait__SWIG_0(swigCPtr, (int)prop, out pOp), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGiVariant trait(OdGiVisualStyleProperties_Property prop)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_trait__SWIG_1(swigCPtr, (int)prop), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGiVisualStyleOperations_Operation operation(OdGiVisualStyleProperties_Property prop)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_operation(swigCPtr, (int)prop);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVisualStyleOperations_Operation)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVisualStyleDataContainer_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
