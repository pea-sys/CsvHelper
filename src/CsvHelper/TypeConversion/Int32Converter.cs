﻿// Copyright 2009-2022 Josh Close
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion
{
	/// <summary>
	/// Converts an <see cref="int"/> to and from a <see cref="string"/>.
	/// </summary>
	public class Int32Converter : DefaultTypeConverter
	{
		/// <summary>
		/// Converts the string to an object.
		/// </summary>
		/// <param name="text">The string to convert to an object.</param>
		/// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
		/// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
		/// <returns>The object created from the string.</returns>
		public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
		{
			var numberStyle = memberMapData.TypeConverterOptions.NumberStyles ?? NumberStyles.Integer;

			if (int.TryParse(text, numberStyle, memberMapData.TypeConverterOptions.CultureInfo, out var i))
			{
				return i;
			}

			return base.ConvertFromString(text, row, memberMapData);
		}
	}
}
