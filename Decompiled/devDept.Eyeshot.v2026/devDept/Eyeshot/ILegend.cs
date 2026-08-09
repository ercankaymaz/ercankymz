using System.Drawing;

namespace devDept.Eyeshot;

public interface ILegend
{
	double Min { get; }

	double Max { get; }

	string Title { get; set; }

	bool Slave { get; }

	string FormatString { get; set; }

	string Subtitle { get; set; }

	Color[] GetColorTable();

	int IndexAt(double numValue);

	double Normalize(double numValue);

	void SetRange(double min, double max);
}
