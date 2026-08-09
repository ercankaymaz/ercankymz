using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadShapeTemplate : CadEntityTemplate
{
	public ushort? ShapeIndex { get; set; }

	public ulong? ShapeFileHandle { get; set; }

	public string ShapeFileName { get; set; }

	public CadShapeTemplate(Shape shape)
		: base(shape)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		Shape shape = base.CadObject as Shape;
		if (getTableReference<TextStyle>(builder, ShapeFileHandle, ShapeFileName, out var reference))
		{
			if (reference.IsShapeFile)
			{
				shape.ShapeStyle = reference;
			}
			else
			{
				builder.Notify($"Shape style {ShapeFileHandle} | {ShapeFileName} not found", NotificationType.Warning);
			}
		}
	}
}
