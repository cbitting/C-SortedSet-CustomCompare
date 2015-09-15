# C-SortedSet-CustomCompare
C# - Using SortedSet as a sorted list with custom comparer

Sometimes you have a list of objects you want to stay sorted. You can usually use an IList and then linq: orderby to sort the list – but other times it helps to have the list always sorted. In those times, SortedSet works very well. In my below example, a sorted set contains some people – and whenever you look at the list in the SortedSet – they are already sorted (by age, name & location).

I was concerned about the performance of the SortedSet vs. a List, so after running some tests, as expected – the SortedSet needs some initial time when adding items (to compare) vs. the List which will is fast to write to – but needs a little time when sorting the list after. 
