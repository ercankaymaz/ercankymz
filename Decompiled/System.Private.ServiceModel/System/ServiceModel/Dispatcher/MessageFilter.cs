using System.Runtime.Serialization;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

[DataContract]
public abstract class MessageFilter
{
	protected internal virtual IMessageFilterTable<FilterData> CreateFilterTable<FilterData>()
	{
		return null;
	}

	public abstract bool Match(MessageBuffer buffer);

	public abstract bool Match(Message message);
}
