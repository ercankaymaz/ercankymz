using System.Windows;
using System.Windows.Media;
using MS.Internal.Interaction;

namespace Microsoft.Windows.Design.Interaction;

public static class AdornerColors
{
	private static readonly ResourceKey _alignmentMarkBrushKey;

	private static readonly ResourceKey _alignmentMarkColorKey;

	private static readonly ResourceKey _elementBorderBrushKey;

	private static readonly ResourceKey _elementBorderColorKey;

	private static readonly ResourceKey _glyphFillBrushKey;

	private static readonly ResourceKey _glyphFillColorKey;

	private static readonly ResourceKey _handleBorderColorKey;

	private static readonly ResourceKey _handleBorderBrushKey;

	private static readonly ResourceKey _handleFillColorKey;

	private static readonly ResourceKey _handleFillBrushKey;

	private static readonly ResourceKey _handleFillHoverColorKey;

	private static readonly ResourceKey _handleEmptyFillColorKey;

	private static readonly ResourceKey _handleEmptyFillBrushKey;

	private static readonly ResourceKey _handleFillHoverBrushKey;

	private static readonly ResourceKey _handleFillPressedColorKey;

	private static readonly ResourceKey _handleFillPressedBrushKey;

	private static readonly ResourceKey _moveHandleContentBrushKey;

	private static readonly ResourceKey _moveHandleContentColorKey;

	private static readonly ResourceKey _moveHandleFillBrushKey;

	private static readonly ResourceKey _moveHandleFillColorKey;

	private static readonly ResourceKey _moveHandleFillHoverBrushKey;

	private static readonly ResourceKey _moveHandleFillHoverColorKey;

	private static readonly ResourceKey _railFillBrushKey;

	private static readonly ResourceKey _railFillColorKey;

	private static readonly ResourceKey _selectionFrameBorderBrushKey;

	private static readonly ResourceKey _selectionFrameBorderColorKey;

	private static readonly ResourceKey _selectionFrameFillBrushKey;

	private static readonly ResourceKey _selectionFrameFillColorKey;

	private static readonly ResourceKey _simpleWashBrushKey;

	private static readonly ResourceKey _simpleWashColorKey;

	private static readonly ResourceKey _toggledGlyphFillBrushKey;

	private static readonly ResourceKey _toggledGlyphFillColorKey;

	public static Brush AlignmentMarkBrush => GetBrush(AlignmentMarkBrushKey);

	public static ResourceKey AlignmentMarkBrushKey => _alignmentMarkBrushKey;

	public static Color AlignmentMarkColor => GetColor(AlignmentMarkColorKey);

	public static ResourceKey AlignmentMarkColorKey => _alignmentMarkColorKey;

	public static Brush ElementBorderBrush => GetBrush(ElementBorderBrushKey);

	public static ResourceKey ElementBorderBrushKey => _elementBorderBrushKey;

	public static Color ElementBorderColor => GetColor(ElementBorderColorKey);

	public static ResourceKey ElementBorderColorKey => _elementBorderColorKey;

	public static Brush GlyphFillBrush => GetBrush(GlyphFillBrushKey);

	public static ResourceKey GlyphFillBrushKey => _glyphFillBrushKey;

	public static Color GlyphFillColor => GetColor(GlyphFillColorKey);

	public static ResourceKey GlyphFillColorKey => _glyphFillColorKey;

	public static Brush HandleBorderBrush => GetBrush(HandleBorderBrushKey);

	public static ResourceKey HandleBorderBrushKey => _handleBorderBrushKey;

	public static Color HandleBorderColor => GetColor(HandleBorderColorKey);

	public static ResourceKey HandleBorderColorKey => _handleBorderColorKey;

	public static Brush HandleFillBrush => GetBrush(HandleFillBrushKey);

	public static ResourceKey HandleFillBrushKey => _handleFillBrushKey;

	public static Color HandleFillColor => GetColor(HandleFillColorKey);

	public static ResourceKey HandleFillColorKey => _handleFillColorKey;

	public static Brush HandleEmptyFillBrush => GetBrush(HandleEmptyFillBrushKey);

	public static ResourceKey HandleEmptyFillBrushKey => _handleEmptyFillBrushKey;

	public static Color HandleEmptyFillColor => GetColor(HandleEmptyFillColorKey);

	public static ResourceKey HandleEmptyFillColorKey => _handleEmptyFillColorKey;

	public static Brush HandleFillHoverBrush => GetBrush(HandleFillHoverBrushKey);

	public static ResourceKey HandleFillHoverBrushKey => _handleFillHoverBrushKey;

	public static Color HandleFillHoverColor => GetColor(HandleFillHoverColorKey);

	public static ResourceKey HandleFillHoverColorKey => _handleFillHoverColorKey;

	public static Brush HandleFillPressedBrush => GetBrush(HandleFillPressedBrushKey);

	public static ResourceKey HandleFillPressedBrushKey => _handleFillPressedBrushKey;

	public static Color HandleFillPressedColor => GetColor(HandleFillPressedColorKey);

	public static ResourceKey HandleFillPressedColorKey => _handleFillPressedColorKey;

	public static Brush MoveHandleContentBrush => GetBrush(MoveHandleContentBrushKey);

	public static ResourceKey MoveHandleContentBrushKey => _moveHandleContentBrushKey;

	public static Color MoveHandleContentColor => GetColor(MoveHandleContentColorKey);

	public static ResourceKey MoveHandleContentColorKey => _moveHandleContentColorKey;

	public static Brush MoveHandleFillBrush => GetBrush(MoveHandleFillBrushKey);

	public static ResourceKey MoveHandleFillBrushKey => _moveHandleFillBrushKey;

	public static Color MoveHandleFillColor => GetColor(MoveHandleFillColorKey);

	public static ResourceKey MoveHandleFillColorKey => _moveHandleFillColorKey;

	public static Brush MoveHandleFillHoverBrush => GetBrush(MoveHandleFillHoverBrushKey);

	public static ResourceKey MoveHandleFillHoverBrushKey => _moveHandleFillHoverBrushKey;

	public static Color MoveHandleFillHoverColor => GetColor(MoveHandleFillHoverColorKey);

	public static ResourceKey MoveHandleFillHoverColorKey => _moveHandleFillHoverColorKey;

	public static Brush RailFillBrush => GetBrush(RailFillBrushKey);

	public static ResourceKey RailFillBrushKey => _railFillBrushKey;

	public static Color RailFillColor => GetColor(RailFillColorKey);

	public static ResourceKey RailFillColorKey => _railFillColorKey;

	public static Brush SelectionFrameBorderBrush => GetBrush(SelectionFrameBorderBrushKey);

	public static ResourceKey SelectionFrameBorderBrushKey => _selectionFrameBorderBrushKey;

	public static Color SelectionFrameBorderColor => GetColor(SelectionFrameBorderColorKey);

	public static ResourceKey SelectionFrameBorderColorKey => _selectionFrameBorderColorKey;

	public static Brush SelectionFrameFillBrush => GetBrush(SelectionFrameFillBrushKey);

	public static ResourceKey SelectionFrameFillBrushKey => _selectionFrameFillBrushKey;

	public static Color SelectionFrameFillColor => GetColor(SelectionFrameFillColorKey);

	public static ResourceKey SelectionFrameFillColorKey => _selectionFrameFillColorKey;

	public static Brush SimpleWashBrush => GetBrush(SimpleWashBrushKey);

	public static ResourceKey SimpleWashBrushKey => _simpleWashBrushKey;

	public static Color SimpleWashColor => GetColor(SimpleWashColorKey);

	public static ResourceKey SimpleWashColorKey => _simpleWashColorKey;

	public static Brush ToggledGlyphFillBrush => GetBrush(ToggledGlyphFillBrushKey);

	public static ResourceKey ToggledGlyphFillBrushKey => _toggledGlyphFillBrushKey;

	public static Color ToggledGlyphFillColor => GetColor(ToggledGlyphFillColorKey);

	public static ResourceKey ToggledGlyphFillColorKey => _toggledGlyphFillColorKey;

	static AdornerColors()
	{
		_alignmentMarkBrushKey = CreateKey("AlignmentMarkBrushKey");
		_alignmentMarkColorKey = CreateKey("AlignmentMarkColorKey");
		_elementBorderBrushKey = CreateKey("ElementBorderBrushKey");
		_elementBorderColorKey = CreateKey("ElementBorderColorKey");
		_glyphFillBrushKey = CreateKey("GlyphFillBrushKey");
		_glyphFillColorKey = CreateKey("GlyphFillColorKey");
		_handleBorderColorKey = CreateKey("HandleBorderColorKey");
		_handleBorderBrushKey = CreateKey("HandleBorderBrushKey");
		_handleFillColorKey = CreateKey("HandleFillColorKey");
		_handleFillBrushKey = CreateKey("HandleFillBrushKey");
		_handleFillHoverColorKey = CreateKey("HandleFillHoverColorKey");
		_handleEmptyFillColorKey = CreateKey("HandleEmptyFillColorKey");
		_handleEmptyFillBrushKey = CreateKey("HandleEmptyFillBrushKey");
		_handleFillHoverBrushKey = CreateKey("HandleFillHoverBrushKey");
		_handleFillPressedColorKey = CreateKey("HandleFillPressedColorKey");
		_handleFillPressedBrushKey = CreateKey("HandleFillPressedBrushKey");
		_moveHandleContentBrushKey = CreateKey("MoveHandleContentBrushKey");
		_moveHandleContentColorKey = CreateKey("MoveHandleContentColorKey");
		_moveHandleFillBrushKey = CreateKey("MoveHandleFillBrushKey");
		_moveHandleFillColorKey = CreateKey("MoveHandleFillColorKey");
		_moveHandleFillHoverBrushKey = CreateKey("MoveHandleFillHoverBrushKey");
		_moveHandleFillHoverColorKey = CreateKey("MoveHandleFillHoverColorKey");
		_railFillBrushKey = CreateKey("RailFillBrushKey");
		_railFillColorKey = CreateKey("RailFillColorKey");
		_selectionFrameBorderBrushKey = CreateKey("SelectionFrameBorderBrushKey");
		_selectionFrameBorderColorKey = CreateKey("SelectionFrameBorderColorKey");
		_selectionFrameFillBrushKey = CreateKey("SelectionFrameFillBrushKey");
		_selectionFrameFillColorKey = CreateKey("SelectionFrameFillColorKey");
		_simpleWashBrushKey = CreateKey("SimpleWashBrushKey");
		_simpleWashColorKey = CreateKey("SimpleWashColorKey");
		_toggledGlyphFillBrushKey = CreateKey("ToggledGlyphFillBrushKey");
		_toggledGlyphFillColorKey = CreateKey("ToggledGlyphFillColorKey");
		AdornerResources.RegisterResources(() => (ResourceDictionary)(object)new AdornerColorResourceDictionary());
	}

	private static ResourceKey CreateKey(string name)
	{
		return AdornerResources.CreateResourceKey(typeof(AdornerColors), name);
	}

	private static Brush GetBrush(ResourceKey key)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return (Brush)AdornerResources.FindResource(key);
	}

	private static Color GetColor(ResourceKey key)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (Color)AdornerResources.FindResource(key);
	}
}
