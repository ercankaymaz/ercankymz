using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Pop3;
using buPop3.Pop3.Exceptions;
using ns54;

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
		if (!buVector.smethod_0("buNet"))
		{
			throw new RegisterException("buNet");
		}
	}

	public void SendEmailFromFatihPrgm(string ToEmail, string MailSubject, string MailBody, List<string> AttachmentFiles)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
			mailMessage.From = new MailAddress("fatihprgm@gmail.com");
			mailMessage.To.Add(ToEmail);
			mailMessage.Subject = MailSubject;
			mailMessage.Body = MailBody;
			if (AttachmentFiles.Count > 0)
			{
				for (int i = 0; i <= AttachmentFiles.Count - 1; i++)
				{
					Attachment item = new Attachment(AttachmentFiles[i]);
					mailMessage.Attachments.Add(item);
				}
			}
			smtpClient.Port = 587;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential("fatihprgm@gmail.com", "fthprgfth4321");
			smtpClient.EnableSsl = true;
			smtpClient.Send(mailMessage);
			mailMessage.Dispose();
			smtpClient.Dispose();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	public void DeleteEmailFromFatihPrgm(int MailIndex)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("pop.gmail.com", 995, useSsl: true);
			pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			if (MailIndex >= 1 && MailIndex <= messageCount)
			{
				pop3Client_0.DeleteMessage(MailIndex);
			}
			pop3Client_0.Disconnect();
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception ex5)
		{
			MessageBox.Show("Error occurred retrieving mail. " + ex5.Message, "POP3 Retrieval");
		}
		finally
		{
		}
	}

	public void DeleteEmailFromFatihPrgm(bool DeleteAll)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("pop.gmail.com", 995, useSsl: true);
			pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
			pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			pop3Client_0.DeleteAllMessages();
			pop3Client_0.Disconnect();
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception ex5)
		{
			MessageBox.Show("Error occurred retrieving mail. " + ex5.Message, "POP3 Retrieval");
		}
		finally
		{
		}
	}

	public void GetEmailFromFatihPrgm(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body, ref List<List<MessagePart>> Attachments)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("pop.gmail.com", 995, useSsl: true);
			pop3Client_0.Authenticate("fatihprgm@gmail.com", "fthprgfth4321");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					List<MessagePart> list = new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list2 = message.FindAllTextVersions();
						if (list2.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list2[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
					List<MessagePart> list3 = message.FindAllAttachments();
					foreach (MessagePart item2 in list3)
					{
						list.Add(item2);
					}
					Attachments.Add(list);
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception ex6)
		{
			MessageBox.Show("Error occurred retrieving mail. " + ex6.Message, "POP3 Retrieval");
		}
		finally
		{
		}
	}

	public void SendEmailFromCmdSoft(string ToEmail, string MailSubject, string MailBody, List<string> AttachmentFiles)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
			mailMessage.From = new MailAddress("info@cmdsoft.com.tr");
			mailMessage.To.Add(ToEmail);
			mailMessage.Subject = MailSubject;
			mailMessage.Body = MailBody;
			if (AttachmentFiles.Count > 0)
			{
				for (int i = 0; i <= AttachmentFiles.Count - 1; i++)
				{
					Attachment item = new Attachment(AttachmentFiles[i]);
					mailMessage.Attachments.Add(item);
				}
			}
			smtpClient.Port = 587;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential("info@cmdsoft.com.tr", "infocmd19865_");
			smtpClient.EnableSsl = false;
			smtpClient.Send(mailMessage);
			mailMessage.Dispose();
			smtpClient.Dispose();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void GetEmailFromCmdSoft(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body, ref List<List<MessagePart>> Attachments)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					List<MessagePart> list = new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list2 = message.FindAllTextVersions();
						if (list2.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list2[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
					List<MessagePart> list3 = message.FindAllAttachments();
					foreach (MessagePart item2 in list3)
					{
						list.Add(item2);
					}
					Attachments.Add(list);
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void GetEmailFromCmdSoft(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list = message.FindAllTextVersions();
						if (list.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void DeleteEmailFromCmdSoft(bool DeleteAll)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("info@cmdsoft.com.tr", "infocmd19865_");
			pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			pop3Client_0.DeleteAllMessages();
			pop3Client_0.Disconnect();
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void SendEmailFromCmdPrg(string ToEmail, string MailSubject, string MailBody, List<string> AttachmentFiles)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
			mailMessage.From = new MailAddress("prg@cmdsoft.com.tr");
			mailMessage.To.Add(ToEmail);
			mailMessage.Subject = MailSubject;
			mailMessage.Body = MailBody;
			if (AttachmentFiles != null && AttachmentFiles.Count > 0)
			{
				for (int i = 0; i <= AttachmentFiles.Count - 1; i++)
				{
					Attachment item = new Attachment(AttachmentFiles[i]);
					mailMessage.Attachments.Add(item);
				}
			}
			smtpClient.Port = 587;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential("prg@cmdsoft.com.tr", "etYgdy54Rev_qojF6");
			smtpClient.EnableSsl = false;
			smtpClient.Send(mailMessage);
			mailMessage.Dispose();
			smtpClient.Dispose();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SendEmailFromCmdConfirm(string ToEmail, string MailSubject, string MailBody, List<string> AttachmentFiles)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient("mail.cmdsoft.com.tr");
			mailMessage.From = new MailAddress("confirm@cmdsoft.com.tr");
			mailMessage.To.Add(ToEmail);
			mailMessage.Subject = MailSubject;
			mailMessage.Body = MailBody;
			if (AttachmentFiles != null && AttachmentFiles.Count > 0)
			{
				for (int i = 0; i <= AttachmentFiles.Count - 1; i++)
				{
					Attachment item = new Attachment(AttachmentFiles[i]);
					mailMessage.Attachments.Add(item);
				}
			}
			smtpClient.Port = 587;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
			smtpClient.EnableSsl = false;
			smtpClient.Send(mailMessage);
			mailMessage.Dispose();
			smtpClient.Dispose();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void GetEmailFromCmdPrg(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body, ref List<List<MessagePart>> Attachments)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					List<MessagePart> list = new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list2 = message.FindAllTextVersions();
						if (list2.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list2[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
					List<MessagePart> list3 = message.FindAllAttachments();
					foreach (MessagePart item2 in list3)
					{
						list.Add(item2);
					}
					Attachments.Add(list);
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void GetEmailFromCmdPrg(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list = message.FindAllTextVersions();
						if (list.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void GetEmailFromCmdConfirm(ref List<string> From, ref List<string> Subject, ref List<DateTime> CommingDate, ref List<string> Body)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
			int messageCount = pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			int num = 0;
			int num2 = 0;
			for (int num3 = messageCount; num3 >= 1; num3--)
			{
				Application.DoEvents();
				try
				{
					buPop3.Mime.Message message = pop3Client_0.GetMessage(num3);
					new List<MessagePart>();
					dictionary_0.Add(num3, message);
					if (message.Headers.From == null)
					{
						From.Add("");
					}
					else
					{
						From.Add(message.Headers.From.ToString());
					}
					if (message.Headers.Subject == null)
					{
						Subject.Add("");
					}
					else
					{
						Subject.Add(message.Headers.Subject);
					}
					_ = message.Headers.DateSent;
					CommingDate.Add(message.Headers.DateSent);
					num++;
					MessagePart messagePart = message.FindFirstPlainTextVersion();
					if (messagePart == null)
					{
						List<MessagePart> list = message.FindAllTextVersions();
						if (list.Count < 1)
						{
							string item = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>";
							Body.Add(item);
						}
						else
						{
							string bodyAsText = list[0].GetBodyAsText();
							Body.Add(bodyAsText);
						}
					}
					else
					{
						string bodyAsText2 = messagePart.GetBodyAsText();
						Body.Add(bodyAsText2);
					}
				}
				catch (Exception ex)
				{
					DefaultLogger.Log.LogError("TestForm: Message fetching failed: " + ex.Message + "\r\nStack trace:\r\n" + ex.StackTrace);
					num2++;
				}
			}
			pop3Client_0.Disconnect();
			if (num2 > 0)
			{
				MessageBox.Show("Since some of the emails were not parsed correctly (exceptions were thrown)\r\nplease consider sending your log file to the developer for fixing.\r\nIf you are able to include any extra information, please do so.", "Help improve OpenPop!");
			}
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void DeleteEmailFromCmdPrg(bool DeleteAll)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("prg@cmdsoft.com.tr", "prgcmdQEfse53dY");
			pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			pop3Client_0.DeleteAllMessages();
			pop3Client_0.Disconnect();
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void DeleteEmailFromCmdConfirm(bool DeleteAll)
	{
		try
		{
			pop3Client_0 = new Pop3Client();
			if (pop3Client_0.Connected)
			{
				pop3Client_0.Disconnect();
			}
			pop3Client_0.Connect("mail.cmdsoft.com.tr", 110, useSsl: false);
			pop3Client_0.Authenticate("confirm@cmdsoft.com.tr", "ryfRPe6783_rt75Sw");
			pop3Client_0.GetMessageCount();
			dictionary_0.Clear();
			pop3Client_0.DeleteAllMessages();
			pop3Client_0.Disconnect();
		}
		catch (InvalidLoginException)
		{
			MessageBox.Show("The server did not accept the user credentials!", "POP3 Server Authentication");
		}
		catch (PopServerNotFoundException)
		{
			MessageBox.Show("The server could not be found", "POP3 Retrieval");
		}
		catch (PopServerLockedException)
		{
			MessageBox.Show("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
		}
		catch (LoginDelayException)
		{
			MessageBox.Show("Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
		}
	}

	public void SendEmail(string ServerName, string FromMail, string UserName, string Password, bool SllEnable, string ToEmail, string MailSubject, string MailBody, List<string> AttachmentFiles)
	{
		try
		{
			MailMessage mailMessage = new MailMessage();
			SmtpClient smtpClient = new SmtpClient(ServerName);
			mailMessage.From = new MailAddress(FromMail);
			mailMessage.To.Add(ToEmail);
			mailMessage.Subject = MailSubject;
			mailMessage.Body = MailBody;
			if (AttachmentFiles.Count > 0)
			{
				for (int i = 0; i <= AttachmentFiles.Count - 1; i++)
				{
					Attachment item = new Attachment(AttachmentFiles[i]);
					mailMessage.Attachments.Add(item);
				}
			}
			smtpClient.Port = 587;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(UserName, Password);
			smtpClient.EnableSsl = SllEnable;
			smtpClient.Send(mailMessage);
		}
		catch (Exception mSException)
		{
			string text = "ServerName: " + ServerName + " - FromMail: " + FromMail;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public bool IsInternetConnection(string WebPage)
	{
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead(WebPage))
			{
				return true;
			}
		}
		catch (Exception mSException)
		{
			string text = "WebPage: " + WebPage;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public bool IsInternetConnectionByGoogleWebPage()
	{
		try
		{
			string address = "http://www.google.com";
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead(address))
			{
				return true;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public bool IsInternetConnectionByPing(string PingAdress)
	{
		try
		{
			Ping ping = new Ping();
			byte[] buffer = new byte[32];
			PingOptions options = new PingOptions();
			PingReply pingReply = ping.Send(PingAdress, 1000, buffer, options);
			if (pingReply.Status != IPStatus.Success)
			{
				return false;
			}
			return true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsValidEmail(string email)
	{
		try
		{
			MailAddress mailAddress = new MailAddress(email);
			return mailAddress.Address == email;
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
			byte[] array = new byte[48];
			array[0] = 27;
			IPAddress[] addressList = Dns.GetHostEntry("time.windows.com").AddressList;
			IPEndPoint remoteEP = new IPEndPoint(addressList[0], 123);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			socket.Connect(remoteEP);
			socket.ReceiveTimeout = 3000;
			socket.Send(array);
			socket.Receive(array);
			socket.Close();
			ulong ulong_ = BitConverter.ToUInt32(array, 40);
			ulong ulong_2 = BitConverter.ToUInt32(array, 44);
			ulong_ = Class156.smethod_190(ulong_);
			ulong_2 = Class156.smethod_190(ulong_2);
			ulong num = ulong_ * 1000L + ulong_2 * 1000L / 4294967296L;
			return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((long)num).ToLocalTime();
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return DateTime.Now;
		}
	}
}
