using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetypeDash : IDisposable
{
	public class DashInfo : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint m_uFlags
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_uFlags_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_uFlags_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dLength
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dLength_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dLength_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dStartWidth
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dStartWidth_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dStartWidth_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dEndWidth
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dEndWidth_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_dEndWidth_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiDgLinetypeDash_DashInfo_StrokeWidthMode m_lsWidthMode
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_lsWidthMode_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiDgLinetypeDash_DashInfo_StrokeWidthMode)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_lsWidthMode_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiDgLinetypeDash_DashInfo_StrokeCapsType m_lsCapsType
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_lsCapsType_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiDgLinetypeDash_DashInfo_StrokeCapsType)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_m_lsCapsType_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DashInfo(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(DashInfo obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~DashInfo()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeDash_DashInfo(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public DashInfo()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDash_DashInfo(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public double getLength()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getLength(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setLength(double dLength)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setLength(swigCPtr, dLength);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public double getStartWidth()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getStartWidth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setStartWidth(double dWidth)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setStartWidth(swigCPtr, dWidth);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public double getEndWidth()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getEndWidth(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setEndWidth(double dWidth)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setEndWidth(swigCPtr, dWidth);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getDashFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getDashFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setDashFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setDashFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getByPassCornerFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getByPassCornerFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setByPassCornerFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setByPassCornerFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getCanBeScaledFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getCanBeScaledFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setCanBeScaledFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setCanBeScaledFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getInvertStrokeInFirstCodeFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getInvertStrokeInFirstCodeFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setInvertStrokeInFirstCodeFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setInvertStrokeInFirstCodeFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getInvertStrokeInLastCodeFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getInvertStrokeInLastCodeFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setInvertStrokeInLastCodeFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setInvertStrokeInLastCodeFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiDgLinetypeDash_DashInfo_StrokeWidthMode getWidthMode()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getWidthMode(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiDgLinetypeDash_DashInfo_StrokeWidthMode)result;
		}

		public void setWidthMode(OdGiDgLinetypeDash_DashInfo_StrokeWidthMode iMode)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setWidthMode(swigCPtr, (int)iMode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getIncreasingTaperFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getIncreasingTaperFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setIncreasingTaperFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setIncreasingTaperFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getDecreasingTaperFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getDecreasingTaperFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setDecreasingTaperFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setDecreasingTaperFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getBaseStrokeDashFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getBaseStrokeDashFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setBaseStrokeDashFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setBaseStrokeDashFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool isDashOrBaseStrokeDash()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_isDashOrBaseStrokeDash(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public OdGiDgLinetypeDash_DashInfo_StrokeCapsType getCapsType()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_getCapsType(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiDgLinetypeDash_DashInfo_StrokeCapsType)result;
		}

		public void setCapsType(OdGiDgLinetypeDash_DashInfo_StrokeCapsType iType)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_DashInfo_setCapsType(swigCPtr, (int)iType);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class ShapeInfo : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint m_uFlags
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_uFlags_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_uFlags_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdDbStub m_pSymbol
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_pSymbol_get(swigCPtr);
				OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_pSymbol_set(swigCPtr, OdDbStub.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke m_lsPos
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_lsPos_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_lsPos_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdGiLinetypeDash.offset m_offset
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_offset_get(swigCPtr);
				OdGiLinetypeDash.offset result = ((intPtr == IntPtr.Zero) ? null : new OdGiLinetypeDash.offset(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_offset_set(swigCPtr, OdGiLinetypeDash.offset.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dRotation
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_dRotation_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_dRotation_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double m_dScale
		{
			get
			{
				double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_dScale_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_m_dScale_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ShapeInfo(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ShapeInfo obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ShapeInfo()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeDash_ShapeInfo(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public ShapeInfo()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDash_ShapeInfo(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdDbStub getSymbolId()
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolId(swigCPtr);
			OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setSymbolId(OdDbStub pStub)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolId(swigCPtr, OdDbStub.getCPtr(pStub));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke getSymbolPosOnStroke()
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolPosOnStroke(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke)result;
		}

		public void setSymbolPosOnStroke(OdGiDgLinetypeDash_ShapeInfo_SymbolPosOnStroke iMode)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolPosOnStroke(swigCPtr, (int)iMode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getSymbolAtElementOriginFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolAtElementOriginFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setSymbolAtElementOriginFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolAtElementOriginFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getSymbolAtElementEndFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolAtElementEndFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setSymbolAtElementEndFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolAtElementEndFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getSymbolAtEachVertexFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolAtEachVertexFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setSymbolAtEachVertexFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolAtEachVertexFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getMirrorSymbolForReversedLinesFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getMirrorSymbolForReversedLinesFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setMirrorSymbolForReversedLinesFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setMirrorSymbolForReversedLinesFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getAbsoluteRotationAngleFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getAbsoluteRotationAngleFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setAbsoluteRotationAngleFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setAbsoluteRotationAngleFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getDoNotScaleElementFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getDoNotScaleElementFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setDoNotScaleElementFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setDoNotScaleElementFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getDoNotClipElementFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getDoNotClipElementFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setDoNotClipElementFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setDoNotClipElementFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getNoPartialStrokesFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getNoPartialStrokesFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setNoPartialStrokesFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setNoPartialStrokesFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getPartialOriginBeyondEndFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getPartialOriginBeyondEndFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setPartialOriginBeyondEndFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setPartialOriginBeyondEndFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getUseSymbolColorFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getUseSymbolColorFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setUseSymbolColorFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setUseSymbolColorFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public bool getUseSymbolWeightFlag()
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getUseSymbolWeightFlag(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setUseSymbolWeightFlag(bool bSet)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setUseSymbolWeightFlag(swigCPtr, bSet);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void getOffset(out double x, out double y)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getOffset(swigCPtr, out x, out y);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void setOffset(double x, double y)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setOffset(swigCPtr, x, y);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public double getRotationAngle()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getRotationAngle(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setRotationAngle(double dRotAngle)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setRotationAngle(swigCPtr, dRotAngle);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public double getSymbolScale()
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_getSymbolScale(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setSymbolScale(double dScale)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_ShapeInfo_setSymbolScale(swigCPtr, dScale);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public DashInfo m_dash
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_m_dash_get(swigCPtr);
			DashInfo result = ((intPtr == IntPtr.Zero) ? null : new DashInfo(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_m_dash_set(swigCPtr, DashInfo.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ShapeInfo m_shape
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_m_shape_get(swigCPtr);
			ShapeInfo result = ((intPtr == IntPtr.Zero) ? null : new ShapeInfo(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDash_m_shape_set(swigCPtr, ShapeInfo.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetypeDash(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetypeDash obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDgLinetypeDash()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeDash(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiDgLinetypeDash()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDash(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
