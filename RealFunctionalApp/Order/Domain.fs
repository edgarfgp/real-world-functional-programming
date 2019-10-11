namespace Order

module Domain =

    [<Measure>] type Euro
    [<Measure>] type GBP
    
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
    
        //https://stackoverflow.com/questions/13567081/creating-a-list-with-multiple-units-of-measurements-of-floats-in-f
        //Thank you Tomas Petricek!
        type Currency =
        | Euros of decimal<Euro>
        | BritishPounds of decimal<GBP> 
        
            static member (+) (x,y) =
                match x, y with
                | (Euros a, Euros b) -> Euros (a + b)
                | (BritishPounds a, Euros b) -> BritishPounds (a + eurosToPounds 7 b)
                | (Euros a, BritishPounds b) -> Euros (a + poundsToEuros 7 b)
                | (BritishPounds a, BritishPounds b) -> BritishPounds (a+b)
        
        
    type Customer =
        { Name: string
          Surname: string
          Gender: Gender
          Active: bool
          Address: Address
          Total: Currency
          Discount: Currency option } with
        
        member this.FullName = 
            this.Name + " " + this.Surname
