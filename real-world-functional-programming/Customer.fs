namespace real_world_functional_programming

module Domain =
    [<Measure>] type Euro

    type Country =
        | Spain
        | UK
        | France

    type City =
        | London
        | Madrid
        | Paris

    type Currency = decimal<Euro>

    type Address =
        { Street: string
          Town: string
          City: City
          PostalCode: string
          Country: Country }

    type Customer =
        { Name: string
          Surname: string
          Active: bool
          Address: Address
          Total: Currency
          Discount: Currency option }

module CustomerLogic =
    open Domain
    let customers = [
        { Name = "Edgar"; Surname = "Gonzalez"; Active = true; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
          Address = { Street = "Kendal House"; Town = "Islington"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Oscar"; Surname = "Gonzalez"; Active = false; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
          Address = { Street = "Kendal House"; Town = "Getafe"; City = Madrid; Country = Spain; PostalCode = "N19DE" } }

        { Name = "Manuel"; Surname = "Gonzalez"; Active = true; Total = 05.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "District 1"; City = Paris; Country = France; PostalCode = "N19DE" } }

        { Name = "Madelin"; Surname = "Gonzalez"; Active = false; Total = 05.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Alba"; Surname = "Gonzalez"; Active = true; Total = 25.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = Madrid; Country = Spain; PostalCode = "N19DE" } }

        { Name = "Eleni"; Surname = "Gonzalez"; Active = false; Total = 25.0M<Euro>; Discount = None;
          Address = { Street = "Kendal House"; Town = "Angel"; City = London; Country = UK; PostalCode = "N19DE" } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = true; Total = 05.0M<Euro>; Discount = Some 0.0M<Euro>;
         Address = { Street = "Kendal House"; Town = "Angel"; City = Paris; Country = France; PostalCode = "N19DE" } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = false; Total = 05.0M<Euro>; Discount = None;
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

    let getCustomerBillTotalFromSpain state customer =
        if customer.Address.Country = Spain then
            state + customer.Total
        else
            state

    let initState = 0.0M<Euro>

    let totalBillFromSPain = List.fold getCustomerBillTotalFromSpain initState customers

    let getCustomersFullName customer =
        customer.Name + " " + customer.Surname

    let customerFullNames =
        customers
        |> List.map getCustomersFullName

    let customerResult =
        customers
        |> List.filter getActiveCustomer
        |> List.filter (getCustomerFromLocation Madrid)
        |> List.filter (getCustomerByTotal 20.0M<Euro>)
        |> List.map (fun c -> Option.defaultValue 0.50M<Euro> c.Discount)
