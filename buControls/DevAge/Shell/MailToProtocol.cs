// Decompiled with JetBrains decompiler
// Type: DevAge.Shell.MailToProtocol
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;

#nullable disable
namespace DevAge.Shell;

public class MailToProtocol
{
  public static string FormatMailToCommand(
    string[] p_To,
    string[] p_Cc,
    string[] p_Bcc,
    string p_Subject,
    string p_Body)
  {
    string str1 = MailToProtocol.FormatEMailAddress(p_To);
    string str2 = MailToProtocol.FormatEMailAddress(p_Cc);
    string str3 = MailToProtocol.FormatEMailAddress(p_Bcc);
    string command = "mailto:";
    if (str1 != null)
      command += str1;
    ArrayList arrayList = new ArrayList();
    if (str2 != null)
      arrayList.Add((object) ("CC=" + str2));
    if (str3 != null)
      arrayList.Add((object) ("BCC=" + str3));
    if (p_Subject != null)
      arrayList.Add((object) ("subject=" + p_Subject));
    if (p_Body != null)
      arrayList.Add((object) ("body=" + p_Body));
    if (arrayList.Count > 0)
    {
      string[] strArray = new string[arrayList.Count];
      arrayList.CopyTo((Array) strArray, 0);
      command = command + "?" + string.Join("&", strArray);
    }
    return command;
  }

  public static void Exec(string[] p_To) => MailToProtocol.Exec(p_To, (string) null);

  public static void Exec(string[] p_To, string p_Subject)
  {
    MailToProtocol.Exec(p_To, (string[]) null, (string[]) null, p_Subject, (string) null);
  }

  public static void Exec(
    string[] p_To,
    string[] p_Cc,
    string[] p_Bcc,
    string p_Subject,
    string p_Body)
  {
    try
    {
      Utilities.ExecCommand(MailToProtocol.FormatMailToCommand(p_To, p_Cc, p_Bcc, p_Subject, p_Body));
    }
    catch (Exception ex)
    {
      throw new ApplicationException("Failed to execute mailto protocol.", ex);
    }
  }

  public static string FormatEMailAddress(string[] p_EMails)
  {
    return (p_EMails == null ? 1 : (p_EMails.Length == 0 ? 1 : 0)) == 0 ? string.Join(";", p_EMails) : (string) null;
  }
}
