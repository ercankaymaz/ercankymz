using System;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Util;

internal static class ShadingParser
{
	public static Shading Create(IToken shading, IPdfTokenScanner scanner, IResourceStore resourceStore, ILookupFilterProvider filterProvider)
	{
		DictionaryToken dictionaryToken = null;
		StreamToken streamToken = null;
		if (shading is StreamToken streamToken2)
		{
			dictionaryToken = streamToken2.StreamDictionary;
			streamToken = new StreamToken(streamToken2.StreamDictionary, streamToken2.Decode(filterProvider, scanner));
		}
		else if (shading is DictionaryToken dictionaryToken2)
		{
			dictionaryToken = dictionaryToken2;
		}
		if (dictionaryToken.TryGet<NumericToken>(NameToken.ShadingType, scanner, out NumericToken token))
		{
			if (token.Int >= 4 && streamToken == null)
			{
				throw new ArgumentNullException("shadingStream", $"Shading type '{(ShadingType)token.Int}' is not properly defined. Shading types 4 to 7 shall be defined by a stream.");
			}
			ShadingType shadingType = (ShadingType)token.Int;
			ColorSpaceDetails colorSpaceDetails = null;
			if (dictionaryToken.TryGet<NameToken>(NameToken.ColorSpace, scanner, out NameToken token2))
			{
				colorSpaceDetails = resourceStore.GetColorSpaceDetails(token2, dictionaryToken);
			}
			else
			{
				if (!dictionaryToken.TryGet<ArrayToken>(NameToken.ColorSpace, scanner, out ArrayToken token3))
				{
					throw new ArgumentNullException($"'{NameToken.ColorSpace}' is required for shading.");
				}
				if (!(token3.Data[0] is NameToken name))
				{
					throw new ArgumentNullException("Invalid color space found in shading.");
				}
				colorSpaceDetails = resourceStore.GetColorSpaceDetails(name, dictionaryToken);
			}
			double[] background = null;
			if (dictionaryToken.TryGet<ArrayToken>(NameToken.Background, scanner, out ArrayToken token4))
			{
				background = (from v in token4.Data.OfType<NumericToken>()
					select v.Double).ToArray();
			}
			PdfRectangle? bbox = null;
			if (dictionaryToken.TryGet<ArrayToken>(NameToken.Bbox, scanner, out ArrayToken token5))
			{
				bbox = token5.ToRectangle(scanner);
			}
			BooleanToken token6;
			bool antiAlias = dictionaryToken.TryGet<BooleanToken>(NameToken.AntiAlias, scanner, out token6) && token6.Data;
			return shadingType switch
			{
				ShadingType.FunctionBased => CreateFunctionBasedShading(dictionaryToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.Axial => CreateAxialShading(dictionaryToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.Radial => CreateRadialShading(dictionaryToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.FreeFormGouraud => CreateFreeFormGouraudShadedTriangleMeshesShading(streamToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.LatticeFormGouraud => CreateLatticeFormGouraudShadedTriangleMeshesShading(streamToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.CoonsPatch => CreateCoonsPatchMeshesShading(streamToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				ShadingType.TensorProductPatch => CreateTensorProductPatchMeshesShading(streamToken, colorSpaceDetails, background, bbox, antiAlias, scanner, filterProvider), 
				_ => throw new PdfDocumentFormatException($"Invalid Shading type encountered in page resource dictionary: '{shadingType}'."), 
			};
		}
		throw new ArgumentNullException($"'{NameToken.ShadingType}' is required for shading.");
	}

	private static PdfFunction[] GetFunctions(IToken functionToken, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		if (DirectObjectFinder.TryGet<ArrayToken>(functionToken, scanner, out ArrayToken tokenResult))
		{
			PdfFunction[] array = new PdfFunction[tokenResult.Length];
			for (int i = 0; i < tokenResult.Length; i++)
			{
				array[i] = PdfFunctionParser.Create(tokenResult[i], scanner, filterProvider);
			}
			return array;
		}
		return new PdfFunction[1] { PdfFunctionParser.Create(functionToken, scanner, filterProvider) };
	}

	private static FunctionBasedShading CreateFunctionBasedShading(DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		double[] array = null;
		array = ((!shadingDictionary.TryGet<ArrayToken>(NameToken.Domain, scanner, out ArrayToken token)) ? new double[4] { 0.0, 1.0, 0.0, 1.0 } : (from v in token.Data.OfType<NumericToken>()
			select v.Double).ToArray());
		TransformationMatrix matrix;
		if (shadingDictionary.TryGet<ArrayToken>(NameToken.Matrix, scanner, out ArrayToken token2))
		{
			matrix = TransformationMatrix.FromArray((from n in token2.Data.OfType<NumericToken>()
				select n.Data).ToArray());
		}
		else
		{
			object obj = global::_003CPrivateImplementationDetails_003E._4787A52766C2D47C0D1BA11D22DDB34A2BEEE258C82364EB9A6FBB8754C63D20_A4;
			if (obj == null)
			{
				obj = new double[6] { 1.0, 0.0, 0.0, 1.0, 0.0, 0.0 };
				global::_003CPrivateImplementationDetails_003E._4787A52766C2D47C0D1BA11D22DDB34A2BEEE258C82364EB9A6FBB8754C63D20_A4 = (double[])obj;
			}
			matrix = TransformationMatrix.FromArray(new ReadOnlySpan<double>((double[])obj));
		}
		if (!shadingDictionary.ContainsKey(NameToken.Function))
		{
			throw new ArgumentNullException($"'{NameToken.Function}' is required for shading type '{ShadingType.FunctionBased}'.");
		}
		PdfFunction[] functions = GetFunctions(shadingDictionary.Data[NameToken.Function], scanner, filterProvider);
		return new FunctionBasedShading(antiAlias, shadingDictionary, colorSpace, bbox, background, array, matrix, functions);
	}

	private static AxialShading CreateAxialShading(DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		double[] array = null;
		if (shadingDictionary.TryGet<ArrayToken>(NameToken.Coords, scanner, out ArrayToken token))
		{
			array = (from v in token.Data.OfType<NumericToken>()
				select v.Double).ToArray();
			double[] array2 = null;
			array2 = ((!shadingDictionary.TryGet<ArrayToken>(NameToken.Domain, scanner, out ArrayToken token2)) ? new double[2] { 0.0, 1.0 } : (from v in token2.Data.OfType<NumericToken>()
				select v.Double).ToArray());
			if (!shadingDictionary.ContainsKey(NameToken.Function))
			{
				throw new ArgumentNullException($"{NameToken.Function} is required for shading type '{ShadingType.Axial}'.");
			}
			PdfFunction[] functions = GetFunctions(shadingDictionary.Data[NameToken.Function], scanner, filterProvider);
			bool[] extend = new bool[2];
			if (shadingDictionary.TryGet<ArrayToken>(NameToken.Extend, scanner, out ArrayToken token3))
			{
				extend = (from v in token3.Data.OfType<BooleanToken>()
					select v.Data).ToArray();
			}
			return new AxialShading(antiAlias, shadingDictionary, colorSpace, bbox, background, array, array2, functions, extend);
		}
		throw new ArgumentNullException($"{NameToken.Coords} is required for shading type '{ShadingType.Axial}'.");
	}

	private static RadialShading CreateRadialShading(DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		double[] array = null;
		if (shadingDictionary.TryGet<ArrayToken>(NameToken.Coords, scanner, out ArrayToken token))
		{
			array = (from v in token.Data.OfType<NumericToken>()
				select v.Double).ToArray();
			double[] array2 = null;
			array2 = ((!shadingDictionary.TryGet<ArrayToken>(NameToken.Domain, scanner, out ArrayToken token2)) ? new double[2] { 0.0, 1.0 } : (from v in token2.Data.OfType<NumericToken>()
				select v.Double).ToArray());
			if (!shadingDictionary.ContainsKey(NameToken.Function))
			{
				throw new ArgumentNullException($"{NameToken.Function} is required for shading type '{ShadingType.Radial}'.");
			}
			PdfFunction[] functions = GetFunctions(shadingDictionary.Data[NameToken.Function], scanner, filterProvider);
			bool[] extend = new bool[2];
			if (shadingDictionary.TryGet<ArrayToken>(NameToken.Extend, scanner, out ArrayToken token3))
			{
				extend = (from v in token3.Data.OfType<BooleanToken>()
					select v.Data).ToArray();
			}
			return new RadialShading(antiAlias, shadingDictionary, colorSpace, bbox, background, array, array2, functions, extend);
		}
		throw new ArgumentNullException($"{NameToken.Coords} is required for shading type '{ShadingType.Radial}'.");
	}

	private static FreeFormGouraudShading CreateFreeFormGouraudShadedTriangleMeshesShading(StreamToken shadingStream, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerCoordinate, scanner, out NumericToken token))
		{
			int bitsPerCoordinate = token.Int;
			if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerComponent, scanner, out NumericToken token2))
			{
				int bitsPerComponent = token2.Int;
				if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerFlag, scanner, out NumericToken token3))
				{
					int bitsPerFlag = token3.Int;
					if (shadingStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Decode, scanner, out ArrayToken token4))
					{
						double[] decode = (from v in token4.Data.OfType<NumericToken>()
							select v.Double).ToArray();
						PdfFunction[] functions = null;
						if (shadingStream.StreamDictionary.ContainsKey(NameToken.Function))
						{
							functions = GetFunctions(shadingStream.StreamDictionary.Data[NameToken.Function], scanner, filterProvider);
						}
						return new FreeFormGouraudShading(antiAlias, shadingStream, colorSpace, bbox, background, bitsPerCoordinate, bitsPerComponent, bitsPerFlag, decode, functions);
					}
					throw new ArgumentNullException($"{NameToken.Decode} is required for shading type '{ShadingType.FreeFormGouraud}'.");
				}
				throw new ArgumentNullException($"{NameToken.BitsPerFlag} is required for shading type '{ShadingType.FreeFormGouraud}'.");
			}
			throw new ArgumentNullException($"{NameToken.BitsPerComponent} is required for shading type '{ShadingType.FreeFormGouraud}'.");
		}
		throw new ArgumentNullException($"{NameToken.BitsPerCoordinate} is required for shading type '{ShadingType.FreeFormGouraud}'.");
	}

	private static LatticeFormGouraudShading CreateLatticeFormGouraudShadedTriangleMeshesShading(StreamToken shadingStream, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerCoordinate, scanner, out NumericToken token))
		{
			int bitsPerCoordinate = token.Int;
			if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerComponent, scanner, out NumericToken token2))
			{
				int bitsPerComponent = token2.Int;
				if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.VerticesPerRow, scanner, out NumericToken token3))
				{
					int verticesPerRow = token3.Int;
					if (shadingStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Decode, scanner, out ArrayToken token4))
					{
						double[] decode = (from v in token4.Data.OfType<NumericToken>()
							select v.Double).ToArray();
						PdfFunction[] functions = null;
						if (shadingStream.StreamDictionary.ContainsKey(NameToken.Function))
						{
							functions = GetFunctions(shadingStream.StreamDictionary.Data[NameToken.Function], scanner, filterProvider);
						}
						return new LatticeFormGouraudShading(antiAlias, shadingStream, colorSpace, bbox, background, bitsPerCoordinate, bitsPerComponent, verticesPerRow, decode, functions);
					}
					throw new ArgumentNullException($"{NameToken.Decode} is required for shading type '{ShadingType.LatticeFormGouraud}'.");
				}
				throw new ArgumentNullException($"{NameToken.VerticesPerRow} is required for shading type '{ShadingType.LatticeFormGouraud}'.");
			}
			throw new ArgumentNullException($"{NameToken.BitsPerComponent} is required for shading type '{ShadingType.LatticeFormGouraud}'.");
		}
		throw new ArgumentNullException($"{NameToken.BitsPerCoordinate} is required for shading type '{ShadingType.LatticeFormGouraud}'.");
	}

	private static CoonsPatchMeshesShading CreateCoonsPatchMeshesShading(StreamToken shadingStream, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerCoordinate, scanner, out NumericToken token))
		{
			int bitsPerCoordinate = token.Int;
			if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerComponent, scanner, out NumericToken token2))
			{
				int bitsPerComponent = token2.Int;
				if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerFlag, scanner, out NumericToken token3))
				{
					int bitsPerFlag = token3.Int;
					if (shadingStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Decode, scanner, out ArrayToken token4))
					{
						double[] decode = (from v in token4.Data.OfType<NumericToken>()
							select v.Double).ToArray();
						PdfFunction[] functions = null;
						if (shadingStream.StreamDictionary.ContainsKey(NameToken.Function))
						{
							functions = GetFunctions(shadingStream.StreamDictionary.Data[NameToken.Function], scanner, filterProvider);
						}
						return new CoonsPatchMeshesShading(antiAlias, shadingStream, colorSpace, bbox, background, bitsPerCoordinate, bitsPerComponent, bitsPerFlag, decode, functions);
					}
					throw new ArgumentNullException($"{NameToken.Decode} is required for shading type '{ShadingType.CoonsPatch}'.");
				}
				throw new ArgumentNullException($"{NameToken.BitsPerFlag} is required for shading type '{ShadingType.CoonsPatch}'.");
			}
			throw new ArgumentNullException($"{NameToken.BitsPerComponent} is required for shading type '{ShadingType.CoonsPatch}'.");
		}
		throw new ArgumentNullException($"{NameToken.BitsPerCoordinate} is required for shading type '{ShadingType.CoonsPatch}'.");
	}

	private static TensorProductPatchMeshesShading CreateTensorProductPatchMeshesShading(StreamToken shadingStream, ColorSpaceDetails colorSpace, double[]? background, PdfRectangle? bbox, bool antiAlias, IPdfTokenScanner scanner, ILookupFilterProvider filterProvider)
	{
		if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerCoordinate, scanner, out NumericToken token))
		{
			int bitsPerCoordinate = token.Int;
			if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerComponent, scanner, out NumericToken token2))
			{
				int bitsPerComponent = token2.Int;
				if (shadingStream.StreamDictionary.TryGet<NumericToken>(NameToken.BitsPerFlag, scanner, out NumericToken token3))
				{
					int bitsPerFlag = token3.Int;
					if (shadingStream.StreamDictionary.TryGet<ArrayToken>(NameToken.Decode, scanner, out ArrayToken token4))
					{
						double[] decode = (from v in token4.Data.OfType<NumericToken>()
							select v.Double).ToArray();
						PdfFunction[] functions = null;
						if (shadingStream.StreamDictionary.ContainsKey(NameToken.Function))
						{
							functions = GetFunctions(shadingStream.StreamDictionary.Data[NameToken.Function], scanner, filterProvider);
						}
						return new TensorProductPatchMeshesShading(antiAlias, shadingStream, colorSpace, bbox, background, bitsPerCoordinate, bitsPerComponent, bitsPerFlag, decode, functions);
					}
					throw new ArgumentNullException($"{NameToken.Decode} is required for shading type '{ShadingType.TensorProductPatch}'.");
				}
				throw new ArgumentNullException($"{NameToken.BitsPerFlag} is required for shading type '{ShadingType.TensorProductPatch}'.");
			}
			throw new ArgumentNullException($"{NameToken.BitsPerComponent} is required for shading type '{ShadingType.TensorProductPatch}'.");
		}
		throw new ArgumentNullException($"{NameToken.BitsPerCoordinate} is required for shading type '{ShadingType.TensorProductPatch}'.");
	}
}
