using System.Drawing;

namespace devDept.Eyeshot.Entities;

public interface IEntity
{
	Color Color { get; set; }

	colorMethodType ColorMethod { get; set; }

	string LayerName { get; set; }

	bool Visible { get; set; }

	colorMethodType LineTypeMethod { get; set; }

	string LineTypeName { get; set; }

	float LineTypeScale { get; set; }

	colorMethodType LineWeightMethod { get; set; }

	float LineWeight { get; set; }

	AutodeskProperties AutodeskProperties { get; set; }
}
