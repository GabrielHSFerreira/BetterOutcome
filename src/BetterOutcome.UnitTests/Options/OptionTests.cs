namespace BetterOutcome.UnitTests.Options
{
    public class OptionTests
    {
        [Fact]
        public void CreateSome_ClassInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyClass(10);

            // Act
            var option = Some<DummyClass>.Create(value);

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
            var option = Some<int>.Create(value);

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
            var option = Some<DummyRecord>.Create(value);

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
            var option = Some<DummyRecordStruct>.Create(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyRecordStruct>>(option);
        }

        [Fact]
        public void CreateNone_Class_NoneInstance()
        {
            // Act
            var option = None<DummyClass>.Create();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyClass>>(option);
        }

        [Fact]
        public void CreateNone_Struct_NoneInstance()
        {
            // Act
            var option = None<int>.Create();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<int>>(option);
        }

        [Fact]
        public void CreateNone_Record_NoneInstance()
        {
            // Act
            var option = None<DummyRecord>.Create();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecord>>(option);
        }

        [Fact]
        public void CreateNone_RecordStruct_NoneInstance()
        {
            // Act
            var option = None<DummyRecordStruct>.Create();

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecordStruct>>(option);
        }

        [Fact]
        public void CreateFromValue_ClassInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyClass(10);

            // Act
            var option = Option<DummyClass>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyClass>>(option);
        }

        [Fact]
        public void CreateFromValue_StructInstance_SomeInstance()
        {
            // Arrange
            int value = 10;

            // Act
            var option = Option<int>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<int>>(option);
        }

        [Fact]
        public void CreateFromValue_RecordInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyRecord(10);

            // Act
            var option = Option<DummyRecord>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyRecord>>(option);
        }

        [Fact]
        public void CreateFromValue_RecordStructInstance_SomeInstance()
        {
            // Arrange
            var value = new DummyRecordStruct(10);

            // Act
            var option = Option<DummyRecordStruct>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<Some<DummyRecordStruct>>(option);
        }

        [Fact]
        public void CreateFromValue_Class_NoneInstance()
        {
            // Arrange
            DummyClass? value = null;

            // Act
            var option = Option<DummyClass>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyClass>>(option);
        }

        [Fact]
        public void CreateFromValue_Struct_NoneInstance()
        {
            // Arrange
            int? value = null;

            // Act
            var option = Option<int>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<int>>(option);
        }

        [Fact]
        public void CreateFromValue_Record_NoneInstance()
        {
            // Arrange
            DummyRecord? value = null;

            // Act
            var option = Option<DummyRecord>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecord>>(option);
        }

        [Fact]
        public void CreateFromValue_RecordStruct_NoneInstance()
        {
            // Arrange
            DummyRecordStruct? value = null;

            // Act
            var option = Option<DummyRecordStruct>.CreateFromValue(value);

            // Assert
            Assert.NotNull(option);
            Assert.IsType<None<DummyRecordStruct>>(option);
        }

        [Fact]
        public void SomeEquality_SameStructTypeAndValue_Equal()
        {
            // Arrange
            var someA = Some<int>.Create(10);
            var someB = Some<int>.Create(10);

            // Act
            var areEqual = someA.Equals(someB);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SomeEquality_DifferentStructTypeAndValue_NotEqual()
        {
            // Arrange
            var someA = Some<decimal>.Create(10.500M);
            var someB = Some<int>.Create(5000);

            // Act
            var areEqual = someA.Equals(someB);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void SomeEquality_DifferentStructTypeAndSameValue_NotEqual()
        {
            // Arrange
            var someA = Some<decimal>.Create(5000);
            var someB = Some<int>.Create(5000);

            // Act
            var areEqual = someA.Equals(someB);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void SomeEquality_SameReferenceTypeAndValue_Equal()
        {
            // Arrange
            var value = new DummyClass(10);
            var someA = Some<DummyClass>.Create(value);
            var someB = Some<DummyClass>.Create(value);

            // Act
            var areEqual = someA.Equals(someB);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void SomeEquality_DifferentReferenceTypeAndValue_NotEqual()
        {
            // Arrange
            var someA = Some<DummyClass>.Create(new DummyClass(10));
            var someB = Some<string>.Create("Test");

            // Act
            var areEqual = someA.Equals(someB);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void NoneEquality_SameType_Equal()
        {
            // Arrange
            var noneA = None<int>.Create();
            var noneB = None<int>.Create();

            // Act
            var areEqual = noneA.Equals(noneB);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void NoneEquality_DifferentType_NotEqual()
        {
            // Arrange
            var noneA = None<int>.Create();
            var noneB = None<string>.Create();

            // Act
            var areEqual = noneA.Equals(noneB);

            // Assert
            Assert.False(areEqual);
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