namespace SharpOutcome.UnitTests.Options
{
    public class OptionTests
    {
        [Fact]
        public void CreateSome_ClassInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyClass(10);

            // Act
            var option = Option<DummyClass>.CreateSome(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyClass>>(option);
            Assert.NotNull(option.Value);
        }

        [Fact]
        public void CreateSome_StructInstance_SomeInstance()
        {
            // Arrange
            int value = 10;

            // Act
            var option = Option<int>.CreateSome(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<int>>(option);
        }

        [Fact]
        public void CreateSome_RecordInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyRecord(10);

            // Act
            var option = Option<DummyRecord>.CreateSome(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyRecord>>(option);
            Assert.NotNull(option.Value);
        }

        [Fact]
        public void CreateSome_RecordStructInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyRecordStruct(10);

            // Act
            var option = Option<DummyRecordStruct>.CreateSome(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyRecordStruct>>(option);
        }

        [Fact]
        public void CreateNone_Class_NoneInstance()
        {
            // Act
            var option = Option<DummyClass>.CreateNone();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyClass>>(option);
        }

        [Fact]
        public void CreateNone_Struct_NoneInstance()
        {
            // Act
            var option = Option<int>.CreateNone();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<int>>(option);
        }

        [Fact]
        public void CreateNone_Record_NoneInstance()
        {
            // Act
            var option = Option<DummyRecord>.CreateNone();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecord>>(option);
        }

        [Fact]
        public void CreateNone_RecordStruct_NoneInstance()
        {
            // Act
            var option = Option<DummyRecordStruct>.CreateNone();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecordStruct>>(option);
        }

        private class DummyClass
        {
            public int SomeValue { get; init; }

            public DummyClass(int someValue)
            {
                SomeValue = someValue;
            }
        }

        private record DummyRecord
        {
            public int SomeValue { get; init; }

            public DummyRecord(int someValue)
            {
                SomeValue = someValue;
            }
        }

        private readonly record struct DummyRecordStruct
        {
            public int SomeValue { get; init; }

            public DummyRecordStruct(int someValue)
            {
                SomeValue = someValue;
            }
        }
    }
}