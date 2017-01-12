module InlineFunctions

let inline inlinemul a b = a * b

let inline (^*) a b = a * b

let MulDoubleTest = inlinemul 5.2 10.7

let MulIntTest = inlinemul 5 12

let InlineOpMultiplyTest = 6 ^* 10

