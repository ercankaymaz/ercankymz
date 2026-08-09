namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class System_002EDiagnostics_002EDiagnosticSource3462135_002EMemberNotNullAttribute : Attribute
{
	public string[] Members { get; }

	public System_002EDiagnostics_002EDiagnosticSource3462135_002EMemberNotNullAttribute(string member)
	{
		Members = new string[1] { member };
	}

	public System_002EDiagnostics_002EDiagnosticSource3462135_002EMemberNotNullAttribute(params string[] members)
	{
		Members = members;
	}
}
