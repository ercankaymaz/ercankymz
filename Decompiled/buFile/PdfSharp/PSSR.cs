#define DEBUG
using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using PdfSharp.Drawing;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp;

internal static class PSSR
{
	private static ResourceManager _resmngr;

	public static string IndexOutOfRange => "The index is out of range.";

	public static string ListEnumCurrentOutOfRange => "Enumeration out of range.";

	public static string PageIndexOutOfRange => "The index of a page is out of range.";

	public static string OutlineIndexOutOfRange => "The index of an outline is out of range.";

	public static string SetValueMustNotBeNull => "The set value property must not be null.";

	public static string ObsoleteFunktionCalled => "The function is obsolete and must not be called.";

	public static string OwningDocumentRequired => "The PDF object must belong to a PdfDocument, but property Document is null.";

	public static string FontDataReadOnly => "Font data is read-only.";

	public static string ErrorReadingFontData => "Error while parsing an OpenType font.";

	public static string PointArrayEmpty => "The PointF array must not be empty.";

	public static string NeedPenOrBrush => "XPen or XBrush or both must not be null.";

	public static string InvalidPdf => "The file is not a valid PDF document.";

	public static string InvalidVersionNumber => "Invalid version number. Valid values are 12, 13, and 14.";

	public static string CannotHandleXRefStreams => "Cannot handle cross-reference streams. The current implementation of PDFsharp cannot handle this PDF feature introduced with Acrobat 6.";

	public static string PasswordRequired => "A password is required to open the PDF document.";

	public static string InvalidPassword => "The specified password is invalid.";

	public static string OwnerPasswordRequired => "To modify the document the owner password is required";

	public static string UserOrOwnerPasswordRequired => GetString(PSMsgID.UserOrOwnerPasswordRequired);

	public static string CannotModify => "The document cannot be modified.";

	public static string NameMustStartWithSlash => "A PDF name must start with a slash (/).";

	public static string MultiplePageInsert => "The page cannot be added to this document because the document already owned this page.";

	public static string UnexpectedTokenInPdfFile => "Unexpected token in PDF file. The PDF file may be corrupt. If it is not, please send us the file for service.";

	public static string UnknownEncryption => GetString(PSMsgID.UnknownEncryption);

	public static ResourceManager ResMngr
	{
		get
		{
			if (_resmngr == null)
			{
				try
				{
					Lock.EnterFontFactory();
					if (_resmngr == null)
					{
						_resmngr = new ResourceManager("PdfSharp.Resources.Messages", Assembly.GetExecutingAssembly());
					}
				}
				finally
				{
					Lock.ExitFontFactory();
				}
			}
			return _resmngr;
		}
	}

	public static string Format(PSMsgID id, params object[] args)
	{
		string text;
		try
		{
			text = GetString(id);
			return (text != null) ? Format(text, args) : "INTERNAL ERROR: Message not found in resources.";
		}
		catch (Exception ex)
		{
			text = $"UNEXPECTED ERROR while formatting message with ID {id.ToString()}: {ex.ToString()}";
		}
		return text;
	}

	public static string Format(string format, params object[] args)
	{
		if (format == null)
		{
			throw new ArgumentNullException("format");
		}
		try
		{
			return string.Format(format, args);
		}
		catch (Exception arg)
		{
			return $"UNEXPECTED ERROR while formatting message '{format}': {arg}";
		}
	}

	public static string GetString(PSMsgID id)
	{
		return ResMngr.GetString(id.ToString());
	}

	public static string InvalidValue(int val, string name, int min, int max)
	{
		return Format("{0} is not a valid value for {1}. {1} should be greater than or equal to {2} and less than or equal to {3}.", val, name, min, max);
	}

	public static string FileNotFound(string path)
	{
		return Format("The file '{0}' does not exist.", path);
	}

	public static string PointArrayAtLeast(int count)
	{
		return Format("The point array must contain {0} or more points.", count);
	}

	public static string CannotChangeImmutableObject(string typename)
	{
		return $"You cannot change this immutable {typename} object.";
	}

	public static string FontAlreadyAdded(string fontname)
	{
		return $"Fontface with the name '{fontname}' already added to font collection.";
	}

	public static string NotImplementedForFontsRetrievedWithFontResolver(string name)
	{
		return $"Not implemented for font '{name}', because it was retrieved with font resolver.";
	}

	public static string ImportPageNumberOutOfRange(int pageNumber, int maxPage, string path)
	{
		return string.Format("The page cannot be imported from document '{2}', because the page number is out of range. The specified page number is {0}, but it must be in the range from 1 to {1}.", pageNumber, maxPage, path);
	}

	public static string InappropriateColorSpace(PdfColorMode colorMode, XColorSpace colorSpace)
	{
		return string.Format("The document requires color mode {0}, but a color is defined using {1}. Use only colors that match the color mode of the PDF document", colorMode switch
		{
			PdfColorMode.Rgb => "RGB", 
			PdfColorMode.Cmyk => "CMYK", 
			_ => "(undefined)", 
		}, colorSpace switch
		{
			XColorSpace.Rgb => "RGB", 
			XColorSpace.Cmyk => "CMYK", 
			XColorSpace.GrayScale => "grayscale", 
			_ => "(undefined)", 
		});
	}

	public static string CannotGetGlyphTypeface(string fontName)
	{
		return Format("Cannot get a matching glyph typeface for font '{0}'.", fontName);
	}

	public static string UnexpectedToken(string token)
	{
		return Format(PSMsgID.UnexpectedToken, token);
	}

	[Conditional("DEBUG")]
	public static void TestResourceMessages()
	{
		string[] names = Enum.GetNames(typeof(PSMsgID));
		string[] array = names;
		foreach (string text in array)
		{
			string text2 = $"{text}: '{ResMngr.GetString(text)}'";
			Debug.Assert(text2 != null);
			Debug.WriteLine(text2);
		}
	}

	static PSSR()
	{
		TestResourceMessages();
	}
}
