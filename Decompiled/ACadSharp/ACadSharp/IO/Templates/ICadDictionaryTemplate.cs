namespace ACadSharp.IO.Templates;

internal interface ICadDictionaryTemplate : ICadObjectTemplate, ICadTemplate
{
	new CadObject CadObject { get; set; }
}
