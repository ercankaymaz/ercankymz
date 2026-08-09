using System.Net.Security;

namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public sealed class PeerHopCountAttribute : MessageHeaderAttribute
{
	public new bool MustUnderstand => base.MustUnderstand;

	public new bool Relay => base.Relay;

	public new string Actor => base.Actor;

	public new string Namespace => base.Namespace;

	public new string Name => base.Name;

	public new ProtectionLevel ProtectionLevel => base.ProtectionLevel;

	public PeerHopCountAttribute()
	{
		base.Name = "Hops";
		base.Namespace = "http://schemas.microsoft.com/net/2006/05/peer/HopCount";
		base.ProtectionLevel = ProtectionLevel.None;
		base.MustUnderstand = false;
	}
}
