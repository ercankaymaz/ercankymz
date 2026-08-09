using devDept.Eyeshot;

namespace devDept.Serialization;

internal class IfcLayerSurrogate : LayerSurrogate
{
	public string Description_V15;

	public string Identifier_V15;

	public IfcLayerSurrogate(IfcLayer ifcBlockReference)
		: base(ifcBlockReference)
	{
	}

	protected override void CopyDataToObject(Layer layer)
	{
		base.CopyDataToObject(layer);
		layer.Description = Description_V15;
		layer.Identifier = Identifier_V15;
	}
}
