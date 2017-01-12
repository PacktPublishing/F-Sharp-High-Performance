
// without delay method
type ComputeExpression1Builder() =
  /// Combine two values
  member sm.Combine(a,b) = a + b
  /// Zero value
  /// sm.Zero()
  member sm.Zero() = 0
  /// Return a value 
  /// sm.Yield expr
  member sm.Yield(a) = a
  /// For loop
  member sm.For(e, f) =
    Seq.fold(fun s x -> sm.Combine(s, f x)) (sm.Zero()) e


// Add delay method
type ComputeExpression2Builder() =
  /// Combine two values
  member sm.Combine(a,b) = a + b
  /// Zero value
  /// sm.Zero()
  member sm.Zero() = 0
  /// Return a value 
  /// sm.Yield expr
  member sm.Yield(a) = a
  /// For loop
  member sm.For(e, f) =
    Seq.fold(fun s x -> sm.Combine(s, f x)) (sm.Zero()) e
  /// Delay a computation
  member sm.Delay (f: unit -> int) =
    System.Console.WriteLine("Test") 
    f()

let compute1 = ComputeExpression1Builder()
let computeEx1 x = compute1 { for x in [1 .. x] do yield x * x }
let computeEx1Result = computeEx1 50

let compute2 = ComputeExpression2Builder()
let computeEx2 x = compute2 { for x in [1 .. x] do yield x * x }
let computeEx2Result = computeEx2 50