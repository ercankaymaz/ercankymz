using System;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Entities;
using ACadSharp.Tables;
using CSUtilities.Text;

namespace ACadSharp.IO;

public abstract class CadWriterBase<T> : ICadWriter, IDisposable where T : CadWriterConfiguration, new()
{
	protected CadDocument _document;

	protected Encoding _encoding;

	protected Stream _stream;

	public T Configuration { get; set; } = new T();

	public event NotificationEventHandler OnNotification;

	protected CadWriterBase(Stream stream, CadDocument document)
	{
		_stream = stream;
		_document = document;
	}

	public abstract void Dispose();

	public virtual void Write()
	{
		_document.UpdateImageReactors();
		_document.UpdateDxfClasses(Configuration.ResetDxfClasses);
		if (Configuration.UpdateDimensionsInModel)
		{
			updateDimensions(_document.ModelSpace);
		}
		if (Configuration.UpdateDimensionsInBlocks)
		{
			foreach (BlockRecord blockRecord in _document.BlockRecords)
			{
				if (!blockRecord.Name.Equals("*Model_Space", StringComparison.OrdinalIgnoreCase))
				{
					updateDimensions(blockRecord);
				}
			}
		}
		_encoding = getListedEncoding(_document.Header.CodePage);
	}

	protected Encoding getListedEncoding(string codePage)
	{
		CodePage codePage2 = CadUtils.GetCodePage(codePage);
		try
		{
			return Encoding.GetEncoding((int)codePage2);
		}
		catch (Exception ex)
		{
			triggerNotification($"Encoding with code {codePage2} not found, using Windows-1252 as default", NotificationType.Warning, ex);
		}
		return TextEncoding.Windows1252();
	}

	protected void triggerNotification(string message, NotificationType notificationType, Exception ex = null)
	{
		triggerNotification(this, new NotificationEventArgs(message, notificationType, ex));
	}

	protected void triggerNotification(object sender, NotificationEventArgs e)
	{
		this.OnNotification?.Invoke(sender, e);
	}

	private void updateDimensions(BlockRecord record)
	{
		foreach (Dimension item in record.Entities.OfType<Dimension>())
		{
			item.UpdateBlock();
		}
	}
}
