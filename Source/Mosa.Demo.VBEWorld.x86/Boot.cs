﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Kernel.x86;
using Mosa.Runtime.x86;
using Mosa.Demo.VBEWorld.x86.HAL;

namespace Mosa.Demo.VBEWorld.x86
{
	/// <summary>
	/// Boot
	/// </summary>
	public static class Boot
	{
		public static ConsoleSession Console;

		private static Hardware _hal;

		/// <summary>
		/// Main
		/// </summary>
		public static void Main()
		{
			Kernel.x86.Kernel.Setup();

			Console = ConsoleManager.Controller.Boot;
			Console.Clear();

			IDT.SetInterruptHandler(ProcessInterrupt);

			Serial.SetupPort(Serial.COM1);

			_hal = new Hardware();
			if (VBEDisplay.InitVBE(_hal))
			{
				Log("VBE setup OK!");

				DoGraphics();
			}
			else
			{
				Log("VBE setup ERROR!");
			}

			ForeverLoop();
		}

		private static void DoGraphics()
		{
			VBEDisplay.Framebuffer.FillRectangle(0x00555555, 0, 0, VBEDisplay.Framebuffer.Width, VBEDisplay.Framebuffer.Height);

			MosaLogo.Draw(VBEDisplay.Framebuffer, 10);
		}

		public static void Log(string line)
		{
			Serial.Write(Serial.COM1, line + "\r\n");
			Console.WriteLine(line);
		}

		private static void ForeverLoop()
		{
			while (true)
			{
				Native.Hlt();
			}
		}

		public static void ProcessInterrupt(uint interrupt, uint errorCode)
		{
		}
	}
}
