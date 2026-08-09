namespace devDept.Eyeshot.Entities;

public interface IText
{
	double Height { get; set; }

	double WidthFactor { get; set; }

	string TextString { get; set; }

	string StyleName { get; set; }
}
