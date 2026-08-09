using System;
using System.Collections.Generic;

namespace buPop3.Mime.Traverse;

public abstract class MultipleMessagePartFinder : AnswerMessageTraverser<List<MessagePart>>
{
	protected override List<MessagePart> MergeLeafAnswers(List<List<MessagePart>> leafAnswers)
	{
		if (leafAnswers != null)
		{
			List<MessagePart> list = new List<MessagePart>();
			foreach (List<MessagePart> leafAnswer in leafAnswers)
			{
				list.AddRange(leafAnswer);
			}
			return list;
		}
		throw new ArgumentNullException("leafAnswers");
	}
}
