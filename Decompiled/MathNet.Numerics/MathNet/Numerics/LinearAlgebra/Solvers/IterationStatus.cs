namespace MathNet.Numerics.LinearAlgebra.Solvers;

public enum IterationStatus
{
	Continue,
	Converged,
	Diverged,
	StoppedWithoutConvergence,
	Cancelled,
	Failure
}
