using System;
using System.Collections.Generic;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;

namespace ACadSharp.IO.Templates;

internal class CadTableTemplate<T> : CadTemplate<Table<T>>, ICadTableTemplate, ICadObjectTemplate, ICadTemplate where T : TableEntry
{
	public HashSet<ulong> EntryHandles { get; } = new HashSet<ulong>();

	public CadTableTemplate(Table<T> tableControl)
		: base(tableControl)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (ulong entryHandle in EntryHandles)
		{
			if (builder.TryGetCadObject<T>(entryHandle, out var value))
			{
				try
				{
					base.CadObject.Add(value);
				}
				catch (ArgumentException exception)
				{
					builder.Notify("[" + base.CadObject.SubclassMarker + "] the entry " + value.Name + " already exists", NotificationType.Error, exception);
				}
				catch (Exception exception2)
				{
					builder.Notify($"Error adding the entry [handle : {entryHandle}] [type : {typeof(T)}]", NotificationType.Error, exception2);
				}
			}
		}
	}
}
