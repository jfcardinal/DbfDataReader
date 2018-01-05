using System;
using System.IO;

namespace DbfDataReader
{
    public static class BinaryReaderExtensions
    {
        private const char NullChar = '\0';

        public static short ReadBigEndianInt16(this BinaryReader binaryReader)
        {
            var bytes = binaryReader.ReadBytes(2);
            return (short)((bytes[0] << 8) | bytes[1]);
        }

        public static ushort ReadBigEndianUInt16(this BinaryReader binaryReader)
        {
            var bytes = binaryReader.ReadBytes(2);
            return (ushort)((bytes[0] << 8) | bytes[1]);
        }

        public static int ReadBigEndianInt32(this BinaryReader binaryReader)
        {
            var bytes = binaryReader.ReadBytes(4);
            return (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
        }

        public static uint ReadBigEndianUInt32(this BinaryReader binaryReader)
        {
            var bytes = binaryReader.ReadBytes(4);
            return (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
        }

        public static string ReadString(this BinaryReader binaryReader, int fieldLength)
        {
            var chars = binaryReader.ReadChars(fieldLength);
            return chars[0] == NullChar
                ? string.Empty 
                : new string (chars, 0, fieldLength);
        }
    }
}
