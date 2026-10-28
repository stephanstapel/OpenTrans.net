using System;
using System.IO;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Read-only, forward-only stream, e.g. like a network stream
    /// </summary>
    internal class NonSeekableStream : Stream
    {
        private readonly Stream _Inner;


        internal NonSeekableStream(byte[] data)
        {
            _Inner = new MemoryStream(data);
        }


        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count) => _Inner.Read(buffer, offset, count);
        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    }
}
