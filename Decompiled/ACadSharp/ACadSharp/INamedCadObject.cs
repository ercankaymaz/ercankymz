using System;

namespace ACadSharp;

public interface INamedCadObject
{
	string Name { get; }

	event EventHandler<OnNameChangedArgs> OnNameChanged;
}
