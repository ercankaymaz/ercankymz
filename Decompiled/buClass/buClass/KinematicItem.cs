using System.Collections.Generic;
using System.Drawing;

namespace buClass;

public class KinematicItem : buSerilization
{
	public string PartName = "Part";

	public List<eEntities> Entities = new List<eEntities>();

	public AxesEnable Axis = new AxesEnable(x: true, y: true, z: true);

	public Color Color = Color.Gray;

	public KinematicItem()
	{
	}

	public KinematicItem(KinematicItem item)
	{
		PartName = item.PartName;
		Color = item.Color;
		Axis = new AxesEnable(item.Axis);
		Entities = new List<eEntities>();
		eEntities.CopyEntities(item.Entities, ref Entities);
	}

	public override string ToString()
	{
		return PartName;
	}
}
