using System;
using System.Collections.Generic;
using buPop3.Mime;
using buPop3.Mime.Traverse;

namespace ns51;

internal class Class134 : IQuestionAnswerMessageTraverser<string, List<MessagePart>>
{
	public List<MessagePart> VisitMessage(Message message, string question)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		return VisitMessagePart(message.MessagePart, question);
	}

	public List<MessagePart> VisitMessagePart(MessagePart messagePart, string question)
	{
		if (messagePart != null)
		{
			List<MessagePart> list = new List<MessagePart>();
			if (messagePart.ContentType.MediaType.Equals(question, StringComparison.OrdinalIgnoreCase))
			{
				list.Add(messagePart);
			}
			if (messagePart.IsMultiPart)
			{
				foreach (MessagePart messagePart2 in messagePart.MessageParts)
				{
					List<MessagePart> collection = VisitMessagePart(messagePart2, question);
					list.AddRange(collection);
				}
			}
			return list;
		}
		throw new ArgumentNullException("messagePart");
	}
}
