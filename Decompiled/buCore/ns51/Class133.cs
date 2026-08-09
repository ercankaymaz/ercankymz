using System;
using System.Collections.Generic;
using buPop3.Mime;
using buPop3.Mime.Traverse;

namespace ns51;

internal class Class133 : MultipleMessagePartFinder
{
	protected override List<MessagePart> CaseLeaf(MessagePart messagePart)
	{
		if (messagePart != null)
		{
			List<MessagePart> list = new List<MessagePart>(1);
			if (messagePart.IsText)
			{
				list.Add(messagePart);
			}
			return list;
		}
		throw new ArgumentNullException("messagePart");
	}
}
