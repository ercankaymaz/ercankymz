namespace ACadSharp.Extensions;

public static class CadObjectExtensions
{
	public static T CloneTyped<T>(this T obj) where T : CadObject
	{
		return (T)obj.Clone();
	}
}
