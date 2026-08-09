namespace System.ServiceModel.Channels;

internal enum FramingRecordType
{
	Version,
	Mode,
	Via,
	KnownEncoding,
	ExtensibleEncoding,
	UnsizedEnvelope,
	SizedEnvelope,
	End,
	Fault,
	UpgradeRequest,
	UpgradeResponse,
	PreambleAck,
	PreambleEnd
}
