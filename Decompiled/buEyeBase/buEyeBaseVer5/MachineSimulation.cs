using System.Collections.Generic;
using buClass;
using devDept.Eyeshot;

namespace buEyeBaseVer5;

public class MachineSimulation
{
	public List<int> SimMovePartIndex = new List<int>();

	public static CollisionDetection colDetect;

	public Pnt6D pntSimOffset = new Pnt6D();
}
