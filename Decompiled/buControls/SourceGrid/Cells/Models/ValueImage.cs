using System.Drawing;
using DevAge.ComponentModel.Validator;

namespace SourceGrid.Cells.Models;

public class ValueImage : IModel, IImage
{
	public static readonly ValueImage Default = new ValueImage();

	private ValidatorTypeConverter validatorTypeConverter_0 = new ValidatorTypeConverter(typeof(System.Drawing.Image));

	public System.Drawing.Image GetImage(CellContext cellContext)
	{
		object value = cellContext.Cell.Model.ValueModel.GetValue(cellContext);
		return (System.Drawing.Image)validatorTypeConverter_0.ObjectToValue(value);
	}
}
