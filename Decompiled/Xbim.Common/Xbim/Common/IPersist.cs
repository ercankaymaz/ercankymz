namespace Xbim.Common;

public interface IPersist
{
	void Parse(int propIndex, IPropertyValue value, int[] nested);
}
