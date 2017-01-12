module LockSample

open System.Threading

let lock (lockobj:obj) anyfunction =
  Monitor.Enter lockobj
  try
    anyfunction()
  finally
    // the code in the finally block will be executed after anyfunction is completely finishing execution. 
    // Therefore we can exit the monitor gracefully.
    Monitor.Exit lockobj

