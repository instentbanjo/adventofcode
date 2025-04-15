# Bitwise Operation Basics

reference:
https://www.youtube.com/watch?v=igIjGxF2J-w

## AND/(&):

do the bits at the same positon have the same value?1:0

7|6|(7&6)
1|1|1
1|1|1
1|0|0

so 7AND6=6/7&6=6

## Or/(|):

does any bit at the same position have the value of 1?1:0

5|6|(5|6)
1|1|1
0|1|1
1|0|1

so 5OR6=7/5|6=7

## XOR/(^) (Exclusive Or)

are the bits the opposite of eachother?1:0

5|6|(5^6)
1|1|1
0|1|0
1|0|0

so 5XOR6=3/5^6=3

## NOT/(~):

generate the opposite bit foreach position

5|~5
1|0
0|1
1|0

this can result in negative numbers thought, because the first bit of a byte determines weather its positive (0) or negative (1)

5 = 0000 0101
~5 = 1111 1010

in this case, it will count up from -128 (python only?)
1 1 1 1 1 0 1 0  
-128 + 64 + 32 + 16 + 8 + 0 + 2 + 0 = -6

## Left Shift, Right Shift / <<, >>

5
0000 0101 = 5
5<<2
0001 0100 = 20
= 20>>2 = 5
