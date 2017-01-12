module ActivePatterns

let (|Even|Odd|) anumber = if anumber % 2 = 0 then Even else Odd

let TestEvenNumber anumber =
    match anumber with
    | Odd -> "Odd number"
    | Even -> "Even number"
