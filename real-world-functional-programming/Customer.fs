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

    type State =
        | Active
        | Inactive

    type Currency = decimal<Euro>

    type Address =
        { Street: string
          Town: string
          City: City }

    type Customer =
        { Name: string
          Surname: string
          Active: State
          Country: Country
          Address: Address
          Total: Currency
          Discount: Currency }

module CustomerLogic =
    open Domain
    let customers = [
        { Name = "Edgar"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>;
            Country = UK; Address = { Street = "Kendal House"; Town = "Islington"; City = London } }

        { Name = "Oscar"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>;
          Country = Spain; Address = { Street = "Kendal House"; Town = "Getafe"; City = Madrid } }

        { Name = "Manuel"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>;
          Country = France; Address = { Street = "Kendal House"; Town = "District 1"; City = Paris } }

        { Name = "Madelin"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>;
          Country = UK; Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

        { Name = "Alba"; Surname = "Gonzalez"; Active = Active; Total = 25.0M<Euro>; Discount = 0.0M<Euro>;
          Country = Spain; Address = { Street = "Kendal House"; Town = "Angel"; City = Madrid } }

        { Name = "Eleni"; Surname = "Gonzalez"; Active = Inactive; Total = 25.0M<Euro>; Discount = 0.0M<Euro>;
          Country = UK; Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>;
         Country = France; Address = { Street = "Kendal House"; Town = "Angel"; City = Paris } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
          Country = France; Address = { Street = "Kendal House"; Town = "Angel"; City = Paris } }
     ]

    let (|ActiveCustomer|InactiveCustomer|) customer =
        if customer.Active = Active then ActiveCustomer
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
        if customer.Country = Spain then
            state + customer.Total
        else
            state

    let initState = 0.0M<Euro>

    let totalBillFromSPain = List.fold getCustomerBillTotalFromSpain initState customers

    let customerResult =
        customers
        |> List.filter getActiveCustomer
        |> List.filter (getCustomerFromLocation Madrid)
        |> List.filter (getCustomerByTotal 20.0M<Euro>)
        |> List.map (updateDiscountCustomer 10.0M<Euro>)
        |> List.map getCustomerAddresses
