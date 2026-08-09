using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Xceed.Wpf.AvalonDock.Layout.Serialization;

public class XmlLayoutSerializer : LayoutSerializer
{
	public XmlLayoutSerializer(DockingManager manager)
		: base(manager)
	{
	}

	public void Serialize(XmlWriter writer)
	{
		new XmlSerializer(typeof(LayoutRoot)).Serialize(writer, base.Manager.Layout);
	}

	public void Serialize(TextWriter writer)
	{
		new XmlSerializer(typeof(LayoutRoot)).Serialize(writer, base.Manager.Layout);
	}

	public void Serialize(Stream stream)
	{
		new XmlSerializer(typeof(LayoutRoot)).Serialize(stream, base.Manager.Layout);
	}

	public void Serialize(string filepath)
	{
		using StreamWriter writer = new StreamWriter(filepath);
		Serialize(writer);
	}

	public void Deserialize(Stream stream)
	{
		try
		{
			StartDeserialization();
			LayoutRoot layout = new XmlSerializer(typeof(LayoutRoot)).Deserialize(stream) as LayoutRoot;
			FixupLayout(layout);
			base.Manager.Layout = layout;
		}
		finally
		{
			EndDeserialization();
		}
	}

	public void Deserialize(TextReader reader)
	{
		try
		{
			StartDeserialization();
			LayoutRoot layout = new XmlSerializer(typeof(LayoutRoot)).Deserialize(reader) as LayoutRoot;
			FixupLayout(layout);
			base.Manager.Layout = layout;
		}
		finally
		{
			EndDeserialization();
		}
	}

	public void Deserialize(XmlReader reader)
	{
		try
		{
			StartDeserialization();
			LayoutRoot layout = new XmlSerializer(typeof(LayoutRoot)).Deserialize(reader) as LayoutRoot;
			FixupLayout(layout);
			base.Manager.Layout = layout;
		}
		finally
		{
			EndDeserialization();
		}
	}

	public void Deserialize(string filepath)
	{
		using StreamReader reader = new StreamReader(filepath);
		Deserialize(reader);
	}
}
