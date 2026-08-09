namespace ExCSS;

internal sealed class OpacityProperty : Property
{
	private static readonly IValueConverter StyleConverter = Converters.NumberConverter.OrDefault(1f);

	internal override IValueConverter Converter => StyleConverter;

	internal OpacityProperty()
		: base(PropertyNames.Opacity, PropertyFlags.Animatable)
	{
	}
}
