using ACadSharp.Entities;
using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadUnderlayTemplate<T> : CadEntityTemplate where T : UnderlayDefinition
{
	public ulong? DefinitionHandle { get; set; }

	public CadUnderlayTemplate(UnderlayEntity<T> entity)
		: base(entity)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		UnderlayEntity<T> underlayEntity = base.CadObject as UnderlayEntity<T>;
		if (builder.TryGetCadObject<T>(DefinitionHandle, out var value))
		{
			underlayEntity.Definition = value;
		}
		else
		{
			builder.Notify($"UnderlayDefinition not found for {base.CadObject.Handle}", NotificationType.Warning);
		}
	}
}
