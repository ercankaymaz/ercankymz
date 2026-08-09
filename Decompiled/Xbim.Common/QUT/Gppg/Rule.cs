namespace QUT.Gppg;

public class Rule
{
	internal int LeftHandSide;

	internal int[] RightHandSide;

	public Rule(int left, int[] right)
	{
		LeftHandSide = left;
		RightHandSide = right;
	}
}
