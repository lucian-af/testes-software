﻿using System;
using System.Linq;

namespace NerdStore.BDD.Tests.Config
{
	public static class TestsExtensions
	{
		public static int ApenasNumeros(this string value)
			=> Convert.ToInt16(new string(value.Where(char.IsDigit).ToArray()));
	}
}
