using System;
using System.Collections.Generic;
using ACadSharp.IO.DWG;
using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadDictionaryTemplate : CadTemplate<CadDictionary>, ICadDictionaryTemplate, ICadObjectTemplate, ICadTemplate
{
	public Dictionary<string, ulong?> Entries { get; set; } = new Dictionary<string, ulong?>();

	public CadDictionaryTemplate()
		: base(new CadDictionary())
	{
	}

	public CadDictionaryTemplate(CadDictionary dictionary)
		: base(dictionary)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (base.OwnerHandle.HasValue && base.OwnerHandle == 0 && builder.DocumentToBuild.RootDictionary == null)
		{
			if (builder is DwgDocumentBuilder dwgDocumentBuilder && base.CadObject.Handle == dwgDocumentBuilder.HeaderHandles.DICTIONARY_NAMED_OBJECTS)
			{
				builder.DocumentToBuild.RootDictionary = base.CadObject;
			}
			else
			{
				builder.DocumentToBuild.RootDictionary = base.CadObject;
			}
		}
		foreach (KeyValuePair<string, ulong?> entry in Entries)
		{
			if (builder.TryGetCadObject<NonGraphicalObject>(entry.Value, out var value))
			{
				if (string.IsNullOrEmpty(value.Name))
				{
					value.Name = entry.Key;
				}
				try
				{
					base.CadObject.Add(value.Name, value);
				}
				catch (Exception exception)
				{
					builder.Notify($"Error when trying to add the entry {value.Name} to {base.CadObject.Name}|{base.CadObject.Handle}", NotificationType.Error, exception);
				}
			}
			else
			{
				builder.Notify($"Entry not found {entry.Key}|{entry.Value} for dictionary {base.CadObject.Name}|{base.CadObject.Handle}", NotificationType.Warning);
			}
		}
	}
}
