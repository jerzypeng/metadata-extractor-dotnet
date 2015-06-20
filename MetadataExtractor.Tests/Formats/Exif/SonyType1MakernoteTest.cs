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

using MetadataExtractor.Formats.Exif.Makernotes;
using Xunit;

namespace MetadataExtractor.Tests.Formats.Exif
{
    /// <author>Drew Noakes https://drewnoakes.com</author>
    public sealed class SonyType1MakernoteTest
    {

        [Fact]
        public void TestSonyType1Makernote()
        {
            var directory = ExifReaderTest.ProcessSegmentBytes<SonyType1MakernoteDirectory>("Tests/Data/sonyType1.jpg.app1");
            Assert.NotNull(directory);
            Assert.False(directory.HasError);
            var descriptor = new SonyType1MakernoteDescriptor(directory);
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagColorTemperature));
            Assert.Null(descriptor.GetColorTemperatureDescription());
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagSceneMode));
            Assert.Null(descriptor.GetSceneModeDescription());
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagZoneMatching));
            Assert.Null(descriptor.GetZoneMatchingDescription());
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagDynamicRangeOptimiser));
            Assert.Null(descriptor.GetDynamicRangeOptimizerDescription());
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagImageStabilisation));
            Assert.Null(descriptor.GetImageStabilizationDescription());
            Assert.Null(directory.GetObject(SonyType1MakernoteDirectory.TagColorMode));
            Assert.Null(descriptor.GetColorModeDescription());
            Assert.Equal("On (Shooting)", descriptor.GetAntiBlurDescription());
            Assert.Equal("Program", descriptor.GetExposureModeDescription());
            Assert.Equal("Off", descriptor.GetLongExposureNoiseReductionDescription());
            Assert.Equal("Off", descriptor.GetMacroDescription());
            Assert.Equal("Normal", descriptor.GetJpegQualityDescription());
        }
    }
}
