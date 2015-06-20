/*
 * Copyright 2002-2015 Drew Noakes
 *
 *    Modified by Yakov Danilov <yakodani@gmail.com> for Imazen LLC (Ported from Java to C#)
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * More information about this project is available at:
 *
 *    https://drewnoakes.com/code/exif/
 *    https://github.com/drewnoakes/metadata-extractor
 */

using MetadataExtractor.Formats.Jpeg;
using Xunit;

namespace MetadataExtractor.Tests.Formats.Jpeg
{
    /// <author>Drew Noakes https://drewnoakes.com</author>
    public sealed class JpegDirectoryTest
    {
        private readonly JpegDirectory _directory;

        public JpegDirectoryTest()
        {
            _directory = new JpegDirectory();
        }

        [Fact]
        public void TestSetAndGetValue()
        {
            _directory.Set(123, 8);
            Assert.Equal(8, _directory.GetInt32(123));
        }

        [Fact]
        public void TestGetComponent_NotAdded()
        {
            Assert.Null(_directory.GetComponent(1));
        }

        // NOTE tests for individual tag values exist in JpegReaderTest.java

        [Fact]
        public void TestGetImageWidth()
        {
            _directory.Set(JpegDirectory.TagImageWidth, 123);
            Assert.Equal(123, _directory.GetImageWidth());
        }


        [Fact]
        public void TestGetImageHeight()
        {
            _directory.Set(JpegDirectory.TagImageHeight, 123);
            Assert.Equal(123, _directory.GetImageHeight());
        }


        [Fact]
        public void TestGetNumberOfComponents()
        {
            _directory.Set(JpegDirectory.TagNumberOfComponents, 3);
            Assert.Equal(3, _directory.GetNumberOfComponents());
            Assert.Equal("3", _directory.GetDescription(JpegDirectory.TagNumberOfComponents));
        }


        [Fact]
        public void TestGetComponent()
        {
            var component1 = new JpegComponent(1, 2, 3);
            var component2 = new JpegComponent(1, 2, 3);
            var component3 = new JpegComponent(1, 2, 3);
            var component4 = new JpegComponent(1, 2, 3);
            _directory.Set(JpegDirectory.TagComponentData1, component1);
            _directory.Set(JpegDirectory.TagComponentData2, component2);
            _directory.Set(JpegDirectory.TagComponentData3, component3);
            _directory.Set(JpegDirectory.TagComponentData4, component4);
            // component numbers are zero-indexed for this method
            Assert.Same(component1, _directory.GetComponent(0));
            Assert.Same(component2, _directory.GetComponent(1));
            Assert.Same(component3, _directory.GetComponent(2));
            Assert.Same(component4, _directory.GetComponent(3));
        }
    }
}
