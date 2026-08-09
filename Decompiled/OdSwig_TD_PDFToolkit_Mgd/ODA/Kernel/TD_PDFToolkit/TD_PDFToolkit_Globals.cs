using System;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDFToolkit_Globals
{
	public static readonly uint UINT_MAX = TD_PDFToolkit_GlobalsPINVOKE.UINT_MAX_get();

	public static readonly uint ULONG_MAX = TD_PDFToolkit_GlobalsPINVOKE.ULONG_MAX_get();

	public static readonly int _MSC_VER = TD_PDFToolkit_GlobalsPINVOKE._MSC_VER_get();

	public static readonly int ODCHAR_IS_INT16LE = TD_PDFToolkit_GlobalsPINVOKE.ODCHAR_IS_INT16LE_get();

	public static readonly int OD_SIZEOF_INT = TD_PDFToolkit_GlobalsPINVOKE.OD_SIZEOF_INT_get();

	public static readonly int OD_SIZEOF_LONG = TD_PDFToolkit_GlobalsPINVOKE.OD_SIZEOF_LONG_get();

	public static readonly string PERCENT18LONG = TD_PDFToolkit_GlobalsPINVOKE.PERCENT18LONG_get();

	public static readonly string HANDLEFORMAT = TD_PDFToolkit_GlobalsPINVOKE.HANDLEFORMAT_get();

	public static readonly string PRId64 = TD_PDFToolkit_GlobalsPINVOKE.PRId64_get();

	public static readonly string PRIu64 = TD_PDFToolkit_GlobalsPINVOKE.PRIu64_get();

	public static readonly string PRIx64 = TD_PDFToolkit_GlobalsPINVOKE.PRIx64_get();

	public static readonly string PRIX64 = TD_PDFToolkit_GlobalsPINVOKE.PRIX64_get();

	public static readonly int OD_SIZEOF_PTR = TD_PDFToolkit_GlobalsPINVOKE.OD_SIZEOF_PTR_get();

	public const int ODPDF_DEFAULT_FONT_WIDTH = 1000;

	public const string PDF_FROZEN_LAYER = "||frozen";

	public const int PDF_FROZEN_LAYER_SIZE = 8;

	public const string PDF_VPFROZEN_LAYER = "_VpFrozen";

	public const int CROP_ZEROES_FOR_ALL = 6;

	public const int CROP_ZEROES_FOR_RGB = 6;

	public const int FORMAT_BUF_LEN = 512;

	public const string SUBSET_PREFIX = "AAAAAA+";

	public static void throw_native_exception_string(string msg)
	{
		TD_PDFToolkit_GlobalsPINVOKE.throw_native_exception_string(msg);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdEmptyInput err)
	{
		TD_PDFToolkit_GlobalsPINVOKE.throw_native_OdError__SWIG_0(OdEdEmptyInput.getCPtr(err));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdEdOtherInput err)
	{
		TD_PDFToolkit_GlobalsPINVOKE.throw_native_OdError__SWIG_1(OdEdOtherInput.getCPtr(err));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void throw_native_OdError(OdError err)
	{
		TD_PDFToolkit_GlobalsPINVOKE.throw_native_OdError__SWIG_2(OdError.getCPtr(err));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_getUnicodeTextString(string pStr, TD_PDF_PDFTextString pUnicodeStr)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_getUnicodeTextString(pStr, TD_PDF_PDFTextString.getCPtr(pUnicodeStr));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static TD_PDF_PDFObject TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sTitle, TD_PDF_TD_PDF_HELPER_FUNCS_BookmarkTypes type, OdDoubleValuesArray values, TD_PDF_PDFObject pParentItem)
	{
		TD_PDF_PDFObject result = Helpers.GetObject<TD_PDF_PDFObject>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_0(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sTitle, (int)type, OdDoubleValuesArray.getCPtr(values), TD_PDF_PDFObject.getCPtr(pParentItem)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFObject TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sTitle, TD_PDF_TD_PDF_HELPER_FUNCS_BookmarkTypes type, OdDoubleValuesArray values)
	{
		TD_PDF_PDFObject result = Helpers.GetObject<TD_PDF_PDFObject>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_CreateBookmark__SWIG_1(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sTitle, (int)type, OdDoubleValuesArray.getCPtr(values)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sParent, OdStringArray childs, OdGePoint3dArray childExt, TD_PDF_PDFObject pParentItem)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_0(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sParent, OdStringArray.getCPtr(childs).Handle, OdGePoint3dArray.getCPtr(childExt).Handle, TD_PDF_PDFObject.getCPtr(pParentItem));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sParent, OdStringArray childs, OdGePoint3dArray childExt)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_1(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sParent, OdStringArray.getCPtr(childs).Handle, OdGePoint3dArray.getCPtr(childExt).Handle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sParent, OdStringArray childs)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_2(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sParent, OdStringArray.getCPtr(childs).Handle);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sParent)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateBookmarksTree__SWIG_3(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sParent);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateChildrenBookmarksTree(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, OdStringArray childs, OdGePoint3dArray childExt, TD_PDF_PDFObject pParentItem)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateChildrenBookmarksTree(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), OdStringArray.getCPtr(childs).Handle, OdGePoint3dArray.getCPtr(childExt).Handle, TD_PDF_PDFObject.getCPtr(pParentItem));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_UpdateThumbnails(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFPageDictionary currentPage, string sName, bool bUseThumbs)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_UpdateThumbnails(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFPageDictionary.getCPtr(currentPage), sName, bUseThumbs);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool TD_PDF_TD_PDF_HELPER_FUNCS_QPDFHelper_process(ref OdStreamBuf inStream, ref OdStreamBuf outStream, bool linearize, string user_password, string owner_password, TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams access_permission_params, TD_PDF_PDFVersion version)
	{
		IntPtr jarg = ((inStream == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(inStream).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((outStream == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(outStream).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_QPDFHelper_process(ref jarg, ref jarg2, linearize, user_password, owner_password, TD_PDF_TD_PDF_HELPER_FUNCS_PDFAccessPermissionsParams.getCPtr(access_permission_params), TD_PDF_PDFVersion.getCPtr(version));
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				inStream = null;
			}
			else if (jarg != intPtr)
			{
				inStream = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				outStream = null;
			}
			else if (jarg2 != intPtr2)
			{
				outStream = Helpers.GetRXObject<OdStreamBuf>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage(OdGiRasterImage pRaster, TD_PDF_PDFImage pImage, bool bTransparency, double brightness, double contrast, double fade, uint entityColor, TD_PDF_PDFDocument PDFDoc, uint bgColor, ushort quality, TD_PDF_PDFResourceDictionary pResDict, bool bTransparencyMaskMode)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_0(OdGiRasterImage.getCPtr(pRaster), TD_PDF_PDFImage.getCPtr(pImage), bTransparency, brightness, contrast, fade, entityColor, TD_PDF_PDFDocument.getCPtr(PDFDoc), bgColor, quality, TD_PDF_PDFResourceDictionary.getCPtr(pResDict), bTransparencyMaskMode);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage(OdGiRasterImage pRaster, TD_PDF_PDFImage pImage, bool bTransparency, double brightness, double contrast, double fade, uint entityColor, TD_PDF_PDFDocument PDFDoc, uint bgColor, ushort quality, TD_PDF_PDFResourceDictionary pResDict)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_dcImageToPdfImage__SWIG_1(OdGiRasterImage.getCPtr(pRaster), TD_PDF_PDFImage.getCPtr(pImage), bTransparency, brightness, contrast, fade, entityColor, TD_PDF_PDFDocument.getCPtr(PDFDoc), bgColor, quality, TD_PDF_PDFResourceDictionary.getCPtr(pResDict));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static TD_PDF_PDFImage TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary pResDict, bool bMask, bool bGrayscaleMask)
	{
		TD_PDF_PDFImage result = Helpers.GetObject<TD_PDF_PDFImage>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_0(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(pResDict), bMask, bGrayscaleMask), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFImage TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary pResDict, bool bMask)
	{
		TD_PDF_PDFImage result = Helpers.GetObject<TD_PDF_PDFImage>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_1(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(pResDict), bMask), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFImage TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage(TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary pResDict)
	{
		TD_PDF_PDFImage result = Helpers.GetObject<TD_PDF_PDFImage>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_addNewImage__SWIG_2(TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(pResDict)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void TD_PDF_TD_PDF_HELPER_FUNCS_addNewImageAsXobject(TD_PDF_PDFDocument PDFDoc, ref OdGiRasterImage pRasterImage, ref TD_PDF_PDFName pImageFormName, ref TD_PDF_PDFResourceDictionary pResDict)
	{
		IntPtr jarg = ((pRasterImage == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pRasterImage).Handle);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((pImageFormName == null) ? IntPtr.Zero : TD_PDF_PDFName.getCPtr(pImageFormName).Handle);
		IntPtr intPtr2 = jarg2;
		IntPtr jarg3 = ((pResDict == null) ? IntPtr.Zero : TD_PDF_PDFResourceDictionary.getCPtr(pResDict).Handle);
		IntPtr intPtr3 = jarg3;
		try
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_TD_PDF_HELPER_FUNCS_addNewImageAsXobject(TD_PDF_PDFDocument.getCPtr(PDFDoc), ref jarg, ref jarg2, ref jarg3);
			if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pRasterImage = null;
			}
			else if (jarg != intPtr)
			{
				pRasterImage = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
			if (jarg2 == IntPtr.Zero)
			{
				pImageFormName = null;
			}
			else if (jarg2 != intPtr2)
			{
				pImageFormName = Helpers.GetObject<TD_PDF_PDFName>(jarg2, bOwn: true, bTryAddToTransaction: false);
			}
			if (jarg3 == IntPtr.Zero)
			{
				pResDict = null;
			}
			else if (jarg3 != intPtr3)
			{
				pResDict = Helpers.GetObject<TD_PDF_PDFResourceDictionary>(jarg3, bOwn: true, bTryAddToTransaction: false);
			}
		}
	}

	public static void TD_PDF_PDFOCManager_clearLayersData()
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_clearLayersData();
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static TD_PDF_PDFName TD_PDF_PDFOCManager_CreateOC4Layer(string layer_name, TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary resource_dict, bool bVisible, bool bLocked)
	{
		TD_PDF_PDFName result = Helpers.GetObject<TD_PDF_PDFName>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_0(layer_name, TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(resource_dict), bVisible, bLocked), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFName TD_PDF_PDFOCManager_CreateOC4Layer(string layer_name, TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary resource_dict, bool bVisible)
	{
		TD_PDF_PDFName result = Helpers.GetObject<TD_PDF_PDFName>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_CreateOC4Layer__SWIG_1(layer_name, TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(resource_dict), bVisible), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFName TD_PDF_PDFOCManager_createOCG(string name, TD_PDF_PDFOCConfigurationDictionary pOCC, bool bVisible, bool bLocked, TD_PDF_PDFResourceDictionary pResource)
	{
		TD_PDF_PDFName result = Helpers.GetObject<TD_PDF_PDFName>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_createOCG(name, TD_PDF_PDFOCConfigurationDictionary.getCPtr(pOCC), bVisible, bLocked, TD_PDF_PDFResourceDictionary.getCPtr(pResource)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFName TD_PDF_PDFOCManager_getOCGbyName(string name, TD_PDF_PDFDocument PDFDoc, TD_PDF_PDFResourceDictionary pResource)
	{
		TD_PDF_PDFName result = Helpers.GetObject<TD_PDF_PDFName>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_getOCGbyName(name, TD_PDF_PDFDocument.getCPtr(PDFDoc), TD_PDF_PDFResourceDictionary.getCPtr(pResource)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static TD_PDF_PDFPageNodeDictionary TD_PDF_PDFOCManager_getOCGNodeByName(string name, TD_PDF_PDFDocument PDFDoc)
	{
		TD_PDF_PDFPageNodeDictionary result = Helpers.GetObject<TD_PDF_PDFPageNodeDictionary>(TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFOCManager_getOCGNodeByName(name, TD_PDF_PDFDocument.getCPtr(PDFDoc)), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
