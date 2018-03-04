namespace Link.Domain

open System
open Helpers

[<CustomEquality; CustomComparison>]
type Link =
  { Id : Guid
    CollectionId : Guid
    Url: string 
    Description : string
    Timestamp : DateTime }

  interface ICustomComparison<Guid> with member x.ComparisonIdentity = x.Id

  override x.Equals y = equalsOn x y
  override x.GetHashCode() = hashOn x
  interface System.IComparable with
    member x.CompareTo y = compareOn x y

[<CustomEquality; CustomComparison>]
type User =
  { 
    Id : Guid
    FirstName : string
    LastName : string
    Email : string
    Links : Link Set
  }

  interface ICustomComparison<Guid> with member x.ComparisonIdentity = x.Id

  override x.Equals y = equalsOn x y
  override x.GetHashCode() = hashOn x
  interface System.IComparable with
    member x.CompareTo y = compareOn x y
