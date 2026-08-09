using System;
using System.Collections.Generic;
using buPop3.Mime;
using buPop3.Mime.Traverse;

namespace ns50;

internal class Class132 : MultipleMessagePartFinder
{
	protected override List<MessagePart> CaseLeaf(MessagePart messagePart)
	{
		if (messagePart != null)
		{
			List<MessagePart> list = new List<MessagePart>(1);
			if (messagePart.IsAttachment)
			{
				list.Add(messagePart);
			}
			return list;
		}
		throw new ArgumentNullException("messagePart");
	}
}
