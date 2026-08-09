namespace buClass;

public class ePlaneEntities : eEntities
{
	public WorkPlane Plane = new WorkPlane();

	public Pnt3D CenterPoint = new Pnt3D();

	public ePlaneEntities()
	{
	}

	public ePlaneEntities(ePlaneEntities ent)
	{
		Plane = new WorkPlane(ent.Plane);
	}

	public static void CopyPlaneBase(eEntities baseEnt, ref eEntities copiedEnt)
	{
		((ePlaneEntities)copiedEnt).Plane = new WorkPlane(((ePlaneEntities)baseEnt).Plane);
	}
}
