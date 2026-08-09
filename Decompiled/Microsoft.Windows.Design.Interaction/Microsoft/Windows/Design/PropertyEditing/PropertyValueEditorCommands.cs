using System.Windows.Input;

namespace Microsoft.Windows.Design.PropertyEditing;

public static class PropertyValueEditorCommands
{
	private static RoutedCommand _showInlineEditor;

	private static RoutedCommand _showExtendedPopupEditor;

	private static RoutedCommand _showExtendedPinnedEditor;

	private static RoutedCommand _showDialogEditor;

	private static RoutedCommand _beginTransaction;

	private static RoutedCommand _commitTransaction;

	private static RoutedCommand _abortTransaction;

	private static RoutedCommand _finishEditing;

	private static RoutedCommand _showErrorMessage;

	private static RoutedCommand _showContextMenu;

	public static RoutedCommand ShowErrorMessage
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showErrorMessage == null)
			{
				_showErrorMessage = new RoutedCommand("ShowErrorMessage", typeof(PropertyValueEditorCommands));
			}
			return _showErrorMessage;
		}
	}

	public static RoutedCommand ShowInlineEditor
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showInlineEditor == null)
			{
				_showInlineEditor = new RoutedCommand("ShowInlineEditor", typeof(PropertyValueEditorCommands));
			}
			return _showInlineEditor;
		}
	}

	public static RoutedCommand ShowExtendedPopupEditor
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showExtendedPopupEditor == null)
			{
				_showExtendedPopupEditor = new RoutedCommand("ShowExtendedPopupEditor", typeof(PropertyValueEditorCommands));
			}
			return _showExtendedPopupEditor;
		}
	}

	public static RoutedCommand ShowExtendedPinnedEditor
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showExtendedPinnedEditor == null)
			{
				_showExtendedPinnedEditor = new RoutedCommand("ShowExtendedPinnedEditor", typeof(PropertyValueEditorCommands));
			}
			return _showExtendedPinnedEditor;
		}
	}

	public static RoutedCommand ShowDialogEditor
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showDialogEditor == null)
			{
				_showDialogEditor = new RoutedCommand("ShowDialogEditor", typeof(PropertyValueEditorCommands));
			}
			return _showDialogEditor;
		}
	}

	public static RoutedCommand BeginTransaction
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_beginTransaction == null)
			{
				_beginTransaction = new RoutedCommand("BeginTransaction", typeof(PropertyValueEditorCommands));
			}
			return _beginTransaction;
		}
	}

	public static RoutedCommand CommitTransaction
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_commitTransaction == null)
			{
				_commitTransaction = new RoutedCommand("CommitTransaction", typeof(PropertyValueEditorCommands));
			}
			return _commitTransaction;
		}
	}

	public static RoutedCommand AbortTransaction
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_abortTransaction == null)
			{
				_abortTransaction = new RoutedCommand("AbortTransaction", typeof(PropertyValueEditorCommands));
			}
			return _abortTransaction;
		}
	}

	public static RoutedCommand FinishEditing
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_finishEditing == null)
			{
				_finishEditing = new RoutedCommand("FinishEditing", typeof(PropertyValueEditorCommands));
			}
			return _finishEditing;
		}
	}

	public static RoutedCommand ShowContextMenu
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_showContextMenu == null)
			{
				_showContextMenu = new RoutedCommand("ShowContextMenu", typeof(PropertyValueEditorCommands));
			}
			return _showContextMenu;
		}
	}
}
