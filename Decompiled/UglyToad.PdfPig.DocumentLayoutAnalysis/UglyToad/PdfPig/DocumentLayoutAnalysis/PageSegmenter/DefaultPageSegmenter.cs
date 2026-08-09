using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

public class DefaultPageSegmenter : IPageSegmenter
{
	public class DefaultPageSegmenterOptions : IPageSegmenterOptions, IDlaOptions
	{
		public int MaxDegreeOfParallelism { get; set; } = -1;

		public string WordSeparator { get; set; } = " ";

		public string LineSeparator { get; set; } = "\n";
	}

	private readonly DefaultPageSegmenterOptions options;

	public static DefaultPageSegmenter Instance { get; } = new DefaultPageSegmenter();

	public DefaultPageSegmenter()
		: this(new DefaultPageSegmenterOptions())
	{
	}

	public DefaultPageSegmenter(DefaultPageSegmenterOptions options)
	{
		this.options = options ?? throw new ArgumentNullException("options");
	}

	public IReadOnlyList<TextBlock> GetBlocks(IEnumerable<Word> words)
	{
		if (words == null || !words.Any())
		{
			return Array.Empty<TextBlock>();
		}
		return new List<TextBlock>
		{
			new TextBlock(new XYLeaf(words).GetLines(options.WordSeparator), options.LineSeparator)
		};
	}
}
