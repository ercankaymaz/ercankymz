using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class IndexTriangleConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo info, object value)
	{
		if (value is string)
		{
			try
			{
				string[] array = ((string)value).Split(',');
				return (_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)byte.Parse(array[0]) switch
				{
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)5 => new ColorSmoothTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]), int.Parse(array[5]), int.Parse(array[6]), byte.Parse(array[7]), byte.Parse(array[8]), byte.Parse(array[9])), 
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)6 => new RichSmoothTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]), int.Parse(array[5]), int.Parse(array[6]), int.Parse(array[7]), int.Parse(array[8]), int.Parse(array[9])), 
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)4 => new SmoothTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]), int.Parse(array[5]), int.Parse(array[6])), 
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)3 => new RichTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]), int.Parse(array[5]), int.Parse(array[6])), 
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)2 => new ColorTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), byte.Parse(array[4]), byte.Parse(array[5]), byte.Parse(array[6])), 
					(_0023_003Dzs0LyyZfsQVbjSshrDDRktenbQ_j_0024)1 => new IndexTriangle(int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3])), 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			catch
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657873));
			}
		}
		return base.ConvertFrom(context, info, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is IndexTriangle)
		{
			if (destinationType == typeof(string))
			{
				if (value is ColorSmoothTriangle)
				{
					ColorSmoothTriangle colorSmoothTriangle = (ColorSmoothTriangle)value;
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657846), (byte)5, colorSmoothTriangle.V1, colorSmoothTriangle.V2, colorSmoothTriangle.V3, colorSmoothTriangle.N1, colorSmoothTriangle.N2, colorSmoothTriangle.N3, colorSmoothTriangle.R, colorSmoothTriangle.G, colorSmoothTriangle.B);
				}
				if (value is RichSmoothTriangle)
				{
					RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)value;
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657846), (byte)6, richSmoothTriangle.V1, richSmoothTriangle.V2, richSmoothTriangle.V3, richSmoothTriangle.N1, richSmoothTriangle.N2, richSmoothTriangle.N3, richSmoothTriangle.T1, richSmoothTriangle.T2, richSmoothTriangle.T3);
				}
				if (value is SmoothTriangle)
				{
					SmoothTriangle smoothTriangle = (SmoothTriangle)value;
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657803), (byte)4, smoothTriangle.V1, smoothTriangle.V2, smoothTriangle.V3, smoothTriangle.N1, smoothTriangle.N2, smoothTriangle.N3);
				}
				if (value is RichTriangle)
				{
					RichTriangle richTriangle = (RichTriangle)value;
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657803), (byte)3, richTriangle.V1, richTriangle.V2, richTriangle.V3, richTriangle.T1, richTriangle.T2, richTriangle.T3);
				}
				if (value is ColorTriangle)
				{
					ColorTriangle colorTriangle = (ColorTriangle)value;
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657803), (byte)3, colorTriangle.V1, colorTriangle.V2, colorTriangle.V3, colorTriangle.R, colorTriangle.G, colorTriangle.B);
				}
				IndexTriangle indexTriangle = (IndexTriangle)value;
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988079), (byte)1, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is ColorSmoothTriangle)
				{
					ColorSmoothTriangle colorSmoothTriangle2 = (ColorSmoothTriangle)value;
					object[] array = new object[9];
					Type[] array2 = new Type[9];
					array2[0] = (array2[1] = (array2[2] = typeof(int)));
					array[0] = colorSmoothTriangle2.V1;
					array[1] = colorSmoothTriangle2.V2;
					array[2] = colorSmoothTriangle2.V3;
					array2[3] = (array2[4] = (array2[5] = typeof(int)));
					array[3] = colorSmoothTriangle2.N1;
					array[4] = colorSmoothTriangle2.N2;
					array[5] = colorSmoothTriangle2.N3;
					array2[6] = (array2[7] = (array2[8] = typeof(byte)));
					array[6] = colorSmoothTriangle2.R;
					array[7] = colorSmoothTriangle2.G;
					array[8] = colorSmoothTriangle2.B;
					return new InstanceDescriptor(typeof(ColorSmoothTriangle).GetConstructor(array2), array);
				}
				if (value is RichSmoothTriangle)
				{
					RichSmoothTriangle richSmoothTriangle2 = (RichSmoothTriangle)value;
					object[] array3 = new object[9];
					Type[] array4 = new Type[9];
					array4[0] = (array4[1] = (array4[2] = typeof(int)));
					array3[0] = richSmoothTriangle2.V1;
					array3[1] = richSmoothTriangle2.V2;
					array3[2] = richSmoothTriangle2.V3;
					array4[3] = (array4[4] = (array4[5] = typeof(int)));
					array3[3] = richSmoothTriangle2.N1;
					array3[4] = richSmoothTriangle2.N2;
					array3[5] = richSmoothTriangle2.N3;
					array4[6] = (array4[7] = (array4[8] = typeof(int)));
					array3[6] = richSmoothTriangle2.T1;
					array3[7] = richSmoothTriangle2.T2;
					array3[8] = richSmoothTriangle2.T3;
					return new InstanceDescriptor(typeof(RichSmoothTriangle).GetConstructor(array4), array3);
				}
				if (value is SmoothTriangle)
				{
					SmoothTriangle smoothTriangle2 = (SmoothTriangle)value;
					object[] array5 = new object[6];
					Type[] array6 = new Type[6];
					array6[0] = (array6[1] = (array6[2] = typeof(int)));
					array5[0] = smoothTriangle2.V1;
					array5[1] = smoothTriangle2.V2;
					array5[2] = smoothTriangle2.V3;
					array6[3] = (array6[4] = (array6[5] = typeof(int)));
					array5[3] = smoothTriangle2.N1;
					array5[4] = smoothTriangle2.N2;
					array5[5] = smoothTriangle2.N3;
					return new InstanceDescriptor(typeof(SmoothTriangle).GetConstructor(array6), array5);
				}
				if (value is RichTriangle)
				{
					RichTriangle richTriangle2 = (RichTriangle)value;
					object[] array7 = new object[6];
					Type[] array8 = new Type[6];
					array8[0] = (array8[1] = (array8[2] = typeof(int)));
					array7[0] = richTriangle2.V1;
					array7[1] = richTriangle2.V2;
					array7[2] = richTriangle2.V3;
					array8[3] = (array8[4] = (array8[5] = typeof(int)));
					array7[3] = richTriangle2.T1;
					array7[4] = richTriangle2.T2;
					array7[5] = richTriangle2.T3;
					return new InstanceDescriptor(typeof(RichTriangle).GetConstructor(array8), array7);
				}
				if (value is ColorTriangle)
				{
					ColorTriangle colorTriangle2 = (ColorTriangle)value;
					object[] array9 = new object[6];
					Type[] array10 = new Type[6];
					array10[0] = (array10[1] = (array10[2] = typeof(int)));
					array9[0] = colorTriangle2.V1;
					array9[1] = colorTriangle2.V2;
					array9[2] = colorTriangle2.V3;
					array10[3] = (array10[4] = (array10[5] = typeof(byte)));
					array9[3] = colorTriangle2.R;
					array9[4] = colorTriangle2.G;
					array9[5] = colorTriangle2.B;
					return new InstanceDescriptor(typeof(ColorTriangle).GetConstructor(array10), array9);
				}
				IndexTriangle indexTriangle2 = (IndexTriangle)value;
				object[] array11 = new object[3];
				Type[] array12 = new Type[3];
				array12[0] = (array12[1] = (array12[2] = typeof(int)));
				array11[0] = indexTriangle2.V1;
				array11[1] = indexTriangle2.V2;
				array11[2] = indexTriangle2.V3;
				return new InstanceDescriptor(typeof(IndexTriangle).GetConstructor(array12), array11);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
