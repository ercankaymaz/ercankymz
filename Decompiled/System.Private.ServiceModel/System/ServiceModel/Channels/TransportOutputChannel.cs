using System.Runtime.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class TransportOutputChannel : OutputChannel
{
	internal class ToDictionary : IXmlDictionary
	{
		public XmlDictionaryString To { get; }

		public ToDictionary(string to)
		{
			To = new XmlDictionaryString(this, to, 0);
		}

		public bool TryLookup(string value, out XmlDictionaryString result)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == To.Value)
			{
				result = To;
				return true;
			}
			result = null;
			return false;
		}

		public bool TryLookup(int key, out XmlDictionaryString result)
		{
			if (key == 0)
			{
				result = To;
				return true;
			}
			result = null;
			return false;
		}

		public bool TryLookup(XmlDictionaryString value, out XmlDictionaryString result)
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value == To)
			{
				result = To;
				return true;
			}
			result = null;
			return false;
		}
	}

	private bool _anyHeadersToAdd;

	private EndpointAddress _to;

	private Uri _via;

	private ToHeader _toHeader;

	protected bool ManualAddressing { get; }

	public MessageVersion MessageVersion { get; }

	public override EndpointAddress RemoteAddress => _to;

	public override Uri Via => _via;

	public EventTraceActivity EventTraceActivity { get; }

	protected TransportOutputChannel(ChannelManagerBase channelManager, EndpointAddress to, Uri via, bool manualAddressing, MessageVersion messageVersion)
		: base(channelManager)
	{
		ManualAddressing = manualAddressing;
		MessageVersion = messageVersion;
		_to = to;
		_via = via;
		if (!manualAddressing && to != null)
		{
			Uri uri = (to.IsAnonymous ? MessageVersion.Addressing.AnonymousUri : ((!to.IsNone) ? to.Uri : MessageVersion.Addressing.NoneUri));
			if (uri != null)
			{
				XmlDictionaryString to2 = new ToDictionary(uri.AbsoluteUri).To;
				_toHeader = ToHeader.Create(uri, to2, messageVersion.Addressing);
			}
			_anyHeadersToAdd = to.Headers.Count > 0;
		}
		if (FxTrace.Trace.IsEnd2EndActivityTracingEnabled)
		{
			EventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
		}
	}

	protected override void AddHeadersTo(Message message)
	{
		base.AddHeadersTo(message);
		if (_toHeader != null)
		{
			message.Headers.SetToHeader(_toHeader);
			if (_anyHeadersToAdd)
			{
				_to.Headers.AddHeadersTo(message);
			}
		}
	}
}
