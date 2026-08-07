// Decompiled with JetBrains decompiler
// Type: buPop3.Pop3.Pop3Client
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Common.Logging;
using buPop3.Mime;
using buPop3.Mime.Header;
using buPop3.Pop3.Exceptions;
using ns1;
using ns7;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace buPop3.Pop3;

public class Pop3Client : Disposable
{
  [CompilerGenerated]
  [SpecialName]
  internal Stream method_0() => this.stream_0;

  [CompilerGenerated]
  [SpecialName]
  internal string method_2() => this.string_0;

  [CompilerGenerated]
  [SpecialName]
  internal void method_3(string string_2) => this.string_0 = string_2;

  [CompilerGenerated]
  [SpecialName]
  internal string method_4() => this.string_1;

  [CompilerGenerated]
  [SpecialName]
  internal void method_5(string string_2) => this.string_1 = string_2;

  [CompilerGenerated]
  [SpecialName]
  internal void method_7(Enum0 enum0_1) => this.enum0_0 = enum0_1;

  public bool Connected { get; internal set; }

  public bool ApopSupported { get; internal set; }

  public Pop3Client() => Class30.smethod_279(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (!this.IsDisposed ? 1 : 0)) != 0 && this.Connected)
      this.Disconnect();
    base.Dispose(disposing);
  }

  public void Connect(Stream stream)
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != 0)
      throw new InvalidUseException("You cannot ask to connect to a POP3 server, when we are already connected to one. Disconnect first.");
    if (stream == null)
      throw new ArgumentNullException(nameof (stream));
    // ISSUE: reference to a compiler-generated method
    this.method_1(stream);
    string string_0 = Class30.smethod_106(this.method_0());
    try
    {
      this.method_7(Enum0.const_1);
      Class30.smethod_98(string_0);
      Class30.smethod_62(this, string_0);
      this.Connected = true;
    }
    catch (PopServerException ex)
    {
      Class30.smethod_61(this);
      DefaultLogger.Log.LogError("Connect(): Error with connection, maybe POP3 server not exist");
      DefaultLogger.Log.LogDebug("Last response from server was: " + this.method_2());
      throw new PopServerNotAvailableException("Server is not available", (Exception) ex);
    }
  }

  public void Connect(string hostname, int port, bool useSsl)
  {
    this.Connect(hostname, port, useSsl, 60000, 60000, (RemoteCertificateValidationCallback) null);
  }

  public void Connect(
    string hostname,
    int port,
    bool useSsl,
    int receiveTimeout,
    int sendTimeout,
    RemoteCertificateValidationCallback certificateValidator)
  {
    this.AssertDisposed();
    switch (hostname)
    {
      case null:
        throw new ArgumentNullException(nameof (hostname));
      case "":
        throw new ArgumentException("hostname cannot be empty", nameof (hostname));
      default:
        if ((port > (int) ushort.MaxValue ? 1 : (port < 0 ? 1 : 0)) != 0)
          throw new ArgumentOutOfRangeException(nameof (port));
        if (receiveTimeout < 0)
          throw new ArgumentOutOfRangeException(nameof (receiveTimeout));
        if (sendTimeout < 0)
          throw new ArgumentOutOfRangeException(nameof (sendTimeout));
        // ISSUE: reference to a compiler-generated method
        if (this.method_6() != 0)
          throw new InvalidUseException("You cannot ask to connect to a POP3 server, when we are already connected to one. Disconnect first.");
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
          throw new PopServerNotFoundException("Server not found", (Exception) ex);
        }
        Stream stream;
        if (useSsl)
        {
          SslStream sslStream = certificateValidator != null ? new SslStream((Stream) tcpClient.GetStream(), false, certificateValidator) : new SslStream((Stream) tcpClient.GetStream(), false);
          sslStream.ReadTimeout = receiveTimeout;
          sslStream.WriteTimeout = sendTimeout;
          sslStream.AuthenticateAsClient(hostname);
          stream = (Stream) sslStream;
        }
        else
          stream = (Stream) tcpClient.GetStream();
        this.Connect(stream);
        break;
    }
  }

  public void Disconnect()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() == Enum0.const_0)
      throw new InvalidUseException("You cannot disconnect a connection which is already disconnected");
    try
    {
      Class30.smethod_144(this, "QUIT");
    }
    finally
    {
      Class30.smethod_61(this);
    }
  }

  public void Authenticate(string username, string password)
  {
    this.AssertDisposed();
    this.Authenticate(username, password, AuthenticationMethod.Auto);
  }

  public void Authenticate(
    string username,
    string password,
    AuthenticationMethod authenticationMethod)
  {
    this.AssertDisposed();
    if (username == null)
      throw new ArgumentNullException(nameof (username));
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_1)
      throw new InvalidUseException("You have to be connected and not authorized when trying to authorize yourself");
    try
    {
      switch (authenticationMethod)
      {
        case AuthenticationMethod.UsernameAndPassword:
          Class30.smethod_214(this, username, password);
          break;
        case AuthenticationMethod.Apop:
          Class30.smethod_68(this, username, password);
          break;
        case AuthenticationMethod.Auto:
          if (this.ApopSupported)
          {
            Class30.smethod_68(this, username, password);
            break;
          }
          Class30.smethod_214(this, username, password);
          break;
        case AuthenticationMethod.CramMd5:
          Class30.smethod_264(this, username, password);
          break;
      }
    }
    catch (PopServerException ex)
    {
      DefaultLogger.Log.LogError($"Problem logging in using method {authenticationMethod.ToString()}. Server response was: {this.method_2()}");
      Class30.smethod_213(ex, this.method_2());
      throw new InvalidLoginException((Exception) ex);
    }
    this.method_7(Enum0.const_2);
  }

  public int GetMessageCount()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("You cannot get the message count without authenticating yourself towards the server first");
    return Class30.smethod_197(this, "STAT", 1);
  }

  public void DeleteMessage(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("You cannot delete any messages without authenticating yourself towards the server first");
    Class30.smethod_144(this, "DELE " + messageNumber.ToString());
  }

  public void DeleteAllMessages()
  {
    this.AssertDisposed();
    for (int messageCount = this.GetMessageCount(); messageCount > 0; --messageCount)
      this.DeleteMessage(messageCount);
  }

  public void NoOperation()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("You cannot use the NOOP command unless you are authenticated to the server");
    Class30.smethod_144(this, "NOOP");
  }

  public void Reset()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("You cannot use the RSET command unless you are authenticated to the server");
    Class30.smethod_144(this, "RSET");
  }

  public string GetMessageUid(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot get message ID, when the user has not been authenticated yet");
    Class30.smethod_144(this, "UIDL " + messageNumber.ToString());
    return this.method_2().Split(' ')[2];
  }

  public List<string> GetMessageUids()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot get message IDs, when the user has not been authenticated yet");
    Class30.smethod_144(this, "UIDL");
    List<string> messageUids = new List<string>();
    string str;
    while (!Class30.smethod_69(str = Class30.smethod_106(this.method_0())))
      messageUids.Add(str.Split(' ')[1]);
    return messageUids;
  }

  public int GetMessageSize(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot get message size, when the user has not been authenticated yet");
    return Class30.smethod_197(this, "LIST " + messageNumber.ToString(), 2);
  }

  public List<int> GetMessageSizes()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot get message sizes, when the user has not been authenticated yet");
    Class30.smethod_144(this, "LIST");
    List<int> messageSizes = new List<int>();
    string str;
    while (!".".Equals(str = Class30.smethod_106(this.method_0())))
      messageSizes.Add(int.Parse(str.Split(' ')[1], (IFormatProvider) CultureInfo.InvariantCulture));
    return messageSizes;
  }

  public Message GetMessage(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
    return new Message(this.GetMessageAsBytes(messageNumber));
  }

  public byte[] GetMessageAsBytes(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
    return this.method_8(messageNumber, false);
  }

  public MessageHeader GetMessageHeaders(int messageNumber)
  {
    this.AssertDisposed();
    Class30.smethod_21(messageNumber);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
    return new Message(this.method_8(messageNumber, true), false).Headers;
  }

  public Dictionary<string, List<string>> Capabilities()
  {
    this.AssertDisposed();
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    if ((this.method_6() == Enum0.const_1 ? 0 : (this.method_6() != Enum0.const_2 ? 1 : 0)) != 0)
      throw new InvalidUseException("Capability command only available while connected or authenticated");
    Class30.smethod_144(this, "CAPA");
    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    string str;
    while (!Class30.smethod_69(str = Class30.smethod_106(this.method_0())))
    {
      string[] strArray = str.Split(' ');
      string key = strArray[0];
      List<string> stringList = new List<string>();
      for (int index = 1; index < strArray.Length; ++index)
        stringList.Add(strArray[index]);
      dictionary.Add(key, stringList);
    }
    return dictionary;
  }

  private byte[] method_8(int int_0, bool bool_3)
  {
    this.AssertDisposed();
    Class30.smethod_21(int_0);
    // ISSUE: reference to a compiler-generated method
    if (this.method_6() != Enum0.const_2)
      throw new InvalidUseException("Cannot fetch a message, when the user has not been authenticated yet");
    if (bool_3)
      Class30.smethod_144(this, $"TOP {int_0.ToString()} 0");
    else
      Class30.smethod_144(this, "RETR " + int_0.ToString());
    using (MemoryStream memoryStream = new MemoryStream())
    {
      bool flag = true;
      byte[] buffer;
      while (!Class30.smethod_225(buffer = Class30.smethod_113(this.method_0())))
      {
        if (!flag)
        {
          byte[] bytes = Encoding.ASCII.GetBytes("\r\n");
          memoryStream.Write(bytes, 0, bytes.Length);
        }
        else
          flag = false;
        if ((buffer.Length == 0 ? 0 : (buffer[0] == (byte) 46 ? 1 : 0)) != 0)
          memoryStream.Write(buffer, 1, buffer.Length - 1);
        else
          memoryStream.Write(buffer, 0, buffer.Length);
      }
      if (bool_3)
      {
        byte[] bytes = Encoding.ASCII.GetBytes("\r\n");
        memoryStream.Write(bytes, 0, bytes.Length);
      }
      return memoryStream.ToArray();
    }
  }
}
