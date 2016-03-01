// Copyright (c) kuicker.org. All rights reserved.
// Modified By      YYYY-MM-DD
// kevinjong        2016-02-11 - Creation

using System;
using System.Drawing;
using Xunit;

namespace IsTo.Tests
{
	public class ToOfGenericToColor
	{
		[Fact]
		public void BySelf()
		{
			var value = Color.Azure;
			Assert.True(value.To<Color>() == value);
		}


		[Theory]
		[InlineData("rgba(0, 100, 255, 1)", 255, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, 100%)", 255, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, 35%)", 89, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, 0.35)", 89, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, 0.0)", 0, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, 1.0)", 255, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, .0)", 0, 0, 100, 255)]
		[InlineData("rgba(0, 100, 255, .35)", 89, 0, 100, 255)]
		public void ByRGBStringToColor(
			string value,
			int a,
			int r,
			int g,
			int b)
		{
			var result = value.To<Color>();
			var expect = Color.FromArgb(a, r, g, b);
			Assert.True(ColorComaparison(
				result,
				expect
			));
		}

		[Theory]
		[InlineData("rgb(0, 100, 256)")]
		[InlineData("rgba(0, 100, 255, -35%)")]
		[InlineData("rgba(0, -100, 255)")]
		[InlineData("rgba(0, 100, 255, 200%)")]
		[InlineData("rgba(0, 100, 255, 2.0)")]
		[InlineData("rgba(0, 100, 255, 2)")]
		[InlineData("#KKKKKK")]
		[InlineData("#KKK")]
		public void ByStringToColor_False(object value)
		{
			var color = default(Color);
			var result = value.To<Color>();
			Assert.True(ColorComaparison(
				result,
				color
			));
		}

		[Theory]
		[InlineData("#FFFFFF", "#FFFFFF")]
		[InlineData("#FFF", "#FFFFFF")]
		[InlineData("#123", "#112233")]
		public void ByHtmlStringToColor(string value, string expect)
		{
			Assert.True(ColorComaparison(
				value.To<Color>(),
				ColorTranslator.FromHtml(expect)
			));
		}

		[Fact]
		public void ByIntegerToColor()
		{
			var color1 = Color.Cyan;
			var color2 = color1.ToArgb().To<Color>();

			Assert.True(ColorComaparison(
				0.To<Color>(),
				Color.FromArgb(0)
			));
			Assert.True(ColorComaparison(
				100.To<Color>(),
				Color.FromArgb(100)
			));
			Assert.True(ColorComaparison(
				color1,
				color2
			));
		}

		private bool ColorComaparison(Color color1, Color color2)
		{
			return
				color1.A == color2.A
				&&
				color1.R == color2.R
				&&
				color1.G == color2.G
				&&
				color1.B == color2.B
			;
		}


		[Fact]
		public void ByColorToColor()
		{
			var c = Color.FromArgb(123, 2, 77);
			Assert.True(ColorComaparison(c.To<Color>(), c));
		}


		[Fact]
		public void FromDateTime()
		{
			var value = DateTime.Now;
			Color flag;
			Assert.False(value.TryTo<Color>(out flag));
		}
	}
}
