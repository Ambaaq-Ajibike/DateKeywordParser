using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateKeywordParser
{
	public static class DateKeywordParser
	{
		/// <summary>
		/// Parses a file name template and replaces date-related keywords with actual date values.
		/// </summary>
		/// <param name="template">The file name template containing date keywords.</param>
		/// <param name="culture">Optional culture info for date formatting.</param>
		/// <returns>Resolved file name.</returns>
		public static string Parse(string template, CultureInfo? culture = null)
		{
			culture ??= CultureInfo.InvariantCulture;
			DateTime now = DateTime.Now;

			// Match date keywords like NOW, YESTERDAY, NOW-1d, etc.
			template = Regex.Replace(template, @"NOW(?:([+-]\d+)([smhd]))?", match =>
			{
				string offset = match.Groups[1].Value;
				string unit = match.Groups[2].Value;

				DateTime adjustedDate = now;

				if (!string.IsNullOrEmpty(offset) && !string.IsNullOrEmpty(unit))
				{
					int value = int.Parse(offset);
					adjustedDate = unit switch
					{
						"s" => adjustedDate.AddSeconds(value),
						"m" => adjustedDate.AddMinutes(value),
						"h" => adjustedDate.AddHours(value),
						"d" => adjustedDate.AddDays(value),
						_ => adjustedDate
					};
				}

				return adjustedDate.ToString("yyyy-MM-dd_HH-mm-ss", culture);
			});

			// Handle YESTERDAY keyword
			template = template.Replace("YESTERDAY", now.AddDays(-1).ToString("yyyy-MM-dd", culture));

			// Match Format(NOW, "yyyy-MM-dd")
			template = Regex.Replace(template, @"Format\(NOW, ""(.*?)""\)", match =>
			{
				string format = match.Groups[1].Value;
				return now.ToString(format, culture);
			});

			return template;
		}
	}
}
