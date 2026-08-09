using System;
using System.Collections.Generic;
using System.IO;

namespace UglyToad.PdfPig.Writer;

public static class PdfTextRemover
{
	public static byte[] RemoveText(string filePath, IReadOnlyList<int>? pagesBundle = null)
	{
		using MemoryStream memoryStream = new MemoryStream();
		RemoveText(memoryStream, filePath, pagesBundle);
		return memoryStream.ToArray();
	}

	public static void RemoveText(Stream output, string filePath, IReadOnlyList<int>? pagesBundle = null)
	{
		using FileStream stream = File.OpenRead(filePath);
		RemoveText(stream, output, pagesBundle);
	}

	public static byte[] RemoveText(byte[] file, IReadOnlyList<int>? pagesBundle = null)
	{
		if (file == null)
		{
			throw new ArgumentNullException("file");
		}
		using MemoryStream memoryStream = new MemoryStream();
		RemoveText(PdfDocument.Open(file), memoryStream, pagesBundle);
		return memoryStream.ToArray();
	}

	public static void RemoveText(Stream stream, Stream output, IReadOnlyList<int>? pagesBundle = null)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		RemoveText(PdfDocument.Open(stream), output, pagesBundle);
	}

	public static void RemoveText(PdfDocument file, Stream output, IReadOnlyList<int>? pagesBundle = null)
	{
		NoTextTokenWriter noTextTokenWriter = new NoTextTokenWriter();
		using PdfDocumentBuilder pdfDocumentBuilder = new PdfDocumentBuilder(output, disposeStream: false, PdfWriterType.Default, file.Version, noTextTokenWriter);
		if (pagesBundle == null)
		{
			for (int i = 1; i <= file.NumberOfPages; i++)
			{
				noTextTokenWriter.Page = i;
				pdfDocumentBuilder.AddPage(file, i);
			}
			return;
		}
		foreach (int item in pagesBundle)
		{
			int pageNumber = (noTextTokenWriter.Page = item);
			pdfDocumentBuilder.AddPage(file, pageNumber);
		}
	}
}
