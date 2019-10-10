module RealFunctionalApp.Tests.Implementation.Tests

open FsUnit.Xunit
open Xunit
open Order
open Order.Domain

[<Fact>]
let ``Returns count of customers from England`` () =
     Data.customers
     |> Implementation.customersCountByCountry UK
     |> should equal 3 

[<Fact>]
let ``Returns count of customers from London`` () =
     Data.customers
     |> Implementation.customersCountByCity London 
     |> should equal 3
     
[<Fact>]
let ``Convert Pounds to Euros`` () =
     05.0M<GBP>
     |> Order.Domain.poundsToEuros 2
     |> should equal 5.56M<Euro>

[<Fact>]
let ``Convert to Pounds`` () =
     05.0M<Euro>
     |> Order.Domain.eurosToPounds 2
     |> should equal 4.50M<GBP>
     
[<Fact>]
let ``Return Count of Male Customers`` () =
     Data.customers
     |> Implementation.customerCountByGender Male
     |> should equal 4
     
[<Fact>]
let ``Return Count of Female Customers`` () =
     Data.customers
     |> Implementation.customerCountByGender Female
     |> should equal 3
     
     
[<Fact>]
let ``Return Count of Unspecified Customers`` () =
     Data.customers
     |> Implementation.customerCountByGender Unspecified
     |> should equal 1
     
//[<Fact>]
//let ``Return total spend for all customers`` () =
//     Data.customers
//     |> Implementation.totalSpend
//     |> should equal 80.0M<Euro> 