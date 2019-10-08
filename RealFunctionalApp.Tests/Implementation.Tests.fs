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
     
//[<Fact>]
//let ``Returns Total number of customers, regardless of City`` () =
//     Data.customers
//     |> Implementation.customersCountByCity None
//     |> should equal 8
//     
//[<Fact>]
//let ``Returns Total number of customers, regardless of Country`` () =
//     Data.customers
//     |> Implementation.customersCountByCountry None
//     |> should equal 8
     
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
     
[<Fact>]
let ``Return total spend for all customers`` () =
     Data.customers
     |> Implementation.totalSpend
     |> should equal 80.0M<Euro> 