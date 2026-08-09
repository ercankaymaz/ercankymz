using System.Collections;
using System.Collections.Generic;

namespace System.ServiceModel.Channels;

public sealed class UnderstoodHeaders : IEnumerable<MessageHeaderInfo>, IEnumerable
{
	private MessageHeaders _messageHeaders;

	internal bool Modified { get; set; }

	internal UnderstoodHeaders(MessageHeaders messageHeaders, bool modified)
	{
		_messageHeaders = messageHeaders;
		Modified = modified;
	}

	public void Add(MessageHeaderInfo headerInfo)
	{
		_messageHeaders.AddUnderstood(headerInfo);
		Modified = true;
	}

	public bool Contains(MessageHeaderInfo headerInfo)
	{
		return _messageHeaders.IsUnderstood(headerInfo);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<MessageHeaderInfo> GetEnumerator()
	{
		return _messageHeaders.GetUnderstoodEnumerator();
	}

	public void Remove(MessageHeaderInfo headerInfo)
	{
		_messageHeaders.RemoveUnderstood(headerInfo);
		Modified = true;
	}
}
