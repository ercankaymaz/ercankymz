using System.Collections.Generic;
using devDept.Eyeshot;

namespace devDept.Serialization;

internal class LayerExSurrogate : LayerSurrogate
{
	public string XRefName_V12;

	public List<KeyValuePair<short, ProtoObject>> XData_V12 { get; set; }

	public LayerExSurrogate(LayerEx layerEx)
		: base(layerEx)
	{
	}

	protected override Layer ConvertToObject()
	{
		Layer layer = new Layer(Name, Color, LineTypeName, LineWeight, Visible, Locked);
		XRefName = XRefName_V12;
		base.XData = XData_V12;
		CopyDataToObject(layer);
		return layer;
	}
}
