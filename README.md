# WTW
This program requires a file named wtw.txt at C:\Venkat, i.e., C:\Venkat\wtw.txt.
This file contains the input to the program & needs to be in the correct format.
e.g.,
Product, Origin Year, Development Year, Incremental Value
Comp, 1992, 1992, 110.0
Comp, 1992, 1993, 170.0
Comp, 1993, 1993, 200.0
Non-Comp, 1990, 1990, 45.2
Non-Comp, 1990, 1991, 64.8
Non-Comp, 1990, 1993, 37.0
Non-Comp, 1991, 1991, 50.0
Non-Comp, 1991, 1992, 75.0
Non-Comp, 1991, 1993, 25.0
Non-Comp, 1992, 1992, 55.0
Non-Comp, 1992, 1993, 85.0
Non-Comp, 1993, 1993, 100.0

If the file format & expected data is correct, then the o/p is generated as below:
1990, 4
Comp, 0, 0, 0, 0, 0, 0, 0, 110, 280, 200
Non-Comp, 45.2, 110, 110, 147, 50, 125, 150, 55, 140, 100

NOTE: Year is not checked for if it is a valid year, only checking for numeric in the program. Also, there may be an extra line in the o/p.
