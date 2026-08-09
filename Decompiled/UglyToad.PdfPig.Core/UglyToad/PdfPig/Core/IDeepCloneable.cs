namespace UglyToad.PdfPig.Core;

public interface IDeepCloneable<out T>
{
	T DeepClone();
}
