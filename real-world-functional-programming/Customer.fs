namespace real_world_functional_programming

type City =
    | London
    | Madrid
    | NY
    | Paris

type State =
    | Active
    | Inactive

type Currency =
    | Dollar of decimal
    | Euro of decimal
    | Pound of decimal

type Address =
    { Street: string
      Town: string
      City: City }

type Customer =
    { Name: string
      Surname: string
      Active: State
      Address: Address
      Total: Currency
      Discount: decimal }

module Examples =
    let customers = [
        { Name = "Edgar"; Surname = "Gonzalez"; Active = Inactive; Total = Pound 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Islington"; City = London } }

        { Name = "Oscar"; Surname = "Gonzalez"; Active = Active; Total = Euro 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Getafe"; City = Madrid } }

        { Name = "Manuel"; Surname = "Gonzalez"; Active = Inactive; Total = Euro 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "District 1"; City = Paris } }

        { Name = "Madelin"; Surname = "Gonzalez"; Active = Active; Total = Pound 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

        { Name = "Alba"; Surname = "Gonzalez"; Active = Inactive; Total = Euro 25.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = Madrid } }

        { Name = "Carlos"; Surname = "Gonzalez"; Active = Active; Total = Dollar 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = NY } }

        { Name = "Eleni"; Surname = "Gonzalez"; Active = Inactive; Total = Pound 25.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

        { Name = "Pepe"; Surname = "Gonzalez"; Active = Active; Total = Dollar 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = NY } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = Inactive; Total = Euro 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = Paris } }

        { Name = "Juan"; Surname = "Gonzalez"; Active = Active; Total = Euro 05.0M; Discount = 0.0M
          Address = { Street = "Kendal House"; Town = "Angel"; City = Paris } }
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


    let getCustomerAddresses =
        function
        | (_, _, _, address, _, _) -> address

    let updateDiscountCustomer discountIncrease =
        function
        | (name, surname, state, address, total, _) when (total >= 20.0M && total <= 50.0M) ->
            (name, surname, state, address, total, discountIncrease)

        | (name, surname, state, address, total, discount) ->
            (name, surname, state, address, total, discount)

    let customerData =
        customers
        |> List.filter getActiveCustomer
        |> List.filter (getCustomerFromLocation Madrid)
        |> List.filter (getCustomerByTotal (Pound 20.0M))
//        |> List.map (updateDiscountCustomer 10.0M)
//        |> List.map getCustomerAddresses
