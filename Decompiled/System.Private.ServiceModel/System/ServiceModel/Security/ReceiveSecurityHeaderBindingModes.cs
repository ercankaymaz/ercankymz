namespace System.ServiceModel.Security;

[Flags]
internal enum ReceiveSecurityHeaderBindingModes
{
	Unknown = 0,
	Primary = 1,
	Endorsing = 2,
	Signed = 4,
	SignedEndorsing = 8,
	Basic = 0x10
}
