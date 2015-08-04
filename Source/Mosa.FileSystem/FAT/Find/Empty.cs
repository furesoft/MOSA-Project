// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.ClassLib;

namespace Mosa.FileSystem.FAT.Find
{
	/// <summary>
	///
	/// </summary>
	public class Empty : FatFileSystem.ICompare
	{
		/// <summary>
		///
		/// </summary>
		protected uint cluster;

		/// <summary>
		///
		/// </summary>
		public Empty()
		{
		}

		/// <summary>
		/// Compares the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public bool Compare(byte[] data, uint offset, FatType type)
		{
			BinaryFormat entry = new BinaryFormat(data);

			byte first = entry.GetByte(offset + Entry.DOSName);

			if (first == FileNameAttribute.LastEntry)
				return true;

			if ((first == FileNameAttribute.Deleted) | (first == FileNameAttribute.Dot))
				return true;

			return false;
		}
	}
}
