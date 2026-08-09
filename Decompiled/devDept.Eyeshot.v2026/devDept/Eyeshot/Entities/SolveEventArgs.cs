using System;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Entities;

public class SolveEventArgs : EventArgs
{
	public solveFailureType Result;

	public bool Dragging;

	public SolveEventArgs(solveFailureType result, bool dragging)
	{
		Result = result;
		Dragging = dragging;
	}
}
