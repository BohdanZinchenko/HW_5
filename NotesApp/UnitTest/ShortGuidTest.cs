using NotesApp.Tools;
using Xunit;
using System;

namespace UnitTest
{
    public class ShortGuidTest
    {
        [Fact]
        public void ShortGuid_Correct_GuidToShort_FromShort_To_Guid()
        {
            var guid  = Guid.NewGuid();
            var shortGuid = guid.ToShortId();
            var lastGuid = shortGuid.FromShortId();
            Assert.Equal(guid.ToString(),lastGuid.ToString());
        }
        [Fact]
        public void ShortGuid_FromShortId_Correct_ToGuid_If_Add_Some_Chars()
        {
            var guid = Guid.NewGuid();
            var shortGuid = guid.ToShortId()+"==";
            var lastGuid = shortGuid.FromShortId();
            Assert.Equal(guid.ToString(), lastGuid.ToString());
        }

        [Fact]
        public void ShortGuid_FromShortId_Correct_Convert_From_StringGuid_to_Guid()
        {
            var guid = Guid.NewGuid();
            var stringGuid = guid.ToString().FromShortId();
            Assert.Equal(guid.ToString(),stringGuid.ToString());

        }

        [Fact]
        public void ShortGuid_FromShortId_Failed_If_Argument_Is_Not_Valid_Short_Guid()
        {
            var guid = Guid.NewGuid();
            var shortGuid = guid.ToShortId();
            var InvalidShortGuid = shortGuid + "11f";
            Assert.Throws<FormatException>(() => InvalidShortGuid.FromShortId());
        }
        [Fact]
        public void ShortGuid_FromShortId_Return_Null_If_Argument_Is_Null()
        {
            
            var nullGuid = ShortGuid.FromShortId(null);
            Assert.Null(nullGuid);
        }

    }
}