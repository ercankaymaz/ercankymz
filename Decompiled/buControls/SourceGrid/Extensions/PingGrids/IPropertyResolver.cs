namespace SourceGrid.Extensions.PingGrids;

public interface IPropertyResolver
{
	object ReadValue(object obj, string propertyPath);
}
