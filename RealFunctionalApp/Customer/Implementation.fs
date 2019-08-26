namespace RealFunctionalApp

open Customer.Data
open Customer.Domain

module BusinessImplementation =

    let (|ActiveCustomer|InactiveCustomer|) customer =
        if customer.Active then ActiveCustomer
        else InactiveCustomer

    let getActiveCustomer customer =
        match customer with
        | ActiveCustomer -> true
        | InactiveCustomer -> false

    let getCustomerFromLocation location customer =
        customer.Address.City = location

    let getCustomerByTotal billTotal customer =
        customer.Total > billTotal

    let getCustomerAddresses customer =
        customer.Address

    let updateDiscountCustomer discountIncrease customer =
        if customer.Total >= 20.0M<Euro> && customer.Total <= 50.0M<Euro> then
            { customer with Discount = discountIncrease }
        else
            customer

    let getCustomersBillTotal state customer =
        if customer.Total > 0.0M<Euro> then
            state + customer.Total
        else
            state

    let getCustomersFullName customer =
        let formattedName = customer.Name + " " + customer.Surname
        let fullName = Option.defaultValue formattedName customer.FullName
        { customer with FullName = Some fullName }

    let addDefaultDiscount customer =
         let discount = Option.defaultValue 0.5M<Euro> customer.Discount
         { customer with Discount = Some discount }

    let showCustomersWithDefaultDiscount customer =
        customer.Discount
            |> Option.map (fun _ -> customer.FullName.Value.ToUpper())
            |> Option.iter (fun discount -> printfn "FullName: %A\n Discount: %A" customer.FullName discount)

    let customersWithDefaultDiscount =
        List.map (getCustomersFullName >> showCustomersWithDefaultDiscount) customers

    let customerState = 0.0M<Euro>

    let customerResult =
        customers
        |> List.filter getActiveCustomer
        |> List.map getCustomersFullName
        |> List.map addDefaultDiscount
        |> List.fold getCustomersBillTotal customerState
