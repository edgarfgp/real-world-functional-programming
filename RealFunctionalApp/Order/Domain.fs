namespace Order


module Domain =

    [<Measure>] type Euro
    [<Measure>] type GBP
    
    type Currency =
        | Euros of decimal<Euro>
        | BritishPounds of decimal<GBP>
    
    let poundsPerEuro = 0.899761M<GBP/Euro>
    let eurosPerPound = 1.111406M<Euro/GBP>
    
    let round (dp:int) (number:decimal) =
        System.Decimal.Round(number, dp)
    
    let eurosToDecimal (euros:decimal<Euro>) : decimal =
        euros / 1.0M<Euro>
    
    let poundsToDecimal (pounds:decimal<GBP>) : decimal =
        pounds / 1.0M<GBP>
    
    let toEuros number =
        number * 1.0M<Euro>
        
    let toPounds number =
        number * 1.0M<GBP>
    
    let poundsToEuros (dp:int) pounds =
          pounds * eurosPerPound
          |> eurosToDecimal
          |> round dp
          |> toEuros
          
    let eurosToPounds (dp:int) (euros:decimal<Euro>) =
        euros * poundsPerEuro
        |> poundsToDecimal
        |> round dp
        |> toPounds
    
    type Country = | Spain | UK | France

    type City = | London | Madrid | Paris

    type Address =
        { Street: string
          Town: string
          City: City
          PostalCode: string
          Country: Country }

    type Gender =
        | Male
        | Female
        | Unspecified
    
    type Customer =
        { Name: string
          Surname: string
          FullName: string option
          Gender: Gender
          Active: bool
          Address: Address
          Total: Currency
          Discount: Currency option }
