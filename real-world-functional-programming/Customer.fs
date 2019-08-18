namespace real_world_functional_programming

module Domain =

    type Customer =
        { Name: string
          Surname: string
          FullName: string option
          Active: bool
          Address: Address
          Total: Currency
          Discount: Currency option }
    and Address =
        { Street: string
          Town: string
          City: City
          PostalCode: string
          Country: Country }
    and  [<Measure>] Euro
    and Currency = decimal<Euro>
    and Country = | Spain | UK | France
    and City = | London | Madrid | Paris

module CustomerLogic =
    open Domain
    let customers = [
        { Name = "Edgar"; Surname = "Gonzalez"; FullName = None; Active = true; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
          Address = { Street = "Kendal House"; Town = "Islington"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Oscar"; Surname = "Gonzalez"; FullName = None; Active = false; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
          Address = { Street = "Kendal House"; Town = "Getafe"; City = Madrid; Country = Spain; PostalCode = "N19DE" } }

        { Name = "Manuel"; Surname = "Gonzalez"; FullName = None; Active = true; Total = 05.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "District 1"; City = Paris; Country = France; PostalCode = "N19DE" } }

        { Name = "Madelin"; Surname = "Gonzalez"; FullName = None; Active = false; Total = 05.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Alba"; Surname = "Gonzalez"; FullName = None; Active = true; Total = 25.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = Madrid; Country = Spain; PostalCode = "N19DE" } }

        { Name = "Eleni"; Surname = "Gonzalez"; FullName = None; Active = false; Total = 25.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Juan"; Surname = "Gonzalez"; FullName = None; Active = true; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
         Address = { Street = "Kendal House"; Town = "Angel"; City = Paris; Country = France; PostalCode = "N19DE" } }

        { Name = "Juan"; Surname = "Gonzalez"; FullName = None; Active = false; Total = 05.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = Paris; Country = France; PostalCode = "N19DE" } }
     ]

    let (|ActiveCustomer|InactiveCustomer|) customer =
        if customer.Active then ActiveCustomer
        else InactiveCustomer

    let getActiveCustomer customer =
        match customer with
        | ActiveCustomer -> true
        | InactiveCustomer -> false

    let getCustomerFromLocation location customer =
        if customer.Address.City = location then true
        else false

    let getCustomerByTotal billTotal customer =
        if customer.Total > billTotal then true
        else false

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
            |> Option.iter (fun discount -> printfn "FullName: %A\n Discount: %A" customer.FullName discount)

    let customersWithDefaultDiscount =
        customers
        |> List.map addDefaultDiscount
        |> List.map showCustomersWithDefaultDiscount

    let customerState = 0.0M<Euro>

    let customerResult =
        customers
        |> List.filter getActiveCustomer
        |> List.map getCustomersFullName
        |> List.map addDefaultDiscount
        |> List.fold getCustomersBillTotal customerState
