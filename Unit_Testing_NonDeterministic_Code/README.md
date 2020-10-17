# Refactoring non-deterministic code

A quick look at how we can use inversion of control via constructor injection to decouple our code
from state that we do not directly control, like the system clock.  This allows us to test
according to our expectations of the behavior of our logic under controlled external circumstances.
