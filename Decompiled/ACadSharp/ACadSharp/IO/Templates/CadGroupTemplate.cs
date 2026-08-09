using System;
using System.Collections.Generic;
using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadGroupTemplate : CadTemplate<Group>
{
	public HashSet<ulong> Handles { get; set; } = new HashSet<ulong>();

	public CadGroupTemplate()
		: base(new Group())
	{
	}

	public CadGroupTemplate(Group group)
		: base(group)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (ulong handle in Handles)
		{
			if (builder.TryGetObjectTemplate<CadEntityTemplate>(handle, out var value))
			{
				value.Build(builder);
				try
				{
					base.CadObject.Add(value.CadObject);
				}
				catch (Exception exception)
				{
					builder.Notify($"Entity with handle {handle} could not be added to group {base.CadObject.Handle}", NotificationType.Error, exception);
				}
			}
			else
			{
				builder.Notify($"Entity with handle {handle} not found for group {base.CadObject.Handle}", NotificationType.Warning);
			}
		}
	}
}
