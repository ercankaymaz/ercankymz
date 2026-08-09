using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadMLineStyleTemplate : CadTemplate<MLineStyle>
{
	public class ElementTemplate
	{
		public MLineStyle.Element Element { get; set; }

		public ulong? LineTypeHandle { get; set; }

		public int? LinetypeIndex { get; set; }

		public string LineTypeName { get; set; }

		public ElementTemplate(MLineStyle.Element element)
		{
			Element = element;
		}

		public void Build(CadDocumentBuilder builder)
		{
			if (builder.TryGetCadObject<LineType>(LineTypeHandle, out var value))
			{
				Element.LineType = value;
			}
			else if (builder.TryGetTableEntry<LineType>(LineTypeName, out value))
			{
				Element.LineType = value;
			}
			else
			{
				if (!LinetypeIndex.HasValue)
				{
					return;
				}
				if (LinetypeIndex == 32767)
				{
					if (builder.TryGetTableEntry<LineType>("ByLayer", out var entry))
					{
						Element.LineType = entry;
					}
					return;
				}
				if (LinetypeIndex != 32766)
				{
					try
					{
						Element.LineType = builder.LineTypesTable.ElementAt(LinetypeIndex.Value);
						return;
					}
					catch (Exception exception)
					{
						builder.Notify($"Linetype not assigned, index {LinetypeIndex}", NotificationType.Error, exception);
						return;
					}
				}
				if (builder.TryGetTableEntry<LineType>("ByBlock", out var entry2))
				{
					Element.LineType = entry2;
				}
			}
		}
	}

	public List<ElementTemplate> ElementTemplates { get; set; } = new List<ElementTemplate>();

	public CadMLineStyleTemplate()
		: base(new MLineStyle())
	{
	}

	public CadMLineStyleTemplate(MLineStyle mlStyle)
		: base(mlStyle)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (ElementTemplate elementTemplate in ElementTemplates)
		{
			elementTemplate.Build(builder);
		}
	}
}
