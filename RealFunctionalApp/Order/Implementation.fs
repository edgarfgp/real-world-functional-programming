﻿namespace Order

open Domain
//open Data

module Implementation =

//    let (|ActiveCustomer|InactiveCustomer|) customer =
//        if customer.Active then ActiveCustomer
//        else InactiveCustomer
//
//    let getActiveCustomer customer =
//        match customer with
//        | ActiveCustomer -> true
//        | InactiveCustomer -> false
//
//    let getCustomerFromLocation location customer =
//        customer.Address.City = location
//
//    let getCustomerByTotal billTotal customer =
//        customer.Total > billTotal
//
//    let getCustomerAddresses customer =
//        customer.Address
//
//    let updateDiscountCustomer discountIncrease customer =
//        if customer.Total >= 20.0M<Euro> && customer.Total <= 50.0M<Euro> then
//            { customer with Discount = discountIncrease }
//        else
//            customer
//
//    let getCustomersBillTotal state customer =
//        if customer.Total > 0.0M<Euro> then
//            state + customer.Total
//        else
//            state
//
//    let getCustomersFullName customer =
//        let formattedName = customer.Name + " " + customer.Surname
//        let fullName = Option.defaultValue formattedName customer.FullName
//        { customer with FullName = Some fullName }
//
//    let addDefaultDiscount customer =
//         let discount = Option.defaultValue 0.5M<Euro> customer.Discount
//         { customer with Discount = Some discount }
//
//    let showCustomersWithDefaultDiscount customer =
//        customer.Discount
//            |> Option.map (fun _ -> customer.FullName.Value.ToUpper())
//            |> Option.iter (fun discount -> printfn "FullName: %A\n Discount: %A" customer.FullName discount)
//
//    let customersWithDefaultDiscount =
//        List.map (getCustomersFullName >> showCustomersWithDefaultDiscount) customers
//
//    let customerState = 0.0M<Euro>
//
//    let customerResult =
//        (List.map (getCustomersFullName >> addDefaultDiscount) (customers
//        |> List.filter getActiveCustomer))
//        |> List.fold getCustomersBillTotal customerState

    let filterAndCount filterFunc list =
        list
        |> Seq.filter filterFunc
        |> Seq.length
    
    let customerCountByGender gender customers =
        customers
        |> filterAndCount (fun customer -> customer.Gender = gender)
    
    let customersCountByCountry country customers =
        customers
        |> filterAndCount (fun customer -> customer.Address.Country = country)
        
    let customersCountByCity city customers =
        customers
        |> filterAndCount (fun customer -> customer.Address.City = city) 
        
//    let rec private totalSpendOf total (customers:Customer list) : Currency =
//        match customers with
//        | [] -> total
//        | head :: tail -> totalSpendOf (total + head.Total) tail 
        
    let totalSpend customers =
        customers
        |> List.fold (fun total customer -> total + customer.Total) 0.0M<Euro>
//        |> totalSpendOf 0.0M<Euro> //removed to avoid stack overflow issues
        