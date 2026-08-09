using System;
using System.Runtime.Serialization;

namespace MathNet.Numerics;

[Serializable]
public class NonConvergenceException : Exception
{
	public NonConvergenceException()
		: base("An algorithm failed to converge.")
	{
	}

	public NonConvergenceException(string message)
		: base(message)
	{
	}

	public NonConvergenceException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	protected NonConvergenceException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
