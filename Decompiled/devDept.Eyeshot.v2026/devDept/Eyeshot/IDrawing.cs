namespace devDept.Eyeshot;

public interface IDrawing : IWorkspace
{
	new DrawingDocument Document { get; }

	string SilhouettesLayerName { get; set; }

	string EdgesLayerName { get; set; }

	string WiresLayerName { get; set; }

	string HiddenSilhouettesLayerName { get; set; }

	string HiddenEdgesLayerName { get; set; }

	string HiddenWiresLayerName { get; set; }

	string CenterlinesLayerName { get; set; }

	string HiddenSegmentsLineTypeName { get; set; }

	string CenterlinesLineTypeName { get; set; }

	SheetKeyedCollection Sheets { get; set; }

	Sheet ActiveSheet { get; set; }

	int ActiveSheetIndex { get; set; }
}
