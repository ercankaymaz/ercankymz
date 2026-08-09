using System;
using System.Collections.Generic;
using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadXRecordTemplate : CadTemplate<XRecord>
{
	private readonly List<Tuple<int, ulong>> _entries = new List<Tuple<int, ulong>>();

	public CadXRecordTemplate()
		: base(new XRecord())
	{
	}

	public CadXRecordTemplate(XRecord cadObject)
		: base(cadObject)
	{
	}

	public void AddHandleReference(int code, ulong handle)
	{
		_entries.Add(new Tuple<int, ulong>(code, handle));
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (Tuple<int, ulong> entry in _entries)
		{
			if (builder.TryGetCadObject<CadObject>(entry.Item2, out var value))
			{
				base.CadObject.CreateEntry(entry.Item1, value);
			}
			else
			{
				builder.Notify($"XRecord reference not found {entry.Item1}|{entry.Item2}", NotificationType.Warning);
			}
		}
	}
}
