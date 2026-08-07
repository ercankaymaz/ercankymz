// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.IO.PdfReader
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace PdfSharp.Pdf.IO;

public static class PdfReader
{
  public static int TestPdfFile(string path)
  {
    FileStream fileStream = (FileStream) null;
    int num;
    try
    {
      string pageNumber = XPdfForm.ExtractPageNumber(path, out int _);
      if (File.Exists(pageNumber))
      {
        fileStream = new FileStream(pageNumber, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        byte[] numArray = new byte[1024 /*0x0400*/];
        fileStream.Read(numArray, 0, 1024 /*0x0400*/);
        num = PdfReader.GetPdfFileVersion(numArray);
        goto label_10;
      }
    }
    catch
    {
    }
    finally
    {
      try
      {
        fileStream?.Close();
      }
      catch
      {
      }
    }
    num = 0;
label_10:
    return num;
  }

  public static int TestPdfFile(Stream stream)
  {
    long num1 = -1;
    int num2;
    try
    {
      num1 = stream.Position;
      byte[] numArray = new byte[1024 /*0x0400*/];
      stream.Read(numArray, 0, 1024 /*0x0400*/);
      num2 = PdfReader.GetPdfFileVersion(numArray);
      goto label_9;
    }
    catch
    {
    }
    finally
    {
      try
      {
        if (num1 != -1L)
          stream.Position = num1;
      }
      catch
      {
      }
    }
    num2 = 0;
label_9:
    return num2;
  }

  public static int TestPdfFile(byte[] data) => PdfReader.GetPdfFileVersion(data);

  internal static int GetPdfFileVersion(byte[] bytes)
  {
    int pdfFileVersion;
    try
    {
      string str = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
      if ((str[0] == '%' ? 1 : (str.IndexOf("%PDF", StringComparison.Ordinal) >= 0 ? 1 : 0)) != 0)
      {
        int num = str.IndexOf("PDF-", StringComparison.Ordinal);
        if ((num <= 0 ? 0 : (str[num + 5] == '.' ? 1 : 0)) != 0)
        {
          char ch1 = str[num + 4];
          char ch2 = str[num + 6];
          if ((ch1 < '1' || ch1 >= '2' || ch2 < '0' ? 0 : (ch2 <= '9' ? 1 : 0)) != 0)
          {
            pdfFileVersion = ((int) ch1 - 48 /*0x30*/) * 10 + ((int) ch2 - 48 /*0x30*/);
            goto label_7;
          }
        }
      }
    }
    catch
    {
    }
    pdfFileVersion = 0;
label_7:
    return pdfFileVersion;
  }

  public static PdfDocument Open(string path, PdfDocumentOpenMode openmode)
  {
    return PdfReader.Open(path, (string) null, openmode, (PdfPasswordProvider) null);
  }

  public static PdfDocument Open(
    string path,
    PdfDocumentOpenMode openmode,
    PdfPasswordProvider provider)
  {
    return PdfReader.Open(path, (string) null, openmode, provider);
  }

  public static PdfDocument Open(string path, string password, PdfDocumentOpenMode openmode)
  {
    return PdfReader.Open(path, password, openmode, (PdfPasswordProvider) null);
  }

  public static PdfDocument Open(
    string path,
    string password,
    PdfDocumentOpenMode openmode,
    PdfPasswordProvider provider)
  {
    Stream stream = (Stream) null;
    PdfDocument pdfDocument;
    try
    {
      stream = (Stream) new FileStream(path, FileMode.Open, FileAccess.Read);
      pdfDocument = PdfReader.Open(stream, password, openmode, provider);
      if (pdfDocument != null)
        pdfDocument._fullPath = Path.GetFullPath(path);
    }
    finally
    {
      stream?.Close();
    }
    return pdfDocument;
  }

  public static PdfDocument Open(string path)
  {
    return PdfReader.Open(path, (string) null, PdfDocumentOpenMode.Modify, (PdfPasswordProvider) null);
  }

  public static PdfDocument Open(string path, string password)
  {
    return PdfReader.Open(path, password, PdfDocumentOpenMode.Modify, (PdfPasswordProvider) null);
  }

  public static PdfDocument Open(Stream stream, PdfDocumentOpenMode openmode)
  {
    return PdfReader.Open(stream, (string) null, openmode);
  }

  public static PdfDocument Open(
    Stream stream,
    PdfDocumentOpenMode openmode,
    PdfPasswordProvider passwordProvider)
  {
    return PdfReader.Open(stream, (string) null, openmode, passwordProvider);
  }

  public static PdfDocument Open(Stream stream, string password, PdfDocumentOpenMode openmode)
  {
    return PdfReader.Open(stream, password, openmode, (PdfPasswordProvider) null);
  }

  public static PdfDocument Open(
    Stream stream,
    string password,
    PdfDocumentOpenMode openmode,
    PdfPasswordProvider passwordProvider)
  {
    PdfDocument document;
    PdfDocument pdfDocument;
    try
    {
      document = new PdfDocument(new Lexer(stream));
      document._state |= DocumentState.Imported;
      document._openMode = openmode;
      document._fileSize = stream.Length;
      byte[] numArray = new byte[1024 /*0x0400*/];
      stream.Position = 0L;
      stream.Read(numArray, 0, 1024 /*0x0400*/);
      document._version = PdfReader.GetPdfFileVersion(numArray);
      if (document._version == 0)
        throw new InvalidOperationException(PSSR.InvalidPdf);
      document._irefTable.IsUnderConstruction = true;
      Parser parser = new Parser(document);
      document._trailer = parser.ReadTrailer();
      Debug.Assert(document._irefTable.IsUnderConstruction);
      document._irefTable.IsUnderConstruction = false;
      if (document._trailer.Elements["/Encrypt"] is PdfReference element)
      {
        PdfObject pdfObject = parser.ReadObject((PdfObject) null, element.ObjectID, false, false);
        pdfObject.Reference = element;
        element.Value = pdfObject;
        PdfStandardSecurityHandler securityHandler = document.SecurityHandler;
        while (true)
        {
          int num;
          switch (securityHandler.ValidatePassword(password))
          {
            case PasswordValidity.Invalid:
              if (passwordProvider != null)
              {
                PdfPasswordProviderArgs args = new PdfPasswordProviderArgs();
                passwordProvider(args);
                if (!args.Abort)
                {
                  password = args.Password;
                  continue;
                }
                goto label_15;
              }
              goto label_16;
            case PasswordValidity.UserPassword:
              num = openmode == PdfDocumentOpenMode.Modify ? 1 : 0;
              break;
            default:
              num = 0;
              break;
          }
          if (num != 0)
          {
            if (passwordProvider != null)
            {
              PdfPasswordProviderArgs args = new PdfPasswordProviderArgs();
              passwordProvider(args);
              if (!args.Abort)
                password = args.Password;
              else
                goto label_19;
            }
            else
              goto label_20;
          }
          else
            goto label_22;
        }
label_15:
        pdfDocument = (PdfDocument) null;
        goto label_59;
label_16:
        if (password == null)
          throw new PdfReaderException(PSSR.PasswordRequired);
        throw new PdfReaderException(PSSR.InvalidPassword);
label_19:
        pdfDocument = (PdfDocument) null;
        goto label_59;
label_20:
        throw new PdfReaderException(PSSR.OwnerPasswordRequired);
      }
      if (password != null)
        ;
label_22:
      PdfReference[] allReferences1 = document._irefTable.AllReferences;
      int length1 = allReferences1.Length;
      Dictionary<int, object> dictionary = new Dictionary<int, object>();
      for (int index1 = 0; index1 < length1; ++index1)
      {
        if (allReferences1[index1].Value is PdfCrossReferenceStream crossReferenceStream)
        {
          for (int index2 = 0; index2 < crossReferenceStream.Entries.Count; ++index2)
          {
            PdfCrossReferenceStream.CrossReferenceStreamEntry entry = crossReferenceStream.Entries[index2];
            if (entry.Type == 2U)
            {
              int field2 = (int) entry.Field2;
              if (!dictionary.ContainsKey(field2))
              {
                dictionary.Add(field2, (object) null);
                PdfObjectID objectID = new PdfObjectID((int) entry.Field2);
                parser.ReadIRefsFromCompressedObject(objectID);
              }
            }
          }
        }
      }
      for (int index3 = 0; index3 < length1; ++index3)
      {
        PdfReference pdfReference = allReferences1[index3];
        if (pdfReference.Value is PdfCrossReferenceStream crossReferenceStream)
        {
          for (int index4 = 0; index4 < crossReferenceStream.Entries.Count; ++index4)
          {
            PdfCrossReferenceStream.CrossReferenceStreamEntry entry = crossReferenceStream.Entries[index4];
            if (entry.Type == 2U)
            {
              parser.ReadCompressedObject(new PdfObjectID((int) entry.Field2), (int) entry.Field3);
              Debug.Assert(document._irefTable.Contains(pdfReference.ObjectID));
            }
          }
        }
      }
      PdfReference[] allReferences2 = document._irefTable.AllReferences;
      int length2 = allReferences2.Length;
      for (int index = 0; index < length2; ++index)
      {
        PdfReference pdfReference = allReferences2[index];
        if (pdfReference.Value == null)
        {
          try
          {
            Debug.Assert(document._irefTable.Contains(pdfReference.ObjectID));
            PdfObject pdfObject = parser.ReadObject((PdfObject) null, pdfReference.ObjectID, false, false);
            Debug.Assert(pdfObject.Reference == pdfReference);
            pdfObject.Reference = pdfReference;
            Debug.Assert(pdfObject.Reference.Value != null, "Something went wrong.");
          }
          catch (Exception ex)
          {
            Debug.WriteLine(ex.Message);
            throw;
          }
        }
        else
          Debug.Assert(document._irefTable.Contains(pdfReference.ObjectID));
        document._irefTable._maxObjectNumber = Math.Max(document._irefTable._maxObjectNumber, pdfReference.ObjectNumber);
      }
      if (element != null)
        document.SecurityHandler.EncryptDocument();
      document._trailer.Finish();
      if (openmode == PdfDocumentOpenMode.Modify)
      {
        if (document.Internals.SecondDocumentID == "")
        {
          document._trailer.CreateNewDocumentIDs();
        }
        else
        {
          byte[] byteArray = Guid.NewGuid().ToByteArray();
          document.Internals.SecondDocumentID = PdfEncoders.RawEncoding.GetString(byteArray, 0, byteArray.Length);
        }
        document.Info.ModificationDate = DateTime.Now;
        int num = document._irefTable.Compact();
        if (num != 0)
          Debug.WriteLine("Number of deleted unreachable objects: " + num.ToString());
        Debug.Assert(document.Pages != null);
        document._irefTable.Renumber();
      }
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      throw;
    }
    pdfDocument = document;
label_59:
    return pdfDocument;
  }

  public static PdfDocument Open(Stream stream)
  {
    return PdfReader.Open(stream, PdfDocumentOpenMode.Modify);
  }
}
