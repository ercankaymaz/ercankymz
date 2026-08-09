using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTextProperties : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const int kNormalText = 1;

	public const int kVerticalText = 2;

	public const int kUnderlined = 4;

	public const int kOverlined = 8;

	public const int kLastChar = 16;

	public const int kInBigFont = 32;

	public const int kInclPenups = 64;

	public const int kZeroNormals = 128;

	public const int kBezierCurves = 256;

	public const int kStriked = 512;

	public const int kLastPosOnly = 1024;

	public const int kTriangleCache = 2048;

	public const int kIsGlyph = 4096;

	public const int kForMTextExtents = 8192;

	public const int kAlignToGrid = 16384;

	public double m_trackingPercent
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_trackingPercent_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_trackingPercent_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort m_flags
	{
		get
		{
			ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_flags_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_flags_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public ushort m_textQuality
	{
		get
		{
			ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_textQuality_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_textQuality_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public char m_prevChar
	{
		get
		{
			char result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_prevChar_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_prevChar_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double m_dTextSizeWoScale
	{
		get
		{
			double result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_dTextSizeWoScale_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_m_dTextSizeWoScale_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdTextProperties(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdTextProperties obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdTextProperties()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTextProperties(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdTextProperties()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTextProperties(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNormalText()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isNormalText(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNormalText(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setNormalText(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isVerticalText()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isVerticalText(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVerticalText(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setVerticalText(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUnderlined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isUnderlined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUnderlined(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setUnderlined(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isOverlined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isOverlined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOverlined(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setOverlined(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isStriked()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isStriked(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStriked(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setStriked(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLastChar()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isLastChar(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLastChar(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setLastChar(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isInBigFont()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isInBigFont(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInBigFont(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setInBigFont(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isIncludePenups()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isIncludePenups(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIncludePenups(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setIncludePenups(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isZeroNormals()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isZeroNormals(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setZeroNormals(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setZeroNormals(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ttfPolyDraw()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_ttfPolyDraw(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTtfPolyDraw(bool bFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setTtfPolyDraw(swigCPtr, bFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double trackingPercent()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_trackingPercent(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTrackingPercent(double trackingPercent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setTrackingPercent(swigCPtr, trackingPercent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint textQuality()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_textQuality(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextQuality(uint val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setTextQuality(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isTriangleCache()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isTriangleCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSetTriangleCache(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setSetTriangleCache(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLastPosOnly()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isLastPosOnly(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setLastPosOnly(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setLastPosOnly(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isGlyph()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isGlyph(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGlyph(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setGlyph(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isForMTextExtents()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isForMTextExtents(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForMTextExtents(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setForMTextExtents(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAlignToGrid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_isAlignToGrid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlignToGrid(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setAlignToGrid(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double textSizeWoScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_textSizeWoScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTextSizeWoScale(double textSizeWoScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextProperties_setTextSizeWoScale(swigCPtr, textSizeWoScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
