module SampleFSharpData

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

type NorthwindSchema = SqlDataConnection<"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost">
let nwdb = NorthwindSchema.GetDataContext()

let customer = nwdb.Customers
let customerNameData = 
    query { for c in customer do
            select c.ContactName }

let displayAllCustomerName () =
    for c in customerNameData do
        Console.WriteLine(c)
    ()

let displayCustomerNameStartsWith prefix =
    let customerStartWith =
        query { for c in customer do 
                where (c.ContactName.StartsWith(prefix))
                sortBy c.ContactName
                select c.ContactName}
    for c in customerStartWith do
        Console.WriteLine(c)
    ()
