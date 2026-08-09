using System;

namespace MIConvexHull;

public class ConvexHullGenerationException : Exception
{
	public string ErrorMessage { get; }

	public ConvexHullCreationResultOutcome Error { get; }

	public ConvexHullGenerationException(ConvexHullCreationResultOutcome error, string errorMessage)
	{
		ErrorMessage = errorMessage;
		Error = error;
	}
}
