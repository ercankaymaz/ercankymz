namespace devDept.Geometry;

public class NodeBase
{
	protected Point2D localMin;

	protected Point2D localMax;

	public NodeBase(Point2D boxMin, Point2D boxMax)
	{
		localMin = boxMin;
		localMax = boxMax;
	}

	public void GetBoudingBox(out Point2D boxMin, out Point2D boxMax)
	{
		boxMin = localMin;
		boxMax = localMax;
	}

	public void SetBoundingBox(Point2D boxMin, Point2D boxMax)
	{
		localMin = boxMin;
		localMax = boxMax;
	}
}
