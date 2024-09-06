INPUT: 34
OUTPUT: 34
This is expected since the regex allows many digits


INPUT: 34.24
OUTPUT: 34.24
This is expected since the regex optionally matches digits and a '.' then digits, to parse floats


INPUT: 34,34
OUTPUT: 34
This is expected since the regex does not allow ',' only '.'