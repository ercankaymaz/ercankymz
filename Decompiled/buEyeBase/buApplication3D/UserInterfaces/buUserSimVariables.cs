using System.Collections.Generic;
using devDept.Geometry;

namespace buApplication3D.UserInterfaces;

public class buUserSimVariables
{
	public static int indexSim = -1;

	public static List<int> SimMovePartIndex = new List<int>();

	public static bool isMachineCreated = false;

	public static Point3D pntMouseViewport = null;

	public static void Init()
	{
		SimMovePartIndex = new List<int>();
		pntMouseViewport = new Point3D();
	}
}
