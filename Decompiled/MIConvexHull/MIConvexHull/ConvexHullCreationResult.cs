namespace MIConvexHull;

public class ConvexHullCreationResult<TVertex, TFace> where TVertex : IVertex where TFace : ConvexFace<TVertex, TFace>, new()
{
	public ConvexHull<TVertex, TFace> Result { get; }

	public ConvexHullCreationResultOutcome Outcome { get; }

	public string ErrorMessage { get; }

	public ConvexHullCreationResult(ConvexHull<TVertex, TFace> result, ConvexHullCreationResultOutcome outcome, string errorMessage = "")
	{
		Result = result;
		Outcome = outcome;
		ErrorMessage = errorMessage;
	}
}
