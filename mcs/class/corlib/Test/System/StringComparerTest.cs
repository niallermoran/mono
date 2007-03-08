//
// MonoTests.System.StringComparerTest
//
// Authors:
//      Gert Driesen (drieseng@users.sourceforge.net)
//
// Copyright (C) 2007 Gert Driesen
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0

using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using NUnit.Framework;

namespace MonoTests.System
{
	[TestFixture]
	public class StringComparerTest
	{
		[Test]
		public void Serialize_CurrentCulture ()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.CurrentCulture);

			// Assert.AreEqual (_serializedCurrentCulture, buffer);
		}

		[Test]
		public void Deserialize_CurrentCulture ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedCurrentCulture, 0, _serializedCurrentCulture.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		[Test]
		public void Serialize_CurrentCultureIgnoreCase ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.CurrentCultureIgnoreCase);

			// Assert.AreEqual (_serializedCurrentCultureIgnoreCase, buffer);
		}

		[Test]
		public void Deserialize_CurrentCultureIgnoreCase ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedCurrentCultureIgnoreCase, 0, _serializedCurrentCultureIgnoreCase.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		[Test]
		public void Serialize_InvariantCulture ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.InvariantCulture);

			byte [] buffer = new byte [ms.Length];
			ms.Position = 0;
			ms.Read (buffer, 0, buffer.Length);

			// Assert.AreEqual (_serializedInvariantCulture, buffer);
		}

		[Test]
		public void Deserialize_InvariantCulture ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedInvariantCulture, 0, _serializedInvariantCulture.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		[Test]
		public void Serialize_InvariantCultureIgnoreCase ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.InvariantCultureIgnoreCase);

			byte [] buffer = new byte [ms.Length];
			ms.Position = 0;
			ms.Read (buffer, 0, buffer.Length);

			// Assert.AreEqual (_serializedInvariantCultureIgnoreCase, buffer);
		}

		[Test]
		public void Deserialize_InvariantCultureIgnoreCase ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedInvariantCultureIgnoreCase, 0, _serializedInvariantCultureIgnoreCase.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		[Test]
		public void Serialize_Ordinal ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.Ordinal);

			byte [] buffer = new byte [ms.Length];
			ms.Position = 0;
			ms.Read (buffer, 0, buffer.Length);

			Assert.AreEqual (_serializedOrdinal, buffer);
		}

		[Test]
		public void Deserialize_Ordinal ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedOrdinal, 0, _serializedOrdinal.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		[Test]
		public void Serialize_OrdinalIgnoreCase ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, StringComparer.OrdinalIgnoreCase);

			byte [] buffer = new byte [ms.Length];
			ms.Position = 0;
			ms.Read (buffer, 0, buffer.Length);

			Assert.AreEqual (_serializedOrdinalIgnoreCase, buffer);
		}

		[Test]
		public void Deserialize_OrdinalIgnoreCase ()
		{
			MemoryStream ms = new MemoryStream ();
			ms.Write (_serializedOrdinalIgnoreCase, 0, _serializedOrdinalIgnoreCase.Length);
			ms.Position = 0;

			BinaryFormatter bf = new BinaryFormatter ();
			StringComparer sc = (StringComparer) bf.Deserialize (ms);
			Assert.IsNotNull (sc);
		}

		private static readonly byte [] _serializedCurrentCulture = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x1b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x43, 0x75, 0x6c,
			0x74, 0x75, 0x72, 0x65, 0x41, 0x77, 0x61, 0x72, 0x65, 0x43, 0x6f,
			0x6d, 0x70, 0x61, 0x72, 0x65, 0x72, 0x02, 0x00, 0x00, 0x00, 0x0c,
			0x5f, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65, 0x49, 0x6e, 0x66,
			0x6f, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f, 0x72, 0x65, 0x43, 0x61,
			0x73, 0x65, 0x03, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d,
			0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61, 0x74,
			0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x49, 0x6e, 0x66, 0x6f, 0x01, 0x09, 0x02, 0x00, 0x00, 0x00, 0x00,
			0x04, 0x02, 0x00, 0x00, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65,
			0x6d, 0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61,
			0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72,
			0x65, 0x49, 0x6e, 0x66, 0x6f, 0x03, 0x00, 0x00, 0x00, 0x09, 0x77,
			0x69, 0x6e, 0x33, 0x32, 0x4c, 0x43, 0x49, 0x44, 0x07, 0x63, 0x75,
			0x6c, 0x74, 0x75, 0x72, 0x65, 0x06, 0x6d, 0x5f, 0x6e, 0x61, 0x6d,
			0x65, 0x00, 0x00, 0x01, 0x08, 0x08, 0x13, 0x08, 0x00, 0x00, 0x13,
			0x08, 0x00, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x05, 0x6e, 0x6c,
			0x2d, 0x42, 0x45, 0x0b };

		private static readonly byte [] _serializedCurrentCultureIgnoreCase = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x1b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x43, 0x75, 0x6c,
			0x74, 0x75, 0x72, 0x65, 0x41, 0x77, 0x61, 0x72, 0x65, 0x43, 0x6f,
			0x6d, 0x70, 0x61, 0x72, 0x65, 0x72, 0x02, 0x00, 0x00, 0x00, 0x0c,
			0x5f, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65, 0x49, 0x6e, 0x66,
			0x6f, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f, 0x72, 0x65, 0x43, 0x61,
			0x73, 0x65, 0x03, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d,
			0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61, 0x74,
			0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x49, 0x6e, 0x66, 0x6f, 0x01, 0x09, 0x02, 0x00, 0x00, 0x00, 0x01,
			0x04, 0x02, 0x00, 0x00, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65,
			0x6d, 0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61,
			0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72,
			0x65, 0x49, 0x6e, 0x66, 0x6f, 0x03, 0x00, 0x00, 0x00, 0x09, 0x77,
			0x69, 0x6e, 0x33, 0x32, 0x4c, 0x43, 0x49, 0x44, 0x07, 0x63, 0x75,
			0x6c, 0x74, 0x75, 0x72, 0x65, 0x06, 0x6d, 0x5f, 0x6e, 0x61, 0x6d,
			0x65, 0x00, 0x00, 0x01, 0x08, 0x08, 0x13, 0x08, 0x00, 0x00, 0x13,
			0x08, 0x00, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x05, 0x6e, 0x6c,
			0x2d, 0x42, 0x45, 0x0b };


		private static readonly byte [] _serializedInvariantCulture = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x1b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x43, 0x75, 0x6c,
			0x74, 0x75, 0x72, 0x65, 0x41, 0x77, 0x61, 0x72, 0x65, 0x43, 0x6f,
			0x6d, 0x70, 0x61, 0x72, 0x65, 0x72, 0x02, 0x00, 0x00, 0x00, 0x0c,
			0x5f, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65, 0x49, 0x6e, 0x66,
			0x6f, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f, 0x72, 0x65, 0x43, 0x61,
			0x73, 0x65, 0x03, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d,
			0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61, 0x74,
			0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x49, 0x6e, 0x66, 0x6f, 0x01, 0x09, 0x02, 0x00, 0x00, 0x00, 0x00,
			0x04, 0x02, 0x00, 0x00, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65,
			0x6d, 0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61,
			0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72,
			0x65, 0x49, 0x6e, 0x66, 0x6f, 0x03, 0x00, 0x00, 0x00, 0x09, 0x77,
			0x69, 0x6e, 0x33, 0x32, 0x4c, 0x43, 0x49, 0x44, 0x07, 0x63, 0x75,
			0x6c, 0x74, 0x75, 0x72, 0x65, 0x06, 0x6d, 0x5f, 0x6e, 0x61, 0x6d,
			0x65, 0x00, 0x00, 0x01, 0x08, 0x08, 0x7f, 0x00, 0x00, 0x00, 0x7f,
			0x00, 0x00, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x00, 0x0b };

		private static readonly byte [] _serializedInvariantCultureIgnoreCase = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x1b, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x43, 0x75, 0x6c,
			0x74, 0x75, 0x72, 0x65, 0x41, 0x77, 0x61, 0x72, 0x65, 0x43, 0x6f,
			0x6d, 0x70, 0x61, 0x72, 0x65, 0x72, 0x02, 0x00, 0x00, 0x00, 0x0c,
			0x5f, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65, 0x49, 0x6e, 0x66,
			0x6f, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f, 0x72, 0x65, 0x43, 0x61,
			0x73, 0x65, 0x03, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d,
			0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61, 0x74,
			0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x49, 0x6e, 0x66, 0x6f, 0x01, 0x09, 0x02, 0x00, 0x00, 0x00, 0x01,
			0x04, 0x02, 0x00, 0x00, 0x00, 0x20, 0x53, 0x79, 0x73, 0x74, 0x65,
			0x6d, 0x2e, 0x47, 0x6c, 0x6f, 0x62, 0x61, 0x6c, 0x69, 0x7a, 0x61,
			0x74, 0x69, 0x6f, 0x6e, 0x2e, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72,
			0x65, 0x49, 0x6e, 0x66, 0x6f, 0x03, 0x00, 0x00, 0x00, 0x09, 0x77,
			0x69, 0x6e, 0x33, 0x32, 0x4c, 0x43, 0x49, 0x44, 0x07, 0x63, 0x75,
			0x6c, 0x74, 0x75, 0x72, 0x65, 0x06, 0x6d, 0x5f, 0x6e, 0x61, 0x6d,
			0x65, 0x00, 0x00, 0x01, 0x08, 0x08, 0x7f, 0x00, 0x00, 0x00, 0x7f,
			0x00, 0x00, 0x00, 0x06, 0x03, 0x00, 0x00, 0x00, 0x00, 0x0b };

		private static readonly byte [] _serializedOrdinal = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x16, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x4f, 0x72, 0x64,
			0x69, 0x6e, 0x61, 0x6c, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x72, 0x01, 0x00, 0x00, 0x00, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f,
			0x72, 0x65, 0x43, 0x61, 0x73, 0x65, 0x00, 0x01, 0x00, 0x0b };

		private static readonly byte [] _serializedOrdinalIgnoreCase = new byte [] {
			0x00, 0x01, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff, 0x01, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00,
			0x16, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6d, 0x2e, 0x4f, 0x72, 0x64,
			0x69, 0x6e, 0x61, 0x6c, 0x43, 0x6f, 0x6d, 0x70, 0x61, 0x72, 0x65,
			0x72, 0x01, 0x00, 0x00, 0x00, 0x0b, 0x5f, 0x69, 0x67, 0x6e, 0x6f,
			0x72, 0x65, 0x43, 0x61, 0x73, 0x65, 0x00, 0x01, 0x01, 0x0b };
	}
}

#endif
