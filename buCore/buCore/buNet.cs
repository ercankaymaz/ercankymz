// Decompiled with JetBrains decompiler
// Type: buCore.buNet
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Pop3;
using buPop3.Pop3.Exceptions;
using ns7;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buNet
{
  private Pop3Client pop3Client_0;
  private readonly Dictionary<int, buPop3.Mime.Message> dictionary_0 = new Dictionary<int, buPop3.Mime.Message>();
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;

  public buNet()
  {
    if (!buVector.smethod_0(nameof (buNet)))
      throw new RegisterException(nameof (buNet));
  }

  public void SendEmailFromFatihPrgm(
    string ToEmail,
    string MailSubject,
    string MailBody,
    List<string> AttachmentFiles)
  {
    try
    {
      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
      message.From = new MailAddress("fatihprgm@gmail.com");
      message.To.Add(ToEmail);
      message.Subject = MailSubject;
      message.Body = MailBody;
      if (AttachmentFiles.Count > 0)
      {
        for (int index = 0; index <= AttachmentFiles.Count - 1; ++index)
        {
          Attachment attachment = new Attachment(AttachmentFiles[index]);
          message.Attachments.Add(attachment);
        }
      }
      smtpClient.Port = 587;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("fatihprgm@gmail.com", "fthprgfth4321");
      smtpClient.EnableSsl = true;
      smtpClient.Send(message);
      message.Dispose();
      smtpClient.Dispose();
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.ToString());
    }
  }

  public void DeleteEmailFromFatihPrgm(int MailIndex)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("pop.gmail.com", 995, true);
      this.pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      if (MailIndex >= 1 & MailIndex <= messageCount)
        this.pop3Client_0.DeleteMessage(MailIndex);
      this.pop3Client_0.Disconnect();
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error occurred retrieving mail. " + ex.Message, "POP3 Retrieval");
    }
    finally
    {
    }
  }

  public void DeleteEmailFromFatihPrgm(bool DeleteAll)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("pop.gmail.com", 995, true);
      this.pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
      this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      this.pop3Client_0.DeleteAllMessages();
      this.pop3Client_0.Disconnect();
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error occurred retrieving mail. " + ex.Message, "POP3 Retrieval");
    }
    finally
    {
    }
  }

  public void GetEmailFromFatihPrgm(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body,
    ref List<List<MessagePart>> Attachments)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("pop.gmail.com", 995, true);
      this.pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
          foreach (MessagePart allAttachment in message.FindAllAttachments())
            messagePartList.Add(allAttachment);
          Attachments.Add(messagePartList);
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error occurred retrieving mail. " + ex.Message, "POP3 Retrieval");
    }
    finally
    {
    }
  }

  public void SendEmailFromCmdSoft(
    string ToEmail,
    string MailSubject,
    string MailBody,
    List<string> AttachmentFiles)
  {
    try
    {
      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
      message.From = new MailAddress("info@cmdsoft.com.tr");
      message.To.Add(ToEmail);
      message.Subject = MailSubject;
      message.Body = MailBody;
      if (AttachmentFiles.Count > 0)
      {
        for (int index = 0; index <= AttachmentFiles.Count - 1; ++index)
        {
          Attachment attachment = new Attachment(AttachmentFiles[index]);
          message.Attachments.Add(attachment);
        }
      }
      smtpClient.Port = 587;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("info@cmdsoft.com.tr", "infocmd19865_");
      smtpClient.EnableSsl = false;
      smtpClient.Send(message);
      message.Dispose();
      smtpClient.Dispose();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GetEmailFromCmdSoft(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body,
    ref List<List<MessagePart>> Attachments)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
          foreach (MessagePart allAttachment in message.FindAllAttachments())
            messagePartList.Add(allAttachment);
          Attachments.Add(messagePartList);
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void GetEmailFromCmdSoft(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void DeleteEmailFromCmdSoft(bool DeleteAll)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
      this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      this.pop3Client_0.DeleteAllMessages();
      this.pop3Client_0.Disconnect();
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void SendEmailFromCmdPrg(
    string ToEmail,
    string MailSubject,
    string MailBody,
    List<string> AttachmentFiles)
  {
    try
    {
      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
      message.From = new MailAddress("prg@cmdsoft.com.tr");
      message.To.Add(ToEmail);
      message.Subject = MailSubject;
      message.Body = MailBody;
      if (AttachmentFiles != null && AttachmentFiles.Count > 0)
      {
        for (int index = 0; index <= AttachmentFiles.Count - 1; ++index)
        {
          Attachment attachment = new Attachment(AttachmentFiles[index]);
          message.Attachments.Add(attachment);
        }
      }
      smtpClient.Port = 587;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("prg@cmdsoft.com.tr", "etYgdy54Rev_qojF6");
      smtpClient.EnableSsl = false;
      smtpClient.Send(message);
      message.Dispose();
      smtpClient.Dispose();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SendEmailFromCmdConfirm(
    string ToEmail,
    string MailSubject,
    string MailBody,
    List<string> AttachmentFiles)
  {
    try
    {
      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
      message.From = new MailAddress("confirm@cmdsoft.com.tr");
      message.To.Add(ToEmail);
      message.Subject = MailSubject;
      message.Body = MailBody;
      if (AttachmentFiles != null && AttachmentFiles.Count > 0)
      {
        for (int index = 0; index <= AttachmentFiles.Count - 1; ++index)
        {
          Attachment attachment = new Attachment(AttachmentFiles[index]);
          message.Attachments.Add(attachment);
        }
      }
      smtpClient.Port = 587;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
      smtpClient.EnableSsl = false;
      smtpClient.Send(message);
      message.Dispose();
      smtpClient.Dispose();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void GetEmailFromCmdPrg(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body,
    ref List<List<MessagePart>> Attachments)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
          foreach (MessagePart allAttachment in message.FindAllAttachments())
            messagePartList.Add(allAttachment);
          Attachments.Add(messagePartList);
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void GetEmailFromCmdPrg(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void GetEmailFromCmdConfirm(
    ref List<string> From,
    ref List<string> Subject,
    ref List<DateTime> CommingDate,
    ref List<string> Body)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
      int messageCount = this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      int num1 = 0;
      int num2 = 0;
      for (int index = messageCount; index >= 1; --index)
      {
        Application.DoEvents();
        try
        {
          buPop3.Mime.Message message = this.pop3Client_0.GetMessage(index);
          List<MessagePart> messagePartList = new List<MessagePart>();
          this.dictionary_0.Add(index, message);
          if (message.Headers.From != null)
            From.Add(message.Headers.From.ToString());
          else
            From.Add("");
          if (message.Headers.Subject != null)
            Subject.Add(message.Headers.Subject);
          else
            Subject.Add("");
          DateTime dateSent = message.Headers.DateSent;
          CommingDate.Add(message.Headers.DateSent);
          ++num1;
          MessagePart plainTextVersion = message.FindFirstPlainTextVersion();
          if (plainTextVersion != null)
          {
            string bodyAsText = plainTextVersion.GetBodyAsText();
            Body.Add(bodyAsText);
          }
          else
          {
            List<MessagePart> allTextVersions = message.FindAllTextVersions();
            if (allTextVersions.Count >= 1)
            {
              string bodyAsText = allTextVersions[0].GetBodyAsText();
              Body.Add(bodyAsText);
            }
            else
            {
              string str = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
              Body.Add(str);
            }
          }
        }
        catch (Exception ex)
        {
          DefaultLogger.Log.LogError($"TestForm: Message fetching failed: {ex.Message}\r\nStack trace:\r\n{ex.StackTrace}");
          ++num2;
        }
      }
      this.pop3Client_0.Disconnect();
      if (num2 <= 0)
        return;
      int num3 = (int) MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void DeleteEmailFromCmdPrg(bool DeleteAll)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
      this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      this.pop3Client_0.DeleteAllMessages();
      this.pop3Client_0.Disconnect();
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void DeleteEmailFromCmdConfirm(bool DeleteAll)
  {
    try
    {
      this.pop3Client_0 = new Pop3Client();
      if (this.pop3Client_0.Connected)
        this.pop3Client_0.Disconnect();
      this.pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, false);
      this.pop3Client_0.Authenticate("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
      this.pop3Client_0.GetMessageCount();
      this.dictionary_0.Clear();
      this.pop3Client_0.DeleteAllMessages();
      this.pop3Client_0.Disconnect();
    }
    catch (InvalidLoginException ex)
    {
      int num = (int) MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
    }
    catch (PopServerNotFoundException ex)
    {
      int num = (int) MessageBox.Show("The server could not be found", "POP3 Retrieval");
    }
    catch (PopServerLockedException ex)
    {
      int num = (int) MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
    }
    catch (LoginDelayException ex)
    {
      int num = (int) MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
    }
  }

  public void SendEmail(
    string ServerName,
    string FromMail,
    string UserName,
    string Password,
    bool SllEnable,
    string ToEmail,
    string MailSubject,
    string MailBody,
    List<string> AttachmentFiles)
  {
    try
    {
      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient(ServerName);
      message.From = new MailAddress(FromMail);
      message.To.Add(ToEmail);
      message.Subject = MailSubject;
      message.Body = MailBody;
      if (AttachmentFiles.Count > 0)
      {
        for (int index = 0; index <= AttachmentFiles.Count - 1; ++index)
        {
          Attachment attachment = new Attachment(AttachmentFiles[index]);
          message.Attachments.Add(attachment);
        }
      }
      smtpClient.Port = 587;
      smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential(UserName, Password);
      smtpClient.EnableSsl = SllEnable;
      smtpClient.Send(message);
    }
    catch (Exception ex)
    {
      string str = $"ServerName: {ServerName} - FromMail: {FromMail}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public bool IsInternetConnection(string WebPage)
  {
    try
    {
      using (WebClient webClient = new WebClient())
      {
        using (webClient.OpenRead(WebPage))
          return true;
      }
    }
    catch (Exception ex)
    {
      string str = "WebPage: " + WebPage;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsInternetConnectionByGoogleWebPage()
  {
    try
    {
      string address = "http://www.google.com";
      using (WebClient webClient = new WebClient())
      {
        using (webClient.OpenRead(address))
          return true;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public bool IsInternetConnectionByPing(string PingAdress)
  {
    try
    {
      return new Ping().Send(PingAdress, 1000, new byte[32 /*0x20*/], new PingOptions()).Status == IPStatus.Success;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool IsValidEmail(string email)
  {
    try
    {
      return new MailAddress(email).Address == email;
    }
    catch
    {
      return false;
    }
  }

  public static DateTime GetNetworkTimeFromInternet()
  {
    try
    {
      byte[] buffer = new byte[48 /*0x30*/];
      buffer[0] = (byte) 27;
      IPEndPoint remoteEP = new IPEndPoint(Dns.GetHostEntry("time.windows.com").AddressList[0], 123);
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
      socket.Connect((EndPoint) remoteEP);
      socket.ReceiveTimeout = 3000;
      socket.Send(buffer);
      socket.Receive(buffer);
      socket.Close();
      ulong uint32_1 = (ulong) BitConverter.ToUInt32(buffer, 40);
      ulong uint32_2 = (ulong) BitConverter.ToUInt32(buffer, 44);
      return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((double) (long) ((ulong) Class30.smethod_190(uint32_1) * 1000UL + (ulong) Class30.smethod_190(uint32_2) * 1000UL / 4294967296UL /*0x0100000000*/)).ToLocalTime();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return DateTime.Now;
    }
  }
}
