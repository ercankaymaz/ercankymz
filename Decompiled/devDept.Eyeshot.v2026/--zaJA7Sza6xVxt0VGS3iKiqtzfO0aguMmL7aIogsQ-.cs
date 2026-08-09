using System.IO;
using ProtoBuf.Meta;
using devDept.Geometry.Blink;
using devDept.Geometry.Blink.Message;
using devDept.Geometry.Blink.Serialization;
using devDept.Serialization;

internal sealed class _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D : FileSerializer
{
	public _0023_003DzaJA7Sza6xVxt0VGS3iKiqtzfO0aguMmL7aIogsQ_003D()
	{
		base.HeaderVersion = Serializer.LastVersion;
		InitializeModel();
		CompileModel();
	}

	protected override void FillModel()
	{
		if (!ModelIsCompiled())
		{
			base.FillModel();
			base.Model.Add(typeof(BlinkMsg), applyDefaultBehaviour: false).AddSubType(1, typeof(EntityMsg)).AddSubType(2, typeof(LabelMsg))
				.AddSubType(3, typeof(CollectionsMsg))
				.AddSubType(4, typeof(ClearMsg))
				.AddSubType(5, typeof(VectorMsg))
				.AddSubType(6, typeof(FitMsg))
				.AddSubType(7, typeof(ViewMsg))
				.AddSubType(8, typeof(BackfaceMsg))
				.SetSurrogate(typeof(BlinkMsgSurrogate));
			MetaType metaType = base.Model[typeof(BlinkMsgSurrogate)];
			metaType.AddSubType(1, typeof(EntityMsgSurrogate));
			metaType.AddSubType(2, typeof(LabelMsgSurrogate));
			metaType.AddSubType(3, typeof(CollectionsMsgSurrogate));
			metaType.AddSubType(4, typeof(ClearMsgSurrogate));
			metaType.AddSubType(5, typeof(VectorMsgSurrogate));
			metaType.AddSubType(6, typeof(FitMsgSurrogate));
			metaType.AddSubType(7, typeof(ViewMsgSurrogate));
			metaType.AddSubType(8, typeof(BackfaceMsgSurrogate));
			metaType.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType.UseConstructor = false;
			MetaType metaType2 = base.Model[typeof(EntityMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997044)).Add(2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829)).Add(3, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654479))
				.Add(4, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654690));
			metaType2.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType2.UseConstructor = false;
			MetaType metaType3 = base.Model[typeof(LabelMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654674)).Add(2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953933)).Add(3, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654688))
				.Add(4, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829));
			metaType3.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType3.UseConstructor = false;
			MetaType metaType4 = base.Model[typeof(VectorMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986399)).Add(2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654669)).Add(3, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829))
				.Add(4, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654690));
			metaType4.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType4.UseConstructor = false;
			MetaType metaType5 = base.Model[typeof(FitMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654630));
			metaType5.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType5.UseConstructor = false;
			MetaType metaType6 = base.Model[typeof(ViewMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988070));
			metaType6.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType6.UseConstructor = false;
			MetaType metaType7 = base.Model[typeof(BackfaceMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953843));
			metaType7.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType7.UseConstructor = false;
			MetaType metaType8 = base.Model[typeof(CollectionsMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998950)).Add(2, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654613));
			metaType8.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType8.UseConstructor = false;
			MetaType metaType9 = base.Model[typeof(ClearMsgSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654600));
			metaType9.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType9.UseConstructor = false;
			base.Model.Add(typeof(ClientConfiguration), applyDefaultBehaviour: false).SetSurrogate(typeof(ClientConfigurationSurrogate));
			MetaType metaType10 = base.Model[typeof(ClientConfigurationSurrogate)].Add(1, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655348));
			metaType10.SetCallbacks(null, null, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654487), null);
			metaType10.UseConstructor = false;
		}
	}

	public void _0023_003Dz18lsJP2p7ers<T>(Stream _0023_003DzdLqTRfo_003D, T _0023_003DzCX9Hbao_003D, int _0023_003DzfOwdbYDOgk2J)
	{
		SerializeWithLengthPrefix(_0023_003DzdLqTRfo_003D, _0023_003DzCX9Hbao_003D, _0023_003DzfOwdbYDOgk2J);
	}

	public T _0023_003Dzc25DZSkxWle7<T>(Stream _0023_003DzdLqTRfo_003D, out long _0023_003DzVRsIQq4_003D, int _0023_003DzfOwdbYDOgk2J)
	{
		return DeserializeWithLengthPrefix<T>(_0023_003DzdLqTRfo_003D, out _0023_003DzVRsIQq4_003D, _0023_003DzfOwdbYDOgk2J);
	}

	public T[] _0023_003DzpjtaAFYywh9r<T>(Stream _0023_003DzdLqTRfo_003D, int _0023_003DzfOwdbYDOgk2J)
	{
		return DeserializeAllItemsWithLengthPrefix<T>(_0023_003DzdLqTRfo_003D, _0023_003DzfOwdbYDOgk2J);
	}

	public void _0023_003DzUal_0024ApYHAIaM()
	{
		Serializer.ResetCache();
	}
}
