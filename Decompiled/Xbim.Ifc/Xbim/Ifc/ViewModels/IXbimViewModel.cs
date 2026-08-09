using System.Collections.Generic;
using System.ComponentModel;
using Xbim.Common;

namespace Xbim.Ifc.ViewModels;

public interface IXbimViewModel : INotifyPropertyChanged
{
	IEnumerable<IXbimViewModel> Children { get; }

	string Name { get; }

	int EntityLabel { get; }

	IPersistEntity Entity { get; }

	IModel Model { get; }

	bool IsExpanded { get; set; }

	bool IsSelected { get; set; }

	IXbimViewModel CreatingParent { get; set; }
}
