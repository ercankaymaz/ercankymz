using System;
using System.IO;
using System.Text;
using ACadSharp.Header;
using CSUtilities.IO;
using CSUtilities.Text;

namespace ACadSharp.IO;

public abstract class CadReaderBase<T> : ICadReader, IDisposable where T : CadReaderConfiguration, new()
{
	protected CadDocument _document = new CadDocument(createDefaults: false);

	protected Encoding _encoding = Encoding.Default;

	internal readonly StreamIO _fileStream;

	public T Configuration { get; set; } = new T();

	public event NotificationEventHandler OnNotification;

	protected CadReaderBase(NotificationEventHandler notification)
	{
		OnNotification += notification;
	}

	protected CadReaderBase(string filename, NotificationEventHandler notification = null)
		: this((Stream)File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), notification)
	{
	}

	protected CadReaderBase(Stream stream, NotificationEventHandler notification = null)
		: this(notification)
	{
		_fileStream = new StreamIO(stream);
	}

	public abstract CadDocument Read();

	public abstract CadHeader ReadHeader();

	public virtual void Dispose()
	{
		_fileStream.Dispose();
	}

	protected Encoding getListedEncoding(int code)
	{
		try
		{
			return Encoding.GetEncoding(code);
		}
		catch (Exception ex)
		{
			triggerNotification($"Encoding with codee {code} not found, using Windows-1252 as default", NotificationType.Warning, ex);
		}
		return TextEncoding.Windows1252();
	}

	protected void triggerNotification(string message, NotificationType notificationType, Exception ex = null)
	{
		onNotificationEvent(null, new NotificationEventArgs(message, notificationType, ex));
	}

	protected void onNotificationEvent(object sender, NotificationEventArgs e)
	{
		this.OnNotification?.Invoke(this, e);
	}
}
