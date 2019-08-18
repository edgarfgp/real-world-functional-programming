namespace Tests

open NUnit.Framework
open real_world_functional_programming.CustomerLogic

[<TestFixture>]
type CustomerTests() =

    [<SetUp>]
    member this.Setup() =
        ()

    [<Test>]
    member this.Test1() =
        let result = SumTwoNumbers 1 2
        Assert.AreEqual(3, result)
