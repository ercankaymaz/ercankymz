using System.Collections.Generic;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadLineTypeTemplate : CadTableEntryTemplate<LineType>
{
	public class SegmentTemplate
	{
		public ulong? StyleHandle { get; set; }

		public LineType.Segment Segment { get; set; } = new LineType.Segment();

		public void Build(CadDocumentBuilder builder)
		{
			if (builder.TryGetCadObject<TextStyle>(StyleHandle, out var value))
			{
				Segment.Style = value;
			}
		}
	}

	public ulong? LtypeControlHandle { get; set; }

	public double? TotalLen { get; set; }

	public List<SegmentTemplate> SegmentTemplates { get; set; } = new List<SegmentTemplate>();

	public CadLineTypeTemplate()
		: base(new LineType())
	{
	}

	public CadLineTypeTemplate(LineType entry)
		: base(entry)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (SegmentTemplate segmentTemplate in SegmentTemplates)
		{
			segmentTemplate.Build(builder);
			base.CadObject.AddSegment(segmentTemplate.Segment);
		}
	}
}
