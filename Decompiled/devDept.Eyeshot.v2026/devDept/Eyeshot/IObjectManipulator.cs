using System.Drawing;

namespace devDept.Eyeshot;

internal interface IObjectManipulator
{
	bool editingClippingPlane { get; }

	ClippingPlaneBase clippingPlane { get; }

	void EditClippingPlane(ClippingPlane clippingPlane, Color optionalColor, bool planeVisibilityStatus);

	void Cancel();

	void Apply();
}
