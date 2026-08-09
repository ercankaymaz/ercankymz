using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Graphics.Operations;
using UglyToad.PdfPig.Outline.Destinations;
using UglyToad.PdfPig.Parser;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Content;

public abstract class BasePageFactory<TPage> : IPageFactory<TPage>
{
	public readonly ParsingOptions ParsingOptions;

	public readonly IPdfTokenScanner PdfScanner;

	public readonly IResourceStore ResourceStore;

	public readonly ILookupFilterProvider FilterProvider;

	public readonly IPageContentParser PageContentParser;

	protected BasePageFactory(IPdfTokenScanner pdfScanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider, IPageContentParser pageContentParser, ParsingOptions parsingOptions)
	{
		ResourceStore = resourceStore;
		FilterProvider = filterProvider;
		PageContentParser = pageContentParser;
		PdfScanner = pdfScanner;
		ParsingOptions = parsingOptions;
	}

	public TPage Create(int number, DictionaryToken dictionary, PageTreeMembers pageTreeMembers, NamedDestinations namedDestinations)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		NameToken nameOrDefault = dictionary.GetNameOrDefault(NameToken.Type);
		if (nameOrDefault != null && !nameOrDefault.Equals(NameToken.Page))
		{
			ParsingOptions.Logger.Error($"Page {number} had its type specified as {nameOrDefault} rather than 'Page'.");
		}
		PageRotationDegrees rotation = new PageRotationDegrees(pageTreeMembers.Rotation);
		if (dictionary.TryGet<NumericToken>(NameToken.Rotate, PdfScanner, out NumericToken token))
		{
			rotation = new PageRotationDegrees(token.Int);
		}
		int num = 0;
		while (pageTreeMembers.ParentResources.Count > 0)
		{
			DictionaryToken resourceDictionary = pageTreeMembers.ParentResources.Dequeue();
			ResourceStore.LoadResourceDictionary(resourceDictionary);
			num++;
		}
		if (dictionary.TryGet<DictionaryToken>(NameToken.Resources, PdfScanner, out DictionaryToken token2))
		{
			ResourceStore.LoadResourceDictionary(token2);
			num++;
		}
		UserSpaceUnit userSpaceUnits = GetUserSpaceUnits(dictionary);
		MediaBox mediaBox = GetMediaBox(number, dictionary, pageTreeMembers);
		CropBox cropBox = GetCropBox(dictionary, pageTreeMembers, mediaBox);
		TransformationMatrix transformationMatrix = OperationContextHelper.GetInitialMatrix(userSpaceUnits, mediaBox, cropBox, rotation, ParsingOptions.Logger);
		ApplyTransformNormalise(in transformationMatrix, ref mediaBox, ref cropBox);
		TPage result;
		ArrayToken tokenResult;
		if (!dictionary.TryGet(NameToken.Contents, out var token3))
		{
			result = ProcessPageInternal(number, dictionary, namedDestinations, mediaBox, cropBox, userSpaceUnits, rotation, in transformationMatrix, null);
		}
		else if (DirectObjectFinder.TryGet<ArrayToken>(token3, PdfScanner, out tokenResult))
		{
			using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>(65536);
			for (int i = 0; i < tokenResult.Data.Count; i++)
			{
				IToken token4 = tokenResult.Data[i];
				if (!(token4 is IndirectReferenceToken indirectReferenceToken))
				{
					throw new PdfDocumentFormatException($"The contents contained something which was not an indirect reference: {token4}.");
				}
				StreamToken streamToken = DirectObjectFinder.Get<StreamToken>(indirectReferenceToken, PdfScanner);
				if (streamToken == null)
				{
					throw new InvalidOperationException($"Could not find the contents for object {indirectReferenceToken}.");
				}
				arrayPoolBufferWriter.Write(streamToken.Decode(FilterProvider, PdfScanner).Span);
				if (i < tokenResult.Data.Count - 1)
				{
					arrayPoolBufferWriter.Write(10);
				}
			}
			result = ProcessPageInternal(number, dictionary, namedDestinations, mediaBox, cropBox, userSpaceUnits, rotation, in transformationMatrix, arrayPoolBufferWriter.WrittenMemory);
		}
		else
		{
			Memory<byte> memory = (DirectObjectFinder.Get<StreamToken>(token3, PdfScanner) ?? throw new InvalidOperationException("Failed to parse the content for the page: " + number)).Decode(FilterProvider, PdfScanner);
			result = ProcessPageInternal(number, dictionary, namedDestinations, mediaBox, cropBox, userSpaceUnits, rotation, in transformationMatrix, memory);
		}
		for (int j = 0; j < num; j++)
		{
			ResourceStore.UnloadResourceDictionary();
		}
		return result;
	}

	private TPage ProcessPageInternal(int pageNumber, DictionaryToken dictionary, NamedDestinations namedDestinations, MediaBox mediaBox, CropBox cropBox, UserSpaceUnit userSpaceUnit, PageRotationDegrees rotation, in TransformationMatrix initialMatrix, ReadOnlyMemory<byte> contentBytes)
	{
		return ProcessPage(operations: (!contentBytes.IsEmpty) ? PageContentParser.Parse(pageNumber, new MemoryInputBytes(contentBytes), ParsingOptions.Logger) : Array.Empty<IGraphicsStateOperation>(), pageNumber: pageNumber, dictionary: dictionary, namedDestinations: namedDestinations, mediaBox: mediaBox, cropBox: cropBox, userSpaceUnit: userSpaceUnit, rotation: rotation, initialMatrix: initialMatrix);
	}

	protected abstract TPage ProcessPage(int pageNumber, DictionaryToken dictionary, NamedDestinations namedDestinations, MediaBox mediaBox, CropBox cropBox, UserSpaceUnit userSpaceUnit, PageRotationDegrees rotation, TransformationMatrix initialMatrix, IReadOnlyList<IGraphicsStateOperation> operations);

	protected static UserSpaceUnit GetUserSpaceUnits(DictionaryToken dictionary)
	{
		if (dictionary.TryGet(NameToken.UserUnit, out var token) && token is NumericToken numericToken)
		{
			return new UserSpaceUnit(numericToken.Int);
		}
		return UserSpaceUnit.Default;
	}

	protected CropBox GetCropBox(DictionaryToken dictionary, PageTreeMembers pageTreeMembers, MediaBox mediaBox)
	{
		if (dictionary.TryGet(NameToken.CropBox, out var token) && DirectObjectFinder.TryGet<ArrayToken>(token, PdfScanner, out ArrayToken tokenResult))
		{
			if (tokenResult.Length != 4)
			{
				ParsingOptions.Logger.Error($"The CropBox was the wrong length in the dictionary: {dictionary}. Array was: {tokenResult}. Using MediaBox.");
				return new CropBox(mediaBox.Bounds);
			}
			return new CropBox(tokenResult.ToRectangle(PdfScanner));
		}
		return pageTreeMembers.GetCropBox() ?? new CropBox(mediaBox.Bounds);
	}

	protected MediaBox GetMediaBox(int number, DictionaryToken dictionary, PageTreeMembers pageTreeMembers)
	{
		MediaBox mediaBox;
		if (dictionary.TryGet(NameToken.MediaBox, out var token) && DirectObjectFinder.TryGet<ArrayToken>(token, PdfScanner, out ArrayToken tokenResult))
		{
			if (tokenResult.Length != 4)
			{
				ParsingOptions.Logger.Error($"The MediaBox was the wrong length in the dictionary: {dictionary}. Array was: {tokenResult}. Defaulting to US Letter.");
				return MediaBox.Letter;
			}
			mediaBox = new MediaBox(tokenResult.ToRectangle(PdfScanner));
		}
		else
		{
			mediaBox = pageTreeMembers.MediaBox;
			if (mediaBox == null)
			{
				ParsingOptions.Logger.Error($"The MediaBox was the wrong missing for page {number}. Using US Letter.");
				mediaBox = MediaBox.Letter;
			}
		}
		return mediaBox;
	}

	protected static void ApplyTransformNormalise(in TransformationMatrix transformationMatrix, ref MediaBox mediaBox, ref CropBox cropBox)
	{
		if (transformationMatrix != TransformationMatrix.Identity)
		{
			mediaBox = new MediaBox(transformationMatrix.Transform(mediaBox.Bounds).Normalise());
			cropBox = new CropBox(transformationMatrix.Transform(cropBox.Bounds).Normalise());
		}
	}
}
