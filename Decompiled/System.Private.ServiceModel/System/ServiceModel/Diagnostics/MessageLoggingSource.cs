namespace System.ServiceModel.Diagnostics;

[Flags]
internal enum MessageLoggingSource
{
	None = 0,
	TransportReceive = 2,
	TransportSend = 4,
	Transport = 6,
	ServiceLevelReceiveDatagram = 0x10,
	ServiceLevelSendDatagram = 0x20,
	ServiceLevelReceiveRequest = 0x40,
	ServiceLevelSendRequest = 0x80,
	ServiceLevelReceiveReply = 0x100,
	ServiceLevelSendReply = 0x200,
	ServiceLevelReceive = 0x150,
	ServiceLevelSend = 0x2A0,
	ServiceLevelService = 0x250,
	ServiceLevelProxy = 0x1A0,
	ServiceLevel = 0x3F0,
	Malformed = 0x400,
	LastChance = 0x800,
	All = int.MaxValue
}
