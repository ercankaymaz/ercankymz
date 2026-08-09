using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class MachineDefPart : buSerilization5
{
	public string PartName = "Part";

	public string PartFileName = Application.StartupPath;

	public bool isMoveable = true;

	public bool isBelongToBody = false;

	public string Tag = "";

	public int No = -1;

	public AxesEnable MoveAxisPermision = new AxesEnable(x: true, y: true, z: true, a: false, b: false, c: false);

	public List<Entity> Entities = new List<Entity>();

	public Color Color = Color.Gray;

	public Point3D PositionBaseOffset = new Point3D();

	public Point3D PositionAuxOffset = new Point3D();

	public double RotationDistance = 0.0;

	public double Stroke = 0.0;

	public Point3D RotationCenter = new Point3D();

	public int Transparency = 255;

	public bool AddAsMesh = false;

	public string PartType = "";

	public MachineDefPart()
	{
	}

	public MachineDefPart(MachineDefPart item)
	{
		PartName = item.PartName;
		Color = item.Color;
		Entities = new List<Entity>();
		buVector5.CopyEntities(item.Entities, ref Entities);
	}

	public override string ToString()
	{
		return PartFileName + " - " + MoveAxisPermision.ToString();
	}
}
