using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

public class ErrorDialogDetails : Form
{
	internal TextBox textBox_0;

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

	public ErrorDialogDetails()
	{
		Class76.smethod_743(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public ErrorDialogDetails(Exception p_Exception, string p_Caption)
		: this()
	{
		Text = "Error Details - " + p_Caption;
		Exception = p_Exception;
	}

	public DialogResult ShowDialog(Exception p_Exception, string p_Caption)
	{
		Text = "Error Details - " + p_Caption;
		Exception = p_Exception;
		return ShowDialog();
	}

	public DialogResult ShowDialog(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
	{
		Text = "Error Details - " + p_Caption;
		Exception = p_Exception;
		return ShowDialog(p_Owner);
	}

	public static void Show(Exception p_Exception, string p_Caption)
	{
		ErrorDialogDetails errorDialogDetails = new ErrorDialogDetails(p_Exception, p_Caption);
		errorDialogDetails.ShowDialog();
	}

	internal void method_0(object sender, EventArgs e)
	{
		try
		{
			if (exception_0 == null)
			{
				textBox_0.Text = "Exception is null";
			}
			else
			{
				textBox_0.Text = exception_0.ToString();
			}
		}
		catch (Exception ex)
		{
			textBox_0.Text = "Error loading message:" + ex.ToString();
		}
	}

	public static void Show(IWin32Window p_Owner, Exception p_Exception, string p_Caption)
	{
		ErrorDialogDetails errorDialogDetails = new ErrorDialogDetails(p_Exception, p_Caption);
		errorDialogDetails.ShowDialog(p_Owner);
	}
}
