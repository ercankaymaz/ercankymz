namespace System.ServiceModel.Diagnostics;

internal enum ActivityType
{
	Unknown,
	Close,
	Construct,
	ExecuteUserCode,
	ListenAt,
	Open,
	OpenClient,
	ProcessMessage,
	ProcessAction,
	ReceiveBytes,
	SecuritySetup,
	TransferToComPlus,
	WmiGetObject,
	WmiPutInstance,
	NumItems
}
