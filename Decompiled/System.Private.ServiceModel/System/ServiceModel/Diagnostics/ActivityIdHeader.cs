using System.Runtime;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Diagnostics;

internal class ActivityIdHeader : DictionaryHeader
{
	private Guid _guid;

	private Guid _headerId;

	public override XmlDictionaryString DictionaryName => XD.ActivityIdFlowDictionary.ActivityId;

	public override XmlDictionaryString DictionaryNamespace => XD.ActivityIdFlowDictionary.ActivityIdNamespace;

	internal ActivityIdHeader(Guid activityId)
	{
		_guid = activityId;
		_headerId = Guid.NewGuid();
	}

	internal static Guid ExtractActivityId(Message message)
	{
		Guid result = Guid.Empty;
		try
		{
			if (message != null && message.State != MessageState.Closed && message.Headers != null)
			{
				int num = message.Headers.FindHeader("ActivityId", "http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics");
				if (num >= 0)
				{
					using XmlDictionaryReader xmlDictionaryReader = message.Headers.GetReaderAtHeader(num);
					result = xmlDictionaryReader.ReadElementContentAsGuid();
				}
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
		return result;
	}

	internal static bool ExtractActivityAndCorrelationId(Message message, out Guid activityId, out Guid correlationId)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		activityId = Guid.Empty;
		correlationId = Guid.Empty;
		try
		{
			if (message.State != MessageState.Closed && message.Headers != null)
			{
				int num = message.Headers.FindHeader("ActivityId", "http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics");
				if (num >= 0)
				{
					using (XmlDictionaryReader xmlDictionaryReader = message.Headers.GetReaderAtHeader(num))
					{
						correlationId = Fx.CreateGuid(xmlDictionaryReader.GetAttribute("CorrelationId", null));
						activityId = xmlDictionaryReader.ReadElementContentAsGuid();
						return activityId != Guid.Empty;
					}
				}
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
		return false;
	}

	internal void AddTo(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (message.State != MessageState.Closed && message.Headers.MessageVersion.Envelope != EnvelopeVersion.None)
		{
			int num = message.Headers.FindHeader("ActivityId", "http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics");
			if (num < 0)
			{
				message.Headers.Add(this);
			}
		}
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		writer.WriteAttributeString("CorrelationId", _headerId.ToString());
		writer.WriteValue(_guid);
	}
}
