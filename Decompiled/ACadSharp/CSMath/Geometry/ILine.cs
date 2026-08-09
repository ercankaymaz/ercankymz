namespace CSMath.Geometry;

public interface ILine<T> where T : IVector
{
	T Origin { get; set; }

	T Direction { get; set; }

	T FindIntersection(ILine<T> line);
}
