# async-test
This is a console application to test how async/await can be used in series and in parallel. 
Also, needed to make sure whether the same thread was being used for each of the separate tasks.

Turns out, one can run multiple tasks in parallel and await all of them at the end for better performance, as all the separate tasks will then be running in separate threads.
