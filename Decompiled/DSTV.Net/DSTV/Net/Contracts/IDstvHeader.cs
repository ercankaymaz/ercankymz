using DSTV.Net.Enums;

namespace DSTV.Net.Contracts;

public interface IDstvHeader
{
	string? OrderIdentification { get; set; }

	string? DrawingIdentification { get; set; }

	string? PhaseIdentification { get; set; }

	string? PieceIdentification { get; set; }

	string? SteelQuality { get; set; }

	int QuantityOfPieces { get; set; }

	string? Profile { get; set; }

	CodeProfile CodeProfile { get; set; }

	double Length { get; set; }

	double? SawLength { get; set; }

	double ProfileHeight { get; set; }

	double FlangeWidth { get; set; }

	double FlangeThickness { get; set; }

	double WebThickness { get; set; }

	double Radius { get; set; }

	double WeightByMeter { get; set; }

	double PaintingSurfaceByMeter { get; set; }

	double WebStartCut { get; set; }

	double WebEndCut { get; set; }

	double FlangeStartCut { get; set; }

	double FlangeEndCut { get; set; }

	string? Text1InfoOnPiece { get; set; }

	string? Text2InfoOnPiece { get; set; }

	string? Text3InfoOnPiece { get; set; }

	string? Text4InfoOnPiece { get; set; }
}
