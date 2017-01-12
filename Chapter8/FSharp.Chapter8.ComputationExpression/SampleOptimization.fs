module SampleOptimization

// without delay method
type ComputeExpression1Builder() =
  /// Combine two values
  /// sm.Combine («cexpr1», b.Delay(fun () -> «cexpr2»))
  member sm.Combine(a,b) = a + b
  /// Zero value
  /// sm.Zero()
  member sm.Zero() = 0
  /// Return a value 
  /// sm.Yield expr
  member sm.Yield(a) = a

// Add delay method
type ComputeExpression2Builder() =
  /// Combine two values
  /// sm.Combine («cexpr1», b.Delay(fun () -> «cexpr2»))
  member sm.Combine(a,b) = a + b
  /// Zero value
  /// sm.Zero()
  member sm.Zero() = 0
  /// Return a value 
  /// sm.Yield expr
  member sm.Yield(a) = a
  /// Delay a computation
  /// sm.Delay (fun () -> «cexpr»))
  member sm.Delay f = f()