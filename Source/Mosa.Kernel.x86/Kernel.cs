﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Kernel.x86.Smbios;
using Mosa.Runtime;

namespace Mosa.Kernel.x86
{
	/// <summary>
	/// X86 Kernel
	/// </summary>
	public static class Kernel
	{
		public static void Setup()
		{
			// Initialize GDT before IDT, because IDT Entries requires a valid Segment Selector
			Multiboot.Setup();
			GDT.Setup();

			// At this stage, allocating memory does not work, so you are only allowed to use ValueTypes or static classes.
			IDT.SetInterruptHandler(null);
			Panic.Setup();

			// Initialize interrupts
			PIC.Setup();
			IDT.Setup();

			// Initializing the memory management
			PageFrameAllocator.Setup();
			PageTable.Setup();
			VirtualPageAllocator.Setup();
			GC.Setup();

			// At this point we can use objects
			Scheduler.Setup();
			SmbiosManager.Setup();
			ConsoleManager.Setup();

			Logger.Log("Kernel initialized");
		}
	}
}
