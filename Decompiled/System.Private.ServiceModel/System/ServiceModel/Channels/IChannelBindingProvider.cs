namespace System.ServiceModel.Channels;

internal interface IChannelBindingProvider
{
	bool IsChannelBindingSupportEnabled { get; }

	void EnableChannelBindingSupport();
}
