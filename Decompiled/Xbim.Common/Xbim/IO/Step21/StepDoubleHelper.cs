namespace Xbim.IO.Step21;

public static class StepDoubleHelper
{
	public static string AsPart21(this double real)
	{
		string text = double.Parse(real.ToString("R", StepText.DoubleCulture), StepText.DoubleCulture).ToString("R", StepText.DoubleCulture);
		if (!text.Contains("."))
		{
			text = ((!text.Contains("E")) ? (text + ".") : text.Replace("E", ".E"));
		}
		return text;
	}
}
