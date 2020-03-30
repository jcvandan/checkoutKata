# Sorted Checkout Kata

## Design

I've tried to make the design as loosely coupled as possible. I've used a design that will allow easy addition of new multiple item discounts, and even brand new discount types (e.g. 3 for 2 etc) without changing any of the existing code.

## Outstanding issues

The `MultipleItemDiscount` class doesn't apply discount for multiples of the specified quantity. E.g. if you pass it 6 apples, it will only apply the discount to 3 apples then a total of the remainder. Something a bit cleverer could be done using modulo & divison operators but I thought I had done enough and had hit the 60 minute time limit.

The `Checkout.Total` method could maybe do with a bit of tidying, there's a bit more indenting than I usually like but again considering the scope of the task and the time limit I've left it.