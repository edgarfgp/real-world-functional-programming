[<Measure>] type Euro

type City =
    | London
    | Madrid
    | NY
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
      Address: Address
      Total: Currency
      Discount: Currency }

let customers = [
    { Name = "Edgar"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Islington"; City = London } }

    { Name = "Oscar"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Getafe"; City = Madrid } }

    { Name = "Manuel"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "District 1"; City = Paris } }

    { Name = "Madelin"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

    { Name = "Alba"; Surname = "Gonzalez"; Active = Active; Total = 25.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = Madrid } }

    { Name = "Carlos"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = NY } }

    { Name = "Eleni"; Surname = "Gonzalez"; Active = Inactive; Total = 25.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = London } }

    { Name = "Pepe"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = NY } }

    { Name = "Juan"; Surname = "Gonzalez"; Active = Inactive; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
      Address = { Street = "Kendal House"; Town = "Angel"; City = Paris } }

    { Name = "Juan"; Surname = "Gonzalez"; Active = Active; Total = 05.0M<Euro>; Discount = 0.0M<Euro>
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


let getCustomerAddresses customer =
    customer.Address

let updateDiscountCustomer discountIncrease customer =
    if customer.Total >= 20.0M<Euro> && customer.Total <= 50.0M<Euro> then
        { customer with Discount = discountIncrease }
    else
        customer

let customerData =
    customers
    |> Seq.filter getActiveCustomer
    |> Seq.filter (getCustomerFromLocation Madrid)
    |> Seq.filter (getCustomerByTotal 20.0M<Euro>)
    |> Seq.map (updateDiscountCustomer 10.0M<Euro>)
    |> Seq.map getCustomerAddresses

customerData
