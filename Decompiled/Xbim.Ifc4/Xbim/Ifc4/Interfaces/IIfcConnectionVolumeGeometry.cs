using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcConnectionVolumeGeometry : IIfcConnectionGeometry, IPersistEntity, IPersist
{
	IIfcSolidOrShell VolumeOnRelatingElement { get; set; }

	IIfcSolidOrShell VolumeOnRelatedElement { get; set; }
}
