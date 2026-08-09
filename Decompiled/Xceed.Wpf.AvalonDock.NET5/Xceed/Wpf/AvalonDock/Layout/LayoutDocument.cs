#define TRACE
using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace Xceed.Wpf.AvalonDock.Layout;

[Serializable]
public class LayoutDocument : LayoutContent
{
	internal bool _canMove = true;

	private bool _isVisible = true;

	private string _description;

	public bool CanMove
	{
		get
		{
			return _canMove;
		}
		set
		{
			if (_canMove != value)
			{
				_canMove = value;
				RaisePropertyChanged("CanMove");
			}
		}
	}

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		internal set
		{
			_isVisible = value;
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			if (_description != value)
			{
				_description = value;
				RaisePropertyChanged("Description");
			}
		}
	}

	public override void WriteXml(XmlWriter writer)
	{
		base.WriteXml(writer);
		if (!string.IsNullOrWhiteSpace(Description))
		{
			writer.WriteAttributeString("Description", Description);
		}
		if (!CanMove)
		{
			writer.WriteAttributeString("CanMove", CanMove.ToString());
		}
	}

	public override void ReadXml(XmlReader reader)
	{
		if (reader.MoveToAttribute("Description"))
		{
			Description = reader.Value;
		}
		if (reader.MoveToAttribute("CanMove"))
		{
			CanMove = bool.Parse(reader.Value);
		}
		base.ReadXml(reader);
	}

	public override void Close()
	{
		if (base.Root != null && base.Root.Manager != null)
		{
			base.Root.Manager._ExecuteCloseCommand(this);
		}
		else
		{
			CloseDocument();
		}
	}

	public override void ConsoleDump(int tab)
	{
		Trace.Write(new string(' ', tab * 4));
		Trace.WriteLine("Document()");
	}

	protected override void InternalDock()
	{
		LayoutRoot layoutRoot = base.Root as LayoutRoot;
		LayoutDocumentPane layoutDocumentPane = null;
		if (layoutRoot.LastFocusedDocument != null && layoutRoot.LastFocusedDocument != this)
		{
			layoutDocumentPane = layoutRoot.LastFocusedDocument.Parent as LayoutDocumentPane;
		}
		if (layoutDocumentPane == null)
		{
			layoutDocumentPane = layoutRoot.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
		}
		bool flag = false;
		if (layoutRoot.Manager.LayoutUpdateStrategy != null)
		{
			flag = layoutRoot.Manager.LayoutUpdateStrategy.BeforeInsertDocument(layoutRoot, this, layoutDocumentPane);
		}
		if (!flag)
		{
			if (layoutDocumentPane == null)
			{
				throw new InvalidOperationException("Layout must contains at least one LayoutDocumentPane in order to host documents");
			}
			layoutDocumentPane.Children.Add(this);
			flag = true;
		}
		if (layoutRoot.Manager.LayoutUpdateStrategy != null)
		{
			layoutRoot.Manager.LayoutUpdateStrategy.AfterInsertDocument(layoutRoot, this);
		}
		base.InternalDock();
	}

	internal bool CloseDocument()
	{
		if (TestCanClose())
		{
			CloseInternal();
			return true;
		}
		return false;
	}
}
