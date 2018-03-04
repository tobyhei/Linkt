module Helpers
  type ICustomComparison<'a when 'a : equality and 'a : comparison> =
    abstract member ComparisonIdentity : 'a

  let equalsOn<'a, 'T when 'T :> ICustomComparison<'a>> (x : 'T) (yobj : obj) =
    match yobj with
    | :? 'T as y -> x.ComparisonIdentity = y.ComparisonIdentity
    | _ -> false

  let hashOn<'a, 'T when 'T :> ICustomComparison<'a>> (x : 'T) = hash (x.ComparisonIdentity)

  let compareOn<'a, 'T when 'T :> ICustomComparison<'a>> (x : 'T) (yobj : obj) =
    match yobj with
    | :? 'T as y -> compare x.ComparisonIdentity y.ComparisonIdentity
    | _ -> invalidArg "yobj" "cannot compare values of different types"

