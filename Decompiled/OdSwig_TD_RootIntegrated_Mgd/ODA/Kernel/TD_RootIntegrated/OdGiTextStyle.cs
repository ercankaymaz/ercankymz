using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiTextStyle : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public const int kShape = 1;

	public const int kUpsideDown = 2;

	public const int kVertical = 4;

	public const int kUnderlined = 8;

	public const int kOverlined = 16;

	public const int kShxFont = 32;

	public const int kPreLoaded = 64;

	public const int kBackward = 128;

	public const int kShapeLoaded = 256;

	public const int kStriked = 512;

	public const int kUseIntercharSpacing = 1024;

	public const int kFixedIntercharSpacing = 2048;

	public const int kNoUsePreferableFont = 4096;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiTextStyle(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiTextStyle obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiTextStyle()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiTextStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public void setShapeLoaded(bool shapeLoaded)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setShapeLoaded(swigCPtr, shapeLoaded);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isShapeLoaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isShapeLoaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiTextStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiTextStyle(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(string fontName, string bigFontName, double textSize, double xScale, double obliquingAngle, double trackingPercent, bool isBackward, bool isUpsideDown, bool isVertical, bool isOverlined, bool isUnderlined, double textSizeWoScale, bool alignToGrid)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_set__SWIG_0(swigCPtr, fontName, bigFontName, textSize, xScale, obliquingAngle, trackingPercent, isBackward, isUpsideDown, isVertical, isOverlined, isUnderlined, textSizeWoScale, alignToGrid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(string fontName, string bigFontName, double textSize, double xScale, double obliquingAngle, double trackingPercent, bool isBackward, bool isUpsideDown, bool isVertical, bool isOverlined, bool isUnderlined, double textSizeWoScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_set__SWIG_1(swigCPtr, fontName, bigFontName, textSize, xScale, obliquingAngle, trackingPercent, isBackward, isUpsideDown, isVertical, isOverlined, isUnderlined, textSizeWoScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(string fontName, string bigFontName, double textSize, double xScale, double obliquingAngle, double trackingPercent, bool isBackward, bool isUpsideDown, bool isVertical, bool isOverlined, bool isUnderlined)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_set__SWIG_2(swigCPtr, fontName, bigFontName, textSize, xScale, obliquingAngle, trackingPercent, isBackward, isUpsideDown, isVertical, isOverlined, isUnderlined);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadStyleRec(OdRxObject pDb)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_loadStyleRec(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getFontFilePath(OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getFontFilePath(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getBigFontFilePath(OdRxObject pDb)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getBigFontFilePath(swigCPtr, OdRxObject.getCPtr(pDb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFontFilePath(string fontFilePath)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setFontFilePath(swigCPtr, fontFilePath);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBigFontFilePath(string bigFontFilePath)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setBigFontFilePath(swigCPtr, bigFontFilePath);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextSize(double textSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setTextSize(swigCPtr, textSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextSizeWoScale(double textSizeWoScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setTextSizeWoScale(swigCPtr, textSizeWoScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAlignToGrid(bool alignToGrid)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setAlignToGrid(swigCPtr, alignToGrid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setXScale(double xScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setXScale(swigCPtr, xScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setObliquingAngle(double obliquingAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setObliquingAngle(swigCPtr, obliquingAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTrackingPercent(double trackingPercent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setTrackingPercent(swigCPtr, trackingPercent);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBackward(bool isBackward)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setBackward(swigCPtr, isBackward);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUpsideDown(bool isUpsideDown)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setUpsideDown(swigCPtr, isUpsideDown);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setVertical(bool isVertical)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setVertical(swigCPtr, isVertical);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUnderlined(bool isUnderlined)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setUnderlined(swigCPtr, isUnderlined);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOverlined(bool isOverlined)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setOverlined(swigCPtr, isOverlined);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setStriked(bool isStriked)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setStriked(swigCPtr, isStriked);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPreLoaded(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setPreLoaded(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShxFont(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setShxFont(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFileName(string fontFileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setFileName(swigCPtr, fontFileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBigFontFileName(string bigFontFileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setBigFontFileName(swigCPtr, bigFontFileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isBackward()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isBackward(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUpsideDown()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isUpsideDown(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isVertical()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isVertical(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isUnderlined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isUnderlined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOverlined()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isOverlined(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isStriked()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isStriked(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPreLoaded()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isPreLoaded(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isShxFont()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isShxFont(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isTtfFont()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isTtfFont(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsShape(bool isShape)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setIsShape(swigCPtr, isShape);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isShape()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isShape(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFont(string typeface, bool bold, bool italic, int charset, int pitchAndFamily)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setFont__SWIG_0(swigCPtr, typeface, bold, italic, charset, pitchAndFamily);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFont(OdFont font)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setFont__SWIG_1(swigCPtr, OdFont.getCPtr(font));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBigFont(OdFont pBigFont)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setBigFont(swigCPtr, OdFont.getCPtr(pBigFont));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void font(ref string typeface, out bool bold, out bool italic, out int charset, out int pitchAndFamily)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(typeface);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_font(swigCPtr, ref jarg, out bold, out italic, out charset, out pitchAndFamily);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				typeface = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public OdFont getFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getFont(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFont getBigFont()
	{
		OdFont rXObject = Helpers.GetRXObject<OdFont>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getBigFont(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdTtfDescriptor ttfdescriptor()
	{
		OdTtfDescriptor result = new OdTtfDescriptor(TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_ttfdescriptor__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string bigFontFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_bigFontFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double textSize()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_textSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double textSizeWoScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_textSizeWoScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isAlignToGrid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isAlignToGrid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double xScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_xScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double obliquingAngle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_obliquingAngle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double trackingPercent()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_trackingPercent(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCodePageId getCodePage()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getCodePage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public void setCodePage(OdCodePageId codePage)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setCodePage(swigCPtr, (int)codePage);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string styleName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_styleName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setStyleName(string name)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setStyleName(swigCPtr, name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIsUseIntercharSpacing(bool isUseIntercharSpacing)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setIsUseIntercharSpacing(swigCPtr, isUseIntercharSpacing);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUseIntercharSpacing()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isUseIntercharSpacing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIsFixedIntercharSpacing(bool isUseIntercharSpacing)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setIsFixedIntercharSpacing(swigCPtr, isUseIntercharSpacing);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isFixedIntercharSpacing()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isFixedIntercharSpacing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getIntercharSpacing()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_getIntercharSpacing(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIntercharSpacing(double dSpacing)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setIntercharSpacing(swigCPtr, dSpacing);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setNoUsePreferableFont(bool isUsePreferableFont)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_setNoUsePreferableFont(swigCPtr, isUsePreferableFont);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNoUsePreferableFont()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTextStyle_isNoUsePreferableFont(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
