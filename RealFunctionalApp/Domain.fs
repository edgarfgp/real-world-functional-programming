namespace RealFunctionalApp

module Domain =

    [<Measure>] type Euro
    
        type Currency = decimal<Euro>
    
        type Country = | Spain | UK | France
    
        type City = | London | Madrid | Paris
    
        type Address =
            { Street: string
              Town: string
              City: City
              PostalCode: string
              Country: Country }
    
        type Customer =
            { Name: string
              Surname: string
              FullName: string option
              Active: bool
              Address: Address
              Total: Currency
              Discount: Currency option }
    