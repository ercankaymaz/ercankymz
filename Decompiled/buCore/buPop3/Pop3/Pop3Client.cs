using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Mime.Header;
using buPop3.Pop3.Exceptions;
using ns48;
using ns54;

namespace buPop3.Pop3;

public class Pop3Client : Disposable
{
	[CompilerGenerated]
	private Stream stream_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Enum9 enum9_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	public bool Connected
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		internal set
		{
			bool_1 = value;
		}
	}

	public bool ApopSupported
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		internal set
		{
			bool_2 = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Stream method_0()
	{
		return stream_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(Stream stream_1)
	{
		stream_0 = stream_1;
	}

	[SpecialName]
	[CompilerGenerated]
	internal string method_2()
	{
		return string_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_3(string string_2)
	{
		string_0 = string_2;
	}

	[SpecialName]
	[CompilerGenerated]
	internal string method_4()
	{
		return string_1;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_5(string string_2)
	{
		string_1 = string_2;
	}

	[SpecialName]
	[CompilerGenerated]
	private Enum9 method_6()
	{
		return enum9_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal void method_7(Enum9 enum9_1)
	{
		enum9_0 = enum9_1;
	}

	public Pop3Client()
	{
		Class156.smethod_279(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && !base.IsDisposed && Connected)
		{
			Disconnect();
		}
		base.Dispose(disposing);
	}

	public void Connect(Stream stream)
	{
		AssertDisposed();
		if (method_6() == Enum9.const_0)
		{
			if (stream != null)
			{
				method_1(stream);
				string text = Class156.smethod_106(method_0());
				try
				{
					method_7(Enum9.const_1);
					Class156.smethod_98(text);
					Class156.smethod_62(this, text);
					Connected = true;
					return;
				}
				catch (PopServerException innerException)
				{
					Class156.smethod_61(this);
					DefaultLogger.Log.LogError("Connect(): Error with connection, maybe POP3 server not exist");
					DefaultLogger.Log.LogDebug("Last response from server was: " + method_2());
					throw new PopServerNotAvailableException("Server is not available", innerException);
				}
			}
			throw new ArgumentNullException("stream");
		}
		throw new InvalidUseException("You cannot ask to connect to a POP3 server, when we are already connected to one. Disconnect first.");
	}

	public void Connect(string hostname, int port, bool useSsl)
	{
		Connect(hostname, port, useSsl, 60000, 60000, null);
	}

	public void Connect(string hostname, int port, bool useSsl, int receiveTimeout, int sendTimeout, RemoteCertificateValidationCallback certificateValidator)
	{
		AssertDisposed();
		if (hostname != null)
		{
			if (hostname.Length != 0)
			{
				if (port <= 65535 && port >= 0)
				{
					if (receiveTimeout >= 0)
					{
						if (sendTimeout >= 0)
						{
							if (method_6() == Enum9.const_0)
							{
								TcpClient tcpClient = new TcpClient();
								tcpClient.ReceiveTimeout = receiveTimeout;
								tcpClient.SendTimeout = sendTimeout;
								try
								{
									tcpClient.Connect(hostname, port);
								}
								catch (SocketException ex)
								{
									tcpClient.Close();
									DefaultLogger.Log.LogError("Connect(): " + ex.Message);
									throw new PopServerNotFoundException("Server not found", ex);
								}
								Stream stream;
								if (!useSsl)
								{
									stream = tcpClient.GetStream();
								}
								else
								{
									SslStream sslStream = ((certificateValidator == null) ? new SslStream(tcpClient.GetStream(), leaveInnerStreamOpen: false) : new SslStream(tcpClient.GetStream(), leaveInnerStreamOpen: false, certificateValidator));
									sslStream.ReadTimeout = receiveTimeout;
									sslStream.WriteTimeout = sendTimeout;
									sslStream.AuthenticateAsClient(hostname);
									stream = sslStream;
								}
								Connect(stream);
								return;
							}
							throw new InvalidUseException("You cannot ask to connect to a POP3 server, when we are already connected to one. Disconnect first.");
						}
						throw new ArgumentOutOfRangeException("sendTimeout");
					}
					throw new ArgumentOutOfRangeException("receiveTimeout");
				}
				throw new ArgumentOutOfRangeException("port");
			}
			throw new ArgumentException("hostname cannot be empty", "hostname");
		}
		throw new ArgumentNullException("hostname");
	}

	public void Disconnect()
	{
		AssertDisposed();
		if (method_6() != Enum9.const_0)
		{
			try
			{
				Class156.smethod_144(this, "QUIT");
				return;
			}
			finally
			{
				Class156.smethod_61(this);
			}
		}
		throw new InvalidUseException("You cannot disconnect a connection which is already disconnected");
	}

	public void Authenticate(string username, string password)
	{
		AssertDisposed();
		Authenticate(username, password, AuthenticationMethod.Auto);
	}

	public void Authenticate(string username, string password, AuthenticationMethod authenticationMethod)
	{
		AssertDisposed();
		if (username != null)
		{
			if (password != null)
			{
				if (method_6() == Enum9.const_1)
				{
					try
					{
						switch (authenticationMethod)
						{
						case AuthenticationMethod.CramMd5:
							Class156.smethod_264(this, username, password);
							break;
						case AuthenticationMethod.UsernameAndPassword:
							Class156.smethod_214(this, username, password);
							break;
						case AuthenticationMethod.Apop:
							Class156.smethod_68(this, username, password);
							break;
						case AuthenticationMethod.Auto:
							if (!ApopSupported)
							{
								Class156.smethod_214(this, username, password);
							}
							else
							{
								Class156.smethod_68(this, username, password);
							}
							break;
						}
					}
					catch (PopServerException ex)
					{
						DefaultLogger.Log.LogError("Problem logging in using method " + authenticationMethod.ToString() + ". Server response was: " + method_2());
						Class156.smethod_213(ex, method_2());
						throw new InvalidLoginException(ex);
					}
					method_7(Enum9.const_2);
					return;
				}
				throw new InvalidUseException("You have to be connected and not authorized when trying to authorize yourself");
			}
			throw new ArgumentNullException("password");
		}
		throw new ArgumentNullException("username");
	}

	public int GetMessageCount()
	{
		AssertDisposed();
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("You cannot get the message count without authenticating yourself towards the server first");
		}
		return Class156.smethod_197(this, "STAT", 1);
	}

	public void DeleteMessage(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("You cannot delete any messages without authenticating yourself towards the server first");
		}
		Class156.smethod_144(this, "DELE " + messageNumber);
	}

	public void DeleteAllMessages()
	{
		AssertDisposed();
		int messageCount = GetMessageCount();
		for (int num = messageCount; num > 0; num--)
		{
			DeleteMessage(num);
		}
	}

	public void NoOperation()
	{
		AssertDisposed();
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("You cannot use the NOOP command unless you are authenticated to the server");
		}
		Class156.smethod_144(this, "NOOP");
	}

	public void Reset()
	{
		AssertDisposed();
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("You cannot use the RSET command unless you are authenticated to the server");
		}
		Class156.smethod_144(this, "RSET");
	}

	public string GetMessageUid(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("Cannot get message ID, when the user has not been authenticated yet");
		}
		Class156.smethod_144(this, "UIDL " + messageNumber);
		return method_2().Split(' ')[2];
	}

	public List<string> GetMessageUids()
	{
		AssertDisposed();
		if (method_6() == Enum9.const_2)
		{
			Class156.smethod_144(this, "UIDL");
			List<string> list = new List<string>();
			string text;
			while (!Class156.smethod_69(text = Class156.smethod_106(method_0())))
			{
				list.Add(text.Split(' ')[1]);
			}
			return list;
		}
		throw new InvalidUseException("Cannot get message IDs, when the user has not been authenticated yet");
	}

	public int GetMessageSize(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("Cannot get message size, when the user has not been authenticated yet");
		}
		return Class156.smethod_197(this, "LIST " + messageNumber, 2);
	}

	public List<int> GetMessageSizes()
	{
		AssertDisposed();
		if (method_6() == Enum9.const_2)
		{
			Class156.smethod_144(this, "LIST");
			List<int> list = new List<int>();
			string text;
			while (!".".Equals(text = Class156.smethod_106(method_0())))
			{
				list.Add(int.Parse(text.Split(' ')[1], CultureInfo.InvariantCulture));
			}
			return list;
		}
		throw new InvalidUseException("Cannot get message sizes, when the user has not been authenticated yet");
	}

	public Message GetMessage(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
		}
		byte[] messageAsBytes = GetMessageAsBytes(messageNumber);
		return new Message(messageAsBytes);
	}

	public byte[] GetMessageAsBytes(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
		}
		return method_8(messageNumber, bool_3: false);
	}

	public MessageHeader GetMessageHeaders(int messageNumber)
	{
		AssertDisposed();
		Class156.smethod_21(messageNumber);
		if (method_6() != Enum9.const_2)
		{
			throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
		}
		byte[] rawMessageContent = method_8(messageNumber, bool_3: true);
		return new Message(rawMessageContent, parseBody: false).Headers;
	}

	public Dictionary<string, List<string>> Capabilities()
	{
		AssertDisposed();
		if (method_6() == Enum9.const_1 || method_6() == Enum9.const_2)
		{
			Class156.smethod_144(this, "CAPA");
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
			string text;
			while (!Class156.smethod_69(text = Class156.smethod_106(method_0())))
			{
				string[] array = text.Split(' ');
				string key = array[0];
				List<string> list = new List<string>();
				for (int i = 1; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				dictionary.Add(key, list);
			}
			return dictionary;
		}
		throw new InvalidUseException("Capability command only available while connected or authenticated");
	}

	private byte[] method_8(int int_0, bool bool_3)
	{
		AssertDisposed();
		Class156.smethod_21(int_0);
		if (method_6() == Enum9.const_2)
		{
			if (!bool_3)
			{
				Class156.smethod_144(this, "RETR " + int_0);
			}
			else
			{
				Class156.smethod_144(this, "TOP " + int_0 + " 0");
			}
			using MemoryStream memoryStream = new MemoryStream();
			bool flag = true;
			byte[] array;
			while (!Class156.smethod_225(array = Class156.smethod_113(method_0())))
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					byte[] bytes = Encoding.ASCII.GetBytes("\r\n");
					memoryStream.Write(bytes, 0, bytes.Length);
				}
				if (array.Length == 0 || array[0] != 46)
				{
					memoryStream.Write(array, 0, array.Length);
				}
				else
				{
					memoryStream.Write(array, 1, array.Length - 1);
				}
			}
			if (bool_3)
			{
				byte[] bytes2 = Encoding.ASCII.GetBytes("\r\n");
				memoryStream.Write(bytes2, 0, bytes2.Length);
			}
			return memoryStream.ToArray();
		}
		throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
	}
}
