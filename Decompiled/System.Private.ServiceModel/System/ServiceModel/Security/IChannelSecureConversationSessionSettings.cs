namespace System.ServiceModel.Security;

internal interface IChannelSecureConversationSessionSettings
{
	TimeSpan KeyRenewalInterval { get; set; }

	TimeSpan KeyRolloverInterval { get; set; }

	bool TolerateTransportFailures { get; set; }
}
