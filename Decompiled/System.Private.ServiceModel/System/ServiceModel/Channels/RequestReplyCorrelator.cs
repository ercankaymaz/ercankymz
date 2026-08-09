using System.Collections;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class RequestReplyCorrelator : IRequestReplyCorrelator
{
	internal struct ReplyToInfo
	{
		private readonly EndpointAddress _replyTo;

		internal EndpointAddress FaultTo { get; }

		internal EndpointAddress From { get; }

		internal bool HasFaultTo => !IsTrivial(FaultTo);

		internal bool HasFrom => !IsTrivial(From);

		internal bool HasReplyTo => !IsTrivial(ReplyTo);

		internal EndpointAddress ReplyTo => _replyTo;

		internal ReplyToInfo(Message message)
		{
			FaultTo = message.Headers.FaultTo;
			_replyTo = message.Headers.ReplyTo;
			if (message.Version.Addressing == AddressingVersion.WSAddressingAugust2004)
			{
				From = message.Headers.From;
			}
			else
			{
				From = null;
			}
		}

		private bool IsTrivial(EndpointAddress address)
		{
			if (!(address == null))
			{
				return address == EndpointAddress.AnonymousAddress;
			}
			return true;
		}
	}

	internal class Key
	{
		internal UniqueId MessageId;

		internal Type StateType;

		internal Key(UniqueId messageId, Type stateType)
		{
			MessageId = messageId;
			StateType = stateType;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Key key))
			{
				return false;
			}
			if (key.MessageId == MessageId)
			{
				return key.StateType == StateType;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return MessageId.GetHashCode() ^ StateType.GetHashCode();
		}

		public override string ToString()
		{
			return typeof(Key).ToString() + ": {" + MessageId?.ToString() + ", " + StateType.ToString() + "}";
		}
	}

	private Hashtable _states;

	internal RequestReplyCorrelator()
	{
		_states = new Hashtable();
	}

	void IRequestReplyCorrelator.Add<T>(Message request, T state)
	{
		UniqueId messageId = request.Headers.MessageId;
		Type typeFromHandle = typeof(T);
		Key key = new Key(messageId, typeFromHandle);
		if (state is ICorrelatorKey correlatorKey)
		{
			correlatorKey.RequestCorrelatorKey = key;
		}
		lock (_states)
		{
			_states.Add(key, state);
		}
	}

	T IRequestReplyCorrelator.Find<T>(Message reply, bool remove)
	{
		UniqueId relatesTo = GetRelatesTo(reply);
		Type typeFromHandle = typeof(T);
		Key key = new Key(relatesTo, typeFromHandle);
		T result = (T)_states[key];
		if (remove)
		{
			lock (_states)
			{
				_states.Remove(key);
			}
		}
		return result;
	}

	internal void RemoveRequest(ICorrelatorKey request)
	{
		if (request.RequestCorrelatorKey != null)
		{
			lock (_states)
			{
				_states.Remove(request.RequestCorrelatorKey);
			}
		}
	}

	private UniqueId GetRelatesTo(Message reply)
	{
		UniqueId relatesTo = reply.Headers.RelatesTo;
		if (relatesTo == null)
		{
			throw TraceUtility.ThrowHelperError(new ArgumentException(System.SR.SuppliedMessageIsNotAReplyItHasNoRelatesTo0), reply);
		}
		return relatesTo;
	}

	internal static bool AddressReply(Message reply, Message request)
	{
		ReplyToInfo info = ExtractReplyToInfo(request);
		return AddressReply(reply, info);
	}

	internal static bool AddressReply(Message reply, ReplyToInfo info)
	{
		EndpointAddress endpointAddress = null;
		if (info.HasFaultTo && reply.IsFault)
		{
			endpointAddress = info.FaultTo;
		}
		else if (info.HasReplyTo)
		{
			endpointAddress = info.ReplyTo;
		}
		else if (reply.Version.Addressing == AddressingVersion.WSAddressingAugust2004)
		{
			endpointAddress = ((!info.HasFrom) ? EndpointAddress.AnonymousAddress : info.From);
		}
		if (endpointAddress != null)
		{
			endpointAddress.ApplyTo(reply);
			return !endpointAddress.IsNone;
		}
		return true;
	}

	internal static ReplyToInfo ExtractReplyToInfo(Message message)
	{
		return new ReplyToInfo(message);
	}

	internal static void PrepareRequest(Message request)
	{
		MessageHeaders headers = request.Headers;
		if (headers.MessageId == null)
		{
			headers.MessageId = new UniqueId();
		}
		request.Properties.AllowOutputBatching = false;
		if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
		{
			TraceUtility.AddAmbientActivityToMessage(request);
		}
	}

	internal static void PrepareReply(Message reply, UniqueId messageId)
	{
		if ((object)messageId == null)
		{
			throw TraceUtility.ThrowHelperError(new InvalidOperationException(System.SR.MissingMessageID), reply);
		}
		MessageHeaders headers = reply.Headers;
		if ((object)headers.RelatesTo == null)
		{
			headers.RelatesTo = messageId;
		}
		if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
		{
			TraceUtility.AddAmbientActivityToMessage(reply);
		}
	}

	internal static void PrepareReply(Message reply, Message request)
	{
		UniqueId messageId = request.Headers.MessageId;
		if (messageId != null)
		{
			MessageHeaders headers = reply.Headers;
			if ((object)headers.RelatesTo == null)
			{
				headers.RelatesTo = messageId;
			}
		}
		if (TraceUtility.PropagateUserActivity || TraceUtility.ShouldPropagateActivity)
		{
			TraceUtility.AddAmbientActivityToMessage(reply);
		}
	}
}
