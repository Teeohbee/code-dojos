#Natural Sorting

Take a list of strings like this: 

`"Z1", "Z54", "Z110", "Z207", "Z33"`

Sorted by ASCII, they would come out as: 

`"Z1", "Z110", "Z207", "Z33", "Z54"`

Sorted naturally, they would come out as:

`"Z1", "Z33", "Z54", "Z110", "Z207"`

Basically, this is sorting on *alphanumeric* order instead of ASCII order, which is different.

This is such a common problem, and yet most programming platforms do not have a native or standard solution.

Your task is to create a string sort that will sort any arbitrary list of strings in natural order. The string can be in any format and will not necessarily be in the format given above, which is just an example to illustrate the problem.
