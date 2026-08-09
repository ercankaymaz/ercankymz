using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSelectionStyle : IDisposable
{
	public class ColorMask : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ColorMask(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ColorMask obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ColorMask()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectionStyle_ColorMask(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public ColorMask()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectionStyle_ColorMask(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setColor(OdCmEntityColor color)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_setColor__SWIG_0(swigCPtr, OdCmEntityColor.getCPtr(color));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdCmEntityColor color()
		{
			OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_color(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setTransparency(byte transparency)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_setTransparency(swigCPtr, transparency);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public byte transparency()
		{
			byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_transparency(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setColor(OdCmEntityColor color, byte transparency)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_setColor__SWIG_1(swigCPtr, OdCmEntityColor.getCPtr(color), transparency);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isVisible()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_isVisible(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isOpaque()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_isOpaque(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void reset()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_reset(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool IsEqual(ColorMask cm2)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_IsEqual(swigCPtr, getCPtr(cm2));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool IsNotEqual(ColorMask cm2)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ColorMask_IsNotEqual(swigCPtr, getCPtr(cm2));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class ElementStyle : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ElementStyle(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ElementStyle obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ElementStyle()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectionStyle_ElementStyle(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public ElementStyle()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectionStyle_ElementStyle(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setVisible(bool bVisible)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setVisible(swigCPtr, bVisible);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isVisible()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_isVisible(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void enablePattern(bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_enablePattern(swigCPtr, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isPatternEnabled()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_isPatternEnabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setPatternBehavior(OdGiSelectionStyle_ElementStyle_PatternBehavior behavior)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setPatternBehavior(swigCPtr, (int)behavior);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiSelectionStyle_ElementStyle_PatternBehavior patternBehavior()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_patternBehavior(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiSelectionStyle_ElementStyle_PatternBehavior)result;
		}

		public void enableColorMasking(bool bEnable)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_enableColorMasking(swigCPtr, bEnable);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isColorMaskingEnabled()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_isColorMaskingEnabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ColorMask colorMask()
		{
			ColorMask result = new ColorMask(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_colorMask__SWIG_0(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isOnTopOfDepth()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_isOnTopOfDepth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool hasEffect()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_hasEffect(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setByDefault()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setByDefault(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setAsDisabled()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setAsDisabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForStippling()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setForStippling(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForColorMasking()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_setForColorMasking(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool IsEqual(ElementStyle secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_IsEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool IsNotEqual(ElementStyle secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_ElementStyle_IsNotEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class EdgeStyle : ElementStyle
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EdgeStyle(IntPtr cPtr, bool cMemoryOwn)
			: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(EdgeStyle obj)
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectionStyle_EdgeStyle(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				base.Dispose(disposing);
			}
		}

		public EdgeStyle()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectionStyle_EdgeStyle(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setMode(OdGiSelectionStyle_EdgeStyle_Mode edgeMode)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setMode(swigCPtr, (int)edgeMode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiSelectionStyle_EdgeStyle_Mode mode()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_mode(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiSelectionStyle_EdgeStyle_Mode)result;
		}

		public void setLineWeightExtension(int nLwdExtension)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setLineWeightExtension(swigCPtr, nLwdExtension);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public int lineWeightExtension()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_lineWeightExtension(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool hasLineWeightExtension()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_hasLineWeightExtension(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new bool hasEffect()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_hasEffect(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public new void setByDefault()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setByDefault(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new void setAsDisabled()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setAsDisabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new void setForStippling()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setForStippling(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public new void setForColorMasking()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_setForColorMasking(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool IsEqual(EdgeStyle secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_IsEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool IsNotEqual(EdgeStyle secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_EdgeStyle_IsNotEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	public class StyleEntry : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StyleEntry(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(StyleEntry obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~StyleEntry()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectionStyle_StyleEntry(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public EdgeStyle edgeStyle()
		{
			EdgeStyle result = new EdgeStyle(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_edgeStyle__SWIG_0(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ElementStyle faceStyle()
		{
			ElementStyle result = new ElementStyle(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_faceStyle__SWIG_0(swigCPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isOnTopOfDepth()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_isOnTopOfDepth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool isVisible()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_isVisible(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool hasEffect()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_hasEffect(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setByDefault()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setByDefault(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setAsDisabled()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setAsDisabled(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForStippling()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setForStippling__SWIG_0(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForColorMasking()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setForColorMasking__SWIG_0(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForColorMasking(OdCmEntityColor color, byte transparency)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setForColorMasking__SWIG_1(swigCPtr, OdCmEntityColor.getCPtr(color), transparency);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setForStippling(OdGiSelectionStyle_ElementStyle_PatternBehavior behavior)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_setForStippling__SWIG_1(swigCPtr, (int)behavior);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool IsEqual(StyleEntry secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_IsEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public bool IsNotEqual(StyleEntry secStyle)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_StyleEntry_IsNotEqual(swigCPtr, getCPtr(secStyle));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public StyleEntry()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectionStyle_StyleEntry(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSelectionStyle(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSelectionStyle obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiSelectionStyle()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSelectionStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiSelectionStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSelectionStyle(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StyleEntry styleFor(bool bDrawOnTop, bool bDrawIn3d)
	{
		StyleEntry result = new StyleEntry(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_styleFor__SWIG_0(swigCPtr, bDrawOnTop, bDrawIn3d), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public StyleEntry styleFor(bool bDrawOnTop)
	{
		StyleEntry result = new StyleEntry(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_styleFor__SWIG_1(swigCPtr, bDrawOnTop), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public StyleEntry styleFor()
	{
		StyleEntry result = new StyleEntry(TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_styleFor__SWIG_2(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void sync3d()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_sync3d(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void sync2d()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_sync2d(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void exchangeTopBottom(bool bFor2d, bool bFor3d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_exchangeTopBottom__SWIG_0(swigCPtr, bFor2d, bFor3d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void exchangeTopBottom(bool bFor2d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_exchangeTopBottom__SWIG_1(swigCPtr, bFor2d);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void exchangeTopBottom()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_exchangeTopBottom__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOnTopOfDepth(bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_setOnTopOfDepth(swigCPtr, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isOnTopOfDepth()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_isOnTopOfDepth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByDefault()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_setByDefault(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAsDisabled()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_setAsDisabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setForStippling()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_setForStippling(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setForColorMasking()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSelectionStyle_setForColorMasking(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
