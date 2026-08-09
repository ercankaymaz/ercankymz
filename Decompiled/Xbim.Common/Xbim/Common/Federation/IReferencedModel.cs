namespace Xbim.Common.Federation;

public interface IReferencedModel
{
	IModel Model { get; }

	string Identifier { get; }

	string Name { get; set; }

	string Role { get; set; }

	string OwningOrganisation { get; set; }

	void Close();
}
