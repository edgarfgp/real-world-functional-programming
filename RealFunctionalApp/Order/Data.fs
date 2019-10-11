namespace Order

open Domain

module Data =
   
    let customers = [
        {
        Name = ""
        Surname = "Gonzalez"
        Active = false
        Gender = Female
        Total =    BritishPounds 05.0M<GBP>
        Discount = Some (BritishPounds 0.0M<GBP>)
        Address = {
            Street = "Kendal House"
            Town = "Angel"
            City = London
            Country = UK
            PostalCode = "N19DE" }}
        {
          Name = "Edgar"
          Surname = "Gonzalez"
          Active = true
          Gender = Male
          Total =    BritishPounds 05.0M<GBP>
          Discount = Some (BritishPounds 0.0M<GBP>)
          Address = {
                      Street = "Kendal House"
                      Town = "Islington"
                      City = London
                      Country = UK
                      PostalCode = "N19DE" }}
        {
          Name = "Eleni"
          Surname = "Gonzalez"
          Active = false
          Gender = Female
          Total =    BritishPounds 25.0M<GBP>
          Discount = Some (BritishPounds 0.0M<GBP>)
          Address =
              { Street = "Kendal House"
                Town = "Angel"
                City = London
                Country = UK
                PostalCode = "N19DE" } }
        {
            Name = "Oscar"
            Surname = "Gonzalez"
            Active = false
            Gender = Male
            Total =    Euros 05.0M<Euro>
            Discount = Some (Euros 0.0M<Euro>)
            Address = {
                Street = "Kendal House"
                Town = "Getafe"
                City = Madrid
                Country = Spain
                PostalCode = "N19DE" }}
        {
            Name = "Manuel"
            Surname = "Gonzalez"
            Active = true
            Gender = Unspecified
            Total =    Euros 05.0M<Euro>
            Discount = Some (Euros 0.0M<Euro>)
            Address =
                { Street = "Kendal House"
                  Town = "District 1"
                  City = Paris
                  Country = France
                  PostalCode = "N19DE" } }
        {
            Name = "Alba"
            Surname = "Gonzalez"
            Active = true
            Gender = Female
            Total =    Euros 25.0M<Euro>
            Discount = Some (Euros 0.0M<Euro>)
            Address =
                { Street = "Kendal House"
                  Town = "Angel"
                  City = Madrid
                  Country = Spain
                  PostalCode = "N19DE" } }
        {
            Name = "Juan"
            Surname = "Gonzalez"
            Active = true
            Gender = Male
            Total =    Euros 05.0M<Euro>
            Discount = Some (Euros 0.0M<Euro>)
            Address = {
                Street = "Kendal House"
                Town = "Angel"
                City = Paris
                Country = France
                PostalCode = "N19DE" } }
        {
              Name = "Juan"
              Surname = "Gonzalez"
              Active = false
              Gender = Male
              Total =    Euros 05.0M<Euro>
              Discount = Some (Euros 0.0M<Euro>)
              Address =
                  { Street = "Kendal House"
                    Town = "Angel"
                    City = Paris
                    Country = France
                    PostalCode = "N19DE" } }
    ]