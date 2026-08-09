namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class System_002EFormats_002EAsn13538873_002EMemberNotNullAttribute : Attribute
{
	public string[] Members { get; }

	public System_002EFormats_002EAsn13538873_002EMemberNotNullAttribute(string member)
	{
		Members = new string[1] { member };
	}

	public System_002EFormats_002EAsn13538873_002EMemberNotNullAttribute(params string[] members)
	{
		Members = members;
	}
}
