namespace System.ServiceModel.Channels;

internal interface ICorrelatorKey
{
	RequestReplyCorrelator.Key RequestCorrelatorKey { get; set; }
}
