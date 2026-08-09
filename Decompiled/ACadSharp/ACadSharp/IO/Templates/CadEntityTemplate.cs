using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSUtilities.Extensions;

namespace ACadSharp.IO.Templates;

internal class CadEntityTemplate : CadTemplate<Entity>
{
	public string BookColorName { get; set; }

	public ulong? ColorHandle { get; set; }

	public byte EntityMode { get; set; }

	public ulong? LayerHandle { get; set; }

	public string LayerName { get; set; }

	public ulong? LineTypeHandle { get; set; }

	public string LineTypeName { get; set; }

	public byte? LtypeFlags { get; set; }

	public ulong? MaterialHandle { get; set; }

	public ulong? NextEntity { get; set; }

	public ulong? PrevEntity { get; set; }

	public CadEntityTemplate(Entity entity)
		: base(entity)
	{
	}

	public void SetUnlinkedReferences()
	{
		if (!string.IsNullOrEmpty(LayerName))
		{
			base.CadObject.Layer = new Layer(LayerName);
		}
		if (!string.IsNullOrEmpty(LineTypeName))
		{
			base.CadObject.LineType = new LineType(LineTypeName);
		}
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (getTableReference<Layer>(builder, LayerHandle, LayerName, out var reference))
		{
			base.CadObject.Layer = reference;
		}
		switch (LtypeFlags)
		{
		case 0:
			LineTypeName = "ByLayer";
			break;
		case 1:
			LineTypeName = "ByBlock";
			break;
		case 2:
			LineTypeName = "Continuous";
			break;
		}
		if (getTableReference<LineType>(builder, LineTypeHandle, LineTypeName, out var reference2))
		{
			base.CadObject.LineType = reference2;
		}
		if (builder.TryGetCadObject<BookColor>(ColorHandle, out var value))
		{
			base.CadObject.BookColor = value;
		}
		else if (!BookColorName.IsNullOrEmpty() && builder.DocumentToBuild != null && builder.DocumentToBuild.Colors != null && builder.DocumentToBuild.Colors.TryGet(BookColorName, out value))
		{
			base.CadObject.BookColor = value;
		}
	}
}
internal class CadEntityTemplate<T> : CadEntityTemplate where T : Entity, new()
{
	public new T CadObject
	{
		get
		{
			return (T)base.CadObject;
		}
		set
		{
			base.CadObject = value;
		}
	}

	public CadEntityTemplate()
		: base(new T())
	{
	}

	public CadEntityTemplate(T entity)
		: base(entity)
	{
	}
}
