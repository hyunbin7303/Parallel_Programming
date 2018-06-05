# Parallel_Programming
Parallel Programming 

Reference : http://www.bogotobogo.com/cplusplus/files/CplusplusConcurrencyInAction_PracticalMultithreading.pdf     
Book : C++ Concurrency in Action     
## Running threads in the background
Detached threads truly run in the background.
Ownership and control are passed over to the C++ Run-time library, which ensures that the
resources associated with the thread are correctly reclaimed when the thread exits.     



-----------------------------------------
By default, the arguments are copied into internal storage, where they can be accessed
by the newly created thread of execution, even if the corresponding parameter in the function
is expecting a reference. 
