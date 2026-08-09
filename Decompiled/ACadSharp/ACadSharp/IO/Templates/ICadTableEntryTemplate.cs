namespace ACadSharp.IO.Templates;

internal interface ICadTableEntryTemplate : ICadObjectTemplate, ICadTemplate
{
	string Type { get; }

	string Name { get; }
}
