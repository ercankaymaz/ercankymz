using System.Windows.Forms;

namespace buControls.DialogBox;

public class DialogBoxes
{
	public static string FileName = "";

	public static DialogResult OpenImageFileDialog(string InitDir)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = InitDir;
		openFileDialog.Filter = "Image Files(*.bmp,*.png,*.jpg)|*.bmp;*.png;*.jpg";
		openFileDialog.FilterIndex = 1;
		openFileDialog.FileName = "";
		DialogResult dialogResult = openFileDialog.ShowDialog();
		FileName = "";
		if (dialogResult == DialogResult.OK)
		{
			FileName = openFileDialog.FileName;
		}
		return dialogResult;
	}
}
