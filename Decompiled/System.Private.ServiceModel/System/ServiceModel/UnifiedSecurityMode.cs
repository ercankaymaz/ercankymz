namespace System.ServiceModel;

[Flags]
public enum UnifiedSecurityMode
{
	None = 1,
	Transport = 4,
	Message = 8,
	Both = 0x10,
	TransportWithMessageCredential = 0x20,
	TransportCredentialOnly = 0x40
}
