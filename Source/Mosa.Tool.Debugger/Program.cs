﻿/*
 * (c) 2012 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Mosa.Utility.DebugEngine;

namespace Mosa.Tool.Debugger
{
	static class Program
	{
		private static DebugServerEngine debugEngine = new DebugServerEngine();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Thread t = new Thread(new ThreadStart(debugEngine.ThreadStart));
			t.IsBackground = true;
			t.Start();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(debugEngine));
		}

		/// <summary>
		/// Creates the form.
		/// </summary>
		private static void CreateMemoryForm()
		{
			Application.Run(new MemoryForm(debugEngine));
		}

	}
}
