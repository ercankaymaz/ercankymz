using System;
using System.Collections;

namespace DevAge.Shell;

public class MailToProtocol
{
	public static string FormatMailToCommand(string[] p_To, string[] p_Cc, string[] p_Bcc, string p_Subject, string p_Body)
	{
		string text = FormatEMailAddress(p_To);
		string text2 = FormatEMailAddress(p_Cc);
		string text3 = FormatEMailAddress(p_Bcc);
		string text4 = "mailto:";
		if (text != null)
		{
			text4 += text;
		}
		ArrayList arrayList = new ArrayList();
		if (text2 != null)
		{
			arrayList.Add("CC=" + text2);
		}
		if (text3 != null)
		{
			arrayList.Add("BCC=" + text3);
		}
		if (p_Subject != null)
		{
			arrayList.Add("subject=" + p_Subject);
		}
		if (p_Body != null)
		{
			arrayList.Add("body=" + p_Body);
		}
		if (arrayList.Count > 0)
		{
			string[] array = new string[arrayList.Count];
			arrayList.CopyTo(array, 0);
			text4 += "?";
			text4 += string.Join("&", array);
		}
		return text4;
	}

	public static void Exec(string[] p_To)
	{
		Exec(p_To, null);
	}

	public static void Exec(string[] p_To, string p_Subject)
	{
		Exec(p_To, null, null, p_Subject, null);
	}

	public static void Exec(string[] p_To, string[] p_Cc, string[] p_Bcc, string p_Subject, string p_Body)
	{
		try
		{
			Utilities.ExecCommand(FormatMailToCommand(p_To, p_Cc, p_Bcc, p_Subject, p_Body));
		}
		catch (Exception innerException)
		{
			throw new ApplicationException("Failed to execute mailto protocol.", innerException);
		}
	}

	public static string FormatEMailAddress(string[] p_EMails)
	{
		if (p_EMails != null && p_EMails.Length != 0)
		{
			return string.Join(";", p_EMails);
		}
		return null;
	}
}
