﻿using System;
using Eto.Forms;

namespace UpemClient.Gtk
{
	class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			new Application(Eto.Platforms.Gtk).Run(new MainForm());
		}
	}
}
