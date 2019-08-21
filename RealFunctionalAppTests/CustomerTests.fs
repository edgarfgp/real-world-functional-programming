namespace RealFunctionalApp.Tests

open NUnit.Framework

[<TestFixture>]
type CustomerTests() =

    [<SetUp>]
    member this.Setup() =
        ()

    [<Test>]
    member this.Test1() =
        Assert.AreEqual(3, 3)
