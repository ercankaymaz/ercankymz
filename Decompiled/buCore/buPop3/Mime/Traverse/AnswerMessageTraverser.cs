using System;
using System.Collections.Generic;

namespace buPop3.Mime.Traverse;

public abstract class AnswerMessageTraverser<TAnswer> : IAnswerMessageTraverser<TAnswer>
{
	public TAnswer VisitMessage(Message message)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		return VisitMessagePart(message.MessagePart);
	}

	public TAnswer VisitMessagePart(MessagePart messagePart)
	{
		if (messagePart != null)
		{
			if (!messagePart.IsMultiPart)
			{
				return CaseLeaf(messagePart);
			}
			List<TAnswer> list = new List<TAnswer>(messagePart.MessageParts.Count);
			foreach (MessagePart messagePart2 in messagePart.MessageParts)
			{
				list.Add(VisitMessagePart(messagePart2));
			}
			return MergeLeafAnswers(list);
		}
		throw new ArgumentNullException("messagePart");
	}

	protected abstract TAnswer CaseLeaf(MessagePart messagePart);

	protected abstract TAnswer MergeLeafAnswers(List<TAnswer> leafAnswers);
}
