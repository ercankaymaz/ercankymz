using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

public class ErrorDialog : Form
{
	internal Button button_0;

	internal PictureBox pictureBox_0;

	internal Label label_0;

	internal System.Windows.Forms.LinkLabel linkLabel_0;

	private Container container_0 = null;

	private Exception exception_0;

	public Exception Exception
	{
		get
		{
			return exception_0;
		}
		set
		{
			exception_0 = value;
		}
	}

	public ErrorDialog()
	{
		Class76.smethod_551(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public ErrorDialog(Exception p_Exception, string p_Caption)
		: this()
	{
		Text = p_Caption;
		Exception = p_Exception;
	}

	public DialogResult ShowDialog(Exception p_Exception, string p_Caption)
	{
		Text = p_Caption;
		Exception = p_Exception;
		return ShowDialog();
	}

	public DialogResult ShowDialog(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
	{
		Text = p_Caption;
		Exception = p_Exception;
		return ShowDialog(p_Owner);
	}

	public static void Show(Exception p_Exception, string p_Caption)
	{
		ErrorDialog errorDialog = new ErrorDialog(p_Exception, p_Caption);
		errorDialog.ShowDialog();
	}

	internal void method_0(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			ErrorDialogDetails errorDialogDetails = new ErrorDialogDetails(Exception, Text);
			errorDialogDetails.ShowDialog(this);
		}
		catch (Exception)
		{
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		try
		{
			if (exception_0 == null)
			{
				label_0.Text = "Exception is null";
			}
			else
			{
				label_0.Text = exception_0.Message;
			}
		}
		catch (Exception ex)
		{
			label_0.Text = "Error loading message:" + ex.Message;
		}
	}

	public static void Show(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
	{
		ErrorDialog errorDialog = new ErrorDialog(p_Exception, p_Caption);
		errorDialog.ShowDialog(p_Owner);
	}
}
