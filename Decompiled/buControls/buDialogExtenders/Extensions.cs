using System.Windows.Forms;
using Win32Types;
using buControls.DialogBox;
using ns27;

namespace buDialogExtenders;

public static class Extensions
{
	public static DialogResult ShowDialog(this FileDialog fdlg, FileDialogControlBase ctrl, IWin32Window owner)
	{
		ctrl.FileDlgType = ((fdlg is SaveFileDialog) ? FileDialogType.SaveFileDlg : FileDialogType.OpenFileDlg);
		OpenFileDialogBoxPreviewWithSubFolder.SelectedFolder = fdlg.InitialDirectory;
		if (Class76.smethod_340(fdlg, ctrl, owner) != DialogResult.OK)
		{
			if (FileDialogControlBase.SubFolderSelected)
			{
				return DialogResult.OK;
			}
			return DialogResult.Ignore;
		}
		return DialogResult.OK;
	}
}
