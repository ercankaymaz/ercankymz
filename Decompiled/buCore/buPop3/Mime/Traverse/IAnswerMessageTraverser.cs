namespace buPop3.Mime.Traverse;

public interface IAnswerMessageTraverser<TAnswer>
{
	TAnswer VisitMessage(Message message);

	TAnswer VisitMessagePart(MessagePart messagePart);
}
