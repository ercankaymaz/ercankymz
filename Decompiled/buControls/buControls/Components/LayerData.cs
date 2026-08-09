using System.Drawing;

namespace buControls.Components;

public class LayerData
{
	public string Name = "";

	public bool Lock = false;

	public bool Visible = true;

	public Color color = Color.Blue;

	public LayerData()
	{
	}

	public LayerData(string name, bool locked, bool visible, Color clr)
	{
		Name = name;
		Lock = locked;
		Visible = visible;
		color = clr;
	}
}
