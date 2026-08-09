using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public class UnsupervisedReadingOrderDetector : IReadingOrderDetector
{
	public enum SpatialReasoningRules
	{
		Basic,
		RowWise,
		ColumnWise
	}

	private Func<TextBlock, TextBlock, double, bool> getBeforeInMethod;

	public static UnsupervisedReadingOrderDetector Instance { get; } = new UnsupervisedReadingOrderDetector();

	public bool UseRenderingOrder { get; }

	public SpatialReasoningRules SpatialReasoningRule { get; }

	public double T { get; }

	public UnsupervisedReadingOrderDetector(double T = 5.0, SpatialReasoningRules spatialReasoningRule = SpatialReasoningRules.ColumnWise, bool useRenderingOrder = true)
	{
		this.T = T;
		SpatialReasoningRule = spatialReasoningRule;
		UseRenderingOrder = useRenderingOrder;
		switch (SpatialReasoningRule)
		{
		case SpatialReasoningRules.ColumnWise:
			if (UseRenderingOrder)
			{
				getBeforeInMethod = (TextBlock a, TextBlock b, double t) => GetBeforeInReadingVertical(a, b, t) || GetBeforeInRendering(a, b);
			}
			else
			{
				getBeforeInMethod = GetBeforeInReadingVertical;
			}
			return;
		case SpatialReasoningRules.RowWise:
			if (UseRenderingOrder)
			{
				getBeforeInMethod = (TextBlock a, TextBlock b, double t) => GetBeforeInReadingHorizontal(a, b, t) || GetBeforeInRendering(a, b);
			}
			else
			{
				getBeforeInMethod = GetBeforeInReadingHorizontal;
			}
			return;
		}
		if (UseRenderingOrder)
		{
			getBeforeInMethod = (TextBlock a, TextBlock b, double t) => GetBeforeInReading(a, b, t) || GetBeforeInRendering(a, b);
		}
		else
		{
			getBeforeInMethod = GetBeforeInReading;
		}
	}

	public IEnumerable<TextBlock> Get(IReadOnlyList<TextBlock> textBlocks)
	{
		int readingOrder = 0;
		Dictionary<int, List<int>> graph = BuildGraph(textBlocks, T);
		while (graph.Count > 0)
		{
			int maxCount = graph.Max((KeyValuePair<int, List<int>> kvp) => kvp.Value.Count);
			KeyValuePair<int, List<int>> keyValuePair = graph.FirstOrDefault((KeyValuePair<int, List<int>> kvp) => kvp.Value.Count == maxCount);
			graph.Remove(keyValuePair.Key);
			int key = keyValuePair.Key;
			foreach (KeyValuePair<int, List<int>> item in graph)
			{
				item.Value.Remove(key);
			}
			TextBlock textBlock = textBlocks[key];
			textBlock.SetReadingOrder(readingOrder++);
			yield return textBlock;
		}
	}

	private Dictionary<int, List<int>> BuildGraph(IReadOnlyList<TextBlock> textBlocks, double T)
	{
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		for (int i = 0; i < textBlocks.Count; i++)
		{
			dictionary.Add(i, new List<int>());
		}
		for (int j = 0; j < textBlocks.Count; j++)
		{
			TextBlock arg = textBlocks[j];
			for (int k = 0; k < textBlocks.Count; k++)
			{
				if (j != k)
				{
					TextBlock arg2 = textBlocks[k];
					if (getBeforeInMethod(arg, arg2, T))
					{
						dictionary[j].Add(k);
					}
				}
			}
		}
		return dictionary;
	}

	private static bool GetBeforeInRendering(TextBlock a, TextBlock b)
	{
		double num = (from l in a.TextLines.SelectMany((TextLine tl) => tl.Words).SelectMany((Word w) => w.Letters)
			select l.TextSequence).Average();
		double num2 = (from l in b.TextLines.SelectMany((TextLine tl) => tl.Words).SelectMany((Word w) => w.Letters)
			select l.TextSequence).Average();
		return num < num2;
	}

	private static bool GetBeforeInReading(TextBlock a, TextBlock b, double T)
	{
		IntervalRelations relationX = IntervalRelationsHelper.GetRelationX(a.BoundingBox, b.BoundingBox, T);
		IntervalRelations relationY = IntervalRelationsHelper.GetRelationY(a.BoundingBox, b.BoundingBox, T);
		if (relationX != IntervalRelations.Precedes && relationY != IntervalRelations.Precedes && relationX != IntervalRelations.Meets && relationY != IntervalRelations.Meets && relationX != IntervalRelations.Overlaps)
		{
			return relationY == IntervalRelations.Overlaps;
		}
		return true;
	}

	private static bool GetBeforeInReadingVertical(TextBlock a, TextBlock b, double T)
	{
		IntervalRelations relationX = IntervalRelationsHelper.GetRelationX(a.BoundingBox, b.BoundingBox, T);
		IntervalRelations relationY = IntervalRelationsHelper.GetRelationY(a.BoundingBox, b.BoundingBox, T);
		if (relationX != IntervalRelations.Precedes && relationX != IntervalRelations.Meets && (relationX != IntervalRelations.Overlaps || (relationY != IntervalRelations.Precedes && relationY != IntervalRelations.Meets && relationY != IntervalRelations.Overlaps)))
		{
			if (relationY == IntervalRelations.Precedes || relationY == IntervalRelations.Meets || relationY == IntervalRelations.Overlaps)
			{
				if (relationX != IntervalRelations.Precedes && relationX != IntervalRelations.Meets && relationX != IntervalRelations.Overlaps && relationX != IntervalRelations.Starts && relationX != IntervalRelations.FinishesI && relationX != IntervalRelations.Equals && relationX != IntervalRelations.During && relationX != IntervalRelations.DuringI && relationX != IntervalRelations.Finishes && relationX != IntervalRelations.StartsI)
				{
					return relationX == IntervalRelations.OverlapsI;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private static bool GetBeforeInReadingHorizontal(TextBlock a, TextBlock b, double T)
	{
		IntervalRelations relationX = IntervalRelationsHelper.GetRelationX(a.BoundingBox, b.BoundingBox, T);
		IntervalRelations relationY = IntervalRelationsHelper.GetRelationY(a.BoundingBox, b.BoundingBox, T);
		if (relationY != IntervalRelations.Precedes && relationY != IntervalRelations.Meets && (relationY != IntervalRelations.Overlaps || (relationX != IntervalRelations.Precedes && relationX != IntervalRelations.Meets && relationX != IntervalRelations.Overlaps)))
		{
			if (relationX == IntervalRelations.Precedes || relationX == IntervalRelations.Meets || relationX == IntervalRelations.Overlaps)
			{
				if (relationY != IntervalRelations.Precedes && relationY != IntervalRelations.Meets && relationY != IntervalRelations.Overlaps && relationY != IntervalRelations.Starts && relationY != IntervalRelations.FinishesI && relationY != IntervalRelations.Equals && relationY != IntervalRelations.During && relationY != IntervalRelations.DuringI && relationY != IntervalRelations.Finishes && relationY != IntervalRelations.StartsI)
				{
					return relationY == IntervalRelations.OverlapsI;
				}
				return true;
			}
			return false;
		}
		return true;
	}
}
