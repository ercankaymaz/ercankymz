using System;
using System.Drawing;
using ProtoBuf.Meta;
using devDept.Eyeshot.Control.Labels;

namespace devDept.Serialization;

public class FileSerializerWithLabels : FileSerializer
{
	public FileSerializerWithLabels()
	{
	}

	public FileSerializerWithLabels(contentType contentType)
		: base(contentType)
	{
	}

	protected override void FillModel()
	{
		if (!ModelIsCompiled())
		{
			base.FillModel();
			base.Model.Add(typeof(Font), applyDefaultBehaviour: false).SetSurrogate(typeof(SystemDrawingFontSurrogate));
			base.Model[typeof(SystemDrawingFontSurrogate)].Add(1, "FamilyName").Add(2, "SizeInPoints").Add(3, "Style")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(Label), applyDefaultBehaviour: false).AddSubType(201, typeof(ImageOnly)).AddSubType(202, typeof(TextOnly))
				.SetSurrogate(typeof(LabelSurrogate));
			MetaType metaType = base.Model[typeof(LabelSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Color");
			metaType.Add(2, "AnchorPoint");
			metaType.Add(3, "Image");
			metaType.Add(4, "Visible");
			metaType.Add(5, "LabelData");
			metaType.Add(6, "Selectable");
			metaType.Add(7, "Alignment");
			metaType.Add(8, "Type");
			metaType.Add(9, "AutoHide");
			AddReferenceIdField(metaType);
			metaType.SetCallbacks("BeforeSerialize", null, "BeforeDeserialize", "AfterDeserialize").UseConstructor = false;
			metaType.AddSubType(201, typeof(ImageOnlySurrogate));
			metaType.AddSubType(202, typeof(TextOnlySurrogate));
			metaType = base.Model[typeof(ImageOnly)];
			metaType.AddSubType(201, typeof(LeaderAndImage));
			metaType = base.Model[typeof(ImageOnlySurrogate)];
			metaType.UseConstructor = false;
			metaType.AddSubType(201, typeof(LeaderAndImageSurrogate));
			metaType.Add(1, "HotSpot");
			metaType.Add(2, "ImageForSelection");
			metaType = base.Model[typeof(LeaderAndImageSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Offset");
			metaType = base.Model[typeof(TextOnly)];
			metaType.AddSubType(201, typeof(LeaderAndText));
			metaType.AddSubType(202, typeof(OutlinedText));
			metaType = base.Model[typeof(TextOnlySurrogate)];
			metaType.UseConstructor = false;
			metaType.AddSubType(201, typeof(LeaderAndTextSurrogate));
			metaType.AddSubType(202, typeof(OutlinedTextSurrogate));
			metaType.Add(1, "Text");
			metaType.Add(2, "Font");
			metaType.Add(3, "Vertical");
			metaType.Add(4, "FillColor");
			metaType.Add(5, "ColorForSelection");
			metaType.Add(6, "FillColorForSelection");
			metaType.Add(7, "CornerRadius");
			metaType = base.Model[typeof(LeaderAndTextSurrogate)];
			metaType.UseConstructor = false;
			metaType.Add(1, "Offset");
			metaType = base.Model[typeof(OutlinedTextSurrogate)];
			metaType.UseConstructor = false;
		}
	}

	protected override Type GetTypeForObject(string typeName)
	{
		Type type = Type.GetType(typeName, throwOnError: false, ignoreCase: true);
		if (type != null)
		{
			return type;
		}
		return base.GetTypeForObject(typeName);
	}
}
