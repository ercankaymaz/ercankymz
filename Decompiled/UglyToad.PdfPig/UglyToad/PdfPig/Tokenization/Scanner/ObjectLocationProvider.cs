using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Parser.Parts;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

internal class ObjectLocationProvider : IObjectLocationProvider
{
	private readonly Dictionary<IndirectReference, ObjectToken> cache = new Dictionary<IndirectReference, ObjectToken>();

	private readonly IInputBytes bytes;

	private IReadOnlyDictionary<IndirectReference, long>? bruteForcedOffsets;

	private readonly Dictionary<IndirectReference, long> offsets;

	public ObjectLocationProvider(IReadOnlyDictionary<IndirectReference, long> xrefOffsets, IReadOnlyDictionary<IndirectReference, long>? bruteForcedOffsets, IInputBytes bytes)
	{
		offsets = new Dictionary<IndirectReference, long>();
		foreach (KeyValuePair<IndirectReference, long> xrefOffset in xrefOffsets)
		{
			offsets[xrefOffset.Key] = xrefOffset.Value;
		}
		this.bruteForcedOffsets = bruteForcedOffsets;
		this.bytes = bytes;
	}

	public bool TryGetOffset(IndirectReference reference, out long offset)
	{
		if (bruteForcedOffsets != null && bruteForcedOffsets.TryGetValue(reference, out var value))
		{
			offset = value;
			return true;
		}
		if (offsets.TryGetValue(reference, out offset))
		{
			if (offset + reference.ObjectNumber == 0L)
			{
				throw new PdfDocumentFormatException("Avoiding infinite recursion in ObjectLocationProvider.TryGetOffset() as 'offset' and 'reference.ObjectNumber' have the same value and opposite signs.");
			}
			return true;
		}
		if (bruteForcedOffsets == null)
		{
			bruteForcedOffsets = BruteForceSearcher.GetObjectLocations(bytes);
		}
		return bruteForcedOffsets.TryGetValue(reference, out offset);
	}

	public void UpdateOffset(IndirectReference reference, long offset)
	{
		offsets[reference] = offset;
	}

	public bool TryGetCached(IndirectReference reference, [NotNullWhen(true)] out ObjectToken? objectToken)
	{
		return cache.TryGetValue(reference, out objectToken);
	}

	public void Cache(ObjectToken objectToken, bool force = false)
	{
		if (objectToken == null)
		{
			throw new ArgumentNullException("objectToken");
		}
		if (force || !offsets.TryGetValue(objectToken.Number, out var value) || objectToken.Position == value)
		{
			cache[objectToken.Number] = objectToken;
		}
	}
}
