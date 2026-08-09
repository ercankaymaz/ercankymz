#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.Security;

namespace PdfSharp.Pdf.IO;

public static class PdfReader
{
	public static int TestPdfFile(string path)
	{
		FileStream fileStream = null;
		try
		{
			int pageNumber;
			string path2 = XPdfForm.ExtractPageNumber(path, out pageNumber);
			if (File.Exists(path2))
			{
				fileStream = new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				byte[] array = new byte[1024];
				fileStream.Read(array, 0, 1024);
				return GetPdfFileVersion(array);
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
		return 0;
	}

	public static int TestPdfFile(Stream stream)
	{
		long num = -1L;
		try
		{
			num = stream.Position;
			byte[] array = new byte[1024];
			stream.Read(array, 0, 1024);
			return GetPdfFileVersion(array);
		}
		catch
		{
		}
		finally
		{
			try
			{
				if (num != -1)
				{
					stream.Position = num;
				}
			}
			catch
			{
			}
		}
		return 0;
	}

	public static int TestPdfFile(byte[] data)
	{
		return GetPdfFileVersion(data);
	}

	internal static int GetPdfFileVersion(byte[] bytes)
	{
		try
		{
			string text = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
			if (text[0] == '%' || text.IndexOf("%PDF", StringComparison.Ordinal) >= 0)
			{
				int num = text.IndexOf("PDF-", StringComparison.Ordinal);
				if (num > 0 && text[num + 5] == '.')
				{
					char c = text[num + 4];
					char c2 = text[num + 6];
					if (c >= '1' && c < '2' && c2 >= '0' && c2 <= '9')
					{
						return (c - 48) * 10 + (c2 - 48);
					}
				}
			}
		}
		catch
		{
		}
		return 0;
	}

	public static PdfDocument Open(string path, PdfDocumentOpenMode openmode)
	{
		return Open(path, null, openmode, null);
	}

	public static PdfDocument Open(string path, PdfDocumentOpenMode openmode, PdfPasswordProvider provider)
	{
		return Open(path, null, openmode, provider);
	}

	public static PdfDocument Open(string path, string password, PdfDocumentOpenMode openmode)
	{
		return Open(path, password, openmode, null);
	}

	public static PdfDocument Open(string path, string password, PdfDocumentOpenMode openmode, PdfPasswordProvider provider)
	{
		Stream stream = null;
		PdfDocument pdfDocument;
		try
		{
			stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			pdfDocument = Open(stream, password, openmode, provider);
			if (pdfDocument != null)
			{
				pdfDocument._fullPath = Path.GetFullPath(path);
			}
		}
		finally
		{
			stream?.Close();
		}
		return pdfDocument;
	}

	public static PdfDocument Open(string path)
	{
		return Open(path, null, PdfDocumentOpenMode.Modify, null);
	}

	public static PdfDocument Open(string path, string password)
	{
		return Open(path, password, PdfDocumentOpenMode.Modify, null);
	}

	public static PdfDocument Open(Stream stream, PdfDocumentOpenMode openmode)
	{
		return Open(stream, null, openmode);
	}

	public static PdfDocument Open(Stream stream, PdfDocumentOpenMode openmode, PdfPasswordProvider passwordProvider)
	{
		return Open(stream, null, openmode, passwordProvider);
	}

	public static PdfDocument Open(Stream stream, string password, PdfDocumentOpenMode openmode)
	{
		return Open(stream, password, openmode, null);
	}

	public static PdfDocument Open(Stream stream, string password, PdfDocumentOpenMode openmode, PdfPasswordProvider passwordProvider)
	{
		PdfDocument pdfDocument;
		try
		{
			Lexer lexer = new Lexer(stream);
			pdfDocument = new PdfDocument(lexer);
			pdfDocument._state |= DocumentState.Imported;
			pdfDocument._openMode = openmode;
			pdfDocument._fileSize = stream.Length;
			byte[] array = new byte[1024];
			stream.Position = 0L;
			stream.Read(array, 0, 1024);
			pdfDocument._version = GetPdfFileVersion(array);
			if (pdfDocument._version == 0)
			{
				throw new InvalidOperationException(PSSR.InvalidPdf);
			}
			pdfDocument._irefTable.IsUnderConstruction = true;
			Parser parser = new Parser(pdfDocument);
			pdfDocument._trailer = parser.ReadTrailer();
			Debug.Assert(pdfDocument._irefTable.IsUnderConstruction);
			pdfDocument._irefTable.IsUnderConstruction = false;
			PdfReference pdfReference = pdfDocument._trailer.Elements["/Encrypt"] as PdfReference;
			if (pdfReference != null)
			{
				PdfObject pdfObject = parser.ReadObject(null, pdfReference.ObjectID, includeReferences: false, fromObjecStream: false);
				pdfObject.Reference = pdfReference;
				pdfReference.Value = pdfObject;
				PdfStandardSecurityHandler securityHandler = pdfDocument.SecurityHandler;
				while (true)
				{
					switch (securityHandler.ValidatePassword(password))
					{
					case PasswordValidity.Invalid:
						if (passwordProvider != null)
						{
							PdfPasswordProviderArgs pdfPasswordProviderArgs2 = new PdfPasswordProviderArgs();
							passwordProvider(pdfPasswordProviderArgs2);
							if (pdfPasswordProviderArgs2.Abort)
							{
								return null;
							}
							password = pdfPasswordProviderArgs2.Password;
							continue;
						}
						if (password == null)
						{
							throw new PdfReaderException(PSSR.PasswordRequired);
						}
						throw new PdfReaderException(PSSR.InvalidPassword);
					case PasswordValidity.UserPassword:
						if (openmode == PdfDocumentOpenMode.Modify)
						{
							if (passwordProvider != null)
							{
								PdfPasswordProviderArgs pdfPasswordProviderArgs = new PdfPasswordProviderArgs();
								passwordProvider(pdfPasswordProviderArgs);
								if (pdfPasswordProviderArgs.Abort)
								{
									return null;
								}
								password = pdfPasswordProviderArgs.Password;
								continue;
							}
							throw new PdfReaderException(PSSR.OwnerPasswordRequired);
						}
						break;
					}
					break;
				}
			}
			else if (password == null)
			{
			}
			PdfReference[] allReferences = pdfDocument._irefTable.AllReferences;
			int num = allReferences.Length;
			Dictionary<int, object> dictionary = new Dictionary<int, object>();
			for (int i = 0; i < num; i++)
			{
				PdfReference pdfReference2 = allReferences[i];
				if (!(pdfReference2.Value is PdfCrossReferenceStream pdfCrossReferenceStream))
				{
					continue;
				}
				for (int j = 0; j < pdfCrossReferenceStream.Entries.Count; j++)
				{
					PdfCrossReferenceStream.CrossReferenceStreamEntry crossReferenceStreamEntry = pdfCrossReferenceStream.Entries[j];
					if (crossReferenceStreamEntry.Type == 2)
					{
						int field = (int)crossReferenceStreamEntry.Field2;
						if (!dictionary.ContainsKey(field))
						{
							dictionary.Add(field, null);
							PdfObjectID objectID = new PdfObjectID((int)crossReferenceStreamEntry.Field2);
							parser.ReadIRefsFromCompressedObject(objectID);
						}
					}
				}
			}
			for (int k = 0; k < num; k++)
			{
				PdfReference pdfReference3 = allReferences[k];
				if (!(pdfReference3.Value is PdfCrossReferenceStream pdfCrossReferenceStream2))
				{
					continue;
				}
				for (int l = 0; l < pdfCrossReferenceStream2.Entries.Count; l++)
				{
					PdfCrossReferenceStream.CrossReferenceStreamEntry crossReferenceStreamEntry2 = pdfCrossReferenceStream2.Entries[l];
					if (crossReferenceStreamEntry2.Type == 2)
					{
						PdfReference pdfReference4 = parser.ReadCompressedObject(new PdfObjectID((int)crossReferenceStreamEntry2.Field2), (int)crossReferenceStreamEntry2.Field3);
						Debug.Assert(pdfDocument._irefTable.Contains(pdfReference3.ObjectID));
					}
				}
			}
			PdfReference[] allReferences2 = pdfDocument._irefTable.AllReferences;
			int num2 = allReferences2.Length;
			for (int m = 0; m < num2; m++)
			{
				PdfReference pdfReference5 = allReferences2[m];
				if (pdfReference5.Value == null)
				{
					try
					{
						Debug.Assert(pdfDocument._irefTable.Contains(pdfReference5.ObjectID));
						PdfObject pdfObject2 = parser.ReadObject(null, pdfReference5.ObjectID, includeReferences: false, fromObjecStream: false);
						Debug.Assert(pdfObject2.Reference == pdfReference5);
						pdfObject2.Reference = pdfReference5;
						Debug.Assert(pdfObject2.Reference.Value != null, "Something went wrong.");
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
						throw;
					}
				}
				else
				{
					Debug.Assert(pdfDocument._irefTable.Contains(pdfReference5.ObjectID));
				}
				pdfDocument._irefTable._maxObjectNumber = Math.Max(pdfDocument._irefTable._maxObjectNumber, pdfReference5.ObjectNumber);
			}
			if (pdfReference != null)
			{
				pdfDocument.SecurityHandler.EncryptDocument();
			}
			pdfDocument._trailer.Finish();
			if (openmode == PdfDocumentOpenMode.Modify)
			{
				if (pdfDocument.Internals.SecondDocumentID == "")
				{
					pdfDocument._trailer.CreateNewDocumentIDs();
				}
				else
				{
					byte[] array2 = Guid.NewGuid().ToByteArray();
					pdfDocument.Internals.SecondDocumentID = PdfEncoders.RawEncoding.GetString(array2, 0, array2.Length);
				}
				pdfDocument.Info.ModificationDate = DateTime.Now;
				int num3 = pdfDocument._irefTable.Compact();
				if (num3 != 0)
				{
					Debug.WriteLine("Number of deleted unreachable objects: " + num3);
				}
				PdfPages pages = pdfDocument.Pages;
				Debug.Assert(pages != null);
				pdfDocument._irefTable.Renumber();
			}
		}
		catch (Exception ex2)
		{
			Debug.WriteLine(ex2.Message);
			throw;
		}
		return pdfDocument;
	}

	public static PdfDocument Open(Stream stream)
	{
		return Open(stream, PdfDocumentOpenMode.Modify);
	}
}
