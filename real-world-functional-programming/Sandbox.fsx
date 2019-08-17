type City = | London | Madrid | NY | Paris

type State = | Active | Inactive

type Currency =
    | Dollar of decimal
    | Euro of decimal
    | Pound of decimal

type Address = Address of Street: string * Town: string * City: City

type Customer = Customer of Name: string * Surname: string * Active: bool * Address: Address * Total: Currency * Discount: decimal

let customers = [
    ("Edgar", "Gonzalez", Inactive, ("Kendal House", "Islington", London), 05.0M, 0.0M)
    ("Manuel", "Doe", Active, ("Kendal House", "Islington", Madrid), 10.0M, 0.0M)
    ("Madelin", "Brexit", Inactive, ("Kendal House", "Islington", NY), 15.0M, 0.0M)
    ("Dario", "Juarez", Active, ("Kendal House", "Islington", London), 20.0M, 0.0M)
    ("Juan", "Perez", Active, ("Kendal House", "Islington", Madrid), 30.0M, 0.0M)
    ("Yeray", "Valdez", Active, ("Kendal House", "Islington", NY), 40.0M, 0.0M)
    ("Marco", "Grimaldi", Active, ("Kendal House", "Islington", Paris), 50.0M, 0.0M)
    ("Luis", "Suarez", Active, ("Kendal House", "Islington", Madrid), 40.0M, 0.0M)
    ("Myles", "Martins", Active, ("Kendal House", "Islington", NY), 25.0M, 0.0M)
    ("Liv", "Bale", Active, ("Kendal House", "Islington", London), 13.0M, 0.0M)
    ("Dan", "Cooper", Active, ("Kendal House", "Islington", Madrid), 08.0M, 0.0M)
    ("Diego", "Jonson", Inactive, ("Kendal House", "Islington", NY), 0.0M, 0.0M)
    ("Aurelio", "Jimenez", Inactive, ("Kendal House", "Islington", London), 0.0M, 0.0M)
 ]

let (|ActiveCustomer|_|) customer =
    match customer with
    | (_, _, active, (_, _, _), _, _) ->
        match active with
        | Active -> Some ActiveCustomer
        | Inactive -> None

let getActiveUsers customer =
    match customer with
    | ActiveCustomer -> true
    | _ -> false

let getCustomerFromLocation location =
    function
    | (_, _, _, (_, _, city), _, _) when city = location -> true
    | _ -> false


let getCustomerByTotal billTotal =
   function
        | (_, _, _, _, total, _) when total > billTotal -> true
        | _ -> false

let getCustomerAddresses customer =
    match customer with
    | (_, _, _, address, _, _) -> address

let updateDiscountCustomer discountIncrease =
    function
    | (name, surname, state, address, total, _) when (total >= 20.0M && total <= 50.0M) ->
        (name, surname, state, address, total, discountIncrease)

    | (name, surname, state, address, total, discount) ->
        (name, surname, state, address, total, discount)

let customerData =
    customers
    |> List.filter getActiveUsers
    |> List.filter (getCustomerFromLocation Madrid)
    |> List.filter (getCustomerByTotal 13.0M)
    |> List.map (updateDiscountCustomer 10.0M)
    |> List.map getCustomerAddresses
