// Decompiled with JetBrains decompiler
// Type: PdfSharp.PSSR
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Internal;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

#nullable disable
namespace PdfSharp;

internal static class PSSR
{
  private static ResourceManager _resmngr;

  public static string Format(PSMsgID id, params object[] args)
  {
    string str1;
    string str2;
    try
    {
      string format = PSSR.GetString(id);
      str1 = format != null ? PSSR.Format(format, args) : "INTERNAL ERROR: Message not found in resources.";
      goto label_4;
    }
    catch (Exception ex)
    {
      str2 = $"UNEXPECTED ERROR while formatting message with ID {id.ToString()}: {ex.ToString()}";
    }
    str1 = str2;
label_4:
    return str1;
  }

  public static string Format(string format, params object[] args)
  {
    if (format == null)
      throw new ArgumentNullException(nameof (format));
    string str;
    try
    {
      str = string.Format(format, args);
    }
    catch (Exception ex)
    {
      str = $"UNEXPECTED ERROR while formatting message '{format}': {ex}";
    }
    return str;
  }

  public static string GetString(PSMsgID id) => PSSR.ResMngr.GetString(id.ToString());

  public static string IndexOutOfRange => "The index is out of range.";

  public static string ListEnumCurrentOutOfRange => "Enumeration out of range.";

  public static string PageIndexOutOfRange => "The index of a page is out of range.";

  public static string OutlineIndexOutOfRange => "The index of an outline is out of range.";

  public static string SetValueMustNotBeNull => "The set value property must not be null.";

  public static string InvalidValue(int val, string name, int min, int max)
  {
    return PSSR.Format("{0} is not a valid value for {1}. {1} should be greater than or equal to {2} and less than or equal to {3}.", (object) val, (object) name, (object) min, (object) max);
  }

  public static string ObsoleteFunktionCalled => "The function is obsolete and must not be called.";

  public static string OwningDocumentRequired
  {
    get => "The PDF object must belong to a PdfDocument, but property Document is null.";
  }

  public static string FileNotFound(string path)
  {
    return PSSR.Format("The file '{0}' does not exist.", (object) path);
  }

  public static string FontDataReadOnly => "Font data is read-only.";

  public static string ErrorReadingFontData => "Error while parsing an OpenType font.";

  public static string PointArrayEmpty => "The PointF array must not be empty.";

  public static string PointArrayAtLeast(int count)
  {
    return PSSR.Format("The point array must contain {0} or more points.", (object) count);
  }

  public static string NeedPenOrBrush => "XPen or XBrush or both must not be null.";

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

  public static string InvalidPdf => "The file is not a valid PDF document.";

  public static string InvalidVersionNumber
  {
    get => "Invalid version number. Valid values are 12, 13, and 14.";
  }

  public static string CannotHandleXRefStreams
  {
    get
    {
      return "Cannot handle cross-reference streams. The current implementation of PDFsharp cannot handle this PDF feature introduced with Acrobat 6.";
    }
  }

  public static string PasswordRequired => "A password is required to open the PDF document.";

  public static string InvalidPassword => "The specified password is invalid.";

  public static string OwnerPasswordRequired
  {
    get => "To modify the document the owner password is required";
  }

  public static string UserOrOwnerPasswordRequired
  {
    get => PSSR.GetString(PSMsgID.UserOrOwnerPasswordRequired);
  }

  public static string CannotModify => "The document cannot be modified.";

  public static string NameMustStartWithSlash => "A PDF name must start with a slash (/).";

  public static string ImportPageNumberOutOfRange(int pageNumber, int maxPage, string path)
  {
    return string.Format("The page cannot be imported from document '{2}', because the page number is out of range. The specified page number is {0}, but it must be in the range from 1 to {1}.", (object) pageNumber, (object) maxPage, (object) path);
  }

  public static string MultiplePageInsert
  {
    get
    {
      return "The page cannot be added to this document because the document already owned this page.";
    }
  }

  public static string UnexpectedTokenInPdfFile
  {
    get
    {
      return "Unexpected token in PDF file. The PDF file may be corrupt. If it is not, please send us the file for service.";
    }
  }

  public static string InappropriateColorSpace(PdfColorMode colorMode, XColorSpace colorSpace)
  {
    string str1;
    switch (colorMode)
    {
      case PdfColorMode.Rgb:
        str1 = "RGB";
        break;
      case PdfColorMode.Cmyk:
        str1 = "CMYK";
        break;
      default:
        str1 = "(undefined)";
        break;
    }
    string str2;
    switch (colorSpace)
    {
      case XColorSpace.Rgb:
        str2 = "RGB";
        break;
      case XColorSpace.Cmyk:
        str2 = "CMYK";
        break;
      case XColorSpace.GrayScale:
        str2 = "grayscale";
        break;
      default:
        str2 = "(undefined)";
        break;
    }
    return $"The document requires color mode {str1}, but a color is defined using {str2}. Use only colors that match the color mode of the PDF document";
  }

  public static string CannotGetGlyphTypeface(string fontName)
  {
    return PSSR.Format("Cannot get a matching glyph typeface for font '{0}'.", (object) fontName);
  }

  public static string UnexpectedToken(string token)
  {
    return PSSR.Format(PSMsgID.UnexpectedToken, (object) token);
  }

  public static string UnknownEncryption => PSSR.GetString(PSMsgID.UnknownEncryption);

  public static ResourceManager ResMngr
  {
    get
    {
      if (PSSR._resmngr == null)
      {
        try
        {
          Lock.EnterFontFactory();
          if (PSSR._resmngr == null)
            PSSR._resmngr = new ResourceManager("PdfSharp.Resources.Messages", Assembly.GetExecutingAssembly());
        }
        finally
        {
          Lock.ExitFontFactory();
        }
      }
      return PSSR._resmngr;
    }
  }

  [Conditional("DEBUG")]
  public static void TestResourceMessages()
  {
    foreach (string name in Enum.GetNames(typeof (PSMsgID)))
    {
      string message = $"{name}: '{PSSR.ResMngr.GetString(name)}'";
      Debug.Assert(message != null);
      Debug.WriteLine(message);
    }
  }

  static PSSR() => PSSR.TestResourceMessages();
}
