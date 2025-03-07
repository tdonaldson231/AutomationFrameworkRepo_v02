using Xunit;

// links the fixture to the test collection
[CollectionDefinition("Extent Report Collection")]
public class ExtentReportCollection : ICollectionFixture<ExtentReportsFixture>
{
    
}