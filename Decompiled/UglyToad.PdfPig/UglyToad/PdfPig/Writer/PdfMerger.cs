using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Actions;
using UglyToad.PdfPig.Outline.Destinations;

namespace UglyToad.PdfPig.Writer;

public static class PdfMerger
{
	public static byte[] Merge(string file1, string file2, IReadOnlyList<int>? file1Selection = null, IReadOnlyList<int>? file2Selection = null, PdfAStandard archiveStandard = PdfAStandard.None, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder = null)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Merge(file1, file2, memoryStream, file1Selection, file2Selection, archiveStandard, docInfoBuilder);
		return memoryStream.ToArray();
	}

	public static void Merge(string file1, string file2, Stream output, IReadOnlyList<int>? file1Selection = null, IReadOnlyList<int>? file2Selection = null, PdfAStandard archiveStandard = PdfAStandard.None, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder = null)
	{
		if (file1 == null)
		{
			throw new ArgumentNullException("file1");
		}
		if (file2 == null)
		{
			throw new ArgumentNullException("file2");
		}
		using FileStream fileStream = File.OpenRead(file1);
		using FileStream fileStream2 = File.OpenRead(file2);
		Merge(new FileStream[2] { fileStream, fileStream2 }, output, new IReadOnlyList<int>[2] { file1Selection, file2Selection }, archiveStandard, docInfoBuilder);
	}

	public static byte[] Merge(params string[] filePaths)
	{
		return Merge(PdfAStandard.None, null, filePaths);
	}

	public static byte[] Merge(PdfAStandard archiveStandard, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder, params string[] filePaths)
	{
		using MemoryStream memoryStream = new MemoryStream();
		Merge(memoryStream, archiveStandard, docInfoBuilder, filePaths);
		return memoryStream.ToArray();
	}

	public static void Merge(Stream output, params string[] filePaths)
	{
		Merge(output, PdfAStandard.None, null, filePaths);
	}

	public static void Merge(Stream output, PdfAStandard archiveStandard, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder, params string[] filePaths)
	{
		List<Stream> list = new List<Stream>(filePaths.Length);
		try
		{
			for (int i = 0; i < filePaths.Length; i++)
			{
				string path = filePaths[i] ?? throw new ArgumentNullException("filePaths", $"Null filepath at index {i}.");
				list.Add(File.OpenRead(path));
			}
			Merge(list, output, null, archiveStandard, docInfoBuilder);
		}
		finally
		{
			foreach (Stream item in list)
			{
				item.Dispose();
			}
		}
	}

	public static byte[] Merge(IReadOnlyList<byte[]> files, IReadOnlyList<IReadOnlyList<int>>? pagesBundle = null, PdfAStandard archiveStandard = PdfAStandard.None, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder = null)
	{
		if (files == null)
		{
			throw new ArgumentNullException("files");
		}
		using MemoryStream memoryStream = new MemoryStream();
		Merge(files.Select((byte[] f) => PdfDocument.Open(f)).ToArray(), memoryStream, pagesBundle, archiveStandard, docInfoBuilder);
		return memoryStream.ToArray();
	}

	public static void Merge(IReadOnlyList<Stream> streams, Stream output, IReadOnlyList<IReadOnlyList<int>?>? pagesBundle = null, PdfAStandard archiveStandard = PdfAStandard.None, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder = null)
	{
		if (streams == null)
		{
			throw new ArgumentNullException("streams");
		}
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		Merge(streams.Select((Stream f) => PdfDocument.Open(f)).ToArray(), output, pagesBundle, archiveStandard, docInfoBuilder);
	}

	private static void Merge(IReadOnlyList<PdfDocument> files, Stream output, IReadOnlyList<IReadOnlyList<int>?>? pagesBundle, PdfAStandard archiveStandard = PdfAStandard.None, PdfDocumentBuilder.DocumentInformationBuilder? docInfoBuilder = null)
	{
		double version = files.Select((PdfDocument x) => x.Version).Max();
		using (PdfDocumentBuilder pdfDocumentBuilder = new PdfDocumentBuilder(output, disposeStream: false, PdfWriterType.Default, version))
		{
			pdfDocumentBuilder.ArchiveStandard = archiveStandard;
			if (docInfoBuilder != null)
			{
				pdfDocumentBuilder.IncludeDocumentInformation = true;
				pdfDocumentBuilder.DocumentInformation = docInfoBuilder;
			}
			foreach (int item in Enumerable.Range(0, files.Count))
			{
				PdfDocument pdfDocument = files[item];
				IReadOnlyList<int> readOnlyList = null;
				if (pagesBundle != null && item < pagesBundle.Count)
				{
					readOnlyList = pagesBundle[item];
				}
				int basePageNumber = pdfDocumentBuilder.Pages.Count;
				if (readOnlyList == null)
				{
					for (int num = 1; num <= pdfDocument.NumberOfPages; num++)
					{
						pdfDocumentBuilder.AddPage(pdfDocument, num, new PdfDocumentBuilder.AddPageOptions
						{
							CopyLinkFunc = (PdfAction link) => CopyLink(link, (int n) => basePageNumber + n)
						});
					}
					continue;
				}
				Dictionary<int, int> pageNumbers = new Dictionary<int, int>();
				for (int num2 = 0; num2 < readOnlyList.Count; num2++)
				{
					pageNumbers[readOnlyList[num2]] = basePageNumber + num2 + 1;
				}
				foreach (int item2 in readOnlyList)
				{
					pdfDocumentBuilder.AddPage(pdfDocument, item2, new PdfDocumentBuilder.AddPageOptions
					{
						CopyLinkFunc = (PdfAction link) => CopyLink(link, (int n) => (!pageNumbers.TryGetValue(n, out var value)) ? ((int?)null) : new int?(value))
					});
				}
			}
		}
		static PdfAction? CopyLink(PdfAction action, Func<int, int?> getPageNumber)
		{
			if (!(action is AbstractGoToAction abstractGoToAction))
			{
				return action;
			}
			int? num3 = getPageNumber(abstractGoToAction.Destination.PageNumber);
			if (!num3.HasValue)
			{
				return null;
			}
			ExplicitDestination destination = new ExplicitDestination(num3.Value, abstractGoToAction.Destination.Type, abstractGoToAction.Destination.Coordinates);
			if (action is GoToAction)
			{
				return new GoToAction(destination);
			}
			if (action is GoToEAction goToEAction)
			{
				return new GoToEAction(destination, goToEAction.FileSpecification);
			}
			if (action is GoToRAction goToRAction)
			{
				return new GoToRAction(destination, goToRAction.Filename);
			}
			return action;
		}
	}
}
