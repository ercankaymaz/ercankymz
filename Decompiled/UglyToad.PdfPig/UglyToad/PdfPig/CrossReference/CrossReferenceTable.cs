using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.CrossReference;

public class CrossReferenceTable
{
	public readonly struct CrossReferenceOffset
	{
		public long Current { get; }

		public long? Previous { get; }

		public CrossReferenceOffset(long current, long? previous)
		{
			Current = current;
			Previous = previous;
		}

		public override string ToString()
		{
			string arg = (Previous.HasValue ? $" {Previous}" : string.Empty);
			return $"{Current}{arg}";
		}
	}

	private readonly Dictionary<IndirectReference, long> objectOffsets;

	public IReadOnlyDictionary<IndirectReference, long> ObjectOffsets => objectOffsets;

	public CrossReferenceType Type { get; }

	public TrailerDictionary Trailer { get; }

	public IReadOnlyList<CrossReferenceOffset> CrossReferenceOffsets { get; }

	internal CrossReferenceTable(CrossReferenceType type, IReadOnlyDictionary<IndirectReference, long> objectOffsets, TrailerDictionary trailer, IReadOnlyList<CrossReferenceOffset> crossReferenceOffsets)
	{
		if (objectOffsets == null)
		{
			throw new ArgumentNullException("objectOffsets");
		}
		Type = type;
		Trailer = trailer ?? throw new ArgumentNullException("trailer");
		CrossReferenceOffsets = crossReferenceOffsets ?? throw new ArgumentNullException("crossReferenceOffsets");
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>(objectOffsets.Count);
		foreach (KeyValuePair<IndirectReference, long> objectOffset in objectOffsets)
		{
			dictionary[objectOffset.Key] = objectOffset.Value;
		}
		this.objectOffsets = dictionary;
	}
}
