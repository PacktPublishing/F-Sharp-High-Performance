module TailcallSample

let rec factorial n = 
    match n with
    | 0 | 1 -> n
    | _ -> n * factorial (n-1)

/// Computes the sum of a list of integers using recursion.
let rec sumList xs =
    match xs with
    | []    -> 0
    | y::ys -> y + sumList ys

/// Computes the greatest common factor of two integers. 
//  Since all of the recursive calls are tail calls, the compiler will turn the function into a loop,
//  which improves performance and reduces memory consumption.
let rec greatestCommonFactor a b = 
    if a = 0 then b
    elif a < b then greatestCommonFactor a (b - a)
    else greatestCommonFactor (a - b) b

let accFactorial x =
    let rec TailCallRecursiveFactorial x acc =
        if x <= 1 then acc
        else TailCallRecursiveFactorial (x - 1) (acc * x)
    TailCallRecursiveFactorial x 1

// very simple sample of function that has tail call recursion optimization
let apply f x = f x