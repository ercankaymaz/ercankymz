using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.CrossReference;

internal class CrossReferenceTableBuilder
{
	private readonly List<CrossReferenceTablePart> parts = new List<CrossReferenceTablePart>();

	public IReadOnlyList<CrossReferenceTablePart> Parts => parts;

	public void Add(CrossReferenceTablePart part)
	{
		if (part == null)
		{
			throw new ArgumentNullException("part");
		}
		parts.Add(part);
	}

	public CrossReferenceTable Build(long firstCrossReferenceOffset, long offsetCorrection, bool isLenientParsing, ILog log)
	{
		CrossReferenceType type = CrossReferenceType.Table;
		DictionaryToken dictionaryToken = new DictionaryToken(new Dictionary<NameToken, IToken>());
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>();
		List<long> list = new List<long>();
		CrossReferenceTablePart crossReferenceTablePart = parts.FirstOrDefault((CrossReferenceTablePart x) => x.Offset == firstCrossReferenceOffset);
		if (crossReferenceTablePart == null)
		{
			log.Warn($"Did not find an XRef object at the specified startxref position {firstCrossReferenceOffset}");
			list.AddRange(parts.Select((CrossReferenceTablePart x) => x.Offset));
			list.Sort();
		}
		else
		{
			type = crossReferenceTablePart.Type;
			list.Add(firstCrossReferenceOffset);
			while (crossReferenceTablePart.Dictionary != null)
			{
				CrossReferenceTablePart activePart = crossReferenceTablePart;
				foreach (CrossReferenceTablePart item in parts.Where((CrossReferenceTablePart x) => x.TiedToXrefAtOffset == activePart.Offset))
				{
					list.Add(item.Offset);
				}
				long prevBytePos = crossReferenceTablePart.GetPreviousOffset();
				if (prevBytePos == -1)
				{
					break;
				}
				crossReferenceTablePart = parts.FirstOrDefault((CrossReferenceTablePart x) => x.Offset == prevBytePos || x.Offset == prevBytePos + offsetCorrection);
				if (crossReferenceTablePart == null)
				{
					log.Warn("Did not found XRef object pointed to by 'Prev' key at position " + prevBytePos);
					break;
				}
				list.Add(prevBytePos);
				if (list.Count >= parts.Count)
				{
					break;
				}
			}
			list.Reverse();
		}
		foreach (long bPos in list)
		{
			CrossReferenceTablePart crossReferenceTablePart2 = parts.First((CrossReferenceTablePart x) => x.Offset == bPos || x.Offset == bPos + offsetCorrection);
			if (crossReferenceTablePart2.Dictionary != null)
			{
				foreach (KeyValuePair<string, IToken> datum in crossReferenceTablePart2.Dictionary.Data)
				{
					if (!datum.Key.Equals("Size", StringComparison.OrdinalIgnoreCase) || !dictionaryToken.ContainsKey(NameToken.Size))
					{
						dictionaryToken = dictionaryToken.With(datum.Key, datum.Value);
					}
				}
			}
			foreach (KeyValuePair<IndirectReference, long> objectOffset in crossReferenceTablePart2.ObjectOffsets)
			{
				dictionary[objectOffset.Key] = objectOffset.Value;
			}
		}
		return new CrossReferenceTable(type, dictionary, new TrailerDictionary(dictionaryToken, isLenientParsing), parts.Select(delegate(CrossReferenceTablePart x)
		{
			long previousOffset = x.GetPreviousOffset();
			return new CrossReferenceTable.CrossReferenceOffset(x.Offset, (previousOffset >= 0) ? new long?(previousOffset) : ((long?)null));
		}).ToList());
	}
}
