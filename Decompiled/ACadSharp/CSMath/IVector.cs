namespace CSMath;

public interface IVector
{
	uint Dimension { get; }

	double this[int index] { get; set; }
}
